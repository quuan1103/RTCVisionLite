using Basler.Pylon;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using RTCHikSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        internal void PrepareBeforeRun_SystemInfo()
        {
            WindowName.rtcValue = MyGroup.MyCam.Name;
            MyGroup.MyCam?.BuildDefaultFolderPath(GlobVar.CurrentProject.FolderNameFullPath);
            WindowPath_File.rtcValue = MyGroup.SaveFileFolder;
            switch (MyGroup.SourceImageSettings.ImageSourceType)
            {
                case RTCEnums.EImageSourceTypes.Computer:
                    CamModel.rtcValue = "Local File";
                    break;
                case RTCEnums.EImageSourceTypes.Camera:
                    {
                        switch (MyGroup.SourceImageSettings.CameraSettings.SdkMode)
                        {
                            case ESdkModes.Hikrobot:
                                CamModel.rtcValue = $"Hikrobot - {MyGroup.SourceImageSettings.CameraSettings.DeviceName}";
                                break;
                            case ESdkModes.HikrobotGenTL:
                                CamModel.rtcValue = $"Hikrobot - {MyGroup.SourceImageSettings.CameraSettings.DeviceName}";
                                break;
                            case ESdkModes.Basler:
                                CamModel.rtcValue = $"Basler - {MyGroup.SourceImageSettings.CameraSettings.DeviceName}";
                                break;
                            case ESdkModes.Dahua:
                                CamModel.rtcValue = $"FujiMV - {MyGroup.SourceImageSettings.CameraSettings.DeviceName}";
                                break;
                        }
                        break;
                    }
            }
        }
        public void Run_SystemInfo()
        {
            CurrentDate.rtcValue = DateTime.Now.ToString(DateFormat.rtcValue);
            CurrentTime.rtcValue = DateTime.Now.ToString(TimeFormat.rtcValue);
            if (IsRunOneTime.rtcValue && IsFinishRunOneTime.rtcValue)
                return;
            ExposureTime.rtcValue = 0;
            switch (MyGroup.SourceImageSettings.ImageSourceType)
            {
                case EImageSourceTypes.Computer:
                    ExposureTime.rtcValue = 0;
                    break;
                case EImageSourceTypes.Camera:
                    {
                        switch (MyGroup.SourceImageSettings.CameraSettings.SdkMode)
                        {
                            case ESdkModes.Hikrobot:
                                if (MyGroup.SourceImageSettings.CameraSettings.HikCamera != null && MyGroup.SourceImageSettings.CameraSettings.HikCamera.IsOpen)
                                {
                                    MyHikCamera.MVCC_FLOATVALUE floatvalue = new MyHikCamera.MVCC_FLOATVALUE();
                                    if (GlobFuncs.HIK_GetFloatValue(MyGroup.SourceImageSettings.CameraSettings.HikCamera, cParamName.ExposureTime,
                                        ref floatvalue)) ExposureTime.rtcValue = Lib.ToInt(floatvalue.fCurValue);
                                }
                                break;
                            case ESdkModes.HikrobotGenTL:
                                if (MyGroup.SourceImageSettings.CameraSettings.HikCamera != null && MyGroup.SourceImageSettings.CameraSettings.HikCamera.IsOpen)
                                {
                                    MyHikCamera.MVCC_FLOATVALUE floatvalue = new MyHikCamera.MVCC_FLOATVALUE();

                                    if (GlobFuncs.HIK_GetFloatValue(MyGroup.SourceImageSettings.CameraSettings.HikCamera, cParamName.ExposureTime,
                                        ref floatvalue)) ExposureTime.rtcValue = Lib.ToInt(floatvalue.fCurValue);
                                }
                                break;
                            case ESdkModes.Basler:
                                if (MyGroup.SourceImageSettings.CameraSettings.BaslerCamera != null && MyGroup.SourceImageSettings.CameraSettings.BaslerCamera.IsConnected)
                                {
                                    IFloatParameter floatParameter = null;
                                    if (MyGroup.SourceImageSettings.CameraSettings.BaslerCamera.Parameters.Contains(new FloatName(cParamName.ExposureTime)))
                                        floatParameter = MyGroup.SourceImageSettings.CameraSettings.BaslerCamera.Parameters[new FloatName(cParamName.ExposureTime)];
                                    else if (MyGroup.SourceImageSettings.CameraSettings.BaslerCamera.Parameters.Contains(new FloatName(cParamName.ExposureTimeAbs)))
                                        floatParameter = MyGroup.SourceImageSettings.CameraSettings.BaslerCamera.Parameters[new FloatName(cParamName.ExposureTimeAbs)];

                                    if (floatParameter != null)
                                        ExposureTime.rtcValue = Lib.ToInt(floatParameter.GetValue());
                                }
                                break;
                            case ESdkModes.Dahua:
                                if (MyGroup.SourceImageSettings.CameraSettings.DahuaCamera != null && MyGroup.SourceImageSettings.CameraSettings.DahuaCamera.IsConnected)
                                {
                                    // ExposureTime.rtcValue = Lib.ToInt(MyGroup.SourceImageSettings.CameraSettings.DahuaCamera.GetDoubleValue(cParamName.ExposureTime));
                                }
                                break;
                        }
                        break;
                    }
            }
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };

            ModelPath.rtcValue = GlobVar.CurrentProject?.FolderNameFullPath;

            Passed.rtcValue = true;
            if (IsRunOneTime.rtcValue)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        }
    }
}
