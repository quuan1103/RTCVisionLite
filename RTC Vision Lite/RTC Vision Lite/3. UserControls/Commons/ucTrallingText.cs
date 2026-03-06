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
    public delegate void TrallingTextValueChangedEvents(object sender);
    public partial class ucTrallingText : UserControl
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

        public TrallingTextValueChangedEvents OnTrallingTextValueChangedEvents;
        public ucTrallingText()
        {
            InitializeComponent();
            _RTCSBItem = null;
            PreviewData();
        }

        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                txtValue.Text = string.Empty;
                if (_RTCSBItem == null) return;
                txtValue.Text = _RTCSBItem.Tralling;
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }

        private void GetValueToItem()
        {
            if(_RTCSBItem == null)
                return;
            _RTCSBItem.Tralling = txtValue.Text.Trim().Replace("\r\n", "");
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
           if (GlobVar.LockEvents) return;
            GetValueToItem();
            if (OnTrallingTextValueChangedEvents != null)
                OnTrallingTextValueChangedEvents(this);
        }

        private void btnGetValue_Click(object sender, EventArgs e)
        {
            GlobFuncs.ShowFormASCIITable(txtValue);
        }
    }
}
