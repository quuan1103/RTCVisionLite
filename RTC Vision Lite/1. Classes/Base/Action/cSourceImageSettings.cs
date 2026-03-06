using RTCEnums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class cSourceImageSettings
    {

        public event ImageSourceTypeChanged OnImageSourceTypeChanged;

        public cCameraSettings CameraSettings { get; set; }

        public cTrigger Trigger { get; set; }

        public cComputerSettings ComputerSettings { get; set; }
        internal bool IsSetDefaultCameraSettingBeforeSnapFinish = false;
        public bool IsUseDefaultCameraSettingBeforeSnap { get; set; }
        public string MasterImage { get; set; }
        public bool IsEnableSnap { get; set; }
        public bool IsTriggerBySoftware { get; set; }
        public bool IsTriggerOn { get; set; }
        public bool IsLineScan { get; set; }
        //public cTrigger IsLineScan { get; set; }
        public EImageSourceTypes OldImageSourceType;

        public EImageSourceTypes _ImageSourceType;

        public EImageSourceTypes ImageSourceType
        {
            get
            {
                return _ImageSourceType;
            }
            set
            {
                _ImageSourceType = value;
                if (OnImageSourceTypeChanged != null)
                {
                    OnImageSourceTypeChanged(null, null);
                }
            }
        }

        public EImageSourceTypes DefaultImageSourceType { get; set; }
        public bool IsNoImage
        {
            get
            {
                return (ImageSourceType == EImageSourceTypes.Computer &&
                    (ComputerSettings.Images.Count <= 0
                    || ComputerSettings.CurrentImgIndex < 0
                    || ComputerSettings.Images.Count <= ComputerSettings.CurrentImgIndex
                    || !File.Exists(ComputerSettings.Images[ComputerSettings.CurrentImgIndex].FileName)))
                    || (ImageSourceType == EImageSourceTypes.Camera && !CameraSettings.IsConnected);

            }
        }

        public cSourceImageSettings()
        {
            DefaultImageSourceType = EImageSourceTypes.None;
            ImageSourceType = EImageSourceTypes.Computer;
            ComputerSettings = new cComputerSettings();
            CameraSettings = new cCameraSettings();
            IsEnableSnap = true;
            IsTriggerBySoftware = false;
            IsTriggerOn = false;
            IsLineScan = false;
            MasterImage = string.Empty;
            Trigger = new cTrigger();
            IsUseDefaultCameraSettingBeforeSnap = false;

        }
    }
}
