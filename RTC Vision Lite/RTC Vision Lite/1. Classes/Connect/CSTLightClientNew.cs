using System;
using System.Collections;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using RTCConst;
using RTC_Vision_Lite.PublicFunctions;
using RtcTcpIp;

namespace RTC_Vision_Lite.Classes
{
    public class CSTLightClientNew
    {
        private TcpIp _tcpClient = null;
        private cCOM _comWriter = null;
        public string ModelName { get; set; }
        public string IPAddress { get; set; } = "192.168.1.208";
        public int PortNumber { get; set; } = 6600;
        public int ISerialPort;
        private string serialPort;
        public string SerialPort
        {
            get => serialPort;
            set
            {
                serialPort = value;
                ISerialPort = (int)GlobFuncs.ExtractNumberOfString(serialPort, 0);
            }
        }

        public int BaudRate { get; set; } = 19200;
        public int DataBits { get; set; } = 8;
        public Parity Parity { get; set; } = Parity.None;
        public StopBits StopBits { get; set; } = StopBits.One;
        public string PrefixRead { get; set; }
        public string SuffixRead { get; set; }
        public string PrefixWrite { get; set; }
        public string SuffixWrite { get; set; }
        public string OnCommand { get; set; }
        public string OffCommand { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public string SourceMode { get; set; }
        public bool IsConnected { get; set; }
        public int SendTimeOut { get; set; } = 1000;
        public int ReceiveTimeOut { get; set; } = 1000;
        public CSTLightClientNew()
        {
            IsConnected = false;
        }
        /// <summary>
        /// Tạo kết nối
        /// </summary>
        /// <returns></returns>
        internal bool Connect()
        {
            try
            {
                IsConnected = false;
                switch (SourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            _tcpClient = new TcpIp(IPAddress, PortNumber, false, false, true)
                            {
                                SendTimeOut = SendTimeOut,
                                ReceiveTimeOut = ReceiveTimeOut
                            };
                            IsConnected = _tcpClient.Connect();
                            break;
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            _comWriter = new cCOM(SerialPort, BaudRate, DataBits, Parity, StopBits, false)
                            {
                                SendTimeOut = SendTimeOut,
                                ReceiveTimeOut = ReceiveTimeOut
                            };
                            IsConnected = _comWriter.IsConnected;
                            break;
                        }
                       
                }
            }
            catch
            {
                IsConnected = false;
            }

            return IsConnected;
        }
        /// <summary>
        /// Đóng kết nối
        /// </summary>
        internal bool Disconnect()
        {
            if (!IsConnected)
                return true;
            try
            {
                switch (SourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            if (_tcpClient != null && _tcpClient.IsConnected)
                                _tcpClient.Disconnect();
                            IsConnected = false;
                            break;
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            if (_comWriter != null && _comWriter.IsConnected)
                                _comWriter.Disconnect();
                            IsConnected = false;
                            break;
                        }
                }
                return !IsConnected;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Đọc độ sáng đèn
        /// </summary>
        /// <param name="channel">Kênh cần đọc</param>
        /// <param name="success">True: Đọc thành công; False: Thất bại</param>
        /// <param name="errMessage">Nội dung lỗi</param>
        /// <param name="sourceType">Kiểu đèn (light hay Strobe)</param>
        /// <returns>Độ sáng của đèn</returns>
        internal int Read(int channel, out bool success, out string errMessage)
        {
            errMessage = string.Empty;
            success = false;
            int value = 0;
            try
            {
                PrefixRead = "SP";
                SuffixRead = "#";
                switch (SourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            if (!_tcpClient.IsConnected)
                                _tcpClient.Connect();

                            if (_tcpClient != null && _tcpClient.IsConnected)
                            {
                                string sChannel = GlobFuncs.AlphabetPositionToString(channel - 1);
                                if (!string.IsNullOrEmpty(sChannel))
                                {
                                    sChannel = $"{PrefixRead}{sChannel}{SuffixRead}";
                                    _tcpClient.Send(sChannel);
                                    sChannel = _tcpClient.GetReceiveDataWithTimeOut();
                                    if (!string.IsNullOrEmpty(sChannel))
                                    {
                                        value = (int)GlobFuncs.ExtractNumberOfString(sChannel, 0);
                                        success = true;
                                    }
                                    else
                                        errMessage = $"Channel {channel} is not exists!";
                                }
                                else
                                    errMessage = $"Channel {channel} is not exists!";
                            }
                            else
                                success = false;
                            break;
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            if (!_comWriter.IsConnected)
                                _comWriter.Connect();

                            if (_comWriter != null && _comWriter.IsConnected)
                            {
                                string sChannel = GlobFuncs.AlphabetPositionToString(channel - 1);
                                if (!string.IsNullOrEmpty(sChannel))
                                {
                                    sChannel = $"{PrefixRead}{sChannel}{SuffixRead}";
                                    _comWriter.Write(sChannel);
                                    sChannel = _comWriter.GetReceiveDataWithTimeOut();
                                    if (!string.IsNullOrEmpty(sChannel))
                                    {
                                        value = (int)GlobFuncs.ExtractNumberOfString(sChannel, 2);
                                        success = true;
                                    }
                                    else
                                        errMessage = $"Channel {channel} is not exists!";
                                }
                                else
                                    errMessage = $"Channel {channel} is not exists!";
                            }
                            else
                                success = false;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                value = 0;
                success = false;
                errMessage = ex.Message;
            }
            return value;
        }
        internal int[] ReadMulti(int[] channels, out bool success, out string errMessage)
        {
            errMessage = string.Empty;
            success = false;
            int[] values = new int[channels.Length];

            int value = 0;
            try
            {
                switch (SourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            if (_tcpClient != null && _tcpClient.IsConnected)
                            {
                                success = true;
                                for (int i = 0; i < channels.Length; i++)
                                {
                                    string sChannel = GlobFuncs.AlphabetPositionToString(channels[i] - 1);
                                    if (!string.IsNullOrEmpty(sChannel))
                                    {
                                        sChannel = $"{PrefixRead}{sChannel}{SuffixRead}";
                                        _tcpClient.Send(sChannel);

                                        sChannel = _tcpClient.GetReceiveDataWithTimeOut();
                                        if (!string.IsNullOrEmpty(sChannel))
                                        {
                                            value = (int)GlobFuncs.ExtractNumberOfString(sChannel, 2);
                                            values[i] = value;
                                        }
                                        else
                                        {
                                            values[i] = -1;
                                            success = false;
                                            errMessage = string.IsNullOrEmpty(errMessage) ? $"Read {channels[i]} value error!" : $"{errMessage}\nRead {channels[i]} value error!";
                                        }
                                    }
                                    else
                                    {
                                        values[i] = -1;
                                        success = false;
                                        errMessage = string.IsNullOrEmpty(errMessage) ? $"Channel {channels[i]} is not exists!" : $"{errMessage}\nChannel {channels[i]} is not exists!";
                                    }
                                }
                            }
                            else
                                success = false;
                            break;
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            if (_comWriter != null && _comWriter.IsConnected)
                            {
                                success = true;
                                for (int i = 0; i < channels.Length; i++)
                                {
                                    string sChannel = GlobFuncs.AlphabetPositionToString(channels[i] - 1);
                                    if (!string.IsNullOrEmpty(sChannel))
                                    {
                                        sChannel = $"{PrefixRead}{sChannel}{SuffixRead}";
                                        _comWriter.Write(sChannel);

                                        sChannel = _comWriter.GetReceiveDataWithTimeOut();

                                        if (!string.IsNullOrEmpty(sChannel))
                                        {
                                            value = (int)GlobFuncs.ExtractNumberOfString(sChannel, 2);
                                            values[i] = value;
                                        }
                                        else
                                        {
                                            values[i] = -1;
                                            success = false;
                                            errMessage = string.IsNullOrEmpty(errMessage) ? $"Read {channels[i]} value error!" : $"{errMessage}\nRead {channels[i]} value error!";
                                        }
                                    }
                                    else
                                    {
                                        values[i] = -1;
                                        success = false;
                                        errMessage = string.IsNullOrEmpty(errMessage) ? $"Channel {channels[i]} is not exists!" : $"{errMessage}\nChannel {channels[i]} is not exists!";
                                    }
                                }
                            }
                            else
                                success = false;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                value = 0;
                success = false;
                errMessage = ex.Message;
            }
            return values;
        }
        /// <summary>
        /// Thay đổi độ sáng đèn
        /// </summary>
        /// <param name="channel">Kênh cần đọc</param>
        /// <param name="lightValue">Giá trị độ sáng</param>
        /// <param name="errMessage">Nội dung lỗi</param>
        /// <returns>True: Thành công; False: Thất bại</returns>
        internal bool Write(int channel, int lightValue, out string errMessage)
        {
            errMessage = string.Empty;
            try
            {
                PrefixWrite = "SP";
                SuffixWrite = "#";
                switch (SourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            if (!_tcpClient.IsConnected)
                                _tcpClient.Connect();

                            if (_tcpClient != null && _tcpClient.IsConnected)
                            {
                                _tcpClient.Send(OnCommand);
                                string sChannel = GlobFuncs.AlphabetPositionToString(channel - 1);
                                sChannel = $"{PrefixWrite}{sChannel}{lightValue.ToString().PadLeft(4, '0')}{SuffixWrite}";
                                //sChannel = $"{"SP"}{sChannel}{lightValue.ToString().PadLeft(4, '0')}{"#"}";

                                return _tcpClient.Send(sChannel);
                            }
                            else
                            {
                                errMessage =
                                    $"Ethernet with IP = '{IPAddress}' and Port = {PortNumber} can't connect.\nPlease check again.";
                                return false;
                            }
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            if (!_comWriter.IsConnected)
                                _comWriter.Connect();

                            if (_comWriter != null && _comWriter.IsConnected)
                            {
                                _comWriter.Write(OnCommand);
                                string result = _comWriter.GetReceiveDataWithTimeOut();
                                if (result == "")
                                {
                                    errMessage =
                                        $"COM with name = '{SerialPort}' can't connect.\nPlease check again.";
                                    return false;
                                }

                                string sChannel = GlobFuncs.AlphabetPositionToString(channel - 1);
                                sChannel = $"{PrefixWrite}{sChannel}{lightValue.ToString().PadLeft(4, '0')}{SuffixWrite}";
                                return _comWriter.Write(sChannel);
                            }
                            else
                            {
                                errMessage =
                                    $"COM with name = '{SerialPort}' can't connect.\nPlease check again.";
                                return false;
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }
            return false;
        }
        internal bool WriteMulti(int[] channels, int[] lightValues, out string errMessage)
        {
            errMessage = string.Empty;
            try
            {
                switch (SourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            if (!_tcpClient.IsConnected)
                                _tcpClient.Connect();

                            if (_tcpClient != null && _tcpClient.IsConnected)
                            {
                                _tcpClient.Send(OnCommand);
                                StringBuilder builder = new StringBuilder();
                                for (int i = 0; i < channels.Length; i++)
                                {
                                    string sChannel = GlobFuncs.AlphabetPositionToString(channels[i] - 1);
                                    builder.Append($"{PrefixWrite}{sChannel}{lightValues[i].ToString().PadLeft(4, '0')}{SuffixWrite}");
                                }
                                return _tcpClient.Send($"{builder.ToString()}");
                            }
                            else
                            {
                                errMessage =
                                    $"Ethernet with IP = '{IPAddress}' and Port = {PortNumber} can't connect.\nPlease check again.";
                                return false;
                            }
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            if (!_comWriter.IsConnected)
                                _comWriter.Connect();

                            if (_comWriter != null && _comWriter.IsConnected)
                            {
                                _comWriter.Write(OnCommand);
                                string result = _comWriter.GetReceiveDataWithTimeOut();
                                if (result == "")
                                {
                                    errMessage =
                                        $"COM with name = '{SerialPort}' can't connect.\nPlease check again.";
                                    return false;
                                }
                                StringBuilder builder = new StringBuilder();
                                for (int i = 0; i < channels.Length; i++)
                                {
                                    string sChannel = GlobFuncs.AlphabetPositionToString(channels[i] - 1);
                                    builder.Append($"{PrefixWrite}{sChannel}{lightValues[i].ToString().PadLeft(4, '0')}{SuffixWrite}");
                                }
                                return _comWriter.Write($"{builder.ToString()}");
                            }
                            else
                            {
                                errMessage =
                                    $"COM with name = '{SerialPort}' can't connect.\nPlease check again.";
                                return false;
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }
            return false;
        }
    }
}
