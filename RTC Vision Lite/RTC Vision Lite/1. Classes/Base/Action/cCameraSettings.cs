using RTCBaslerSdk;
using RTCDahuaSdk;
using RTCEnums;
using RTCHikSdk;
using System;
using RTC_Vision_Lite.PublicFunctions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTCConst;
using System.Threading;
using System.IO;

namespace RTC_Vision_Lite.Classes
{
    public class cCameraSettings
    {
        public event CameraLiveAndConnectChanged OnCameraLiveAndConnectChanged;
        public List<string> Interfaces { get; set; }

        public List<InterfaceCamera> Cameras { get; set; }
        public List<InterfaceCamera> ManualCameras { get; set; }
        public List<cImage> FileNames { get; set; }
        private bool _islive;
        public bool IsLive
        {
            get
            {
                return _islive;
            }
            set
            {
                _islive = value;
                if (OnCameraLiveAndConnectChanged != null)
                {
                    OnCameraLiveAndConnectChanged(null, null);
                }
            }
        }
        private bool _Isconnected;
        public bool IsConnected
        {
            get
            {
                return _Isconnected;
            }
            set
            {
                _Isconnected = value;
                if (OnCameraLiveAndConnectChanged != null)
                {
                    OnCameraLiveAndConnectChanged(null, null);
                }
            }
        }
        public ManualResetEvent StopEventHandle;
        public Thread ThreadAcq, ThreadIP, ThreadLive;
        public List<String> AllProps { get; set; }
        public DataTable dtAllProps { get; set; }
        public bool IsCreatddtAllProps { get; set; }
        public string VendorName { get; set; }
        public string InterfaceName { get; set; }

        public string DeviceName { get; set; }
        private string _DeviceNameOrigin;
        public string DeviceNameOrigin
        {
            get { return _DeviceNameOrigin; }
            set
            {
                _DeviceNameOrigin = value;
                VendorName = GlobFuncs.GetVendorName(_DeviceNameOrigin);
            }
        }
        public bool IsPropCompareExists { get; set; }
        public Dictionary<string, cPropCompare> PropCompareDefault { get; set; }
        public Dictionary<string, cPropCompare> PropCompare { get; set; }
        public bool IsSaveImage { get; set; }
        public bool IsSaveImage_Pass { get; set; }
        public bool IsSaveImage_Fail { get; set; }
        public bool IsUseProjectFolder { get; set; }
        public string SaveFileFolder { get; set; }
        public string SaveImageFolder_Pass { get; set; }
        public string SaveImageFolder_Fail { get; set; }
        public string SaveImageFolder_Origin { get; set; }
        public string SaveImageFolder_Snap { get; set; }
        public string SaveImagePrefixName { get; set; }
        public string SaveImageDateTimeFormat { get; set; }
        public ESuffixMode SuffixMode { get; set; }
        public string SaveFolder { get; set; }
        public int SaveImageOrder { get; set; }
        public int SaveImageOrderOK { get; set; }
        public int SaveImageOrderNG { get; set; }
        public bool AutoResetSaveImageOrder { get; set; }
        public int MaxSaveImageOrder { get; set; }
        public string GrabberMode { get; set; }
        public int NumBuffers { get; set; }
        public bool isAutoSetDefaultCAMSettingWhenConnect { get; set; }
        public List<cImage> Images { get; set; }

        public bool IsAutoSaveImage { get; set; }

        public object SaveImageType { get; set; } = cImageTypes.bmp;
        public bool IsAutoCreateFolderByDate { get; set; }
        public MyHikCamera HikCamera = null;
        public MyBaslerCamera BaslerCamera = null;
        public MyDahuaCamera DahuaCamera = null;
        public string CurrentSettingTemplateName = string.Empty;
        public ESdkModes SdkMode { get; set; } = ESdkModes.Hikrobot;


        //public string SaveImageFolder { get; set; }
        public bool UseBalanceWhiteColor;
        /// <summary>
        /// </summary>

