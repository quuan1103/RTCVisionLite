using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCLibs;

namespace RTC_Vision_Lite.UserManager.Classes
{
    public partial class cUser
    {
        public static void AutoLogin()
        {
            if (GlobVar.RTCVision.SecurityOptions.SecurityModes != cSecurityModes.SecurityModes_UseAccount)
                return;

            cUserManagerData userManagerData = new cUserManagerData();
            userManagerData.Connect(GlobVar.RTCVision.Files.UserData);
            if (userManagerData.IsConnected())
            {
                try
                {
                    DataRow[] configs = userManagerData.Config?.Select($"{cColName.Name} = 'UserIdAutoLogin'");
                    if (configs != null && configs.Length > 0)
                    {
                        string userIdString = GlobFuncs.GetDataRowValue_String(configs[0], cColName.Value);
                        if (userIdString != "")
                        {
                            Guid userId = GlobFuncs.Object2Guid(cEncryptDecrypt.Decrypt(userIdString), Guid.Empty);
                            userManagerData.GetPermission(userId, out GlobVar.User);
                            if (GlobVar.User != null)
                                GlobVar.User.IsKeepLoggedInOneSession = true;
                        }
                    }
                }
                finally
                {
                    userManagerData.Disconnect();
                }
            }
        }

        public static void GetCurrentUserPermission(Guid userId)
        {
            if (GlobVar.RTCVision.SecurityOptions.SecurityModes != cSecurityModes.SecurityModes_UseAccount)
                return;
            cUserManagerData userManagerData = new cUserManagerData();
            try
            {
                userManagerData.Connect(GlobVar.RTCVision.Files.UserData);
                if (userManagerData.IsConnected())
                    userManagerData.GetPermission(userId, out GlobVar.User);
            }
            finally
            {
                userManagerData.Disconnect();
            }
        }
        public static bool CheckPermission(string permissionName, string permissionFunctionName,
            bool isShowMessage = true)
        {
            if (GlobVar.RTCVision.SecurityOptions.SecurityModes == cSecurityModes.SecurityModes_None)
                return true;

            if (GlobVar.User == null ||
                !GlobVar.User.IsLogged)
            {
                FrmLogin frmLogin = new FrmLogin();
                if (frmLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return false;
            }

            cPermissionDetail permissionDetail = (cPermissionDetail)GlobVar.User.Permission.GetType().
                    GetProperty(permissionName).GetValue(GlobVar.User.Permission, null);
            if (permissionDetail != null)
            {
                bool isPermission = (bool)permissionDetail.GetType().GetProperty(permissionFunctionName).GetValue(permissionDetail, null);

                if (!isPermission && isShowMessage)
                {
                    switch (permissionFunctionName)
                    {
                        case nameof(GlobVar.User.Permission.Templates.Execute):
                            {
                                cMessageBox.Warning(cMessageContent.War_CannotExecuteObject);
                                break;
                            }
                        case nameof(GlobVar.User.Permission.Templates.View):
                            {
                                cMessageBox.Warning(cMessageContent.War_CannotViewObject);
                                break;
                            }
                        case nameof(GlobVar.User.Permission.Templates.Add):
                            {
                                cMessageBox.Warning(string.Format(cMessageContent.War_CannotAddObject, permissionName));
                                break;
                            }
                        case nameof(GlobVar.User.Permission.Templates.Edit):
                            {
                                cMessageBox.Warning(string.Format(cMessageContent.War_CannotEditObject, permissionName));
                                break;
                            }
                        case nameof(GlobVar.User.Permission.Templates.Delete):
                            {
                                cMessageBox.Warning(string.Format(cMessageContent.War_CannotDeleteObject, permissionName));
                                break;
                            }
                        default:
                            {
                                cMessageBox.Warning(cMessageContent.War_CannotViewObject);
                                break;
                            }
                    }
                    return false;
                }
                return isPermission;
            }

            return false;
        }
        public static bool ShowFormLoginAndCheckPermission(string permissionName, string permissionFunctionName, bool isShowMessage = true)
        {
            if (GlobVar.RTCVision.SecurityOptions.SecurityModes == cSecurityModes.SecurityModes_None)
                return true;

            if (GlobVar.User == null ||
                !GlobVar.User.IsLogged ||
                !GlobVar.User.IsKeepLoggedInOneSession)
            {
                FrmLogin frmLogin = new FrmLogin();
                if (frmLogin.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return false;
            }

            cPermissionDetail permissionDetail = (cPermissionDetail)GlobVar.User.Permission.GetType().
                    GetProperty(permissionName).GetValue(GlobVar.User.Permission, null);
            if (permissionDetail != null)
            {
                bool isPermission = (bool)permissionDetail.GetType().GetProperty(permissionFunctionName).GetValue(permissionDetail, null);

                if (!isPermission && isShowMessage)
                {
                    switch (permissionFunctionName)
                    {
                        case nameof(GlobVar.User.Permission.Templates.Execute):
                            {
                                cMessageBox.Warning(cMessageContent.War_CannotExecuteObject);
                                break;
                            }
                        case nameof(GlobVar.User.Permission.Templates.View):
                            {
                                cMessageBox.Warning(cMessageContent.War_CannotViewObject);
                                break;
                            }
                        case nameof(GlobVar.User.Permission.Templates.Add):
                            {
                                cMessageBox.Warning(string.Format(cMessageContent.War_CannotAddObject, permissionName));
                                break;
                            }
                        case nameof(GlobVar.User.Permission.Templates.Edit):
                            {
                                cMessageBox.Warning(string.Format(cMessageContent.War_CannotEditObject, permissionName));
                                break;
                            }
                        case nameof(GlobVar.User.Permission.Templates.Delete):
                            {
                                cMessageBox.Warning(string.Format(cMessageContent.War_CannotDeleteObject, permissionName));
                                break;
                            }
                        default:
                            {
                                cMessageBox.Warning(cMessageContent.War_CannotViewObject);
                                break;
                            }
                    }
                    return false;
                }
                return isPermission;
            }

            return false;
        }
        public static bool ShowFormLogin()
        {
            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return true;
            return false;
        }
        public static void Logout()
        {
            if (cMessageBox.Question_YesNo(cMessageContent.Que_LogoutAccount) == System.Windows.Forms.DialogResult.No)
                return;
            GlobVar.User = null;
        }
        public static void ShowFormUserManager()
        {
            if (!ShowFormLogin())
                return;
            if (!GlobVar.User.Permission.User.View)
            {
                cMessageBox.Warning(cMessageContent.War_CannotViewObject);
                return;
            }

            FrmUser frmUser = new FrmUser();
            frmUser.ShowDialog();
        }

        public static void ShowFormPermissionManager()
        {
            if (!ShowFormLogin())
                return;
            if (!GlobVar.User.Permission.Permission.View)
            {
                cMessageBox.Warning(cMessageContent.War_CannotViewObject);
                return;
            }
            FrmPermission frmPermission = new FrmPermission();
            frmPermission.ShowDialog();
        }
        public static void ShowFormDepartmentManager()
        {
            if (!ShowFormLogin())
                return;
            if (!GlobVar.User.Permission.Department.View)
            {
                cMessageBox.Warning(cMessageContent.War_CannotViewObject);
                return;
            }
            FrmDepartment frmDepartment = new FrmDepartment();
            frmDepartment.ShowDialog();
        }
        public static void ShowFormPositionManager()
        {

            if (!GlobVar.User.Permission.Position.View)
            {
                cMessageBox.Warning(cMessageContent.War_CannotViewObject);
                return;
            }
            FrmPosition frmPosition = new FrmPosition();
            frmPosition.ShowDialog();
        }
    }
}
