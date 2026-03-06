using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Basler.Pylon;
using RTCConst;

namespace RTCBaslerSdk
{
    public delegate void BaslerCameraStatusChangedEvents(bool isConnected);
    public class MyBaslerCamera : IDisposable
    {
        public MyBaslerCamera(bool grabByEvent = false)
        {
            GrabByEvent = grabByEvent;
        }

        #region VARIABALES AND PROPERTIES

        private readonly double RENDERFPS = 14;

        public Camera Camera;

        private string _deviceName = string.Empty;
        private object _lockImage = new Object();
        private IntPtr BufferAdr = IntPtr.Zero;
        private Bitmap latestBitmap = null;
        private bool m_bGrabbing = false;
        private Thread m_hReceiveThread = null;
        private PixelDataConverter converter = new PixelDataConverter();

        private bool _isCheckConnect = false;
        private Thread _checkConnectThread = null;
        private bool _firstTimeSetAcquireSingleFrame = false;

        /// <summary>
        /// Thời gian lấy ảnh tối đa
        /// </summary>
        public int GrabTimeout { get; set; } = 5000;
        /// <summary>
        /// Cờ báo lấy ảnh theo sự kiện của camera tự detect hay là lấy bằng cách lấy buffer
        /// </summary>
        public bool GrabByEvent { get; set; } = false;
        /// <summary>
        /// Xác nhận cơ chế lấy ảnh của camera là ASync (lấy liên tục) hay Sync (chờ gọi lấy ảnh từ chương trình ngoài)
        /// </summary>
        public string GrabberMode { get; set; } = CGrabberMode.ASync;
        /// <summary>
        /// Có/không sử dụng mode chuyển thằng buffer sang ảnh Halcon
        /// </summary>
        public bool IsBufferToHalcon { get; set; } = false;
        /// <summary>
        /// Thông báo lỗi trả ra của camera
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Có đảo ngược pixel của ảnh hay không
        /// </summary>
        public bool InvertPixels { get; set; } = false;
        public IParameterCollection Parameters => Camera?.Parameters;
        public bool IsCreated => Camera != null;
        public bool IsConnected => IsCreated && Camera.IsOpen;
        public bool IsGrabbing => IsConnected && Camera.StreamGrabber.IsGrabbing;
        public bool IsMono { get; set; }
        public PixelType PixelType { get; set; }
        /// <summary>
        /// Cờ xác nhận mode Trigger có đang được bật hay không
        /// </summary>
        public bool IsTriggerOn { get; set; }
        public int MaxNumBuffer { get; set; } = 5;
        /// <summary>
        /// Cờ báo có bật chế độ tự kết nối lại camera khi mất kết nối hay không
        /// </summary>
        public bool AutoReconnect { get; set; } = false;
        /// <summary>
        /// Cờ báo có sử dụng chế độ ghép ảnh sau khi chụp hay không
        /// </summary>
        public bool Merging { get; set; } = false;
        /// <summary>
        /// Chiều ghép ảnh (ngang hoặc dọc)
        /// </summary>
        public string DirectionMerging { get; set; } = CDirectionMerging.Vertical;
        /// <summary>
        /// Số lần lấy ảnh, mặc định là 1, >1 dùng khi ghép ảnh
        /// </summary>
        public int SnapCount { get; set; } = 1;
        /// <summary>
        /// Khoảng thời gian giữa các lần kiểm tra kết nối camera
        /// </summary>
        public int IntervalTimeCheckConnected { get; set; } = 500;
        /// <summary>
        /// Cờ báo có bật chế độ tự động kiểm tra kết nối hay không
        /// </summary>
        public bool AutoCheckConnected { get; set; } = true;
        /// <summary>
        /// Sự kiện đưa ra ngoài để báo tình trạng kết nối của camera
        /// </summary>

        public event BaslerCameraStatusChangedEvents OnBaslerCameraStatusChangedEvents;

        #endregion

