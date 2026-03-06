using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserManager.Classes;
using RTCConst;
using RTCEnums;
using RTCLibs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmUser :FrmBase
    {
        public FrmUser()
        {
            InitializeComponent();
        }
        #region VARIABLES

        private int OrderNum = 1;
        //private cUserManagerData Data = null;
        private EUserActionData UserActionData = EUserActionData.None;

        #endregion

        private void FrmUser_Load(object sender, EventArgs e)
        {
            grdUserData.AutoGenerateColumns = false;
            grdPermission.AutoGenerateColumns = false;
            LoadUserData();
            LoadComboData();
            ShowUserFocused();
        }
        private void LoadUserData()
        {
            grdUserData.DataSource = null;
            GlobVar.UserData = new cUserManagerData();
            GlobVar.UserData.Connect(GlobVar.RTCVision.Files.UserData);
            if (!GlobVar.UserData.IsConnected())
            {
                cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_NotConnectObject,
                    new string[] { GlobVar.RTCVision.Files.UserData }, new string[] { GlobVar.RTCVision.Files.UserData }));
                GlobVar.UserData = null;
                return;
            }

            grdUserData.DataSource = GlobVar.UserData.UserData;
            OrderNum = GlobVar.UserData.GetMax(cTableName_UserManager.User, cColName.OrderNum);
            colDepartment.DataSource = GlobVar.UserData?.DepartmentData;
            colDepartment.DisplayMember = cColName.Name;
            colDepartment.ValueMember = cColName.ID;
            colPermission.DataSource = GlobVar.UserData?.PermissionData;
            colPermission.DisplayMember = cColName.Name;
            colPermission.ValueMember = cColName.ID;
            colPosition.DataSource = GlobVar.UserData?.PositionData;
            colPosition.DisplayMember = cColName.Name;
            colPosition.ValueMember = cColName.ID;
        }

        private void LoadComboData()
        {
            LoadComboData_Department();
            LoadComboData_Permission();
            LoadComboData_Position();
        }
        private void ShowUserFocused()
        {
            ShowUserInfoToEditControl();
            LoadPermissionDetail();
            UserActionData = EUserActionData.None;
        }
        private void LoadComboData_Department()
        {
            cbDepartment.DataSource = null;
            if (GlobVar.UserData.IsConnected())
            {
                cbDepartment.DataSource = GlobVar.UserData.DepartmentData;
                InitDisplayComboData(cbDepartment);
            }
        }
        private void LoadComboData_Permission()
        {
            cbPermission.DataSource = null;
            if (GlobVar.UserData.IsConnected())
            {
                cbPermission.DataSource = GlobVar.UserData.PermissionData;
                InitDisplayComboData(cbPermission);
            }
        }
        private void LoadComboData_Position()
        {
            cbPosition.DataSource = null;
            if (GlobVar.UserData.IsConnected())
            {
                cbPosition.DataSource = GlobVar.UserData.PositionData;
                InitDisplayComboData(cbPosition);
            }
        }
        private void InitDisplayComboData(ComboBox lookUpEdit)
        {
            lookUpEdit.DisplayMember = cColName.Name;
            lookUpEdit.ValueMember = cColName.ID;

        }
        private void ShowUserInfoToEditControl()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = false;

            EnableEditControl(false);
            ClearEditControl();

            if (grdUserData.SelectedRows.Count <= 0)
            {
                btnAdd.Enabled = true;
                return;
            }
            Guid idUser = Guid.Parse(grdUserData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow useRow = GlobVar.UserData?.UserData.Rows.Find(idUser);
            if (useRow != null)
            {
                txtName.Text = GlobFuncs.GetDataRowValue_String(useRow, cColName.Name);
                txtUserName.Text = GlobFuncs.GetDataRowValue_String(useRow, cColName.UserName);
                txtPassword.Text = cEncryptDecrypt.Decrypt(GlobFuncs.GetDataRowValue_String(useRow, cColName.PassWord));
                txtAddress.Text = GlobFuncs.GetDataRowValue_String(useRow, cColName.Address);
                txtPhone.Text = GlobFuncs.GetDataRowValue_String(useRow, cColName.Phone);
                txtEmail.Text = GlobFuncs.GetDataRowValue_String(useRow, cColName.Email);
                txtNote.Text = GlobFuncs.GetDataRowValue_String(useRow, cColName.Note);
                chkActive.Checked = GlobFuncs.GetDataRowValue_Boolean(useRow, cColName.Active);

                cbDepartment.SelectedValue = GlobFuncs.GetDataRowValue_String(useRow, cColName.IDDepartment);
                cbPosition.SelectedValue = GlobFuncs.GetDataRowValue_String(useRow, cColName.IDPosition);
                cbPermission.SelectedValue = GlobFuncs.GetDataRowValue_String(useRow, cColName.IDPermission);

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                DataRow[] configs = GlobVar.UserData?.Config?.Select($"{cColName.Name} = 'UserIdAutoLogin'");
                if (configs != null && configs.Length > 0)
                {
                    if (idUser.ToString() ==
                        cEncryptDecrypt.Decrypt(GlobFuncs.GetDataRowValue_String(configs[0], cColName.Value)))
                        chkAutoLogin.Checked = true;
                    else
                        chkAutoLogin.Checked = false;
                }
            }
        }
        private void LoadPermissionDetail()
        {
            grdPermission.DataSource = null;
            if (grdUserData.SelectedRows.Count <= 0)
                return;

            Guid idPermission = GlobFuncs.Object2Guid(grdUserData.CurrentRow.Cells["colPermission"].Value, Guid.Empty);
            grdPermission.DataSource = GlobVar.UserData?.LoadPermissionDetailById(idPermission);
        }
        private void EnableEditControl(bool enable)
        {
            txtName.Enabled = enable;
            txtUserName.Enabled = enable;
            txtPassword.Enabled = enable;
            txtAddress.Enabled = enable;
            txtPhone.Enabled = enable;
            txtEmail.Enabled = enable;
            txtNote.Enabled = enable;
            chkActive.Enabled = enable;
            chkAutoLogin.Enabled = enable;
            cbDepartment.Enabled = enable;
            cbPermission.Enabled = enable;
            cbPosition.Enabled = enable;


            btnCancelEditData.Enabled = enable;
        }
        private void ClearEditControl()
        {
            txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNote.Text = string.Empty;
            chkActive.Checked = false;
            cbDepartment.Text = null;
            cbPermission.Text = null;
            cbPosition.Text = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser();
        }
        private void AddUser()
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditUser();
        }
        private void EditUser()
        {
            EnableEditControl(true);
            UserActionData = EUserActionData.Edit;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveData.Enabled = true;
            btnCancelEditData.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }
        private void DeleteUser()
        {
            if (grdUserData.SelectedRows.Count == 0)
                return;
            if (cMessageBox.Question_YesNo(cMessageContent.BuildMessage(cMessageContent.Que_DeleteObject,
                new string[] { "user" }, new string[] { "người dùng" })) == DialogResult.No)
                return;

            Guid idUser = Guid.Parse(grdUserData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow useRow = GlobVar.UserData?.UserData.Rows.Find(idUser);
            if (GlobVar.UserData != null && GlobVar.UserData.IsConnected() && useRow != null)
                if (!GlobVar.UserData.DeleteUser(useRow))
                {
                    cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_DeleteObject,
                        new string[] { "user" }, new string[] { "người dùng" }));
                    return;
                }
            ShowUserFocused();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SaveUser();
            ReOrderNumber();
        }
        private void ReOrderNumber()
        {
            if (GlobVar.UserData?.UserData != null)
            {
                int orderNumber = 1;
                foreach (DataRow row in GlobVar.UserData.UserData.Rows)
                {
                    row[cColName.OrderNum] = orderNumber;
                    orderNumber += 1;
                }
            }
        }
        private void SaveUser()
        {
            DataRow userRow = null;
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
                        if (grdUserData.SelectedRows.Count == 0)
                            return;
                        try
                        {
                            Guid idUser = Guid.Parse(grdUserData.CurrentRow.Cells["colID"].Value.ToString());
                            userRow = GlobVar.UserData?.UserData.Rows.Find(idUser);
                        }
                        catch
                        {
                            userRow = null;
                        }

                        if (userRow == null)
                        {
                            cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                                new string[] { "user" }, new string[] { "người dùng" }));
                            return;
                        }

                        if (!InvalidateData())
                            return;

                        break;
                    }
            }

            GetData(ref userRow);

            if (GlobVar.UserData == null || !GlobVar.UserData.SaveUser(userRow, UserActionData))
            {
                cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_SaveObject,
                    new string[] { "user" }, new string[] { "người dùng" }));
            }
            else
            {
                DataRow[] configs = GlobVar.UserData?.Config?.Select($"{cColName.Name} = 'UserIdAutoLogin'");
                if (configs != null && configs.Length > 0)
                {
                    Guid idUser = Guid.Parse(grdUserData.CurrentRow.Cells["colID"].Value.ToString());
                    if (chkAutoLogin.Checked)
                    {
                        GlobVar.UserData.MyConn.ExecuteQuery(
                            $"UPDATE {cTableName_UserManager.Config} SET Value='{cEncryptDecrypt.Encrypt(idUser.ToString())}' WHERE Name='UserIdAutoLogin'");
                    }
                    else
                    {
                        string oldIdUserString = GlobFuncs.GetDataRowValue_String(configs[0], cColName.Value);
                        if (oldIdUserString != "")
                        {
                            Guid oldIdUser = GlobFuncs.Object2Guid(cEncryptDecrypt.Decrypt(oldIdUserString), Guid.Empty);
                            if (oldIdUser == idUser)
                                GlobVar.UserData.MyConn.ExecuteQuery(
                                    $"UPDATE {cTableName_UserManager.Config} SET Value='' WHERE Name='UserIdAutoLogin'");
                        }
                    }
                }
                else
                {
                    Guid idUser = Guid.Parse(grdUserData.CurrentRow.Cells["colID"].Value.ToString());
                    if (chkAutoLogin.Checked)
                        GlobVar.UserData.MyConn.ExecuteQuery(
                            $"INSERT INTO {cTableName_UserManager.Config} VALUES('UserIdAutoLogin','{cEncryptDecrypt.Encrypt(idUser.ToString())}')");
                }

                cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectSuccess,
                    new string[] { "user" }, new string[] { "người dùng" }));
            }
            ShowUserFocused();
        }
        private void GetData(ref DataRow userRow)
        {
            if (userRow == null)
            {
                userRow = GlobVar.UserData?.UserData.NewRow();
                if (userRow == null) return;
                userRow[cColName.ID] = Guid.NewGuid();
                OrderNum += 1;
                userRow[cColName.OrderNum] = OrderNum;
            }

            userRow[cColName.Name] = txtName.Text.Trim();
            userRow[cColName.UserName] = txtUserName.Text;
            userRow[cColName.PassWord] = cEncryptDecrypt.Encrypt(txtPassword.Text);
            userRow[cColName.Address] = txtAddress.Text;
            userRow[cColName.Phone] = txtPhone.Text;
            userRow[cColName.Email] = txtEmail.Text;
            userRow[cColName.Note] = txtNote.Text;
            userRow[cColName.Active] = chkActive.Checked.ToString().ToLower();
            userRow[cColName.IDDepartment] = cbDepartment.SelectedValue;
            userRow[cColName.IDPermission] = cbPermission.SelectedValue;
            userRow[cColName.IDPosition] = cbPosition.SelectedValue;
        }
        private bool InvalidateData(DataRow userRow = null)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                    new string[] { "name" }, new string[] { "tên người dùng" }));
                txtName.Focus();
                return false;
            }

            if (GlobVar.UserData?.NameIsExists(txtName.Text.Trim(), userRow, UserActionData) > 0)
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists,
                    new string[] { "name" }, new string[] { "tên người dùng" }));
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnCancelEditData_Click(object sender, EventArgs e)
        {
            ShowUserFocused();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            Guid idUser = Guid.Parse(grdUserData.CurrentRow.Cells["colID"].Value.ToString());
            DataRow useRow = GlobVar.UserData?.UserData.Rows.Find(idUser);
            if (useRow != null)
            {
                txtPassword.Text = cEncryptDecrypt.Encrypt(GlobFuncs.GetDataRowValue_String(useRow, cColName.PassWord));
            }
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            cUser.ShowFormPermissionManager();
            LoadComboData_Permission();
        }

        private void grdUserData_SelectionChanged(object sender, EventArgs e)
        {
            ShowUserFocused();
        }

    

        private void btnPosition_Click(object sender, EventArgs e)
        {
            cUser.ShowFormPositionManager();
            LoadComboData_Position();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            cUser.ShowFormDepartmentManager();
            LoadComboData_Department();
        }
    }
}
