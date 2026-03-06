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
    public partial class ucInputDelimiterStringBulderItem :UserControl
    {
        private int OldWidth = 110;
        #region PROPERTIES
        private string _RTCCaption;

        public string RTCCaption
        {
            get { return lblCaption.Text; }
            set
            {
                _RTCCaption = value;
                lblCaption.Text = _RTCCaption;
            }
        }
        private SStringBuilderItem _RTCSBItem;
        public SStringBuilderItem RTCSBItem
        {
            get { return _RTCSBItem; }
            set
            {
                _RTCSBItem = value;
                PreviewData();
            }
        }
        private bool _RTCHideCustomButton = false;

        public bool RTCHideCustomButton
        {
            get { return _RTCHideCustomButton; }
            set
            {
                _RTCHideCustomButton = value;
                if (_RTCHideCustomButton)
                {
                    btnCustomListDelimiter.Visible = false;
                    OldWidth = txtCustomListDelimiter.Width;
                    txtCustomListDelimiter.Width = cbStandardListDelimiter.Width;
                }
                else
                {
                    btnCustomListDelimiter.Visible = true;
                    txtCustomListDelimiter.Width = OldWidth;
                }
            }
        }

        #endregion
        public InputDelimiterStringBuilderItemValueChangedEvents OnInputDelimiterValueChangedEvents;
        public ucInputDelimiterStringBulderItem()
        {
            InitializeComponent();
            _RTCSBItem = null;
            PreviewData();
            LayoutControls();
        }
        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                RadStandardListDelimiter.Checked = true;
                RadCustomListDelimiter.Checked = false;
                cbStandardListDelimiter.Enabled = RadStandardListDelimiter.Checked;
                txtCustomListDelimiter.Enabled = RadCustomListDelimiter.Checked;
                btnCustomListDelimiter.Enabled = RadCustomListDelimiter.Checked;
                cbStandardListDelimiter.SelectedIndex = 1;
                txtCustomListDelimiter.Text = string.Empty;

                if (_RTCSBItem == null) return;

                switch (_RTCSBItem.ElementDelimiter.DelimiterTypes)
                {
                    case EDelimiterTypes.Standard:
                        RadStandardListDelimiter.Checked = true;
                        RadCustomListDelimiter.Checked = false;
                        break;
                    case EDelimiterTypes.Custom:
                        RadStandardListDelimiter.Checked = false;
                        RadCustomListDelimiter.Checked = true;
                        break;
                }

                cbStandardListDelimiter.Enabled = RadStandardListDelimiter.Checked;
                txtCustomListDelimiter.Enabled = RadCustomListDelimiter.Checked;
                btnCustomListDelimiter.Enabled = RadCustomListDelimiter.Checked;

                cbStandardListDelimiter.SelectedIndex = (int)_RTCSBItem.ElementDelimiter.StandardValue;
                txtCustomListDelimiter.Text = _RTCSBItem.ElementDelimiter.CustomValue;
            }
            finally
            {
                GlobVar.LockEvents = false;
            }

        }
        private void LayoutControls_DisableAll()
        {
            var c = GlobFuncs.GetAllControls(this);
            if (c != null && c.Count() > 0)
                foreach (Control item in c)
                    item.Enabled = false;
        }
        private void LayoutControls_EnableAll()
        {
            var c = GlobFuncs.GetAllControls(this);
            if (c != null && c.Count() > 0)
                foreach (Control item in c)
                    item.Enabled = true;
        }
        public void LayoutControls()
        {
            //Disable toàn bộ control
            LayoutControls_DisableAll();
            if (_RTCSBItem == null) return;
            LayoutControls_EnableAll();
            cbStandardListDelimiter.Enabled = RadStandardListDelimiter.Checked;
            txtCustomListDelimiter.Enabled = RadCustomListDelimiter.Checked;
            btnCustomListDelimiter.Enabled = RadCustomListDelimiter.Checked;
        }
        private void GetValueToItem()
        {
            if (_RTCSBItem == null) return;
            _RTCSBItem.ElementDelimiter.DelimiterTypes = RadStandardListDelimiter.Checked ? EDelimiterTypes.Standard : EDelimiterTypes.Custom;
            _RTCSBItem.ElementDelimiter.StandardValue = (EDelimiter)cbStandardListDelimiter.SelectedIndex;
            _RTCSBItem.ElementDelimiter.CustomValue = txtCustomListDelimiter.Text;
        }
        private void RadStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            try
            {
                GlobVar.LockEvents = true;
                cbStandardListDelimiter.Enabled = true;
                RadCustomListDelimiter.Checked = false;
                txtCustomListDelimiter.Enabled = false;
                btnCustomListDelimiter.Enabled = false;

                GetValueToItem();
                if (OnInputDelimiterValueChangedEvents != null)
                    OnInputDelimiterValueChangedEvents(this);
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        private void RadCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            try
            {
                GlobVar.LockEvents = true;
                RadStandardListDelimiter.Checked = false;
                cbStandardListDelimiter.Enabled = false;
                txtCustomListDelimiter.Enabled = true;
                btnCustomListDelimiter.Enabled = true;
                GetValueToItem();
                if (OnInputDelimiterValueChangedEvents != null)
                    OnInputDelimiterValueChangedEvents(this);
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        private void cbStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            GetValueToItem();
            if (OnInputDelimiterValueChangedEvents != null)
                OnInputDelimiterValueChangedEvents(this);
        }
        private void txtCustom_EditValueChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            GetValueToItem();
            if (OnInputDelimiterValueChangedEvents != null)
                OnInputDelimiterValueChangedEvents(this);
        }

        private void RadStandardListDelimiter_Validating(object sender, CancelEventArgs e)
        {
            if (RadCustomListDelimiter.Checked && RadStandardListDelimiter.Checked) e.Cancel = true; else e.Cancel = false;
        }

        private void RadCustomListDelimiter_Validating(object sender, CancelEventArgs e)
        {
            if (RadCustomListDelimiter.Checked && RadStandardListDelimiter.Checked) e.Cancel = true; else e.Cancel = false;
        }

        private void btnCustomListDelimiter_Click(object sender, EventArgs e)
        {
            GlobFuncs.ShowFormASCIITable(txtCustomListDelimiter);
        }
    }

}
