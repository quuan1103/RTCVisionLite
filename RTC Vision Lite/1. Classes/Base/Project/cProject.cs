using RTC_Vision_Lite.Layout.Classes;
using RTCEnums;
using RTCSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    /// <summary>
    /// A result item
    /// </summary>
    public class cResultItem
    {
        /// <summary>
        /// Get or Set the identifier
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Get or Set the camid
        /// </summary>
        public Guid CAMID { get; set; }
        /// <summary>
        /// Get or Set the identifier of the group
        /// </summary>
        public Guid GroupID { get; set; }
        /// <summary>
        /// Get or Set the amount camera
        /// </summary>
        public int AmountCAM { get; set; }
        /// <summary>
        /// Get or Set the Passed1
        /// </summary>
        public int Passed1 { get; set; }
        /// <summary>
        /// Get or Set the Passed2
        /// </summary>
        public int Passed2 { get; set; }
        /// <summary>
        /// Get or Set the Passed
        /// </summary>
        public List<bool> Passed { get; set; }
        public Dictionary<Guid, cCAMTypes> CAMS { get; set; }
    }

    /// <summary>
    /// Kieeur chuaws thoong tin Project
    /// </summary>
    public partial class cProjectTypes
    {
        public Guid ID;
        public int OrderNum { get; set; }
        public Guid SerialsID { get; set; }
        public bool Pinned { get; set; }
        public string SerialsName { get; set; }
        /// <summary>
        /// Full pathname of the folder name full file
        /// </summary>
        public string FolderNameFullPath;

        public string OriginPositionImageViewFolder;
        public string RealPositionImageViewFolder;
        /// <summary>
        /// Thư mục chứa (backup)
        /// </summary>
        public string FolderNameFullPathBAK;
        /// <summary>
        /// Tên thư mục chứa
        /// </summary>
        public string FolderName;
        /// <summary>
        /// Thư mục lịch sử
        /// </summary>
        public string FolderNameHistory;
        internal string OldFileName;
        /// <summary>
        /// Tên tệp project (model)
        /// </summary>
        public string FileName;
        public string FileNameBAK;
        /// <summary>
        /// Cờ báo dữ liệu có thay đổi hay không
        /// </summary>
        public bool DataChange;
        /// <summary>
        /// Tên project (model)
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Gets or Sets a value indicating whether this is run
        /// </summary>
        public bool IsRun { get; set; }
        /// <summary>
        /// Gets or Sets the STTCAM
        /// </summary>
        public bool IsUseAlarm { get; set; }
        public bool IsUseAlarmEng { get; set; }
        public bool IsUsePLCStatus { get; set; }
        public bool IsUseRobotStatus { get; set; }
        public bool IsUseCheckStatus { get; set; }
        public bool IsUseAmountCount { get; set; }
        public bool IsUseUserOKNGSLMP { get; set; }
        public string PreviewImage { get; set; }

        public bool SaveSuccess;

        public EAlarmTypes AlarmTypes { get; set; }

        public DataTable Alarm;

        public string Note { get; set; }
        /// <summary>
        /// Gets or Sets the STTCAM
        /// </summary>
        public int STTCAM { get; set; }
        /// <summary>
        /// Gets or Sets the stt group CAM
        /// </summary>
        public int STTGroupCAM { get; set; }
        /// <summary>
        /// Gets or Sets the total products
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Gets or Sets the total pass products
        /// </summary>
        public int OKCount { get; set; }
        /// <summary>
        /// Gets or Sets the total fail product
        /// </summary>
        public int NGCount { get; set; }
        /// <summary>
        /// The result
        /// </summary>
        public Queue<cResultItem> Result;

        /// <summary>
        /// Gets or sets options for controlling the history
        /// </summary>
        internal cHistoryOptions HistoryOptions { get; set; }
        /// <summary>
        /// Gets or sets the ca millisenconds
        /// </summary>
        public Dictionary<Guid, cCAMTypes> CAMs { get; set; }
        /// <summary>
        /// Gets or sets the ca millisenconds
        /// </summary>
        public Dictionary<Guid, cGroupCAMTypes> GroupCAMs { get; set; }
        /// <summary>
        /// Gets or sets the ca millisenconds
        /// </summary>
        public Dictionary<string, List<Guid>> DicRunCAM { get; set; }

        public cTrayResultSettings TrayResultSettings = null;

        public cProjectTypes()
        {
            ID = Guid.NewGuid();
            FolderName = string.Empty;
            FolderNameFullPath = string.Empty;
            FolderNameFullPathBAK = string.Empty;
            ProjectName = string.Empty;
            FileName = string.Empty;
            Note = string.Empty;
            DataChange = false;
            STTCAM = 1;
            STTGroupCAM = 1;

            CAMs = new Dictionary<Guid, cCAMTypes>();
            GroupCAMs = new Dictionary<Guid, cGroupCAMTypes>();
            DicRunCAM = null;
            TotalCount = 0;
            OKCount = 0;
            NGCount = 0;
            IsRun = false;
            IsUseAlarm = false;
            IsUseAlarmEng = false;
            IsUsePLCStatus = false;
            IsUseRobotStatus = false;
            IsUseCheckStatus = false;
            IsUseAmountCount = false;
            IsUseUserOKNGSLMP = false;
            AlarmTypes = EAlarmTypes.PLC;
            Alarm = null;
            TrayResultSettings = new cTrayResultSettings();
            HistoryOptions = new cHistoryOptions();
            Result = new Queue<cResultItem>();
            PreviewImage = string.Empty;
        }
        internal void PrepareDataBeforeRun()
        {
            foreach (cCAMTypes cam in CAMs.Values)
                if (!cam.IsRun)
                    cam.PrepareDataBeforeRun();
        }
    }
}
  
   