        #region STATIC FUNCTIONS
        /// <summary>
        /// Lấy ra thông tin của 1 camera cụ thể thông qua Device Name (hay FriendlyName)
        /// </summary>
        /// <param name="deviceName">Tên camera cần lấy thông tin</param>
        /// <returns>Thông tin của camera</returns>
        public static ICameraInfo GetBaslerCameraInfo(string deviceName)
        {
            Dictionary<string, ICameraInfo> foundCameraInfos = GetBaslerCameraInfos();
            if (foundCameraInfos != null && foundCameraInfos.TryGetValue(deviceName, out var cameraInfo))
                return cameraInfo;
            else
                return null;
        }
        /// <summary>
        /// Lấy danh sách camera basler đang có trong máy
        /// </summary>
        /// <returns>Từ điển camera basler với Key là tên camera, giá trị là đối tượng chứa thông tin camera</returns>
        public static Dictionary<string, ICameraInfo> GetBaslerCameraInfos()
        {
            Dictionary<string, ICameraInfo> foundCameraInfos = null;
            try
            {
                // Ask the camera finder for a list of cameras.
                List<ICameraInfo> cameraInfos = CameraFinder.Enumerate();
                if (cameraInfos.Count > 0)
                {
                    // Maps the camera name to the camera info for use with the combo box.
                    foundCameraInfos = new Dictionary<string, ICameraInfo>();
                    foreach (ICameraInfo cameraInfo in cameraInfos)
                        if (!foundCameraInfos.ContainsKey(cameraInfo[CameraInfoKey.FriendlyName]))
                            foundCameraInfos.Add(cameraInfo[CameraInfoKey.FriendlyName], cameraInfo);
                }
            }
            catch
            {
                foundCameraInfos = null;
            }

            return foundCameraInfos;
        }

