using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;

namespace RTCVision2101.Classes
{
    public class cUdp
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public bool IsHex { get; set; }
        public string ErrMessage { get; set; }
        /// <summary>   The on receive data events. </summary>
        public ReceiveDataEvents OnReceiveDataEvents;
        public cUdp(string hostName,
            int port,
            bool isHex)
        {
            ErrMessage = string.Empty;
            HostName = hostName;
            Port = port;
            IsHex = isHex;
        }

        public void StartGetData()
        {
            _isGetData = true;
            _udpThreadRead = new Thread(GetData);
            _udpThreadRead.IsBackground = true;
            _udpThreadRead.Start();
        }

        public void OnServerReceiveDataEvents(string data)
        {
            if (OnReceiveDataEvents != null)
                OnReceiveDataEvents(data);
        }

        private Thread _udpThreadRead = null;
        private bool _isGetData = false;
        private readonly object _clientLock = new object();

        private void GetData()
        {
            while (_isGetData)
            {
                UdpClient udpClient = null;
                try
                {
                    lock (_clientLock)
                    {
                        ErrMessage = string.Empty;
                        udpClient = new UdpClient(Port);
                        IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, Port);
                        Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                        string returnData = Encoding.ASCII.GetString(receiveBytes);
                        udpClient.Close();
                        udpClient.Dispose();

                        if (!string.IsNullOrEmpty(returnData))
                            if (OnReceiveDataEvents != null)
                                OnReceiveDataEvents(returnData);
                    }
                }
                catch (Exception ex)
                {
                    ErrMessage = ex.Message;
                }
                finally
                {
                    if (udpClient != null)
                    {
                        udpClient.Close();
                        udpClient.Dispose();
                    }
                }
            }
        }
        public bool SendData(string value)
        {
            try
            {
                ErrMessage = string.Empty;
                byte[] data;
                if (IsHex)
                {
                    data = Encoding.Default.GetBytes(value);
                    string hexString = BitConverter.ToString(data);
                    hexString = hexString.Replace("-", "");
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    data = encoding.GetBytes(hexString);
                }
                else
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    data = encoding.GetBytes(value);
                }

                lock (_clientLock)
                {
                    UdpClient udpClient = new UdpClient();
                    udpClient.Send(data, data.Length, HostName, Port);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
                return false;
            }
        }
        public void Disconnect()
        {
            try
            {
                _isGetData = false;
                if (_udpThreadRead != null)
                {
                    _udpThreadRead.Abort();
                    _udpThreadRead = null;
                }
            }
            catch
            {
            }
        }
    }
}
