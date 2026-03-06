using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Classes.Robot;
using RTC_Vision_Lite.PublicFunctions;

namespace RTC_Vision_Lite.Classes
{
    public class CSocketClient
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public bool IsHex { get; set; }
        public bool IsServer { get; set; }
        public int ReceiveTimeOut { get; set; }
        public int SendTimeOut { get; set; }
        public ProtocolType ProtocolType { get; set; }

        /// <summary>   The client. </summary>
        private Socket _socket;
        private UdpClient _udpClient;
        private List<Socket> _clientSockets;
        int BUFFER_SIZE = 1024;
        /// <summary>   The buffer. </summary>
        private byte[] _buffer;
        private CSocketServer _socketServer;
        private bool _isConnected = false;
        public bool IsConnected
        {
            get
            {
                try
                {
                    if (IsServer)
                        return (_socketServer != null && _socketServer.IsConnected);
                    if (ProtocolType == ProtocolType.Tcp)
                    {
                        if (_socket == null || !_socket.Connected)
                            return false;

                        bool part1 = _socket.Poll(1000, SelectMode.SelectRead);
                        bool part2 = (_socket.Available == 0);
                        if (part1 && part2)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        return _udpClient != null;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public string ErrMessage { get; set; }
        /// <summary>   The on receive data events. </summary>
        public ReceiveDataEvents OnReceiveDataEvents;
        public CSocketClient(string hostName,
            int port,
            bool isHex,
            List<Socket> clientSockets,
            ProtocolType protocolType = ProtocolType.Tcp,
            bool isServer = false,
            bool isWithStart = true,
            int receiveTimeout = 10000,
            int sendTimeOut = 10000)
        {
            ErrMessage = string.Empty;
            HostName = hostName;
            Port = port;
            IsHex = isHex;
            this._clientSockets = clientSockets;
            IsServer = isServer;
            ReceiveTimeOut = receiveTimeout;
            SendTimeOut = sendTimeOut;
            ProtocolType = protocolType;
            if (isWithStart)
                Connect(receiveTimeout, sendTimeOut);
        }
        public void OnServerReceiveDataEvents(string _Data)
        {
            if (OnReceiveDataEvents != null)
                OnReceiveDataEvents(_Data);
        }

        private Thread _updThreadRead = null;
        private Thread _updThreadWrite = null;
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

                    if (IsServer)
                    {
                        _socketServer = new CSocketServer(Port, ProtocolType, IsHex);
                        _socketServer.Start();
                        _socketServer.OnReceiveDataEvents -= OnServerReceiveDataEvents;
                        _socketServer.OnReceiveDataEvents += OnServerReceiveDataEvents;
                    }
                    else
                    {
                        if (ProtocolType == ProtocolType.Tcp)
                        {
                            _socket = new Socket(AddressFamily.InterNetwork,
                                (ProtocolType == ProtocolType.Tcp ? SocketType.Stream : SocketType.Dgram), ProtocolType);
                            var endPoint = new IPEndPoint((ProtocolType == ProtocolType.Tcp ? IPAddress.Parse(HostName) : IPAddress.Any), Port);
                            _socket.ReceiveTimeout = ReceiveTimeOut;
                            _socket.SendTimeout = SendTimeOut;
                            _socket.BeginConnect(endPoint,
                                new AsyncCallback(ConnectCallback), _socket);
                        }
                        else
                        {
                            _updThreadRead = new Thread(UdpReadData);
                            _updThreadRead.IsBackground = true;
                            _updThreadRead.Start();
                        }

                        Thread.Sleep(1000);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ErrMessage = ex.Message;
                }
            }
            return false;
        }

        private void UdpReadData()
        {
            while (true)
            {
                try
                {
                    UdpClient udpClient = new UdpClient(Port);
                    IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, Port);
                    Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                    string returnData = Encoding.ASCII.GetString(receiveBytes);
                    if (!string.IsNullOrEmpty(returnData))
                        if (OnReceiveDataEvents != null)
                            OnReceiveDataEvents(returnData);
                    _isConnected = true;
                }
                catch
                {
                    _isConnected = false;
                }
            }
        }
        public void Disconnect()
        {
            try
            {
                if (IsServer)
                {
                    if (_socketServer != null)
                        _socketServer.Stop();
                    _socketServer = null;
                }
                else
                {
                    if (ProtocolType == ProtocolType.Tcp)
                    {
                        if (_socket != null && _socket.Connected)
                        {
                            try
                            {
                                _socket.Shutdown(SocketShutdown.Both);
                            }
                            catch { }
                            _socket.Close();
                            _socket.Dispose();
                            _socket = null;
                        }
                    }
                    else
                    {
                        try
                        {
                            if (_updThreadRead != null)
                                _updThreadRead.Abort();
                        }
                        catch
                        {
                        }

                        if (_udpClient != null)
                        {
                            _udpClient.Close();
                            _udpClient.Dispose();
                            _udpClient = null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                GlobFuncs.SaveErr(e);
            }
        }
        private void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                _socket = (Socket)AR.AsyncState;
                _socket.EndConnect(AR);
                _buffer = new byte[_socket.ReceiveBufferSize];
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,
                    new AsyncCallback(ReceiveCallback), _socket);
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
                _socket = (Socket)AR.AsyncState;

                int received = _socket.EndReceive(AR);

                if (received == 0)
                    return;

                string text = string.Empty;
                byte[] recBuf = new byte[received];
                Array.Copy(_buffer, recBuf, received);

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

                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,
                    new AsyncCallback(ReceiveCallback), _socket);
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

                if (ProtocolType == ProtocolType.Tcp)
                {
                    if (IsServer && _socketServer != null && _socketServer.IsConnected)
                        _socketServer.SendAll(data);
                    else if (_socket == null || !_socket.Connected)
                        return false;
                    else
                        _socket.Send(data);
                }
                else
                {
                    UdpClient udpClient = new UdpClient();
                    udpClient.Send(data, data.Length, HostName, Port);
                    //_udpClient.SendAsync(data, data.Length, new IPEndPoint(IPAddress.Parse(HostName), Port));
                    //IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, Port);
                    //_udpClient.Send(data, data.Length, remoteIpEndPoint);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
                return false;
            }
        }
        public string GetData()
        {
            try
            {
                if (IsServer)
                {
                    byte[] buffer = new byte[1024];
                    _socket.Receive(buffer);
                    return IsHex ? BitConverter.ToString(buffer).Replace("\0", "").Replace("-", "") : Encoding.ASCII.GetString(buffer).Replace("\0", "");
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
