using RTC_Vision_Lite.Classes.ProjectFunctions;
using RTC_Vision_Lite.Classes.Robot;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using RTCVision2101.Classes;
using SlmpCustom;
using SLMPTcp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public partial class cGroupActions
    {
        internal Thread threadRun = null;
        private Thread threadView = null;
        private Stopwatch _toltalTime = null;
        public long TotalTimeValue = 0;

        public bool IsSnapSuccess = false;
        public bool IsRunInThread = false;

        public bool IsInRunProcess = false;
        public bool IsSnap = false;
        private bool _isRun = false;

        private bool _isHaveAliveTcpIp = false;
        private bool _isHaveAliveCom = false;
        private bool _isHaveAliveIo = false;
        private bool _isHaveAliveSlmp = false;
        private bool _isHaveAliveMitsuSlmp = false;
        private bool _isHaveAliveModbus = false;
        private bool _isHaveAlivePoc = false;
        private bool _isHaveAliveUdp = false;
        private bool _isHaveAliveCst = false;
        private bool _isHaveAliveVst = false;
        private bool _isHaveAliveCCLinkIE = false;
        private bool _isHaveAliveAdlinkIO = false;
        private bool _isHaveAliveEasyAlign = false;
        public bool IsRun
        {
            get => _isRun;
            set
            {
                _isRun = value;
                //if (MainAction != null)
                //    MainAction.IsRunning.rtcValue = value;
            }

        }

        public void Setting_PrepareDataAllBrachTools()
        {
            foreach(cAction action in Actions.Values)
            {
                switch(action.ActionType)
                {
                    case EActionTypes.Branch:
                        action.Prepare_Branch(action);
                        break;
                    case EActionTypes.Switch:
                        action.Prepare_Switch(action);
                        break;
                    case EActionTypes.PassFail:
                        action.Prepare_PassFail(action);
                        break;
                    case EActionTypes.CounterLoop:
                        action.Prepare_CounterLoop(action);
                        break;
                }
            }
        }

        public void Setting_StopRun()
        {
            try
            {
                StopLoop = true;
                IsRun = false;
                //Thread.Sleep(300);
                //Setting_StopRun_WriteAfterStop();
                //Setting_ResetPropertyValueWhenStop();
                //MyCam.RunThread?.Join(10000);
                //MyCam.RunThread = null;
                //if (MyCam != null && MyCam.View != null && RunSimple)
                //    MyCam.View.RebuildButton();
                //if (GlobVar.FormMain != null && RunSimple)
                //    GlobVar.FormMain.LockOrUnlockControls();
                //IsRunInThread = false;
                //IsRun = false;
                //DisconnectAllCameraUse();
                //Setting_CloseAllConnection();
                //Setting_CloseKeyboardHook();
                //MyCam?.MyProject?.SetOfflineCam(MyCam);
                //AllPropertyHaveRef = null;
                //AllPropertyParentRef = null;

            }
            catch(Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        public void Setting_StopRunFinal()
        {
            try
            {
             
                Thread.Sleep(300);
                //Setting_StopRun_WriteAfterStop();
                Setting_ResetPropertyValueWhenStop();
                //MyCam.RunThread?.Join(10000);
                //MyCam.RunThread = null;
                if (MyCam != null && MyCam.View != null && RunSimple)
                    MyCam.View.RebuildButton();
                if (GlobVar.FormMain != null && RunSimple)
                    GlobVar.FormMain.LockOrUnlockControls();
                IsRunInThread = false;
                //IsRun = false;
                DisconnectAllCameraUse();

                //Setting_CloseAllConnection();
                Setting_CloseKeyboardHook();
                MyCam?.MyProject?.SetOfflineCam(MyCam);
                AllPropertyHaveRef = null;
                AllPropertyParentRef = null;

            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        private void Setting_CloseKeyboardHook()
        {
            if (Actions.Values.FirstOrDefault(x => (x.ActionType == EActionTypes.HookKeyboard) && x.Enable.rtcValue) != null)
            {
                foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                    if (cam.ID != MyCam.ID && cam.GroupActions.IsRun)
                    {
                        if (cam.GroupActions.Actions.Values.FirstOrDefault(x => (x.ActionType == EActionTypes.HookKeyboard)
                                                                && x.Enable.rtcValue) != null)
                            return;
                    }    
            }
            //cKeyboardHook.
        }
        private void Setting_ResetPropertyValueWhenStop()
        {
            foreach (cAction action in Actions.Values)
                action.ResetPropertyValueWhenStop();
        }
        public async void Setting_StartRun(ERunActionMode runMode,
            bool isForceSnap = false,
            string fileName = "",
            bool isShowMessage = false,
            bool isResetIdRun = true,
            bool isCheckData = true,
            cAction runProgramAction = null)
        {
            var task = new Task(() => Setting_Run(runMode, isForceSnap, fileName, isShowMessage, isResetIdRun, isCheckData, runProgramAction));
            task.Start();
            await task;
            Setting_StopRunFinal();
        }
        /// <summary>
        public async Task Setting_Run(ERunActionMode runMode,
            bool isForceSnap = false,
            string fileName = "",
            bool isShowMessage = false,
            bool isResetIdRun = true,
            bool isCheckData = true,
            cAction runProgramAction = null)
        {
            try
            {
                ErrMessage = string.Empty;
                GlobVar.IsChangeJob = false;
                OrderActionId = Actions.OrderBy(x => x.Value.STT).Select(x => x.Key).ToList();
                ViewResult_CleanData();
                if (runMode == ERunActionMode.CurentAction)
                {
                    if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera && SourceImageSettings.CameraSettings.IsLive)
                    {
                        SetLiveCamera(false);
                        MainAction.InputImage.rtcValue = SnapImage();
                        if (frmHsmartWindow != null)
                            frmHsmartWindow.Image = MainAction.InputImage.rtcValue;
                    }
                    IsSnapSuccess = true;
                    Setting_RunCurrentAction(isShowMessage);
                }
                else
                {
                    if (IsRun)
                        return;
                    if (isCheckData)
                        if (!Setting_Run_CheckData(isShowMessage))
                            return;
                    //if(isThreading)
                    //{
                    //    threadRun = new Thread(() => Setting_Run(runMode, isForceSnap, fileName, isShowMessage, false, isResetIdRun, false))
                    //    {
                    //        IsBackground = true
                    //    };
                    //    threadRun.Start();
                    //    IsRunInThread = true;
                    //    return;
                    //}
                    Setting_PrepareData();
                    if (isResetIdRun)
                        IDRun = 0;

                    IsRun = true;

                    if (MyCam != null && MyCam.View != null && RunSimple)
                        MyCam.View.RebuildButton();
                    if (GlobVar.FormMain != null && RunSimple && (MyCam != null && !MyCam.IsBackground))
                        GlobVar.FormMain.LockOrUnlockControls();
                    Setting_RunAllAliveTools();
                    switch (runMode)
                    {
                        case ERunActionMode.All:
                            {
                                if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera)
                                {
                                    Stopwatch totalTime = new Stopwatch();
                                    totalTime.Start();
                                    SetLiveCamera(false);
                                    Actions[IDMainAction].InputImage.rtcValue = SnapImage_Camera();
                                    Actions[IDMainAction].InputBgrImage.rtcValue = GlobFuncs.BitmapToBgrImage(SnapImage_Camera());
                                    Actions[IDMainAction].InputGrayImage.rtcValue = GlobFuncs.BitmapToGrayImage(SnapImage_Camera());
                                    IsSnapSuccess = Actions[IDMainAction].InputImage.rtcValue != null;
                                    Setting_RunProces(isShowMessage);
                                    totalTime.Stop();
                                    if (IsSnapSuccess)
                                    {
                                        RunCount += 1;
                                        Setting_ViewTotalTime(totalTime.ElapsedMilliseconds, RunCount);
                                    }

                                }
                                else
                                {
                                    SourceImageSettings.ComputerSettings.CurrentImgIndex = -1;
                                    for (int i = 0; i < SourceImageSettings.ComputerSettings.Images.Count; i++)
                                    {
                                        Stopwatch totalTime = new Stopwatch();
                                        totalTime.Start();
                                        IsSnapSuccess = (Setting_Snap(runMode, isForceSnap) != null);
                                        Setting_RunProces(isShowMessage);
                                        totalTime.Stop();
                                        if (IsSnapSuccess)
                                        {
                                            RunCount += 1;
                                            Setting_ViewTotalTime(totalTime.ElapsedMilliseconds, RunCount);
                                        }
                                    }
                                }
                                break;
                            }
                        case ERunActionMode.Endless:
                            {
                                SourceImageSettings.ComputerSettings.CurrentImgIndex = -1;
                                while (IsRun)
                                {
                                    Stopwatch totalTime = new Stopwatch();
                                    totalTime.Start();
                                    IsSnapSuccess = false;
                                    if (SourceImageSettings.Trigger.Trigger())
                                    {
                                        IsSnapSuccess = (Setting_Snap(runMode, isForceSnap) != null);
                                        Setting_RunProces(isShowMessage);
                                        if (GlobVar.IsChangeJob || GlobVar.IsStop)
                                            return;
                                    }
                                    totalTime.Stop();
                                    if (IsSnapSuccess)
                                    {
                                        RunCount += 1;
                                        Setting_ViewTotalTime(totalTime.ElapsedMilliseconds, RunCount);
                                    }
                                }
                                break;
                            }
                        case ERunActionMode.FileName:
                            {
                                if (!File.Exists(fileName))
                                {
                                    ErrMessage = cMessageContent.BuildMessage(
                                        cMessageContent.War_ObjectIsExists,
                                        new string[] { "File : '" + fileName + "'\n" },
                                        new string[] { "Tệp: '" + fileName + "'\n" });
                                    return;
                                }
                                Stopwatch totalTime = new Stopwatch();
                                totalTime.Start();
                                IsSnapSuccess = Actions[IDMainAction].InputImage.rtcValue != null;
                                Setting_RunProces(isShowMessage);
                                totalTime.Stop();
                                if (IsSnapSuccess)
                                {
                                    RunCount += 1;
                                    Setting_ViewTotalTime(totalTime.ElapsedMilliseconds, RunCount);
                                }
                                break;
                            }
                        default:
                            {
                                Stopwatch totalTime = new Stopwatch();
                                totalTime.Start();

                                IsSnapSuccess = (Setting_Snap(runMode, isForceSnap) != null);
                                Setting_RunProces(isShowMessage);
                                totalTime.Stop();
                                if (IsSnapSuccess)
                                {
                                    RunCount += 1;
                                    Setting_ViewTotalTime(totalTime.ElapsedMilliseconds, RunCount);
                                }
                                break;

                            }
                    }

                    IsRun = false;
                }
            }
            catch (Exception ex)
            {
                IsRun = false;
                GlobFuncs.SaveErr(ex);
            }
            finally
            {

                if (!string.IsNullOrEmpty(ErrMessage) && isShowMessage)
                    cMessageBox.Error(ErrMessage);
                if (GlobVar.IsChangeJob || GlobVar.IsStop)
                    IsRun = false;
                if (!IsRun)
                {
                    if (MyCam != null && MyCam.View != null && RunSimple && MyCam.IsActive && !MyCam.IsHide)
                        MyCam.View.RebuildButton();
                    if (GlobVar.FormMain != null && RunSimple && (MyCam != null && !MyCam.IsBackground))
                        GlobVar.FormMain.LockOrUnlockControls();
                    Setting_ResetPropertyValueWhenStop();
                }
                if (runMode != ERunActionMode.Endless && GlobVar.FrmActions != null && !RunSimple)
                    GlobVar.FrmActions.ViewControlWhenStop();
                //if (GlobVar.IsStop)
                //    if (GlobVar.FrmActions != null && !RunSimple)
                //        GlobVar.FormMain.mnuStop.PerformClick();
                if (GlobVar.IsChangeJob)
                {
                    GlobFuncs.ShowWaitForm("Change Job...");
                    Task.Delay(GlobVar.RTCVision.Options.TimeDelayWhenChangeJob).ContinueWith(t => cProjectFunctions.ChangeJob());
                }
                if (runProgramAction != null)
                {
                    runProgramAction.IsRunning.rtcValue = false;
                    runProgramAction.ResultOK.rtcValue = Actions[IDMainAction].ResultOK.rtcValue;

                    runProgramAction.MyGroup.SetValuetoVariableIsParentRef(runProgramAction);
                    if (!runProgramAction.MyGroup.RunSimple &&
                        runProgramAction.ViewInfo != null &&
                        runProgramAction.ViewInfo.GetType() != typeof(ucMainActions))
                        ((ucBaseActionDetail)runProgramAction.ViewInfo).ReviewAllPropertyValueToViewInfo();
                }
            }

        }

        private void Setting_ViewTotalTime(long totalTime, int runCount)
        {
            if(!RunSimple)
            {
                ActionTools mainNode = Actions[IDMainAction].MyNode;
                mainNode.ProcessTime = totalTime.ToString();
                GlobVar.tl.UpdateObject(mainNode);
            }    
            else if (MyCam != null && IsSnapSuccess && MyCam.View != null)
            {
                if (!MyCam.IsHide && MyCam.IsActive && (GlobVar.RTCVision.ViewOptions.IsViewCycleTimeInWindow ||
                    GlobVar.RTCVision.ViewOptions.IsViewRunCountInWindow))
                    if (MyCam.View.lblCycleTime.InvokeRequired)
                    {
                        MyCam.View.lblCycleTime.Invoke((MethodInvoker)delegate
                        {
                            MyCam.View.lblCycleTime.Visible = true;
                            MyCam.View.lblCycleTime.Text = string.Empty;
                            if (GlobVar.RTCVision.ViewOptions.IsViewCycleTimeInWindow)
                                MyCam.View.lblCycleTime.Text = string.Format(cStrings.TotalTime, totalTime);
                            if (GlobVar.RTCVision.ViewOptions.IsViewRunCountInWindow)
                                MyCam.View.lblCycleTime.Text = MyCam.View.lblCycleTime.Text == string.Empty ?
                                "RC : " + runCount.ToString() : MyCam.View.lblCycleTime.Text + " -RC: " + runCount.ToString();
                        });
                    }
                    else
                    {
                        MyCam.View.lblCycleTime.Visible = true;
                        if (GlobVar.RTCVision.ViewOptions.IsViewCycleTimeInWindow)
                            MyCam.View.lblCycleTime.Text = String.Format(cStrings.TotalTime, totalTime);
                        if (GlobVar.RTCVision.ViewOptions.IsViewRunCountInWindow)
                            MyCam.View.lblCycleTime.Text = MyCam.View.lblCycleTime.Text == String.Empty ?
                                "RC : " + runCount.ToString() : MyCam.View.lblCycleTime.Text + " -RC: " + runCount.ToString();
                    } 
            } 
            switch (SourceImageSettings.ImageSourceType)
            {
                case EImageSourceTypes.Computer:
                    int imageIndex = SourceImageSettings.ComputerSettings.CurrentImgIndex;
                    if (SourceImageSettings.ComputerSettings.Images != null &&
                        SourceImageSettings.ComputerSettings.Images.Count > 0 &&
                        imageIndex >= 0 &&
                        imageIndex <= SourceImageSettings.ComputerSettings.Images.Count - 1 &&
                        File.Exists(SourceImageSettings.ComputerSettings.Images[imageIndex].FileName))
                    {
                        SourceImageSettings.ComputerSettings.Images[imageIndex].Ran = true;
                        SourceImageSettings.ComputerSettings.Images[imageIndex].Passed = Passed;
                    }
                    break;
                case EImageSourceTypes.Camera:
                    break;
            }    
        } 
        internal void Setting_CloseAllConnectionInControls()
        {
            try
            {
                foreach (cAction action in Actions.Values)
                {
                    if (action.ActionType == EActionTypes.MainAction && action.ViewInfo != null)
                    {
                        ((ucMainActions)action.ViewInfo).DisconnectCamera();
                    }
                    else if (action.ViewInfo != null)
                        ((ucBaseActionDetail)action.ViewInfo).CloseAllConnectionInControls();
                            
                }    
            }
            catch
            {

            }
        }

        private void Setting_RunProces(bool isShowMessage)
        {
            IDRun += 1;
            cAction runAction, runAction1 = null;
            MainAction.RunCountInProcess = 1;
            SetValuetoVariableIsParentRef(MainAction);
            bool isSetPassFailByTool = false;
            bool isHaveMasterView = false;
            bool lanDau = true;
            IndexBreak = 0;
            
            
            try
            {
                Passed = false; // cờ để nhận ra phiên chụp này trả về kết quả là gì để có thể lưu ảnh lại
                for (int i = 1; i < OrderActionId.Count; i++)
                {
                    IndexBreak = i;
                    runAction = Actions[OrderActionId[i]];
                    runAction.IsRunned = false;
                    runAction.RunCountInProcess = 0;
                    if (!IsRun)
                        break;
                    Run1Action(ref runAction);
                    if(runAction.IsRunned)
                    {
                        if (runAction.ActionType == EActionTypes.DataSet &&
                            runAction.DestinationPort.rtcPropNameRef == nameof(runAction.ResultOK))
                            isSetPassFailByTool = true;
                        if (runAction.ActionType == EActionTypes.PassFail &&
                            runAction.IsMasterResult.rtcValue)
                        {
                            Passed = runAction.Passed.rtcValue;
                            Actions[IDMainAction].ResultOK.rtcValue = Passed;
                            isSetPassFailByTool = true;
                        }
                        if (runAction.ActionType == EActionTypes.ViewResult &&
                            runAction.IsMasterView.rtcValue)
                            isHaveMasterView = true;
                        if (GlobVar.IsChangeJob || GlobVar.IsStop)
                            return;
                        if (this.IsReturn)
                        {
                            bool isContinue = false;
                            if (this.ReturnToolID == IDMainAction)
                                return;
                            for (int j = 0; j < OrderActionId.Count;  j++)
                            {
                                if (OrderActionId[j] == this.ReturnToolID)

                                {
                                    runAction1 = Actions[OrderActionId[j]];
                                    i = runAction1.STT - 1;
                                    runAction1.IsCanRun = runAction1.Enable.rtcValue;
                                    // KIỂM TRA XEM TOOL NÀY CÓ TRỰC THUỘC 1 TOOL ĐIỀU KIỆN NÀO KHÔNG ?
                                    // NẾU THUỘC 1 TOOL, IDBRANCHITEM != Guid.Empty;
                                    if (runAction1.IDBranchItem != Guid.Empty)
                                    {
                                        cAction brandItemAction = this.Actions[runAction1.IDBranchItem];
                                        // Làm lại cờ chạy cho các tool trực thuộc nhánh
                                        brandItemAction.ApplyIsCanRunToAllToolOfBranchItem(brandItemAction, true);
                                        ///
                                    }
                                    isContinue = true;
                                    break;
                                }
                            }
                            if (isContinue)
                                continue;

                        }
                        if (!isSetPassFailByTool)
                        {
                            if (lanDau)
                                Passed = runAction.Passed.rtcValue;
                            else
                                Passed = Passed && runAction.Passed.rtcValue;
                            lanDau = false;
                        }
                        i = IndexBreak;

                    }    
                }    

            }
            finally
            {
                if (!isSetPassFailByTool && (Actions[IDMainAction].ManualAction.rtcValue == cManualAction.Inspection ||
                                             Actions[IDMainAction].ProgramMode.rtcValue == cProgramMode.Auto))
                    Actions[IDMainAction].ResultOK.rtcValue = Passed;
                if (Actions[IDMainAction].ManualAction.rtcValue == cManualAction.Inspection ||
                    Actions[IDMainAction].ManualAction.rtcValue == cManualAction.Capture ||
                    Actions[IDMainAction].ManualAction.rtcValue == cManualAction.Live ||
                    Actions[IDMainAction].ManualAction.rtcValue == cManualAction.StopLive ||
                    Actions[IDMainAction].ManualAction.rtcValue == cManualAction.None ||
                    Actions[IDMainAction].ProgramMode.rtcValue == cProgramMode.Auto)
                {
                    if (IsSnapSuccess && !isHaveMasterView)
                        ViewResult(MyCam.IsViewResult);
                    else ViewResult_CleanData();
                }
                else
                {
                    if (IsSnapSuccess && !isHaveMasterView)
                        ViewResult(false);
                    else
                        ViewResult_CleanData();
                }


            }
        }
        public void Setting_RunAllAliveTools_SLMP()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.SLMPWrite &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        /// <summary>
        /// Run All Connection For ModBus Tool
        /// </summary>
        public void Setting_RunAllAliveTools_ModBus()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.ModBusWrite &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Setting run all alive tools TCP/IP. </summary>
        ///
        /// <remarks>   DATRUONG, 19/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Setting_RunAllAliveTools_TCPIP()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.TCPIPWrite &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        public void Setting_RunAllAliveTools_Udp()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.UpdWrite &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        public void Setting_RunAllAliveTools_POC()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.POCIOWrite &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        public void Setting_RunAllAliveTools_COM()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.COMWriter &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        public void Setting_RunAllAliveTools_AdlinkIO()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.AdlinkIOWriter &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        public void Setting_RunAllAliveTools_CCLinkIE()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.CCLinkIEWriter &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        public void Setting_RunAllAliveTools_IOController()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.IOControllerWrite &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        public void Setting_RunAllAliveTools_MitsuSLMP()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.MitsuSLMPWrite &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        //TODO: EA hàm khởi tạo luồng run alive
        /// <summary>
        /// EasyAlign: Lấy ra các action cần run alive và khởi tạo luồng 
        /// </summary>
        public void Setting_RunAllAliveTools_EasyAlign()
        {
            var aliveActions = Actions.Values.Where(x => x.Enable.rtcValue &&
                                                         x.ActionType == EActionTypes.EasyAlign &&
                                                         x.IsAliveControl.rtcValue).ToList();
            if (aliveActions.Any())
                foreach (var aliveAction in aliveActions)
                {
                    Task task = Task.Factory.StartNew(() => Setting_RunAliveAction(aliveAction));
                }
        }
        public void Setting_RunAliveAction(cAction action)
        {
            if (IsRun)
            {
                if (GlobVar.IsSimulatorMode)
                    return;
                switch (action.ActionType)
                {
                    case EActionTypes.SLMPWrite:
                        {
                            switch (GlobVar.RTCVision.RunOptions.SLMPType)
                            {
                                case 0:
                                    {
                                        SLMPClient MyMCProtocolTCP = null;
                                        if (GlobVar.MyListMCPTCP != null)
                                            MyMCProtocolTCP =
                                                GlobVar.MyListMCPTCP.FirstOrDefault(x =>
                                                    x.IP == action.IPAddress.rtcValue && x.Port == action.PortNumber.rtcValue);

                                        if (MyMCProtocolTCP == null)
                                        {
                                            MyMCProtocolTCP = new SLMPClient(action.IPAddress.rtcValue, action.PortNumber.rtcValue);
                                            MyMCProtocolTCP.Connect();
                                            if (GlobVar.MyListMCPTCP == null) GlobVar.MyListMCPTCP = new List<SLMPClient>();
                                            GlobVar.MyListMCPTCP.Add(MyMCProtocolTCP);
                                        }
                                        else if (!MyMCProtocolTCP.IsConnected)
                                            MyMCProtocolTCP.Connect();

                                        if (!MyMCProtocolTCP.IsConnected)
                                        {
                                            ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                                new string[] { action.Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() },
                                                new string[] { action.Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() });
                                        }

                                        while (IsRun)
                                        {
                                            if (!IsRun) break;
                                            if (!MyMCProtocolTCP.IsConnected) continue;
                                            action.Passed.rtcValue = MyMCProtocolTCP.WriteBitRegister(action.Address.rtcValue, SLMPClient.ObToInt(action.AliveValue));
                                            action.AliveValue = action.AliveValue == 0 ? 1 : 0;
                                            if (!RunSimple && action.ViewInfo != null)
                                                ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                                            Thread.Sleep(action.TimeDelay.rtcValue);
                                        }
                                        break;
                                    }

                                case 1:
                                    {
                                        cSlmpCustom slmpCustom = null;
                                        if (GlobVar.MyListSLMP1 != null)
                                            slmpCustom =
                                                GlobVar.MyListSLMP1.FirstOrDefault(x =>
                                                    x.IPAddress == action.IPAddress.rtcValue && x.Port == action.PortNumber.rtcValue);

                                        if (slmpCustom == null)
                                        {
                                            slmpCustom = new cSlmpCustom(action.IPAddress.rtcValue, action.PortNumber.rtcValue);
                                            if (GlobVar.MyListSLMP1 == null) GlobVar.MyListSLMP1 = new List<cSlmpCustom>();
                                            GlobVar.MyListSLMP1.Add(slmpCustom);
                                        }
                                        else if (!slmpCustom.Connected)
                                            slmpCustom.ConnectSocket();

                                        if (!slmpCustom.Connected)
                                        {
                                            ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                                new string[] { action.Name.rtcValue, slmpCustom.IPAddress, slmpCustom.Port.ToString() },
                                                new string[] { action.Name.rtcValue, slmpCustom.IPAddress, slmpCustom.Port.ToString() });
                                        }

                                        while (IsRun)
                                        {
                                            if (!IsRun) break;
                                            if (!slmpCustom.Connected) continue;
                                            action.Passed.rtcValue = slmpCustom.SendBit(SLMPClient.ObToByte(action.AliveValue), action.Address.rtcValue);
                                            action.AliveValue = action.AliveValue == 0 ? 1 : 0;
                                            if (!RunSimple && action.ViewInfo != null)
                                                ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                                            Thread.Sleep(action.TimeDelay.rtcValue);
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case EActionTypes.ModBusWrite:
                        {
                            cModbusClient modbusClient = null;
                            if (GlobVar.MyListModBusTCP != null)
                                modbusClient =
                                    GlobVar.MyListModBusTCP.FirstOrDefault(x =>
                                        x.IP == action.IPAddress.rtcValue && x.Port == action.PortNumber.rtcValue);

                            if (modbusClient == null)
                            {
                                modbusClient = new cModbusClient(action.IPAddress.rtcValue, action.PortNumber.rtcValue);
                                modbusClient.Connect();
                                if (GlobVar.MyListModBusTCP == null)
                                    GlobVar.MyListModBusTCP = new List<cModbusClient>();
                                GlobVar.MyListModBusTCP.Add(modbusClient);
                            }
                            else if (!modbusClient.IsConnected)
                                modbusClient.Connect();

                            if (!modbusClient.IsConnected)
                            {
                                ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { action.Name.rtcValue, modbusClient.IP, modbusClient.Port.ToString() },
                                    new string[] { action.Name.rtcValue, modbusClient.IP, modbusClient.Port.ToString() });
                            }

                            while (IsRun)
                            {
                                if (!IsRun) break;
                                if (!modbusClient.IsConnected) continue;

                                if (!int.TryParse(action.Address.rtcValue, out int iAddress))
                                    continue;
                                switch (action.ValueTypes.rtcValue)
                                {
                                    case cModBusValueTypes.BooleanFC1:
                                        {
                                            action.Passed.rtcValue = modbusClient.WriteSingleCoil(iAddress, action.AliveValue == 1 ? true : false);
                                            break;
                                        }
                                    case cModBusValueTypes.Integer:
                                        {
                                            action.Passed.rtcValue = modbusClient.WriteSingleRegister(iAddress, action.AliveValue);
                                            break;
                                        }
                                    case cModBusValueTypes.Float:
                                        {
                                            action.Passed.rtcValue = modbusClient.WriteFloatToServer(iAddress, action.AliveValue); ;
                                            break;
                                        }
                                    case cModBusValueTypes.Double:
                                        {
                                            action.Passed.rtcValue =
                                                modbusClient.WriteDoubleToServer(iAddress, action.AliveValue);
                                            ;
                                            break;
                                        }
                                }
                                action.AliveValue = action.AliveValue == 0 ? 1 : 0;
                                if (!RunSimple && action.ViewInfo != null)
                                    ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                                Thread.Sleep(action.TimeDelay.rtcValue);
                            }
                            break;
                        }
                    case EActionTypes.TCPIPWrite:
                        {
                            CSocketClient cSocketClient = null;
                            if (GlobVar.MyListTCPIP != null)
                                cSocketClient =
                                    GlobVar.MyListTCPIP.FirstOrDefault(x =>
                                        x.HostName == action.IPAddress.rtcValue && x.Port == action.PortNumber.rtcValue);

                            if (cSocketClient == null)
                            {
                                cSocketClient = new CSocketClient(action.IPAddress.rtcValue, action.PortNumber.rtcValue, false, null);
                                cSocketClient.Connect();
                                if (GlobVar.MyListTCPIP == null)
                                    GlobVar.MyListTCPIP = new List<CSocketClient>();
                                GlobVar.MyListTCPIP.Add(cSocketClient);
                            }
                            else if (!cSocketClient.IsConnected)
                                cSocketClient.Connect();

                            if (!cSocketClient.IsConnected)
                            {
                                ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { action.Name.rtcValue, cSocketClient.HostName, cSocketClient.Port.ToString() },
                                    new string[] { action.Name.rtcValue, cSocketClient.HostName, cSocketClient.Port.ToString() });
                            }

                            while (IsRun)
                            {
                                if (!IsRun) break;
                                if (!cSocketClient.IsConnected) continue;

                                cSocketClient.SendData(action.AliveValue.ToString());

                                action.AliveValue = action.AliveValue == 0 ? 1 : 0;

                                if (!RunSimple && action.ViewInfo != null)
                                    ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                                Thread.Sleep(action.TimeDelay.rtcValue);
                            }
                            break;
                        }
                    case EActionTypes.UpdWrite:
                        {
                            cUdp myUdp = null;
                            if (GlobVar.MyListUDP != null)
                                myUdp =
                                    GlobVar.MyListUDP.FirstOrDefault(x =>
                                        x.HostName == action.IPAddress.rtcValue && x.Port == action.PortNumber.rtcValue);

                            if (myUdp == null)
                            {
                                myUdp = new cUdp(action.IPAddress.rtcValue, action.PortNumber.rtcValue, action.IsHex.rtcValue);
                                myUdp.StartGetData();
                                if (GlobVar.MyListUDP == null)
                                    GlobVar.MyListUDP = new List<cUdp>();
                                GlobVar.MyListUDP.Add(myUdp);
                            }

                            while (IsRun)
                            {
                                if (!IsRun) break;
                                myUdp.SendData(action.AliveValue.ToString());
                                action.AliveValue = action.AliveValue == 0 ? 1 : 0;
                                if (!RunSimple && action.ViewInfo != null)
                                    ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                                Thread.Sleep(action.TimeDelay.rtcValue);
                            }
                            break;
                        }
                    case EActionTypes.COMWriter:
                        {
                            cCOM com = null;
                            if (GlobVar.MyListCOMReader != null)
                                com =
                                    GlobVar.MyListCOMReader.FirstOrDefault(x =>
                                        x.ComName == action.COMName.rtcValue);
                            if (com == null)
                            {
                                System.IO.Ports.Parity parity = System.IO.Ports.Parity.None;
                                switch (action.Parity.rtcValue)
                                {
                                    case cParity.None:
                                        {
                                            parity = System.IO.Ports.Parity.None;
                                            break;
                                        }
                                    case cParity.Even:
                                        {
                                            parity = System.IO.Ports.Parity.Even;
                                            break;
                                        }
                                    case cParity.Mark:
                                        {
                                            parity = System.IO.Ports.Parity.Mark;
                                            break;
                                        }
                                    case cParity.Odd:
                                        {
                                            parity = System.IO.Ports.Parity.Odd;
                                            break;
                                        }
                                    case cParity.Space:
                                        {
                                            parity = System.IO.Ports.Parity.Space;
                                            break;
                                        }
                                }

                                System.IO.Ports.StopBits stopbits = System.IO.Ports.StopBits.None;
                                switch (action.StopBits.rtcValue)
                                {
                                    case cStopBits.None:
                                        {
                                            stopbits = System.IO.Ports.StopBits.None;
                                            break;
                                        }
                                    case cStopBits.One:
                                        {
                                            stopbits = System.IO.Ports.StopBits.One;
                                            break;
                                        }
                                    case cStopBits.Two:
                                        {
                                            stopbits = System.IO.Ports.StopBits.Two;
                                            break;
                                        }
                                    case cStopBits.OnePointFive:
                                        {
                                            stopbits = System.IO.Ports.StopBits.OnePointFive;
                                            break;
                                        }
                                }

                                com = new cCOM(action.COMName.rtcValue,
                                                int.Parse(action.BaudRate.rtcValue),
                                                int.Parse(action.DataBits.rtcValue),
                                                parity,
                                                stopbits,
                                                action.IsHex.rtcValue);
                                //MyMCProtocolTCP.
                                if (GlobVar.MyListCOMReader == null) GlobVar.MyListCOMReader = new List<cCOM>();
                                GlobVar.MyListCOMReader.Add(com);
                            }
                            else if (!com.IsConnected)
                                com.Connect();

                            if (!com.IsConnected)
                            {
                                ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_COMNameActionCanNotConnect,
                                    new string[] { action.Name.rtcValue, action.COMName.rtcValue },
                                    new string[] { action.Name.rtcValue, action.COMName.rtcValue });
                            }

                            while (IsRun)
                            {
                                if (!IsRun) break;
                                if (!com.IsConnected) continue;

                                com.Write(GlobFuncs.Ve2Str(action.AliveValue == 1
                                    ? action.ReplaceDelemiterStringToSendDataString(action.AliveValueOn.rtcValue)
                                    : action.ReplaceDelemiterStringToSendDataString(action.AliveValueOff.rtcValue)));

                                action.AliveValue = action.AliveValue == 0 ? 1 : 0;

                                if (!RunSimple && action.ViewInfo != null)
                                    ((ucBaseActionDetail)action.ViewInfo).ReviewAllPropertyValueToViewInfo();
                                Thread.Sleep(action.TimeDelay.rtcValue);
                            }
                            break;
                        }
                    case EActionTypes.DetectFileStatus:
                        {
                            break;
                        }
                }
            }
        }
        private void Setting_RunAllAliveTools()
        {
            if (_isHaveAliveSlmp)
                Setting_RunAllAliveTools_SLMP();
            if (_isHaveAliveModbus)
                Setting_RunAllAliveTools_ModBus();
            if (_isHaveAliveTcpIp)
                Setting_RunAllAliveTools_TCPIP();
            if (_isHaveAliveUdp)
                Setting_RunAllAliveTools_Udp();
            if (_isHaveAliveCom)
                Setting_RunAllAliveTools_COM();
            if (_isHaveAliveMitsuSlmp)
                Setting_RunAllAliveTools_MitsuSLMP();
            if (_isHaveAlivePoc)
                Setting_RunAllAliveTools_POC();
            if (_isHaveAliveIo)
                Setting_RunAllAliveTools_IOController();
            if (_isHaveAliveCCLinkIE)
                Setting_RunAllAliveTools_CCLinkIE();
            if (_isHaveAliveAdlinkIO)
                Setting_RunAllAliveTools_AdlinkIO();
            //TODO: EA gọi luồng alive Easy Align
            if (_isHaveAliveEasyAlign)
                Setting_RunAllAliveTools_EasyAlign();
        }

        private void Setting_PrepareData()
        {

            foreach (cAction action in Actions.Values.OrderBy(x => x.STT).ToList())
                action.PrepareBeforeRun();
            UseLog = (GlobVar.FormLogs != null && GlobVar.FormLogs.Visible) ||
                 GlobVar.RTCVision.LogOptions.IsSaveLog;
            #region Have Alive

            _isHaveAliveTcpIp = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.TCPIPWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveCom = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.COMWriter && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveIo = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.IOControllerWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveModbus = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.ModBusWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveMitsuSlmp = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.MitsuSLMPWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveUdp = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.UdpWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAlivePoc = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.POCIOWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveCst = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.CSTLightWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveVst = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.VSTLightWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveSlmp = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.SLMPWrite && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;

            _isHaveAliveCCLinkIE = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.CCLinkIEWriter && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;
            _isHaveAliveAdlinkIO = Actions.Values.FirstOrDefault(x =>
                x.Enable.rtcValue && x.ActionType == EActionTypes.AdlinkIOWriter && x.IsAliveControl != null && x.IsAliveControl.rtcValue) != null;
            //TODO: EA gán giá trị cho biến check alive
            //_isHaveAliveEasyAlign = Actions.Values.FirstOrDefault(x =>
            //    x.Enable.rtcValue && x.ActionType == EActionTypes.EasyAlign && x.CommunicationType.rtcValue == cCommunication_Protocol.MitsuSLMP) != null;
            #endregion
        }

        private bool Setting_Run_CheckData(bool isShowMessage)
        {
            if (Actions.Values.FirstOrDefault(x => x.ActionType == EActionTypes.HookKeyboard && x.Enable.rtcValue) != null)
                return true;
            return true;
                //cKeyBoardHook.Hookkeyboard_Start();
         }
        public void Setting_RunCurrentAction(bool isShowMessage = false)
        {
            cAction action = Actions.Values.FirstOrDefault(x => x.STT == GlobVar.CurrentTool);
            if (action == null) return;
            RunBefore(action, isShowMessage);
            GlobVar.RunningProcess = false;
            //var test = MainAction.InputImage;
            Run1Action(ref action, false, false);
            GlobVar.RunningProcess = true;


        }

        public bool Setting_CheckAllConnection()
        {
            if (GlobVar.IsSimulatorMode)
                return true;
            bool bResult = true;
            switch (GlobVar.RTCVision.RunOptions.SLMPType)
            {
                case 0:
                    {
                        bResult = Setting_CheckAllConnection_SLMP();
                        break;
                    }
                case 1:
                    {
                        bResult = Setting_CheckAllConnection_SLMP();
                        break;
                    }
            }
            if (bResult)
                bResult = Setting_CheckAllConnecttion_ModBus();
            if (bResult)
                bResult = Setting_CheckAllConnection_TCPIP();
            if (bResult)
                bResult = Setting_CheckAllConnection_Udp();
            if (bResult)
                bResult = Setting_CheckAllConnection_COM();
            if (bResult)
                bResult = Setting_CheckAllConnection_CSTLight();
            if (bResult)
                bResult = Setting_CheckAllConnection_VSTLight();
            if (bResult)
                bResult = Setting_CheckAllConnection_FTP();
            return bResult;
        }

        private bool Setting_CheckAllConnection_FTP()
        {
            if (GlobVar.IsSimulatorMode)
                return true;
            var listActions = Actions.Values.Where(x =>
            (x.ActionType == EActionTypes.CSTLightRead || x.ActionType == EActionTypes.CSTLightWrite) &&
            x.Enable.rtcValue && x.IsCanRun).ToList();
            if (listActions.Any())
                foreach (var action in listActions)
                {
                    if (string.IsNullOrEmpty(action.HostName.rtcValue) ||
                        string.IsNullOrEmpty(action.UserName.rtcValue) ||
                        string.IsNullOrEmpty(action.PassWord.rtcValue))
                        continue;
                    cFTP MyFTP = null;
                    if (GlobVar.MyListFPT != null)
                        MyFTP = GlobVar.MyListFPT.FirstOrDefault(x =>
                            x.HostName == action.HostName.rtcValue &&
                            x.UserName == action.UserName.rtcValue &&
                            x.PassWord == action.PassWord.rtcValue );
                    if (MyFTP == null)
                    {
                        MyFTP = new cFTP(action.HostName.rtcValue, action.UserName.rtcValue, action.PassWord.rtcValue);
                        MyFTP.Connect();
                        if (MyFTP.IsConnected)
                        {
                            if (GlobVar.MyListFPT == null) GlobVar.MyListFPT = new List<cFTP>();
                            GlobVar.MyListFPT.Add(MyFTP);
                        }
                    }
                    else if (!MyFTP.IsConnected)
                        MyFTP.Connect();
                    if (MyFTP.IsConnected)
                    {
                        ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_FTPActionCanNotConnect,
                            new string[] { action.Name.rtcValue, MyFTP.HostName, MyFTP.UserName },
                            new string[] { action.Name.rtcValue, MyFTP.HostName, MyFTP.UserName });
                        return false;
                    }
                }
            return true;
        }

        private bool Setting_CheckAllConnection_VSTLight()
        {
            if (GlobVar.IsSimulatorMode)
                return true;
            var listActions = Actions.Values.Where(x =>
            (x.ActionType == EActionTypes.CSTLightRead || x.ActionType == EActionTypes.CSTLightWrite) &&
            x.Enable.rtcValue && x.IsCanRun).ToList();
            if (listActions.Any())
                foreach (var action in listActions)
                {
                    CSTLightClientNew cstLightClient = null;
                    if (GlobVar.MyListModBusTCP != null)
                        cstLightClient = GlobVar.MyListCSTLight.FirstOrDefault(x =>
                        (x.SourceMode == cCSTLightSourceMode.Ethernet && x.IPAddress == action.IPAddress.rtcValue) ||
                        (x.SourceMode == cCSTLightSourceMode.SerialPort && x.SerialPort == action.SerialPort.rtcValue));

                    if (cstLightClient == null)
                    {
                        cstLightClient = new CSTLightClientNew();
                        cstLightClient.SourceMode = action.SourceMode.rtcValue;
                        cstLightClient.SerialPort = action.SerialPort.rtcValue;
                        cstLightClient.IPAddress = action.IPAddress.rtcValue;
                        if (GlobVar.MyListCSTLight == null) GlobVar.MyListCSTLight = new List<CSTLightClientNew>();
                        GlobVar.MyListCSTLight.Add(cstLightClient);
                    }
                    if (!cstLightClient.IsConnected)
                        cstLightClient.Connect();
                    if (!cstLightClient.IsConnected)
                    {
                        ErrMessage = cMessageContent.War_CSTLightOfActionCanNotConnect;
                        return false;
                    }
                }
            return true;
        }
        public Image Setting_Snap(ERunActionMode runMode,
           bool isForceSnap = false,
           string fileName = "",
           bool isBringImageToMain = true,
           bool isFromOtherCam = false)
        {
            Bitmap outputImage = null;
            if (SourceImageSettings.IsEnableSnap || isForceSnap)
            {
                switch (SourceImageSettings.ImageSourceType)
                {
                    case EImageSourceTypes.Computer:
                        {
                            switch (runMode)
                            {
                                case ERunActionMode.All:
                                    SourceImageSettings.ComputerSettings.CurrentImgIndex += 1;
                                    break;
                                case ERunActionMode.Prev:
                                    SourceImageSettings.ComputerSettings.CurrentImgIndex -= 1;
                                    break;
                                case ERunActionMode.Next:
                                    SourceImageSettings.ComputerSettings.CurrentImgIndex += 1;
                                    break;
                                case ERunActionMode.Current:
                                    break;
                                case ERunActionMode.FileName:
                                    {
                                        Image img1 = Image.FromFile(fileName);
                                        Bitmap img = new Bitmap(img1);
                                        Actions[IDMainAction].InputImage.rtcValue = img;
                                        Actions[IDMainAction].InputBgrImage.rtcValue = GlobFuncs.BitmapToBgrImage(img);
                                        Actions[IDMainAction].InputGrayImage.rtcValue = GlobFuncs.BitmapToGrayImage(img);
                                        outputImage = img;
                                        if (!RunSimple)
                                        {
                                            //frmHsmartWindow.Image = Actions[IDMainAction].InputImage.rtcValue;
                                            frmHsmartWindow.FileName = fileName;
                                        }

                                        break;
                                    }
                                case ERunActionMode.Endless:
                                    {
                                        switch (SourceImageSettings.ImageSourceType)
                                        {
                                            case EImageSourceTypes.Computer:
                                                SourceImageSettings.ComputerSettings.CurrentImgIndex += 1;
                                                break;
                                            case EImageSourceTypes.Camera:
                                                Actions[IDMainAction].InputImage.rtcValue = SnapImage_Camera();
                                                outputImage = new Bitmap(Actions[IDMainAction].InputImage.rtcValue);
                                                //frmHsmartWindow.Image = Actions[IDMainAction].InputImage.rtcValue;
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    }
                                case ERunActionMode.CurentAction:
                                    break;
                                default:
                                    break;
                            }
                            if (SourceImageSettings.ComputerSettings.CurrentImgIndex < 0 ||
                                (SourceImageSettings.ComputerSettings.Images != null &&
                                 SourceImageSettings.ComputerSettings.CurrentImgIndex >=
                                 SourceImageSettings.ComputerSettings.Images.Count))
                                SourceImageSettings.ComputerSettings.CurrentImgIndex = 0;
                            if (SourceImageSettings.ComputerSettings.Images != null &&
                                SourceImageSettings.ComputerSettings.Images.Count > 0 &&
                                File.Exists(SourceImageSettings.ComputerSettings
                                    .Images[SourceImageSettings.ComputerSettings.CurrentImgIndex].FileName))
                            {
                                outputImage = new Bitmap(SourceImageSettings.ComputerSettings
                                    .Images[SourceImageSettings.ComputerSettings.CurrentImgIndex].FileName);

                                if (isBringImageToMain && !isFromOtherCam)
                                {
                                    Actions[IDMainAction].InputImage.rtcValue = outputImage;
                                    Actions[IDMainAction].InputBgrImage.rtcValue = GlobFuncs.BitmapToBgrImage(new Bitmap(outputImage));
                                    Actions[IDMainAction].InputGrayImage.rtcValue = GlobFuncs.BitmapToGrayImage(new Bitmap(outputImage));
                                    SetValueToDicRefValue(MainAction, nameof(MainAction.InputImage), MainAction.InputImage.rtcValue);
                                    SetValueToDicRefValue(MainAction, nameof(MainAction.InputGrayImage), MainAction.InputGrayImage.rtcValue);
                                    SetValueToDicRefValue(MainAction, nameof(MainAction.InputBgrImage), MainAction.InputBgrImage.rtcValue);
                                  
                                }
                                if (!RunSimple && !isFromOtherCam)
                                {
                                    frmHsmartWindow.Image = GlobFuncs.CopyImage(outputImage);
                                    //frmHsmartWindow.Image = outputImage;
                                    frmHsmartWindow.FileName = SourceImageSettings.ComputerSettings
                                        .Images[SourceImageSettings.ComputerSettings.CurrentImgIndex].FileName;
                                }
                            }
                            break;
                        }
                    case EImageSourceTypes.Camera:
                        {
                            outputImage = SnapImage_Camera();
                            if (isBringImageToMain && !isFromOtherCam && outputImage != null)
                            {
                                Actions[IDMainAction].InputImage.rtcValue = outputImage;
                                //outputImage.Save(@"D:\2222.bmp");
                                Actions[IDMainAction].InputGrayImage.rtcValue = GlobFuncs.BitmapToGrayImage(new Bitmap(outputImage));
                                Actions[IDMainAction].InputBgrImage.rtcValue = GlobFuncs.BitmapToBgrImage(new Bitmap(outputImage));
                            }
                            if (!RunSimple && !isFromOtherCam)
                                frmHsmartWindow.Image = outputImage;
                            //outputImage.Save(@"D:\2222.bmp");
                            break;
                        }
                }
            }
            else if (Actions[IDMainAction].NoCaptureAndUsingDirectImage.rtcValue)
                outputImage = new Bitmap(Actions[IDMainAction].InputImage.rtcValue);
            //if (outputImage != null)
            //{
            //    using (Bitmap clonedImage = (Bitmap)outputImage.Clone())
            //    {
            //        GlobVar.BGRImage = GlobFuncs.BitmapToBgrImage(clonedImage);
            //        GlobVar.GrayImage = GlobFuncs.BitmapToGrayImage(clonedImage);
            //    }
            //}
            return outputImage;
        }
        private bool Setting_CheckAllConnection_CSTLight()
        {
            if (GlobVar.IsSimulatorMode)
                return true;
            var listActions = Actions.Values.Where(x =>
            (x.ActionType == EActionTypes.CSTLightRead || x.ActionType == EActionTypes.CSTLightWrite) &&
            x.Enable.rtcValue && x.IsCanRun).ToList();
            if (listActions.Any())
                foreach (var action in listActions)
                {
                    CSTLightClientNew cstLightClient = null;
                    if (GlobVar.MyListModBusTCP != null)
                        cstLightClient = GlobVar.MyListCSTLight.FirstOrDefault(x =>
                        (x.SourceMode == cCSTLightSourceMode.Ethernet && x.IPAddress == action.IPAddress.rtcValue) ||
                        (x.SourceMode == cCSTLightSourceMode.SerialPort && x.SerialPort == action.SerialPort.rtcValue));

                    if (cstLightClient == null)
                    {
                        cstLightClient = new CSTLightClientNew();
                        cstLightClient.SourceMode = action.SourceMode.rtcValue;
                        cstLightClient.SerialPort = action.SerialPort.rtcValue;
                        cstLightClient.IPAddress = action.IPAddress.rtcValue;
                        if (GlobVar.MyListCSTLight == null) GlobVar.MyListCSTLight = new List<CSTLightClientNew>();
                        GlobVar.MyListCSTLight.Add(cstLightClient);
                    }
                    if (!cstLightClient.IsConnected)
                        cstLightClient.Connect();
                    if (!cstLightClient.IsConnected)
                    {
                        ErrMessage = cMessageContent.War_CSTLightOfActionCanNotConnect;
                        return false;
                    }    
                }
            return true;
        }

        private bool Setting_CheckAllConnection_COM()
        {
            if (GlobVar.IsSimulatorMode)
                return true;

            var listActions = Actions.Values.Where(x =>
            (x.ActionType == EActionTypes.COMReader || x.ActionType == EActionTypes.COMWriter) &&
            x.Enable.rtcValue).ToList();
            if (listActions.Any())
                foreach (var action in listActions)
                {
                    if (string.IsNullOrEmpty(action.COMName.rtcValue))
                    {
                        ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                            new string[] { "COM port name" },
                            new string[] { " Tên cổng COM" });
                    }
                    cCOM com = null;
                    if (GlobVar.MyListCOMReader != null)
                        com = GlobVar.MyListCOMReader.FirstOrDefault(x =>
                        x.ComName == action.COMName.rtcValue);
                    if (com == null)
                    {
                        System.IO.Ports.Parity parity = System.IO.Ports.Parity.None;
                        switch (action.Parity.rtcValue)
                        {
                            case cParity.None:
                                {
                                    parity = System.IO.Ports.Parity.None;
                                    break;
                                }
                            case cParity.Even:
                                {
                                    parity = System.IO.Ports.Parity.Even;
                                    break;
                                }
                            case cParity.Mark:
                                {
                                    parity = System.IO.Ports.Parity.Mark;
                                    break;
                                }
                            case cParity.Odd:
                                {
                                    parity = System.IO.Ports.Parity.None;
                                    break;
                                }
                            case cParity.Space:
                                {
                                    parity = System.IO.Ports.Parity.Space;
                                    break;
                                }
                        }
                        System.IO.Ports.StopBits stopbits = System.IO.Ports.StopBits.None;
                        switch (action.StopBits.rtcValue)
                        {
                            case cStopBits.None:
                                {
                                    stopbits = System.IO.Ports.StopBits.None;
                                    break;
                                }
                            case cStopBits.One:
                                {
                                    stopbits = System.IO.Ports.StopBits.One;
                                    break;
                                }
                            case cStopBits.Two:
                                {
                                    stopbits = System.IO.Ports.StopBits.Two;
                                    break;
                                }
                            case cStopBits.OnePointFive:
                                {
                                    stopbits = System.IO.Ports.StopBits.OnePointFive;
                                    break;
                                }
                        }
                        com = new cCOM(action.COMName.rtcValue,
                                        int.Parse(action.BaudRate.rtcValue),
                                        int.Parse(action.DataBits.rtcValue),
                                        parity,
                                        stopbits,
                                        action.IsHex.rtcValue);


                        if (GlobVar.MyListCOMReader == null) GlobVar.MyListCOMReader = new List<cCOM>();
                        GlobVar.MyListCOMReader.Add(com);
                    }
                    else if (!com.IsConnected)
                        com.Connect();
                    com.OnReceiveDataEvents -= action.OnCOMReceiveDataEvents;
                    com.OnReceiveDataEvents += action.OnCOMReceiveDataEvents;
                    if (!com.IsConnected)
                    {
                        ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_COMNameActionCanNotConnect,
                                                     new string[] { action.Name.rtcValue, action.COMName.rtcValue },
                                                     new string[] { action.Name.rtcValue, action.COMName.rtcValue });
                        return false;
                    }    
                }
            return true;
        }

        private bool Setting_CheckAllConnection_Udp()
        {
            return true;
        }

        private bool Setting_CheckAllConnection_TCPIP()
        {
            if (GlobVar.IsSimulatorMode)
                return true;
            var listActions = Actions.Values.Where(x =>
            (x.ActionType == EActionTypes.TCPIPRead || x.ActionType == EActionTypes.TCPIPWrite) &&
            x.Enable.rtcValue).ToList();

            if (listActions.Any())
                foreach (var action in listActions)
                {
                    CSocketClient myClient = null;
                    if (GlobVar.MyListTCPIP != null)
                    {
                        if (action.IsServer.rtcValue)
                            myClient =
                           GlobVar.MyListTCPIP.FirstOrDefault(x =>
                               x.Port == action.PortNumber.rtcValue && x.IsServer);
                        else
                            myClient =
                                GlobVar.MyListTCPIP.FirstOrDefault(x =>
                                x.HostName == action.IPAddress.rtcValue && x.Port == action.PortNumber.rtcValue && !x.IsServer);
                    }

                    if (myClient == null)
                    {
                        myClient = new CSocketClient(action.IPAddress.rtcValue, action.PortNumber.rtcValue, false, null, ProtocolType.Tcp, action.IsServer.rtcValue, false);
                        myClient.Connect();
                    
                        if (GlobVar.MyListTCPIP == null) GlobVar.MyListTCPIP = new List<CSocketClient>();
                        GlobVar.MyListTCPIP.Add(myClient);
                    }

                    else if (!myClient.IsConnected)
                    {
                        myClient.Connect();
                       
                    }
                    myClient.OnReceiveDataEvents -= action.OnReceiveDataEvents;
                    myClient.OnReceiveDataEvents += action.OnReceiveDataEvents;
                    if (!action.IsServer.rtcValue && !myClient.IsConnected &&
                        GlobVar.RTCVision.RunOptions.NumberOfTimesTryReconnect >= 1)
                    {
                        for (int i = 0; i < GlobVar.RTCVision.RunOptions.NumberOfTimesTryReconnect; i++)
                        {
                            GlobFuncs.ExecuteCommand($"ping {action.IPAddress.rtcValue}");
                            myClient.Connect();
                            if (myClient.IsConnected)
                                break;
                        }
                    }
                    if (!myClient.IsConnected)
                    {
                        ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_SLMPCanNotConnect,
                            new string[] { action.Name.rtcValue, myClient.HostName, myClient.Port.ToString() }, new string[] { action.Name.rtcValue, myClient.HostName, myClient.Port.ToString() });
                        return false;
                    }
                }
            return true;
        }

        private bool Setting_CheckAllConnecttion_ModBus()
        {
            if (GlobVar.IsSimulatorMode)
                return true;
            var listActions = Actions.Values.Where(x =>
            (x.ActionType == EActionTypes.ModBusRead || x.ActionType == EActionTypes.ModBusWrite) &&
            x.Enable.rtcValue).ToList();

            if (listActions.Any())
                foreach (var action in listActions)
                {
                    cModbusClient modbusClient = null;
                    if (GlobVar.MyListModBusTCP != null)
                        modbusClient = 
                            GlobVar.MyListModBusTCP.FirstOrDefault(x =>
                                x.IP == action.IPAddress.rtcValue && x.Port == action.PortNumber.rtcValue);
                    if (modbusClient == null)
                    {
                        modbusClient = new cModbusClient(action.IPAddress.rtcValue, action.PortNumber.rtcValue);
                        modbusClient.Connect();
                        if (GlobVar.MyListModBusTCP == null) GlobVar.MyListModBusTCP = new List<cModbusClient>();
                        GlobVar.MyListModBusTCP.Add(modbusClient);
                    }

                    else if (!modbusClient.IsConnected)
                        modbusClient.Connect();

                    if (!modbusClient.IsConnected &&
                        GlobVar.RTCVision.RunOptions.NumberOfTimesTryReconnect >= 1)
                    {
                        for (int i = 0; i < GlobVar.RTCVision.RunOptions.NumberOfTimesTryReconnect; i++)
                        {
                            GlobFuncs.ExecuteCommand($"ping {action.IPAddress.rtcValue}");
                            modbusClient.Connect();
                            if (modbusClient.IsConnected)
                                break;
                        }
                    }
                    if (!modbusClient.IsConnected)
                    {
                        ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                            new string[] { action.Name.rtcValue, modbusClient.IP, modbusClient.Port.ToString() }, new string[] { action.Name.rtcValue, modbusClient.IP, modbusClient.Port.ToString() });
                        return false;
                    }
                }
            return true;
        }

        private bool Setting_CheckAllConnection_SLMP()
        {
            if (GlobVar.IsSimulatorMode)
                return true;
            var listActions = Actions.Values.Where(x =>
            (x.ActionType == EActionTypes.SLMPRead || x.ActionType == EActionTypes.SLMPWrite) &&
            x.Enable.rtcValue && x.IsCanRun).ToList();

            if (listActions.Any())
                foreach (var action in listActions)
                {
                    SLMPClient slmpClient = null;
                    if (GlobVar.MyListCOMReader != null)
                        slmpClient = GlobVar.MyListMCPTCP.FirstOrDefault(x =>
                        x.IP == action.IPAddress.rtcValue && x.Port == action.PortNumber.rtcValue);
                    if (slmpClient == null)
                    {
                        slmpClient = new SLMPClient(action.IPAddress.rtcValue, action.PortNumber.rtcValue);
                        slmpClient.Connect();
                        if (GlobVar.MyListMCPTCP == null) GlobVar.MyListMCPTCP = new List<SLMPClient>();
                        GlobVar.MyListMCPTCP.Add(slmpClient);
                    }
                    else if (!slmpClient.IsConnected)
                        slmpClient.Connect();
                    if (!slmpClient.IsConnected &&
                        GlobVar.RTCVision.RunOptions.NumberOfTimesTryReconnect >= 1)
                    {
                        for (int i = 0; i < GlobVar.RTCVision.RunOptions.NumberOfTimesTryReconnect; i++)
                        {
                            GlobFuncs.ExecuteCommand($"ping {action.IPAddress.rtcValue}");
                            slmpClient.Connect();
                            if (slmpClient.IsConnected)
                                break;
                        }    
                    }  
                    if (!slmpClient.IsConnected)
                    {
                        ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_SLMPCanNotConnect,
                            new string[] { action.Name.rtcValue, slmpClient.IP, slmpClient.Port.ToString() }, new string[] { action.Name.rtcValue, slmpClient.IP, slmpClient.Port.ToString() });
                        return false;
                    }    
                }
            return true;
        }

        //public bool Setting_Run_CheckData(bool isShowMessage = false)
        //{
        //    if(Actions.Values.FirstOrDefault(x => x.ActionType == EActionTypes.HookKeybroad && x.Enable.rtcValue) != null)
        //        cKey
        //}
    }
}
