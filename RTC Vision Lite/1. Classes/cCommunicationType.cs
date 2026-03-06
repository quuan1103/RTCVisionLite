using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    /// <summary>
    /// Thiết lập của TCPIP
    /// </summary>
    public class cTCPIPSettings
    {
        /// <summary>
        /// Địa chỉ server
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Timeout
        /// </summary>
        public int TimeOut { get; set; }
        private Socket SocketConn = null;

        public bool Connected
        {
            get
            {
                if (SocketConn == null)
                    return false;
                else
                    return SocketConn.Connected;
            }
        }

        public cTCPIPSettings()
        {
            HostName = "127.0.0.1";
            Port = 3050;
            TimeOut = 1000;
        }
        public void DisconnectTCPIP()
        {
            if (SocketConn != null && SocketConn.Connected)
                SocketConn.Close();

            SocketConn = null;
        }
        /// <summary>
        /// Connect đến host
        /// </summary>
        /// <returns></returns>
        public bool ConnectTCPIP()
        {
            try
            {
                IPAddress iPAddress = IPAddress.Parse(HostName);
                IPEndPoint ipe = new IPEndPoint(iPAddress, Port);

                SocketConn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketConn.Connect(ipe);
                SocketConn.ReceiveTimeout = 1000;
                SocketConn.SendTimeout = 1000;
                return SocketConn.Connected;
            }
            catch
            {
                SocketConn = null;
                return false;
            }
        }
        public void SendData(byte[] _Data)
        {
            try
            {
                SocketConn.Send(_Data);
            }
            catch
            {

            }
        }
        public string GetData(int _Length)
        {
            try
            {
                byte[] buffer = new byte[_Length];
                SocketConn.Receive(buffer);
                ASCIIEncoding encoding = new ASCIIEncoding();
                string value = encoding.GetString(buffer).Replace("\0","");
                return value;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
    /// <summary>
    /// Đối trượng chứa thông số của 1 thiết bị
    /// </summary>
    public class cDevice
    {
        public int OrderNum { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        public bool IsUse { get; set; }
        public EDeviceTypes DeviceType { get; set; }
        public string Manufacture { get; set; }
        public EProtocols ProtocolType { get; set; }
        public EOutputStringMode OutputStringMode { get; set; }
        public cTCPIPSettings TCPSetting { get; set; }
        public string PassedValue { get; set; }
        public string FailedValue { get; set; }
        public Guid StringBuilderToolID { get; set; }
        public string StringBuilderToolName { get; set; }
        public Control ViewInfo { get; set; }

        public bool Passed { get; set; }

        public cDevice()
        {
            OrderNum = 0;
            Name = string.Empty;
            Manufacture = string.Empty;
            Selected = false;
            IsUse = true;
            DeviceType = EDeviceTypes.None;
            ProtocolType = EProtocols.TCPIP;
            TCPSetting = null;
            StringBuilderToolID = Guid.Empty;
            StringBuilderToolName = string.Empty;
            ViewInfo = null;
        }
        public cDevice(EDeviceTypes _DeviceType, string _Manufacture, EProtocols _ProtocolType)
        {
            OrderNum = 0;
            switch(_ProtocolType)
            {
                case EProtocols.Modbus:
                    Name = cCommunication_Protocol.Modbus;
                    break;
                case EProtocols.CCLink:
                    Name = cCommunication_Protocol.CCLink;
                    break;
                case EProtocols.SLMP:
                    Name = cCommunication_Protocol.SLMP;
                    break;
                case EProtocols.SLMPScaner:
                    Name = cCommunication_Protocol.SLMPScaner;
                    break;
                case EProtocols.EthernetIP:
                    Name = cCommunication_Protocol.EthernetIP;
                    break;
                case EProtocols.PROFINET:
                    Name = cCommunication_Protocol.PROFINET;
                    break;
                case EProtocols.EthernetNR:
                    Name = cCommunication_Protocol.EthernetNR;
                    break;
                case EProtocols.EthernetIR:
                    Name = cCommunication_Protocol.EthernetIR;
                    break;
                case EProtocols.EthernetNS:
                    Name = cCommunication_Protocol.EthernetNS;
                    break;
                case EProtocols.TCPIP:
                    Name = cCommunication_Protocol.TCPIP;
                    TCPSetting = new cTCPIPSettings();
                    break;
                case EProtocols.UDP:
                    Name = cCommunication_Protocol.UDP;
                    break;
                default:
                    Name = Enum.GetName(typeof(EProtocols), _ProtocolType);
                    break;
            }
            Manufacture = _Manufacture;
            Selected = false;
            DeviceType = _DeviceType;
            ProtocolType = _ProtocolType;
            StringBuilderToolID = Guid.Empty;
            StringBuilderToolName = string.Empty;
            OutputStringMode = EOutputStringMode.Tool;
            Passed = false;
            PassedValue = "GP1OK";
            FailedValue = "GP1NG";
            CreateViewInfo(_ProtocolType);

        }

        private void CreateViewInfo_TCPIP()
        {
            //ViewInfo = new ucTCPIPSetup();
        }

        private void CreateViewInfo(EProtocols _ProtocolType)
        {
            ViewInfo = null;
            switch(_ProtocolType)
            {
                case EProtocols.Modbus:
                    break;
                case EProtocols.CCLink:
                    break;
                case EProtocols.SLMP:
                    break;
                case EProtocols.SLMPScaner:
                    break;
                case EProtocols.EthernetIP:
                    break;
                case EProtocols.PROFINET:
                    break;
                case EProtocols.EthernetNR:
                    break;
                case EProtocols.EthernetIR:
                    break;
                case EProtocols.EthernetNS:
                    break;
                case EProtocols.TCPIP:
                    CreateViewInfo_TCPIP();
                    break;
                case EProtocols.UDP:
                    break;
                default:
                    ViewInfo = null;
                    break;
            }
        }
    }
    class cCommunicationType
    {
    }
}
