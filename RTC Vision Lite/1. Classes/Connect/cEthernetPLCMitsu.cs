using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using InControls.Common;
using InControls.PLC.FX;
using System.IO.Ports;
using RTCVision2101.PublicFunctions;
using InControls.PLC;
using System.Collections.Generic;
using LIB_MCProtocol.Mitsubishi;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace RTCVision2101.Classes
{
    /// <summary>
    /// Đối tượng đảm nhiệm vai trò khởi tạo một máy khách
    /// </summary>
    public class cEthernetPLCMitsu
    {
        /// <summary>
        /// Địa chỉ IP
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// Cổng của server
        /// </summary>
        public int Port { get; set; }
        public string PLCAddress { get; set; }
        public int ByteLength { get; set; }
        /// <summary>
        /// Dữ liệu tiếp nhận có phải dạng Hexa hay không
        /// </summary>
        public bool IsHex { get; set; }
        /// <summary>
        /// Thời gian đọc tối đa
        /// </summary>
        public int ReadTimeout { get; set; }
        /// <summary>
        /// Cờ báo đang connect đến PLC
        /// </summary>
        public bool IsConnected { get; set; }
        /// <summary>
        /// Đối tượng kết nối cổng COM
        /// </summary>
        private Plc MCApp;
        private string _Value = string.Empty;
        private byte[] buffer;
        private Thread ThreadGetValue;
        private bool IsRun;
        public ReceiveDataEvents OnReceiveDataEvents;
        public cEthernetPLCMitsu()
        {
            IsRun = false;
        }
        public cEthernetPLCMitsu(string _IPAddress, 
            int _Port, bool _IsHex,
            string _PLCAddress,int _ByteLength, 
            int _ReadTimeout=1000, bool _IsWithStart = true)
        {
            IsRun = false;
            IPAddress = _IPAddress;
            Port = _Port;
            IsHex = _IsHex;
            ReadTimeout = _ReadTimeout;
            ByteLength = _ByteLength;
            PLCAddress = _PLCAddress;
            if (_IsWithStart)
                Start();
        }
        /// <summary>
        /// Khởi chạy kết nối cổng COM
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                MCApp = new McProtocolTcp(IPAddress, Port);
                MCApp.Open();
                IsConnected = true;
                IsRun = true;

                ThreadGetValue = new Thread(() => ProcessGetValue());
                ThreadGetValue.IsBackground = true;
                ThreadGetValue.Start();

                return IsConnected;
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
        public void Stop()
        {
            IsRun = false;
            ThreadGetValue.Abort();
            if (MCApp != null)
            {
                MCApp.Close();
                MCApp.Dispose();
            }
            MCApp = null;
            IsConnected = false;
        }
        public byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Hàm đọc dữ liệu
        /// </summary>
        private void ProcessGetValue()
        {
            while (IsRun)
            {
                if (!IsRun) return;

                _Value = string.Empty;
                try
                {
                    if (MCApp != null && IsConnected)
                    {
                        string cmd = string.Format("{0},{1}", PLCAddress, ByteLength.ToString());
                        var value = MCApp.Excute(cmd);
                        if (value != null)
                        {
                            //Chuyển dữ liệu thanh ghi về dạng chuỗi
                            Array.Copy(ObjectToByteArray(value), buffer, ByteLength);
                            if (IsHex)
                                _Value = BitConverter.ToString(buffer).Replace("-", "");
                            else
                                _Value = Encoding.ASCII.GetString(buffer);

                            //Reset giá trị sau khi đọc xong
                            cmd = string.Format("{0},{1}=0", PLCAddress, ByteLength.ToString());
                            MCApp.Excute(cmd);
                        }
                    }
                }
                catch
                {
                    _Value = string.Empty;
                }
                if (_Value != string.Empty)
                {
                    if (OnReceiveDataEvents != null)
                    {
                        OnReceiveDataEvents(_Value);
                    }
                }
            }
        }

    }
}
