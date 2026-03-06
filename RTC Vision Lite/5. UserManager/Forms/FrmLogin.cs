using RTC_Vision_Lite.Classes;
using RTCConst;
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
    public partial class FrmLogin : FrmBase
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                btnOK.PerformClick();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                                    new string[] { "user name" }, new string[] { "Tên tài khoản" }));
                txtPassWord.Focus();
                return;
            }
            if (txtPassWord.Text == "")
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                                    new string[] { "password" }, new string[] { "Mật khẩu" }));
                txtPassWord.Focus();
                return;
            }

            cUserManagerData userManagerData = new cUserManagerData();
            if (!userManagerData.Connect(GlobVar.RTCVision.Files.UserData))
            {
                cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_NotConnectObject,
                        new string[] { GlobVar.RTCVision.Files.UserData }, new string[] { GlobVar.RTCVision.Files.UserData }));
                userManagerData = null;
                return;
            }

            userManagerData.GetPermission(txtUserName.Text, txtPassWord.Text, out GlobVar.User);

            if (GlobVar.User == null)
            {
                cMessageBox.Error(cMessageContent.War_UserNameOrPasswordIsWrong);
                return;
            }

            GlobVar.User.IsKeepLoggedInOneSession = chkKeepLogin.Checked;
            DialogResult = DialogResult.OK;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (GlobVar.User != null)
                chkKeepLogin.Checked = GlobVar.User.IsKeepLoggedInOneSession;
        }

        private void lblShowHide_Click(object sender, EventArgs e)
        {
            if (lblShowHide.Text == cStrings.Show)
            {
                txtPassWord.PasswordChar = char.MinValue;
                lblShowHide.Text = cStrings.Hide;
            }
            else
            {
                txtPassWord.PasswordChar = '*';
                lblShowHide.Text = cStrings.Show;
            }
        }
    }
}
