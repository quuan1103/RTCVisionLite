using InControls.Common;
using RTC_Vision_Lite.PublicFunctions;
using RTCEnums;
using RTCVision2101.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cTrigger
    {
        public cAction ActionTcpRead = null;
        private string RealTriggerValue = string.Empty;
        private cCOMPLCMitsu _COMPLCMitsu = null;
        private Socket _SocketConn = null;

        public string ErrMessage;

        public bool Trigger()
        {
            switch (TriggerMode)
            {
                case ETriggerMode.None:
                    return TriggerNone();
                case ETriggerMode.IO:
                    return TriggerIO();
                case ETriggerMode.TCPIP:
                    return TriggerTCPIP();
                case ETriggerMode.PLCMitsu:
                    switch (PLCReadType)
                    {
                        case EPLCReadType.COM:
                            return TriggerPLCMitsu_COM();
                        case EPLCReadType.Ethernet:
                            return true;
                        case EPLCReadType.Modbus:
                            return true;
                        default:
                            return false;
                    }
                default:
                    return true;

            }
        }
        private bool TriggerPLCMitsu_COM()
        {
            string _Value = string.Empty;
            if (_COMPLCMitsu == null || !_COMPLCMitsu.Connected)
                ConnectPLCMitsu_COM();
            try
            {
                _Value = _COMPLCMitsu.GetValue();

                if (_Value == TriggerValue)
                    return true;
                else
                    return false;
            }
            catch
            {
                ConnectPLCMitsu_COM();
                return false;
            }
        }
        private bool ConnectPLCMitsu_COM()
        {
            try
            {
                _COMPLCMitsu = new cCOMPLCMitsu();
                _COMPLCMitsu.COMName = COMName;
                _COMPLCMitsu.BaudRate = BaudRate;
                _COMPLCMitsu.DataBits = DataBits;
                _COMPLCMitsu.Parity = Parity;
                _COMPLCMitsu.StopBits = StopBits;
                _COMPLCMitsu.IsHex = IsHex;
                _COMPLCMitsu.PLCAddress = PLCAddress;
                _COMPLCMitsu.ByteLength = ByteLenght;
                _COMPLCMitsu.ControllerTypeConst = ControllerTypeConst;
                return _COMPLCMitsu.Start();
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                ErrMessage = ex.Message;
                _SocketConn = null;
                return false;
            }
        }
        private bool TriggerTCPIP()
        {
            ConnetTCPIP();
            if (ActionTcpRead != null)
            {
                RealTriggerValue = GlobFuncs.Ve2Str(ActionTcpRead.Value.rtcValue);
                if (RealTriggerValue == TriggerValue)
                {
                    ActionTcpRead.Value.rtcValue = new List<string>();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private bool ConnetTCPIP()
        {
            try
            {
                if (ActionTcpRead != null)
                    return true;
                ActionTcpRead = new cAction(EActionTypes.TCPIPRead, EObjectTypes.Action, null, null)
                {
                    IsServer =
                    {
                        rtcValue = IsServer
                    },
                    IPAddress =
                    {
                        rtcValue = IP
                    },
                    PortNumber =
                    {
                        rtcValue = Port
                    }
                };
                ActionTcpRead.Run_TCPIPRead();
                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                ErrMessage = ex.Message;
                ActionTcpRead = null;
                return false;
            }
        }

        private bool TriggerIO()
        {
            return true;
        }

        private bool TriggerNone()
        {
            return true;
        }
    }
}
