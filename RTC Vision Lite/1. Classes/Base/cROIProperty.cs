using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTCConst;
using RTCEnums;
using RTC_Vision_Lite.UserControls;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.Classes;
using System.Reflection;


namespace RTC_Vision_Lite.Classes
{
    public class cROIProperty
    {
        /// <summary>
        /// ID này là ID do chương trình tự sinh ra để quản lý dữ liệu, không tham gia vào các chu trình thao tác
        /// Việc đó sẽ do ID đảm nhiệm
        /// </summary>
        public Guid GID;
        public bool Selected;
        public long IDLink;
        public long ID;
        public bool Active;
        public EActionTypes ActionType;

        public SString DetectType { get; set; }
        public SString GreyLevelThresholdType { get; set; }
        public SBool FillHoles { get; set; }
        public SListDouble ThresholdRange { get; set; }

        public SBool EnableAreaFilter { get; set; }

        public SListDouble AreaRange { get; set; }
        public SBool EnableOuterRadiusFilter { get; set; }

        public SListDouble OuterRadiusRange { get; set; }
        public SBool EnableHeightFilter { get; set; }
        public SBool EnableColumnFilter { get; set; }
        public SBool EnableRowFilter { get; set; }
        public SListDouble HeightRange { get; set; }
        public SBool EnableWidthFilter { get; set; }
        public SListDouble WidthRange { get; set; }

        public SBool RequiredPass { get; set; }
        public SListObject RequiredNumberOfBlobs { get; set; }
        public SBool Passed { get; set; }

        public SInt SamplingPercent { get; set; }
        public SString EdgeTransition { get; set; }
        public SString EdgeType { get; set; }
        public SString SubpixelMethod { get; set; }
        public SInt EdgeDetectionThreshold { get; set; }

        public SString ROILegend { get; set; }
        public SListDouble DeFaultOrigin { get; set; }
        public SInt MinEdgePointNumber { get; set; }
        public SDouble OutlierDistanceThreshold { get; set; }
        public SString DefaultOutputString { get; set; }
        public SListDouble RedTolerance { get; set; }
        public SListDouble BlueTolerance { get; set; }
        public SListDouble GreenTolerance { get; set; }
        public SListDouble HueTolerance { get; set; }
        public SListDouble SaturationTolerance { get; set; }
        public SListDouble IntensityTolerance { get; set; }
        public SString ColorSpace { get; set; }
        public SString Expression { get; set; }
        public SListDouble BarcodeHeightMin { get; set; }
        public SListDouble MaximumNumberOfCodeToFind { get; set; }

        public SListDouble AbsThreshold { get; set; }
        public SListDouble VarThreshold { get; set; }
        public SString VariationModelCompareMode { get; set; }
        public SListDouble ReAlignModelID { get; set; }
        public SListDouble AllowdErrorPercentage { get; set; }

        public SBool UseGlobalSetUpParams { get; set; }
        public SString ColorMode { get; set; }
        public SListDouble CenterPoint { get; set; }
        public SString DrawingType { get; set; }
        public SString DrawingMode { get; set; }
        public SString ROIName { get; set; }
        public SListDouble Angle { get; set; }
        public SListDouble Width { get; set; }
        public SListDouble Height { get; set; }
        public SString ROIColor { get; set; }
        public SString AlphaColor { get; set; }

