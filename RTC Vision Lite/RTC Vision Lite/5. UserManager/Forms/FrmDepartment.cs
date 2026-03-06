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
    public partial class FrmDepartment : FrmBase
    {
        public FrmDepartment()
        {
            InitializeComponent();
        }
        #region VARIABLES

        private int OrderNum = 1;
        private EUserActionData UserActionData = EUserActionData.None;

        #endregion

        #region FUNCTIONS
        private void LoadDepartmentData()
        {
            grdDepartmentData.DataSource = null;
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
            grdDepartmentData.DataSource = GlobVar.UserData.DepartmentData;
            OrderNum = GlobVar.UserData.GetMax(cTableName_UserManager.Department, cColName.OrderNum);
        }
        private void AddDepartment()
        {
            ClearEditControl();
            EnableEditControl(true);
            UserActionData = EUserActionData.Add;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = true;
            btnCancelEditData.Enabled = true;
        }
        private void EditDepartment()
        {
            EnableEditControl(true);
            UserActionData = EUserActionData.Edit;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = true;
            btnCancelEditData.Enabled = true;
        }
        private void DeleteDepartment()
        {
            if (grdDepartmentData.SelectedRows.Count <= 0)
                return;
            if (cMessageBox.Question_YesNo(cMessageContent.BuildMessage(cMessageContent.Que_DeleteObject,
                new string[] { "department" }, new string[] { "phòng ban" })) == DialogResult.No)
                return;

            Guid departmentID = Guid.Parse(grdDepartmentData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow departmentRow = GlobVar.UserData?.DepartmentData.Rows.Find(departmentID);
            if (GlobVar.UserData != null && GlobVar.UserData.IsConnected() && departmentRow != null)
                if (!GlobVar.UserData.DeleteDepartment(departmentRow))
                {
                    cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_DeleteObject,
                        new string[] { "department" }, new string[] { "phòng ban" }));
                    return;
                }

            ShowDepartmentFocused();
        }

        private void GetData(ref DataRow departmentRow)
        {
            if (departmentRow == null)
            {
                departmentRow = GlobVar.UserData?.DepartmentData.NewRow();
                if (departmentRow == null) return;
                departmentRow[cColName.ID] = Guid.NewGuid();
                OrderNum += 1;
                departmentRow[cColName.OrderNum] = OrderNum;
            }

            departmentRow[cColName.Name] = txtName.Text.Trim();
            departmentRow[cColName.Note] = txtNote.Text;
        }

        private bool InvalidateData(DataRow departmentRow = null)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                    new string[] { "department name" }, new string[] { "tên phòng ban" }));
                txtName.Focus();
                return false;
            }

            if (GlobVar.UserData?.DepartmentNameIsExists(txtName.Text.Trim(), departmentRow, UserActionData) > 0)
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists,
                    new string[] { "department name" }, new string[] { "tên phòng ban" }));
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void SaveDepartment()
        {
            DataRow departmentRow = null;
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
                        if (grdDepartmentData.SelectedRows.Count <= 0)
                            return;
                        try
                        {
                            Guid departmentID = Guid.Parse(grdDepartmentData.CurrentRow.Cells["colID"].Value.ToString());
                            departmentRow = GlobVar.UserData?.DepartmentData.Rows.Find(departmentID);
                        }
                        catch
                        {
                            departmentRow = null;
                        }

                        if (departmentRow == null)
                        {
                            cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                                new string[] { "department name" }, new string[] { "tên phòng ban" }));
                            return;
                        }

                        if (!InvalidateData())
                            return;

                        break;
                    }
            }

            GetData(ref departmentRow);

            if (GlobVar.UserData == null || !GlobVar.UserData.SaveDepartment(departmentRow, UserActionData))
            {
                cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_SaveObject,
                    new string[] { "department name" }, new string[] { "tên phòng ban" }));
            }
            else
            {
                cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectSuccess,
                    new string[] { "department name" }, new string[] { "tên phòng ban" }));
            }

            ShowDepartmentFocused();
        }
        private void EnableEditControl(bool enable)
        {
            txtName.Enabled = enable;
            txtNote.Enabled = enable;
        }

        private void ClearEditControl()
        {
            txtName.Text = string.Empty;
            txtNote.Text = string.Empty;
        }
        private void ShowDepartmentInfoToEditControl()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = false;
            btnCancelEditData.Enabled = false;

            EnableEditControl(false);
            ClearEditControl();

            if (grdDepartmentData.SelectedRows.Count <= 0)
            {
                btnAdd.Enabled = true;
                return;
            }

            Guid departmentID = Guid.Parse(grdDepartmentData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow departmentRow = GlobVar.UserData?.DepartmentData.Rows.Find(departmentID);
            if (departmentRow != null)
            {
                txtName.Text = GlobFuncs.GetDataRowValue_String(departmentRow, cColName.Name);
                txtNote.Text = GlobFuncs.GetDataRowValue_String(departmentRow, cColName.Note);

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void ShowDepartmentFocused()
        {
            ShowDepartmentInfoToEditControl();
        }
        private void ReOrderNumber()
        {
            if (GlobVar.UserData?.DepartmentData != null)
            {
                int orderNumber = 1;
                foreach (DataRow row in GlobVar.UserData.DepartmentData.Rows)
                {
                    row[cColName.OrderNum] = orderNumber;
                    orderNumber += 1;
                }
            }
        }
        #endregion
        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            LoadDepartmentData();
            ShowDepartmentFocused();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SaveDepartment();
            ReOrderNumber();
        }
        private void btnCancelEditData_Click(object sender, EventArgs e)
        {
            ShowDepartmentFocused();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDepartment();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditDepartment();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDepartment();
        }
    }
}