        public string SaveImageFolder_Origin_Withday;
        /// <summary>
        /// The save image folder pass with day. 
        /// </summary>
        public string SaveImageFolder_Pass_Withday;
        /// <summary>
        /// The save image folder fail with day. 
        /// </summary>
        public string SaveImageFolder_Fail_Withday;
        /// <summary>
        /// The save image folder snap with day. 
        /// </summary>
        public string SaveImageFolder_Snap_Withday;
        public cCameraSettings()
        {
            Interfaces = new List<string>();
            Cameras = new List<InterfaceCamera>();
            ManualCameras = new List<InterfaceCamera>();
            FileNames = new List<cImage>();
            IsLive = false;
            IsConnected = false;
            StopEventHandle = new ManualResetEvent(false);

            AllProps = new List<string>();
            dtAllProps = null;
            IsCreatddtAllProps = false;

            InterfaceName = string.Empty;
            DeviceName = string.Empty;
            DeviceNameOrigin = string.Empty;

            IsPropCompareExists = false;
            PropCompare = null;

            IsSaveImage = false;
            IsSaveImage_Pass = false;
            IsSaveImage_Fail = false;

            IsUseProjectFolder = true;
            SaveFileFolder = string.Empty;
            SaveImageFolder_Pass = string.Empty;
            SaveImageFolder_Fail = string.Empty;
            SaveImageFolder_Origin = string.Empty;
            SaveImageFolder_Snap = string.Empty;
            SaveImagePrefixName = string.Empty;
            SaveImageDateTimeFormat = cDateTimeFormats.yyyyddMMHHmmss;
            SuffixMode = ESuffixMode.DateTime;
            SaveFolder = GlobVar.RTCVision.Paths.AppPath;
            Images = new List<cImage>();
            SaveImageOrder = 0;
            SaveImageOrderOK = 0;
            SaveImageOrderNG = 0;
            MaxSaveImageOrder = 1000000;
            AutoResetSaveImageOrder = false;
            isAutoSetDefaultCAMSettingWhenConnect = true;
            GrabberMode = cGrabberMode.Sync;
            NumBuffers = 3;

            //IsAutoSaveImage


        }
        #region  Các biến dành cho phần setting lưu trữ ảnh


        #endregion
        /// <summary>
        /// Cài đặt thông số mặc định cho camera
        /// </summary>
        public void SetDefaultValue()
        {
            List<string> propCompareKeys = new List<string>();
            // đẩy các dạng mode lên đầu để nó xác định trước các mode làm việc
            var listPropCompare = PropCompareDefault.Keys.Where(x => x.ToLower().Contains("enable")).ToList();
            if (listPropCompare.Any())
                foreach (string s in listPropCompare)
                    propCompareKeys.Add(s);
            listPropCompare = PropCompareDefault.Keys.Where(x => x.ToLower().Contains("auto")).ToList();
            if (listPropCompare.Any())
                foreach (string s in listPropCompare)
                    propCompareKeys.Add(s);
            listPropCompare = PropCompareDefault.Keys.Where(x => x.ToLower().Contains("mode")).ToList();
            if (listPropCompare.Any())
                foreach (string s in listPropCompare)
                    propCompareKeys.Add(s);
            //Cho width, height được ưu tiên set trước với trường hợp offset
            if (PropCompareDefault.ContainsKey(cPropCamName.Width))
                propCompareKeys.Add(cPropCamName.Width);
            if (PropCompareDefault.ContainsKey(cPropCamName.Height))
                propCompareKeys.Add(cPropCamName.Height);
            if (PropCompareDefault.ContainsKey(cPropCamName.TriggerSelector))
                propCompareKeys.Add(cPropCamName.TriggerSelector);
            if (PropCompareDefault.ContainsKey(cPropCamName.TriggerMode))
                propCompareKeys.Add(cPropCamName.TriggerMode);
            foreach (string key in PropCompareDefault.Keys)
                if (!propCompareKeys.Contains(key))
                    propCompareKeys.Add(key);
            switch (SdkMode)
            {
                case ESdkModes.Hikrobot:
                case ESdkModes.HikrobotGenTL:
                    {
                        SetDefaultValue_Hikrobot(propCompareKeys);
                        break;
                    }
                case ESdkModes.Basler:
                    {
                        SetDefaultValue_Basler(propCompareKeys);
                        break;
                    }
            }


        }

