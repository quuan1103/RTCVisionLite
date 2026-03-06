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
    public delegate void InputDelimiterStringBuilderItemValueChangedEvents(object sender);
    public delegate void InputDelimiterValue1ChangedEvents(object sender, string propertyname);
    public partial class ucInputDelimiter : UserControl
    {
        #region PROPERTIES
        private string _RTCPropertyStandardValueName;

        public string RTCPropertyStandardValueName
        {
            get { return _RTCPropertyStandardValueName; }
            set { _RTCPropertyStandardValueName = value; }
        }

        private string _RTCPropertyCustomValueName;

        public string RTCPropertyCustomValueName
        {
            get { return _RTCPropertyCustomValueName; }
            set
            {
                _RTCPropertyCustomValueName = value;
                PreviewData();
            }
        }

        private string _RTCPropertyTypeName;

        public string RTCPropertyTypeName
        {
            get { return _RTCPropertyTypeName; }
            set
            {
                _RTCPropertyTypeName = value;
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

        private EDelimiterTypes _RTCPropertyType;
        /// <summary>
        /// Kiểu đối tượng nối
        /// </summary>
        public EDelimiterTypes RTCPropertyType
        {
            get
            {
                _RTCPropertyType = RadStandard.Checked ? EDelimiterTypes.Standard : EDelimiterTypes.Custom;
                return _RTCPropertyType;
            }
        }

        private EDelimiter _RTCPropertyStandardValue;
        /// <summary>
        /// Giá trị standard
        /// </summary>
        public EDelimiter RTCPropertyStandardValue
        {
            get
            {
                _RTCPropertyStandardValue = (EDelimiter)cbStandard.SelectedIndex;
                return _RTCPropertyStandardValue;
            }
        }
        private string _RTCPropertyCustomValue;
        /// <summary>
        /// Giá trị custom
        /// </summary>
        public string RTCPropertyCustomValue
        {
            get
            {
                _RTCPropertyCustomValue = txtCustom.Text;
                return _RTCPropertyCustomValue;
            }
        }
        #endregion

        public ucInputDelimiter()
        {
            InitializeComponent();
        }
        public InputDelimiterValue1ChangedEvents OnInputDelimiterValueChangedEvents;
        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                if (RTCAction == null) return;

                if (_RTCPropertyTypeName != string.Empty)
                {
                    SInt rtcvar = (SInt)RTCAction.GetType().GetProperty(_RTCPropertyTypeName).GetValue(RTCAction, null);
                    if (rtcvar != null)
                    {
                        EDelimiterTypes eInputDelimiterType = (EDelimiterTypes)rtcvar.rtcValue;

                        switch (eInputDelimiterType)
                        {
                            case EDelimiterTypes.Standard:
                                RadStandard.Checked = true;
                                RadCustomList.Checked = false;
                                break;
                            case EDelimiterTypes.Custom:
                                RadStandard.Checked = false;
                                RadCustomList.Checked = true;
                                break;
                        }

                        cbStandard.Enabled = RadStandard.Checked;
                        txtCustom.Enabled = RadCustomList.Checked;
                        btnCustom.Enabled = RadCustomList.Checked;
                    }

                    cbStandard.SelectedIndex = 0;
                    rtcvar = (SInt)RTCAction.GetType().GetProperty(_RTCPropertyStandardValueName).GetValue(RTCAction, null);
                    if (rtcvar != null)
                    {
                        EDelimiter eInputDelimiterStandardValue = (EDelimiter)rtcvar.rtcValue;
                        cbStandard.SelectedIndex = (int)eInputDelimiterStandardValue;
                    }

                    txtCustom.Text = string.Empty;
                    SString srtcvar = (SString)RTCAction.GetType().GetProperty(_RTCPropertyCustomValueName).GetValue(RTCAction, null);
                    if (srtcvar != null)
                        txtCustom.Text = srtcvar.rtcValue;
                }
            }
            finally
            {
                GlobVar.LockEvents = false;
            }

        }
        private void RadStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            try
            {
                GlobVar.LockEvents = true;
                RadCustomList.Checked = false;
                cbStandard.Enabled = true;
                txtCustom.Enabled = false;
                btnCustom.Enabled = false;

                if (OnInputDelimiterValueChangedEvents != null)
                    OnInputDelimiterValueChangedEvents(this, RTCPropertyTypeName);
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
                RadStandard.Checked = false;
                cbStandard.Enabled = false;
                txtCustom.Enabled = true;
                btnCustom.Enabled = true;
                if (OnInputDelimiterValueChangedEvents != null)
                    OnInputDelimiterValueChangedEvents(this, RTCPropertyTypeName);
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
        }
        private void cbStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            if (OnInputDelimiterValueChangedEvents != null)
                OnInputDelimiterValueChangedEvents(this, RTCPropertyStandardValueName);
        }
        private void txtCustom_EditValueChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents) return;
            if (OnInputDelimiterValueChangedEvents != null)
                OnInputDelimiterValueChangedEvents(this, RTCPropertyCustomValueName);
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            GlobFuncs.ShowFormASCIITable(txtCustom);
        }
    }
}
