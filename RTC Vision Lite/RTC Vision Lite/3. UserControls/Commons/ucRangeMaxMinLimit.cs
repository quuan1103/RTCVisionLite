using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucRangeMaxMinLimit : UserControl
    {
        public event SValueChangeEvent OnValueChangeEvents;

        int txtBeginValueLocationX = 0;
        public ucRangeMaxMinLimit()
        {
            InitializeComponent();
            //GlobFuncs.EnableTransparency(txtBeginValue);
            //GlobFuncs.EnableTransparency(txtEndValue);
            txtBeginValueLocationX = txtBeginValue.Location.X;


        }
        public void SetValue(SListDouble sListDouble)
        {
            if (sListDouble != null && sListDouble.rtcValue.Count == 4)
            {
                RTCMax = sListDouble.rtcValue[3];
                RTCMin = sListDouble.rtcValue[2];
                RTCEndValue = sListDouble.rtcValue[1];
                RTCBeginValue = sListDouble.rtcValue[0];
            }
        }
        private double _rtcMax = 100;
        public double RTCMax
        {
            get => _rtcMax;
            set
            {
                if (value <= _rtcMin)
                    return;
                _rtcMax = value;
                if (lblMax.InvokeRequired)
                    lblMax.Invoke(new MethodInvoker(() =>
                    {
                        lblMax.Text = _rtcMax.ToString();
                    }));
                else
                    lblMax.Text = _rtcMax.ToString();
                ValueChanged();

            }
        }
        private double _rtcMin = 0;
        public double RTCMin
        {
            get => _rtcMin;
            set
            {
                if (_rtcMax <= value)
                    return;
                _rtcMin = value;
                if (lblMin.InvokeRequired)
                    lblMin.Invoke(new MethodInvoker(() =>
                    {
                        lblMin.Text = _rtcMin.ToString();
                    }));
                else
                    lblMin.Text = _rtcMin.ToString();
                ValueChanged();

            }
        }
        private void ValueChanged()
        {
            double VungBienDong = RTCMax - RTCMin;
            hScrollBar.Minimum = 0;
            hScrollBar.Maximum = (int)((VungBienDong - (RTCEndValue - RTCBeginValue)) / RTCStepChange);
            hScrollBar.Value = (int)((RTCBeginValue - RTCMin) / RTCStepChange);
        } 
        private double _RTCEndValue = 25;
        /// <summary>
        /// Must be bigthan BeginValue
        /// </summary>
        [Browsable(true)]
        [Category("RTCVision2101")]
        [Description("Must be big than BeginValue.")]
        public double RTCEndValue
        {
            get { return _RTCEndValue; }
            set
            {
                _RTCEndValue = value;
                lblMaxR.Text = _RTCEndValue.ToString();
                txtEndValue.Text = _RTCEndValue.ToString();
                ValueChanged();
            }
        }
        private double _RTCBeginValue = 0;
        public double RTCBeginValue
        {
            get { return _RTCBeginValue; }
            set
            {
                if(value > _RTCEndValue)
                {
                    return;
                }
                _RTCBeginValue = value;
                lblMinR.Text = _RTCBeginValue.ToString();
                txtBeginValue.Text = _RTCBeginValue.ToString();
                ValueChanged();
            }
        }
        private double _RTCStepChange = 1;
        public double RTCStepChange
        {
            get { return _RTCStepChange; }
            set
            {
                _RTCStepChange = value;
                ValueChanged();
            }
        }
        private string _RTCPropertyName;
        public string RTCPropertyName
        {
            get { return _RTCPropertyName; }
            set
            {
                _RTCPropertyName = value;
                PreviewData();
            }
        }
        private string _RTCValuePropertyName;
        public string RTCValuePropertyName
        {
            get { return _RTCValuePropertyName; }
            set
            {
                _RTCValuePropertyName = value;
                PreviewData();
            }
        }

        private void PreviewData()
        {
            if (RTCAction != null && _RTCPropertyName != string.Empty)
            {
                PropertyInfo PropInfo = RTCAction.GetType().GetProperty(_RTCPropertyName);
                if(PropInfo.PropertyType.Name != "SListDouble")
                {
                    return;
                }
                SListDouble rtcvar = (SListDouble)RTCAction.GetType().GetProperty(_RTCPropertyName).GetValue(RTCAction, null);
                if( rtcvar != null && rtcvar.rtcValue != null)
                {
                    RTCBeginValue = rtcvar.rtcValue[0];
                    RTCEndValue = rtcvar.rtcValue[1];
                    RTCMin = rtcvar.rtcValue[2];
                    RTCMax = rtcvar.rtcValue[3];
                    RTCStepChange = 0.1;
                  
                }
            }
        }
        private cAction _RTCAction;
        public cAction RTCAction
        {
            get { return _RTCAction; }
            set
            {
                _RTCAction = value;
                PreviewData();
            }
        }
     

        private void txtEndValue_KeyDown(object sender, KeyEventArgs e)
        {
           switch (e.KeyCode)
            {
                case Keys.Enter:
                    GlobFuncs.ValidateTextDoubleValue(txtEndValue, _rtcMax, _RTCBeginValue, true, true);
                    txtEndValue.Visible = false;
                    lblMaxR.Text = txtEndValue.Text;
                    if (double.TryParse(txtEndValue.Text, out double dValue))
                        RTCEndValue = dValue;
                    else
                        RTCEndValue = 0;
                    RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
                    eRTC.PropertyName = RTCPropertyName;
                    SListDouble ldValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
                    ldValue.rtcValue[1] = RTCEndValue;
                    eRTC.Value = ldValue;
                    if(OnValueChangeEvents != null)
                    {
                        OnValueChangeEvents(sender, eRTC);
                    }
                    break;
                case Keys.Escape:
                    txtEndValue.Text = RTCEndValue.ToString();
                    txtEndValue.Visible = false;
                    break;
                default:
                    break;

            }
        }

        private void txtBeginValue_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    GlobFuncs.ValidateTextDoubleValue(txtBeginValue, _RTCEndValue, _rtcMin, true, true);
                    txtBeginValue.Visible = false;
                    lblMinR.Text = txtBeginValue.Text;
                    if (double.TryParse(txtBeginValue.Text, out double dValue))
                        RTCBeginValue = dValue;
                    else
                        RTCBeginValue = 0;
                    RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
                    eRTC.PropertyName = RTCPropertyName;
                    SListDouble ldValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
                    ldValue.rtcValue[0] = RTCBeginValue;
                    eRTC.Value = ldValue;
                    if (OnValueChangeEvents != null)
                    {
                        OnValueChangeEvents(sender, eRTC);
                    }
                    break;
                case Keys.Escape:
                    txtBeginValue.Text = RTCBeginValue.ToString();
                    txtBeginValue.Visible = false;
                    break;
                default:
                    break;

            }
        }

        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            double minVal = (hScrollBar.Value) * RTCStepChange;
            double maxVal = (hScrollBar.Value) * RTCStepChange + (RTCEndValue - RTCBeginValue);
            lblMinR.Text = minVal.ToString();
            lblMaxR.Text = maxVal.ToString();
            txtBeginValue.Text = minVal.ToString();
            txtEndValue.Text = maxVal.ToString();
            if (!GlobVar.LockEvents) timer1.Enabled = true;
        }

        private void lblMinR_DoubleClick(object sender, EventArgs e)
        {
            txtBeginValue.HideSelection = false;
            txtBeginValue.Visible = true;
            txtBeginValue.BringToFront();
            txtBeginValue.SelectAll();
            txtBeginValue.Focus();
        }

        private void lblMaxR_DoubleClick(object sender, EventArgs e)
        {
            txtEndValue.HideSelection = false;
            txtEndValue.Visible = true;
            txtEndValue.BringToFront();
            txtEndValue.SelectAll();
            txtEndValue.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            double minVal = 0;
            double maxVal = 0;
            if (hScrollBar.InvokeRequired)
                hScrollBar.Invoke(new MethodInvoker(() =>
               {
                   minVal = (hScrollBar.Value) * RTCStepChange;
                   maxVal = (hScrollBar.Value) * RTCStepChange + (RTCEndValue - RTCBeginValue);
               }));
            else
            {
                minVal = (hScrollBar.Value) * RTCStepChange;
                maxVal = (hScrollBar.Value) * RTCStepChange + (RTCEndValue - RTCBeginValue);
            }
            RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            SListDouble ldValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
            ldValue.rtcValue[0] = minVal;
            ldValue.rtcValue[1] = maxVal;
            eRTC.Value = ldValue;
            if (OnValueChangeEvents != null )
            {
                OnValueChangeEvents(sender, eRTC);
            }
        }

 
    }
}
