using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using RTC_Vision_Lite.PublicFunctions;

namespace RTC_Vision_Lite.Classes
{
    public class cTCPIPServer
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public bool IsHex { get; set; }
        public int ReceiveTimeOut { get; set; }
        public int SendTimeOut { get; set; }
        private Socket Client;
        private byte[] buffer;
        public bool IsConnected
        {
            get
            {
                try
                {
                    if (Client == null || !Client.Connected)
                        return false;
                    bool part1 = Client.Poll(1000, SelectMode.SelectRead);
                    bool part2 = (Client.Available == 0);
                    if (part1 && part2)
                        return false;
                    else
                        return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public string ErrMessage { get; set; }
        public ReceiveDataEvents OnReceiveDataEvents;
        public cTCPIPServer(string _HostName, int _Port, bool _IsHex, bool _IsWithStart = true,
            int receiveTimeout = 10000, int sendTimeOut = 10000)
        {
            ErrMessage = string.Empty;
            HostName = _HostName;
            Port = _Port;
            IsHex = _IsHex;
            ReceiveTimeOut = receiveTimeout;
            SendTimeOut = sendTimeOut;
            if (_IsWithStart)
                Connect(receiveTimeout, sendTimeOut);
        }
        public bool Connect(int receiveTimeout = 10000, int sendTimeOut = 10000)
        {
            ReceiveTimeOut = receiveTimeout;
            SendTimeOut = sendTimeOut;
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    ErrMessage = string.Empty;
                    Disconnect();
                    Client = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);
                    var endPoint = new IPEndPoint(IPAddress.Parse(HostName), Port);
                    Client.ReceiveTimeout = ReceiveTimeOut;
                    Client.SendTimeout = SendTimeOut;
                    Client.BeginConnect(endPoint,
                    new AsyncCallback(ConnectCallback), Client);
                    Thread.Sleep(1000);
                    return true;
                }
                catch (Exception ex)
                {
                    ErrMessage = ex.Message;
                }
            }
            return false;
        }
        public void Disconnect()
        {
            if (Client != null && Client.Connected)
            {
                Client.Shutdown(SocketShutdown.Both);
                Client.Close();
                Client.Dispose();
            }
            Client = null;
        }
        private void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                Client = (Socket)AR.AsyncState;
                Client.EndConnect(AR);
                buffer = new byte[Client.ReceiveBufferSize];
                Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), Client);
            }
            catch (SocketException ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            catch (ObjectDisposedException ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                Client = (Socket)AR.AsyncState;

                int received = Client.EndReceive(AR);

                if (received == 0)
                    return;

                string text = string.Empty;
                byte[] recBuf = new byte[received];
                Array.Copy(buffer, recBuf, received);

                if (IsHex)
                    text = BitConverter.ToString(recBuf).Replace("-", "");
                else
                    text = Encoding.ASCII.GetString(recBuf);

                if (!string.IsNullOrEmpty(text))
                {
                    if (OnReceiveDataEvents != null)
                    {
                        OnReceiveDataEvents(text);
                    }
                }

                Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), Client);
            }
            catch (SocketException ex)
            {
                GlobFuncs.SaveErr(ex);
            }
            catch (ObjectDisposedException ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public bool SendData(string value)
        {
            try
            {
                if (Client == null || !Client.Connected)
                    return false;

                if (IsHex)
                {
                    byte[] data = Encoding.Default.GetBytes(value);
                    string hexString = BitConverter.ToString(data);
                    hexString = hexString.Replace("-", "");
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    data = encoding.GetBytes(hexString);
                    Client.Send(data);
                    Client.Shutdown(SocketShutdown.Send);
                }
                else
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(value);
                    Client.Send(data);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
