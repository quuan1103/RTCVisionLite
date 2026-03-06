using RTCEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Layout.Classes
{
    public class cTrayResultSettings_CamItem
    {
        public Guid CamID { get; set; }
        public string Name { get; set; }
        public bool IsUseCustomTools { get; set; }
        public List<Guid> ToolsUse;
        public cTrayResultSettings_CamItem()
        {
            CamID = Guid.Empty;
            Name = String.Empty;
            IsUseCustomTools = false;
            ToolsUse = new List<Guid>();
        }
    }

    public class cTrayResultSettings
    {
        private List<cTrayResultSettings_CamItem> EvenCamsBackup;
        private List<cTrayResultSettings_CamItem> OddCamsBackup;
        private Dictionary<int, List<cTrayResultSettings_CamItem>> CustomCamsBackup;
        public List<cTrayResultSettings_CamItem> EvenCams;
        public List<cTrayResultSettings_CamItem> OddCams;
        public IDictionary<int, List<cTrayResultSettings_CamItem>> CustomCams;

        public ETrayResult_SetupProgramToProductMode SetupProgramToProductMode;
        public int NumberOfTray;
        public int RowOfTray;
        public int ColOfTray;
        public string LotName;
        public string TrayName;

        public cTrayResultSettings()
        {
            SetupProgramToProductMode = ETrayResult_SetupProgramToProductMode.EvenOdd;
            EvenCams = new List<cTrayResultSettings_CamItem>();
            OddCams = new List<cTrayResultSettings_CamItem>();
            CustomCams = new Dictionary<int, List<cTrayResultSettings_CamItem>>();
            NumberOfTray = 35;
            RowOfTray = 7;
            ColOfTray = 5;
            LotName = string.Empty;
            TrayName = string.Empty;
        }
    }
}