        private void SetDefaultValue_Basler(List<string> propCompareKeys)
        {
            if (!IsConnected || BaslerCamera == null || !BaslerCamera.IsConnected)
                return;
            string errMessage = string.Empty;
            foreach (string key in propCompareKeys)
                try
                {
                    cPropCompare propCompare = PropCompareDefault[key];
                    switch (key)
                    {
                        case cParamName.TriggerDelay:
                            {
                                GlobFuncs.Basler_SetValue(BaslerCamera, cParamName.TriggerDelay, propCompare.DValue, ref errMessage);
                                break;
                            }
                        case cParamName.Gain:
                            {
                                GlobFuncs.Basler_SetValue(BaslerCamera, cParamName.Gain, propCompare.DValue, ref errMessage);
                                break;
                            }

                        case cParamName.TriggerSource:
                            {
                                GlobFuncs.Basler_SetValue(BaslerCamera, cParamName.TriggerSource, propCompare.SValue, ref errMessage);
                                break;
                            }
                        case cParamName.ExposureTime:
                            {
                                GlobFuncs.Basler_SetValue(BaslerCamera, cParamName.ExposureTime, propCompare.DValue, ref errMessage);
                                break;
                            }
                        case cParamName.TriggerMode:
                            {
                                GlobFuncs.Basler_SetValue(BaslerCamera, cParamName.TriggerMode, propCompare.SValue, ref errMessage);
                                break;
                            }
                        case cParamName.TriggerActivation:
                            {
                                GlobFuncs.Basler_SetValue(BaslerCamera, cParamName.TriggerActivation, propCompare.SValue, ref errMessage);
                                break;
                            }
                        case cParamName.ExposureMode:
                            {
                                GlobFuncs.Basler_SetValue(BaslerCamera, cParamName.ExposureMode, propCompare.SValue, ref errMessage);
                                break;
                            }
                        case cParamName.AcquisitionMode:
                            {
                                GlobFuncs.Basler_SetValue(BaslerCamera, cParamName.AcquisitionMode, propCompare.SValue, ref errMessage);
                                break;
                            }

                    }
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                }
        }
        private void SetDefaultValue_Hikrobot(List<string> propCompareKeys)
        {
            if (!IsConnected || HikCamera == null || HikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            string errMessage = string.Empty;
            bool Result = true;
            foreach (string key in propCompareKeys)
            {
                cPropCompare propCompare = PropCompareDefault[key];
                if (key == cParamName.UseBalanceWhiteColor)
                    continue;
                switch (propCompare.PropCAMName)
                {
                    case cParamName.TriggerDelay:
                        Result = GlobFuncs.HIK_SetFloatValue(HikCamera, cParamName.TriggerDelay, propCompare.DValue);
                        break;
                    case cParamName.TriggerSource:
                        Result = GlobFuncs.HIK_SetTriggerSource(HikCamera, propCompare.SValue);
                        break;
                    case cParamName.TriggerMode:
                        Result = GlobFuncs.HIK_SetTriggerMode(HikCamera, propCompare.SValue);
                        break;
                    case cParamName.TriggerActivation:
                        Result = GlobFuncs.HIK_SetTriggerActivation(HikCamera, propCompare.SValue);
                        break;
                    case cParamName.ExposureTime:
                        Result = GlobFuncs.HIK_SetExposureTime(HikCamera, propCompare.DValue);
                        break;
                    case cParamName.Gain:
                        Result = GlobFuncs.HIK_SetFloatValue(HikCamera, cParamName.Gain, propCompare.DValue);
                        break;
                    case cParamName.ExposureMode:
                        Result = GlobFuncs.HIK_SetExposureMode(HikCamera, propCompare.SValue);
                        break;
                    case cParamName.AcquisitionMode:
                        Result = GlobFuncs.HIK_SetAcquisitionMode(HikCamera, propCompare.SValue);
                        break;
                    case cParamName.BalanceRatioR:
                        Result = GlobFuncs.HIK_SetBalanceRatioValue(HikCamera, propCompare.DValue);
                        break;
                    case cParamName.BalanceRatioG:
                        Result = GlobFuncs.HIK_SetBalanceRatioValue(HikCamera, propCompare.DValue, cBalanceRatioSelector.Green);
                        break;
                    case cParamName.BalanceRatioB:
                        Result = GlobFuncs.HIK_SetBalanceRatioValue(HikCamera, propCompare.DValue, cBalanceRatioSelector.Blue);
                        break;


                }
            }
            Thread.Sleep(GlobVar.RTCVision.RunOptions.WaitTimeWhenChangeCameraSettings_Hikrobot);
        }
        public void BuildDefaultSettingsSaveImage_Passed(string projectPath, string camName)
        {
            string sNewSaveFileFolder = projectPath + Path.DirectorySeparatorChar + camName + "_Passed";
            SaveImageFolder_Pass = sNewSaveFileFolder;
            if (!Directory.Exists(SaveImageFolder_Pass) || SaveImageFolder_Pass.ToLower() != sNewSaveFileFolder.ToLower())
                Directory.CreateDirectory(SaveImageFolder_Pass);
        }
        public void BuildDefaultSettingsSaveImage_Failed(string projectPath, string camName)
        {
            string sNewSaveFileFolder = projectPath + Path.DirectorySeparatorChar + camName + "_Failed";
            SaveImageFolder_Fail = sNewSaveFileFolder;
            if (!Directory.Exists(SaveImageFolder_Fail) || SaveImageFolder_Fail.ToLower() != sNewSaveFileFolder.ToLower())
                Directory.CreateDirectory(SaveImageFolder_Fail);
        }
        public void BuildDefaultSettingsSaveImage_Origin(string projectPath, string camName)
        {
            string sNewSaveFileFolder = projectPath + Path.DirectorySeparatorChar + camName + "_Origin";
            SaveImageFolder_Origin = sNewSaveFileFolder;
            if (!Directory.Exists(SaveImageFolder_Origin) || SaveImageFolder_Origin.ToLower() != sNewSaveFileFolder.ToLower())
                Directory.CreateDirectory(SaveImageFolder_Origin);
        }
        public void BuildDefaultSettingsSaveImage_Snap(string projectPath, string camName)
        {
            string sNewSaveFileFolder = projectPath + Path.DirectorySeparatorChar + camName + "_Snap";
            SaveImageFolder_Snap = sNewSaveFileFolder;
            if (!Directory.Exists(SaveImageFolder_Snap) || SaveImageFolder_Snap.ToLower() != sNewSaveFileFolder.ToLower())
                Directory.CreateDirectory(SaveImageFolder_Snap);
        }
        /// <summary>
        /// The save image folder origin with day. 
        /// </summary>

    }
}
