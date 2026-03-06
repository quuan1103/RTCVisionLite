using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using NewPattern;
using OriginTool;
using Region_Processing;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCBase.Drawing;
using RTCConst;
using RTCEnums;
//using RTCEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Media.Imaging;


namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        private object _lockImage = new object();
        public cAction(EActionTypes eActionType, EObjectTypes eObjectType, FrmHsmartWindow _frmHsmartWindow, cGroupActions myGroupActions)
        {
            ID = Guid.NewGuid();
            MyGroup = myGroupActions;
            IDBranch = Guid.Empty;
            IDBranchItem = Guid.Empty;
            STT = -1;
            _CanChangeName = true;
            DataChanged = true;
            _Name = Enum.GetName(typeof(EActionTypes), eActionType);
            _SuffixName = "|" + _Name;
            ActionType = eActionType;
            ObjectType = eObjectType;
            frmHsmartWindow = _frmHsmartWindow;
            ROIs = new Dictionary<long, object>();
            ROIProperties = new Dictionary<long, cROIProperty>();
            var test = this.GetType().GetProperties();

            foreach (PropertyInfo item in this.GetType().GetProperties())
            {
                item.SetValue(this, null);
            }

            Name = new SString(nameof(Name))
            {
                rtcValue = CommonData.GetActionCaption(_Name, _Name),
                rtcActive = true,
                rtcSystem = true
            };

            IsShowOnlyHighLightProperties = new SBool(nameof(IsShowOnlyHighLightProperties))
            {
                rtcValue = false,
                rtcActive = false,
                rtcSystem = true,
                rtcReadOnly = true
            };
            Description = new SListString(nameof(Description))
            {
                rtcActive = true,
                rtcSystem = true,
                rtcReadOnly = true
            };
            WindowHandle = new SWindow(CommonData.GetPropertyDescription(nameof(WindowHandle)), EHTupleStyle.None, EPropertyState.Input)
            {
                rtcActive = true

            };
            try
            {
                WindowHandle.rtcValue = frmHsmartWindow?.SmartWindowControl;
            }
            catch
            {
                WindowHandle.rtcValue = null;
            }
            Enable = new SBool(nameof(Enable))
            {
                rtcActive = true,
                rtcValue = true
            };

            IsCanEdit = new SBool(nameof(IsCanEdit))
            {
                rtcActive = true,
                rtcSystem = false,
                rtcValue = true,

            };
            DisplayOutput = new SBool(nameof(DisplayOutput))
            {
                rtcActive = true,
                rtcSystem = false,
                rtcValue = true,
                rtcState = EPropertyState.Input
            };
            RunIsSilent = new SBool(CommonData.GetPropertyDescription(nameof(RunIsSilent)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None
                )
            {
                rtcValue = true
            };
            Passed = new SBool(CommonData.GetPropertyDescription(nameof(Passed)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false)
            {
                rtcValue = false
            };
            HighLights = new SBool(CommonData.GetPropertyDescription(nameof(HighLights)),
             EHTupleStyle.None,
             EPropertyState.None,
             EROILegend.None,
             false)
            {
                rtcValue = false
            };
            Note = new SString(CommonData.GetPropertyDescription(nameof(HighLights)),
             EHTupleStyle.None,
             EPropertyState.None,
             EROILegend.None,
             false)
            {
                rtcValue = string.Empty
            };
            CycleTime = new SLong(nameof(CycleTime))
            {
                rtcValue = 0,
                rtcActive = true,
                rtcSystem = true,
                rtcIsReBinding = true,
                rtcState = EPropertyState.None
            };
            ErrMessage = new SListString(CommonData.GetPropertyDescription(nameof(ErrMessage)),
             EHTupleStyle.None,
             EPropertyState.Output,
             EROILegend.None);

            IsMultiROI = false;

            ViewInfo = null;

            Pattern_ROITrain_Find = false;

            RunWhenROIButtonClick = true;

            RunWhenPassFailButtonClick = true;

            if (ActionType == EActionTypes.Pattern ||
               ActionType == EActionTypes.Blob ||
               ActionType == EActionTypes.BlobMultipleROI ||
               ActionType == EActionTypes.ColorBlob ||
               ActionType == EActionTypes.VariationModel ||
               ActionType == EActionTypes.DeformablePattern ||
               ActionType == EActionTypes.CorrelationPattern ||
               ActionType == EActionTypes.Origin ||
               ActionType == EActionTypes.CodeReader ||
               ActionType == EActionTypes.OCR ||
               ActionType == EActionTypes.ColorBlobMultipleROI ||
               ActionType == EActionTypes.PixelCount ||
               ActionType == EActionTypes.Brightness ||
               ActionType == EActionTypes.LineFind ||
               ActionType == EActionTypes.Metrology ||
               ActionType == EActionTypes.GaugeDualROI ||
               ActionType == EActionTypes.ImageSplit)
            {
                MasterShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(MasterShapeList)),
                EHTupleStyle.ValueList,
                EPropertyState.None,
                EROILegend.SearchROI,
                true,
                false,
                false,
                true);
                OutputMasterShapeList = new SListObject(CommonData.GetPropertyDescription(nameof(MasterShapeList)),
                EHTupleStyle.ValueList,
                EPropertyState.None,
                EROILegend.SearchROI,
                true,
                false,
                false,
                true);
            }
            GroupType = EGroupTypes.None;
            PropOutputInfos = this.GetType().GetProperties().Where(x => (
                            (RTCVariableType)x.GetValue(this, null)) != null &&
                              ((RTCVariableType)x.GetValue(this, null)).rtcActive &&
                              (
                                    (((RTCVariableType)x.GetValue(this, null)).rtcState == EPropertyState.Output) ||
                                    (((RTCVariableType)x.GetValue(this,
                              null)).rtcIDRef != Guid.Empty) ||
                              ((RTCVariableType)x.GetValue(this, null)).rtcIsReBinding
                              )).ToList();

            /// <summary>
            /// Hàm tổng khởi tạo tool
            /// </summary>
            /// <param name="eActionType"> Loại tool.</param>
            /// <param name="eObjectType"> Kiểu tool</param>
            SetupPropertyByActionType(eActionType, eObjectType);

        }
        public void CreateViewInfo()
        {
            if (ViewInfo != null)
                return;
            switch (ActionType)
            {
                case EActionTypes.MainAction:
                    {
                        CreateViewInfo_MainAction();
                        break;
                    }
                case EActionTypes.Blob:
                    {
                        CreateViewInfo_Blob();
                        break;
                    }
                case EActionTypes.BlobFilter:
                    {
                        CreateViewInfo_BlobFilter();
                        break;
                    }
                case EActionTypes.Pattern:
                    {
                        CreateViewInfo_Pattern();
                        break;
                    }
                case EActionTypes.BlobMultipleROI:
                    {
                        CreateViewInfo_BlobMultipleROI();
                        break;
                    }
                case EActionTypes.Math:
                    {
                        CreateViewInfo_Math();
                        break;
                    }
                case EActionTypes.Branch:
                    {
                        CreateViewInfo_Brach();
                        break;
                    }
                case EActionTypes.BranchItem:
                    {
                        CreateViewInfo_BranchItem();
                        break;
                    }
                case EActionTypes.Brightness:
                    {
                        CreateViewInfo_Brightness();
                        break;
                    }
                case EActionTypes.PixelCount:
                    {
                        CreateViewInfo_PixelCount();
                        break;
                    }
                case EActionTypes.LineFind:
                    {
                        CreateViewInfo_LineFine();
                        break;
                    }
                case EActionTypes.ColorBlob:
                    {
                        CreateViewInfo_ColorBlob();
                        break;
                    }
                case EActionTypes.DistanceMeasurement:
                    {
                        CreateViewInfo_DistanceMeasurement();
                        break;
                    }
                case EActionTypes.ImageFilter:
                    {
                        CreateViewInfo_ImageFilter();
                        break;
                    }
                case EActionTypes.HandEye:
                    {
                        CreateViewInfo_HandEye();
                        break;
                    }
                case EActionTypes.CSTLightRead:
                    {
                        CreateViewInfo_CSTLightRead();
                        break;
                    }
                case EActionTypes.CSTLightWrite:
                    {
                        CreateViewInfo_CSTLightWrite();
                        break;
                    }
                case EActionTypes.TCPIPRead:
                    {
                        CreateViewInfo_TCPIPRead();
                        break;
                    }
                case EActionTypes.COMReader:
                    {
                        CreateViewInfo_ComReader();
                        break;
                    }
                case EActionTypes.COMWriter:
                    {
                        CreateViewInfo_COMWriter();
                        break;
                    }
                case EActionTypes.TCPIPWrite:
                    {
                        CreateViewInfo_TCPIPWrite();
                        break;
                    }
                case EActionTypes.SLMPRead:
                    {
                        CreateViewInfo_SLMPRead();
                        break;
                    }
                case EActionTypes.SLMPWrite:
                    {
                        CreateViewInfo_SLMPWrite();
                        break;
                    }
                case EActionTypes.Switch:
                    {
                        CreateViewInfo_Switch();
                        break;
                    }
                case EActionTypes.CounterLoop:
                    {
                        CreateViewInfo_CounterLoop();
                        break;
                    }
                case EActionTypes.PassFail:
                    {
                        CreateViewInfo_PassFail();
                        break;
                    }
                case EActionTypes.Return:
                    {
                        CreateViewInfo_Return();
                        break;
                    }
                case EActionTypes.ResetTool:
                    {
                        CreateViewInfo_Reset();
                        break;
                    }
                case EActionTypes.RegionProcessing:
                    {
                        CreateViewInfo_RegionProcessing();
                        break;
                    }
                case EActionTypes.ColorBlobMultipleROI:
                    {
                        CreateViewInfo_ColorBlobMultiROI();
                        break;
                    }
                case EActionTypes.Origin:
                    {
                        CreateViewInfo_Origin();
                        break;
                    }
                case EActionTypes.SnapImage:
                    {
                        CreateViewInfo_SnapImage();
                        break;
                    }
                case EActionTypes.LoadImage:
                    {
                        CreateViewInfo_LoadImage();
                        break;
                    }
                // thêm thử QUAN
                case EActionTypes.LoadObject:
                    {
                        CreateViewInfo_LoadObject();
                        break;
                    }
                case EActionTypes.StopLiveCam:
                    {
                        CreateViewInfo_StopLiveCam();
                        break;
                    }
                case EActionTypes.DataSet:
                    {
                        CreateViewInfo_DataSet();
                        break;
                    }
                case EActionTypes.DataInstance:
                    {
                        CreateViewInfo_DataIntance();
                        break;
                    }
                case EActionTypes.SaveImage:
                    {
                        CreateViewInfo_SaveImage();
                        break;
                    }
                case EActionTypes.CsvWrite:
                    {
                        CreateViewInfo_CSVWrite();
                        break;
                    }
                case EActionTypes.ExcelWrite:
                    {
                        CreateViewInfo_ExcelWrite();
                        break;
                    }
                case EActionTypes.RunProgram:
                    {
                        CreateViewInfo_RunProgram();
                        break;
                    }
                case EActionTypes.LinkValue:
                    {
                        CreateViewInfo_PropertyLink();
                        break;
                    }
                case EActionTypes.ChangeJob:
                    {
                        CreateViewInfo_ChangeJob();
                        break;
                    }
                case EActionTypes.MXComponentWrite:
                    {
                        CreateViewInfo_MXComponentWrite();
                        break;
                    }
                case EActionTypes.MXComponentRead:
                    {
                        CreateViewInfo_MXComponentRead();
                        break;
                    }
                case EActionTypes.CycleTimeStop:
                    {
                        CreateViewInfo_CycleTimeStop();
                        break;
                    }
                case EActionTypes.CycleTimeStart:
                    {
                        CreateViewInfo_CycleTimeStart();
                        break;
                    }
                case EActionTypes.DetectFileStatus:
                    {
                        CreateViewInfo_DetectFileStatus();
                        break;
                    }
                case EActionTypes.RunCommand:
                    {
                        CreateViewInfo_RunCommand();
                        break;
                    }
                case EActionTypes.ClearWindows:
                    {
                        CreateViewInfo_ClearWindow();
                        break;
                    }
                case EActionTypes.StringBuilder:
                    {
                        CreateViewInfo_StringBuilder();
                        break;
                    }
                case EActionTypes.ImageSplit:
                    {
                        CreateViewInfo_SplitImage();
                        break;
                    }
                case EActionTypes.SaveProject:
                    {
                        CreateViewInfo_SaveProject();
                        break;
                    }
                case EActionTypes.DialogMessage:
                    {
                        CreateViewInfo_DialogMessage();
                        break;
                    }
                case EActionTypes.SendMessage:
                    {
                        CreateViewInfo_SendMessage();
                        break;
                    }
                case EActionTypes.SystemInfo:
                    {
                        CreateViewInfo_SystemInfo();
                        break;
                    }
                case EActionTypes.OkNgCounter:
                    {
                        CreateViewInfo_OkNgCounter();
                        break;
                    }
                case EActionTypes.ViewResult:
                    {
                        CreateViewInfo_ViewResult();
                        break;
                    }
                case EActionTypes.HookKeyboard:
                    {
                        CreateViewInfo_HookKeyboard();
                        break;
                    }
                case EActionTypes.Wait:
                    {
                        CreateViewInfo_Wait();
                        break;
                    }
                case EActionTypes.Stop:
                    {
                        CreateViewInfo_Stop();
                        break;
                    }
                case EActionTypes.LoadConfig:
                    {
                        CreateViewInfo_LoadConfig();
                        break;
                    }
                case EActionTypes.SaveConfig:
                    {
                        CreateViewInfo_SaveConfig();
                        break;
                    }
                case EActionTypes.Count:
                    {
                        CreateViewInfo_Count();
                        break;
                    }
                case EActionTypes.Script:
                    {
                        CreateViewInfo_Script();
                        break;
                    }
                case EActionTypes.SaveObject:
                    {
                        CreateViewInfo_SaveObject();
                        break;
                    }
                case EActionTypes.LiveCam:
                    {
                        CreateViewInfo_LiveCam();
                        break;
                    }
                case EActionTypes.ImageMath:
                    {
                        CreateViewInfo_ImageMath();
                        break;
                    }
                case EActionTypes.CodeReader:
                    {
                        CreateViewInfo_CodeReader();
                        break;
                    }
                case EActionTypes.IOControllerRead:
                    {
                        CreateViewInfo_IOControllerRead();
                        break;
                    }
                case EActionTypes.IOControllerWrite:
                    {
                        CreateViewInfo_IOControllerWrite();
                        break;
                    }
                case EActionTypes.POCIORead:
                    {
                        CreateViewInfo_POCIORead();
                        break;
                    }
                case EActionTypes.POCIOWrite:
                    {
                        CreateViewInfo_POCIOWrite();
                        break;
                    }
                case EActionTypes.AffineImage:
                    {
                        CreateViewInfo_AffineImage();
                        break;
                    }
                default:
                    break;
            }
        }



        public void SetFlagTrainToDefault(bool value)
        {
            Pattern_ROITrain_Find = value;
            CorrelationPattern_ROITrain_Find = value;
            Blob_ROITrain_Roi = value;
            Brightness_ROITrain_ROI = value;
            ImageSplit_ROITrain_ROI = value;
            PixelCount_ROITrain_ROI = value;
            LineFind_ROITrain_ROI = value;

            ColorBlob_ROITrain_Find = value;
            ColorBlob_ROITrain_ROI = value;

            Calibrate_ROITrain_ROI = value;
            Origin_ROITrain_ROI = value;
            CodeReader_ROITrain_ROI = value;
            OCR_ROITrain_Find = value;
            AffineImage_ROITrain_ROI = value;
            DeformablePattern_ROITrain_Find = value;
            VariationModel_ROITrain_Find = value;
            VariationModel_ROITrain_ROI = value;

        }


        public void Run(bool setWaitForDebugConnection = false, bool isCheckCanRun = true, bool isGetRunningTime = true)
        {
            Stopwatch watch = null;
            Stopwatch watchtest = null;
            GlobVar.IsChangeJob = false;
            GlobVar.IsStop = false;
            MyGroup.IsReturn = false;
            this.AbortCause = string.Empty;


            if (isCheckCanRun)
                if ((this.IDBranchItem != Guid.Empty && !this.IsCanRun) ||
                    (this.IDBranch != Guid.Empty && !this.IsCanRun) ||
                    (!this.Enable.rtcValue &&
                    this.ActionType != EActionTypes.Branch &&
                    this.ActionType != EActionTypes.Switch &&
                    this.ActionType != EActionTypes.PassFail &&
                    this.ActionType != EActionTypes.CounterLoop) ||
                    (this.IsAliveControl != null && this.IsAliveControl.rtcValue))
                {
                    return;
                }
            try
            {
                //if (!MyGroup.RunSimple && this.MyNode != null)
                //{
                //    this.MyNode.
                //}    
                //    return;
                StartStopWatch();
                Run_ResetOutPutToDefault();

                MyGroup.DataChanged = true;
                this.IsRunned = this.Enable.rtcValue;
                this.RunCountInProcess += 1;
                if (!MyGroup.RunSimple)
                    watch = System.Diagnostics.Stopwatch.StartNew();
                watchtest = System.Diagnostics.Stopwatch.StartNew();
                if (this.ActionType != EActionTypes.DataInstance)
                {

                    if (!MyGroup.GetValueToVariableIsRef(this))
                        return;

                }
                if (this.ActionType == EActionTypes.VariationModel && this.IsAutoCreateRoi.rtcValue)
                    AutoCreateRoi();

                //if (this.ROIs.Count > 0)
                //{
                //    foreach (object item in this.ROIs.Values)
                //    {
                //        AddROIToShapeList(item, this.ShapeListOriginal, 2);
                //       // AddROIToShapeList(item, this.ShapeList, 2);

                //    }
                //}
                if (MasterShapeList != null)
                {
                    MasterShapeList.rtcValue = new List<Object>();
                    MainROIs = new Dictionary<long, object>();
                    if (ROIs != null)
                        foreach (cDrawingBaseType roiBaseType in ROIs.Values)
                            if (roiBaseType.MasterID != -1 && MyGroup.MainAction.ROIs != null &&
                                MyGroup.MainAction.ROIs.ContainsKey(roiBaseType.MasterID) &&
                                !MainROIs.ContainsKey(roiBaseType.MasterID))
                            {
                                cRectangType oldMainRoi = (cRectangType)MyGroup.MainAction.ROIs[roiBaseType.MasterID];
                                cRectangType newMainRoi = new cRectangType();
                                newMainRoi.Width = oldMainRoi.Width;
                                newMainRoi.Height = oldMainRoi.Height;
                                newMainRoi.Phi = oldMainRoi.Phi;
                                newMainRoi.Center.Row = oldMainRoi.Center.Row;
                                newMainRoi.Center.Col = oldMainRoi.Center.Col;
                                newMainRoi.ID = oldMainRoi.ID;
                                MainROIs.Add(roiBaseType.MasterID, newMainRoi);
                                AddROIToShapeList(newMainRoi, MasterShapeList, 2);
                            }
                    if (FindROIs != null)
                        foreach (cDrawingBaseType roiBaseType in FindROIs.Values)
                            if (roiBaseType.MasterID != 1 && MyGroup.MainAction.ROIs != null &&
                                MyGroup.MainAction.ROIs.ContainsKey(roiBaseType.MasterID) &&
                                !MainROIs.ContainsKey(roiBaseType.MasterID))
                            {
                                cRectangType oldMainRoi = (cRectangType)MyGroup.MainAction.ROIs[roiBaseType.MasterID];
                                cRectangType newMainRoi = new cRectangType();
                                newMainRoi.Width = oldMainRoi.Width;
                                newMainRoi.Height = oldMainRoi.Height;
                                newMainRoi.Phi = oldMainRoi.Phi;
                                newMainRoi.Center.Row = oldMainRoi.Center.Row;
                                newMainRoi.Center.Col = oldMainRoi.Center.Col;
                                newMainRoi.ID = oldMainRoi.ID;
                                MainROIs.Add(roiBaseType.MasterID, newMainRoi);
                                AddROIToShapeList(newMainRoi, MasterShapeList, 2);
                            }
                }
                if (this.ErrMessage != null)
                    this.ErrMessage.rtcValue = new List<string>();
                if (IsMultiROI && ShapeListData != null)
                {
                    var _ROIProperties = ROIProperties.Values.Where(x => x != null).ToList();
                    ShapeListData.rtcValue = new List<Object>();
                    foreach (cROIProperty ROI in _ROIProperties)
                    {

                        if (!ROI.Active)
                            if (!(!MyGroup.RunSimple && ROI.Selected && RunOnlyROISelected))
                                continue;
                        if (ROI.Selected)
                            SetActionValueToROIPropertiesSelected(ROI);
                        if (RunIsSilent.rtcValue)
                            ShapeListData.rtcValue.AddRange(ROI.GenValue());
                        else if (RunOnlyROISelected && ROI.Selected)
                        {
                            List<RTCRectangle> lstSelected = new List<RTCRectangle>();
                            ShapeListData.rtcValue.AddRange(ROI.GenValue());
                            Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(ShapeList);
                            long IDselect = DataShape.Keys.FirstOrDefault(x => x == ROI.ID);
                            if (DataShape.ContainsKey(IDselect))
                            {
                                lstSelected.Add(DataShape[IDselect]);
                            }
                            Tuple<PointF, double> toolOrigin;
                            if (ToolOrigin.rtcValue.Count < 3)
                            {
                                toolOrigin = Tuple.Create(new PointF(0, 0), 0.0);
                            }
                            else
                            {
                                toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                                   ToolOrigin.rtcValue[2]);
                            }
                            InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(lstSelected, toolOrigin));
                            continue;
                        }
                        else if (!RunOnlyROISelected)
                        {
                            ShapeListData.rtcValue.AddRange(ROI.GenValue());
                            Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(ShapeList);

                            Tuple<PointF, double> toolOrigin;
                            if (ToolOrigin.rtcValue.Count < 3)
                            {
                                toolOrigin = Tuple.Create(new PointF(0, 0), 0.0);
                            }
                            else
                            {

                                toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                                ToolOrigin.rtcValue[2]);
                            }
                            InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(DataShape.Values.ToList(), toolOrigin));
                        }
                    }
                }
                if (ActionType == EActionTypes.Pattern && PlacementMode.rtcValue == cPlacementMode.WherePlacedOnImage)
                {
                    ModelReferenceOrigin.rtcValue = new List<double> { ReferencePointRectangle.Center.Row,
                        ReferencePointRectangle.Center.Col,
                        ReferencePointRectangle.Phi};
                }
                if (OutputShapeList != null)
                    OutputShapeList.rtcValue = new List<object>();
                if (OutputMasterShapeList != null)
                    OutputMasterShapeList.rtcValue = new List<object>();
                #region RUN TOOL

                switch (ActionType)
                {

                    case EActionTypes.Branch:
                        {
                            Run_Branch();
                            break;
                        }
                    case EActionTypes.Switch:
                        {
                            Run_Switch();
                            break;
                        }
                    case EActionTypes.OkNgCounter:
                        {
                            Run_OkNgCounter();
                            break;
                        }
                    case EActionTypes.BranchItem:
                        return;

                    case EActionTypes.TCPIPWrite:
                        {
                            if (IsRunOneTime.rtcValue && IsFinishRunOneTime.rtcValue)
                                return;
                            Run_TCPIPWrite();
                            break;
                        }
                    case EActionTypes.TCPIPRead:
                        {
                            Run_TCPIPRead();
                            var test = this.Value.rtcValue;
                            break;
                        }
                    case EActionTypes.CSTLightRead:
                        {
                            Run_CSTLightRead();
                            break;
                        }
                    case EActionTypes.CSTLightWrite:
                        {
                            Run_CSTLightWrite();
                            break;
                        }
                    case EActionTypes.COMReader:
                        {
                            Run_COMReader();
                            break;
                        }
                    case EActionTypes.COMWriter:
                        {
                            Run_COMWriter();
                            break;
                        }
                    case EActionTypes.CounterLoop:
                        {
                            Run_CounterLoop();
                            break;
                        }
                    case EActionTypes.PassFail:
                        {
                            Run_PassFail();
                            break;
                        }
                    case EActionTypes.Math:
                        {
                            if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Replace)
                                Run_Math_Replace();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Select)
                                Run_Math_Select();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.SelectString)
                                Run_Math_SelectString();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.InvertPosition)
                                Run_Math_InvertPosition();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Split)
                                Run_Math_Split();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Trim)
                                Run_Math_Trim();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.BinaryToInteger)
                                Run_Math_BinaryToInteger();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Length)
                                Run_Math_Length();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Random)
                                Run_Math_Random();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.ReplaceString)
                                Run_Math_ReplaceString();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.MaxWithAbs)
                                Run_Math_MaxWithAbs();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.ToBinary)
                                Run_Math_ToBinary();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.None)
                                Run_Math_Operator();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.CountElenment)
                                Run_Math_CountElenment();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.Concat)
                                Run_Math_Concat();
                            else if (AdvancedMathematicsMode.rtcValue == cAdvancedMathematicsMode.SumElement)
                                Run_Math_SumElement();

                            Result.rtcValue = Result.rtcValue;

                            Run_Math_ResultComplete();
                            break;
                        }

                    case EActionTypes.Return:
                        {
                            Run_Return();
                            break;
                        }
                    case EActionTypes.ResetTool:
                        {
                            Run_ResetTool();
                            break;
                        }
                    case EActionTypes.SnapImage:
                        {
                            Run_SnapImage();
                            break;
                        }
                    case EActionTypes.DataInstance:
                        {
                            Run_DataInstance();
                            break;
                        }
                    case EActionTypes.DataSet:
                        {
                            Run_DataSet();
                            break;
                        }
                    case EActionTypes.SaveImage:
                        {
                            Run_SaveImage();
                            break;
                        }
                    case EActionTypes.LoadImage:
                        {
                            Run_LoadImage();
                            break;
                        }
                    case EActionTypes.CsvWrite:
                        {
                            Run_SaveCsv();
                            break;
                        }
                    case EActionTypes.LinkValue:
                        {
                            Run_LinkValue();
                            break;
                        }
                    case EActionTypes.MXComponentRead:
                        {
                            Run_MXComponentRead();
                            break;
                        }
                    case EActionTypes.MXComponentWrite:
                        {
                            RUN_MXComponentWrite();
                            break;
                        }
                    case EActionTypes.RunProgram:
                        {
                            Run_Program();
                            break;
                        }
                    case EActionTypes.ChangeJob:
                        {
                            Run_ChangeJob();
                            break;
                        }
                    case EActionTypes.CycleTimeStart:
                        {
                            Run_CycleTimeStart();
                            GlobVar.CycleTimeStack.Push(ID);
                            break;
                        }
                    case EActionTypes.CycleTimeStop:
                        {
                            Guid CycleTimeStartId = GlobVar.CycleTimeStack.Pop();
                            Run_CycleTimeStop(CycleTimeStartId);
                            break;
                        }
                    case EActionTypes.DetectFileStatus:
                        {
                            if (IsRunning.rtcValue)
                            {
                                Run_DetectFileStatus();
                                return;
                            }
                            Run_DetectFileStatus();
                            break;
                        }
                    case EActionTypes.StringBuilder:
                        {
                            Run_StringBuilder();
                            break;
                        }

                    case EActionTypes.SystemInfo:
                        {
                            Run_SystemInfo();
                            break;
                        }
                    case EActionTypes.SaveProject:
                        {
                            if (IsRunOneTime.rtcValue && IsFinishRunOneTime.rtcValue)
                                return;
                            Run_SaveProject();
                            break;
                        }
                    case EActionTypes.Wait:
                        {
                            Run_Wait();
                            break;
                        }
                    case EActionTypes.SendMessage:
                        {
                            if (IsRunOneTime.rtcValue && IsFinishRunOneTime.rtcValue)
                                return;
                            Run_SendAlarmMessage();
                            break;
                        }
                    case EActionTypes.DialogMessage:
                        {
                            Run_SendDialogMessage();
                            break;
                        }
                    case EActionTypes.IOControllerRead:
                        {
                            Run_IOControllerRead();
                            break;
                        }
                    case EActionTypes.IOControllerWrite:
                        {
                            Run_IOControllerWrite();
                            break;
                        }
                    case EActionTypes.POCIORead:
                        {
                            Run_POCIORead();
                            break;
                        }
                    case EActionTypes.POCIOWrite:
                        {
                            Run_POCIOWrite();
                            break;
                        }
                    default:
                        {
                            RunAllToolNeedDLL();
                            break;
                        }
                }

                #endregion
                if (!MyGroup.RunSimple && watch != null && this.Enable.rtcValue)
                {
                    watch.Stop();
                    ViewResultWhenAfterRun(watch);
                }
                if (ActionType != EActionTypes.TCPIPRead && ActionType != EActionTypes.UpdRead &&
                ActionType != EActionTypes.DetectFileStatus)
                    GlobFuncs.WriteLog(this);
            }

            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            finally
            {
                //if (!MyGroup.RunSimple && this.MyNode != null)
                //{
                //    if (!MyGroup.RunSimple && this.MyNode != null)
                //        if ()
                //}    
            }


        }
        public void RunAllToolNeedDLL()
        {
            RunToolDLL();
            GetValueAfterRunTool();
        }
        public void RunToolDLL()
        {
            try
            {
                switch (this.ActionType)
                {
                    case EActionTypes.Blob:
                        {
                            Run_Blob();
                            break;
                        }
                    case EActionTypes.BlobFilter:
                        {

                            Run_BlobFilter();
                            break;
                        }
                    case EActionTypes.BlobMultipleROI:
                        {
                            Run_BlobMultiROI();
                            break;
                        }
                    case EActionTypes.ColorBlobMultipleROI:
                        {
                            Run_ColorBlobMultiROIs();
                            break;
                        }
                    case EActionTypes.ColorBlob:
                        {
                            Run_ColorBlob();
                            break;
                        }
                    case EActionTypes.RegionProcessing:
                        {
                            Run_RegionProcessing();
                            break;
                        }
                    case EActionTypes.DistanceMeasurement:
                        {
                            Run_DistanceMeasurement();
                            break;
                        }
                    case EActionTypes.ImageSplit:
                        {
                            Run_SplitImage();
                            break;
                        }
                    case EActionTypes.Brightness:
                        {
                            Run_Brightness();
                            break;
                        }
                    case EActionTypes.LineFind:
                        {
                            Run_LineFind();
                            break;
                        }
                    case EActionTypes.PixelCount:
                        {
                            Run_PixelCount();
                            break;
                        }
                    case EActionTypes.Origin:
                        {
                            Run_Origin();
                            break;
                        }
                    case EActionTypes.Pattern:
                        {
                            Run_Pattern();
                            break;
                        }
                    case EActionTypes.ImageFilter:
                        {
                            Run_ImageFilter();
                            break;
                        }
                    case EActionTypes.ImageMath:
                        {
                            Run_ImageMath();
                            break;
                        }
                    case EActionTypes.CodeReader:
                        {
                            Run_CodeReader();
                            break;
                        }
                    case EActionTypes.AffineImage:
                        {
                            Run_AffineImage();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public void GetValueAfterRunTool()
        {
            bool isReViewShapeList = false;
            bool isReViewFindShapeList = false;
            if (ShapeList != null && DisplayOutput.rtcValue && TabRoiActive != null && TabRoiActive.rtcValue && !MyGroup.RunSimple)
                isReViewShapeList = true;
            if (FindShapeList != null && DisplayOutput.rtcValue && TabPassActive != null && TabPassActive.rtcValue && !MyGroup.RunSimple)
                isReViewFindShapeList = true;
            switch (ActionType)
            {
                case EActionTypes.MainAction:
                    break;
                case EActionTypes.Pattern:
                    {
                        OutputOriginListCount.rtcValue = 0;
                        if (OutputOriginList.rtcValue != null && OutputOriginList.rtcValue.Count % 3 == 0)
                            OutputOriginListCount.rtcValue = (int)OutputOriginList.rtcValue.Count / 3;
                        if (TrainPressed.rtcValue == true)
                            InputTrained.rtcValue = OutputTrained.rtcValue;
                        if (OutputModelID != null && OutputModelID.rtcValue.Count > 0)
                        {
                            InputModelID.rtcValue = OutputModelID.rtcValue;
                        }
                        TrainPressed.rtcValue = false;
                        Pattern_ROITrain_Find = false;
                        if (OutputMasterOrigin != null && OutputMasterOrigin.rtcValue.Count > 0)
                            ToolMasterOrigin.rtcValue = OutputMasterOrigin.rtcValue;
                        break;
                    }
                case EActionTypes.CodeReader:
                    {
                        TrainPressed.rtcValue = false;
                        break;
                    }
                //case EActionTypes.Metrology:
                //    {
                //        if (TrainPressed.rtcValue == true)
                //            InputTrained.rtcValue = OutputTrained.rtcValue;
                //        if (OutputMetrologyHandle != null && OutputMetrologyHandle.rtcValue.Length > 0)
                //        {
                //            InputMetrologyHandle.rtcValue = OutputMetrologyHandle.rtcValue;
                //        }
                //        TrainPressed.rtcValue = false;
                //        Pattern_ROITrain_Find = false;

                //        break;
                //    }
                case EActionTypes.Blob:
                    {
                        Blob_ROITrain_Roi = false;

                        break;
                    }
                case EActionTypes.GaugeDualROI:
                    {
                        Blob_ROITrain_Roi = false;

                        break;
                    }
                case EActionTypes.BlobMultipleROI:
                    {
                        Blob_ROITrain_Roi = false;

                        break;
                    }
                case EActionTypes.PixelCount:
                    {
                        PixelCount_ROITrain_ROI = false;
                        break;
                    }
                case EActionTypes.Brightness:
                    {
                        Brightness_ROITrain_ROI = false;
                        break;
                    }
                case EActionTypes.LineFind:
                    {
                        LineFind_ROITrain_ROI = false;
                        break;
                    }
                case EActionTypes.AffineImage:
                    {
                        AffineImage_ROITrain_ROI = false;

                        if (IsBringImageToMain.rtcValue)
                        {
                            if (OutputImage?.rtcValue != null)
                                MyGroup.Actions[MyGroup.IDMainAction].InputImage.rtcValue = (Image)OutputImage.rtcValue.Clone();
                            if (OutputBgrImage?.rtcValue != null)
                                MyGroup.Actions[MyGroup.IDMainAction].InputBgrImage.rtcValue = OutputBgrImage.rtcValue;
                            MyGroup.SetValuetoVariableIsParentRef(MyGroup.Actions[MyGroup.IDMainAction]);
                        }
                        break;
                    }
                case EActionTypes.DistanceMeasurement:
                    {
                        TrainPressed.rtcValue = false;
                        ResetPressed.rtcValue = false;
                        ScaleFactor.rtcValue = ScaleFactorOut.rtcValue;
                        break;
                    }
                case EActionTypes.ColorBlob:
                    {
                        ColorBlob_ROITrain_ROI = false;
                        ColorBlob_ROITrain_Find = false;
                        RedTolerance.rtcValue = RedToleranceOut.rtcValue;
                        GreenTolerance.rtcValue = GreenToleranceOut.rtcValue;
                        BlueTolerance.rtcValue = BlueToleranceOut.rtcValue;
                        HueTolerance.rtcValue = HueToleranceOut.rtcValue;
                        SaturationTolerance.rtcValue = SaturationToleranceOut.rtcValue;
                        IntensityTolerance.rtcValue = IntensityToleranceOut.rtcValue;
                        TrainPressed.rtcValue = false;
                        break;
                    }
                case EActionTypes.ColorBlobMultipleROI:
                    {

                        ColorBlob_ROITrain_ROI = false;
                        TrainPressed.rtcValue = false;
                        break;
                    }
                case EActionTypes.CalibrateEdgetoEdge:
                    {
                        Calibrate_ROITrain_ROI = false;
                        break;
                    }
                case EActionTypes.Origin:
                    {
                        Origin_ROITrain_ROI = false;
                        if (TrainPressed.rtcValue == true)
                            InputTrained.rtcValue = OutputTrained.rtcValue;

                        TrainPressed.rtcValue = false;
                        if (OutputMasterOrigin != null && OutputMasterOrigin.rtcValue.Count > 0)
                            ToolMasterOrigin.rtcValue = OutputMasterOrigin.rtcValue;
                        break;
                    }
                case EActionTypes.None:
                    break;

                case EActionTypes.DeformablePattern:
                    {
                        if (TrainPressed.rtcValue == true)
                            InputTrained.rtcValue = OutputTrained.rtcValue;
                        if (OutputModelID != null && OutputModelID.rtcValue.Count > 0)
                        {
                            InputModelID.rtcValue = OutputModelID.rtcValue;
                        }

                        TrainPressed.rtcValue = false;
                        DeformablePattern_ROITrain_Find = false;

                        break;
                    }
                //case EActionTypes.ImageMath:
                //    {
                //        PreviousPressed.rtcValue = false;
                //        NextPressed.rtcValue = false;

                //        break;
                //    }
                case EActionTypes.ImageSplit:
                    {
                        PreviousPressed.rtcValue = false;
                        NextPressed.rtcValue = false;
                        CurrentImageIndex.rtcValue = CurrentImageIndexOut.rtcValue;
                        ImageSplit_ROITrain_ROI = false;
                        break;
                    }
                //case EActionTypes.VariationModel:
                //    {
                //        if (OutputVariationModelID != null && OutputVariationModelID.rtcValue.Length > 0)
                //        {
                //            InputVariationModelID.rtcValue = OutputVariationModelID.rtcValue;
                //        }

                //        InputTrained.rtcValue = OutputTrained.rtcValue;
                //        ShowMasterImage.rtcValue = false;
                //        CreatePressed.rtcValue = false;
                //        TrainAllImage.rtcValue = false;
                //        TrainSingleImage.rtcValue = false;
                //        TestAlignAllImage.rtcValue = false;
                //        TestAlignSingleImage.rtcValue = false;
                //        VariationModel_ROITrain_ROI = false;
                //        ShowOutputImage.rtcValue = false;
                //        ShowCustomROI.rtcValue = false;
                //        VariationModel_ROITrain_Find = false;
                //        if (OutputBestOrigin.rtcValue != null && OutputBestOrigin.rtcValue.Length >= 2)
                //            if (GlobFuncs.He2Double(OutputBestOrigin.rtcValue[0]) != 0 &&
                //                GlobFuncs.He2Double(OutputBestOrigin.rtcValue[1]) != 0)
                //            {
                //                ToolOrigin.rtcValue = new HTuple();
                //                for (int i = 0; i < OutputBestOrigin.rtcValue.Length; i++)
                //                    ToolOrigin.rtcValue.Append(OutputBestOrigin.rtcValue.TupleSelect(i));
                //            }
                //        break;
                //    }
                case EActionTypes.CorrelationPattern:
                    {
                        if (TrainPressed.rtcValue == true)
                            InputTrained.rtcValue = OutputTrained.rtcValue;
                        if (OutputModelID != null && OutputModelID.rtcValue.Count > 0)
                        {
                            InputModelID.rtcValue = OutputModelID.rtcValue;
                        }

                        TrainPressed.rtcValue = false;
                        CorrelationPattern_ROITrain_Find = false;
                        if (OutputMasterOrigin != null && OutputMasterOrigin.rtcValue.Count > 0)
                            ToolMasterOrigin.rtcValue = OutputMasterOrigin.rtcValue;

                        break;
                    }
                default:
                    break;
            }
            if (isReViewShapeList)
            {
                frmHsmartWindow.ClearAllRoi();
                frmHsmartWindow.ReviewAllROIS(true, true);
            }
            if (isReViewFindShapeList)
            {
                frmHsmartWindow.ClearAllRoi();
                frmHsmartWindow.ReviewAllROIS(true, true);
            }
        }
        private void Run_HandEye()
        {

        }
        private void Run_BlobFilter()
        {
            BlobFilter = new Blob_Filter.BlobFilter();
            BlobFilter.InputImage = InputGrayImage.rtcValue?.Clone();
            BlobFilter.InputBlobList = InputRegion.rtcValue;
            BlobFilter.EnableAreaFilter = EnableAreaFilter.rtcValue;
            BlobFilter.EnableCircularityFilter = EnableCircularityFilter.rtcValue;
            BlobFilter.EnableColumnFilter = EnableColumnFilter.rtcValue;
            BlobFilter.EnableHeightFilter = EnableHeightFilter.rtcValue;
            BlobFilter.EnableOuterRadiusFilter = EnableOuterRadiusFilter.rtcValue;
            BlobFilter.EnableRowFilter = EnableRowFilter.rtcValue;
            BlobFilter.EnableWidthFilter = EnableWidthFilter.rtcValue;

            BlobFilter.RequireNumberOfBlobs = new Tuple<int, int>(int.TryParse(RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Value) ? Value : 0, int.TryParse(RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Result) ? Result : 1000000000);
            BlobFilter.AreaRange = new Tuple<double, double>(AreaRange.rtcValue[0], AreaRange.rtcValue[1]);
            BlobFilter.CircularityRange = new Tuple<double, double>(CircularityRange.rtcValue[0], CircularityRange.rtcValue[1]);
            BlobFilter.ColumnRange = new Tuple<double, double>(ColumnRange.rtcValue[0], ColumnRange.rtcValue[1]);
            BlobFilter.HeightRange = new Tuple<double, double>(HeightRange.rtcValue[0], HeightRange.rtcValue[1]);
            BlobFilter.OuterRadiusRange = new Tuple<double, double>(OuterRadiusRange.rtcValue[0], OuterRadiusRange.rtcValue[1]);
            BlobFilter.RowRange = new Tuple<double, double>(RowRange.rtcValue[0], RowRange.rtcValue[1]);
            BlobFilter.WidthRange = new Tuple<double, double>(WidthRange.rtcValue[0], WidthRange.rtcValue[1]);
            BlobFilter.SelectedIndex = SelectedIndex.rtcValue[0];
            BlobFilter.IsShowImageResult = true;

            bool Ressult = BlobFilter.Run();

            //stopwatch.Stop();
            //Blobtool.GetImageResult();
            if (WindowHandle.rtcValue.InvokeRequired)
            {
                WindowHandle.rtcValue.Invoke(new Action(() =>
                {
                    WindowHandle.rtcValue.Image = BlobFilter.OutputImageShow;
                    Passed.rtcValue = BlobFilter.Passed;
                    NumberOfBlobsFound.rtcValue = new List<double> { BlobFilter.NumberOfBlobsFound };
                    OutputBlobList.rtcValue = BlobFilter.OutputBlobList;
                }));

            }
            else
            {
                WindowHandle.rtcValue.Image = BlobFilter.OutputImageShow;
                Passed.rtcValue = BlobFilter.Passed;
                NumberOfBlobsFound.rtcValue = new List<double> { BlobFilter.NumberOfBlobsFound };
                OutputBlobList.rtcValue = BlobFilter.OutputBlobList;

            }


        }

        private void Run_RegionProcessing()
        {
            RegionProcessing _RegionProcessing = new RegionProcessing();
            Bitmap bitmapImage = null;

            lock (_lockImage)
                bitmapImage = (Bitmap)InputImage.rtcValue.Clone();
            //Rectangle rectangle = new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height);//System.Drawing
            //BitmapData bmpData = bitmapImage.LockBits(rectangle, ImageLockMode.ReadWrite, bitmapImage.PixelFormat);//System.Drawing.Imaging
            ////Image<Gray, byte> Input_Image = new Image<Gray, byte>(bitmapImage.Width, bitmapImage.Height, bmpData.Stride, bmpData.Scan0);//(IntPtr)
            Image<Gray, byte> Input_Image = null;
            lock (_lockImage)
                Input_Image = bitmapImage.ToImage<Gray, byte>();
            _RegionProcessing.InputImage = Input_Image;
            _RegionProcessing.InputRegion = InputRegion.rtcValue;
            _RegionProcessing.Interation = Interations.rtcValue;
            _RegionProcessing.IsShowImageResult = true;
            _RegionProcessing.Margin = Margin.rtcValue;
            _RegionProcessing.MashRadius = MaskRadius.rtcValue;
            _RegionProcessing.MaskHeight = MaskHeight.rtcValue;
            _RegionProcessing.MaskType = MaskType.rtcValue;
            _RegionProcessing.MaskWidth = MaskWidth.rtcValue;
            _RegionProcessing.MorphologyType = MorphologyType.rtcValue;
            _RegionProcessing.Run();
            if (WindowHandle.rtcValue.InvokeRequired)
            {
                WindowHandle.rtcValue.Invoke(new Action(() =>
                {
                    WindowHandle.rtcValue.Image = _RegionProcessing.OutputImageShow;
                    WindowHandle.rtcValue.FitImage = true;
                    OutputRegion.rtcValue = _RegionProcessing.OutputRegion;
                    WindowHandle.rtcValue.Refresh();
                }));
            }
            else
            {
                WindowHandle.rtcValue.Image = _RegionProcessing.OutputImageShow;
                WindowHandle.rtcValue.FitImage = true;
                OutputRegion.rtcValue = _RegionProcessing.OutputRegion;
                WindowHandle.rtcValue.Refresh();
            }
            bitmapImage?.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void Run_DistanceMeasurement()
        {
            DistanceMeasurementTool = new DistanceMeasurementTool.Measurement();
            DistanceMeasurementTool.InputImage = InputGrayImage.rtcValue.Clone();
            DistanceMeasurementTool.Point = GlobFuncs.ListDoubleToListPoint(Point.rtcValue);
            DistanceMeasurementTool.PointTwo = GlobFuncs.ListDoubleToListPoint(PointTwo.rtcValue);
            List<Point> LinePoint = GlobFuncs.ListDoubleToListPoint(Line.rtcValue);
            List<Point> LineTwoPoint = GlobFuncs.ListDoubleToListPoint(LineTwo.rtcValue);
            DistanceMeasurementTool.Line = new Tuple<Point, Point>(LinePoint[0], LinePoint[1]);
            DistanceMeasurementTool.LineTwo = new Tuple<Point, Point>(LineTwoPoint[0], LineTwoPoint[1]);
            DistanceMeasurementTool.DistanceType = MeasurementType.rtcValue;
            DistanceMeasurementTool.MeasurementType = DistanceType.rtcValue;
            DistanceMeasurementTool.AngleDirection = MeasureDirection.rtcValue;
            DistanceMeasurementTool.AngleEndPoint = MeasureEndPoint.rtcValue;
            DistanceMeasurementTool.Tolerance = new Tuple<double, double, double>(Tolerance.rtcValue[0], Tolerance.rtcValue[1], Tolerance.rtcValue[2]);
            DistanceMeasurementTool.IsShowImageResult = true;
            bool ResultRun = DistanceMeasurementTool.Run();
            Passed.rtcValue = DistanceMeasurementTool.Passed;
            Distance.rtcValue = DistanceMeasurementTool.Distance[0];
            if (WindowHandle.rtcValue.InvokeRequired)
            {
                WindowHandle.rtcValue.BeginInvoke(new Action(() =>
                {
                    WindowHandle.rtcValue.Image = DistanceMeasurementTool.OutputImageShow;
                    WindowHandle.rtcValue.Refresh();
                }));
            }
            else
            {
                WindowHandle.rtcValue.Image = DistanceMeasurementTool.OutputImageShow;
                WindowHandle.rtcValue.Refresh();
            }


        }

        //private void Run_ColorBlob()
        //{
        //    ColorBlob = new Blob_Color_Multi_ROI.BlobColor();
        //    //Bitmap bitmapImage = null;
        //    //lock (_lockImage)
        //    //    bitmapImage = (Bitmap)InputImage.rtcValue.Clone();
        //    //Image<Bgr, byte> Input_Image = null;
        //    //lock (_lockImage)
        //    //    Input_Image = bitmapImage.ToImage<Bgr, byte>();
        //    ColorBlob.InputImage = InputBgrImage.rtcValue;

        //    Tuple<Point, double> toolOrigin = Tuple.Create(new Point(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
        //        ToolOrigin.rtcValue[2]);
        //    Tuple<PointF, double> toolOriginF = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
        //      ToolOrigin.rtcValue[2]);
        //    List<RTCRectangle> ROIs = new List<RTCRectangle>();
        //    if (TrainPressed.rtcValue || TabRoiActive.rtcValue)
        //    {
        //        ColorBlob.ToolOrigin = Tuple.Create(new Point(0, 0), 0.0);
        //        toolOriginF = Tuple.Create(new PointF(0,0),0.0);
        //        RTCRectangle Rect = new RTCRectangle();
        //        Rect.Height = InputImage.rtcValue.Height;
        //        Rect.Width = InputImage.rtcValue.Width;
        //        foreach (object ROI in this.ROIs.Values)
        //        {
        //            cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
        //            RTCRectangle Data = new RTCRectangle();
        //            long OldID = ROIB.ID;
        //            switch (ROIB.DrawingType)
        //            {
        //                case EDrawingtypes.Rectang:
        //                    {

        //                        cRectangType Rec = (cRectangType)ROI;
        //                        Data.Phi = (float)Rec.Phi * Math.PI / 180;
        //                        Data.Width = (float)Rec.Width * 2;
        //                        Data.Height = (float)Rec.Height * 2;
        //                        Data.Center = new RTCPoint(Rec.Center.Row, Rec.Center.Col, 0);
        //                        ROIs.Add(Data);

        //                        //SmartWindow.DrawROI(DataRoi);
        //                        break;
        //                    }
        //                case EDrawingtypes.Ellipse:
        //                    {
        //                        if (ROIProperties[ROIB.ID].Selected)
        //                        {
        //                            cEllipseType Ell = (cEllipseType)ROI;
        //                            Data.Phi = (float)Ell.Phi;
        //                            Data.Width = (float)Ell.Radius1;
        //                            Data.Height = (float)Ell.Radius2;
        //                            Data.Center = new RTCPoint(Ell.Center.Row, Ell.Center.Col, 0);
        //                            ROIs.Add(Data);
        //                        }
        //                        break;

        //                    }
        //            }
        //        }
        //        if (ROIs.Count > 0)
        //        {
        //            ColorBlob.ROITrain = ROIs;

        //        }
        //        else
        //        {
        //            ColorBlob.ROITrain = new List<RTCRectangle> { Rect };
        //        }
        //        InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOriginF));
        //        //_BlobTool.InSetOrigin = SetOrigin.Run(ROIs, toolOrigin);
        //        ColorBlob.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue);
        //        bool trainsucces = ColorBlob.Train();
        //        if (trainsucces)
        //        {
        //            HueToleranceOut.rtcValue = new List<double> { (double)ColorBlob.HueTolerance.Item1, (double)ColorBlob.HueTolerance.Item2, (double)ColorBlob.HueTolerance.Item3 };
        //            IntensityToleranceOut.rtcValue = new List<double> { (double)ColorBlob.IntensityTolerance.Item1, (double)ColorBlob.IntensityTolerance.Item2, (double)ColorBlob.IntensityTolerance.Item3 };
        //            SaturationToleranceOut.rtcValue = new List<double> { (double)ColorBlob.SaturationTolerance.Item1, (double)ColorBlob.SaturationTolerance.Item2, (double)ColorBlob.SaturationTolerance.Item3 };
        //            BlueToleranceOut.rtcValue = new List<double> { (double)ColorBlob.BlueTolerance.Item1, (double)ColorBlob.BlueTolerance.Item2, (double)ColorBlob.BlueTolerance.Item3 };
        //            GreenToleranceOut.rtcValue = new List<double> { (double)ColorBlob.GreenTolerance.Item1, (double)ColorBlob.GreenTolerance.Item2, (double)ColorBlob.GreenTolerance.Item3 };
        //            RedToleranceOut.rtcValue = new List<double> { (double)ColorBlob.RedTolerance.Item1, (double)ColorBlob.RedTolerance.Item2, (double)ColorBlob.RedTolerance.Item3 };
        //        }
        //        ColorBlob.ColorSpace = ColorSpace.rtcValue;
        //        string err = ColorBlob.ErrMessage;

        //        ColorBlob.FillHoles = FillHoles.rtcValue;
        //        ColorBlob.RequireNumberOfBlobs = new Tuple<int, int>(int.Parse(RequiredNumberOfBlobs.rtcValue[0].ToString()), int.TryParse(RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Result) ? Result : 100);
        //        ColorBlob.EnableAreaFilter = EnableAreaFilter.rtcValue;
        //        if (EnableAreaFilter.rtcValue)
        //            ColorBlob.AreaRange = new Tuple<double, double>(AreaRange.rtcValue[0], AreaRange.rtcValue[1]);
        //        ColorBlob.EnableWidthFilter = EnableWidthFilter.rtcValue;
        //        if (EnableWidthFilter.rtcValue)
        //            ColorBlob.WidthRange = new Tuple<double, double>(WidthRange.rtcValue[0], WidthRange.rtcValue[1]);
        //        ColorBlob.EnableHeightFilter = EnableHeightFilter.rtcValue;
        //        if (EnableHeightFilter.rtcValue)
        //            ColorBlob.HeightRange = new Tuple<double, double>(HeightRange.rtcValue[0], HeightRange.rtcValue[1]);
        //        ColorBlob.EnableColumnFilter = EnableColumnFilter.rtcValue;
        //        if (EnableColumnFilter.rtcValue)
        //            ColorBlob.ColumnRange = new Tuple<double, double>(ColumnRange.rtcValue[0], ColumnRange.rtcValue[1]);
        //        ColorBlob.EnableRowFilter = EnableRowFilter.rtcValue;
        //        if (EnableRowFilter.rtcValue)
        //            ColorBlob.RowRange = new Tuple<double, double>(RowRange.rtcValue[0], RowRange.rtcValue[1]);
        //        ColorBlob.HueTolerance = new Tuple<int, int, int>((int)HueToleranceOut.rtcValue[0], (int)HueToleranceOut.rtcValue[1], (int)HueToleranceOut.rtcValue[2]);
        //        ColorBlob.SaturationTolerance = new Tuple<int, int, int>((int)SaturationToleranceOut.rtcValue[0], (int)SaturationToleranceOut.rtcValue[1], (int)SaturationToleranceOut.rtcValue[2]);
        //        ColorBlob.IntensityTolerance = new Tuple<int, int, int>((int)IntensityToleranceOut.rtcValue[0], (int)IntensityToleranceOut.rtcValue[1], (int)IntensityToleranceOut.rtcValue[2]);
        //        ColorBlob.BlueTolerance = new Tuple<int, int, int>((int)BlueToleranceOut.rtcValue[0], (int)BlueToleranceOut.rtcValue[1], (int)BlueToleranceOut.rtcValue[2]);
        //        ColorBlob.GreenTolerance = new Tuple<int, int, int>((int)GreenToleranceOut.rtcValue[0], (int)GreenToleranceOut.rtcValue[1], (int)GreenToleranceOut.rtcValue[2]);
        //        ColorBlob.RedTolerance = new Tuple<int, int, int>((int)RedToleranceOut.rtcValue[0], (int)RedToleranceOut.rtcValue[1], (int)RedToleranceOut.rtcValue[2]);
        //        ColorBlob.FillHoles = FillHoles.rtcValue;
        //        ColorBlob.IsShowImageResult = true;
        //        bool result = ColorBlob.Run();
        //        err = ColorBlob.ErrMessage;
        //        NumberOfBlobsFound.rtcValue = new List<double>() { ColorBlob.NumberOfBlobsFound };
        //        Passed.rtcValue = ColorBlob.Passed;
        //        OutputBlobList.rtcValue = ColorBlob.OutputBlobList;
        //        if (WindowHandle.rtcValue.InvokeRequired)
        //        {
        //            WindowHandle.rtcValue.Invoke(new Action(() =>
        //            {
        //                WindowHandle.rtcValue.Image = ColorBlob.OutputImageShow;
        //            }));
        //        }
        //        else
        //        {
        //            WindowHandle.rtcValue.Image = ColorBlob.OutputImageShow;

        //        }
        //        TrainPressed.rtcValue = false;

        //    }
        //    else if (TabPassActive.rtcValue || RunIsSilent.rtcValue)
        //    {
        //        ColorBlob.ToolOrigin = toolOrigin;
        //        RTCRectangle Rect = new RTCRectangle();
        //        Rect.Height = InputImage.rtcValue.Height;
        //        Rect.Width = InputImage.rtcValue.Width;
        //        //  var DataROI = frmHsmartWindow.Action.ROIs.Values.Cast<cRectangType>;
        //        foreach (object ROI in this.FindROIs.Values)
        //        {
        //            cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
        //            RTCRectangle Data = new RTCRectangle();
        //            long OldID = ROIB.ID;
        //            switch (ROIB.DrawingType)
        //            {
        //                case EDrawingtypes.Rectang:
        //                    {
        //                        cRectangType Rec = (cRectangType)ROI;
        //                        Data.Phi = (float)Rec.Phi * Math.PI / 180;
        //                        Data.Width = (float)Rec.Width * 2;
        //                        Data.Height = (float)Rec.Height * 2;
        //                        Data.Center = new RTCPoint(Rec.Center.Row, Rec.Center.Col, 0);
        //                        ROIs.Add(Data);
        //                        //SmartWindow.DrawROI(DataRoi);
        //                        break;
        //                    }
        //                case EDrawingtypes.Ellipse:
        //                    {
        //                        cEllipseType Ell = (cEllipseType)ROI;
        //                        Data.Phi = (float)Ell.Phi;
        //                        Data.Width = (float)Ell.Radius1;
        //                        Data.Height = (float)Ell.Radius2;
        //                        Data.Center = new RTCPoint(Ell.Center.Row, Ell.Center.Col, 0);
        //                        ROIs.Add(Data);
        //                        break;
        //                    }
        //            }
        //            if (ROIs.Count > 0)
        //            {
        //                ColorBlob.ROI = ROIs;
        //            }
        //            if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
        //            {
        //                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOriginF));
        //            }

        //            ColorBlob.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue);
        //            // ColorBlob.ToolOrigin


        //            //bool trainsucces = ColorBlob.Train();
        //            //if (trainsucces)
        //            //{
        //            //    HueToleranceOut.rtcValue = new List<double> { (double)ColorBlob.HueTolerance.Item1, (double)ColorBlob.HueTolerance.Item2, (double)ColorBlob.HueTolerance.Item3 };
        //            //    IntensityToleranceOut.rtcValue = new List<double> { (double)ColorBlob.IntensityTolerance.Item1, (double)ColorBlob.IntensityTolerance.Item2, (double)ColorBlob.IntensityTolerance.Item3 };
        //            //    SaturationToleranceOut.rtcValue = new List<double> { (double)ColorBlob.SaturationTolerance.Item1, (double)ColorBlob.SaturationTolerance.Item2, (double)ColorBlob.SaturationTolerance.Item3 };
        //            //    BlueToleranceOut.rtcValue = new List<double> { (double)ColorBlob.BlueTolerance.Item1, (double)ColorBlob.BlueTolerance.Item2, (double)ColorBlob.BlueTolerance.Item3 };
        //            //    GreenToleranceOut.rtcValue = new List<double> { (double)ColorBlob.GreenTolerance.Item1, (double)ColorBlob.GreenTolerance.Item2, (double)ColorBlob.GreenTolerance.Item3 };
        //            //    RedToleranceOut.rtcValue = new List<double> { (double)ColorBlob.RedTolerance.Item1, (double)ColorBlob.RedTolerance.Item2, (double)ColorBlob.RedTolerance.Item3 };
        //            //}
        //            ColorBlob.ColorSpace = ColorSpace.rtcValue;
        //            string err = ColorBlob.ErrMessage;

        //            ColorBlob.FillHoles = FillHoles.rtcValue;
        //            ColorBlob.RequireNumberOfBlobs = new Tuple<int, int>(int.Parse(RequiredNumberOfBlobs.rtcValue[0].ToString()), int.TryParse(RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Result) ? Result : 100);
        //            ColorBlob.EnableAreaFilter = EnableAreaFilter.rtcValue;
        //            if (EnableAreaFilter.rtcValue)
        //                ColorBlob.AreaRange = new Tuple<double, double>(AreaRange.rtcValue[0], AreaRange.rtcValue[1]);
        //            ColorBlob.EnableWidthFilter = EnableWidthFilter.rtcValue;
        //            if (EnableWidthFilter.rtcValue)
        //                ColorBlob.WidthRange = new Tuple<double, double>(WidthRange.rtcValue[0], WidthRange.rtcValue[1]);
        //            ColorBlob.EnableHeightFilter = EnableHeightFilter.rtcValue;
        //            if (EnableHeightFilter.rtcValue)
        //                ColorBlob.HeightRange = new Tuple<double, double>(HeightRange.rtcValue[0], HeightRange.rtcValue[1]);
        //            ColorBlob.EnableColumnFilter = EnableColumnFilter.rtcValue;
        //            if (EnableColumnFilter.rtcValue)
        //                ColorBlob.ColumnRange = new Tuple<double, double>(ColumnRange.rtcValue[0], ColumnRange.rtcValue[1]);
        //            ColorBlob.EnableRowFilter = EnableRowFilter.rtcValue;
        //            if (EnableRowFilter.rtcValue)
        //                ColorBlob.RowRange = new Tuple<double, double>(RowRange.rtcValue[0], RowRange.rtcValue[1]);

        //            ColorBlob.HueTolerance = new Tuple<int, int, int>((int)HueToleranceOut.rtcValue[0], (int)HueToleranceOut.rtcValue[1], (int)HueToleranceOut.rtcValue[2]);
        //            ColorBlob.SaturationTolerance = new Tuple<int, int, int>((int)SaturationToleranceOut.rtcValue[0], (int)SaturationToleranceOut.rtcValue[1], (int)SaturationToleranceOut.rtcValue[2]);
        //            ColorBlob.IntensityTolerance = new Tuple<int, int, int>((int)IntensityToleranceOut.rtcValue[0], (int)IntensityToleranceOut.rtcValue[1], (int)IntensityToleranceOut.rtcValue[2]);
        //            ColorBlob.BlueTolerance = new Tuple<int, int, int>((int)BlueToleranceOut.rtcValue[0], (int)BlueToleranceOut.rtcValue[1], (int)BlueToleranceOut.rtcValue[2]);
        //            ColorBlob.GreenTolerance = new Tuple<int, int, int>((int)GreenToleranceOut.rtcValue[0], (int)GreenToleranceOut.rtcValue[1], (int)GreenToleranceOut.rtcValue[2]);
        //            ColorBlob.RedTolerance = new Tuple<int, int, int>((int)RedToleranceOut.rtcValue[0], (int)RedToleranceOut.rtcValue[1], (int)RedToleranceOut.rtcValue[2]);
        //            ColorBlob.IsShowImageResult = true;
        //            bool result = ColorBlob.Run();
        //            err = ColorBlob.ErrMessage;
        //            NumberOfBlobsFound.rtcValue = new List<double>() { ColorBlob.NumberOfBlobsFound };
        //            Passed.rtcValue = ColorBlob.Passed;
        //            OutputBlobList.rtcValue = ColorBlob.OutputBlobList;
        //            if (WindowHandle.rtcValue.InvokeRequired)
        //            {
        //                WindowHandle.rtcValue.Invoke(new Action(() =>
        //                {

        //                    WindowHandle.rtcValue.Image = ColorBlob.OutputImageShow;


        //                }));
        //            }
        //            else
        //            {
        //                WindowHandle.rtcValue.Image = ColorBlob.OutputImageShow;
        //            }


        //        }
        //    }
        //    //bitmapImage?.Dispose();
        //    //GC.Collect();
        //    //GC.WaitForPendingFinalizers();
        //}
        private void Run_ColorBlob()
        {
            ColorBlob = new Blob_Color_Multi_ROI.BlobColor();
            //Bitmap bitmapImage = null;
            //lock (_lockImage)
            //    bitmapImage = (Bitmap)InputImage.rtcValue.Clone();
            //Image<Bgr, byte> Input_Image = null;
            //lock (_lockImage)
            //    Input_Image = bitmapImage.ToImage<Bgr, byte>();
            ColorBlob.InputImage = InputBgrImage.rtcValue?.Clone();
            //InputBgrImage.rtcValue.Save(@"D:\1_2.bmp");
            Tuple<Point, double> toolOrigin = Tuple.Create(new Point(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                ToolOrigin.rtcValue[2]);
            Tuple<PointF, double> toolOriginF = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
              ToolOrigin.rtcValue[2]);
            List<RTCRectangle> ROIs = new List<RTCRectangle>();
            if (!RunIsSilent.rtcValue && TabRoiActive.rtcValue)
            {
                if (ColorSpace.rtcValue == cBlobColorTool.ColorSpace_HSV)
                {
                    ColorBlob.HueTolerance = Tuple.Create((int)HueToleranceOut.rtcValue[0], (int)HueToleranceOut.rtcValue[1], (int)HueToleranceOut.rtcValue[2]);
                    ColorBlob.SaturationTolerance = Tuple.Create((int)SaturationTolerance.rtcValue[0], (int)SaturationTolerance.rtcValue[1], (int)SaturationTolerance.rtcValue[2]);
                    ColorBlob.IntensityTolerance = Tuple.Create((int)IntensityTolerance.rtcValue[0], (int)IntensityTolerance.rtcValue[1], (int)IntensityTolerance.rtcValue[2]);
                }
                else
                {
                    ColorBlob.RedTolerance = Tuple.Create((int)RedTolerance.rtcValue[0], (int)RedTolerance.rtcValue[1], (int)RedTolerance.rtcValue[2]);
                    ColorBlob.GreenTolerance = Tuple.Create((int)GreenTolerance.rtcValue[0], (int)GreenTolerance.rtcValue[1], (int)GreenTolerance.rtcValue[2]);
                    ColorBlob.BlueTolerance = Tuple.Create((int)BlueTolerance.rtcValue[0], (int)BlueTolerance.rtcValue[1], (int)BlueTolerance.rtcValue[2]);
                }
            }
            if (!RunIsSilent.rtcValue && TrainPressed.rtcValue)
            {
                ColorBlob.ToolOrigin = Tuple.Create(new Point(0, 0), 0.0);
                toolOriginF = Tuple.Create(new PointF(0, 0), 0.0);
                RTCRectangle Rect = new RTCRectangle();
                Rect.Height = InputImage.rtcValue.Height;
                Rect.Width = InputImage.rtcValue.Width;
                foreach (object ROI in this.ROIs.Values)
                {
                    cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
                    RTCRectangle Data = new RTCRectangle();
                    long OldID = ROIB.ID;
                    switch (ROIB.DrawingType)
                    {
                        case EDrawingtypes.Rectang:
                            {

                                cRectangType Rec = (cRectangType)ROI;
                                Data.Phi = (float)Rec.Phi * Math.PI / 180;
                                Data.Width = (float)Rec.Width * 2;
                                Data.Height = (float)Rec.Height * 2;
                                Data.Center = new RTCPoint(Rec.Center.Row, Rec.Center.Col, 0);
                                ROIs.Add(Data);

                                //SmartWindow.DrawROI(DataRoi);
                                break;
                            }
                        case EDrawingtypes.Ellipse:
                            {
                                if (ROIProperties[ROIB.ID].Selected)
                                {
                                    cEllipseType Ell = (cEllipseType)ROI;
                                    Data.Phi = (float)Ell.Phi;
                                    Data.Width = (float)Ell.Radius1;
                                    Data.Height = (float)Ell.Radius2;
                                    Data.Center = new RTCPoint(Ell.Center.Row, Ell.Center.Col, 0);
                                    ROIs.Add(Data);
                                }
                                break;

                            }
                    }
                }
                if (ROIs.Count > 0)
                {
                    ColorBlob.ROITrain = ROIs;

                }
                else
                {
                    ColorBlob.ROITrain = new List<RTCRectangle> { Rect };
                }
                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOriginF));
                //_BlobTool.InSetOrigin = SetOrigin.Run(ROIs, toolOrigin);
                ColorBlob.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue);
                bool trainsucces = ColorBlob.Train();
                if (trainsucces)
                {
                    HueToleranceOut.rtcValue = new List<double> { (double)ColorBlob.HueTolerance.Item1, (double)ColorBlob.HueTolerance.Item2, (double)ColorBlob.HueTolerance.Item3 };
                    IntensityToleranceOut.rtcValue = new List<double> { (double)ColorBlob.IntensityTolerance.Item1, (double)ColorBlob.IntensityTolerance.Item2, (double)ColorBlob.IntensityTolerance.Item3 };
                    SaturationToleranceOut.rtcValue = new List<double> { (double)ColorBlob.SaturationTolerance.Item1, (double)ColorBlob.SaturationTolerance.Item2, (double)ColorBlob.SaturationTolerance.Item3 };
                    BlueToleranceOut.rtcValue = new List<double> { (double)ColorBlob.BlueTolerance.Item1, (double)ColorBlob.BlueTolerance.Item2, (double)ColorBlob.BlueTolerance.Item3 };
                    GreenToleranceOut.rtcValue = new List<double> { (double)ColorBlob.GreenTolerance.Item1, (double)ColorBlob.GreenTolerance.Item2, (double)ColorBlob.GreenTolerance.Item3 };
                    RedToleranceOut.rtcValue = new List<double> { (double)ColorBlob.RedTolerance.Item1, (double)ColorBlob.RedTolerance.Item2, (double)ColorBlob.RedTolerance.Item3 };
                    TrainPressed.rtcActive = true;
                }
                ColorBlob.ColorSpace = ColorSpace.rtcValue;
                string err = ColorBlob.ErrMessage;

                ColorBlob.FillHoles = FillHoles.rtcValue;
                ColorBlob.RequireNumberOfBlobs = new Tuple<int, int>(int.Parse(RequiredNumberOfBlobs.rtcValue[0].ToString()), int.TryParse(RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Result) ? Result : 100);
                ColorBlob.EnableAreaFilter = EnableAreaFilter.rtcValue;
                if (EnableAreaFilter.rtcValue)
                    ColorBlob.AreaRange = new Tuple<double, double>(AreaRange.rtcValue[0], AreaRange.rtcValue[1]);
                ColorBlob.EnableWidthFilter = EnableWidthFilter.rtcValue;
                if (EnableWidthFilter.rtcValue)
                    ColorBlob.WidthRange = new Tuple<double, double>(WidthRange.rtcValue[0], WidthRange.rtcValue[1]);
                ColorBlob.EnableHeightFilter = EnableHeightFilter.rtcValue;
                if (EnableHeightFilter.rtcValue)
                    ColorBlob.HeightRange = new Tuple<double, double>(HeightRange.rtcValue[0], HeightRange.rtcValue[1]);
                ColorBlob.EnableColumnFilter = EnableColumnFilter.rtcValue;
                if (EnableColumnFilter.rtcValue)
                    ColorBlob.ColumnRange = new Tuple<double, double>(ColumnRange.rtcValue[0], ColumnRange.rtcValue[1]);
                ColorBlob.EnableRowFilter = EnableRowFilter.rtcValue;
                if (EnableRowFilter.rtcValue)
                    ColorBlob.RowRange = new Tuple<double, double>(RowRange.rtcValue[0], RowRange.rtcValue[1]);
                ColorBlob.HueTolerance = new Tuple<int, int, int>((int)HueToleranceOut.rtcValue[0], (int)HueToleranceOut.rtcValue[1], (int)HueToleranceOut.rtcValue[2]);
                ColorBlob.SaturationTolerance = new Tuple<int, int, int>((int)SaturationToleranceOut.rtcValue[0], (int)SaturationToleranceOut.rtcValue[1], (int)SaturationToleranceOut.rtcValue[2]);
            }
            else if (TabPassActive.rtcValue || RunIsSilent.rtcValue || !GlobVar.RunningProcess)
            {
                ColorBlob.ToolOrigin = toolOrigin;

                RTCRectangle Rect = new RTCRectangle();
                Rect.Height = InputImage.rtcValue.Height;
                Rect.Width = InputImage.rtcValue.Width;
                //  var DataROI = frmHsmartWindow.Action.ROIs.Values.Cast<cRectangType>;
                if (this.FindROIs == null)
                    return;
                foreach (object ROI in this.FindROIs.Values)
                {
                    cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
                    RTCRectangle Data = new RTCRectangle();
                    long OldID = ROIB.ID;
                    switch (ROIB.DrawingType)
                    {
                        case EDrawingtypes.Rectang:
                            {
                                cRectangType Rec = (cRectangType)ROI;
                                Data.Phi = (float)Rec.Phi * Math.PI / 180;
                                Data.Width = (float)Rec.Width * 2;
                                Data.Height = (float)Rec.Height * 2;
                                Data.Center = new RTCPoint(Rec.Center.Row, Rec.Center.Col, 0);
                                ROIs.Add(Data);
                                //SmartWindow.DrawROI(DataRoi);
                                break;
                            }
                        case EDrawingtypes.Ellipse:
                            {
                                cEllipseType Ell = (cEllipseType)ROI;
                                Data.Phi = (float)Ell.Phi;
                                Data.Width = (float)Ell.Radius1;
                                Data.Height = (float)Ell.Radius2;
                                Data.Center = new RTCPoint(Ell.Center.Row, Ell.Center.Col, 0);
                                ROIs.Add(Data);
                                break;
                            }
                    }
                }

                if (ROIs.Count > 0)
                {
                    ColorBlob.ROITrain = ROIs;
                    ColorBlob.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue);
                    InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOriginF));
                    //_BlobTool.InSetOrigin = SetOrigin.Run(ROIs, toolOrigin);
                    ColorBlob.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue);
                }
                else
                {
                    ColorBlob.InSetOrigin = null;
                }
                //    RedToleranceOut.rtcValue = new List<double> { (double)ColorBlob.RedTolerance.Item1, (double)ColorBlob.RedTolerance.Item2, (double)ColorBlob.RedTolerance.Item3 };
                //}
                ColorBlob.ColorSpace = ColorSpace.rtcValue;
                string err = ColorBlob.ErrMessage;

                ColorBlob.FillHoles = FillHoles.rtcValue;
                ColorBlob.RequireNumberOfBlobs = new Tuple<int, int>(int.Parse(RequiredNumberOfBlobs.rtcValue[0].ToString()), int.TryParse(RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Result) ? Result : 100);
                ColorBlob.EnableAreaFilter = EnableAreaFilter.rtcValue;
                if (EnableAreaFilter.rtcValue)
                    ColorBlob.AreaRange = new Tuple<double, double>(AreaRange.rtcValue[0], AreaRange.rtcValue[1]);
                ColorBlob.EnableWidthFilter = EnableWidthFilter.rtcValue;
                if (EnableWidthFilter.rtcValue)
                    ColorBlob.WidthRange = new Tuple<double, double>(WidthRange.rtcValue[0], WidthRange.rtcValue[1]);
                ColorBlob.EnableHeightFilter = EnableHeightFilter.rtcValue;
                if (EnableHeightFilter.rtcValue)
                    ColorBlob.HeightRange = new Tuple<double, double>(HeightRange.rtcValue[0], HeightRange.rtcValue[1]);
                ColorBlob.EnableColumnFilter = EnableColumnFilter.rtcValue;
                if (EnableColumnFilter.rtcValue)
                    ColorBlob.ColumnRange = new Tuple<double, double>(ColumnRange.rtcValue[0], ColumnRange.rtcValue[1]);
                ColorBlob.EnableRowFilter = EnableRowFilter.rtcValue;
                if (EnableRowFilter.rtcValue)
                    ColorBlob.RowRange = new Tuple<double, double>(RowRange.rtcValue[0], RowRange.rtcValue[1]);

                ColorBlob.HueTolerance = new Tuple<int, int, int>((int)HueToleranceOut.rtcValue[0], (int)HueToleranceOut.rtcValue[1], (int)HueToleranceOut.rtcValue[2]);
                ColorBlob.SaturationTolerance = new Tuple<int, int, int>((int)SaturationToleranceOut.rtcValue[0], (int)SaturationToleranceOut.rtcValue[1], (int)SaturationToleranceOut.rtcValue[2]);
                ColorBlob.IntensityTolerance = new Tuple<int, int, int>((int)IntensityToleranceOut.rtcValue[0], (int)IntensityToleranceOut.rtcValue[1], (int)IntensityToleranceOut.rtcValue[2]);
                ColorBlob.BlueTolerance = new Tuple<int, int, int>((int)BlueToleranceOut.rtcValue[0], (int)BlueToleranceOut.rtcValue[1], (int)BlueToleranceOut.rtcValue[2]);
                ColorBlob.GreenTolerance = new Tuple<int, int, int>((int)GreenToleranceOut.rtcValue[0], (int)GreenToleranceOut.rtcValue[1], (int)GreenToleranceOut.rtcValue[2]);
                ColorBlob.RedTolerance = new Tuple<int, int, int>((int)RedToleranceOut.rtcValue[0], (int)RedToleranceOut.rtcValue[1], (int)RedToleranceOut.rtcValue[2]);
                ColorBlob.IsShowImageResult = true;
                bool result = ColorBlob.Run();
                err = ColorBlob.ErrMessage;
                if (err == null)
                {
                    if (err == null)
                    {
                        NumberOfBlobsFound.rtcValue = new List<double>() { ColorBlob.NumberOfBlobsFound };
                        Passed.rtcValue = ColorBlob.Passed;
                        OutputBlobList.rtcValue = ColorBlob.OutputBlobList;
                        OutputAreaList.rtcValue = ColorBlob.OutputAreaList;
                        OutputHeightList.rtcValue = ColorBlob.OutputHeightList.Select(x => (double)x).ToList();
                        OutputWidthList.rtcValue = ColorBlob.OutputWidthList.Select(x => (double)x).ToList();
                        if (WindowHandle.rtcValue.InvokeRequired)
                        {
                            WindowHandle.rtcValue.Invoke(new Action(() =>
                            {
                                WindowHandle.rtcValue.Image = ColorBlob.OutputImageShow;
                            }));
                        }
                        else
                        {
                            WindowHandle.rtcValue.Image = ColorBlob.OutputImageShow;
                        }
                    }
                    else
                    {
                        ErrMessage.rtcValue.Add(err);
                        Passed.rtcValue = false;
                    }

                }
                //bitmapImage?.Dispose();
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            }
            // ColorBlob.ToolOrigin


            //bool trainsucces = ColorBlob.Train();
            //if (trainsucces)
            //{
            //    HueToleranceOut.rtcValue = new List<double> { (double)ColorBlob.HueTolerance.Item1, (double)ColorBlob.HueTolerance.Item2, (double)ColorBlob.HueTolerance.Item3 };
            //    IntensityToleranceOut.rtcValue = new List<double> { (double)ColorBlob.IntensityTolerance.Item1, (double)ColorBlob.IntensityTolerance.Item2, (double)ColorBlob.IntensityTolerance.Item3 };
            //    SaturationToleranceOut.rtcValue = new List<double> { (double)ColorBlob.SaturationTolerance.Item1, (double)ColorBlob.SaturationTolerance.Item2, (double)ColorBlob.SaturationTolerance.Item3 };
            //    BlueToleranceOut.rtcValue = new List<double> { (double)ColorBlob.BlueTolerance.Item1, (double)ColorBlob.BlueTolerance.Item2, (double)ColorBlob.BlueTolerance.Item3 };
            //    GreenToleranceOut.rtcValue = new List<double> { (double)ColorBlob.GreenTolerance.Item1, (double)ColorBlob.GreenTolerance.Item2, (double)ColorBlob.GreenTolerance.Item3 };

        }
        private void Run_SplitImage()
        {

            Tuple<PointF, double> toolOrigin;

            //OutputImage.rtcValue = DistanceMeasurementTool.OutputImage;
            if (ToolOrigin.rtcValue.Count < 3)
            {
                toolOrigin = Tuple.Create(new PointF(0, 0), 0.0);
            }
            else
            {
                toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                   ToolOrigin.rtcValue[2]);
            }
            List<RTCRectangle> ROIs = new List<RTCRectangle>();
            Dictionary<long, RTCRectangle> DataShapes = GlobFuncs.GenShapeList(ShapeListOriginal);
            foreach (long key in DataShapes.Keys)
            {
                ROIs.Add(DataShapes[key]);
            }
            if (ROIs.Count <= 0)
            {
                ROIs.Add(GlobFuncs.GenRectangleImage(InputImage.rtcValue));
            }
            if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
            {
                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOrigin));
            }
            SplitImage.InputImageGray = InputGrayImage.rtcValue.Clone();
            SplitImage.InputImageColor = InputBgrImage.rtcValue.Clone();
            SplitImage.IsImageColor = true;
            SplitImage.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue);
            SplitImage.InputRegion = InputRegion.rtcValue;
            SplitImage.IsAdaptImageSize = AdaptImageSize.rtcValue;
            SplitImage.ColumnNumber = Lib.ToInt(ColumnNumber.rtcValue[0]);
            SplitImage.RowNumber = Lib.ToInt(RowNumber.rtcValue[0]);
            SplitImage.SplitROIType = ShapeListROIType.rtcValue;
            SplitImage.SplitType = SplitType.rtcValue;
            SplitImage.ROI = DataShapes.Values.Cast<RTCRectangle>().ToList();
            SplitImage.ToolOrigin = toolOrigin;
            SplitImage.IsShowImageResult = true;
            bool Result = SplitImage.Run();
            if (WindowHandle.rtcValue.InvokeRequired)
            {
                WindowHandle.rtcValue.Invoke(new Action(() =>
                {
                    //OutputGrayImage.rtcValue = SplitImage.OutputImage;
                    OutputImage.rtcValue = SplitImage.OutputImageShow;
                    //WindowHandle.rtcValue.Image = GlobFuncs.BitmapToBgrImage(SplitImage.OutputImage).ToBitmap();
                    WindowHandle.rtcValue.Image = SplitImage.OutputImageShow;
                }));
            }
            else
            {
                // OutputGrayImage.rtcValue = SplitImage.OutputImage;

                OutputImage.rtcValue = SplitImage.OutputImageShow;
                //WindowHandle.rtcValue.Image = GlobFuncs.BitmapToBgrImage(SplitImage.OutputImage).ToBitmap();

                WindowHandle.rtcValue.Image = SplitImage.OutputImageShow;
            }
            if (SaveMode.rtcValue == cSplitSaveMode.Folder)
            {
                //GlobFuncs.BitmapToBgrImage(SplitImage.OutputImage).ToBitmap().Save($"{FolderName.rtcValue}" + "/" + $"{this.Name.rtcValue}" + ".bmp");
                SplitImage.OutputImage[0].Save($"{FolderName.rtcValue}" + "/" + $"{this.Name.rtcValue}{this.MyGroup.SourceImageSettings.ComputerSettings.CurrentImgIndex}-1" + ".png");
                SplitImage.OutputImage[1].Save($"{FolderName.rtcValue}" + "/" + $"{this.Name.rtcValue}{this.MyGroup.SourceImageSettings.ComputerSettings.CurrentImgIndex}-2" + ".png");
            }

        }
        private void Run_ColorBlobMultiROIs()
        {

            OutputBlobList.rtcValue = new List<VectorOfVectorOfPoint>();
            NumberOfBlobsFound.rtcValue = new List<double>();
            ColorBlobMultiROIS = new Blob_Color_Multi_ROI.BlobColor();
            BlobView = new Blob_View.BlobView();
            List<VectorOfVectorOfPoint> blobList = new List<VectorOfVectorOfPoint>();
            List<double> areaList = new List<double>();
            List<int> widthList = new List<int>();
            List<int> heightList = new List<int>();
            //Bitmap bitmapImage = null;
            //lock (_lockImage)
            //    bitmapImage = (Bitmap)InputImage.rtcValue.Clone();
            //Image<Bgr, byte> Input_Image = null;
            //lock (_lockImage)
            //    Input_Image = bitmapImage.ToImage<Bgr, byte>();
            ColorBlobMultiROIS.InputImage = InputBgrImage.rtcValue?.Clone();
            var toolOrigin = Tuple.Create(new Point(Int16.Parse(ToolOrigin.rtcValue[0].ToString()), Int16.Parse(ToolOrigin.rtcValue[1].ToString())), double.Parse(ToolOrigin.rtcValue[2].ToString()));
            ColorBlobMultiROIS.ToolOrigin = toolOrigin;
            Tuple<PointF, double> toolOriginF = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
              ToolOrigin.rtcValue[2]);
            List<RTCRectangle> ROIs = new List<RTCRectangle>();
            if (TrainPressed.rtcValue)
            {
                Dictionary<long, RTCRectangle> DataShapes = GlobFuncs.GenShapeList(ShapeList);
                foreach (long key in DataShapes.Keys)
                {
                    ROIs = new List<RTCRectangle>();
                    ROIs.Add(DataShapes[key]);
                    cROIProperty ROIProperty = this.ROIProperties[key];
                    ColorBlobMultiROIS.ROITrain = ROIs;
                    bool trainsucces = ColorBlobMultiROIS.Train();
                    if (trainsucces)
                    {
                        ROIProperty.HueTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.HueTolerance.Item1, (double)ColorBlobMultiROIS.HueTolerance.Item2, (double)ColorBlobMultiROIS.HueTolerance.Item3 };
                        ROIProperty.IntensityTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.IntensityTolerance.Item1, (double)ColorBlobMultiROIS.IntensityTolerance.Item2, (double)ColorBlobMultiROIS.IntensityTolerance.Item3 };
                        ROIProperty.SaturationTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.SaturationTolerance.Item1, (double)ColorBlobMultiROIS.SaturationTolerance.Item2, (double)ColorBlobMultiROIS.SaturationTolerance.Item3 };
                        ROIProperty.BlueTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.BlueTolerance.Item1, (double)ColorBlobMultiROIS.BlueTolerance.Item2, (double)ColorBlobMultiROIS.BlueTolerance.Item3 };
                        ROIProperty.GreenTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.GreenTolerance.Item1, (double)ColorBlobMultiROIS.GreenTolerance.Item2, (double)ColorBlobMultiROIS.GreenTolerance.Item3 };
                        ROIProperty.RedTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.RedTolerance.Item1, (double)ColorBlobMultiROIS.RedTolerance.Item2, (double)ColorBlobMultiROIS.RedTolerance.Item3 };
                        HueTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.HueTolerance.Item1, (double)ColorBlobMultiROIS.HueTolerance.Item2, (double)ColorBlobMultiROIS.HueTolerance.Item3 };
                        IntensityTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.IntensityTolerance.Item1, (double)ColorBlobMultiROIS.IntensityTolerance.Item2, (double)ColorBlobMultiROIS.IntensityTolerance.Item3 };
                        SaturationTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.SaturationTolerance.Item1, (double)ColorBlobMultiROIS.SaturationTolerance.Item2, (double)ColorBlobMultiROIS.SaturationTolerance.Item3 };
                        BlueTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.BlueTolerance.Item1, (double)ColorBlobMultiROIS.BlueTolerance.Item2, (double)ColorBlobMultiROIS.BlueTolerance.Item3 };
                        GreenTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.GreenTolerance.Item1, (double)ColorBlobMultiROIS.GreenTolerance.Item2, (double)ColorBlobMultiROIS.GreenTolerance.Item3 };
                        RedTolerance.rtcValue = new List<double> { (double)ColorBlobMultiROIS.RedTolerance.Item1, (double)ColorBlobMultiROIS.RedTolerance.Item2, (double)ColorBlobMultiROIS.RedTolerance.Item3 };
                    }
                    ColorBlobMultiROIS.ColorSpace = ROIProperty.ColorSpace.rtcValue;
                    string err = ColorBlobMultiROIS.ErrMessage;

                    ColorBlobMultiROIS.FillHoles = ROIProperty.FillHoles.rtcValue;
                    ColorBlobMultiROIS.RequireNumberOfBlobs = new Tuple<int, int>(int.Parse(ROIProperty.RequiredNumberOfBlobs.rtcValue[0].ToString()), int.TryParse(ROIProperty.RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Result) ? Result : 100);
                    ColorBlobMultiROIS.EnableAreaFilter = ROIProperty.EnableAreaFilter.rtcValue;
                    if (EnableAreaFilter.rtcValue)
                        ColorBlobMultiROIS.AreaRange = new Tuple<double, double>(ROIProperty.AreaRange.rtcValue[0], ROIProperty.AreaRange.rtcValue[1]);
                    ColorBlobMultiROIS.EnableWidthFilter = ROIProperty.EnableWidthFilter.rtcValue;
                    if (EnableWidthFilter.rtcValue)
                        ColorBlobMultiROIS.WidthRange = new Tuple<double, double>(ROIProperty.WidthRange.rtcValue[0], ROIProperty.WidthRange.rtcValue[1]);
                    ColorBlobMultiROIS.EnableHeightFilter = EnableHeightFilter.rtcValue;
                    if (EnableHeightFilter.rtcValue)
                        ColorBlobMultiROIS.HeightRange = new Tuple<double, double>(ROIProperty.HeightRange.rtcValue[0], ROIProperty.HeightRange.rtcValue[1]);
                    ColorBlobMultiROIS.EnableColumnFilter = ROIProperty.EnableColumnFilter.rtcValue;
                    if (EnableColumnFilter.rtcValue)
                        ColorBlobMultiROIS.ColumnRange = new Tuple<double, double>(ColumnRange.rtcValue[0], ColumnRange.rtcValue[1]);
                    ColorBlobMultiROIS.EnableRowFilter = EnableRowFilter.rtcValue;
                    if (EnableRowFilter.rtcValue)
                        ColorBlobMultiROIS.RowRange = new Tuple<double, double>(RowRange.rtcValue[0], RowRange.rtcValue[1]);

                    ColorBlobMultiROIS.HueTolerance = new Tuple<int, int, int>((int)ROIProperty.HueTolerance.rtcValue[0], (int)ROIProperty.HueTolerance.rtcValue[1], (int)HueTolerance.rtcValue[2]);
                    ColorBlobMultiROIS.SaturationTolerance = new Tuple<int, int, int>((int)ROIProperty.SaturationTolerance.rtcValue[0], (int)SaturationTolerance.rtcValue[1], (int)SaturationTolerance.rtcValue[2]);
                    ColorBlobMultiROIS.IntensityTolerance = new Tuple<int, int, int>((int)ROIProperty.IntensityTolerance.rtcValue[0], (int)ROIProperty.IntensityTolerance.rtcValue[1], (int)IntensityTolerance.rtcValue[2]);
                    ColorBlobMultiROIS.BlueTolerance = new Tuple<int, int, int>((int)ROIProperty.BlueTolerance.rtcValue[0], (int)ROIProperty.BlueTolerance.rtcValue[1], (int)ROIProperty.BlueTolerance.rtcValue[2]);
                    ColorBlobMultiROIS.GreenTolerance = new Tuple<int, int, int>((int)ROIProperty.GreenTolerance.rtcValue[0], (int)ROIProperty.GreenTolerance.rtcValue[1], (int)ROIProperty.GreenTolerance.rtcValue[2]);
                    ColorBlobMultiROIS.RedTolerance = new Tuple<int, int, int>((int)ROIProperty.RedTolerance.rtcValue[0], (int)ROIProperty.RedTolerance.rtcValue[1], (int)ROIProperty.RedTolerance.rtcValue[2]);
                    ColorBlobMultiROIS.IsShowImageResult = true;

                    bool result = ColorBlobMultiROIS.Run();
                    err = ColorBlobMultiROIS.ErrMessage;


                    if (WindowHandle.rtcValue.InvokeRequired)
                    {
                        WindowHandle.rtcValue.Invoke(new Action(() =>
                        {
                            WindowHandle.rtcValue.Image = ColorBlobMultiROIS.OutputImageShow;

                        }));
                    }
                    else
                    {
                        WindowHandle.rtcValue.Image = ColorBlobMultiROIS.OutputImageShow;

                    }
                    TrainPressed.rtcValue = false;
                }

            }
            else
            {
                //  var DataROI = frmHsmartWindow.Action.ROIs.Values.Cast<cRectangType>;
                Dictionary<long, RTCRectangle> DataShapes = GlobFuncs.GenShapeList(ShapeList);
                var test = ShapeListData.rtcValue;
                foreach (long key in DataShapes.Keys)
                {
                    for (int i = 0; i < ShapeListData.rtcValue.Count; i = i + 36)
                    {
                        if (GlobFuncs.Object2Long(ShapeListData.rtcValue[i + 0]) == key)
                        {
                            ColorBlobMultiROIS.InputImage = InputBgrImage.rtcValue?.Clone();
                            toolOrigin = Tuple.Create(new Point(Int16.Parse(ToolOrigin.rtcValue[0].ToString()), Int16.Parse(ToolOrigin.rtcValue[1].ToString())), double.Parse(ToolOrigin.rtcValue[2].ToString()));
                            ColorBlobMultiROIS.ToolOrigin = toolOrigin;
                            ROIs = new List<RTCRectangle>();
                            RTCRectangle Data = new RTCRectangle();
                            cROIProperty ROIProperty = this.ROIProperties[key];
                            ROIs.Add(DataShapes[key]);
                            ColorBlobMultiROIS.ROITrain = new List<RTCRectangle>();
                            ColorBlobMultiROIS.ROITrain = ROIs;
                            bool trainsucces = ColorBlobMultiROIS.Train();

                            ColorBlobMultiROIS.ColorSpace = ROIProperty.ColorSpace.rtcValue;
                            string err = ColorBlobMultiROIS.ErrMessage;

                            ColorBlobMultiROIS.FillHoles = ROIProperty.FillHoles.rtcValue;
                            ColorBlobMultiROIS.RequireNumberOfBlobs = new Tuple<int, int>(int.Parse(ROIProperty.RequiredNumberOfBlobs.rtcValue[0].ToString()), int.TryParse(RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Result) ? Result : 100);
                            //ColorBlobMultiROIS.Re = ROIProperty.RequiredPass.rtcValue;
                            ColorBlobMultiROIS.EnableAreaFilter = ROIProperty.EnableAreaFilter.rtcValue;
                            if (ROIProperty.EnableAreaFilter.rtcValue)
                                ColorBlobMultiROIS.AreaRange = new Tuple<double, double>(ROIProperty.AreaRange.rtcValue[0], ROIProperty.AreaRange.rtcValue[1]);
                            ColorBlobMultiROIS.EnableWidthFilter = ROIProperty.EnableWidthFilter.rtcValue;
                            if (ROIProperty.EnableWidthFilter.rtcValue)
                                ColorBlobMultiROIS.WidthRange = new Tuple<double, double>(ROIProperty.WidthRange.rtcValue[0], ROIProperty.WidthRange.rtcValue[1]);
                            ColorBlobMultiROIS.EnableHeightFilter = EnableHeightFilter.rtcValue;
                            if (ROIProperty.EnableHeightFilter.rtcValue)
                                ColorBlobMultiROIS.HeightRange = new Tuple<double, double>(ROIProperty.HeightRange.rtcValue[0], ROIProperty.HeightRange.rtcValue[1]);
                            ColorBlobMultiROIS.EnableColumnFilter = EnableColumnFilter.rtcValue;
                            if (ROIProperty.EnableColumnFilter.rtcValue)
                                ColorBlobMultiROIS.ColumnRange = new Tuple<double, double>(ColumnRange.rtcValue[0], ColumnRange.rtcValue[1]);
                            ColorBlobMultiROIS.EnableRowFilter = EnableRowFilter.rtcValue;
                            if (ROIProperty.EnableRowFilter.rtcValue)
                                ColorBlobMultiROIS.RowRange = new Tuple<double, double>(RowRange.rtcValue[0], RowRange.rtcValue[1]);
                            ColorBlobMultiROIS.HueTolerance = new Tuple<int, int, int>((int)ROIProperty.HueTolerance.rtcValue[0], (int)ROIProperty.HueTolerance.rtcValue[1], (int)ROIProperty.HueTolerance.rtcValue[2]);
                            ColorBlobMultiROIS.SaturationTolerance = new Tuple<int, int, int>((int)ROIProperty.SaturationTolerance.rtcValue[0], (int)ROIProperty.SaturationTolerance.rtcValue[1], (int)ROIProperty.SaturationTolerance.rtcValue[2]);
                            ColorBlobMultiROIS.IntensityTolerance = new Tuple<int, int, int>((int)ROIProperty.IntensityTolerance.rtcValue[0], (int)ROIProperty.IntensityTolerance.rtcValue[1], (int)ROIProperty.IntensityTolerance.rtcValue[2]);
                            ColorBlobMultiROIS.BlueTolerance = new Tuple<int, int, int>((int)ROIProperty.BlueTolerance.rtcValue[0], (int)ROIProperty.BlueTolerance.rtcValue[1], (int)ROIProperty.BlueTolerance.rtcValue[2]);
                            ColorBlobMultiROIS.GreenTolerance = new Tuple<int, int, int>((int)ROIProperty.GreenTolerance.rtcValue[0], (int)ROIProperty.GreenTolerance.rtcValue[1], (int)ROIProperty.GreenTolerance.rtcValue[2]);
                            ColorBlobMultiROIS.RedTolerance = new Tuple<int, int, int>((int)ROIProperty.RedTolerance.rtcValue[0], (int)ROIProperty.RedTolerance.rtcValue[1], (int)ROIProperty.RedTolerance.rtcValue[2]);
                            ColorBlobMultiROIS.IsShowImageResult = true;
                            ColorBlobMultiROIS.InSetOrigin = SetOrigin.Run(ROIs, toolOriginF);

                            ColorBlobMultiROIS.Run();
                            //  ColorBlobMultiROIS.OutputImage.Save(@"D:\Test2.bmp");
                            err = ColorBlobMultiROIS.ErrMessage;
                            BlobView.InputImage = InputGrayImage.rtcValue.Clone();

                            blobList.AddRange(ColorBlobMultiROIS.OutputBlobList);
                            areaList.AddRange(ColorBlobMultiROIS.OutputAreaList);
                            widthList.AddRange(ColorBlobMultiROIS.OutputWidthList);
                            heightList.AddRange(ColorBlobMultiROIS.OutputHeightList);
                            BlobView.InputBlobList = blobList;
                            BlobView.InputAreaList = areaList;
                            BlobView.InputHeightList = heightList;
                            BlobView.InputWidthList = widthList;
                            BlobView.IsShowImageResult = true;
                            BlobView.Run();
                            OutputBlobList.rtcValue.AddRange(ColorBlobMultiROIS.OutputBlobList);
                            NumberOfBlobsFound.rtcValue.Add(ColorBlobMultiROIS.NumberOfBlobsFound);

                            NumberOfBlobsFound.rtcValue = new List<double>() { NumberOfBlobsFound.rtcValue.Sum() };
                        }
                    }

                }

                if (WindowHandle.rtcValue.InvokeRequired)
                {
                    WindowHandle.rtcValue.Invoke(new Action(() =>
                    {

                        NumberOfBlobsFound.rtcValue = new List<double>() { ColorBlobMultiROIS.NumberOfBlobsFound };
                        if (OutputBlobList != null && OutputBlobList.rtcValue.Count > 0)
                        {
                            WindowHandle.rtcValue.Image = BlobView.OutputImageShow;
                            OutputAreaList.rtcValue = ColorBlobMultiROIS.OutputAreaList;
                            //OutputWidthList.rtcValue = ColorBlobMultiROIS.OutputWidthList.Cast<double>().ToList();
                            //OutputHeightList.rtcValue = ColorBlobMultiROIS.OutputHeightList.Cast<double>().ToList();

                        }
                    }));
                }
                else
                {
                    NumberOfBlobsFound.rtcValue = new List<double>() { ColorBlobMultiROIS.NumberOfBlobsFound };
                    if (OutputBlobList != null && OutputBlobList.rtcValue.Count > 0)
                    {
                        WindowHandle.rtcValue.Image = BlobView.OutputImageShow;
                        OutputAreaList.rtcValue = ColorBlobMultiROIS.OutputAreaList;
                        //OutputWidthList.rtcValue = ColorBlobMultiROIS.OutputWidthList.Cast<double>().ToList();
                        //OutputHeightList.rtcValue = ColorBlobMultiROIS.OutputHeightList.Cast<double>().ToList();
                        Passed.rtcValue = ColorBlobMultiROIS.Passed;
                    }
                }

            }
        }

        private void Run_LineFind()
        {
            LineFind = new LineFindTool.LineFind();

            LineFind.InputImage = InputGrayImage.rtcValue.Clone();
            Tuple<PointF, double> toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                ToolOrigin.rtcValue[2]);
            LineFind.ToolOrigin = toolOrigin;
            //LineFind.SetToolOrigin();
            List<RTCRectangle> ROIs = new List<RTCRectangle>();
            Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(ShapeList);

            foreach (object ROI in this.ROIs.Values)
            {
                cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
                long OldID = ROIB.ID;
                switch (ROIB.DrawingType)
                {
                    case EDrawingtypes.Rectang:
                        {
                            cRectangType Rec = (cRectangType)ROI;
                            RTCRectangle Data = new RTCRectangle();
                            Data.Phi = (float)Rec.Phi * Math.PI / 180;
                            Data.Width = (float)Rec.Width * 2;
                            Data.Height = (float)Rec.Height * 2;
                            Data.Center = new RTCPoint(Rec.Center.Row, Rec.Center.Col, 0);

                            ROIs.Add(Data);
                            //SmartWindow.DrawROI(DataRoi);
                            break;
                        }
                    case EDrawingtypes.Ellipse:
                        {
                            cEllipseType Ell = (cEllipseType)ROI;
                            RTCRectangle Data = new RTCRectangle();
                            Data.Phi = (float)Ell.Phi;
                            Data.Width = (float)Ell.Radius1;
                            Data.Height = (float)Ell.Radius2;
                            Data.Center = new RTCPoint(Ell.Center.Row, Ell.Center.Col, 0);
                            ROIs.Add(Data);
                            //SmartWindow.DrawROI(DataRoi);
                            break;
                        }
                }
                LineFind.ROI = ROIs[0];
            }
            if (ROIs.Count <= 0)
            {
                RTCRectangle Default = new RTCRectangle();
                Default.Width = InputImage.rtcValue.Width;
                Default.Height = InputImage.rtcValue.Height;
                Default.Center = new RTCPoint(InputImage.rtcValue.Width / 2, InputImage.rtcValue.Height / 2, 0);
                LineFind.ROI = Default;
            }
            LineFind.ToolOrigin = toolOrigin;
            if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
            {
                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOrigin));
            }
            LineFind.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue)[0];
            LineFind.EdgeTransition = EdgeTransition.rtcValue;
            LineFind.EdgeType = EdgeType.rtcValue.Trim();
            LineFind.EdgeDetectionThreshold = EdgeDetectionThreshold.rtcValue;
            LineFind.SamplingPercent = SamplingPercent.rtcValue;
            LineFind.OutlierDistanceThreshold = 5;
            LineFind.StepFindPoint = 10;
            LineFind.MaxPercentageOfOutliers = MaxPercentageOfOutliers.rtcValue;
            LineFind.MinEdgePointNumber = MinEdgePointNumber.rtcValue;
            LineFind.IsShowImageResult = true;

            LineFind.EnableGapLengthCheck = EnableGapLengthCheck.rtcValue;
            LineFind.GapLengthRange = new Tuple<double, double>(GapLengthRange.rtcValue[0], GapLengthRange.rtcValue[1]);

            LineFind.EnableLineLengthCheck = EnableLineLengthCheck.rtcValue;
            LineFind.LineLengthTolerance = new Tuple<double, double, double>(LineLengthTolerance.rtcValue[0], LineLengthTolerance.rtcValue[1], LineLengthTolerance.rtcValue[2]);

            LineFind.EnableAngleRangeCheck = EnableAngleRangeCheck.rtcValue;
            LineFind.IsShowImageResult = !GlobVar.RunningProcess;
            LineFind.LineAngleTolerance = new Tuple<double, double, double>(LineAngleTolerance.rtcValue[0], LineAngleTolerance.rtcValue[1], LineAngleTolerance.rtcValue[2]);
            bool result = LineFind.Run();
            string err = LineFind.ErrMessage;

            Passed.rtcValue = LineFind.Passed;
            GreatestGapLength.rtcValue = LineFind.GreatestGapLength;
            OutputPointList.rtcValue = GlobFuncs.ListPointToListDouble(LineFind.OutputPointList);
            EdgePoints.rtcValue = GlobFuncs.ListPointToListDouble(LineFind.EdgePoints);
            OutlierPoints.rtcValue = GlobFuncs.ListPointToListDouble(LineFind.OutlierPoints);
            if (LineFind.LineSegment != null)
            {
                LineSegment.rtcValue = new List<double> { LineFind.LineSegment.Item1.X, LineFind.LineSegment.Item1.Y,
                                                      LineFind.LineSegment.Item2.X, LineFind.LineSegment.Item2.Y };
            }
            if (TabRoiActive.rtcValue)
            {
                bool setting = LineFind.GetImageSetting();
            }
            //lineA.rtcValue = new List<double> { LineFind.LineLengthActual };
            //LineAngleTolerance.rtcValue = new List<double> { LineFind.LineAngleActual };
            //PercentageOfOutliers.rtcValue =  LineFind.PercentageOfOutliers;
            if (!GlobVar.RunningProcess)
            {
                if (WindowHandle.rtcValue.InvokeRequired)
                {
                    WindowHandle.rtcValue.Invoke(new Action(() =>
                    {
                        WindowHandle.rtcValue.Image = LineFind.OutputImageShow;
                        WindowHandle.rtcValue.FitImage = true;
                    }));
                }
                else
                {
                    WindowHandle.rtcValue.Image = LineFind.OutputImageShow;
                    WindowHandle.rtcValue.FitImage = true;

                    // OutputImage.rtcValue = LineFind.OutputImage;
                }
            }
            WindowHandle.rtcValue.Refresh();

        }

        private void Run_Brightness()
        {
            BrightnessTool = new Brightness_Tool.Brightness();
            //OutputImage.rtcValue = DistanceMeasurementTool.OutputImage;

            BrightnessTool.InputImage = InputGrayImage.rtcValue?.Clone();
            BrightnessTool.Invert = Invert.rtcValue;
            BrightnessTool.BrightnessRange = new Tuple<double, double>(BrightnessRange.rtcValue[0], BrightnessRange.rtcValue[1]);
            List<RTCRectangle> ROIs = new List<RTCRectangle>();
            foreach (object ROI in this.ROIs.Values)
            {
                cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
                long OldID = ROIB.ID;
                switch (ROIB.DrawingType)
                {
                    case EDrawingtypes.Rectang:
                        {
                            cRectangType Rec = (cRectangType)ROI;
                            RTCRectangle Data = new RTCRectangle();
                            Data.Phi = (float)Rec.Phi * Math.PI / 180; ;
                            Data.Width = (float)Rec.Width * 2;
                            Data.Height = (float)Rec.Height * 2;
                            Data.Center = new RTCPoint(Rec.Center.Row, Rec.Center.Col, 0);
                            ROIs.Add(Data);
                            break;
                        }
                    case EDrawingtypes.Ellipse:
                        {
                            cEllipseType Ell = (cEllipseType)ROI;
                            RTCRectangle Data = new RTCRectangle();
                            Data.Phi = (float)Ell.Phi;
                            Data.Width = (float)Ell.Radius1;
                            Data.Height = (float)Ell.Radius2;
                            Data.Center = new RTCPoint(Ell.Center.Row, Ell.Center.Col, 0);
                            ROIs.Add(Data);
                            break;
                        }
                }
            }
            if (ROIs.Count > 0)
                BrightnessTool.ROI = ROIs[0];
            Tuple<Point, double> toolOrigin = Tuple.Create(new Point(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
               ToolOrigin.rtcValue[2]);
            Tuple<PointF, double> toolOriginF = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
             ToolOrigin.rtcValue[2]);
            BrightnessTool.ToolOrigin = toolOrigin;
            if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
            {
                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOriginF));
            }
            BrightnessTool.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue)[0];
            bool result = BrightnessTool.Run();
            string err = BrightnessTool.ErrMessage;
            Brightness.rtcValue = BrightnessTool.BrightnessValue;
            Passed.rtcValue = BrightnessTool.Passed;

        }


        private void Run_PixelCount()
        {
            PixelCount = new PixelCountTool.PixelCount();

            PixelCount.InputImage = InputGrayImage.rtcValue?.Clone();
            PixelCount.Invert = Invert.rtcValue;
            PixelCount.PixelColor = PixelColor.rtcValue;
            PixelCount.ThresholdMode = ThresholdMode.rtcValue;
            PixelCount.ThresholdRange = new Tuple<int, int>((int)ThresholdRange.rtcValue[0], (int)ThresholdRange.rtcValue[1]);
            PixelCount.PixelCountRange = new Tuple<int, int>((int)PixelCountRange.rtcValue[0], (int)PixelCountRange.rtcValue[1]);
            List<RTCRectangle> ROIs = new List<RTCRectangle>();
            //  var DataROI = frmHsmartWindow.Action.ROIs.Values.Cast<cRectangType>;
            foreach (object ROI in this.ROIs.Values)
            {
                cDrawingBaseType ROIB = (cDrawingBaseType)ROI;
                long OldID = ROIB.ID;
                switch (ROIB.DrawingType)
                {
                    case EDrawingtypes.Rectang:
                        {
                            cRectangType Rec = (cRectangType)ROI;
                            RTCRectangle Data = new RTCRectangle();
                            Data.Phi = (float)Rec.Phi * Math.PI / 180; ;
                            Data.Width = (float)Rec.Width * 2;
                            Data.Height = (float)Rec.Height * 2;
                            Data.Center = new RTCPoint(Rec.Center.Row, Rec.Center.Col, 0);

                            ROIs.Add(Data);
                            //SmartWindow.DrawROI(DataRoi);
                            break;
                        }
                    case EDrawingtypes.Ellipse:
                        {
                            cEllipseType Ell = (cEllipseType)ROI;
                            RTCRectangle Data = new RTCRectangle();
                            Data.Phi = (float)Ell.Phi;
                            Data.Width = (float)Ell.Radius1;
                            Data.Height = (float)Ell.Radius2;
                            Data.Center = new RTCPoint(Ell.Center.Row, Ell.Center.Col, 0);
                            ROIs.Add(Data);
                            //SmartWindow.DrawROI(DataRoi);
                            break;
                        }
                }
            }
            if (ROIs.Count > 0)
                PixelCount.ROI = ROIs[0];
            else
            {

                PixelCount.ROI = GlobFuncs.GenRectangleImage(InputImage.rtcValue);
            }
            //var toolOrigin = Tuple.Create(new Point(Int16.Parse(ToolOrigin.rtcValue[0].ToString()), Int16.Parse(ToolOrigin.rtcValue[1].ToString())),
            //   ToolOrigin.rtcValue[2]);
            Tuple<PointF, double> toolOriginF = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
            ToolOrigin.rtcValue[2]);
            Tuple<Point, double> toolOrigin = Tuple.Create(new Point(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
            ToolOrigin.rtcValue[2]);
            PixelCount.ToolOrigin = toolOrigin;
            if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
            {
                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOriginF));
            }
            PixelCount.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue).Count > 0 ? GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue)[0] : new PointF[4];
            PixelCount.ToolOrigin = toolOrigin;
            bool Result = PixelCount.Run();

            string Err = PixelCount.ErrMessage;
            Pixels.rtcValue = PixelCount.Pixels;
            if (WindowHandle.rtcValue.InvokeRequired)
            {
                WindowHandle.rtcValue.Invoke(new Action(() =>
                {

                    WindowHandle.rtcValue.Image = PixelCount.OutputImageShow;

                    WindowHandle.rtcValue.Refresh();
                    Passed.rtcValue = PixelCount.Passed;
                }));

            }
            else
            {
                WindowHandle.rtcValue.Image = PixelCount.OutputImageShow;
                WindowHandle.rtcValue.Refresh();
                Passed.rtcValue = PixelCount.Passed;

            }
        }

        private void Run_Switch()
        {
            isPrepare = false;
            MyExpression.CalculateMode = CalculateMode.rtcValue;
            MyExpression.Calculate();
            Passed.rtcValue = MyExpression.Result.bValue;
            Result.rtcValue = MyExpression.Result.hValue;
            var listBranchItems = MyGroup.Actions.Values.Where(x =>
            x.ActionType == EActionTypes.BranchItem && x.IDBranch == ID).ToList();
            if (!listBranchItems.Any()) return;
            bool isUsingDefaultCase = true;
            cAction defaultBranchAction = null;

            foreach (cAction branchItem in listBranchItems)
            {
                branchItem.Passed.rtcValue = false;
                // So sánh điều kiện của tool branch
                if (
                    branchItem.Name.rtcValue.ToLower() == cStrings.DEFAULTCASE.ToLower())
                {
                    defaultBranchAction = branchItem;
                    continue;
                }
                //bool test = Result.rtcValue.Equals(branchItem.DataItems[0].ListDoubleValue.Cast<object>());
                if (Result.rtcValue != null && branchItem.DataItems != null &&
                    (GlobFuncs.ListsEqual(Result.rtcValue, branchItem.DataItems[0].ListDoubleValue.Cast<object>().ToList()) ||
                     GlobFuncs.ListsEqual(Result.rtcValue, branchItem.DataItems[0].ListStringValue?.Cast<object>().ToList())))
                {
                    branchItem.Passed.rtcValue = true;
                    isUsingDefaultCase = false;
                }
                ApplyIsCanRunToAllToolOfBranchItem(branchItem, Enable.rtcValue && branchItem.Passed.rtcValue, true, true);
            }

            if (defaultBranchAction != null)
            {
                defaultBranchAction.Passed.rtcValue = isUsingDefaultCase;
                ApplyIsCanRunToAllToolOfBranchItem(defaultBranchAction, Enable.rtcValue && isUsingDefaultCase, true, true);
            }
        }


        private void Run_Branch()
        {
            isPrepare = false;
            MyExpression.CalculateMode = CalculateMode.rtcValue;
            MyExpression.Calculate();
            Passed.rtcValue = MyExpression.Result.bValue;
            var listBranchItems = MyGroup.Actions.Values.Where(x =>
            x.ActionType == EActionTypes.BranchItem && x.IDBranch == ID).ToList();
            if (!listBranchItems.Any()) return;
            foreach (cAction branchItem in listBranchItems)
            {
                branchItem.Passed.rtcValue = false;
                // So sánh điều kiện của tool branch
                if (Passed.rtcValue &&
                    branchItem.Name.rtcValue == cStrings.True.ToUpper())
                    branchItem.Passed.rtcValue = true;
                else if (!Passed.rtcValue &&
                          branchItem.Name.rtcValue == cStrings.False.ToUpper())
                    branchItem.Passed.rtcValue = true;
                ApplyIsCanRunToAllToolOfBranchItem(branchItem, Enable.rtcValue && branchItem.Passed.rtcValue, true, true);

            }
        }

        private void ViewResultWhenAfterRun(Stopwatch stopwatch)
        {
            if (!MyGroup.RunSimple)
            {
                if (this.ActionType != EActionTypes.MainAction && this.ViewInfo != null)
                    ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
                this.RunCount += 1;
                this.FailCount += (this.Passed != null && this.Passed.rtcValue) ? 0 : 1;
                if (stopwatch != null)
                {
                    this.ProcessTime = stopwatch.ElapsedMilliseconds;
                    this.TotalTime += this.ProcessTime;
                }

                if (this.ErrMessage != null && this.ErrMessage.rtcValue.Count > 0)
                {
                    if (this.ErrMessage.rtcValue.Count == 1)
                        this.AbortCause = this.ErrMessage.rtcValue[0];
                    else if (this.ErrMessage.rtcValue.Count > 2)
                        this.AbortCause = this.ErrMessage.rtcValue[2];
                }
                else
                    this.AbortCause = this.Passed != null ? (this.Passed.rtcValue ? "" : "False") : "";
                ViewResultToTreeListNode();

            }
        }
        public void ViewResultWhenAfterRun()
        {
            if (MyGroup.RunSimple)
                return;
            if (this.ActionType != EActionTypes.MainAction && this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
            this.RunCount += 1;
            this.FailCount += (this.Passed != null && !this.Passed.rtcValue) ? 1 : 0;
            string errMessage = GlobFuncs.Ve2Str(this.ErrMessage.rtcValue);
            if (string.IsNullOrEmpty(errMessage))
                errMessage = this.Passed != null ? (this.Passed.rtcValue ? "" : "False") : "";
            this.AbortCause = errMessage;
            ViewResultToTreeListNode();
        }

        private void ViewResultToTreeListNode()
        {
            // ucBaseActionDetail.lay
            //GlobVar.tl.SuspendLayout();

            if (MyNode != null)
            {
                this.MyNode.RunCount = this.RunCount.ToString();
                this.MyNode.FailCount = this.FailCount.ToString();
                this.MyNode.ProcessTime = this.ProcessTime.ToString();
                this.MyNode.TotalTime = this.TotalTime.ToString();
                this.MyNode.AbortCause = this.AbortCause?.ToString();
            }
            GlobVar.tl.RemoveObject(this.MyNode);

            //GlobVar.tl.UpdateObject(this.MyNode);
            //GlobVar.tl.ResumeLayout();
        }
        public void ViewResultToUi()
        {
            //if (MyGroup.RunSimple || !this.Enable.rtcValue || !GlobVar.RTCVision.RunOptions.RealTimeUpdateViewToolData)
            if (MyGroup.RunSimple || !this.Enable.rtcValue)
                return;

            if (ViewInfo == null)
            {
                switch (ActionType)
                {
                    case EActionTypes.DataSet:
                        {
                            UpdatePropertyToNodeValue(DestinationPort.rtcPropNameRef);
                            break;
                        }
                }
                return;
            }

            if (this.STT != GlobVar.CurrentTool)
                return;

            switch (ActionType)
            {
                case EActionTypes.StringBuilder:
                    {
                        ((ucStringBuilderDetail)ViewInfo).ShowStringResult();
                        //((ucBaseActionDetail)ViewInfo).ReviewAllPropertyValueToViewInfo();
                        break;
                    }
                case EActionTypes.Count:
                    {
                        ((ucBaseActionDetail)ViewInfo).UpdatePropertyValueToAllControls(nameof(StartNumber));
                        ((ucBaseActionDetail)ViewInfo).ReviewAllPropertyValueToViewInfo();
                        break;
                    }
                case EActionTypes.DataInstance:
                    {
                        ((ucBaseActionDetail)ViewInfo).UpdatePropertyValueToAllControls(nameof(Value));
                        break;
                    }
                case EActionTypes.DataSet:
                    {
                        ((ucBaseActionDetail)ViewInfo).ReviewAllPropertyValueToViewInfo();
                        ((ucBaseActionDetail)ViewInfo).UpdatePropertyValueToAllControls(DestinationPort.rtcPropNameRef);
                        break;
                    }
                default:
                    {
                        ((ucBaseActionDetail)ViewInfo).ReviewAllPropertyValueToViewInfo();
                        break;
                    }
            }
        }

        private void GetOutputValueAfterRunTool()
        {
            var orderedProperty = this.GetType().GetProperties().Where(x => x != null && ((RTCVariableType)x.GetValue(this, null)) != null && ((RTCVariableType)x.GetValue(this, null)).rtcActive
            && ((RTCVariableType)x.GetValue(this, null)).rtcState == EPropertyState.Output);
            bool IsReviewShaplist = false;
            bool isReviewFindShapeList = false;

            foreach (PropertyInfo item in orderedProperty)
            {
                RTCVariableType propertyInfo = (RTCVariableType)this.GetType().GetProperty(item.Name).GetValue(this, null);
                PropertyInfo propertyInfoValue = item.PropertyType.GetProperty(cPropertyName.rtcValue);
                try
                {
                    switch (item.PropertyType.Name)
                    {
                        //case nameof(SBool):
                        //    propertyInfoValue.SetValue(propertyInfo, GlobFuncs.Object2Bool()
                    }
                }
                catch
                {

                }

            }
        }
        public void Run_SaveProject()
        {
            IsFinishRunOneTime.rtcValue = false;
            ErrMessage.rtcValue = new List<String>() { string.Empty };
            Passed.rtcValue = false;
            if (!ProjectFunctions.cProjectFunctions.SaveProject(GlobVar.CurrentProject, this.MyGroup.MyCam.ID, ESaveMode.OneCam, false))
            {
                ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.Err_SaveObject, new string[] { cStrings.Project.ToLower() }, new string[] { cStrings.ProjectV.ToLower() }) };
                return;
            }
            else
                Passed.rtcValue = true;
            this.MyGroup.DataChanged = false;
            if (IsRunOneTime.rtcValue)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        }

        private void Run_Blob()
        {
            _BlobTool = new Blob_Muilti_ROI.BlobTool();
            var test = GlobVar.GroupActions;
            _BlobTool.InputImage = InputGrayImage.rtcValue?.Clone();
            //InputGrayImage.rtcValue.Save("D:\\Test.jpg");
            _BlobTool.DetectType = DetectType.rtcValue;
            _BlobTool.GreyLevelThresholdType = GreyLevelThresholdType.rtcValue;
            _BlobTool.ThresholdRange = new Tuple<int, int>((int)ThresholdRange.rtcValue[0], (int)ThresholdRange.rtcValue[1]);
            _BlobTool.AreaRange = new Tuple<double, double>(AreaRange.rtcValue[0], AreaRange.rtcValue[1]);
            _BlobTool.CircularityRange = new Tuple<double, double>(CircularityRange.rtcValue[0], CircularityRange.rtcValue[1]);
            _BlobTool.ColumnRange = new Tuple<double, double>(ColumnRange.rtcValue[0], ColumnRange.rtcValue[1]);
            _BlobTool.HeightRange = new Tuple<double, double>(HeightRange.rtcValue[0], HeightRange.rtcValue[1]);
            _BlobTool.OuterRadiusRange = new Tuple<double, double>(OuterRadiusRange.rtcValue[0], OuterRadiusRange.rtcValue[1]);
            _BlobTool.WidthRange = new Tuple<double, double>(WidthRange.rtcValue[0], WidthRange.rtcValue[1]);

            _BlobTool.RequireNumberOfBlobs = new Tuple<int, int>(int.Parse(RequiredNumberOfBlobs.rtcValue[0].ToString()), int.TryParse(RequiredNumberOfBlobs.rtcValue[1].ToString(), out int Result) ? Result : 1000000000);
            _BlobTool.EnableAreaFilter = EnableAreaFilter.rtcValue;
            _BlobTool.EnableCircularityFilter = EnableCircularityFilter.rtcValue;
            _BlobTool.EnableRowFilter = EnableRowFilter.rtcValue;
            _BlobTool.EnableHeightFilter = EnableHeightFilter.rtcValue;
            _BlobTool.EnableWidthFilter = EnableWidthFilter.rtcValue;
            _BlobTool.EnableColumnFilter = EnableColumnFilter.rtcValue;
            _BlobTool.FillHoles = FillHoles.rtcValue;
            _BlobTool.IsShowImageResult = !GlobVar.RunningProcess;
            Tuple<PointF, double> toolOrigin;
            if (ToolOrigin.rtcValue.Count < 3)
            {
                toolOrigin = Tuple.Create(new PointF(0, 0), 0.0);
            }
            else
            {
                toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                   ToolOrigin.rtcValue[2]);
            }
            _BlobTool.ToolOrigin = toolOrigin;
            List<RTCRectangle> ROIs = new List<RTCRectangle>();
            Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(ShapeListOriginal);
            foreach (long key in DataShape.Keys)
            {
                ROIs.Add(DataShape[key]);
            }
            if (ROIs.Count <= 0)
            {
                ROIs.Add(GlobFuncs.GenRectangleImage(InputImage.rtcValue));
            }
            if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
            {
                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROIs, toolOrigin));
            }
            //_BlobTool.InSetOrigin = SetOrigin.Run(ROIs, toolOrigin);
            _BlobTool.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue);
            _BlobTool.ROI = ROIs;
            var errMessage = _BlobTool.ErrMessage;

            bool Ressult = _BlobTool.Run();
            if (WindowHandle.rtcValue.InvokeRequired)
            {
                WindowHandle.rtcValue.Invoke(new Action(() =>
                {
                    if (!GlobVar.RunningProcess)
                    {
                        WindowHandle.rtcValue.Image = _BlobTool.OutputImageShow;
                        //WindowHandle.rtcValue.Image = _BlobTool.OutputImageShow;
                        //SetImage
                    }
                    Passed.rtcValue = _BlobTool.Passed;
                    NumberOfBlobsFound.rtcValue = new List<double> { _BlobTool.NumberOfBlobsFound };
                    OutputBlobList.rtcValue = _BlobTool.OutputBlobList;
                    //OutputAreaList.rtcValue = _BlobTool.OutputAreaList;
                    //AreaActual.rtcValue = new List<double> { _BlobTool.AreaActual };
                    //OutputHeightList.rtcValue = _BlobTool.OutputHeightList.Select(p => (double)p).ToList();
                    //HeightActual.rtcValue = new List<double> { _BlobTool.HeightActual };
                    //OutputWidthList.rtcValue = _BlobTool.OutputWidthList.Select(p => (double)p).ToList();
                    //WidthActual.rtcValue = new List<double> { _BlobTool.WidthActual };
                    //OuterRadiusActual.rtcValue = new List<double> { _BlobTool.OuterRadiusActual };
                    //CircularityActual.rtcValue = new List<double> { _BlobTool.CircularityActual };
                    //ColumnActual.rtcValue = new List<double> { _BlobTool.ColumnActual};
                    //RowActual.rtcValue = new List<double> { _BlobTool.RowActual };
                }));
            }
            else
            {
                if (!GlobVar.RunningProcess)
                {
                    if (_BlobTool.OutputBlobList == null || _BlobTool.OutputBlobList.Count <= 0)
                    {
                        WindowHandle.rtcValue.Image = InputImage.rtcValue;
                    }
                    else
                    {
                        WindowHandle.rtcValue.Image = _BlobTool.OutputImageShow;
                        //WindowHandle.rtcValue.Image = _BlobTool.OutputImageShow;
                    }
                }
                Passed.rtcValue = _BlobTool.Passed;
                NumberOfBlobsFound.rtcValue = new List<double> { _BlobTool.NumberOfBlobsFound };
                OutputBlobList.rtcValue = _BlobTool.OutputBlobList;
                //OutputAreaList.rtcValue = _BlobTool.OutputAreaList;
                //AreaActual.rtcValue = new List<double> { _BlobTool.OutputAreaList.Max() };
                //OutputHeightList.rtcValue = _BlobTool.OutputHeightList.Select(p => (double)p).ToList();
                //HeightActual.rtcValue = new List<double> { _BlobTool.OutputHeightList.Max() };
                //OutputWidthList.rtcValue = _BlobTool.OutputWidthList.Select(p => (double)p).ToList();
                //WidthActual.rtcValue = new List<double> { _BlobTool.OutputWidthList.Max() };
                //OuterRadiusActual.rtcValue = new List<double> { _BlobTool.OuterRadiusActual };
                //CircularityActual.rtcValue = new List<double> { _BlobTool.CircularityActual };
                //ColumnActual.rtcValue = new List<double> { _BlobTool.ColumnActual };
                //RowActual.rtcValue = new List<double> { _BlobTool.RowActual };
                // OutputWidthList.rtcValue = _BlobTool.WidthRange;

            }

        }

        private void Run_BlobMultiROI()
        {
            OutputBlobList.rtcValue = new List<VectorOfVectorOfPoint>();
            NumberOfBlobsFound.rtcValue = new List<double>();
            Passed.rtcValue = true;
            BlobView = new Blob_View.BlobView();
            List<VectorOfVectorOfPoint> blobList = new List<VectorOfVectorOfPoint>();
            _BlobTool = new Blob_Muilti_ROI.BlobTool();
            List<RTCRectangle> DataROI = new List<RTCRectangle>();
            List<double> areaList = new List<double>();
            List<int> widthList = new List<int>();
            List<int> heightList = new List<int>();
            Bitmap bitmapImage = null;
            Dictionary<long, RTCRectangle> DataShapes = GlobFuncs.GenShapeList(ShapeList);
            _BlobTool.InputImage = InputGrayImage.rtcValue?.Clone();
            foreach (long key in DataShapes.Keys)
            {
                DataROI = new List<RTCRectangle>();
                for (int i = 0; i < ShapeListData.rtcValue.Count; i = i + 21)
                {
                    if (GlobFuncs.Object2Long(ShapeListData.rtcValue[i + 0]) == key)
                    {
                        _BlobTool.DetectType = ShapeListData.rtcValue[i + 1].ToString();
                        _BlobTool.FillHoles = GlobFuncs.Object2Bool(ShapeListData.rtcValue[i + 2]);
                        _BlobTool.GreyLevelThresholdType = GlobFuncs.Object2Str(ShapeListData.rtcValue[i + 3]);
                        _BlobTool.ThresholdRange = new Tuple<int, int>(GlobFuncs.Object2Int(ShapeListData.rtcValue[i + 4]), GlobFuncs.Object2Int(ShapeListData.rtcValue[i + 5]));
                        _BlobTool.EnableAreaFilter = GlobFuncs.Object2Bool(ShapeListData.rtcValue[i + 6]);
                        _BlobTool.AreaRange = new Tuple<double, double>(GlobFuncs.Object2Double(ShapeListData.rtcValue[i + 7]), GlobFuncs.Object2Double(ShapeListData.rtcValue[i + 8]));
                        _BlobTool.EnableWidthFilter = GlobFuncs.Object2Bool(ShapeListData.rtcValue[i + 9]);
                        _BlobTool.WidthRange = new Tuple<double, double>(GlobFuncs.Object2Double(ShapeListData.rtcValue[i + 10]), GlobFuncs.Object2Double(ShapeListData.rtcValue[i + 11]));
                        _BlobTool.EnableHeightFilter = GlobFuncs.Object2Bool(ShapeListData.rtcValue[i + 12]);
                        _BlobTool.HeightRange = new Tuple<double, double>(GlobFuncs.Object2Double(ShapeListData.rtcValue[i + 13]), GlobFuncs.Object2Double(ShapeListData.rtcValue[i + 14]));
                        _BlobTool.EnableOuterRadiusFilter = GlobFuncs.Object2Bool(ShapeListData.rtcValue[i + 15]);
                        _BlobTool.OuterRadiusRange = new Tuple<double, double>(GlobFuncs.Object2Double(ShapeListData.rtcValue[i + 16]), GlobFuncs.Object2Double(ShapeListData.rtcValue[i + 17]));
                        _BlobTool.RequiredPass = GlobFuncs.Object2Bool(ShapeListData.rtcValue[i + 18]);
                        _BlobTool.RequireNumberOfBlobs = new Tuple<int, int>(GlobFuncs.Object2Int(ShapeListData.rtcValue[i + 19]), GlobFuncs.Object2Int(ShapeListData.rtcValue[i + 20]));
                        //_BlobTool.RequiredPass = ShapeListData.

                        _BlobTool.IsShowImageResult = !GlobVar.RunningProcess;
                        Tuple<PointF, double> toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                        ToolOrigin.rtcValue[2]);
                        _BlobTool.ToolOrigin = toolOrigin;
                        _BlobTool.ROI = new List<RTCRectangle>();
                        DataROI.Add(DataShapes[key]);


                        //if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
                        //{
                        InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(DataROI, toolOrigin));
                        //}
                        //_BlobTool.InSetOrigin = SetOrigin.Run(ROIs, toolOrigin);
                        _BlobTool.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue);
                        _BlobTool.ROI = DataROI;

                        var errMessage = _BlobTool.ErrMessage;
                        bool Ressult = _BlobTool.Run();
                        blobList.AddRange(_BlobTool.OutputBlobList);
                        areaList.AddRange(_BlobTool.OutputAreaList);
                        widthList.AddRange(_BlobTool.OutputWidthList);
                        heightList.AddRange(_BlobTool.OutputHeightList);

                        //Input_Image?.Dispose();
                        //Input_Image = null;
                        BlobView.InputImage = InputGrayImage.rtcValue.Clone();

                        BlobView.InputBlobList = blobList;
                        BlobView.InputAreaList = areaList;
                        BlobView.InputHeightList = heightList;
                        BlobView.InputWidthList = widthList;
                        BlobView.IsShowImageResult = !GlobVar.RunningProcess;
                        OutputBlobList.rtcValue.AddRange(_BlobTool.OutputBlobList);
                        NumberOfBlobsFound.rtcValue.Add(_BlobTool.NumberOfBlobsFound);
                        NumberOfBlobsFound.rtcValue = new List<double>() { NumberOfBlobsFound.rtcValue.Sum() };
                        BlobView.Run();
                    }
                }
            }
            if (WindowHandle.rtcValue.InvokeRequired)
            {
                WindowHandle.rtcValue.Invoke(new Action(() =>
                {
                    NumberOfBlobsFound.rtcValue = new List<double>() { _BlobTool.NumberOfBlobsFound };
                    if (OutputBlobList != null && OutputBlobList.rtcValue.Count > 0)
                    {
                        WindowHandle.rtcValue.Image = BlobView.OutputImageShow;
                        OutputAreaList.rtcValue = _BlobTool.OutputAreaList;
                        Passed.rtcValue = _BlobTool.Passed;
                    }
                }));
            }
            else
            {


                NumberOfBlobsFound.rtcValue = new List<double>() { _BlobTool.NumberOfBlobsFound };
                if (!GlobVar.RunningProcess)
                {
                    if (OutputBlobList != null && OutputBlobList.rtcValue.Count > 0)
                    {
                        WindowHandle.rtcValue.Image = BlobView.OutputImageShow;
                        OutputAreaList.rtcValue = _BlobTool.OutputAreaList;
                        //OutputWidthList.rtcValue = ColorBlobMultiROIS.OutputWidthList.Cast<double>().ToList();
                        //OutputHeightList.rtcValue = ColorBlobMultiROIS.OutputHeightList.Cast<double>().ToList();
                        Passed.rtcValue = _BlobTool.Passed;
                    }
                }
                else
                {
                    WindowHandle.rtcValue.Image = InputImage.rtcValue;
                    Passed.rtcValue = _BlobTool.Passed;
                }
            }

        }
        private void Run_Origin()
        {
            OriginTool = new OriginTool.Origin();
            Bitmap bitmapImage = null;
            Tuple<Point, double> toolOrigin = Tuple.Create(new Point(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
             ToolOrigin.rtcValue[2]);
            Tuple<PointF, double> toolOriginF = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
             ToolOrigin.rtcValue[2]);
            OriginTool.ToolOrigin = toolOrigin;
            OriginTool.OriginType = OriginType.rtcValue;
            OriginTool.EnableAngleRangeCheck = EnableAngleRangeCheck.rtcValue;
            OriginTool.EnableColumnFilter = EnableColumnFilter.rtcValue;
            OriginTool.EnableRowFilter = EnableRowFilter.rtcValue;
            Dictionary<long, RTCRectangle> DataShapes = GlobFuncs.GenShapeList(ShapeList);
            List<RTCRectangle> DataROI = DataShapes.Values.ToList();
            if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
            {
                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(DataROI, toolOriginF));
            }

            foreach (long key in DataShapes.Keys)
            {
                for (int i = 0; i < ShapeListData.rtcValue.Count; i += i + 13)
                {

                    if (GlobFuncs.Object2Long(ShapeListData.rtcValue[i]) == key)
                    {
                        if (i < 13)
                            OriginTool.SamplingPercentROI1 = Lib.ToInt(ShapeListData.rtcValue[i + 3]);
                        OriginTool.EdgeTransitionROI1 = Lib.ToString(ShapeListData.rtcValue[i + 2]);
                        OriginTool.EdgeTypeROI1 = Lib.ToString(ShapeListData.rtcValue[i + 1]);
                        OriginTool.EdgeDetectionThresholdROI1 = Lib.ToInt(ShapeListData.rtcValue[i + 4]);
                        OriginTool.OutlierDistanceThresholdROI1 = Lib.ToInt(ShapeListData.rtcValue[i + 11]);
                        OriginTool.InSetOriginROI1 = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue)[0];
                        OriginTool.ROI1 = DataShapes[key];
                    }
                    else
                    {
                        OriginTool.SamplingPercentROI2 = Lib.ToInt(ShapeListData.rtcValue[i + 3]);
                        OriginTool.EdgeTransitionROI2 = Lib.ToString(ShapeListData.rtcValue[i + 2]);
                        OriginTool.EdgeTypeROI2 = Lib.ToString(ShapeListData.rtcValue[i + 1]);
                        OriginTool.EdgeDetectionThresholdROI2 = Lib.ToInt(ShapeListData.rtcValue[i + 4]);
                        OriginTool.OutlierDistanceThresholdROI2 = Lib.ToInt(ShapeListData.rtcValue[i + 11]);
                        OriginTool.InSetOriginROI2 = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue)[1];
                        OriginTool.ROI2 = DataShapes[key];
                    }
                    break;
                }
            }

            if (OriginType.rtcValue == cOriginTool.OriginType_TwoLine && DataShapes.Values.Count < 2 && (OriginTool.ROI1 == null || OriginTool.ROI2 == null))
                return;
            OriginTool.IsShowImageResult = true;
            OriginTool.InputImage = InputGrayImage.rtcValue.Clone();
            bool Result = OriginTool.Run();
            var errMessage = OriginTool.ErrMessage;
            if (Result)
            {
                if (OriginTool.OutputOrigin != null)
                {
                    OutputOriginList.rtcValue = new List<double>() { OriginTool.OutputOrigin.Item1.X, OriginTool.OutputOrigin.Item1.Y, OriginTool.OutputOrigin.Item2 };
                    OutPutBestOrigin.rtcValue = new List<double>() { OriginTool.OutputOrigin.Item1.X, OriginTool.OutputOrigin.Item1.Y, OriginTool.OutputOrigin.Item2 };
                }
                if (WindowHandle.rtcValue.InvokeRequired)
                {
                    WindowHandle.rtcValue.Invoke(new Action(() =>
                    {

                        WindowHandle.rtcValue.Image = OriginTool.OutputImageShow;
                        Passed.rtcValue = Passed.rtcValue && OriginTool.Passed;
                        //WindowHandle.rtcValue.Refresh();
                    }));
                }
                else
                {
                    WindowHandle.rtcValue.Image = OriginTool.OutputImageShow;
                    Passed.rtcValue = Passed.rtcValue && OriginTool.Passed;
                    //WindowHandle.rtcValue.Refresh();
                }
            }

        }
        private void Run_Pattern()
        {
            List<RTCRectangle> ROIs = new List<RTCRectangle>();
            List<RTCRectangle> ROISearches = new List<RTCRectangle>();
            Dictionary<long, RTCRectangle> DataShapesTrain = GlobFuncs.GenShapeList(ShapeListOriginal);
            Dictionary<long, RTCRectangle> DataShapesFind = GlobFuncs.GenShapeList(FindShapeList);
            var test = GlobVar.GroupActions.SaveFileFolder;
            foreach (long key in DataShapesFind.Keys)
            {
                ROISearches.Add(DataShapesFind[key]);
            }
            if (ROISearches.Count <= 0)
            {
                ROISearches.Add(GlobFuncs.GenRectangleImage(InputImage.rtcValue));
            }
            foreach (long key in DataShapesTrain.Keys)
            {
                ROIs.Add(DataShapesTrain[key]);
            }
            if (ROIs.Count <= 0)
            {
                ROIs.Add(GlobFuncs.GenRectangleImage(InputImage.rtcValue));
            }

            if (TrainPressed.rtcValue)
            {
                Pattern = new NewPattern.NewPattern();
                Pattern.InputImage = InputGrayImage.rtcValue.Clone();
                Pattern.ROITrain = ROIs;
                bool Result = Pattern.Train();

                // Cập nhật giao diện người dùng
                if (WindowHandle.rtcValue.InvokeRequired)
                {
                    WindowHandle.rtcValue.Invoke(new Action(() =>
                    {
                        WindowHandle.rtcValue.Image = Pattern.OutputImageShow;
                        //WindowHandle.rtcValue.Refresh();
                    }));
                }
                else
                {
                    WindowHandle.rtcValue.Image = Pattern.OutputImageShow;
                    //WindowHandle.rtcValue.Refresh();
                }

                if (Result)
                {
                    OutputMasterOrigin.rtcValue = new List<double> { Pattern.OutputMasterOrigin.Item1.X, Pattern.OutputMasterOrigin.Item1.Y,
                                                               Pattern.OutputMasterOrigin.Item2};
                    try
                    {
                        string savePath = $"{GlobVar.CurrentProject.FolderNameFullPathBAK}\\{this.Name.rtcValue}";
                        using (Bitmap outputBitmap = new Bitmap(Pattern.OutputImageShow))
                        {
                            outputBitmap.Save(savePath + ".bmp");
                        }
                    }
                    catch (System.Runtime.InteropServices.ExternalException ex)
                    {
                        GlobFuncs.SaveErr(ex);
                    }
                    finally
                    {
                    }
                }
            }

            else if (TabPassActive.rtcValue || RunIsSilent.rtcValue)
            {
                if (!Pattern.Trained)
                {
                    Pattern = new NewPattern.NewPattern();
                    string fileMaster = $"{GlobVar.CurrentProject.FolderNameFullPath}\\{this.Name.rtcValue}.bmp";
                    if (!File.Exists(fileMaster))
                    {
                        ErrMessage.rtcValue = new List<string> { "No Data Train" };
                        return;
                    }
                    ImageMaster.rtcValue = new Bitmap(fileMaster);
                    var masterImage = new Bitmap(ImageMaster.rtcValue);
                    Pattern.InputImage = GlobFuncs.BitmapToGrayImage(masterImage);
                    Pattern.ROITrain = ROIs;
                    bool Result = Pattern.Train();
                    if (Result)
                    {
                        isTrainned = true;
                        masterImage?.Dispose();
                    }
                }
                Tuple<PointF, double> toolOrigin;
                if (ToolOrigin.rtcValue.Count < 3)
                {
                    toolOrigin = Tuple.Create(new PointF(0, 0), 0.0);
                }
                else
                {
                    toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                       ToolOrigin.rtcValue[2]);
                }
                if (InSetOrigin.rtcValue == null || InSetOrigin.rtcValue.Count <= 0)
                {
                    InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(ROISearches, toolOrigin));
                }
                Pattern.ROISearch = ROISearches;
                Pattern.ToolOrigin = toolOrigin;
                Pattern.InSetOrigin = GlobFuncs.ListDoubleToListPointF(InSetOrigin.rtcValue)[0];
                Pattern.InputImage = InputGrayImage.rtcValue.Clone();
                Pattern.AngleRangePattern = new Tuple<int, int>(Lib.ToInt(AngleRangePattern.rtcValue[0]), Lib.ToInt(AngleRangePattern.rtcValue[1]));
                Pattern.PossibleRotations = PossibleRotations.rtcValue;
                Pattern.MaxOverLap = MaxOverlap.rtcValue;
                Pattern.MinSearchScore = MinSearchScore.rtcValue;
                Pattern.MaxNumberToSearch = Lib.ToInt(NumberToFindRange.rtcValue[1]);
                Pattern.NumberToFindRange = new Tuple<int, int>(Lib.ToInt(NumberToFindRange.rtcValue[0]), Lib.ToInt(NumberToFindRange.rtcValue[1]));
                Pattern.Accuracy = PositionAccuracy.rtcValue;
                Pattern.MinScorePass = MinPassScore.rtcValue;
                //Pattern.IsShowImageResult = !GlobVar.RunningProcess;
                Pattern.IsShowImageResult = true;
                bool r = Pattern.Run();
                if (r)
                {
                    OutPutBestOrigin.rtcValue = new List<double> { Pattern.OutputBestOrigin.Item1.X, Pattern.OutputBestOrigin.Item1.Y,
                                                                Pattern.OutputBestOrigin.Item2};
                    OutputOriginList.rtcValue = GlobFuncs.TupleOriginToOrigin(Pattern.OutputOriginList);
                    OutputScore.rtcValue = Pattern.OutPutScoreList;
                    OutputBestOrigin_X.rtcValue = OutPutBestOrigin.rtcValue[0];
                    OutputBestOrigin_Y.rtcValue = OutPutBestOrigin.rtcValue[1];
                    OutputBestOrigin_Phi.rtcValue = OutPutBestOrigin.rtcValue[2];
                    OutputMasterOrigin.rtcValue = new List<double> { Pattern.OutputMasterOrigin.Item1.X, Pattern.OutputMasterOrigin.Item1.Y,
                                                                Pattern.OutputMasterOrigin.Item2};
                    Passed.rtcValue = Pattern.Passed;
                }
                if (WindowHandle.rtcValue.InvokeRequired)
                {
                    WindowHandle.rtcValue.Invoke(new Action(() =>
                    {
                        //WindowHandle.rtcValue.Image = Pattern.OutputImageShow;
                        WindowHandle.rtcValue.Image = Pattern.OutputImageShow;
                        //WindowHandle.rtcValue.RefreshIma();
                    }));
                }
                else
                {
                    // WindowHandle.rtcValue.SetImage(Pattern.OutputImageShow);
                    WindowHandle.rtcValue.Image = Pattern.OutputImageShow;
                    //WindowHandle.rtcValue.Refresh();
                }
            }
        }

        private void Run_ImageMath()
        {
            ImageMath = new ImageMath.ImageMath();
            ImageMath.InputImage = InputGrayImage.rtcValue?.Clone();
            ImageMath.InputImage2 = InputGrayImage2.rtcValue?.Clone();
            ImageMath.ImageOperation = ImageOperation.rtcValue;
            ImageMath.OffsetValue = OffsetValue.rtcValue[0];
            ImageMath.ScaleFactor = ScaleFactor.rtcValue;
            ImageMath.IsShowImageResult = !GlobVar.RunningProcess;
            bool result = ImageMath.Run();
            OutputGrayImage.rtcValue = ImageMath.OutputImage;
            if (!GlobVar.RunningProcess)
            {
                if (WindowHandle.rtcValue.InvokeRequired)
                {
                    WindowHandle.rtcValue.Invoke(new Action(() =>
                    {
                        OutputImage.rtcValue = ImageMath.OutputImageShow;
                        WindowHandle.rtcValue.Image = ImageMath.OutputImageShow;
                    }));
                }
                else
                {
                    OutputImage.rtcValue = ImageMath.OutputImageShow;
                    WindowHandle.rtcValue.Image = ImageMath.OutputImageShow;

                }
            }
            Passed.rtcValue = ImageMath.Passed;
        }
        public void Run_CodeReader()
        {
            Dictionary<long, RTCRectangle> DataShapesTrain = GlobFuncs.GenShapeList(ShapeList);
            //Dictionary<long, RTCRectangle> DataShapesFind = GlobFuncs.GenShapeList(FindShapeList);
            CodeReader.InputImage = InputGrayImage.rtcValue.Clone();

            Tuple<PointF, double> toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
            ToolOrigin.rtcValue[2]);
            if (TrainPressed.rtcValue)
            {
                CodeReader.ROITrain = DataShapesTrain.Values.FirstOrDefault();

                CodeReader.InputListFormatTrain = new List<string> { "CODABAR", "CODE_39", "CODE_93", "CODE_128", "EAN_8", "EAN_13", "ITF", "UPC_A", "UPC_E", "PDF_417", "MSI" };
                CodeReader.CodeType = Code.rtcValue;
                CodeReader.ToolOrigin = toolOrigin;
                CodeReader.PathSaveFileTrain = GlobVar.CurrentProject.FolderNameFullPath + "\\" + $"{this.Name.rtcValue}" + "\\" + " modelCode.json"; //Truyền đường dẫn lưu file Json 
                CodeReader.IsShowImageResult = true; //Hiển thị ảnh đầu ra
                bool Result = CodeReader.Train();
                string errMessage = CodeReader.ErrMessage;
                OutputCodeType.rtcValue = CodeReader.OutputCodeFomatTrain;
                CODABAR.rtcValue = OutputCodeType.rtcValue.Contains("CODABAR");
                CODE_39.rtcValue = OutputCodeType.rtcValue.Contains("CODE_39");
                CODE_93.rtcValue = OutputCodeType.rtcValue.Contains("CODE_93");
                CODE_128.rtcValue = OutputCodeType.rtcValue.Contains("CODE_128");
                Interleaved.rtcValue = OutputCodeType.rtcValue.Contains("ITF");
                PHARMA_CODE.rtcValue = OutputCodeType.rtcValue.Contains("PHARMA_CODE");
                EAN_8.rtcValue = OutputCodeType.rtcValue.Contains("EAN_8");
                EAN_13.rtcValue = OutputCodeType.rtcValue.Contains("EAN_13");
                UPC_A.rtcValue = OutputCodeType.rtcValue.Contains("UPC_A");
                UPC_E.rtcValue = OutputCodeType.rtcValue.Contains("UPC_E");
                UPC_EAN_EXTENSION.rtcValue = OutputCodeType.rtcValue.Contains("UPC_EAN_EXTENSION");
                RSS_14.rtcValue = OutputCodeType.rtcValue.Contains("RSS_14");
                RSS_EXPANDED.rtcValue = OutputCodeType.rtcValue.Contains("RSS_EXPANDED");
                PDF_417.rtcValue = OutputCodeType.rtcValue.Contains("PDF_417");
                MSI.rtcValue = OutputCodeType.rtcValue.Contains("MSI");
                PLESSEY.rtcValue = OutputCodeType.rtcValue.Contains("PLESSEY");
                PLESSEY.rtcValue = OutputCodeType.rtcValue.Contains("PLESSEY");
                IMB.rtcValue = OutputCodeType.rtcValue.Contains("IMB");
                DATA_MATRIX.rtcValue = OutputCodeType.rtcValue.Contains("DATA_MATRIX");
                QR_CODE.rtcValue = OutputCodeType.rtcValue.Contains("QR_CODE");
                MAXICODE.rtcValue = OutputCodeType.rtcValue.Contains("MAXICODE");
                AZTEC.rtcValue = OutputCodeType.rtcValue.Contains("AZTEC");
                if (WindowHandle.rtcValue.InvokeRequired)
                {
                    WindowHandle.rtcValue.Invoke(new Action(() =>
                    {
                        WindowHandle.rtcValue.Image = CodeReader.OutputImageShow;
                        WindowHandle.rtcValue.Refresh();
                    }));
                }
                else
                {
                    WindowHandle.rtcValue.Image = CodeReader.OutputImageShow;
                    WindowHandle.rtcValue.Refresh();
                }
            }
            else
            {
                //if(!CodeReader.Tra)
                //{

                //    CodeReader.ROITrain = DataShapesTrain.Values.FirstOrDefault();
                //    CodeReader.InputListFormatTrain = new List<string> { "AZTEC", "CODABAR", "CODE_39", "CODE_93", "CODE_128", "EAN_8", "EAN_13", "ITF", "UPC_A", "UPC_E" };
                //    CodeReader.CodeType = "1D";
                //    CodeReader.ToolOrigin = toolOrigin;
                //    CodeReader.PathSaveFileTrain = GlobVar.CurrentProject.FolderNameFullPath + "\\" + $"{this.Name.rtcValue}" + "\\" + " modelCode.json"; //Truyền đường dẫn lưu file Json 
                //    CodeReader.IsShowImageResult = true; //Hiển thị ảnh đầu ra
                //    bool Result = CodeReader.Train();
                //}

                Stopwatch t = new Stopwatch();
                CodeReader.ROISearch = DataShapesTrain.Values.FirstOrDefault();
                CodeReader.PathSaveFileTrain = GlobVar.CurrentProject.FolderNameFullPath + "\\" + $"{this.Name.rtcValue}" + "\\" + " modelCode.json"; //Truyền đường dẫn lưu file Json 
                CodeReader.CodeType = Code.rtcValue; //Truyền kiểu code Code 1D:"1D", Code 2D:"2D"
                CodeReader.InSetOrigin = SetOrigin.Run(DataShapesTrain.Values.FirstOrDefault(), toolOrigin); //Truyền ROI đã chuyển đổi
                CodeReader.ToolOrigin = toolOrigin;
                CodeReader.LoadFile();
                CodeReader.IsShowImageResult = true;
                // CodeReader.SetLineWidth = 2;//Set độ rộng của nét
                //  CodeReader.SetFontSize = 1;
                if (CodeReader.Run())
                {
                    OutputCodeHandle.rtcValue = CodeReader.OutputStringCode;
                    Passed.rtcValue = CodeReader.Passed;
                    NumberOfCodeFound.rtcValue = CodeReader.OutputStringCode.Count();
                    ResultCode.rtcValue = CodeReader.OutputStringCode;
                    if (MatchString.rtcValue)
                    {
                        if (ResultCode.rtcValue.Contains(InputString.rtcValue))
                        {

                        }
                    }
                    if (WindowHandle.rtcValue.InvokeRequired)
                    {
                        WindowHandle.rtcValue.Invoke(new Action(() =>
                        {
                            WindowHandle.rtcValue.Image = CodeReader.OutputImageShow;
                            //WindowHandle.rtcValue.Refresh();
                        }));
                    }
                    else
                    {
                        WindowHandle.rtcValue.Image = CodeReader.OutputImageShow;

                        //WindowHandle.rtcValue.Refresh();
                    }
                }
                else
                {
                    ErrMessage.rtcValue = new List<string> { CodeReader.ErrMessage };
                }



            }
        }
        private static List<List<double[]>> ConvertListVectorOfVectorToListPoints(List<VectorOfVectorOfPoint> listOfVectorOfVector)
        {
            List<List<double[]>> listOfPoints = new List<List<double[]>>();

            foreach (var vectorOfVector in listOfVectorOfVector)
            {
                List<double[]> vectorPoints = new List<double[]>();

                for (int i = 0; i < vectorOfVector.Size; i++)
                {
                    VectorOfPoint vectorOfPoint = vectorOfVector[i];

                    for (int j = 0; j < vectorOfPoint.Size; j++)
                    {
                        System.Drawing.Point point = vectorOfPoint[j];
                        double[] pointArray = { point.X, point.Y };
                        vectorPoints.Add(pointArray);
                    }
                }

                listOfPoints.Add(vectorPoints);
            }

            return listOfPoints;
        }
        private bool IsActionCanRunLinkPassFail(cAction _Action)
        {
            //if (_Action.ActionType == EActionTypes.Branch ||
            //    _Action.ActionType == EActionTypes.BranchItem ||
            //    _Action.ActionType == EActionTypes.CounterLoop)
            //    return false;
            return IsActionCanRun(_Action);
        }
        private bool IsActionCanRun(cAction _Action)
        {
            bool result = true;
            if (_Action.IDBranchItem != Guid.Empty)
            {
                cAction _BranchItemAction = MyGroup.Actions.Values.First(x => x.ID == _Action.IDBranchItem);
                if (_BranchItemAction != null)
                {
                    cAction _BranchAction = MyGroup.Actions.Values.First(x => x.ID == _BranchItemAction.IDBranch);

                    if (_BranchAction != null)
                    {
                        switch (_BranchAction.ActionType)
                        {
                            case EActionTypes.Branch:
                                if (_BranchAction.Passed.rtcValue &&
                                    _BranchItemAction.Name.rtcValue != cStrings.True.ToUpper())
                                    result = false;
                                else if (!_BranchAction.Passed.rtcValue && _BranchItemAction.Name.rtcValue != cStrings.False.ToUpper())
                                    result = false;
                                break;
                            case EActionTypes.PassFail:
                                if (_BranchAction.Passed.rtcValue &&
                                    _BranchItemAction.Name.rtcValue != cStrings.Pass.ToUpper())
                                    result = false;
                                else if (!_BranchAction.Passed.rtcValue && _BranchItemAction.Name.rtcValue != cStrings.Fail.ToUpper())
                                    result = false;
                                break;
                            case EActionTypes.Switch:
                                //So sánh điều kiện của tool branch 
                                if (_BranchAction.Result.rtcValue != null && _BranchItemAction.DataItems != null)
                                    result = GlobFuncs.ListsEqual(_BranchAction.Result.rtcValue, (_BranchItemAction.DataItems[0].ListDoubleValue.Cast<object>().ToList()));
                                //result = _BranchAction.Result.rtcValue.Equals(_BranchItemAction.DataItems[0].Value);
                                else
                                    result = false;
                                break;
                        }
                    }

                    if (!MyGroup.RunSimple && _BranchItemAction.MyNode != null)
                    {


                        _BranchItemAction.MyNode.AbortCause = result ? bool.TrueString : bool.FalseString;
                        GlobVar.tl.RefreshObject(_BranchItemAction.MyNode);



                    }

                }
            }

            return result;
        }

        public void SetOrigin_Blob()
        {


            //RTCRectangle ROI = new RTCRectangle();
            //ROI.Center = new RTCPoint(Int16.Parse(tbCenXROI.Text), Int16.Parse(tbCenYROI.Text), 0);
            //ROI.Phi = double.Parse(tbAngleROI.Text);
            //ROI.Width = double.Parse(tbWidthROI.Text);
            //ROI.Height = double.Parse(tbHieghtROI.Text);


            //var toolOrigin = Tuple.Create(new Point(Int16.Parse(tbOriginX.Text), Int16.Parse(tbOriginY.Text)), double.Parse(tbAngleOrigin.Text));
            //Blob.ToolOrigin = toolOrigin;
            //var result = Blob.SetROI();
            //var errMessage = Blob.ErrMessage;
        }
        public void BackupImage(Image image)
        {
            ImageBackup = null;
            if (image == null && image == null)
                return;

            ImageBackup = (Image)image.Clone();
        }
        public void RoolBackImage(ref Image image, bool isClearBackup = true)
        {
            image = null;
            if (ImageBackup == null)
                return;
            image = (Image)ImageBackup?.Clone();
            if (isClearBackup)
            {
                ImageBackup?.Dispose();
                ImageBackup = null;
            }
        }
        static Image<Gray, byte> ConvertToEmguImage(System.Drawing.Image inputImage)
        {
            // Chuyển đổi hình ảnh sang Emgu.CV.Image<Gray, byte>
            Bitmap bitmap = new Bitmap(inputImage);

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            try
            {
                int length = Math.Abs(bmpData.Stride) * bmpData.Height;
                byte[] imageData = new byte[length];

                Marshal.Copy(bmpData.Scan0, imageData, 0, length);

                Image<Gray, byte> emguImage = new Image<Gray, byte>(bitmap.Width, bitmap.Height);
                emguImage.Bytes = imageData;

                return emguImage;
            }
            finally
            {
                bitmap.UnlockBits(bmpData);
            }
        }
        private void AddROIToShapeList(object item, SListObject shapeList, int type)
        {
            if (shapeList == null)
                return;
            cDrawingBaseType Normal = (cDrawingBaseType)item;
            switch (Normal.DrawingType)
            {
                case EDrawingtypes.Rectang:
                    {

                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cRectangType)item).Phi);
                        shapeList.rtcValue.Add(((cRectangType)item).Width);
                        shapeList.rtcValue.Add(((cRectangType)item).Height);
                        shapeList.rtcValue.Add((int)Normal.DrawingType);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);

                        break;
                    }
                case EDrawingtypes.Rectang1:
                    {
                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cRectangType)item).Phi);
                        shapeList.rtcValue.Add(((cRectangType)item).Width);
                        shapeList.rtcValue.Add(((cRectangType)item).Height);
                        shapeList.rtcValue.Add((int)EDrawingtypes.Rectang1);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);
                        break;
                    }
                case EDrawingtypes.Ellipse:
                    {
                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cEllipseType)item).Phi);
                        shapeList.rtcValue.Add(((cEllipseType)item).Radius1);
                        shapeList.rtcValue.Add(((cEllipseType)item).Radius2);
                        shapeList.rtcValue.Add((int)Normal.DrawingType);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);
                        break;
                    }
            }
        }


        private void Run_ResetOutPutToDefault()
        {
            switch (ActionType)
            {
                case EActionTypes.SLMPRead:
                    {
                        Value.rtcValue = new List<string>();
                        switch (ValueTypes.rtcValue)
                        {
                            case cSLMPValueTypes.BIT:
                                Value.rtcValue.Add("0");
                                break;
                            case cSLMPValueTypes.BITRegister:
                                Value.rtcValue.Add("0");
                                break;
                            case cSLMPValueTypes.Word:
                                Value.rtcValue.Add("0");
                                break;
                            case cSLMPValueTypes.Dword:
                                Value.rtcValue.Add("0");
                                break;
                            case cSLMPValueTypes.String:
                                Value.rtcValue.Add(string.Empty);
                                break;
                        }
                        break;
                    }
                case EActionTypes.ModBusRead:
                    {
                        Value.rtcValue = new List<string>();
                        switch (ValueTypes.rtcValue)
                        {
                            case cModBusValueTypes.BooleanFC1:
                                Value.rtcValue.Add("false");
                                break;
                            case cModBusValueTypes.Float:
                                Value.rtcValue.Add("false");
                                break;
                            case cModBusValueTypes.Integer:
                                Value.rtcValue.Add("false");
                                break;
                        }
                        break;
                    }
                case EActionTypes.RunProgram:
                    {
                        IsRunning.rtcValue = false;
                        break;
                    }
                default:
                    break;
            }
        }

        public void UpdateShapeListOriginal()
        {
            try
            {
                //Tạm thời comment lại
                if (ToolOrigin != null &&
                    ToolOrigin.rtcValue != null &&
                    ToolOrigin.rtcValue.Count >= 2 &&
                    ToolOrigin.rtcValue[0] != 0 &&
                    ToolOrigin.rtcValue[1] != 0)
                {
                    for (int Index = 0; Index < ShapeList.rtcValue.Count; Index += GlobVar.ShapeListCount)
                    {
                        double RowFinRoi = Lib.Object2Double(ShapeList.rtcValue[Index + 0]);
                        double ColumnFinRoi = Lib.Object2Double(ShapeList.rtcValue[Index + 1]);
                        double PhiFindRoi = Lib.Object2Double(ShapeList.rtcValue[Index + 2]);
                        ShapeList.rtcValue[Index + 0] = RowFinRoi;
                        ShapeList.rtcValue[Index + 1] = ColumnFinRoi;
                        //ShapeList.rtcValue[Index + 2] = PhiFindRoi - ToolOrigin.rtcValue[2];
                    }

                }
                ShapeListOriginal.rtcValue = ShapeList.rtcValue;
                Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(ShapeListOriginal);

                Tuple<PointF, double> toolOrigin;
                if (ToolOrigin.rtcValue.Count < 3)
                {
                    toolOrigin = Tuple.Create(new PointF(0, 0), 0.0);
                }
                else
                {
                    toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                       ToolOrigin.rtcValue[2]);
                }

                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(DataShape.Values.Cast<RTCRectangle>().ToList(), toolOrigin));
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public void UpdateFindShapeListOriginal()
        {
            try
            {
                for (int Index = 0; Index < FindShapeList.rtcValue.Count; Index += GlobVar.ShapeListCount)
                {
                    double RowFindROi = Lib.Object2Double(FindShapeList.rtcValue[Index + 0]);
                    double ColumnFindROI = Lib.Object2Double(FindShapeList.rtcValue[Index + 1]);
                    double PhiFinRoi = Lib.Object2Double(FindShapeList.rtcValue[Index + 2]);
                    FindShapeList.rtcValue[Index + 0] = RowFindROi;
                    FindShapeList.rtcValue[Index + 1] = ColumnFindROI;
                    //FindShapeList.rtcValue[Index + 2] = PhiFinRoi - ToolOrigin.rtcValue[2];
                }
                FindShapeListOriginal.rtcValue = FindShapeList.rtcValue;
                Dictionary<long, RTCRectangle> DataShape = GlobFuncs.GenShapeList(FindShapeListOriginal);

                Tuple<PointF, double> toolOrigin;
                if (ToolOrigin.rtcValue.Count < 3)
                {
                    toolOrigin = Tuple.Create(new PointF(0, 0), 0.0);
                }
                else
                {
                    toolOrigin = Tuple.Create(new PointF(Lib.ToInt(ToolOrigin.rtcValue[0]), Lib.ToInt(ToolOrigin.rtcValue[1])),
                       ToolOrigin.rtcValue[2]);
                }

                InSetOrigin.rtcValue = GlobFuncs.ListPointFToListDouble(SetOrigin.Run(DataShape.Values.ToList(), toolOrigin));
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        internal void RebuildReferenceTextWhenToolNameIsChanged(string oldName, string newName)
        {   // tìm kiếm toàn bộ các took có link đến tool này
            if (MyGroup?.Actions == null)
                return;
            foreach (cAction childAction in MyGroup.Actions.Values)
            {
                // Lấy ra danh sách thuộc tính
                var properties = childAction.GetType().GetProperties().Where(x =>
                ((RTCVariableType)x.GetValue(childAction, null)) != null &&
                ((RTCVariableType)x.GetValue(childAction, null)).rtcIDRef == this.ID).ToList();
                if (properties.Any())
                {
                    foreach (PropertyInfo property in properties)
                    {
                        RTCVariableType rtcVariableType = (RTCVariableType)childAction.GetType()
                            .GetProperty(property.Name)?.GetValue(childAction, null);
                        if (rtcVariableType != null)
                            rtcVariableType.rtcRef =
                                rtcVariableType.rtcRef.Replace("MainAction." + oldName, "MainAction." + newName);
                    }
                    if (childAction.ViewInfo != null && childAction.ActionType != EActionTypes.MainAction)
                        ((ucBaseActionDetail)childAction.ViewInfo).ReviewAllPropertyValueToViewInfo_Ref_ToControls(properties);
                }
                if (childAction.DataItems != null)
                {
                    foreach (SStringBuilderItem dataItem in childAction.DataItems)
                        if (dataItem.RefID == this.ID)
                            dataItem.Ref = dataItem.Ref.Replace("MainAction." + oldName, "MainAction." + newName);

                    if (childAction.ViewInfo != null && childAction.ActionType != EActionTypes.MainAction)
                        ((ucBaseActionDetail)childAction.ViewInfo)
                            .ReviewAllPropertyValueToViewInfo_DataItem_ToPropertyGrid(childAction.DataItems);
                }
                if (childAction.MyExpression != null && childAction.MyExpression.Operands != null)
                {
                    foreach (SStringBuilderItem dataItem in childAction.MyExpression.Operands)
                        if (dataItem.RefID == this.ID)
                            dataItem.Ref = dataItem.Ref.Replace("MainAction." + oldName, "MainAction." + newName);

                    if (childAction.ViewInfo != null && childAction.ActionType != EActionTypes.MainAction)
                        ((ucBaseActionDetail)childAction.ViewInfo)
                            .ReviewAllPropertyValueToViewInfo_DataItem_ToPropertyGrid(childAction.MyExpression
                                .Operands);
                }
                if (childAction.StringBuilders != null)
                {
                    foreach (SStringBuilderItem dataItem in childAction.StringBuilders)
                        if (dataItem.RefID == this.ID)
                            dataItem.Ref = dataItem.Ref.Replace("MainAction." + oldName, "MainAction." + newName);

                    if (childAction.ActionType == EActionTypes.StringBuilder && childAction.ViewInfo != null &&
                        childAction.ActionType != EActionTypes.MainAction)
                        ((ucStringBuilderDetail)childAction.ViewInfo).LoadStringBuilderItems();
                }
            }
        }
        public void PrepareBeforeRun()
        {
            this.IsCanRun = this.Enable.rtcValue;

            //if (this.ActionType == EActionTypes.RunDeep)
            //    PrepareBeforeRun_RunDeep();

            PropIsImageInfos = this.GetType().GetProperties().Where(x =>
                ((RTCVariableType)x.GetValue(this, null)) != null
                && ((RTCVariableType)x.GetValue(this, null)).rtcDisplay && x.GetValue(this, null).GetType() == typeof(SImage)).ToList();
            PropIsDisplayInfos = this.GetType().GetProperties().Where(x =>
                ((RTCVariableType)x.GetValue(this, null)) != null
                && ((RTCVariableType)x.GetValue(this, null)).rtcDisplay && x.GetValue(this, null).GetType() != typeof(SImage)).ToList();

            if (this.IDBranchItem != Guid.Empty)
            {
                this.IsCanRun = false;
                return;
            }
            if (!this.Enable.rtcValue &&
                this.ActionType != EActionTypes.Branch &&
                this.ActionType != EActionTypes.Switch &&
                this.ActionType != EActionTypes.PassFail &&
                this.ActionType != EActionTypes.CounterLoop)
            {
                this.IsCanRun = false;
                return;
            }

            if (this.IsAliveControl != null && this.IsAliveControl.rtcValue)
            {
                this.IsCanRun = false;
                return;
            }
            switch (ActionType)
            {
                case EActionTypes.Branch:
                    Prepare_Branch(this);
                    break;
                case EActionTypes.Switch:
                    Prepare_Switch(this);
                    break;
                case EActionTypes.PassFail:
                    Prepare_PassFail(this);
                    break;
                case EActionTypes.CounterLoop:
                    Prepare_CounterLoop(this);
                    break;
            }
            var listPropertiesResetWhenStart = this.GetType().GetProperties().Where(x => x != null &&
                x.GetValue(this, null) != null &&
                ((RTCVariableType)x.GetValue(this, null)).rtcResetWhenStart).ToList();
            if (listPropertiesResetWhenStart.Any())
                foreach (PropertyInfo propertyInfo in listPropertiesResetWhenStart)
                {
                    var rtcVariableType = (RTCVariableType)this.GetType().GetProperty(propertyInfo.Name)?.GetValue(this, null);
                    if (rtcVariableType == null)
                        continue;

                    switch (propertyInfo.PropertyType.Name)
                    {
                        case nameof(SBool):
                            ((SBool)rtcVariableType).rtcValue = CommonData.GetDefaultValues_Bool(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SString):
                            ((SString)rtcVariableType).rtcValue = CommonData.GetDefaultValues_Text(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SInt):
                            ((SInt)rtcVariableType).rtcValue = CommonData.GetDefaultValues_Int(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SDouble):
                            ((SDouble)rtcVariableType).rtcValue = CommonData.GetDefaultValues_Double(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SListDouble):
                            ((SListDouble)rtcVariableType).rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SListString):
                            ((SListString)rtcVariableType).rtcValue = CommonData.GetDefaultValues_ListString(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SListObject):
                            ((SListObject)rtcVariableType).rtcValue = CommonData.GetDefaultValues_ListObject(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        default:
                            break;
                    }
                }
        }

        public void ResetPropertyValueWhenStop()
        {
            var listPropertiesResetWhenStart = this.GetType().GetProperties().Where(x => x != null &&
                x.GetValue(this, null) != null &&
                ((RTCVariableType)x.GetValue(this, null)).rtcResetWhenStop).ToList();
            if (listPropertiesResetWhenStart.Any())
                foreach (PropertyInfo propertyInfo in listPropertiesResetWhenStart)
                {
                    var rtcVariableType = (RTCVariableType)this.GetType().GetProperty(propertyInfo.Name)?.GetValue(this, null);
                    if (rtcVariableType == null)
                        continue;

                    switch (propertyInfo.PropertyType.Name)
                    {
                        case nameof(SBool):
                            ((SBool)rtcVariableType).rtcValue = CommonData.GetDefaultValues_Bool(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SString):
                            ((SString)rtcVariableType).rtcValue = CommonData.GetDefaultValues_Text(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SInt):
                            ((SInt)rtcVariableType).rtcValue = CommonData.GetDefaultValues_Int(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SDouble):
                            ((SDouble)rtcVariableType).rtcValue = CommonData.GetDefaultValues_Double(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SListDouble):
                            ((SListDouble)rtcVariableType).rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SListObject):
                            ((SListObject)rtcVariableType).rtcValue = CommonData.GetDefaultValues_ListObject(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        case nameof(SListString):
                            ((SListString)rtcVariableType).rtcValue = CommonData.GetDefaultValues_ListString(nameof(propertyInfo.Name) + _SuffixName);
                            break;
                        default:
                            break;
                    }

                    if (this.ActionType != EActionTypes.MainAction && this.ViewInfo != null)
                        ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
                }
        }
        public void ResetCount(bool _WithInterface = false)
        {
            RunCount = 0;
            FailCount = 0;
            ProcessTime = 0;
            TotalTime = 0;
            AbortCause = string.Empty;
            if (_WithInterface && this.MyNode != null)
            {

                GlobVar.RunCount.PutValue(this.MyNode, string.Empty);
                GlobVar.FailCount.PutValue(this.MyNode, string.Empty);
                GlobVar.ProcessTime.PutValue(this.MyNode, string.Empty);
                GlobVar.TotalTime.PutValue(this.MyNode, string.Empty);
                GlobVar.AbortCause.PutValue(this.MyNode, string.Empty);
            }
        }
        public void UpdateValueToOrtherActionsLink_Value(List<PropertyInfo> listPropertyInfo)
        {
            RTCVariableType childValue = null;
            for (int i = 0; i < listPropertyInfo.Count(); i++)
            {
                var nProperty = listPropertyInfo[i];
                if (this.ActionType == EActionTypes.DataInstance && nProperty.Name == nameof(this.Value))
                    continue;
                childValue = (RTCVariableType)GetType().GetProperty(nProperty.Name)?.GetValue(this, null);
                if (childValue == null)
                    continue;
                // truy đến property được property này REF đến
                cAction actionParent = GlobVar.GroupActions.Actions[childValue.rtcIDRef];
                var parentValue = (RTCVariableType)actionParent.GetType().GetProperty(childValue.rtcPropNameRef)?.GetValue(actionParent, null);
                if (parentValue != null)
                {
                    if (nProperty.PropertyType.Name == nameof(SListString) && parentValue.GetType().Name == nameof(SListString))
                    {
                        childValue.GetType().GetProperty(cPropertyName.rtcValue)?.SetValue(childValue, GlobFuncs.CloneStringList(((SListString)parentValue).rtcValue));
                        childValue.rtcValueView = parentValue.rtcValueView;
                    }
                    else
                        childValue.rtcValueView = parentValue.rtcValueView;
                }
                else
                {
                    SStringBuilderItem dataItem = null;
                    if (actionParent.DataItems != null)
                        dataItem = actionParent.DataItems.FirstOrDefault(x => x.Name == childValue.rtcPropNameRef);
                    if (dataItem == null && actionParent.MyExpression != null && actionParent.MyExpression.Operands != null)
                        dataItem = actionParent.MyExpression.Operands.FirstOrDefault(x => x.Name == childValue.rtcPropNameRef);
                    if (DataItems != null)
                        if (childValue.ValueStyle != dataItem.ValueStyle)
                            childValue.GetType().GetProperty(cPropertyName.rtcValue)?.SetValue(childValue, GlobFuncs.CloneStringList(
                                dataItem.ListStringValue));
                }
            }
        }
    }
}
