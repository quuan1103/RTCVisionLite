using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmPermission : FrmBase
    {
        public FrmPermission()
        {
            InitializeComponent();
            grdPermission.AutoGenerateColumns = false;
            grdPermissionData.AutoGenerateColumns = false;
        }

        #region VARIABLES

        private int OrderNum = 1;
        private DataTable permissionDetail = null;
        private EUserActionData UserActionData = EUserActionData.None;

        #endregion
        #region FUNCTIONS

        private void LoadPermissionData()
        {
            grdPermissionData.DataSource = null;
            if (GlobVar.UserData == null)
            {
                GlobVar.UserData = new cUserManagerData();
                GlobVar.UserData.Connect(GlobVar.RTCVision.Files.UserData);
                if (!GlobVar.UserData.IsConnected())
                {
                    cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_NotConnectObject,
                        new string[] { GlobVar.RTCVision.Files.UserData }, new string[] { GlobVar.RTCVision.Files.UserData }));
                    GlobVar.UserData = null;
                    return;
                }
            }

            grdPermissionData.DataSource = GlobVar.UserData.PermissionData;
            OrderNum = GlobVar.UserData.GetMax(cTableName_UserManager.Permission, cColName.OrderNum);
        }
        private void AddPermission()
        {
            ClearEditControl();
            EnableEditControl(true);
            UserActionData = EUserActionData.Add;
            LoadPermissionDetailDefault();

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = true;
            btnCancelEditData.Enabled = true;
        }
        private void EditPermission()
        {
            EnableEditControl(true);
            UserActionData = EUserActionData.Edit;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = true;
            btnCancelEditData.Enabled = true;
        }
        private void DeletePermission()
        {
            if (grdPermissionData.SelectedRows.Count < 0)
                return;
            if (cMessageBox.Question_YesNo(cMessageContent.BuildMessage(cMessageContent.Que_DeleteObject,
                new string[] { "permission" }, new string[] { "quyền" })) == DialogResult.No)
                return;

            Guid idPermission = Guid.Parse(grdPermissionData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow permissionRow = GlobVar.UserData?.PermissionData.Rows.Find(idPermission);
            if (GlobVar.UserData != null && GlobVar.UserData.IsConnected() && permissionRow != null)
                if (!GlobVar.UserData.DeletePermission(permissionRow))
                {
                    cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_DeleteObject,
                        new string[] { "permission" }, new string[] { "quyền" }));
                    return;
                }

            ShowPermissionFocused();
        }

        private void GetData(ref DataRow permissionRow)
        {
            if (permissionRow == null)
            {
                permissionRow = GlobVar.UserData?.PermissionData.NewRow();
                if (permissionRow == null) return;
                permissionRow[cColName.ID] = Guid.NewGuid();
                OrderNum += 1;
                permissionRow[cColName.OrderNum] = OrderNum;
            }

            permissionRow[cColName.Name] = txtName.Text.Trim();
            permissionRow[cColName.Note] = txtNote.Text;
        }

        private bool InvalidateData(DataRow permissionRow = null)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                    new string[] { "name" }, new string[] { "tên người dùng" }));
                txtName.Focus();
                return false;
            }

            if (GlobVar.UserData?.PermissionNameIsExists(txtName.Text.Trim(), permissionRow, UserActionData) > 0)
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists,
                    new string[] { "permission name" }, new string[] { "tên quyền" }));
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void SavePermission()
        {
            DataRow permissionRow = null;
            switch (UserActionData)
            {
                case EUserActionData.Add:
                    {
                        if (!InvalidateData())
                            return;

                        break;
                    }
                case EUserActionData.Edit:
                    {
                        if (grdPermissionData.SelectedRows.Count <= 0)
                            return;
                        try
                        {
                            Guid idPermission = Guid.Parse(grdPermissionData.CurrentRow.Cells["colID"].Value.ToString());
                            permissionRow = GlobVar.UserData?.PermissionData.Rows.Find(idPermission);
                        }
                        catch
                        {
                            permissionRow = null;
                        }

                        if (permissionRow == null)
                        {
                            cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                                new string[] { "permission" }, new string[] { "quyền" }));
                            return;
                        }

                        if (!InvalidateData())
                            return;

                        break;
                    }
            }

            GetData(ref permissionRow);

            if (GlobVar.UserData == null || !GlobVar.UserData.SavePermission(permissionRow, permissionDetail, UserActionData))
            {
                cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_SaveObject,
                    new string[] { "permission" }, new string[] { "quyền" }));
            }
            else
            {
                cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectSuccess,
                    new string[] { "permission" }, new string[] { "quyền" }));
            }

            ShowPermissionFocused();
        }
        private void EnableEditControl(bool enable)
        {
            txtName.Enabled = enable;
            txtNote.Enabled = enable;
            grdPermission.ReadOnly = !enable;
        }

        private void ClearEditControl()
        {
            txtName.Text = string.Empty;
            txtNote.Text = string.Empty;
        }
        private void ShowPermissionInfoToEditControl()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = false;
            btnCancelEditData.Enabled = false;

            EnableEditControl(false);
            ClearEditControl();

            if (grdPermissionData.SelectedRows.Count <= 0)
            {
                btnAdd.Enabled = false;
                return;
            }
            var test = grdPermissionData.CurrentRow.Cells["colID"];
            Guid idUser = Guid.Parse(grdPermissionData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow useRow = GlobVar.UserData?.PermissionData.Rows.Find(idUser);
            if (useRow != null)
            {
                txtName.Text = GlobFuncs.GetDataRowValue_String(useRow, cColName.Name);
                txtNote.Text = GlobFuncs.GetDataRowValue_String(useRow, cColName.Note);

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void ShowPermissionFocused()
        {
            ShowPermissionInfoToEditControl();
            LoadPermissionDetail();
        }
        private void LoadPermissionDetailDefault()
        {
            permissionDetail = GlobVar.UserData?.LoadPermissionDetailById(Guid.Empty);
            if (permissionDetail != null)
            {
                foreach (DataRow row in permissionDetail.Rows)
                {
                    row[cColName.Add] = cStrings.@false;
                    row[cColName.Edit] = cStrings.@false;
                    row[cColName.Delete] = cStrings.@false;
                    row[cColName.View] = cStrings.@false;
                    row[cColName.Execute] = cStrings.@false;
                }
            }
            grdPermission.DataSource = permissionDetail;
        }
        private void LoadPermissionDetail()
        {
            grdPermission.DataSource = null;
            if (grdPermissionData.SelectedRows.Count <= 0)
                return;
            Guid idPermission = Guid.Parse(grdPermissionData.CurrentRow.Cells["colID"].Value.ToString());
            permissionDetail = GlobVar.UserData?.LoadPermissionDetailById(idPermission);
            grdPermission.DataSource = permissionDetail;
        }
        private void ReOrderNumber()
        {
            if (GlobVar.UserData?.PermissionData != null)
            {
                int orderNumber = 1;
                foreach (DataRow row in GlobVar.UserData.PermissionData.Rows)
                {
                    row[cColName.OrderNum] = orderNumber;
                    orderNumber += 1;
                }
            }
        }
        #endregion

        private void FrmPermission_Load(object sender, EventArgs e)
        {
            LoadPermissionData();
            ShowPermissionFocused();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SavePermission();
            ReOrderNumber();
        }
        private void btnCancelEditData_Click(object sender, EventArgs e)
        {
            ShowPermissionFocused();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPermission();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPermission();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePermission();
        }

        private void grdPermissionData_SelectionChanged(object sender, EventArgs e)
        {
            
            ShowPermissionFocused();
        }
    }
}
