//using HalconDotNet;
using RTC_Vision_Lite.Classes;
using RTCConst;
using RTC_Vision_Lite.PublicFunctions;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using RTC_Vision_Lite.UserControls;
using System.Collections.Generic;

namespace RTC_Vision_Lite.UserControls
{
    //public delegate void ButtonLinkClickEvent(object sender, RTCE_ButtonLinkClickEventArgs e);
    //public delegate void ButtonRemoveLinkClickEvent(object sender, RTCE_ButtonRemoveLinkClickEventArgs e);
    public partial class ucLine : UserControl
    {
        public event ButtonLinkClickEvent OnButtonLinkClickEvent;
        public event ButtonRemoveLinkClickEvent OnButtonRemoveLinkClickEvent;
        public event SValueChangeEvent OnSHTupleValueChangeEvent;

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
        private void PreviewData()
        {
            lblRef.Text = "Source:";
            btnRemoveLink.Enabled = false;
            txtX1.Enabled = true;
            txtY1.Enabled = true;
            txtX2.Enabled = true;
            txtY2.Enabled = true;
            if (RTCAction != null && _RTCPropertyName != string.Empty && RTCAction.GetType().GetProperty(_RTCPropertyName).PropertyType.Name == "SHTuple")
            {
                SListDouble rtcvar = (SListDouble)RTCAction.GetType().GetProperty(_RTCPropertyName).GetValue(RTCAction, null);
                if (rtcvar != null && rtcvar.rtcValue != null && rtcvar.rtcValue.Count >= 4)
                {
                    txtX1.Text = rtcvar.rtcValue[0].ToString();
                    txtY1.Text = rtcvar.rtcValue[1].ToString();
                    txtX2.Text = rtcvar.rtcValue[2].ToString();
                    txtY2.Text = rtcvar.rtcValue[3].ToString();
                }

                if (rtcvar != null && rtcvar.rtcIDRef != Guid.Empty)
                {
                    lblRef.Text = "Source: <color=0, 0, 255>" + rtcvar.rtcRef + "</color>";
                    btnRemoveLink.Enabled = true;
                    txtX1.Enabled = false;
                    txtY1.Enabled = false;
                    txtX2.Enabled = false;
                    txtY2.Enabled = false;
                }
            }
        }
        public ucLine()
        {
            InitializeComponent();
            RTCAction = null;
            RTCPropertyName = string.Empty;
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (RTCPropertyName == "" || RTCAction == null) { return; }
            RTCE_ButtonLinkClickEventArgs eRTC = new RTCE_ButtonLinkClickEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            if (OnButtonLinkClickEvent != null)
            {
                OnButtonLinkClickEvent(sender, eRTC);
            }
        }

        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            if (RTCPropertyName == "" || RTCAction == null) { return; }
            RTCE_ButtonRemoveLinkClickEventArgs eRTC = new RTCE_ButtonRemoveLinkClickEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            if (OnButtonRemoveLinkClickEvent != null)
            {
                OnButtonRemoveLinkClickEvent(sender, eRTC);
            }
        }
        private void GetValueToSHTupleFromTextEdit(SListDouble _Value)
        {
            if (_Value.rtcValue == null)
            {
                _Value.rtcValue = new List<double>() { };
                _Value.rtcValue.Add(0);
                _Value.rtcValue.Add(0);
                _Value.rtcValue.Add(0);
                _Value.rtcValue.Add(0);
            }
            _Value.rtcValue[0] = double.Parse(txtX1.Text);
            _Value.rtcValue[1] = double.Parse(txtY1.Text);
            _Value.rtcValue[2] = double.Parse(txtX2.Text);
            _Value.rtcValue[3] = double.Parse(txtY2.Text);
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            TextBox txt = (TextBox)sender;

           // txt.DoValidate();
            //if (txt.ErrorText != string.Empty) return;
            if (RTCAction == null || RTCPropertyName == string.Empty) return;

            RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            SListDouble htValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
            if (htValue == null || htValue.rtcValue.Count >= 4)
            {
                GetValueToSHTupleFromTextEdit(htValue);

                eRTC.Value = htValue;
                if (OnSHTupleValueChangeEvent != null)
                {
                    OnSHTupleValueChangeEvent(sender, eRTC);
                }
            }
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            double dvalue = 0;
            string sValue = txt.Text.Trim().ToLower();
            if (!double.TryParse(sValue, out dvalue))
            {
                //txt.Text = txt.OldEditValue;
                e.Cancel = true;
            }
            else
            {
                if (dvalue < 0)
                {
                    dvalue = -dvalue;
                    txt.Text = dvalue.ToString();
                }
                e.Cancel = false;
            }
        }
        public void UpdateHTupleValue(List<double> _Value)
        {
            if (_Value != null && _Value.Count >= 4)
            {
                GlobFuncs.SetTextEditValueByHtuple(txtX1, _Value[0]);
                GlobFuncs.SetTextEditValueByHtuple(txtY1, _Value[1]);
                GlobFuncs.SetTextEditValueByHtuple(txtX2, _Value[2]);
                GlobFuncs.SetTextEditValueByHtuple(txtY2, _Value[3]);
            }
        }
    }
}
