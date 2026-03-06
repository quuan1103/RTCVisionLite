using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.UserControls;
using RTCConst;
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
    public partial class ucObjectLink : UserControl
    {
        public event ButtonLinkClickEvent OnButtonLinkClickEvent;
        public event ButtonRemoveLinkClickEvent OnButtonRemoveLinkClickEvent;
        public event ButtonLinkEndSelectedPropertyLinkEvent OnButtonLinkEndSelectedPropertyLinkEvent;
        public ucObjectLink()
        {
            InitializeComponent();
            RTCAction = null;
            RTCPropertyName = string.Empty;
           

        }
        public string RTCCaption
        {
            get
            {
                return groupBox2.Text;
            }
            set
            {
                groupBox2.Text = value;
            }
        }
        private string _rtcPropertyName = "InputObject";
        public string RTCPropertyName
        {
            get => _rtcPropertyName;
            set
            {
                _rtcPropertyName = value;
                PreviewData();
            }
        }
        private cAction _Action;
        public cAction RTCAction
        {
            get { return _Action; }
            set
            {
                _Action = value;
                PreviewData();
            }
        }

        private void PreviewData()
        {
            lblRef.Text = "Source:";
            btnRemoveLink.Enabled = false;
            if (RTCAction != null && _rtcPropertyName != string.Empty)
            {
                RTCVariableType rtcvar = (RTCVariableType)RTCAction.GetType().GetProperty(_rtcPropertyName).GetValue(RTCAction, null);
                if (rtcvar != null && rtcvar.rtcIDRef != Guid.Empty)
                {
                    lblRef.Text = $"Source: + {rtcvar.rtcRef}";
                    btnRemoveLink.Enabled = true;
                }
            }
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
        public void ViewData()
        {

        }
    }
}
