using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public class cMessageContent
    {
        #region INFORMATION
        public static string Inf_ApplyPropertyValueIsSuccess
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Apply Property Value Is Success.";
                    case ELanguage.VN:
                        return "Áp dụng giá trị của thuộc tính cho tool khác thành công.";
                    default:
                        return "";
                }
            }
        }
        public static string Inf_SaveObjectSuccess
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Save {0} is success.";
                    case ELanguage.VN:
                        return "Lưu {0} thành công.";
                    default:
                        return "";
                }
            }
        }
        public static string Inf_SaveObjectIsNotSuccess
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Save {0} is not success.";
                    case ELanguage.VN:
                        return "Lưu {0} không thành công.";
                    default:
                        return "";
                }
            }
        }
        public static string Inf_FileOpening
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "File is opening...";
                    case ELanguage.VN:
                        return "Đang mở tệp...";
                    default:
                        return "";
                }
            }
        }
        public static string Nor_ChooseFile
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Choose file...";
                    case ELanguage.VN:
                        return "Chọn tệp...";
                    default:
                        return "";
                }
            }
        }
        public static string Nor_OpenDialogFilter_GroupToolFileType
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Group tool file type(*" + cExtFile.GroupD + ")|*" + cExtFile.GroupD;
                    case ELanguage.VN:
                        return "Kiểu tệp nhóm chức năng(*" + cExtFile.GroupD + ")|*" + cExtFile.GroupD;
                    default:
                        return "";
                }
            }
        }
        public static string Nor_OpenDialogFilter_ImageFileType
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Image type(*.jpg;*.png;*.bmp;*.tif;*.ico)|*.jpg;*.png;*.bmp;*.tif;*.ico|All Files|(*.*)";
                    case ELanguage.VN:
                        return "Kiểu ảnh(*.jpg;*.png;*.bmp;*.tif;*.ico)|*.jpg;*.png;*.bmp;*.tif;*.ico|Toàn bộ kiểu|(*.*)";
                    default:
                        return "";
                }
            }
        }
        public static string Inf_FunctionUnderConstruction
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Function under construction...";
                    case ELanguage.VN:
                        return "Chức năng đang được xây dựng...";
                    default:
                        return "";
                }
            }
        }
        public static string Inf_SaveGroupSuccess
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Save group is success.";
                    case ELanguage.VN:
                        return "Save group is success.";
                    default:
                        return "";
                }
            }
        }
        #endregion

        #region QUESTION

        public static string Que_DeleteThisTool
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to delete this Tool?";
                    case ELanguage.VN:
                        return "Do you want to delete this Tool?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_DeleteAllTool
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to delete all Tools?";
                    case ELanguage.VN:
                        return "Do you want to delete all Tools?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_DeleteAllBranch
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to delete all branch?";
                    case ELanguage.VN:
                        return "Do you want to delete all branch?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_DeleteAllROIs
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to delete all ROIs?";
                    case ELanguage.VN:
                        return "Do you want to delete all ROIs?";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// Chuỗi dùng cho việc thông báo sự kiện xóa 1 đối tượng nào đó.
        /// </summary>
        public static string Que_DeleteObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to delete this {0}?";
                    case ELanguage.VN:
                        return "Bạn thực sự muốn xóa {0} này?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_ResetObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to reset this {0}?";
                    case ELanguage.VN:
                        return "Bạn thực sự muốn khởi tạo lại thông số của {0} này?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_SelectAllObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to select all {0}?";
                    case ELanguage.VN:
                        return "Bạn thực sự muốn chọn toàn bộ {0}?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_UnselectAllObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to unselect all {0}?";
                    case ELanguage.VN:
                        return "Bạn thực sự muốn bỏ chọn toàn bộ {0}?";
                    default:
                        return "";
                }
            }
        }
        public static string Nor_DeleteObjectSuccess
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Delete {0} is success";
                    case ELanguage.VN:
                        return "Xóa {0} thành công";
                    default:
                        return "";
                }
            }
        }
        public static string War_DeleteObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Delete this {0} is error.\nPlease check again.";
                    case ELanguage.VN:
                        return "Xóa {0} không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_SourceImageNotIsCamera
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Image source mode is not camera.\nPlease check again.";
                    case ELanguage.VN:
                        return "Chế độ nguồn ảnh không phải là camera.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// Chuỗi dùng cho việc thông báo sự kiện xóa toàn bộ đối tượng nào đó.
        /// </summary>
        public static string Que_DeleteAllObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Do you want to delete all {0}?";
                    case ELanguage.VN:
                        return "Bạn thực sự muốn xóa toàn bộ {0}?";
                    default:
                        return "";
                }
            }
        }
        public static string War_UserNameOrPasswordIsWrong
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "User name or password is wrong.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tên tài khoản hoặc mật khẩu không chính xác.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        #endregion

        #region ERROR

        public static string Err_SaveGroup
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Save group is error.\nPlease check log file to see full error message.";
                    case ELanguage.VN:
                        return "Save group is error.\nPlease check log file to see full error message.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_FailedRegisterVC3000
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Failed to register IOController VC3000 library.";
                    case ELanguage.VN:
                        return "Đăng ký  thư viện IOController VC3000 thất bại.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_UnableToSetOutputPolarity
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Unable to set Output Polarity.";
                    case ELanguage.VN:
                        return "Không thiết lập được Output Polarity.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_WriteIO_IsFail
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Write IO {0} Is Fail.";
                    case ELanguage.VN:
                        return "Quá trình ghi tín hiệu IO {0} không thành công.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_SaveGroup_SaveBAKErr
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Save group backup file is error.\nPlease check log file to see full error message.";
                    case ELanguage.VN:
                        return "Save group backup file is error.\nPlease check log file to see full error message.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_SaveGroup_RestoreBAKErr
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Restore the group backup file is error.\nPlease check log file to see full error message.";
                    case ELanguage.VN:
                        return "Restore the group backup file is error.\nPlease check log file to see full error message.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_Save_SaveTemplateIsNotExist
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Save template file:\n" + GlobVar.RTCVision.Files.SaveTemplate + ".\nis not exist.\nPlease check log file to see full error message.";
                    case ELanguage.VN:
                        return "Save template file:\n" + GlobVar.RTCVision.Files.SaveTemplate + ".\nis not exist.\nPlease check log file to see full error message.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_SaveGroup_CanNotConnectToFile
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Can't connect to save file.\nPlease check log file to see full error message.";
                    case ELanguage.VN:
                        return "Can't connect to save file.\nPlease check log file to see full error message.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_OpenGroup_CanNotConnectToFile
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Can't connect to file.\nPlease check log file to see full error message.";
                    case ELanguage.VN:
                        return "Can't connect to file.\nPlease check log file to see full error message.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_SaveObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Save {0} is not success.\nCheck error in log file.";
                    case ELanguage.VN:
                        return "Lưu {0} không thành công.\nKiểm tra nội dung lỗi trong tệp log.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_CloneObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Clone {0} is not success.\nCheck error in log file.";
                    case ELanguage.VN:
                        return "Sao chép {0} không thành công.\nKiểm tra nội dung lỗi trong tệp log.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_ClearObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Clear {0} is not success.\nCheck error in log file.";
                    case ELanguage.VN:
                        return "Xóa toàn bộ {0} không thành công.\nKiểm tra nội dung lỗi trong tệp log.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_HalconLicenseError
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Halcon: No copyright or expired copyright.\nPlease check again.";
                    case ELanguage.VN:
                        return "Halcon: Không có bản quyền hoặc bản quyền đã hết hạn.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_NotConnectObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "File\n{0}\ncannot connect.\nPlease check file or file path.";
                    case ELanguage.VN:
                        return "Không thể kết nối tới tệp:\n {0}.\nVui lòng kiểm tra lại tệp hoặc đường dẫn tệp.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_ExecuteQueryCannotSuccess
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Execute query\n{0}\ncannot success.\nPlease check file or file path.";
                    case ELanguage.VN:
                        return "Không thể thực thi câu lệnh:\n {0}.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_BeginLineValueError
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Begin line value does not match.";
                    case ELanguage.VN:
                        return "Giá trị dòng bắt đầu không phù hợp.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_BackToOriginProcessIsNotSuccses
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Back to origin process is not succes.\nPlease check again.";
                    case ELanguage.VN:
                        return "Quá trình về điểm gốc không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_BackToMaintanceProcessIsNotSuccses
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Back to maintance process is not succes.\nPlease check again.";
                    case ELanguage.VN:
                        return "Quá trình về điểm bảo trì không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string Err_EndLineValueError
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "End line value does not match.";
                    case ELanguage.VN:
                        return "Giá trị dòng kết thúc không phù hợp.";
                    default:
                        return "";
                }
            }
        }
        public static string War_EndLineValueMustBeGreaterThanBigLine
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "End line must be greater than begin line.";
                    case ELanguage.VN:
                        return "Dòng kết thúc cần lớn hơn dòng bắt đầu.";
                    default:
                        return "";
                }
            }
        }
        public static string War_FileSizeExceedsTheAllowedLimit
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "File size exceeds the allowed limit.";
                    case ELanguage.VN:
                        return "Kích thước tệp vượt mức cho phép.";
                    default:
                        return "";
                }
            }
        }
        public static string Que_ClearObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Are you sure you want to delete all {0}?";
                    case ELanguage.VN:
                        return "Bạn chắn chắn muốn xóa toàn bộ {0}?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_Update
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The program has new updates {0}.\nDo you want to upgrade? ";
                    case ELanguage.VN:
                        return "Chương trình có cập nhật mới {0}.\nBạn có muốn nâng cấp hay không ? ";
                    default:
                        return "";
                }
            }
        }
        public static string Que_ApplyPropertyValueToAllTools
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Are you sure you want to assign the value of this property to all tools?";
                    case ELanguage.VN:
                        return "Bạn chắc chắn muốn gán giá trị của thuộc tính này cho toàn bộ các tool?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_SaveProject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Current model is changed data. Do you want save model?";
                    case ELanguage.VN:
                        return "Model hiện tại có sự thay đổi dữ liệu. Bạn có muốn lưu lại hay không?";
                    default:
                        return "";
                }
            }
        }
        public static string Que_LogoutAccount
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Dou you want logout this account?";
                    case ELanguage.VN:
                        return "Bạn muốn thoát tài khoản này?";
                    default:
                        return "";
                }
            }
        }
        #endregion

        #region WARNING MESSAGE
        public static string War_CameraOffline
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The camera is offline.\nPlease check again.";
                    case ELanguage.VN:
                        return "Camera chưa kết nối.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }

        public static string War_NoHaveActionIsActive
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The cam with name '{0}' need at least 1 tool is active.\nPlease check again.";
                    case ELanguage.VN:
                        return "Cửa sổ với tên '{0}' cần ít nhất 1 tool hoạt động.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string Que_NoHaveActionIsActive
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The cam with name '{0}' need at least 1 tool is active.\n Do you want to continue?";
                    case ELanguage.VN:
                        return "Cửa sổ với tên '{0}' cần ít nhất 1 tool hoạt động.\nBạn có muốn tiếp tục chạy?";
                    default:
                        return "";
                }
            }
        }

        public static string War_FileCannotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "File\n '{0}' \ncannot connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tệp\n '{0}' \nkhông thể kết nối.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_ObjectValueIsNotValidWithExample
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The '{0}' value is not valid.\nValid value is '{1}'.\nPlease check again.";
                    case ELanguage.VN:
                        return "Gía trị của '{0}' không hợp lệ.\nGía trị hợp lệ là: '{1}'.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_ToolNameIsExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Tool name is exitst.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tool name is exitst.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_ToolNameIsEmpty
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Tool name cannot be left blank.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tool name cannot be left blank.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_GroupIsNotExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Group is not exists.\nPlease check again.";
                    case ELanguage.VN:
                        return "Group is not exists.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_NotSelectedToolToMoveUp
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You have not selected the Tool to move up.\nPlease check again.";
                    case ELanguage.VN:
                        return "You have not selected the Tool to move up.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_NNotSelectedToolToMoveDown
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You have not selected the Tool to move down.\nPlease check again.";
                    case ELanguage.VN:
                        return "You have not selected the Tool to move down.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_NotSelectedToolToDelete
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You have not selected the Tool to delete.\nPlease check again.";
                    case ELanguage.VN:
                        return "You have not selected the Tool to delete.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_NCanNotMoveThisTool
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Cannot move this Tool.\nPlease check again.";
                    case ELanguage.VN:
                        return "Cannot move this Tool.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_NCanNotDeleteThisTool
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Cannot delete this Tool.\nPlease check again.";
                    case ELanguage.VN:
                        return "Cannot delete this Tool.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_SaveGroup_BakIsUsed
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The group backup file is in use.\nPlease check again.";
                    case ELanguage.VN:
                        return "The group backup file is in use.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        public static string War_FileIsUsed
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The file:\n {0} \nis used.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tệp:\n {0} \nđang được sử dụng.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_FileNotOverwite
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The file:\n {0} \nis not overwite.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tệp:\n {0} \nkhông thể ghi đè.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_LicenseIsNotAcivated
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The program is not activated.\nPlease contact the product supplier.";
                    case ELanguage.VN:
                        return "Chương trình của bạn chưa được kích hoạt bản quyền.\nVui lòng liên hệ với bên cung cấp sản phẩm.";
                    default:
                        return "";
                }
            }
        }
        public static string War_FileNotUnzip
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The file:\n {0} \ncan't unzip.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tệp:\n {0} \nkhông thể giải nén.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_DicrectoryCannotCreate
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The directory:\n {0} \ncan't create.\nPlease check again.";
                    case ELanguage.VN:
                        return "Không tạo được thư mục:\n {0}.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_DicrectoryNotExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The directory:\n {0} \not exists.\nPlease check again.";
                    case ELanguage.VN:
                        return "Thư mục:\n {0}\nkhông tồn tại.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_FileNotExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The file:\n {0} \nis not exists.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tệp:\n {0} \nkhông tồn tại.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_ColumnIsMaximum
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The {0} file only up to 30 columns of data are allowed.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tệp {0}chỉ cho phép tối đa 30 cột dữ liệu.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CsvFileColumnCountRequiment
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Csv file requires at least 1 column.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tệp csv cần tối thiểu 1 cột.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_FileNameIsExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The file:\n {0} \nis exists.\nPlease check again.";
                    case ELanguage.VN:
                        return "The file:\n {0} \nis exists.\nPlease check again.";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// Chuỗi dùng cho việc thông báo sự kiện chưa chọn 1 đối tượng nào đó.
        /// </summary>
        public static string War_NotSelected
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "No {0} has been selected yet.\nPlease check again.";
                    case ELanguage.VN:
                        return "Chưa có {0} nào được chọn.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// <para>Chuỗi dùng cho việc thông báo 1 thành phần nào đó đã tồn tại.</para>
        /// {0} is exists.\nPlease check again.
        /// </summary>
        public static string War_ObjectIsExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "{0} is exists.\nPlease check again.";
                    case ELanguage.VN:
                        return "{0} đã tồn tại.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_ModuleSummaryOKNGCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Module summary OK-NG can not connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "Thành phần tổng hợp kết quả không thể kết nối.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        //
        //public static string War_YouAreWorkingWithTheModelYouNeedToChange
        //{
        //    get
        //    {
        //        switch (GlobVar.RTCVision.Language)
        //        {
        //            case ELanguage.Eng:
        //                return "You are working with the model you need to change.\nPlease check again.";
        //            case ELanguage.VN:
        //                return "Bạn đang làm việc với model cần đổi.\nVui lòng kiểm tra lại.";
        //            default:
        //                return "";
        //        }
        //    }
        //}
        /// <summary>
        /// Chuỗi dùng cho việc thông báo 1 thành phần nào đó đã tồn tại.
        /// </summary>
        public static string War_ObjectIsNotExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "{0} is not exists. Please check again.";
                    case ELanguage.VN:
                        return "{0} không tồn tại. Vui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// Chuỗi dùng cho việc thông báo 1 thành phần nào đó không đủ số lượng.
        /// </summary>
        public static string War_ObjectNotEnoughQuantity
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "{0} quantity must be greater than 1.\nPlease check again.";
                    case ELanguage.VN:
                        return "{0} phải có ít nhất 1 phần tử.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_ActionToolWantAddIsExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The tool you want to add already exists.\nPlease check again.";
                    case ELanguage.VN:
                        return "Tool bạn muốn thêm vào đã tồn tại.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CAMIsNotSetup
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The '{0}' has not set up.\nPlease check again.";
                    case ELanguage.VN:
                        return "'{0}' chưa thiết lập bài toán kiểm tra.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_SLMPCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The SLMP with IP ='{0}' and PORT='{1}' can't connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "Kết nối SLMP tới IP='{0}' và PORT = '{1}' không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_SLMPOfActionCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "{0} with IP ='{1}' and PORT='{2}' can't connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "{0} với IP='{1}' và PORT = '{2}' kết nối không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_FTPActionCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "{0} with HostName ='{1}' and UserName='{2}' can't connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "{0} với HostName='{1}' và UserName = '{2}' kết nối không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_MXComponentActionCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "MXComponent can't connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "MXComponent kết nối không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CSTLightOfActionCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "CSTLight can't connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "CSTLight kết nối không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_VSTLightOfActionCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "VSTLight can't connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "VSTLight kết nối không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_TCPIPOfActionCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "{0} with HOSTNAME = '{1}' and PORT = '{2}' can't connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "{0} với HOSTNAME = '{1}' và PORT = '{2}' kết nối không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_COMNameActionCanNotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "{0} with COM name = '{1}' can't connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "{0} có cổng = '{1}' kết nối không thành công.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_IsNotHaveTools
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You have not set up the tools to run.\nPlease check again.";
                    case ELanguage.VN:
                        return "Bạn chưa thiết lập các tool chạy kiểm tra.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CAMIsNotHaveSourceImage
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The '{0}' has not input image setting.\nPlease check again.";
                    case ELanguage.VN:
                        return "'{0}' chưa thiết lập ảnh đầu vào.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_ObjectIsNotEmpty
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The '{0}' cannot be left blank.\nPlease check again.";
                    case ELanguage.VN:
                        return "'{0}' không được để trống.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_WrongPassword
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Wrong Password.\nPlease check again.";
                    case ELanguage.VN:
                        return "Mật khẩu không đúng.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }

        public static string War_OnlyAcceptInteger
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The current value only accepts type Integer.";
                    case ELanguage.VN:
                        return "Giá trị hiện tại chỉ chấp nhận kiểu Integer.";
                    default:
                        return "";
                }
            }
        }
        public static string War_OnlyAcceptNumericOrInf
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The current value only accepts number or Inf.";
                    case ELanguage.VN:
                        return "Giá trị hiện tại chỉ chấp nhận kiểu số hoặc Inf.";
                    default:
                        return "";
                }
            }
        }
        public static string War_2ObjectIsNotEqual
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The '{0}' and '{1}' not same.\nPlease check again.";
                    case ELanguage.VN:
                        return "'{0}' và {1} không giống nhau.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_IsLimitedProcessRunning
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You can only run {0} process of this program.\nPlease check again.";
                    case ELanguage.VN:
                        return "Bạn chỉ có thể chạy {0} tiến trình của chương trình này.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_StopAllCamIsRun
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Stop all windows is running before perform the operation.\nPlease check again.";
                    case ELanguage.VN:
                        return "Vui lòng dừng chạy toàn bộ chương trình để thực hiện thao tác này.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CanNotLoadImage
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Cannot load image (Tool: {0}).\nPlease check again.";
                    case ELanguage.VN:
                        return "Không nạp được ảnh (Tool: {0}).\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }

        public static string War_CannotLoadImage {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Cannot load Image (Tool: {0}).\nPlease check again.";
                    case ELanguage.VN:
                        return "Không tải được ảnh(Tool: {0}).\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }

        public static string War_CanNotLoadObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Cannot load object (Tool: {0}).\nPlease check again.";
                    case ELanguage.VN:
                        return "Không nạp được đối tượng (Tool: {0}).\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CanNotLoadConfig
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Cannot load config (Tool: {0}).\nPlease check again.";
                    case ELanguage.VN:
                        return "Không nạp được thông số (Tool: {0}).\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CannotViewObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You do not have permission to access this content.";
                    case ELanguage.VN:
                        return "Bạn không có quyền truy cập nội dung này.";
                    default:
                        return "You do not have permission to access this content.";
                }
            }
        }
        public static string War_CannotAddObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You do not have permission to add {0}.";
                    case ELanguage.VN:
                        return "Bạn không có quyền thêm {0}.";
                    default:
                        return "You do not have permission to add {0}.";
                }
            }
        }
        public static string War_CannotEditObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You do not have permission to edit {0}.";
                    case ELanguage.VN:
                        return "Bạn không có quyền sửa {0}.";
                    default:
                        return "You do not have permission to edit {0}.";
                }
            }
        }
        public static string War_CannotDeleteObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You do not have permission to delete {0}.";
                    case ELanguage.VN:
                        return "Bạn không có quyền xóa {0}.";
                    default:
                        return "You do not have permission to delete {0}.";
                }
            }
        }
        public static string War_CannotExecuteObject
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You do not have permission to run this function.";
                    case ELanguage.VN:
                        return "Bạn không có quyền sử dụng chức năng này.";
                    default:
                        return "You do not have permission to run this function.";
                }
            }
        }
        public static string War_CAMCannotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The '{0}' cannot connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "'{0}' không thể kết nối.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CAMCannotConnectCamera
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The '{0}' cannot connect camera.\nPlease check again.";
                    case ELanguage.VN:
                        return "'{0}' không thể kết nối camera.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CannotConnectCamera
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The CAM cannot connect.\nPlease check again.";
                    case ELanguage.VN:
                        return "Không thể kết nối tới CAM.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CannotLiveCamera
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The CAM cannot live.\nPlease check again.";
                    case ELanguage.VN:
                        return "Không thể hiển thị cam.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_CannotStopLiveCamera
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The CAM cannot stop live.\nPlease check again.";
                    case ELanguage.VN:
                        return "Không thể hủy hiển thị cam.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_COMPortIsNotExists
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The COM port '{0}' is not exists.\nPlease check again.";
                    case ELanguage.VN:
                        return "Cổng COM '{0}' không tồn tại.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_FTPCannotConnect
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Cannot connect to FTP.\nPlease check again.";
                    case ELanguage.VN:
                        return "Không kết nối được tới địa chỉ FTP.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_COMNameIsNotEmpty
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You have not selected a COM port.\nPlease check again.";
                    case ELanguage.VN:
                        return "Bạn chưa chọn cổng COM.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_TriggerValueIsNotEmpty
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Trigger Value cannot be left blank.\nPlease check again.";
                    case ELanguage.VN:
                        return "Giá trị trigger không được để trống.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_IPAddressIsNotEmpty
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "IP address cannot be left blank.\nPlease check again.";
                    case ELanguage.VN:
                        return "Địa chỉ IP không được để trống.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_PortIsNotEmpty
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The Port cannot be left blank.\nPlease check again.";
                    case ELanguage.VN:
                        return "Port không được để trống.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_PLCAddressIsNotEmpty
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The PLC Address cannot be left blank.\nPlease check again.";
                    case ELanguage.VN:
                        return "Địa chỉ thanh nhớ PLC không được để trống.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_PortIsAcceptOnlyNumber
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Port only accepts numeric value.\nPlease check again.";
                    case ELanguage.VN:
                        return "Port chỉ nhận giá trị số.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_NumberOfDayCleanImageOnlyNumber
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Number of day clean image only accepts numeric value.\nPlease check again.";
                    case ELanguage.VN:
                        return "Thời gian xóa ảnh chỉ nhận giá trị số.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_ValueOutOffRange
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "The Value Out of Range.\nPlease check again.";
                    case ELanguage.VN:
                        return "Giá trị nằm ngoài khoảng cho phép.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }
        public static string War_MustHave2Value
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Must be have 2 Values.\nPlease check again.";
                    case ELanguage.VN:
                        return "Cần tối thiểu 2 giá trị";
                    default:
                        return "";
                }
            }
        }

        public static string War_PortNumberIsNotEmpty
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "You have not input port number.\nPlease check again.";
                    case ELanguage.VN:
                        return "Bạn chưa nhập cổng PORT.\nVui lòng kiểm tra lại.";
                    default:
                        return "";
                }
            }
        }

        #endregion



        #region NORMAL MESSAGE
        public static string Nor_Saved
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Saved";
                    case ELanguage.VN:
                        return "Đã lưu";
                    default:
                        return "";
                }
            }
        }
        public static string Nor_Connected
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Connect";
                    case ELanguage.VN:
                        return "Đã kết nối";
                    default:
                        return "";
                }
            }
        }
        public static string Nor_NotConnected
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Not Connect";
                    case ELanguage.VN:
                        return "Kết nối thất bại";
                    default:
                        return "";
                }
            }
        }
        public static string Nor_DetectInterfaces
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Detect Interfaces...";
                    case ELanguage.VN:
                        return "Tìm kiếm giao thức...";
                    default:
                        return "";
                }
            }
        }
        public static string Nor_UnderConstruction
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "Feature is under construction.";
                    case ELanguage.VN:
                        return "Tính năng đang được xây dựng.";
                    default:
                        return "";
                }
            }
        }
        public static string Nor_ToolUnderConstruction
        {
            get
            {
                switch (GlobVar.RTCVision.Language)
                {
                    case ELanguage.Eng:
                        return "This tool is under construction.\nPlease come back later.";
                    case ELanguage.VN:
                        return "Công cụ hiện tại đang được xây dựng.\nVui lòng quay lại sau.";
                    default:
                        return "";
                }
            }
        }


        public static string BuildMessage(string _MessageOrigin, string[] _EParameters, string[] _VParameters)
        {
            switch (GlobVar.RTCVision.Language)
            {
                case ELanguage.Eng:
                    return string.Format(_MessageOrigin, _EParameters);
                case ELanguage.VN:
                    return string.Format(_MessageOrigin, _VParameters);
                default:
                    return "";
            }

        }
        #endregion

    }

    public class cMessageBox
    {
        public static void Notification(string message)
        {
            GlobFuncs.CloseWaitForm();
            MessageBox.Show(message, cDialogCaptions.Infor, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string message)
        {
            GlobFuncs.CloseWaitForm();
            MessageBox.Show(message, cDialogCaptions.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }
        public static DialogResult Question_YesNo(string message)
        {
            GlobFuncs.CloseWaitForm();
             return MessageBox.Show(message, cDialogCaptions.Infor, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult Question_YesNoCancel(string message)
        {
            GlobFuncs.CloseWaitForm();
            return MessageBox.Show(message, cDialogCaptions.Infor, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        public static void Error(string message)
        {
            GlobFuncs.CloseWaitForm();
            MessageBox.Show(message, cDialogCaptions.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void Warning(object notChooseInterface)
        {
            throw new NotImplementedException();
        }
        public static DialogResult Custom(string caption,
            string message,
            string dialogType,
            string messageBoxButtons,
            bool isShowDialogMode,
            string position,
            Form ownerForm = null,
            int width = 400,
            int height = 180,
            Image image = null,
            bool isAutoClose = false,
            int waitTimeToAutoClose = 3)
        {
            try
            {
                GlobFuncs.CloseWaitForm();
                FrmMessageBox frmMessageBox = new FrmMessageBox();
                if (width > 400)
                    frmMessageBox.Width = width;
                if (height > 180)
                    frmMessageBox.Height = height;
                frmMessageBox.RTCInputImage = image;
                frmMessageBox.RTCDialogType = dialogType;
                frmMessageBox.RTCCaption = caption;
                frmMessageBox.RTCMessage = message;
                frmMessageBox.RTCTimeAutoClose = waitTimeToAutoClose;
                frmMessageBox.RTCMessageBoxButtons = messageBoxButtons;
                frmMessageBox.RTCIsAutoClose = isAutoClose;
                frmMessageBox.StartPosition = FormStartPosition.Manual;
                if (ownerForm != null)
                {
                    if (position == cPositionForm.Center)
                        frmMessageBox.Location = new Point((ownerForm.Width - frmMessageBox.Width) / 2,
                            (ownerForm.Height - frmMessageBox.Height) / 2);
                    else if (position == cPositionForm.UpperLeftCorner)
                        frmMessageBox.Location = new Point(0, 0);
                    else if (position == cPositionForm.UpperRightCorner)
                        frmMessageBox.Location = new Point(ownerForm.Width - frmMessageBox.Width - 10, 0);
                    else if (position == cPositionForm.LowerLeftCorner)
                        frmMessageBox.Location = new Point(0, ownerForm.Height - frmMessageBox.Height - 10);
                    else if (position == cPositionForm.LowerRightCorner)
                        frmMessageBox.Location = new Point(ownerForm.Width - frmMessageBox.Width - 10, ownerForm.Height - frmMessageBox.Height - 10);

                }
                else
                {
                    if (position == cPositionForm.Center)
                        frmMessageBox.Location = new Point((Screen.PrimaryScreen.Bounds.Width - frmMessageBox.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - frmMessageBox.Height) / 2);
                    else if (position == cPositionForm.UpperLeftCorner)
                        frmMessageBox.Location = new Point(0, 0);
                    else if (position == cPositionForm.UpperRightCorner)
                        frmMessageBox.Location = new Point(Screen.PrimaryScreen.Bounds.Width - frmMessageBox.Width, 0);
                    else if (position == cPositionForm.LowerLeftCorner)
                        frmMessageBox.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - frmMessageBox.Height);
                    else if (position == cPositionForm.LowerRightCorner)
                        frmMessageBox.Location = new Point(Screen.PrimaryScreen.Bounds.Width - frmMessageBox.Width, Screen.PrimaryScreen.Bounds.Height - frmMessageBox.Height);

                }
                frmMessageBox.Owner = ownerForm;
                if (isShowDialogMode)
                {
                    if (ownerForm != null)
                        if (ownerForm.InvokeRequired)
                            ownerForm.Invoke((MethodInvoker)delegate
                            {
                                frmMessageBox.ShowDialog();
                            });
                        else
                            frmMessageBox.ShowDialog();
                    else
                        frmMessageBox.ShowDialog();
                    return frmMessageBox.RTCDialogResult;
                }
                else
                {
                    if (ownerForm != null)
                        if (ownerForm.InvokeRequired)
                            ownerForm.Invoke((MethodInvoker)delegate
                            {
                                frmMessageBox.Show();
                            });
                        else
                            frmMessageBox.Show();
                    else
                        frmMessageBox.Show();
                    return DialogResult.None;

                }
            }
            catch (Exception ex)
            {
                return DialogResult.None;
            }
        }


        //public static DialogResult Custom(string caption,
        //    string message,
        //    string dialogType,
        //    string messageBoxButtons,
        //    bool isShowDialogMode,
        //    string position,
        //    Form ownerForm = null,
        //    int width = 400,
        //    int height = 180,
        //    Image image = null,
        //    bool isAutoClose = false,
        //    int waitTimeToAutoClose = 3)
        //{
        //    try
        //    {
        //        GlobFuncs.CloseWaitForm();
        //        FrmMessageBox
        //    }
        //}
    }
}
