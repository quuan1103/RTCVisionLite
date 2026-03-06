using RTCConst;
using RTCEnums;
using RTCLibs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace RTCSystem
{
    public enum EViewCamInMainFormMode
    {
        Normal = 0,
        GroupCAMWithTab = 1,
        GroupCAMWithoutTab = 2,
        GroupCAMWithoutTabInRow = 3
    }
    public enum ESaveLogFileMode
    {
        CloseProgram = 0,
        AfterTime = 1
    }
    public enum EUpdateSource
    {
        FTP = 0,
        HTTP = 1
    }
    public enum ETimeTypes
    {
        Minutes = 0,
        Hours = 1,
        Days = 2
    }
    public enum EOldMode
    {
        Oldest = 0,
        Latest = 1
    }
    public enum EOKNGConfirm_SaveImage
    {
        None = 0,
        OnlyOK = 1,
        OnlyNG = 2,
        Both = 3
    }

    public enum ESaveLogFileNameMode
    {
        DateTime = 0,
        Order = 1
    }
    public enum ETabControlMainView
    {
        Setup = 0,
        Result = 1
    }
    public enum EupdateSource
    {
        FTP = 0,
        HTTP = 1
    }
    public enum EUpdateMode
    {
        StartProgram = 0,
        ByTime = 1
    }
    public enum ECleanImageFolderMode
    {
        ProjectFolder = 0,
        Custom = 1
    }
    public class cVersion
    {
        public string FileVersion { get; set; }
        public string ProductName { get; set; }
        public string ProductVersion { get; set; }
        public string FileDescription { get; set; }
        public string FileName { get; set; }
        public string PublicName { get; set; }
        public string OriginalFileName { get; set; }
        public string LegalCopyRight { get; set; }
        public cVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            FileVersion = fvi.FileVersion;
            ProductName = fvi.ProductName;
            ProductVersion = fvi.ProductVersion;
            FileDescription = fvi.FileDescription;
            FileName = fvi.FileName;
            PublicName = fvi.InternalName;
            OriginalFileName = fvi.OriginalFilename;
            LegalCopyRight = fvi.LegalCopyright;
        }
    }

    public class cOSInfo
    {
        public string WindowName { get; set; }
        public string OSVersion { get; set; }
        public string OSPlatform { get; set; }
        public string OSServicePack { get; set; }
        public string OSVersionString { get; set; }
        public string MajorVersion { get; set; }
        public string MajorRevision { get; set; }
        public string MinorVersion { get; set; }
        public string MinorRevision { get; set; }
        public string Build { get; set; }
        public string FullInfo
        {
            get
            {
                return string.Join(";", WindowName, "Version: " + OSVersion, "Platform: " + OSPlatform, "ServicePack: " + OSServicePack, "Build: " + Build);
            }
        }
        public string GetOSFriendlyName()
        {
            string result = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
                foreach (ManagementObject os in searcher.Get())
                {
                    result = os["Caption"].ToString();
                    break;
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
        public cOSInfo()
        {
            WindowName = GetOSFriendlyName();
        }
    }

    /// <summary>
    /// Đối tượng lưu thông tin các đường dẫn thư mục
    /// </summary>
    public class cPaths
    {
        /// <summary>
        /// Thư mục thực thi của chương trình
        /// </summary>
        public string AppPath { get; set; }
        /// <summary>
        /// Thư mục chứa các procedure Halcon
        /// </summary>
        public string Procedures { get; set; }
        /// <summary>
        /// Thư mục chứa các file mẫu của chương trình
        /// </summary>
        public string Templates { get; set; }
        public string License { get; set; }
        public string ProjectSaveResult { get; set; }
        public string Logs { get; set; }
        public string UpdateVersion { get; set; }
        public string Errors { get; set; }
        public string Reports { get; set; }
        public string Helps { get; set; }
        public string Documents { get; set; }
        public string Videos { get; set; }
        public string ProjectTemplates { get; set; }
        public string Temp { get; set; }
        /// <summary>
        /// Thư mục lưu project
        /// </summary>
        public string Projects { get; set; }
        public string History { get; set; }
        public string Snap { get; set; }
        /// <summary>
        /// Thư mục nhớ lưu file thiết lập groupactions
        /// </summary>
        public string OldPathSaveGroup { get; set; }
        /// <summary>
        /// Thư mục nhớ mở file thiết lập groupactions
        /// </summary>
        public string OldPathOpenGroup { get; set; }
        public string OldPathChooseFolder { get; set; }
    }
    /// <summary>
    /// Đối tượng chứa thông tin các đường dẫn file
    /// </summary>
    public class cFiles
    {
        public string Common { get; set; }
        public string SaveTemplate { get; set; }
        public string ReportTemplate { get; set; }
        public string LogTemplate { get; set; }
        public string ErrorTemplate { get; set; }
        public string ErrorData { get; set; }
        public string LogData { get; set; }
        public string ReportData { get; set; }
        public string LayoutData { get; set; }
        public string UserData { get; set; }
        public string CursorZoom { get; set; }
        public string Config { get; set; }
        public string LastProjectOpenName { get; set; }
        public string HistoryTemplate { get; set; }
        public string HistoryLogo { get; set; }
        public string RTCLogo { get; set; }
        public string RTCIco { get; set; }
        public string LicenseFile { get; set; }
        public string LicenseFileByMonth { get; set; }
        public string LicenseFileDefault { get; set; }
        public string PdfManual { get; set; }
        public string WordManual { get; set; }
        public string ClearApp { get; set; }
        public string Update { get; set; }
    }
    /// <summary>
    /// Đối tượng chứa thông tin các thiết lập của chương trình
    /// </summary>
    public class cHistoryOptions
    {
        /// <summary>
        /// Cờ báo có lưu file lịch sử lên FTP hay không
        /// </summary>
        public bool IsSaveToFTP { get; set; }
        /// <summary>
        /// HostName
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// Tài khoản đăng nhập
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Mật khẩu FTP
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Tự động tạo folder chứa file lịch sử theo tên project
        /// </summary>
        public bool IsAutoCreateFolderByProjectName { get; set; }
        public bool IsUseSaveLog { get; set; }
        public bool IsAutoSaveLogFile { get; set; }
        public ESaveLogFileMode SaveLogFileMode { get; set; }
        public double TimeSaveLogFile { get; set; }
        public ETimeTypes TimeTypes { get; set; }
        public string SaveLogFileFolder { get; set; }
        public bool IsSaveLogFileFolderByMonth { get; set; }
        public bool IsSaveLogFileFolderByDay { get; set; }
        public string SaveLogFileNamePrefix { get; set; }
        public ESaveLogFileNameMode SaveLogFileNameMode { get; set; }
        public string SaveLogFileNameDateTimeFormat { get; set; }
        public bool IsUseSaveError { get; set; }
        public cHistoryOptions()
        {
            IsSaveToFTP = false;
            HostName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            IsAutoCreateFolderByProjectName = false;

            IsUseSaveLog = true;
            IsAutoSaveLogFile = false;
            SaveLogFileMode = ESaveLogFileMode.CloseProgram;
            TimeSaveLogFile = 30;
            TimeTypes = ETimeTypes.Minutes;
            SaveLogFileFolder = string.Empty;
            IsSaveLogFileFolderByMonth = true;
            IsSaveLogFileFolderByDay = true;
            SaveLogFileNamePrefix = string.Empty;
            SaveLogFileNameMode = ESaveLogFileNameMode.DateTime;
            SaveLogFileNameDateTimeFormat = "yyyy-dd-MM-HH-mm-ss";
            IsUseSaveError = true;
        }
    }
    public class cSmartWindowOptions
    {
        public string MoveAndEditROIWithKey { get; set; }
        public string FontName { get; set; }
        public string FontNameViewRoiInfo { get; set; }
        public string FontLink { get; set; }
        public string FontCamDisplay { get; set; }
        public bool IsUseOKNGLabel { get; set; }
        public bool IsUseOKFrameColor { get; set; }
        public bool IsUseNGFrameColor { get; set; }
        public bool IsUseWindowTextBackgroundColor { get; set; }
        public bool IsUseWindowTextShadowColor { get; set; }
        public string OKFrameColor { get; set; }
        public string NGFrameColor { get; set; }
        public string WindowTextBackgroundColor { get; set; }
        public string WindowTextShadowColor { get; set; }
        public int DisplacementRange { get; set; }
        public int GraphicStackSize { get; set; }
    }
    public class cOptions
    {
        /// <summary>
        /// Cờ báo khi apply thông tin của 1 CAM cho CAM khác có apply thông tin các tools hay không.
        /// </summary>
        public bool ApplyActions_Tools { get; set; }
        /// <summary>
        /// Cờ báo khi apply thông tin của 1 CAM cho CAM khác có apply thông tin ảnh hay không.
        /// </summary>
        public bool ApplyActions_Images { get; set; }
        /// <summary>
        /// Thời gian để tạo khoảng trễ khi RUN multicam nhằm ghi ra kết quả trên màn hình
        /// <para>Đơn vị: ms</para>
        /// </summary>
        public int TimeDelayWhenRunCAM { get; set; }
        /// <summary>
        /// Hiển thị group cam trên màn hình theo tab hay không.
        /// <para>True: Có; False: Không</para>
        /// </summary>
        public EViewCamInMainFormMode ViewCamInMainFormMode { get; set; }
        /// <summary>
        /// Cờ báo có đánh lại tên ROIs hay không.
        /// <para>True: Có; False: Không</para>
        /// </summary>
        public bool RetypeNameROIs { get; set; }
        public bool RetypeNameROI_SortAscending { get; set; }
        public string RetypeNameROI_NameMode { get; set; }
        public string RetypeNameROI_PrefixName { get; set; }
        public int RetypeNameROI_OrderNumber { get; set; }
        public string RetypeNameROI_SortMode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the maximum column camera. </summary>
        ///
        /// <value> True if maximum column camera, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int MaximumColumnCAM { get; set; }
        /// <summary>
        /// Cờ báo chương trình có đóng vai trò là 1 server hay ko
        /// </summary>
        public bool IsServer { get; set; }
        /// <summary>
        /// Cổng port khi đóng vai trò là server
        /// </summary>
        public int PortNumber { get; set; }
        /// <summary>
        /// Cờ báo chương trình đang hiển thị ở trạng thái RUN
        /// </summary>
        public bool RunMode { get; set; }
        /// <summary>
        /// Cờ báo có sử dụng thông tin trigger của CAM hay là custom bên ngoài.
        /// </summary>
        public bool UsingCAMTriggerSetting { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the panel camera cordinate is hidden.
        /// </summary>
        ///
        /// <value> True if hide panel camera cordinate, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool HidePanelCAMCordinate { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this  is PLC enable. </summary>
        ///
        /// <value> True if this  is PLC enable, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPLCEnable { get; set; }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time delay when change job. </summary>
        ///
        /// <value> The time delay when change job. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int TimeDelayWhenChangeJob { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this  is show master camera. </summary>
        ///
        /// <value> True if this  is show master camera, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsShowMasterCAM { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this  is show child camera. </summary>
        ///
        /// <value> True if this  is show child camera, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsShowChildCAM { get; set; }
        public bool IsAutoGetDataWhenRun { get; set; }
        public bool IsSaveLog { get; set; }
        public int BackToOriginTimeOut { get; set; }
        public bool IsUseVisionResult { get; set; }
        public int CameraConnectTimeOut { get; set; }
        public int NumberOfAttemptsToConnectTheCamera { get; set; }
        public bool IsLimitProcessRunning { get; set; }
        public int LimitProcessRunning { get; set; }
        public bool IsAutorunProgramWhenStartWindows { get; set; }
        public int RandomStringLenght { get; set; }
    }

    public class cSecurityOptions
    {
        /// <summary>
        /// Cờ báo có sử dụng mật khẩu cho việc chỉnh sửa thông tin tool
        /// </summary>
        public bool IsHavePassOfToolSetting { get; set; }
        /// <summary>
        /// Cờ báo không hỏi lại password
        /// </summary>
        public bool IsKeepLoginToolSetting { get; set; }
        /// <summary>
        /// Cờ báo đã đăng nhập thành công
        /// </summary>
        public bool IsLoginToolSettingSuccess { get; set; }
        /// <summary>
        /// Mật khẩu chỉnh sửa tool
        /// </summary>
        public string PassWordOfToolSetting { get; set; }
        public string PasswordOfToolEdit { get; set; }
        public string SecurityModes { get; set; }
        public bool IsNeedLoginWhenOpenProgram { get; set; }
        public bool IsAdminKeepLogin { get; set; }

        public cSecurityOptions()
        {
            IsLoginToolSettingSuccess = false;
            IsKeepLoginToolSetting = false;
            IsHavePassOfToolSetting = false;
            IsNeedLoginWhenOpenProgram = false;
            PassWordOfToolSetting = "";
            PasswordOfToolEdit = "t44+V+K+8gYvh5LsWh5iQA==";
            SecurityModes = cSecurityModes.SecurityModes_None;
            IsAdminKeepLogin = false;
        }
    }
    public class cRunOptions
    {
        public bool IsAutoCleanWindowBeforeCheck { get; set; }
        public bool IsAutoChangeMainActionUsedCameraWhenRun { get; set; }
        public bool IsAutoRunProjectWhenStartProgram { get; set; }
        public bool IsUseDeviceNameOriginCompact { get; set; }
        public int NumberOfTimesTakePicture { get; set; }
        public int NumberOfTimesTakePictureAsync { get; set; }
        public int NumberOfTimesTryReconnect { get; set; }
        public int SLMPType { get; set; }
        public bool AutoReconnectCam { get; set; } = false;

        /// <summary>
        /// Kí tự nối trong chuỗi num_buffer
        /// </summary>
        public string CharacterUsedForNumBuffers { get; set; }
        /// <summary>
        /// Thời gian chờ khi stop chương trình (tính bằng giây)
        /// </summary>
        public int StopTimeOut { get; set; }
        /// <summary>
        /// Thơi gian chờ khi lấy ảnh (tính bằng mili giây - mặc định 1000)
        /// </summary>
        public int GrabTimeOut { get; set; }
        //public EPLCTypes PlcType { get; set; }
        //public ESLMPTypes SlmpType { get; set; }
        //public EGetImageMode GetImageMode { get; set; }
        public int WaitTimeWhenChangeCameraSettings_Hikrobot = 100;
        public int WaitTimeWhenChangeCameraSettings_Basler = 100;
        public int WaitTimeWhenChangeCameraSettings_Dahua = 100;
        public cRunOptions()
        {
            IsAutoCleanWindowBeforeCheck = true;
            IsAutoChangeMainActionUsedCameraWhenRun = false;
            IsAutoRunProjectWhenStartProgram = false;
            IsUseDeviceNameOriginCompact = true;
            NumberOfTimesTakePicture = 3;
            NumberOfTimesTakePictureAsync = 1;
            NumberOfTimesTryReconnect = 3;
            SLMPType = 0;
        }


    }
    public class cViewOptions
    {
        public bool IsViewRoiCheck { get; set; }
        public bool IsViewCycleTimeInWindow { get; set; }
        public bool IsViewRunCountInWindow { get; set; }
        public ETabControlMainView TabControlMainView { get; set; }
        public int TrayResultSetupPanelWidth { get; set; }
        public bool IsViewMarkName { get; set; }
        public string MarkNameColor { get; set; }
        public bool IsViewMasterName { get; set; }
        public string MasterNameColor { get; set; }
        public bool IsViewNormalRoiName { get; set; }
        public string NormalRoiNameColor { get; set; }
        public bool IsViewMasterRoi { get; set; }
        public bool IsViewMarkRoi { get; set; }
        public bool IsViewNormalRoi { get; set; }
        public string DrawingMode { get; set; }
        public double DrawingLineWidth { get; set; }
        public bool TrayResult_UseMasterView { get; set; }
        public bool TrayResult_IsHorizontal { get; set; }
        public bool IsViewResultTab { get; set; }
        public bool CamFooter_IsViewOKNGButton { get; set; }
        public bool CamFooter_IsViewRobotMoveButton { get; set; }
        public bool CamFooter_IsViewSnapImageButton { get; set; }
        public bool CamFooter_IsViewSaveImageButton { get; set; }
        public bool CamFooter_IsViewLiveCamButton { get; set; }
        public bool CamFooter_IsViewStopLiveCamButton { get; set; }
        public bool CamFooter_IsViewRunButton { get; set; }
        public bool CamFooter_IsViewLogButton { get; set; }
        public bool CamFooter_IsViewCoordinates { get; set; }
        public bool CamFooter_IsViewTriggerSoftware { get; set; }
        public string CamFooter_LogDockStyle { get; set; }
        public bool IsPreviewImageEmbedToGrid { get; set; }
        public bool IsShowPreviewImage { get; set; }
        public bool IsShowLogo { get; set; }
        public bool IsShowMainCounter { get; set; }
        public bool IsShowTime { get; set; }
        public string LogoFileName { get; set; }
        public string ProgramName { get; set; }
        public string SkinName { get; set; }
        public string DefaultSkinName { get; set; }
        public int NumberOfDigitsToRound { get; set; }
        public int ListModelFontSize { get; set; }
        public cViewOptions()
        {
            IsViewRoiCheck = true;
            IsViewCycleTimeInWindow = true;
            IsViewRunCountInWindow = true;
            TabControlMainView = ETabControlMainView.Setup;
            TrayResultSetupPanelWidth = 500;
            IsViewMarkName = true;
            IsViewMasterName = true;
            IsViewNormalRoiName = true;
            MarkNameColor = cColor.MarkColorT;
            MasterNameColor = cColor.DefaultColorT;
            NormalRoiNameColor = cColor.DefaultColorT;
            TrayResult_UseMasterView = false;
            IsShowMainCounter = false;
            IsShowTime = true;
            TrayResult_IsHorizontal = true;
            IsViewMasterRoi = true;
            IsViewMarkRoi = true;
            IsViewNormalRoi = true;
            IsViewResultTab = true;

            CamFooter_IsViewOKNGButton = false;
            CamFooter_IsViewRobotMoveButton = false;
            CamFooter_IsViewSnapImageButton = false;
            CamFooter_IsViewSaveImageButton = false;
            CamFooter_IsViewLiveCamButton = false;
            CamFooter_IsViewStopLiveCamButton = false;
            CamFooter_IsViewCoordinates = false;
            CamFooter_IsViewTriggerSoftware = false;
            //CamFooter_LogDockStype = false;
            IsPreviewImageEmbedToGrid = false;
            IsShowPreviewImage = false;
            IsShowLogo = false;
            LogoFileName = string.Empty;
            //DrawingMode = /*true*/;
            DrawingLineWidth = 3;
            SkinName = "office 2016 Dark";
            DefaultSkinName = "office 2016 Dark";
            ProgramName = "RTCVISIONLIT";
            NumberOfDigitsToRound = 4;
        }
    }

    public class cImageOptions
    {
        public bool IsAutoCleanImage { get; set; }
        public string CleanImageEvent { get; set; }
        public int NumberOfTimeCleanImage { get; set; }
        public int NumberOfTimeCleanImageWithin { get; set; }
        //public ETimeTypes CleanImageTimeType { get; set; }
        //public ETimeTypes CleanImageWithinTimeType { get; set; }
        //public EOldMode CleanImageWithinOldMode { get; set; }
        public DateTime BeginTimeClean { get; set; }

        public bool IsQuestionBeforeClean { get; set; }
        public EOKNGConfirm_SaveImage OKNGConfirm_SaveImageMode { get; set; }
        public string OKNGConfirm_SaveFolder { get; set; }
        public bool OKNGConfirm_UseChildFolder { get; set; }
        public bool OKNGConfirm_ChildFolder_ByMonth { get; set; }
        public bool OKNGConfirm_ChildFolder_ByDay { get; set; }
        public bool OKNGConfirm_ChildFolder_ByModel { get; set; }
        public ECleanImageFolderMode CleanImageFolderMode { get; set; }
        public string CleanImageFolder { get; set; }
    }
    public class cUpdateOptions
    {
        public string AppName { get; set; }
        public string ClearAppName { get; set; }
        public string LicenseAppName { get; set; }
        public string UpdateAppName { get; set; }
        public string CurrentVersion { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FolderName { get; set; }
        public EUpdateSource UpdateSource { get; set; }
        public EUpdateMode UpdateMode { get; set; }
        public bool IsAutoUpdate { get; set; }
    }

    public class cLogOptions
    {
        public bool Disable { get; set; }
        public bool IsSaveLog { get; set; }
        public bool IsSaveLogToDataFile { get; set; }
        public bool IsSaveLogToTextFile { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
        public bool SplitByModel { get; set; }
        public int MaxLine { get; set; }
        public bool LogFormAlwaysOnTop { get; set; }
    }
    public class cReportOptions
    {
        public bool IsSaveReport { get; set; }
    }
    public class cErrorOptions
    {
        public bool IsSaveError { get; set; }
        public bool IsSaveErrorToDataFile { get; set; }
        public bool IsSaveErrorToTextFile { get; set; }
    }
    public class cHikrobotOptions
    {
        public int GetImageBufferTimeOut { get; set; } = 1000;
        public int GrabTimeout { get; set; } = 1000;
        public int IntervalTimeCheckConnected { get; set; } = 500;
        public bool AutoCheckConnected { get; set; } = true;
    }
    public class cDahuaOptions
    {
        public int GetImageBufferTimeOut { get; set; } = 1000;
        public int IntervalTimeCheckConnected { get; set; } = 500;
        public bool AutoCheckConnected { get; set; } = true;
    }
    public class cBaslerOptions
    {
        public int GrabTimeout { get; set; } = 5000;
        public bool GrabByEvent { get; set; } = true;
        public int MaxNumBuffer { get; set; } = 5;
        public int IntervalTimeCheckConnected { get; set; } = 500;
        public bool AutoCheckConnected { get; set; } = true;
    }
    public class cSystemTypes
    {
        private ELanguage _ELanguage = ELanguage.Eng;

        /// <summary>
        /// Ngôn ngữ sử dụng của chương trình
        /// </summary>
        public ELanguage Language
        {
            get { return _ELanguage; }
            set { _ELanguage = value; }
        }

        public cPaths Paths { get; set; }
        public cFiles Files { get; set; }
        public cOSInfo OSInfo { get; set; }
        public cVersion Version { get; set; }
        public cOptions Options { get; set; }
        public cHistoryOptions HistoryOptions { get; set; }
        public cSecurityOptions SecurityOptions { get; set; }
        public cViewOptions ViewOptions { get; set; }
        public cRunOptions RunOptions { get; set; }
        public cSmartWindowOptions SWindowOptions { get; set; }
        public cImageOptions ImageOptions { get; set; }
        public cUpdateOptions UpdateOptions { get; set; }
        public cLogOptions LogOptions { get; set; }
        public cReportOptions ReportOptions { get; set; }
        public cErrorOptions ErrorOptions { get; set; }
        public cDelayTimeOptions DelayTimeOptions { get; set; }
        public cBaslerOptions BaslerOptions { get; set; }
        public cHikrobotOptions HikrobotOptions { get; set; }
        public cDahuaOptions DahuaOptions { get; set; }
        public cSystemTypes()
        {
            Paths = new cPaths();
            Files = new cFiles();
            OSInfo = new cOSInfo();
            Version = new cVersion();
            Options = new cOptions();
            SWindowOptions = new cSmartWindowOptions();
            HistoryOptions = new cHistoryOptions();
            SecurityOptions = new cSecurityOptions();
            ViewOptions = new cViewOptions();
            RunOptions = new cRunOptions();
            ImageOptions = new cImageOptions();
            LogOptions = new cLogOptions();
            ReportOptions = new cReportOptions();
            ErrorOptions = new cErrorOptions();
            UpdateOptions = new cUpdateOptions();
            //HalconOptions = new cHalconOptions();
            DelayTimeOptions = new cDelayTimeOptions();
            BaslerOptions = new cBaslerOptions();
            HikrobotOptions = new cHikrobotOptions();
            DahuaOptions = new cDahuaOptions();
        }

        public void SaveIniConfig()
        {
            cIniFile oINIFile = new cIniFile(Files.Config);
            try
            {
                SaveIniConfig_Paths(oINIFile);

                SaveIniConfig_Files(oINIFile);

                SaveIniConfig_Options(oINIFile);

                SaveIniConfig_HistoryOptions(oINIFile);

                SaveIniConfig_SecurityOptions(oINIFile);

                SaveIniConfig_HSmartOptions(oINIFile);

                SaveIniConfig_ImageOptions(oINIFile);

                SaveIniConfig_ViewOptions(oINIFile);

                SaveIniConfig_LogOptions(oINIFile);

                SaveIniConfig_ReportOptions(oINIFile);

                SaveIniConfig_ErrorOptions(oINIFile);

                SaveIniConfig_RunOptions(oINIFile);

                SaveIniConfig_UpdateOptions(oINIFile);

                //SaveIniConfig_HalconOptions(oINIFile);

                SaveIniConfig_DelayTimeOptions(oINIFile);
            }
            finally
            {
                oINIFile = null;
            }
        }
        public void SaveIniConfig_DelayTimeOptions(cIniFile oINIFile)
        {
            oINIFile.WriteInteger("DelayTimeOptions", "VstDelaySetValue", DelayTimeOptions.VstDelaySetValue);
            oINIFile.WriteInteger("DelayTimeOptions", "GrabImageFixedTime", DelayTimeOptions.GrabImageFixedTime);
        }
        public void SaveIniConfig_UpdateOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("UpdateOptions", "IsAutoUpdate", UpdateOptions.IsAutoUpdate);
            oINIFile.WriteInteger("UpdateOptions", "UpdateSource", (int)UpdateOptions.UpdateSource);
            oINIFile.WriteInteger("UpdateOptions", "UpdateMode", (int)UpdateOptions.UpdateMode);
            oINIFile.WriteString("UpdateOptions", "CurrentVersion", UpdateOptions.CurrentVersion);
            oINIFile.WriteString("UpdateOptions", "HostName", cEncryptDecrypt.Encrypt(UpdateOptions.HostName));
            oINIFile.WriteString("UpdateOptions", "UserName", cEncryptDecrypt.Encrypt(UpdateOptions.UserName));
            oINIFile.WriteString("UpdateOptions", "Password", cEncryptDecrypt.Encrypt(UpdateOptions.Password));
            oINIFile.WriteString("UpdateOptions", "FolderName", UpdateOptions.FolderName);
        }
        public void SaveIniConfig_RunOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("RunOptions", "IsAutoCleanWindowBeforeCheck", RunOptions.IsAutoCleanWindowBeforeCheck);
            oINIFile.WriteBoolean("RunOptions", "IsAutoRunProjectWhenStartProgram", RunOptions.IsAutoRunProjectWhenStartProgram);
            oINIFile.WriteBoolean("RunOptions", "IsUseDeviceNameOriginCompact", RunOptions.IsUseDeviceNameOriginCompact);
            oINIFile.WriteInteger("RunOptions", "NumberOfTimesTakePicture", RunOptions.NumberOfTimesTakePicture);
            oINIFile.WriteInteger("RunOptions", "NumberOfTimesTakePictureAsync", RunOptions.NumberOfTimesTakePictureAsync);
            oINIFile.WriteInteger("RunOptions", "StopTimeOut", RunOptions.StopTimeOut);
            oINIFile.WriteInteger("RunOptions", "GrabTimeOut", RunOptions.GrabTimeOut);
            oINIFile.WriteInteger("RunOptions", "WaitTimeWhenChangeCameraSettings_Hikrobot", RunOptions.WaitTimeWhenChangeCameraSettings_Hikrobot);
            oINIFile.WriteInteger("RunOptions", "WaitTimeWhenChangeCameraSettings_Basler", RunOptions.WaitTimeWhenChangeCameraSettings_Basler);
            oINIFile.WriteInteger("RunOptions", "WaitTimeWhenChangeCameraSettings_Dahua", RunOptions.WaitTimeWhenChangeCameraSettings_Dahua);
            oINIFile.WriteInteger("RunOptions", "NumberOfTimesTryReconnect", RunOptions.NumberOfTimesTryReconnect);
            //oINIFile.WriteInteger("RunOptions", "PlcType", (int)RunOptions.PlcType);
            oINIFile.WriteInteger("RunOptions", "SlmpType", (int)RunOptions.SLMPType);
            //oINIFile.WriteInteger("RunOptions", "GetImageMode", (int)RunOptions.GetImageMode);
            oINIFile.WriteString("RunOptions", "CharacterUsedForNumBuffers", string.IsNullOrEmpty(RunOptions.CharacterUsedForNumBuffers) ? " " : RunOptions.CharacterUsedForNumBuffers);
        }
        public void SaveIniConfig_ErrorOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("ErrorOptions", "IsSaveError", ErrorOptions.IsSaveError);
            oINIFile.WriteBoolean("ErrorOptions", "IsSaveErrorToDataFile", ErrorOptions.IsSaveErrorToDataFile);
            oINIFile.WriteBoolean("ErrorOptions", "IsSaveErrorToTextFile", ErrorOptions.IsSaveErrorToTextFile);
        }
        public void SaveIniConfig_ReportOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("ReportOptions", "IsSaveReport", ReportOptions.IsSaveReport);
        }
        public void SaveIniConfig_LogOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("LogOptions", "IsSaveLog", LogOptions.IsSaveLog);
            oINIFile.WriteBoolean("LogOptions", "IsSaveLogToDataFile", LogOptions.IsSaveLogToDataFile);
            oINIFile.WriteBoolean("LogOptions", "IsSaveLogToTextFile", LogOptions.IsSaveLogToTextFile);
            oINIFile.WriteBoolean("LogOptions", "LogFormAlwaysOnTop", LogOptions.LogFormAlwaysOnTop);
            oINIFile.WriteString("LogOptions", "DateFormat", LogOptions.DateFormat);
            oINIFile.WriteString("LogOptions", "TimeFormat", LogOptions.TimeFormat);
            oINIFile.WriteBoolean("LogOptions", "SplitByModel", LogOptions.SplitByModel);
            oINIFile.WriteInteger("LogOptions", "MaxLine", LogOptions.MaxLine);
        }
        public void SaveIniConfig_ViewOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("ViewOptions", "IsViewRoiCheck", ViewOptions.IsViewRoiCheck);
            oINIFile.WriteBoolean("ViewOptions", "IsViewCycleTimeInWindow", ViewOptions.IsViewCycleTimeInWindow);
            oINIFile.WriteBoolean("ViewOptions", "IsViewRunCountInWindow", ViewOptions.IsViewRunCountInWindow);
            oINIFile.WriteInteger("ViewOptions", "TabControlMainView", (int)ViewOptions.TabControlMainView);
            oINIFile.WriteInteger("ViewOptions", "TrayResultSetupPanelWidth", ViewOptions.TrayResultSetupPanelWidth);

            oINIFile.WriteBoolean("ViewOptions", "IsViewMasterRoi", ViewOptions.IsViewMasterRoi);
            oINIFile.WriteBoolean("ViewOptions", "IsViewMarkRoi", ViewOptions.IsViewMarkRoi);
            oINIFile.WriteBoolean("ViewOptions", "IsViewNormalRoi", ViewOptions.IsViewNormalRoi);

            oINIFile.WriteBoolean("ViewOptions", "IsViewMasterName", ViewOptions.IsViewMasterName);
            oINIFile.WriteBoolean("ViewOptions", "IsViewMarkName", ViewOptions.IsViewMarkName);
            oINIFile.WriteBoolean("ViewOptions", "IsViewNormalRoiName", ViewOptions.IsViewNormalRoiName);

            oINIFile.WriteString("ViewOptions", "NormalRoiNameColor", ViewOptions.NormalRoiNameColor);
            oINIFile.WriteString("ViewOptions", "MarkNameColor", ViewOptions.MarkNameColor);
            oINIFile.WriteString("ViewOptions", "MasterNameColor", ViewOptions.MasterNameColor);

            oINIFile.WriteBoolean("ViewOptions", "TrayResult_UseMasterView", ViewOptions.TrayResult_UseMasterView);
            oINIFile.WriteBoolean("ViewOptions", "TrayResult_IsHorizontal", ViewOptions.TrayResult_IsHorizontal);

            oINIFile.WriteBoolean("ViewOptions", "IsViewResultTab", ViewOptions.IsViewResultTab);
            oINIFile.WriteBoolean("ViewOptions", "IsShowMainCounter", ViewOptions.IsShowMainCounter);
            oINIFile.WriteBoolean("ViewOptions", "IsShowTime", ViewOptions.IsShowTime);

            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewOKNGButton", ViewOptions.CamFooter_IsViewOKNGButton);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewRobotMoveButton", ViewOptions.CamFooter_IsViewRobotMoveButton);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewSnapImageButton", ViewOptions.CamFooter_IsViewSnapImageButton);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewSaveImageButton", ViewOptions.CamFooter_IsViewSaveImageButton);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewLiveCamButton", ViewOptions.CamFooter_IsViewLiveCamButton);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewStopLiveCamButton", ViewOptions.CamFooter_IsViewStopLiveCamButton);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewRunButton", ViewOptions.CamFooter_IsViewRunButton);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewLogButton", ViewOptions.CamFooter_IsViewLogButton);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewCoordinates", ViewOptions.CamFooter_IsViewCoordinates);
            oINIFile.WriteBoolean("ViewOptions", "CamFooter_IsViewTriggerSoftware", ViewOptions.CamFooter_IsViewTriggerSoftware);
            oINIFile.WriteString("ViewOptions", "CamFooter_LogDockStyle", ViewOptions.CamFooter_LogDockStyle);
            oINIFile.WriteBoolean("ViewOptions", "IsShowPreviewImage", ViewOptions.IsShowPreviewImage);
            oINIFile.WriteBoolean("ViewOptions", "IsPreviewImageEmbedToGrid", ViewOptions.IsPreviewImageEmbedToGrid);
            oINIFile.WriteInteger("ViewOptions", "ListModelFontSize", ViewOptions.ListModelFontSize);
            oINIFile.WriteString("ViewOptions", "DrawingMode", ViewOptions.DrawingMode);
            oINIFile.WriteDouble("ViewOptions", "DrawingLineWidth", ViewOptions.DrawingLineWidth);
            oINIFile.WriteBoolean("ViewOptions", "IsShowLogo", ViewOptions.IsShowLogo);
            oINIFile.WriteString("ViewOptions", "LogoFileName", ViewOptions.LogoFileName);
            oINIFile.WriteString("ViewOptions", "SkinName", ViewOptions.SkinName);
            oINIFile.WriteString("ViewOptions", "DefaultSkinName", ViewOptions.DefaultSkinName);
            oINIFile.WriteString("ViewOptions", "ProgramName", ViewOptions.ProgramName);
            oINIFile.WriteInteger("ViewOptions", "NumberOfDigitsToRound", ViewOptions.NumberOfDigitsToRound);
        }
        public void SaveIniConfig_ImageOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("ImageOptions", "IsAutoCleanImage", ImageOptions.IsAutoCleanImage);
            oINIFile.WriteString("ImageOptions", "CleanImageEvent", ImageOptions.CleanImageEvent);
            oINIFile.WriteInteger("ImageOptions", "NumberOfTimeCleanImage", ImageOptions.NumberOfTimeCleanImage);
            oINIFile.WriteString("ImageOptions", "BeginTimeClean", ImageOptions.BeginTimeClean.ToString(CultureInfo.InvariantCulture));
            oINIFile.WriteInteger("ImageOptions", "NumberOfTimeCleanImageWithin", ImageOptions.NumberOfTimeCleanImageWithin);
            oINIFile.WriteBoolean("ImageOptions", "IsQuestionBeforeClean", ImageOptions.IsQuestionBeforeClean);
            oINIFile.WriteInteger("ImageOptions", "CleanImageFolderMode", (int)ImageOptions.CleanImageFolderMode);
            oINIFile.WriteString("ImageOptions", "CleanImageFolder", ImageOptions.CleanImageFolder);
        }

        public void SaveIniConfig_HSmartOptions(cIniFile oINIFile)
        {
            oINIFile.WriteString("HSmartOptions", "MoveAndEditROIWithKey", SWindowOptions.MoveAndEditROIWithKey);
            oINIFile.WriteString("HSmartOptions", "FontName", SWindowOptions.FontName);
            oINIFile.WriteString("HSmartOptions", "FontLink", SWindowOptions.FontLink);
            oINIFile.WriteString("HSmartOptions", "FontCamDisplay", SWindowOptions.FontCamDisplay);
            oINIFile.WriteBoolean("HSmartOptions", "IsUseOKFrameColor", SWindowOptions.IsUseOKFrameColor);
            oINIFile.WriteBoolean("HSmartOptions", "IsUseNGFrameColor", SWindowOptions.IsUseNGFrameColor);
            oINIFile.WriteBoolean("HSmartOptions", "IsUseWindowTextBackgroundColor", SWindowOptions.IsUseWindowTextBackgroundColor);
            oINIFile.WriteBoolean("HSmartOptions", "IsUseWindowTextShadowColor", SWindowOptions.IsUseWindowTextShadowColor);
            oINIFile.WriteBoolean("HSmartOptions", "IsUseOKNGLabel", SWindowOptions.IsUseOKNGLabel);
            oINIFile.WriteString("HSmartOptions", "OKFrameColor", SWindowOptions.OKFrameColor);
            oINIFile.WriteString("HSmartOptions", "NGFrameColor", SWindowOptions.NGFrameColor);
            oINIFile.WriteString("HSmartOptions", "WindowTextBackgroundColor", SWindowOptions.WindowTextBackgroundColor);
            oINIFile.WriteString("HSmartOptions", "WindowTextShadowColor", SWindowOptions.WindowTextShadowColor);
            oINIFile.WriteInteger("HSmartOptions", "DisplacementRange", SWindowOptions.DisplacementRange);
            oINIFile.WriteInteger("HSmartOptions", "GraphicStackSize", SWindowOptions.GraphicStackSize);
        }
        public void SaveIniConfig_SecurityOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("SecurityOptions", "IsHavePassOfToolSetting", SecurityOptions.IsHavePassOfToolSetting);
            oINIFile.WriteString("SecurityOptions", "PassWordOfToolSetting", cEncryptDecrypt.Encrypt(SecurityOptions.PassWordOfToolSetting));
            oINIFile.WriteString("SecurityOptions", "PassWordOfToolEdit", cEncryptDecrypt.Encrypt(SecurityOptions.PasswordOfToolEdit));
            oINIFile.WriteString("SecurityOptions", "SecurityModes", cEncryptDecrypt.Encrypt(SecurityOptions.SecurityModes));
            oINIFile.WriteBoolean("SecurityOptions", "IsNeedLoginWhenOpenProgram", SecurityOptions.IsNeedLoginWhenOpenProgram);
        }
        public void SaveIniConfig_HistoryOptions(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("HistoryOptions", "IsSaveToFTP", HistoryOptions.IsSaveToFTP);
            oINIFile.WriteBoolean("HistoryOptions", "IsAutoCreateFolderByProjectName", HistoryOptions.IsAutoCreateFolderByProjectName);
            oINIFile.WriteString("HistoryOptions", "HostName", HistoryOptions.HostName);
            oINIFile.WriteString("HistoryOptions", "UserName", cEncryptDecrypt.Encrypt(HistoryOptions.UserName));
            oINIFile.WriteString("HistoryOptions", "Password", cEncryptDecrypt.Encrypt(HistoryOptions.Password));

            oINIFile.WriteBoolean("HistoryOptions", "IsUseSaveLog", HistoryOptions.IsUseSaveLog);
            oINIFile.WriteBoolean("HistoryOptions", "IsAutoSaveLogFile", HistoryOptions.IsAutoSaveLogFile);
            oINIFile.WriteInteger("HistoryOptions", "SaveLogFileMode", (int)HistoryOptions.SaveLogFileMode);
            oINIFile.WriteString("HistoryOptions", "TimeSaveLogFile", HistoryOptions.TimeSaveLogFile.ToString(CultureInfo.InvariantCulture));
            oINIFile.WriteInteger("HistoryOptions", "TimeSaveLogFileMode", (int)HistoryOptions.TimeTypes);
            oINIFile.WriteString("HistoryOptions", "SaveLogFileFolder", HistoryOptions.SaveLogFileFolder);
            oINIFile.WriteBoolean("HistoryOptions", "IsSaveLogFileFolderByMonth", HistoryOptions.IsSaveLogFileFolderByMonth);
            oINIFile.WriteBoolean("HistoryOptions", "IsSaveLogFileFolderByDay", HistoryOptions.IsSaveLogFileFolderByDay);
            oINIFile.WriteString("HistoryOptions", "SaveLogFileNamePrefix", HistoryOptions.SaveLogFileNamePrefix);
            oINIFile.WriteInteger("HistoryOptions", "SaveLogFileNameMode", (int)HistoryOptions.SaveLogFileNameMode);
            oINIFile.WriteString("HistoryOptions", "SaveLogFileNameDateTimeFormat", HistoryOptions.SaveLogFileNameDateTimeFormat);
            oINIFile.WriteBoolean("HistoryOptions", "IsUseSaveError", HistoryOptions.IsUseSaveError);
        }
        public void SaveIniConfig_Paths(cIniFile oINIFile)
        {
            oINIFile.WriteString("Paths", "OldPathSaveGroup", Paths.OldPathSaveGroup);
            oINIFile.WriteString("Paths", "OldPathOpenGroup", Paths.OldPathOpenGroup);
            oINIFile.WriteString("Paths", "OldPathSaveGroup", Paths.OldPathSaveGroup);
            oINIFile.WriteString("Paths", "OldPathOpenGroup", Paths.OldPathOpenGroup);
            oINIFile.WriteString("Paths", "OldPathChooseFolder", Paths.OldPathChooseFolder);
            oINIFile.WriteString("Paths", "Temp", Paths.Temp);
        }
        public void SaveIniConfig_Files(cIniFile oINIFile)
        {
            oINIFile.WriteString("Files", "LastProjectOpenName", Files.LastProjectOpenName);
            oINIFile.WriteString("Files", "LicenseFile", Files.LicenseFile);
        }
        public void SaveIniConfig_Options(cIniFile oINIFile)
        {
            oINIFile.WriteBoolean("Options", "ApplyActions_Tools", Options.ApplyActions_Tools);
            oINIFile.WriteBoolean("Options", "ApplyActions_Images", Options.ApplyActions_Images);
            oINIFile.WriteInteger("Options", "TimeDelayWhenRunCAM", Options.TimeDelayWhenRunCAM);
            oINIFile.WriteInteger("Options", "ViewGroupCAMInTab", (int)Options.ViewCamInMainFormMode);

            oINIFile.WriteBoolean("Options", "RetypeNameROIs", Options.RetypeNameROIs);
            oINIFile.WriteBoolean("Options", "RetypeNameROI_SortAscending", Options.RetypeNameROI_SortAscending);
            oINIFile.WriteString("Options", "RetypeNameROI_NameMode", Options.RetypeNameROI_NameMode);
            oINIFile.WriteString("Options", "RetypeNameROI_SortMode", Options.RetypeNameROI_SortMode);
            oINIFile.WriteString("Options", "RetypeNameROI_PrefixName", Options.RetypeNameROI_PrefixName);
            oINIFile.WriteInteger("Options", "RetypeNameROI_OrderNumber", Options.RetypeNameROI_OrderNumber);

            oINIFile.WriteBoolean("Options", "IsServer", Options.IsServer);
            oINIFile.WriteInteger("Options", "PortNumber", Options.PortNumber);
            oINIFile.WriteBoolean("Options", "RunMode", Options.RunMode);
            oINIFile.WriteBoolean("Options", "UsingCAMTriggerSetting", Options.UsingCAMTriggerSetting);
            oINIFile.WriteBoolean("Options", "HidePanelCamCordinate", Options.HidePanelCAMCordinate);
            oINIFile.WriteBoolean("Options", "IsPLCEnable", Options.IsPLCEnable);

            oINIFile.WriteInteger("Options", "TimeDelayWhenChangeJob", Options.TimeDelayWhenChangeJob);

            oINIFile.WriteInteger("Options", "MaximumColumnCAM", Options.MaximumColumnCAM);
            oINIFile.WriteBoolean("Options", "IsShowMasterCAM", Options.IsShowMasterCAM);
            oINIFile.WriteBoolean("Options", "IsShowMasterCAM", Options.IsShowChildCAM);
            oINIFile.WriteBoolean("Options", "IsAutoGetDataWhenRun", Options.IsAutoGetDataWhenRun);
            oINIFile.WriteBoolean("Options", "IsSaveLog", Options.IsSaveLog);
            oINIFile.WriteBoolean("Options", "IsLimitProcessRunning", Options.IsLimitProcessRunning);
            oINIFile.WriteInteger("Options", "LimitProcessRunning", Options.LimitProcessRunning);
            oINIFile.WriteInteger("Options", "BackToOriginTimeOut", Options.BackToOriginTimeOut);
            oINIFile.WriteBoolean("Options", "IsUseVisionResult", Options.IsUseVisionResult);
            oINIFile.WriteInteger("Options", "CameraConnectTimeOut", Options.CameraConnectTimeOut);
            oINIFile.WriteInteger("Options", "NumberOfAttemptsToConnectTheCamera", Options.NumberOfAttemptsToConnectTheCamera);

            oINIFile.WriteBoolean("Options", "IsAutorunProgramWhenStartWindows", Options.IsAutorunProgramWhenStartWindows);
            oINIFile.WriteInteger("Options", "RandomStringLenght", Options.RandomStringLenght);
        }
        public void ReadIniConfig()
        {
            ReadDefault();
            if (Files == null || !File.Exists(Files.Config))
                return;

            cIniFile oINIFile = new cIniFile(Files.Config);
            if (oINIFile == null)
                return;
            try
            {
                ReadIniConfig_Paths(oINIFile);

                ReadIniConfig_Files(oINIFile);

                ReadIniConfig_Options(oINIFile);

                ReadIniConfig_HistoryOptions(oINIFile);

                ReadIniConfig_SecurityOptions(oINIFile);

                ReadIniConfig_HSmartOptions(oINIFile);

                ReadIniConfig_RunOptions(oINIFile);

                ReadIniConfig_ImageOptions(oINIFile);

                ReadIniConfig_ViewOptions(oINIFile);

                ReadIniConfig_LogOptions(oINIFile);

                ReadIniConfig_ReportOptions(oINIFile);

                ReadIniConfig_ErrorOptions(oINIFile);

                ReadIniConfig_UpdateOptions(oINIFile);

                //ReadIniConfig_HalconOptions(oINIFile);

                ReadIniConfig_DelayTimeOptions(oINIFile);
            }
            finally
            {
                oINIFile = null;
            }
        }
        public void ReadIniConfig_Options(cIniFile oINIFile)
        {
            Options.ApplyActions_Images = oINIFile.GetBoolean("Options", "ApplyActions_Images", Options.ApplyActions_Images);
            Options.ApplyActions_Tools = oINIFile.GetBoolean("Options", "ApplyActions_Tools", Options.ApplyActions_Tools);
            Options.TimeDelayWhenRunCAM = oINIFile.GetInteger("Options", "TimeDelayWhenRunCAM", Options.TimeDelayWhenRunCAM);
            Options.ViewCamInMainFormMode = (EViewCamInMainFormMode)oINIFile.GetInteger("Options", "ViewGroupCAMInTab", (int)Options.ViewCamInMainFormMode);

            Options.RetypeNameROIs = oINIFile.GetBoolean("Options", "RetypeNameROIs", Options.RetypeNameROIs);
            Options.RetypeNameROI_SortAscending = oINIFile.GetBoolean("Options", "RetypeNameROI_SortAscending", Options.RetypeNameROI_SortAscending);
            Options.RetypeNameROI_NameMode = oINIFile.GetString("Options", "RetypeNameROI_NameMode", Options.RetypeNameROI_NameMode);
            Options.RetypeNameROI_SortMode = oINIFile.GetString("Options", "RetypeNameROI_SortMode", Options.RetypeNameROI_SortMode);
            Options.RetypeNameROI_PrefixName = oINIFile.GetString("Options", "RetypeNameROI_PrefixName", Options.RetypeNameROI_PrefixName);
            Options.RetypeNameROI_OrderNumber = oINIFile.GetInteger("Options", "RetypeNameROI_OrderNumber", Options.RetypeNameROI_OrderNumber);

            Options.IsServer = oINIFile.GetBoolean("Options", "IsServer", Options.IsServer);
            Options.PortNumber = oINIFile.GetInteger("Options", "PortNumber", Options.PortNumber);
            Options.RunMode = oINIFile.GetBoolean("Options", "RunMode", Options.RunMode);
            Options.UsingCAMTriggerSetting = oINIFile.GetBoolean("Options", "UsingCAMTriggerSetting", Options.UsingCAMTriggerSetting);
            Options.HidePanelCAMCordinate = oINIFile.GetBoolean("Options", "HidePanelCamCordinate", Options.HidePanelCAMCordinate);
            Options.IsPLCEnable = oINIFile.GetBoolean("Options", "IsPLCEnable", Options.IsPLCEnable);

            Options.TimeDelayWhenChangeJob = oINIFile.GetInteger("Options", "TimeDelayWhenChangeJob", Options.TimeDelayWhenChangeJob);
            Options.MaximumColumnCAM = oINIFile.GetInteger("Options", "MaximumColumnCAM", Options.MaximumColumnCAM);

            Options.MaximumColumnCAM = oINIFile.GetInteger("Options", "MaximumColumnCAM", Options.MaximumColumnCAM);
            Options.IsShowMasterCAM = oINIFile.GetBoolean("Options", "IsShowMasterCAM", Options.IsShowMasterCAM);
            Options.IsShowChildCAM = oINIFile.GetBoolean("Options", "IsShowChildCAM", Options.IsShowChildCAM);
            Options.IsAutoGetDataWhenRun = oINIFile.GetBoolean("Options", "IsAutoGetDataWhenRun", Options.IsAutoGetDataWhenRun);
            Options.IsSaveLog = oINIFile.GetBoolean("Options", "IsSaveLog", Options.IsSaveLog);
            Options.IsLimitProcessRunning = oINIFile.GetBoolean("Options", "IsLimitProcessRunning", Options.IsLimitProcessRunning);
            Options.LimitProcessRunning = oINIFile.GetInteger("Options", "LimitProcessRunning", Options.LimitProcessRunning);

            if (Options.LimitProcessRunning <= 0)
                Options.LimitProcessRunning = 1;
            else if (Options.LimitProcessRunning >= 100)
                Options.LimitProcessRunning = 100;

            Options.BackToOriginTimeOut = oINIFile.GetInteger("Options", "BackToOriginTimeOut", Options.BackToOriginTimeOut);
            Options.IsUseVisionResult = oINIFile.GetBoolean("Options", "IsUseVisionResult", Options.IsUseVisionResult);
            Options.CameraConnectTimeOut = oINIFile.GetInteger("Options", "CameraConnectTimeOut", Options.CameraConnectTimeOut);
            Options.NumberOfAttemptsToConnectTheCamera = oINIFile.GetInteger("Options", "NumberOfAttemptsToConnectTheCamera", Options.NumberOfAttemptsToConnectTheCamera);
            Options.IsAutorunProgramWhenStartWindows = oINIFile.GetBoolean("Options", "IsAutorunProgramWhenStartWindows", Options.IsAutorunProgramWhenStartWindows);
        }
        public void ReadIniConfig_UpdateOptions(cIniFile oINIFile)
        {
            UpdateOptions.UpdateSource = (EUpdateSource)oINIFile.GetInteger("UpdateOptions", "UpdateSource", 0);
            UpdateOptions.UpdateMode = (EUpdateMode)oINIFile.GetInteger("UpdateOptions", "UpdateMode", 0);
            UpdateOptions.IsAutoUpdate = oINIFile.GetBoolean("UpdateOptions", "IsAutoUpdate", UpdateOptions.IsAutoUpdate);
            UpdateOptions.CurrentVersion = oINIFile.GetString("UpdateOptions", "CurrentVersion", UpdateOptions.CurrentVersion);
            UpdateOptions.HostName = cEncryptDecrypt.Decrypt(oINIFile.GetString("UpdateOptions", "HostName",
                cEncryptDecrypt.Encrypt(UpdateOptions.HostName)));
            UpdateOptions.UserName = cEncryptDecrypt.Decrypt(oINIFile.GetString("UpdateOptions", "UserName",
                cEncryptDecrypt.Encrypt(UpdateOptions.UserName)));
            UpdateOptions.Password = cEncryptDecrypt.Decrypt(oINIFile.GetString("UpdateOptions", "Password",
                cEncryptDecrypt.Encrypt(UpdateOptions.Password)));
            UpdateOptions.FolderName = oINIFile.GetString("UpdateOptions", "FolderName", UpdateOptions.FolderName);
        }
        public void ReadIniConfig_DelayTimeOptions(cIniFile oINIFile)
        {
            DelayTimeOptions.VstDelaySetValue = oINIFile.GetInteger("DelayTimeOptions", "VstDelaySetValue", DelayTimeOptions.VstDelaySetValue);
            DelayTimeOptions.GrabImageFixedTime = oINIFile.GetInteger("DelayTimeOptions", "GrabImageFixedTime", DelayTimeOptions.GrabImageFixedTime);
        }
        public void ReadIniConfig_ReportOptions(cIniFile oINIFile)
        {
            ReportOptions.IsSaveReport = oINIFile.GetBoolean("ReportOptions", "IsSaveReport", ReportOptions.IsSaveReport);
        }
        public void ReadIniConfig_ErrorOptions(cIniFile oINIFile)
        {
            ErrorOptions.IsSaveError = oINIFile.GetBoolean("ErrorOptions", "IsSaveError", ErrorOptions.IsSaveError);
            ErrorOptions.IsSaveErrorToDataFile = oINIFile.GetBoolean("ErrorOptions", "IsSaveErrorToDataFile", ErrorOptions.IsSaveErrorToDataFile);
            ErrorOptions.IsSaveErrorToTextFile = oINIFile.GetBoolean("ErrorOptions", "IsSaveErrorToTextFile", ErrorOptions.IsSaveErrorToTextFile);
        }
        public void ReadIniConfig_LogOptions(cIniFile oINIFile)
        {
            LogOptions.IsSaveLog = oINIFile.GetBoolean("LogOptions", "IsSaveLog", LogOptions.IsSaveLog);
            LogOptions.IsSaveLogToDataFile = oINIFile.GetBoolean("LogOptions", "IsSaveLogToDataFile", LogOptions.IsSaveLogToDataFile);
            LogOptions.IsSaveLogToTextFile = oINIFile.GetBoolean("LogOptions", "IsSaveLogToTextFile", LogOptions.IsSaveLogToTextFile);
            LogOptions.LogFormAlwaysOnTop = oINIFile.GetBoolean("LogOptions", "LogFormAlwaysOnTop", LogOptions.LogFormAlwaysOnTop);
            LogOptions.DateFormat = oINIFile.GetString("LogOptions", "DateFormat", LogOptions.DateFormat);
            LogOptions.TimeFormat = oINIFile.GetString("LogOptions", "TimeFormat", LogOptions.TimeFormat);
            LogOptions.SplitByModel = oINIFile.GetBoolean("LogOptions", "SplitByModel", LogOptions.SplitByModel);
            LogOptions.MaxLine = oINIFile.GetInteger("LogOptions", "MaxLine", LogOptions.MaxLine);
            if (LogOptions.MaxLine <= 0)
                LogOptions.MaxLine = 10000;
        }
        public void ReadIniConfig_ViewOptions(cIniFile oINIFile)
        {
            ViewOptions.IsViewRoiCheck = oINIFile.GetBoolean("ViewOptions", "IsViewRoiCheck", ViewOptions.IsViewRoiCheck);
            ViewOptions.IsViewCycleTimeInWindow = oINIFile.GetBoolean("ViewOptions", "IsViewCycleTimeInWindow", ViewOptions.IsViewCycleTimeInWindow);
            ViewOptions.IsViewRunCountInWindow = oINIFile.GetBoolean("ViewOptions", "IsViewRunCountInWindow", ViewOptions.IsViewRunCountInWindow);
            ViewOptions.TabControlMainView = (ETabControlMainView)oINIFile.GetInteger("ViewOptions", "TabControlMainViewk",
                (int)ViewOptions.TabControlMainView);
            ViewOptions.TrayResultSetupPanelWidth = oINIFile.GetInteger("ViewOptions", "TrayResultSetupPanelWidth",
                ViewOptions.TrayResultSetupPanelWidth);

            ViewOptions.IsViewMasterRoi = oINIFile.GetBoolean("ViewOptions", "IsViewMasterRoi", ViewOptions.IsViewMasterRoi);
            ViewOptions.IsViewMarkRoi = oINIFile.GetBoolean("ViewOptions", "IsViewMarkRoi", ViewOptions.IsViewMarkRoi);
            ViewOptions.IsViewNormalRoi = oINIFile.GetBoolean("ViewOptions", "IsViewNormalRoi", ViewOptions.IsViewNormalRoi);


            ViewOptions.IsViewMarkName = oINIFile.GetBoolean("ViewOptions", "IsViewMarkName", ViewOptions.IsViewMarkName);
            ViewOptions.IsViewMasterName = oINIFile.GetBoolean("ViewOptions", "IsViewMasterName", ViewOptions.IsViewMasterName);
            ViewOptions.IsViewNormalRoiName = oINIFile.GetBoolean("ViewOptions", "IsViewNormalRoiName", ViewOptions.IsViewNormalRoiName);

            ViewOptions.MarkNameColor = oINIFile.GetString("ViewOptions", "MarkNameColor", ViewOptions.MarkNameColor);
            ViewOptions.MasterNameColor = oINIFile.GetString("ViewOptions", "MasterNameColor", ViewOptions.MasterNameColor);
            ViewOptions.NormalRoiNameColor = oINIFile.GetString("ViewOptions", "NormalRoiNameColor", ViewOptions.NormalRoiNameColor);

            ViewOptions.TrayResult_UseMasterView = oINIFile.GetBoolean("ViewOptions", "TrayResult_UseMasterView", ViewOptions.TrayResult_UseMasterView);
            ViewOptions.TrayResult_IsHorizontal = oINIFile.GetBoolean("ViewOptions", "TrayResult_IsHorizontal", ViewOptions.TrayResult_IsHorizontal);
            ViewOptions.IsViewResultTab = oINIFile.GetBoolean("ViewOptions", "IsViewResultTab", ViewOptions.IsViewResultTab);
            ViewOptions.IsShowMainCounter = oINIFile.GetBoolean("ViewOptions", "IsShowMainCounter", ViewOptions.IsShowMainCounter);
            ViewOptions.IsShowTime = oINIFile.GetBoolean("ViewOptions", "IsShowTime", ViewOptions.IsShowTime);

            ViewOptions.CamFooter_IsViewOKNGButton = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewOKNGButton", ViewOptions.CamFooter_IsViewOKNGButton);
            ViewOptions.CamFooter_IsViewRobotMoveButton = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewRobotMoveButton", ViewOptions.CamFooter_IsViewRobotMoveButton);
            ViewOptions.CamFooter_IsViewSnapImageButton = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewSnapImageButton", ViewOptions.CamFooter_IsViewSnapImageButton);
            ViewOptions.CamFooter_IsViewSaveImageButton = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewSaveImageButton", ViewOptions.CamFooter_IsViewSaveImageButton);
            ViewOptions.CamFooter_IsViewLiveCamButton = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewLiveCamButton", ViewOptions.CamFooter_IsViewLiveCamButton);
            ViewOptions.CamFooter_IsViewStopLiveCamButton = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewStopLiveCamButton", ViewOptions.CamFooter_IsViewStopLiveCamButton);
            ViewOptions.CamFooter_IsViewRunButton = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewRunButton", ViewOptions.CamFooter_IsViewRunButton);
            ViewOptions.CamFooter_IsViewLogButton = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewLogButton", ViewOptions.CamFooter_IsViewLogButton);
            ViewOptions.CamFooter_IsViewTriggerSoftware = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewTriggerSoftware", ViewOptions.CamFooter_IsViewTriggerSoftware);
            ViewOptions.CamFooter_IsViewCoordinates = oINIFile.GetBoolean("ViewOptions", "CamFooter_IsViewCoordinates", ViewOptions.CamFooter_IsViewCoordinates);
            ViewOptions.CamFooter_LogDockStyle = oINIFile.GetString("ViewOptions", "CamFooter_LogDockStyle", ViewOptions.CamFooter_LogDockStyle);
            ViewOptions.IsPreviewImageEmbedToGrid = oINIFile.GetBoolean("ViewOptions", "IsPreviewImageEmbedToGrid", ViewOptions.IsPreviewImageEmbedToGrid);
            ViewOptions.IsShowPreviewImage = oINIFile.GetBoolean("ViewOptions", "IsShowPreviewImage", ViewOptions.IsShowPreviewImage);
            ViewOptions.DrawingMode = oINIFile.GetString("ViewOptions", "DrawingMode", ViewOptions.DrawingMode);
            ViewOptions.DrawingLineWidth = oINIFile.GetDouble("ViewOptions", "DrawingLineWidth", ViewOptions.DrawingLineWidth);
            ViewOptions.IsShowLogo = oINIFile.GetBoolean("ViewOptions", "IsShowLogo", ViewOptions.IsShowLogo);
            ViewOptions.LogoFileName = oINIFile.GetString("ViewOptions", "LogoFileName", ViewOptions.LogoFileName);
            ViewOptions.SkinName = oINIFile.GetString("ViewOptions", "SkinName", ViewOptions.SkinName);
            ViewOptions.DefaultSkinName = oINIFile.GetString("ViewOptions", "DefaultSkinName", ViewOptions.DefaultSkinName);
            ViewOptions.ProgramName = oINIFile.GetString("ViewOptions", "ProgramName", ViewOptions.ProgramName);
            ViewOptions.NumberOfDigitsToRound = oINIFile.GetInteger("ViewOptions", "NumberOfDigitsToRound", ViewOptions.NumberOfDigitsToRound);
            ViewOptions.ListModelFontSize = oINIFile.GetInteger("ViewOptions", "ListModelFontSize", ViewOptions.ListModelFontSize);
            if (ViewOptions.NumberOfDigitsToRound < 0)
                ViewOptions.NumberOfDigitsToRound = 0;
        }
        public void ReadIniConfig_ImageOptions(cIniFile oINIFile)
        {
            ImageOptions.IsAutoCleanImage = oINIFile.GetBoolean("ImageOptions", "IsAutoCleanImage", ImageOptions.IsAutoCleanImage);
            ImageOptions.CleanImageEvent = oINIFile.GetString("ImageOptions", "CleanImageEvent", ImageOptions.CleanImageEvent);
            ImageOptions.NumberOfTimeCleanImage = oINIFile.GetInteger("ImageOptions", "NumberOfTimeCleanImage", ImageOptions.NumberOfTimeCleanImage);
            DateTime.TryParse(oINIFile.GetString("ImageOptions", "BeginTimeClean",
                    DateTime.Now.ToString(CultureInfo.InvariantCulture)), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime beginTimeClean);
            ImageOptions.BeginTimeClean = beginTimeClean;
            ImageOptions.NumberOfTimeCleanImageWithin = oINIFile.GetInteger("ImageOptions", "NumberOfTimeCleanImageWithin", ImageOptions.NumberOfTimeCleanImageWithin);
            ImageOptions.CleanImageFolderMode = (ECleanImageFolderMode)oINIFile.GetInteger("ImageOptions", "CleanImageFolderMode", (int)ImageOptions.CleanImageFolderMode);
            ImageOptions.CleanImageFolder = oINIFile.GetString("ImageOptions", "CleanImageFolder", ImageOptions.CleanImageFolder);
            ImageOptions.IsQuestionBeforeClean = oINIFile.GetBoolean("ImageOptions", "IsQuestionBeforeClean", ImageOptions.IsQuestionBeforeClean);
        }
        public void ReadIniConfig_RunOptions(cIniFile oINIFile)
        {
            RunOptions.IsAutoCleanWindowBeforeCheck = oINIFile.GetBoolean("RunOptions", "IsAutoCleanWindowBeforeCheck", RunOptions.IsAutoCleanWindowBeforeCheck);
            RunOptions.IsAutoRunProjectWhenStartProgram = oINIFile.GetBoolean("RunOptions", "IsAutoRunProjectWhenStartProgram", RunOptions.IsAutoRunProjectWhenStartProgram);
            //RunOptions.PlcType = (EPLCTypes)oINIFile.GetInteger("RunOptions", "PlcType", (int)RunOptions.PlcType);
            //RunOptions.SlmpType = (ESLMPTypes)oINIFile.GetInteger("RunOptions", "SlmpType", (int)RunOptions.SlmpType);
            //RunOptions.GetImageMode = (EGetImageMode)oINIFile.GetInteger("RunOptions", "GetImageMode", (int)RunOptions.GetImageMode);

            RunOptions.NumberOfTimesTakePicture = oINIFile.GetInteger("RunOptions", "NumberOfTimesTakePicture", RunOptions.NumberOfTimesTakePicture);
            RunOptions.NumberOfTimesTakePictureAsync = oINIFile.GetInteger("RunOptions", "NumberOfTimesTakePictureAsync", RunOptions.NumberOfTimesTakePictureAsync);
            RunOptions.NumberOfTimesTryReconnect = oINIFile.GetInteger("RunOptions", "NumberOfTimesTryReconnect", RunOptions.NumberOfTimesTryReconnect);
            if (RunOptions.NumberOfTimesTakePicture < 1)
                RunOptions.NumberOfTimesTakePicture = 1;
            if (RunOptions.NumberOfTimesTakePictureAsync < 1)
                RunOptions.NumberOfTimesTakePictureAsync = 1;
            if (RunOptions.NumberOfTimesTryReconnect < 1)
                RunOptions.NumberOfTimesTryReconnect = 3;
            RunOptions.SLMPType = oINIFile.GetInteger("RunOptions", "SlmpType", (int)RunOptions.SLMPType);
            if (RunOptions.SLMPType > 1 || RunOptions.SLMPType < 0)
            {
                RunOptions.SLMPType = 0;
            }
            //RunOptions.CharacterUsedForNumBuffers = oINIFile.GetString("RunOptions", "CharacterUsedForNumBuffers", RunOptions.CharacterUsedForNumBuffers).Trim();
        }
        public void ReadIniConfig_HSmartOptions(cIniFile oINIFile)
        {
            SWindowOptions.MoveAndEditROIWithKey = oINIFile.GetString("HSmartOptions", "MoveAndEditROIWithKey", SWindowOptions.MoveAndEditROIWithKey);
            SWindowOptions.FontCamDisplay = oINIFile.GetString("HSmartOptions", "FontCamDisplay", SWindowOptions.FontCamDisplay);
            SWindowOptions.FontName = oINIFile.GetString("HSmartOptions", "FontName", SWindowOptions.FontName);
            SWindowOptions.FontLink = oINIFile.GetString("HSmartOptions", "FontLink", SWindowOptions.FontLink);
            SWindowOptions.IsUseOKFrameColor = oINIFile.GetBoolean("HSmartOptions", "IsUseOKFrameColor", SWindowOptions.IsUseOKFrameColor);
            SWindowOptions.IsUseNGFrameColor = oINIFile.GetBoolean("HSmartOptions", "IsUseNGFrameColor", SWindowOptions.IsUseNGFrameColor);
            SWindowOptions.IsUseWindowTextBackgroundColor = oINIFile.GetBoolean("HSmartOptions", "IsUseWindowTextBackgroundColor", SWindowOptions.IsUseWindowTextBackgroundColor);
            SWindowOptions.IsUseWindowTextShadowColor = oINIFile.GetBoolean("HSmartOptions", "IsUseWindowTextShadowColor", SWindowOptions.IsUseWindowTextShadowColor);
            SWindowOptions.IsUseOKNGLabel = oINIFile.GetBoolean("HSmartOptions", "IsUseOKNGLabel", SWindowOptions.IsUseOKNGLabel);
            SWindowOptions.OKFrameColor = oINIFile.GetString("HSmartOptions", "OKFrameColor", SWindowOptions.OKFrameColor);
            SWindowOptions.NGFrameColor = oINIFile.GetString("HSmartOptions", "NGFrameColor", SWindowOptions.NGFrameColor);
            SWindowOptions.WindowTextBackgroundColor = oINIFile.GetString("HSmartOptions", "WindowTextBackgroundColor", SWindowOptions.WindowTextBackgroundColor);
            SWindowOptions.WindowTextShadowColor = oINIFile.GetString("HSmartOptions", "WindowTextShadowColor", SWindowOptions.WindowTextShadowColor);
            SWindowOptions.DisplacementRange = oINIFile.GetInteger("HSmartOptions", "DisplacementRange", SWindowOptions.DisplacementRange);
            SWindowOptions.GraphicStackSize = oINIFile.GetInteger("HSmartOptions", "GraphicStackSize", SWindowOptions.GraphicStackSize);
            if (SWindowOptions.GraphicStackSize <= 50 && SWindowOptions.GraphicStackSize != -999)
                SWindowOptions.GraphicStackSize = 50;
        }
        public void ReadIniConfig_SecurityOptions(cIniFile oINIFile)
        {
            SecurityOptions.IsHavePassOfToolSetting = oINIFile.GetBoolean("SecurityOptions", "IsHavePassOfToolSetting", SecurityOptions.IsHavePassOfToolSetting);
            SecurityOptions.PassWordOfToolSetting = cEncryptDecrypt.Decrypt(oINIFile.GetString("SecurityOptions", "PassWordOfToolSetting", cEncryptDecrypt.Encrypt(SecurityOptions.PassWordOfToolSetting)));
            SecurityOptions.PasswordOfToolEdit = cEncryptDecrypt.Decrypt(oINIFile.GetString("SecurityOptions", "PassWordOfToolEdit", "t44+V+K+8gYvh5LsWh5iQA=="));
            SecurityOptions.SecurityModes = cEncryptDecrypt.Decrypt(oINIFile.GetString("SecurityOptions", "SecurityModes", cEncryptDecrypt.Encrypt(cSecurityModes.SecurityModes_None)));
            SecurityOptions.IsNeedLoginWhenOpenProgram = oINIFile.GetBoolean("SecurityOptions", "IsNeedLoginWhenOpenProgram", SecurityOptions.IsNeedLoginWhenOpenProgram);
        }
        public void ReadIniConfig_HistoryOptions(cIniFile oINIFile)
        {
            HistoryOptions.IsSaveToFTP = oINIFile.GetBoolean("HistoryOptions", "IsSaveToFTP", HistoryOptions.IsSaveToFTP);
            HistoryOptions.IsAutoCreateFolderByProjectName = oINIFile.GetBoolean("HistoryOptions", "IsAutoCreateFolderByProjectName", HistoryOptions.IsAutoCreateFolderByProjectName);
            HistoryOptions.HostName = oINIFile.GetString("HistoryOptions", "HostName", HistoryOptions.HostName);
            HistoryOptions.UserName = cEncryptDecrypt.Decrypt(oINIFile.GetString("HistoryOptions", "UserName", HistoryOptions.UserName));
            HistoryOptions.Password = cEncryptDecrypt.Decrypt(oINIFile.GetString("HistoryOptions", "Password", HistoryOptions.Password));
            HistoryOptions.IsUseSaveLog = oINIFile.GetBoolean("HistoryOptions", "IsUseSaveLog", HistoryOptions.IsUseSaveLog);
            HistoryOptions.IsAutoSaveLogFile = oINIFile.GetBoolean("HistoryOptions", "IsAutoSaveLogFile", HistoryOptions.IsAutoSaveLogFile);
            HistoryOptions.SaveLogFileMode = (ESaveLogFileMode)oINIFile.GetInteger("HistoryOptions", "SaveLogFileMode", (int)HistoryOptions.SaveLogFileMode);
            double.TryParse(oINIFile.GetString("HistoryOptions", "TimeSaveLogFile", "30"), out double timeSaveLogFile);
            HistoryOptions.TimeSaveLogFile = timeSaveLogFile;
            HistoryOptions.TimeTypes = (ETimeTypes)oINIFile.GetInteger("HistoryOptions", "TimeSaveLogFileMode", (int)HistoryOptions.TimeTypes);
            HistoryOptions.SaveLogFileFolder = oINIFile.GetString("HistoryOptions", "SaveLogFileFolder", HistoryOptions.SaveLogFileFolder);
            HistoryOptions.IsSaveLogFileFolderByMonth = oINIFile.GetBoolean("HistoryOptions", "IsSaveLogFileFolderByMonth", HistoryOptions.IsSaveLogFileFolderByMonth);
            HistoryOptions.IsSaveLogFileFolderByDay = oINIFile.GetBoolean("HistoryOptions", "IsSaveLogFileFolderByDay", HistoryOptions.IsSaveLogFileFolderByDay);
            HistoryOptions.SaveLogFileNamePrefix = oINIFile.GetString("HistoryOptions", "SaveLogFileNamePrefix", HistoryOptions.SaveLogFileNamePrefix);
            HistoryOptions.SaveLogFileNameMode = (ESaveLogFileNameMode)oINIFile.GetInteger("HistoryOptions", "SaveLogFileNameMode", (int)HistoryOptions.SaveLogFileNameMode);
            HistoryOptions.SaveLogFileNameDateTimeFormat = oINIFile.GetString("HistoryOptions", "SaveLogFileNameDateTimeFormat", HistoryOptions.SaveLogFileNameDateTimeFormat);
            HistoryOptions.IsUseSaveError = oINIFile.GetBoolean("HistoryOptions", "IsUseSaveError", HistoryOptions.IsUseSaveError);
        }
        public void ReadIniConfig_Files(cIniFile oINIFile)
        {
            Files.LastProjectOpenName = oINIFile.GetString("Files", "LastProjectOpenName", Files.LastProjectOpenName);
            Files.LicenseFile = oINIFile.GetString("Files", "LicenseFile", Files.LicenseFile);
        }
        public class cDelayTimeOptions
        {
            /// <summary>
            /// Thời gian chờ giữa các lần cài đặt độ sáng đèn 
            /// </summary>
            public int VstDelaySetValue { get; set; }
            public int GrabImageFixedTime { get; set; }
            public cDelayTimeOptions()
            {
                VstDelaySetValue = 20;
                GrabImageFixedTime = 0;
            }
        }
        public void ReadIniConfig_Paths(cIniFile oINIFile)
        {
            Paths.OldPathOpenGroup = oINIFile.GetString("Paths", "OldPathOpenGroup", Paths.OldPathOpenGroup);
            if (!Directory.Exists(Paths.OldPathOpenGroup))
                Paths.OldPathOpenGroup = Paths.Projects;

            Paths.OldPathSaveGroup = oINIFile.GetString("Paths", "OldPathSaveGroup", Paths.OldPathSaveGroup);
            if (!Directory.Exists(Paths.OldPathSaveGroup))
                Paths.OldPathSaveGroup = Paths.Projects;

            Paths.OldPathChooseFolder = oINIFile.GetString("Paths", "OldPathChooseFolder", Paths.OldPathChooseFolder);
            if (!Directory.Exists(Paths.OldPathChooseFolder))
                Paths.OldPathChooseFolder = Paths.Projects;

            Paths.Temp = oINIFile.GetString("Paths", "Temp", Paths.Temp);
            if (!Directory.Exists(Paths.Temp))
            {
                Paths.Temp = Path.Combine(Paths.AppPath, "Temp");
                CreatePath(Paths.Temp);
            }

        }

        public void ReadDefault()
        {
            ReadDefault_Paths();
            ReadDefault_Files();
            ReadDefault_OSInfo();
            ReadDefault_Options();
            ReadDefault_HSmartOptions();
            ReadDefault_HistoryOptions();
            ReadDefault_ImageOptions();
            ReadDefault_UpdateOptions();
            ReadDefault_LogOptions();
            ReadDefault_ReportOptions();
            ReadDefault_ErrorOptions();
            ReadDefault_ViewOptions();

        }
        private void ReadDefault_ErrorOptions()
        {
            ErrorOptions.IsSaveError = false;
            ErrorOptions.IsSaveErrorToDataFile = true;
            ErrorOptions.IsSaveErrorToTextFile = true;
        }
        public void ReadDefault_ViewOptions()
        {
            ViewOptions.IsViewRoiCheck = true;
            ViewOptions.IsViewCycleTimeInWindow = true;
            ViewOptions.IsViewRunCountInWindow = true;
            ViewOptions.TabControlMainView = ETabControlMainView.Setup;
            ViewOptions.TrayResultSetupPanelWidth = 500;
            ViewOptions.IsViewMarkName = true;
            ViewOptions.IsViewMasterName = true;
            ViewOptions.IsViewNormalRoiName = true;
            ViewOptions.MarkNameColor = cColor.MarkColorT;
            ViewOptions.MasterNameColor = cColor.DefaultColorT;
            ViewOptions.NormalRoiNameColor = cColor.DefaultColorT;
            ViewOptions.TrayResult_UseMasterView = false;
            ViewOptions.TrayResult_IsHorizontal = true;

            ViewOptions.IsViewMasterRoi = true;
            ViewOptions.IsViewMarkRoi = true;
            ViewOptions.IsViewNormalRoi = true;

            ViewOptions.IsViewResultTab = true;
            ViewOptions.IsShowMainCounter = false;

            ViewOptions.CamFooter_IsViewOKNGButton = false;
            ViewOptions.CamFooter_IsViewRobotMoveButton = false;
            ViewOptions.CamFooter_IsViewSnapImageButton = false;
            ViewOptions.CamFooter_IsViewSaveImageButton = false;
            ViewOptions.CamFooter_IsViewLiveCamButton = false;
            ViewOptions.CamFooter_IsViewStopLiveCamButton = false;
            ViewOptions.CamFooter_IsViewRunButton = false;
            ViewOptions.CamFooter_IsViewLogButton = false;
            ViewOptions.CamFooter_IsViewCoordinates = false;
            ViewOptions.CamFooter_LogDockStyle = cDockStyle.Right;
            ViewOptions.ListModelFontSize = 9;
            ViewOptions.IsPreviewImageEmbedToGrid = false;
            ViewOptions.IsShowPreviewImage = false;

            ViewOptions.IsShowLogo = false;
            ViewOptions.LogoFileName = Files.RTCLogo;

            ViewOptions.DrawingMode = cDrawingMode.fill;
            ViewOptions.DrawingLineWidth = 3;

            ViewOptions.SkinName = "Office 2016 Dark";
            ViewOptions.DefaultSkinName = "Office 2016 Dark";
            ViewOptions.ProgramName = "RTCVISION";
            ViewOptions.NumberOfDigitsToRound = 3;
        }
        private void ReadDefault_ReportOptions()
        {
            ReportOptions.IsSaveReport = false;

        }
        private void ReadDefault_LogOptions()
        {
            LogOptions.Disable = true;
            LogOptions.IsSaveLog = false;
            LogOptions.IsSaveLogToDataFile = true;
            LogOptions.LogFormAlwaysOnTop = false;
            LogOptions.IsSaveLogToTextFile = true;
            LogOptions.DateFormat = cDateFormat.yyyymmdd;
            LogOptions.TimeFormat = cTimeFormat.hhmmss24;
            LogOptions.SplitByModel = false;
            LogOptions.MaxLine = 10000;
        }
        private void ReadDefault_UpdateOptions()
        {
            UpdateOptions.AppName = "RTCVision";
            UpdateOptions.ClearAppName = "RTCClear";
            UpdateOptions.LicenseAppName = "RTCLicense";
            UpdateOptions.UpdateAppName = "RTCUpdate";
            UpdateOptions.CurrentVersion = "4.0.0.1";

            UpdateOptions.IsAutoUpdate = true;
            UpdateOptions.UpdateMode = EUpdateMode.StartProgram;
            UpdateOptions.UpdateSource = EUpdateSource.FTP;
            UpdateOptions.HostName = cEncryptDecrypt.Decrypt("cD/ngp+UykwYOjSn9pUTng==");
            UpdateOptions.UserName = cEncryptDecrypt.Decrypt("Y3On8Gp/ugI=");
            UpdateOptions.Password = cEncryptDecrypt.Decrypt("kB0MeuDycoVez4Whmk/bcA==");
            UpdateOptions.FolderName = "UpdateVersion/RTCVision";
        }

        private void ReadDefault_ImageOptions()
        {
            ImageOptions.CleanImageEvent = cCleanImageEvent.ByTime;
            ImageOptions.IsAutoCleanImage = true;
            ImageOptions.NumberOfTimeCleanImage = 30;
            //ImageOptions.CleanImageTimeType = ETimeTypes.Days;

            //ImageOptions.CleanImageWithinTimeType = ETimeTypes.Days;
            ImageOptions.NumberOfTimeCleanImageWithin = 30;
            //ImageOptions.CleanImageWithinOldMode = EOldMode.Oldest;

            ImageOptions.OKNGConfirm_SaveImageMode = EOKNGConfirm_SaveImage.Both;
            ImageOptions.OKNGConfirm_SaveFolder = Paths.ProjectSaveResult;
            ImageOptions.OKNGConfirm_UseChildFolder = true;
            ImageOptions.OKNGConfirm_ChildFolder_ByMonth = true;
            ImageOptions.OKNGConfirm_ChildFolder_ByDay = true;
            ImageOptions.OKNGConfirm_ChildFolder_ByModel = true;
            ImageOptions.BeginTimeClean = DateTime.Now;
            ImageOptions.IsQuestionBeforeClean = true;
            ImageOptions.CleanImageFolder = string.Empty;
        }
        private void ReadDefault_OSInfo()
        {
            OperatingSystem os = Environment.OSVersion;
            OSInfo.OSVersion = os.Version.ToString();
            OSInfo.OSPlatform = os.Platform.ToString();
            OSInfo.OSServicePack = os.ServicePack.ToString();
            OSInfo.OSVersionString = os.VersionString.ToString();

            Version ver = os.Version;
            OSInfo.MajorVersion = ver.Major.ToString();
            OSInfo.MajorRevision = ver.MajorRevision.ToString();
            OSInfo.MinorVersion = ver.Minor.ToString();
            OSInfo.MinorRevision = ver.MinorRevision.ToString();
            OSInfo.Build = ver.Build.ToString();
        }
        private void ReadDefault_HSmartOptions()
        {
            SWindowOptions.MoveAndEditROIWithKey = cMoveAndEditROIWithKey.None;
            SWindowOptions.FontName = string.Empty;
            SWindowOptions.FontLink = string.Empty;
            SWindowOptions.FontCamDisplay = string.Empty;
            SWindowOptions.IsUseOKNGLabel = true;
            SWindowOptions.IsUseOKFrameColor = false;
            SWindowOptions.IsUseNGFrameColor = true;
            SWindowOptions.OKFrameColor = nameof(Color.Green);
            SWindowOptions.NGFrameColor = nameof(Color.Red);
            SWindowOptions.DisplacementRange = 1;
            SWindowOptions.FontNameViewRoiInfo = string.Empty;
            SWindowOptions.WindowTextBackgroundColor = nameof(Color.Navy);
            SWindowOptions.WindowTextShadowColor = nameof(Color.Navy);


        }
        private void ReadDefault_HistoryOptions()
        {
            HistoryOptions.SaveLogFileFolder = Paths.AppPath;
        }
        private void ReadDefault_Paths()
        {
            Paths.AppPath = AppDomain.CurrentDomain.BaseDirectory;
            Paths.Procedures = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Procedures");
            Paths.Templates = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
            Paths.License = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "License");
            Paths.Projects = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Projects");
            Paths.History = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "History");
            Paths.Logs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            Paths.UpdateVersion = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UpdateVersion");
            Paths.Errors = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Errors");
            Paths.Reports = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
            Paths.Snap = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Snap");
            Paths.ProjectSaveResult = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AOI-Result");
            Paths.Helps = Path.Combine(Paths.AppPath, "Helps");
            Paths.Documents = Path.Combine(Paths.Helps, "Documents");
            Paths.Videos = Path.Combine(Paths.Helps, "Videos");
            Paths.ProjectTemplates = Path.Combine(Paths.Templates, "ProjectTemplates");
            Paths.Temp = Path.Combine(Paths.AppPath, "Temp");

            CreatePath(Paths.Temp);
            CreatePath(Paths.Logs);
            CreatePath(Paths.Errors);
            CreatePath(Paths.Reports);

            Paths.OldPathSaveGroup = Paths.AppPath;
            Paths.OldPathOpenGroup = Paths.AppPath;
            Paths.OldPathChooseFolder = Paths.AppPath;
        }
        private void CreatePath(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch { }
        }

        private void ReadDefault_Files()
        {
            Files.Common = Paths.Templates + Path.DirectorySeparatorChar + "Common.db";
            Files.SaveTemplate = Paths.Templates + Path.DirectorySeparatorChar + "SaveTemplate.db";
            Files.ReportTemplate = Paths.Templates + Path.DirectorySeparatorChar + "ReportTemplate.db";
            Files.LogTemplate = Paths.Templates + Path.DirectorySeparatorChar + "LogTemplate.db";
            Files.ErrorTemplate = Paths.Templates + Path.DirectorySeparatorChar + "ErrorTemplate.db";

            Files.ErrorData = Paths.Templates + Path.DirectorySeparatorChar + "ErrorData.db";
            Files.LogData = Paths.Templates + Path.DirectorySeparatorChar + "LogData.db";
            Files.ReportData = Paths.Templates + Path.DirectorySeparatorChar + "ReportData.db";

            Files.LayoutData = Paths.Templates + Path.DirectorySeparatorChar + "LayoutData.db";
            Files.UserData = Paths.Templates + Path.DirectorySeparatorChar + "UserManager.db";
            Files.CursorZoom = Paths.Templates + Path.DirectorySeparatorChar + "CursorZoom.cur";
            Files.Config = Paths.AppPath + "Config.ini";
            Files.HistoryTemplate = Paths.Templates + Path.DirectorySeparatorChar + "HistoryReport.xlsx";
            Files.HistoryLogo = Paths.Templates + Path.DirectorySeparatorChar + "HistoryReportLogo.png";
            Files.ReportTemplate = Paths.Templates + Path.DirectorySeparatorChar + "ReportTemplate.xlsx";
            Files.PdfManual = Path.Combine(Paths.Documents, "RTCVision Manual.pdf");
            Files.WordManual = Path.Combine(Paths.Documents, "RTCVision Manual.docx");
            Files.LastProjectOpenName = string.Empty;
            Files.LicenseFile = string.Empty;
            Files.LicenseFileByMonth = Paths.License + Path.DirectorySeparatorChar + "license_" + DateTime.Now.Year.ToString() + "_" +
                                       DateTime.Now.Month.ToString() + ".lic";
            Files.LicenseFileDefault = Paths.License + Path.DirectorySeparatorChar + "license.lic";
            Files.ClearApp = Path.Combine(Paths.AppPath, "RTCClear.exe");
            Files.Update = Path.Combine(Paths.AppPath, "RTCUpdate.exe");
            Files.RTCLogo = Path.Combine(Paths.Templates, "RTCLogo.jpg");
            Files.RTCIco = Path.Combine(Paths.Templates, "RTCIco.ico");
        }

        private void ReadDefault_Options()
        {
            Options.ApplyActions_Images = true;
            Options.ApplyActions_Tools = true;
            Options.TimeDelayWhenRunCAM = 10;
            Options.ViewCamInMainFormMode = EViewCamInMainFormMode.Normal;

            Options.RetypeNameROIs = true;
            Options.RetypeNameROI_SortAscending = true;
            Options.RetypeNameROI_NameMode = cROIPropertyTypeNameMode.ByOrderNumber;
            Options.RetypeNameROI_SortMode = cSortMode.None;
            Options.RetypeNameROI_PrefixName = string.Empty;
            Options.RetypeNameROI_OrderNumber = 1;

            Options.IsServer = true;
            Options.PortNumber = 3000;
            Options.RunMode = true;
            Options.UsingCAMTriggerSetting = true;
            Options.HidePanelCAMCordinate = true;
            Options.IsPLCEnable = true;

            Options.TimeDelayWhenChangeJob = 3000;

            Options.MaximumColumnCAM = 4;

            Options.IsShowMasterCAM = true;
            Options.IsShowChildCAM = true;
            Options.IsAutoGetDataWhenRun = true;
            Options.IsSaveLog = false;
            Options.IsLimitProcessRunning = false;
            Options.LimitProcessRunning = 1;
            Options.BackToOriginTimeOut = 15000;
            Options.IsUseVisionResult = false;
            Options.CameraConnectTimeOut = 3000;
            Options.NumberOfAttemptsToConnectTheCamera = 3;
            Options.IsAutorunProgramWhenStartWindows = false;
            Options.RandomStringLenght = 20;
        }
    }
}
