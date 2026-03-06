using System;
using System.Net;
using System.Text;
using System.Threading;
using SuperSimpleTcp;

namespace RtcTcpIp
{
    public delegate void TcpIpMessageReceived(string data);
    public class TcpIp
    {
        private string _returnValue;
        public string ReturnValue
        {
            get
            {
                string s = _returnValue;
                _returnValue = string.Empty;
                return s;
            }
        }
        public int Port { get; set; }
        public string IpAddress { get; set; }
        public bool IsServer { get; set; }
        private bool _isHex = false;
        public bool IsHex
        {
            get => _isHex;
            set
            {
                _isHex = value;
                if (_server != null)
                    _server.IsHex = value;
                if (_client != null)
                    _client.IsHex = value;
            }
        }
        public bool IsRead { get; set; }
        public int SendTimeOut { get; set; } = 1000;
        public int ReceiveTimeOut { get; set; } = 1000;
        public bool IsConnected => (IsServer && _server != null && _server.IsConnected) ||
                                   (!IsServer && _client != null && _client.IsConnected);
        public event TcpIpMessageReceived OnReceiveDataEvents;
        private TcpIpServer _server = null;
        private TcpIpClient _client = null;
        public TcpIp(string ipAddress, int port, bool isHex, bool isServer, bool isRead)
        {
            IsServer = isServer;
            IsHex = isHex;
            IsRead = isRead;
            IpAddress = ipAddress;
            Port = port;
        }
        public TcpIp(bool isServer = true)
        {
            IsServer = isServer;
        }
        public void Disconnect()
        {
            if (IsServer)
            {
                if (_server != null)
                {
                    _server.Disconnect();
                    _server.OnTcpIpMessageReceived -= ReceiveDataEvents;
                    _server = null;
                }
            }
            else if (_client != null)
            {
                _client.Disconnect();
                _client.OnTcpIpMessageReceived -= ReceiveDataEvents;
                _client = null;
            }
        }
        public void SetEvent(TcpIpMessageReceived tcpIpMessageReceived)
        {
            OnReceiveDataEvents -= tcpIpMessageReceived;
            OnReceiveDataEvents += tcpIpMessageReceived;
        }
        public void RemoveEvent(TcpIpMessageReceived tcpIpMessageReceived)
        {
            if (OnReceiveDataEvents != null)
                OnReceiveDataEvents -= tcpIpMessageReceived;
        }
        public bool Connect()
        {
            try
            {
                Disconnect();
                if (IsServer)
                {
                    _server = new TcpIpServer();
                    _server.OnTcpIpMessageReceived += ReceiveDataEvents;
                    _server.Connect(IpAddress, Port, IsHex, IsRead);
                }
                else
                {
                    _client = new TcpIpClient();
                    _client.OnTcpIpMessageReceived += ReceiveDataEvents;
                    _client.Connect(IpAddress, Port, IsHex, IsRead);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Connect(string ipAddress, int port)
        {
            try
            {
                IpAddress = ipAddress;
                Port = port;
                Disconnect();
                if (IsServer)
                {
                    _server = new TcpIpServer();
                    _server.OnTcpIpMessageReceived += ReceiveDataEvents;
                    _server.Connect(ipAddress, port, IsHex, IsRead);
                }
                else
                {
                    _client = new TcpIpClient();
                    _client.OnTcpIpMessageReceived += ReceiveDataEvents;
                    _client.Connect(ipAddress, port, IsHex, IsRead);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Send(string data)
        {
            _returnValue = string.Empty;
            if (IsServer)
            {
                if (_server == null)
                    return false;
                else
                    return _server.Send(data);
            }
            else
            {
                if (_client == null)
                    return false;
                else
                    return _client.Send(data);
            }

        }
        private void ReceiveDataEvents(string data)
        {
            _returnValue = data;
            if (OnReceiveDataEvents != null)
                OnReceiveDataEvents(data);
        }
        public override bool Equals(object obj)
        {
            return obj is TcpIp ip &&
                   _isHex == ip._isHex;
        }
        public string GetReceiveDataWithTimeOut()
        {
            DateTime startTime = DateTime.Now;
            double span = 0;
            while (span <= ReceiveTimeOut)
            {
                if (!string.IsNullOrEmpty(_returnValue))
                    break;
                Thread.Sleep(10);
                TimeSpan ts = DateTime.Now - startTime;
                span = ts.TotalMilliseconds;
            }
            return _returnValue;
        }
    }
    internal class TcpIpServer
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public bool IsHex { get; set; }
        public bool IsRead { get; set; }
        //private string PortS => $"{(IpAddress == "127.0.0.1" || IpAddress == "localhost" || IpAddress == "0.0.0.0" || IpAddress == "*" ? "*" : IpAddress)}:{Port}";
        private string PortS => $"{IpAddress}:{Port}";
        public bool IsConnected => _server != null && _server.IsListening;

        public event TcpIpMessageReceived OnTcpIpMessageReceived;
        private SimpleTcpServer _server = null;
        public void Disconnect()
        {
            try
            {
                if (_server != null)
                {
                    _server.DisconnectClient(PortS);
                    _server.Events.DataReceived -= DataReceived;
                    _server.Stop();
                    _server.Dispose();
                }
                _server = null;
            }
            catch (Exception ex)
            {
            }
        }
        public bool Connect(string ipAddress, int port, bool isHex, bool isRead)
        {
            try
            {
                IpAddress = ipAddress;
                Port = port;
                IsHex = isHex;
                IsRead = isRead;
                Disconnect();
                _server = new SimpleTcpServer(PortS);
                _server.Events.DataReceived -= DataReceived;
                _server.Events.DataReceived += DataReceived;
                _server.Start();
                _server.Keepalive.EnableTcpKeepAlives = true;
                return _server.IsListening;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Send(string data)
        {
            if (_server.IsListening)
            {
                foreach (string client in _server.GetClients())
                    if (_server.IsConnected(client))
                        try
                        {
                            if (IsHex && !IsRead)
                            {
                                byte[] bytes = Encoding.Default.GetBytes(data);
                                string hexString = BitConverter.ToString(bytes);
                                hexString = hexString.Replace("-", "");
                                _server.Send(client, hexString);
                            }
                            else
                                _server.Send(client, data);
                        }
                        catch
                        {
                            return false;
                        }

                //if (IsHex || IsRead)
                //    data = Encoding.ASCII.GetString(FromHex(data));

                //if (OnTcpIpMessageReceived != null)
                //    OnTcpIpMessageReceived(data);

                return true;
            }
            return false;
        }
        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e == null || e.Data.Array == null || e.Data.Count <= 0)
                    return;
                string text = string.Empty;
                if (IsHex)
                {
                    text = Encoding.ASCII.GetString(e.Data.Array, 0, e.Data.Count);
                    text = Encoding.ASCII.GetString(FromHex(text));
                }
                else
                    text = Encoding.ASCII.GetString(e.Data.Array, 0, e.Data.Count);

                if (OnTcpIpMessageReceived != null)
                    OnTcpIpMessageReceived(text);
            }
            catch
            {
            }
        }
    }
    internal class TcpIpClient
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public bool IsHex { get; set; }
        public bool IsRead { get; set; }
        public bool IsConnected => _client != null && _client.IsConnected;
        private string _returnValue;
        public string ReturnValue
        {
            get
            {
                string s = _returnValue;
                _returnValue = string.Empty;
                return s;
            }
        }

        public event TcpIpMessageReceived OnTcpIpMessageReceived;
        private SimpleTcpClient _client = null;
        public void Disconnect()
        {
            try
            {
                if (_client != null)
                {
                    _client.Disconnect();
                    _client.Events.DataReceived -= DataReceived;
                    _client.Dispose();
                }
                _client = null;
            }
            catch (Exception ex)
            {
            }
        }
        public bool Connect(string ipAddress, int port, bool isHex, bool isRead)
        {
            try
            {
                IpAddress = ipAddress;
                Port = port;
                IsHex = isHex;
                IsRead = isRead;
                Disconnect();
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
                _client = new SimpleTcpClient(ipEndPoint);
                _client.Events.DataReceived += DataReceived;
                _client.Connect();
                return _client.IsConnected;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Send(string data)
        {
            if (IsConnected)
                try
                {
                    if (IsHex && !IsRead)
                    {
                        byte[] bytes = Encoding.Default.GetBytes(data);
                        string hexString = BitConverter.ToString(bytes);
                        hexString = hexString.Replace("-", "");
                        _client.Send(hexString);
                    }
                    else
                        _client.Send(data);
                    return true;
                }
                catch
                {
                    return false;
                }
            return false;
        }
        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e == null || e.Data.Array == null || e.Data.Count <= 0)
                    return;
                _returnValue = string.Empty;
                if (IsHex)
                {
                    _returnValue = Encoding.ASCII.GetString(e.Data.Array, 0, e.Data.Count);
                    _returnValue = Encoding.ASCII.GetString(FromHex(_returnValue));
                }
                else
                    _returnValue = Encoding.ASCII.GetString(e.Data.Array, 0, e.Data.Count);
                if (OnTcpIpMessageReceived != null)
                    OnTcpIpMessageReceived(_returnValue);
            }
            catch
            {
            }
        }
    }
}