        public void SetupPropertyByCalibrateEdgeToEdge()
        {
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
            cAction action = new cAction(EActionTypes.LineFind, EObjectTypes.Action, null, null);

            SamplingPercent.rtcValue = CommonData.GetDefaultValues_Int(nameof(SamplingPercent) + action._SuffixName);
            EdgeTransition.rtcValue = CommonData.GetDefaultValues_Text(nameof(EdgeTransition) + action._SuffixName);
            EdgeType.rtcValue = CommonData.GetDefaultValues_Text(nameof(EdgeType) + action._SuffixName);
            SubpixelMethod.rtcValue = CommonData.GetDefaultValues_Text(nameof(SubpixelMethod) + action._SuffixName);
            EdgeDetectionThreshold.rtcValue = CommonData.GetDefaultValues_Int(nameof(EdgeDetectionThreshold) + action._SuffixName);
            action = null;

        }
        public void SetupPropertyByOrigin()
        {
            ROILegend = new SString(CommonData.GetPropertyDescription(nameof(ROILegend)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            SamplingPercent = new SInt(CommonData.GetPropertyDescription(nameof(ROILegend)),
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
            MinEdgePointNumber = new SInt(CommonData.GetPropertyDescription(nameof(MinEdgePointNumber)),
               EHTupleStyle.None,
               EPropertyState.Input,
               EROILegend.None,
               false,
               false,
               false,
               false);
            DeFaultOrigin = new SListDouble(CommonData.GetPropertyDescription(nameof(DeFaultOrigin)),
               EHTupleStyle.None,
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
            cAction action2 = new cAction(EActionTypes.Origin, EObjectTypes.Action, null, null);
            ROILegend.rtcValue = CommonData.GetDefaultValues_Text(nameof(ROILegend) + action2._SuffixName);
            DeFaultOrigin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(DeFaultOrigin) + action2._SuffixName);
            action2 = null;

            cAction action = new cAction(EActionTypes.LineFind, EObjectTypes.Action, null, null);
            OutlierDistanceThreshold.rtcValue = CommonData.GetDefaultValues_Double (nameof(OutlierDistanceThreshold) + action._SuffixName);
            MinEdgePointNumber.rtcValue = CommonData.GetDefaultValues_Int(nameof(MinEdgePointNumber) + action._SuffixName);
            SamplingPercent.rtcValue = CommonData.GetDefaultValues_Int(nameof(SamplingPercent) + action._SuffixName);
            EdgeTransition.rtcValue = CommonData.GetDefaultValues_Text(nameof(EdgeTransition) + action._SuffixName);
            EdgeType.rtcValue = CommonData.GetDefaultValues_Text(nameof(EdgeType) + action._SuffixName);
            SubpixelMethod.rtcValue = CommonData.GetDefaultValues_Text(nameof(SubpixelMethod) + action._SuffixName);
            EdgeDetectionThreshold.rtcValue = CommonData.GetDefaultValues_Int(nameof(EdgeDetectionThreshold) + action._SuffixName);
            action = null;
        }
        public void SetUpPropertyByBlobMultipleROI()
        {
            DetectType = new SString(CommonData.GetPropertyDescription(nameof(DetectType)), EHTupleStyle.None, EPropertyState.Input);
            GreyLevelThresholdType = new SString(CommonData.GetPropertyDescription(nameof(GreyLevelThresholdType)), EHTupleStyle.None, EPropertyState.Input);
            FillHoles = new SBool(CommonData.GetPropertyDescription(nameof(FillHoles)), EHTupleStyle.None, EPropertyState.Input);
            ThresholdRange = new SListDouble(CommonData.GetPropertyDescription(nameof(ThresholdRange)), EHTupleStyle.RangeMinMaxLimit, EPropertyState.Input);
            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)), EHTupleStyle.None, EPropertyState.Input);
            AreaRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaRange)), EHTupleStyle.RangeMinMax, EPropertyState.Input);
            EnableOuterRadiusFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableOuterRadiusFilter)), EHTupleStyle.None, EPropertyState.Input);
            OuterRadiusRange = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusRange)), EHTupleStyle.ValueList, EPropertyState.Input);
            EnableHeightFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableHeightFilter)), EHTupleStyle.None, EPropertyState.Input);
            HeightRange = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightRange)), EHTupleStyle.ValueList, EPropertyState.Input);
            EnableWidthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableWidthFilter)), EHTupleStyle.None, EPropertyState.Input);
            WidthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthRange)), EHTupleStyle.ValueList, EPropertyState.Input);
            RequiredNumberOfBlobs = new SListObject(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)), EHTupleStyle.ValueList, EPropertyState.Input);

            cAction action = new cAction(EActionTypes.BlobMultipleROI, EObjectTypes.Action, null, null);

            DetectType.rtcValue = CommonData.GetDefaultValues_Text(nameof(DetectType) + action._SuffixName);
            GreyLevelThresholdType.rtcValue = CommonData.GetDefaultValues_Text(nameof(GreyLevelThresholdType) + action._SuffixName);
            FillHoles.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FillHoles) + action._SuffixName);
            ThresholdRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ThresholdRange) + action._SuffixName);


            EnableAreaFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableAreaFilter) + action._SuffixName);
            AreaRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AreaRange) + action._SuffixName);
            WidthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(WidthRange) + action._SuffixName);
            HeightRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HeightRange) + action._SuffixName);
            OuterRadiusRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(OuterRadiusRange) + action._SuffixName);
            EnableOuterRadiusFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOuterRadiusFilter) + action._SuffixName);
            EnableHeightFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableHeightFilter) + action._SuffixName);
            EnableWidthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableWidthFilter) + action._SuffixName);
            RequiredNumberOfBlobs.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(RequiredNumberOfBlobs) + action._SuffixName);

            action = null;

        }
        public void SetupPropertyByCodeReader()
        {
            DefaultOutputString = new SString(CommonData.GetPropertyDescription(nameof(DefaultOutputString)),
                EHTupleStyle.None,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            BarcodeHeightMin = new SListDouble(CommonData.GetPropertyDescription(nameof(BarcodeHeightMin)),
                EHTupleStyle.ValueList,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            MaximumNumberOfCodeToFind = new SListDouble(CommonData.GetPropertyDescription(nameof(MaximumNumberOfCodeToFind)),
                EHTupleStyle.ValueList,
                EPropertyState.Input,
                EROILegend.None,
                false,
                false,
                false,
                false);
            cAction action = new cAction(EActionTypes.CodeReader, EObjectTypes.Action, null, null);
            BarcodeHeightMin.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(BarcodeHeightMin) + action._SuffixName);
            MaximumNumberOfCodeToFind.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(MaximumNumberOfCodeToFind) + action._SuffixName);
            DefaultOutputString.rtcValue = CommonData.GetDefaultValues_Text(nameof(MaximumNumberOfCodeToFind) + action._SuffixName);
            action = null;


        }
        public void SetUpPropertyByColorMultipleROI()
        {
            RedTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(RedTolerance)), EHTupleStyle.Tolerance, EPropertyState.Input);
            BlueTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(BlueTolerance)), EHTupleStyle.Tolerance, EPropertyState.Input);
            GreenTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(GreenTolerance)), EHTupleStyle.Tolerance, EPropertyState.Input);
            HueTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(HueTolerance)), EHTupleStyle.Tolerance, EPropertyState.Input);
            SaturationTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(SaturationTolerance)), EHTupleStyle.Tolerance, EPropertyState.Input);
            IntensityTolerance = new SListDouble(CommonData.GetPropertyDescription(nameof(IntensityTolerance)), EHTupleStyle.Tolerance, EPropertyState.Input);
            ColorSpace = new SString(CommonData.GetPropertyDescription(nameof(ColorSpace)), EHTupleStyle.None, EPropertyState.Input);

            SaturationTolerance.rtcIsReBinding = true;
            IntensityTolerance.rtcIsReBinding = true;
            GreenTolerance.rtcIsReBinding = true;
            RedTolerance.rtcIsReBinding = true;
            BlueTolerance.rtcIsReBinding = true;
            HueTolerance.rtcIsReBinding = true;

            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)), EHTupleStyle.None, EPropertyState.Input);
            EnableRowFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableRowFilter)), EHTupleStyle.None, EPropertyState.Input);
            EnableColumnFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableColumnFilter)), EHTupleStyle.None, EPropertyState.Input);

            AreaRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaRange)), EHTupleStyle.RangeMinMax, EPropertyState.Input);
            EnableOuterRadiusFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableOuterRadiusFilter)), EHTupleStyle.None, EPropertyState.Input);
            OuterRadiusRange = new SListDouble(CommonData.GetPropertyDescription(nameof(OuterRadiusRange)), EHTupleStyle.ValueList, EPropertyState.Input);
            EnableHeightFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableHeightFilter)), EHTupleStyle.None, EPropertyState.Input);
            HeightRange = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightRange)), EHTupleStyle.ValueList, EPropertyState.Input);
            EnableWidthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableWidthFilter)), EHTupleStyle.None, EPropertyState.Input);
            WidthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthRange)), EHTupleStyle.ValueList, EPropertyState.Input);
            RequiredNumberOfBlobs = new SListObject(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)), EHTupleStyle.ValueList, EPropertyState.Input);
            FillHoles = new SBool(CommonData.GetPropertyDescription(nameof(FillHoles)), EHTupleStyle.None, EPropertyState.Input);


            cAction action = new cAction(EActionTypes.ColorBlob, EObjectTypes.Action, null, null);

            RedTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(RedTolerance) + action._SuffixName);
            BlueTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(BlueTolerance) + action._SuffixName);
            GreenTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(GreenTolerance) + action._SuffixName);
            HueTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HueTolerance) + action._SuffixName);
            SaturationTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(SaturationTolerance) + action._SuffixName);
            IntensityTolerance.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(SaturationTolerance) + action._SuffixName);
            ColorSpace.rtcValue = CommonData.GetDefaultValues_Text(nameof(ColorSpace) + action._SuffixName);

            action = new cAction(EActionTypes.Blob, EObjectTypes.Action, null, null);
            FillHoles.rtcValue = CommonData.GetDefaultValues_Bool(nameof(FillHoles) + action._SuffixName);
            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)), EHTupleStyle.None, EPropertyState.Input);
            AreaRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AreaRange) + action._SuffixName);
            WidthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(WidthRange) + action._SuffixName);
            HeightRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HeightRange) + action._SuffixName);
            OuterRadiusRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(OuterRadiusRange) + action._SuffixName);
            EnableOuterRadiusFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableOuterRadiusFilter) + action._SuffixName);
            EnableHeightFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableHeightFilter) + action._SuffixName);
            EnableWidthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableWidthFilter) + action._SuffixName);
            EnableColumnFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableColumnFilter) + action._SuffixName);
            EnableRowFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableRowFilter) + action._SuffixName);
            RequiredNumberOfBlobs.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(RequiredNumberOfBlobs) + action._SuffixName);
            action = null;

        }
        public void SetupPropertyByVariationModel()
        {
            EnableAreaFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableAreaFilter)), EHTupleStyle.None, EPropertyState.Input);
            EnableHeightFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableHeightFilter)), EHTupleStyle.None, EPropertyState.Input);
            EnableWidthFilter = new SBool(CommonData.GetPropertyDescription(nameof(EnableWidthFilter)), EHTupleStyle.None, EPropertyState.Input);
            AreaRange = new SListDouble(CommonData.GetPropertyDescription(nameof(AreaRange)), EHTupleStyle.RangeMinMax, EPropertyState.Input);
            WidthRange = new SListDouble(CommonData.GetPropertyDescription(nameof(WidthRange)), EHTupleStyle.ValueList, EPropertyState.Input);
            HeightRange = new SListDouble(CommonData.GetPropertyDescription(nameof(HeightRange)), EHTupleStyle.ValueList, EPropertyState.Input);
            RequiredNumberOfBlobs = new SListObject(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)), EHTupleStyle.ValueList, EPropertyState.Input);
            AbsThreshold = new SListDouble(CommonData.GetPropertyDescription(nameof(AbsThreshold)), EHTupleStyle.ValueList, EPropertyState.Input);
            VarThreshold = new SListDouble(CommonData.GetPropertyDescription(nameof(RequiredNumberOfBlobs)), EHTupleStyle.ValueList, EPropertyState.Input);
            VariationModelCompareMode = new SString(CommonData.GetPropertyDescription(nameof(VariationModelCompareMode)), EHTupleStyle.ValueList, EPropertyState.Input);

            ReAlignModelID = new SListDouble(CommonData.GetPropertyDescription(nameof(ReAlignModelID)), EHTupleStyle.None, EPropertyState.Input);
            AllowdErrorPercentage = new SListDouble(CommonData.GetPropertyDescription(nameof(AllowdErrorPercentage)), EHTupleStyle.ValueList, EPropertyState.Input);
            UseGlobalSetUpParams = new SBool(CommonData.GetPropertyDescription(nameof(UseGlobalSetUpParams)), EHTupleStyle.None, EPropertyState.Input);
            ColorMode = new SString(CommonData.GetPropertyDescription(nameof(ColorMode)), EHTupleStyle.ValueList, EPropertyState.Input);


            cAction action = new cAction(EActionTypes.VariationModel, EObjectTypes.Action, null, null);
            ColorMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(ColorMode) + action._SuffixName);

            EnableAreaFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(ColorMode) + action._SuffixName);
            EnableHeightFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableHeightFilter) + action._SuffixName);
            EnableWidthFilter.rtcValue = CommonData.GetDefaultValues_Bool(nameof(EnableWidthFilter) + action._SuffixName);
            AreaRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AreaRange) + action._SuffixName);
            WidthRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(WidthRange) + action._SuffixName);
            HeightRange.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(HeightRange) + action._SuffixName);
            RequiredNumberOfBlobs.rtcValue = CommonData.GetDefaultValues_ListObject(nameof(RequiredNumberOfBlobs) + action._SuffixName);
            AbsThreshold.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AbsThreshold) + action._SuffixName);
            VarThreshold.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(VarThreshold) + action._SuffixName);
            ReAlignModelID.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(ReAlignModelID) + action._SuffixName);
            AllowdErrorPercentage.rtcValue = CommonData.GetDefaultValues_ListDouble(nameof(AllowdErrorPercentage) + action._SuffixName);
            VariationModelCompareMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(VariationModelCompareMode) + action._SuffixName);
            UseGlobalSetUpParams.rtcValue = CommonData.GetDefaultValues_Bool(nameof(UseGlobalSetUpParams) + action._SuffixName);
            action = null;
        }
        public void SetupPropertyByDrawingROI()
        {
            CenterPoint = new SListDouble(CommonData.GetPropertyDescription(nameof(CenterPoint)),
                EHTupleStyle.Point,
                EPropertyState.Input);
            DrawingType = new SString(CommonData.GetPropertyDescription(nameof(DrawingType)),
                EHTupleStyle.None,
                EPropertyState.Input);
            DrawingMode = new SString(CommonData.GetPropertyDescription(nameof(DrawingMode)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ROIName = new SString(CommonData.GetPropertyDescription(nameof(ROIName)),
                EHTupleStyle.None,
                EPropertyState.Input);
            Angle = new SListDouble(CommonData.GetPropertyDescription(nameof(Angle)),
                EHTupleStyle.Real,
                EPropertyState.Input);
            Width = new SListDouble(CommonData.GetPropertyDescription(nameof(DrawingType)),
                EHTupleStyle.Real,
                EPropertyState.Input);
            Height = new SListDouble(CommonData.GetPropertyDescription(nameof(Height)),
                EHTupleStyle.None,
                EPropertyState.Input);
            ROIColor = new SString(CommonData.GetPropertyDescription(nameof(ROIColor)),
                EHTupleStyle.None,
                EPropertyState.Input);
            AlphaColor = new SString(CommonData.GetPropertyDescription(nameof(AlphaColor)),
                EHTupleStyle.None,
                EPropertyState.Input);
            cAction action = new cAction(EActionTypes.DrawingROI, EObjectTypes.Action, null, null);
            DrawingType.rtcValue = CommonData.GetDefaultValues_Text(nameof(DrawingType) + action._SuffixName);
            DrawingMode.rtcValue = CommonData.GetDefaultValues_Text(nameof(DrawingMode) + action._SuffixName);
            AlphaColor.rtcValue = CommonData.GetDefaultValues_Text(nameof(DrawingMode) + action._SuffixName);
            Width.rtcValue = new List<double> { 100};
            Height.rtcValue = new List<double> { 100 };
            CenterPoint.rtcValue = new List<double> { 0, 0 };
            ROIColor.rtcValue = cColor.DefaultColorT;


        }
        private void SetUpPropertyByActionType( EActionTypes eActionType)
        { 
            switch(eActionType)
            {
                case EActionTypes.BlobMultipleROI:
                    SetUpPropertyByBlobMultipleROI();
                    break;
                case EActionTypes.CalibrateEdgetoEdge:
                    SetupPropertyByCalibrateEdgeToEdge();
                    break;
                case EActionTypes.Origin:
                    SetupPropertyByOrigin();
                    break;
                case EActionTypes.CodeReader:
                    SetupPropertyByCodeReader();
                    break;
                case EActionTypes.ColorBlobMultipleROI:
                    SetUpPropertyByColorMultipleROI();
                    break;
                case EActionTypes.VariationModel:
                    SetupPropertyByVariationModel();
                    break;
                case EActionTypes.DrawingROI:
                    SetupPropertyByDrawingROI();
                    break;
                default:
                    break;

            }
        }
        public cROIProperty(EActionTypes _ActionType, long _ID = -1, bool _IsSelected = false)
        {
            GID = Guid.NewGuid();
            ID = _ID;
            IDLink = -1;
            Active = true;
            Selected = _IsSelected;
            ActionType = _ActionType;

            foreach (PropertyInfo item in this.GetType().GetProperties())
            {
                item.SetValue(this, null);
            }
            IDLink = -1;
            Passed = new SBool(CommonData.GetPropertyDescription(nameof(Passed)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false);
            Passed.rtcValue = false;
            RequiredPass = new SBool(CommonData.GetPropertyDescription(nameof(RequiredPass)),
                EHTupleStyle.None,
                EPropertyState.Output,
                EROILegend.None,
                false);
            RequiredPass.rtcValue = true;
            SetUpPropertyByActionType(_ActionType);
        }



        public void GetValueFromAction(cAction action)
        {
            var listProperties = this.GetType().GetProperties().Where(x => x != null && x.GetValue(this, null) != null);

            foreach(PropertyInfo item in listProperties)
            {
                var propertyInfo_Roi = (RTCVariableType)this.GetType().GetProperty(item.Name)?.GetValue(this, null);
                //var test = action.GetType().GetProperty(item.Name)?.GetValue(this, null);
                var propertyInfo_Ac = (RTCVariableType)action.GetType().GetProperty(item.Name)?.GetValue(action, null);
                if (propertyInfo_Roi == null || propertyInfo_Ac == null)
                    continue;
                propertyInfo_Roi.rtcIDRef = propertyInfo_Ac.rtcIDRef;
                propertyInfo_Roi.rtcRef = propertyInfo_Ac.rtcRef;
                propertyInfo_Roi.rtcPropNameRef = propertyInfo_Ac.rtcPropNameRef;
                propertyInfo_Roi.rtcSaveToFileConfig = propertyInfo_Ac.rtcSaveToFileConfig;

                switch(item.PropertyType.Name)
                {
                    case nameof(SBool):
                        ((SBool)propertyInfo_Roi).rtcValue = ((SBool)propertyInfo_Ac).rtcValue;
                        break;
                    case nameof(SString):
                        ((SString)propertyInfo_Roi).rtcValue = ((SString)propertyInfo_Ac).rtcValue;
                        break;
                    case nameof(SInt):
                        ((SInt)propertyInfo_Roi).rtcValue = ((SInt)propertyInfo_Ac).rtcValue;
                        break;
                    case nameof(SDouble):
                        ((SDouble)propertyInfo_Roi).rtcValue = ((SDouble)propertyInfo_Ac).rtcValue;
                        break;
                    case nameof(SListString):
                        ((SListString)propertyInfo_Roi).rtcValue = ((SListString)propertyInfo_Ac).rtcValue;
                        break;
                    //case nameof(SListDouble):
                    //    ((SListDouble)propertyInfo_Roi).rtcValue = ((SListDouble)propertyInfo_Ac).rtcValue;
                    //    break;
                    #region Quân sửa ngày 16/03
                    case nameof(SListDouble):
                        ((SListDouble)propertyInfo_Roi).rtcValue = new List<double>(((SListDouble)propertyInfo_Ac).rtcValue);
                        break;
                    #endregion
                    case nameof(SShapeList):
                        ((SShapeList)propertyInfo_Roi).rtcValue = ((SShapeList)propertyInfo_Ac).rtcValue;
                        break;
                    default:
                        break;
                }


            }
        }

        public void GetValueFromOtherRoi(cROIProperty _ROI)
        {
            var listProperties = this.GetType().GetProperties().Where(x => x != null && x.GetValue(this, null) != null);
            RTCVariableType propertyInfo_ROI = null;
            RTCVariableType propertyInfo_AC = null;

            foreach (PropertyInfo item in listProperties)
            {
                propertyInfo_ROI = (RTCVariableType)this.GetType().GetProperty(item.Name).GetValue(this, null);
                propertyInfo_AC = (RTCVariableType)_ROI.GetType().GetProperty(item.Name).GetValue(_ROI, null);
                if (propertyInfo_ROI == null || propertyInfo_AC == null)
                    return;
                propertyInfo_ROI.rtcIDRef = propertyInfo_AC.rtcIDRef;
                propertyInfo_ROI.rtcPropNameRef = propertyInfo_AC.rtcPropNameRef;
                propertyInfo_ROI.rtcRef = propertyInfo_AC.rtcRef;

                switch (item.PropertyType.Name)
                {
                    case nameof(SBool):
                        ((SBool)propertyInfo_ROI).rtcValue = ((SBool)propertyInfo_AC).rtcValue;
                        break;
                    case nameof(SString):
                        ((SString)propertyInfo_ROI).rtcValue = ((SString)propertyInfo_AC).rtcValue;
                        break;
                    case nameof(SInt):
                        ((SInt)propertyInfo_ROI).rtcValue = ((SInt)propertyInfo_AC).rtcValue;
                        break;
                    case nameof(SDouble):
                        ((SDouble)propertyInfo_ROI).rtcValue = ((SDouble)propertyInfo_AC).rtcValue;
                        break;
                    //case nameof(SListDouble):
                    //    ((SListDouble)propertyInfo_ROI).rtcValue = ((SListDouble)propertyInfo_AC).rtcValue;
                    //    break;
                    #region Quân sửa ngày 16/03
                    case nameof(SListDouble):
                        ((SListDouble)propertyInfo_ROI).rtcValue = new List<double>(((SListDouble)propertyInfo_AC).rtcValue);
                        break;
                    #endregion
                    default:
                        break;
                }
            }
        }
        public void SetValueToAction(cAction action)
        {
            try
            {
                var listProperties = this.GetType().GetProperties().Where(x => x != null && x.GetValue(this, null) != null);
                RTCVariableType propertyInfo_Roi = null;
                RTCVariableType propertyInfo_Ac = null;
                foreach (PropertyInfo item in listProperties)
                {
                    propertyInfo_Roi = (RTCVariableType)this.GetType().GetProperty(item.Name)?.GetValue(this, null);
                    //var test = action.GetType().GetProperty(item.Name)?.GetValue(action, null);
                    propertyInfo_Ac = (RTCVariableType)action.GetType().GetProperty(item.Name)?.GetValue(action, null);
                    if (propertyInfo_Roi == null || propertyInfo_Ac == null)
                        continue;
                    propertyInfo_Roi.rtcIDRef = propertyInfo_Ac.rtcIDRef;
                    propertyInfo_Roi.rtcRef = propertyInfo_Ac.rtcRef;
                    propertyInfo_Roi.rtcPropNameRef = propertyInfo_Ac.rtcPropNameRef;
                    propertyInfo_Roi.rtcSaveToFileConfig = propertyInfo_Ac.rtcSaveToFileConfig;

                    switch (item.PropertyType.Name)
                    {
                        case nameof(SBool):
                            ((SBool)propertyInfo_Ac).rtcValue = ((SBool)propertyInfo_Roi).rtcValue;
                            break;
                        case nameof(SString):
                            ((SString)propertyInfo_Ac).rtcValue = ((SString)propertyInfo_Roi).rtcValue;
                            break;
                        case nameof(SInt):
                            ((SInt)propertyInfo_Ac).rtcValue = ((SInt)propertyInfo_Roi).rtcValue;
                            break;
                        case nameof(SDouble):
                            ((SDouble)propertyInfo_Ac).rtcValue = ((SDouble)propertyInfo_Roi).rtcValue;
                            break;
                        case nameof(SListString):
                            ((SListString)propertyInfo_Ac).rtcValue = ((SListString)propertyInfo_Roi).rtcValue;
                            break;
                        //case nameof(SListDouble):
                        //    ((SListDouble)propertyInfo_Ac).rtcValue = ((SListDouble)propertyInfo_Roi).rtcValue;
                        //    break;
                        #region Quân sửa ngyaf 16/03
                        case nameof(SListDouble):
                            ((SListDouble)propertyInfo_Ac).rtcValue = new List<double>(((SListDouble)propertyInfo_Roi).rtcValue);
                            break;
                        #endregion
                        case nameof(SListObject):
                            ((SListObject)propertyInfo_Ac).rtcValue = ((SListObject)propertyInfo_Roi).rtcValue;
                            break;
                        case nameof(SShapeList):
                            ((SShapeList)propertyInfo_Ac).rtcValue = ((SShapeList)propertyInfo_Roi).rtcValue;
                            break;
                        default:
                            break;
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<object> GenValue()
        {
            switch (ActionType)
            {
                case EActionTypes.BlobMultipleROI:
                    return GenValue_BlobMultipleROI();
                case EActionTypes.CalibrateEdgetoEdge:
                    return GenValue_CalibrateEdgeToEdge();
                case EActionTypes.Origin:
                    return GenValue_Origin();
                case EActionTypes.CodeReader:
                    return GenValue_CodeReader();
                case EActionTypes.ColorBlobMultipleROI:
                    return GenValue_ColorBlobMultipleROI();
            }
            return new List<object>();
        }
        private List<object> GenValue_BlobMultipleROI()
        {
            List<object> _hValue = new List<object>();

            _hValue.Add(ID);
            _hValue.Add(DetectType.rtcValue);
            _hValue.Add(FillHoles.rtcValue.ToString().ToLower());

            _hValue.Add(GreyLevelThresholdType.rtcValue);
            _hValue.Add(ThresholdRange.rtcValue[0]);
            _hValue.Add(ThresholdRange.rtcValue[1]);

            _hValue.Add(EnableAreaFilter.rtcValue.ToString().ToLower());
            _hValue.Add(AreaRange.rtcValue[0]);
            _hValue.Add(AreaRange.rtcValue[1]);

            _hValue.Add(EnableWidthFilter.rtcValue.ToString().ToLower());
            _hValue.Add(WidthRange.rtcValue[0]);
            _hValue.Add(WidthRange.rtcValue[1]);

            _hValue.Add(EnableHeightFilter.rtcValue.ToString().ToLower());
            _hValue.Add(HeightRange.rtcValue[0]);
            _hValue.Add(HeightRange.rtcValue[1]);

            _hValue.Add(EnableOuterRadiusFilter.rtcValue.ToString().ToLower());
            _hValue.Add(OuterRadiusRange.rtcValue[0]);
            _hValue.Add(OuterRadiusRange.rtcValue[1]);

            _hValue.Add(RequiredPass.rtcValue.ToString().ToLower());
            _hValue.Add(RequiredNumberOfBlobs.rtcValue[0]);
            _hValue.Add(RequiredNumberOfBlobs.rtcValue[1]);
            return _hValue;



        }
        private List<object> GenValue_CalibrateEdgeToEdge()
        {
            List<object> _hValue = new List<object>();

            _hValue.Add(ID);
            _hValue.Add(EdgeType.rtcValue);
            _hValue.Add(EdgeTransition.rtcValue);

            _hValue.Add(SamplingPercent.rtcValue);
            _hValue.Add(EdgeDetectionThreshold.rtcValue);
            _hValue.Add(SubpixelMethod.rtcValue);
            return _hValue;



        }
        private List<object> GenValue_CodeReader()
        {
            List<object> _hValue = new List<object>();

            _hValue.Add(ID);
            _hValue.Add(DefaultOutputString.rtcValue);
            _hValue.Add(MaximumNumberOfCodeToFind.rtcValue);
            _hValue.Add(BarcodeHeightMin.rtcValue);
            _hValue.Add(RequiredPass.rtcValue);         
            return _hValue;



        }
        private List<object> GenValue_ColorBlobMultipleROI()
        {
            List<object> _hValue = new List<object>();

            _hValue.Add(ID);
            _hValue.Add(ColorSpace.rtcValue);
            _hValue.Add(FillHoles.rtcValue.ToString().ToLower());

            _hValue.Add(HueTolerance.rtcValue[0]);
            _hValue.Add(HueTolerance.rtcValue[1]);
            _hValue.Add(HueTolerance.rtcValue[2]);

            _hValue.Add(SaturationTolerance.rtcValue[0]);
            _hValue.Add(SaturationTolerance.rtcValue[1]);
            _hValue.Add(SaturationTolerance.rtcValue[2]);

            _hValue.Add(IntensityTolerance.rtcValue[0]);
            _hValue.Add(IntensityTolerance.rtcValue[1]);
            _hValue.Add(IntensityTolerance.rtcValue[2]);

            _hValue.Add(RedTolerance.rtcValue[0]);
            _hValue.Add(RedTolerance.rtcValue[1]);
            _hValue.Add(RedTolerance.rtcValue[2]);

            _hValue.Add(GreenTolerance.rtcValue[0]);
            _hValue.Add(GreenTolerance.rtcValue[1]);
            _hValue.Add(GreenTolerance.rtcValue[2]);

            _hValue.Add(BlueTolerance.rtcValue[0]);
            _hValue.Add(BlueTolerance.rtcValue[1]);
            _hValue.Add(BlueTolerance.rtcValue[2]);

            _hValue.Add(EnableAreaFilter.rtcValue.ToString().ToLower());
            _hValue.Add(AreaRange.rtcValue[0]);
            _hValue.Add(AreaRange.rtcValue[1]);

            _hValue.Add(EnableWidthFilter.rtcValue.ToString().ToLower());
            _hValue.Add(WidthRange.rtcValue[0]);
            _hValue.Add(WidthRange.rtcValue[1]);

            _hValue.Add(EnableHeightFilter.rtcValue.ToString().ToLower());
            _hValue.Add(HeightRange.rtcValue[0]);
            _hValue.Add(HeightRange.rtcValue[1]);

            _hValue.Add(EnableOuterRadiusFilter.rtcValue.ToString().ToLower());
            _hValue.Add(OuterRadiusRange.rtcValue[0]);
            _hValue.Add(OuterRadiusRange.rtcValue[1]);

            _hValue.Add(RequiredPass.rtcValue.ToString().ToLower());
            _hValue.Add(RequiredNumberOfBlobs.rtcValue[0]);
            _hValue.Add(RequiredNumberOfBlobs.rtcValue[1]);
            return _hValue;



        }
        private List<object> GenValue_Origin()
        {

            List<object> _hValue = new List<object>();
            _hValue.Add(ID);
            _hValue.Add(EdgeType.rtcValue);
            _hValue.Add(EdgeTransition.rtcValue);
            _hValue.Add(SamplingPercent.rtcValue);
            _hValue.Add(EdgeDetectionThreshold.rtcValue);
            _hValue.Add(SubpixelMethod.rtcValue);
            _hValue.Add(ROILegend.rtcValue);
            _hValue.Add(MinEdgePointNumber.rtcValue);
            _hValue.AddRange(DeFaultOrigin.rtcValue.Cast<object>().ToList());
            _hValue.Add(OutlierDistanceThreshold.rtcValue);
            _hValue.Add(RequiredPass.rtcValue.ToString().ToLower());
            return _hValue;



        }



    }

    #region ROI PROPERTY FUNCTIONS IN ACTION
    public partial class cAction
    {
        public void SetActionValueToROIPropertiesSelected()
        {
            if (IsMultiROI && ROIProperties != null && ROIProperties.Count() > 0)
            {
                foreach (cROIProperty ROI in ROIProperties.Values)
                    if(ROI.Selected)
                    {
                        ROI.GetValueFromAction(this);
                        UpdateROIPropertieValueToOtherROILinked(ROI);
                        if(this.ActionType == EActionTypes.DrawingROI && 
                            !this.MyGroup.RunSimple)
                        {
                            // Cập nhật thông tin kích thước nếu có thay đổi vào cho vùng roi
                            bool isChange = false;
                            cDrawingBaseType drawingBaseType = (cDrawingBaseType)ROIs[ROI.ID];
                            if (drawingBaseType.Center.Row != ROI.CenterPoint.rtcValue[0] || drawingBaseType.Center.Col != ROI.CenterPoint.rtcValue[1])
                            {
                                drawingBaseType.Center.Row = ROI.CenterPoint.rtcValue[0];
                                drawingBaseType.Center.Col = ROI.CenterPoint.rtcValue[1];
                                isChange = true;
                            }    
                            if (drawingBaseType.Name != ROI.ROIName.rtcValue)
                            {
                                drawingBaseType.Name = ROI.ROIName.rtcValue;
                                isChange = true;
                            }    
                            switch (drawingBaseType.DrawingType)
                            {
                                case EDrawingtypes.Rectang:
                                    {
                                        cRectangType rectangType = (cRectangType)drawingBaseType;
                                        if (rectangType.Width != ROI.Width.rtcValue[0])
                                        {
                                            rectangType.Width = ROI.Width.rtcValue[0];
                                            isChange = true;
                                        }
                                        if (rectangType.Height != ROI.Height.rtcValue[0])
                                        {
                                            rectangType.Height = ROI.Height.rtcValue[0];
                                            isChange = true;
                                        }
                                        break;
                                    }
                                case EDrawingtypes.Rectang1:
                                    {
                                        cRectangType rectangType = (cRectangType)drawingBaseType;
                                        if (rectangType.Width != ROI.Width.rtcValue[0])
                                        {
                                            rectangType.Width = ROI.Width.rtcValue[0];
                                            isChange = true;
                                        }
                                        if (rectangType.Height != ROI.Height.rtcValue[0])
                                        {
                                            rectangType.Height = ROI.Height.rtcValue[0];
                                            isChange = true;
                                        }
                                        break;
                                    }
                                case EDrawingtypes.Ellipse:
                                    {
                                        cEllipseType rectangType = (cEllipseType)drawingBaseType;
                                        if (rectangType.Radius1 != ROI.Width.rtcValue[0])
                                        {
                                            rectangType.Radius1 = ROI.Width.rtcValue[0];
                                            isChange = true;
                                        }
                                        if (rectangType.Radius2 != ROI.Height.rtcValue[0])
                                        {
                                            rectangType.Radius2 = ROI.Height.rtcValue[0];
                                            isChange = true;
                                        }
                                        break;
                                    }
                                case EDrawingtypes.Line:
                                    break;
                                case EDrawingtypes.Polygon:
                                    break;
                                case EDrawingtypes.none:
                                    break;
                            }    
                            

                        }
                    }
            }
        }
        public cROIProperty GetROIPropertiesSelected()
        {
            if (IsMultiROI && ROIProperties != null)
            {
                foreach (cROIProperty ROI in ROIProperties.Values)
                    if (ROI.Selected)
                        return ROI;
            }
            return null;
        }
        public void SetROIPropertiesSelectedValueToAction(long _ID)
        {
            if (IsMultiROI && ROIProperties != null && ROIProperties.ContainsKey(_ID))
            {
                cROIProperty ROI = ROIProperties[_ID];
                ROI.SetValueToAction(this);
            }
        }
        public void SetActionValueToROIPropertiesSelected(cROIProperty _ROI)
        {
            if (IsMultiROI && _ROI != null && ROIProperties != null && ROIProperties.ContainsKey(_ROI.ID))
            {
                _ROI.GetValueFromAction(this);
                UpdateROIPropertieValueToOtherROILinked(_ROI);
            }    
        }

        private void UpdateROIPropertieValueToOtherROILinked(cROIProperty _ROI)
        {
            var ROILinks = ROIProperties.Values.Where(x => x.IDLink == _ROI.ID).ToList();
            if (ROILinks != null && ROILinks.Count() > 0)
                for (int i = 0; i < ROILinks.Count(); i++)
                {
                    CopyROIProperties(_ROI, ROILinks[i]);
                    UpdateROIPropertieValueToOtherROILinked(ROILinks[i]);
                }
        }
        /// <summary>
        /// Copies the roi properties
        /// </summary>
        /// <param name="_ROISrc">The roi source</param>
        /// <param name="_ROIDes">Infomation describing the roi</param>
        public void CopyROIProperties(cROIProperty _ROISrc, cROIProperty _ROIDes)
        {
            if (!IsMultiROI || ROIProperties == null || ROIProperties.Count() == 0) return;
            cROIProperty crpTemp;
                
            if(_ROIDes != null)
            {
                //_ROIDes.GetValueFromOtherRoi(crpTemp);
                ROIProperties[_ROIDes.ID] = _ROIDes;
            }
        }
        /// <summary>
        /// Copy the roi properties.
        /// </summary>
        /// <param name="_IDSrc">       The identitysource.     /param>
        /// <param name="_IDDes">       Information Describing the identifier.      </param>
        public void CopyROIProperties(long _IDSrc, long _IDDes)
        {
            if (!IsMultiROI || ROIProperties == null || !ROIProperties.Any()) return;
            ROIProperties.TryGetValue(_IDSrc, out cROIProperty crpSrc);
            ROIProperties.TryGetValue(_IDDes, out cROIProperty crpDes);

            cROIProperty crpTemp = DeepCopyData.Clone_ROIProperties(crpSrc);
            if (/*crpTemp != null*/ crpDes != null)
            {
                crpDes.GetValueFromOtherRoi(crpTemp);
                ROIProperties[crpDes.ID] = crpDes;
            }
        }
        public void SetLinkROIProperties(long _IDSrc, long _IDDes)
        {
            if (!IsMultiROI || ROIProperties == null || ROIProperties.Count() == 0) return;
            ROIProperties.TryGetValue(_IDSrc, out cROIProperty crpSrc);
            ROIProperties.TryGetValue(_IDDes, out cROIProperty crpDes);
            crpDes.IDLink = crpSrc.ID;
        }
        public void AddROIProperties(long _ID, bool _IsSelected = false)
        {
            if (!IsMultiROI) return;
            if (_IsSelected)
                foreach (cROIProperty roiProperty in ROIProperties.Values)
                    roiProperty.Selected = false;

            cROIProperty crp = new cROIProperty(ActionType, _ID, _IsSelected);
            if (ROIProperties.Count <= 0)
                crp.Selected = true;
            ROIProperties.Add(_ID, crp);
        }

        public void EnableOrDisableTabRoiByActionType()
        {
            ((ucBaseActionDetail)this.ViewInfo).ScrollableROI.Enabled = true;
            if (this.IsMultiROI && (this.ROIProperties == null || this.ROIProperties.Count <= 0))
                ((ucBaseActionDetail)this.ViewInfo).ScrollableROI.Enabled = false;
        }

       


        //private List<object> GenValue_CalibrateEdgeToEdge()
        //{
        //    List<object> _hValue = new List<object>();
        //    _hValue.Add(ID);
        //    _hValue.Add(Edge)
        //}


    }

}
#endregion
