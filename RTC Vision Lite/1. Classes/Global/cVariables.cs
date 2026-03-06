//using CommonTools;
using RTC_Vision_Lite.Classes.Robot;
using RTC_Vision_Lite.Forms;
using RTCConst;
using RTCEnums;
using RTCSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using SLMPTcp;
using RTC_Vision_Lite.Log;
using SlmpCustom;
using ActUtlType64Lib;
using RTC_Vision_Lite.Layout;
using RTC_Vision_Lite.UserManager.Classes;
using Emgu.CV.Structure;
using Emgu.CV;
using RTCVision2101.Classes;
using NsIOControllerSDK.VC3000X;

namespace RTC_Vision_Lite.Classes
{
    static class GlobVar
    {
        internal static Font DefaultFont = new Font("Segoe UI", (float)8.25, FontStyle.Regular);
        public static string AppName = "RVS LITE";
        public static string Version = "1.0.0";
        public static Icon RTCIcon = null;
        public static Stack<Guid> CycleTimeStack = new Stack<Guid>();
        public static string ProgramName = string.Empty;
        public static cLicense License = null;
        public static cUser User = null;
        public static cUserManagerData UserData = null;


        public static bool LockEvents = false;
        public static bool Pause = false;
        public static bool OnlySetValue = false;
        public static bool IsSimulatorMode = false;
        public static bool IsVC3000Register = false;
        public static bool Draw = false;
        public static int ShapeListCount = 10;
        public static bool RunningProcess = true;

        public static int CurrentTool = -1;
        public static object LockObjectCameraSettings = new object();

        public static cSystemTypes RTCVision;

        public static bool IsLinkMode;
        public static bool IsLinkStringBuilderItemMode;
        public static bool IsLinkImageFilterMode;
        public static bool IsLinkCsvWriteValue;
        public static bool IsDebugMode = true;
        public static TreeListView tl;
        public static TreeListView tl_Template;
        public static cProjectTypes CurrentProject = null;
        public static CSocketServer SocketServer = null;
        public static List<ActUtlType64> MyListMXComponent;
        public static cLog Log = null;
        public static cError Error = null;
        public static RTC_Vision_Lite.Forms.FrmLog FormLogs;
        public static bool IsWaitFormActive = false;

        public static Dictionary<Guid, cProjectTypes> DicProjects = null;

        public static Dictionary<string, Guid> ListCams = null;

        public static frmWait RTCWaitForm;
        public static Splasher RTCSplashScreenManager = new Splasher("RTCVision Lite");


        public static DataTable DataTableProjects = null;

        public static string programMode = cProgramMode.Manual;

        public static FrmHsmartWindow fHsmartWindow;

        public static FrmActions FrmActions;

        public static FrmMain FormMain;

        public static ImageList imlActionType32 = null;

        public static ImageList imlActionType24 = null;

        public static ImageList imlActionType16 = null;
        public static Image<Gray, byte> GrayImage = null;
        public static Image<Bgr, byte> BGRImage = null;

        public static OLVColumn ColName = null;
        public static OLVColumn Description = null;
        public static OLVColumn RunCount = null;
        public static OLVColumn FailCount = null;
        public static OLVColumn ProcessTime = null;
        public static OLVColumn TotalTime = null;
        public static OLVColumn AbortCause = null;
        public static OLVColumn Active = null;
        public static Dictionary<string, byte> DicASCII = null;
        public static bool IsSelectMode = false;
        public static bool IsChangeJob = false;
        public static string ChangeJob_ProjectName = string.Empty;
        public static bool ChangeJob_AutoStart = false;
        public static bool ChangeJob_UseOrderNumber = false;
        public static int ChangeJob_OrderNumber = -1;
        public static bool IsStop = false;
        public static bool IsOnlineMode = true;
        public static bool RunByTest = false;

        public static string DeepCopyFileName = string.Empty;
      //  public static cError Error = null;
        /// <summary>
        /// Đối tượng quản lý của waitform, splash screen
        /// </summary>
       

        public static EBuildMode BuildMode = EBuildMode.RTCVision;

        public static List<string> ListToolDemo = new List<string>()
        {
            cStrings.AllTools
        };

        public static bool IsMainMode = true;

        public static cGroupActions GroupActions;
        public static string ProgramMode
        {
            get => programMode;
            set
            {
                programMode = value;
                RebuildControlsStatus();
            }
        }
        public static void RebuildControlsStatus()
        {
            switch (programMode)
            {
                case cProgramMode.Auto:
                    {
                        if (CurrentProject != null)
                            foreach (cCAMTypes cam in CurrentProject.CAMs.Values)
                            {
                                if (cam.View != null)
                                    if (cam.View.InvokeRequired)
                                        cam.View.Invoke((MethodInvoker)delegate
                                        {
                                            cam.View.RebuildButton();
                                        });
                                    else
                                        cam.View.RebuildButton();

                                cAction mainAction = cam.GroupActions.Actions[cam.GroupActions.IDMainAction];
                                mainAction.ProgramMode.rtcValue = programMode;
                                mainAction.ManualAction.rtcValue = cManualAction.None;
                            }
                        break;
                    }
                case cProgramMode.Manual:
                    {
                        if (CurrentProject != null)
                            foreach (cCAMTypes cam in CurrentProject.CAMs.Values)
                            {
                                if (cam.View != null)
                                    cam.View.RebuildButton();
                                cAction mainAction = cam.GroupActions.Actions[cam.GroupActions.IDMainAction];
                                mainAction.ProgramMode.rtcValue = programMode;
                                mainAction.ManualAction.rtcValue = cManualAction.None;
                            }
                        break;
                    }
            }
        }
        public static List<string> HsmartWindowFonts = new List<string>()
        {
            "Courier New","Microsoft Sans Serif","Segoe UI","Tahoma","Verdana","Roboto", "Helvetica Neue"
        };
        /// 
        /// <summary> My PLC with TCP Protocol</summary>
        ///
        public static List<cCOM> MyListCOMReader;
        public static List<SLMPClient> MyListMCPTCP;
        public static List<cModbusClient> MyListModBusTCP;
        public static List<CSocketClient> MyListTCPIP;
        public static List<CSTLightClientNew> MyListCSTLight;
        public static List<cSlmpCustom> MyListSLMP1;
        public static List<cUdp> MyListUDP;
        public static List<CIOControllerSDK3000X> MyListVC3000X;

