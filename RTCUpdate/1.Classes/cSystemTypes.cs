using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCUpdate.Classes
{
    public enum EviewCamInMainFormMode
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
    public enum ETimeTypes
    {
        Minutes = 0,
        Housr = 1,
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
    public enum EUpdateSource
    {
        FTP = 0,
        HTTP = 1
    }
    public enum EUpdateMode
    {
        StartProgram = 0,
        ByTime = 1
    }

    public class cPaths
    {
        /// <summary>
        /// Thư mực thực thi của chương trình
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
        /// <summary>
        /// Thư mục lưu projject
        /// </summary>
        public string Projects { get; set; }
        public string History { get; set; }
        public string Snap { get; set; }
        /// <summary>
        /// Thư mục nhwos lưu file thiết lập groupactions
        /// </summary>
        public string OldPathSaveGroup { get; set; }
        /// <summary>
        /// Thư mục nhớ mở file thiết lập groupactions
        /// </summary>
        public string OldPathOpenGroup { get; set; }
        public string OldPathChooseFolder { get; set; }
    }
    public class cFiles
    {
        public string Config { get; set; }
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
    /// <summary>
    /// Đối tượng chứa thông tin của toàn bộ chương trình khi chạy
    /// </summary>
    public class cSystemTypes
    {
        /// <summary>
        /// Thông tin Path
        /// </summary>
        public cPaths Paths { get; set; }
        public cFiles Files { get; set; }
        public cUpdateOptions UpdateOptions { get; set; }
        public cSystemTypes()
        {
            Paths = new cPaths();
            Files = new cFiles();
            UpdateOptions = new cUpdateOptions();
        }
        private void ReadDefault_UpdateOptions()
        {
            UpdateOptions.AppName = "RTCVisionsLite";
            UpdateOptions.ClearAppName = "RTCClear";
            UpdateOptions.LicenseAppName = "RTCLicense";
            UpdateOptions.UpdateAppName = "RTCUpdate";
            UpdateOptions.CurrentVersion = "1.0.0";

            UpdateOptions.IsAutoUpdate = true;
            UpdateOptions.UpdateMode = EUpdateMode.StartProgram;
            UpdateOptions.UpdateSource = EUpdateSource.FTP;
            UpdateOptions.HostName = cEncryptDecrypt.Decrypt("cD/ngp+UykwYOjSn9pUTng==");
            UpdateOptions.UserName = cEncryptDecrypt.Decrypt("Y3On8Gp/ugI=");
            UpdateOptions.Password = cEncryptDecrypt.Decrypt("kB0MeuDycoVez4Whmk/bcA==");
            UpdateOptions.FolderName = "UpdateVersion/RTCVisionsLite";
        }
        /// <summary>
        /// Đọc thông tin các đường dẫn sử dụng (Mặc định)
        /// </summary>
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
            Paths.OldPathSaveGroup = Paths.AppPath;
            Paths.OldPathOpenGroup = Paths.AppPath;
            Paths.OldPathChooseFolder = Paths.AppPath;

            Files.Config = Paths.AppPath + "Config.ini";
        }
        /// <summary>
        /// Thiết lập Default
        /// </summary>
        public void ReadDefault()
        {
            ReadDefault_Paths();
            ReadDefault_UpdateOptions();
        }

        public void SaveIniConfig_Paths(cIniFile oINIFile)
        {
            oINIFile.WriteString("Paths", "OldPathSaveGroup", Paths.OldPathSaveGroup);
            oINIFile.WriteString("Paths", "OldPathOpenGroup", Paths.OldPathOpenGroup);
            oINIFile.WriteString("Paths", "OldPathSaveGroup", Paths.OldPathSaveGroup);
            oINIFile.WriteString("Paths", "OldPathOpenGroup", Paths.OldPathOpenGroup);
            oINIFile.WriteString("Paths", "OldPathChooseFolder", Paths.OldPathChooseFolder);
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

        /// <summary>
        /// Lưu thiết lập chương trình thành file
        /// </summary>
        public void SaveIniConfig()
        {
            cIniFile oINIFile = new cIniFile(Files.Config);
            try
            {
                SaveIniConfig_Paths(oINIFile);

                SaveIniConfig_UpdateOptions(oINIFile);
            }
            finally
            {
                oINIFile = null;
            }
        }

        public void ReadIniConfig_Paths(cIniFile oINIFile)
        {
            Paths.OldPathOpenGroup = oINIFile.GetString("Paths", "OldPathOpenGroup", Paths.OldPathOpenGroup);
            Paths.OldPathSaveGroup = oINIFile.GetString("Paths", "OldPathSaveGroup", Paths.OldPathSaveGroup);
            Paths.OldPathSaveGroup = oINIFile.GetString("Paths", "OldPathSaveGroup", Paths.OldPathSaveGroup);
            Paths.OldPathOpenGroup = oINIFile.GetString("Paths", "OldPathOpenGroup", Paths.OldPathOpenGroup);
            Paths.OldPathChooseFolder = oINIFile.GetString("Paths", "OldPathChooseFolder", Paths.OldPathChooseFolder);
        }

        public void ReadIniConfig_UpdateOptions(cIniFile oINIFile)
        {
            UpdateOptions.UpdateSource = (EUpdateSource)oINIFile.GetInteger("UpdateOptions", "UpdateSource", 0);
            UpdateOptions.UpdateMode = (EUpdateMode)oINIFile.GetInteger("UpdateOptions", "UpdateMode", 0);
            UpdateOptions.IsAutoUpdate = oINIFile.GetBoolean("UpdateOptions", "IsAutoUpdate", UpdateOptions.IsAutoUpdate);
            UpdateOptions.CurrentVersion = oINIFile.GetString("UpdateOptions", "CurrentVersion", UpdateOptions.CurrentVersion);
            UpdateOptions.HostName = cEncryptDecrypt.Decrypt(oINIFile.GetString("UpdateOptions", "HostName", cEncryptDecrypt.Encrypt(UpdateOptions.HostName)));
            UpdateOptions.UserName = cEncryptDecrypt.Decrypt(oINIFile.GetString("UpdateOptions", "UserName", cEncryptDecrypt.Encrypt(UpdateOptions.UserName)));
            UpdateOptions.Password = cEncryptDecrypt.Decrypt(oINIFile.GetString("UpdateOptions", "Password", cEncryptDecrypt.Encrypt(UpdateOptions.Password)));
            UpdateOptions.FolderName = oINIFile.GetString("UpdateOptions", "FolderName", UpdateOptions.FolderName);
        }
        /// <summary>
        /// Đọc thiết lập chương trình từ file
        /// </summary>
        public void ReadIniConfig()
        {
            ReadDefault();
            cIniFile oINIFile = new cIniFile(Files.Config);
            try
            {
                ReadIniConfig_Paths(oINIFile);

                ReadIniConfig_UpdateOptions(oINIFile);
            }
            finally
            {
                oINIFile = null;
            }
        }
    }
}
