using Emgu.CV.UI;
using RTC_Vision_Lite.Classes.ProjectFunctions;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.Layout.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RTC_Vision_Lite.Forms.FrmApplyActionToOtherCAMs;

namespace RTC_Vision_Lite.Classes
{
    public class ProjectData
    {
        public string DataFileName = string.Empty;
        public cSQLite MyConn = null;

        #region PROPERTIES
        private DataTable _ProjectList = null;

        public DataTable ProjectList
        {
            get
            {
                if (_ProjectList == null) _ProjectList = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ProjectList);

                if (_ProjectList != null)
                {
                    _ProjectList.TableName = cTableName_SaveTemplate.ProjectList;
                    _ProjectList.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _ProjectList.Columns[cColName.ID];
                    _ProjectList.PrimaryKey = keys;
                }
                return _ProjectList;
            }
            set { _ProjectList = value; }
        }

        public DataTable _ProjectSetting = null;

        public DataTable ProjectSetting
        {
            get
            {
                if (_ProjectSetting == null) _ProjectSetting = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.ProjectSetting);

                if (_ProjectSetting != null)
                {
                    _ProjectSetting.TableName = cTableName_SaveTemplate.ProjectSetting;
                    _ProjectSetting.Columns[cColName.ProjID].Caption = cColName.KEY;
                    _ProjectSetting.Columns[cColName.PropName].Caption = cColName.KEY;
                    var keys = new DataColumn[2];
                    keys[0] = _ProjectSetting.Columns[cColName.ProjID];
                    keys[1] = _ProjectSetting.Columns[cColName.PropName];
                    _ProjectSetting.PrimaryKey = keys;
                }
                return _ProjectSetting;
            }
            set { _ProjectSetting = value; }
        }

        public DataTable _CAMList = null;

        public DataTable CAMList
        {
            get
            {
                if (!MyConn.Connect()) return null;
                if (_CAMList == null) _CAMList = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.CAMList + " ORDER BY STT");

                if (_CAMList != null)
                {
                    if (!_CAMList.Columns.Contains(cColName.RunOrder))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.CAMList, cColName.RunOrder, "INT");
                        MyConn.ExecuteQuery("UPDATE " + cTableName_SaveTemplate.CAMList + " SET RunOrder = STT");
                        _CAMList.Columns.Add(cColName.RunOrder, typeof(int));
                        foreach (DataRow row in _CAMList.Rows)
                            row[cColName.RunOrder] = row[cColName.STT];
                    }

                    _CAMList.TableName = cTableName_SaveTemplate.CAMList;
                    _CAMList.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _CAMList.Columns[cColName.ID];
                    _CAMList.PrimaryKey = keys;
                }
                return _CAMList;
            }
            set { _CAMList = value; }
        }

        public DataTable _GroupCAMList = null;

        public DataTable GroupCAMList
        {
            get
            {
                if (_GroupCAMList == null) _GroupCAMList = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.GroupCAMList + " ORDER BY STT");

                if (_GroupCAMList != null)
                {
                    _GroupCAMList.TableName = cTableName_SaveTemplate.GroupCAMList;
                    _GroupCAMList.Columns[cColName.ID].Caption = cColName.KEY;
                    var keys = new DataColumn[1];
                    keys[0] = _GroupCAMList.Columns[cColName.ID];
                    _GroupCAMList.PrimaryKey = keys;
                }
                return _GroupCAMList;
            }
            set { _GroupCAMList = value; }
        }

        public DataTable _CAMSettings = null;

        public DataTable CAMSettings
        {
            get
            {
                if (!MyConn.Connect()) return null;

                if (_CAMSettings == null) _CAMSettings = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.CAMSettings);

                if (_CAMSettings != null)
                {
                    _CAMSettings.TableName = cTableName_SaveTemplate.CAMSettings;
                    _CAMSettings.Columns[cColName.CAMID].Caption = cColName.KEY;
                    _CAMSettings.Columns[cColName.PropName].Caption = cColName.KEY;
                    var keys = new DataColumn[2];
                    keys[0] = _CAMSettings.Columns[cColName.CAMID];
                    keys[1] = _CAMSettings.Columns[cColName.PropName];
                    _CAMSettings.PrimaryKey = keys;
                }
                return _CAMSettings;
            }
            set { _CAMSettings = value; }
        }

        public DataTable _GroupCAMSettings = null;

        public DataTable GroupCAMSettings
        {
            get
            {
                if (_GroupCAMSettings == null) _GroupCAMSettings = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.GroupCAMSettings);

                if (_GroupCAMSettings != null)
                {
                    _GroupCAMSettings.TableName = cTableName_SaveTemplate.GroupCAMSettings;
                    _GroupCAMSettings.Columns[cColName.GroupID].Caption = cColName.KEY;
                    _GroupCAMSettings.Columns[cColName.PropName].Caption = cColName.KEY;
                    var keys = new DataColumn[2];
                    keys[0] = _GroupCAMSettings.Columns[cColName.GroupID];
                    keys[1] = _GroupCAMSettings.Columns[cColName.PropName];
                    _GroupCAMSettings.PrimaryKey = keys;
                }
                return _GroupCAMSettings;
            }
            set { _GroupCAMSettings = value; }
        }

        private DataTable _TrayResult_Settings = null;

        public DataTable TrayResult_Settings
        {
            get
            {
                if (!MyConn.IsTableExists(cTableName_SaveTemplate.TrayResult_Settings))
                {
                    MyConn.ExecuteQuery("CREATE TABLE 'TrayResult_Settings' (" + "'SetupProgramToProductMode' INTEGER)");
                }

                if (_TrayResult_Settings == null)
                    _TrayResult_Settings = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.TrayResult_Settings);

                if (_TrayResult_Settings != null)
                {
                    if (!_TrayResult_Settings.Columns.Contains(cColName.NumberOfTray))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.TrayResult_Settings, cColName.NumberOfTray, "INT");
                        _TrayResult_Settings.Columns.Add(cColName.NumberOfTray, typeof(int));
                    }
                    if (!_TrayResult_Settings.Columns.Contains(cColName.RowOfTray))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.TrayResult_Settings, cColName.RowOfTray, "INT");
                        _TrayResult_Settings.Columns.Add(cColName.RowOfTray, typeof(int));
                    }
                    if (!_TrayResult_Settings.Columns.Contains(cColName.ColOfTray))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.TrayResult_Settings, cColName.ColOfTray, "INT");
                        _TrayResult_Settings.Columns.Add(cColName.ColOfTray, typeof(int));
                    }
                    if (!_TrayResult_Settings.Columns.Contains(cColName.LotName))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.TrayResult_Settings, cColName.LotName, "TEXT");
                        _TrayResult_Settings.Columns.Add(cColName.LotName, typeof(int));
                    }
                    if (!_TrayResult_Settings.Columns.Contains(cColName.TrayName))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.TrayResult_Settings, cColName.TrayName, "TEXT");
                        _TrayResult_Settings.Columns.Add(cColName.TrayName, typeof(int));
                    }
                    _TrayResult_Settings.TableName = cTableName_SaveTemplate.TrayResult_Settings;
                }
                return _TrayResult_Settings;
            }
            set => _TrayResult_Settings = value;
        }

        private DataTable _TrayResult_ProgramName = null;

        public DataTable TrayResult_ProgramName
        {
            get
            {
                if (!MyConn.IsTableExists(cTableName_SaveTemplate.TrayResult_ProgramName))
                {
                    MyConn.ExecuteQuery("CREATE TABLE 'TrayResult_ProgramName' (" + "'Name' TEXT," + "'CAMID' TEXT," + "'CamName' TEXT)");
                }

                if (_TrayResult_ProgramName == null)
                    _TrayResult_ProgramName = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.TrayResult_ProgramName);

                if (_TrayResult_ProgramName != null)
                {
                    if (_TrayResult_ProgramName.Columns.Contains(cColName.IsUseCustomTools))
                    {
                        MyConn.AddCol(cTableName_SaveTemplate.TrayResult_ProgramName, cColName.IsUseCustomTools, "TEXT");
                        _TrayResult_ProgramName.Columns.Add(cColName.IsUseCustomTools, typeof(string));
                    }
                    _TrayResult_ProgramName.TableName = cTableName_SaveTemplate.TrayResult_ProgramName;
                }
                return _TrayResult_ProgramName;
            }
            set => _TrayResult_ProgramName = value;
        }

        private DataTable _TrayResult_ToolName = null;

        public DataTable TrayResult_ToolName
        {
            get
            {
                if (!MyConn.IsTableExists(cTableName_SaveTemplate.TrayResult_ToolName))
                {
                    MyConn.ExecuteQuery("CREATE TABLE 'TrayResult_ToolName' (" + "'Name' TEXT," + "'CamName' TEXT," + "'ActionID' TEXT)");
                }

                if (_TrayResult_ToolName == null)
                    _TrayResult_ToolName = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.TrayResult_ToolName);

                if (_TrayResult_ToolName != null)
                    _TrayResult_ToolName.TableName = cTableName_SaveTemplate.TrayResult_ToolName;

                return _TrayResult_ToolName;
            }
            set => _TrayResult_ToolName = value;
        }

        public DataTable TrayResult_ProgramName_Names => MyConn.GetDataTable("SELECT DISTINCT Name FROM " + cTableName_SaveTemplate.TrayResult_ProgramName);
        private DataTable _runningTemplate = null;

        public DataTable RunningTemplate
        {
            get
            {
                if (!MyConn.IsTableExists(cTableName_SaveTemplate.RunningTemplate))
                    MyConn.ExecuteQuery("CREATE TABLE 'RunningTemplate' ('ID'  TEXT, 'Name' TEXT, 'Description' TEXT, 'Choose' TEXT, PRIMARY KEY('ID'))");

                if (_runningTemplate == null)
                    _runningTemplate = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.RunningTemplate);

                if (_runningTemplate != null)
                {
                    var keys = new DataColumn[1];
                    keys[0] = _runningTemplate.Columns[cColName.ID];
                    _runningTemplate.PrimaryKey = keys;
                    _runningTemplate.TableName = cTableName_SaveTemplate.RunningTemplate;
                }
                return _runningTemplate;
            }
            set => _runningTemplate = value;
        }

        private DataTable _runningTemplateDetail = null;

        public DataTable RunningTemplateDetail
        {
            get
            {
                if (!MyConn.IsTableExists(cTableName_SaveTemplate.RunningTemplateDetail))
                    MyConn.ExecuteQuery("CREATE TABLE 'RunningTemplateDetail' ('ID'  TEXT, 'CAMID' TEXT, 'ToolID' TEXT, 'PropName' TEXT, 'Value' TEXT)");

                if (_runningTemplateDetail == null)
                    _runningTemplateDetail = MyConn.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.RunningTemplateDetail);

                if (_runningTemplateDetail != null)
                    _runningTemplateDetail.TableName = cTableName_SaveTemplate.RunningTemplateDetail;

                return _runningTemplateDetail;
            }
            set => _runningTemplateDetail = value;
        }
        #endregion

        public bool Connect(string _DataFileName)
        {
            DataFileName = _DataFileName;
            MyConn = new cSQLite(DataFileName);
            ProjectList = null;
            ProjectSetting = null;
            CAMList = null;
            CAMSettings = null;
            GroupCAMList = null;
            _GroupCAMSettings = null;

            return MyConn.Connect();
        }

        public void Disconnect()
        {
            if (MyConn != null && MyConn.IsConnected)
                MyConn.Close();

            ProjectList = null;
            ProjectSetting = null;
            CAMList = null;
            CAMSettings = null;
            GroupCAMList = null;
            GroupCAMSettings = null;
            ProjectList = null;
            ProjectList = null;
        }

        public bool SaveProject_Prepare(cProjectTypes _Project)
        {
            try
            {
                if (_Project.FolderNameFullPathBAK.Trim() != string.Empty && !Directory.Exists(_Project.FolderNameFullPathBAK) &&
                    _Project.FolderNameFullPathBAK.ToLower() != _Project.FolderNameFullPath.ToLower())
                {
                    Directory.Move(_Project.FolderNameFullPathBAK, _Project.FolderNameFullPath);
                }
                else if (!Directory.Exists(_Project.FolderNameFullPath))
                {
                    Directory.CreateDirectory(_Project.FolderNameFullPath);
                }
                if (!File.Exists(_Project.FileName))
                {
                    File.Copy(GlobVar.RTCVision.Files.SaveTemplate, _Project.FileName, true);
                }
                foreach (cCAMTypes _CAM in _Project.CAMs.Values)
                {
                    _CAM.GroupActions.FileName = _Project.FolderNameFullPath + Path.DirectorySeparatorChar + _CAM.FileName_Actions + cExtFile.GroupD;
                    if (!File.Exists(_CAM.GroupActions.FileName))
                        File.Copy(GlobVar.RTCVision.Files.SaveTemplate, _CAM.GroupActions.FileName, true);
                    _CAM.GroupActions.FileNameIconic = Path.GetDirectoryName(_CAM.GroupActions.FileName) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(_CAM.GroupActions.FileName) + cExtFile.GroupIconicD;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveProject_ProjectSettings_Connect(cProjectTypes _Project)
        {
            bool Result = Connect(_Project.FileName);
            if (Result) Result = MyConn.StartTransaction();
            return Result;
        }

        internal EFunctionReturn SaveAs(cProjectTypes project, out cProjectTypes newProject)
        {
            newProject = null;
            try
            {
                FrmProjectSaveAs frmProjectSaveAs = new FrmProjectSaveAs();
                if (frmProjectSaveAs.ShowDialog() == DialogResult.Cancel)
                    return EFunctionReturn.Cancel;
                string modelName = frmProjectSaveAs.ModelName;
                bool isKeepPath = frmProjectSaveAs.IsKeepPath;

                string sourcePath = project.FolderNameFullPath;
                string desPath = GlobVar.RTCVision.Paths.Projects + Path.DirectorySeparatorChar + GlobFuncs.SwitchToUnsigned(
                    GlobFuncs.RemoveSpecialCharacters(modelName));

                string newFileNameWidthoutExt = GlobFuncs.SwitchToUnsigned(
                    GlobFuncs.RemoveSpecialCharacters(modelName));
                string newFileName = $"{newFileNameWidthoutExt}{cExtFile.ProjD}";
                string newFullFileName = Path.Combine(desPath, newFileName);
                string oldFullFileNameInNewFolder = Path.Combine(desPath, Path.GetFileName(project.FileName));

                GlobFuncs.CopyFilesRecursively(sourcePath, desPath);

                //Trường hợp không copy được ==> lỗi
                if (!Directory.Exists(desPath))
                    return EFunctionReturn.Error;

                //Sau khi đã copy toàn bộ thư mục của project cũ sang thư mục của project mới
                // chúng ta tiến hành đổi hệ thống tên file và thư mục
                if (!File.Exists(oldFullFileNameInNewFolder))
                    return EFunctionReturn.Error;

                File.Move(oldFullFileNameInNewFolder, newFullFileName);

                if (!File.Exists(newFullFileName))
                    return EFunctionReturn.Error;

                //Thực hiện việc load project mới vào biến new project
                if (!isKeepPath)
                    SaveAs_StandardizedData_Project(newFullFileName, project.FolderNameFullPath,
                        desPath);
                newProject = cProjectFunctions.LoadProjectFromFolder(desPath);
                newProject.ID = Guid.NewGuid();
                newProject.OrderNum = frmProjectSaveAs.OrderNumber;
                newProject.ProjectName = modelName;

                cProjectFunctions.SaveProject_OnlySetting(newProject);
                // Đồng thời làm lại các thông số đường dẫn của các cửa sổ
                System.IO.DirectoryInfo di = new DirectoryInfo(desPath);
                FileInfo[] fileInfos = di.GetFiles($"*{cExtFile.GroupD}");
                foreach (FileInfo file in fileInfos)
                {
                    //Đây là file chứa thông tin các cửa sổ check
                    string camFileName = Path.Combine(desPath, Path.GetFileName(file.Name));
                    if (!isKeepPath)
                        SaveAs_StandardizedData_Cam(camFileName, project.FolderNameFullPath,
                            desPath);
                }

                return EFunctionReturn.Success;
            }
            catch
            {
                newProject = null;
                return EFunctionReturn.Error;
            }
        }
        private void SaveAs_StandardizedData_Cam(string fileName, string oldPath, string newPath)
        {
            cSQLite myConn = new cSQLite(fileName);
            try
            {
                if (!myConn.Connect())
                {
                    throw new Exception(cMessageContent.BuildMessage(cMessageContent.Err_NotConnectObject,
                        new string[] { "File Name:\n" + fileName + "\n" },
                        new string[] { "Tệp:\n" + fileName + "\n)" }));
                }

                myConn.StartTransaction();
                List<string> querys = new List<string>();
                querys.Add("UPDATE " + cTableName_SaveTemplate.ActionSettings + " SET ValueT = REPLACE(ValueT,'" +
                           oldPath + "','" + newPath + "')");
                querys.Add("UPDATE " + cTableName_SaveTemplate.CameraSettings + " SET ValueT = REPLACE(ValueT,'" +
                           oldPath + "','" + newPath + "')");
                foreach (string query in querys)
                {
                    if (!myConn.ExecuteQuery(query))
                    {
                        myConn.RollBack();
                        throw new Exception(cMessageContent.BuildMessage(cMessageContent.Err_ExecuteQueryCannotSuccess,
                            new string[] { query },
                            new string[] { query }));
                    }
                }

                myConn.Commit();
            }
            catch (Exception ex)
            {
                if (myConn.IsConnected)
                    myConn.RollBack();
                throw;
            }
            finally
            {
                myConn.Close();
                myConn = null;
            }
        }
        #region SAVE AS

        private void SaveAs_StandardizedData_Project(string fileName, string oldPath, string newPath)
        {
            cSQLite myConn = new cSQLite(fileName);
            try
            {
                if (!myConn.Connect())
                    return;
                myConn.StartTransaction();
                if (!myConn.ExecuteQuery("UPDATE " + cTableName_SaveTemplate.CAMSettings + " SET ValueT = REPLACE(ValueT, '" +
                    oldPath + "','" + newPath + "')"))
                {
                    myConn.RollBack();
                    return;
                }
                myConn.Commit();
            }
            catch
            {
                if (myConn.IsConnected)
                    myConn.RollBack();
            }
            finally
            {
                myConn.Close();
                myConn = null;
            }
        }

        #endregion

        #region SAVE OR OPEN DATA
        /// <summary>
        /// Opens project get project information
        /// </summary>
        /// <param name="_Project"></param>
        /// <returns></returns>
        public bool OpenProject_GetProjectInfo(cProjectTypes _Project)
        {
            try
            {
                if (ProjectList == null || ProjectList.Rows.Count <= 0)
                    return false;

                _Project.ID = GlobFuncs.GetDataRowValue_Guid(_ProjectList.Rows[0], cColName.ID);
                _Project.ProjectName = GlobFuncs.GetDataRowValue_String(_ProjectList.Rows[0], cColName.Name);
                _Project.Note = GlobFuncs.GetDataRowValue_String(_ProjectList.Rows[0], cColName.Note);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool OpenProject_GetProjectSettings(cProjectTypes _Project)
        {
            try
            {
                if (ProjectSetting == null) return false;

                PropertyInfo[] pProjectSettings = _Project.GetType().GetProperties();
                foreach (PropertyInfo item in pProjectSettings)
                {
                    DataRow r = _ProjectSetting.Rows.Find(new object[] { _Project.ID, item.Name });
                    if (r == null) continue;
                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            item.SetValue(_Project, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case "Guid":
                            item.SetValue(_Project, GlobFuncs.GetDataRowValue_Guid(r, cColName.ValueT));
                            break;
                        case "Boolean":
                            item.SetValue(_Project, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case "Int32":
                            item.SetValue(_Project, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                item.SetValue(_Project, GlobFuncs.String2ListString(GlobFuncs.GetDataRowValue_String(r, cColName.ValueT), cStrings.SepPhay));
                            }
                            break;
                        default:
                            continue;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool OpenProject_GetCAMs(cProjectTypes project, bool widthoutTool = false)
        {
            try
            {
                if (CAMList == null)
                    return false;
                project.STTCAM = 1;
                project.CAMs = new Dictionary<Guid, cCAMTypes>();
                foreach (DataRow r in _CAMList.Rows)
                {
                    cCAMTypes cam = null;
                    cam = widthoutTool ? new cCAMTypes() : new cCAMTypes(project, project.STTCAM);

                    project.STTCAM += 1;
                    cam.ID = GlobFuncs.GetDataRowValue_Guid(r, cColName.ID);
                    cam.GroupID = GlobFuncs.GetDataRowValue_Guid(r, cColName.GroupID);
                    cam.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                    cam.RunOrder = GlobFuncs.GetDataRowValue_Int(r, cColName.RunOrder);
                    cam.FileName_Actions = MyConn.ExecuteScalar_String("SELECT ValueT FROM CAMSettings WHERE CAMID= '" +
                        cam.ID.ToString() + "' AND PropName='FileName_Actions'");
                    cam.GroupActions.FileName = project.FolderNameFullPath + Path.DirectorySeparatorChar + cam.FileName_Actions + cExtFile.GroupD;
                    cam.GroupActions.FileNameBAK = cam.GroupActions.FileName + cExtFile.BAKD;
                    cam.GroupActions.FileNameIconic = project.FolderNameFullPath + Path.DirectorySeparatorChar + cam.FileName_Actions + cExtFile.GroupIconicD;
                    cam.GroupActions.FileNameIconicBAK = cam.GroupActions.FileNameIconic + cExtFile.BAKD;
                    if (widthoutTool)
                    {
                        project.CAMs.Add(cam.ID, cam);
                        continue;
                    }
                    cam.View.MyCAM = cam;
                    cam.GroupActions.SmartWindowControl = cam.View.SmartWindow;
                    if (!OpenProject_GetCAMProperties(cam)) return false;
                    cam.BuildDefaultFolderPath(project.FolderNameFullPath);
                    cam.BuidDefaultSettingsSaveImage(project.FolderNameFullPath);
                    GroupActionsData groupActionsData = new GroupActionsData();
                    if (File.Exists(cam.GroupActions.FileName))
                    {
                        if (groupActionsData.Connect(cam.GroupActions.FileName))
                        {
                            groupActionsData.Myconn.StartTransaction();
                            bool KQ = groupActionsData.OpenGroup(cam.GroupActions);
                            if (KQ)
                                KQ = groupActionsData.OpenGroup_ComputerSettings(cam.GroupActions);
                            if (KQ)
                                KQ = groupActionsData.OpenGroup_CameraSettings(cam.GroupActions);
                            if (KQ)
                                KQ = groupActionsData.OpenGroup_SourceImages(cam.GroupActions);
                            if (KQ)
                                if (KQ)
                                    KQ = groupActionsData.OpenActionList(cam.GroupActions);
                            if (!KQ)
                            {
                                groupActionsData.Myconn.RollBack();
                                return false;
                            }
                        }
                    }
                    project.CAMs.Add(cam.ID, cam);
                    groupActionsData.Disconnect();

                }
                return true;

            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public async Task<bool> OpenProject_GetCAMsTestAsync(cProjectTypes project, bool withoutTool = false)
        {
            try
            {
                if (CAMList == null || CAMList.Rows.Count == 0) return false;

                project.STTCAM = 0;
                project.CAMs = new Dictionary<Guid, cCAMTypes>();
                bool Result = true;
                var tasks = new List<Task>();
                int maxConcurrentTasks = 5; // Số luồng tối đa
                var semaphore = new SemaphoreSlim(maxConcurrentTasks);
                foreach (DataRow row in _CAMList.Rows)
                {
                    await semaphore.WaitAsync(); // Giới hạn số luồng

                    // Tạo một Task mới cho mỗi dòng
                    try
                    {
                        cCAMTypes cam = withoutTool ? new cCAMTypes() : new cCAMTypes(project, project.STTCAM);
                        project.STTCAM += 1;
                        cam.ID = GlobFuncs.GetDataRowValue_Guid(row, cColName.ID);
                        cam.GroupID = GlobFuncs.GetDataRowValue_Guid(row, cColName.GroupID);
                        cam.Name = GlobFuncs.GetDataRowValue_String(row, cColName.Name);
                        cam.RunOrder = GlobFuncs.GetDataRowValue_Int(row, cColName.RunOrder);

                        cam.FileName_Actions = MyConn.ExecuteScalar_String($"SELECT ValueT FROM CAMSettings WHERE CAMID='{cam.ID}' AND PropName='FileName_Actions'");

                        cam.GroupActions.FileName = Path.Combine(project.FolderNameFullPath, cam.FileName_Actions + cExtFile.GroupD);
                        cam.GroupActions.FileNameBAK = cam.GroupActions.FileName + cExtFile.BAKD;

                        if (!withoutTool)
                        {
                            cam.View.MyCAM = cam;
                            cam.GroupActions.SmartWindowControl = cam.View.SmartWindow;

                            if (!OpenProject_GetCAMProperties(cam))
                                Result = false;

                            cam.BuildDefaultFolderPath(project.FolderNameFullPath);
                            cam.BuidDefaultSettingsSaveImage(project.FolderNameFullPath);
                            var task = Task.Run(() =>
                            {
                                if (File.Exists(cam.GroupActions.FileName))
                                {
                                    GroupActionsData groupActionsData = new GroupActionsData();

                                    if (groupActionsData.Connect(cam.GroupActions.FileName, true))
                                    {
                                        //groupActionsData.Myconn.StartTransaction();
                                        bool KQ = groupActionsData.OpenGroup(cam.GroupActions);
                                        KQ &= groupActionsData.OpenGroup_ComputerSettings(cam.GroupActions);
                                        KQ &= groupActionsData.OpenGroup_CameraSettings(cam.GroupActions);
                                        KQ &= groupActionsData.OpenGroup_SourceImages(cam.GroupActions);
                                        KQ &= groupActionsData.OpenActionList(cam.GroupActions);
                                        if (!KQ)
                                        {
                                            groupActionsData.Myconn.RollBack();
                                            Result = false;
                                        }
                                        project.CAMs.Add(cam.ID, cam);
                                        groupActionsData.Disconnect();
                                    }
                                }
                            });
                            tasks.Add(task);
                        }


                        // Thêm vào Dictionary với lock
                        //lock (_dbLock)
                        //{
                        //    project.CAMs[cam.ID] = cam; // Sử dụng chỉ định thay vì Add để cập nhật
                        //}
                    }
                    catch (Exception ex)
                    {

                        GlobFuncs.SaveErr(ex);
                    }
                    finally
                    {
                        semaphore.Release(); // Giải phóng slot sau khi hoàn thành
                    }

                    //break;

                }


                // Chờ tất cả các Task hoàn thành
                Task.WaitAll(tasks.ToArray());
                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }

        }




        public bool OpenProject_GetCAMProperties(cCAMTypes _CAM)
        {
            try
            {
                if (CAMSettings == null)
                    return false;
                PropertyInfo[] pCAMSettings = _CAM.GetType().GetProperties();
                foreach (PropertyInfo item in pCAMSettings)
                {
                    DataRow r = _CAMSettings.Rows.Find(new object[] { _CAM.ID, item.Name });
                    if (r == null)
                    {
                        if (item.Name == nameof(_CAM.IsViewResult))
                            _CAM.IsViewResult = true;
                        continue;
                    }
                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            item.SetValue(_CAM, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case "Boolean":
                            item.SetValue(_CAM, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case "Int32":
                            item.SetValue(_CAM, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "ECamTypes":
                            item.SetValue(_CAM, (ECamTypes)GlobFuncs.GetDataRowValue_Int(r, cColName.ValueI));
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                item.SetValue(_CAM, GlobFuncs.String2ListString(GlobFuncs.GetDataRowValue_String(r, cColName.ValueT), cStrings.SepPhay));
                            }
                            break;
                        default:
                            continue;
                    }
                }
                DataRow[] propCompareDefaultRows = _CAMSettings.Select("CAMID='" + _CAM.ID.ToString() + "' AND PropName LIKE 'PropCompareDefault.%'");
                _CAM.GroupActions.SourceImageSettings.CameraSettings.PropCompareDefault = new Dictionary<string, cPropCompare>();
                if (propCompareDefaultRows != null && propCompareDefaultRows.Count() > 0)
                {
                    foreach (DataRow row in propCompareDefaultRows)
                    {
                        cPropCompare propCompare = new cPropCompare();
                        propCompare.PropCAMName = GlobFuncs.GetDataRowValue_String(row, cColName.PropName).Replace(cStrings.PropCompareDefaultWithDot, "");
                        if (row[cColName.ValueT] != DBNull.Value)
                        {
                            propCompare.DataType = typeof(string);
                            propCompare.SValue = GlobFuncs.GetDataRowValue_String(row, cColName.ValueT);
                        }
                        else
                        {
                            propCompare.DataType = typeof(string);
                            propCompare.DValue = GlobFuncs.GetDataRowValue_Decimal(row, cColName.ValueD);
                        }

                        _CAM.GroupActions.SourceImageSettings.CameraSettings.PropCompareDefault.Add(propCompare.PropCAMName, propCompare);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool OpenProject_GetGroupCAMProperties(cGroupCAMTypes _GroupCAM)
        {
            try
            {
                if (GroupCAMSettings == null)
                    return false;
                PropertyInfo[] pGroupCAMSettings = _GroupCAM.GetType().GetProperties();
                foreach (PropertyInfo item in pGroupCAMSettings)
                {
                    DataRow r = _GroupCAMSettings.Rows.Find(new object[] { _GroupCAM.ID, item.Name });
                    if (r == null)
                        continue;
                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            item.SetValue(_GroupCAM, GlobFuncs.GetDataRowValue_String(r, cColName.ValueT));
                            break;
                        case "Boolean":
                            item.SetValue(_GroupCAM, GlobFuncs.GetDataRowValue_Boolean(r, cColName.ValueT));
                            break;
                        case "Int32":
                            item.SetValue(_GroupCAM, GlobFuncs.GetDataRowValue_Int(r, cColName.ValueT));
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                item.SetValue(_GroupCAM, GlobFuncs.String2ListString(GlobFuncs.GetDataRowValue_String(r, cColName.ValueT), cStrings.SepPhay));
                            }
                            break;
                        default:
                            continue;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool OpenProject_GetGroupCAMs(cProjectTypes _Project)
        {
            try
            {
                if (GroupCAMList == null)
                    return false;
                _Project.STTGroupCAM = 1;
                _Project.GroupCAMs = new Dictionary<Guid, cGroupCAMTypes>();
                foreach (DataRow r in _GroupCAMList.Rows)
                {
                    cGroupCAMTypes _GroupCAM = new cGroupCAMTypes();
                    _GroupCAM.STT = _Project.STTGroupCAM;
                    _Project.STTCAM += 1;
                    _GroupCAM.ID = GlobFuncs.GetDataRowValue_Guid(r, cColName.ID);
                    _GroupCAM.Name = GlobFuncs.GetDataRowValue_String(r, cColName.Name);
                    _GroupCAM.View.MyGroup = _GroupCAM;
                    if (!OpenProject_GetGroupCAMProperties(_GroupCAM)) return false;

                    _Project.GroupCAMs.Add(_GroupCAM.ID, _GroupCAM);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveProject_ProjectSettings(cProjectTypes _Project)
        {
            try
            {
                if (!MyConn.Connect())
                    return false;

                if (ProjectList == null)
                    return false;

                bool Result = true;
                if (_ProjectList.Rows.Find(_Project.ID) == null)
                {
                    DataRow _Row = _ProjectList.NewRow();
                    _Row[cColName.ID] = _Project.ID.ToString();
                    _Row[cColName.Name] = _Project.ProjectName;
                    _Row[cColName.Note] = _Project.Note;
                    Result = MyConn.AddRow(_Row);
                }

                if (!Result || ProjectSetting == null)
                    return false;

                PropertyInfo[] pProjectSettings = _Project.GetType().GetProperties();
                foreach (PropertyInfo item in pProjectSettings)
                {
                    DataRow r = ProjectSetting.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.ProjID] = _Project.ID;
                    r[cColName.PropName] = item.Name;

                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            r[cColName.ValueT] = item.GetValue(_Project, null)?.ToString();
                            break;
                        case "Guid":
                            r[cColName.ValueT] = item.GetValue(_Project, null)?.ToString();
                            break;
                        case "Boolean":
                            r[cColName.ValueT] = item.GetValue(_Project, null)?.ToString().ToLower();
                            break;
                        case "Int32":
                            r[cColName.ValueI] = item.GetValue(_Project, null);
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                List<string> obj = (List<string>)item.GetValue(_Project, null);
                                r[cColName.ValueT] = string.Join(",", obj.ToArray());
                            }
                            break;
                        default:
                            continue;
                    }
                    Result = MyConn.AddRow(r);
                    if (!Result) break;
                }
                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        private void SetNullValueToDataRow(DataRow _Row)
        {
            foreach (DataColumn item in _Row.Table.Columns)
            {
                _Row[item] = DBNull.Value;
            }
        }
        #endregion

        #region TRAY RESULT

        public bool SaveProject_TrayReSult_Settings(cProjectTypes _Project)
        {
            try
            {
                if (!MyConn.Connect())
                    return false;

                if (TrayResult_Settings == null)
                    return false;

                DataRow _Row = _TrayResult_Settings.NewRow();
                _Row[cColName.SetupProgramToProductMode] = _Project.TrayResultSettings.SetupProgramToProductMode;
                _Row[cColName.RowOfTray] = _Project.TrayResultSettings.RowOfTray;
                _Row[cColName.ColOfTray] = _Project.TrayResultSettings.ColOfTray;
                _Row[cColName.NumberOfTray] = _Project.TrayResultSettings.NumberOfTray;
                _Row[cColName.LotName] = _Project.TrayResultSettings.LotName;
                _Row[cColName.TrayName] = _Project.TrayResultSettings.TrayName;

                return MyConn.AddRow(_Row);
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool OpenProject_TrayResult_Settings(cProjectTypes _Project)
        {
            try
            {
                _Project.TrayResultSettings = new cTrayResultSettings();
                if (TrayResult_Settings == null)
                    return false;
                if (_TrayResult_Settings.Rows.Count <= 0)
                    return false;
                DataRow r = _TrayResult_Settings.Rows[0];
                _Project.TrayResultSettings.SetupProgramToProductMode = (ETrayResult_SetupProgramToProductMode)GlobFuncs.GetDataRowValue_Int(
                    r, cColName.SetupProgramToProductMode);
                _Project.TrayResultSettings.RowOfTray = GlobFuncs.GetDataRowValue_Int(
                    r, cColName.RowOfTray);
                _Project.TrayResultSettings.ColOfTray = GlobFuncs.GetDataRowValue_Int(
                    r, cColName.ColOfTray);
                _Project.TrayResultSettings.NumberOfTray = GlobFuncs.GetDataRowValue_Int(
                    r, cColName.NumberOfTray);
                _Project.TrayResultSettings.LotName = GlobFuncs.GetDataRowValue_String(
                    r, cColName.LotName);
                _Project.TrayResultSettings.TrayName = GlobFuncs.GetDataRowValue_String(
                    r, cColName.TrayName);
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                _Project.TrayResultSettings = new cTrayResultSettings();
                return false;
            }
        }
        public bool SaveProject_TrayReSult_ProgramName(cProjectTypes _Project)
        {
            try
            {
                if (!MyConn.Connect())
                    return false;

                if (TrayResult_Settings == null)
                    return false;
                MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.TrayResult_ToolName);
                switch (_Project.TrayResultSettings.SetupProgramToProductMode)
                {
                    case ETrayResult_SetupProgramToProductMode.EvenOdd:
                        {
                            if (_Project.TrayResultSettings.EvenCams != null)
                            {
                                foreach (cTrayResultSettings_CamItem evenCam in _Project.TrayResultSettings.EvenCams)
                                {
                                    DataRow _Row = _TrayResult_Settings.NewRow();
                                    _Row[cColName.Name] = cStrings.EvenCams;
                                    _Row[cColName.CAMID] = evenCam.CamID;
                                    _Row[cColName.CamName] = evenCam.Name;
                                    _Row[cColName.IsUseCustomTools] = evenCam.IsUseCustomTools.ToString();
                                    if (!MyConn.AddRow(_Row))
                                        return false;

                                    if (evenCam.IsUseCustomTools && evenCam.ToolsUse != null)
                                    {
                                        foreach (var actionID in evenCam.ToolsUse)
                                        {
                                            DataRow rowTool = TrayResult_ToolName.NewRow();
                                            rowTool[cColName.Name] = cStrings.EvenCams;
                                            rowTool[cColName.CamName] = evenCam.Name;
                                            rowTool[cColName.ActionID] = actionID.ToString();
                                            if (!MyConn.AddRow(rowTool))
                                                return false;
                                        }
                                    }
                                }
                            }
                            if (_Project.TrayResultSettings.OddCams != null)
                            {
                                foreach (cTrayResultSettings_CamItem oddCam in _Project.TrayResultSettings.OddCams)
                                {
                                    DataRow _Row = TrayResult_ProgramName.NewRow();
                                    _Row[cColName.Name] = cStrings.EvenCams;
                                    _Row[cColName.CAMID] = oddCam.CamID;
                                    _Row[cColName.CamName] = oddCam.Name;
                                    _Row[cColName.IsUseCustomTools] = oddCam.IsUseCustomTools.ToString();
                                    if (!MyConn.AddRow(_Row))
                                        return false;

                                    if (oddCam.IsUseCustomTools && oddCam.ToolsUse != null)
                                    {
                                        foreach (var actionID in oddCam.ToolsUse)
                                        {
                                            DataRow rowTool = TrayResult_ToolName.NewRow();
                                            rowTool[cColName.Name] = cStrings.OddCams;
                                            rowTool[cColName.CamName] = oddCam.Name;
                                            rowTool[cColName.ActionID] = actionID.ToString();
                                            if (!MyConn.AddRow(rowTool))
                                                return false;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case ETrayResult_SetupProgramToProductMode.Custom:
                        {
                            if (_Project.TrayResultSettings.CustomCams != null)
                            {
                                foreach (int customCamsKey in _Project.TrayResultSettings.CustomCams.Keys)
                                {
                                    List<cTrayResultSettings_CamItem> customCam = _Project.TrayResultSettings.CustomCams[customCamsKey];
                                    if (customCam != null)
                                    {
                                        foreach (cTrayResultSettings_CamItem camItem in customCam)
                                        {
                                            DataRow _Row = TrayResult_ProgramName.NewRow();
                                            _Row[cColName.Name] = customCamsKey.ToString();
                                            _Row[cColName.CAMID] = camItem.CamID;
                                            _Row[cColName.CamName] = camItem.Name;
                                            _Row[cColName.IsUseCustomTools] = camItem.IsUseCustomTools.ToString();
                                            if (!MyConn.AddRow(_Row))
                                                return false;

                                            if (camItem.IsUseCustomTools && camItem.ToolsUse != null)
                                            {
                                                foreach (var actionID in camItem.ToolsUse)
                                                {
                                                    DataRow rowTool = TrayResult_ToolName.NewRow();
                                                    rowTool[cColName.Name] = customCamsKey.ToString();
                                                    rowTool[cColName.CamName] = camItem.Name;
                                                    rowTool[cColName.ActionID] = actionID.ToString();
                                                    if (!MyConn.AddRow(rowTool))
                                                        return false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool OpenProject_TrayReSult_ProgramName(cProjectTypes _Project)
        {
            try
            {
                _Project.TrayResultSettings.EvenCams = new List<cTrayResultSettings_CamItem>();
                _Project.TrayResultSettings.OddCams = new List<cTrayResultSettings_CamItem>();
                _Project.TrayResultSettings.CustomCams = new Dictionary<int, List<cTrayResultSettings_CamItem>>();

                if (TrayResult_ProgramName == null)
                    return false;

                if (TrayResult_ToolName == null)
                    _TrayResult_ToolName = null;
                DataRow[] evenRows = _TrayResult_ProgramName.Select("Name='" + cStrings.EvenCams + "'");

                if (evenRows.Any())
                {
                    foreach (DataRow evenRow in evenRows)
                    {
                        cTrayResultSettings_CamItem camItem = new cTrayResultSettings_CamItem();
                        camItem.CamID = GlobFuncs.GetDataRowValue_Guid(evenRow, cColName.CAMID);
                        camItem.IsUseCustomTools = GlobFuncs.GetDataRowValue_Boolean(evenRow, cColName.IsUseCustomTools);
                        if (_Project.CAMs.ContainsKey(camItem.CamID))
                        {
                            camItem.Name = _Project.CAMs[camItem.CamID].Name;
                            if (_TrayResult_ToolName != null)
                            {
                                DataRow[] toolRows = _TrayResult_ToolName.Select("Name='" + cStrings.EvenCams + "'");
                                if (toolRows.Any())
                                {
                                    foreach (DataRow toolRow in toolRows)
                                    {
                                        camItem.ToolsUse.Add(GlobFuncs.GetDataRowValue_Guid(toolRow, cColName.ActionID));
                                    }
                                }
                            }

                            _Project.TrayResultSettings.EvenCams.Add(camItem);
                        }
                    }
                }
                DataRow[] oddRows = _TrayResult_ProgramName.Select("Name='" + cStrings.OddCams + "'");
                if (oddRows.Any())
                {
                    foreach (DataRow oddRow in oddRows)
                    {
                        cTrayResultSettings_CamItem camItem = new cTrayResultSettings_CamItem();
                        camItem.CamID = GlobFuncs.GetDataRowValue_Guid(oddRow, cColName.CAMID);
                        camItem.IsUseCustomTools = GlobFuncs.GetDataRowValue_Boolean(oddRow, cColName.IsUseCustomTools);
                        if (_Project.CAMs.ContainsKey(camItem.CamID))
                        {
                            camItem.Name = _Project.CAMs[camItem.CamID].Name;
                            if (_TrayResult_ToolName != null)
                            {
                                DataRow[] toolRows = _TrayResult_ToolName.Select("Name='" + cStrings.OddCams + "'");
                                if (toolRows.Any())
                                {
                                    foreach (DataRow toolRow in toolRows)
                                    {
                                        camItem.ToolsUse.Add(GlobFuncs.GetDataRowValue_Guid(toolRow, cColName.ActionID));
                                    }
                                }
                            }

                            _Project.TrayResultSettings.OddCams.Add(camItem);
                        }
                    }
                }
                DataTable names = TrayResult_ProgramName_Names;
                if (names != null)
                {
                    foreach (DataRow namesRow in names.Rows)
                    {
                        string name = GlobFuncs.GetDataRowValue_String(namesRow, cColName.Name);
                        if (name == cStrings.EvenCams || name == cStrings.OddCams)
                            continue;
                        if (!int.TryParse(name, out int iName))
                            continue;
                        DataRow[] customRows = _TrayResult_ProgramName.Select("Name='" + name + "'");
                        List<cTrayResultSettings_CamItem> camItems = new List<cTrayResultSettings_CamItem>();
                        if (oddRows.Any())
                        {
                            foreach (DataRow customRow in customRows)
                            {
                                cTrayResultSettings_CamItem camItem = new cTrayResultSettings_CamItem();
                                camItem.CamID = GlobFuncs.GetDataRowValue_Guid(customRow, cColName.CAMID);
                                camItem.IsUseCustomTools = GlobFuncs.GetDataRowValue_Boolean(customRow, cColName.IsUseCustomTools);
                                if (_Project.CAMs.ContainsKey(camItem.CamID))
                                {
                                    camItem.Name = _Project.CAMs[camItem.CamID].Name;
                                    if (_TrayResult_ToolName != null)
                                    {
                                        DataRow[] toolRows = _TrayResult_ToolName.Select("Name='" + name + "'");
                                        if (toolRows.Any())
                                        {
                                            foreach (DataRow toolRow in toolRows)
                                            {
                                                camItem.ToolsUse.Add(GlobFuncs.GetDataRowValue_Guid(toolRow, cColName.ActionID));
                                            }
                                        }
                                    }

                                    camItems.Add(camItem);
                                }
                            }
                            _Project.TrayResultSettings.CustomCams.Add(iName, camItems);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool SaveProject_ClearAllData_ProjectSettings()
        {
            try
            {
                if (!MyConn.Connect())
                    return false;

                bool Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ProjectList);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.ProjectSetting);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.TrayResult_Settings);
                if (Result) Result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.TrayResult_ProgramName);
                return Result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool SaveProject_RunningTemplate(cProjectTypes project)
        {
            try
            {
                if (!MyConn.Connect())
                    return false;
                if (RunningTemplate == null)
                    return false;
                MyConn.ExecuteQuery("SELETE FROM " + cTableName_SaveTemplate.RunningTemplate);
                if (!File.Exists(project.OldFileName))
                    return true;
                DataTable oldTemplate = Lib.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.RunningTemplate, project.OldFileName);
                if (oldTemplate == null)
                    return true;
                foreach (DataRow oldTemplateRow in oldTemplate.Rows)
                {
                    DataRow row = _runningTemplate.NewRow();
                    foreach (DataColumn oldTemplateColumn in oldTemplate.Columns)
                        row[oldTemplateColumn.ColumnName] = oldTemplateRow[oldTemplateColumn.ColumnName];
                    if (!MyConn.AddRow(row))
                        return false;
                }
                return true;
            }
            catch (Exception e)
            {
                GlobFuncs.SaveErr(e);
                return false;
            }
        }
        public bool SaveProject_RunningTemplateDetail(cProjectTypes project)
        {
            try
            {
                if (!MyConn.Connect())
                    return false;
                if (RunningTemplateDetail == null)
                    return false;
                MyConn.ExecuteQuery("SELETE FROM " + cTableName_SaveTemplate.RunningTemplate);
                if (!File.Exists(project.OldFileName))
                    return true;
                DataTable oldTemplate = Lib.GetDataTable("SELECT * FROM " + cTableName_SaveTemplate.RunningTemplate, project.OldFileName);
                if (oldTemplate == null)
                    return true;
                foreach (DataRow oldTemplateRow in oldTemplate.Rows)
                {
                    DataRow row = _runningTemplate.NewRow();
                    foreach (DataColumn oldTemplateColumn in oldTemplate.Columns)
                        row[oldTemplateColumn.ColumnName] = oldTemplateRow[oldTemplateColumn.ColumnName];
                    if (!MyConn.AddRow(row))
                        return false;
                }
                return true;
            }
            catch (Exception e)
            {
                GlobFuncs.SaveErr(e);
                return false;
            }
        }

        public bool SaveProject_ClearAll_CAMSettings(Guid camID)
        {
            if (!MyConn.Connect())
                return false;

            bool result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.CAMList + " WHERE ID = '" + camID.ToString() + "'");
            if (result) result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.CAMSettings + " WHERE CAMID= '" + camID.ToString() + "'");
            return result;
        }

        public bool SaveProject_ClearAll_CAMSettings()
        {
            try
            {
                if (!MyConn.Connect())
                    return false;

                bool result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.CAMList);
                if (result) result = MyConn.ExecuteQuery("DELETE FROM " + cTableName_SaveTemplate.CAMSettings);
                return result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool SaveProject_CAMSttings_Prepare(cProjectTypes _Project, cCAMTypes _CAM)
        {
            try
            {
                _CAM.GroupActions.FileName = _Project.FolderNameFullPath + Path.DirectorySeparatorChar + _CAM.FileName_Actions + cExtFile.GroupD;
                _CAM.GroupActions.FileNameIconic = _Project.FolderNameFullPath + Path.DirectorySeparatorChar + _CAM.FileName_Actions + cExtFile.GroupIconicD;
                if (!File.Exists(_CAM.GroupActions.FileName))
                    File.Copy(GlobVar.RTCVision.Files.SaveTemplate, _CAM.GroupActions.FileName, true);

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool SaveProject_CAMs_CamList(cCAMTypes _CAM)
        {
            try
            {
                if (CAMList == null)
                    return false;

                DataRow row = _CAMList.NewRow();
                row[cColName.ID] = _CAM.ID;
                row[cColName.GroupID] = _CAM.GroupID;
                row[cColName.STT] = _CAM.STT;
                row[cColName.RunOrder] = _CAM.RunOrder;
                row[cColName.Name] = _CAM.Name;

                if (!MyConn.AddRow(row))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool SaveProject_CAMs_CamSettings(cCAMTypes _CAM)
        {
            try
            {
                if (CAMSettings == null)
                    return false;

                bool result = false;

                PropertyInfo[] pCAMSettings = _CAM.GetType().GetProperties();
                foreach (PropertyInfo item in pCAMSettings)
                {
                    DataRow r = _CAMSettings.NewRow();
                    SetNullValueToDataRow(r);
                    r[cColName.CAMID] = _CAM.ID;
                    r[cColName.PropName] = item.Name;

                    switch (item.PropertyType.Name)
                    {
                        case "String":
                            r[cColName.ValueT] = item.GetValue(_CAM, null)?.ToString();
                            break;
                        case "Boolean":
                            r[cColName.ValueT] = item.GetValue(_CAM, null)?.ToString().ToLower();
                            break;
                        case "Int32":
                            r[cColName.ValueI] = (int)item.GetValue(_CAM, null);
                            break;
                        case "ECamTypes":
                            r[cColName.ValueI] = (int)item.GetValue(_CAM, null);
                            break;
                        case "List`1":
                            if (item.PropertyType == typeof(List<string>))
                            {
                                List<string> obj = (List<string>)item.GetValue(_CAM, null);
                                r[cColName.ValueT] = string.Join(",", obj.ToArray());
                            }
                            break;
                        default:
                            continue;
                    }
                    result = MyConn.AddRow(r);
                    if (!result) break;
                }
                if (_CAM.GroupActions.SourceImageSettings.CameraSettings.PropCompareDefault != null)
                {
                    foreach (cPropCompare item in _CAM.GroupActions.SourceImageSettings.CameraSettings.PropCompareDefault.Values)
                    {
                        DataRow r = _CAMSettings.NewRow();
                        SetNullValueToDataRow(r);
                        r[cColName.CAMID] = _CAM.ID;
                        r[cColName.PropName] = cStrings.PropCompareDefault + "." + item.PropCAMName;

                        if (item.DataType == typeof(double))
                            r[cColName.ValueD] = item.DValue;
                        else if (item.DataType == typeof(string))
                            r[cColName.ValueT] = item.SValue;

                        result = MyConn.AddRow(r);
                        if (result) break;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public void SaveProject_CAM(cProjectTypes _Project, cCAMTypes cam)
        {
            cam.SaveSuccess = false;
            GroupActionsData groupActionsData = new GroupActionsData();
            cam.GroupActions.SavePart();
            if (groupActionsData.Connect(cam.GroupActions.FileName))
            {
                groupActionsData.Myconn.StartTransaction();
                groupActionsData.Myconn.ExecuteQuery("PRAGMA journal_mode = WAL");
                groupActionsData.Myconn.ExecuteQuery("PRAGMA synchronous = NORMAL");

                cam.SaveSuccess = groupActionsData.ClearAllData();

                // Save Group
                if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveGroup(cam.GroupActions);

                // Lưu ComputerSettings
                if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveGroup_ComputerSettings(cam.GroupActions);

                // Lưu CameraSettings
                if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveGroup_CameraSettings(cam.GroupActions);

                //if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveGroup_ManualDeviceCameraList(cam.GroupActions);

                if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveGroup_SourceImages(cam.GroupActions);

                //if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveGroup_Communications(cam.GroupActions);
                // Lưu dữ liệu Trigger
                if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveGroup_Trigger(cam.GroupActions);

                if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveGroup_Info(cam.GroupActions);

                // Lưu ActionList
                if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveActionList(cam.GroupActions);

               // if (cam.SaveSuccess) cam.SaveSuccess = groupActionsData.SaveActionList_Iconic(cam.GroupActions);

                groupActionsData.Myconn.Commit();
                groupActionsData.Disconnect();
            }
            else
                cam.SaveSuccess = false;
        }

        public void SaveProject_CAMs(cProjectTypes _Project)
        {
            _Project.SaveSuccess = SaveProject_ClearAll_CAMSettings();
            foreach (cCAMTypes _CAM in _Project.CAMs.Values)
            {
                if (_Project.SaveSuccess) _Project.SaveSuccess = SaveProject_CAMSttings_Prepare(_Project, _CAM);
                if (_Project.SaveSuccess) _Project.SaveSuccess = SaveProject_CAMs_CamList(_CAM);
                if (_Project.SaveSuccess) _Project.SaveSuccess = SaveProject_CAMs_CamSettings(_CAM);
            }

            if (_Project.SaveSuccess)
            {
                foreach (cCAMTypes _CAM in _Project.CAMs.Values)
                    SaveProject_CAM(_Project, _CAM);
                //List<Task> lstTask = new List<Task>();
                //foreach (cCAMTypes _CAM in _Project.CAMs.Values)
                //{
                //    Task task = Task.Factory.StartNew(() => SaveProject_CAM(_Project, _CAM));
                //    lstTask.Add(task);
                //}
                //Task t = Task.WhenAll(lstTask);
                //try
                //{
                //    t.Wait();
                //}
                //catch { }

                //foreach (cCAMTypes _CAM in _Project.CAMs.Values)
                //{
                //    if (!_CAM.SaveSuccess)
                //    {
                //        _Project.SaveSuccess = false;
                //        break;
                //    }
                //}
            }
        }
        public bool SaveProject_OneCam(cProjectTypes _Project, Guid CamID)
        {
            cCAMTypes _CAM = _Project.CAMs[CamID];
            bool result = SaveProject_ClearAll_CAMSettings(_CAM.ID);
            if (result) result = SaveProject_CAMSttings_Prepare(_Project, _CAM);
            if (result) result = SaveProject_CAMs_CamList(_CAM);
            if (result) result = SaveProject_CAMs_CamSettings(_CAM);
            if (result) result = SaveProject_CAMSttings_Prepare(_Project, _CAM);
            if (result) SaveProject_CAM(_Project, _CAM);
            result = _CAM.SaveSuccess;
            return result;
        }
        #endregion
    }

    class cData
    {
    }
}
