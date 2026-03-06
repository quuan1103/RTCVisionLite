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
    public delegate void LeadingTextValueChangedEvents(object sender);

    public partial class ucLeadingText : UserControl
    {
        private string _RTCCaption;

        public string RTCCaption
        {
            get => lblCaption.Text;
            set
            {
                _RTCCaption = value;
                lblCaption.Text = _RTCCaption;
            }
        }

        public float RTCCaptionWidth
        {
            get => tlpMain.ColumnStyles[0].Width;
            set => tlpMain.ColumnStyles[0].Width = value;
        }

        private SStringBuilderItem _RTCSBItem;

        public SStringBuilderItem RTCSBItem
        {
            get => _RTCSBItem;
            set
            {
                _RTCSBItem = value;
                PreviewData();
            }
        }

        public LeadingTextValueChangedEvents OnLeadingTextValueChangedEvents;

        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                txtValue.Text = string.Empty;
                if (_RTCSBItem == null) return;
                txtValue.Text = _RTCSBItem.Leading;
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        public ucLeadingText()
        {
            InitializeComponent();
            _RTCSBItem = null;
            PreviewData();
        }

        private void GetValueToItem()
        {
            if (_RTCSBItem == null)
                return;
           _RTCSBItem.Leading = txtValue.Text.Trim().Replace("\r\n", "");
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            GetValueToItem();
            if (OnLeadingTextValueChangedEvents != null)
                OnLeadingTextValueChangedEvents(this);
        }

        private void btnGetValue_Click(object sender, EventArgs e)
        {
            //GlobFuncs.Show
        }
    }
}
