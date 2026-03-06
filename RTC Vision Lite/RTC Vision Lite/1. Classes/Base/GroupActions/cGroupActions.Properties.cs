using RTC_Vision_Lite.Forms;
using RTCConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RTC_Vision_Lite.Classes
{
    public partial class cGroupActions
    {

        public int STT;
        public Guid ID;
        public Guid IDMainAction;
        public Guid IDCam;
        public int IDRun = 0;
        public bool DataChanged = true;
        public string FileName = string.Empty;
        public string FileNameBAK = string.Empty;
        public string FileNameIconic = string.Empty;
        public string FileNameIconicBAK = string.Empty;

        public int RunCount = 0;
        public int PassCount = 0;
        public int FailCount = 0;

        public bool StopLoop = false;
        public SString Name;

        public List<string> ImageErrors;

        public bool IsMasterMode = false;

        public Dictionary<string, object> Refvalues;

        public bool Passed = false;

        public bool RunSimple = false;
        public bool IstheFirstTimeRunning = true;
        public string FeedbackData = string.Empty;

        public cSourceImageSettings SourceImageSettings;

        public string SaveFileFolder = string.Empty;

        public string ErrMessage = string.Empty;

        internal List<Guid> OrderActionId = null;

        public Dictionary<Guid, cAction> Actions;
        /// <summary> My camamera.       /// </summary>
        public cCAMTypes MyCam = null;
        /// <summary> The current part r 1/// </summary>
        public List<double> CurrentPart_R1 = null;
        /// <summary> The current part c 1/// </summary>

        public List<double> CurrentPart_C1 = null;
        /// <summary> The current part r 2/// </summary>
        public List<double> CurrentPart_R2 = null;
        /// <summary> The current part c 2/// </summary>

        public List<double> CurrentPart_C2 = null;
        /// <summary> The current part r 3/// </summary>

        public List<double> CurrentPartSetting_C1 = null;
        /// <summary> The current part c 3/// </summary>

        public List<double> CurrentPartSetting_R1 = null;
        /// <summary> The current part r 1/// </summary>

        public List<double> CurrentPartSetting_R2 = null;
        /// <summary> The current part c 1/// </summary>

        public List<double> CurrentPartSetting_C2 = null;

        public bool IsLockMoveTool = false;
        public bool IsReturn = false;
        private FrmHsmartWindow _frmHsmartWindow;

        public FrmHsmartWindow frmHsmartWindow
        {
            get => _frmHsmartWindow;
            set
            {
                _frmHsmartWindow = value;
                _SmartWindowControl = _frmHsmartWindow?.SmartWindow;
            }
        }

        private GraphicsWindow.GraphicsWindow _SmartWindowControl;

        public GraphicsWindow.GraphicsWindow SmartWindowControl
        {
            get => _SmartWindowControl;
            set
            {
                _SmartWindowControl = value;
            }
        }

        private Control _SmartControl;

        public Control SmartControl
        {
            get => _SmartControl;
            set
            {
                _SmartControl = value;
            }
        }

        public cAction MainAction
        {
            get
            {
                if (Actions != null && Actions.ContainsKey(IDMainAction))
                    return Actions[IDMainAction];
                return null;

            }
        }
        internal Dictionary<Guid, List<PropertyInfo>> AllPropertyHaveRef = null;
        public int IndexBreak = -1;
        public Guid ReturnToolID = Guid.Empty;
        public string ReturnMode = cReturnMode.Break;

        internal bool UseLog = false;


    }
}
