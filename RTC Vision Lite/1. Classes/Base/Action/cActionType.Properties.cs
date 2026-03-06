using ActUtlType64Lib;
using BrightIdeasSoftware;
using CommonTools;
using Emgu.CV;
using Emgu.CV.Structure;
using ImageMath;
using RTC_Vision_Lite.Commons;
using RTC_Vision_Lite.Forms;
using RTCConst;
using RTCEnums;
using SlmpCustom;
using SLMPTcp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        #region EVENT
        public ButtonClickEvents OnbtnLineCalibEtoEClickEvent;
        #endregion

        public cGroupActions MyGroup;




        #region "NOT PROP => NOT VIEW IN TREELISTVIEW"
        public EActionTypes ActionType;

        public EObjectTypes ObjectType;
        /// <summary>
        /// Cờ báo tool này có phải có phải là tool dạng chứa multiRoi hay không
        /// </summary>
        public bool IsMultiROI = false;

        public Dictionary<long, cROIProperty> ROIProperties = null;
        public FrmHsmartWindow frmHsmartWindow;

        public int RunCount = 0;
        public int FailCount = 0;
        public long ProcessTime = 0;
        public long TotalTime = 0;
        public int AliveValue = 1;

        public List<SStringBuilderItem> StringBuilders = null;
        public List<cLinkPassFail> LinkPassFail = null;
        public List<cLinkPassFail> ListResetTools = null;
        public List<cLinkProperty> LinkProperty = null;
        public Blob_Muilti_ROI.BlobTool _BlobTool = new Blob_Muilti_ROI.BlobTool();
        public AffineImage.AffineImage AffineImage = new AffineImage.AffineImage();
        public PixelCountTool.PixelCount PixelCount = new PixelCountTool.PixelCount();
        public Brightness_Tool.Brightness BrightnessTool = new Brightness_Tool.Brightness();
        public LineFindTool.LineFind LineFind = new LineFindTool.LineFind();
        public Blob_Color_Multi_ROI.BlobColor ColorBlob = new Blob_Color_Multi_ROI.BlobColor();
        public Blob_Color_Multi_ROI.BlobColor ColorBlobMultiROIS = new Blob_Color_Multi_ROI.BlobColor();
        public DistanceMeasurementTool.Measurement DistanceMeasurementTool = new DistanceMeasurementTool.Measurement();
        public ImageFilterTool.ImageFilter ImageFilter = new ImageFilterTool.ImageFilter();
        public Blob_Filter.BlobFilter BlobFilter = new Blob_Filter.BlobFilter();
        public Blob_View.BlobView BlobView = new Blob_View.BlobView();
        public SetOrigin.SetOrigin SetOrigin = new SetOrigin.SetOrigin();
        public OriginTool.Origin OriginTool = new OriginTool.Origin();
        public NewPattern.NewPattern Pattern = new NewPattern.NewPattern();
        public ImageSplit.ImageSplit SplitImage = new ImageSplit.ImageSplit();
        /// <summary>
        public ImageMath.ImageMath ImageMath = new ImageMath.ImageMath();
        public CodeReader.CodeReader CodeReader = new CodeReader.CodeReader();
        /// </summary>
        public List<cImageFilterProperty> ImageFilterProperty = null;
        public EGroupTypes GroupType;
        public CSocketClient MySocket;
        public cCOM MyCOMReader;
        public CSTLightClientNew MyCSTLight;
        public ActUtlType64 MyMXComponent;
        public Image<Gray, byte> GrayImage = null;
        public Image<Bgr, byte> BGRImage = null;
        /// <summary>
        /// True run ROI button click
        /// </summary>
        public bool RunWhenROIButtonClick = true;
        /// <summary> True to deformable pattern roi train find </summary>
        public bool DeformablePattern_ROITrain_Find;

        public bool Blob_ROITrain_Roi;
        /// <summary> True to colỏ BLOB roi train roi </summary>
        public bool ColorBlob_ROITrain_ROI;

        public bool ColorBlob_ROITrain_Find;

        public bool LineFind_ROITrain_ROI;
        public bool PixelCount_ROITrain_ROI;
        public bool VariationModel_ROITrain_ROI;
        public bool VariationModel_ROITrain_Find;
        public bool CorrelationPattern_ROITrain_Find;
        public bool CorrelationPattern_ROITrain_ROI;
        public bool AutoRun = true;



        public bool Brightness_ROITrain_ROI;
        public bool ImageSplit_ROITrain_ROI;
        public bool Calibrate_ROITrain_ROI;
        public bool Origin_ROITrain_ROI;
        public bool OCR_ROITrain_ROI;
        public bool OCR_ROITrain_Find;
        public bool CodeReader_ROITrain_ROI;
        public bool IsMultiROIIsRunEnableControl = false;
        public bool IsUseDefaultBranch = false;

        public bool AffineImage_ROITrain_ROI;
        public bool AnomolyDetection_ROITrain_ROI;
        public bool AnomolyDetection_ROITrain_Find;
        public bool Classification_ROITrain_ROI;
        public bool Classification_ROITrain_Find;
        public bool ObjectDetection_ROITrain_ROI;
        public bool ObjectDetection_ROITrain_Find;
        public bool SemanticSegmentation_ROITrain_ROI;
        public bool SemanticSegmentation_ROITrain_Find;
        //public bool RunWhenROIButtonClick = true
        /// <summary>
        /// True to run PassFail Button Click
        /// </summary>
        public bool RunWhenPassFailButtonClick = true;

        public bool Pattern_ROITrain_Find;
        public void GetImageToInputImage()
        {
            if (InputImage == null)
                return;
            InputImage.rtcValue = null;
            if (InputImage.rtcIDRef == MyGroup.IDMainAction)
                InputImage.rtcValue = MyGroup.Actions[MyGroup.IDMainAction].InputImage.rtcValue;
            else if (InputImage.rtcIDRef != Guid.Empty)
            {
                if (MyGroup.Actions.TryGetValue(InputImage.rtcIDRef, out cAction sourceAction))
                {
                    RTCVariableType sourceImagePropInfo = (RTCVariableType)sourceAction.GetType().GetProperty(InputImage.rtcPropNameRef)?.GetValue(sourceAction, null);
                    InputImage.rtcValue = (Image)sourceImagePropInfo?.GetType().GetProperty(cPropertyName.rtcValue)
                        ?.GetValue(sourceImagePropInfo, null);
                }
            }
            //InputImage.rtcActive = null;
        }
        public cCameraSettings CameraSettings = null;
        internal List<PropertyInfo> PropIsImageInfos = null;
        internal List<PropertyInfo> PropIsDisplayInfos = null;
        internal List<PropertyInfo> PropOutputInfos = null;
        public int Level;
        #endregion
        public cExpression MyExpression;

        // Bổ sung để tăng tốc độ chạy
        internal List<Guid> OrderActionID_Child = null; // toàn bộ tool con của tool này
        internal Stopwatch MyStopWatch = null;
        public cRectangType ReferencePointRectangle = null;
        #region PROPERTY
        public SListString Description { get; set; }
        public SString ProgramID { get; set; }
        public SBool Enable { get; set; }
        public SBool DisplayOutput { get; set; }
        public SBool HighLights { get; set; }
        public SString Note { get; set; }
        public SBool IsRunning { get; set; }
        public SBool IsHaveError { get; set; }
        public SString CamName { get; set; }
        public SString TriggerValue { get; set; }
        public SBool NoCaptureAndUsingDirectImage { get; set; }
        public SWindow WindowHandle { get; set; }
        public SInt ModelOkCount { get; set; }
        public SInt ModelNgCount { get; set; }
        public SInt ModelTotalCount { get; set; }
        public SInt OkCount { get; set; }
        public SInt NgCount { get; set; }
        public SInt TotalCount { get; set; }

        public SBool MatchCase { get; set; }
        public SString StatusType { get; set; }
        public SString CustomStatusType { get; set; }
        public SString Position { get; set; }
        public SBool IsShowDialogMode { get; set; }
        public SString StatusTypeConnect { get; set; }
        public SString ModelInfo { get; set; }
        public SString ModelInfor { get; set; }

        public SString DialogType { get; set; }
        public SString MessageBoxButtons { get; set; }
        public SString DialogCaption { get; set; }
        public SString YesButtonCaption { get; set; }
        public SString NoButtonCaption { get; set; }
        public SString CancelButtonCaption { get; set; }
        public SString DialogResult { get; set; }
        public SInt DialogResultI { get; set; }
        public SBool IsUseYesButton { get; set; }
        public SBool IsUseNoButton { get; set; }
        public SBool IsUseCancelButton { get; set; }
        public SString Message { get; set; }
        public SInt WidthForm { get; set; }
        public SInt HeightForm { get; set; }
        public SBool IsAutoClose { get; set; }
        public SInt AutoCloseWaitTime { get; set; }
        public SString StartupPath { get; set; }
        public SString TemplatePath { get; set; }
        public SString ProjectPath { get; set; }
        public SString ModelPath { get; set; }
        public SString WindowPath_Origin { get; set; }
        public SString WindowPath_Snap { get; set; }
        public SString WindowPath_Passed { get; set; }
        public SString WindowPath_Failed { get; set; }
        public SString WindowPath_File { get; set; }
        public SString WindowName { get; set; }
        public SString CamModel { get; set; }
        public SInt ExposureTime { get; set; }
        public SString TimeFormat { get; set; }
        public SString CurrentDate { get; set; }
        public SString CurrentTime { get; set; }
        public SString CounterType { get; set; }
        public SString CounterNG { get; set; }
        public SString CounterOK { get; set; }

        public SString ViewIn { get; set; }
        public SString ResultMode { get; set; }
        public SInt RunOrder { get; set; }
        public SBool IsSaveGraphicWindow { get; set; }
        public SBool IsSaveOriginImage { get; set; }
        public SBool IsSaveScreenshot { get; set; }
        public SBool IsResize { get; set; }
        public SInt ResizePercentage { get; set; }
        public SString ViewOKNG { get; set; }
        public SString OutputFileNameW { get; set; }
        public SString OutputFileNameS { get; set; }
        public SBool OnlyNG { get; set; }
        public SBool CtrlKey { get; set; }
        public SBool ShiftKey { get; set; }
        public SBool AltKey { get; set; }
        public SBool WindowKey { get; set; }
        public SListString KeyValues { get; set; }
        public SString NumberOfRuns { get; set; }


        public SObject InputObject { get; set; }

        public SInt FailNumber { get; set; }
        public SInt NumberBeginRestart { get; set; }
        public SBool ResetNumberWhenNewDay { get; set; }
        public SString OldDay { get; set; }
        public SBool TabRoiActive { get; set; }
        public SInt InRangeOutputPixel { get; set; }
        public SInt OutRangeOutputPixel { get; set; }
        public SInt Interations { get; set; }
        public SString FilterType { get; set; }
        public SBool TabPassActive { get; set; }
        public SString CameraType { get; set; }
        public SListDouble HomMat_Image_To_World_Out { get; set; }
        public SListDouble HomMat_TCP_To_Tool_Out { get; set; }
        public SListDouble HomMat_Tool_To_TCP_Out { get; set; }
        public SListDouble HomMat_World_To_Image_Out { get; set; }
        public SListDouble ListPointVision { get; set; }
        public SListDouble ListPointRobot { get; set; }
        public SString UseRotatedPoints { get; set; }

        private SListDouble aOvr_Out { get; set; }
        private SLong ValueCounterWhenAdd { get; set; }


        public SString AppendMode { get; set; }
        public SBool Distinct { get; set; }
        public SListImage ImageArray { get; set; }
        public SListDouble XOvr_Out { get; set; }
        public SListDouble YOvr_Out { get; set; }
        public SBool TabMethodActive { get; set; }
        public SBool TabSearchActive { get; set; }
        public SString FileName { get; set; }
        public SString Name { get; set; }
        public SString FolderName { get; set; }
        public SString IFileName { get; set; }
        public SString ProgramMode { get; set; }
        public SString ManualAction { get; set; }
        public SString AdvancedMathematicsMode { get; set; }
        public SString COMName { get; set; }
        public SString SerialPort { get; set; }
        public SString BaudRate { get; set; }
        public SString DataBits { get; set; }
        public SString Parity { get; set; }
        public SString StopBits { get; set; }
        public SBool IsHex { get; set; }
        public SString Model { get; set; }
        public Control ViewInfo;
        public SString DataArchive_FolderName { get; set; }
        public SString DataArchive_FileName { get; set; }
        public SString BranchItemType { get; set; }
        public SString MasterImageFile { get; set; }
        public SString Expression { get; set; }
        public SString ProgramName { get; set; }
        public SListString DefaultValue { get; set; }
        public SBool RunIsSilent { get; set; }
        public SBool IsShowOnlyHighLightProperties { get; set; }
        public SBool IsCanEdit { get; set; }
        public SBool IsAliveControl { get; set; }
        public SBool RepeatMeasurement { get; set; }
        public SListObject ShapeList { get; set; }
        public SListObject FindShapeList { get; set; }
        public SListObject FindShapeListOriginal { get; set; }
        public SString TrainEdgeDetectionMode { get; set; }
        public SString DestinationTypes { get; set; }
        public SListDouble TrainFixedEdgeThresholdRange { get; set; }
        public SListDouble MinCoutourLength { get; set; }
        public SString NoiseLevelMode { get; set; }
        public SInt NoiseLevel { get; set; }
        public SString PossibleRotations { get; set; }

        public SListDouble AngleRangePattern { get; set; }

        public SDouble AngleStepValue { get; set; }

        public SString PossibleScaling { get; set; }
        public SListDouble ScaleRangePattern { get; set; }
        public SString ScaleStepMode { get; set; }
        public SDouble ScaleStepValue { get; set; }
        public SString TrainSubsamplingLevelMode { get; set; }
        public SListDouble TrainSubsamplingLevel { get; set; }

        public SString AffineMode { get; set; }
        public SListDouble InputHomMat2D { get; set; }
        public SListDouble InputTransX { get; set; }
        public SListDouble InputTransY { get; set; }
        public SString Interpolation { get; set; }
        public SListDouble InputOrigin1 { get; set; }
        public SListDouble InputOrigin2 { get; set; }
        public SListDouble InputY { get; set; }
        public SListDouble InputX { get; set; }
        public SListDouble InputAngle { get; set; }
        public SBool UserOrigin { get; set; }
        public SBool RevertAngle { get; set; }


        public SString Polarity { get; set; }
        public SString TrainOptimizationMode { get; set; }
        public SString FindSubsamplingLevelMode { get; set; }
        public SListDouble FindSubsamplingLevel { get; set; }
        public SString FindAngleRangeMode { get; set; }
        public SListDouble FindAngleRange { get; set; }
        public SString FindScaleRangeMode { get; set; }
        public SListDouble FindScaleRange { get; set; }
        public SDouble FindOptimizationLevel { get; set; }
        public SString RunMode { get; set; }
        public SBool IsAllWindows { get; set; }
        public SBool IsRunByRunOrder { get; set; }
        public SListDouble RunOrderCams { get; set; }

        public SDouble MinSearchScore { get; set; }
        public SDouble MinPassScore { get; set; }
        public SListDouble NumberToFindRange { get; set; }
        public SString NumberToFindMode { get; set; }
        public SInt MaxDeformationInPixels { get; set; }
        public SDouble MaxOverlap { get; set; }
        public SString PositionAccuracy { get; set; }
        public SBool CanTouchImageBorder { get; set; }
        public SBool EnableToolTimeOut { get; set; }
        public SInt ToolTimeOut { get; set; }
        public SListDouble ReadTimeOut { get; set; }
        public SBool InputTrained { get; set; }
        public SListDouble InputModelID { get; set; }
        public SListDouble OutputModelID { get; set; }
        public SListDouble OutputModelIDInfo { get; set; }
        public SListDouble ToolMasterOrigin { get; set; }
        public SListDouble OutputMasterOrigin { get; set; }
        public SListDouble OutPutBestOrigin { get; set; }
        public SListDouble OutputOriginList { get; set; }
        public SListDouble OutputOriginListEx { get; set; }
        public SInt OutputOriginListCount { get; set; }
        public SListDouble ActualTrainFixedThresholdRange { get; set; }
        public SListDouble ActualNoiseLevel { get; set; }
        public SListDouble ActualTrainSubsamlingLevel { get; set; }
        public SListDouble ActualAngleStepValue { get; set; }
        public SListDouble ActualScaleStepValue { get; set; }
        public SBool OutputTrained { get; set; }
        public SListDouble ActualColumn { get; set; }
        public SListDouble ActualRow { get; set; }
        public SListDouble ActualAngle { get; set; }
        public SDouble OutputMasterOrigin_X { get; set; }
        public SDouble OutputMasterOrigin_Y { get; set; }
        public SDouble OutputMasterOrigin_Phi { get; set; }
        public SDouble OutputBestOrigin_X { get; set; }
        public SDouble OutputBestOrigin_Y { get; set; }
        public SDouble OutputBestOrigin_Phi { get; set; }
        public SListDouble OutputOriginListSortedByRowEx { get; set; }
        public SString OutputOriginListSorteMode { get; set; }

        public SBool GP01 { get; set; }
        public SBool GP02 { get; set; }
        public SBool GP03 { get; set; }
        public SBool GP04 { get; set; }
        public SBool GP05 { get; set; }
        public SBool GP06 { get; set; }
        public SBool GP07 { get; set; }
        public SBool GP08 { get; set; }
        public SBool GP09 { get; set; }
        public SBool GP10 { get; set; }
        public SBool GP11 { get; set; }
        public SBool GP12 { get; set; }
        public SBool GP13 { get; set; }
        public SBool GP14 { get; set; }
        public SBool GP15 { get; set; }
        public SBool GP16 { get; set; }
        public SBool GPI1 { get; set; }
        public SBool GPI2 { get; set; }
        public SBool GPI3 { get; set; }
        public SBool GPI4 { get; set; }
        public SBool GPI5 { get; set; }
        public SBool GPI6 { get; set; }
        public SBool GPI7 { get; set; }
        public SBool GPI8 { get; set; }
        public SListDouble OutputOriginListSortedByColumn { get; set; }
        public SListDouble OutputOriginListSortedByColumnEX { get; set; }
        public SString AngleStepMode { get; set; }
        public SListDouble OutputScore { get; set; }
        public SString PlacementMode { get; set; }
        public SListDouble ModelReferenceOrigin { get; set; }
        public SListDouble OutputBestHomMat2D { get; set; }
        public SListDouble OutputBestHomMat2DList { get; set; }

        public ActionTools MyNode;
        public BrightIdeasSoftware.TreeListView test;
        internal Stopwatch MyStopwatch = null;
        internal Stopwatch MyStopwatchUi = null;
        public long GroupTime = 0;

        public SListString ErrMessage { get; set; }
        public bool IsRunned = false;

        public int RunCountInProcess = 0;
        public bool isTrainned = false;
        public SListDouble OffsetValue { get; set; }
        public SString ImageOperation { get; set; }
        public SImage InputImage { get; set; }
        public SGrayImage InputGrayImage { get; set; }
        public SBgrImage InputBgrImage { get; set; }
        public SImage InputImage2 { get; set; }
        public SGrayImage InputGrayImage2 { get; set; }
        public SBgrImage InputBgrImage2 { get; set; }
        public SImage ImageMaster { get; set; }
        public Image ImageBackup = null;
        public SBool IsKeepImage { get; set; }
        public SBool IsBringImageToMain { get; set; }
        public SString SnapMode { get; set; }
        public SString CameraMode { get; set; }
        public SString InterfaceName { get; set; }
        public SString DeviceName { get; set; }
        public SString DeviceNameOrigin { get; set; }
        public SString VendorName { get; set; }
        public SString TemplateName { get; set; }
        public SBool UseCameraSettings { get; set; }
        public SBool AdaptImageSize { get; set; }
        public SString SplitType { get; set; }
        public SListDouble ColumnNumber { get; set; }
        public SListDouble CurrentImageIndexOut { get; set; }
        public SListDouble CurrentImageIndex { get; set; }
        public SListDouble RowNumber { get; set; }
        public SBool PreviousPressed { get; set; }
        public SBool NextPressed { get; set; }
        public SString ShapeListROIType { get; set; }

        public SDouble DynamicOffset { get; set; }
        public SBool FillHoles { get; set; }
        public SBool EnableOutputBlobList { get; set; }
        public SBool EnableOutputDimsList { get; set; }
        public SBool EnableOutputAreaList { get; set; }
        public SListObject MasterShapeList { get; set; }
        //  public SShapeList ShapeList { get; set; }
        public SListObject OutputMasterShapeList { get; set; }
        public SListObject ShapeListOriginal { get; set; }
        public SListDouble OutputPointList { get; set; }
        public SListString DestinationPort { get; set; }
        public SString Destination { get; set; }
        public SListDouble ToolOrigin { get; set; }
        public SListDouble InSetOrigin { get; set; }

        public SListDouble LineTwo { get; set; }
        public SListVector DistanceCircleContour { get; set; }
        public SString MeasureEndPoint { get; set; }
        public SString MeasureDirection { get; set; }
        public SListDouble IntersectionPoint { get; set; }
        public SString ROILegend { get; set; }
        public SString OriginType { get; set; }

        public SString ProjectName { get; set; }
        public SBool AutoStart { get; set; }
        public SBool IsUsingOrderNumber { get; set; }
        public SInt OrderNumber { get; set; }

        /// <summary>
        /// Integer
        /// </summary>
        public SListDouble ThresholdRange { get; set; }
        public SInt MaskHeight { get; set; }
        public SInt MaskWidth { get; set; }
        public SString ThresholdMode { get; set; }
        public SString PixelColor { get; set; }
        public SBool Invert { get; set; }
        public SListDouble BrightnessRange { get; set; }
        public SDouble Brightness { get; set; }
        public SListDouble PixelCountRange { get; set; }
        public SInt Pixels { get; set; }
        public SListDouble ActualThresholdRange { get; set; }
        public SBool EnableAreaFilter { get; set; }
        /// <summary>
        /// Add vào 1 cặp số (real)
        /// </summary>
        public SListDouble AreaRange { get; set; }
        public SBool EnableOuterRadiusFilter { get; set; }

        public SString IPAddress { get; set; }
        public SInt PortNumber { get; set; }
        public SBool IsServer { get; set; }
        public SInt SendTimeOut { get; private set; }
        public SBool IsSendOriginalValue { get; set; }
        public SString SourceMode { get; set; }
        public SString Port { get; set; }
        public SString SourceModePort { get; set; }

        public SString HostName { get; set; }
        public SString UserName { get; set; }
        public SString PassWord { get; set; }

        /// <summary>
        /// real
        /// </summary>
        public SListDouble OuterRadiusRange { get; set; }

        public SBool EnableHeightFilter { get; set; }
        public SBool EnableLongestLengthFilter { get; set; }
        public SBool EnableShortestLengthFilter { get; set; }
        /// <summary>
        /// Real
        /// </summary>
        public SListDouble LongestLengthRange { get; set; }
        public SListDouble LongestLengthActual { get; set; }

        public SListDouble ShortestLengthRange { get; set; }
        public SListDouble ShortestLengthActual { get; set; }

        public SListDouble HeightRange { get; set; }
        public SListDouble RedTolerance { get; set; }
        public SListDouble BlueTolerance { get; set; }
        public SListDouble GreenTolerance { get; set; }
        public SListDouble HueTolerance { get; set; }
        public SListDouble SaturationTolerance { get; set; }
        public SListDouble IntensityToleranceOut { get; set; }
        public SListDouble IntensityTolerance { get; set; }
        public SListDouble HueToleranceOut { get; set; }
        public SListDouble SaturationToleranceOut { get; set; }
        public SListDouble RedToleranceOut { get; set; }
        public SListDouble GreenToleranceOut { get; set; }
        public SListDouble BlueToleranceOut { get; set; }

        public SInt StartNumber { get; set; }
        public SInt MaxNumber { get; set; }
        public SInt ResetNumber { get; set; }
        public SInt Step { get; set; }


        public SBool KeepValueToNextSession { get; set; }



        public SString OutputPolarity { get; set; }
        public SBool EnableWidthFilter { get; set; }
        public SListDouble WidthRange { get; set; }
        public SBool EnableCircularityFilter { get; set; }
        public SListDouble CircularityRange { get; set; }
        public SBool EnableRectangularityFilter { get; set; }
        public SListDouble RectangularityRange { get; set; }
        public SListDouble RectangularityFilter { get; set; }
        public SListObject RequiredNumberOfBlobs { get; set; }
        //public SListObject A { get; set; }
        public SString Operation { get; set; }
        public SBool ResultOK { get; set; }
        public SString GreyLevelThresholdType { get; set; }
        public SDouble Min { get; set; }
        public SDouble Max { get; set; }
        public SBool IsHaveWarning { get; set; }
        public SBool IsMasterResult { get; set; }
        public SBool IsMasterView { get; set; }
        public SString PassCriteria { get; set; }


        public SListString IndexToGetActual { get; set; }

        public SListDouble AreaActual { get; set; }
        public SListDouble WidthActual { get; set; }
        public SListDouble HeightActual { get; set; }
        public SListDouble OuterRadiusActual { get; set; }
        public SListDouble CircularityActual { get; set; }
        public SListDouble RectangularityActual { get; set; }
        public SListDouble ColumnActual { get; set; }
        public SListDouble RowActual { get; set; }
        public SListVector InputRegion { get; set; }
        public SListVector OutputRegion { get; set; }

        public SListDouble GrayValue { get; set; }
        public SString Margin { get; set; }
        public SListVector InputRegion2 { get; set; }
        public SListDouble PointTwo { get; set; }
        public SListDouble Point { get; set; }
        public SListDouble Line { get; set; }
        public SString DistanceType { get; set; }
        public SString MeasurementType { get; set; }
        public SDouble DisplayRadius { get; set; }
        public SString DistanceContourType { get; set; }
        public SListDouble RowRange { get; set; }
        public SListDouble ColumnRange { get; set; }
        public SString Order { get; set; }

        public SBool EnableSortRegion { get; set; }
        public SString SortMode { get; set; }
        public SString RowOrCol { get; set; }
        public SListString SelectedIndex { get; set; }
        public SString RegionMath { get; set; }
        public SListVector InputBlobList { get; set; }
        public SListVector BlobList { get; set; }
        public SListString Header { get; set; }
        public SBool EnableRowFilter { get; set; }
        public SBool EnableColumnFilter { get; set; }
        public SBool SmartFeature { get; set; }
        public SString DynamicFeature { get; set; }
        public SImage ReferenceImage { get; set; }
        public SListString StringList { get; set; }
        public SString DataArchive_ArchiveName { get; set; }
        public SString WriteMode { get; set; }
        public SBool BinaryMode { get; set; }
        public SString TranferMode { get; set; }
        public SString CalculateMode { get; set; }

        public SString ImageArchive_FolderName { get; set; }
        public SString ImageArchive_Name { get; set; }
        public SString ImageArchive_TranferMode { get; set; }
        public SString ImageArchive_FileName { get; set; }
        public SString ImageArchive_FullFileName { get; set; }
        public SBool AppendCountToFileName { get; set; }
        public SInt Count { get; set; }
        public SInt CurrentCount { get; set; }
        public SInt RolloverAt { get; set; }
        public SInt ImageArchive_MaximumNumberOfImagesInQueue { get; set; }
        public SInt MaximumNumberOfTextItemsInQueue { get; set; }
        private int NumberOfTextItemsInQueue = 0;

        private List<string> DataArchive_ContentList = new List<string>();

        public SString OldFullPath { get; set; }
        public SString FullPath { get; set; }
        public SString Status { get; set; }
        public SBool FixedFileName { get; set; }
        public SString OldFileName { get; set; }
        public SString OutputFileName { get; set; }
        public SString ClassNameUse { get; set; }
        public SString FunctionName { get; set; }
        public SListDouble NumberOfBlobsFound { get; set; }
        public SString ColorSpace
        {
            get;
            set;
        }
        public SString DetectType { get; set; }

        public SListObject OutputShapeList { get; set; }
        public SString DataArchive_DestinationTypes { get; set; }

        public SString PositionMode { get; set; }
        public SListDouble OutputResultList { get; set; }
        public SListObject ShapeListData { get; set; }
        public SListObject OutputFindShapeList { get; set; }

        public SListObject InputOne { get; set; }
        public SListObject InputTwo { get; set; }
        public SListObject InputThree { get; set; }
        public SString Operator { get; set; }
        public SBool AbsoluteResult { get; set; }
        public SListObject Result { get; set; }

        public SInt NumberOfRun { get; set; }
        public SString ReturnMode { get; set; }
        public SString ToolName { get; set; }
        public SString ToolID { get; set; }

        public SBool IsUseNumberOfRun { get; set; }

        public SString LeadingText { get; set; }
        public SString TrallingText { get; set; }
        public SInt Terminator { get; set; }
        public SInt DelimiterType { get; set; }
        public SInt DelimiterStandard { get; set; }
        public SString DelimiterCustom { get; set; }
        public SString OutputHeaderString { get; set; }
        public SString OutputStringSend { get; set; }
        public SString OutputString { get; set; }
        public SListObject OutputDataList { get; set; }
        public SInt DecimalSeparator { get; set; }

        public SInt SamplingPercent { get; set; }
        public SString EdgeTransition { get; set; }
        public SString EdgeType { get; set; }
        public SBool EnableGapLengthCheck { get; set; }
        public SBool EnableLineLengthCheck { get; set; }
        public SListDouble OutputIndexOK { get; set; }
        public SListDouble OutputIndexNG { get; set; }
        public SListDouble Tolerance { get; set; }
        public SDouble ScaleFactor { get; set; }
        public SDouble TrainDistance { get; set; }
        public SDouble Distance { get; set; }
        public SDouble DistanceError { get; set; }
        public SDouble CalibrationScale { get; set; }

        public SBool RoundResult { get; set; }

        public SListDouble RoundFactor { get; set; }

        public SBool UseTolerance { get; set; }

        public SString SelectDataInteractionType { get; set; }

        public SString ReplaceDataInteractionType { get; set; }
        public SBool EnableAngleRangeCheck { get; set; }
        public SListDouble GapLengthRange { get; set; }
        public SListDouble LineLengthTolerance { get; set; }
        public SListDouble LineAngleTolerance { get; set; }
        public SDouble OutlierDistanceThreshold { get; set; }
        public SDouble MaxPercentageOfOutliers { get; set; }
        public SInt MinEdgePointNumber { get; set; }
        public SListDouble DefaultOrigin { get; set; }
        public SBool UseMasterOrigin { get; set; }
        public SString SubpixelMethod { get; set; }
        public SInt EdgeDetectionThreshold { get; set; }
        public SDouble Sigma { get; set; }
        public SDouble GreatestOutlierDistance { get; set; }
        public SDouble GreatestGapLength { get; set; }
        public SDouble PercentageOfOutliers { get; set; }
        public SListDouble EdgePoints { get; set; }
        public SListDouble OutlierPoints { get; set; }
        public SListDouble LineSegment { get; set; }
        public SListDouble AngleRange { get; set; }
        public SString ValueTypes { get; set; }
        public SString ValueTypesConvert { get; set; }
        public SBool IsAutoCreateRoi { get; set; }
        public Dictionary<long, object> ROIs = null;
        public SListDouble OutputDisplayTextPosition { get; set; }
        public SListDouble DistanceErrorPoints { get; set; }
        public SDouble ScaleFactorOut { get; set; }
        public SDouble TrainDistanceOut { get; set; }
        public SListDouble DistanceMin { get; set; }

        public SString MorphologyType { get; set; }
        public SString MaskType { get; set; }
        public SDouble MaskRadius { get; set; }

        public SString InputString { get; set; }
        public SString Code { get; set; }
        public SBool Industrial25 { get; set; }
        public SBool Interleaved25 { get; set; }
        public SBool CODABAR { get; set; }
        public SBool CODE_39 { get; set; }
        public SBool MAXICODE { get; set; }
        public SBool Interleaved { get; set; }
        public SBool RSS_14 { get; set; }
        public SBool RSS_EXPANDED { get; set; }

        public SBool CODE_93 { get; set; }
        public SBool CODE_128 { get; set; }
        public SBool MSI { get; set; }
        public SBool PHARMA_CODE { get; set; }
        public SBool EAN_8 { get; set; }
        public SBool EAN_13 { get; set; }
        public SBool UPC_A { get; set; }
        public SBool UPC_E { get; set; }
        public SBool UPC_EAN_EXTENSION { get; set; }
        public SBool PLESSEY { get; set; }
        public SBool IMB { get; set; }
        public SBool GS1128 { get; set; }
        public SBool DATA_MATRIX { get; set; }
        public SBool QR_CODE { get; set; }
        public SBool MicroQRCode { get; set; }
        public SBool PDF_417 { get; set; }
        public SBool AZTEC { get; set; }
        public SBool DotCode { get; set; }
        public SBool GS1DataMatrix { get; set; }
        public SListString InputCodeHandle { get; set; }
        public SBool Input1DTrained { get; set; }
        public SBool Input2DTrained { get; set; }
        public SBool MatchString { get; set; }
        public SListObject NumberCodeRequired { get; set; }
        public SBool CheckQuantity { get; set; }
        public SListString ResultCode { get; set; }
        public SListString OutputCodeType { get; set; }
        public SListString OutputCodeHandle { get; set; }
        public SBool Output2DTrained { get; set; }
        public SListVector CodeBoundary { get; set; }
        public SBool Output1DTrained { get; set; }
        public SInt NumberOfCodeFound { get; set; }

        public SString DefaultOutputString { get; set; }

        public SString TrainCodeMode { get; set; }
        public SListDouble MaximumNumberOfCodeToFind { get; set; }
        public SListDouble BarcodeHeightMin { get; set; }
        public SString FileMasterTrain { get; set; }
        //public SListString ErrMesage 

        //public SBool EnableRectangularityFilter { get; set; }
        public Guid IDBranch;

        public int STTBranch = 0;

        public Guid IDBranchItem;
        public string AbortCause = string.Empty;

        public bool IsCanRun = false;
        public Guid ID;

        public int STT;

        public bool _CanChangeName;

        public bool DataChanged;

        public bool RunOnlyROISelected = true;
        private string _Name;

        public string _SuffixName;
        public SBool TrainPressed { get; set; }
        public SBool ResetPressed { get; set; }

        public List<SStringBuilderItem> DataItems = null;

        public Dictionary<long, object> MainROIs = null;
        public Dictionary<long, object> FindROIs = null;
        public List<cColumnProperty> Columns = null;

        public SListString Value { get; set; }
        public SString BitMode { get; set; }

        public SInt ValueLength { get; set; }
        public SInt LogicalStationNumber { get; set; }
        public SInt ReceiveTimeOut { get; set; }
        public SBool IsCompareValue { get; set; }
        public SListString CompareValue { get; set; }
        public SListDouble Channel { get; set; }
        public SString ModeChannel { get; set; }

        public SListString SimulatorValue { get; set; }
        public SBool IsUseValueTypesConvert { get; set; }
        public SImage OutputImage { get; set; }
        public SGrayImage OutputGrayImage { get; set; }
        public SBgrImage OutputBgrImage { get; set; }

        public SListVector OutputBlobList { get; set; }

        public SListDouble OutputAreaList { get; set; }
        public SListDouble AutoThresholdRange { get; set; }
        public SListDouble OutputWidthList { get; set; }
        public SListDouble OutputHeightList { get; set; }
        public SString AliveValueOn { get; set; }
        public SString AliveValueOff { get; set; }
        public SInt TimeDelay { get; set; }
        public SString Address { get; set; }
        public SListString ValueAfterDelay { get; set; }
        public SListString ValueAfterStop { get; set; }
        public SBool IsFinishRunOneTime { get; set; }
        public SBool IsRunOneTime { get; set; }
        public SString WaitMode { get; set; }
        public SBool ForceSetValueDataInstance { get; set; }
        public SString SourceType { get; set; }

        public SBool Passed { get; set; }
        public SBool RequiredPass { get; set; }
        public SString ROIName { get; set; }
        public SListDouble CenterPoint { get; set; }
        public SListDouble Width { get; set; }
        public SListDouble Height { get; set; }
        public SListDouble Angle { get; set; }
        public SString DrawingType { get; set; }
        public SString DrawingMode { get; set; }
        public SLMPClient MyMCProtocolTCP;
        public cSlmpCustom SLMP1;

        public SString PrefixName { get; set; }
        public SBool IsUseProjectFolder { get; set; }
        public SString SuffixNameMode { get; set; }
        public SString DateTimeFormat { get; set; }
        public SBool IsAutoResetWhenNewSession { get; set; }
        public SBool OverwriteWhenExists { get; set; }
        public SString Password { get; set; }
        public SString ImageTypes { get; set; }
        public SString SaveMode { get; set; }

        public SString DateFormat { get; set; }
        public SBool IsSaveMyWindow { get; set; }
        public SBool AutoCreateFolderByDate { get; set; }

        public SString Separator { get; set; }

        public SDouble ElapsedTime { get; set; }
        public SLong CycleTime { get; set; }
        public SBool IsSaveDetailCycleTimeToFile { get; set; }
        public SBool IsSaveDetailToOneFile { get; set; }
        public SString SegmentText { get; set; }
        public SString StartTime { get; set; }
        public SBool IncludeSubdirectories { get; set; }
        public SBool IsChanged { get; set; }
        public SBool IsCreated { get; set; }
        public SBool IsRenamed { get; set; }
        public SBool IsDeleted { get; set; }
        public SString Filter { get; set; }
        public SString Command { get; set; }
        public SString Arguments { get; set; }
        public SBool IsCreateNoWindow { get; set; }
        public SString WindowStyle { get; set; }


        //public Guid ReturnToolID = Guid.Empty;

        // public SDouble Value { get; set; }
        #endregion

    }
}
