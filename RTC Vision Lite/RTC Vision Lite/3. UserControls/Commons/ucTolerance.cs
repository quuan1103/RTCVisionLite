//using HalconDotNet;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Classes.ProjectFunctions;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
//using RTCVision2101.PublicFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucTolerance : UserControl
    {
        public event CheckboxValueChangeEvent OnCheckboxValueChangeEvent;
        public event SValueChangeEvent OnSValueChangeEvent;
        private bool _LockEvents = true;
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
                    txtMinus.Enabled = chkEnable.Checked;
                    txtNominal.Enabled = chkEnable.Checked;
                    txtPlus.Enabled = chkEnable.Checked;
                }
                else
                {
                    LayoutPanel.ColumnStyles[0].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[0].Width = 0;
                    LayoutPanel.ColumnStyles[1].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[1].Width = 0;

                    chkEnable.Visible = false;
                    txtMinus.Enabled = true;
                    txtNominal.Enabled = true;
                    txtPlus.Enabled = true;
                    
                }
            }
        }

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
        private int _RTCCheckboxSize = 120;

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
        private bool _RTCChecked = false;

        public bool RTCChecked
        {
            get { return _RTCChecked; }
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
            get { return _RTCCheckboxPropertyName; }
            set
            {
                _RTCCheckboxPropertyName = value;
                _LockEvents = true;
                PreviewData();
                _LockEvents = false;
            }
        }
        private bool _RTCUseActual=false;

        public bool RTCUseActual
        {
            get { return _RTCUseActual; }
            set 
            { 
                _RTCUseActual = value;
                SetHeight();
                if (!value)
                {
                    txtActual.Text = "          ";
                }
                else
                {
                    txtActual.Text = "Actual";
                }
            }
        }

        private string _RTCPropertyName;

        public string RTCPropertyName
        {
            get { return _RTCPropertyName; }
            set 
            { 
                _RTCPropertyName = value;
                _LockEvents = true;
                PreviewData();
                _LockEvents = false;
            }
        }
        private cAction _RTCAction=null;
        
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

        private bool _RTCUseLabelAtTop = true;

        public bool RTCUseLabelAtTop
        {
            get { return _RTCUseLabelAtTop; }
            set
            {
                _RTCUseLabelAtTop = value;
                if (_RTCUseLabelAtTop)
                {
                    lblMinusTop.Visible = true;
                    lblNominalTop.Visible = true;
                    lblPlusTop.Visible = true;
                    SetHeight();
                }
                else
                {
                    lblMinusTop.Visible = false;
                    lblNominalTop.Visible = false;
                    lblPlusTop.Visible = false;
                    SetHeight();
                }
            }
        }
        private bool _RTCUseLabelAtLine = true;
        public bool RTCUseLabelAtLine
        {
            get { return _RTCUseLabelAtLine; }
            set
            {
                _RTCUseLabelAtLine = value;
                if (_RTCUseLabelAtLine)
                {
                    lblMinus.Visible = true;
                    lblNominal.Visible = true;
                    lblPlus.Visible = true;

                    LayoutPanel.ColumnStyles[2].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[2].Width = 60;
                    LayoutPanel.ColumnStyles[5].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[5].Width = 60;
                    LayoutPanel.ColumnStyles[8].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[8].Width = 60;

                    SetHeight();
                }
                else
                {
                    lblMinus.Visible = false;
                    lblNominal.Visible = false;
                    lblPlus.Visible = false;

                    LayoutPanel.ColumnStyles[2].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[2].Width = 0;
                    LayoutPanel.ColumnStyles[5].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[5].Width = 0;
                    LayoutPanel.ColumnStyles[8].SizeType = SizeType.Absolute;
                    LayoutPanel.ColumnStyles[8].Width = 0;

                    SetHeight();
                }
            }
        }
        private bool _RTCUseFeatures;

        public bool RTCUseFeatures
        {
            get { return _RTCUseFeatures; }
            set
            {
                _RTCUseFeatures = value;
                lblFeatures.Visible = _RTCUseFeatures;                
                SetHeight();
            }
        }
        private bool _RTCUseActualLabel;

        public bool RTCUseActualLabel
        {
            get { return _RTCUseActualLabel; }
            set
            {
                _RTCUseActualLabel = value;
                lblActual.Visible = _RTCUseActualLabel;
                SetHeight();
            }
        }
        private string _RTCFeaturesLabel = "Features";

        public string RTCFeaturesLabel
        {
            get { return _RTCFeaturesLabel; }
            set
            {
                _RTCFeaturesLabel = value;
                lblFeatures.Text = _RTCFeaturesLabel;
            }
        }
        private string _RTCMinusLabel = "Minus";
        public string RTCMinusLabel
        {
            get { return _RTCMinusLabel; }
            set
            {
                _RTCMinusLabel = value;
                lblMinus.Text = _RTCMinusLabel;
                lblMinusTop.Text = _RTCMinusLabel;
            }
        }
        private string _RTCNominalLabel = "Nominal";
        public string RTCNominalLabel
        {
            get { return _RTCNominalLabel; }
            set
            {
                _RTCNominalLabel = value;
                lblNominal.Text = _RTCNominalLabel;
                lblNominalTop.Text = _RTCNominalLabel;
            }
        }

        private string _RTCPlusLabel = "Plus";
        public string RTCPlusLabel
        {
            get { return _RTCPlusLabel; }
            set
            {
                _RTCPlusLabel = value;
                lblPlus.Text = _RTCPlusLabel;
                lblPlusTop.Text = _RTCPlusLabel;
            }
        }
        private bool _RTCAllowInfinityValue=true;

        public bool RTCAllowInfinityValue
        {
            get { return _RTCAllowInfinityValue; }
            set
            {
                _RTCAllowInfinityValue = value;
            }
        }
        
        public ucTolerance()
        {
            InitializeComponent();
            _LockEvents = false;
        }
        private void SetHeight()
        {
            LayoutPanel.RowStyles[0].Height = _RTCUseActualLabel || _RTCUseFeatures || _RTCUseLabelAtTop ? 30 : 0;
            if (LayoutPanel.RowStyles[0].Height == 0)
                this.Height = 30;
            else
                this.Height = 60;
        }
        /// <summary>
        /// Set data to control
        /// </summary>
        private void PreviewData()
        {
            try
            {
                if (RTCAction == null) return;

                _LockEvents = true;

                if (RTCUseCheckbox && RTCCheckboxPropertyName != string.Empty)
                {
                    SBool bEnable = (SBool)RTCAction.GetType().GetProperty(RTCCheckboxPropertyName).GetValue(RTCAction, null);
                    if (bEnable != null) { chkEnable.Checked = bEnable.rtcValue; }

                    txtMinus.Enabled = chkEnable.Checked;
                    txtNominal.Enabled = chkEnable.Checked;
                    txtPlus.Enabled = chkEnable.Checked;
                }

                if (RTCPropertyName != string.Empty)
                {
                    SListDouble htValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
                    if (htValue != null && htValue.rtcValue != null && htValue.rtcValue.Count >= 3)
                    {
                        GlobFuncs.SetTextEditValueByHtuple(txtMinus, htValue.rtcValue[0]);
                        GlobFuncs.SetTextEditValueByHtuple(txtNominal, htValue.rtcValue[1]);
                        GlobFuncs.SetTextEditValueByHtuple(txtPlus, htValue.rtcValue[2]);
                    }
                }
            }
            finally
            {
                _LockEvents = false;
            }
        }
        public void UpdateCheckboxValue(bool value)
        {
            _LockEvents = true;
            chkEnable.Checked = value;
            _LockEvents = false;
        }
        public void UpdateValue(List<double> _Value)
        {
            _LockEvents = true;
            if (_Value != null && _Value.Count >= 3)
            {
                GlobFuncs.SetTextEditValueByHtuple(txtMinus, _Value[0]);
                GlobFuncs.SetTextEditValueByHtuple(txtNominal, _Value[1]);
                GlobFuncs.SetTextEditValueByHtuple(txtPlus, _Value[2]);
            }
            _LockEvents = false;
        }
        private void GetValueToSHTupleFromTextEdit(SListDouble _Value)
        {
            if (_Value.rtcValue == null)
            {
               // _Value.rtcValue = new HalconDotNet.HTuple();
                _Value.rtcValue.Add(0);
                _Value.rtcValue.Add(0);
                _Value.rtcValue.Add(0);
            }
            if (txtMinus.Text.Trim().ToLower() == "inf")
                _Value.rtcValue[0] = 0;
            else
                _Value.rtcValue[0] = double.Parse(txtMinus.Text);

            if (txtNominal.Text.Trim().ToLower() == "inf")
                _Value.rtcValue[0] = 0;
            else
                _Value.rtcValue[1] = double.Parse(txtNominal.Text.ToString());

            if (txtPlus.Text.Trim().ToLower() == "inf")
                _Value.rtcValue[2] = 0;
            else
                _Value.rtcValue[2] = double.Parse(txtPlus.Text);
        }
        private void txtMinus_Validating(object sender, CancelEventArgs e)
        {
            double dvalue = 0;
            string sValue = txtMinus.Text.Trim().ToLower();
            if (((!RTCAllowInfinityValue) && (sValue == "infinity" || sValue == "inf")))
            {
                //txtMinus.EditValue = txtMinus.OldEditValue;
                e.Cancel = false;
            }
            else
            if (((RTCAllowInfinityValue) && (sValue == "infinity" || sValue == "inf")))
            {
                e.Cancel = false;
            }
            else
            if (!double.TryParse(sValue, out dvalue))
            {
               // txtMinus.EditValue = txtMinus.OldEditValue;
                e.Cancel = true;
            }
            else
            {
                //if(dvalue<0)
                //{
                //    dvalue = -dvalue;
                //    txtMinus.EditValue = dvalue;
                //}
                e.Cancel = false;
            }
        }
        private void txtMinus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

           // txtMinus.DoValidate();
           // if (txtMinus.ErrorText != string.Empty) return;
            if (RTCAction == null || RTCPropertyName == string.Empty) return;

            RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            SListDouble htValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
            if (htValue == null || htValue.rtcValue.Count >= 3)
            {
                GetValueToSHTupleFromTextEdit(htValue);

                eRTC.Value = htValue;
                if (OnSValueChangeEvent != null)
                {
                    OnSValueChangeEvent(sender, eRTC);
                }
            }
        }

        private void txtNominal_Validating(object sender, CancelEventArgs e)
        {
            double dvalue = 0;
            string sValue = txtNominal.Text.Trim().ToLower();
            if (sValue == "infinity" || sValue == "inf")
            {
                //txtNominal.Text = txtNominal.OldEditValue;
                e.Cancel = true;
            }
            else
            if (!double.TryParse(txtNominal.Text,out dvalue))
            {
                //txtNominal.EditValue = txtNominal.OldEditValue;
                e.Cancel = true;
            }
            else
            {
                //if (dvalue < 0)
                //{
                //    dvalue = -dvalue;
                //    txtNominal.EditValue = dvalue;
                //}
                e.Cancel = false;
            }
        }
        private void txtNominal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

           // txtNominal.DoValidate();
           // if (txtNominal.ErrorText != string.Empty) return;
            if (RTCAction == null || RTCPropertyName == string.Empty) return;

            RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            SListDouble htValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
            if (htValue == null || htValue.rtcValue.Count >= 3)
            {
                GetValueToSHTupleFromTextEdit(htValue);

                eRTC.Value = htValue;
                if (OnSValueChangeEvent != null)
                {
                    OnSValueChangeEvent(sender, eRTC);
                }
            }
        }

        private void txtPlus_Validating(object sender, CancelEventArgs e)
        {
            double dvalue = 0;
            string sValue = txtPlus.Text.Trim().ToLower();
            if (((!RTCAllowInfinityValue) && (sValue == "infinity" || sValue == "inf")))
            {
               // txtPlus.EditValue = txtPlus.OldEditValue;
                e.Cancel = false;
            }
            else
            if (((RTCAllowInfinityValue) && (sValue == "infinity" || sValue == "inf")))
            {
                e.Cancel = false;
            }
            else
            if (!double.TryParse(sValue, out dvalue))
            {
               // txtPlus.EditValue = txtPlus.OldEditValue;
                e.Cancel = true;
            }
            else
            {
                ///DATRUONG 06/09/2021 - Bỏ các đoạn này do yêu cầu mới có thể nhập số âm.
                //if (dvalue < 0)
                //{
                //    dvalue = -dvalue;
                //    txtPlus.EditValue = dvalue;
                //}
                e.Cancel = false;
            }
        }
        private void txtPlus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

           // txtPlus.DoValidate();
           // if (txtPlus.ErrorText != string.Empty) return;
            if (RTCAction == null || RTCPropertyName == string.Empty) return;

            RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            SListDouble htValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
            if (htValue == null || htValue.rtcValue.Count >= 3)
            {
                GetValueToSHTupleFromTextEdit(htValue);

                eRTC.Value = htValue;
                if (OnSValueChangeEvent != null)
                {
                    OnSValueChangeEvent(sender, eRTC);
                }
            }
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            txtMinus.Enabled = chkEnable.Checked;
            txtNominal.Enabled = chkEnable.Checked;
            txtPlus.Enabled = chkEnable.Checked;

            if (_LockEvents) return;

            if (RTCCheckboxPropertyName == "" || RTCAction == null) { return; }
            RTCE_CheckboxValueChangeEventArgs eRTC = new RTCE_CheckboxValueChangeEventArgs();
            eRTC.PropertyName = RTCCheckboxPropertyName;
            eRTC.Value = chkEnable.Checked;
            if (OnCheckboxValueChangeEvent != null)
            {
                OnCheckboxValueChangeEvent(sender, eRTC);
            }
        }
    }
}
