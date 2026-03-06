using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public delegate void StringBuilderItem_DataChangedEvent(SStringBuilderItem SBItem);

    public partial class ucStringBuilderItemProperty : UserControl
    {
        public StringBuilderItem_DataChangedEvent OnStringBuilderItem_DataChangedEvent;

        public ucStringBuilderItemProperty()
        {
            InitializeComponent();
            RTCStringBuilderItemType = EStringBuilderItemTypes.Boolean;

        }
        #region PROPERTIES
        private EStringBuilderItemTypes _RTCStringBuilderItemType;
        [Browsable(true), DefaultValue(EStringBuilderItemTypes.Boolean), Description("String Builder Item Types")]
        [ListBindable(true), Editor(typeof(System.Windows.Forms.ComboBox), typeof(System.Windows.Forms.ComboBox))]
        public EStringBuilderItemTypes RTCStringBuilderItemType
        {
            get
            {
                return _RTCStringBuilderItemType;
            }
            set
            {
                _RTCStringBuilderItemType = value;
                RemoveEventForAllConfigureItem();

                ucConfigureDateTimeInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.DateAndTime;
                ucConfigureDateTimeInput1.RTCSBItem = ucConfigureDateTimeInput1.Visible ? _RTCSBItem : null;

                ucConfigureBooleanInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.Boolean;
                ucConfigureBooleanInput1.RTCSBItem = ucConfigureBooleanInput1.Visible ? _RTCSBItem : null;

                ucConfigureBooleanListInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.BooleanList;
                ucConfigureBooleanListInput1.RTCSBItem = ucConfigureBooleanListInput1.Visible ? _RTCSBItem : null;

                ucConfigureIntegerInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.Integer;
                ucConfigureIntegerInput1.RTCSBItem = ucConfigureIntegerInput1.Visible ? _RTCSBItem : null;

                ucConfigureIntegerListInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.IntegerList;
                ucConfigureIntegerListInput1.RTCSBItem = ucConfigureIntegerListInput1.Visible ? _RTCSBItem : null;

                ucConfigureOriginInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.Origin;
                ucConfigureOriginInput1.RTCSBItem = ucConfigureOriginInput1.Visible ? _RTCSBItem : null;

                ucConfigureOriginListInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.OriginList;
                ucConfigureOriginListInput1.RTCSBItem = ucConfigureOriginListInput1.Visible ? _RTCSBItem : null;

                ucConfigurePointInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.Point;
                ucConfigurePointInput1.RTCSBItem = ucConfigurePointInput1.Visible ? _RTCSBItem : null;

                ucConfigurePointListInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.PointList;
                ucConfigurePointListInput1.RTCSBItem = ucConfigurePointListInput1.Visible ? _RTCSBItem : null;

                ucConfigureRealInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.Real;
                ucConfigureRealInput1.RTCSBItem = ucConfigureRealInput1.Visible ? _RTCSBItem : null;

                ucConfigureRealListInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.RealList;
                ucConfigureRealListInput1.RTCSBItem = ucConfigureRealListInput1.Visible ? _RTCSBItem : null;

                ucConfigureStringInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.String;
                ucConfigureStringInput1.RTCSBItem = ucConfigureStringInput1.Visible ? _RTCSBItem : null;

                ucConfigureStringListInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.StringList;
                ucConfigureStringListInput1.RTCSBItem = ucConfigureStringListInput1.Visible ? _RTCSBItem : null;

                ucConfigureRectangleInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.Rectangle;
                ucConfigureRectangleInput1.RTCSBItem = ucConfigureRectangleInput1.Visible ? _RTCSBItem : null;

                ucConfigureRectangleListInput1.Visible = _RTCStringBuilderItemType == EStringBuilderItemTypes.RectangleList;
                ucConfigureRectangleListInput1.RTCSBItem = ucConfigureRectangleListInput1.Visible ? _RTCSBItem : null;
            }
        }

        private SStringBuilderItem _RTCSBItem;

        public SStringBuilderItem RTCSBItem
        {
            get { return _RTCSBItem; }
            set
            {
                try
                {
                    GlobFuncs.BeginControlUpdate(this);
                    _RTCSBItem = value;
                    RemoveEventForAllConfigureItem();
                    if (_RTCSBItem == null) return;
                    switch (_RTCSBItem.ValueStyle)
                    {
                        case EHTupleStyle.Rectangle:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.Rectangle;
                            ucConfigureRectangleInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureRectangleInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureRectangleInput1.LayoutControls();
                            break;
                        case EHTupleStyle.Origin:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.Origin;
                            ucConfigureOriginInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureOriginInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureOriginInput1.LayoutControls();
                            break;
                        case EHTupleStyle.OriginList:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.OriginList;
                            ucConfigureOriginListInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureOriginListInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureOriginListInput1.LayoutControls();
                            break;
                        case EHTupleStyle.RectangleList:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.RectangleList;
                            ucConfigureRectangleListInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureRectangleListInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureRectangleListInput1.LayoutControls();
                            break;
                        case EHTupleStyle.Point:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.Point;
                            ucConfigurePointInput1.RTCSBItem = _RTCSBItem;
                            ucConfigurePointInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigurePointInput1.LayoutControls();
                            break;
                        case EHTupleStyle.PointList:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.PointList;
                            ucConfigurePointListInput1.RTCSBItem = _RTCSBItem;
                            ucConfigurePointListInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigurePointListInput1.LayoutControls();
                            break;
                        case EHTupleStyle.Boolean:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.Boolean;
                            ucConfigureBooleanInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureBooleanInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureBooleanInput1.LayoutControls();
                            break;
                        case EHTupleStyle.BooleanList:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.BooleanList;
                            ucConfigureBooleanListInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureBooleanListInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureBooleanListInput1.LayoutControls();
                            break;
                        case EHTupleStyle.Integer:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.Integer;
                            ucConfigureIntegerInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureIntegerInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureIntegerInput1.LayoutControls();
                            break;
                        case EHTupleStyle.IntegerList:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.IntegerList;
                            ucConfigureIntegerListInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureIntegerListInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureIntegerListInput1.LayoutControls();
                            break;
                        case EHTupleStyle.Real:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.Real;
                            ucConfigureRealInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureRealInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureRealInput1.LayoutControls();
                            break;
                        case EHTupleStyle.RealList:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.RealList;
                            ucConfigureRealListInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureRealListInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureRealListInput1.LayoutControls();
                            break;
                        case EHTupleStyle.String:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.String;
                            ucConfigureStringInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureStringInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureStringInput1.LayoutControls();
                            break;
                        case EHTupleStyle.StringList:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.StringList;
                            ucConfigureStringListInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureStringListInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureStringListInput1.LayoutControls();
                            break;
                        case EHTupleStyle.DateAndTime:
                            RTCStringBuilderItemType = EStringBuilderItemTypes.DateAndTime;
                            ucConfigureDateTimeInput1.RTCSBItem = _RTCSBItem;
                            ucConfigureDateTimeInput1.OnConfigureInputDataChanged += OnConfigureInputItem_DataChangedEvent;
                            ucConfigureDateTimeInput1.LayoutControls();
                            break;
                    }
                }
                finally
                {
                    GlobFuncs.EndControlUpdate(this);
                }
            }
        }

        #endregion

        #region FUNCTIONS        

        private void RemoveEventForAllConfigureItem()
        {
            var c = GlobFuncs.GetAllUserControlWithBaseType(this, typeof(ucConfigureInputBase));
            if (c != null && c.Count() > 0)
            {
                ucConfigureInputBase ConfigureInputBase = null;
                foreach (Control item in c)
                {
                    ConfigureInputBase = (ucConfigureInputBase)item;
                    ConfigureInputBase.OnConfigureInputDataChanged -= OnConfigureInputItem_DataChangedEvent;
                }
            }
        }
        private void OnConfigureInputItem_DataChangedEvent(SStringBuilderItem SBItem)
        {
            if (OnStringBuilderItem_DataChangedEvent != null)
                OnStringBuilderItem_DataChangedEvent(SBItem);
        }
        #endregion
    }
}
