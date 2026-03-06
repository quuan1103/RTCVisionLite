using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;

namespace RTC_Vision_Lite.Classes
{
    public class SafeSerialPort : SerialPort
    {
        private Stream theBaseStream;
        public SafeSerialPort()
        {

        }
        public SafeSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
            : base(portName, baudRate, parity, dataBits, stopBits)
        {

        }

        public new void Open()
        {
            try
            {
                base.Open();
                theBaseStream = BaseStream;
                GC.SuppressFinalize(BaseStream);
            }
            catch
            {

            }
        }

        public new void Dispose()
        {
            Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (base.Container != null))
            {
                base.Container.Dispose();
            }
            try
            {
                if (theBaseStream != null && theBaseStream.CanRead)
                {
                    theBaseStream.Close();
                    GC.ReRegisterForFinalize(theBaseStream);
                }
            }
            catch
            {
                // ignore exception - bug with USB - serial adapters.
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// Đối tượng đảm nhiệm vai trò khởi tạo một máy khách
    /// </summary>
    public class cCOM
    {
        /// <summary>
        /// Cổng COM cần kết nối
        /// </summary>
        public string ComName { get; set; }
        /// <summary>
        /// Tốc độ truyền
        /// </summary>
        public int BaudRate { get; set; }
        /// <summary>
        /// Số bit dữ liệu
        /// </summary>
        public int DataBits { get; set; }
        /// <summary>
        /// Kiểm tra bit chẵn, lẻ
        /// </summary>
        public Parity Parity { get; set; }
        /// <summary>
        /// Bit dừng
        /// </summary>
        public StopBits StopBits { get; set; }
        /// <summary>
        /// Dữ liệu tiếp nhận có phải dạng Hexa hay không
        /// </summary>
        public bool IsHex { get; set; }
        /// <summary>
        /// Thời gian gửi tối đa
        /// </summary>
        public int SendTimeOut { get; set; } = 1000;
        /// <summary>
        /// Thời gian đọc tối đa
        /// </summary>
        public int ReceiveTimeOut { get; set; } = 1000;
        public string ErrorMessage { get; set; } = string.Empty;
        /// <summary>
        /// Đối tượng kết nối cổng COM
        /// </summary>
        private SerialPort _comHandheld;

        public bool IsConnected => _comHandheld != null && _comHandheld.IsOpen;

        private string _receiveValue = string.Empty;

        public ReceiveDataEvents OnReceiveDataEvents;
        public cCOM()
        {
        }
        public cCOM(string _COMName, int _BaudRate, int _DataBits, Parity _Parity, StopBits _StopBits, bool _IsHex, int receiveTimeOut = 1000, bool _IsWithStart = true)
        {
            ComName = _COMName;
            BaudRate = _BaudRate;
            DataBits = _DataBits;
            Parity = _Parity;
            StopBits = _StopBits;
            IsHex = _IsHex;
            ReceiveTimeOut = receiveTimeOut;
            if (_IsWithStart)
                Connect();
        }
        /// <summary>
        /// Khởi chạy kết nối cổng COM
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                _comHandheld = new SerialPort();
                _comHandheld.PortName = ComName;
                _comHandheld.BaudRate = BaudRate;
                _comHandheld.Parity = Parity;
                _comHandheld.DataBits = DataBits;
                _comHandheld.StopBits = StopBits;
                _comHandheld.ReadTimeout = ReceiveTimeOut;
                _comHandheld.WriteTimeout = SendTimeOut;
                _comHandheld.Open();
                _comHandheld.DataReceived -= ProcessHandheldPortMessage;
                _comHandheld.DataReceived += ProcessHandheldPortMessage;
                return _comHandheld.IsOpen;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        /// <summary>
        /// Đóng kết nối COM
        /// </summary>
        public void Disconnect()
        {
            ErrorMessage = string.Empty;
            if (_comHandheld != null)
            {
                _comHandheld.DataReceived -= ProcessHandheldPortMessage;
                try
                {
                    _comHandheld.DiscardInBuffer();
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }

                _comHandheld.Close();
            }
            _comHandheld = null;
        }

        public string GetReceiveDataWithTimeOut()
        {
            DateTime startTime = DateTime.Now;
            double span = 0;
            while (span <= ReceiveTimeOut)
            {
                if (!string.IsNullOrEmpty(_receiveValue))
                    break;
                Thread.Sleep(10);
                TimeSpan ts = DateTime.Now - startTime;
                span = ts.TotalMilliseconds;
            }
            return _receiveValue;
        }
        public string Read(out bool success)
        {
            success = false;
            try
            {
                _receiveValue = string.Empty;
                if (_comHandheld != null && _comHandheld.IsOpen)
                {
                    if (IsHex)
                    {
                        int length = _comHandheld.BytesToRead;
                        byte[] buf = new byte[length];
                        _comHandheld.Read(buf, 0, length);
                        _receiveValue = BitConverter.ToString(buf).Replace("-", "");
                        _comHandheld.ReadExisting();
                        success = true;
                    }
                    else
                    {
                        _receiveValue = _comHandheld.ReadExisting();
                        success = true;
                    }
                }
            }
            catch
            {
                _receiveValue = string.Empty;
            }

            return _receiveValue;
        }
        public bool Write(string value)
        {
            try
            {
                ErrorMessage = string.Empty;
                if (_comHandheld == null || !_comHandheld.IsOpen)
                    return false;
                _receiveValue = string.Empty;
                if (IsHex)
                {
                    byte[] data = Encoding.Default.GetBytes(value);
                    string hexString = BitConverter.ToString(data);
                    hexString = hexString.Replace("-", "");
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    data = encoding.GetBytes(hexString);
                    _comHandheld.Write(data, 0, data.Length);
                }
                else
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(value);
                    _comHandheld.Write(data, 0, data.Length);
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// Sự kiện đón nhận 1 dữ liệu gửi về
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessHandheldPortMessage(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_comHandheld != null && _comHandheld.IsOpen)
                {
                    if (IsHex)
                    {
                        int length = _comHandheld.BytesToRead;
                        byte[] buf = new byte[length];
                        _comHandheld.Read(buf, 0, length);
                        _receiveValue = BitConverter.ToString(buf).Replace("-", "");
                        _comHandheld.ReadExisting();

                    }
                    else
                        _receiveValue = _comHandheld.ReadExisting();

                    if (OnReceiveDataEvents != null)
                    {
                        OnReceiveDataEvents(_receiveValue);
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

    }
}
