using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCEnums
{
    public enum ESaveMode
    {
        ProjectSettings = 0,
        OneCam = 1,
        AllCam = 2,
        Project = 99
    }
    public enum EImageSourceTypes
    {
        Computer = 0,
        Camera = 1,
        None = 999
    }

    public enum ETriggerType
    {
        Sync = 0,
        ASync = 1
    }

    public enum ETriggerMode
    {
        None = 0,
        IO = 1,
        TCPIP = 2,
        COM = 3,
        PLCMitsu = 4
    }

    public enum EPLCReadType
    {
        COM = 0,
        Ethernet = 1,
        Modbus = 2
    }
    public enum ETermiator
    {
        None,
        CarriageReturn,
        LineFeed,
        CarriageReturnAndLineFeed
    }
    public enum EDecimalSeparator
    {
        Dot,
        Comma
    }

    public enum EGroupTypes
    {
        Locating = 0,
        FeatureFinding = 1,
        Filtering = 2,
        Identification = 3,
        GeomertryTransform = 4,
        Measurement = 5,
        VisionDeviceControl = 6,
        Drawing = 7,
        Communication = 8,
        Logic = 9,
        Files = 10,
        System = 11,
        None = 9999

    }
    public enum EActionTypes
    {
        MainAction = 0,
        Pattern = 1,
        Blob = 2,
        PixelCount = 3,
        Brightness = 4,
        AffineImage = 5,
        BlobMultipleROI = 6,
        RegionProcessing = 7,
        LineFind = 8,
        ImageFilter = 9,
        BlobFilter = 10,
        DistanceMeasurement = 11,
        Math = 12,
        StringBuilder = 13,
        CalibrateEdgetoEdge = 14,
        ColorBlob = 15,
        Branch = 16,
        BranchItem = 17,
        OCR = 18,
        CodeReader = 19,
        Alignment = 20,
        HandEye = 21,
        Count = 22,
        DataInstance = 23,
        DataArchive = 24,
        SLMPRead = 25,
        SLMPWrite = 26,
        DataArchiveRead = 27,
        SnapImage = 28,
        ResetTool = 29,
        Switch = 30,
        CalibrationCheckBoard = 31,
        PoseManipulation = 32,
        ImageArchive = 33,
        Origin = 34,
        SaveImage = 35,
        DeformablePattern = 36,
        ImageMath = 37,
        ModBusRead = 38,
        ModBusWrite = 39,
        RunProgram = 40,
        StopProgram = 41,
        LinkValue = 42,
        CounterLoop = 43,
        Wait = 44,
        ImageSplit = 45,
        TCPIPRead = 46,
        TCPIPWrite = 47,
        MXComponentRead = 48,
        MXComponentWrite = 49,
        SendMessage = 50,
        DataSet = 51,
        ChangeJob = 52,
        LiveCam = 53,
        StopLiveCam = 54,
        Return = 55,
        ColorBlobMultipleROI = 56,
        RunDLL = 57,
        ManualAlignment = 58,
        COMReader = 59, 
        COMWriter =60,
        CSTLightRead = 61,
        CSTLightWrite = 62,
        CycleTimeStart = 63,
        CycleTimeStop = 64,
        VariationModel = 65,
        DialogMessage = 66,
        FTPUpload = 67,
        FTPDownload = 68,
        Stop = 69,
        ViewResult = 70,
        DetectFileStatus = 71,
        LoadImage = 72,
        ViewText = 73,
        DrawingROI = 74,
        CorrelationPattern = 75,
        CameraSettings = 76,
        SaveProject = 77,
        OpticalFlowImage = 78,
        SystemInfo = 79,
        RunCommand = 80,
        IOControllerRead = 81,
        IOControllerWrite = 82,
        ClearWindows = 83,
        WindownSettings = 84,
        CustomProcedure = 85,
        SaveObject = 86,
        LoadObject = 87,
        Metrology = 88,
        HookKeyboard= 89,
        SaveConfig = 90,
        LoadConfig = 91,
        GaugeDualROI = 92,
        CsvRead = 93,
        CsvWrite = 94,
        ExcelRead = 95,
        ExcelWrite = 96,
        OkNgCounter = 98,
        CameraIOReader = 99,
        UpdRead = 100,
        UpdWrite = 101,
        PhotometricStereo = 102,
        VSTLightRead = 103,
        VSTLightWrite = 104,
        Script = 105,
        MitsuSLMPWrite = 106,
        EasyHandEye = 107,
        EasyAlign = 108,
        APIRead = 109,
        APIWrite = 110,
        Ping = 111,
        CCLinkIEReader = 112,
        CCLinkIEWriter = 113,
        AdlinkIOReader = 114,
        AdlinkIOWriter = 115,
        POCIORead = 116,
        POCIOWrite = 117,
        UdpWrite = 118,
        UdpRead = 119,
        RunDeep = 9997,
        PassFail = 9998,
        None = 9999
    }

    public enum EObjectTypes
    {
        Group = 0,
        Action = 1,
        Pass = 2
    }

    public enum ETupleStyle
    {
        RangeMinMax = 0,
        RangeMinMaxLimit = 1,
        PointList = 2,
        Rectangle = 3,
        Origin = 4,
        RectangleList = 11,
        Boolean = 13,
        BooleanList = 13,
        Integer = 15,
        IntegerList = 16,
        String = 17,
        StringList = 18,
        DateAndTime = 19,
        Real = 20,
        RealList = 21,
        None = 9999
    }

    public enum EPropertyState
    {
        Input = 0,
        Output = 1,
        Operand = 2,
        DataItemParent = 3,
        DataItemParentView = 4,
        DataItem = 5,
        DataItemView = 6,
        None = 9999
    }

    public enum EROILegend
    {
        OriginRelativeToRWC = 0,
        PrimaryRoi = 1,
        SecondaryROI = 2,
        PerpendicilarROI = 3,
        PrimaryPointFound = 4,
        SecondPoinFound = 5,
        PerpendicularPointFound = 6,
        ToolOrigin = 7,
        FoundBlobs = 8,
        SearchROI = 9,
        OutputOriginRelativeToRCW = 10,
        PrimaryStepROI = 11,
        PrimaryStepROIMaster = 12,
        SecondaryStepROI = 13,
        SecondaryStepROIMaster = 14,
        None = 9999
    }

    public enum EBuildMode
    {
        Demo = 0,
        Project = 1,
        RTCVision = 2
    }

    public enum ERunActionMode
    {
        All = 0,
        Prev = 1,
        Next = 2,
        Current = 3,
        Endless = 4,
        CurentAction = 5,
        FileName = 6
    }
    public enum EHTupleStyle
    {   
        /// <summary>
        /// [Min,Max]
        /// </summary>
        RangeMinMax = 0,

        /// <summary>
        /// LimitMinValue, LimitMaxValue, MinValue, MaxValue
        /// </summary>
        RangeMinMaxLimit =1,

        /// <summary>
        /// [X1, Y1, X2, Y2, X3, Y3] - [Toạ độ các điểm theo từng cặp giá trị]
        /// </summary>
        PointList = 2,

        /// <summary>
        /// X,Y, Phi, lÈNTH1, LENGTH2] - [TOẠ ĐỘ TÂM, GÓC, ĐỘ DÀI(1/2) CẠNH DÀI VÀ NGẮN]
        /// </summary>
        Rectangle = 3,

        /// <summary>
        /// [X,Y, PHI] - [TOẠ ĐỘ TÂM, GÓC QUAY]
        /// </summary>
        Origin = 4,


        /// <summary>
        ///[X1,Y1,X2,Y2] - TOẠ ĐỘ 2 ĐIỂM ĐẦU CUỐI CỦA LINE
        /// </summary>
        Line = 5,

        /// <summary>
        /// ['STRING1', ' STRING2', 'STRING3' ...] - [MẢNG CÁC STRING]
        /// </summary>
        StringRange = 6,

        /// <summary>
        /// [10,20,30] - [MẢNG CÁC PHẦN TỬ]
        /// </summary>
        ValueList = 7,

        /// <summary>
        /// [MISNUS, NOMINAL, PLUS] - [NGƯỠNG VÀ SAI SỐ]
        /// </summary>
        Tolerance = 8,

        /// <summary>
        /// [REGION1, REGION2 ....] - MẢNG CÁC REGION
        /// </summary>
        Regions = 9,

        OriginList = 10,

        RectangleList = 11,

        Point = 12,

        Boolean = 13,

        BooleanList = 14,

        Integer = 15,

        IntegerList = 16,

        String = 17,

        StringList =18,

        DateAndTime = 19,

        Real = 20,

        RealList =21,

        Pose = 22,

        PoseList = 23,

        Long =24,

        Double = 25,

        DoubleList = 26,

        Object = 27,

        None = 9999
    }
    public enum EVarType
    {
        None = 0,
        Input = 1,
        Output = 2
    }

    class EnumActions
    {
    }
}
