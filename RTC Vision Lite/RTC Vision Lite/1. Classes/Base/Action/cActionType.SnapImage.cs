using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        private string _currentTemplateUsingName = string.Empty;
        public void Run_SnapImage_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_SnapImage();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
            MyGroup.SetValuetoVariableIsParentRef(this);
        }
        /// <summary>
        /// Hàm chuẩn bị các điều kiện chạy của tool Snap Image
        /// </summary>
        internal void Prepare_SnapImage()
        {
            if (!this.UseCameraSettings.rtcValue)
                return;
            // Lấy các thuộc tính cam
            this.CameraSettings = new cCameraSettings();
            this.CameraSettings.PropCompareDefault = new Dictionary<string, cPropCompare>();
            DataTable dataTable = Lib.GetDataTable(
                $"SELECT * FROM {cTableName_SaveTemplate.CameraSettingTemplate} WHERE Name = '{TemplateName.rtcValue}'",
                this.MyGroup.MyCam.MyProject.FileName);
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                this.CameraSettings = null;
                return;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                string dataType = GlobFuncs.GetDataRowValue_String(row, cColName.DataType);

                cPropCompare propCompare = new cPropCompare();
                propCompare.PropCAMName = GlobFuncs.GetDataRowValue_String(row, cColName.ParamName);
                switch (dataType)
                {
                    case cDataTypes.TEXT:
                        {
                            propCompare.SValue = GlobFuncs.GetDataRowValue_String(row, cColName.ValueT);
                            propCompare.DataType = typeof(string);
                            break;
                        }
                    case cDataTypes.INTEGER:
                        {
                            propCompare.DValue = GlobFuncs.GetDataRowValue_Decimal(row, cColName.ValueI);
                            propCompare.DataType = typeof(int);
                            break;
                        }
                    case cDataTypes.DOUBLE:
                        {
                            propCompare.DValue = GlobFuncs.GetDataRowValue_Decimal(row, cColName.ValueD);
                            propCompare.DataType = typeof(double);
                            break;
                        }
                }
                this.CameraSettings.PropCompareDefault.Add(propCompare.PropCAMName, propCompare);
            }
        }
        /// <summary>
        /// Cài đặt các thông số camera nếu có trước khi chụp
        /// </summary>
        /// <param name="groupActions">Cửa chứa thông số camera cần cài đặt</param>
        private void Run_SnapImage_SetCameraSettings(cGroupActions groupActions)
        {
            List<string> propCompareKeys = new List<string>();
            // Đẩy các dạng mode lên đầu để nó xác định trước các mode làm việc
            var listPropCompare = CameraSettings.PropCompareDefault.Keys
                .Where(x => x.ToLower().Contains("enable")).ToList();
            if (listPropCompare.Any())
                foreach (string s in listPropCompare)
                    propCompareKeys.Add(s);

            listPropCompare = CameraSettings.PropCompareDefault.Keys
                .Where(x => x.ToLower().Contains("auto")).ToList();
            if (listPropCompare.Any())
                foreach (string s in listPropCompare)
                    propCompareKeys.Add(s);

            listPropCompare = CameraSettings.PropCompareDefault.Keys
                .Where(x => x.ToLower().Contains("mode")).ToList();
            if (listPropCompare.Any())
                foreach (string s in listPropCompare)
                    propCompareKeys.Add(s);

            // Cho Width, Height được ưu tiên set trước với trường hợp offset
            if (CameraSettings.PropCompareDefault.ContainsKey(cPropCamName.Width))
                propCompareKeys.Add(cPropCamName.Width);
            if (CameraSettings.PropCompareDefault.ContainsKey(cPropCamName.Height))
                propCompareKeys.Add(cPropCamName.Height);

            foreach (string key in CameraSettings.PropCompareDefault.Keys)
                if (!propCompareKeys.Contains(key))
                    propCompareKeys.Add(key);

            string listPropertiesCanNotSet = string.Empty;

            switch (groupActions.SourceImageSettings.CameraSettings.SdkMode)
            {

                case ESdkModes.Hikrobot:
                case ESdkModes.HikrobotGenTL:
                    {
                        groupActions.SourceImageSettings.CameraSettings.HikCamera.MV_CC_StopGrabbing_NET();

                        foreach (string key in propCompareKeys)
                        {
                            cPropCompare propCompare = CameraSettings.PropCompareDefault[key];
                            if (key == cParamName.UseBalanceWhiteColor)
                                continue;

                            var result = groupActions.SetCameraPropValue_Hikrobot(groupActions.SourceImageSettings.CameraSettings.HikCamera, propCompare);
                            if (!result)
                                listPropertiesCanNotSet = string.IsNullOrEmpty(listPropertiesCanNotSet)
                                    ? "List Properties can't set: " + propCompare.PropCAMName
                                    : listPropertiesCanNotSet + "," + propCompare.PropCAMName;
                        }

                        Thread.Sleep(GlobVar.RTCVision.RunOptions.WaitTimeWhenChangeCameraSettings_Hikrobot);

                        groupActions.SourceImageSettings.CameraSettings.HikCamera.MV_CC_StartGrabbing_NET();

                        break;
                    }
                case ESdkModes.Basler:
                    {
                        foreach (string key in propCompareKeys)
                        {
                            cPropCompare propCompare = CameraSettings.PropCompareDefault[key];
                            string errMessage = string.Empty;
                            var result = groupActions.SetCameraPropValue_Basler(groupActions.SourceImageSettings.CameraSettings.BaslerCamera, propCompare, ref errMessage);
                            if (!result)
                                listPropertiesCanNotSet = string.IsNullOrEmpty(listPropertiesCanNotSet)
                                    ? "List Properties can't set: " + propCompare.PropCAMName
                                    : listPropertiesCanNotSet + "," + propCompare.PropCAMName;
                        }
                        Thread.Sleep(GlobVar.RTCVision.RunOptions.WaitTimeWhenChangeCameraSettings_Basler);
                        break;
                    }
                case ESdkModes.Dahua:
                    {
                        foreach (string key in propCompareKeys)
                        {
                            cPropCompare propCompare = CameraSettings.PropCompareDefault[key];
                            string errMessage = string.Empty;
                            var result = groupActions.SetCameraPropValue_Dahua(groupActions.SourceImageSettings.CameraSettings.DahuaCamera, propCompare, ref errMessage);
                            if (!result)
                                listPropertiesCanNotSet = string.IsNullOrEmpty(listPropertiesCanNotSet)
                                    ? "List Properties can't set: " + propCompare.PropCAMName
                                    : listPropertiesCanNotSet + "," + propCompare.PropCAMName;
                        }
                        Thread.Sleep(GlobVar.RTCVision.RunOptions.WaitTimeWhenChangeCameraSettings_Dahua);
                        break;
                    }
            }
        }
        /// <summary>
        /// Hàm chạy tool Snap Image
        /// </summary>
        public void Run_SnapImage()
        {
            Passed.rtcValue = false;

            switch (CameraMode.rtcValue)
            {
                case cCameraMode.CurrentMain:
                    {
                        if (MyGroup.SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera &&
                            !MyGroup.SourceImageSettings.CameraSettings.IsConnected)
                            if (!MyGroup.ConnectCamera())
                                return;
                        bool currentLive = MyGroup.SourceImageSettings.CameraSettings.IsLive;
                        if (currentLive)
                            MyGroup.SetLiveCamera(false);
                        if (UseCameraSettings.rtcValue && MyGroup.SourceImageSettings.CameraSettings.CurrentSettingTemplateName != null
                            && MyGroup.SourceImageSettings.CameraSettings.CurrentSettingTemplateName != TemplateName.rtcValue)
                        {
                            Prepare_SnapImage();
                            Run_SnapImage_SetCameraSettings(MyGroup);
                            MyGroup.SourceImageSettings.CameraSettings.CurrentSettingTemplateName = TemplateName.rtcValue;
                        }

                        if (InputImage.rtcIDRef == Guid.Empty)
                            switch (SnapMode.rtcValue)
                            {
                                case cSnapMode.Previous:
                                    {
                                        InputImage.rtcValue = MyGroup.Setting_Snap(ERunActionMode.Prev, true, "", IsBringImageToMain.rtcValue);

                                        break;
                                    }
                                case cSnapMode.Current:
                                    {
                                        InputImage.rtcValue = MyGroup.Setting_Snap(ERunActionMode.Current, true, "", IsBringImageToMain.rtcValue);

                                        break;
                                    }
                                default:
                                    {
                                        InputImage.rtcValue = MyGroup.Setting_Snap(ERunActionMode.Next, true, "", IsBringImageToMain.rtcValue);

                                        break;
                                    }
                            }
                        if (currentLive)
                            MyGroup.SetLiveCamera(currentLive);

                        break;
                    }

                case cCameraMode.OtherMain:
                    {
                        cCAMTypes otherCam =
                            GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name == ProgramName.rtcValue);
                        if (otherCam != null)
                        {
                            if (otherCam.GroupActions.SourceImageSettings.ImageSourceType == EImageSourceTypes.Camera)
                                if (!otherCam.GroupActions.ConnectCamera())
                                    return;

                            if (UseCameraSettings.rtcValue && otherCam.GroupActions.SourceImageSettings.CameraSettings.CurrentSettingTemplateName != TemplateName.rtcValue)
                            {
                                Prepare_SnapImage();
                                Run_SnapImage_SetCameraSettings(otherCam.GroupActions);
                                otherCam.GroupActions.SourceImageSettings.CameraSettings.CurrentSettingTemplateName = TemplateName.rtcValue;
                            }

                            if (InputImage.rtcIDRef == Guid.Empty)
                                switch (SnapMode.rtcValue)
                                {
                                    case cSnapMode.Previous:
                                        {
                                            InputImage.rtcValue = otherCam.GroupActions.Setting_Snap(ERunActionMode.Prev, true, "", IsBringImageToMain.rtcValue, true);

                                            break;
                                        }
                                    case cSnapMode.Current:
                                        {
                                            InputImage.rtcValue = otherCam.GroupActions.Setting_Snap(ERunActionMode.Current, true, "", IsBringImageToMain.rtcValue, true);

                                            break;
                                        }
                                    default:
                                        {
                                            InputImage.rtcValue = otherCam.GroupActions.Setting_Snap(ERunActionMode.Next, true, "", IsBringImageToMain.rtcValue, true);

                                            break;
                                        }
                                }
                        }
                        break;
                    }
                case cCameraMode.Custom:
                    {
                        cCameraSettings cameraSettings = new cCameraSettings();
                        cameraSettings.DeviceName = DeviceName.rtcValue;
                        cameraSettings.DeviceNameOrigin = DeviceNameOrigin.rtcValue;
                        cameraSettings.VendorName = VendorName.rtcValue;
                        cameraSettings.InterfaceName = InterfaceName.rtcValue;
                        break;
                    }
            }


            MyGroup.IsSnapSuccess = (InputImage.rtcValue != null);

            Passed.rtcValue = MyGroup.IsSnapSuccess;

            if (IsBringImageToMain.rtcValue)
            {
                if (InputImage?.rtcValue != null)
                {
                    MyGroup.Actions[MyGroup.IDMainAction].InputImage.rtcValue = (Bitmap)InputImage.rtcValue.Clone();
                    //using (Bitmap bmp = (Bitmap)InputImage.rtcValue.Clone())
                    //{
                    //    MyGroup.Actions[MyGroup.IDMainAction].InputImage.rtcValue = bmp;
                    //}
                }
                MyGroup.SetValuetoVariableIsParentRef(MyGroup.Actions[MyGroup.IDMainAction]);
            }
        }
    }
    

}
