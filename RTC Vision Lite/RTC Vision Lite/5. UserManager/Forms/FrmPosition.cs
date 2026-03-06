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
    public partial class FrmPosition : FrmBase
    {
        public FrmPosition()
        {
            InitializeComponent();
        }
        #region VARIABLES

        private int OrderNum = 1;
        private EUserActionData UserActionData = EUserActionData.None;

        #endregion
        #region FUNCTIONS
        private void LoadPositionData()
        {
            grdPositionData.DataSource = null;
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

            grdPositionData.DataSource = GlobVar.UserData.PositionData;
            OrderNum = GlobVar.UserData.GetMax(cTableName_UserManager.Position, cColName.OrderNum);
        }
        private void AddPosition()
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
        private void EditPosition()
        {
            EnableEditControl(true);
            UserActionData = EUserActionData.Edit;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = true;
            btnCancelEditData.Enabled = true;
        }
        private void DeletePosition()
        {
            if (grdPositionData.SelectedRows.Count <= 0)
                return;
            if (cMessageBox.Question_YesNo(cMessageContent.BuildMessage(cMessageContent.Que_DeleteObject,
                new string[] { "position" }, new string[] { "chức vụ" })) == DialogResult.No)
                return;

            Guid positionID = Guid.Parse(grdPositionData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow positionRow = GlobVar.UserData?.PositionData.Rows.Find(positionID);
            if (GlobVar.UserData != null && GlobVar.UserData.IsConnected() && positionRow != null)
                if (!GlobVar.UserData.DeletePosition(positionRow))
                {
                    cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_DeleteObject,
                        new string[] { "position" }, new string[] { "chức vụ" }));
                    return;
                }

            ShowPositionFocused();
        }

        private void GetData(ref DataRow positionRow)
        {
            if (positionRow == null)
            {
                positionRow = GlobVar.UserData?.PositionData.NewRow();
                if (positionRow == null) return;
                positionRow[cColName.ID] = Guid.NewGuid();
                OrderNum += 1;
                positionRow[cColName.OrderNum] = OrderNum;
            }

            positionRow[cColName.Name] = txtName.Text.Trim();
            positionRow[cColName.Note] = txtNote.Text;
        }

        private bool InvalidateData(DataRow permissionRow = null)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                    new string[] { "position name" }, new string[] { "tên chức vụ" }));
                txtName.Focus();
                return false;
            }

            if (GlobVar.UserData?.PositionNameIsExists(txtName.Text.Trim(), permissionRow, UserActionData) > 0)
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists,
                    new string[] { "position name" }, new string[] { "tên chức vụ" }));
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void SavePosition()
        {
            DataRow positionRow = null;
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
                        if (grdPositionData.SelectedRows.Count <= 0)
                            return;
                        try
                        {
                            Guid positionID = Guid.Parse(grdPositionData.CurrentRow.Cells["colID"].Value.ToString());
                            positionRow = GlobVar.UserData?.PositionData.Rows.Find(positionID);
                        }
                        catch
                        {
                            positionRow = null;
                        }

                        if (positionRow == null)
                        {
                            cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                                new string[] { "position" }, new string[] { "chức vụ" }));
                            return;
                        }

                        if (!InvalidateData())
                            return;

                        break;
                    }
            }

            GetData(ref positionRow);

            if (GlobVar.UserData == null || !GlobVar.UserData.SavePosition(positionRow, UserActionData))
            {
                cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_SaveObject,
                                new string[] { "position" }, new string[] { "chức vụ" }));
            }
            else
            {
                cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectSuccess,
                                new string[] { "position" }, new string[] { "chức vụ" }));
            }

            ShowPositionFocused();
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
        private void ShowPositionInfoToEditControl()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = false;
            btnCancelEditData.Enabled = false;

            EnableEditControl(false);
            ClearEditControl();

            if (grdPositionData.SelectedRows.Count <= 0)
            {
                btnAdd.Enabled = true;
                return;
            }

            Guid positiondataID = Guid.Parse(grdPositionData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow positiondataRow = GlobVar.UserData?.PositionData.Rows.Find(positiondataID);
            if (positiondataRow != null)
            {
                txtName.Text = GlobFuncs.GetDataRowValue_String(positiondataRow, cColName.Name);
                txtNote.Text = GlobFuncs.GetDataRowValue_String(positiondataRow, cColName.Note);

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void ShowPositionFocused()
        {
            ShowPositionInfoToEditControl();
        }
        private void ReOrderNumber()
        {
            if (GlobVar.UserData?.PositionData != null)
            {
                int orderNumber = 1;
                foreach (DataRow row in GlobVar.UserData.PositionData.Rows)
                {
                    row[cColName.OrderNum] = orderNumber;
                    orderNumber += 1;
                }
            }
        }
        #endregion
        private void FrmPosition_Load(object sender, EventArgs e)
        {
            LoadPositionData();
            ShowPositionFocused();
        }

        private void grdPositionData_SelectionChanged(object sender, EventArgs e)
        {
            ShowPositionFocused();
        }
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SavePosition();
            ReOrderNumber();
        }
        private void btnCancelEditData_Click(object sender, EventArgs e)
        {
            ShowPositionFocused();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPosition();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPosition();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePosition();
        }

      
    }
}
