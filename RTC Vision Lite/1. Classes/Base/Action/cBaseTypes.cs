using BrightIdeasSoftware;
using CommonTools;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.Util;
using RTC_Vision_Lite.Commons;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace RTC_Vision_Lite.Classes
{
    public class RTCVariableType
    {
        public bool rtcActive { get; set; }
        public bool rtc { get; set; }
        public bool rtcIsHotLink { get; set; }
        public bool rtcSystem { get; set; }
        public bool rtcRunWhenChange { get; set; }
        public bool rtcReadOnly { get; set; }
        public bool rtcSaveToFile { get; set; }
        public bool rtcHidden { get; set; }
        public bool rtcIsCanReset { get; set; }
        public bool rtcIsReBinding { get; set; }
        public bool rtcIsCanLink { get; set; }
        public bool rtcDisplay { get; set; }
        public bool rtcDisplayValueInHistory { get; set; }
        public bool rtcDisplayOrigin { get; set; }
        public string rtcValueS { get; set; }
        public string rtcValueView { get; set; }
        public string rtcValueViewFull { get; set; }
        public string rtcDescription { get; set; }
        public Guid rtcIDRef { get; set; }
        public string rtcPropNameRef { get; set; }
        public string rtcRef { get; set; }
        public string rtcRefIndex { get; set; }
        public bool rtcIsParent { get; set; }
        public bool rtcResetWhenStart { get; set; }
        public bool rtcResetWhenStop { get; set; }
        public bool rtcIsSaveLog { get; set; }
        public bool rtcIsHighLight { get; set; }
        public bool rtcSaveToFileConfig { get; set; }
        public bool rtcClearWhenRun { get; set; }
        public bool rtcIsSetValueByOtherTool { get; set; }
        public bool rtcIsAutoCreateDataItems { get; set; }
        public string rtcDisplayText { get; set; }
        public EPropertyState rtcState { get; set; }
        public string rtcColor { get; set; }
        public List<Guid> ParentIDResets { get; set; }
        public Bitmap rtcBitmap { get; set; }

        
        public EROILegend rtcRoiLegend { get; set; }
        public ETupleStyle TupleStyle { get; set; }
        public EHTupleStyle ValueStyle { get; set; }
        public List<SStringBuilderItem> DataItems;
        public RTCVariableType()
        {
            rtcActive = false;
            rtcIsParent = false;
            rtcSystem = false;
            rtcReadOnly = false;
            rtcHidden = false;
            rtcIsSaveLog = false;
            rtcClearWhenRun = false;
            rtcResetWhenStart = false;
            rtcResetWhenStop = false;
            rtcDisplay = false;
            rtcDisplayValueInHistory = false;
            rtcDisplayOrigin = false;
            rtcSaveToFile = false;
            rtcSaveToFileConfig = false;
            rtcIsCanReset = false;
            rtcIsReBinding = false;
            rtcIsIconic = false;
            rtcIsAutoCreateDataItems = false;
            rtcRunWhenChange = true;
            rtcIsCanLink = true;
            rtcIsHighLight = false;
            rtcIsSetValueByOtherTool = false;
            rtcColor = "";
            rtcIDRef = Guid.Empty;
            rtcRef = string.Empty;
            rtcRefIndex = string.Empty;
            rtcPropNameRef = string.Empty;
            rtcDescription = string.Empty;
            rtcValueS = string.Empty;
            rtcValueView = string.Empty;
            rtcValueViewFull = string.Empty;
            rtcDisplayText = string.Empty;
            rtcState = EPropertyState.None;
            rtcRoiLegend = EROILegend.None;
            ValueStyle = EHTupleStyle.None;
            DataItems = null;
            ParentIDResets = null;
        }
        public bool rtcIsIconic { get; set; }
    }

    public class SBool : RTCVariableType
    {
        private bool _rtcValue;

        public bool rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                rtcValueS = _rtcValue.ToString();
                rtcValueView = _rtcValue.ToString();
                rtcValueViewFull = rtcDescription + " = " + _rtcValue.ToString();
            }
        }

        public SBool(String description,
            EHTupleStyle hTupleStyle = EHTupleStyle.None,
            EPropertyState propertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool readOnly = false,
            bool hidden = false,
            bool display = false,
            bool saveToFile = false,
            bool isCanReset = false)
        {
            rtcDescription = description;
            rtcValue = false;
            rtcState = propertyState;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
            rtcIsCanReset = isCanReset;
        }
    }
   
    public class SListObject : RTCVariableType
    {
        private List<object> _rtcValue;
        public List<object> rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                rtcValueS = string.Empty;
                rtcValueView = string.Empty;
                rtcValueViewFull = rtcDescription + " = " + _rtcValue?.ToString();
                switch (ValueStyle)
                {
                    case EHTupleStyle.ValueList:
                        GenValueView_ValueList();
                        break;
                    case EHTupleStyle.RangeMinMax:
                        GenVaLueView_RangeMinMax();
                        break;
                    default:
                        break;
                        
                }


            }
        }
        public SListObject(EHTupleStyle _HTupleStyle = EHTupleStyle.None)
        {
            ValueStyle = _HTupleStyle;
            rtcValue = new List<object>();
            rtcActive = true;
        }
        public SListObject(String description,
       EHTupleStyle hTupleStyle = EHTupleStyle.None,
       EPropertyState propertyState = EPropertyState.None,
       EROILegend roiLegend = EROILegend.None,
       bool readOnly = false,
       bool hidden = false,
       bool display = false,
       bool saveToFile = false)
        {
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            rtcDescription = description;
            rtcState = propertyState;
            rtcValue = new List<object> { };
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
        private void GenValueView_ValueList()
        {
            if (_rtcValue == null)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;
            }
            else
            {

                for (int i = 0; i < _rtcValue.Count; i++)
                {
                    string s = GlobFuncs.Ve2Str(_rtcValue[i], false, false,
                 GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    rtcValueView = string.IsNullOrEmpty(rtcValueView) ? s : $"{rtcValueView}, {s}";
                }

                rtcValueS = rtcValueView;
                rtcValueView = string.IsNullOrEmpty(rtcValueView) ? "0 Items" :
                    _rtcValue.Count.ToString() + " Item [" + rtcValueView + "]";
            }

            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        private void GenVaLueView_RangeMinMax()
        {
            if (_rtcValue != null && _rtcValue.Count >= 2)
            {
                rtcValueView = _rtcValue == null ? string.Empty :
                    "[" + GlobFuncs.Ve2Str(_rtcValue[0]) + "," + GlobFuncs.Ve2Str(_rtcValue[1]) + "]";
                rtcValueViewFull = _rtcValue == null ? rtcDescription : rtcDescription + " = " + rtcValueView;
                rtcValueViewFull = _rtcValue == null ? rtcDescription : rtcDescription + " = " + rtcValueView;
            }
        }
   
    }
    public class SDateTime : RTCVariableType
    {
        public DateTime rtcValue { get; set; }
        public SDateTime(String description,
            EHTupleStyle hTupleStyle = EHTupleStyle.None,
            EPropertyState propertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool readOnly = false,
            bool hidden = false,
            bool display = false,
            bool saveToFile = false,
            bool isCanReset = false)
        {
            rtcDescription = description;
            rtcValue = DateTime.Now;
            rtcState = propertyState;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
            rtcIsCanReset = isCanReset;
        }
    }    
    public class SString : RTCVariableType
    {
        private string _rtcValue;

        public string rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                rtcValueS = _rtcValue;
                rtcValueView = _rtcValue;
                rtcValueViewFull = _rtcValue.Trim() != "" ? rtcDescription + " = '" + _rtcValue + "'" : rtcDescription;
            }
        }
        public SString(String description,
            EHTupleStyle hTupleStyle = EHTupleStyle.None,
            EPropertyState propertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool readOnly = false,
            bool hidden = false,
            bool display = false,
            bool saveToFile = false)
        {
            rtcState = propertyState;
            rtcDescription = description;
            rtcValue = string.Empty;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }

    }
    public class SInt : RTCVariableType
    {
        private int _rtcValue;
        public int rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                rtcValueView = _rtcValue.ToString();
                rtcValueViewFull = rtcDescription + " = " + _rtcValue.ToString();
                if (rtcValueView == string.Empty)
                    rtcValueView = " ";
            }
        }
        public SInt(String _Description, EHTupleStyle _HTupleStyle = EHTupleStyle.None,
            EPropertyState _PropertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool _ReadOnly = false,
            bool _Hidden = false,
            bool _Display = false,
            bool _SaveToFile = false,
            bool _IsCanReset = false)
        {
            rtcRoiLegend = roiLegend;
            rtcDescription = _Description;
            rtcValue = -1;
            rtcState = _PropertyState;
            rtcActive = true;
            rtcReadOnly = _ReadOnly;
            rtcHidden = _Hidden;
            rtcDisplay = _Display;
            rtcDisplayOrigin = _Display;
            rtcSaveToFile = _SaveToFile;
            rtcIsCanReset = _IsCanReset;
        }
    }
    public class SLong : RTCVariableType
    {
        private long _rtcValue;
        public long rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                rtcValueView = _rtcValue.ToString();
                rtcValueViewFull = rtcDescription + " = " + _rtcValue.ToString();
            }
        }
        public SLong(String _Description, EHTupleStyle _HTupleStyle = EHTupleStyle.None,
            EPropertyState _PropertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool _ReadOnly = false,
            bool _Hidden = false,
            bool _Display = false,
            bool _SaveToFile = false,
            bool _IsCanReset = false)
        {
            if (!Enum.IsDefined(typeof(EPropertyState), _PropertyState))
                throw new InvalidEnumArgumentException(nameof(_PropertyState), (int)_PropertyState,
                    typeof(EPropertyState));

            rtcDescription = _Description;
            rtcValue = -1;
            rtcState = _PropertyState;
            rtcActive = true;
            rtcReadOnly = _ReadOnly;
            rtcHidden = _Hidden;
            rtcDisplay = _Display;
            rtcDisplayOrigin = _Display;
            rtcSaveToFile = _SaveToFile;
            rtcIsCanReset = _IsCanReset;
        }
    }

    public class SDouble : RTCVariableType
    {
        private double _rtcValue;
        public double rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                rtcValueView = Math.Round(_rtcValue, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound).ToString();
                rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            }
        }
        public SDouble(String description, EHTupleStyle hTupleStyle = EHTupleStyle.None,
        EPropertyState propertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
             bool readOnly = false,
            bool hidden = false,
            bool display = false,
            bool saveToFile = false,
            bool isCanReset = false)
        {
            rtcDescription = description;
            rtcValue = -1;
            rtcState = propertyState;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
            rtcIsCanReset = isCanReset;
        }
    }
    public class SGrayImage : RTCVariableType
    {
   
        private Image<Gray, byte> _rtcValue;
        public Image<Gray, byte> rtcValue
        {
            get => _rtcValue;
            set
            {
                ///_rtcValue.Save("D\\1.bmp");
               // bool Result = _rtcValue.Equals(value);
                _rtcValue = value;
                if (value != null)
                {

                    int count = value.NumberOfChannels;
                    if (count == -1)
                    {
                        rtcValueS = "0 Items";
                        rtcValueView = "0 Items";
                    }
                    else
                    {
                        rtcValueS = $"{count} Items";
                        rtcValueView = $"{count} items";
                    }
                }
                else
                {
                    rtcValueS = "0 Items";
                    rtcValueView = "0 Items";
                }
                rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            }
        }
      


        public SGrayImage(String description,
            EHTupleStyle hTupleStyle = EHTupleStyle.None,
            EPropertyState propertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool readOnly = false,
            bool hidden = false,
            bool display = false,
            bool saveToFile = false,
            bool _IsCanReset = false)
        {
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            rtcDescription = description;
            rtcIsIconic = true;
            rtcValue = null;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
        public void Dispose()
        {
            try
            {
                if (_rtcValue != null)
                {
                    _rtcValue.Dispose();
                    _rtcValue = null;
                }
                _rtcValue = null;
            }
            catch
            {
                _rtcValue = null;

            }
        }
    }
    public class SBgrImage : RTCVariableType
    {

        private Image<Bgr, byte> _rtcValue;
        public Image<Bgr, byte> rtcValue
        {
            get => _rtcValue;
            set
            {
                ///_rtcValue.Save("D\\1.bmp");
               // bool Result = _rtcValue.Equals(value);
                _rtcValue = value;
                if (value != null)
                {

                    int count = value.NumberOfChannels;
                    if (count == -1)
                    {
                        rtcValueS = "0 Items";
                        rtcValueView = "0 Items";
                    }
                    else
                    {
                        rtcValueS = $"{count} Items";
                        rtcValueView = $"{count} items";
                    }
                }
                else
                {
                    rtcValueS = "0 Items";
                    rtcValueView = "0 Items";
                }
                rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            }
        }



        public SBgrImage(String description,
            EHTupleStyle hTupleStyle = EHTupleStyle.None,
            EPropertyState propertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool readOnly = false,
            bool hidden = false,
            bool display = false,
            bool saveToFile = false,
            bool _IsCanReset = false)
        {
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            rtcDescription = description;
            rtcIsIconic = true;
            rtcValue = null;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
        public void Dispose()
        {
            try
            {
                if (_rtcValue != null)
                {
                    _rtcValue.Dispose();
                    _rtcValue = null;
                }
                _rtcValue = null;
            }
            catch
            {
                _rtcValue = null;

            }
        }
    }

    public class SImage : RTCVariableType
    {
   

        private Image _rtcValue;
        public Image rtcValue
        {
            get => _rtcValue;
            set
            {
                ///_rtcValue.Save("D\\1.bmp");
               // bool Result = _rtcValue.Equals(value);
                _rtcValue = value;
                if (value != null)
                {
                    using (Bitmap bmp = (Bitmap)value.Clone())
                    {
                        int count = bmp.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                        if (count == -1)
                      //  if (count >= 0)
                        {
                            rtcValueS = "0 Items";
                            rtcValueView = "0 Items";
                        }
                        else
                        {
                            rtcValueS = $"{count} Items";
                            rtcValueView = $"{count} items";
                        }
                    }
                }
                else
                {
                    rtcValueS = "0 Items";
                    rtcValueView = "0 Items";
                }
                rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            }
        }
        

        public SImage(String description,
            EHTupleStyle hTupleStyle = EHTupleStyle.None,
            EPropertyState propertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool readOnly = false,
            bool hidden = false,
            bool display = false,
            bool saveToFile = false,
            bool _IsCanReset = false)
        {
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            rtcDescription = description;
            rtcIsIconic = true;
            rtcValue = null;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
        public void Dispose()
        {
            try
            {
                if (_rtcValue != null)
                {
                    _rtcValue.Dispose();
                    _rtcValue = null;
                }
                _rtcValue = null;
            }
            catch
            {
                _rtcValue = null;

            }
        }    
    }


    public class SListImage : RTCVariableType
    {

        private List<Image> _rtcValue;

        public List<Image> rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                if (value != null)
                {
                    int count = value.Count();
                    if (count == -1)
                    {
                        rtcValueS = "0 Items";
                        rtcValueView = "0 Items";
                    }
                    else
                    {
                        rtcValueS = $"{count} Items";
                        rtcValueView = $"{count} items";
                    }

                }
                else
                {
                    rtcValueS = "0 Items";
                    rtcValueView = "0 Items";
                }
                rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            }
        }

        public SListImage(String description,
            EHTupleStyle hTupleStyle = EHTupleStyle.None,
            EPropertyState propertyState = EPropertyState.None,
            EROILegend roiLegend = EROILegend.None,
            bool readOnly = false,
            bool hidden = false,
            bool display = false,
            bool saveToFile = false,
            bool _IsCanReset = false)
        {
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            rtcDescription = description;
            rtcIsIconic = true;
            rtcValue = null;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
        //public void Dispose()
        //{
        //    try
        //    {
        //        if (_rtcValue != null)
        //        {
        //            _rtcValue.Dispose();
        //            _rtcValue = null;
        //        }
        //        _rtcValue = null;
        //    }
        //    catch
        //    {
        //        _rtcValue = null;

        //    }
        //}
    }
    public class SElementDelimiter
    {
        public EDelimiterTypes DelimiterTypes { get; set; }
        public EDelimiter StandardValue { get; set; }
        public string CustomValue { get; set; }
        public SElementDelimiter()
        {
            DelimiterTypes = EDelimiterTypes.Standard;
            StandardValue = EDelimiter.Comma;
            CustomValue = string.Empty;
        }
    }

    public class SStringBuilderItem
    {
        public MyPropertiesItem Node { get; set; } // not sure!
        public OLVColumn ColValue { get; set; } // not sure!
        public int OrderNum { get; set; }
        public string Name { get; set; }
        public Guid RefID { get; set; }
        public string RefPropName { get; set; }

        public string Ref { get; set; }
        public string RefIndex { get; set; }
        public bool IsParent { get; set; }
        public bool IscanReset { get; set; }
        public bool IsHightLight { get; set; }
        public List<Guid> ParentIDResets { get; set; }
        public bool IsDataItem { get; set; }
        public string ErrMessage { get; set; }

        public List<SStringBuilderItem> DataItems;
        private List<String> _lsValue;
        public List<String> lsValue
        {
            get => _lsValue;
            set
            {
                DataItems = new List<SStringBuilderItem>();
                _lsValue = value;
                ValueView = string.Empty;
                ValueViewFull = string.Empty;

                switch(ValueStyle)
                {
                    case EHTupleStyle.DateAndTime:
                        GenValueView_DateAndTime();
                        break;
                    case EHTupleStyle.Boolean:
                        GenValueView_Boolean();
                        break;
                    case EHTupleStyle.BooleanList:
                        GenValueView_BooleanList();
                        break;
                    case EHTupleStyle.String:
                        GenValueView_String();
                        break;
                    case EHTupleStyle.StringList:
                        GenValueView_StringList();
                        break;
                    default:
                        GenValueView_Default();
                        break;
                }
            }
        }

        public EVarType VarType;
        public string ValueView { get; set; }
        public string ValueViewFull { get; set; }

        private EHTupleStyle _ValueStyle;

        public EHTupleStyle ValueStyle
        {
            get => _ValueStyle;
            set
            {
                _ValueStyle = value;
                RefID = Guid.Empty;
                RefPropName = string.Empty;
                switch (_ValueStyle)
                {
                    case EHTupleStyle.PointList:
                        ListDoubleValue = new List<double> { };
                        break;
                    case EHTupleStyle.Rectangle:
                        ListDoubleValue = new List<double> { 0, 0, 0, 0 };
                        break;
                    case EHTupleStyle.Origin:
                        ListDoubleValue = new List<double> { 0, 0, 0 };
                        break;
                    case EHTupleStyle.OriginList:
                        ListDoubleValue = new List<double> { };
                        break;
                    case EHTupleStyle.RectangleList:
                        ListDoubleValue = new List<double> { };
                        break;
                    case EHTupleStyle.Point:
                        ListDoubleValue = new List<double> { 0, 0 };
                        break;
                    case EHTupleStyle.Boolean:
                        ListStringValue = new List<string> { "False" };
                        break;
                    case EHTupleStyle.BooleanList:
                        ListStringValue = new List<string> { };
                        break;
                    case EHTupleStyle.Integer:
                        ListDoubleValue = new List<double> { 0 };
                        break;
                    case EHTupleStyle.IntegerList:
                        ListDoubleValue = new List<double> {  };
                        break;
                    case EHTupleStyle.String:
                        ListStringValue = new List<string> { };
                        break;
                    case EHTupleStyle.StringList:
                        ListStringValue = new List<string> {"0"};
                        break;
                    case EHTupleStyle.DateAndTime:
                        ListStringValue = new List<string> { DateTime.Now.ToString() };
                        break;
                    case EHTupleStyle.Real:
                        ListDoubleValue = new List<double> { 0 };
                        break;
                    case EHTupleStyle.RealList:
                        ListDoubleValue = new List<double> { 0 };
                        break;
                }
            }
        }
        public string Leading { get; set; }
        public string Tralling { get; set; }

        //public object Value { get; internal set; }

        private List<double> _ListDoubleValue;
        public List<double> ListDoubleValue
        {
            get => _ListDoubleValue;
            set
            {
                DataItems = new List<SStringBuilderItem>();
                _ListDoubleValue = value;
                ValueView = string.Empty;
                ValueViewFull = string.Empty;
                switch (ValueStyle)
                {
                    case EHTupleStyle.Integer:
                        GenValueView_Integer();
                        break;
                    case EHTupleStyle.IntegerList:
                        GenValueView_IntegerList();
                        break;
                    case EHTupleStyle.Real:
                        GenValueView_Real();
                        break;
                    case EHTupleStyle.RealList:
                        GenValueView_RealList();
                        break;
                    case EHTupleStyle.Rectangle:
                        GenValueView_Rectangle();
                        break;
                    case EHTupleStyle.RectangleList:
                        GenValueView_RectangleList();
                        break;
                    case EHTupleStyle.Origin:
                        if (value != null && value.Count % 3 == 0)
                            _ListDoubleValue = value;
                        else if (value != null && value.Count % 5 == 0)
                        {
                            _ListDoubleValue = new List<double> { };
                            for (int i = 0; i < value.Count; i += 5)
                                _ListDoubleValue.AddRange(new List<double> { value[i], value[i + 1], value[i + 2] });
                        }
                        GenValueView_Origin();
                        break;
                    case EHTupleStyle.OriginList:
                        if (value != null && value.Count % 3 == 0)
                            _ListDoubleValue = value;
                        else if (value != null && value.Count % 5 == 0)
                        {
                            for (int i = 0; i < value.Count; i += 5)
                                _ListDoubleValue.AddRange(new List<double> { value[i], value[i + 1], value[i + 2] });

                        }
                        GenValueView_OriginList();
                        break;
                    case EHTupleStyle.Point:
                        GenValueView_Point();
                        break;
                    case EHTupleStyle.PointList:
                        GenValueView_PointList();
                        break;
                    //case EHTupleStyle.ValueList:
                    //    GenValueView_ValueList();
                    //    break;
                    default:
                        GenValueView_Default();
                        break;
                }
                //if(Node != null & ColValue != null)
                //{
                //}    
            }
        }
        private void GenValueView_DateAndTime()
        {
            if (_ListStringValue == null || _ListStringValue.Count <= 0) return;
            ValueView = GlobFuncs.Ve2Str(_ListStringValue[0]);
        }
        private void GenValueView_Boolean()
        {
            if (_ListStringValue == null || _ListStringValue.Count <= 0) return;
            ValueView = GlobFuncs.Ve2Str(_ListStringValue[0]);
        }
        private void GenValueView_BooleanList()
        {
            if (_ListStringValue == null || _ListStringValue.Count <= 0)
                ValueView = "0 Boolean";
            else
            {
                for (int i = 0; i < _ListStringValue.Count; i++)
                {
                    if (i == 0)
                        ValueView = "(" + GlobFuncs.Ve2Str(_ListDoubleValue[i]).ToLower();
                    else
                        ValueView = ValueView + ", " + GlobFuncs.Ve2Str(_ListStringValue[i].ToLower());
                    var oneItem = new SStringBuilderItem(EHTupleStyle.Boolean)
                    {
                        ListStringValue = new List<string> { _ListStringValue[i] }
                    };
                    DataItems.Add(oneItem);
                }
                ValueView = _ListStringValue.ToString() + " Booleans " + ValueView + ")";
            }

        }
        private void GenValueView_String()
        {
            if (_ListStringValue == null || _ListStringValue.Count <= 0) return;
            ValueView = GlobFuncs.Ve2Str(_ListStringValue[0]);
        }
        private void GenValueView_StringList()
        {
            if (_ListStringValue == null || _ListStringValue.Count <= 0)
                ValueView = "0 Strings";
            else
            {
                for (int i = 0; i < _ListStringValue.Count; i++)
                {
                    if (i == 0)
                        ValueView = "(" + GlobFuncs.Ve2Str(_ListDoubleValue[i]).ToLower();
                    else
                        ValueView = ValueView + ", " + GlobFuncs.Ve2Str(_ListStringValue[i].ToLower());
                    var oneItem = new SStringBuilderItem(EHTupleStyle.String)
                    {
                        ListStringValue = new List<string> { _ListStringValue[i] }
                    };
                    DataItems.Add(oneItem);
                }
                ValueView = _ListStringValue.Count.ToString() + " Strings " + ValueView + ")";
            }

        }
       

        private void GenValueView_Real()
        {
            ValueView = string.Empty;
            if (_ListDoubleValue == null || _ListDoubleValue.Count <= 0) return;
            ValueView = GlobFuncs.Ve2Str(_ListDoubleValue[0], false, false,
                GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
        }
        private void GenValueView_RealList()
        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count <= 0)
                ValueView = "0 Reals";
            else
            {
                for (int i = 0; i < _ListDoubleValue.Count; i++)
                {
                    string s = GlobFuncs.Ve2Str(_ListDoubleValue[i], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);

                    ValueView = i == 0 ? $"({s}" : $"{ValueView}, {s}";

                    var oneItem = new SStringBuilderItem(EHTupleStyle.Real)
                    {
                        ListDoubleValue = new List<double> { _ListDoubleValue[i] }
                    };
                    DataItems.Add(oneItem);
                }
                ValueView = _ListDoubleValue.Count.ToString() + " Reals " + ValueView + ")";
            }

        }
        private void GenValueView_Integer()
        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count <= 0) return;
            ValueView = GlobFuncs.Ve2Str(_ListDoubleValue[0]);
        }
        private void GenValueView_IntegerList()
        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count <= 0)
                ValueView = " 0 Intergers";
            else
            {
                for (int i = 0; i < _ListDoubleValue.Count; i++)
                {
                    if (i == 0)
                        ValueView = "(" + GlobFuncs.Ve2Str(_ListDoubleValue[i]);
                    else
                        ValueView = ValueView + ", " + GlobFuncs.Ve2Str(_ListDoubleValue[i]);
                    var oneItem = new SStringBuilderItem(EHTupleStyle.Integer)
                    {
                        ListDoubleValue = new List<double> { _ListDoubleValue[i] }
                    };
                    DataItems.Add(oneItem);
                }
                ValueView = _ListDoubleValue.Count.ToString() + " Integers " + ValueView + ")";
            }
        }
        private void GenValueView_Rectangle()
        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count < 5) return;
            string s0 = GlobFuncs.Ve2Str(_ListDoubleValue[0], false, false,
                GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            string s1 = GlobFuncs.Ve2Str(_ListDoubleValue[1], false, false,
               GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            string s2 = GlobFuncs.Ve2Str(_ListDoubleValue[2], false, false,
               GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            string s3 = GlobFuncs.Ve2Str(_ListDoubleValue[3], false, false,
               GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            string s4 = GlobFuncs.Ve2Str(_ListDoubleValue[4], false, false,
               GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);

            ValueView = $"((({s0},{s1}),{s2}), ({s3},{s4}))";
            for (int i = 0; i < _ListDoubleValue.Count; i++)
            {
                var oneItem = new SStringBuilderItem(EHTupleStyle.Real)
                {
                    ListDoubleValue = new List<double> { _ListDoubleValue[i] }
                };
                DataItems.Add(oneItem);
            }
        }
        private void GenValueView_RectangleList()
        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count < 5)
                ValueView = "0 Rectangles";
            else if (_ListDoubleValue.Count % 5 == 0)
            {
                for (int i = 0; i < _ListDoubleValue.Count; i += 5)
                {
                    string s0 = GlobFuncs.Ve2Str(_ListDoubleValue[0], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s1 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 1], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s2 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 2], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s3 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 3], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s4 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 4], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    ValueView = string.IsNullOrEmpty(ValueView) ? $"([({s0},{s1}),{s2}), ({s3},{s4}]" : $"{ValueView}, [({s0}, {s1}, {s2}, {s4}]";
                    var oneItem = new SStringBuilderItem(EHTupleStyle.Rectangle)
                    {
                        ListDoubleValue = new List<double> { _ListDoubleValue[i],
                        _ListDoubleValue[i + 1],
                        _ListDoubleValue[i + 2],
                        _ListDoubleValue[i + 3],
                        _ListDoubleValue[i + 4]
                        }
                    };
                    DataItems.Add(oneItem);
                }
                ValueView = $"{_ListDoubleValue.Count / 5} Rectangles {ValueView}";
            }
            else ValueView = "0 Rectangles";

        }

        private void GenValueView_Origin()
        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count < 3) return;
            string s0 = GlobFuncs.Ve2Str(_ListDoubleValue[0], false, false,
                GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            string s1 = GlobFuncs.Ve2Str(_ListDoubleValue[1], false, false,
               GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            string s2 = GlobFuncs.Ve2Str(_ListDoubleValue[2], false, false,
               GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);


            ValueView = $"(({s0},{s1}),{s2})";
            for (int i = 0; i < _ListDoubleValue.Count; i++)
            {
                var oneItem = new SStringBuilderItem(EHTupleStyle.Real)
                {
                    ListDoubleValue = new List<double> { _ListDoubleValue[i] }
                };
                DataItems.Add(oneItem);
            }
        }
        private void GenValueView_OriginList()

        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count < 3)
                ValueView = "0 Origins";
            else if (_ListDoubleValue.Count % 3 == 0)
            {
                for (int i = 0; i < _ListDoubleValue.Count; i += 3)
                {
                    string s0 = GlobFuncs.Ve2Str(_ListDoubleValue[0], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s1 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 1], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s2 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 2], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    ValueView = ValueView == "" ? $"[({s0}, {s1}), {s2})]" : $"{ValueView}, [({s0}, {s1}, {s2})]";

                    var oneItem = new SStringBuilderItem(EHTupleStyle.Origin)
                    {
                        ListDoubleValue = new List<double> { _ListDoubleValue[i],
                        _ListDoubleValue[i + 1],
                        _ListDoubleValue[i + 2],
                        }
                    };
                    DataItems.Add(oneItem);
                }
                if (!string.IsNullOrEmpty(ValueView))
                    ValueView = (_ListDoubleValue.Count / 3).ToString() + "Origins " + ValueView;
            }
            else if (_ListDoubleValue.Count % 5 == 0)
            {
                for (int i = 0; i < _ListDoubleValue.Count; i += 5)
                {
                    string s0 = GlobFuncs.Ve2Str(_ListDoubleValue[0], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s1 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 1], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s2 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 2], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    ValueView = ValueView == "" ? $"[({s0}, {s1}), {s2})]" : $"{ValueView}, [({s0}, {s1}, {s2})]";

                    var oneItem = new SStringBuilderItem(EHTupleStyle.Origin)
                    {
                        ListDoubleValue = new List<double> { _ListDoubleValue[i],
                        _ListDoubleValue[i + 1],
                        _ListDoubleValue[i + 2],
                        }
                    };
                    DataItems.Add(oneItem);
                }
                if (!string.IsNullOrEmpty(ValueView))
                    ValueView = (_ListDoubleValue.Count / 5).ToString() + "Origins " + ValueView;

            }
            else ValueView = "0 Origins";
        }
        private void GenValueView_Point()
        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count < 2) return;
            string s0 = GlobFuncs.Ve2Str(_ListDoubleValue[0], false, false,
                GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            string s1 = GlobFuncs.Ve2Str(_ListDoubleValue[1], false, false,
               GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);



            ValueView = $"({s0},{s1})";
            for (int i = 0; i < _ListDoubleValue.Count; i++)
            {
                var oneItem = new SStringBuilderItem(EHTupleStyle.Real)
                {
                    ListDoubleValue = new List<double> { _ListDoubleValue[i] }
                };
                DataItems.Add(oneItem);
            }
        }
        private void GenValueView_PointList()
        {
            if (_ListDoubleValue == null || _ListDoubleValue.Count < 2)
                ValueView = "0 Points";
            else if (_ListDoubleValue.Count % 2 == 0)
            {

                for (int i = 0; i < _ListDoubleValue.Count; i += 2)
                {
                    string s0 = GlobFuncs.Ve2Str(_ListDoubleValue[i], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s1 = GlobFuncs.Ve2Str(_ListDoubleValue[i + 1], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    ValueView = ValueView == "" ? $"({s0}, {s1})" : $"{ValueView}, ({s0}, {s1})";
                    var oneItem = new SStringBuilderItem(EHTupleStyle.Point)
                    {
                        ListDoubleValue = new List<double> { _ListDoubleValue[i] }
                    };
                    DataItems.Add(oneItem);


                }
                if (!string.IsNullOrEmpty(ValueView))
                    ValueView = (_ListDoubleValue.Count / 2).ToString() + " Points" + ValueView;
            }
            else ValueView = "0 Points";
        }
        private void GenValueView_Default()
        {
            if (_ListStringValue == null || _ListStringValue.Count <= 0) return;
            ValueView = GlobFuncs.Ve2Str(_ListStringValue[0]);
        }
        private List<string> _ListStringValue;
        public List<string> ListStringValue
        {
            get => _ListStringValue;
            set
            {
                DataItems = new List<SStringBuilderItem>();
                _ListStringValue = value;
                ValueView = string.Empty;
                ValueViewFull = string.Empty;
                switch (ValueStyle)
                {
                    case EHTupleStyle.DateAndTime:
                        GenValueView_DateAndTime();
                        break;
                    case EHTupleStyle.Boolean:
                        GenValueView_Boolean();
                        break;
                    case EHTupleStyle.BooleanList:
                        GenValueView_BooleanList();
                        break;
                    case EHTupleStyle.String:
                        GenValueView_String();
                        break;
                    case EHTupleStyle.StringList:
                        GenValueView_StringList();
                        break;
                    default:
                        GenValueView_Default();
                        break;
                }
            }
        }
      
        public string TrueText { get; set; }

        public string FalseText { get; set; }
        public EDateFormat DateFormat { get; set; }
        public EDelimiterDate DelimiterDate { get; set; }
        public ETimeFormat TimeFormat { get; set; }
        public EDelimiterTime DelemiterTime { get; set; }
        public bool UseDecimalPlaces { get; set; }
        public int DecimalPlaces { get; set; }
        public bool UseMiniumLength { get; set; }
        public int MiniumLength { get; set; }
        public bool UseLimitInput { get; set; }
        public int MaximumLength { get; set; }
        public bool UsePadOutput { get; set; }
        public EPadOutPut PadOutPut { get; set; }
        public EPadWiths PadWith { get; set; }
        public EGroupingBracket GroupingBracket { get; set; }
        public EXYDelimiter XYDelimiter { get; set; }
        public EDelimiterTime DelimiterTime { get; set; }

        public SElementDelimiter ElementDelimiter { get; set; }
        public SStringBuilderItem(EHTupleStyle _ValueStyle = EHTupleStyle.Integer)
        {
            Node = null;
            ColValue = null;
            OrderNum = 0;
            Name = "Input";
            RefID = Guid.Empty;
            RefPropName = string.Empty;
            RefIndex = string.Empty;
            IscanReset = false;
            IsParent = false;
            IsDataItem = false;
            ValueStyle = _ValueStyle;
            ElementDelimiter = new SElementDelimiter();
            TrueText = "True";
            FalseText = "False";
            Leading = string.Empty;
            Tralling = string.Empty;
            DateFormat = EDateFormat.yyyymmdd;
            TimeFormat = ETimeFormat.hhmmss24;
            DelimiterDate = EDelimiterDate.Slash;
            DelemiterTime = EDelimiterTime.Colon;
            UseDecimalPlaces = false || (ValueStyle == EHTupleStyle.Origin || ValueStyle == EHTupleStyle.OriginList);
            ParentIDResets = null;
            DecimalPlaces = 4;
            switch(ValueStyle)
            {
                case EHTupleStyle.DateAndTime:
                    DecimalPlaces = 3;
                    break;
                case EHTupleStyle.Origin:
                    DecimalPlaces = 4;
                    break;
                case EHTupleStyle.OriginList:
                    DecimalPlaces = 4;
                    break;
            }
            MiniumLength = 1;
            switch (ValueStyle)
            {
                case EHTupleStyle.Integer:
                    MiniumLength = 8;
                    break;
                case EHTupleStyle.Origin:
                    MiniumLength = 1;
                    break;
                case EHTupleStyle.OriginList:
                    MiniumLength = 1;
                    break;
            }   
            UseMiniumLength = false || (ValueStyle == EHTupleStyle.Origin || ValueStyle == EHTupleStyle.OriginList);
            UseLimitInput = false;
            MaximumLength = 0;
            UsePadOutput = false;
            IscanReset = false;
            IsHightLight = false;
            PadOutPut = EPadOutPut.LeadingSpaces;
            PadWith = EPadWiths.LeadingZeros;
            GroupingBracket = EGroupingBracket.Parenttheses;
            XYDelimiter = EXYDelimiter.Comma;
            ElementDelimiter = new SElementDelimiter
            {
                DelimiterTypes = EDelimiterTypes.Standard,
                StandardValue = EDelimiter.Comma,
                CustomValue = string.Empty
            };
            VarType = EVarType.Input;

        }
        public string GetItemType()
        {
            string _Result = string.Empty;
            switch (ValueStyle)
            {
                case EHTupleStyle.Point:
                    _Result = cDataTypes.Point;
                    break;
                case EHTupleStyle.PointList:
                    _Result = cDataTypes.PointList;
                    break;
                case EHTupleStyle.Rectangle:
                    _Result = cDataTypes.Rectangle;
                    break;
                case EHTupleStyle.RectangleList:
                    _Result = cDataTypes.RectangleList;
                    break;
                case EHTupleStyle.Origin:
                    _Result = cDataTypes.Origin;
                    break;
                case EHTupleStyle.OriginList:
                    _Result = cDataTypes.OriginList;
                    break;
                case EHTupleStyle.Boolean:
                    _Result = cDataTypes.Boolean;
                    break;
                case EHTupleStyle.BooleanList:
                    _Result = cDataTypes.BooleanList;
                    break;
                case EHTupleStyle.Integer:
                    _Result = cDataTypes.Integer;
                    break;
                case EHTupleStyle.IntegerList:
                    _Result = cDataTypes.IntegerList;
                    break;
                case EHTupleStyle.String:
                    _Result = cDataTypes.String;
                    break;
                case EHTupleStyle.Real:
                    _Result = cDataTypes.Real;
                    break;
                case EHTupleStyle.RealList:
                    _Result = cDataTypes.RealList;
                    break;
                case EHTupleStyle.StringList:
                    _Result = cDataTypes.StringList;
                    break;
                case EHTupleStyle.DateAndTime:
                    _Result = cDataTypes.DataAndTime;
                    break;
            }
            return _Result;
        }

        public EHTupleStyle GetValueType(string _Type)
        {
            EHTupleStyle _Result = EHTupleStyle.Boolean;
            switch (_Type)
            {
                case cDataTypes.Boolean:
                    _Result = EHTupleStyle.Boolean;
                    break;
                case cDataTypes.BooleanList:
                    _Result = EHTupleStyle.BooleanList;
                    break;
                case cDataTypes.DataAndTime:
                    _Result = EHTupleStyle.DateAndTime;
                    break;
                case cDataTypes.Integer:
                    _Result = EHTupleStyle.Integer;
                    break;
                case cDataTypes.IntegerList:
                    _Result = EHTupleStyle.IntegerList;
                    break;
                case cDataTypes.Origin:
                    _Result = EHTupleStyle.Origin;
                    break;
                case cDataTypes.OriginList:
                    _Result = EHTupleStyle.OriginList;
                    break;
                case cDataTypes.Rectangle:
                    _Result = EHTupleStyle.Rectangle;
                    break;
                case cDataTypes.RectangleList:
                    _Result = EHTupleStyle.RectangleList;
                    break;
                case cDataTypes.Real:
                    _Result = EHTupleStyle.Real;
                    break;
                case cDataTypes.RealList:
                    _Result = EHTupleStyle.RealList;
                    break;
                case cDataTypes.Point:
                    _Result = EHTupleStyle.Point;
                    break;
                case cDataTypes.PointList:
                    _Result = EHTupleStyle.PointList;
                    break;
                case cDataTypes.String:
                    _Result = EHTupleStyle.String;
                    break;
                case cDataTypes.StringList:
                    _Result = EHTupleStyle.StringList;
                    break;
             

            }
            return _Result;
        }
        //public ETupleStyle TupleStyle
        //{
        //    get => _TupleStyle;
        //    set
        //    {
        //        _TupleStyle = value;
        //        RefID = Guid.Empty;
        //        RefPropName = string.Empty;
        //        switch(_TupleStyle)
        //        {
        //            case ETupleStyle.PointList:
        //                Value
        //        }
        //    }
        //}

    }

    public class ShapeListItem
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        /// <summary>
        /// TRỤC Y
        /// </summary>
        public double Row { get; set; }
        public double Phi { get; set; }
        //public Drawingtype
        /// <summary>
        /// TRỤC X
        /// </summary>
        public double Col { get; set; }
        public int Drawingtype { get; set; }
        public int ConnectType { get; set; }
        public int Type {get; set ;}
    }
    public class SShapeList : RTCVariableType
    {
        private List<ShapeListItem> _rtcValue;
        public List<ShapeListItem> rtcValue
        //private ShapeListItem _rtcValue;
        //public ShapeListItem rtcValue
        {

            get => _rtcValue;
            set
            {
                _rtcValue = value;
                DataItems = new List<SStringBuilderItem>();
                rtcValueView = string.Empty;
                rtcValueViewFull = string.Empty;
                GenValueView_ShapeList();
            }
        }

        private void GenValueView_ShapeList()
        {
            if (_rtcValue == null || _rtcValue.Count == 0)
                rtcValueView = string.Empty;
            //if (_rtcValue == null)
            //    rtcValueView = string.Empty;
            else
            {
                for (int i = 0; i < _rtcValue.Count; i++)
                {
                    string Row = _rtcValue[i].Row.ToString();
                    string Col = _rtcValue[i].Col.ToString();
                    string Phi = _rtcValue[i].Phi.ToString();
                    string Width = _rtcValue[i].Width.ToString();
                    string Height = _rtcValue[i].Height.ToString();
                    string DrawingType = _rtcValue[i].Drawingtype.ToString();
                    string ConnectType = _rtcValue[i].Drawingtype.ToString();
                    string Type = _rtcValue[i].Type.ToString();
                    string ID = _rtcValue[i].ID.ToString();
                    string Name = _rtcValue[i].Name.ToString();

                    if (rtcValueView == "")
                        rtcValueView = $"[{Row}, {Col}, {Phi}, {Width}, {Height}, {DrawingType}, {ConnectType}, {Type}, {ID}, {Name}]";
                }

                //string Row = _rtcValue.Row.ToString();
                //string Col = _rtcValue.Col.ToString();
                //string Phi = _rtcValue.Phi.ToString();
                //string Width = _rtcValue.Width.ToString();
                //string Height = _rtcValue.Height.ToString();
                //string DrawingType = _rtcValue.Drawingtype.ToString();
                //string ConnectType = _rtcValue.Drawingtype.ToString();
                //string Type = _rtcValue.type.ToString();
                //string ID = _rtcValue.ID.ToString();
                //string Name = _rtcValue.Name.ToString();

                //if (rtcValueView == "")
                //    rtcValueView = $"[{Row}, {Col}, {Phi}, {Width}, {Height}, {DrawingType}, {ConnectType}, {Type}, {ID}, {Name}]";
            }
        }
        
        public SShapeList(EHTupleStyle _HTupleStyle = EHTupleStyle.None)
        {
            ValueStyle = _HTupleStyle;
            //rtcValue = new ShapeListItem();
            rtcValue = new List<ShapeListItem>();
            rtcActive = true;
        }
        public SShapeList(String description,
          EHTupleStyle hTupleStyle = EHTupleStyle.None,
          EPropertyState propertyState = EPropertyState.None,
          EROILegend roiLegend = EROILegend.None,
          bool readOnly = false,
          bool hidden = false,
          bool display = false,
          bool saveToFile = false,
          bool _IsCanReset = false)
        {
            rtcDescription = description;
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            //rtcValue = new ShapeListItem();
            rtcValue = new List<ShapeListItem>();
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
    }

    public class SListString : RTCVariableType
    {
        private List<string> _rtcValue;
        public List<string> rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                DataItems = new List<SStringBuilderItem>();
                rtcValueView = string.Empty;
                rtcValueViewFull = string.Empty;
                switch (ValueStyle)
                {
                    case EHTupleStyle.StringRange:
                        GenValueView_Line();
                        break;
                    default:
                        GenValueView_None();
                        break;
                }
            }
        }
        public SListString(EHTupleStyle _HTupleStyle = EHTupleStyle.None)
        {
            ValueStyle = _HTupleStyle;
            rtcValue = new List<string>();
            rtcActive = true;
        }
        public SListString(String description,
          EHTupleStyle hTupleStyle = EHTupleStyle.None,
          EPropertyState propertyState = EPropertyState.None,
          EROILegend roiLegend = EROILegend.None,
          bool readOnly = false,
          bool hidden = false,
          bool display = false,
          bool saveToFile = false,
          bool _IsCanReset = false)
        {
            rtcDescription = description;
            rtcValue = new List<string>();
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
        #region GEN VALUE STRING
        private void GenValueView_Line()
        {
            if (_rtcValue == null || _rtcValue.Count < 4)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;

            }
            else
            {
                string s0 = GlobFuncs.Ve2Str(_rtcValue[0], false, false, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s1 = GlobFuncs.Ve2Str(_rtcValue[1], false, false, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s2 = GlobFuncs.Ve2Str(_rtcValue[2], false, false, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s3 = GlobFuncs.Ve2Str(_rtcValue[3], false, false, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                rtcValueView = $"[({s0},{s1},{s2},{s3}]";


            }
            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        private void GenValueView_None()
        {
            if (_rtcValue == null)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;
            }
            else
            {
                for (int i = 0; i < rtcValue.Count; i++)
                {
                    string s = GlobFuncs.Ve2Str(_rtcValue[i], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    rtcValueView = string.IsNullOrEmpty(rtcValueView) ? s : $"{rtcValueView},{s}";
                }
                rtcValueS = rtcValueView;
                rtcValueView = string.IsNullOrEmpty(rtcValueView) ? "0 Items" :
                    _rtcValue.Count.ToString() + " Item [" + rtcValueView + "]";
            }
            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        #endregion

    }
    public class SListDouble : RTCVariableType
    {
        private List<double> _rtcValue;
        public List<double> rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                DataItems = new List<SStringBuilderItem>();
                rtcValueView = string.Empty;
                rtcValueViewFull = string.Empty;
                switch (ValueStyle)
                {
                    case EHTupleStyle.RangeMinMax:
                        GenVaLueView_RangeMinMax();
                        break;
                    case EHTupleStyle.RangeMinMaxLimit:
                        GenVaLueView_RangeMinMaxLimit();
                        break;
                    case EHTupleStyle.PointList:
                        GenValueView_PointList();
                        break;
                    case EHTupleStyle.Rectangle:
                        GenValueView_Rectangle();
                        break;
                    case EHTupleStyle.Origin:
                        GenValueView_Origin();
                        break;
                    case EHTupleStyle.OriginList:
                        GenValueView_OriginList();
                        break;
                    case EHTupleStyle.Line:
                        GenValueView_Line();
                        break;
                    case EHTupleStyle.ValueList:
                        GenValueView_ValueList();
                        break;
                    case EHTupleStyle.Tolerance:
                        GenValueView_Tolerance();
                        break;
                    case EHTupleStyle.None:
                        GenValueView_None();
                        break;



                }
            }
        }
        #region Gen VaLue Double
        private void GenValueView_Line()
        {
            if (_rtcValue == null || _rtcValue.Count < 4)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;

            }
            else
            {
                string s0 = GlobFuncs.Ve2Str(_rtcValue[0], false, false, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s1 = GlobFuncs.Ve2Str(_rtcValue[1], false, false, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s2 = GlobFuncs.Ve2Str(_rtcValue[2], false, false, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s3 = GlobFuncs.Ve2Str(_rtcValue[3], false, false, GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                rtcValueView = $"[({s0},{s1},{s2},{s3}]";


            }
            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        private void GenValueView_None()
        {
            if (_rtcValue == null)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;
            }
            else
            {
                for(int i = 0; i<rtcValue.Count; i ++)
                {
                    string s = GlobFuncs.Ve2Str(_rtcValue[i], false, false,
                   GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    rtcValueView = string.IsNullOrEmpty(rtcValueView) ? s : $"{ rtcValueView}, { s}";

                }
                rtcValueS = rtcValueView;
                rtcValueView = string.IsNullOrEmpty(rtcValueView) ? "0 Items" :
                    _rtcValue.Count.ToString() + " Items [" + rtcValueView + "]";
            }

            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        private void GenValueView_Rectangle()
        {
            if (rtcValue == null || rtcValue.Count < 5)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;
            }
            else
            {
                string s0 = GlobFuncs.Ve2Str(_rtcValue[0], false, false,
                   GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s1 = GlobFuncs.Ve2Str(_rtcValue[1], false, false,
                   GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s2 = GlobFuncs.Ve2Str(_rtcValue[2], false, false,
                   GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s3 = GlobFuncs.Ve2Str(_rtcValue[3], false, false,
                   GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s4 = GlobFuncs.Ve2Str(_rtcValue[4], false, false,
              GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                rtcValueView = $"[({s0}, {s1}),{s2},{s3}, {s4}]";
            }
            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : "=" + rtcValueView);
        }

        private void GenValueView_PointList()
        {
            int soPoint = 0;
            if (_rtcValue != null)
                for (int i = 0; i < _rtcValue.Count; i += 2)
                {
                    if (i + 1 > _rtcValue.Count - 1)
                        break;
                    soPoint += 1;
                    string s0 = GlobFuncs.Ve2Str(_rtcValue[i], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s1 = GlobFuncs.Ve2Str(_rtcValue[i + 1], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);

                    if (rtcValueView == "")
                        rtcValueView = $"({s0},{s1})";
                    else
                        rtcValueView = $"{rtcValueView}, ({s0},{s1})";

                    var oneItem = new SStringBuilderItem(EHTupleStyle.Point)
                    {
                        ListDoubleValue = new List<double>() { _rtcValue[i], _rtcValue[i + 1] }
                    };
                    DataItems.Add(oneItem);
                }
            rtcValueView = soPoint.ToString() + (soPoint > 1 ? "Points" : "Point") + (rtcValueView != "" ? " [" + rtcValueView + "]" : "");
            rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            //if (_rtcValue != null && _rtcValue.Count > 0)
            //{
            //    if (rtcValue == null || rtcValue.Count < 4)
            //        rtcValueView = string.Empty;
            //    else
            //    {
            //        string s0 = GlobFuncs.Ve2Str(_rtcValue[0], false, false,
            //           GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            //        string s1 = GlobFuncs.Ve2Str(_rtcValue[1], false, false,
            //           GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            //        string s2 = GlobFuncs.Ve2Str(_rtcValue[2], false, false,
            //           GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            //        string s3 = GlobFuncs.Ve2Str(_rtcValue[3], false, false,
            //           GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
            //        rtcValueView = $"[{s0}, {s1}], LIMIT = [{s2},{s3}]";
            //    }
            //    rtcValueViewFull = string.IsNullOrEmpty(rtcValueView) ? rtcDescription : rtcDescription + " = " + rtcValueView;
            //}
        }

        private void GenVaLueView_RangeMinMaxLimit()
        {
            if (_rtcValue != null && _rtcValue.Count > 0)
                if (rtcValue == null || rtcValue.Count < 4)
                    rtcValueView = string.Empty;
                else
                {
                    string s0 = GlobFuncs.Ve2Str(_rtcValue[0], false, false,
                        GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s1 = GlobFuncs.Ve2Str(_rtcValue[1], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s2 = GlobFuncs.Ve2Str(_rtcValue[2], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    string s3 = GlobFuncs.Ve2Str(_rtcValue[3], false, false,
                       GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);

                    rtcValueView = $"[{s0}, {s1}], Limit = [{s2}, {s3}]";
                }
            rtcValueViewFull = string.IsNullOrEmpty(rtcValueView) ? rtcDescription : rtcDescription + " = " + rtcValueView;
        }

        private void GenVaLueView_RangeMinMax()
        {
            if (_rtcValue != null && _rtcValue.Count >= 2)
            {
                rtcValueView = _rtcValue == null ? string.Empty :
                    "[" + GlobFuncs.Ve2Str(_rtcValue[0]) + "," + GlobFuncs.Ve2Str(_rtcValue[1]) + "]";
                rtcValueViewFull = _rtcValue == null ? rtcDescription : rtcDescription + " = " + rtcValueView;
                rtcValueViewFull = _rtcValue == null ? rtcDescription : rtcDescription + " = " + rtcValueView;
            }
        }
        private void GenValueView_Origin()
        {
            if (_rtcValue == null || _rtcValue.Count < 3)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;
            }
            else
            {
                string s0 = GlobFuncs.Ve2Str(_rtcValue[0], false, false,
                         GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s1 = GlobFuncs.Ve2Str(_rtcValue[1], false, false,
                   GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                string s2 = GlobFuncs.Ve2Str(_rtcValue[2], false, false,
                     GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                rtcValueView = $"[({s0}, {s1}, {s2})]";

                var oneItem = new SStringBuilderItem(EHTupleStyle.Origin)
                {
                    ListDoubleValue = new List<double> { _rtcValue[0], _rtcValue[1], _rtcValue[2] }
                };
                DataItems.Add(oneItem);
            }
            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        
        private void GenValueView_OriginList()
        {
            if(_rtcValue ==null)
            {
                rtcValueView = "0 Origins";
                rtcValueS = rtcValueView;
            }
            else
            {
                if(_rtcValue != null && _rtcValue.Count > 0)
                {
                    if(_rtcValue.Count % 3 == 0)
                    {
                        for(int i = 0; i < _rtcValue.Count; i +=3)
                        {
                            string s0 = GlobFuncs.Ve2Str(_rtcValue[i], false, false,
                         GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                            string s1 = GlobFuncs.Ve2Str(_rtcValue[i + 1], false, false,
                               GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                            string s2 = GlobFuncs.Ve2Str(_rtcValue[i + 2], false, false,
                                 GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);


                            if (rtcValueView == "")
                                rtcValueView = $"[{s0}, {s1}, {s2}]";
                            else
                                rtcValueView = $"{rtcValueView}, [{s0}, {s1}, {s2}]";
                            var oneItem = new SStringBuilderItem(EHTupleStyle.Origin)
                            {
                                ListDoubleValue = new List<double> { _rtcValue[i], _rtcValue[i + 1], _rtcValue[i + 2] }
                            };
                            DataItems.Add(oneItem);
                        }
                        rtcValueS = rtcValueView;
                        if (!string.IsNullOrEmpty(rtcValueView))
                            rtcValueView = (_rtcValue.Count / 3).ToString() + " Origins " + rtcValueView;
                    }
                }
            }
            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        private void GenValueView_ValueList()
        {
            if (_rtcValue == null)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;
            }
            else
            {

                for (int i = 0; i < _rtcValue.Count; i++)
                {
                    string s = GlobFuncs.Ve2Str(_rtcValue[i], false, false,
                 GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);
                    rtcValueView = string.IsNullOrEmpty(rtcValueView) ? s : $"{rtcValueView}, {s}";
                }

                rtcValueS = rtcValueView;
                rtcValueView = string.IsNullOrEmpty(rtcValueView) ? "0 Items" :
                    _rtcValue.Count.ToString() + " Item [" + rtcValueView + "]";
            } 
               
            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        private void GenValueView_Tolerance()
        {
            if (_rtcValue == null || _rtcValue.Count <3)
            {
                rtcValueView = string.Empty;
                rtcValueS = rtcValueView;
            }
            else
            {

                string s0 = GlobFuncs.Ve2Str(_rtcValue[0], false, false,
                    GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);

                string s1 = GlobFuncs.Ve2Str(_rtcValue[1], false, false,
                    GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);

                string s2 = GlobFuncs.Ve2Str(_rtcValue[2], false, false,
                    GlobVar.RTCVision.ViewOptions.NumberOfDigitsToRound);

                rtcValueS = rtcValueView;
                rtcValueView = $"[{s0}, {s1}, {s2}]";
            }

            rtcValueViewFull = rtcDescription + (rtcValueView == string.Empty ? "" : " = " + rtcValueView);
        }
        #endregion
        public SListDouble(EHTupleStyle _HTupleStyle = EHTupleStyle.None)
        {
            ValueStyle = _HTupleStyle;
            rtcValue = new List<double>();
            rtcActive = true;
        }
        public SListDouble(String description,
          EHTupleStyle hTupleStyle = EHTupleStyle.None,
          EPropertyState propertyState = EPropertyState.None,
          EROILegend roiLegend = EROILegend.None,
          bool readOnly = false,
          bool hidden = false,
          bool display = false,
          bool saveToFile = false,
          bool _IsCanReset = false)
        {
            rtcDescription = description;
            
            rtcValue = new List<double> { };
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }

    }
    
    public class SListVector : RTCVariableType
    {
        private List<VectorOfVectorOfPoint> _rtcValue;
        public List<VectorOfVectorOfPoint> rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;

                if (value != null && value.Count > 0)
                {
                    int Count = value.Count;
                    if (Count == -1)
                    {
                        rtcValueS = "0 Items";
                        rtcValueView = "0 Items";
                    }
                    else
                    {
                        rtcValueS = $"{Count} Items";
                        rtcValueView = $"{Count} Items";
                    }
                }
                else
                {
                    rtcValueS = "0 Items";
                    rtcValueView = "0 Items";

                }
                rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            }
        }
        public SListVector(String description,
          EHTupleStyle hTupleStyle = EHTupleStyle.None,
          EPropertyState propertyState = EPropertyState.None,
          EROILegend roiLegend = EROILegend.None,
          bool readOnly = false,
          bool hidden = false,
          bool display = false,
          bool saveToFile = false,
          bool _IsCanReset = false)
        {
            rtcDescription = description;
            rtcValue = new List<VectorOfVectorOfPoint>();
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
            ValueStyle = hTupleStyle;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
    }
    public class SWindow : RTCVariableType
    {
        private GraphicsWindow.GraphicsWindow _rtcValue;
        public GraphicsWindow.GraphicsWindow rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;
                if (_rtcValue != null)
                {
                    rtcValueView = _rtcValue.GetType().ToString();
                    rtcValueViewFull = rtcDescription + " = " + _rtcValue.GetType().ToString();
                }
                else
                {
                    rtcValueView = string.Empty;
                    rtcValueViewFull = rtcDescription;
                }
            }    
        }
        public SWindow(string description,
                    EHTupleStyle hTupleStyle = EHTupleStyle.None,
                    EPropertyState propertyState = EPropertyState.None,
                    EROILegend roiLegend = EROILegend.None,
                    bool readOnly = false,
                    bool hidden = false,
                    bool display = false,
                    bool saveToFile = false,
                    bool isCanReset = false)
        {
            rtcDescription = description;
            rtcValue = null;
            rtcState = propertyState;
            rtcRoiLegend = roiLegend;
           // rtcColor = EROILengendColor.Values[Enum.GetName(typeof(EROILegend), RtcRoiLegend) ?? nameof(EROILegend.None)];
            ValueStyle = hTupleStyle;
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcClearWhenRun = false;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
            rtcIsCanReset = isCanReset;
        }
    }
    public class SRegion : RTCVariableType
    {
        private List<List<double[]>> _rtcValue;
        public List<List<double[]>> rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;

                if (value != null && value.Count > 0 )
                {
                    int Count = value.Count;
                    if (Count == -1)
                    {
                        rtcValueS = "0 Items";
                        rtcValueView = "0 Items";
                    }
                    else
                    {
                        rtcValueS = $"{Count} Items";
                        rtcValueView = $"{Count} Items";
                    }
                }
                else
                {
                    rtcValueS = "0 Items";
                    rtcValueView = "0 Items";
                               
                }
                rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            }
        }
        public SRegion(String description,
          EHTupleStyle hTupleStyle = EHTupleStyle.None,
          EPropertyState propertyState = EPropertyState.None,
          EROILegend roiLegend = EROILegend.None,
          bool readOnly = false,
          bool hidden = false,
          bool display = false,
          bool saveToFile = false,
          bool _IsCanReset = false)
        {
            rtcDescription = description;
            rtcValue = new List<List<double[]>>();
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
    }
  
       public class SObject : RTCVariableType
    {
        private Dictionary<Guid, List<double>> _rtcValue;
        public Dictionary<Guid, List<double>> rtcValue
        {
            get => _rtcValue;
            set
            {
                _rtcValue = value;

                if (value != null  && value.Count > 0 ? value.ContainsKey(Guid.Empty) : false)
                {
                    int Count = value.Count;
                    if (Count == -1)
                    {
                        rtcValueS = "0 Items";
                        rtcValueView = "0 Items";
                    }
                    else
                    {
                        rtcValueS = $"{Count} Items";
                        rtcValueView = $"{Count} Items";
                    }
                }
                else
                {
                    rtcValueS = "0 Items";
                    rtcValueView = "0 Items";

                }
                rtcValueViewFull = rtcDescription + " = " + rtcValueView;
            }
        }
        public SObject(String description,
          EHTupleStyle hTupleStyle = EHTupleStyle.None,
          EPropertyState propertyState = EPropertyState.None,
          EROILegend roiLegend = EROILegend.None,
          bool readOnly = false,
          bool hidden = false,
          bool display = false,
          bool saveToFile = false,
          bool _IsCanReset = false)
        {
            rtcDescription = description;
            rtcValue = new Dictionary<Guid, List<double>>();
            rtcActive = true;
            rtcReadOnly = readOnly;
            rtcHidden = hidden;
            rtcDisplay = display;
            rtcDisplayOrigin = display;
            rtcSaveToFile = saveToFile;
        }
    }

    class cBaseTypes
    {
    }


}
