using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using RTCSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes.ProjectFunctions
{
    public static partial class cProjectFunctions
    {
        #region OTHER FUNCTIONS

        public static cProjectTypes LoadProjectFromFolder(string folder)
        {
            ProjectData projectData = null;
            try
            {
                cProjectTypes project = new cProjectTypes
                {
                    FolderNameFullPath = folder,
                    FolderNameFullPathBAK = folder
                };
                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                project.FolderName = directoryInfo.Name;
                project.FileName = folder + Path.DirectorySeparatorChar + project.FolderName + cExtFile.ProjD;
                project.FileNameBAK = project.FileName + cExtFile.BAKD;

                if (!File.Exists(project.FileName))
                    return null;
                project.OriginPositionImageViewFolder = project.FolderNameFullPath + Path.DirectorySeparatorChar + "OriginPositionImageView";
                project.RealPositionImageViewFolder = project.FolderNameFullPath + Path.DirectorySeparatorChar + "RealPositionImageView";

                if (!Directory.Exists(project.OriginPositionImageViewFolder))
                {
                    try
                    {
                        Directory.CreateDirectory(project.OriginPositionImageViewFolder);
                    }
                    catch
                    {

                    }
                }
                if (!Directory.Exists(project.RealPositionImageViewFolder))
                    try
                    {
                        Directory.CreateDirectory(project.RealPositionImageViewFolder);
                    }
                    catch
                    {

                    }
                projectData = new ProjectData();
                if (!projectData.Connect(project.FileName))
                    return null;
                //Đọc thông tin của project
                if (!projectData.OpenProject_GetProjectInfo(project))
                    return null;
                //Đọc thông số của project
                if (!projectData.OpenProject_GetProjectSettings(project))
                    return null;
                if (!projectData.OpenProject_GetCAMs(project, true))
                    return null;

                project.OldFileName = project.FileName;
                return project;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (projectData != null)
                    projectData.Disconnect();
                projectData = null;
            }
        }
        public static bool SaveProject(cProjectTypes project, Guid camId, ESaveMode saveMode = ESaveMode.Project, bool isShowWaitForm = true)
        {
            try
            {
                ProjectData projectData = new ProjectData();
                if (isShowWaitForm)
                    GlobFuncs.ShowWaitForm("Saving Project...");
                project.FolderNameFullPathBAK = project.FolderNameFullPath;
                var result = projectData.SaveProject_Prepare(project);
                if (result) result = projectData.SaveProject_ProjectSettings_Connect(project);
                switch (saveMode)
                {
                    case ESaveMode.ProjectSettings:
                        if (result) result = projectData.SaveProject_ClearAllData_ProjectSettings();
                        if (result) result = projectData.SaveProject_ProjectSettings(project);
                        if (result) result = projectData.SaveProject_TrayReSult_Settings(project);
                        if (result) result = projectData.SaveProject_TrayReSult_ProgramName(project);
                        if (result) result = projectData.SaveProject_RunningTemplate(project);
                        if (result) result = projectData.SaveProject_RunningTemplateDetail(project);
                        break;
                    case ESaveMode.OneCam:
                        if (result) result = projectData.SaveProject_OneCam(project, camId);
                        break;
                    case ESaveMode.AllCam:
                        if (result) projectData.SaveProject_CAMs(project);
                        break;
                    case ESaveMode.Project:
                        if (result) result = projectData.SaveProject_ClearAllData_ProjectSettings();
                        if (result) result = projectData.SaveProject_ProjectSettings(project);
                        if (result) result = projectData.SaveProject_TrayReSult_Settings(project);
                        if (result) result = projectData.SaveProject_TrayReSult_ProgramName(project);
                        if (result) result = projectData.SaveProject_RunningTemplate(project);
                        if (result) result = projectData.SaveProject_RunningTemplateDetail(project);
                        if (result) projectData.SaveProject_CAMs(project);

                        project.DataChange = !result;
                        break;
                    default:
                        break;
                }

                if (result)
                    projectData.MyConn.Commit();
                projectData.Disconnect();
                if (project.OldFileName != project.FileName)
                {
                    try
                    {
                        File.Delete(project.OldFileName);
                    }
                    catch
                    {

                    }
                }
                project.OldFileName = project.FileName;

                return result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
            finally
            {
                if (isShowWaitForm)
                    GlobFuncs.CloseWaitForm();
            }
        }

        public static void DeleteProject(ref cProjectTypes project)
        {
            try
            {
                if (project == null) return;

                foreach (cCAMTypes cam in project.CAMs.Values)
                {
                    if (cam.View != null)
                    {
                        cam.View.Dock = DockStyle.None;
                        cam.View.Dispose();
                    }
                }

                GlobVar.DicProjects.Remove(project.ID);
                GlobVar.DataTableProjects.Rows.Remove(GlobVar.DataTableProjects.Rows.Find(project.ID));

                if (Directory.Exists(project.FolderNameFullPath))
                    try
                    {
                        Directory.Delete(project.FolderNameFullPath, true);
                    }
                    catch (Exception ex)
                    {
                        GlobFuncs.SaveErr(ex);
                    }

                project = null;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public static bool SaveProject_OnlyCounter(cProjectTypes project)
        {
            bool result = false;
            ProjectData projectData = new ProjectData();
            try
            {

                result = projectData.SaveProject_ProjectSettings_Connect(project);
                if (!projectData.MyConn.IsConnected)
                    return false;

                int count = projectData.MyConn.ExecuteScalar_Int(
                    "SELECT COUNT(PropName) FROM ProjectSettings WHERE PropName='TotalCount'");
                if (count != 0)
                    projectData.MyConn.ExecuteQuery($"UPDATE " + cTableName_SaveTemplate.ProjectSettings +
                                                    $" SET ValueI={project.TotalCount} WHERE PropName='TotalCount'");
                else
                    projectData.MyConn.ExecuteQuery($"INSERT INTO " + cTableName_SaveTemplate.ProjectSettings +
                                                    $"(ProjID,PropName,ValueI) VALUES ('{project.ID.ToString()}','TotalCount',{project.TotalCount})");

                count = projectData.MyConn.ExecuteScalar_Int(
                    "SELECT COUNT(PropName) FROM ProjectSettings WHERE PropName='OKCount'");
                if (count != 0)
                    projectData.MyConn.ExecuteQuery($"UPDATE " + cTableName_SaveTemplate.ProjectSettings +
                                                    $" SET ValueI={project.OKCount} WHERE PropName='OKCount'");
                else
                    projectData.MyConn.ExecuteQuery($"INSERT INTO " + cTableName_SaveTemplate.ProjectSettings +
                                                    $"(ProjID,PropName,ValueI) VALUES ('{project.ID.ToString()}','OKCount',{project.OKCount})");

                count = projectData.MyConn.ExecuteScalar_Int(
                    "SELECT COUNT(PropName) FROM ProjectSettings WHERE PropName='NGCount'");
                if (count != 0)
                    projectData.MyConn.ExecuteQuery($"UPDATE " + cTableName_SaveTemplate.ProjectSettings +
                                                    $" SET ValueI={project.NGCount} WHERE PropName='NGCount'");
                else
                    projectData.MyConn.ExecuteQuery($"INSERT INTO " + cTableName_SaveTemplate.ProjectSettings +
                                                    $"(ProjID,PropName,ValueI) VALUES ('{project.ID.ToString()}','NGCount',{project.NGCount})");

                if (result)
                {
                    projectData.MyConn.Commit();
                    project.DataChange = false;
                }
                projectData.Disconnect();
                return result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                if (projectData.MyConn != null && projectData.MyConn.IsConnected)
                    projectData.MyConn.RollBack();
                return false;
            }
        }

        public static bool SaveProject_OnlySetting(cProjectTypes _Project)
        {
            bool Result = false;
            ProjectData projectData = new ProjectData();
            try
            {
                Result = projectData.SaveProject_ProjectSettings_Connect(_Project);
                if (!projectData.MyConn.IsConnected)
                    return false;
                if (Result) Result = projectData.MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ProjectList);
                if (Result) Result = projectData.MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ProjectSetting);
                if (Result) Result = projectData.MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.TrayResult_Settings);
                if (Result) Result = projectData.MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.TrayResult_ProgramName);
                if (Result) Result = projectData.SaveProject_ProjectSettings(_Project);
                if (Result) Result = projectData.SaveProject_TrayReSult_Settings(_Project);
                if (Result) Result = projectData.SaveProject_TrayReSult_ProgramName(_Project);
                if (Result)
                {
                    projectData.MyConn.Commit();
                    _Project.DataChange = false;
                }
                projectData.Disconnect();
                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                if (projectData.MyConn != null && projectData.MyConn.IsConnected)
                    projectData.MyConn.RollBack();
                return false;
            }
        }
        private static void CreateProjectsDataTable()
        {
            if (GlobVar.DataTableProjects != null)
                return;

            GlobVar.DataTableProjects = new DataTable();
            GlobVar.DataTableProjects.Columns.Add(cColName.ID, typeof(Guid));
            GlobVar.DataTableProjects.Columns.Add(cColName.OrderNum, typeof(int));
            GlobVar.DataTableProjects.Columns.Add(cColName.ProjectName, typeof(string));
            GlobVar.DataTableProjects.Columns.Add(cColName.Note, typeof(string));
            GlobVar.DataTableProjects.Columns.Add(cColName.PreviewImage, typeof(string));
            GlobVar.DataTableProjects.Columns.Add(cColName.Image, typeof(object));
            GlobVar.DataTableProjects.Columns.Add(cColName.Pinned, typeof(bool));

            var keys = new DataColumn[1];
            keys[0] = GlobVar.DataTableProjects.Columns[cColName.ID];
            GlobVar.DataTableProjects.PrimaryKey = keys;
            GlobVar.DataTableProjects.DefaultView.Sort = "Pinned DESC, OrderNum ASC";
        }
        public static void LoadAllProjects()
        {
            GlobVar.DicProjects = new Dictionary<Guid, cProjectTypes>();

            CreateProjectsDataTable();
            if (!Directory.Exists(GlobVar.RTCVision.Paths.Projects))
            {
                try
                {
                    Directory.CreateDirectory(GlobVar.RTCVision.Paths.Projects);
                }
                catch
                {

                }
            }
            if (!Directory.Exists(GlobVar.RTCVision.Paths.Projects)) return;
            List<string> listProjectFolders = GlobFuncs.GetDirectories(GlobVar.RTCVision.Paths.Projects);
            foreach (string folder in listProjectFolders)
            {
                cProjectTypes project = LoadProjectFromFolder(folder);
                if (project == null) continue;

                if (GlobVar.DicProjects.ContainsKey(project.ID))
                    project.ID = Guid.NewGuid();
                GlobVar.DicProjects.Add(project.ID, project);
            }
            LoadAllProjectsToDataTable();

            LoadAllProjectsToMainFormCombobox();
        }
        public static void ViewAllProjectToCombobox(ToolStripComboBox cbProjects)
        {
            ToolStripComboBox _cbProjects = cbProjects;
            _cbProjects.Items.Clear();
            foreach (cProjectTypes project in GlobVar.DicProjects.Values)
            {
                _cbProjects.Items.Add(project.ProjectName);
                //cbProjects.Items.Add(project.ProjectName);
            }
            if (_cbProjects.Items.Count > 0)
            {
                int iCurrentIndex = _cbProjects.Items.IndexOf(GlobVar.RTCVision.Files.LastProjectOpenName);
                if (!string.IsNullOrEmpty(GlobVar.RTCVision.Files.LastProjectOpenName) &&
                    iCurrentIndex >= 0 && iCurrentIndex < _cbProjects.Items.Count)
                    cbProjects.SelectedItem = _cbProjects.Items[iCurrentIndex];
                else
                {
                    //for (int i = 0; i < _cbProjects.Items.Count; i++)
                    //{
                    //    _lastIndex = _cbProjects.Items.;
                    //}
                    cbProjects.SelectedIndex = 0;
                }
            }
        }
            public static void LoadAllProjectsToMainFormCombobox(string defaultProjectName = "")
        {
            GlobVar.FormMain.cbProjects1.Items.Clear();
            foreach (cProjectTypes value in GlobVar.DicProjects.Values)
                GlobVar.FormMain.cbProjects1.Items.Add(value.ProjectName);

            if (GlobVar.FormMain.cbProjects1.Items.IndexOf(defaultProjectName) >= 0)
                GlobVar.FormMain.cbProjects1.SelectedIndex = GlobVar.FormMain.cbProjects1.Items.IndexOf(defaultProjectName);
            else if (GlobVar.FormMain.cbProjects1.Items.Count > 0)
                GlobVar.FormMain.cbProjects1.SelectedIndex = 0;
        }

        public static bool SaveCamSetting_OnlyCounter(cProjectTypes project, cCAMTypes cam)
        {
            if (cam == null || project == null)
                return false;

            ProjectData projectData = new ProjectData();
            try
            {

                var result = projectData.SaveProject_ProjectSettings_Connect(project);
                if (!projectData.MyConn.IsConnected)
                    return false;

                int count = projectData.MyConn.ExecuteScalar_Int(
                    $"SELECT COUNT(PropName) FROM CAMSettings WHERE PropName='IsViewCounter' AND CAMID='{cam.ID}'");
                if (count != 0)
                    projectData.MyConn.ExecuteQuery($"UPDATE CAMSettings SET ValueT='{cam.IsViewCounter.ToString().ToLower()}' WHERE PropName='IsViewCounter' AND CAMID='{cam.ID}'");
                else
                    projectData.MyConn.ExecuteQuery($"INSERT INTO CAMSettings(CAMID,PropName,ValueT) VALUES ('{cam.ID}','IsViewCounter','{cam.IsViewCounter.ToString().ToLower()}')");

                count = projectData.MyConn.ExecuteScalar_Int(
                   $"SELECT COUNT(PropName) FROM CAMSettings WHERE PropName='TotalCount' AND CAMID='{cam.ID}'");
                if (count != 0)
                    projectData.MyConn.ExecuteQuery($"UPDATE CAMSettings SET ValueI={cam.TotalCount} WHERE PropName='TotalCount' AND CAMID='{cam.ID}'");
                else
                    projectData.MyConn.ExecuteQuery($"INSERT INTO CAMSettings(CAMID,PropName,ValueI) VALUES ('{cam.ID}','TotalCount',{cam.TotalCount})");

                count = projectData.MyConn.ExecuteScalar_Int(
                    $"SELECT COUNT(PropName) FROM CAMSettings WHERE PropName='OKCount' AND CAMID='{cam.ID}'");
                if (count != 0)
                    projectData.MyConn.ExecuteQuery($"UPDATE CAMSettings SET ValueI={cam.OKCount} WHERE PropName='OKCount' AND CAMID='{cam.ID}'");
                else
                    projectData.MyConn.ExecuteQuery($"INSERT INTO CAMSettings(CAMID,PropName,ValueI) VALUES ('{cam.ID}','OKCount',{cam.OKCount})");

                count = projectData.MyConn.ExecuteScalar_Int(
                    $"SELECT COUNT(PropName) FROM CAMSettings WHERE PropName='NGCount' AND CAMID='{cam.ID}'");
                if (count != 0)
                    projectData.MyConn.ExecuteQuery($"UPDATE CAMSettings SET ValueI={cam.OKCount} WHERE PropName='NGCount' AND CAMID='{cam.ID}'");
                else
                    projectData.MyConn.ExecuteQuery($"INSERT INTO CAMSettings(CAMID,PropName,ValueI) VALUES ('{cam.ID}','NGCount',{cam.NGCount})");

                if (result)
                {
                    projectData.MyConn.Commit();
                    project.DataChange = false;
                }
                projectData.Disconnect();
                return result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                if (projectData.MyConn != null && projectData.MyConn.IsConnected)
                    projectData.MyConn.RollBack();
                return false;
            }
        }
        public static void LoadAllProjectsToDataTable()
        {
            CreateProjectsDataTable();
            GlobVar.DataTableProjects.Clear();
            foreach (cProjectTypes value in GlobVar.DicProjects.Values)
            {
                GlobVar.DataTableProjects.Rows.Add(new object[]
                {
                    value.ID, value.OrderNum, value.ProjectName, value.Note, value.PreviewImage,
                    value.Pinned
                });
            }
        }
        public static void ChangeJob()
        {
            GlobVar.FormMain?.Invoke(new Action(ChangeJobProcess));
        }
        public static void CleanSavedImageByTask(string cleanImageEvent)
        {
            try
            {
                if (!GlobVar.RTCVision.ImageOptions.IsAutoCleanImage)
                    return;

                if (GlobVar.DicProjects == null || GlobVar.DicProjects.Count <= 0)
                    return;

                if (GlobVar.RTCVision.ImageOptions.CleanImageEvent != cleanImageEvent)
                    return;

                if (cleanImageEvent == cCleanImageEvent.ByTime)
                {
                    TimeSpan ts = DateTime.Now - GlobVar.RTCVision.ImageOptions.BeginTimeClean;
                    if (ts.TotalDays < GlobVar.RTCVision.ImageOptions.NumberOfTimeCleanImage)
                        return;
                }

                if (GlobVar.RTCVision.ImageOptions.IsQuestionBeforeClean)
                    if (cMessageBox.Question_YesNo("Do you want clean image by task?") == DialogResult.No)
                    {
                        if (GlobVar.RTCVision.ImageOptions.CleanImageEvent == cCleanImageEvent.ByTime)
                            GlobVar.RTCVision.ImageOptions.BeginTimeClean = DateTime.Now;
                        return;
                    }

                GlobFuncs.ShowWaitForm("Clean Image Process By Task...");

                foreach (cProjectTypes project in GlobVar.DicProjects.Values)
                {
                    foreach (cCAMTypes cam in project.CAMs.Values)
                    {
                        if (Directory.Exists(cam.GroupActions.SourceImageSettings.CameraSettings
                                .SaveImageFolder_Origin))
                        {
                            System.IO.DirectoryInfo di = new DirectoryInfo(cam.GroupActions.SourceImageSettings
                                .CameraSettings.SaveImageFolder_Origin);
                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }

                            foreach (DirectoryInfo dir in di.GetDirectories())
                            {
                                dir.Delete(true);
                            }
                        }

                        if (Directory.Exists(cam.GroupActions.SourceImageSettings.CameraSettings
                            .SaveImageFolder_Pass))
                        {
                            System.IO.DirectoryInfo di = new DirectoryInfo(cam.GroupActions.SourceImageSettings
                                .CameraSettings.SaveImageFolder_Pass);
                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }

                            foreach (DirectoryInfo dir in di.GetDirectories())
                            {
                                dir.Delete(true);
                            }
                        }

                        if (Directory.Exists(cam.GroupActions.SourceImageSettings.CameraSettings
                            .SaveImageFolder_Fail))
                        {
                            System.IO.DirectoryInfo di = new DirectoryInfo(cam.GroupActions.SourceImageSettings
                                .CameraSettings.SaveImageFolder_Fail);
                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }

                            foreach (DirectoryInfo dir in di.GetDirectories())
                            {
                                dir.Delete(true);
                            }
                        }
                    }
                }

                if (GlobVar.RTCVision.ImageOptions.OKNGConfirm_SaveImageMode != EOKNGConfirm_SaveImage.None)
                    if (Directory.Exists(GlobVar.RTCVision.ImageOptions.OKNGConfirm_SaveFolder))
                    {
                        //Lấy danh sách các folder trong thư mục này
                        System.IO.DirectoryInfo di = new DirectoryInfo(GlobVar.RTCVision.ImageOptions.OKNGConfirm_SaveFolder);
                        var orderDirByOldMode = di.GetDirectories().OrderBy(x => Directory.GetCreationTime(x.FullName)).ToList();
                        DateTime maxTime = DateTime.MinValue;

                        if (orderDirByOldMode.Any())
                        {
                            maxTime = orderDirByOldMode[0].CreationTime;
                            TimeSpan time = new TimeSpan(GlobVar.RTCVision.ImageOptions.NumberOfTimeCleanImageWithin, 0, 0, 0);
                            maxTime.Add(time);

                            foreach (DirectoryInfo info in orderDirByOldMode)
                                if (info.CreationTime < maxTime)
                                {
                                    foreach (FileInfo file in info.GetFiles())
                                        file.Delete();
                                    info.Delete(true);
                                }
                        }
                    }

                if (cleanImageEvent == cCleanImageEvent.ByTime)
                    GlobVar.RTCVision.ImageOptions.BeginTimeClean = DateTime.Now;
            }
            catch (Exception ex)
            {
                GlobFuncs.CloseWaitForm();
                cMessageBox.Error(ex.Message);
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clean saved image. </summary>
        ///
        /// <remarks>   DATRUONG, 25/11/2021. </remarks>
        ///
        /// <param name="project">  The project. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void CleanSavedImage(cProjectTypes project)
        {
            if (project == null)
                return;
            if (cMessageBox.Question_YesNo("Do you want clean all image saved in this model?") == DialogResult.No)
                return;
            try
            {
                GlobFuncs.ShowWaitForm("Clean Image Process...");
                foreach (cCAMTypes cam in project.CAMs.Values)
                {
                    if (Directory.Exists(cam.GroupActions.SourceImageSettings.CameraSettings
                        .SaveImageFolder_Origin))
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(cam.GroupActions.SourceImageSettings
                            .CameraSettings.SaveImageFolder_Origin);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }

                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }

                    if (Directory.Exists(cam.GroupActions.SourceImageSettings.CameraSettings
                        .SaveImageFolder_Pass))
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(cam.GroupActions.SourceImageSettings
                            .CameraSettings.SaveImageFolder_Pass);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }

                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }

                    if (Directory.Exists(cam.GroupActions.SourceImageSettings.CameraSettings
                        .SaveImageFolder_Fail))
                    {
                        System.IO.DirectoryInfo di = new DirectoryInfo(cam.GroupActions.SourceImageSettings
                            .CameraSettings.SaveImageFolder_Fail);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }

                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.CloseWaitForm();
                cMessageBox.Error(ex.Message);
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
        }
        public static void ChangeJobProcess()
        {
            try
            {
                GlobFuncs.ShowWaitForm("Change Job...");

                // Kiểm tra xem có cửa sổ setting được mở lên không
                if (GlobVar.FrmActions != null)
                {
                    //Đóng chu trình chạy
                    GlobVar.FrmActions.mnuStop.PerformClick();
                    //Lưu vào đóng form
                    GlobVar.FrmActions.btnSaveAndClose.PerformClick();
                }
                cProjectFunctions.StopAllCam(GlobVar.CurrentProject);
                //foreach (var projectCam in GlobVar.CurrentProject.CAMs)
                //    projectCam.Value.GroupActions.RefValues = null;
                //GlobVar.MyListMCPTCP = null;
                //GlobVar.MyListModBusTCP = null;
                //GlobVar.MyListTCPIP = null;
                //Thread.Sleep(2000);

                //Chuyển Job
                GlobFuncs.ShowWaitForm("Change Job...");

                if (GlobVar.FormMain.InvokeRequired)
                {
                    GlobVar.FormMain.Invoke((MethodInvoker)delegate
                    {
                        string sProjectName = GlobVar.ChangeJob_ProjectName;
                        if (GlobVar.ChangeJob_UseOrderNumber)
                            foreach (cProjectTypes projectsValue in GlobVar.DicProjects.Values)
                                if (projectsValue.OrderNum == GlobVar.ChangeJob_OrderNumber)
                                {
                                    sProjectName = projectsValue.ProjectName;
                                    break;
                                }

                        GlobVar.LockEvents = true;
                        GlobVar.FormMain.cbProjects.Text = string.Empty;
                        GlobVar.LockEvents = false;
                        GlobVar.FormMain.cbProjects.Text = sProjectName;
                        if (GlobVar.ChangeJob_AutoStart)
                            GlobVar.FormMain.mnuRun.PerformClick();
                    });
                }
                else
                {
                    string sProjectName = GlobVar.ChangeJob_ProjectName;
                    if (GlobVar.ChangeJob_UseOrderNumber)
                        foreach (cProjectTypes projectsValue in GlobVar.DicProjects.Values)
                            if (projectsValue.OrderNum == GlobVar.ChangeJob_OrderNumber)
                            {
                                sProjectName = projectsValue.ProjectName;
                                break;
                            }

                    GlobVar.LockEvents = true;
                    GlobVar.FormMain.cbProjects.Text = string.Empty;
                    GlobVar.LockEvents = false;
                    GlobVar.FormMain.cbProjects.Text = sProjectName;
                    if (GlobVar.ChangeJob_AutoStart)
                        GlobVar.FormMain.mnuRun.PerformClick();
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
        }

        #endregion
    }
}
