using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public delegate void CheckboxValueChangeEvent(object sender, RTCE_CheckboxValueChangeEventArgs e);
    public delegate void SValueChangeEvent(object sender, RTCE_SValueChangeEventArgs e);
    public partial class ucRangeMaxMin : UserControl
    {
        public event CheckboxValueChangeEvent OnCheckboxValueChangeEvent;
        public event SValueChangeEvent OnSValueChangeEvent;
        private string _RTCCheckboxCaption = "Caption";

        public string RTCCheckboxCaption
        {
            get { return _RTCCheckboxCaption; }
            set
            {
                _RTCCheckboxCaption = value;
                chkEnable.Text = value;
            }
        }
        private bool _RTCIsLimit = false;
        public bool RTCIsLimit
        {
            get { return _RTCIsLimit; }
            set { _RTCIsLimit = value; }
        }
        private int _RTCCheckboxSize = 100;
        public int RTCCheckboxSize
        {
            get { return _RTCCheckboxSize; }
            set
            {
                _RTCCheckboxSize = value;
                if (_RTCUseCheckbox)
                {
                    LayoutPanel.ColumnStyles[0].Width = _RTCCheckboxSize;
                }
            }
        }
        private int _RTCTextboxSize = 50;
        public int RTCTextboxSize
        {
            get { return _RTCTextboxSize; }
            set
            {
                _RTCTextboxSize = value;
                LayoutPanel.ColumnStyles[3].Width = RTCTextboxSize;
                LayoutPanel.ColumnStyles[6].Width = RTCTextboxSize;
            }
        }
        private bool _RTCUseCheckbox = true;
        public bool RTCUseCheckbox
        {
            get { return _RTCUseCheckbox; }
            set
            {
                _RTCUseCheckbox = value;
                if (_RTCUseCheckbox)
                {
                    LayoutPanel.ColumnStyles[0].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[0].Width = _RTCCheckboxSize;
                    LayoutPanel.ColumnStyles[1].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[1].Width = 20;
                    chkEnable.Visible = true;
                    txtRangeMin.Enabled = chkEnable.Checked;
                    txtRangeMax.Enabled = chkEnable.Checked;
                }
                else
                {
                    LayoutPanel.ColumnStyles[0].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[0].Width = 0;
                    LayoutPanel.ColumnStyles[1].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[1].Width = 0;
                    chkEnable.Visible = false;
                    txtRangeMin.Enabled = true;
                    txtRangeMax.Enabled = true;
                }
            }
        }
        private bool _RTCUseActual = false;

        public bool RTCUseActual
        {
            get => _RTCUseActual;
            set
            {
                _RTCUseActual = value;
                SetHeight();
                txtActual.Text = !value ? "             " : "Actual";
            }
        }
        private bool _RTCChecked = false;
        public bool RTCChecked
        {
            get => _RTCChecked;
            set
            {
                _RTCChecked = value;
                if (_RTCUseCheckbox)
                {
                    chkEnable.Checked = _RTCChecked;
                }
            }
        }

        private string _RTCCheckboxPropertyName;

        public string RTCCheckboxPropertyName
        {
            get => _RTCCheckboxPropertyName;
            set
            {
                _RTCCheckboxPropertyName = value;
                _LockEvents = true;
                PreviewData();
                _LockEvents = false;
            }
        }
        private string _RTCValuePropertyName;
        public string RTCValuePropertyName
        {
            get => _RTCValuePropertyName;
            set
            {
                _RTCValuePropertyName = value;
                _LockEvents = true;
                PreviewData();
                _LockEvents = false;
            }
        }
        private string _RTCActualPropertyName;
        public string RTCActualPropertyName
        {
            get => _RTCActualPropertyName;
            set
            {
                _RTCActualPropertyName = value;
                _LockEvents = true;
                PreviewData();
                _LockEvents = false;
            }
        }
        private bool _UseMinMaxAtTop = true;

        public bool RTCUseMinMaxAtTop
        {
            get => _UseMinMaxAtTop;
            set
            {
                _UseMinMaxAtTop = value;
                if (_UseMinMaxAtTop)
                {
                    lblMinTop.Visible = true;
                    LayoutPanel.ColumnStyles[2].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[2].Width = 0;

                    lblMaxTop.Visible = true;
                    LayoutPanel.ColumnStyles[5].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[5].Width = 0;
                    SetHeight();
                }
                else
                {
                    lblMaxTop.Visible = false;
                    lblMinTop.Visible = false;
                    SetHeight();
                }
            }
        }

        private bool _RTCUseMinMaxAtLine = false;
        public bool RTCUseMinMaxAtLine
        {
            get => _RTCUseMinMaxAtLine;
            set
            {
                _RTCUseMinMaxAtLine = value;
                if (_RTCUseMinMaxAtLine)
                {
                    lblMin.Visible = true;
                    LayoutPanel.ColumnStyles[1].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[1].Width = 12;
                    LayoutPanel.ColumnStyles[2].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[2].Width = 35;
                    lblMax.Visible = true;
                    LayoutPanel.ColumnStyles[4].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[4].Width = 12;
                    LayoutPanel.ColumnStyles[5].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[5].Width = 35;
                    SetHeight();

                }
                else
                {
                    lblMin.Visible = false;
                    LayoutPanel.ColumnStyles[1].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[1].Width = 12;
                    LayoutPanel.ColumnStyles[2].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[2].Width = 0;
                    lblMax.Visible = false;
                    LayoutPanel.ColumnStyles[4].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[4].Width = 12;
                    LayoutPanel.ColumnStyles[5].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[5].Width = 0;
                    SetHeight();
                }
            }
        }

        private bool _UseFeatureLabel;
        public bool RTCUseFeatures
        {
            get => _UseFeatureLabel;
            set
            {
                _UseFeatureLabel = value;
                lblFeatures.Visible = _UseFeatureLabel;
                SetHeight();
            }
        }
        private bool _UseActualLabel;
        public bool RTCUseActualLabel
        {
            get => _UseActualLabel;
            set
            {
                _UseActualLabel = value;
                lblActual.Visible = _UseActualLabel;
                SetHeight();
            }
        }
        //public event SValueChangeEvent OnSValueChangeEvent;
        public ucRangeMaxMin()
        {
            InitializeComponent();
            if (_RTCUseCheckbox)
            {
                txtRangeMax.Enabled = chkEnable.Checked;
                txtRangeMin.Enabled = chkEnable.Checked;
            }
            else
            {
                txtRangeMax.Enabled = true;
                txtRangeMin.Enabled = true;
            }
            //RTCChecked = false;
            //txtRangeMin.Mask.
        }
        public void UpdateCheckboxValue (bool value)
        {
            _LockEvents = true;
            chkEnable.Checked = value;
            _LockEvents = false;
        }
        public void UpdateValue(List<double> value)
        {
            txtRangeMax.Text = "0";
            txtRangeMin.Text = "0";
            if (value == null || value.Count < 2) return;
            txtRangeMin.Text = value[0].ToString();
            txtRangeMax.Text = value[1].ToString();
            _LockEvents = false;
        }
        public void UpdateMixValue(List<object> value)
        {
            txtRangeMax.Text = "0";
            txtRangeMin.Text = "0";
            if (value == null || value.Count < 2) return;
            txtRangeMin.Text = value[0].ToString();
            txtRangeMax.Text = value[1].ToString();
            _LockEvents = false;
        }
        private bool _LockEvents = true;
        public void UpdateActualValue(List<double> value, int decimalPlaces = 3)
        {
            _LockEvents = true;
            GlobFuncs.SetLabelControlText(txtActual, string.Empty);
            if (value.Count != 0)
                GlobFuncs.SetLabelControlText(txtActual, GlobFuncs.Ve2Str(value), true);
            _LockEvents = false;
        }
        private void RTCEnable_CheckedChanged(object sender, EventArgs e)
        {
            txtRangeMin.Enabled = chkEnable.Checked;
            txtRangeMax.Enabled = chkEnable.Checked;
            if(_LockEvents)
            {
                return;
            }
            if (RTCCheckboxPropertyName == "" || RTCAction == null) return;
            RTCE_CheckboxValueChangeEventArgs eRTC = new RTCE_CheckboxValueChangeEventArgs();
            eRTC.PropertyName = RTCCheckboxPropertyName;
            eRTC.Value = chkEnable.Checked;
            if (OnCheckboxValueChangeEvent != null)
            {
                OnCheckboxValueChangeEvent(sender, eRTC);
            }    
        }

        private string _FeaturesLabel = "Features";
        public string RTCFeaturesLabel
        {
            get { return _FeaturesLabel; }
            set
            {
                _FeaturesLabel = value;
                lblFeatures.Text = _FeaturesLabel;
            }
        }
        private string _MinLabel = "Min";
        public string RTCMinLabel
        {
            get { return _MinLabel; }
            set
            {
                _MinLabel = value;
                lblMin.Text = _MinLabel;
                lblMinTop.Text = _MinLabel;
            }
        }
        private string _MaxLabel = "Max";
        public string RTCMaxLabel
        {
            get { return _MaxLabel; }
            set
            {
                _MaxLabel = value;
                lblMax.Text = _MaxLabel;
                lblMaxTop.Text = _MaxLabel;
            }
        }
        private bool _RTCAllowInfinityMaxValue = true;
        public bool RTCAllowInfinityMaxValue
        {
            get { return _RTCAllowInfinityMaxValue; }
            set
            {
                _RTCAllowInfinityMaxValue = value;
            }
        }
        private string _RTCEditMask = "n2";
        public string RTCEditMask
        {
            get { return _RTCEditMask; }
            set
            {
                MaskedTextBox maskedTextBox1 = new MaskedTextBox();
                _RTCEditMask = value;
                txtRangeMin.Mask = RTCEditMask;
                if(!RTCAllowInfinityMaxValue)
                {
                    this.txtRangeMax.Mask = RTCEditMask;
                }    
            }
        }
        private bool _RTCUseMaskAsDisplayFormat = false;
        public bool RTCUseMaskAsDisplayFormat
        {
            get { return _RTCUseMaskAsDisplayFormat; }
            set
            {
                _RTCUseMaskAsDisplayFormat = value;
                if(!value )
                {
                    txtRangeMin.Mask = null;
                    if(!RTCAllowInfinityMaxValue)
                    {
                        txtRangeMax.Mask = "";
                    }    
                }    
            }
        }
        private void PreviewData()
        {
            try
            {
               
                if (RTCAction == null)
                {
                    return;
                }
                _LockEvents = true;
                if (RTCUseCheckbox && _RTCCheckboxPropertyName != String.Empty)
                {
                    SBool bEnable = (SBool)RTCAction.GetType().GetProperty(RTCCheckboxPropertyName).GetValue(RTCAction, null);
                    if (bEnable != null)
                    {
                        chkEnable.Checked = bEnable.rtcValue;
                    }
                    txtRangeMin.Enabled = chkEnable.Checked;
                    txtRangeMax.Enabled = chkEnable.Checked;
                }
                if (RTCValuePropertyName != string.Empty)
                {
                    SListString lsValue = null;
                    SListDouble ldValue = null;
                    SListObject loValue = null;


                    string propertyType = RTCAction.GetType().GetProperty(RTCValuePropertyName).PropertyType.Name;
                    switch(propertyType)
                    {
                        case "SListString":
                            {
                                 lsValue = (SListString)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                                break;
                            }
                        case "SListDouble":
                            {
                                ldValue = (SListDouble)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                                break;
                            }
                        case "SListObject":
                            {
                                loValue = (SListObject)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                                break;
                            }
                    }    
                   
                     
                    if (lsValue != null && lsValue.rtcValue != null && lsValue.rtcValue.Count >= 2)
                    {
                        txtRangeMin.Text = lsValue.rtcValue[0];
                        txtRangeMax.Text = lsValue.rtcValue[1];
                    }
                    if (ldValue != null && ldValue.rtcValue != null && ldValue.rtcValue.Count >= 2)
                    {
                        txtRangeMin.Text = ldValue.rtcValue[0].ToString();
                        txtRangeMax.Text = ldValue.rtcValue[1].ToString();
                    }
                    if (loValue != null && loValue.rtcValue != null && loValue.rtcValue.Count >= 2)
                    {
                        txtRangeMin.Text = loValue.rtcValue[0].ToString();
                        txtRangeMax.Text = loValue.rtcValue[1].ToString();
                    }

                }
                if (RTCUseActual && !String.IsNullOrEmpty(RTCActualPropertyName))
                {
                    RTCVariableType variable = (RTCVariableType)RTCAction.GetType().GetProperty(RTCActualPropertyName)?.GetValue(RTCAction, null);
                    if (variable != null)
                    {
                        switch (variable.GetType().Name)
                        {
                            case nameof(SInt):
                                {
                                    SInt intValue = (SInt)RTCAction.GetType().GetProperty(RTCActualPropertyName)?.GetValue(RTCAction, null);
                                    txtActual.Text = intValue.rtcValue.ToString();
                                    break;
                                }
                            case nameof(SDouble):
                                {
                                    SDouble doubleValue = (SDouble)RTCAction.GetType().GetProperty(RTCActualPropertyName)?.GetValue(RTCAction, null);
                                    txtActual.Text = doubleValue.rtcValue.ToString();
                                    break;
                                }
                            case nameof(SListDouble):
                                {
                                    SListDouble ldValue = (SListDouble)RTCAction.GetType().GetProperty(RTCActualPropertyName)?.GetValue(RTCAction, null);
                                    if (ldValue != null && ldValue.rtcValue != null && ldValue.rtcValue.Count >= 1)
                                        txtActual.Text = GlobFuncs.ListDouble2Str(ldValue.rtcValue);
                                    break;
                                }
                        }
                    }
                }
            }
        
            finally
            {
                _LockEvents = false;
            }
        }
        private cAction _RTCAction = null;
        public cAction RTCAction
        {
            get { return _RTCAction; }
            set
            {
                _RTCAction = value;
                _LockEvents = true;
                PreviewData();
                _LockEvents = false;
            }
        }
      
      
        private void SetHeight()
        {
            LayoutPanel.RowStyles[0].Height = _UseActualLabel || _UseFeatureLabel || _UseMinMaxAtTop ? 30 : 0;
            if (LayoutPanel.RowStyles[0].Height == 0)
                this.Height = 30;
            else
                this.Height = 60;
        }




        private void RTCRangeMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (RTCAction != null && RTCValuePropertyName != String.Empty)
                {
                    RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
                    eRTC.PropertyName = RTCValuePropertyName;
                    //var tesstt = RTCAction.GetType();

                    switch (RTCAction.GetType().GetProperty(RTCValuePropertyName).PropertyType.Name)
                    {
                        case nameof(SListDouble):
                            {
                                var ldValue = (SListDouble)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                                if (ldValue != null && (ldValue.rtcValue == null || (ldValue.rtcValue != null && ldValue.rtcValue.Count >= 2)))
                                {
                                    if (ldValue.rtcValue == null)
                                    {
                                        ldValue.rtcValue = new List<double> { };
                                        ldValue.rtcValue.Add(0);
                                        ldValue.rtcValue.Add(0);
                                    }
                                    if (txtRangeMin.Text == "Inf")
                                    {
                                        //ldValue.rtcValue[0] = "inf";
                                    }
                                    else
                                    {
                                        ldValue.rtcValue[0] = double.Parse(txtRangeMin.Text);
                                    }
                                    if (txtRangeMax.Text == "Inf")
                                    {
                                        //ldValue.rtcValue[1] = "inf";
                                    }
                                    else
                                    {
                                        ldValue.rtcValue[1] = double.Parse(txtRangeMax.Text);
                                    }
                                    chkEnable.Focus();
                                    eRTC.Value = ldValue;
                                    if (OnSValueChangeEvent != null)
                                    {
                                        OnSValueChangeEvent(sender, eRTC);
                                    }
                                }
                                break;
                            }
                        case nameof(SListObject):
                            {
                                var ldValue = (SListObject)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                                if (ldValue != null && (ldValue.rtcValue == null || (ldValue.rtcValue != null && ldValue.rtcValue.Count >= 2)))
                                {
                                    if (ldValue.rtcValue == null)
                                    {
                                        ldValue.rtcValue = new List<Object> { };
                                        ldValue.rtcValue.Add(0);
                                        ldValue.rtcValue.Add(0);
                                    }
                                    if (txtRangeMin.Text == "Inf")
                                    {
                                        ldValue.rtcValue[0] = "inf";
                                    }
                                    else
                                    {
                                        ldValue.rtcValue[0] = double.Parse(txtRangeMin.Text);
                                    }
                                    if (txtRangeMax.Text.ToLower() == "inf")
                                    {
                                        ldValue.rtcValue[1] = "inf";
                                    }
                                    else
                                    {
                                        ldValue.rtcValue[1] = double.TryParse(txtRangeMax.Text, out double Value) ? Value : 0;
                                    }
                                    eRTC.ObjectValue = ldValue;
                                    if (OnSValueChangeEvent != null)
                                    {
                                        OnSValueChangeEvent(sender, eRTC);
                                    }
                                }
                                break;
                            }
                        default:
                            break;
                    }
                   
                }
            }
        }
        private void RTCRangeMin_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (RTCAction != null && RTCValuePropertyName != String.Empty)
                {
                    RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
                    eRTC.PropertyName = RTCValuePropertyName;
                    //var tesstt = RTCAction.GetType();

                    switch (RTCAction.GetType().GetProperty(RTCValuePropertyName).PropertyType.Name)
                    {
                        case nameof(SListDouble):
                            {
                                var ldValue = (SListDouble)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                                if (ldValue != null && (ldValue.rtcValue == null || (ldValue.rtcValue != null && ldValue.rtcValue.Count >= 2)))
                                {
                                    if (ldValue.rtcValue == null)
                                    {
                                        ldValue.rtcValue = new List<double> { };
                                        ldValue.rtcValue.Add(0);
                                        ldValue.rtcValue.Add(0);
                                    }
                                    if (txtRangeMin.Text == "Inf")
                                    {
                                        //ldValue.rtcValue[0] = "inf";
                                    }
                                    else
                                    {
                                        ldValue.rtcValue[0] = double.Parse(txtRangeMin.Text);

                                    }
                                    if (txtRangeMax.Text == "Inf")
                                    {
                                        //ldValue.rtcValue[1] = "inf";
                                    }
                                    else
                                    {
                                        ldValue.rtcValue[1] = double.Parse(txtRangeMax.Text);

                                    }
                                    eRTC.Value = ldValue;
                                    if (OnSValueChangeEvent != null)
                                    {
                                        OnSValueChangeEvent(sender, eRTC);
                                    }
                                }
                                break;
                            }
                        case nameof(SListObject):
                            {
                                var ldValue = (SListObject)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                                if (ldValue != null && (ldValue.rtcValue == null || (ldValue.rtcValue != null && ldValue.rtcValue.Count >= 2)))
                                {
                                    if (ldValue.rtcValue == null)
                                    {
                                        ldValue.rtcValue = new List<Object> { };
                                        ldValue.rtcValue.Add(0);
                                        ldValue.rtcValue.Add(0);
                                    }
                                    if (txtRangeMin.Text == "Inf")
                                    {
                                        ldValue.rtcValue[0] = "inf";
                                    }
                                    else
                                    {
                                        ldValue.rtcValue[0] = double.Parse(txtRangeMin.Text);

                                    }
                                    if (txtRangeMax.Text == "Inf")
                                    {
                                        //ldValue.rtcValue[1] = "inf";
                                    }
                                    else
                                    {
                                        ldValue.rtcValue[1] = double.Parse(txtRangeMax.Text);

                                    }

                                    eRTC.ObjectValue = ldValue;
                                    if (OnSValueChangeEvent != null)
                                    {
                                        OnSValueChangeEvent(sender, eRTC);
                                    }
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
        private void RTCRangeMin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            double dvalue = 0;
            if (txtRangeMin.Text.ToLower() == "infinity" || txtRangeMin.Text.ToLower() == "inf")
            {
                e.Cancel = false;
            }
            else
            if (double.TryParse(txtRangeMin.Text, out dvalue))
            {
                if (RTCIsLimit)
                {
                    SListDouble dbValue = (SListDouble)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                    if (dbValue != null && (dbValue.rtcValue == null || (dbValue.rtcValue != null && dbValue.rtcValue.Count >= 4)))
                    {
                        if (GlobFuncs.Ve2Str(dbValue.rtcValue[2]).ToString().ToLower() != "infinity" &&
                            GlobFuncs.Ve2Str(dbValue.rtcValue[2]).ToString().ToLower() != "inf")
                        {
                            if (double.TryParse(GlobFuncs.Ve2Str(dbValue.rtcValue[2]), out double dvaluemin))
                                if (dvalue < dvaluemin)
                                {
                                    txtRangeMin.Text = dvaluemin.ToString();
                                    e.Cancel = false;
                                    return;

                                }
                        }
                    }

                }
                if (txtRangeMax.Text != cPropertyValue.Inf)
                {
                    if (dvalue > double.Parse(txtRangeMax.Text))
                    {
                        e.Cancel = true;
                        
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void RTCRangeMax_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            double dvalue = 0;
            if (txtRangeMax.Text.ToLower() == "infinity" || txtRangeMin.Text.ToLower() == "inf")
            {
                if (RTCIsLimit)
                {
                    SListDouble ldValue = (SListDouble)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                    if (ldValue != null && (ldValue.rtcValue == null || (ldValue.rtcValue != null && ldValue.rtcValue.Count >=4 )))
                    {
                        if (GlobFuncs.Ve2Str(ldValue.rtcValue[3]).ToLower() != "infinity" && 
                            GlobFuncs.Ve2Str(ldValue.rtcValue[3]).ToLower() != "inf")
                        {
                            if (double.TryParse(GlobFuncs.Ve2Str(ldValue.rtcValue[3]), out double dvalueMax))
                            {
                                txtRangeMax.Text = dvalueMax.ToString();
                                e.Cancel = false;
                                return;
                            }    
                        }    
                    }    
                }    
            }
            else
            if (double.TryParse(txtRangeMax.Text, out dvalue))
            {
                if (RTCIsLimit)
                {
                    SListDouble dbValue = (SListDouble)RTCAction.GetType().GetProperty(RTCValuePropertyName).GetValue(RTCAction, null);
                    if (dbValue != null && (dbValue.rtcValue == null || (dbValue.rtcValue != null && dbValue.rtcValue.Count >= 4)))
                    {
                        if (GlobFuncs.Ve2Str(dbValue.rtcValue[3]).ToString().ToLower() != "infinity" &&
                            GlobFuncs.Ve2Str(dbValue.rtcValue[3]).ToString().ToLower() != "inf")
                        {
                            if (double.TryParse(GlobFuncs.Ve2Str(dbValue.rtcValue[3]), out double dvaluemax))
                                if (dvalue > dvaluemax)
                                {
                                    txtRangeMin.Text = dvaluemax.ToString();
                                    e.Cancel = false;
                                    return;

                                }
                        }
                    }

                }
                if (dvalue < double.Parse(txtRangeMin.Text))
                {
                        e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
