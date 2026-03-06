using Emgu.CV.Structure;
using Emgu.CV;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.Properties;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Basler.Pylon;
using RTCBaslerSdk;
using RTCDahuaSdk;
using RTCHikSdk;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace RTC_Vision_Lite.Classes
{
    public partial class cGroupActions
    {
        private bool IsTriggerBySoftware = false;
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        public object BufForDriverLock = new object();
        private IntPtr m_BufForDriver = IntPtr.Zero;
        private uint m_nBufSizeForDriver = 0;
        private BackgroundWorker liveBackgroundWorker = null;
        internal object LockTriggerSoftwareObject = new object();



        public Image SnapImage(bool isSetPart = false, bool isPreview = false, string errMessage = "")
        {
            Image image = null;
            switch (SourceImageSettings.ImageSourceType)
            {
                case EImageSourceTypes.Computer:
                    {
                        image = SnapImage_Computer();
                        break;
                    }
                case EImageSourceTypes.Camera:
                    {
                        image = SnapImage_Camera();
                        break;
                    }
            }

            SetImageToAllAction(image);

            if (isSetPart)
                GlobFuncs.SmartSetPart(image, frmHsmartWindow.SmartWindow);

            if (isPreview && image != null)
            {
                GlobVar.GroupActions.frmHsmartWindow.Image = (Image)image.Clone();

                GlobVar.GroupActions.DataChanged = true;
            }

            return image;
        }

        private Bitmap SnapImage_Camera(bool isInMainAction = false)
        {
            switch (SourceImageSettings.CameraSettings.SdkMode)
            {
                case ESdkModes.Hikrobot:
                    {
                        return SnapImage_Camera_Hikrobot(isInMainAction);
                        //return SourceImageSettings.CameraSettings.HikCamera.SingleShotGrabbing();
                    }
                case ESdkModes.HikrobotGenTL:
                    return SnapImage_Camera_Hikrobot(isInMainAction);
                case ESdkModes.Basler:
                    return SnapImage_Camera_Basler(isInMainAction);
                case ESdkModes.Dahua:
                default:
                    return null;

            }
        }

        public Image SnapImage_Computer()
        {
            Image outputImage = null;
            SourceImageSettings.ComputerSettings.CurrentImgIndex += 1;

            if (SourceImageSettings.ComputerSettings.CurrentImgIndex < 0 ||
                SourceImageSettings.ComputerSettings.Images != null &&
                SourceImageSettings.ComputerSettings.CurrentImgIndex >=
                SourceImageSettings.ComputerSettings.Images.Count)
                SourceImageSettings.ComputerSettings.CurrentImgIndex = 0;

            if (SourceImageSettings.ComputerSettings.Images != null ||
                SourceImageSettings.ComputerSettings.Images.Count > 0 &&
                File.Exists(SourceImageSettings.ComputerSettings.Images[SourceImageSettings.ComputerSettings.CurrentImgIndex].FileName))
                outputImage = Image.FromFile(SourceImageSettings.ComputerSettings.Images[SourceImageSettings.ComputerSettings.CurrentImgIndex].FileName);

            return outputImage;
        }
        //private Image SnapImage_Camera_Hikrobot(bool isInMainAction = false)
        //{
        //    lock (LockTriggerSoftwareObject)
        //    {
        //        Stopwatch stopwatch = null;
        //        try
        //        {

        //            if (SourceImageSettings == null ||
        //                SourceImageSettings.CameraSettings.HikCamera == null ||
        //                !SourceImageSettings.CameraSettings.HikCamera.IsOpen)
        //                return null;


        //            _snapImage = SourceImageSettings.CameraSettings.HikCamera.Snap(
        //                (SourceImageSettings.IsTriggerOn && !isInMainAction) || IsTri ||
        //                !SourceImageSettings.IsTriggerOn);

        //            if (!string.IsNullOrEmpty(SourceImageSettings.CameraSettings.HikCamera.ErrorMessage))
        //                GlobFuncs.SaveErr(SourceImageSettings.CameraSettings.HikCamera.ErrorMessage);

        //            return _snapImage;
        //        }
        //        catch (Exception ex)
        //        {
        //            GlobFuncs.SaveErr(ex);
        //            return null;
        //        }
        //        finally
        //        {
        //            if (GlobVar.RTCVision.DelayTimeOptions.GrabImageFixedTime > 0 && stopwatch != null)
        //            {
        //                stopwatch.Stop();
        //                int delayTime = GlobVar.RTCVision.DelayTimeOptions.GrabImageFixedTime -
        //                                (int)stopwatch.ElapsedMilliseconds;
        //                if (delayTime > 0)
        //                    Thread.Sleep(delayTime);
        //            }

        //            IsTriggerBySoftware = false;
        //        }
        //    }
        //}
        public void SetImageToAllAction(Image image)
        {
            if (Actions != null && Actions.ContainsKey(IDMainAction))
            {
                Actions[IDMainAction].InputImage.rtcValue = image;
                if (image != null)
                {
                    Actions[IDMainAction].InputBgrImage.rtcValue = GlobFuncs.BitmapToBgrImage(new Bitmap(image));
                    Actions[IDMainAction].InputGrayImage.rtcValue = GlobFuncs.BitmapToGrayImage(new Bitmap(image));
                }
                var listActions = Actions.Values.Where(x => x.InputImage != null).ToList();

                if (listActions.Any())
                    foreach (var action in listActions)
                        if (action.InputImage.rtcIDRef == IDMainAction)
                        {
                            action.InputImage.rtcValue = Actions[IDMainAction].InputImage.rtcValue;
                            action.MyGroup.SetValueToDicRefValue(action, nameof(action.InputImage), action.InputImage.rtcValue);
                            action.InputGrayImage.rtcValue = Actions[IDMainAction].InputGrayImage.rtcValue;
                            action.MyGroup.SetValueToDicRefValue(action, nameof(action.InputGrayImage), action.InputGrayImage.rtcValue);
                            action.InputBgrImage.rtcValue = Actions[IDMainAction].InputBgrImage.rtcValue;
                            action.MyGroup.SetValueToDicRefValue(action, nameof(action.InputBgrImage), action.InputBgrImage.rtcValue);
                        }
            }
        }

        public void DisconnectCamera()
        {
            try
            {
                if (SourceImageSettings == null || SourceImageSettings.ImageSourceType != EImageSourceTypes.Camera)
                    return;
                SetLiveCamera(false);
                if (SourceImageSettings.CameraSettings.InterfaceName == "DirectShow")
                {
                    SourceImageSettings.CameraSettings.IsLive = false;

                    SourceImageSettings.CameraSettings.IsCreatddtAllProps = false;
                    SourceImageSettings.CameraSettings.dtAllProps = null;
                    SourceImageSettings.CameraSettings.AllProps = null;
                }
                else
                {
                    switch (SourceImageSettings.CameraSettings.SdkMode)
                    {
                        case ESdkModes.Hikrobot:
                            {
                                DisconnectCamera_Hikrobot();
                                break;
                            }
                        case ESdkModes.HikrobotGenTL:
                            {
                                DisconnectCamera_Hikrobot();
                                break;
                            }
                        case ESdkModes.Basler:
                            {
                                DisconnectCamera_Basler();
                                break;
                            }
                        case ESdkModes.Dahua:
                            {
                                DisconnectCamera_Dahua();
                                break;
                            }

                    }
                }
                SourceImageSettings.CameraSettings.IsConnected = false;
                if (GlobVar.ListCams != null &&
                    GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                {
                    DisconnectCamera(GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings);
                    GlobVar.ListCams.Remove(SourceImageSettings.CameraSettings.DeviceName);
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Hàm ngắt két nối cam của 1 kết nối bất kỳ
        /// </summary>
        /// <param name="sourceImageSettings">Đối tượng chứa thông tin kết nối</param>
        public void DisconnectCamera(cSourceImageSettings sourceImageSettings)
        {
            if (sourceImageSettings == null || sourceImageSettings.ImageSourceType != EImageSourceTypes.Camera)
                return;
            if (sourceImageSettings.CameraSettings.InterfaceName == "DirectShow")
            {
                sourceImageSettings.CameraSettings.IsLive = false;
                sourceImageSettings.CameraSettings.IsCreatddtAllProps = false;
                sourceImageSettings.CameraSettings.dtAllProps = null;
                sourceImageSettings.CameraSettings.AllProps = null;
            }
            else
            {
                switch (sourceImageSettings.CameraSettings.SdkMode)
                {
                    case ESdkModes.Hikrobot:
                        {
                            DisconnectCamera_Hikrobot(sourceImageSettings);
                            break;
                        }
                    case ESdkModes.Basler:
                        {
                            DisconnectCamera_Basler();
                            break;
                        }
                    case ESdkModes.HikrobotGenTL:
                        {
                            DisconnectCamera_Hikrobot(sourceImageSettings);
                            break;
                        }
                }
            }
            sourceImageSettings.CameraSettings.IsConnected = false;
        }

        private void DisconnectCamera_Hikrobot(cSourceImageSettings sourceImageSettings)
        {

            if (SourceImageSettings.CameraSettings.HikCamera == null || SourceImageSettings.CameraSettings.HikCamera.GetCameraHandle() == IntPtr.Zero)
                return;

            SourceImageSettings.CameraSettings.HikCamera.MV_CC_StopGrabbing_NET();
            SourceImageSettings.CameraSettings.HikCamera.MV_CC_CloseDevice_NET();
            SourceImageSettings.CameraSettings.HikCamera = null;

        }

        private void DisconnectCamera_Basler()
        {

            if (SourceImageSettings.CameraSettings.BaslerCamera == null ||
             !SourceImageSettings.CameraSettings.BaslerCamera.IsConnected)
                return;

            SourceImageSettings.CameraSettings.BaslerCamera.Close();
            SourceImageSettings.CameraSettings.BaslerCamera = null;
        }

        private void DisconnectCamera_Dahua()
        {
            if (SourceImageSettings.CameraSettings.DahuaCamera == null
                 || !SourceImageSettings.CameraSettings.DahuaCamera.IsConnected)
                return;

            SourceImageSettings.CameraSettings.DahuaCamera.Close();
            SourceImageSettings.CameraSettings.DahuaCamera = null;
        }

        private void DisconnectCamera_Hikrobot()
        {
            if (SourceImageSettings.CameraSettings.HikCamera == null || SourceImageSettings.CameraSettings.HikCamera.GetCameraHandle() == IntPtr.Zero)
                return;

            SourceImageSettings.CameraSettings.HikCamera.MV_CC_StopGrabbing_NET();
            SourceImageSettings.CameraSettings.HikCamera.MV_CC_CloseDevice_NET();
            SourceImageSettings.CameraSettings.HikCamera = null;

        }
        /// <summary>
        /// Chuyển camera về trạng thái live
        /// </summary>
        /// <param name="isLive"> Cờ báo là live hay tắt live </param>
        /// <returns>true: Thành công; False: Thất bại</returns>
        public bool SetLiveCamera(bool isLive = true)
        {
            if (SourceImageSettings.CameraSettings.InterfaceName == "DirectShow")
                return SetLiveCamera_DirectShow(isLive);
            else
                switch (SourceImageSettings.CameraSettings.SdkMode)
                {
                    case ESdkModes.Hikrobot:
                    case ESdkModes.HikrobotGenTL:
                        return SetLiveCamera_Hikrobot(isLive);
                    case ESdkModes.Basler:
                        return SetLiveCamera_Basler(isLive);
                    case ESdkModes.Dahua:
                        return SetLiveCamera_Dahua(isLive);
                    default:
                        return true;

                }
        }

        private bool SetLiveCamera_Dahua(bool isLive)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool SetLiveCamera_Basler(bool isLive = true)
        {
            try
            {
                if (SourceImageSettings == null ||
                    SourceImageSettings.CameraSettings.BaslerCamera == null ||
                    !SourceImageSettings.CameraSettings.BaslerCamera.IsConnected)
                    return false;
                if (SourceImageSettings.CameraSettings.IsLive == isLive)
                    return true;
                SourceImageSettings.CameraSettings.IsLive = isLive;
                if (isLive)
                {
                    SnapImage(true);
                    StartLiveBackgroundWorker(BackgroundWorkerLiveWebCam_Basler_DoWork, LiveBackgroundWorkerCompleted);
                }
                else
                    StopLiveBackgroundWorker();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void BackgroundWorkerLiveWebCam_Basler_DoWork(object sender, DoWorkEventArgs e)
        {
            while (SourceImageSettings.CameraSettings.IsLive && SmartWindowControl != null)
            {
                var Image = SnapImage_Camera_Basler();
                if (Image != null)
                {
                    SmartWindowControl.Image = Image;
                }
            }
        }

        private Bitmap SnapImage_Camera_Basler(bool isInMainAction = false)
        {
            try
            {
                if (SourceImageSettings == null || SourceImageSettings.CameraSettings.BaslerCamera == null
                    || !SourceImageSettings.CameraSettings.BaslerCamera.IsConnected)
                    return null;
                if (isInMainAction &&
                       SourceImageSettings.IsUseDefaultCameraSettingBeforeSnap &&
                       !SourceImageSettings.IsSetDefaultCameraSettingBeforeSnapFinish)
                {
                    SourceImageSettings.CameraSettings.SetDefaultValue();
                    Thread.Sleep(GlobVar.RTCVision.RunOptions.WaitTimeWhenChangeCameraSettings_Basler);
                    SourceImageSettings.IsSetDefaultCameraSettingBeforeSnapFinish = true;
                    SourceImageSettings.CameraSettings.CurrentSettingTemplateName = string.Empty;
                }
                return SourceImageSettings.CameraSettings.BaslerCamera.Snap((SourceImageSettings.IsTriggerOn && !isInMainAction) ||
                                                                         IsTriggerBySoftware ||
                                                                         !SourceImageSettings.IsTriggerOn);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool SetLiveCamera_Hikrobot(bool isLive = true)
        {
            try
            {
                if (SourceImageSettings == null ||
                    SourceImageSettings.CameraSettings.HikCamera == null ||
                    SourceImageSettings.CameraSettings.HikCamera.GetCameraHandle() == IntPtr.Zero)
                    return false;

                SourceImageSettings.CameraSettings.IsLive = isLive;
                if (isLive)
                {
                    SnapImage(true);
                    StartLiveBackgroundWorker(BackgroundWorkerLiveWebCam_Hikrobot_DoWork, LiveBackgroundWorkerCompleted);
                }
                else
                    StopLiveBackgroundWorker();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void StopLiveBackgroundWorker()
        {
            if (liveBackgroundWorker != null && liveBackgroundWorker.IsBusy)
                liveBackgroundWorker.CancelAsync();
            Thread.Sleep(100);
        }
        private void StartLiveBackgroundWorker(DoWorkEventHandler doWorkFunc, RunWorkerCompletedEventHandler runWorkerCompletedFunc)
        {
            StopLiveBackgroundWorker();
            liveBackgroundWorker = new BackgroundWorker();
            liveBackgroundWorker.WorkerSupportsCancellation = true;
            liveBackgroundWorker.DoWork -= doWorkFunc;
            liveBackgroundWorker.DoWork += doWorkFunc;
            liveBackgroundWorker.RunWorkerCompleted -= runWorkerCompletedFunc;
            liveBackgroundWorker.RunWorkerCompleted += runWorkerCompletedFunc;
            liveBackgroundWorker.RunWorkerAsync();

        }

        private void LiveBackgroundWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SnapImage(true);
            if (liveBackgroundWorker != null)
            {
                liveBackgroundWorker.Dispose();
                liveBackgroundWorker = null;
            }
        }

        private bool SetLiveCamera_DirectShow(bool isLive)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorkerLiveWebCam_DoWork;
            backgroundWorker.RunWorkerAsync();
            return true;

        }
        private void BackgroundWorkerLiveWebCam_Hikrobot_DoWork(object sender,
            DoWorkEventArgs e)
        {
            while (SourceImageSettings.CameraSettings.IsLive && SmartWindowControl != null)
            {
                var bitmap = SnapImage_Camera_Hikrobot();
                if (bitmap != null)
                {
                    SmartWindowControl.Image = bitmap;
                }
                if (liveBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private Bitmap SnapImage_Camera_Hikrobot(bool isInMainAction = false)
        {
            lock (LockTriggerSoftwareObject)
            {
                Stopwatch stopwatch = null;
                try
                {
                    Bitmap _snapImage = null;
                    if (isInMainAction && SourceImageSettings != null &&
                        SourceImageSettings.IsUseDefaultCameraSettingBeforeSnap &&
                        !SourceImageSettings.IsSetDefaultCameraSettingBeforeSnapFinish)
                    {
                        SourceImageSettings.CameraSettings.SetDefaultValue();
                        Thread.Sleep(GlobVar.RTCVision.RunOptions.WaitTimeWhenChangeCameraSettings_Hikrobot);
                        SourceImageSettings.IsSetDefaultCameraSettingBeforeSnapFinish = true;
                        SourceImageSettings.CameraSettings.CurrentSettingTemplateName = string.Empty;
                    }

                    if (GlobVar.RTCVision.DelayTimeOptions.GrabImageFixedTime > 0)
                    {
                        stopwatch = new Stopwatch();
                        stopwatch.Start();
                    }

                    _snapImage = SourceImageSettings.CameraSettings.HikCamera?.Snap(
                        (SourceImageSettings.IsTriggerOn && !isInMainAction) || IsTriggerBySoftware ||
                        !SourceImageSettings.IsTriggerOn);

                    if (!string.IsNullOrEmpty(SourceImageSettings.CameraSettings.HikCamera?.ErrorMessage))
                        GlobFuncs.SaveErr(SourceImageSettings.CameraSettings.HikCamera.ErrorMessage);

                    return _snapImage;
                }
                catch (Exception ex)
                {
                    GlobFuncs.SaveErr(ex);
                    return null;
                }
                finally
                {
                    if (GlobVar.RTCVision.DelayTimeOptions.GrabImageFixedTime > 0 && stopwatch != null)
                    {
                        stopwatch.Stop();
                        int delayTime = GlobVar.RTCVision.DelayTimeOptions.GrabImageFixedTime -
                                        (int)stopwatch.ElapsedMilliseconds;
                        if (delayTime > 0)
                            Thread.Sleep(delayTime);
                    }

                    IsTriggerBySoftware = false;
                }
            }
        }

        private Bitmap SnapImage_Camera_Hikrobot_Process()
        {
            var stFrameOut = new MyHikCamera.MV_FRAME_OUT();
            Bitmap bitmap = null;
            var pImageBuf = IntPtr.Zero;
            var nRet = -1;
            try
            {
                var nImageBufSize = 0;
                var pTemp = IntPtr.Zero;

                nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_GetImageBuffer_NET(ref stFrameOut, 1000);
                if (MyHikCamera.MV_OK == nRet)
                {
                    if (!RunSimple && SourceImageSettings.CameraSettings.IsAutoSaveImage)
                        Task.Factory.StartNew(() => SnapImage_Camera_Hikrobot_SaveOriginImage(stFrameOut));

                    if (IsColorPixelFormat(stFrameOut.stFrameInfo.enPixelType))
                    {
                        if (stFrameOut.stFrameInfo.enPixelType == MyHikCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                        {
                            pTemp = stFrameOut.pBufAddr;

                        }
                        else
                        {
                            if (IntPtr.Zero == pImageBuf || nImageBufSize <
                                stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * 3)
                            {
                                if (pImageBuf != IntPtr.Zero)
                                {
                                    Marshal.FreeHGlobal(pImageBuf);
                                    pImageBuf = IntPtr.Zero;
                                }
                                pImageBuf = Marshal.AllocHGlobal((int)stFrameOut.stFrameInfo.nWidth *
                                    stFrameOut.stFrameInfo.nHeight * 3);
                                if (IntPtr.Zero == pImageBuf)
                                    return null;
                                nImageBufSize = stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * 3;
                            }
                            var stPixelConvertParam =
                                new MyHikCamera.MV_PIXEL_CONVERT_PARAM();
                            stPixelConvertParam.pSrcData = stFrameOut.pBufAddr;
                            stPixelConvertParam.nWidth = stFrameOut.stFrameInfo.nWidth;
                            stPixelConvertParam.nHeight = stFrameOut.stFrameInfo.nHeight;
                            stPixelConvertParam.enSrcPixelType = stFrameOut.stFrameInfo.enPixelType;
                            stPixelConvertParam.nSrcDataLen = stFrameOut.stFrameInfo.nFrameLen;

                            stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                            stPixelConvertParam.pDstBuffer = pImageBuf;
                            stPixelConvertParam.enDstPixelType = MyHikCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                            nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_ConvertPixelType_NET(
                                ref stPixelConvertParam);
                            if (MyHikCamera.MV_OK != nRet)
                                return null;
                            pTemp = pImageBuf;
                            bitmap = new Bitmap(stPixelConvertParam.nWidth, stPixelConvertParam.nHeight, PixelFormat.Format32bppRgb);
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, stPixelConvertParam.nWidth, stPixelConvertParam.nHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                            bitmap.UnlockBits(bitmapData);

                        }
                    }
                    else if (isMonoPixelFormat(stFrameOut.stFrameInfo.enPixelType))
                    {
                        if (stFrameOut.stFrameInfo.enPixelType == MyHikCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                        {
                            pTemp = stFrameOut.pBufAddr;
                        }
                        else
                        {
                            if (IntPtr.Zero == pImageBuf ||
                                nImageBufSize < stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight)
                            {
                                if (pImageBuf != IntPtr.Zero)
                                {
                                    Marshal.FreeHGlobal(pImageBuf);
                                    pImageBuf = IntPtr.Zero;
                                }
                                pImageBuf = Marshal.AllocHGlobal((int)stFrameOut.stFrameInfo.nWidth *
                                                                 stFrameOut.stFrameInfo.nHeight);
                                if (IntPtr.Zero == pImageBuf)
                                    return null;
                                nImageBufSize = stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight;
                            }
                            var stPixelConvertParam =
                                new MyHikCamera.MV_PIXEL_CONVERT_PARAM();
                            stPixelConvertParam.pSrcData = stFrameOut.pBufAddr;
                            stPixelConvertParam.nWidth = stFrameOut.stFrameInfo.nWidth;
                            stPixelConvertParam.nHeight = stFrameOut.stFrameInfo.nHeight;
                            stPixelConvertParam.enSrcPixelType = stFrameOut.stFrameInfo.enPixelType;
                            stPixelConvertParam.nSrcDataLen = stFrameOut.stFrameInfo.nFrameLen;

                            stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                            stPixelConvertParam.pDstBuffer = pImageBuf;
                            stPixelConvertParam.enDstPixelType = MyHikCamera.MvGvspPixelType.PixelType_Gvsp_HB_Mono8;
                            nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_ConvertPixelType_NET(
                                ref stPixelConvertParam);
                            if (MyHikCamera.MV_OK != nRet)
                                return null;
                            pTemp = pImageBuf;
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, stPixelConvertParam.nWidth, stPixelConvertParam.nHeight), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                            bitmap.UnlockBits(bitmapData);
                        }

                    }
                }
                else
                {
                    return null;
                }
                if (bitmap != null)
                    return bitmap;
                else
                    return null;

            }
            finally
            {
                SourceImageSettings.CameraSettings.HikCamera.MV_CC_FreeImageBuffer_NET(ref stFrameOut);
                if (pImageBuf != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pImageBuf);
                    pImageBuf = IntPtr.Zero;
                }
            }
        }

        private bool isMonoPixelFormat(MyHikCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;
                default:
                    return false;
            }
        }

        private bool IsColorPixelFormat(MyHikCamera.MvGvspPixelType enType)
        {

            switch (enType)
            {
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyHikCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                    return true;

                default:
                    return false;
            }
        }

        public bool ConnectCamera()
        {
            var result = false;
            for (var i = 0; i < GlobVar.RTCVision.Options.NumberOfAttemptsToConnectTheCamera; i++)
            {
                result = ConnectCamera_Process();
                if (!result)
                    Thread.Sleep(GlobVar.RTCVision.Options.CameraConnectTimeOut);

            }
            return result;
        }

        private bool ConnectCamera_Process(bool force = false)
        {
            if (SourceImageSettings == null)
                return false;
            if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Computer)
                return true;
            switch (SourceImageSettings.CameraSettings.SdkMode)
            {
                case ESdkModes.Hikrobot:
                    {
                        return ConnectCamera_Process_Hikrobot(force);
                    }
                case ESdkModes.HikrobotGenTL:
                    {
                        return ConnectCamera_Process_HikrobotGenTl(force);
                    }
                case ESdkModes.Basler:
                    {
                        return ConnectCamera_Process_Basler(force);
                    }
                case ESdkModes.Dahua:
                    {
                        return ConnectCamera_Process_Dahua(force);
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private bool ConnectCamera_Process_Dahua(bool force = false)
        {

            if (!force)
                if (GlobVar.ListCams != null &&
                        GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                    if (GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.SdkMode == SourceImageSettings.CameraSettings.SdkMode)
                    {
                        SourceImageSettings.CameraSettings.DahuaCamera = GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.DahuaCamera;
                        if (GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.IsConnected)
                        {
                            SourceImageSettings.CameraSettings.IsConnected = true;
                            return true;
                        }
                    }
            SourceImageSettings.CameraSettings.IsConnected = false;
            try
            {
                SourceImageSettings.CameraSettings.DahuaCamera = new MyDahuaCamera();
                if (SourceImageSettings.CameraSettings.DahuaCamera.Open(SourceImageSettings.CameraSettings.DeviceName))
                {
                    // Thiết lập các thông số ban đầu cho camera
                    if (SourceImageSettings.CameraSettings.isAutoSetDefaultCAMSettingWhenConnect)
                        SourceImageSettings.CameraSettings.SetDefaultValue();
                    // Truyền các thông tin setup vào camera
                    SourceImageSettings.CameraSettings.DahuaCamera.GrabberMode = SourceImageSettings.IsTriggerOn ? CGrabberMode.Sync : SourceImageSettings.CameraSettings.GrabberMode;
                    //SourceImageSettings.CameraSettings.DahuaCamera.Merging = SourceImageSettings.CameraSettings.Merging;
                    //SourceImageSettings.CameraSettings.DahuaCamera.SnapCount = SourceImageSettings.CameraSettings.SnapCount;
                    //SourceImageSettings.CameraSettings.DahuaCamera.DirectionMerging = SourceImageSettings.CameraSettings.DirectionMerging;

                    SourceImageSettings.CameraSettings.DahuaCamera.GetImageBufferTimeOut = GlobVar.RTCVision.DahuaOptions.GetImageBufferTimeOut;
                    SourceImageSettings.CameraSettings.DahuaCamera.IntervalTimeCheckConnected = GlobVar.RTCVision.DahuaOptions.IntervalTimeCheckConnected;
                    SourceImageSettings.CameraSettings.DahuaCamera.AutoReconnect = GlobVar.RTCVision.RunOptions.AutoReconnectCam;

                    SourceImageSettings.CameraSettings.DahuaCamera.ClearAllEvents();
                    SourceImageSettings.CameraSettings.DahuaCamera.OnDahuaCameraStatusChangedEvents += MyCam.OnDahuaCameraStatusChangedEvents;

                    // Lấy thông tin IsTriggerOn
                    SourceImageSettings.IsTriggerOn = SourceImageSettings.CameraSettings.DahuaCamera.IsTriggerOn;

                    if (!SourceImageSettings.CameraSettings.DahuaCamera.StartGrabbing())
                    {
                        ErrMessage = SourceImageSettings.CameraSettings.DahuaCamera.ErrorMessage;
                        return false;
                    }
                    // Lưu trữ thông tin camera kết nối
                    SourceImageSettings.CameraSettings.InterfaceName = SourceImageSettings.CameraSettings.InterfaceName;
                    SourceImageSettings.CameraSettings.DeviceName = SourceImageSettings.CameraSettings.DeviceName;
                    SourceImageSettings.CameraSettings.DeviceNameOrigin = SourceImageSettings.CameraSettings.DeviceNameOrigin;
                    SourceImageSettings.CameraSettings.IsConnected = true;

                    if (GlobVar.ListCams == null)
                        GlobVar.ListCams = new Dictionary<string, Guid>();
                    if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                        GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);

                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.IsConnected = true;
                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
                    return true;
                }
                else
                {
                    ErrMessage = SourceImageSettings.CameraSettings.DahuaCamera.ErrorMessage;
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        private bool ConnectCamera_Process_Basler(bool force = false)
        {
            if (!force)
                if (GlobVar.ListCams != null &&
                        GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                    if (GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.SdkMode == SourceImageSettings.CameraSettings.SdkMode)
                    {
                        SourceImageSettings.CameraSettings.BaslerCamera = GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.BaslerCamera;

                        if (GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.IsConnected)
                        {
                            SourceImageSettings.CameraSettings.IsConnected = true;
                            return true;
                        }
                    }
            SourceImageSettings.CameraSettings.IsConnected = false;
            SourceImageSettings.CameraSettings.BaslerCamera = new MyBaslerCamera();

            var result = false;


            try
            {
                SourceImageSettings.CameraSettings.BaslerCamera = null;
                Dictionary<string, ICameraInfo> foundCameraInfos = GlobFuncs.GetBaslerCameraInfos();
                if (foundCameraInfos.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                {
                    SourceImageSettings.CameraSettings.BaslerCamera = new MyBaslerCamera(GlobVar.RTCVision.BaslerOptions.GrabByEvent);
                    SourceImageSettings.CameraSettings.BaslerCamera.Open(SourceImageSettings.CameraSettings.DeviceName);
                    if (!SourceImageSettings.CameraSettings.BaslerCamera.IsConnected)
                    {
                        ErrMessage = SourceImageSettings.CameraSettings.BaslerCamera.ErrorMessage;
                        SourceImageSettings.CameraSettings.BaslerCamera = null;
                        return false;
                    }
                }

                if (SourceImageSettings.CameraSettings.BaslerCamera != null)
                {

                    SourceImageSettings.CameraSettings.IsConnected = true;
                    if (SourceImageSettings.CameraSettings.isAutoSetDefaultCAMSettingWhenConnect)
                        SourceImageSettings.CameraSettings.SetDefaultValue();

                    SourceImageSettings.IsTriggerOn =
                        GlobFuncs.Basler_IsTriggerOn(SourceImageSettings.CameraSettings.BaslerCamera);
                    SourceImageSettings.IsTriggerOn = SourceImageSettings.CameraSettings.BaslerCamera.IsTriggerOn;
                    SourceImageSettings.CameraSettings.BaslerCamera.GrabberMode = SourceImageSettings.IsTriggerOn ? CGrabberMode.Sync : SourceImageSettings.CameraSettings.GrabberMode;
                    SourceImageSettings.CameraSettings.BaslerCamera.AutoReconnect = GlobVar.RTCVision.RunOptions.AutoReconnectCam;

                    SourceImageSettings.CameraSettings.BaslerCamera.MaxNumBuffer = GlobVar.RTCVision.BaslerOptions.MaxNumBuffer;
                    SourceImageSettings.CameraSettings.BaslerCamera.IntervalTimeCheckConnected = GlobVar.RTCVision.BaslerOptions.IntervalTimeCheckConnected;

                    //SourceImageSettings.CameraSettings.BaslerCamera.Merging = SourceImageSettings.CameraSettings.Merging;
                    //SourceImageSettings.CameraSettings.BaslerCamera.DirectionMerging = SourceImageSettings.CameraSettings.DirectionMerging;
                    //SourceImageSettings.CameraSettings.BaslerCamera.SnapCount = SourceImageSettings.CameraSettings.SnapCount;

                    // Truyền event ra ngoài
                    SourceImageSettings.CameraSettings.BaslerCamera.ClearAllEvents();
                    SourceImageSettings.CameraSettings.BaslerCamera.OnBaslerCameraStatusChangedEvents += MyCam.OnBaslerCameraStatusChangedEvents;

                    SourceImageSettings.CameraSettings.BaslerCamera.StartGrabbing();
                    if (GlobVar.ListCams == null)
                        GlobVar.ListCams = new Dictionary<string, Guid>();
                    if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                        GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);
                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.IsConnected = true;
                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        private bool ConnectCamera_Process_HikrobotGenTl(bool force = false)
        {
            if (!force)
                if (GlobVar.ListCams != null &&
                        GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                    if (GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.SdkMode == SourceImageSettings.CameraSettings.SdkMode)
                    {
                        SourceImageSettings.CameraSettings.HikCamera = GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.HikCamera;

                        if (GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.IsConnected)
                        {
                            SourceImageSettings.CameraSettings.IsConnected = true;
                            return true;
                        }
                    }
            SourceImageSettings.CameraSettings.IsConnected = false;
            SourceImageSettings.CameraSettings.HikCamera = new MyHikCamera();

            try
            {
                var deviceIndex = -1;
                MyHikCamera.MV_GENTL_DEV_INFO_LIST gentlDevInfoList = new MyHikCamera.MV_GENTL_DEV_INFO_LIST();
                MyHikCamera.MV_GENTL_IF_INFO stIFInfo = GlobFuncs.GetHikrobotGenICamTLInterfaceInfo(SourceImageSettings.CameraSettings.InterfaceName);
                int nRet = MyHikCamera.MV_CC_EnumDevicesByGenTL_NET(ref stIFInfo, ref gentlDevInfoList);
                if (0 != nRet)
                {
                    return false;
                }
                for (var i = 0; i < gentlDevInfoList.nDeviceNum; i++)
                {
                    var device1 =
                        (MyHikCamera.MV_GENTL_DEV_INFO)Marshal.PtrToStructure(gentlDevInfoList.pDeviceInfo[i],
                        typeof(MyHikCamera.MV_GENTL_DEV_INFO));

                    if (device1.chUserDefinedName != "")
                        deviceIndex = "Dev: " + device1.chUserDefinedName + " (" + device1.chSerialNumber + ")" == SourceImageSettings.CameraSettings.DeviceName
                            ? i : -1;
                    else
                        deviceIndex = "Dev: " + device1.chVendorName + " " + device1.chModelName + " (" + device1.chSerialNumber +
                            ")" == SourceImageSettings.CameraSettings.DeviceName
                            ? i
                            : -1;
                    if (deviceIndex != -1)
                        break;
                }
                if (deviceIndex == -1)
                    return false;
                // open device
                if (null == SourceImageSettings.CameraSettings.HikCamera)
                {
                    SourceImageSettings.CameraSettings.HikCamera = new MyHikCamera();
                    if (null == SourceImageSettings.CameraSettings.HikCamera)
                        return false;
                }
                var device =
                    (MyHikCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(
                    gentlDevInfoList.pDeviceInfo[deviceIndex], typeof(MyHikCamera.MV_CC_DEVICE_INFO));
                nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_CreateDevice_NET(ref device);
                if (MyHikCamera.MV_OK != nRet)
                {
                    return false;
                }
                nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_OpenDevice_NET();
                if (MyHikCamera.MV_OK != nRet)
                {
                    SourceImageSettings.CameraSettings.HikCamera.MV_CC_DestroyDevice_NET();
                    return false;
                }
                MyHikCamera.MV_CAM_TRIGGER_MODE camTriggerMode = MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF;
                if (!GlobFuncs.HIK_GetTriggerMode(SourceImageSettings.CameraSettings.HikCamera, ref camTriggerMode))
                    camTriggerMode = MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF;
                SourceImageSettings.IsTriggerOn = camTriggerMode == MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON;

                nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_StartGrabbing_NET();
                if (MyHikCamera.MV_OK != nRet)
                {
                    return false;
                }
                if (GlobVar.ListCams == null)
                    GlobVar.ListCams = new Dictionary<string, Guid>();
                if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                    GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);
                SourceImageSettings.CameraSettings.IsConnected = true;
                GlobVar.CurrentProject
                    .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                    .SourceImageSettings.CameraSettings.IsConnected = true;
                GlobVar.CurrentProject
                    .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                    .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
                return true;
            }


            catch (Exception ex)
            {
                return false;
            }

        }

        private bool ConnectCamera_Process_Hikrobot(bool force = false)
        {
            if (!force)
                if (GlobVar.ListCams != null && GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                    if (GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.SdkMode == SourceImageSettings.CameraSettings.SdkMode)
                    {
                        SourceImageSettings.CameraSettings.HikCamera = GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.HikCamera;

                        if (GlobVar.CurrentProject
                            .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                            .SourceImageSettings.CameraSettings.IsConnected)
                        {
                            SourceImageSettings.CameraSettings.IsConnected = true;
                            return true;
                        }
                    }

            SourceImageSettings.CameraSettings.IsConnected = true;
            SourceImageSettings.CameraSettings.HikCamera = new MyHikCamera();
            try
            {

                SourceImageSettings.CameraSettings.HikCamera = new MyHikCamera();
                MyHikCamera.MV_CC_DEVICE_INFO device = GlobFuncs.GetHikrobotDeviceInfo(SourceImageSettings.CameraSettings.DeviceName, out bool isExists);
                var nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_CreateDevice_NET(ref device);
                if (MyHikCamera.MV_OK != nRet)
                {
                    ErrMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                    return false;
                }


                nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_OpenDevice_NET();
                if (MyHikCamera.MV_OK != nRet)
                {
                    SourceImageSettings.CameraSettings.HikCamera.MV_CC_DestroyDevice_NET();
                    ErrMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                    return false;
                }
                if (device.nTLayerType == MyHikCamera.MV_GIGE_DEVICE)
                {
                    var nPacketSize = SourceImageSettings.CameraSettings.HikCamera.MV_CC_GetOptimalPacketSize_NET();
                    if (nPacketSize > 0)
                    {
                        nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_SetIntValueEx_NET(
                            "GevSCPSPacketSize", nPacketSize);
                        if (nRet != MyHikCamera.MV_OK)
                        {
                            ErrMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                if (SourceImageSettings.CameraSettings.HikCamera != null)
                {
                    SourceImageSettings.IsTriggerOn = SourceImageSettings.CameraSettings.HikCamera.IsTriggerOn;

                    if (!SourceImageSettings.CameraSettings.HikCamera.StartGrabbing())
                    {
                        ErrMessage = SourceImageSettings.CameraSettings.HikCamera.ErrorMessage;
                        return false;
                    }
                    SourceImageSettings.CameraSettings.InterfaceName = SourceImageSettings.CameraSettings.InterfaceName;
                    SourceImageSettings.CameraSettings.DeviceName = SourceImageSettings.CameraSettings.DeviceName;
                    SourceImageSettings.CameraSettings.DeviceNameOrigin = SourceImageSettings.CameraSettings.DeviceNameOrigin;
                    SourceImageSettings.CameraSettings.IsConnected = true;
                    if (SourceImageSettings.CameraSettings.isAutoSetDefaultCAMSettingWhenConnect)
                        SourceImageSettings.CameraSettings.SetDefaultValue();

                    if (GlobVar.ListCams == null)
                        GlobVar.ListCams = new Dictionary<string, Guid>();
                    if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                        GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);

                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.IsConnected = true;
                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            ///

            //    MyHikCamera.MV_CC_DEVICE_INFO device = GlobFuncs.GetHikrobotDeviceInfo(SourceImageSettings.CameraSettings.DeviceName, out bool isExists);
            //    var nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_CreateDevice_NET(ref device);
            //    if (MyHikCamera.MV_OK != nRet)
            //        return false;

            //    SourceImageSettings.IsTriggerOn = SourceImageSettings.CameraSettings.HikCamera.IsTriggerOn;

            //    if (!SourceImageSettings.CameraSettings.HikCamera.StartGrabbing())
            //    {
            //        ErrMessage = SourceImageSettings.CameraSettings.HikCamera.ErrorMessage;
            //        return false;
            //    }
            //    if (device.nTLayerType == MyHikCamera.MV_GIGE_DEVICE)
            //    {
            //        var nPacketSize = SourceImageSettings.CameraSettings.HikCamera.MV_CC_GetOptimalPacketSize_NET();
            //        if (nPacketSize > 0)
            //        {
            //            nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_SetIntValueEx_NET(
            //                "GevSCPSPacketSize", nPacketSize);
            //            if (nRet != MyHikCamera.MV_OK)
            //                return false;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }

            //    if (GlobVar.ListCams == null)
            //        GlobVar.ListCams = new Dictionary<string, Guid>();
            //    if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
            //        GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);
            //    SourceImageSettings.CameraSettings.IsConnected = true;
            //    GlobVar.CurrentProject
            //        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
            //        .SourceImageSettings.CameraSettings.IsConnected = true;
            //    GlobVar.CurrentProject
            //        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
            //        .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
            //    return true;
            //}

            catch (Exception ex)
            {
                return false;
            }

        }


        public void DisconnectAllCameraUse()
        {
            DisconnectCamera();
            var listRunProgramActions = Actions.Values.Where(x => x.ActionType == EActionTypes.RunProgram).ToList();
            if (listRunProgramActions.Any())
                foreach (cAction action in listRunProgramActions)
                {
                    cCAMTypes cam =
                        GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x =>
                        x.Name == action.ProgramName.rtcValue);
                    if (cam == null)
                        continue;
                    cam.GroupActions?.DisconnectCamera();
                }
            // Tìm danh sách các tool setting camera
            var listCameraSettingsActions = Actions.Values.Where(x => x.ActionType == EActionTypes.CameraSettings).ToList();
            if (listCameraSettingsActions.Any())
                foreach (cAction action in listCameraSettingsActions)
                    action.MyGroup.DisconnectCamera();
        }
        private void SnapImage_Camera_Hikrobot_SaveOriginImage(MyHikCamera.MV_FRAME_OUT stFrameOut)
        {
            var fileName = SaveOriginImage_CreateFileName();
            if (SourceImageSettings.CameraSettings.IsAutoCreateFolderByDate)
                CreateSaveFolder();
            fileName = Path.Combine(SourceImageSettings.CameraSettings.IsAutoCreateFolderByDate
                ? SourceImageSettings.CameraSettings.SaveImageFolder_Origin_Withday
                : SourceImageSettings.CameraSettings.SaveImageFolder_Origin, fileName);
            lock (BufForDriverLock)
            {
                if (m_BufForDriver == IntPtr.Zero || stFrameOut.stFrameInfo.nFrameLen > m_nBufSizeForDriver)
                {
                    if (m_BufForDriver != IntPtr.Zero)
                    {
                        Marshal.Release(m_BufForDriver);
                        m_BufForDriver = IntPtr.Zero;
                    }
                    m_BufForDriver = Marshal.AllocHGlobal((int)stFrameOut.stFrameInfo.nFrameLen);
                    if (m_BufForDriver == IntPtr.Zero) return;

                    m_nBufSizeForDriver = stFrameOut.stFrameInfo.nFrameLen;
                }
                CopyMemory(m_BufForDriver, stFrameOut.pBufAddr, stFrameOut.stFrameInfo.nFrameLen);
                var stSaveFileParam = new MyHikCamera.MV_SAVE_IMG_TO_FILE_PARAM();
                stSaveFileParam.enImageType = SourceImageSettings.CameraSettings.SaveImageType == cImageTypes.bmp
                    ? MyHikCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp
                    : SourceImageSettings.CameraSettings.SaveImageType == cImageTypes.jpg
                        ? MyHikCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Jpeg
                        : MyHikCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Png;
                stSaveFileParam.enPixelType = stFrameOut.stFrameInfo.enPixelType;
                stSaveFileParam.pData = m_BufForDriver;
                stSaveFileParam.nDataLen = stFrameOut.stFrameInfo.nFrameLen;
                stSaveFileParam.nHeight = stFrameOut.stFrameInfo.nHeight;
                stSaveFileParam.nWidth = stFrameOut.stFrameInfo.nWidth;
                stSaveFileParam.nQuality = 80;
                stSaveFileParam.iMethodValue = 2;
                stSaveFileParam.pImagePath = fileName;
                SourceImageSettings.CameraSettings.HikCamera.MV_CC_SaveImageToFile_NET(ref stSaveFileParam);

            }
        }

        internal void GetDeviceInfo(out DeviceInfo deviceInfo)
        {
            deviceInfo = null;
            switch (SourceImageSettings.CameraSettings.SdkMode)
            {
                case ESdkModes.Hikrobot:
                    {
                        GetDeviceInfo_Hikrobot(out deviceInfo);
                        break;
                    }
                case ESdkModes.HikrobotGenTL:
                    {
                        GetDeviceInfo_Hikrobot(out deviceInfo);
                        break;
                    }
                case ESdkModes.Basler:
                    {
                        GetDeviceInfo_Basler(out deviceInfo);
                        break;
                    }
                    //case ESdkModes.Dahua:
                    //    {
                    //        Getdev
                    //    }

            }
        }
        internal void GetDeviceInfo_Dahua(out DeviceInfo deviceInfo)
        {
            deviceInfo = new DeviceInfo();
            ICameraInfo cameraInfo = MyBaslerCamera.GetBaslerCameraInfo(SourceImageSettings.CameraSettings.DeviceName);
        }

        internal void GetDeviceInfo_Basler(out DeviceInfo deviceInfo)
        {
            deviceInfo = new DeviceInfo();
            ICameraInfo cameraInfo = MyBaslerCamera.GetBaslerCameraInfo(SourceImageSettings.CameraSettings.DeviceName);
        }

        internal void GetDeviceInfo_Hikrobot(out DeviceInfo deviceInfo)
        {
            deviceInfo = new DeviceInfo();
            try
            {
                if (string.IsNullOrEmpty(SourceImageSettings.CameraSettings.DeviceName))
                {
                    deviceInfo.ErrorMessage = cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                        new string[] { "Camera" }, new string[] { "Camera" });
                    return;
                }
                // Lấy thông tin camera đang chọn
                MyHikCamera.MV_CC_DEVICE_INFO device = GlobFuncs.GetHikrobotDeviceInfo(SourceImageSettings.CameraSettings.DeviceName, out bool isExist);
                if (!isExist)
                {
                    deviceInfo.ErrorMessage = cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists,
                        new string[] { "Camera" }, new string[] { "Camera" });
                    return;
                }
                // Check các thông tin địa chỉ ip config
                if (device.nTLayerType == MyHikCamera.MV_GIGE_DEVICE)
                {
                    deviceInfo.IsGIGE = true;
                    deviceInfo.IsExists = true;
                    MyHikCamera.MV_GIGE_DEVICE_INFO gigeInfo =
                        (MyHikCamera.MV_GIGE_DEVICE_INFO)MyHikCamera.ByteToStruct(device.SpecialInfo.stGigEInfo,
                        typeof(MyHikCamera.MV_GIGE_DEVICE_INFO));
                    deviceInfo.Manufacturer = gigeInfo.chManufacturerName;
                    deviceInfo.ModelName = gigeInfo.chModelName;
                    deviceInfo.SerialNumber = gigeInfo.chSerialNumber;
                    deviceInfo.Version = gigeInfo.chDeviceVersion;

                    uint nIp1 = ((gigeInfo.nCurrentIp & 0xff000000) >> 24);
                    uint nIp2 = ((gigeInfo.nCurrentIp & 0x00ff0000) >> 16);
                    uint nIp3 = ((gigeInfo.nCurrentIp & 0x0000ff00) >> 8);
                    uint nIp4 = ((gigeInfo.nCurrentIp & 0x000000ff));
                    deviceInfo.IpAddress = $"{nIp1}.{nIp2}.{nIp3}.{nIp4}";

                    uint nSm2 = ((gigeInfo.nCurrentSubNetMask & 0x00ff0000) >> 16);
                    uint nSm3 = ((gigeInfo.nCurrentSubNetMask & 0x0000ff00) >> 8);
                    uint nSm1 = ((gigeInfo.nCurrentSubNetMask & 0xff000000) >> 24);
                    uint nSm4 = ((gigeInfo.nCurrentSubNetMask & 0x000000ff));
                    deviceInfo.IpAddress = $"{nSm1}.{nSm2}.{nSm3}.{nSm4}";

                    uint nDg2 = ((gigeInfo.nDefultGateWay & 0x00ff0000) >> 16);
                    uint nDg3 = ((gigeInfo.nDefultGateWay & 0x0000ff00) >> 8);
                    uint nDg1 = ((gigeInfo.nDefultGateWay & 0xff000000) >> 24);
                    uint nDg4 = ((gigeInfo.nDefultGateWay & 0x000000ff));
                    deviceInfo.DefaultGateway = $"{nDg1}.{nDg2}.{nDg3}.{nDg4}";
                }
                else if (device.nTLayerType == MyHikCamera.MV_USB_DEVICE)
                {
                    deviceInfo.IsExists = true;
                    MyHikCamera.MV_USB3_DEVICE_INFO usbInfo =
                        (MyHikCamera.MV_USB3_DEVICE_INFO)MyHikCamera.ByteToStruct(device.SpecialInfo.stUsb3VInfo, typeof(MyHikCamera.MV_USB3_DEVICE_INFO));
                    deviceInfo.Manufacturer = usbInfo.chManufacturerName;
                    deviceInfo.ModelName = usbInfo.chModelName;
                    deviceInfo.SerialNumber = usbInfo.chSerialNumber;
                    deviceInfo.Version = usbInfo.chDeviceVersion;
                }
            }
            catch
            {
                deviceInfo = new DeviceInfo();
            }
        }

        private void BackgroundWorkerLiveWebCam_DoWork(object sender, DoWorkEventArgs e)
        {
            while (SourceImageSettings.CameraSettings.IsLive && SmartWindowControl != null)
            {

            }
        }

        public bool ConnectCamera(string interfaceName, string deviceName, string deviceNameOrigin, ref string errMessage)
        {
            errMessage = string.Empty;
            switch (SourceImageSettings.CameraSettings.SdkMode)
            {
                case ESdkModes.Hikrobot:
                    {
                        return ConnectCamera_Hikrobot(interfaceName, deviceName, deviceNameOrigin, ref ErrMessage);

                    }
                case ESdkModes.HikrobotGenTL:
                    {
                        return ConnectCamera_HikrobotGenTL(interfaceName, deviceName, deviceNameOrigin, ref errMessage);

                    }
                case ESdkModes.Basler:
                    {
                        return ConnectCamera_Basler(interfaceName, deviceName, deviceNameOrigin, ref errMessage);

                    }
                case ESdkModes.Dahua:
                    {
                        return ConnectCamera_Dahua(interfaceName, deviceName, deviceNameOrigin, ref errMessage);

                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private bool ConnectCamera_Dahua(string interfaceName, string deviceName, string deviceNameOrigin, ref string errMessage)
        {
            DisconnectCamera_Dahua();
            errMessage = string.Empty;
            var result = false;
            if (SourceImageSettings == null)
                return false;
            if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Computer)
                return true;
            if (GlobVar.ListCams != null && GlobVar.ListCams.Count > 0 && GlobVar.ListCams.ContainsKey(deviceName))
            {
                cCameraSettings otherCameraSettings = GlobVar.CurrentProject
                    .CAMs[GlobVar.ListCams[deviceName]].GroupActions
                    .SourceImageSettings.CameraSettings;
                if (otherCameraSettings.SdkMode == SourceImageSettings.CameraSettings.SdkMode)
                {
                    SourceImageSettings.CameraSettings.DahuaCamera = otherCameraSettings.DahuaCamera;
                    if (otherCameraSettings.IsConnected)
                    {
                        SourceImageSettings.CameraSettings.IsConnected = true;
                        return true;
                    }
                }
            }
            try
            {
                SourceImageSettings.CameraSettings.DahuaCamera = new MyDahuaCamera();
                if (SourceImageSettings.CameraSettings.DahuaCamera.Open(deviceName))
                {
                    // Thiết lập các thông số ban đầu cho camera
                    if (SourceImageSettings.CameraSettings.isAutoSetDefaultCAMSettingWhenConnect)
                        SourceImageSettings.CameraSettings.SetDefaultValue();
                    // Truyền các thông tin setup vào camera
                    SourceImageSettings.CameraSettings.DahuaCamera.GrabberMode = SourceImageSettings.IsTriggerOn ? CGrabberMode.Sync : SourceImageSettings.CameraSettings.GrabberMode;

                    SourceImageSettings.CameraSettings.DahuaCamera.GetImageBufferTimeOut = GlobVar.RTCVision.DahuaOptions.GetImageBufferTimeOut;
                    SourceImageSettings.CameraSettings.DahuaCamera.IntervalTimeCheckConnected = GlobVar.RTCVision.DahuaOptions.IntervalTimeCheckConnected;
                    SourceImageSettings.CameraSettings.DahuaCamera.AutoReconnect = GlobVar.RTCVision.RunOptions.AutoReconnectCam;

                    // Truyền event ra ngoài
                    SourceImageSettings.CameraSettings.DahuaCamera.ClearAllEvents();
                    SourceImageSettings.CameraSettings.DahuaCamera.OnDahuaCameraStatusChangedEvents += MyCam.OnDahuaCameraStatusChangedEvents;

                    // Lấy thông tin IsTriggerOn
                    SourceImageSettings.IsTriggerOn = SourceImageSettings.CameraSettings.DahuaCamera.IsTriggerOn;

                    if (!SourceImageSettings.CameraSettings.DahuaCamera.StartGrabbing())
                    {
                        errMessage = SourceImageSettings.CameraSettings.DahuaCamera.ErrorMessage;
                        return false;
                    }
                    // Lưu trữ thông tin camera kết nối
                    SourceImageSettings.CameraSettings.InterfaceName = interfaceName;
                    SourceImageSettings.CameraSettings.DeviceName = deviceName;
                    SourceImageSettings.CameraSettings.DeviceNameOrigin = deviceNameOrigin;
                    SourceImageSettings.CameraSettings.IsConnected = true;

                    if (GlobVar.ListCams == null)
                        GlobVar.ListCams = new Dictionary<string, Guid>();
                    if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                        GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);

                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.IsConnected = true;
                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
                    return true;
                }
                else
                {
                    errMessage = SourceImageSettings.CameraSettings.DahuaCamera.ErrorMessage;
                    return false;
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                result = false;
            }
            return result;
        }

        private bool ConnectCamera_Basler(string interfaceName, string deviceName, string deviceNameOrigin, ref string errMessage)
        {
            DisconnectCamera_Basler();
            errMessage = string.Empty;
            var result = false;
            if (SourceImageSettings == null)
                return false;
            if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Computer)
                return true;
            if (GlobVar.ListCams != null && GlobVar.ListCams.Count > 0 && GlobVar.ListCams.ContainsKey(deviceName))
            {
                cCameraSettings otherCameraSettings = GlobVar.CurrentProject
                    .CAMs[GlobVar.ListCams[deviceName]].GroupActions
                    .SourceImageSettings.CameraSettings;
                if (otherCameraSettings.SdkMode == SourceImageSettings.CameraSettings.SdkMode)
                {
                    SourceImageSettings.CameraSettings.BaslerCamera = otherCameraSettings.BaslerCamera;
                    if (otherCameraSettings.IsConnected)
                    {
                        SourceImageSettings.CameraSettings.IsConnected = true;
                        return true;
                    }
                }
            }
            try
            {

                // Bắt đầu quá trình kết nối
                SourceImageSettings.CameraSettings.BaslerCamera = new MyBaslerCamera(GlobVar.RTCVision.BaslerOptions.GrabByEvent);
                SourceImageSettings.CameraSettings.BaslerCamera.Open(deviceName);
                if (!SourceImageSettings.CameraSettings.BaslerCamera.IsConnected)
                {
                    ErrMessage = SourceImageSettings.CameraSettings.BaslerCamera.ErrorMessage;
                    SourceImageSettings.CameraSettings.BaslerCamera = null;
                    return false;
                }

                // Lưu trữ thông tin camera
                SourceImageSettings.CameraSettings.InterfaceName = interfaceName;
                SourceImageSettings.CameraSettings.DeviceName = deviceName;
                SourceImageSettings.CameraSettings.DeviceNameOrigin = deviceNameOrigin;
                SourceImageSettings.CameraSettings.IsConnected = true;

                // Thiết lập thông số camera nếu có lựa chọn cài thông số sau khi kết nối
                if (SourceImageSettings.CameraSettings.isAutoSetDefaultCAMSettingWhenConnect)
                    SourceImageSettings.CameraSettings.SetDefaultValue();

                SourceImageSettings.IsTriggerOn = SourceImageSettings.CameraSettings.BaslerCamera.IsTriggerOn;

                SourceImageSettings.CameraSettings.BaslerCamera.GrabberMode = SourceImageSettings.IsTriggerOn
                    ? CGrabberMode.Sync
                    : SourceImageSettings.CameraSettings.GrabberMode;
                SourceImageSettings.CameraSettings.BaslerCamera.MaxNumBuffer = GlobVar.RTCVision.BaslerOptions.MaxNumBuffer;
                SourceImageSettings.CameraSettings.BaslerCamera.IntervalTimeCheckConnected = GlobVar.RTCVision.BaslerOptions.IntervalTimeCheckConnected;
                // SourceImageSettings.CameraSettings.BaslerCamera.AutoReconnect = GlobVar.RTCVision.RunOptions.AutoReconnectCam;

                // Truyền event ra ngoài
                SourceImageSettings.CameraSettings.BaslerCamera.ClearAllEvents();
                SourceImageSettings.CameraSettings.BaslerCamera.OnBaslerCameraStatusChangedEvents += MyCam.OnBaslerCameraStatusChangedEvents;

                SourceImageSettings.CameraSettings.BaslerCamera.StartGrabbing();

                if (GlobVar.ListCams == null)
                    GlobVar.ListCams = new Dictionary<string, Guid>();
                if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                    GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);

                GlobVar.CurrentProject
                    .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                    .SourceImageSettings.CameraSettings.IsConnected = true;
                GlobVar.CurrentProject
                    .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                    .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
                result = true;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                if (errMessage.Contains("The device is controlled by another application"))
                    errMessage = $"The device is controlled by another application.";
                result = false;
            }

            return result;
        }

        private bool ConnectCamera_HikrobotGenTL(string interfaceName, string deviceName, string deviceNameOrigin, ref string errMessage)
        {
            errMessage = string.Empty;
            var result = false;
            if (SourceImageSettings == null)
                return false;
            if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Computer)
                return true;
            if (GlobVar.ListCams != null && GlobVar.ListCams.ContainsKey(deviceName))
                if (GlobVar.CurrentProject
                    .CAMs[GlobVar.ListCams[deviceName]].GroupActions
                    .SourceImageSettings.CameraSettings.SdkMode == SourceImageSettings.CameraSettings.SdkMode)
                {
                    SourceImageSettings.CameraSettings.HikCamera = GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[deviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.HikCamera;

                    if (GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[deviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.IsConnected)
                    {
                        SourceImageSettings.CameraSettings.IsConnected = true;
                        return true;
                    }
                }
            try
            {
                SourceImageSettings.CameraSettings.HikCamera = new MyHikCamera();
                var deviceIndex = -1;
                MyHikCamera.MV_GENTL_DEV_INFO_LIST gentlDevInfoList = new MyHikCamera.MV_GENTL_DEV_INFO_LIST();
                MyHikCamera.MV_GENTL_IF_INFO stIFInfo = GlobFuncs.GetHikrobotGenICamTLInterfaceInfo(interfaceName);
                int nRet = MyHikCamera.MV_CC_EnumDevicesByGenTL_NET(ref stIFInfo, ref gentlDevInfoList);
                if (0 != nRet)
                {
                    errMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                    return false;
                }
                for (var i = 0; i < gentlDevInfoList.nDeviceNum; i++)
                {
                    var device1 =
                        (MyHikCamera.MV_GENTL_DEV_INFO)Marshal.PtrToStructure(gentlDevInfoList.pDeviceInfo[i],
                        typeof(MyHikCamera.MV_GENTL_DEV_INFO));

                    if (device1.chUserDefinedName != "")
                        deviceIndex = "Dev: " + device1.chUserDefinedName + " (" + device1.chSerialNumber + ")" == deviceName
                            ? i : -1;
                    else
                        deviceIndex = "Dev: " + device1.chVendorName + " " + device1.chModelName + " (" + device1.chSerialNumber +
                            ")" == deviceName
                            ? i
                            : -1;
                    if (deviceIndex != -1)
                        break;
                }
                if (deviceIndex == -1)
                    return false;
                // open device
                if (null == SourceImageSettings.CameraSettings.HikCamera)
                {
                    SourceImageSettings.CameraSettings.HikCamera = new MyHikCamera();
                    if (null == SourceImageSettings.CameraSettings.HikCamera)
                        return false;
                }
                var device = (MyHikCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(
                    gentlDevInfoList.pDeviceInfo[deviceIndex], typeof(MyHikCamera.MV_CC_DEVICE_INFO));
                nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_CreateDevice_NET(ref device);
                if (MyHikCamera.MV_OK != nRet)
                {
                    errMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                    return false;
                }
                nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_OpenDevice_NET();
                if (MyHikCamera.MV_OK != nRet)
                {
                    errMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                    SourceImageSettings.CameraSettings.HikCamera.MV_CC_DestroyDevice_NET();

                    return false;
                }

                if (SourceImageSettings.CameraSettings.HikCamera != null)
                {
                    nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_StartGrabbing_NET();
                    if (MyHikCamera.MV_OK != nRet)
                    {
                        errMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                        return false;
                    }


                    MyHikCamera.MV_CAM_TRIGGER_MODE camTriggerMode = MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF;
                    if (!GlobFuncs.HIK_GetTriggerMode(SourceImageSettings.CameraSettings.HikCamera, ref camTriggerMode))
                        camTriggerMode = MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF;
                    SourceImageSettings.IsTriggerOn = camTriggerMode == MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON;

                    SourceImageSettings.CameraSettings.InterfaceName = interfaceName;
                    SourceImageSettings.CameraSettings.DeviceName = deviceName;
                    SourceImageSettings.CameraSettings.DeviceNameOrigin = deviceNameOrigin;
                    SourceImageSettings.CameraSettings.IsConnected = true;
                    if (SourceImageSettings.CameraSettings.isAutoSetDefaultCAMSettingWhenConnect)
                        SourceImageSettings.CameraSettings.SetDefaultValue();

                    if (GlobVar.ListCams == null)
                        GlobVar.ListCams = new Dictionary<string, Guid>();
                    if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                        GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);

                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.IsConnected = true;
                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
                    result = true;
                }
            }

            catch (Exception ex)
            {
                errMessage = ex.Message;
                result = false;
            }
            return result;
        }

        private bool ConnectCamera_Hikrobot(string interfaceName, string deviceName, string deviceNameOrigin, ref string errMessage)
        {
            errMessage = string.Empty;
            var result = false;
            if (SourceImageSettings == null)
                return false;
            if (SourceImageSettings.ImageSourceType == EImageSourceTypes.Computer)
                return true;
            if (GlobVar.ListCams != null && GlobVar.ListCams.ContainsKey(deviceName))
                if (GlobVar.CurrentProject
                    .CAMs[GlobVar.ListCams[deviceName]].GroupActions
                    .SourceImageSettings.CameraSettings.SdkMode == SourceImageSettings.CameraSettings.SdkMode)
                {
                    SourceImageSettings.CameraSettings.HikCamera = GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[deviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.HikCamera;

                    if (GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[deviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.IsConnected)
                    {
                        SourceImageSettings.CameraSettings.IsConnected = true;
                        return true;
                    }
                }
            try
            {
                SourceImageSettings.CameraSettings.HikCamera = new MyHikCamera();
                MyHikCamera.MV_CC_DEVICE_INFO device = GlobFuncs.GetHikrobotDeviceInfo(deviceName, out bool isExists);
                var nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_CreateDevice_NET(ref device);
                if (MyHikCamera.MV_OK != nRet)
                {
                    errMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                    return false;
                }


                nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_OpenDevice_NET();
                if (MyHikCamera.MV_OK != nRet)
                {
                    SourceImageSettings.CameraSettings.HikCamera.MV_CC_DestroyDevice_NET();
                    errMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                    return false;
                }
                if (device.nTLayerType == MyHikCamera.MV_GIGE_DEVICE)
                {
                    var nPacketSize = SourceImageSettings.CameraSettings.HikCamera.MV_CC_GetOptimalPacketSize_NET();
                    if (nPacketSize > 0)
                    {
                        nRet = SourceImageSettings.CameraSettings.HikCamera.MV_CC_SetIntValueEx_NET(
                            "GevSCPSPacketSize", nPacketSize);
                        if (nRet != MyHikCamera.MV_OK)
                        {
                            errMessage = GlobFuncs.Hik_GetErrorMessage(nRet);
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                if (SourceImageSettings.CameraSettings.HikCamera != null)
                {
                    SourceImageSettings.IsTriggerOn = SourceImageSettings.CameraSettings.HikCamera.IsTriggerOn;

                    if (!SourceImageSettings.CameraSettings.HikCamera.StartGrabbing())
                    {
                        errMessage = SourceImageSettings.CameraSettings.HikCamera.ErrorMessage;
                        return false;
                    }
                    SourceImageSettings.CameraSettings.InterfaceName = interfaceName;
                    SourceImageSettings.CameraSettings.DeviceName = deviceName;
                    SourceImageSettings.CameraSettings.DeviceNameOrigin = deviceNameOrigin;
                    SourceImageSettings.CameraSettings.IsConnected = true;
                    if (SourceImageSettings.CameraSettings.isAutoSetDefaultCAMSettingWhenConnect)
                        SourceImageSettings.CameraSettings.SetDefaultValue();

                    if (GlobVar.ListCams == null)
                        GlobVar.ListCams = new Dictionary<string, Guid>();
                    if (!GlobVar.ListCams.ContainsKey(SourceImageSettings.CameraSettings.DeviceName))
                        GlobVar.ListCams.Add(SourceImageSettings.CameraSettings.DeviceName, MyCam.ID);

                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings.IsConnected = true;
                    GlobVar.CurrentProject
                        .CAMs[GlobVar.ListCams[SourceImageSettings.CameraSettings.DeviceName]].GroupActions
                        .SourceImageSettings.CameraSettings = SourceImageSettings.CameraSettings;
                    result = true;
                }

            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                result = false;
            }
            return result;
        }
        public bool ConnectAllCameraUse(bool isShowMessage = false)
        {
            try
            {
                if (ConnectCamera())
                {
                    var listRunProgramActions =
                        Actions.Values.Where(x => x.ActionType == EActionTypes.RunProgram && x.Enable.rtcValue).ToList();
                    if (listRunProgramActions.Any())
                        foreach (cAction action in listRunProgramActions)
                        {
                            cCAMTypes cam =
                                GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x =>
                                x.Name == action.ProgramName.rtcValue);
                            if (cam != null)
                                if (!cam.GroupActions.ConnectCamera())
                                {
                                    if (isShowMessage)
                                        cMessageBox.Warning(cMessageContent.BuildMessage(
                                            cMessageContent.War_CAMCannotConnect,
                                            new string[] { cam.Name }, new string[] { cam.Name }));
                                    else
                                        ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_CAMCannotConnect,
                                            new string[] { cam.Name }, new string[] { cam.Name });
                                    return false;
                                }
                        }

                    //// Tìm danh sác tool setttings camera
                    //var listCameraSettingsActions =
                    //    Actions.Values.Where(x => x.ActionType == EActionTypes.CameraSettings && x.Enable.rtcValue).ToList();
                    //if (listCameraSettingsActions.Any())
                    //    foreach (cAction action in listCameraSettingsActions)
                    //    {
                    //        if (action.CameraSettings == null)
                    //            continue;
                    //        if (string.IsNullOrEmpty(action.CameraSettings.InterfaceName) ||
                    //            string.IsNullOrEmpty(action.CameraSettings.DeviceName))
                    //            continue;
                    //        action.MyGroup.ConnectCameraByAction(action);
                    //    }
                }
                else
                {
                    if (isShowMessage)
                        cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_CAMCannotConnectCamera,
                            new string[] { MyCam.Name }, new string[] { MyCam.Name }));
                    else
                        ErrMessage = cMessageContent.BuildMessage(cMessageContent.War_CAMCannotConnect,
                            new string[] { MyCam.Name }, new string[] { MyCam.Name });
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }

        public bool Setting_CheckAllConnecttion()
        {
            if (GlobVar.IsSimulatorMode)
                return true;
            bool bResult = true;
            switch (GlobVar.RTCVision.RunOptions.SLMPType)
            {
                case 0:
                    {
                        bResult = Setting_CheckAllConnection_SLMP();
                        break;
                    }
            }
            return true;
        }

        public bool SetCameraPropValue_Hikrobot(MyHikCamera hikCamera, cPropCompare propCompare)
        {
            switch (propCompare.PropCAMName)
            {
                case cParamName.TriggerDelay:
                    return GlobFuncs.HIK_SetFloatValue(hikCamera, cParamName.TriggerDelay, propCompare.DValue);
                case cParamName.TriggerSource:
                    return GlobFuncs.HIK_SetTriggerSource(hikCamera, propCompare.SValue);
                case cParamName.TriggerMode:
                    return GlobFuncs.HIK_SetTriggerMode(hikCamera, propCompare.SValue);
                case cParamName.TriggerActivation:
                    return GlobFuncs.HIK_SetTriggerActivation(hikCamera, propCompare.SValue);
                case cParamName.ExposureTime:
                    return GlobFuncs.HIK_SetFloatValue(hikCamera, cParamName.ExposureTime, propCompare.DValue);
                case cParamName.Gain:
                    return GlobFuncs.HIK_SetFloatValue(hikCamera, cParamName.Gain, propCompare.DValue);
                case cParamName.ExposureMode:
                    return GlobFuncs.HIK_SetExposureMode(hikCamera, propCompare.SValue);
                case cParamName.AcquisitionMode:
                    return GlobFuncs.HIK_SetAcquisitionMode(hikCamera, propCompare.SValue);
                case cParamName.BalanceRatioR:
                    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue);
                case cParamName.BalanceRatioG:
                    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue, cBalanceRatioSelector.Green);
                case cParamName.BalanceRatioB:
                    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue, cBalanceRatioSelector.Blue);
            }

            return false;
        }


        public bool SetCameraPropValue_Basler(MyBaslerCamera baslerCamera, cPropCompare propCompare, ref string errMessage)
        {
            errMessage = string.Empty;
            switch (propCompare.PropCAMName)
            {
                case cParamName.TriggerDelay:
                    {
                        GlobFuncs.Basler_SetValue(baslerCamera, cParamName.TriggerDelay, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerSource:
                    {
                        GlobFuncs.Basler_SetValue(baslerCamera, cParamName.TriggerSource, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerMode:
                    {
                        GlobFuncs.Basler_SetValue(baslerCamera, cParamName.TriggerMode, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerActivation:
                    {
                        GlobFuncs.Basler_SetValue(baslerCamera, cParamName.TriggerActivation, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.ExposureTime:
                    {
                        GlobFuncs.Basler_SetValue(baslerCamera, cParamName.ExposureTime, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.Gain:
                    {
                        GlobFuncs.Basler_SetValue(baslerCamera, cParamName.Gain, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.ExposureMode:
                    {
                        GlobFuncs.Basler_SetValue(baslerCamera, cParamName.ExposureMode, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.AcquisitionMode:
                    return true;
                    //case cParamName.BalanceRatioR:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue);
                    //case cParamName.BalanceRatioG:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue, cBalanceRatioSelector.Green);
                    //case cParamName.BalanceRatioB:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue, cBalanceRatioSelector.Blue);
            }

            return string.IsNullOrEmpty(errMessage);
        }

        public bool SetCameraPropValue_Dahua(MyDahuaCamera dahuaCamera, cPropCompare propCompare, ref string errMessage)
        {
            errMessage = string.Empty;
            switch (propCompare.PropCAMName)
            {
                case cParamName.TriggerDelay:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.TriggerDelay, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerSource:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.TriggerSource, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerMode:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.TriggerMode, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerActivation:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.TriggerActivation, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.ExposureTime:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.ExposureTime, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.Gain:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.Gain, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.ExposureMode:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.ExposureMode, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.AcquisitionMode:
                    return true;
                    //case cParamName.BalanceRatioR:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue);
                    //case cParamName.BalanceRatioG:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue, cBalanceRatioSelector.Green);
                    //case cParamName.BalanceRatioB:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue, cBalanceRatioSelector.Blue);
            }

            return string.IsNullOrEmpty(errMessage);
        }


        private void ConnectCameraByAction(cAction action)
        {
        }
    }
}