        public static List<cFTP> MyListFPT;
        public static ucCycleTime CycleTime = null;



        //public static List<cModbusClient> MyListModBusTCP != null;
    }

    public class ActionTools
    {
        public string Description { get; set; }
        public bool Enable { get; set; }
        public bool Active { get; set; }
        public string RunCount { get; set; }
        public string FailCount { get; set; }
        public string ProcessTime { get; set; }
        public string TotalTime { get; set; }
        public string AbortCause { get; set; }
        public Guid IDGroup { get; set; }
        public Guid ID { get; set; }
        public Guid IDBranch { get; set; }
        public Guid IDBranchItem { get; set; }
        public Guid rtcIDRef { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public ENodeTypes NodeType { get; set; }
        public bool rtcSystem { get; set; }
        public EPropertyState State { get; set; }
        public EActionTypes ActionType { get; set; }
        public ActionTools Parent { get; set; }
        public List<ActionTools> child = new List<ActionTools>();
        public ActionTools Copy()
        {
            ActionTools Copy = new ActionTools();
            Copy.Description = this.Description;
            Copy.Enable = this.Enable;
            Copy.Active = this.Active;
            Copy.RunCount = this.RunCount;
            Copy.FailCount = this.FailCount;
            Copy.ProcessTime = this.ProcessTime;
            Copy.TotalTime = this.TotalTime;
            Copy.AbortCause = this.AbortCause;
            Copy.ID = this.ID;
            Copy.IDBranch = this.IDBranch;
            Copy.IDBranchItem = this.IDBranchItem;
            Copy.rtcIDRef = this.rtcIDRef;
            Copy.Name = this.Name;
            Copy.DataType = this.DataType;
            Copy.State = this.State;
            Copy.ActionType = this.ActionType;
            Copy.child = this.child;
            Copy.Parent = this.Parent;
            return Copy;
        }
    }
    public class MyPropertiesItem 
    {
        public string Delete { get; set; }
        public Guid IDref { get; set; }
        public ENodeTypes NodeType { get; set; }
        public bool Enable { get; set; }
        public bool DisplayOutput { get; set; }
        public string Name { get; set; }
        public int STT { get; set; }
        public string Type { get; set; }
        private string _Value = string.Empty;
        public string Value;
        public string RefIndex { get; set; }
        public EPropertyState State { get; set; }
        public bool ReadOnly { get; set; }
        public bool DisplayOutputValueInHistory { get; set; }

        public bool System { get; set; }
        public bool IsCanLink { get; set; }
        public string RefPropName { get; set; }
        public bool Log { get; set; }
        public List<MyPropertiesItem> child = new List<MyPropertiesItem>();
    }
    public class CSVWrite
    {
        public Guid ID { get; set; }
        public int OrderNum { get; set; }
        public bool Active { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public string Link { get; set; }
        public string Format { get; set; }
        public bool Enable { get; set; }
        public bool IsRowToCol { get; set; }
        public string SortMode { get; set; }
        public string Delete { get; set; }
        public List<CSVWrite> Child { get; set; }
    }
    public class LinkSummary
    {
        public ENodeTypes NodeType { get; set; }
        public string PropName { get; set; }
        public string Ref { get; set; }
        public string image { get; set; }
        public List<LinkSummary> child = new List<LinkSummary>();
    }
    public class PassFail
    {
        public Guid IDref { get; set; }
        public string Ref { get; set; }
        public bool Active { get; set; }
        public bool Invert { get; set; }
        public string PropName { get; set; }
        public string Type { get; set; }
        public string CurrentValue { get; set; }
        public string Result { get; set; }
        public bool GetResult { get; set; }
        public string ToolGetResult { get; set; }
        public List<PassFail> child = new List<PassFail>();
    }
    public class ResetTool
    {
        public Guid IDref { get; set; }
        public string ToolName { get; set; }
        public bool IsReset { get; set; }
        public string Type { get; set; }
        public string Settings { get; set; }
        public string SettingsValue { get; set; }


        public List<ResetTool> child = new List<ResetTool>();
    }
    public class CameraSettings
    {
       
        public string PropName { get; set; }
        public string Value { get; set; }
        public List<CameraSettings> child = new List<CameraSettings>();
    }
    public class MultiLink
    {
        public int OrderNumber { get; set; }
        public string SourceCam { get; set; }
        public string SourceTool { get; set; }
        public string SourceName { get; set; }
        public string SourceIndex { get; set; }
        public List<MultiLink> Children { get; set; } 
    }
    public class PropertyLink
    {
        public int OrderNumber { get; set; }
        public string SourceCam { get; set; }
        public string SourceTool { get; set; }
        public string SourceName { get; set; }
        public string SourceIndex { get; set; }
        public string TargetCam { get; set; }
        public string TargetTool { get; set; }
        public string TargetName { get; set; }
        public string TargetIndex { get; set; }
        public List<PropertyLink> Children { get; set; }
    }

}
