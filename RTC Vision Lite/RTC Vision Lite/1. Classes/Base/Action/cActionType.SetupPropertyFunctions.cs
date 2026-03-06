using NLog.Filters;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void SetupPropertyByActionType(EActionTypes eActionTypes, EObjectTypes eObjectTypes)
        {
            switch (eActionTypes)
            {
                case EActionTypes.MainAction:
                    SetupPropertyByMainAction();
                    break;
                case EActionTypes.Blob:
                    SetupPropertyByBlob();
                    break;
                case EActionTypes.Pattern:
                    SetupPropertyByPattern();
                    break;
                case EActionTypes.BlobFilter:
                    SetupPropertyByBlobFiler();
                    break;
                case EActionTypes.BlobMultipleROI:
                    SetupPropertyByBlobMultipleROI();
                    break;
                case EActionTypes.BranchItem:
                    SetupPropertyByBranchItem();
                    break;
                case EActionTypes.Branch:
                    SetupPropertyByBranch();
                    break;
                case EActionTypes.PixelCount:
                    SetUpPropertyByPixelCount();
                    break;
                case EActionTypes.Brightness:
                    SetUpPropertyByBrightness();
                    break;
                case EActionTypes.LineFind:
                    SetupPropertyByLineFind();
                    break;
                case EActionTypes.ColorBlob:
                    SetupPropertyByColorBlob();
                    break;
                case EActionTypes.DistanceMeasurement:
                    SetupPropertyByDistanceMeasurement();
                    break;
                case EActionTypes.ImageFilter:
                    SetUpPropertyByImageFilter();
                    break;
                case EActionTypes.TCPIPWrite:
                    SetupPropertyByTCPIPWrite();
                    break;
                case EActionTypes.COMReader:
                    SetupPropertyByCOMReader();
                    break;
                case EActionTypes.COMWriter:
                    SetupPropertyByCOMWriter();
                    break;
                case EActionTypes.CSTLightRead:
                    SetupPropertyByCSTLightRead();
                    break;
                case EActionTypes.CSTLightWrite:
                    SetupPropertyByCSTLightWrite();
                    break;
                case EActionTypes.TCPIPRead:
                    SetupPropertyByTCPIPRead();
                    break;
                case EActionTypes.SLMPRead:
                    SetupPropertyBySLMPRead();
                    break;
                case EActionTypes.SLMPWrite:
                    SetupPropertyBySLMPWrite();
                    break;
                case EActionTypes.Switch:
                    SetupPropertyBySwitch();
                    break;
                case EActionTypes.Math:
                    SetupPropertyByMath();
                    break;
                case EActionTypes.PassFail:
                    SetupPropertyByPassFail();
                    break;
                case EActionTypes.CounterLoop:
                    SetupPropertyByCounterLoop();
                    break;
                case EActionTypes.Return:
                    SetupPropertyByReturn();
                    break;
                case EActionTypes.ResetTool:
                    SetupPropertyByResetTool();
                    break;
                case EActionTypes.RegionProcessing:
                    SetupPropertyByRegionProcessing();
                    break;
                case EActionTypes.ColorBlobMultipleROI:
                    SetupPropertyByColorBlobMultipleROI();
                    break;
                case EActionTypes.Origin:
                    SetupPropertyByOrigin();
                    break;
                case EActionTypes.SnapImage:
                    SetupPropertyBySnapImage();
                    break;
                case EActionTypes.StopLiveCam:
                    SetupPropertyByStopLiveCam();
                    break;
                case EActionTypes.DataSet:
                    SetupPropertyByDataSet();
                    break;
                case EActionTypes.DataInstance:
                    SetupPropertyByDataInstance();
                    break;
                case EActionTypes.SaveImage:
                    SetupPropertyBySaveImage();
                    break;
                case EActionTypes.LoadImage:
                    SetupPropertyByLoadImage();
                    break;
                case EActionTypes.CsvWrite:
                    SetupPropertyByCsvWrite();
                    break;
                case EActionTypes.ExcelWrite:
                    SetupPropertyByExcelWrite();
                    break;
                case EActionTypes.RunProgram:
                    SetupPropertyByRunProgram();
                    break;
                case EActionTypes.LinkValue:
                    SetupPropertyByLinkValue();
                    break;
                case EActionTypes.ChangeJob:
                    SetupPropertyByChangeJob();
                    break;
                case EActionTypes.MXComponentRead:
                    SetupPropertyByMXComponentRead();
                    break;
                case EActionTypes.MXComponentWrite:
                    SetupPropertyByMXComponentWrite();
                    break;
                case EActionTypes.StringBuilder:
                    SetupPropertyByStringBuilder();
                    break;
                case EActionTypes.ClearWindows:
                    SetupPropertyByClearWindow();
                    break;
                case EActionTypes.CycleTimeStart:
                    SetupPropertyByCycleTimeStart();
                    break;
                case EActionTypes.CycleTimeStop:
                    SetupPropertyByCycleTimeStop();
                    break;
                case EActionTypes.DetectFileStatus:
                    SetupPropertyByDetectFileStatus();
                    break;
                case EActionTypes.RunCommand:
                    SetupPropertyByRunCommand();
                    break;
                case EActionTypes.ImageSplit:
                    SetupPropertyByImageSplit();
                    break;
                case EActionTypes.OkNgCounter:
                    SetupPropertyByOkNgCounter();
                    break;
                case EActionTypes.SendMessage:
                    SetupPropertyBySendMessage();
                    break;
                case EActionTypes.SaveProject:
                    SetupPropertyBySaveProject();
                    break;
                case EActionTypes.DialogMessage:
                    SetupPropertyByDialogMessage();
                    break;
                case EActionTypes.SystemInfo:
                    SetupPropertyBySystemInfo();
                    break;
                case EActionTypes.HookKeyboard:
                    SetupPropertyByHookKeyboard();
                    break;
                case EActionTypes.Wait:
                    SetupPropertyByWait();
                    break;
                case EActionTypes.Stop:
                    SetupPropertyByStop();
                    break;
                case EActionTypes.LoadConfig:
                    SetupPropertyByLoadConfig();
                    break;
                case EActionTypes.SaveConfig:
                    SetupPropertyBySaveConfig();
                    break;
                case EActionTypes.Count:
                    SetupPropertyByCount();
                    break;
                case EActionTypes.Script:
                    SetupPropertyByScript();
                    break;
                case EActionTypes.SaveObject:
                    SetupPropertyBySaveObject();
                    break;
                case EActionTypes.LiveCam:
                    SetupPropertyByLiveCamera();
                    break;
                case EActionTypes.ImageMath:
                    SetupPropertyByImageMath();
                    break;
                case EActionTypes.CodeReader:
                    SetupPropertyByCodeReader();
                    break;
                case EActionTypes.IOControllerRead:
                    SetupPropertyByIOControllerReader();
                    break;
                case EActionTypes.IOControllerWrite:
                    SetupPropertyByIOControllerWriter();
                    break;
                case EActionTypes.POCIORead:
                    SetupPropertyByPOCIORead();
                    break;
                case EActionTypes.POCIOWrite:
                    SetupPropertyByPOCIOWrite();
                    break;
                case EActionTypes.AffineImage:
                    SetupPropertyByAffineImage();
                    break;
                default:
                    break;
            }
        }
        public void SetupPropertyByResetTool()
        {
            ListResetTools = new List<cLinkPassFail>();
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false);
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
        }
        public void SetupPropertyByStopLiveCam()
        {
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcValue = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }    
        private void SetupPropertyByPassFail()
        {
            LinkPassFail = new List<cLinkPassFail>();

            PassCriteria = new SString(CommonData.GetPropertyDescription(nameof(PassCriteria)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);

            IsMasterResult = new SBool(CommonData.GetPropertyDescription(nameof(IsMasterResult)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            //IsReturnValueToTool = new SBool(CommonData.GetPropertyDescription(nameof(IsReturnValueToTool)),
            //EHTupleStyle.None,
            //EPropertyState.Input,
            //EROILegend.None,
            //false);

            PassCriteria.rtcValue = CommonData.GetDefaultValues_Text(nameof(PassCriteria) + _SuffixName);
            //IsReturnValueToTool.rtcHidden = false;
            DisplayOutput.rtcHidden = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
        }
        private void SetupPropertyByCounterLoop()
        {

            Count = new SInt(CommonData.GetPropertyDescription(nameof(Count)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            StartNumber = new SInt(CommonData.GetPropertyDescription(nameof(StartNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            Step = new SInt(CommonData.GetPropertyDescription(nameof(Step)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            CurrentCount = new SInt(CommonData.GetPropertyDescription(nameof(CurrentCount)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false);

            Count.rtcValue = 0;
            StartNumber.rtcValue = 0;
            Step.rtcValue = 1;
            CurrentCount.rtcValue = 0;
            Passed.rtcValue = false;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;

        }
        private void SetupPropertyBySwitch()
        {
            Expression = new SString(CommonData.GetPropertyDescription(nameof(Expression)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);

            CalculateMode = new SString(CommonData.GetPropertyDescription(nameof(CalculateMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            Result = new SListObject(CommonData.GetPropertyDescription(nameof(Result)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            true);
            CalculateMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(CalculateMode) + _SuffixName);
            Result.rtcValue = new List<object>();
            Expression.rtcValue = CommonData.GetDefaultValues_Text(nameof(Expression) + _SuffixName);
            DisplayOutput.rtcHidden = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunExpression();
        }

        public void SetupPropertyBySLMPWrite()
        {
            IPAddress = new SString(CommonData.GetPropertyDescription(nameof(IPAddress)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PortNumber = new SInt(CommonData.GetPropertyDescription(nameof(PortNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ValueTypes = new SString(CommonData.GetPropertyDescription(nameof(ValueTypes)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            WaitMode = new SString(CommonData.GetPropertyDescription(nameof(WaitMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            BitMode = new SString(CommonData.GetPropertyDescription(nameof(BitMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ValueAfterDelay = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterDelay)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ValueAfterStop = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterStop)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsAliveControl = new SBool(CommonData.GetPropertyDescription(nameof(IsAliveControl)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);

            IPAddress.rtcValue = cStrings.IPAddressDefault;
            PortNumber.rtcValue = 3000;
            TimeDelay.rtcValue = 0;
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            IsCompareValue.rtcValue = false;
            IsAliveControl.rtcValue = false;
            ValueTypes.rtcValue = CommonData.GetDefaultValues_Text(nameof(ValueTypes) + _SuffixName);
            WaitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WaitMode) + _SuffixName);
            BitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(BitMode) + _SuffixName);

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
            GroupType = EGroupTypes.Communication;
        }

        public void SetupPropertyBySLMPRead()
        {
            IPAddress = new SString(CommonData.GetPropertyDescription(nameof(IPAddress)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PortNumber = new SInt(CommonData.GetPropertyDescription(nameof(PortNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ValueTypes = new SString(CommonData.GetPropertyDescription(nameof(ValueTypes)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ValueTypesConvert = new SString(CommonData.GetPropertyDescription(nameof(ValueTypesConvert)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ValueLength = new SInt(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            IsUseValueTypesConvert = new SBool(CommonData.GetPropertyDescription(nameof(IsUseValueTypesConvert)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            IPAddress.rtcValue = cStrings.IPAddressDefault;
            PortNumber.rtcValue = 3000;
            ValueLength.rtcValue = 1;
            IsCompareValue.rtcValue = false;
            IsUseValueTypesConvert.rtcValue = false;
            ValueTypes.rtcValue = CommonData.GetDefaultValues_Text(nameof(ValueTypes) + _SuffixName);
            ValueTypesConvert.rtcValue = CommonData.GetDefaultValues_Text(nameof(ValueTypesConvert) + _SuffixName);

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
            GroupType = EGroupTypes.Communication;
        }

        public void SetupPropertyByMainAction()
        {
            IFileName = new SString(cDescriptionVar.IFileName, EHTupleStyle.None, EPropertyState.Input);
            IFileName.rtcActive = true;
            IFileName.rtcSystem = true;

            InputImage = new SImage(cDescriptionVar.InputImage, EHTupleStyle.None, EPropertyState.Input);
            InputImage.rtcActive = true;
            InputImage.rtcSystem = true;
            InputImage.rtcResetWhenStop = true;
            InputGrayImage = new SGrayImage(cDescriptionVar.InputImage, EHTupleStyle.None, EPropertyState.Input);
            InputImage.rtcActive = true;
            InputImage.rtcSystem = true;
            InputImage.rtcResetWhenStop = true;
            InputBgrImage = new SBgrImage(cDescriptionVar.InputImage, EHTupleStyle.None, EPropertyState.Input);
            InputImage.rtcActive = true;
            InputImage.rtcSystem = true;
            InputImage.rtcResetWhenStop = true;
            ProgramMode = new SString(CommonData.GetPropertyDescription(nameof(ProgramMode)), EHTupleStyle.None, EPropertyState.Input);
            ManualAction = new SString(CommonData.GetPropertyDescription(nameof(ManualAction)), EHTupleStyle.None, EPropertyState.Input);
            ResultOK = new SBool(CommonData.GetPropertyDescription(nameof(ResultOK)), EHTupleStyle.None, EPropertyState.Input);
            IsHaveWarning = new SBool(CommonData.GetPropertyDescription(nameof(IsHaveWarning)),
                         EHTupleStyle.None,
                         EPropertyState.Input);
            IsHaveError = new SBool(CommonData.GetPropertyDescription(nameof(IsHaveError)),
                            EHTupleStyle.None,
                            EPropertyState.Input);
            IsHaveError = new SBool(CommonData.GetPropertyDescription(nameof(IsHaveError)),
                              EHTupleStyle.None,
                              EPropertyState.Input);
            CamName = new SString(CommonData.GetPropertyDescription(nameof(CamName)),
                          EHTupleStyle.None,
                          EPropertyState.Input);
            TriggerValue =new SString(CommonData.GetPropertyDescription(nameof(TriggerValue)),
                          EHTupleStyle.None,
                          EPropertyState.Input);
            NoCaptureAndUsingDirectImage = new SBool(CommonData.GetPropertyDescription(nameof(NoCaptureAndUsingDirectImage)),
                          EHTupleStyle.None,
                          EPropertyState.Input);
            MasterImageFile = new SString(CommonData.GetPropertyDescription(nameof(MasterImageFile)),
                          EHTupleStyle.None,
                          EPropertyState.Input);
            OkCount = new SInt(CommonData.GetPropertyDescription(nameof(OkCount)),
                EHTupleStyle.None,
                EPropertyState.Output);
            NgCount = new SInt(CommonData.GetPropertyDescription(nameof(NgCount)),
                EHTupleStyle.None,
                EPropertyState.Output);
            TotalCount = new SInt(CommonData.GetPropertyDescription(nameof(TotalCount)),
                EHTupleStyle.None,
                EPropertyState.Output);
            ModelOkCount = new SInt(CommonData.GetPropertyDescription(nameof(ModelOkCount)),
                EHTupleStyle.None,
                EPropertyState.Output);
            ModelNgCount = new SInt(CommonData.GetPropertyDescription(nameof(ModelNgCount)),
                EHTupleStyle.None,
                EPropertyState.Output);
            ModelTotalCount = new SInt(CommonData.GetPropertyDescription(nameof(ModelTotalCount)),
                EHTupleStyle.None,
                EPropertyState.Output);

            OkCount.rtcValue = NgCount.rtcValue = TotalCount.rtcValue = ModelOkCount.rtcValue = ModelNgCount.rtcValue = ModelTotalCount.rtcValue = 0;

            IsHaveWarning.rtcValue = false;
            IsHaveError.rtcValue = false;
            NoCaptureAndUsingDirectImage.rtcValue = false;
            ProgramMode.rtcValue = cProgramMode.Auto;
            ManualAction.rtcValue = cManualAction.None;
            ResultOK.rtcValue = false;
            CamName.rtcValue = string.Empty;
            MasterImageFile.rtcActive = true;
            IFileName.rtcSystem = true;
            InputImage.rtcResetWhenStop = true;
            ROIs = new Dictionary<long, object>();



            
        }
        public void SetupPropertyByCOMWriter()
        {
            COMName = new SString(CommonData.GetPropertyDescription(nameof(COMName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            Parity = new SString(CommonData.GetPropertyDescription(nameof(Parity)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            BaudRate = new SString(CommonData.GetPropertyDescription(nameof(BaudRate)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            StopBits = new SString(CommonData.GetPropertyDescription(nameof(StopBits)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DataBits = new SString(CommonData.GetPropertyDescription(nameof(DataBits)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            WaitMode = new SString(CommonData.GetPropertyDescription(nameof(WaitMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ValueAfterDelay = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterDelay)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ValueAfterStop = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterStop)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsAliveControl = new SBool(CommonData.GetPropertyDescription(nameof(IsAliveControl)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false);
            IsHex = new SBool(CommonData.GetPropertyDescription(nameof(IsHex)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AliveValueOn = new SString(CommonData.GetPropertyDescription(nameof(AliveValueOn)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AliveValueOff = new SString(CommonData.GetPropertyDescription(nameof(AliveValueOff)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AliveValueOn.rtcValue = "1";
            AliveValueOff.rtcValue = "0";
            COMName.rtcValue = string.Empty;
            Parity.rtcValue = CommonData.GetDefaultValues_Text(nameof(Parity) + _SuffixName);
            DataBits.rtcValue = CommonData.GetDefaultValues_Text(nameof(DataBits) + _SuffixName);
            StopBits.rtcValue = CommonData.GetDefaultValues_Text(nameof(StopBits) + _SuffixName);
            BaudRate.rtcValue = CommonData.GetDefaultValues_Text(nameof(BaudRate) + _SuffixName);
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            IsCompareValue.rtcValue = false;
            IsAliveControl.rtcValue = false;
            IsHex.rtcValue = false;
            WaitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WaitMode) + _SuffixName);
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByCSTLightRead()
        {
            IPAddress = new SString(CommonData.GetPropertyDescription(nameof(IPAddress)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SerialPort = new SString(CommonData.GetPropertyDescription(nameof(SerialPort)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SourceType = new SString(CommonData.GetPropertyDescription(nameof(SourceType)),
            EHTupleStyle.None,
            EPropertyState.Input);
            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SourceMode = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SourceModePort = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
                EHTupleStyle.None,
                 EPropertyState.Input);
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
            EHTupleStyle.None,
            EPropertyState.Input);
            WaitMode = new SString(CommonData.GetPropertyDescription(nameof(WaitMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Output);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input);

            IPAddress.rtcValue = cStrings.IPAddressDefault;
            SourceType.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceType) + _SuffixName);
            WaitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WaitMode) + _SuffixName);
            SourceMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceMode) + _SuffixName);
            SourceModePort.rtcHidden = true;
            IsCompareValue.rtcValue = false;

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
        }

        public void SetupPropertyByCSTLightWrite()
        {
            IPAddress = new SString(CommonData.GetPropertyDescription(nameof(IPAddress)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SerialPort = new SString(CommonData.GetPropertyDescription(nameof(SerialPort)),
            EHTupleStyle.None,
            EPropertyState.Input);
            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SourceMode = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SourceModePort = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
            EHTupleStyle.None,
             EPropertyState.Input);
            SourceType = new SString(CommonData.GetPropertyDescription(nameof(SourceType)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
            EHTupleStyle.None,
            EPropertyState.Input);
            WaitMode = new SString(CommonData.GetPropertyDescription(nameof(WaitMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Input);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ValueAfterDelay = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterDelay)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ValueAfterStop = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterStop)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Output);

            IPAddress.rtcValue = cStrings.IPAddressDefault;
            WaitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WaitMode) + _SuffixName);
            SourceMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceMode) + _SuffixName);
            SourceType.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceType) + _SuffixName);
            IsCompareValue.rtcValue = false;
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
            SourceModePort.rtcHidden = true;
        }
        public void SetupPropertyByCOMReader()
        {
            COMName = new SString(CommonData.GetPropertyDescription(nameof(COMName)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);

            Parity = new SString(CommonData.GetPropertyDescription(nameof(Parity)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);

            BaudRate = new SString(CommonData.GetPropertyDescription(nameof(BaudRate)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);

            StopBits = new SString(CommonData.GetPropertyDescription(nameof(StopBits)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            DataBits = new SString(CommonData.GetPropertyDescription(nameof(DataBits)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);

            IsUseValueTypesConvert = new SBool(CommonData.GetPropertyDescription(nameof(IsUseValueTypesConvert)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsHex = new SBool(CommonData.GetPropertyDescription(nameof(IsHex)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ValueTypesConvert = new SString(CommonData.GetPropertyDescription(nameof(ValueTypesConvert)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Value.rtcResetWhenStart = true;
            COMName.rtcValue = string.Empty;
            Parity.rtcValue = CommonData.GetDefaultValues_Text(nameof(Parity) + _SuffixName);
            DataBits.rtcValue = CommonData.GetDefaultValues_Text(nameof(DataBits) + _SuffixName);
            StopBits.rtcValue = CommonData.GetDefaultValues_Text(nameof(StopBits) + _SuffixName);
            BaudRate.rtcValue = CommonData.GetDefaultValues_Text(nameof(BaudRate) + _SuffixName);
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        /// <summary>
        /// Hàm tổng khởi tạo tool
        /// </summary>
        /// <param name="eActionTypes"> Loại tool. </param>
        /// <param name="eObjectTypes"> Kiểu tool. </param>
        public void SetupPropertyByTCPIPWrite()
        {
            IPAddress = new SString(CommonData.GetPropertyDescription(nameof(IPAddress)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            PortNumber = new SInt(CommonData.GetPropertyDescription(nameof(PortNumber)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            WaitMode = new SString(CommonData.GetPropertyDescription(nameof(WaitMode)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ValueAfterDelay = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterDelay)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ValueAfterStop = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterStop)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsAliveControl = new SBool(CommonData.GetPropertyDescription(nameof(IsAliveControl)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false);
            IsHex = new SBool(CommonData.GetPropertyDescription(nameof(IsHex)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsServer = new SBool(CommonData.GetPropertyDescription(nameof(IsServer)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            SendTimeOut = new SInt(CommonData.GetPropertyDescription(nameof(SendTimeOut)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsSendOriginalValue = new SBool(CommonData.GetPropertyDescription(nameof(IsSendOriginalValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            //AliveValueOn = new SString(CommonData.GetPropertyDescription(nameof(AliveValueOn)),
            //    EHTupleStyle.None,
            //    EPropertyState.Input,
            //    EROILegend.None,
            //    false,
            //    false,
            //    false,
            //    false);
            //AliveValueOff = new SString(CommonData.GetPropertyDescription(nameof(AliveValueOff)),
            //    EHTupleStyle.None,
            //    EPropertyState.Input,
            //    EROILegend.None,
            //    false,
            //    false,
            //    false,
            //    false);
            //AliveValueOn.rtcValue = "1";
            //AliveValueOff.rtcValue = "0";
            IsSendOriginalValue.rtcValue = true;
            IPAddress.rtcValue = cStrings.IPAddressDefault;
            PortNumber.rtcValue = 3000;
            SendTimeOut.rtcValue = 10000;
            TimeDelay.rtcValue = 0;
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            IsCompareValue.rtcValue = false;
            IsAliveControl.rtcValue = false;
            IsHex.rtcValue = false;
            IsServer.rtcValue = false;
            WaitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WaitMode) + _SuffixName);

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
            GroupType = EGroupTypes.Communication;
        }
        public void SetupPropertyByTCPIPRead()
        {
            IPAddress = new SString(CommonData.GetPropertyDescription(nameof(IPAddress)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            PortNumber = new SInt(CommonData.GetPropertyDescription(nameof(PortNumber)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ValueTypesConvert = new SString(CommonData.GetPropertyDescription(nameof(ValueTypesConvert)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ValueLength = new SInt(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ReceiveTimeOut = new SInt(CommonData.GetPropertyDescription(nameof(ReceiveTimeOut)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);

            IsUseValueTypesConvert = new SBool(CommonData.GetPropertyDescription(nameof(IsUseValueTypesConvert)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsHex = new SBool(CommonData.GetPropertyDescription(nameof(IsHex)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsServer = new SBool(CommonData.GetPropertyDescription(nameof(IsServer)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);

            Value.rtcResetWhenStart = true;
            IPAddress.rtcValue = cStrings.IPAddressDefault;
            PortNumber.rtcValue = 3000;
            ReceiveTimeOut.rtcValue = 10000;
            ValueLength.rtcValue = 1;
            IsHex.rtcValue = false;
            IsServer.rtcValue = false;
            IsCompareValue.rtcValue = false;
            IsUseValueTypesConvert.rtcValue = false;
            ValueTypesConvert.rtcValue = CommonData.GetDefaultValues_Text(nameof(ValueTypesConvert) + _SuffixName);

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
            GroupType = EGroupTypes.Communication;
        }

        public void SetupPropertyByUDPRead()
        {
            IPAddress = new SString(CommonData.GetPropertyDescription(nameof(IPAddress)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            PortNumber = new SInt(CommonData.GetPropertyDescription(nameof(PortNumber)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ValueTypesConvert = new SString(CommonData.GetPropertyDescription(nameof(ValueTypesConvert)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ValueLength = new SInt(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ReceiveTimeOut = new SInt(CommonData.GetPropertyDescription(nameof(ReceiveTimeOut)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);

            IsUseValueTypesConvert = new SBool(CommonData.GetPropertyDescription(nameof(IsUseValueTypesConvert)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsHex = new SBool(CommonData.GetPropertyDescription(nameof(IsHex)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            //IsServer = new SBool(CommonData.GetPropertyDescription(nameof(IsServer)),
            //    EHTupleStyle.None,
            //    EPropertyState.Input,
            //    EROILegend.None,
            //    false,
            //    false,
            //    false,
            //    false);

            Value.rtcResetWhenStart = true;
            IPAddress.rtcValue = cStrings.IPAddressDefault;
            PortNumber.rtcValue = 3000;
            ReceiveTimeOut.rtcValue = 10000;
            ValueLength.rtcValue = 1;
            IsHex.rtcValue = false;
            //IsServer.rtcValue = false;
            IsCompareValue.rtcValue = false;
            IsUseValueTypesConvert.rtcValue = false;
            ValueTypesConvert.rtcValue = CommonData.GetDefaultValues_Text(nameof(ValueTypesConvert) + _SuffixName);

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
            GroupType = EGroupTypes.Communication;
        }
        private void SetUpPropertyByImageFilter()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
         EHTupleStyle.None,
         EPropertyState.Input,
         EROILegend.None);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
         EHTupleStyle.None,
         EPropertyState.Input,
         EROILegend.None);
            OutputImage = new SImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None);
            OutputGrayImage= new SGrayImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None);
            OutputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None);
            ThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ThresholdRange)),
            EHTupleStyle.RangeMinMaxLimit,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            MaskHeight = new SInt(CommonData.GetPropertyDescription(nameof(MaskHeight)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            MaskWidth = new SInt(CommonData.GetPropertyDescription(nameof(MaskWidth)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            ScaleFactor = new SDouble(CommonData.GetPropertyDescription(nameof(ScaleFactor)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            InRangeOutputPixel = new SInt(CommonData.GetPropertyDescription(nameof(InRangeOutputPixel)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            OutRangeOutputPixel = new SInt(CommonData.GetPropertyDescription(nameof(OutRangeOutputPixel)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            Interations = new SInt(CommonData.GetPropertyDescription(nameof(Interations)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            FilterType = new SString(CommonData.GetPropertyDescription(nameof(FilterType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            InputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(InputRegion)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            GrayValue = new SListDouble(CommonData.GetPropertyDescription(nameof(GrayValue)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            Margin = new SString(CommonData.GetPropertyDescription(nameof(Margin)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);

            ThresholdRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ThresholdRange) + _SuffixName);
            MaskHeight.rtcValue = CommonData.GetDefaultValues_Int(nameof(MaskHeight) + _SuffixName);
            MaskWidth.rtcValue = CommonData.GetDefaultValues_Int(nameof(MaskWidth) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            InRangeOutputPixel.rtcValue = CommonData.GetDefaultValues_Int(nameof(InRangeOutputPixel) + _SuffixName);
            OutRangeOutputPixel.rtcValue = CommonData.GetDefaultValues_Int(nameof(OutRangeOutputPixel) + _SuffixName);
            Interations.rtcValue = CommonData.GetDefaultValues_Int(nameof(Interations) + _SuffixName);
            ScaleFactor.rtcValue = 1;

            FilterType.rtcValue = CommonData.GetDefaultValues_Text(nameof(FilterType) + _SuffixName);
            GrayValue.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(GrayValue) + _SuffixName);
            Margin.rtcValue = CommonData.GetDefaultValues_Text(nameof(Margin) + _SuffixName);
            ImageFilterProperty = new List<cImageFilterProperty>();
        }

        private void SetupPropertyByDistanceMeasurement()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
           EHTupleStyle.None,
           EPropertyState.Input,
           EROILegend.None,
           false,
           false,
           false,
           false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
         EHTupleStyle.None,
         EPropertyState.Input,
         EROILegend.None,
         false,
         false,
         false,
         false); 
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
           EHTupleStyle.None,
           EPropertyState.Input,
           EROILegend.None,
           false,
           false,
           false,
           false);
            InputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(InputRegion)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputRegion2 = new SListVector(CommonData.GetPropertyDescription(nameof(InputRegion2)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PointTwo = new SListDouble(CommonData.GetPropertyDescription(nameof(PointTwo)),
            EHTupleStyle.PointList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Point = new SListDouble(CommonData.GetPropertyDescription(nameof(Point)),
            EHTupleStyle.PointList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Line = new SListDouble(CommonData.GetPropertyDescription(nameof(Line)),
            EHTupleStyle.Line,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DistanceType = new SString(CommonData.GetPropertyDescription(nameof(DistanceType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MeasurementType = new SString(CommonData.GetPropertyDescription(nameof(MeasurementType)),
            EHTupleStyle.None,
            EPropertyState.Input);
            DisplayRadius = new SDouble(CommonData.GetPropertyDescription(nameof(DisplayRadius)),
            EHTupleStyle.None,
            EPropertyState.Input);
            DistanceContourType = new SString(CommonData.GetPropertyDescription(nameof(DistanceContourType)),
            EHTupleStyle.None,
            EPropertyState.Input);
            TrainPressed = new SBool(CommonData.GetPropertyDescription(nameof(TrainPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            ResetPressed = new SBool(CommonData.GetPropertyDescription(nameof(ResetPressed)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Tolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(Tolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input);
            ScaleFactor = new SDouble(CommonData.GetPropertyDescription(nameof(ScaleFactor)),
            EHTupleStyle.None,
            EPropertyState.Input);
            TrainDistance = new SDouble(CommonData.GetPropertyDescription(nameof(TrainDistance)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Distance = new SDouble(CommonData.GetPropertyDescription(nameof(Distance)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            true);
            DistanceError = new SDouble(CommonData.GetPropertyDescription(nameof(DistanceError)),
            EHTupleStyle.None,
            EPropertyState.Output);
            DistanceErrorPoints = new SListDouble(CommonData.GetPropertyDescription(nameof(DistanceErrorPoints)),
            EHTupleStyle.None,
            EPropertyState.Output);
            ScaleFactorOut = new SDouble(CommonData.GetPropertyDescription(nameof(ScaleFactorOut)),
            EHTupleStyle.None,
            EPropertyState.Output);
            TrainDistanceOut = new SDouble(CommonData.GetPropertyDescription(nameof(TrainDistanceOut)),
            EHTupleStyle.None,
            EPropertyState.Output);
            DistanceMin = new SListDouble(CommonData.GetPropertyDescription(nameof(DistanceMin)),
            EHTupleStyle.None,
            EPropertyState.Output);
            LineSegment = new SListDouble(CommonData.GetPropertyDescription(nameof(LineSegment)),
            EHTupleStyle.Line,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            true,
            false);
            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input);
           // //InputContour = new SHXLDCont(CommonData.GetPropertyDescription(nameof(InputContour)),
           // EHTupleStyle.None,
           // EPropertyState.Input);
           //// InputContour2 = new SHXLDCont(CommonData.GetPropertyDescription(nameof(InputContour2)),
           // EHTupleStyle.None,
           // EPropertyState.Input);
            LineTwo = new SListDouble(CommonData.GetPropertyDescription(nameof(LineTwo)),
            EHTupleStyle.Line,
            EPropertyState.Input);
            //DistanceContour = new SHXLDCont(CommonData.GetPropertyDescription(nameof(DistanceContour)),
            //EHTupleStyle.None,
            //EPropertyState.Output,
            //EROILegend.None,
            //false, false, true);
            DistanceCircleContour = new SListVector(CommonData.GetPropertyDescription(nameof(DistanceCircleContour)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false, true, false);
            MeasureEndPoint = new SString(CommonData.GetPropertyDescription(nameof(MeasureEndPoint)),
            EHTupleStyle.None,
            EPropertyState.Input);
            MeasureDirection = new SString(CommonData.GetPropertyDescription(nameof(MeasureDirection)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IntersectionPoint = new SListDouble(CommonData.GetPropertyDescription(nameof(IntersectionPoint)),
            EHTupleStyle.ValueList,
            EPropertyState.Output);

            DistanceContourType.rtcValue = CommonData.GetDefaultValues_Text(nameof(DistanceContourType) + _SuffixName);
            DisplayRadius.rtcValue = CommonData.GetDefaultValues_Double(nameof(DisplayRadius) + _SuffixName);
            PointTwo.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(PointTwo) + _SuffixName);
            Point.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(Point) + _SuffixName);
            Line.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(Line) + _SuffixName);
            DistanceType.rtcValue = CommonData.GetDefaultValues_Text(nameof(DistanceType) + _SuffixName);
            MeasurementType.rtcValue = CommonData.GetDefaultValues_Text(nameof(MeasurementType) + _SuffixName);
            TrainPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TrainPressed) + _SuffixName);
            ResetPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(ResetPressed) + _SuffixName);
            Tolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(Tolerance) + _SuffixName);
            ScaleFactor.rtcValue = CommonData.GetDefaultValues_Double(nameof(ScaleFactor) + _SuffixName);
            TrainDistance.rtcValue = CommonData.GetDefaultValues_Double(nameof(TrainDistance) + _SuffixName);
            TrainDistance.rtcValue = CommonData.GetDefaultValues_Double(nameof(TrainDistance) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            LineTwo.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(LineTwo) + _SuffixName);
            //MeasurementType.rtcValue = CommonData.GetDefaultValues_Text(nameof(MeasurementType) + _SuffixName);
            MeasureEndPoint.rtcValue = CommonData.GetDefaultValues_Text(nameof(MeasureEndPoint) + _SuffixName);
            MeasureDirection.rtcValue = CommonData.GetDefaultValues_Text(nameof(MeasureDirection) + _SuffixName);
            //Proc = new HDevProcedure(CommonData.GetProcedureName(_Name, _Name));
        }

        private void SetupPropertyByColorBlob()
        {
            IsMultiROI = true;
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input,
              EROILegend.None,
              false,
              false,
              false,
              false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
         EHTupleStyle.None,
         EPropertyState.Input,
         EROILegend.None,
         false,
         false,
         false,
         false);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
           EHTupleStyle.None,
           EPropertyState.Input,
           EROILegend.None,
           false,
           false,
           false,
           false);
            OutputBlobList = new SListVector(CommonData.GetPropertyDescription(nameof(OutputBlobList)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
            EHTupleStyle.DoubleList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            OutputFindShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputFindShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.SearchROI,
            true,
            true,
            false,
            true);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            FindShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(FindShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.SearchROI,
            false,
            false,
            false,
            true);
            FindShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(FindShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.SearchROI,
            true,
            true,
            false,
            true);

            FillHoles = new SBool(CommonData.GetPropertyDescription(nameof(FillHoles)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableHeightFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableHeightFilter)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableOutputAreaList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputAreaList)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableOutputBlobList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputBlobList)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableOutputDimsList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputDimsList)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableRowFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableRowFilter)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableWidthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableWidthFilter)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableColumnFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableColumnFilter)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AreaRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            WidthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ColumnRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RowRange = new SListDouble(CommonData.GetPropertyDescription(nameof(RowRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RequiredNumberOfBlobs = new SListObject(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TrainPressed = new SBool(CommonData.GetPropertyDescription(nameof(TrainPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputAreaList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputAreaList)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputWidthList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputWidthList)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputHeightList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputHeightList)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            NumberOfBlobsFound = new SListDouble(CommonData.GetPropertyDescription(nameof(NumberOfBlobsFound)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ColorSpace = new SString(CommonData.GetPropertyDescription(nameof(ColorSpace)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TabSearchActive = new SBool(CommonData.GetPropertyDescription(nameof(TabSearchActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            HeightRange = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RedTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(RedTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RedTolerance.rtcIsReBinding = true;
            BlueTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(BlueTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            BlueTolerance.rtcIsReBinding = true;
            GreenTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(GreenTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            GreenTolerance.rtcIsReBinding = true;
            HueTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(HueTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            HueTolerance.rtcIsReBinding = true;
            SaturationTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(SaturationTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SaturationTolerance.rtcIsReBinding = true;
            IntensityTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(IntensityTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IntensityTolerance.rtcIsReBinding = true;
            HueToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(HueToleranceOut)),
            EHTupleStyle.Tolerance,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IntensityToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(IntensityToleranceOut)),
            EHTupleStyle.Tolerance,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SaturationToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(SaturationToleranceOut)),
            EHTupleStyle.Tolerance,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RedToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(RedToleranceOut)),
            EHTupleStyle.Tolerance,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            GreenToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(GreenToleranceOut)),
            EHTupleStyle.Tolerance,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            BlueToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(BlueToleranceOut)),
            EHTupleStyle.Tolerance,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);

            AreaActual = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            WidthActual = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            HeightActual = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ColumnActual = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RowActual = new SListDouble(CommonData.GetPropertyDescription(nameof(RowActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(InputRegion)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            AreaActual.rtcIsReBinding = true;
            WidthActual.rtcIsReBinding = true;
            HeightActual.rtcIsReBinding = true;
            ColumnActual.rtcIsReBinding = true;
            RowActual.rtcIsReBinding = true;

            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            //ShapeList.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeList) + _SuffixName);
            //ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeListOriginal) + _SuffixName);
            //FindShapeList.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(FindShapeList) + _SuffixName);
            //FindShapeListOriginal.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(FindShapeListOriginal) + _SuffixName);
            FillHoles.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FillHoles) + _SuffixName);
            EnableAreaFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAreaFilter) + _SuffixName);
            EnableHeightFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableHeightFilter) + _SuffixName);
            EnableOutputAreaList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputAreaList) + _SuffixName);
            EnableOutputBlobList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputBlobList) + _SuffixName);
            EnableOutputDimsList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputDimsList) + _SuffixName);
            EnableRowFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableRowFilter) + _SuffixName);
            EnableWidthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableWidthFilter) + _SuffixName);
            EnableColumnFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableColumnFilter) + _SuffixName);
            AreaRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AreaRange) + _SuffixName);
            WidthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(WidthRange) + _SuffixName);
            ColumnRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ColumnRange) + _SuffixName);
            RowRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RowRange) + _SuffixName);
            RequiredNumberOfBlobs.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(RequiredNumberOfBlobs) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            TrainPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TrainPressed) + _SuffixName);
            ColorSpace.rtcValue = CommonData.GetDefaultValues_Text(nameof(ColorSpace) + _SuffixName);
            TabSearchActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabSearchActive) + _SuffixName);
            HeightRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HeightRange) + _SuffixName);
            RedTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RedTolerance) + _SuffixName);
            BlueTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(BlueTolerance) + _SuffixName);
            GreenTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble (nameof(GreenTolerance) + _SuffixName);
            HueTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HueTolerance) + _SuffixName);
            SaturationTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(SaturationTolerance) + _SuffixName);
            IntensityTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(IntensityTolerance) + _SuffixName);
            RedToleranceOut.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RedTolerance) + _SuffixName);
            BlueToleranceOut.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(BlueTolerance) + _SuffixName);
            GreenToleranceOut.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(GreenTolerance) + _SuffixName);
            HueToleranceOut.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HueTolerance) + _SuffixName);
            SaturationToleranceOut.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(SaturationTolerance) + _SuffixName);
            IntensityToleranceOut.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(IntensityTolerance) + _SuffixName);
        }
        private void SetupPropertyByLineFind()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
             EHTupleStyle.None,
             EPropertyState.Input,
             EROILegend.None,
             false,
             false,
             false,
             false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            SamplingPercent = new SInt(CommonData.GetPropertyDescription(nameof(SamplingPercent)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EdgeTransition = new SString(CommonData.GetPropertyDescription(nameof(EdgeTransition)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EdgeType = new SString(CommonData.GetPropertyDescription(nameof(EdgeType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableGapLengthCheck = new SBool(CommonData.GetPropertyDescription(nameof(EnableGapLengthCheck)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableLineLengthCheck = new SBool(CommonData.GetPropertyDescription(nameof(EnableLineLengthCheck)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableAngleRangeCheck = new SBool(CommonData.GetPropertyDescription(nameof(EnableAngleRangeCheck)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            GapLengthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(GapLengthRange)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            LineLengthTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(LineLengthTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            LineAngleTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(LineAngleTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutlierDistanceThreshold = new SDouble(CommonData.GetPropertyDescription(nameof(OutlierDistanceThreshold)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MaxPercentageOfOutliers = new SDouble(CommonData.GetPropertyDescription(nameof(MaxPercentageOfOutliers)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MinEdgePointNumber = new SInt(CommonData.GetPropertyDescription(nameof(MinEdgePointNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SubpixelMethod = new SString(CommonData.GetPropertyDescription(nameof(SubpixelMethod)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EdgeDetectionThreshold = new SInt(CommonData.GetPropertyDescription(nameof(EdgeDetectionThreshold)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Sigma = new SDouble(CommonData.GetPropertyDescription(nameof(Sigma)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            false,
            false,
            false);
            GreatestOutlierDistance = new SDouble(CommonData.GetPropertyDescription(nameof(GreatestOutlierDistance)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            GreatestGapLength = new SDouble(CommonData.GetPropertyDescription(nameof(GreatestGapLength)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PercentageOfOutliers = new SDouble(CommonData.GetPropertyDescription(nameof(PercentageOfOutliers)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EdgePoints = new SListDouble(CommonData.GetPropertyDescription(nameof(EdgePoints)),
            EHTupleStyle.PointList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutlierPoints = new SListDouble(CommonData.GetPropertyDescription(nameof(OutlierPoints)),
            EHTupleStyle.PointList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            LineSegment = new SListDouble(CommonData.GetPropertyDescription(nameof(LineSegment)),
            EHTupleStyle.Line,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            true,
            false);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            //FoundLineContour = new SHXLDCont(CommonData.GetPropertyDescription(nameof(FoundLineContour)),
            //EHTupleStyle.None,
            //EPropertyState.Output,
            //EROILegend.None,
            //false, false, true);
            OutputPointList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputPointList)),
            EHTupleStyle.PointList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            true,
            false);
            //ShapeList.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeList) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            SamplingPercent.rtcValue = CommonData.GetDefaultValues_Int(nameof(SamplingPercent) + _SuffixName);
            EdgeTransition.rtcValue = CommonData.GetDefaultValues_Text(nameof(EdgeTransition) + _SuffixName);
            EdgeType.rtcValue = CommonData.GetDefaultValues_Text(nameof(EdgeType) + _SuffixName);
            EnableGapLengthCheck.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableGapLengthCheck) + _SuffixName);
            EnableLineLengthCheck.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableLineLengthCheck) + _SuffixName);
            EnableAngleRangeCheck.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAngleRangeCheck) + _SuffixName);
            GapLengthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(GapLengthRange) + _SuffixName);
            LineLengthTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(LineLengthTolerance) + _SuffixName);
            LineAngleTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(LineAngleTolerance) + _SuffixName);
            OutlierDistanceThreshold.rtcValue = CommonData.GetDefaultValues_Double(nameof(OutlierDistanceThreshold) + _SuffixName);
            MaxPercentageOfOutliers.rtcValue = CommonData.GetDefaultValues_Double(nameof(MaxPercentageOfOutliers) + _SuffixName);
            MinEdgePointNumber.rtcValue = CommonData.GetDefaultValues_Int(nameof(MinEdgePointNumber) + _SuffixName);
            SubpixelMethod.rtcValue = CommonData.GetDefaultValues_Text(nameof(SubpixelMethod) + _SuffixName);
            EdgeDetectionThreshold.rtcValue = CommonData.GetDefaultValues_Int(nameof(EdgeDetectionThreshold) + _SuffixName);
            Sigma.rtcValue = CommonData.GetDefaultValues_Double(nameof(Sigma) + _SuffixName);
            //ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeListOriginal) + _SuffixName);
        }

        private void SetUpPropertyByBrightness()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
             EHTupleStyle.None,
             EPropertyState.Input,
             EROILegend.None,
             false,
             false,
             false,
             false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            BrightnessRange = new SListDouble(CommonData.GetPropertyDescription(nameof(BrightnessRange)),
            EHTupleStyle.RangeMinMaxLimit,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Invert = new SBool(CommonData.GetPropertyDescription(nameof(Invert)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Brightness = new SDouble(CommonData.GetPropertyDescription(nameof(Brightness)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);

            //ShapeList.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeList) + _SuffixName);
            //ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeListOriginal) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            BrightnessRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(BrightnessRange) + _SuffixName);
            Invert.rtcValue = CommonData.GetDefaultValues_Bool(nameof(Invert) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
        }

        private void SetUpPropertyByPixelCount()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
           EHTupleStyle.None,
           EPropertyState.Input,
           EROILegend.None,
           false,
           false,
           false,
           false);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false);
            OutputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(OutputRegion)), 
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false);

            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            ThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ThresholdRange)),
            EHTupleStyle.RangeMinMaxLimit,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false);
            ThresholdMode = new SString(CommonData.GetPropertyDescription(nameof(ThresholdMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false);
            PixelColor = new SString(CommonData.GetPropertyDescription(nameof(PixelColor)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false);
            Invert = new SBool(CommonData.GetPropertyDescription(nameof(Invert)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false);
            PixelCountRange = new SListDouble(CommonData.GetPropertyDescription(nameof(PixelCountRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false);
            Pixels = new SInt(CommonData.GetPropertyDescription(nameof(Pixels)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false);
            ActualThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualThresholdRange)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);

            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            //ShapeList.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ShapeList) + _SuffixName);
            //ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ShapeListOriginal) + _SuffixName);
            ThresholdRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ThresholdRange) + _SuffixName);
            ThresholdMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(ThresholdMode) + _SuffixName);
            PixelColor.rtcValue = CommonData.GetDefaultValues_Text(nameof(PixelColor) + _SuffixName);
            Invert.rtcValue = CommonData.GetDefaultValues_Bool(nameof(Invert) + _SuffixName);
            PixelCountRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(PixelCountRange) + _SuffixName);
            PixelCount_ROITrain_ROI = true;
        }

        public void SetupPropertyByBlob()
        {
            Blob_ROITrain_Roi = true;
            FillHoles = new SBool(CommonData.GetPropertyDescription(nameof(FillHoles)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ThresholdRange)),
                EHTupleStyle.RangeMinMaxLimit,
                EPropertyState.Input);
            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);
            AreaRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaRange)),
               EHTupleStyle.RangeMinMax,
               EPropertyState.Input);
            EnableHeightFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableHeightFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);
            HeightRange = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);

            #region Bổ sung cho dự án SEI 15.05.2023
            EnableLongestLengthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableLongestLengthFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);
            LongestLengthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(LongestLengthRange)),
               EHTupleStyle.RangeMinMax,
               EPropertyState.Input);
            LongestLengthActual = new SListDouble(CommonData.GetPropertyDescription(nameof(LongestLengthActual)));

            EnableShortestLengthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableShortestLengthFilter)),
               EHTupleStyle.None,
               EPropertyState.Input);
            ShortestLengthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ShortestLengthRange)),
               EHTupleStyle.RangeMinMax,
               EPropertyState.Input);
            ShortestLengthActual = new SListDouble(CommonData.GetPropertyDescription(nameof(ShortestLengthActual)));
            #endregion

            EnableOuterRadiusFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableOuterRadiusFilter)),
               EHTupleStyle.None,
               EPropertyState.Input);
            OuterRadiusRange = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusRange)),
               EHTupleStyle.RangeMinMax,
                EPropertyState.Input);
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
               EHTupleStyle.None,
               EPropertyState.Input); 
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OutputBlobList = new SListVector(CommonData.GetPropertyDescription(nameof(EnableShortestLengthFilter)),
                EHTupleStyle.None,
                EPropertyState.Output);
            WidthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
                EHTupleStyle.Origin,
                EPropertyState.Input);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
                EHTupleStyle.Regions,
                EPropertyState.Input,
                EROILegend.PrimaryRoi,
                false,
                false,
                false,
                true);
            EnableCircularityFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableCircularityFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);
            CircularityRange = new SListDouble(CommonData.GetPropertyDescription(nameof(CircularityRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);
            EnableOutputBlobList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputBlobList)),
                EHTupleStyle.None,
                EPropertyState.Input);
            EnableOutputAreaList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputAreaList)),
                EHTupleStyle.None,
                EPropertyState.Input);
            EnableOutputDimsList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputDimsList)),
                EHTupleStyle.None,
                EPropertyState.Input);
            RequiredNumberOfBlobs = new SListObject(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);
            OutputAreaList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputAreaList)),
                EHTupleStyle.ValueList,
                EPropertyState.Output);
            OutputWidthList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputWidthList)),
                EHTupleStyle.ValueList,
                EPropertyState.Output);
            OutputHeightList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputHeightList)),
                EHTupleStyle.ValueList,
                EPropertyState.Output);
            NumberOfBlobsFound = new SListDouble(CommonData.GetPropertyDescription(nameof(NumberOfBlobsFound)),
                EHTupleStyle.None,
                EPropertyState.Output);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
                EHTupleStyle.Regions,
                EPropertyState.Input,
                EROILegend.PrimaryRoi,
                false,
                false,
                false,
                true);
            AutoThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AutoThresholdRange)),
                EHTupleStyle.RangeMinMaxLimit,
                EPropertyState.Output);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                true,
                true,
                false,
                false);
            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                true,
                true,
                false,
                false);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
                EHTupleStyle.Regions,
                EPropertyState.Output,
                EROILegend.PrimaryRoi,
                true,
                true,
                false,
                true);
            GreyLevelThresholdType = new SString(CommonData.GetPropertyDescription(nameof(GreyLevelThresholdType)),
                EHTupleStyle.None,
                EPropertyState.Input);
            DynamicOffset = new SDouble(CommonData.GetPropertyDescription(nameof(DynamicOffset)),
                EHTupleStyle.None,
                EPropertyState.Input);
            DynamicFeature = new SString(CommonData.GetPropertyDescription(nameof(DynamicFeature)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ReferenceImage = new SImage(CommonData.GetPropertyDescription(nameof(ReferenceImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            EnableColumnFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableColumnFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);
            EnableRowFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableRowFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);
            RowRange = new SListDouble(CommonData.GetPropertyDescription(nameof(RowRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);
            ColumnRange = new SListDouble(CommonData.GetPropertyDescription(nameof(RowRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);
            DetectType = new SString(CommonData.GetPropertyDescription(nameof(DetectType)),
                EHTupleStyle.None,
                EPropertyState.Input);
            EnableWidthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableWidthFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);
            // Bổ sung cho chức năng view actual
            IndexToGetActual = new SListString(CommonData.GetPropertyDescription(nameof(IndexToGetActual)));
            IndexToGetActual.rtcValue = new List<string> { cStrings.None };
            AreaActual = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaActual)));
            WidthActual = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthActual)));
            HeightActual = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightActual)));
            OuterRadiusActual = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusActual)));
            CircularityActual = new SListDouble(CommonData.GetPropertyDescription(nameof(CircularityActual)));
            ColumnActual = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnActual)));
            RowActual = new SListDouble(CommonData.GetPropertyDescription(nameof(RowActual)));
            PositionMode = new SString(CommonData.GetPropertyDescription(nameof(PositionMode)));
            PositionMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(PositionMode) + _SuffixName);
            PositionMode.rtcIsReBinding = true;

            AreaActual.rtcIsReBinding = true;
            WidthActual.rtcIsReBinding = true;
            HeightActual.rtcIsReBinding = true;
            OuterRadiusActual.rtcIsReBinding = true;
            CircularityActual.rtcIsReBinding = true;
            ColumnActual.rtcIsReBinding = true;
            RowActual.rtcIsReBinding = true;
            LongestLengthActual.rtcIsReBinding = true;
            ShortestLengthActual.rtcIsReBinding = true;



            FillHoles.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FillHoles) + _SuffixName);
            ThresholdRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ThresholdRange) + _SuffixName);
            EnableAreaFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAreaFilter) + _SuffixName);
            AreaRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AreaRange) + _SuffixName);
            EnableHeightFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableHeightFilter) + _SuffixName);
            HeightRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HeightRange) + _SuffixName);
            EnableLongestLengthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableLongestLengthFilter) + _SuffixName);
            LongestLengthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(LongestLengthRange) + _SuffixName);
            ShortestLengthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ShortestLengthRange) + _SuffixName);
            EnableOuterRadiusFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOuterRadiusFilter) + _SuffixName);
            OuterRadiusRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(OuterRadiusRange) + _SuffixName);
            WidthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(WidthRange) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
           // ShapeList.rtcValue = CommonData.GetDefaultValues_ShapeList(nameof(ShapeList) + _SuffixName);
            EnableCircularityFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableCircularityFilter) + _SuffixName);
            CircularityRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(CircularityRange) + _SuffixName);
            EnableOutputBlobList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputBlobList) + _SuffixName);
            EnableOutputAreaList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputAreaList) + _SuffixName);
            EnableOutputDimsList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputDimsList) + _SuffixName);

            RequiredNumberOfBlobs.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(RequiredNumberOfBlobs) + _SuffixName);
            // ShapeListOriginal
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            GreyLevelThresholdType.rtcValue = CommonData.GetDefaultValues_Text(nameof(GreyLevelThresholdType) + _SuffixName);
            DynamicOffset.rtcValue = CommonData.GetDefaultValues_Double(nameof(DynamicOffset) + _SuffixName);
            DynamicFeature.rtcValue = CommonData.GetDefaultValues_Text(nameof(DynamicFeature) + _SuffixName);
            EnableColumnFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableColumnFilter) + _SuffixName);
            EnableRowFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableRowFilter) + _SuffixName);
            RowRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RowRange) + _SuffixName);
            ColumnRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ColumnRange) + _SuffixName);
            DetectType.rtcValue = CommonData.GetDefaultValues_Text(nameof(DetectType) + _SuffixName);
            EnableWidthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableWidthFilter) + _SuffixName);

        }
        public void SetupPropertyByBlobMultipleROI()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
                EHTupleStyle.Regions,
                EPropertyState.Input,
                EROILegend.PrimaryRoi,
                false,
                false,
                false,
                true);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
               EHTupleStyle.Regions,
               EPropertyState.Input,
               EROILegend.PrimaryRoi,
               true,
               true,
               false,
               true);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
                EHTupleStyle.Regions,
                EPropertyState.Output,
                EROILegend.PrimaryRoi,
                true,
                true,
                false,
                true);
            OutputResultList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputResultList)),
                EHTupleStyle.ValueList,
                EPropertyState.Output,
                EROILegend.None,
                true,
                false,
                false,
                false);
            ShapeListData = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListData)),
                EHTupleStyle.ValueList,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                true);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
               EHTupleStyle.None,
               EPropertyState.Input,
               EROILegend.None,
               true,
               true,
               false,
               false);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
               EHTupleStyle.Origin,
               EPropertyState.Input,
               EROILegend.None,
               false,
               false,
               false,
               false);
            EnableOutputAreaList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputAreaList)),
               EHTupleStyle.None,
               EPropertyState.Input);
            EnableOutputDimsList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputDimsList)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OutputAreaList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputAreaList)),
                EHTupleStyle.ValueList,
                EPropertyState.Output);
            OutputWidthList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputWidthList)),
                EHTupleStyle.ValueList,
                EPropertyState.Output);
            OutputHeightList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputHeightList)),
                EHTupleStyle.ValueList,
                EPropertyState.Output);
            EnableOutputBlobList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputBlobList)),
               EHTupleStyle.None,
               EPropertyState.Input);
            OutputBlobList = new SListVector(CommonData.GetPropertyDescription(nameof(EnableShortestLengthFilter)),
                EHTupleStyle.None,
                EPropertyState.Output);

            AreaActual = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaActual)));
            WidthActual = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthActual)));
            HeightActual = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightActual)));
            OuterRadiusActual = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusActual)));

            AreaActual.rtcIsReBinding = true;
            WidthActual.rtcIsReBinding = true;
            HeightActual.rtcIsReBinding = true;
            OuterRadiusActual.rtcIsReBinding = true;

            DetectType = new SString(CommonData.GetPropertyDescription(nameof(DetectType)),
               EHTupleStyle.None,
               EPropertyState.None,
               EROILegend.None,
               false,
               true);
            DetectType.rtcValue = CommonData.GetDefaultValues_Text(nameof(DetectType) + _SuffixName);
            GreyLevelThresholdType = new SString(CommonData.GetPropertyDescription(nameof(GreyLevelThresholdType)),
               EHTupleStyle.None,
               EPropertyState.None,
               EROILegend.None,
               false,
               true);
            GreyLevelThresholdType.rtcValue = CommonData.GetDefaultValues_Text(nameof(GreyLevelThresholdType) + _SuffixName);
            FillHoles = new SBool(CommonData.GetPropertyDescription(nameof(FillHoles)),
                EHTupleStyle.None,
                EPropertyState.None,
                EROILegend.None,
                false,
                true);
            FillHoles.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FillHoles) + _SuffixName);
            ThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ThresholdRange)),
                EHTupleStyle.RangeMinMaxLimit,
                EPropertyState.None,
                EROILegend.None,
                false,
                true);
            ThresholdRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ThresholdRange) + _SuffixName);

            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)),
                EHTupleStyle.None,
                EPropertyState.None,
                EROILegend.None,
                false,
                true);
            AreaRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaRange)),
              EHTupleStyle.RangeMinMax,
              EPropertyState.None,
              EROILegend.None,
              false,
              true);
            EnableOuterRadiusFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableOuterRadiusFilter)),
                EHTupleStyle.None,
                EPropertyState.None,
                EROILegend.None,
                false,
                true);
            OuterRadiusRange = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusRange)),
                EHTupleStyle.ValueList,
                EPropertyState.None,
                EROILegend.None,
                false,
                true);
            EnableHeightFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableHeightFilter)),
                EHTupleStyle.None,
                EPropertyState.None,
                EROILegend.None,
                false,
                true);
            HeightRange = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightRange)),
                EHTupleStyle.ValueList,
                EPropertyState.None,
                EROILegend.None,
                false,
                true);
            EnableWidthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableWidthFilter)),
                EHTupleStyle.None,
                EPropertyState.None,
                EROILegend.None,
                false,
                true);
            WidthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthRange)),
               EHTupleStyle.ValueList,
               EPropertyState.None,
               EROILegend.None,
               false,
               true);
            RequiredPass = new SBool(CommonData.GetPropertyDescription(nameof(RequiredPass)),
               EHTupleStyle.None,
               EPropertyState.None,
               EROILegend.None,
               false,
               true);
            RequiredPass.rtcValue = true;

            RequiredNumberOfBlobs = new SListObject(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)),
               EHTupleStyle.ValueList,
               EPropertyState.None,
               EROILegend.None,
               false,
               true);
            RequiredNumberOfBlobs.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(RequiredNumberOfBlobs) + _SuffixName);

            NumberOfBlobsFound = new SListDouble(CommonData.GetPropertyDescription(nameof(NumberOfBlobsFound)),
                EHTupleStyle.None,
                EPropertyState.Output);

            AreaRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AreaRange) + _SuffixName);
            WidthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(WidthRange) + _SuffixName);
            HeightRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HeightRange) + _SuffixName);
            OuterRadiusRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(OuterRadiusRange) + _SuffixName);

            EnableOutputBlobList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputBlobList) + _SuffixName);
            EnableOutputAreaList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputAreaList) + _SuffixName);
            EnableOutputDimsList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputDimsList) + _SuffixName);

            EnableAreaFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAreaFilter) + _SuffixName);
            EnableHeightFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableHeightFilter) + _SuffixName);
            EnableOuterRadiusFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOuterRadiusFilter) + _SuffixName);
            EnableWidthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableWidthFilter) + _SuffixName);

            AutoThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AutoThresholdRange)),
                EHTupleStyle.RangeMinMaxLimit,
                EPropertyState.Output);

            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                true,
                true,
                false,
                false);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            //ShapeList.rtcValue = CommonData.GetDefaultValues_ShapeList(nameof(ShapeList) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            IsMultiROI = true;
            //AutoRun = false;
        }
        public void SetupPropertyByColorBlobMultipleROI()
        {

            IsMultiROI = true;
            RequiredPass = new SBool(CommonData.GetPropertyDescription(nameof(RequiredPass)), EHTupleStyle.None, EPropertyState.None, EROILegend.None, false, true);
            RequiredPass.rtcValue = true;

            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
             EHTupleStyle.None,
             EPropertyState.Input,
             EROILegend.None,
             false,
             false,
             false,
             false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            ShapeListData = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListData)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            true);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            EnableOutputAreaList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputAreaList)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableOutputBlobList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputBlobList)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableOutputDimsList = new SBool(CommonData.GetPropertyDescription(nameof(EnableOutputDimsList)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TrainPressed = new SBool(CommonData.GetPropertyDescription(nameof(TrainPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RedToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(RedToleranceOut)),
            EHTupleStyle.Tolerance,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SaturationToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(SaturationToleranceOut)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            GreenToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(GreenToleranceOut)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            HueToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(HueToleranceOut)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            BlueToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(BlueToleranceOut)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IntensityToleranceOut = new SListDouble(CommonData.GetPropertyDescription(nameof(IntensityToleranceOut)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            NumberOfBlobsFound = new SListDouble(CommonData.GetPropertyDescription(nameof(NumberOfBlobsFound)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputResultList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputResultList)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputBlobList = new SListVector(CommonData.GetPropertyDescription(nameof(OutputBlobList)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputAreaList = new SListDouble(CommonData.GetPropertyDescription(nameof(RedTolerance)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            OutputAreaList = new SListDouble(CommonData.GetPropertyDescription(nameof(RedTolerance)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false); 
            OutputAreaList = new SListDouble(CommonData.GetPropertyDescription(nameof(RedTolerance)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            RedTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(RedTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            RedTolerance.rtcIsReBinding = true;
            BlueTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(BlueTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            BlueTolerance.rtcIsReBinding = true;
            GreenTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(GreenTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            GreenTolerance.rtcIsReBinding = true;
            HueTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(HueTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            HueTolerance.rtcIsReBinding = true;
            SaturationTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(SaturationTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            SaturationTolerance.rtcIsReBinding = true;
            IntensityTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(IntensityTolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            IntensityTolerance.rtcIsReBinding = true;
            ColorSpace = new SString(CommonData.GetPropertyDescription(nameof(ColorSpace)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            FillHoles = new SBool(CommonData.GetPropertyDescription(nameof(FillHoles)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            RequiredNumberOfBlobs = new SListObject(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            EnableColumnFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableColumnFilter)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            EnableHeightFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableHeightFilter)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            EnableRowFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableRowFilter)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            EnableWidthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableWidthFilter)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            EnableOuterRadiusFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableOuterRadiusFilter)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            OuterRadiusRange = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            AreaRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            HeightRange = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            WidthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            ColumnRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            Expression = new SString(CommonData.GetPropertyDescription(nameof(Expression)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AreaActual = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            WidthActual = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            HeightActual = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OuterRadiusActual = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusActual)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);

            AreaActual.rtcIsReBinding = true;
            WidthActual.rtcIsReBinding = true;
            HeightActual.rtcIsReBinding = true;
            OuterRadiusActual.rtcIsReBinding = true;

            //ShapeList.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(ShapeList) + _SuffixName);
            //ShapeListData.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeListData) + _SuffixName);
            //ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeListOriginal) + _SuffixName);
            EnableOutputAreaList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputAreaList) + _SuffixName);
            EnableOutputBlobList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputBlobList) + _SuffixName);
            EnableOutputDimsList.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOutputDimsList) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            TrainPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TrainPressed) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            RedTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RedTolerance) + _SuffixName);
            BlueTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(BlueTolerance) + _SuffixName);
            GreenTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(GreenTolerance) + _SuffixName);
            HueTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HueTolerance) + _SuffixName);
            SaturationTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(SaturationTolerance) + _SuffixName);
            IntensityTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(IntensityTolerance) + _SuffixName);
            ColorSpace.rtcValue = CommonData.GetDefaultValues_Text(nameof(ColorSpace) + _SuffixName);
            FillHoles.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FillHoles) + _SuffixName);
            RequiredNumberOfBlobs.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(RequiredNumberOfBlobs) + _SuffixName);
            EnableAreaFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAreaFilter) + _SuffixName);
            EnableColumnFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableColumnFilter) + _SuffixName);
            EnableHeightFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableHeightFilter) + _SuffixName);
            EnableRowFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableRowFilter) + _SuffixName);
            EnableWidthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableWidthFilter) + _SuffixName);
            EnableOuterRadiusFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOuterRadiusFilter) + _SuffixName);
            OuterRadiusRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(OuterRadiusRange) + _SuffixName);
            AreaRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AreaRange) + _SuffixName);
            HeightRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HeightRange) + _SuffixName);
            WidthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(WidthRange) + _SuffixName);
            ColumnRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ColumnRange) + _SuffixName);

           
        }

        public void SetupPropertyByBlobFiler()
        {
            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);

            EnableCircularityFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableCircularityFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);

            EnableRowFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableRowFilter)),
               EHTupleStyle.None,
               EPropertyState.Input);

            EnableHeightFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableHeightFilter)),
               EHTupleStyle.None,
               EPropertyState.Input);

            EnableOuterRadiusFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableOuterRadiusFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);

            EnableColumnFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableColumnFilter)),
               EHTupleStyle.None,
               EPropertyState.Input);

            EnableWidthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableWidthFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);

            EnableRectangularityFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableRectangularityFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);

            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                true,
                true,
                false,
                false);

            OutputBlobList = new SListVector(CommonData.GetPropertyDescription(nameof(EnableShortestLengthFilter)),
                EHTupleStyle.None,
                EPropertyState.Input);

            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            InputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(InputRegion)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            AreaRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);

            CircularityRange = new SListDouble(CommonData.GetPropertyDescription(nameof(CircularityRange)),
               EHTupleStyle.RangeMinMax,
               EPropertyState.Input);

            RectangularityRange = new SListDouble(CommonData.GetPropertyDescription(nameof(RectangularityRange)),
               EHTupleStyle.RangeMinMax,
               EPropertyState.Input);

      
            RowRange = new SListDouble(CommonData.GetPropertyDescription(nameof(RowRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);

            HeightRange = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);

            WidthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthRange)),
                EHTupleStyle.RangeMinMax,
                EPropertyState.Input);

            OuterRadiusRange = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusRange)),
               EHTupleStyle.RangeMinMax,
               EPropertyState.Input);

            ColumnRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnRange)),
             EHTupleStyle.RangeMinMax,
             EPropertyState.Input);

            InputBlobList = new SListVector(CommonData.GetPropertyDescription(nameof(InputBlobList)),
             EHTupleStyle.None,
             EPropertyState.Input);

            Order = new SString(CommonData.GetPropertyDescription(nameof(Order)),
             EHTupleStyle.None,
             EPropertyState.Input);

            NumberOfBlobsFound = new SListDouble(CommonData.GetPropertyDescription(nameof(NumberOfBlobsFound)),
               EHTupleStyle.None,
               EPropertyState.Output);

            EnableSortRegion = new SBool(CommonData.GetPropertyDescription(nameof(EnableSortRegion)),
                EHTupleStyle.None,
                EPropertyState.Input); 

            SortMode = new SString(CommonData.GetPropertyDescription(nameof(SortMode)),
                EHTupleStyle.None,
                EPropertyState.Input);

            RowOrCol = new SString(CommonData.GetPropertyDescription(nameof(RowOrCol)),
                EHTupleStyle.None,
                EPropertyState.Input);

            SelectedIndex = new SListString(CommonData.GetPropertyDescription(nameof(SelectedIndex)),
               EHTupleStyle.ValueList,
               EPropertyState.Output);
            RequiredNumberOfBlobs = new SListObject(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)),
            EHTupleStyle.ValueList,
            EPropertyState.Output);
            PositionMode = new SString(CommonData.GetPropertyDescription(nameof(PositionMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            PositionMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(PositionMode) + _SuffixName);
            PositionMode.rtcIsReBinding = true;
            OutputBlobList = new SListVector(CommonData.GetPropertyDescription(nameof(OutputBlobList)), EHTupleStyle.None,
                EPropertyState.Output);
            

            // Bổ sung chức năng view actual
            IndexToGetActual = new SListString(CommonData.GetPropertyDescription(nameof(IndexToGetActual)));
            AreaActual = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaActual)));
            WidthActual = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthActual)));
            HeightActual = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightActual)));
            OuterRadiusActual = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusActual)));
            CircularityActual = new SListDouble(CommonData.GetPropertyDescription(nameof(CircularityActual)));
            RectangularityActual = new SListDouble(CommonData.GetPropertyDescription(nameof(RectangularityActual)));
            ColumnActual = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnActual)));
            RowActual = new SListDouble(CommonData.GetPropertyDescription(nameof(RowActual)));

            IndexToGetActual.rtcValue = new List<string> { cStrings.None };
            AreaActual.rtcIsReBinding = true;
            WidthActual.rtcIsReBinding = true;
            HeightActual.rtcIsReBinding = true;
            OuterRadiusActual.rtcIsReBinding = true;
            CircularityActual.rtcIsReBinding = true;
            RectangularityActual.rtcIsReBinding = true;
            ColumnActual.rtcIsReBinding = true;
            RowActual.rtcIsReBinding = true;

            EnableAreaFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAreaFilter) + _SuffixName);
            EnableCircularityFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableCircularityFilter) + _SuffixName);
            EnableRectangularityFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableRectangularityFilter) + _SuffixName);
            RectangularityRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RectangularityRange) + _SuffixName);

            EnableRowFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableRowFilter) + _SuffixName);
            EnableHeightFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableHeightFilter) + _SuffixName);
            EnableOuterRadiusFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOuterRadiusFilter) + _SuffixName);
            EnableColumnFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableColumnFilter) + _SuffixName);
            EnableWidthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableWidthFilter) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            AreaRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AreaRange) + _SuffixName);
            CircularityRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(CircularityRange) + _SuffixName);
            RowRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RowRange) + _SuffixName);
            HeightRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HeightRange) + _SuffixName);
            WidthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(WidthRange) + _SuffixName);
            OuterRadiusRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(OuterRadiusRange) + _SuffixName);
            ColumnRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ColumnRange) + _SuffixName);
            RequiredNumberOfBlobs.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(RequiredNumberOfBlobs) + _SuffixName);
            EnableSortRegion.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableSortRegion) + _SuffixName);
            SortMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SortMode) + _SuffixName);
            RowOrCol.rtcValue = CommonData.GetDefaultValues_Text(nameof(RowOrCol) + _SuffixName);
            SelectedIndex.rtcValue = CommonData.GetDefaultValues_ListString(nameof(SelectedIndex) + _SuffixName);
            Order.rtcValue = CommonData.GetDefaultValues_Text(nameof(Order) + _SuffixName);
           // RequiredNumberOfBlobs.rtcValue = new List<double> { 0 };


        }
        public void SetupPropertyByPattern()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)), EHTupleStyle.None,
                                               EPropertyState.Input, EROILegend.None, false);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)), EHTupleStyle.None,
                                              EPropertyState.Input, EROILegend.None, false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)), EHTupleStyle.None,
                                         EPropertyState.Input, EROILegend.None, false);
            ImageMaster = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)), EHTupleStyle.None,
                                   EPropertyState.Input, EROILegend.None, false, true);

            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)), EHTupleStyle.Regions,
                                               EPropertyState.Input, EROILegend.PrimaryRoi, false, false, false, true);

            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
                                               EHTupleStyle.Regions, EPropertyState.Input, EROILegend.PrimaryRoi, false,
                                               false, false, true);

            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
                                               EHTupleStyle.Regions, EPropertyState.Output, EROILegend.PrimaryRoi, true,
                                               false, false, true);
            OutputFindShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputFindShapeList)),
                                               EHTupleStyle.Regions, EPropertyState.Output, EROILegend.SearchROI);

            FindShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(FindShapeList)),
                                               EHTupleStyle.Regions, EPropertyState.Input, EROILegend.SearchROI, false,
                                             false, false, true);

            FindShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(FindShapeListOriginal)),
                                               EHTupleStyle.Regions, EPropertyState.Input, EROILegend.SearchROI, false,
                                                   true, false, true);

            TrainEdgeDetectionMode = new SString(CommonData.GetPropertyDescription(nameof(TrainEdgeDetectionMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            TrainFixedEdgeThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(TrainFixedEdgeThresholdRange)),
                                               EHTupleStyle.RangeMinMaxLimit, EPropertyState.Input, EROILegend.None, false);

            MinCoutourLength = new SListDouble(CommonData.GetPropertyDescription(nameof(MinCoutourLength)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            NoiseLevelMode = new SString(CommonData.GetPropertyDescription(nameof(NoiseLevelMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            NoiseLevel = new SInt(CommonData.GetPropertyDescription(nameof(NoiseLevel)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            PossibleRotations = new SString(CommonData.GetPropertyDescription(nameof(PossibleRotations)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            AngleRangePattern = new SListDouble(CommonData.GetPropertyDescription(nameof(AngleRangePattern)),
                                               EHTupleStyle.RangeMinMax, EPropertyState.Input, EROILegend.None, false);
            AngleStepMode =  new SString(CommonData.GetPropertyDescription(nameof(AngleStepMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            AngleStepValue = new SDouble(CommonData.GetPropertyDescription(nameof(AngleStepValue)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            PossibleScaling = new SString(CommonData.GetPropertyDescription(nameof(PossibleScaling)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            ScaleRangePattern = new SListDouble(CommonData.GetPropertyDescription(nameof(ScaleRangePattern)),
                                               EHTupleStyle.RangeMinMax, EPropertyState.Input, EROILegend.None, false);

            ScaleStepMode = new SString(CommonData.GetPropertyDescription(nameof(ScaleStepMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            ScaleStepValue = new SDouble(CommonData.GetPropertyDescription(nameof(ScaleStepValue)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            TrainSubsamplingLevelMode = new SString(CommonData.GetPropertyDescription(nameof(TrainSubsamplingLevelMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            TrainSubsamplingLevel = new SListDouble(CommonData.GetPropertyDescription(nameof(TrainSubsamplingLevel)),
                                               EHTupleStyle.ValueList, EPropertyState.Input, EROILegend.None, false);

            Polarity = new SString(CommonData.GetPropertyDescription(nameof(Polarity)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);


            OutputResultList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputResultList)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, true,
                                               false, false, false);

            TrainOptimizationMode = new SString(CommonData.GetPropertyDescription(nameof(TrainOptimizationMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            FindSubsamplingLevelMode = new SString(CommonData.GetPropertyDescription(nameof(FindSubsamplingLevelMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            FindSubsamplingLevel = new SListDouble(CommonData.GetPropertyDescription(nameof(FindSubsamplingLevel)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            FindAngleRangeMode = new SString(CommonData.GetPropertyDescription(nameof(FindAngleRangeMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            FindAngleRange = new SListDouble(CommonData.GetPropertyDescription(nameof(FindAngleRange)),
                                               EHTupleStyle.RangeMinMax, EPropertyState.Input, EROILegend.None, false);

            FindScaleRangeMode = new SString(CommonData.GetPropertyDescription(nameof(FindScaleRangeMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            FindScaleRange = new SListDouble(CommonData.GetPropertyDescription(nameof(FindScaleRange)),
                                               EHTupleStyle.RangeMinMax, EPropertyState.Input, EROILegend.None, false);

            FindOptimizationLevel = new SDouble(CommonData.GetPropertyDescription(nameof(FindOptimizationLevel)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false, true);


            TrainPressed = new SBool(CommonData.GetPropertyDescription(nameof(TrainPressed)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false, true);

            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false, true);

            MinSearchScore = new SDouble(CommonData.GetPropertyDescription(nameof(MinSearchScore)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);


            MinPassScore = new SDouble(CommonData.GetPropertyDescription(nameof(MinPassScore)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            NumberToFindRange = new SListDouble(CommonData.GetPropertyDescription(nameof(NumberToFindRange)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            NumberToFindMode = new SString(CommonData.GetPropertyDescription(nameof(NumberToFindMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            NumberToFindMode = new SString(CommonData.GetPropertyDescription(nameof(NumberToFindMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            MaxDeformationInPixels = new SInt(CommonData.GetPropertyDescription(nameof(MaxDeformationInPixels)), 
                                               EHTupleStyle.None,EPropertyState.Input, EROILegend.None, false);
                                               

            MaxOverlap = new SDouble(CommonData.GetPropertyDescription(nameof(MaxOverlap)), 
                                               EHTupleStyle.None,EPropertyState.Input, EROILegend.None, false);

            PositionAccuracy = new SString(CommonData.GetPropertyDescription(nameof(PositionAccuracy)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            CanTouchImageBorder = new SBool(CommonData.GetPropertyDescription(nameof(CanTouchImageBorder)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            EnableToolTimeOut = new SBool(CommonData.GetPropertyDescription(nameof(EnableToolTimeOut)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            ToolTimeOut = new SInt(CommonData.GetPropertyDescription(nameof(ToolTimeOut)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            InputTrained = new SBool(CommonData.GetPropertyDescription(nameof(InputTrained)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false, true);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);

            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
                                               EHTupleStyle.Origin, EPropertyState.Input, EROILegend.None, false);

            InputModelID = new SListDouble(CommonData.GetPropertyDescription(nameof(InputModelID)),
                                               EHTupleStyle.ValueList, EPropertyState.Input, EROILegend.None, false);

            OutputModelID = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputModelID)),
                                               EHTupleStyle.ValueList, EPropertyState.Input, EROILegend.None, false);

            OutputMasterOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputMasterOrigin)),
                                               EHTupleStyle.Origin, EPropertyState.Input, EROILegend.None, false);

            ToolMasterOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolMasterOrigin)),
                                               EHTupleStyle.Origin, EPropertyState.Input, EROILegend.None, false);

            //Modelcontour = new SBool(CommonData.GetPropertyDescription(nameof(CanTouchImageBorder)),
            //                                   EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            //MasterOriginCoutour
            //BestOriginContour

            OutPutBestOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(OutPutBestOrigin)),
                                               EHTupleStyle.Origin, EPropertyState.Output, EROILegend.None, false);

            OutputOriginList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputOriginList)),
                                               EHTupleStyle.OriginList, EPropertyState.Output, EROILegend.None, false);

            OutputOriginListEx = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputOriginListEx)),
                                               EHTupleStyle.None, EPropertyState.Output, EROILegend.None, false);

            OutputOriginListCount = new SInt(CommonData.GetPropertyDescription(nameof(OutputOriginListCount)),
                                               EHTupleStyle.None, EPropertyState.None, EROILegend.None, false);

            ActualTrainFixedThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualTrainFixedThresholdRange)),
                                               EHTupleStyle.RangeMinMax, EPropertyState.Output, EROILegend.None, false);

            ActualNoiseLevel = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualNoiseLevel)),
                                               EHTupleStyle.None, EPropertyState.Output, EROILegend.None, false);

            ActualTrainSubsamlingLevel = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualTrainSubsamlingLevel)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            ActualAngleStepValue = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualAngleStepValue)),
                                               EHTupleStyle.None, EPropertyState.Output, EROILegend.None, false);

            ActualScaleStepValue = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualScaleStepValue)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            OutputTrained = new SBool(CommonData.GetPropertyDescription(nameof(OutputTrained)),
                                               EHTupleStyle.None, EPropertyState.Output, EROILegend.None, false, true);

            ActualColumn = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualColumn)),
                                               EHTupleStyle.OriginList, EPropertyState.Output, EROILegend.None, false);

            OutputOriginListSortedByRowEx = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputOriginListSortedByRowEx)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            OutputOriginListSortedByColumn = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualColumn)),
                                               EHTupleStyle.OriginList, EPropertyState.Output, EROILegend.None, false);

            OutputOriginListSortedByColumnEX = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputOriginListSortedByColumnEX)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            OutputOriginListSorteMode = new SString(CommonData.GetPropertyDescription(nameof(OutputOriginListSorteMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            OutputScore = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputScore)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            PlacementMode = new SString(CommonData.GetPropertyDescription(nameof(PlacementMode)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            ModelReferenceOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ModelReferenceOrigin)),
                                               EHTupleStyle.Origin, EPropertyState.Input, EROILegend.None, false);

            OutputModelIDInfo = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputModelIDInfo)),
                                               EHTupleStyle.OriginList, EPropertyState.Output, EROILegend.None, false);

            EnableAngleRangeCheck = new SBool(CommonData.GetPropertyDescription(nameof(EnableAngleRangeCheck)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            EnableColumnFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableColumnFilter)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            EnableRowFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableRowFilter)),
                                               EHTupleStyle.None, EPropertyState.Input, EROILegend.None, false);

            AngleRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AngleRange)),
                                               EHTupleStyle.RangeMinMax, EPropertyState.Input, EROILegend.None, false);

            RowRange = new SListDouble(CommonData.GetPropertyDescription(nameof(RowRange)),
                                               EHTupleStyle.RangeMinMax, EPropertyState.Input, EROILegend.None, false);

            ColumnRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnRange)),
                                               EHTupleStyle.RangeMinMax, EPropertyState.Input, EROILegend.None, false);

            ActualColumn = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualColumn)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            ActualRow = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualRow)),
                                               EHTupleStyle.OriginList, EPropertyState.Output, EROILegend.None, false);

            ActualAngle = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualAngle)),
                                               EHTupleStyle.OriginList, EPropertyState.Output, EROILegend.None, false);

            #region BỔ SUNG CHO PANASONIC
            //TODO [1] PHẦN NÀY BỔ SUNG TẠM CHO DỰ ÁN PANASONIC - SẼ BỎ SAU KHI SỬA LẠI CẤU TRÚC

            OutputMasterOrigin_X = new SDouble(CommonData.GetPropertyDescription(nameof(OutputMasterOrigin_X)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            OutputMasterOrigin_Y = new SDouble(CommonData.GetPropertyDescription(nameof(OutputMasterOrigin_Y)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            OutputMasterOrigin_Phi = new SDouble(CommonData.GetPropertyDescription(nameof(OutputMasterOrigin_Phi)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            OutputBestOrigin_X = new SDouble(CommonData.GetPropertyDescription(nameof(OutputBestOrigin_X)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            OutputBestOrigin_Y= new SDouble(CommonData.GetPropertyDescription(nameof(OutputBestOrigin_Y)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);

            OutputBestOrigin_Phi = new SDouble(CommonData.GetPropertyDescription(nameof(OutputBestOrigin_Phi)),
                                               EHTupleStyle.ValueList, EPropertyState.Output, EROILegend.None, false);
            #endregion


            OutputOriginListSorteMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(OutputOriginListSorteMode) + _SuffixName);
            PlacementMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(PlacementMode) + _SuffixName);
            //ShapeList
            FindShapeList.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(FindShapeList) + _SuffixName);
            TrainEdgeDetectionMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(TrainEdgeDetectionMode) + _SuffixName);
            TrainFixedEdgeThresholdRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(TrainFixedEdgeThresholdRange) + _SuffixName);
            MinCoutourLength.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(MinCoutourLength) + _SuffixName);
            NoiseLevelMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(NoiseLevelMode) + _SuffixName);
            NoiseLevel.rtcValue = CommonData.GetDefaultValues_Int(nameof(NoiseLevel) + _SuffixName);
            PossibleRotations.rtcValue = CommonData.GetDefaultValues_Text(nameof(PossibleRotations) + _SuffixName);
            AngleRangePattern.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AngleRangePattern) + _SuffixName);
            AngleStepMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(AngleStepMode) + _SuffixName);
            AngleStepValue.rtcValue = CommonData.GetDefaultValues_Double(nameof(AngleStepValue) + _SuffixName);
            PossibleScaling.rtcValue = CommonData.GetDefaultValues_Text(nameof(PossibleScaling) + _SuffixName);

            ScaleRangePattern.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ScaleRangePattern) + _SuffixName);
            ScaleStepMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(ScaleStepMode) + _SuffixName);
            TrainSubsamplingLevelMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(TrainSubsamplingLevelMode) + _SuffixName);
            TrainSubsamplingLevel.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(TrainSubsamplingLevel) + _SuffixName);
            Polarity.rtcValue = CommonData.GetDefaultValues_Text(nameof(Polarity) + _SuffixName);
            TrainOptimizationMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(TrainOptimizationMode) + _SuffixName);
            FindSubsamplingLevelMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(FindSubsamplingLevelMode) + _SuffixName);
            FindSubsamplingLevel.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(FindSubsamplingLevel) + _SuffixName);
            FindAngleRangeMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(FindAngleRangeMode) + _SuffixName);
            FindAngleRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(FindAngleRange) + _SuffixName);
            FindScaleRangeMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(FindScaleRangeMode) + _SuffixName);
            FindScaleRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(FindScaleRange) + _SuffixName);
            FindOptimizationLevel.rtcValue = CommonData.GetDefaultValues_Double(nameof(FindOptimizationLevel) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            TrainPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TrainPressed) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            MinSearchScore.rtcValue = CommonData.GetDefaultValues_Double(nameof(MinSearchScore) + _SuffixName);
            NumberToFindRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(NumberToFindRange) + _SuffixName);
            NumberToFindMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(NumberToFindMode) + _SuffixName);
            MaxDeformationInPixels.rtcValue = CommonData.GetDefaultValues_Int(nameof(MaxDeformationInPixels) + _SuffixName);
            MaxOverlap.rtcValue = CommonData.GetDefaultValues_Double(nameof(MaxOverlap) + _SuffixName);
            PositionAccuracy.rtcValue = CommonData.GetDefaultValues_Text(nameof(PositionAccuracy) + _SuffixName);
            CanTouchImageBorder.rtcValue = CommonData.GetDefaultValues_Bool(nameof(CanTouchImageBorder) + _SuffixName);
            EnableToolTimeOut.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableToolTimeOut) + _SuffixName);
            ToolTimeOut.rtcValue = CommonData.GetDefaultValues_Int(nameof(ToolTimeOut) + _SuffixName);
            InputTrained.rtcValue = CommonData.GetDefaultValues_Bool(nameof(InputTrained) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            InputModelID.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputModelID) + _SuffixName);
            ModelReferenceOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ModelReferenceOrigin) + _SuffixName);
            EnableAngleRangeCheck.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAngleRangeCheck) + _SuffixName);
            EnableColumnFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableColumnFilter) + _SuffixName);
            EnableRowFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableRowFilter) + _SuffixName);
            AngleRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AngleRange) + _SuffixName);
            RowRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RowRange) + _SuffixName);
            ColumnRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ColumnRange) + _SuffixName);
            ToolMasterOrigin.rtcValue = new List<double> { 0, 0, 0 };
            ShapeListOriginal.rtcValue = new List<object> { };
            FindShapeListOriginal.rtcValue = new List<object> { };
            Pattern_ROITrain_Find = true;
            RunWhenROIButtonClick = true;
        }

        public void SetupPropertyByBranchItem(bool isMultiBranch = false)
        {
            BranchItemType = new SString(CommonData.GetPropertyDescription(nameof(BranchItemType)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                true);
            BranchItemType.rtcValue = CommonData.GetDefaultValues_Text(nameof(BranchItemType) + _SuffixName);
            Description.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            Passed.rtcHidden = true;
            Enable.rtcHidden = true;
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByBranch()
        {
            Expression = new SString(CommonData.GetPropertyDescription(nameof(Expression)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            CalculateMode = new SString(CommonData.GetPropertyDescription(nameof(CalculateMode)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            Expression.rtcValue = CommonData.GetDefaultValues_Text(nameof(Expression) + _SuffixName);
            CalculateMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(CalculateMode) + _SuffixName);
            DisplayOutput.rtcHidden = true;
            RunIsSilent.rtcHidden = true;

            RunExpression();
        }

        private void RunExpression()
        {
            EExpressionResultTypes resultTypes = (ActionType == EActionTypes.Branch) ? EExpressionResultTypes.Boolean : EExpressionResultTypes.HTuple;
            if (this.MyExpression != null && this.MyExpression.ExpressionOrigin.Trim() != "")
                this.MyExpression.SetNewExpression(Expression.rtcValue, CalculateMode.rtcValue, resultTypes);
            else
                this.MyExpression = new cExpression(Expression.rtcValue, CalculateMode.rtcValue, resultTypes);
            if (ViewInfo != null)
                ((ucBaseActionDetail)ViewInfo).UpdateBranchOpennds();
        }
        public void SetupPropertyByHandeye()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            CameraType = new SString(CommonData.GetPropertyDescription(nameof(CameraType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None);
            HomMat_Image_To_World_Out = new SListDouble(CommonData.GetPropertyDescription(nameof(HomMat_Image_To_World_Out)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            HomMat_TCP_To_Tool_Out = new SListDouble(CommonData.GetPropertyDescription(nameof(HomMat_TCP_To_Tool_Out)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            HomMat_Tool_To_TCP_Out = new SListDouble(CommonData.GetPropertyDescription(nameof(HomMat_Tool_To_TCP_Out)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            HomMat_World_To_Image_Out = new SListDouble(CommonData.GetPropertyDescription(nameof(HomMat_World_To_Image_Out)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ListPointVision = new SListDouble(CommonData.GetPropertyDescription(nameof(ListPointVision)),
            EHTupleStyle.OriginList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ListPointRobot = new SListDouble(CommonData.GetPropertyDescription(nameof(ListPointRobot)),
            EHTupleStyle.OriginList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            UseRotatedPoints = new SString(CommonData.GetPropertyDescription(nameof(UseRotatedPoints)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            aOvr_Out = new SListDouble(CommonData.GetPropertyDescription(nameof(aOvr_Out)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            XOvr_Out = new SListDouble(CommonData.GetPropertyDescription(nameof(XOvr_Out)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            YOvr_Out = new SListDouble(CommonData.GetPropertyDescription(nameof(YOvr_Out)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);

            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            ListPointVision.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ListPointVision) + _SuffixName);
            ListPointRobot.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ListPointRobot) + _SuffixName);
            UseRotatedPoints.rtcValue = CommonData.GetDefaultValues_Text(nameof(UseRotatedPoints) + _SuffixName);

           


        }
        public void SetupPropertyByMath()
        {
            InputOne = new SListObject(CommonData.GetPropertyDescription(nameof(InputOne)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputTwo = new SListObject(CommonData.GetPropertyDescription(nameof(InputTwo)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputThree = new SListObject(CommonData.GetPropertyDescription(nameof(InputThree)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Operator = new SString(CommonData.GetPropertyDescription(nameof(Operator)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AbsoluteResult = new SBool(CommonData.GetPropertyDescription(nameof(AbsoluteResult)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Result = new SListObject(CommonData.GetPropertyDescription(nameof(Result)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputIndexOK = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputIndexOK)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputIndexNG = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputIndexNG)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Tolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(Tolerance)),
            EHTupleStyle.Tolerance,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            CalibrationScale = new SDouble(CommonData.GetPropertyDescription(nameof(CalibrationScale)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            RoundResult = new SBool(CommonData.GetPropertyDescription(nameof(RoundResult)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RoundFactor = new SListDouble(CommonData.GetPropertyDescription(nameof(RoundFactor)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            UseTolerance = new SBool(CommonData.GetPropertyDescription(nameof(UseTolerance)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AdvancedMathematicsMode = new SString(CommonData.GetPropertyDescription(nameof(AdvancedMathematicsMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SelectDataInteractionType = new SString(CommonData.GetPropertyDescription(nameof(SelectDataInteractionType)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ReplaceDataInteractionType = new SString(CommonData.GetPropertyDescription(nameof(ReplaceDataInteractionType)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MatchCase = new SBool(CommonData.GetPropertyDescription(nameof(MatchCase)),
            EHTupleStyle.None,
            EPropertyState.None);

            MatchCase.rtcValue = false;
            SelectDataInteractionType.rtcValue = CommonData.GetDefaultValues_Text(nameof(SelectDataInteractionType) + _SuffixName);
            ReplaceDataInteractionType.rtcValue = CommonData.GetDefaultValues_Text(nameof(ReplaceDataInteractionType) + _SuffixName);
            AdvancedMathematicsMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(AdvancedMathematicsMode) + _SuffixName);
            RoundResult.rtcValue = CommonData.GetDefaultValues_Bool(nameof(RoundResult) + _SuffixName);
            RoundFactor.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RoundFactor) + _SuffixName);
            UseTolerance.rtcValue = CommonData.GetDefaultValues_Bool(nameof(UseTolerance) + _SuffixName);
            InputOne.rtcValue = new List<object> { CommonData.GetDefaultValues_ListDouble(nameof(InputOne) + _SuffixName) };
            InputTwo.rtcValue = new List<object> { CommonData.GetDefaultValues_ListDouble(nameof(InputTwo) + _SuffixName) };
            Operator.rtcValue = CommonData.GetDefaultValues_Text(nameof(Operator) + _SuffixName);
            AbsoluteResult.rtcValue = CommonData.GetDefaultValues_Bool(nameof(AbsoluteResult) + _SuffixName);
            Tolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(Tolerance) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            CalibrationScale.rtcValue = 1;
        }
        public void SetupPropertyByDataInstance()
        {
            AppendMode = new SString(CommonData.GetPropertyDescription(nameof(AppendMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            DefaultValue = new SListString(CommonData.GetPropertyDescription(nameof(DefaultValue)),
            EHTupleStyle.ValueList,
            EPropertyState.Input);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.ValueList,
            EPropertyState.Input);
            //ModelContour = new SHXLDCont(CommonData.GetPropertyDescription(nameof(ModelContour)),
            //EHTupleStyle.None,
            //EPropertyState.Input);
            BlobList = new SListVector(CommonData.GetPropertyDescription(nameof(BlobList)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Distinct = new SBool(CommonData.GetPropertyDescription(nameof(Distinct)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ImageArray = new SListImage(CommonData.GetPropertyDescription(nameof(ImageArray)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            true);
            ValueCounterWhenAdd = new SLong(CommonData.GetPropertyDescription(nameof(ValueCounterWhenAdd)),
            EHTupleStyle.None,
            EPropertyState.Input);
            AppendMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(AppendMode) + _SuffixName);
            Distinct.rtcValue = false;
            DisplayOutput.rtcHidden = false;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByReturn()
        {
            ReturnMode = new SString(CommonData.GetPropertyDescription(nameof(ReturnMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ToolName = new SString(CommonData.GetPropertyDescription(nameof(ToolName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            NumberOfRun = new SInt(CommonData.GetPropertyDescription(nameof(NumberOfRun)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsUseNumberOfRun = new SBool(CommonData.GetPropertyDescription(nameof(IsUseNumberOfRun)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CurrentCount = new SInt(CommonData.GetPropertyDescription(nameof(CurrentCount)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ToolID = new SString(CommonData.GetPropertyDescription(nameof(ToolID)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);

            ReturnMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(ReturnMode) + _SuffixName);
            CurrentCount.rtcResetWhenStart = true;
            NumberOfRun.rtcValue = 1;
            CurrentCount.rtcValue = 0;
            IsUseNumberOfRun.rtcValue = false;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByRegionProcessing()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                    EHTupleStyle.None,
                    EPropertyState.Input);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            InputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(InputRegion)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(OutputRegion)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MorphologyType = new SString(CommonData.GetPropertyDescription(nameof(MorphologyType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Margin = new SString(CommonData.GetPropertyDescription(nameof(Margin)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Interations = new SInt(CommonData.GetPropertyDescription(nameof(Interations)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);

            MaskType = new SString(CommonData.GetPropertyDescription(nameof(MaskType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            //MaskAngle = new SDouble(CommonData.GetPropertyDescription(nameof(MaskAngle)),
            //EHTupleStyle.None,
            //EPropertyState.Input,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            MaskHeight = new SInt(CommonData.GetPropertyDescription(nameof(MaskHeight)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MaskRadius = new SDouble(CommonData.GetPropertyDescription(nameof(MaskRadius)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MaskWidth = new SInt(CommonData.GetPropertyDescription(nameof(MaskWidth)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RegionMath = new SString(CommonData.GetPropertyDescription(nameof(RegionMath)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
           
            //InputX = new SHTuple(CommonData.GetPropertyDescription(nameof(InputX)),
            //EHTupleStyle.ValueList,
            //EPropertyState.Input,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            //InputY = new SHTuple(CommonData.GetPropertyDescription(nameof(InputY)),
            //EHTupleStyle.ValueList,
            //EPropertyState.Input,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            //InputAngle = new SHTuple(CommonData.GetPropertyDescription(nameof(InputAngle)),
            //EHTupleStyle.ValueList,
            //EPropertyState.Input,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            //OutputX = new SHTuple(CommonData.GetPropertyDescription(nameof(OutputX)),
            //EHTupleStyle.ValueList,
            //EPropertyState.Output,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            //OutputY = new SHTuple(CommonData.GetPropertyDescription(nameof(OutputY)),
            //EHTupleStyle.ValueList,
            //EPropertyState.Output,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            OutputWidthList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputWidthList)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            //OutputAngleList = new SHTuple(CommonData.GetPropertyDescription(nameof(OutputAngleList)),
            //EHTupleStyle.ValueList,
            //EPropertyState.Output,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            OutputHeightList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputHeightList)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            //RevertAngle = new SBool(CommonData.GetPropertyDescription(nameof(RevertAngle)),
            //EHTupleStyle.None,
            //EPropertyState.Input,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            //UserOrigin = new SBool(CommonData.GetPropertyDescription(nameof(UserOrigin)),
            //EHTupleStyle.None,
            //EPropertyState.Input,
            //EROILegend.None,
            //false,
            //false,
            //false,
            //false);
            SortMode = new SString(CommonData.GetPropertyDescription(nameof(SortMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            OutputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(OutputBlobList)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);


            CenterPoint = new SListDouble(CommonData.GetPropertyDescription(nameof(CenterPoint)),
            EHTupleStyle.PointList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
           
            Expression = new SString(CommonData.GetPropertyDescription(nameof(Expression)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false);
            CalculateMode = new SString(CommonData.GetPropertyDescription(nameof(CalculateMode)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            true);

            CalculateMode.rtcValue = cCalculateMode.ByDataTable;

          

            RegionMath.rtcValue = CommonData.GetDefaultValues_Text(nameof(RegionMath) + _SuffixName);
            MorphologyType.rtcValue = CommonData.GetDefaultValues_Text(nameof(MorphologyType) + _SuffixName);
            Margin.rtcValue = CommonData.GetDefaultValues_Text(nameof(Margin) + _SuffixName);
            Interations.rtcValue = CommonData.GetDefaultValues_Int(nameof(Interations) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            MaskType.rtcValue = CommonData.GetDefaultValues_Text(nameof(MaskType) + _SuffixName);
            MaskHeight.rtcValue = CommonData.GetDefaultValues_Int(nameof(MaskHeight) + _SuffixName);
            MaskRadius.rtcValue = CommonData.GetDefaultValues_Double(nameof(MaskRadius) + _SuffixName);
            MaskWidth.rtcValue = CommonData.GetDefaultValues_Int(nameof(MaskWidth) + _SuffixName);
            //InputX.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(InputX) + _SuffixName);
            //InputY.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(InputY) + _SuffixName);
            //InputAngle.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(InputAngle) + _SuffixName);
            //RevertAngle.rtcValue = CommonData.GetDefaultValues_Bool(nameof(RevertAngle) + _SuffixName);
            //UserOrigin.rtcValue = CommonData.GetDefaultValues_Bool(nameof(UserOrigin) + _SuffixName);
            //Proc = new HDevProcedure(CommonData.GetProcedureName(_Name, _Name));
            //ProcCall = new HDevProcedureCall(Proc);
            RunExpression();
        }

        private void SetupPropertyByOrigin()
        {
            IsMultiROI = true;
            Origin_ROITrain_ROI = true;
            RequiredPass = new SBool(CommonData.GetPropertyDescription(nameof(RequiredPass)), EHTupleStyle.None, EPropertyState.None, EROILegend.None, false, true);
            RequiredPass.rtcValue = true;
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            ShapeListData = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListData)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            true);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            SamplingPercent = new SInt(CommonData.GetPropertyDescription(nameof(SamplingPercent)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EdgeType = new SString(CommonData.GetPropertyDescription(nameof(EdgeType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EdgeTransition = new SString(CommonData.GetPropertyDescription(nameof(EdgeTransition)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EdgeDetectionThreshold = new SInt(CommonData.GetPropertyDescription(nameof(EdgeDetectionThreshold)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SubpixelMethod = new SString(CommonData.GetPropertyDescription(nameof(SubpixelMethod)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ROILegend = new SString(CommonData.GetPropertyDescription(nameof(ROILegend)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OriginType = new SString(CommonData.GetPropertyDescription(nameof(OriginType)),
            EHTupleStyle.Pose,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ToolMasterOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolMasterOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            InputTrained = new SBool(CommonData.GetPropertyDescription(nameof(InputTrained)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            OutputTrained = new SBool(CommonData.GetPropertyDescription(nameof(OutputTrained)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            true,
            false,
            false);
            OutputMasterOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputMasterOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutPutBestOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(OutPutBestOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Output,
            EROILegend.OutputOriginRelativeToRCW,
            false,
            false,
            false,
            false);
            OutputOriginList = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputOriginList)),
            EHTupleStyle.OriginList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TrainPressed = new SBool(CommonData.GetPropertyDescription(nameof(TrainPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            ActualAngle = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualAngle)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ActualRow = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualRow)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ActualColumn = new SListDouble(CommonData.GetPropertyDescription(nameof(ActualColumn)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RowRange = new SListDouble(CommonData.GetPropertyDescription(nameof(RowRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ColumnRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableRowFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableRowFilter)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableColumnFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableColumnFilter)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EnableAngleRangeCheck = new SBool(CommonData.GetPropertyDescription(nameof(EnableAngleRangeCheck)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AngleRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AngleRange)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MinEdgePointNumber = new SInt(CommonData.GetPropertyDescription(nameof(MinEdgePointNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DefaultOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(DefaultOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            // OriginContour = new SHXLDCont(CommonData.GetPropertyDescription(nameof(OriginContour)),
            //EHTupleStyle.None,
            //EPropertyState.Output,
            //EROILegend.None,
            //false, false, true);
            OutlierDistanceThreshold = new SDouble(CommonData.GetPropertyDescription(nameof(OutlierDistanceThreshold)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            UseMasterOrigin = new SBool(CommonData.GetPropertyDescription(nameof(UseMasterOrigin)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            UseMasterOrigin.rtcValue = CommonData.GetDefaultValues_Bool(nameof(UseMasterOrigin) + _SuffixName);
            OutlierDistanceThreshold.rtcValue = CommonData.GetDefaultValues_Double(nameof(OutlierDistanceThreshold) + _SuffixName);
            //ShapeList.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeList) + _SuffixName);
            //ShapeListData.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeListData) + _SuffixName);
            //ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_HTuple(nameof(ShapeListOriginal) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            SamplingPercent.rtcValue = CommonData.GetDefaultValues_Int(nameof(SamplingPercent) + _SuffixName);
            EdgeType.rtcValue = CommonData.GetDefaultValues_Text(nameof(EdgeType) + _SuffixName);
            EdgeTransition.rtcValue = CommonData.GetDefaultValues_Text(nameof(EdgeTransition) + _SuffixName);
            EdgeDetectionThreshold.rtcValue = CommonData.GetDefaultValues_Int(nameof(EdgeDetectionThreshold) + _SuffixName);
            SubpixelMethod.rtcValue = CommonData.GetDefaultValues_Text(nameof(SubpixelMethod) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            ROILegend.rtcValue = CommonData.GetDefaultValues_Text(nameof(ROILegend) + _SuffixName);
            OriginType.rtcValue = CommonData.GetDefaultValues_Text(nameof(OriginType) + _SuffixName);
            ToolMasterOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolMasterOrigin) + _SuffixName);
            InputTrained.rtcValue = CommonData.GetDefaultValues_Bool(nameof(InputTrained) + _SuffixName);
            TrainPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TrainPressed) + _SuffixName);
            RowRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RowRange) + _SuffixName);
            ColumnRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ColumnRange) + _SuffixName);
            EnableRowFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableRowFilter) + _SuffixName);
            EnableColumnFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableColumnFilter) + _SuffixName);
            EnableAngleRangeCheck.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAngleRangeCheck) + _SuffixName);
            AngleRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AngleRange) + _SuffixName);
            MinEdgePointNumber.rtcValue = CommonData.GetDefaultValues_Int(nameof(MinEdgePointNumber) + _SuffixName);
            DefaultOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(DefaultOrigin) + _SuffixName);
          
        }

        private void SetupPropertyBySnapImage()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
           EHTupleStyle.None,
           EPropertyState.Input,
           EROILegend.None,
           true,
           false,
           true,
           false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsKeepImage = new SBool(CommonData.GetPropertyDescription(nameof(IsKeepImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsBringImageToMain = new SBool(CommonData.GetPropertyDescription(nameof(IsBringImageToMain)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            //IsSaveImage = new SBool(CommonData.GetPropertyDescription(nameof(IsSaveImage)),
            //EHTupleStyle.None,
            //EPropertyState.Input,
            //EROILegend.None,
            //false);
            //ImageTypes = new SString(CommonData.GetPropertyDescription(nameof(ImageTypes)),
            //EHTupleStyle.None,
            //EPropertyState.Input,
            //EROILegend.None,
            //false);
            SnapMode = new SString(CommonData.GetPropertyDescription(nameof(SnapMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            CameraMode = new SString(CommonData.GetPropertyDescription(nameof(CameraMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            InterfaceName = new SString(CommonData.GetPropertyDescription(nameof(InterfaceName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            DeviceName = new SString(CommonData.GetPropertyDescription(nameof(DeviceName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            DeviceNameOrigin = new SString(CommonData.GetPropertyDescription(nameof(DeviceNameOrigin)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            VendorName = new SString(CommonData.GetPropertyDescription(nameof(VendorName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            ProgramName = new SString(CommonData.GetPropertyDescription(nameof(ProgramName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            TemplateName = new SString(CommonData.GetPropertyDescription(nameof(TemplateName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            UseCameraSettings = new SBool(CommonData.GetPropertyDescription(nameof(UseCameraSettings)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            //ImageTypes.rtcValue = CommonData.GetDefaultValues_Text(nameof(ImageTypes) + _SuffixName);
            SnapMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SnapMode) + _SuffixName);
            CameraMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(CameraMode) + _SuffixName);
            IsKeepImage.rtcValue = false;
            IsBringImageToMain.rtcValue = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
        }
        public void SetupPropertyByDataSet()
        {
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            ImageArray = new SListImage(CommonData.GetPropertyDescription(nameof(ImageArray)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None);
            //ModelContour = new SHXLDCont(CommonData.GetPropertyDescription(nameof(ModelContour)),
            //EHTupleStyle.None,
            //EPropertyState.Input);
            BlobList = new SListVector(CommonData.GetPropertyDescription(nameof(BlobList)),
            EHTupleStyle.None,
            EPropertyState.Input);
            DestinationPort = new SListString(CommonData.GetPropertyDescription(nameof(DestinationPort)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false);
            ForceSetValueDataInstance = new SBool(CommonData.GetPropertyDescription(nameof(ForceSetValueDataInstance)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);

            Value.rtcIsReBinding = true;
            ImageArray.rtcIsReBinding = true;
            BlobList.rtcIsReBinding = true;
            ForceSetValueDataInstance.rtcValue = false;
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
        }
        public void SetupPropertyBySaveImage()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsUseProjectFolder = new SBool(CommonData.GetPropertyDescription(nameof(IsUseProjectFolder)),
            EHTupleStyle.None,
            EPropertyState.Input);
            FolderName = new SString(CommonData.GetPropertyDescription(nameof(FolderName)),
            EHTupleStyle.None,
            EPropertyState.Input);
            PrefixName = new SString(CommonData.GetPropertyDescription(nameof(PrefixName)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SuffixNameMode = new SString(CommonData.GetPropertyDescription(nameof(SuffixNameMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            StartNumber = new SInt(CommonData.GetPropertyDescription(nameof(StartNumber)),
            EHTupleStyle.None,
            EPropertyState.Input);
            MaxNumber = new SInt(CommonData.GetPropertyDescription(nameof(MaxNumber)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ResetNumber = new SInt(CommonData.GetPropertyDescription(nameof(ResetNumber)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsAutoResetWhenNewSession = new SBool(CommonData.GetPropertyDescription(nameof(IsAutoResetWhenNewSession)),
            EHTupleStyle.None,
            EPropertyState.Input);
            OverwriteWhenExists = new SBool(CommonData.GetPropertyDescription(nameof(OverwriteWhenExists)),
            EHTupleStyle.None,
            EPropertyState.Input);
            HostName = new SString(CommonData.GetPropertyDescription(nameof(HostName)),
            EHTupleStyle.None,
            EPropertyState.Input);
            UserName = new SString(CommonData.GetPropertyDescription(nameof(UserName)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Password = new SString(CommonData.GetPropertyDescription(nameof(Password)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ImageTypes = new SString(CommonData.GetPropertyDescription(nameof(ImageTypes)),
            EHTupleStyle.None,
            EPropertyState.Input);
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
            EHTupleStyle.None,
            EPropertyState.Input);
            OutputFileName = new SString(CommonData.GetPropertyDescription(nameof(OutputFileName)),
            EHTupleStyle.None,
            EPropertyState.Output);
            FixedFileName = new SBool(CommonData.GetPropertyDescription(nameof(FixedFileName)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SaveMode = new SString(CommonData.GetPropertyDescription(nameof(SaveMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            DateTimeFormat = new SString(CommonData.GetPropertyDescription(nameof(DateTimeFormat)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsSaveMyWindow = new SBool(CommonData.GetPropertyDescription(nameof(IsSaveMyWindow)),
            EHTupleStyle.None,
            EPropertyState.Input);
            AutoCreateFolderByDate = new SBool(CommonData.GetPropertyDescription(nameof(AutoCreateFolderByDate)),
            EHTupleStyle.None,
            EPropertyState.Input);
            DateFormat = new SString(CommonData.GetPropertyDescription(nameof(DateFormat)),
            EHTupleStyle.None,
            EPropertyState.Input);

            DateTimeFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateTimeFormat) + _SuffixName);
            DateFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateFormat) + _SuffixName);
            SuffixNameMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SuffixNameMode) + _SuffixName);
            ImageTypes.rtcValue = CommonData.GetDefaultValues_Text(nameof(ImageTypes) + _SuffixName);
            SaveMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SaveMode) + _SuffixName);
            FixedFileName.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FixedFileName) + _SuffixName);
            IsUseProjectFolder.rtcValue = CommonData.GetDefaultValues_Bool(nameof(IsUseProjectFolder) + _SuffixName); ;
            StartNumber.rtcValue = 0;
            MaxNumber.rtcValue = 0;
            ResetNumber.rtcValue = 0;
            OverwriteWhenExists.rtcValue = true;
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;
        }
        public void SetupPropertyByLoadImage()
        {
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false);
            IsKeepImage = new SBool(CommonData.GetPropertyDescription(nameof(IsKeepImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsBringImageToMain = new SBool(CommonData.GetPropertyDescription(nameof(IsBringImageToMain)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            OutputImage = new SImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);

            DisplayOutput.rtcHidden = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByCsvWrite()
        {
            IsUseProjectFolder = new SBool(CommonData.GetPropertyDescription(nameof(IsUseProjectFolder)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            FolderName = new SString(CommonData.GetPropertyDescription(nameof(FolderName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            WriteMode = new SString(CommonData.GetPropertyDescription(nameof(WriteMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PrefixName = new SString(CommonData.GetPropertyDescription(nameof(PrefixName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SuffixNameMode = new SString(CommonData.GetPropertyDescription(nameof(SuffixNameMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            StartNumber = new SInt(CommonData.GetPropertyDescription(nameof(StartNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MaxNumber = new SInt(CommonData.GetPropertyDescription(nameof(MaxNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ResetNumber = new SInt(CommonData.GetPropertyDescription(nameof(ResetNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsAutoResetWhenNewSession = new SBool(CommonData.GetPropertyDescription(nameof(IsAutoResetWhenNewSession)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            FixedFileName = new SBool(CommonData.GetPropertyDescription(nameof(FixedFileName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DateTimeFormat = new SString(CommonData.GetPropertyDescription(nameof(DateTimeFormat)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AutoCreateFolderByDate = new SBool(CommonData.GetPropertyDescription(nameof(AutoCreateFolderByDate)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DateFormat = new SString(CommonData.GetPropertyDescription(nameof(DateFormat)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputFileName = new SString(CommonData.GetPropertyDescription(nameof(OutputFileName)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Separator = new SString(CommonData.GetPropertyDescription(nameof(Separator)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Separator.rtcValue = CommonData.GetDefaultValues_Text(nameof(Separator) + _SuffixName);
            WriteMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WriteMode) + _SuffixName);
            MaxNumber.rtcValue = CommonData.GetDefaultValues_Int(nameof(MaxNumber) + _SuffixName);
            SuffixNameMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SuffixNameMode) + _SuffixName);
            DateTimeFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateTimeFormat) + _SuffixName);
            FixedFileName.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FixedFileName) + _SuffixName);
            DateFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateFormat) + _SuffixName);
            IsUseProjectFolder.rtcValue = CommonData.GetDefaultValues_Bool(nameof(IsUseProjectFolder) + _SuffixName); ;
            StartNumber.rtcValue = 0;
            ResetNumber.rtcValue = 0;

            Columns = new List<cColumnProperty>();

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByExcelWrite()
        {
            IsUseProjectFolder = new SBool(CommonData.GetPropertyDescription(nameof(IsUseProjectFolder)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            FolderName = new SString(CommonData.GetPropertyDescription(nameof(FolderName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            WriteMode = new SString(CommonData.GetPropertyDescription(nameof(WriteMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PrefixName = new SString(CommonData.GetPropertyDescription(nameof(PrefixName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SuffixNameMode = new SString(CommonData.GetPropertyDescription(nameof(SuffixNameMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            StartNumber = new SInt(CommonData.GetPropertyDescription(nameof(StartNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MaxNumber = new SInt(CommonData.GetPropertyDescription(nameof(MaxNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ResetNumber = new SInt(CommonData.GetPropertyDescription(nameof(ResetNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            IsAutoResetWhenNewSession = new SBool(CommonData.GetPropertyDescription(nameof(IsAutoResetWhenNewSession)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            FixedFileName = new SBool(CommonData.GetPropertyDescription(nameof(FixedFileName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DateTimeFormat = new SString(CommonData.GetPropertyDescription(nameof(DateTimeFormat)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AutoCreateFolderByDate = new SBool(CommonData.GetPropertyDescription(nameof(AutoCreateFolderByDate)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DateFormat = new SString(CommonData.GetPropertyDescription(nameof(DateFormat)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputFileName = new SString(CommonData.GetPropertyDescription(nameof(OutputFileName)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);

            WriteMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WriteMode) + _SuffixName);
            MaxNumber.rtcValue = CommonData.GetDefaultValues_Int(nameof(MaxNumber) + _SuffixName);
            SuffixNameMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SuffixNameMode) + _SuffixName);
            DateTimeFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateTimeFormat) + _SuffixName);
            FixedFileName.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FixedFileName) + _SuffixName);
            DateFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateFormat) + _SuffixName);
            IsUseProjectFolder.rtcValue = CommonData.GetDefaultValues_Bool(nameof(IsUseProjectFolder) + _SuffixName); ;
            StartNumber.rtcValue = 0;
            ResetNumber.rtcValue = 0;

            Columns = new List<cColumnProperty>();

            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByRunProgram()
        {
            ProgramName = new SString(CommonData.GetPropertyDescription(nameof(ProgramName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            RunMode = new SString(CommonData.GetPropertyDescription(nameof(RunMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false);
            IsRunning = new SBool(CommonData.GetPropertyDescription(nameof(IsRunning)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false);
            ResultOK = new SBool(CommonData.GetPropertyDescription(nameof(ResultOK)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false);
            IsRunByRunOrder = new SBool(CommonData.GetPropertyDescription(nameof(IsRunByRunOrder)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false);
            RunOrderCams = new SListDouble(CommonData.GetPropertyDescription(nameof(RunOrderCams)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false);
            RunMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(RunMode) + _SuffixName);
            ResultOK.rtcValue = false;
            IsRunByRunOrder.rtcValue = false;
            IsRunOneTime.rtcValue = false;
            IsRunning.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
        }
        public void SetupPropertyByLinkValue()
        {
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;

            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
        }
        public void SetupPropertyByChangeJob()

        {
            ProjectName = new SString(CommonData.GetPropertyDescription(nameof(ProjectName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            AutoStart = new SBool(CommonData.GetPropertyDescription(nameof(AutoStart)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            IsUsingOrderNumber = new SBool(CommonData.GetPropertyDescription(nameof(IsUsingOrderNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            OrderNumber = new SInt(CommonData.GetPropertyDescription(nameof(OrderNumber)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            OrderNumber.rtcValue = 0;
            AutoStart.rtcValue = true;
            IsUsingOrderNumber.rtcValue = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByMXComponentWrite()
        {
            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
                EHTupleStyle.None,
                EPropertyState.Input);
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
                EHTupleStyle.None,
                EPropertyState.Input);
            WaitMode = new SString(CommonData.GetPropertyDescription(nameof(WaitMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ValueAfterDelay = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterDelay)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ValueAfterStop = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterStop)),
                EHTupleStyle.None,
                EPropertyState.Output);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsAliveControl = new SBool(CommonData.GetPropertyDescription(nameof(IsAliveControl)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output);
            LogicalStationNumber = new SInt(CommonData.GetPropertyDescription(nameof(LogicalStationNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);

            LogicalStationNumber.rtcValue = 1;
            TimeDelay.rtcValue = 0;
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            IsCompareValue.rtcValue = false;
            IsAliveControl.rtcValue = false;
            WaitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WaitMode) + _SuffixName);
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
            GroupType = EGroupTypes.Communication;
        }
        public void SetupPropertyByMXComponentRead()
        {
            Address = new SString(CommonData.GetPropertyDescription(nameof(Address)),
                EHTupleStyle.None,
                EPropertyState.Input);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Output);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input);
            LogicalStationNumber = new SInt(CommonData.GetPropertyDescription(nameof(LogicalStationNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            LogicalStationNumber.rtcValue = 1;
            IsCompareValue.rtcValue = false;
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
            GroupType = EGroupTypes.Communication;
        }
        public void SetupPropertyByClearWindow()
        {
            IsAllWindows = new SBool(CommonData.GetPropertyDescription(nameof(IsAllWindows)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsRunByRunOrder = new SBool(CommonData.GetPropertyDescription(nameof(IsRunByRunOrder)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ProgramName = new SString(CommonData.GetPropertyDescription(nameof(ProgramName)),
               EHTupleStyle.None,
               EPropertyState.Input);
            RunOrderCams = new SListDouble(CommonData.GetPropertyDescription(nameof(RunOrderCams)),
                EHTupleStyle.ValueList,
                EPropertyState.Input);
            RunMode = new SString(CommonData.GetPropertyDescription(nameof(RunMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(RunMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output);
            RunMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(RunMode) + _SuffixName);
            IsAllWindows.rtcValue = CommonData.GetDefaultValues_Bool(nameof(IsAllWindows) + _SuffixName);
            IsRunByRunOrder.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
        }
        public void SetupPropertyByCycleTimeStart()
        {
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByCycleTimeStop()
        {
            ElapsedTime = new SDouble(CommonData.GetPropertyDescription(nameof(ElapsedTime)),
                EHTupleStyle.None,
                EPropertyState.Output);
            IsSaveDetailCycleTimeToFile = new SBool(CommonData.GetPropertyDescription(nameof(IsSaveDetailCycleTimeToFile)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsSaveDetailToOneFile = new SBool(CommonData.GetPropertyDescription(nameof(IsSaveDetailToOneFile)),
                EHTupleStyle.None,
                EPropertyState.Input);
            SegmentText = new SString(CommonData.GetPropertyDescription(nameof(SegmentText)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ElapsedTime.rtcValue = 0;
            IsSaveDetailCycleTimeToFile.rtcValue = false;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByDetectFileStatus()
        {
            FolderName = new SString(CommonData.GetPropertyDescription(nameof(FolderName)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None);
            IncludeSubdirectories = new SBool(CommonData.GetPropertyDescription(nameof(IncludeSubdirectories)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None);
            IsChanged = new SBool(CommonData.GetPropertyDescription(nameof(IsChanged)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None);
            IsCreated = new SBool(CommonData.GetPropertyDescription(nameof(IsCreated)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None);
            IsRenamed = new SBool(CommonData.GetPropertyDescription(nameof(IsRenamed)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None);
            IsDeleted = new SBool(CommonData.GetPropertyDescription(nameof(IsDeleted)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None);
            Filter = new SString(CommonData.GetPropertyDescription(nameof(Filter)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None);
            OldFileName = new SString(CommonData.GetPropertyDescription(nameof(OldFileName)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None);
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None);
            OldFullPath = new SString(CommonData.GetPropertyDescription(nameof(OldFullPath)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None);
            FullPath = new SString(CommonData.GetPropertyDescription(nameof(FullPath)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None);
            Status = new SString(CommonData.GetPropertyDescription(nameof(Status)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None);
            IsRunning = new SBool(CommonData.GetPropertyDescription(nameof(IsRunning)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None);

            FileName.rtcResetWhenStart = true;
            OldFileName.rtcResetWhenStart = true;
            OldFullPath.rtcResetWhenStart = true;
            FullPath.rtcResetWhenStart = true;
            Status.rtcResetWhenStart = true;
            IsRunning.rtcResetWhenStart = true;

            Filter.rtcValue = cStrings.FilterAllFile;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByRunCommand()
        {
            Command = new SString(CommonData.GetPropertyDescription(nameof(Command)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Arguments = new SString(CommonData.GetPropertyDescription(nameof(Arguments)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsCreateNoWindow = new SBool(CommonData.GetPropertyDescription(nameof(IsCreateNoWindow)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            WindowStyle = new SString(CommonData.GetPropertyDescription(nameof(WindowStyle)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                false);
            WindowStyle.rtcValue = CommonData.GetDefaultValues_Text(nameof(WindowStyle) + _SuffixName);
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByStringBuilder()
        {
            LeadingText = new SString(CommonData.GetPropertyDescription(nameof(LeadingText)),
            EHTupleStyle.None, EPropertyState.Input,
            EROILegend.None, false, false, false, false);
            TrallingText = new SString(CommonData.GetPropertyDescription(nameof(TrallingText)),
            EHTupleStyle.None, EPropertyState.Input,
            EROILegend.None, false, false, false, false);
            DelimiterType = new SInt(CommonData.GetPropertyDescription(nameof(DelimiterType)),
            EHTupleStyle.None, EPropertyState.Input,
            EROILegend.None, false, false, false, false);
            Terminator = new SInt(CommonData.GetPropertyDescription(nameof(Terminator)),
            EHTupleStyle.None, EPropertyState.Input,
            EROILegend.None, false, false, false, false);
            DelimiterStandard = new SInt(CommonData.GetPropertyDescription(nameof(DelimiterStandard)),
            EHTupleStyle.None, EPropertyState.Input,
            EROILegend.None, false, false, false, false);
            DelimiterCustom = new SString(CommonData.GetPropertyDescription(nameof(DelimiterCustom)),
            EHTupleStyle.None, EPropertyState.Input,
            EROILegend.None, false, false, false, false);
            DecimalSeparator = new SInt(CommonData.GetPropertyDescription(nameof(DecimalSeparator)),
            EHTupleStyle.None, EPropertyState.Input,
            EROILegend.None, false, false, false, false);

            OutputHeaderString = new SString(CommonData.GetPropertyDescription(nameof(OutputHeaderString)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None, false, false, false, false);

            OutputString = new SString(CommonData.GetPropertyDescription(nameof(OutputString)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None, false, false, false, false);

            OutputDataList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputDataList)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None, false, false, false, false);

            OutputStringSend = new SString(CommonData.GetPropertyDescription(nameof(OutputStringSend)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None, false, false, false, false);

            StringBuilders = new List<SStringBuilderItem>();

            LeadingText.rtcValue = string.Empty;
            TrallingText.rtcValue = string.Empty;

            OutputStringSend.rtcValue = string.Empty;
            OutputString.rtcValue = string.Empty;
            OutputHeaderString.rtcValue = string.Empty;

            Terminator.rtcValue = (int)ETermiator.None;

            DelimiterType.rtcValue = (int)EDelimiterTypes.Standard;
            DelimiterStandard.rtcValue = (int)EDelimiter.None;
            DelimiterCustom.rtcValue = string.Empty;
            DecimalSeparator.rtcValue = (int)EDecimalSeparator.Comma;
            AutoRun = false;
        }

        public void SetupPropertyByImageSplit()

        {
            AdaptImageSize = new SBool(CommonData.GetPropertyDescription(nameof(AdaptImageSize)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            SplitType = new SString(CommonData.GetPropertyDescription(nameof(SplitType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            FolderName = new SString(CommonData.GetPropertyDescription(nameof(FolderName)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SaveMode = new SString(CommonData.GetPropertyDescription(nameof(SaveMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ColumnNumber = new SListDouble(CommonData.GetPropertyDescription(nameof(ColumnNumber)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CurrentImageIndexOut = new SListDouble(CommonData.GetPropertyDescription(nameof(CurrentImageIndexOut)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CurrentImageIndex = new SListDouble(CommonData.GetPropertyDescription(nameof(CurrentImageIndex)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            RowNumber = new SListDouble(CommonData.GetPropertyDescription(nameof(RowNumber)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PreviousPressed = new SBool(CommonData.GetPropertyDescription(nameof(PreviousPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            NextPressed = new SBool(CommonData.GetPropertyDescription(nameof(NextPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            InputRegion = new SListVector(CommonData.GetPropertyDescription(nameof(InputRegion)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ShapeListROIType = new SString(CommonData.GetPropertyDescription(nameof(ShapeListROIType)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputImage = new SImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
              EHTupleStyle.None,
              EPropertyState.Output,
              EROILegend.None,
              false,
              false,
              false,
              false);
            OutputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            SaveMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SaveMode) + _SuffixName);
            AdaptImageSize.rtcValue = CommonData.GetDefaultValues_Bool(nameof(AdaptImageSize) + _SuffixName);
            AdaptImageSize.rtcValue = CommonData.GetDefaultValues_Bool(nameof(AdaptImageSize) + _SuffixName);
            ShapeList.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(ShapeList) + _SuffixName);
            ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(ShapeListOriginal) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            SplitType.rtcValue = CommonData.GetDefaultValues_Text(nameof(SplitType) + _SuffixName);
            ColumnNumber.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ColumnNumber) + _SuffixName);
            CurrentImageIndex.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(CurrentImageIndex) + _SuffixName);
            RowNumber.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RowNumber) + _SuffixName);
            PreviousPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(PreviousPressed) + _SuffixName);
            NextPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(NextPressed) + _SuffixName);
            NextPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(NextPressed) + _SuffixName);
            ShapeListROIType.rtcValue = CommonData.GetDefaultValues_Text(nameof(ShapeListROIType) + _SuffixName);
            AutoRun = false;
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            //Proc = new HDevProcedure(CommonData.GetProcedureName(_Name, _Name));
            //ProcCall = new HDevProcedureCall(Proc);
        }
        public void SetupPropertyBySaveProject()
        {
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByDialogMessage()
        {
            DialogType = new SString(CommonData.GetPropertyDescription(nameof(DialogType)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            MessageBoxButtons = new SString(CommonData.GetPropertyDescription(nameof(MessageBoxButtons)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            DialogCaption = new SString(CommonData.GetPropertyDescription(nameof(DialogCaption)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Message = new SString(CommonData.GetPropertyDescription(nameof(Message)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            YesButtonCaption = new SString(CommonData.GetPropertyDescription(nameof(YesButtonCaption)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            NoButtonCaption = new SString(CommonData.GetPropertyDescription(nameof(NoButtonCaption)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            CancelButtonCaption = new SString(CommonData.GetPropertyDescription(nameof(CancelButtonCaption)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            DialogResult = new SString(CommonData.GetPropertyDescription(nameof(DialogResult)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                false);
            DialogResultI = new SInt(CommonData.GetPropertyDescription(nameof(DialogResultI)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            Position = new SString(CommonData.GetPropertyDescription(nameof(Position)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            IsShowDialogMode = new SBool(CommonData.GetPropertyDescription(nameof(IsShowDialogMode)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            WidthForm = new SInt(CommonData.GetPropertyDescription(nameof(WidthForm)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            HeightForm = new SInt(CommonData.GetPropertyDescription(nameof(HeightForm)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsAutoClose = new SBool(CommonData.GetPropertyDescription(nameof(IsAutoClose)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            AutoCloseWaitTime = new SInt(CommonData.GetPropertyDescription(nameof(AutoCloseWaitTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            IsAutoClose.rtcValue = false;
            AutoCloseWaitTime.rtcValue = CommonData.GetDefaultValues_Int(nameof(AutoCloseWaitTime) + _SuffixName);
            WidthForm.rtcValue = 400;
            HeightForm.rtcValue = 180;

            Position.rtcValue = CommonData.GetDefaultValues_Text(nameof(Position) + _SuffixName);
            DialogType.rtcValue = CommonData.GetDefaultValues_Text(nameof(DialogType) + _SuffixName);
            MessageBoxButtons.rtcValue = CommonData.GetDefaultValues_Text(nameof(MessageBoxButtons) + _SuffixName);
            YesButtonCaption.rtcValue = cStrings.OK;
            NoButtonCaption.rtcValue = cStrings.No;
            CancelButtonCaption.rtcValue = cStrings.Cancel;
            IsShowDialogMode.rtcValue = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyBySendMessage()
        {
            Message = new SString(CommonData.GetPropertyDescription(nameof(Message)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            StatusType = new SString(CommonData.GetPropertyDescription(nameof(StatusType)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            CustomStatusType = new SString(CommonData.GetPropertyDescription(nameof(CustomStatusType)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            Destination = new SString(CommonData.GetPropertyDescription(nameof(Destination)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            StatusTypeConnect = new SString(CommonData.GetPropertyDescription(nameof(StatusTypeConnect)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            ModelInfor = new SString(CommonData.GetPropertyDescription(nameof(ModelInfor)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);

            StatusType.rtcValue = CommonData.GetDefaultValues_Text(nameof(StatusType) + _SuffixName);
            StatusTypeConnect.rtcValue = CommonData.GetDefaultValues_Text(nameof(StatusTypeConnect) + _SuffixName);
            ModelInfor.rtcValue = CommonData.GetDefaultValues_Text(nameof(ModelInfor) + _SuffixName);
            Destination.rtcValue = CommonData.GetDefaultValues_Text(nameof(Destination) + _SuffixName);
            IsRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;

        }
        public void SetupPropertyBySystemInfo()
        {
            StartupPath = new SString(CommonData.GetPropertyDescription(nameof(StartupPath)),
                EHTupleStyle.None,
                EPropertyState.Output);
            TemplatePath = new SString(CommonData.GetPropertyDescription(nameof(TemplatePath)),
                EHTupleStyle.None,
                EPropertyState.Output);
            ProjectPath = new SString(CommonData.GetPropertyDescription(nameof(ProjectPath)),
                EHTupleStyle.None,
                EPropertyState.Output);
            ModelPath = new SString(CommonData.GetPropertyDescription(nameof(ModelPath)),
                EHTupleStyle.None,
                EPropertyState.Output);
            WindowPath_Origin = new SString(CommonData.GetPropertyDescription(nameof(WindowPath_Origin)),
                EHTupleStyle.None,
                EPropertyState.Output);
            WindowPath_Snap = new SString(CommonData.GetPropertyDescription(nameof(WindowPath_Snap)),
                EHTupleStyle.None,
                EPropertyState.Output);
            WindowPath_Passed = new SString(CommonData.GetPropertyDescription(nameof(WindowPath_Passed)),
                EHTupleStyle.None,
                EPropertyState.Output);
            WindowPath_Failed = new SString(CommonData.GetPropertyDescription(nameof(WindowPath_Failed)),
                EHTupleStyle.None,
                EPropertyState.Output);
            WindowPath_File = new SString(CommonData.GetPropertyDescription(nameof(WindowPath_File)),
                EHTupleStyle.None,
                EPropertyState.Output);
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
                EHTupleStyle.None,
                EPropertyState.Output);
            ProjectName = new SString(CommonData.GetPropertyDescription(nameof(ProjectName)),
                EHTupleStyle.None,
                EPropertyState.Output);
            WindowName = new SString(CommonData.GetPropertyDescription(nameof(WindowName)),
                EHTupleStyle.None,
                EPropertyState.Output);
            CamModel = new SString(CommonData.GetPropertyDescription(nameof(CamModel)),
                EHTupleStyle.None,
                EPropertyState.Output);
            ExposureTime = new SInt(CommonData.GetPropertyDescription(nameof(ExposureTime)),
                EHTupleStyle.None,
                EPropertyState.Output);
            OrderNumber = new SInt(CommonData.GetPropertyDescription(nameof(CamModel)),
                EHTupleStyle.None,
                EPropertyState.Output);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output);
            DateFormat = new SString(CommonData.GetPropertyDescription(nameof(DateFormat)),
                EHTupleStyle.None,
                EPropertyState.Output);
            TimeFormat = new SString(CommonData.GetPropertyDescription(nameof(TimeFormat)),
                EHTupleStyle.None,
                EPropertyState.Output);
            CurrentDate = new SString(CommonData.GetPropertyDescription(nameof(CurrentDate)),
                EHTupleStyle.None,
                EPropertyState.Output);
            CurrentTime = new SString(CommonData.GetPropertyDescription(nameof(CurrentTime)),
                EHTupleStyle.None,
                EPropertyState.Output);

            DateFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateFormat) + _SuffixName);
            TimeFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(TimeFormat) + _SuffixName);
            CurrentDate.rtcValue = DateTime.Now.ToString(DateFormat.rtcValue);
            CurrentTime.rtcValue = DateTime.Now.ToString(TimeFormat.rtcValue);

            IsRunOneTime.rtcValue = true;
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;

            StartupPath.rtcValue = GlobVar.RTCVision.Paths.AppPath;
            ProjectPath.rtcValue = GlobVar.RTCVision.Paths.Projects;
            TemplatePath.rtcValue = GlobVar.RTCVision.Paths.Templates;

            if (GlobVar.CurrentProject != null)
            {
                ProjectName.rtcValue = GlobVar.CurrentProject.ProjectName;
                ModelPath.rtcValue = GlobVar.CurrentProject.FolderNameFullPath;
                FileName.rtcValue = GlobVar.CurrentProject.FileName;
                OrderNumber.rtcValue = GlobVar.CurrentProject.OrderNum;

                WindowPath_Origin.rtcValue = MyGroup.SourceImageSettings.CameraSettings.SaveImageFolder_Origin;
                WindowPath_Snap.rtcValue = MyGroup.SourceImageSettings.CameraSettings.SaveImageFolder_Snap;
                WindowPath_Passed.rtcValue = MyGroup.SourceImageSettings.CameraSettings.SaveImageFolder_Pass;
                WindowPath_Failed.rtcValue = MyGroup.SourceImageSettings.CameraSettings.SaveImageFolder_Fail;
                MyGroup.MyCam?.BuildDefaultFolderPath(GlobVar.CurrentProject.FolderNameFullPath);
                WindowPath_File.rtcValue = MyGroup.SaveFileFolder;
            }
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = true;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByOkNgCounter()
        {
            //CounterOK = new SString(CommonData.GetPropertyDescription(nameof(CounterOK)),
            //    EHTupleStyle.None,
            //    EPropertyState.Input);
            //CounterOK = new SString(CommonData.GetPropertyDescription(nameof(CounterOK)),
            //  EHTupleStyle.None,
            //  EPropertyState.Input);
            CounterType = new SString(CommonData.GetPropertyDescription(nameof(CounterNG)),
                EHTupleStyle.None,
                EPropertyState.Input);
            RunMode = new SString(CommonData.GetPropertyDescription(nameof(RunMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ProgramName = new SString(CommonData.GetPropertyDescription(nameof(ProgramName)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            //CounterOK.rtcValue = CommonData.GetDefaultValues_Text(nameof(CounterOK) + _SuffixName);
            //CounterNG.rtcValue = CommonData.GetDefaultValues_Text(nameof(CounterNG) + _SuffixName);
            CounterType.rtcValue = CommonData.GetDefaultValues_Text(nameof(CounterNG) + _SuffixName);
            RunMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(RunMode) + _SuffixName);
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByViewResult()
        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsMasterView = new SBool(CommonData.GetPropertyDescription(nameof(IsMasterView)),
                EHTupleStyle.None,
            EPropertyState.Input);
            ViewIn = new SString(CommonData.GetPropertyDescription(nameof(ViewIn)),
            EHTupleStyle.None,
                EPropertyState.Input);
            ProgramName = new SString(CommonData.GetPropertyDescription(nameof(ProgramName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ProgramID = new SString(CommonData.GetPropertyDescription(nameof(ProgramID)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResultMode = new SString(CommonData.GetPropertyDescription(nameof(ResultMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResultOK = new SBool(CommonData.GetPropertyDescription(nameof(ResultOK)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsRunByRunOrder = new SBool(CommonData.GetPropertyDescription(nameof(IsRunByRunOrder)),
                EHTupleStyle.None,
                EPropertyState.Input);
            RunOrder = new SInt(CommonData.GetPropertyDescription(nameof(RunOrder)),
                EHTupleStyle.None,
                EPropertyState.Input);

            IsSaveGraphicWindow = new SBool(CommonData.GetPropertyDescription(nameof(IsSaveGraphicWindow)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsSaveScreenshot = new SBool(CommonData.GetPropertyDescription(nameof(IsSaveScreenshot)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsSaveOriginImage = new SBool(CommonData.GetPropertyDescription(nameof(IsSaveOriginImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsResize = new SBool(CommonData.GetPropertyDescription(nameof(IsResize)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResizePercentage = new SInt(CommonData.GetPropertyDescription(nameof(ResizePercentage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ViewOKNG = new SString(CommonData.GetPropertyDescription(nameof(ViewOKNG)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResultOK = new SBool(CommonData.GetPropertyDescription(nameof(ResultOK)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OnlyNG = new SBool(CommonData.GetPropertyDescription(nameof(OnlyNG)),
                EHTupleStyle.None,
                EPropertyState.Input);

            IsUseProjectFolder = new SBool(CommonData.GetPropertyDescription(nameof(IsUseProjectFolder)),
                EHTupleStyle.None,
                EPropertyState.Input);
            FolderName = new SString(CommonData.GetPropertyDescription(nameof(FolderName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            PrefixName = new SString(CommonData.GetPropertyDescription(nameof(PrefixName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            SuffixNameMode = new SString(CommonData.GetPropertyDescription(nameof(SuffixNameMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            StartNumber = new SInt(CommonData.GetPropertyDescription(nameof(StartNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            MaxNumber = new SInt(CommonData.GetPropertyDescription(nameof(MaxNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResetNumber = new SInt(CommonData.GetPropertyDescription(nameof(ResetNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsAutoResetWhenNewSession = new SBool(CommonData.GetPropertyDescription(nameof(IsAutoResetWhenNewSession)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OverwriteWhenExists = new SBool(CommonData.GetPropertyDescription(nameof(OverwriteWhenExists)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ImageTypes = new SString(CommonData.GetPropertyDescription(nameof(ImageTypes)),
               EHTupleStyle.None,
               EPropertyState.Input);
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
               EHTupleStyle.None,
               EPropertyState.Input);
            OutputFileName = new SString(CommonData.GetPropertyDescription(nameof(OutputFileName)),
               EHTupleStyle.None,
               EPropertyState.Input);
            OutputFileNameW = new SString(CommonData.GetPropertyDescription(nameof(OutputFileNameW)),
               EHTupleStyle.None,
               EPropertyState.Input);
            OutputFileNameS = new SString(CommonData.GetPropertyDescription(nameof(OutputFileNameS)),
               EHTupleStyle.None,
               EPropertyState.Input);
            DateTimeFormat = new SString(CommonData.GetPropertyDescription(nameof(DateTimeFormat)),
               EHTupleStyle.None,
               EPropertyState.Input);
            FixedFileName = new SBool(CommonData.GetPropertyDescription(nameof(FixedFileName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            AutoCreateFolderByDate = new SBool(CommonData.GetPropertyDescription(nameof(AutoCreateFolderByDate)),
                EHTupleStyle.None,
                EPropertyState.Input);
            DateFormat = new SString(CommonData.GetPropertyDescription(nameof(DateFormat)),
               EHTupleStyle.None,
               EPropertyState.Input);


            DateTimeFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateTimeFormat) + _SuffixName);
            DateFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateFormat) + _SuffixName);
            SuffixNameMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SuffixNameMode) + _SuffixName);
            ImageTypes.rtcValue = CommonData.GetDefaultValues_Text(nameof(ImageTypes) + _SuffixName);
            FixedFileName.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FixedFileName) + _SuffixName);
            IsUseProjectFolder.rtcValue = CommonData.GetDefaultValues_Bool(nameof(IsUseProjectFolder) + _SuffixName);
            ResizePercentage.rtcValue = 0;
            StartNumber.rtcValue = 0;
            ResetNumber.rtcValue = 0;
            OverwriteWhenExists.rtcValue = true;

            ViewIn.rtcValue = CommonData.GetDefaultValues_Text(nameof(ViewIn) + _SuffixName);
            ViewOKNG.rtcValue = CommonData.GetDefaultValues_Text(nameof(ViewOKNG) + _SuffixName);
            ResultMode.rtcValue = cResultMode.ByMainWindow;
            IsMasterView.rtcValue = true;
            OnlyNG.rtcValue = true;

            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByHookKeyboard()
        {
            CtrlKey = new SBool(CommonData.GetPropertyDescription(nameof(CtrlKey)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false);
            ShiftKey = new SBool(CommonData.GetPropertyDescription(nameof(ShiftKey)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false);
            AltKey = new SBool(CommonData.GetPropertyDescription(nameof(AltKey)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false);
            WindowKey = new SBool(CommonData.GetPropertyDescription(nameof(WindowKey)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false);
            KeyValues = new SListString(CommonData.GetPropertyDescription(nameof(KeyValues)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByWait()
        {
            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);

            TimeDelay.rtcValue = CommonData.GetDefaultValues_Int(nameof(TimeDelay) + _SuffixName);
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByStopProgram()
        {
            ProgramName = new SString(CommonData.GetPropertyDescription(nameof(ProgramName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            RunMode = new SString(CommonData.GetPropertyDescription(nameof(RunMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            NumberOfRuns = new SString(CommonData.GetPropertyDescription(nameof(NumberOfRuns)),
                EHTupleStyle.None,
                EPropertyState.Input);

            RunMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(RunMode) + _SuffixName);
            NumberOfRuns.rtcValue = CommonData.GetDefaultValues_Text(nameof(NumberOfRuns) + _SuffixName);
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
        }
        public void SetupPropertyByStop()
        {
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByLoadConfig()
        {
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                            EHTupleStyle.None,
                            EPropertyState.Output,
                            EROILegend.None,
                            false);
            DisplayOutput.rtcHidden = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenROIButtonClick = false;
            AutoRun = false;

        }
        public void SetupPropertyBySaveConfig()
        {
            InputObject = new SObject(CommonData.GetPropertyDescription(nameof(InputObject)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsUseProjectFolder = new SBool(CommonData.GetPropertyDescription(nameof(IsUseProjectFolder)),
                EHTupleStyle.None,
                EPropertyState.Input);
            FolderName = new SString(CommonData.GetPropertyDescription(nameof(FolderName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            PrefixName = new SString(CommonData.GetPropertyDescription(nameof(PrefixName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            SuffixNameMode = new SString(CommonData.GetPropertyDescription(nameof(SuffixNameMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            StartNumber = new SInt(CommonData.GetPropertyDescription(nameof(StartNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            MaxNumber = new SInt(CommonData.GetPropertyDescription(nameof(MaxNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResetNumber = new SInt(CommonData.GetPropertyDescription(nameof(ResetNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsAutoResetWhenNewSession = new SBool(CommonData.GetPropertyDescription(nameof(IsAutoResetWhenNewSession)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OverwriteWhenExists = new SBool(CommonData.GetPropertyDescription(nameof(OverwriteWhenExists)),
                EHTupleStyle.None,
                EPropertyState.Input);
            HostName = new SString(CommonData.GetPropertyDescription(nameof(HostName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            UserName = new SString(CommonData.GetPropertyDescription(nameof(UserName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            Password = new SString(CommonData.GetPropertyDescription(nameof(Password)),
                EHTupleStyle.None,
                EPropertyState.Input);
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OutputFileName = new SString(CommonData.GetPropertyDescription(nameof(OutputFileName)),
                EHTupleStyle.None,
                EPropertyState.Output);
            FixedFileName = new SBool(CommonData.GetPropertyDescription(nameof(FixedFileName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            SaveMode = new SString(CommonData.GetPropertyDescription(nameof(SaveMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            DateTimeFormat = new SString(CommonData.GetPropertyDescription(nameof(DateTimeFormat)),
                EHTupleStyle.None,
                EPropertyState.Input);
            AutoCreateFolderByDate = new SBool(CommonData.GetPropertyDescription(nameof(AutoCreateFolderByDate)),
                EHTupleStyle.None,
                EPropertyState.Input);
            DateFormat = new SString(CommonData.GetPropertyDescription(nameof(DateFormat)),
                EHTupleStyle.None,
                EPropertyState.Input);


            DateTimeFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateTimeFormat) + _SuffixName);
            SuffixNameMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SuffixNameMode) + _SuffixName);
            SaveMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SaveMode) + _SuffixName);
            FixedFileName.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FixedFileName) + _SuffixName);
            IsUseProjectFolder.rtcValue = CommonData.GetDefaultValues_Bool(nameof(IsUseProjectFolder) + _SuffixName);
            StartNumber.rtcValue = 0;
            MaxNumber.rtcValue = 0;
            ResetNumber.rtcValue = 0;
            OverwriteWhenExists.rtcValue = true;
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;


        }
        public void SetupPropertyByCount()
        {
            StartNumber = new SInt(CommonData.GetPropertyDescription(nameof(StartNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            StartNumber.rtcIsHotLink = true;
            Step = new SInt(CommonData.GetPropertyDescription(nameof(Step)),
                EHTupleStyle.None,
                EPropertyState.Input);
            FailNumber = new SInt(CommonData.GetPropertyDescription(nameof(FailNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            NumberBeginRestart = new SInt(CommonData.GetPropertyDescription(nameof(NumberBeginRestart)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResetNumber = new SInt(CommonData.GetPropertyDescription(nameof(ResetNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResetNumberWhenNewDay = new SBool(CommonData.GetPropertyDescription(nameof(ResetNumberWhenNewDay)),
                EHTupleStyle.None,
                EPropertyState.Input);
            KeepValueToNextSession = new SBool(CommonData.GetPropertyDescription(nameof(KeepValueToNextSession)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OldDay = new SString(CommonData.GetPropertyDescription(nameof(OldDay)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None, true, true);

            StartNumber.rtcValue = CommonData.GetDefaultValues_Int(nameof(StartNumber) + _SuffixName);
            Step.rtcValue = CommonData.GetDefaultValues_Int(nameof(Step) + _SuffixName);
            ResetNumber.rtcValue = CommonData.GetDefaultValues_Int(nameof(ResetNumber) + _SuffixName);
            NumberBeginRestart.rtcValue = CommonData.GetDefaultValues_Int(nameof(NumberBeginRestart) + _SuffixName);
            FailNumber.rtcValue = CommonData.GetDefaultValues_Int(nameof(FailNumber) + _SuffixName);
            KeepValueToNextSession.rtcValue = false;
            ResetNumberWhenNewDay.rtcValue = false;
            OldDay.rtcValue = DateTime.Now.ToString(cDateTimeFormats.yyyyMMdd);
            RunWhenROIButtonClick = false;
            RunWhenPassFailButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByScript()
        {
            Expression = new SString(CommonData.GetPropertyDescription(nameof(Expression)),
                EHTupleStyle.None,
                EPropertyState.Input);
            CalculateMode = new SString(CommonData.GetPropertyDescription(nameof(CalculateMode)),
                EHTupleStyle.None,
                EPropertyState.Input);

            Expression.rtcValue = CommonData.GetDefaultValues_Text(nameof(Expression) + _SuffixName);
            CalculateMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(CalculateMode) + _SuffixName);
            CalculateMode.rtcHidden = true;
            DisplayOutput.rtcHidden = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunExpresion();

        }
        public void SetupPropertyBySaveObject()
        {
            InputObject = new SObject(CommonData.GetPropertyDescription(nameof(InputObject)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsUseProjectFolder = new SBool(CommonData.GetPropertyDescription(nameof(IsUseProjectFolder)),
                EHTupleStyle.None,
                EPropertyState.Input);
            FolderName = new SString(CommonData.GetPropertyDescription(nameof(FolderName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            PrefixName = new SString(CommonData.GetPropertyDescription(nameof(PrefixName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            SuffixNameMode = new SString(CommonData.GetPropertyDescription(nameof(SuffixNameMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            StartNumber = new SInt(CommonData.GetPropertyDescription(nameof(StartNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            MaxNumber = new SInt(CommonData.GetPropertyDescription(nameof(MaxNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ResetNumber = new SInt(CommonData.GetPropertyDescription(nameof(ResetNumber)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsAutoResetWhenNewSession = new SBool(CommonData.GetPropertyDescription(nameof(IsAutoResetWhenNewSession)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OverwriteWhenExists = new SBool(CommonData.GetPropertyDescription(nameof(OverwriteWhenExists)),
                EHTupleStyle.None,
                EPropertyState.Input);
            HostName = new SString(CommonData.GetPropertyDescription(nameof(HostName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            UserName = new SString(CommonData.GetPropertyDescription(nameof(UserName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            Password = new SString(CommonData.GetPropertyDescription(nameof(Password)),
                EHTupleStyle.None,
                EPropertyState.Input);
            FileName = new SString(CommonData.GetPropertyDescription(nameof(FileName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            OutputFileName = new SString(CommonData.GetPropertyDescription(nameof(OutputFileName)),
                EHTupleStyle.None,
                EPropertyState.Output);
            FixedFileName = new SBool(CommonData.GetPropertyDescription(nameof(FixedFileName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            SaveMode = new SString(CommonData.GetPropertyDescription(nameof(SaveMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            DateTimeFormat = new SString(CommonData.GetPropertyDescription(nameof(DateTimeFormat)),
                EHTupleStyle.None,
                EPropertyState.Input);

            AutoCreateFolderByDate = new SBool(CommonData.GetPropertyDescription(nameof(AutoCreateFolderByDate)),
                EHTupleStyle.None,
                EPropertyState.Input);
            DateFormat = new SString(CommonData.GetPropertyDescription(nameof(DateFormat)),
                EHTupleStyle.None,
                EPropertyState.Input);


            DateTimeFormat.rtcValue = CommonData.GetDefaultValues_Text(nameof(DateTimeFormat) + _SuffixName);
            SuffixNameMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SuffixNameMode) + _SuffixName);
            SaveMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SaveMode) + _SuffixName);
            FixedFileName.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FixedFileName) + _SuffixName);
            IsUseProjectFolder.rtcValue = CommonData.GetDefaultValues_Bool(nameof(IsUseProjectFolder) + _SuffixName);
            StartNumber.rtcValue = 0;
            MaxNumber.rtcValue = 0;
            ResetNumber.rtcValue = 0;
            OverwriteWhenExists.rtcValue = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            AutoRun = false;
        }
        public void SetupPropertyByLiveCamera()
        {
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output);

            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByImageMath()

        {
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
              EHTupleStyle.None,
              EPropertyState.Input,
              EROILegend.None,
              false,
              false,
              false,
              false);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
             EHTupleStyle.None,
             EPropertyState.Input,
             EROILegend.None,
             false,
             false,
             false,
             false);

            OutputImage = new SImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
          EHTupleStyle.None,
          EPropertyState.Input,
          EROILegend.None,
          false,
          false,
          false,
          false);
            OutputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
             EHTupleStyle.None,
             EPropertyState.Input,
             EROILegend.None,
             false,
             false,
             false,
             false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            PreviousPressed = new SBool(CommonData.GetPropertyDescription(nameof(PreviousPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            NextPressed = new SBool(CommonData.GetPropertyDescription(nameof(NextPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            ScaleFactor = new SDouble(CommonData.GetPropertyDescription(nameof(ScaleFactor)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputImage2 = new SImage(CommonData.GetPropertyDescription(nameof(InputImage2)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputBgrImage2 = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage2)),
             EHTupleStyle.None,
             EPropertyState.Input,
             EROILegend.None,
             false,
             false,
             false,
             false);
            InputGrayImage2 = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage2)),
             EHTupleStyle.None,
             EPropertyState.Input,
             EROILegend.None,
             false,
             false,
             false,
             false);
            OffsetValue = new SListDouble(CommonData.GetPropertyDescription(nameof(OffsetValue)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ImageOperation = new SString(CommonData.GetPropertyDescription(nameof(ImageOperation)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);

            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            PreviousPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(PreviousPressed) + _SuffixName);
            NextPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(NextPressed) + _SuffixName);
            ScaleFactor.rtcValue = CommonData.GetDefaultValues_Double(nameof(ScaleFactor) + _SuffixName);
            ScaleFactor.rtcValue = CommonData.GetDefaultValues_Double(nameof(ScaleFactor) + _SuffixName);
            OffsetValue.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(OffsetValue) + _SuffixName);
            ImageOperation.rtcValue = CommonData.GetDefaultValues_Text(nameof(ImageOperation) + _SuffixName);

        }
        public void SetupPropertyByCodeReader()
        {
            IsMultiROI = true;
            RequiredPass = new SBool(CommonData.GetPropertyDescription(nameof(RequiredPass)), EHTupleStyle.None, EPropertyState.None, EROILegend.None, false, true);
            RequiredPass.rtcValue = true;
            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InSetOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(InSetOrigin)),
              EHTupleStyle.DoubleList,
              EPropertyState.Input,
              EROILegend.None,
              false,
              true,
              false,
              false);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
            EHTupleStyle.Origin,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Output,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            true,
            true,
            false,
            true);
            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
            EHTupleStyle.Regions,
            EPropertyState.Input,
            EROILegend.PrimaryRoi,
            false,
            false,
            false,
            true);
            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            true,
            true,
            false,
            false);
            TrainPressed = new SBool(CommonData.GetPropertyDescription(nameof(TrainPressed)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            InputString = new SString(CommonData.GetPropertyDescription(nameof(InputString)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Code = new SString(CommonData.GetPropertyDescription(nameof(Code)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Industrial25 = new SBool(CommonData.GetPropertyDescription(nameof(Industrial25)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Interleaved25 = new SBool(CommonData.GetPropertyDescription(nameof(Interleaved25)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CODABAR = new SBool(CommonData.GetPropertyDescription(nameof(CODABAR)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CODE_39 = new SBool(CommonData.GetPropertyDescription(nameof(CODE_39)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CODE_93 = new SBool(CommonData.GetPropertyDescription(nameof(CODE_93)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CODE_128 = new SBool(CommonData.GetPropertyDescription(nameof(CODE_128)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MSI = new SBool(CommonData.GetPropertyDescription(nameof(MSI)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PHARMA_CODE = new SBool(CommonData.GetPropertyDescription(nameof(PHARMA_CODE)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EAN_8 = new SBool(CommonData.GetPropertyDescription(nameof(EAN_8)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            EAN_13 = new SBool(CommonData.GetPropertyDescription(nameof(EAN_13)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            UPC_A = new SBool(CommonData.GetPropertyDescription(nameof(UPC_A)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            UPC_E = new SBool(CommonData.GetPropertyDescription(nameof(UPC_E)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            GS1128 = new SBool(CommonData.GetPropertyDescription(nameof(GS1128)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DATA_MATRIX = new SBool(CommonData.GetPropertyDescription(nameof(DATA_MATRIX)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            QR_CODE = new SBool(CommonData.GetPropertyDescription(nameof(QR_CODE)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MicroQRCode = new SBool(CommonData.GetPropertyDescription(nameof(MicroQRCode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            PDF_417 = new SBool(CommonData.GetPropertyDescription(nameof(PDF_417)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            AZTEC = new SBool(CommonData.GetPropertyDescription(nameof(AZTEC)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            DotCode = new SBool(CommonData.GetPropertyDescription(nameof(DotCode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Interleaved = new SBool(CommonData.GetPropertyDescription(nameof(Interleaved)),
              EHTupleStyle.None,
              EPropertyState.Input,
              EROILegend.None,
              false,
              false,
              false,
              false);
            MAXICODE = new SBool(CommonData.GetPropertyDescription(nameof(MAXICODE)),
          EHTupleStyle.None,
          EPropertyState.Input,
          EROILegend.None,
          false,
          false,
          false,
          false);
            RSS_14 = new SBool(CommonData.GetPropertyDescription(nameof(RSS_14)),
                              EHTupleStyle.None,
                              EPropertyState.Input,
                              EROILegend.None,
                              false,
                              false,
                              false,
                              false);
            RSS_EXPANDED = new SBool(CommonData.GetPropertyDescription(nameof(RSS_EXPANDED)),
                                  EHTupleStyle.None,
                                  EPropertyState.Input,
                                  EROILegend.None,
                                  false,
                                  false,
                                  false,
                                  false);
            UPC_EAN_EXTENSION = new SBool(CommonData.GetPropertyDescription(nameof(UPC_EAN_EXTENSION)),
                              EHTupleStyle.None,
                              EPropertyState.Input,
                              EROILegend.None,
                              false,
                              false,
                              false,
                              false);
            PLESSEY = new SBool(CommonData.GetPropertyDescription(nameof(PLESSEY)),
                            EHTupleStyle.None,
                            EPropertyState.Input,
                            EROILegend.None,
                            false,
                            false,
                            false,
                            false);
            IMB = new SBool(CommonData.GetPropertyDescription(nameof(PLESSEY)),
                           EHTupleStyle.None,
                           EPropertyState.Input,
                           EROILegend.None,
                           false,
                           false,
                           false,
                           false);
            GS1DataMatrix = new SBool(CommonData.GetPropertyDescription(nameof(GS1DataMatrix)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            InputCodeHandle = new SListString(CommonData.GetPropertyDescription(nameof(InputCodeHandle)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            true);
            Input1DTrained = new SBool(CommonData.GetPropertyDescription(nameof(Input1DTrained)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            Input2DTrained = new SBool(CommonData.GetPropertyDescription(nameof(Input2DTrained)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            true,
            false,
            false);
            MatchString = new SBool(CommonData.GetPropertyDescription(nameof(MatchString)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            NumberCodeRequired = new SListObject(CommonData.GetPropertyDescription(nameof(NumberCodeRequired)),
            EHTupleStyle.RangeMinMax,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            CheckQuantity = new SBool(CommonData.GetPropertyDescription(nameof(CheckQuantity)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ResultCode = new SListString(CommonData.GetPropertyDescription(nameof(ResultCode)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputCodeType = new SListString(CommonData.GetPropertyDescription(nameof(OutputCodeType)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            OutputCodeHandle = new SListString(CommonData.GetPropertyDescription(nameof(OutputCodeHandle)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Output2DTrained = new SBool(CommonData.GetPropertyDescription(nameof(Output2DTrained)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            true,
            false,
            false);
            CodeBoundary = new SListVector(CommonData.GetPropertyDescription(nameof(CodeBoundary)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            Output1DTrained = new SBool(CommonData.GetPropertyDescription(nameof(Output1DTrained)),
            EHTupleStyle.None,
            EPropertyState.Output,
            EROILegend.None,
            false,
            true,
            false,
            false);
            NumberOfCodeFound = new SInt(CommonData.GetPropertyDescription(nameof(NumberOfCodeFound)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            ShapeListData = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListData)),
            EHTupleStyle.ValueList,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            true);
            DefaultOutputString = new SString(CommonData.GetPropertyDescription(nameof(DefaultOutputString)),
            EHTupleStyle.None,
            EPropertyState.None,
            EROILegend.None,
            false,
            false,
            false,
            false);
            TrainCodeMode = new SString(CommonData.GetPropertyDescription(nameof(TrainCodeMode)),
            EHTupleStyle.None,
            EPropertyState.Input,
            EROILegend.None,
            false,
            false,
            false,
            false);
            MaximumNumberOfCodeToFind = new SListDouble(CommonData.GetPropertyDescription(nameof(MaximumNumberOfCodeToFind)),
            EHTupleStyle.ValueList,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            BarcodeHeightMin = new SListDouble(CommonData.GetPropertyDescription(nameof(BarcodeHeightMin)),
            EHTupleStyle.ValueList,
            EPropertyState.None,
            EROILegend.None,
            false,
            true,
            false,
            false);
            OutputDisplayTextPosition = new SListDouble(CommonData.GetPropertyDescription(nameof(OutputDisplayTextPosition)),
            EHTupleStyle.ValueList,
            EPropertyState.Output,
            EROILegend.None,
            false,
            false,
            false,
            false);
            FileMasterTrain = new SString(CommonData.GetPropertyDescription(nameof(FileMasterTrain)),
                EHTupleStyle.String,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                false,
                false);
            BarcodeHeightMin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(BarcodeHeightMin) + _SuffixName);
            FileMasterTrain.rtcValue = CommonData.GetDefaultValues_Text(nameof(FileMasterTrain) + _SuffixName);
            ShapeListData.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(ShapeListData) + _SuffixName);
            DefaultOutputString.rtcValue = CommonData.GetDefaultValues_Text(nameof(DefaultOutputString) + _SuffixName);

            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(ShapeListOriginal) + _SuffixName);
            ShapeList.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(ShapeList) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            TrainPressed.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TrainPressed) + _SuffixName);
            InputString.rtcValue = CommonData.GetDefaultValues_Text(nameof(InputString) + _SuffixName);
            Code.rtcValue = CommonData.GetDefaultValues_Text(nameof(Code) + _SuffixName);

            Industrial25.rtcValue = CommonData.GetDefaultValues_Bool(nameof(Industrial25) + _SuffixName);
            Industrial25.rtcIsReBinding = true;

            Interleaved25.rtcValue = CommonData.GetDefaultValues_Bool(nameof(Interleaved25) + _SuffixName);
            Interleaved25.rtcIsReBinding = true;

            CODABAR.rtcValue = CommonData.GetDefaultValues_Bool(nameof(CODABAR) + _SuffixName);
            CODABAR.rtcIsReBinding = true;

            CODE_39.rtcValue = CommonData.GetDefaultValues_Bool(nameof(CODE_39) + _SuffixName);
            CODE_39.rtcIsReBinding = true;

            CODE_93.rtcValue = CommonData.GetDefaultValues_Bool(nameof(CODE_93) + _SuffixName);
            CODE_93.rtcIsReBinding = true;

            CODE_128.rtcValue = CommonData.GetDefaultValues_Bool(nameof(CODE_128) + _SuffixName);
            CODE_128.rtcIsReBinding = true;

            MSI.rtcValue = CommonData.GetDefaultValues_Bool(nameof(MSI) + _SuffixName);
            MSI.rtcIsReBinding = true;

            PHARMA_CODE.rtcValue = CommonData.GetDefaultValues_Bool(nameof(PHARMA_CODE) + _SuffixName);
            PHARMA_CODE.rtcIsReBinding = true;

            EAN_8.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EAN_8) + _SuffixName);
            EAN_8.rtcIsReBinding = true;

            EAN_13.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EAN_13) + _SuffixName);
            EAN_13.rtcIsReBinding = true;

            UPC_A.rtcValue = CommonData.GetDefaultValues_Bool(nameof(UPC_A) + _SuffixName);
            UPC_A.rtcIsReBinding = true;

            UPC_E.rtcValue = CommonData.GetDefaultValues_Bool(nameof(UPC_E) + _SuffixName);
            UPC_E.rtcIsReBinding = true;

            GS1128.rtcValue = CommonData.GetDefaultValues_Bool(nameof(GS1128) + _SuffixName);
            GS1128.rtcIsReBinding = true;

            DATA_MATRIX.rtcValue = CommonData.GetDefaultValues_Bool(nameof(DATA_MATRIX) + _SuffixName);
            DATA_MATRIX.rtcIsReBinding = true;

            QR_CODE.rtcValue = CommonData.GetDefaultValues_Bool(nameof(QR_CODE) + _SuffixName);
            QR_CODE.rtcIsReBinding = true;
            MAXICODE.rtcValue = CommonData.GetDefaultValues_Bool(nameof(MAXICODE) + _SuffixName);
            MAXICODE.rtcIsReBinding = true;

            MicroQRCode.rtcValue = CommonData.GetDefaultValues_Bool(nameof(MicroQRCode) + _SuffixName);
            MicroQRCode.rtcIsReBinding = true;

            PDF_417.rtcValue = CommonData.GetDefaultValues_Bool(nameof(PDF_417) + _SuffixName);
            PDF_417.rtcIsReBinding = true;

            AZTEC.rtcValue = CommonData.GetDefaultValues_Bool(nameof(AZTEC) + _SuffixName);
            AZTEC.rtcIsReBinding = true;

            DotCode.rtcValue = CommonData.GetDefaultValues_Bool(nameof(DotCode) + _SuffixName);
            DotCode.rtcIsReBinding = true;

            Interleaved.rtcValue = CommonData.GetDefaultValues_Bool(nameof(Interleaved) + _SuffixName);
            Interleaved.rtcIsReBinding = true;

            RSS_14.rtcValue = CommonData.GetDefaultValues_Bool(nameof(RSS_14) + _SuffixName);
            RSS_14.rtcIsReBinding = true;

            RSS_EXPANDED.rtcValue = CommonData.GetDefaultValues_Bool(nameof(RSS_EXPANDED) + _SuffixName);
            RSS_EXPANDED.rtcIsReBinding = true;

            UPC_EAN_EXTENSION.rtcValue = CommonData.GetDefaultValues_Bool(nameof(UPC_EAN_EXTENSION) + _SuffixName);
            UPC_EAN_EXTENSION.rtcIsReBinding = true;  
            
            PLESSEY.rtcValue = CommonData.GetDefaultValues_Bool(nameof(PLESSEY) + _SuffixName);
            PLESSEY.rtcIsReBinding = true;

            IMB.rtcValue = CommonData.GetDefaultValues_Bool(nameof(IMB) + _SuffixName);
            IMB.rtcIsReBinding = true;

            GS1DataMatrix.rtcValue = CommonData.GetDefaultValues_Bool(nameof(GS1DataMatrix) + _SuffixName);
            GS1DataMatrix.rtcIsReBinding = true;

            InputCodeHandle.rtcValue = CommonData.GetDefaultValues_ListString(nameof(InputCodeHandle) + _SuffixName);
            Input1DTrained.rtcValue = CommonData.GetDefaultValues_Bool(nameof(Input1DTrained) + _SuffixName);
            Input2DTrained.rtcValue = CommonData.GetDefaultValues_Bool(nameof(Input2DTrained) + _SuffixName);
            MatchString.rtcValue = CommonData.GetDefaultValues_Bool(nameof(MatchString) + _SuffixName);
            NumberCodeRequired.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(NumberCodeRequired) + _SuffixName);
            CheckQuantity.rtcValue = CommonData.GetDefaultValues_Bool(nameof(CheckQuantity) + _SuffixName);
            MaximumNumberOfCodeToFind.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(MaximumNumberOfCodeToFind) + _SuffixName);
            TrainCodeMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(TrainCodeMode) + _SuffixName);

            AutoRun = false;
        }
        public void SetupPropertyByIOControllerReader()
        {
            SourceMode = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GPI1 = new SBool(CommonData.GetPropertyDescription(nameof(GPI1)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GPI2 = new SBool(CommonData.GetPropertyDescription(nameof(GPI2)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GPI3 = new SBool(CommonData.GetPropertyDescription(nameof(GPI3)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GPI4 = new SBool(CommonData.GetPropertyDescription(nameof(GPI4)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GPI5 = new SBool(CommonData.GetPropertyDescription(nameof(GPI5)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GPI6 = new SBool(CommonData.GetPropertyDescription(nameof(GPI6)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GPI7 = new SBool(CommonData.GetPropertyDescription(nameof(GPI7)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GPI8 = new SBool(CommonData.GetPropertyDescription(nameof(GPI8)),
                EHTupleStyle.None,
                EPropertyState.Input);

            COMName = new SString(CommonData.GetPropertyDescription(nameof(COMName)),
                EHTupleStyle.None,
                EPropertyState.Input);

            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input);

            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input);

            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
                EHTupleStyle.None,
                EPropertyState.Input);

            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Output);

            Value.rtcResetWhenStart = true;

            SourceMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceMode) + _SuffixName);
            COMName.rtcValue = CommonData.GetDefaultValues_Text(nameof(COMName) + _SuffixName);
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByIOControllerWriter()
        {
            SourceMode = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
                EHTupleStyle.None,
                EPropertyState.Input);

            OutputPolarity = new SString(CommonData.GetPropertyDescription(nameof(OutputPolarity)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP01 = new SBool(CommonData.GetPropertyDescription(nameof(GP01)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP02 = new SBool(CommonData.GetPropertyDescription(nameof(GP02)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP03 = new SBool(CommonData.GetPropertyDescription(nameof(GP03)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP04 = new SBool(CommonData.GetPropertyDescription(nameof(GP04)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP05 = new SBool(CommonData.GetPropertyDescription(nameof(GP05)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP06 = new SBool(CommonData.GetPropertyDescription(nameof(GP06)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP07 = new SBool(CommonData.GetPropertyDescription(nameof(GP07)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP08 = new SBool(CommonData.GetPropertyDescription(nameof(GP08)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP09 = new SBool(CommonData.GetPropertyDescription(nameof(GP09)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP10 = new SBool(CommonData.GetPropertyDescription(nameof(GP10)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP11 = new SBool(CommonData.GetPropertyDescription(nameof(GP11)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP12 = new SBool(CommonData.GetPropertyDescription(nameof(GP12)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP13 = new SBool(CommonData.GetPropertyDescription(nameof(GP13)),
                EHTupleStyle.None,

                EPropertyState.Input);
            GP14 = new SBool(CommonData.GetPropertyDescription(nameof(GP14)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP15 = new SBool(CommonData.GetPropertyDescription(nameof(GP15)),
                EHTupleStyle.None,
                EPropertyState.Input);

            GP16 = new SBool(CommonData.GetPropertyDescription(nameof(GP16)),
                EHTupleStyle.None,
                EPropertyState.Input);

            COMName = new SString(CommonData.GetPropertyDescription(nameof(COMName)),
                EHTupleStyle.None,
                EPropertyState.Input);

            IsAliveControl = new SBool(CommonData.GetPropertyDescription(nameof(IsAliveControl)),
                EHTupleStyle.None,
                EPropertyState.Input);

            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input);

            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
                EHTupleStyle.None,
                EPropertyState.Input);

            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
                EHTupleStyle.None,
                EPropertyState.Input);

            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
                EHTupleStyle.None,
                EPropertyState.Input);

            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
                EHTupleStyle.None,
                EPropertyState.Input);

            WaitMode = new SString(CommonData.GetPropertyDescription(nameof(WaitMode)),
                EHTupleStyle.None,
                EPropertyState.Input);

            ValueAfterDelay = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterDelay)),
                EHTupleStyle.None,
                EPropertyState.Input);

            ValueAfterStop = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterStop)),
                EHTupleStyle.None,
                EPropertyState.Input);

            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Input);

            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
                EHTupleStyle.None,
                EPropertyState.Output);

            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            TimeDelay.rtcValue = 0;
            COMName.rtcValue = CommonData.GetDefaultValues_Text(nameof(COMName) + _SuffixName);
            SourceMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceMode) + _SuffixName);
            OutputPolarity.rtcValue = CommonData.GetDefaultValues_Text(nameof(OutputPolarity) + _SuffixName);
            WaitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WaitMode) + _SuffixName);

            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByPOCIORead()
        {
            SourceMode = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ValueTypes = new SString(CommonData.GetPropertyDescription(nameof(ValueTypes)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Channel = new SListDouble(CommonData.GetPropertyDescription(nameof(Channel)),
            EHTupleStyle.None,
            EPropertyState.Input);

            IsCompareValue = new SBool(CommonData.GetPropertyDescription(nameof(IsCompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input);
            CompareValue = new SListString(CommonData.GetPropertyDescription(nameof(CompareValue)),
            EHTupleStyle.None,
            EPropertyState.Input);
            SimulatorValue = new SListString(CommonData.GetPropertyDescription(nameof(SimulatorValue)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Output);

            SourceMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceMode) + _SuffixName);
            ValueTypes.rtcValue = CommonData.GetDefaultValues_Text(nameof(ValueTypes) + _SuffixName);
            Channel.rtcValue = new List<double> { 0 };

            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }

        public void SetupPropertyByPOCIOWrite()
        {
            SourceMode = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ModeChannel = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Port = new SString(CommonData.GetPropertyDescription(nameof(SourceMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ValueTypes = new SString(CommonData.GetPropertyDescription(nameof(ValueTypes)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Channel = new SListDouble(CommonData.GetPropertyDescription(nameof(Channel)),
            EHTupleStyle.None,
            EPropertyState.Input);
            Value = new SListString(CommonData.GetPropertyDescription(nameof(Value)),
            EHTupleStyle.None,
            EPropertyState.Output);
            TimeDelay = new SInt(CommonData.GetPropertyDescription(nameof(TimeDelay)),
            EHTupleStyle.None,
            EPropertyState.Input);
            WaitMode = new SString(CommonData.GetPropertyDescription(nameof(WaitMode)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ValueAfterDelay = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterDelay)),
            EHTupleStyle.None,
            EPropertyState.Input);
            ValueAfterStop = new SListString(CommonData.GetPropertyDescription(nameof(ValueAfterStop)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsAliveControl = new SBool(CommonData.GetPropertyDescription(nameof(IsAliveControl)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Input);
            IsFinishRunOneTime = new SBool(CommonData.GetPropertyDescription(nameof(IsFinishRunOneTime)),
            EHTupleStyle.None,
            EPropertyState.Output);
            //AliveValueOn = new SString(CommonData.GetPropertyDescription(nameof(AliveValueOn)),
            //EHTupleStyle.None,
            //EPropertyState.Input);
            //AliveValueOff = new SString(CommonData.GetPropertyDescription(nameof(AliveValueOff)),
            //EHTupleStyle.None,
            //EPropertyState.Input);
            //AliveValueOn.rtcValue = "1";
            //AliveValueOff.rtcValue = "0";

            WaitMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(WaitMode) + _SuffixName);
            SourceMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceMode) + _SuffixName);
            Port.rtcValue = CommonData.GetDefaultValues_Text(nameof(SourceMode) + _SuffixName);
            ValueTypes.rtcValue = CommonData.GetDefaultValues_Text(nameof(ValueTypes) + _SuffixName);
            TimeDelay.rtcValue = 0;
            Channel.rtcValue = new List<double> { 0};
            IsFinishRunOneTime.rtcValue = false;
            IsFinishRunOneTime.rtcResetWhenStart = true;
            IsFinishRunOneTime.rtcResetWhenStop = true;
            WindowHandle.rtcHidden = true;
            RunIsSilent.rtcHidden = true;
            RunWhenPassFailButtonClick = false;
            RunWhenROIButtonClick = false;
            AutoRun = false;
        }
        public void SetupPropertyByAffineImage()
        {

            InputImage = new SImage(CommonData.GetPropertyDescription(nameof(InputImage)),
                EHTupleStyle.None,
                EPropertyState.Input);
            InputGrayImage = new SGrayImage(CommonData.GetPropertyDescription(nameof(InputImage)),
           EHTupleStyle.None,
           EPropertyState.Input);
            InputBgrImage = new SBgrImage(CommonData.GetPropertyDescription(nameof(InputImage)),
           EHTupleStyle.None,
           EPropertyState.Input);

            ToolOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(ToolOrigin)),
                EHTupleStyle.Origin,
                EPropertyState.Input);

            AffineMode = new SString(CommonData.GetPropertyDescription(nameof(AffineMode)),
                EHTupleStyle.None,
                EPropertyState.Input);

            Interpolation = new SString(CommonData.GetPropertyDescription(nameof(Interpolation)),
                EHTupleStyle.None,
                EPropertyState.Input);

            AdaptImageSize = new SBool(CommonData.GetPropertyDescription(nameof(AdaptImageSize)),
                EHTupleStyle.None,
                EPropertyState.Input);

            InputX = new SListDouble(CommonData.GetPropertyDescription(nameof(InputX)),
                EHTupleStyle.ValueList,
                EPropertyState.Input);

            InputY = new SListDouble(CommonData.GetPropertyDescription(nameof(InputY)),
                EHTupleStyle.ValueList,
                EPropertyState.Input);

            InputTransX = new SListDouble(CommonData.GetPropertyDescription(nameof(InputTransX)),
                EHTupleStyle.ValueList,
                EPropertyState.Input);

            InputTransY = new SListDouble(CommonData.GetPropertyDescription(nameof(InputTransY)),
                EHTupleStyle.ValueList,
                EPropertyState.Input);

            InputOrigin1 = new SListDouble(CommonData.GetPropertyDescription(nameof(InputOrigin1)),
                EHTupleStyle.Origin,
                EPropertyState.Input);

            InputOrigin2 = new SListDouble(CommonData.GetPropertyDescription(nameof(InputOrigin2)),
                EHTupleStyle.Origin,
                EPropertyState.Input);

            InputAngle = new SListDouble(CommonData.GetPropertyDescription(nameof(InputAngle)),
                EHTupleStyle.ValueList,
                EPropertyState.Input);

            InputHomMat2D = new SListDouble(CommonData.GetPropertyDescription(nameof(InputHomMat2D)),
                EHTupleStyle.ValueList,
                EPropertyState.Input);

            RevertAngle = new SBool(CommonData.GetPropertyDescription(nameof(RevertAngle)),
                EHTupleStyle.None,
                EPropertyState.Input);

            IsBringImageToMain = new SBool(CommonData.GetPropertyDescription(nameof(IsBringImageToMain)),
                EHTupleStyle.None,
                EPropertyState.None);

            ShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeList)),
                EHTupleStyle.Regions,
                EPropertyState.Input,
                EROILegend.PrimaryRoi,
                false,
                false,
                false,
                true);

            ShapeListOriginal = new SListObject(CommonData.GetPropertyDescription(nameof(ShapeListOriginal)),
                EHTupleStyle.Regions,
                EPropertyState.Input,
                EROILegend.PrimaryRoi,
                false,
                false,
                false,
                true);

            TabRoiActive = new SBool(CommonData.GetPropertyDescription(nameof(TabRoiActive)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                true,
                true,
                false,
                false);

            TabPassActive = new SBool(CommonData.GetPropertyDescription(nameof(TabPassActive)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                true,
                true,
                false,
                false);

            OutputImage = new SImage(CommonData.GetPropertyDescription(nameof(OutputImage)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false,
                false,
                true,
                false);
            OutputImage.rtcIsHotLink = true;

            OutputShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(OutputShapeList)),
                EHTupleStyle.Regions,
                EPropertyState.Output,
                EROILegend.PrimaryRoi,
                true,
                true,
                false,
                true);

            InputHomMat2D.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputHomMat2D) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            TabRoiActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabRoiActive) + _SuffixName);
            ToolOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ToolOrigin) + _SuffixName);
            Interpolation.rtcValue = CommonData.GetDefaultValues_Text(nameof(Interpolation) + _SuffixName);
            AdaptImageSize.rtcValue = CommonData.GetDefaultValues_Bool(nameof(AdaptImageSize) + _SuffixName);
            InputY.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputY) + _SuffixName);
            InputX.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputX) + _SuffixName);
            InputAngle.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputAngle) + _SuffixName);
            RevertAngle.rtcValue = CommonData.GetDefaultValues_Bool(nameof(RevertAngle) + _SuffixName);
            TabPassActive.rtcValue = CommonData.GetDefaultValues_Bool(nameof(TabPassActive) + _SuffixName);
            ShapeListOriginal.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(ShapeListOriginal) + _SuffixName);
            ShapeList.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(ShapeList) + _SuffixName);
            InputTransX.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputTransX) + _SuffixName);
            InputTransY.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputTransY) + _SuffixName);
            AffineMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(AffineMode) + _SuffixName);
            InputOrigin1.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputOrigin1) + _SuffixName);
            InputOrigin2.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(InputOrigin2) + _SuffixName);

            
        }

    }


}
