using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucCameraSettings : UserControl
    {
        
        public ucCameraSettings()
        {
            
            InitializeComponent();
            GroupActions = null;
            tcMainSettings.SelectedIndex = 0;
        }
        private cGroupActions _groupActions;
        public cGroupActions GroupActions
        {
            get => _groupActions;
            set
            {
                _groupActions = value;
                LoadData();
            }
        }
        private bool HaveData()
        {
            return _groupActions != null && _groupActions.SourceImageSettings != null &&
                _groupActions.SourceImageSettings.CameraSettings.IsConnected;
        }
        internal void LoadData()
        {
            if (!HaveData())
            {
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            cCameraSettings cameraSettings = _groupActions.SourceImageSettings.CameraSettings;
            // Bắt đầu lấy dữ liệu
            switch (cameraSettings.SdkMode)
            {
                case ESdkModes.Hikrobot:
                case ESdkModes.HikrobotGenTL:
                    {
                        GlobFuncs.HIK_SetTriggerDelaytoNumberic(cameraSettings.HikCamera, txtTriggerDelayRaw);
                        GlobFuncs.HIK_SetTriggerDelaytoComboBox(cameraSettings.HikCamera, cbTriggerSource);
                        GlobFuncs.HIK_SetTriggerModetoComboBox(cameraSettings.HikCamera, cbTriggerMode);
                        GlobFuncs.HIK_SetTriggerActivitionToComboBox(cameraSettings.HikCamera, cbTriggerActivation);
                        GlobFuncs.HIK_SetFloatValueToNumberic(cameraSettings.HikCamera, cParamName.ExposureTimeAbs, txtExposureTimeRaw);
                        GlobFuncs.HIK_SetFloatValueToNumberic(cameraSettings.HikCamera, cParamName.Gain, txtGainRaw);
                        GlobFuncs.HIK_SetExposureModeToComboBox(cameraSettings.HikCamera, cbExposureMode);
                        GlobFuncs.HIK_SetAcquisitionModeToComBoBox(cameraSettings.HikCamera, cbAcquisitionMode);
                        GlobFuncs.HIK_SetPixelFormatToComboBox(cameraSettings.HikCamera, cbPixelFomat);
                        GlobFuncs.HIK_SetBalanceRatioToNumberic(cameraSettings.HikCamera, txtBalanceRed);
                        GlobFuncs.HIK_SetBalanceRatioToNumberic(cameraSettings.HikCamera, txtBalanceGreen, cBalanceRatioSelector.Green);
                        GlobFuncs.HIK_SetBalanceRatioToNumberic(cameraSettings.HikCamera, txtBalanceBlue, cBalanceRatioSelector.Blue);
                        break;
                    }
                case ESdkModes.Basler:
                    {
                        GlobFuncs.Basler_SetFloatValueToNumberic(cameraSettings.BaslerCamera, cParamName.TriggerDelay, txtTriggerDelayRaw);
                        GlobFuncs.Basler_SetFloatValueToNumberic(cameraSettings.BaslerCamera, cParamName.AcquisitionLineRate, txtAcquisitionLineRate);
                        GlobFuncs.Basler_SetFloatValueToNumberic(cameraSettings.BaslerCamera, cParamName.ExposureTime, txtExposureTimeRaw);
                        GlobFuncs.Basler_SetFloatValueToNumberic(cameraSettings.BaslerCamera, cParamName.Gain, txtGainRaw);

                        GlobFuncs.Basler_SetStringValueToCombobox(cameraSettings.BaslerCamera, cParamName.TriggerMode, cbTriggerMode);
                        GlobFuncs.Basler_SetStringValueToCombobox(cameraSettings.BaslerCamera, cParamName.TriggerSource, cbTriggerSource);
                        GlobFuncs.Basler_SetStringValueToCombobox(cameraSettings.BaslerCamera, cParamName.TriggerActivation, cbTriggerActivation);
                        GlobFuncs.Basler_SetStringValueToCombobox(cameraSettings.BaslerCamera, cParamName.ExposureMode, cbExposureMode);
                        GlobFuncs.Basler_SetStringValueToCombobox(cameraSettings.BaslerCamera, cParamName.AcquisitionMode, cbAcquisitionMode);
                        break;
                    }
                case ESdkModes.Dahua:
                    {
                        GlobFuncs.Dahua_SetFloatValueToNumeric(cameraSettings.DahuaCamera, cParamName.TriggerDelay, txtTriggerDelayRaw);
                        GlobFuncs.Dahua_SetFloatValueToNumeric(cameraSettings.DahuaCamera, cParamName.AcquisitionLineRate, txtAcquisitionLineRate);
                        GlobFuncs.Dahua_SetFloatValueToNumeric(cameraSettings.DahuaCamera, cParamName.ExposureTime, txtExposureTimeRaw);
                        GlobFuncs.Dahua_SetFloatValueToNumeric(cameraSettings.DahuaCamera, cParamName.Gain, txtGainRaw);

                        GlobFuncs.Dahua_SetStringValueToCombobox(cameraSettings.DahuaCamera, cParamName.TriggerMode, cbTriggerMode);
                        GlobFuncs.Dahua_SetStringValueToCombobox(cameraSettings.DahuaCamera, cParamName.TriggerSource, cbTriggerSource);
                        GlobFuncs.Dahua_SetStringValueToCombobox(cameraSettings.DahuaCamera, cParamName.TriggerActivation, cbTriggerActivation);
                        GlobFuncs.Dahua_SetStringValueToCombobox(cameraSettings.DahuaCamera, cParamName.ExposureMode, cbExposureMode);
                        GlobFuncs.Dahua_SetStringValueToCombobox(cameraSettings.DahuaCamera, cParamName.AcquisitionMode, cbAcquisitionMode);
                        break;
                    }
                default: {
                        break;
                    }
            }
            chkUseBalnceWhiteColor.Checked = cameraSettings.UseBalanceWhiteColor;
            EnableorDisableControls();

        }

        private void EnableorDisableControls()
        {
            txtBalanceBlue.Enabled = chkUseBalnceWhiteColor.Checked;
            txtBalanceRed.Enabled = chkUseBalnceWhiteColor.Checked;
            txtBalanceGreen.Enabled = chkUseBalnceWhiteColor.Checked;


            txtTriggerDelayRaw.Enabled = chkTriggerDelay.Checked;
            cbTriggerMode.Enabled = chkTriggerMode.Checked;
            cbTriggerSource.Enabled = chkTriggerSource.Checked;
            cbTriggerActivation.Enabled = chkTriggerActivity.Checked;
            txtExposureTimeRaw.Enabled = chkExposureTime.Checked;
            cbExposureMode.Enabled = chkExposureMode.Checked;
            cbAcquisitionMode.Enabled = chkAcquisitionMode.Checked;


        }
        internal void SavePropValueToDefault(bool showMessage = false)
        {
            //if (!HaveData())
            //    return;
            //tlCAMProp.CloseEditor();
            //tlCAMProp.EndCurrentEdit();
            //_groupActions.SourceImageSettings.CameraSettings.PropCompareDefault = new Dictionary<string, cPropCompare>();

            //DataRow[] defaultRows =
            //    _groupActions.SourceImageSettings.CameraSettings.dtAllProps.Select(cColName.Default + "=true");
            //foreach (DataRow defaultRow in defaultRows)
            //{
            //    HTupleType hTupleType = (HTupleType)defaultRow[cColName.DataType];
            //    Type type = typeof(string);
            //    HTuple value = null;
            //    string sValue = defaultRow[cColName.StringValue].ToString();
            //    if (!decimal.TryParse(sValue, out decimal dValue))
            //        dValue = 0;
            //    switch (hTupleType)
            //    {
            //        case HTupleType.INTEGER:
            //            {
            //                type = typeof(int);
            //                break;
            //            }
            //        case HTupleType.LONG:
            //            {
            //                type = typeof(long);
            //                break;
            //            }
            //        case HTupleType.DOUBLE:
            //            {
            //                type = typeof(double);
            //                break;
            //            }
            //    }
            //    cPropCompare defaultValue = new cPropCompare(type);
            //    defaultValue.RTCPropCAMName = defaultRow[cColName.PropName].ToString();
            //    defaultValue.PropCAMName = defaultRow[cColName.PropName].ToString();
            //    if (type == typeof(string))
            //        defaultValue.SValue = sValue;
            //    else
              //    _groupActions.SourceImageSettings.CameraSettings.PropCompareDefault.Add(defaultValue.RTCPropCAMName, defaultValue);
            //}
            //if (showMessage)
            //    cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectSuccess,
            //        new string[] { "default CAM setting" }, new string[] { "thông số mặc định của CAM" }));
        }
        private void myTreeList1_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadDefault_Click(object sender, EventArgs e)
        {
            if (!HaveData())
                return;
            cCameraSettings CameraSettings = _groupActions.SourceImageSettings.CameraSettings;
            if (CameraSettings.PropCompareDefault == null ||
                    CameraSettings.PropCompareDefault.Count <= 0)
                return;
            chkTriggerDelay.Checked = false;
            chkTriggerSource.Checked = false;
            chkTriggerMode.Checked = false;
            chkTriggerActivity.Checked = false;
            chkExposureMode.Checked = false;
            chkExposureTime.Checked = false;
            chkAcquisitionMode.Checked = false;
            chkAcquisitionLineRate.Checked = false;

            // TRIGGER DELAY
            if(CameraSettings.PropCompareDefault.TryGetValue(cParamName.TriggerDelay, out cPropCompare propCompare))
            {
                txtTriggerDelayRaw.Value = propCompare.DValue;
                chkTriggerDelay.Checked = true;
            }
            if (CameraSettings.PropCompareDefault.TryGetValue(cParamName.TriggerSource, out propCompare))
            {
                cbTriggerSource.Text = propCompare.SValue;
                chkTriggerSource.Checked = true;
            }
            if (CameraSettings.PropCompareDefault.TryGetValue(cParamName.TriggerMode, out propCompare))
            {
                cbTriggerMode.Text = propCompare.SValue;
                chkTriggerMode.Checked = true;
            }
            if (CameraSettings.PropCompareDefault.TryGetValue(cParamName.TriggerActivation, out  propCompare))
            {
                cbTriggerActivation.Text = propCompare.SValue;
                chkTriggerActivity.Checked = true;
            }
            if (CameraSettings.PropCompareDefault.TryGetValue(cParamName.ExposureTime, out  propCompare))
            {
                txtExposureTimeRaw.Value = propCompare.DValue;
                chkExposureTime.Checked = true;
            }
            if (CameraSettings.PropCompareDefault.TryGetValue(cParamName.Gain, out propCompare))
            {
                txtGainRaw.Value = propCompare.DValue;
                chkGain.Checked = true;
            }
            if (CameraSettings.PropCompareDefault.TryGetValue(cParamName.ExposureMode, out propCompare))
            {
                cbExposureMode.Text = propCompare.SValue;
                chkExposureMode.Checked = true;
            }
            if (CameraSettings.PropCompareDefault.TryGetValue(cParamName.AcquisitionMode, out propCompare))
            {
                cbAcquisitionMode.Text = propCompare.SValue;
                chkAcquisitionMode.Checked = true;
            }
            if (CameraSettings.PropCompareDefault.TryGetValue(cParamName.AcquisitionLineRate, out propCompare))
            {
                txtAcquisitionLineRate.Value = propCompare.DValue;
                chkAcquisitionLineRate.Checked = true;
            }

        }

        private void btnSaveDefault_Click(object sender, EventArgs e)
        {
            if (!HaveData())
                return;
            cCameraSettings cameraSettings = _groupActions.SourceImageSettings.CameraSettings;
            cameraSettings.PropCompareDefault = new Dictionary<string, cPropCompare>();
            if (chkTriggerDelay.Checked)
                SaveDecimalDefaultValue(cameraSettings, cParamName.TriggerDelay, txtTriggerDelayRaw.Value,
                    txtTriggerDelayRaw.Maximum, txtTriggerDelayRaw.Minimum);
            if (chkTriggerSource.Checked)
                SaveStringDefaultValue(cameraSettings, cParamName.TriggerSource, cbTriggerSource.Text);
            if (chkTriggerMode.Checked)
                SaveStringDefaultValue(cameraSettings, cParamName.TriggerMode, cbTriggerMode.Text);
            if (chkTriggerActivity.Checked)
                SaveStringDefaultValue(cameraSettings, cParamName.TriggerActivation, cbTriggerActivation.Text);
            if (chkExposureTime.Checked)
                SaveDecimalDefaultValue(cameraSettings, cParamName.ExposureTime, txtExposureTimeRaw.Value,
                    txtExposureTimeRaw.Maximum, txtExposureTimeRaw.Minimum);
            if (chkGain.Checked)
                SaveDecimalDefaultValue(cameraSettings, cParamName.Gain, txtGainRaw.Value,
                    txtGainRaw.Maximum, txtGainRaw.Minimum);
            if (chkExposureMode.Checked)
                SaveStringDefaultValue(cameraSettings, cParamName.ExposureMode, cbExposureMode.Text);
            if (chkAcquisitionMode.Checked)
                SaveStringDefaultValue(cameraSettings, cParamName.AcquisitionMode, cbAcquisitionMode.Text);
            if (chkAcquisitionLineRate.Checked)
                SaveDecimalDefaultValue(cameraSettings, cParamName.AcquisitionLineRate, txtAcquisitionLineRate.Value,
                    txtAcquisitionLineRate.Maximum, txtAcquisitionLineRate.Minimum);

            if (_groupActions.SaveCameraDefaultSettings())
                cMessageBox.Notification(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectSuccess,
                    new string[] { "camera settings" }, new string[] { "Thông số camera" }));
            else
                cMessageBox.Error(cMessageContent.BuildMessage(cMessageContent.Inf_SaveObjectIsNotSuccess,
                    new string[] { "camera settings" }, new string[] { "Thông số camera" }));

        }

        private void SaveDecimalDefaultValue(cCameraSettings cameraSettings, string propName, decimal value, decimal maxValue, decimal minValue)
        {
           if (cameraSettings.PropCompareDefault.TryGetValue(propName, out var propCompare))
            {
                propCompare.DValue = value;
                propCompare.DMinValue = minValue;
                propCompare.DMaxValue = maxValue;
            } 
           else
            {
                propCompare = new cPropCompare
                {
                    RTCPropCAMName = propName,
                    PropCAMName = propName,
                    DataType = typeof(double),
                    DMinValue = minValue,
                    DMaxValue = maxValue,
                    IsLive = false,
                    ReadOnly = false,
                    DValue = value
                   
                
                };
                cameraSettings.PropCompareDefault.Add(propName, propCompare);
            }    
        }
        private void SaveStringDefaultValue(cCameraSettings cameraSettings, string propName, string value)
        {
            if (cameraSettings.PropCompareDefault.TryGetValue(propName, out var propCompare))
            {
                propCompare.SValue = value;
            
            }
            else
            {
                propCompare = new cPropCompare
                {
                    RTCPropCAMName = propName,
                    PropCAMName = propName,
                    DataType = typeof(string),
                    SValue = value,
                    IsLive = false,
                    ReadOnly = false

                };
                cameraSettings.PropCompareDefault.Add(propName, propCompare);
            }
        }

        private void btnSetValue_Click(object sender, EventArgs e)
        {
            if (!HaveData())
                return;
            btnSetValue.Focus();
            cCameraSettings cameraSettings = _groupActions.SourceImageSettings.CameraSettings;
            switch (cameraSettings.SdkMode)
            {
                case ESdkModes.Hikrobot:
                case ESdkModes.HikrobotGenTL:
                    {
                        SetValue_Hikrobot();
                        break;
                    }
                case ESdkModes.Basler:
                    {
                        SetValue_Basler();
                        break;
                    }
                case ESdkModes.Dahua:
                    {
                        SetValue_Dahua();
                        break;
                    }

            }    
        }
        public void SetValue_Hikrobot()
        {
            StringBuilder errMessage = new StringBuilder();
            cCameraSettings cameraSettings = GroupActions.SourceImageSettings.CameraSettings;
            bool result = GlobFuncs.HIK_SetFloatValueFromNumberic(cameraSettings.HikCamera, cParamName.TriggerDelay,
                txtTriggerDelayRaw);
            if (!GlobFuncs.HIK_SetTriggerSourceFromCombobox(cameraSettings.HikCamera, cbTriggerSource))
                errMessage.Append("Can't set TriggerSource value");
            if (!GlobFuncs.HIK_SetTriggerModeFromCombobox(cameraSettings.HikCamera, cbTriggerSource))
                errMessage.Append("Can't set TriggerMode value");
            if (!GlobFuncs.HIK_SetTriggerActivitionFromCombobox(cameraSettings.HikCamera, cbTriggerSource))
                errMessage.Append("Can't set TriggerActivition value");
            if (!GlobFuncs.HIK_SetFloatValueFromNumberic(cameraSettings.HikCamera, cParamName.ExposureTime, txtExposureTimeRaw)) 
                errMessage.Append("Can't set ExposureTime value");
            if (!GlobFuncs.HIK_SetIntValueFromNumberic(cameraSettings.HikCamera, cParamName.Gain, txtGainRaw))
                errMessage.Append("Can't set Gain value");
            if (!GlobFuncs.HIK_SetExposureModeFromCombobox(cameraSettings.HikCamera, cbExposureMode))
                errMessage.Append("Can't set Gain value");
            if (cbAcquisitionMode.Enabled && !GlobFuncs.HIK_AcquisitionModeFromCombobox(cameraSettings.HikCamera, cbExposureMode))
                errMessage.Append("Cann't set AcquisitionMode Value");




        }
        public void SetValue_Basler()
        {
            if (!HaveData())
            {
                //panCamParam.Enable = false;
                return;
            }

            string errMessage = string.Empty;
            cCameraSettings cameraSettings = GroupActions.SourceImageSettings.CameraSettings;

            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.TriggerDelay, txtTriggerDelayRaw.Value, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.ExposureTime, txtExposureTimeRaw.Value, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.Gain, txtGainRaw.Value, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.TriggerSource, cbTriggerSource.Text, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.TriggerMode, cbTriggerMode.Text, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.TriggerActivation, cbTriggerActivation.Text, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.ExposureMode, cbExposureMode.Text, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.PixelFormat, cbPixelFomat.Text, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.AcquisitionMode, cbAcquisitionMode.Text, ref errMessage);
            GlobFuncs.Basler_SetValue(cameraSettings.BaslerCamera, cParamName.AcquisitionLineRate, txtAcquisitionLineRate.Value, ref errMessage);
        }
        public void SetValue_Dahua()
        {
            if(!HaveData())
            {
                return;
            }
            string errMessage = string.Empty;
            cCameraSettings cameraSettings = GroupActions.SourceImageSettings.CameraSettings;
            
        }

        private void btnRealValue_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chkTriggerDelay_CheckedChanged(object sender, EventArgs e)
        {
            EnableorDisableControls();
        }
    }
}
