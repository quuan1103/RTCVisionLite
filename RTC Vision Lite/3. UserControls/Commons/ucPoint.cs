using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
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
    public partial class ucPoint : UserControl
    {
        public event ButtonLinkClickEvent OnButtonLinkClickEvent;
        public event ButtonRemoveLinkClickEvent OnButtonRemoveLinkClickEvent;
        public event SValueChangeEvent OnSValueChangeEvent;

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
            txtX.Enabled = true;
            txtY.Enabled = true;
            cbItems.Visible = false;
            if (RTCAction != null && _RTCPropertyName != string.Empty && RTCAction.GetType().GetProperty(_RTCPropertyName).PropertyType.Name == "SHTuple")
            {
                SListDouble rtcvar = (SListDouble)RTCAction.GetType().GetProperty(_RTCPropertyName).GetValue(RTCAction, null);
                if (rtcvar != null && rtcvar.rtcValue != null && rtcvar.rtcValue.Count >= 2)
                {
                    txtX.Text = rtcvar.rtcValue[0].ToString();
                    txtY.Text = rtcvar.rtcValue[1].ToString();

                    //if (rtcvar.rtcValue.Length > 2)
                    //{
                    //    cbItems.Properties.Items.Clear();
                    //    int SoPoint = rtcvar.rtcValue.Length / 2;
                    //    for (int i = 0; i < SoPoint; i++)
                    //        cbItems.Properties.Items.Add((i + 1).ToString());
                    //    cbItems.SelectedIndex = 0;
                    //    cbItems.Visible = true;
                    //}
                    //else
                    //{
                    //    txtX.EditValue = (double)rtcvar.rtcValue.TupleSelect(0);
                    //    txtY.EditValue = (double)rtcvar.rtcValue.TupleSelect(1);
                    //}    
                }

                if (rtcvar != null && rtcvar.rtcIDRef != Guid.Empty)
                {
                    lblRef.Text = $"Source: +  {rtcvar.rtcRef}";
                    btnRemoveLink.Enabled = true;
                    txtX.Enabled = false;
                    txtY.Enabled = false;
                }
            }
        }
        public ucPoint()
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
        private void GetValueToSListDoubleFromTextEdit(SListDouble _Value)
        {
            if (_Value == null) return;
            if (_Value.rtcValue == null)
            {
                _Value.rtcValue = new List<double>() { };
                _Value.rtcValue.Add(0);
                _Value.rtcValue.Add(0);
                _Value.rtcValue.Add(0);
            }
            _Value.rtcValue[0] = double.Parse(txtX.Text);
            _Value.rtcValue[1] = double.Parse(txtY.Text);
        }

        private void txtX_Validating(object sender, CancelEventArgs e)
        {
            double dvalue = 0;
            string sValue = txtX.Text.Trim().ToLower();
            if (!double.TryParse(sValue, out dvalue))
            {
               
                e.Cancel = true;
            }
            else
            {
                if (dvalue < 0)
                {
                    dvalue = -dvalue;
                    txtX.Text = dvalue.ToString();
                }
                e.Cancel = false;
            }
        }

        private void txtY_Validating(object sender, CancelEventArgs e)
        {
            double dvalue = 0;
            string sValue = txtY.Text.Trim().ToLower();
            if (!double.TryParse(sValue, out dvalue))
            {
                
                e.Cancel = true;
            }
            else
            {
                if (dvalue < 0)
                {
                    dvalue = -dvalue;
                    txtY.Text = dvalue.ToString();
                }
                e.Cancel = false;
            }
        }

        private void txtX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            //txtX.DoValidate();
           // if (txtX.ErrorText != string.Empty) return;
            if (RTCAction == null || RTCPropertyName == string.Empty) return;

            RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            SListDouble htValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
            GetValueToSListDoubleFromTextEdit(htValue);
            if (htValue != null)
            {
                GetValueToSListDoubleFromTextEdit(htValue);

                eRTC.Value = htValue;
                if (OnSValueChangeEvent != null)
                {
                    OnSValueChangeEvent(sender, eRTC);
                }
            }
        }

        private void txtY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            //txtX.DoValidate();
            //if (txtY.ErrorText != string.Empty) return;
            if (RTCAction == null || RTCPropertyName == string.Empty) return;

            RTCE_SValueChangeEventArgs eRTC = new RTCE_SValueChangeEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            SListDouble htValue = (SListDouble)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
            GetValueToSListDoubleFromTextEdit(htValue);

            if (htValue != null && htValue.rtcValue.Count >= 2)
            {
                eRTC.Value = htValue;
                if (OnSValueChangeEvent != null)
                {
                    OnSValueChangeEvent(sender, eRTC);
                }
            }
        }

        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbItems.Items != null && cbItems.Items.Count > 0)
            {
                SListDouble rtcvar = (SListDouble)RTCAction.GetType().GetProperty(_RTCPropertyName).GetValue(RTCAction, null);
                int ItemIndex = cbItems.SelectedIndex;
                txtX.Text = rtcvar.rtcValue[ItemIndex * 2].ToString();
                txtY.Text = rtcvar.rtcValue[ItemIndex * 2 + 1].ToString();
            }
        }
        public void UpdateHTupleValue(List<double> _Value)
        {
            if (_Value != null && _Value.Count >= 2)
            {
                GlobFuncs.SetTextEditValueByHtuple(txtX, _Value[0]);
                GlobFuncs.SetTextEditValueByHtuple(txtY, _Value[1]);
            }
        }
    }
}

