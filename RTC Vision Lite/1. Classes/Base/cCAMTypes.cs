using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public delegate void RTCButtonClickEvents(cCAMTypes sender, EventArgs e);
    public delegate void RTCCameraStatusChangedEvents(cCAMTypes sender);

    public class cGroupCAMTypes
    {
        public Guid ID;
        public int STT { get; set; }
        private string _Name;
        public string Name
        {
            get => _Name;
            set => _Name = value;
        }

        private string _Description;
        public string Description
        {
            get => _Description;
            set => _Description = value;
        }

        private bool _IsActive;
        public bool IsActive
        {
            get => _IsActive;
            set => _IsActive = value;
        }
        public bool IsMultiCAM { get; set; }
        private bool _Passed;
        public bool Passed
        {
            get => _Passed;
            set
            {
                _Passed = value;

                if (Communications != null && Communications.Count > 0)
                {
                    foreach (cDevice _Device in Communications)
                        _Device.Passed = value;
                }
            }
        }
        public List<cDevice> Communications;
        public ucGroupCAMs View { get; set; }

        public cGroupCAMTypes()
        {
            ID = Guid.NewGuid();
            STT = 0;
            Name = "CAM";
            Description = "";
            IsActive = true;
            IsMultiCAM = false;
            View = new ucGroupCAMs();
            cDevice device = new cDevice(EDeviceTypes.Other, "Other", EProtocols.TCPIP);
            device.TCPSetting.HostName = "127.0.0.1";
            device.TCPSetting.Port = 3000;
            device.TCPSetting.TimeOut = 1000;
            device.OutputStringMode = EOutputStringMode.PassFailValue;
        }
        public void BuildDefaultName()
        {
            Name = cStrings.GroupCAM + " " + STT.ToString();
        }

        public void BuildCaptionView()
        {
            if (View != null) View.lblCAMName.Text = Name + (_Description == String.Empty ? "" : " - " + _Description);
        }
    }
    public class cCAMTypes
    {
        #region EVENTS DECLARE

        public RTCButtonClickEvents OnButtonRunClickEvents;
        public RTCButtonClickEvents OnButtonStopClickEvents;
        public RTCCameraStatusChangedEvents OnCameraStatusChangedEvents;
        #endregion

        #region VARIABLES

        public Guid ID;
        public Guid GroupID;
        public long IDRun;
        public bool SaveSuccess;
        public bool LoadSuccess;
        private string _ErrMessage = string.Empty;
        public Thread RunThread = null;

        #endregion

        #region PROPERTIES

        public int STT { get; set; }
        public int RunOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName_Actions { get; set; }
        public string FileName_Iconic { get; set; }
        public string _FileName_TemplateImage;
        public int Position { get; set; }
        public bool IsActive { get; set; }
        public bool IsMaster { get; set; }
        public bool IsAlign { get; set; }
        public bool IsChangeJob { get; set; }
        public bool IsAutoRunBackground { get; set; }
        public bool IsHide { get; set; }
        public bool IsBackground { get; set; }
        public bool IsViewResult { get; set; }
        public bool IsJoinResult { get; set; }
        public bool IsMaximize { get; set; }
        public bool IsGetResultByRunningTool { get; set; }
        public bool DataChange { get; set; }
        public bool IsInThread { get; set; }
        public bool IsRun { get; set; }
        public bool IsViewCounter { get; set; }
        public int OKCount { get; set; }
        public int NGCount { get; set; }
        public int TotalCount { get; set; }

        internal string OldName = string.Empty;

        public cSourceImageSettings SourceImageSettings;
        public ECamTypes _CamType;
        public ECamTypes CamType
        {
            get => _CamType;
            set
            {
                _CamType = value;
                switch (_CamType)
                {
                    case ECamTypes.Normal:
                        break;
                    case ECamTypes.ChangeJob:
                        break;
                    case ECamTypes.Align:
                        if (View != null)
                            View.IsAlignCAM = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public cGroupActions GroupActions { get; set; }

        public ucCAM View { get; set; }
        public cCAMTypes()
        {
            ID = Guid.NewGuid();
            GroupID = Guid.Empty;
            Description = "";
            FileName_Actions = string.Empty;
            FileName_Iconic = string.Empty;
            IsActive = true;
            DataChange = false;
            IsRun = false;
            IsInThread = false;
            IsMaster = true;
            IsHide = false;
            IsBackground = false;
            IsAlign = false;
            IsChangeJob = false;
            IsViewResult = true;
            CamType = ECamTypes.Normal;

            GroupActions = new cGroupActions(GlobVar.fHsmartWindow)
            {
                MyCam = this
            };
            View = new ucCAM();
            View.lblCamName.Text = Name;
            View.MyCAM = this;
        }

        public cCAMTypes(cProjectTypes myProject)
        {
            ID = Guid.NewGuid();
            GroupID = Guid.Empty;
            STT = 0;
            Name = "CAM";
            Description = "";
            FileName_Actions = string.Empty;
            FileName_Iconic = string.Empty;
            IsActive = true;
            IsMaster = true;
            IsAutoRunBackground = false;
            DataChange = false;
            IsRun = false;
            IsInThread = false;
            IsHide = false;
            IsBackground = false;
            IsAlign = false;
            IsChangeJob = false;
            IsViewResult = true;
            IsJoinResult = true;
            IsGetResultByRunningTool = false;
            IsViewCounter = false;
            OKCount = 0;
            NGCount = 0;
            TotalCount = 0;

            GroupActions = new cGroupActions(GlobVar.fHsmartWindow)
            {
                MyCam = this
            };

            View = new ucCAM();
            View.MyCAM = this;
            View.lblCamName.Text = Name;

            View.btnRun.Visible = true;
            View.OnRunButtonClickEvent -= ucCAM_OnRunButtonClickEvents;
            View.OnRunButtonClickEvent += ucCAM_OnRunButtonClickEvents;

            View.OnStopButtonClickEvent -= ucCAM_OnStopButtonClickEvents;
            View.OnStopButtonClickEvent += ucCAM_OnStopButtonClickEvents;

            CamType = ECamTypes.Normal;
            MyProject = myProject;
            //Task task = Task.Factory.StartNew(SetDefaultFont);
        }
        public cCAMTypes(cProjectTypes myProject, int _STT)
        {
            ID = Guid.NewGuid();
            GroupID = Guid.Empty;
            STT = _STT;
            Name = "CAM " + _STT.ToString();
            Description = "";
            FileName_Actions = string.Empty;
            FileName_Iconic = string.Empty;
            IsActive = true;
            IsMaster = true;
            IsAutoRunBackground = false;
            DataChange = false;
            IsRun = false;
            IsInThread = false;
            IsHide = false;
            IsBackground = false;
            IsAlign = false;
            IsChangeJob = false;
            IsViewResult = true;
            IsJoinResult = true;
            IsGetResultByRunningTool = false;
            IsViewCounter = false;
            OKCount = 0;
            NGCount = 0;
            TotalCount = 0;

            GroupActions = new cGroupActions(GlobVar.fHsmartWindow)
            {
                MyCam = this
            };

            View = new ucCAM();
            View.MyCAM = this;
            View.lblCamName.Text = Name;

            View.btnRun.Visible = true;
            View.OnRunButtonClickEvent -= ucCAM_OnRunButtonClickEvents;
            View.OnRunButtonClickEvent += ucCAM_OnRunButtonClickEvents;

            View.OnStopButtonClickEvent -= ucCAM_OnStopButtonClickEvents;
            View.OnStopButtonClickEvent += ucCAM_OnStopButtonClickEvents;

            CamType = ECamTypes.Normal;
            MyProject = myProject;
            //Task task = Task.Factory.StartNew(SetDefaultFont);
        }


        public void BuildDefaultFolderPath(string projectPath)
        {
            if (string.IsNullOrEmpty(OldName) || OldName.ToLower() == Name.ToLower())
            {
                GroupActions.SaveFileFolder = projectPath + Path.DirectorySeparatorChar + FileName_Actions + "_File";
                if (!Directory.Exists(GroupActions.SaveFileFolder))
                    Directory.CreateDirectory(GroupActions.SaveFileFolder);
            }
            else
            {
                string newSaveFileFolder = projectPath + Path.DirectorySeparatorChar + FileName_Actions + "_File";
                string oldSaveFileFolder = projectPath + Path.DirectorySeparatorChar + GlobFuncs.SwitchToUnsigned(OldName) + "File";
                if (Directory.Exists(newSaveFileFolder))
                    GroupActions.SaveFileFolder = newSaveFileFolder;
                else if (Directory.Exists(oldSaveFileFolder))
                {
                    Directory.Move(oldSaveFileFolder, newSaveFileFolder);
                    GroupActions.SaveFileFolder = newSaveFileFolder;
                }
            }
        }
        private string BuildDefaultSettingsSaveImage_Process(string projectPath, string subFolderName)
        {
            string newSaveImagePath = projectPath + Path.DirectorySeparatorChar + FileName_Actions + subFolderName;
            if (string.IsNullOrEmpty(OldName) || OldName.ToLower() == Name.ToLower())
            {
                if (!Directory.Exists(newSaveImagePath))
                    Directory.CreateDirectory(newSaveImagePath);
            }
            else
            {
                string newSaveFileFolder = projectPath + Path.DirectorySeparatorChar + FileName_Actions + subFolderName;
                string oldSaveFileFolder = projectPath + Path.DirectorySeparatorChar + GlobFuncs.SwitchToUnsigned(OldName) + subFolderName;
                if (Directory.Exists(newSaveFileFolder))
                    newSaveImagePath = newSaveFileFolder;
                else if (Directory.Exists(oldSaveFileFolder))
                {
                    Directory.Move(oldSaveFileFolder, newSaveFileFolder);
                    newSaveImagePath = newSaveFileFolder;
                }
            }
            return newSaveImagePath;
        }
        public void BuidDefaultSettingsSaveImage(string projectPath)
        {
            GroupActions.SourceImageSettings.CameraSettings.SaveImageFolder_Pass = BuildDefaultSettingsSaveImage_Process(projectPath, "_Passed");
            GroupActions.SourceImageSettings.CameraSettings.SaveImageFolder_Fail = BuildDefaultSettingsSaveImage_Process(projectPath, "_Failed");
            GroupActions.SourceImageSettings.CameraSettings.SaveImageFolder_Origin = BuildDefaultSettingsSaveImage_Process(projectPath, "_Origin");
            GroupActions.SourceImageSettings.CameraSettings.SaveImageFolder_Snap = BuildDefaultSettingsSaveImage_Process(projectPath, "_Snap");
        }

        public bool IsChangeJobMasterCam()
        {
            return IsActive && IsChangeJob && !IsHide;
        }

        public bool IsAlignMasterCam()
        {
            return IsActive && IsAlign && !IsHide;
        }
        public cProjectTypes MyProject;

        public void BuildDefaultName()
        {
            switch (CamType)
            {
                case ECamTypes.Normal:
                    Name = cStrings.Windows + " " + STT.ToString();
                    break;
                case ECamTypes.Align:
                    Name = "Align CAM";
                    break;
                case ECamTypes.ChangeJob:
                    Name = "Change Job CAM";
                    break;
                default:
                    Name = cStrings.Windows + " " + STT.ToString();
                    break;
            }
        }

        /// <summary>
        /// Build default file name actions
        /// </summary>
        public void BuildDefaultFileNameActions()
        {
            FileName_Actions = GlobFuncs.SwitchToUnsigned(Name);
        }

        public void RemoveEvent()
        {
            if (View == null) return;
            View.OnRunButtonClickEvent -= ucCAM_OnRunButtonClickEvents;
            View.OnStopButtonClickEvent -= ucCAM_OnStopButtonClickEvents;
        }

        private void ucCAM_OnRunButtonClickEvents(object CAMsender, object sender, EventArgs e)
        {
            if (OnButtonRunClickEvents != null)
            {
                OnButtonRunClickEvents(this, e);
            }
        }

        private void ucCAM_OnStopButtonClickEvents(object CAMsender, object sender, EventArgs e)
        {
            if (OnButtonStopClickEvents != null)
            {
                OnButtonStopClickEvents(this, e);
            }
        }

        public void BuildCaptionView()
        {
            if (View != null)
                View.lblCamName.Text = Name + (Description == string.Empty ? "" : " - " + Description);
        }

        public bool IsNormal()
        {
            return IsActive && !IsAlignMasterCam() && !IsChangeJobMasterCam() && !IsHide;
        }


        public void ShowActionTool(cProjectTypes currentProject)
        {
            try
            {
                GlobFuncs.ShowWaitForm("Show tools...");
                GlobVar.GroupActions = GroupActions.Clone(out bool success);
                //var test = GlobVar.GroupActions.Actions[GlobVar.GroupActions.IDMainAction].ProgramMode.rtcValue;
                // var test2 = GroupActions.Actions[GroupActions.IDMainAction].ProgramMode.rtcValue;
                GlobVar.GroupActions.Actions[GlobVar.GroupActions.IDMainAction].ProgramMode.rtcValue = GroupActions.Actions[GroupActions.IDMainAction].ProgramMode.rtcValue;
                GlobVar.GroupActions.Actions[GlobVar.GroupActions.IDMainAction].ManualAction.rtcValue = GroupActions.Actions[GroupActions.IDMainAction].ManualAction.rtcValue;
                GlobVar.GroupActions.Actions[GlobVar.GroupActions.IDMainAction].NoCaptureAndUsingDirectImage.rtcValue = false;
                GlobVar.GroupActions.MyCam = GroupActions.MyCam;
                if (!success)
                {
                    cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_CloneObject, new string[] { Name + ".GroupActions" }, new string[] { Name + ".GroupActions" }));
                    return;
                }
                GlobVar.FrmActions = new FrmActions();
                GlobVar.FrmActions.CreatefHsmartWindow();

                GlobVar.GroupActions.frmHsmartWindow = GlobVar.fHsmartWindow;
                foreach (cAction _Action in GlobVar.GroupActions.Actions.Values)
                {
                    if (_Action.WindowHandle != null)
                        _Action.WindowHandle.rtcValue = GlobVar.fHsmartWindow != null ? GlobVar.fHsmartWindow.SmartWindow : null;
                    if (_Action.RunIsSilent.rtcValue != null) _Action.RunIsSilent.rtcValue = false;
                    _Action.frmHsmartWindow = GlobVar.fHsmartWindow;
                }
                GlobVar.FrmActions.ShowInTaskbar = false;
                if (GlobVar.GroupActions.Actions[GroupActions.IDMainAction].ViewInfo == null)
                    GlobVar.GroupActions.Actions[GroupActions.IDMainAction].CreateViewInfo();

                ((ucMainActions)GlobVar.GroupActions.Actions[GroupActions.IDMainAction].ViewInfo).ViewedValueComputer = false;
                ((ucMainActions)GlobVar.GroupActions.Actions[GroupActions.IDMainAction].ViewInfo).ViewedValueCAM = false;

                GlobVar.FrmActions.IsChildForm = true;
                GlobVar.FrmActions.CurrentProject = currentProject;
                GlobVar.FrmActions.CurrentCAMID = ID;

                GlobVar.GroupActions.RunSimple = false;
                int currentIndex = GroupActions.SourceImageSettings.ComputerSettings.CurrentImgIndex;
                GlobVar.FrmActions.OnSaveJobEvents -= SaveJobEvents;
                GlobVar.FrmActions.OnSaveJobEvents += SaveJobEvents;
                GlobFuncs.CloseWaitForm();
                if (GlobVar.FrmActions.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GlobFuncs.ShowWaitForm("Saving Project...");
                        GroupActions = GlobVar.GroupActions.Clone(out success, false);
                        GroupActions.Actions[GlobVar.GroupActions.IDMainAction].ProgramMode.rtcValue = GlobVar.GroupActions.Actions[GroupActions.IDMainAction].ProgramMode.rtcValue;
                        GroupActions.Actions[GlobVar.GroupActions.IDMainAction].ManualAction.rtcValue = GlobVar.GroupActions.Actions[GroupActions.IDMainAction].ManualAction.rtcValue;
                        GroupActions.MyCam = GlobVar.GroupActions.MyCam;
                        GroupActions.RunSimple = true;
                        if (!success)
                        {
                            cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_CloneObject, new string[] { Name + ".GroupActions" }, new string[] { Name + ".GroupActions" }));
                            return;
                        }
                        GroupActions.SourceImageSettings.ComputerSettings.CurrentImgIndex = currentIndex;
                        GroupActions.SmartWindowControl = View.SmartWindow;
                        foreach (cAction _Action in GroupActions.Actions.Values)
                        {
                            if (_Action.WindowHandle != null && View != null)
                                _Action.WindowHandle.rtcValue = View.SmartWindow;
                            if (_Action.RunIsSilent != null) _Action.RunIsSilent.rtcValue = true;

                            _Action.frmHsmartWindow = null;
                            if (_Action.ViewInfo != null)
                            {
                                _Action.ViewInfo.Dispose();
                                _Action.ViewInfo = null;
                            }
                            _Action.SetFlagTrainToDefault(false);
                        }
                        if (GlobVar.FrmActions.ApplyActionTable != null)
                            foreach (DataRow r in GlobVar.FrmActions.ApplyActionTable.Rows)
                                if (r[cColName.Select].ToString().ToLower() == "true")
                                {
                                    cCAMTypes cam = currentProject.CAMs[(Guid)r[cColName.ID]];
                                    cam.GroupActions = GroupActions.Clone(out success);
                                    cam.GroupActions.SmartWindowControl = cam.View.SmartWindow;
                                    currentProject.CAMs[(Guid)r[cColName.ID]] = cam;

                                    //foreach(cAction action in currentProject.CAMs[(Guid)r[cColName.ID]].GroupActions.Actions.Values)
                                    //{
                                    //    if(action.)
                                    //}
                                }
                        View.ViewImageMode();
                        GlobFuncs.SetWaitFormSuccess();

                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        GlobFuncs.CloseWaitForm();
                    }
                }
            }
            finally
            {
                if (GlobVar.FrmActions != null)
                {
                    GlobVar.FrmActions.Dispose();
                    GlobVar.FrmActions = null;
                }
                if (GlobVar.fHsmartWindow != null)
                {
                    GlobVar.fHsmartWindow.Dispose();
                    GlobVar.fHsmartWindow = null;
                }
                GlobVar.GroupActions = null;
                GlobFuncs.CloseWaitForm();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public void SaveJobEvents(cProjectTypes curentProject)
        {
            try
            {
                GlobFuncs.ShowWaitForm("Prepare data...");
                GroupActions = GlobVar.GroupActions.Clone(out bool success);
                var test = GroupActions.IDMainAction;
                GroupActions.Actions[GlobVar.GroupActions.IDMainAction].ProgramMode.rtcValue = GlobVar.GroupActions.Actions[GroupActions.IDMainAction].ProgramMode.rtcValue;
                GroupActions.Actions[GlobVar.GroupActions.IDMainAction].ManualAction.rtcValue = GlobVar.GroupActions.Actions[GroupActions.IDMainAction].ManualAction.rtcValue;
                GroupActions.MyCam = GlobVar.GroupActions.MyCam;
                GroupActions.RunSimple = true;
                GroupActions.DataChanged = false;
                if (!success)
                {
                    cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Err_CloneObject, new string[] { Name + ".GroupActios" }, new string[] { Name + ".GroupActions" }));
                    return;
                }
                GroupActions.SmartWindowControl = View.SmartWindow;
                foreach (cAction action in GroupActions.Actions.Values)
                {
                    if (action.WindowHandle != null && View != null)
                        action.WindowHandle.rtcValue = View.SmartWindow;
                    if (action.RunIsSilent != null) action.RunIsSilent.rtcValue = true;
                    action.frmHsmartWindow = null;
                    if (action.ViewInfo != null)
                    {
                        action.ViewInfo.Dispose();
                        action.ViewInfo = null;
                    }
                }

                if (GlobVar.FrmActions.ApplyActionTable != null)
                    foreach (DataRow r in GlobVar.FrmActions.ApplyActionTable.Rows)
                        if (r[cColName.Select].ToString().ToLower() == "true")
                        {
                            cCAMTypes cam = curentProject.CAMs[(Guid)r[cColName.ID]];
                            cam.GroupActions = GlobVar.GroupActions.Clone(out success);
                            cam.GroupActions.SmartWindowControl = cam.View.SmartWindow;
                            curentProject.CAMs[(Guid)r[cColName.ID]] = cam;

                            //foreach(cAction action in curentProject.CAMs[(Guid)r[cColName.ID]].GroupActions.Actions.Values)
                            //{
                            //    if(action.)
                            //}
                        }
                curentProject.CAMs[ID].GroupActions = GroupActions;
                if (!ProjectFunctions.cProjectFunctions.SaveProject(curentProject, GroupActions.MyCam.ID, ESaveMode.OneCam))
                    cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Err_SaveObject, new string[] { cStrings.Project.ToLower() }, new string[] { cStrings.ProjectV.ToLower() }));
                else
                    GlobVar.CurrentProject.DataChange = false;
                GlobVar.GroupActions.DataChanged = false;
                View.ViewImageMode();
                GlobFuncs.SetWaitFormSuccess();

            }
            finally
            {
                GlobFuncs.CloseWaitForm();
            }
        }

        public bool IsCamCanRunAuto()
        {
            return IsActive && IsMaster && !IsBackground;
        }
        internal void PrepareDataBeforeRun()
        {
            GroupActions?.PrepareDataBeforeRun();
        }
        internal void ClearDataBeforeRun()
        {
            GroupActions?.ClearDataBeforeRun();
        }
        public void OnDahuaCameraStatusChangedEvents(bool isConnected)
        {
            if (GroupActions != null && GroupActions.SourceImageSettings.CameraSettings.DahuaCamera != null)
            {
                GroupActions.SourceImageSettings.CameraSettings.IsConnected =
                    GroupActions.SourceImageSettings.CameraSettings.DahuaCamera.IsConnected;
                if (OnCameraStatusChangedEvents != null)
                {
                    OnCameraStatusChangedEvents(this);
                }
            }
        }
        public void OnBaslerCameraStatusChangedEvents(bool isConnected)
        {
            if (GroupActions != null && GroupActions.SourceImageSettings.CameraSettings.BaslerCamera != null)
            {
                GroupActions.SourceImageSettings.CameraSettings.IsConnected =
                    GroupActions.SourceImageSettings.CameraSettings.BaslerCamera.IsConnected;
                if (OnCameraStatusChangedEvents != null)
                {
                    OnCameraStatusChangedEvents(this);
                }
            }
        }
        #endregion
    }
}
