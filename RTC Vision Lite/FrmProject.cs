using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmProject : Form
    {
        public FrmProject()
        {
            InitializeComponent();
        }
        #region VAR

        private DataTable dataTable;

        #endregion

        #region Properties

        private cProjectTypes project = null;

        public cProjectTypes Project
        {
            get => project;
            set => project = value;
        }

        private bool isAdd;

        public bool IsAdd
        {
            get => isAdd;
            set => isAdd = value;
        }

        #endregion

        #region FUNCTIONS NEW
        /// <summary>
        /// Create DataTable
        /// </summary>
        private void CreateDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(cColName.ID, typeof(Guid));
            dataTable.Columns.Add(cColName.IsGroup, typeof(bool));
            dataTable.Columns.Add(cColName.GroupID, typeof(Guid));
            dataTable.Columns.Add(cColName.OrderNum, typeof(int));
            dataTable.Columns.Add(cColName.RunOrder, typeof(int));
            dataTable.Columns.Add(cColName.Name, typeof(string));
            dataTable.Columns.Add(cColName.Description, typeof(string));
            dataTable.Columns.Add(cColName.Image, typeof(string));
            dataTable.Columns.Add(cColName.IsActive, typeof(bool));
            dataTable.Columns.Add(cColName.IsMaster, typeof(bool));
            dataTable.Columns.Add(cColName.IsBackground, typeof(bool));
            dataTable.Columns.Add(cColName.IsAlign, typeof(bool));
            dataTable.Columns.Add(cColName.IsChangeJob, typeof(bool));
            dataTable.Columns.Add(cColName.IsHide, typeof(bool));
            dataTable.Columns.Add(cColName.IsViewResult, typeof(bool));
            dataTable.Columns.Add(cColName.IsJoinResult, typeof(bool));
            dataTable.Columns.Add(cColName.IsMaximize, typeof(bool));
            dataTable.Columns.Add(cColName.FileName_Actions, typeof(string));
            //dataTable.Columns.Add(cColName.FileName_TemplateImage, typeof(string));

            var keys = new DataColumn[1];
            keys[0] = dataTable.Columns[cColName.ID];
            dataTable.PrimaryKey = keys;

            grdData.DataSource = dataTable;
        }
        /// <summary>
        /// Add cam to datatable
        /// </summary>
        /// <param name=""></param>
        private void AddCamToDataTable(cCAMTypes cam)
        {
            if (dataTable == null)
                CreateDataTable();
            if (dataTable == null)
                return;
            DataRow newRow = dataTable.NewRow();
            newRow[cColName.ID] = cam.ID;
            newRow[cColName.GroupID] = cam.GroupID;
            newRow[cColName.IsGroup] = false;
            newRow[cColName.OrderNum] = cam.STT;
            newRow[cColName.Name] = cam.Name;
            newRow[cColName.RunOrder] = cam.RunOrder;
            newRow[cColName.Description] = cam.Description;
            newRow[cColName.Image] = cStrings.SetImage;
            newRow[cColName.IsActive] = cam.IsActive;
            newRow[cColName.IsMaster] = cam.IsMaster;
            newRow[cColName.IsAlign] = cam.IsAlign;
            newRow[cColName.IsChangeJob] = cam.IsChangeJob;
            newRow[cColName.IsBackground] = cam.IsBackground;
            newRow[cColName.IsHide] = cam.IsHide;
            newRow[cColName.IsViewResult] = cam.IsViewResult;
            newRow[cColName.IsJoinResult] = cam.IsJoinResult;
            newRow[cColName.IsMaximize] = cam.IsMaximize;
            newRow[cColName.FileName_Actions] = cam.FileName_Actions;
            //newRow[cColName.FileName_TemplateImage] = cam.GroupActions.SourceImageSettings.MasterImage;
            dataTable.Rows.Add(newRow);
        }
        /// <summary>
        /// Insert a camera to data table
        /// </summary>
        /// <param name="cam"></param>
        /// <param name="pos"></param>
        private void InsertCamToDataTable(cCAMTypes cam, int pos)
        {
            if (dataTable == null)
                CreateDataTable();
            if (dataTable == null)
                return;
            DataRow newRow = dataTable.NewRow();
            newRow[cColName.ID] = cam.ID;
            newRow[cColName.GroupID] = cam.GroupID;
            newRow[cColName.IsGroup] = false;
            newRow[cColName.OrderNum] = cam.STT;
            newRow[cColName.Name] = cam.Name;
            newRow[cColName.RunOrder] = cam.RunOrder;
            newRow[cColName.Description] = cam.Description;
            newRow[cColName.Image] = cStrings.SetImage;
            newRow[cColName.IsActive] = cam.IsActive;
            newRow[cColName.IsMaster] = cam.IsMaster;
            newRow[cColName.IsAlign] = cam.IsAlign;
            newRow[cColName.IsChangeJob] = cam.IsChangeJob;
            newRow[cColName.IsBackground] = cam.IsBackground;
            newRow[cColName.IsHide] = cam.IsHide;
            newRow[cColName.IsViewResult] = cam.IsViewResult;
            newRow[cColName.IsJoinResult] = cam.IsJoinResult;
            newRow[cColName.IsMaximize] = cam.IsMaximize;
            newRow[cColName.FileName_Actions] = cam.FileName_Actions;
            //newRow[cColName.FileName_TemplateImage] = cam.GroupActions.SourceImageSettings.MasterImage;
            dataTable.Rows.InsertAt(newRow, pos);
        }

        /// <summary>
        /// Insert a group camera to data table
        /// </summary>
        /// <param name="cam"></param>
        /// <param name="pos"></param>
        private void AddGroupCamToDataTable(cGroupCAMTypes groupCam)
        {
            if (dataTable == null)
                CreateDataTable();
            if (dataTable == null)
                return;
            DataRow newRow = dataTable.NewRow();
            newRow[cColName.ID] = groupCam.ID;
            newRow[cColName.GroupID] = Guid.Empty;
            newRow[cColName.IsGroup] = true;
            newRow[cColName.OrderNum] = -1;
            newRow[cColName.Name] = groupCam.Name;
            newRow[cColName.RunOrder] = -1;
            newRow[cColName.Description] = groupCam.Description;
            newRow[cColName.Image] = string.Empty;
            newRow[cColName.IsActive] = false;
            newRow[cColName.IsMaster] = false;
            newRow[cColName.IsAlign] = false;
            newRow[cColName.IsChangeJob] = false;
            newRow[cColName.IsBackground] = false;
            newRow[cColName.IsHide] = false;
            newRow[cColName.IsViewResult] = false;
            newRow[cColName.IsJoinResult] = false;
            newRow[cColName.IsMaximize] = false;
            newRow[cColName.FileName_Actions] = string.Empty;
            //newRow[cColName.FileName_TemplateImage] = string.Empty;
            dataTable.Rows.Add(newRow);
        }

        /// <summary>
        /// Loads camera to data table
        /// </summary>
        private void LoadCamToDataTable()
        {
            var orderCAM = Project.CAMs.OrderBy(x => x.Value.STT).ToList();
            Guid _GroupID = Guid.Empty;
            foreach(var t in orderCAM)
            {
                cCAMTypes _CAM = t.Value;

                if (_CAM.IsChangeJobMasterCam() || _CAM.IsAlignMasterCam())
                    continue;

                if (_CAM.GroupID == Guid.Empty) // CAM thường
                    AddCamToDataTable(_CAM);
                else if (_CAM.GroupID != _GroupID)
                {
                    if (Project.GroupCAMs.ContainsKey(_GroupID))
                    {
                        cGroupCAMTypes _GroupCAM = Project.GroupCAMs[_GroupID];
                        AddGroupCamToDataTable(_GroupCAM);
                        _GroupID = _CAM.GroupID;
                    }
                    else
                        _CAM.GroupID = Guid.Empty;

                    AddCamToDataTable(_CAM);
                }
                else
                    AddCamToDataTable(_CAM);
            }

            cCAMTypes alignCam = Project.CAMs.Values.FirstOrDefault(x => x.IsAlignMasterCam());
            if (alignCam != null)
                AddCamToDataTable(alignCam);

            cCAMTypes changeJobCam = Project.CAMs.Values.FirstOrDefault(x => x.IsChangeJobMasterCam());
            if (changeJobCam != null)
                AddCamToDataTable(changeJobCam);

            grdData.DataSource = dataTable;
        }

        #endregion

        private void NumberedOrderCAM()
        {
            Project.STTCAM = 1;
            Project.STTGroupCAM = 1;
            foreach(DataRow row in dataTable.Rows)
                if((bool)row[cColName.IsGroup])
                {
                    row[cColName.OrderNum] = Project.STTGroupCAM;
                    Project.GroupCAMs[(Guid)row[cColName.ID]].STT = Project.STTGroupCAM;
                    Project.STTGroupCAM += 1;
                }
                else
                {
                    row[cColName.OrderNum] = Project.STTCAM;
                    Project.CAMs[(Guid)row[cColName.ID]].STT = Project.STTCAM;
                    Project.STTCAM += 1;
                }
        }

        /// <summary>
        /// View project data to form
        /// </summary>
        private void ViewProjectDataToForm()
        {
            GlobVar.LockEvents = true;
            if (project == null)
                project = new cProjectTypes();
            if(isAdd && GlobVar.DicProject != null)
            {
                cProjectTypes ProjectsValue = GlobVar.DicProject.Values.OrderByDescending(x => x.OrderNum).FirstOrDefault();
                if (ProjectsValue != null)
                    Project.OrderNum = ProjectsValue.OrderNum + 1;
            }
            chkPinned.Checked = Project.Pinned;
            txtModelName.Text = Project.ProjectName;
            txtModelNote.Text = Project.Note;
            txtSaveFolder.Text = Project.FolderNameFullPath;
            nmrModelID.Value = Project.OrderNum;
            txtModelImage.Text = "";

            LoadCamToDataTable();

            GlobVar.LockEvents = false;
        }

        private void AddCam(ECamTypes eCamTypes = ECamTypes.Normal)
        {
            cCAMTypes newCam = new cCAMTypes(Project)
            {
                IsAlign = (eCamTypes == ECamTypes.Align),
                IsChangeJob = (eCamTypes == ECamTypes.ChangeJob),
                STT = Project.STTCAM,
                RunOrder = Project.STTCAM
            };

            Project.STTCAM += 1;
            newCam.BuildDefaultName();
            newCam.BuildDefaultFileNameActions();

            Project.CAMs.Add(newCam.ID, newCam);
            AddCamToDataTable(newCam);
            NumberedOrderCAM();
        }

        /// <summary>
        /// Thêm nhóm CAM
        /// </summary>
        private void AddGroupCam(object sender, EventArgs e)
        {
            cGroupCAMTypes newGroupCam = new cGroupCAMTypes();
            newGroupCam.STT = Project.STTGroupCAM;
            newGroupCam.BuildDefaultName();
            Project.STTGroupCAM += 1;
            Project.GroupCAMs.Add(newGroupCam.ID, newGroupCam);

            AddGroupCamToDataTable(newGroupCam);
            NumberedOrderCAM();
        }

        /// <summary>
        /// Adds camera to group camera
        /// </summary>
        private void AddCamToGroupCam(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Copies the camera.
        /// </summary>
        private void CloneCam(object sender, EventArgs e)
        {
            int rowHandle = grdData.CurrentCell.RowIndex;
            if (rowHandle < 0)
                return;

            DataRow currentRow = ((grdData.DataSource) as DataTable).Rows[rowHandle];
            if ((bool)currentRow[cColName.IsGroup])
                return;
            cCAMTypes sourceCam = Project.CAMs[(Guid)currentRow[cColName.ID]];

            cCAMTypes cloneCam = new cCAMTypes(Project)
            {
                STT = Project.STTCAM,
                RunOrder = Project.STTCAM,
                GroupID = sourceCam.GroupID,
                IsActive = sourceCam.IsActive,
                IsMaster = sourceCam.IsMaster,
                IsBackground = sourceCam.IsBackground,
                IsHide = sourceCam.IsHide,
                IsViewResult = sourceCam.IsViewResult,
                IsAlign = sourceCam.IsAlign,
                IsChangeJob = sourceCam.IsChangeJob,
                Description = sourceCam.Description
            };

            Project.STTCAM += 1;

            cloneCam.BuildDefaultName();
            cloneCam.BuildDefaultFileNameActions();

            Project.CAMs.Add(cloneCam.ID, cloneCam);
            int insertIndex = dataTable.Rows.IndexOf(currentRow) + 1;
            if (dataTable.Rows.Count > insertIndex)
                InsertCamToDataTable(cloneCam, insertIndex);
            else
                AddCamToDataTable(cloneCam);

            NumberedOrderCAM();
        }

        /// <summary>
        /// Deletes the camera
        /// </summary>
        private void DeleteCam(object sender, EventArgs e)
        {
            int rowHandle = grdData.CurrentCell.RowIndex;
            if (rowHandle < 0)
                return;

            DataRow currentRow = ((grdData.DataSource) as DataTable).Rows[rowHandle];
            if ((bool)currentRow[cColName.IsGroup])
            {
                if (cMessageBox.Question_YesNo(cMessageContent.BuildMessage(cMessageContent.Que_DeleteObject,
                    new string[] { cStrings.GroupCAM }, new string[] { cStrings.GroupCAMV })) == DialogResult.No) return;
                DataRow[] listRowCamOfGroup = dataTable.Select( cColName.GroupID + "='" + currentRow[cColName.GroupID].ToString() + "'");
                foreach(DataRow row in listRowCamOfGroup)
                {
                    Project.CAMs.Remove((Guid)row[cColName.ID]);
                    dataTable.Rows.Remove(row);
                    Project.GroupCAMs.Remove((Guid)currentRow[cColName.ID]);
                    dataTable.Rows.Remove(currentRow);
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không ?", "",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                Project.CAMs.Remove((Guid)currentRow[cColName.ID]);
                dataTable.Rows.Remove(currentRow);
            }
            NumberedOrderCAM();
        }

        /// <summary>
        /// Deletes all camera
        /// </summary>
        private void DeleteAllCam(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            Project.CAMs.Clear();
            Project.GroupCAMs.Clear();
            Project.STTCAM = 1;
            Project.STTGroupCAM = 1;
            dataTable.Rows.Clear();
        }
        //TODO: 23022024 - Chỉnh sửa MoveCamUp/Down
        private void MoveCamUp(object sender, EventArgs e)
        {
            int rowHandle = grdData.CurrentCell.RowIndex;
            if (rowHandle <= 0)
                return;

            DataRow currentRow = ((grdData.DataSource) as DataTable).Rows[rowHandle];
            DataRow upRow = ((grdData.DataSource) as DataTable).Rows[rowHandle - 1];

            if ((Guid)currentRow[cColName.GroupID] != Guid.Empty &&
                (Guid)upRow[cColName.GroupID] != Guid.Empty)
            {
                DataRow firstRowOfGroup = dataTable.Select(cColName.GroupID + "='" + ((Guid)upRow[cColName.GroupID]).ToString() + "'",
                    cColName.OrderNum + " ASC").FirstOrDefault();

                if (firstRowOfGroup != null)
                {
                    int upIndex = dataTable.Rows.IndexOf(firstRowOfGroup) - 1;

                    if (upIndex >= 0)
                    {
                        upRow = dataTable.Rows[upIndex];
                        if ((bool)upRow[cColName.IsGroup])
                        {
                            upIndex -= 1;
                        }
                    }
                    else
                        return;

                    if (upIndex >= 0)
                        upRow = dataTable.Rows[upIndex];
                    else
                        return;
                }
                else
                    return;
            }
            DataRow backupCurrentRow = dataTable.Clone().NewRow();
            DataRow backupUpRow = dataTable.Clone().NewRow();
            backupCurrentRow.ItemArray = currentRow.ItemArray.Clone() as object[] ?? Array.Empty<object>();
            backupUpRow.ItemArray = upRow.ItemArray.Clone() as object[] ?? Array.Empty<object>();

            upRow[cColName.ID] = Guid.Empty;
            currentRow.ItemArray = backupUpRow.ItemArray.Clone() as object[] ?? Array.Empty<object>();
            upRow.ItemArray = backupCurrentRow.ItemArray.Clone() as object[] ?? Array.Empty<object>();
            //grdData.CurrentCell.Value = rowHandle - 1;
            if (rowHandle != 0)
                FocusOnRow(rowHandle - 1);
            NumberedOrderCAM();
        }

        /// <summary>
        /// Move camera down
        /// </summary>
        private void MoveCAMDown(object sender, EventArgs e)
        {
            int rowHandle = grdData.CurrentCell.RowIndex;
            if (rowHandle >= dataTable.Rows.Count - 1)
                return;

            DataRow currentRow = ((grdData.DataSource) as DataTable).Rows[rowHandle];
            DataRow downRow = ((grdData.DataSource) as DataTable).Rows[rowHandle + 1];

            if ((Guid)currentRow[cColName.GroupID] != Guid.Empty &&
                (Guid)downRow[cColName.GroupID] != (Guid)currentRow[cColName.GroupID])
                return;

            if (((Guid)currentRow[cColName.GroupID] == Guid.Empty && (Guid)downRow[cColName.GroupID] != Guid.Empty) ||
                    (bool)downRow[cColName.IsGroup])
            {
                DataRow lastRowOfGroup = null;

                if ((bool)downRow[cColName.IsGroup])
                    lastRowOfGroup = dataTable.Select(cColName.GroupID + "='" + ((Guid)downRow[cColName.GroupID]).ToString() + "'",
                    cColName.OrderNum + " DESC").FirstOrDefault();
                else
                    dataTable.Select(cColName.GroupID + "='" + ((Guid)downRow[cColName.GroupID]).ToString() + "'",
                            cColName.OrderNum + " DESC").FirstOrDefault();

                if (lastRowOfGroup != null)
                {
                    int downIndex = dataTable.Rows.IndexOf(lastRowOfGroup) + 1;
                    if (downIndex <= dataTable.Rows.Count - 1)
                        downRow = dataTable.Rows[downIndex];
                    else
                        return;
                }
                else
                    return;
            }
            DataRow backupCurrentRow = dataTable.Clone().NewRow();
            DataRow backupDownRow = dataTable.Clone().NewRow();
            backupCurrentRow.ItemArray = currentRow.ItemArray.Clone() as object[] ?? Array.Empty<object>();
            backupDownRow.ItemArray = downRow.ItemArray.Clone() as object[] ?? Array.Empty<object>();

            downRow[cColName.ID] = Guid.Empty;
            currentRow.ItemArray = backupDownRow.ItemArray.Clone() as object[] ?? Array.Empty<object>();
            downRow.ItemArray = backupCurrentRow.ItemArray.Clone() as object[] ?? Array.Empty<object>();
            //grdData.CurrentCell.Value = rowHandle + 1;
            FocusOnRow(rowHandle + 1);
            NumberedOrderCAM();
        }
        private void FocusOnRow(int rowIndex)
        {
            try
            {
                if (rowIndex >= 0 && rowIndex < grdData.Rows.Count)
                {
                    grdData.Rows[rowIndex].Selected = true;
                    grdData.CurrentCell = grdData.Rows[rowIndex].Cells[4];
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        private void FrmProject_Load(object sender, EventArgs e)
        {
            ViewProjectDataToForm();
        }

        private void FrmProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();
        }
        //TODO: 23022024 - Chỉnh sửa SetImage
        private void btnSetImage_Click(object sender, EventArgs e)
        {
            txtModelImage.Text = GlobFuncs.GetFileName(cFilterFileName.ImageFilter);
        }
        //TODO: 23022024 - Chỉnh sửa Save Project
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtModelName.Text.Trim() == "")
            {
                MessageBox.Show("Model name không được để trống. \nVui lòng thử lại sau !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModelName.Focus();
                return;
            }
            if (nmrModelID.Text.Trim() == "")
            {
                MessageBox.Show("Model ID không được để trống. \nVui lòng thử lại sau !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmrModelID.Focus();
                return;
            }
            int.TryParse(nmrModelID.Value.ToString(), out int orderNumber);

            foreach (cProjectTypes item in GlobVar.DicProject.Values)
            {
                if (IsAdd && item.ProjectName.ToLower() == txtModelName.Text.Trim().ToLower())
                {
                    MessageBox.Show("Đã tồn tại. \nVui lòng thử lại sau !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtModelName.Focus();
                    return;
                }
                else if ((IsAdd && item.OrderNum == orderNumber) || (!IsAdd && item.ID != project.ID && item.OrderNum == orderNumber))
                {
                    MessageBox.Show("Đã tồn tại. \nVui lòng thử lại sau !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nmrModelID.Focus();
                    return;
                }
                else if (IsAdd && item.ID != project.ID && item.ProjectName.ToLower() == txtModelName.Text.Trim().ToLower())
                {
                    MessageBox.Show("Đã tồn tại. \nVui lòng thử lại sau !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtModelName.Focus();
                    return;
                }
            }

            if (grdData.RowCount <= 0)
            {
                MessageBox.Show("Phải có ít nhất 1 phần tử. \nVui lòng thử lại sau !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grdData.Focus();
                return;
            }

            Project.ProjectName = txtModelName.Text.Trim();
            Project.OrderNum = orderNumber;
            Project.Note = txtModelNote.Text.Trim();
            Project.FolderNameFullPath = txtSaveFolder.Text;
            Project.Pinned = chkPinned.Checked;
            Project.PreviewImage = txtModelImage.Text;
            if (IsAdd)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Project.FolderNameFullPath);
                Project.FolderName = directoryInfo.Name;
                Project.FileName = Project.FolderNameFullPath + Path.DirectorySeparatorChar + Project.FolderName + cExtFile.ProjD;
                Project.OldFileName = Project.FileName;
                foreach (cCAMTypes _CAM in Project.CAMs.Values)
                {
                    _CAM.FileName_Actions = GlobFuncs.SwitchToUnsigned(_CAM.Name);
                    _CAM.BuildDefaultFolderPath(Project.FolderNameFullPath);
                    _CAM.BuidDefaultSettingsSaveImage(Project.FolderNameFullPath);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Project.FolderNameFullPathBAK) && Project.FolderNameFullPath.ToLower() != Project.FolderNameFullPathBAK.ToLower())
                {
                    Project.FolderName = Path.GetFileName(Project.FolderNameFullPath);
                    Project.OldFileName = Path.Combine(Project.FolderNameFullPath, Path.GetFileName(Project.FileName));
                    Project.FileName = Project.FolderNameFullPath + Path.DirectorySeparatorChar + Project.FolderName + cExtFile.ProjD;
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void txtModelName_TextChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents || project == null) return;

            if (txtModelName.Text.Trim() == "")
                txtSaveFolder.Text = GlobVar.RTCVision.Paths.Projects;
            else
                txtSaveFolder.Text = GlobVar.RTCVision.Paths.Projects + Path.DirectorySeparatorChar + GlobFuncs.SwitchToUnsigned(
                    GlobFuncs.RemoveSpecialCharacters(txtModelName.Text.Trim()));

            project.DataChange = true;
        }

        private void btnAddCAM_Click(object sender, EventArgs e)
        {
            AddCam();
        }

        private void nmrModelID_ValueChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents || project == null) return;
            project.DataChange = true;
        }

        private void txtModelNote_TextChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents || project == null) return;
            project.DataChange = true;
        }
        private void grdData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || GlobVar.LockEvents)
                    return;
                grdData.Update();
                DataTable dt = (DataTable)grdData.DataSource;
                DataRow row = dt.Rows[e.RowIndex];
                if (!(bool)row[cColName.IsGroup])
                {
                    cCAMTypes cam = Project.CAMs[Guid.Parse(row[cColName.ID].ToString())];
                    if (e.ColumnIndex == 5)
                        grdData_CellValueChanged_Name(cam, e);
                    else if (e.ColumnIndex == 6)
                        grdData_CellValueChanged_Description(cam, e);
                    else if (e.ColumnIndex == 8)
                        grdData_CellValueChanged_Active(cam, e);
                    else if (e.ColumnIndex == 9)
                        grdData_CellValueChanged_Master(cam, e);
                    else if (e.ColumnIndex == 10)
                        grdData_CellValueChanged_Background(cam, e);
                    else if (e.ColumnIndex == 11)
                        grdData_CellValueChanged_Align(cam, e);
                    else if (e.ColumnIndex == 12)
                        grdData_CellValueChanged_ChangeJob(cam, e);
                    else if (e.ColumnIndex == 13)
                        grdData_CellValueChanged_Hide(cam, e);
                    else if (e.ColumnIndex == 14)
                        grdData_CellValueChanged_ViewResult(cam, e);
                    else if (e.ColumnIndex == 15)
                        grdData_CellValueChanged_JoinResult(cam, e);
                    else if (e.ColumnIndex == 16)
                        grdData_CellValueChanged_Maximine(cam, e);
                    else if (e.ColumnIndex == 4)
                        grdData_CellValueChanged_RunOrder(cam, e);
                }
                else
                {
                    cGroupCAMTypes groupCam = Project.GroupCAMs[Guid.Parse(row[cColName.ID].ToString())];
                    if (e.ColumnIndex == 5)
                    {
                        string snewName = row["Name"]?.ToString();
                        if (string.IsNullOrEmpty(snewName))
                        {
                            cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty, new string[] { "Group Name" }, new string[] { "Tên nhóm" }));
                            GlobVar.LockEvents = true;
                            row[cColName.Name] = groupCam.Name;
                            GlobVar.LockEvents = false;
                            return;
                        }
                        else
                        {
                            cGroupCAMTypes groupCamHaveSampleName = Project.GroupCAMs.Values.FirstOrDefault(x => x.Name.Trim().ToLower() == snewName.Trim().ToLower());
                            if (groupCamHaveSampleName != null)
                            {
                                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists, new string[] { "Group Name" }, new string[] { "Tên nhóm" }));
                                GlobVar.LockEvents = true;
                                row[cColName.Name] = groupCam.Name;
                                GlobVar.LockEvents = false;
                                return;
                            }
                        }
                        groupCam.Name = snewName;
                        row[cColName.Description] = groupCam.Name;
                        project.DataChange = true;
                    }
                    else if (e.RowIndex == 6)
                    {
                        groupCam.Description = row["Description"]?.ToString();
                        row[cColName.Description] = groupCam.Description;
                        project.DataChange = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
            }
        }
        private void grdData_CellValueChanged_Name(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt_name = (DataTable)grdData.DataSource;
            DataRow row = dt_name.Rows[e.RowIndex];
            string snewName = row["Name"]?.ToString();
            if (string.IsNullOrEmpty(snewName))
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty, new string[] { "Cam name" }, new string[] { "Tên cam" }));
                GlobVar.LockEvents = true;
                row[cColName.Name] = cam.Name;
                GlobVar.LockEvents = false;
            }
            else
            {
                cCAMTypes camHaveSampleName = Project.CAMs.Values.FirstOrDefault(x => x.Name.Trim().ToLower() == snewName.Trim().ToLower());
                if (camHaveSampleName != null)
                {
                    cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists, new string[] { "Cam name" }, new string[] { "Tên cam" }));
                    GlobVar.LockEvents = true;
                    row[cColName.Name] = cam.Name;
                    GlobVar.LockEvents = false;
                    return;
                }
            }
            cam.Name = snewName;
            row[cColName.Name] = cam.Name;
            project.DataChange = true;
        }
        private void grdData_CellValueChanged_Description(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.Description = row["Description"]?.ToString();
            project.DataChange = true;
        }
        private void grdData_CellValueChanged_Active(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.IsActive = (bool)row["IsActive"];
            row[cColName.IsActive] = cam.IsActive;
            project.DataChange = true;
        }
        private void grdData_CellValueChanged_Hide(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.IsHide = (bool)row["IsHide"];
            row[cColName.IsHide] = cam.IsHide;
            project.DataChange = true;
        }
        private void grdData_CellValueChanged_Master(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            row[cColName.IsMaster] = cam.IsMaster;
            project.DataChange = true;
            if (cam.IsAlign && cam.IsMaster)
            {
                var listCamAligns = Project.CAMs.Values.Where(x => x.IsAlign && x.GroupID == cam.GroupID && x.ID != cam.ID).ToList();
                if (listCamAligns.Any())
                    foreach (cCAMTypes otherAlignCam in listCamAligns)
                    {
                        otherAlignCam.IsMaster = false;
                        dataTable.Rows.Find(otherAlignCam.ID)[cColName.IsMaster] = false;
                    }
            }
            else if (cam.IsChangeJob && cam.IsMaster)
            {
                var listCamChanJobs = Project.CAMs.Values.Where(x => x.IsChangeJob && x.GroupID == cam.GroupID && x.ID != cam.ID).ToList();
                if (listCamChanJobs.Any())
                {
                    foreach (cCAMTypes otherCJCam in listCamChanJobs)
                    {
                        otherCJCam.IsMaster = false;
                        dataTable.Rows.Find(otherCJCam)[cColName.IsMaster] = false;
                    }
                }
            }
        }
        private void grdData_CellValueChanged_Background(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.IsBackground = (bool)row["IsBackground"];
            row[cColName.IsBackground] = cam.IsBackground;
            project.DataChange = true;
        }
        private void grdData_CellValueChanged_Align(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.IsAlign = (bool)row["IsAlign"];
            row[cColName.IsAlign] = cam.IsAlign;
            project.DataChange = true;
            if (cam.IsAlign)
            {
                cam.IsChangeJob = false;
                row[cColName.IsChangeJob] = cam.IsChangeJob;
            }
            if (cam.IsAlign && cam.IsMaster)
            {
                var listCamAligns = Project.CAMs.Values.Where(x => x.IsAlign && x.GroupID == cam.GroupID && x.ID != cam.ID).ToList();
                if (listCamAligns.Any())
                {
                    foreach (cCAMTypes otherAlignCam in listCamAligns)
                    {
                        otherAlignCam.IsMaster = false;
                        dataTable.Rows.Find(otherAlignCam.ID)[cColName.IsMaster] = false;
                    }
                }
            }
        }
        private void grdData_CellValueChanged_ChangeJob(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.IsChangeJob = (bool)row["IsChangeJob"];
            row[cColName.IsChangeJob] = cam.IsChangeJob;
            project.DataChange = true;
            if (cam.IsChangeJob)
            {
                cam.IsAlign = false;
                row[cColName.IsAlign] = cam.IsAlign;
            }
            if (cam.IsChangeJob && cam.IsMaster)
            {
                var listCamChanJobs = Project.CAMs.Values.Where(x => x.IsChangeJob && x.GroupID == cam.GroupID && x.ID != cam.ID).ToList();
                if (listCamChanJobs.Any())
                {
                    foreach (cCAMTypes otherCJCam in listCamChanJobs)
                    {
                        otherCJCam.IsMaster = false;
                        dataTable.Rows.Find(otherCJCam)[cColName.IsMaster] = false;
                    }
                }
            }
        }
        private void grdData_CellValueChanged_ViewResult(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.IsViewResult = (bool)row["IsViewResult"];
            row[cColName.IsViewResult] = cam.IsViewResult;
            project.DataChange = true;
        }
        private void grdData_CellValueChanged_JoinResult(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.IsJoinResult = (bool)row["IsJoinResult"];
            row[cColName.IsJoinResult] = cam.IsJoinResult;
            project.DataChange = true;
        }
        private void grdData_CellValueChanged_Maximine(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            cam.IsMaximize = (bool)row["IsMaximize"];
            row[cColName.IsMaximize] = cam.IsMaximize;
            project.DataChange = true;
            if (cam.IsMaximize)
            {
                foreach (cCAMTypes cam1 in Project.CAMs.Values)
                {
                    if (cam.ID != cam1.ID)
                    {
                        cam1.IsMaximize = false;
                        dataTable.Rows.Find(cam1.ID)[cColName.IsMaximize] = false;
                    }
                }
            }
        }
        private void grdData_CellValueChanged_RunOrder(cCAMTypes cam, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow row = dt.Rows[e.RowIndex];
            string snewOrder = row["RunOrder"].ToString();
            if (!int.TryParse(snewOrder, out int runOrder))
            {
                cMessageBox.Warning("Run Order only takes numeric values");
                GlobVar.LockEvents = true;
                row[cColName.RunOrder] = cam.RunOrder;
                GlobVar.LockEvents = false;
                return;
            }
            else
            {
                cCAMTypes camHaveSampleRunOrder = Project.CAMs.Values.FirstOrDefault(x => x.RunOrder == runOrder);
                if (camHaveSampleRunOrder != null)
                {
                    cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists, new string[] { "Cam run order" }, new string[] { "Số thứ tự chạy của Cam" }));
                    GlobVar.LockEvents = true;
                    row[cColName.RunOrder] = cam.RunOrder;
                    GlobVar.LockEvents = false;
                    return;
                }
            }
            cam.RunOrder = runOrder;
            row[cColName.RunOrder] = cam.RunOrder;
            project.DataChange = true;
        }
    }
}