        #endregion
        /// <summary>
        /// Hàm mở kết nối
        /// </summary>
        /// <param name="deviceName">Tên camera basler cần kết nối</param>
        public void Open(string deviceName)
        {
            try
            {
                ErrorMessage = string.Empty;
                // Kiểm tra tên camera đưa vào
                if (string.IsNullOrEmpty(deviceName))
                {
                    ErrorMessage = $"Device name can't empty!";
                    return;
                }

                // Hủy kết nối cũ khi có lệnh gọi kết nối mới
                if (IsCreated)
                    Close();

                // Lấy thông tin camera từ tên camera
                ICameraInfo info = GetBaslerCameraInfo(deviceName);
                if (info == null)
                {
                    ErrorMessage = $"Can't detect camera info with device name = '{deviceName}'";
                    return;
                }

                // Khởi tạo 1 số thông số
                _deviceName = string.Empty;
                IsMono = true;
                PixelType = PixelType.Mono8;

                // Khởi tạo đối tượng kết nối
                Camera = new Camera(info);
                if (!IsCreated)
                {
                    ErrorMessage = "Cannot open camera. No camera has been created.";
                    return;
                }

                // Bắt đầu quá trình kết nối
                Camera.CameraOpened += Configuration.AcquireContinuous;

                Camera.Open();

                if (Camera.Parameters.Contains(PLCamera.PixelFormat))
                {
                    IEnumParameter enumParameter = Camera.Parameters[PLCamera.PixelFormat];
                    IsMono = enumParameter.GetValue().ToLower().Contains("mono");
                }

                GetTriggerMode();

                ConnectToCameraEvents();

                _deviceName = deviceName;

                if (AutoCheckConnected && _checkConnectThread == null)
                {
                    _checkConnectThread = new Thread(CheckConnected)
                    {
                        IsBackground = true
                    };
                    _checkConnectThread.Start();
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            finally
            {
                if (OnBaslerCameraStatusChangedEvents != null)
                    OnBaslerCameraStatusChangedEvents(IsConnected);
            }
        }
        /// <summary>
        /// Lấy thông tin trạng thái của cài đặt Trigger
        /// </summary>
        public void GetTriggerMode()
        {
            IsTriggerOn = false;

            EnumName name = (EnumName)"TriggerSelector";
            IEnumParameter enumParameter = Camera.Parameters[name];
            EnumName name2 = (EnumName)"TriggerMode";
            IEnumParameter enumParameter2 = Camera.Parameters[name2];
            EnumName name3 = (EnumName)"TriggerSource";
            IEnumParameter enumParameter3 = Camera.Parameters[name3];

            string currentTriggerSelector = enumParameter.GetValue();
            string currentTriggerMode = enumParameter2.GetValue();

            try
            {
                if (enumParameter.CanSetValue(cParamName.AcquisitionStart))
                {
                    enumParameter.SetValue(cParamName.AcquisitionStart);
                    IsTriggerOn = enumParameter2.GetValue() == PLCamera.TriggerMode.On;
                    if (IsTriggerOn)
                        return;
                }

                if (enumParameter.CanSetValue(cParamName.FrameStart))
                {
                    enumParameter.SetValue(cParamName.FrameStart);
                    IsTriggerOn = enumParameter2.GetValue() == PLCamera.TriggerMode.On;
                    if (IsTriggerOn)
                        return;
                }

                if (enumParameter.CanSetValue(cParamName.LineStart))
                {
                    enumParameter.SetValue(cParamName.LineStart);
                    IsTriggerOn = enumParameter2.GetValue() == PLCamera.TriggerMode.On;
                    if (IsTriggerOn)
                        return;
                }
            }
            catch
            {
                IsTriggerOn = false;
            }
            finally
            {
                if (!IsTriggerOn)
                    enumParameter.SetValue(currentTriggerSelector);
            }
        }
        private CancellationTokenSource cancellationTokenSourceCheckConnected = new CancellationTokenSource();
        /// <summary>
        /// Hàm chuyên thực hiện việc kiểm tra kết nối của cam theo thời gian thực
        /// </summary>
        private void CheckConnected()
        {
            CancellationToken token = cancellationTokenSourceCheckConnected.Token;
            try
            {
                while (!token.IsCancellationRequested)
                {
                    if (!IsConnected)
                    {
                        CloseWhenCheckConnect();

                        if (AutoReconnect)
                        {
                            Open(_deviceName);

                            if (IsConnected)
                                StartGrabbing();
                        }
                    }

                    if (OnBaslerCameraStatusChangedEvents != null)
                        OnBaslerCameraStatusChangedEvents(IsConnected);
                    Thread.Sleep(IntervalTimeCheckConnected);
                }
            }
            catch
            {
                // ignored
            }
        }

        private void InvertColors(IGrabResult result)
        {
            byte pixelSize = 255;
            byte[] data = (byte[])result.PixelData;
            for (long i = 0; i < data.Length; i++)
            {
                data[i] = (byte)((int)pixelSize - (int)data[i]);
            }
        }

        public void StartGrabbing()
        {
            try
            {
                if (IsBufferToHalcon)
                {
                    converter.OutputPixelFormat = IsMono ? PixelType.Mono8 : PixelType.RGB8packed;
                    converter.Parameters[PLPixelDataConverter.InconvertibleEdgeHandling].SetValue("Clip");
                }

                if (MaxNumBuffer == 0)
                    MaxNumBuffer = 5;

                Camera.Parameters[PLCameraInstance.MaxNumBuffer].SetValue(MaxNumBuffer);

                if (GrabByEvent)
                {
                    if (!IsTriggerOn)
                    {
                        if (GrabberMode == "ASync")
                            StartContinuousShotGrabbing();
                        else
                            StartSingleShotGrabbing();
                    }
                    else
                        StartContinuousShotGrabbing();
                }
                else
                {
                    Camera.StreamGrabber.Start();

                    m_bGrabbing = true;

                    if (GrabberMode == "ASync")
                    {
                        m_hReceiveThread = new Thread(ReceiveThreadProcess)
                        {
                            IsBackground = true
                        };
                        m_hReceiveThread.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}\n{ex.StackTrace}";
            }
        }

        private void StartContinuousShotGrabbing()
        {
            ClearLatestFrame();
            if (Camera != null && !Camera.StreamGrabber.IsGrabbing)
            {
                if (!IsTriggerOn)
                    Configuration.AcquireContinuous(Camera, null);
                Camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
            }
        }

        private void StartSingleShotGrabbing()
        {
            ClearLatestFrame();
            if (Camera != null && !Camera.StreamGrabber.IsGrabbing)
            {
                if (!_firstTimeSetAcquireSingleFrame)
                {
                    Configuration.AcquireSingleFrame(Camera, null);
                    _firstTimeSetAcquireSingleFrame = true;
                }
                Camera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
                //Configuration.AcquireSingleFrame(Camera, null);
                //Camera.Parameters[PLCameraInstance.MaxNumBuffer].SetValue(1);
            }
        }
        public void StopGrabbing()
        {
            m_bGrabbing = false;
            m_hReceiveThread?.Join();
            m_hReceiveThread = null;

            Camera.StreamGrabber.Stop();
            ClearLatestFrame();
        }
        public void Close()
        {
            try
            {
                ErrorMessage = string.Empty;

                if (AutoCheckConnected)
                    cancellationTokenSourceCheckConnected.Cancel();

                ClearAllEvents();

                if (IsGrabbing)
                    StopGrabbing();

                if (IsConnected)
                {
                    ClearLatestFrame();
                    Camera.Close();
                }

                if (IsCreated)
                {
                    DisconnectFromCameraEvents();
                    Camera.Dispose();
                    Camera = null;
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        private void CloseWhenCheckConnect()
        {
            try
            {
                if (IsGrabbing)
                    StopGrabbing();
                if (IsConnected)
                {
                    ClearLatestFrame();
                    Camera.Close();
                }

                if (IsCreated)
                {
                    DisconnectFromCameraEvents();
                    Camera.Dispose();
                    Camera = null;
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        private void ConnectToCameraEvents()
        {
            if (IsCreated && GrabByEvent)
                Camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
        }
        private void DisconnectFromCameraEvents()
        {
            if (IsCreated && GrabByEvent)
                Camera.StreamGrabber.ImageGrabbed -= OnImageGrabbed;
        }
        public void ClearAllEvents()
        {
            OnBaslerCameraStatusChangedEvents = null;
        }
        public void ClearLatestFrame()
        {
            lock (_lockImage)
            {
               
                    latestBitmap?.Dispose();
                    latestBitmap = null;
                
            }
        }
        private void ReceiveThreadProcess()
        {
            while (m_bGrabbing)
            {
                //if (Camera == null || Camera.StreamGrabber == null || !Camera.StreamGrabber.IsGrabbing)
                //{
                //    CloseCamera();
                //    OpenCamera();
                //    continue;
                //}


                StartSingleShotBitmap();
            }
        }
       
        
        private void StartSingleShotBitmap()
        {
            try
            {
                if (Camera == null || Camera.StreamGrabber == null || !Camera.StreamGrabber.IsGrabbing)
                    return;
                IGrabResult grabResult = Camera.StreamGrabber.RetrieveResult(GrabTimeout, TimeoutHandling.ThrowException);
                if (grabResult == null)
                    return;
                using (grabResult)
                {
                    if (grabResult.GrabSucceeded)
                    {
                        if (grabResult.PixelTypeValue.BitDepth() == 8 && InvertPixels)
                        {
                            InvertColors(grabResult);
                        }

                        Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            ImageLockMode.ReadWrite, bitmap.PixelFormat);
                        converter.OutputPixelFormat = PixelType.BGRA8packed;
                        IntPtr ptrBmp = bmpData.Scan0;
                        converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
                        bitmap.UnlockBits(bmpData);
                        lock (_lockImage)
                        {
                            latestBitmap?.Dispose();
                            latestBitmap = bitmap;
                        }
                    }
                    else
                    {
                        ErrorMessage = $"Error: {grabResult.ErrorCode} {grabResult.ErrorDescription}";
                        ClearLatestFrame();
                        lock (_lockImage)
                            latestBitmap = null;
                    }
                }
            }
            catch (Exception ex)
            {
                lock (_lockImage)
                    latestBitmap = null;
                ErrorMessage = $"Error: {ex.Message}\n{ex.StackTrace}";
                ClearLatestFrame();
            }
        }
        private Bitmap SingleShotBitmap()
        {
            try
            {
                if (Camera == null || Camera.StreamGrabber == null || !Camera.StreamGrabber.IsGrabbing)
                    return null;

                Bitmap bitmap = null;

                IGrabResult grabResult = Camera.StreamGrabber.RetrieveResult(GrabTimeout, TimeoutHandling.ThrowException);
                if (grabResult == null)
                    return null;

                using (grabResult)
                {
                    if (grabResult.GrabSucceeded)
                    {
                        if (grabResult.PixelTypeValue.BitDepth() == 8 && InvertPixels)
                        {
                            InvertColors(grabResult);
                        }

                        bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            ImageLockMode.ReadWrite, bitmap.PixelFormat);
                        converter.OutputPixelFormat = PixelType.BGRA8packed;
                        IntPtr ptrBmp = bmpData.Scan0;
                        converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
                        bitmap.UnlockBits(bmpData);
                    }
                    else
                    {
                        ErrorMessage = $"Error: {grabResult.ErrorCode} {grabResult.ErrorDescription}";
                        ClearLatestFrame();
                        return null;

                    }
                }
                return bitmap;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}\n{ex.StackTrace}";
                return null;
            }
        }
     
        /// <summary>
        /// Lấy ảnh Bitmap
        /// </summary>
        /// <returns>Ảnh Bitmap</returns>
        private Bitmap GetLatestBitmap()
        {
            lock (_lockImage)
            {
                if (latestBitmap != null)
                {
                    Bitmap returnedBitmap = latestBitmap;
                    latestBitmap = null;
                    return returnedBitmap;
                }
                return null;
                //if (GrabberMode == CGrabberMode.Sync)
                //    return latestBitmap;
                //else
                //{
                //    if (latestBitmap != null)
                //    {
                //        Bitmap returnedBitmap = latestBitmap;
                //        latestBitmap = null;
                //        return returnedBitmap;
                //    }
                //    return null;
                //}
            }
        }
        private void SoftwareTrigger()
        {
            ClearLatestFrame();

            if (!IsTriggerOn)
                return;

            //if (Camera.CanWaitForFrameTriggerReady)
            //    Camera.WaitForFrameTriggerReady(1000, TimeoutHandling.ThrowException);

            EnumName name = (EnumName)"TriggerSelector";
            IEnumParameter enumParameter = Camera.Parameters[name];
            EnumName name2 = (EnumName)"TriggerMode";
            IEnumParameter enumParameter2 = Camera.Parameters[name2];
            EnumName name3 = (EnumName)"TriggerSource";
            IEnumParameter enumParameter3 = Camera.Parameters[name3];

            IEnumerator<string> enumeratorTriggerSource = enumParameter3.GetEnumerator();
            string currentTriggerSelector = enumParameter.GetValue();
            string currentTriggerMode = enumParameter2.GetValue();
            string currentTriggerSource = enumParameter3.GetValue();

            enumParameter3.SetValue(PLCamera.TriggerSource.Software);
            enumParameter2.SetValue(PLCamera.TriggerMode.On);

            //StartSingleShotGrabbing();
            Camera.ExecuteSoftwareTrigger();

            enumParameter3.SetValue(currentTriggerSource);
            enumParameter2.SetValue(currentTriggerMode);
        }
        private void OnImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                IGrabResult grabResult = e.GrabResult;

                if (grabResult.GrabSucceeded)
                {
                    ErrorMessage = string.Empty;


                    if (grabResult.PixelTypeValue.BitDepth() == 8 && InvertPixels)
                    {
                        InvertColors(grabResult);
                    }

                    Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
                    BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
                    converter.OutputPixelFormat = PixelType.BGRA8packed;
                    IntPtr ptrBmp = bmpData.Scan0;
                    converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
                    bitmap.UnlockBits(bmpData);
                    lock (_lockImage)
                    {
                        if (latestBitmap != null)
                        {
                            latestBitmap.Dispose();
                        }
                        latestBitmap = bitmap;
                    }

                }
                else
                {
                    ErrorMessage = grabResult.ErrorDescription;
                    ClearLatestFrame();
                }

                Thread.Sleep(5);
            }
            catch (Exception exception)
            {
                ErrorMessage = $"{exception.Message}\n{exception.StackTrace}";
                ClearLatestFrame();
            }
            finally
            {
                e.DisposeGrabResultIfClone();
                GC.Collect();
            }
        }
        private void SetErrorMessage(string errorMessage)
        {
            if (string.IsNullOrEmpty(ErrorMessage))
                ErrorMessage = errorMessage;
            else
                ErrorMessage = $"{ErrorMessage}\n{errorMessage}";
        }

        /// <summary>
        /// Lệnh chụp lấy ảnh
        /// </summary>
        /// <param name="triggerBySoftware">Cờ báo có trigger bởi phần mềm hay không</param>
        /// <returns>Ảnh định dạng HImage của Halcon</returns>
        public Bitmap Snap(bool triggerBySoftware)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            ErrorMessage = string.Empty;
            Bitmap snapImage = null;
            int snapCount = Merging ? SnapCount : 1;
            if (snapCount <= 0)
                snapCount = 1;
            try
            {
                if (GrabByEvent)
                {
                    for (int i = 0; i < snapCount; i++)
                    {
                        if (triggerBySoftware)
                            SoftwareTrigger();

                        if (!IsTriggerOn && GrabberMode != CGrabberMode.ASync)
                            StartSingleShotGrabbing();
                        // Tại đây sẽ dùng 1 vòng timeout lấy ảnh (mặc định 1000ms)
                        // TH Basler sẽ khác với 2 SDK còn lại vì Basler đang lấy ảnh thông qua sự kiện nên ở dưới đều dùng cơ chế Get Latest Image
                        int timeout = 0;
                        while (true)
                        {

                            snapImage = GetLatestBitmap();
                            if (snapImage != null)
                                break;
                            timeout += 3;
                            Thread.Sleep(3);
                            if (timeout >= GrabTimeout)
                                break;
                        }


                    }
                    //stopwatch.Stop();
                }
                else if (GrabberMode == CGrabberMode.ASync)
                {
                    if (triggerBySoftware)
                    {
                        for (int i = 0; i < snapCount; i++)
                        {
                            if (IsTriggerOn)
                                SoftwareTrigger();

                            int timeout = 0;
                            while (true)
                            {

                                snapImage = GetLatestBitmap();
                                if (snapImage != null)
                                {
                                    break;
                                }
                                timeout += 5;
                                Thread.Sleep(5);
                                if (timeout >= GrabTimeout)
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < snapCount; i++)
                    {
                        if (triggerBySoftware)
                            SoftwareTrigger();
                        snapImage = SingleShotBitmap();

                    }
                }

                return snapImage;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return null;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();
                ClearLatestFrame();
                converter.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
