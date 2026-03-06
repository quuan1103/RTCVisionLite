using System;
using System.Runtime.InteropServices;
using RTCConst;
using RTC_Vision_Lite.PublicFunctions;

namespace RTC_Vision_Lite.Classes
{
    /// <summary>
    /// Đối tượng đảm nhiệm vai trò khởi tạo một máy khách
    /// </summary>
    public class CSTLightClient
    {
        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern int CST_EthernetConnectIP(string IP, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern int CST_EthernetConnectStop(ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_EthernetGetDigitalValue(int CH, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_SerialPortGetDigitalValue(int CH, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_EthernetGetStrobeValue(int CH, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_SerialPortGetStrobeValue(int CH, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_EthernetSetLightState(int CH, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_EthernetSetStrobeValue(int CH, int Light, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_EthernetSetDigitalValue(int CH, int Light, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_CreateSerialPort(int ComNum, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_ReleaseSerialPort(ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_SerialPortSetDigitalValue(int CH, int Light, ref Int64 Handle);

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_SerialPortSetStrobeValue(int CH, int Light, ref Int64 Handle);


        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern UInt16 CST_EthernetSetMulDigitalValue(MulDigitalValue[] mMulDigitalValue, int length, ref Int64 Handle);
        public struct MulDigitalValue
        {
            public int channelIndex;
            public int DigitalValue;
        }

        [DllImport("CSTControllerDll.dll", CallingConvention = CallingConvention.Cdecl)] public static extern int CST_CST_GetAdapter(IntPtr mAdapterPrmPtr);
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct Adapter_prm
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
            public char[] cSn;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] cIp;
        }
        //public struct Controller_prm
        //{
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
        //    public char[] cSn;
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        //    public char[] cIp;
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        //    public char[] cSm;
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        //    public char[] cGw;
        //    public byte DHCP;
        //}


        Int64 mHandle = 0;

        /// <summary>
        /// Cổng COM cần kết nối
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// Tốc độ truyền
        /// </summary>
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

        public string CSTLightSourceMode { get; set; }
        public bool IsConnected { get; set; }
        public CSTLightClient()
        {
            IsConnected = false;
        }
        /// <summary>
        /// Khởi chạy kết nối cổng COM
        /// </summary>
        /// <returns></returns>
        internal bool Connect()
        {
            try
            {
                IsConnected = false;
                switch (CSTLightSourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            int connectIp = CST_EthernetConnectIP(IPAddress, ref mHandle); //Connect IP
                            IsConnected = (connectIp == 10000);
                            break;
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            int comNum = (int)GlobFuncs.ExtractNumberOfString(SerialPort, 0);  //Get serial port number
                            int createSerialPort = CST_CreateSerialPort(comNum, ref mHandle);  //create serial port
                            IsConnected = (createSerialPort == 10000);
                            break;
                        }
                }

            }
            catch(Exception ex)
            {
                IsConnected = false;
            }

            return IsConnected;
        }
        /// <summary>
        /// Đóng kết nối COM
        /// </summary>
        internal bool Disconnect()
        {
            if (!IsConnected)
                return true;
            try
            {
                switch (CSTLightSourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            int stop = CST_EthernetConnectStop(ref mHandle); //Connect IP
                            IsConnected = (stop != 10000);
                            break;
                        }

                    case cCSTLightSourceMode.SerialPort:
                        {
                            int release = CST_ReleaseSerialPort(ref mHandle);  //create serial port
                            IsConnected = (release != 10000);
                            break;
                        }
                }
                return !IsConnected;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private string GetCstError(long mHandle)
        {
            switch (mHandle)
            {
                case 10001:
                    return "Error 10001: Socket initialization failed";
                case 10002:
                    return "Error 10002: Failed to close";
                case 10003:
                    return "Error 10003: Communication identifier error";
                case 10004:
                    return "Error 10004: Connection failed";
                case 10005:
                    return "Error 10005: Failed to receive";
                case 10006:
                    return "Error 10006: Failed to send";
                case 10007:
                    return "Error 10007: Data error";
                case 10008:
                    return "Error 10008: Return illegal value";
                case 10009:
                    return "Error 10009: Failed to read brightness";
                case 10010:
                    return "Error 10010: Failed to read strobe value";
                case 10011:
                    return "Error 10011: Failed to read light source output delay";
                case 10012:
                    return "Error 10012: Failed to read camera output delay";
                case 10013:
                    return "Error 10013: Failed to read internal and external trigger cycles";
                case 10014:
                    return "Error 10014: Failed to read internal and external trigger mode";
                case 10015:
                    return "Error 10015: Failed to read camera trigger edge";
                case 10016:
                    return "Error 10016: Failed to read always on and off mode";
                case 10017:
                    return "Error 10017: Failed to set brightness";
                case 10018:
                    return "Error 10018: Failed to set strobe value";
                case 10019:
                    return "Error 10019: Failed to set light source output delay value";
                case 10020:
                    return "Error 10020: Failed to set camera output delay";
                case 10021:
                    return "Error 10021: Trigger period failed within setup";
                case 10022:
                    return "Error 10022: Failed to set internal and external trigger mode";
                case 10023:
                    return "Error 10023: Failed to set camera trigger edge";
                case 10024:
                    return "Error 10024: Failed to set the always on and off mode";
                case 10025:
                    return "Error 10025: Device dropped";
                case 10026:
                    return "Error 10026: Failed to send heartbeat packet";
                case 10027:
                    return "Error 10027: Failed to get network card information";
                case 10028:
                    return "Error 10028: Failed to set multi-channel brightness";
                case 10029:
                    return "Error 10029: Failed to set multi-channel strobe value";
                case 10030:
                    return "Error 10030: Failed to set multi-channel light source output delay value";
                case 10031:
                    return "Error 10031: Failed to set multi-channel camera output delay value";
                default:
                    return string.Empty;
            }
        }
        internal int Read(int channel, out bool success, out string errMessage, string sourceType = cCSTLightSourceType.Light)
        {
            errMessage = string.Empty;
            success = false;
            int value = 0;
            try
            {
                switch (CSTLightSourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            switch (sourceType)
                            {
                                case cCSTLightSourceType.Light:
                                    {
                                        value = CST_EthernetGetDigitalValue(channel, ref mHandle);
                                        success = value == 10000;
                                        errMessage = GetCstError(value);
                                        break;
                                    }
                                case cCSTLightSourceType.Strobe:
                                    {
                                        value = CST_EthernetGetStrobeValue(channel, ref mHandle);
                                        success = value == 10000;
                                        errMessage = GetCstError(value);
                                        break;
                                    }
                            }
                            break;
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            switch (sourceType)
                            {
                                case cCSTLightSourceType.Light:
                                    {
                                        value = CST_SerialPortGetDigitalValue(channel, ref mHandle);
                                        success = value == 10000;
                                        errMessage = GetCstError(value);
                                        break;
                                    }
                                case cCSTLightSourceType.Strobe:
                                    {
                                        value = CST_SerialPortGetStrobeValue(channel, ref mHandle);
                                        success = value == 10000;
                                        errMessage = GetCstError(value);
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                value = 0;
                success = false;
                errMessage = ex.Message;
            }
            return value;
        }
        internal bool Write(int channel, int lightValue, out string errMessage, string sourceType = cCSTLightSourceType.Light)
        {
            errMessage = string.Empty;
            try
            {
                switch (CSTLightSourceMode)
                {
                    case cCSTLightSourceMode.Ethernet:
                        {
                            int result = -1;
                            switch (sourceType)
                            {
                                case cCSTLightSourceType.Light:
                                    {
                                        result = CST_EthernetSetDigitalValue(channel, lightValue, ref mHandle);
                                        errMessage = GetCstError(result);
                                        break;
                                    }
                                case cCSTLightSourceType.Strobe:
                                    {
                                        result = CST_EthernetSetStrobeValue(channel, lightValue, ref mHandle);
                                        errMessage = GetCstError(result);
                                        break;
                                    }
                            }
                            return result == 10000;
                        }
                    case cCSTLightSourceMode.SerialPort:
                        {
                            int result = -1;
                            switch (sourceType)
                            {
                                case cCSTLightSourceType.Light:
                                    {
                                        result = CST_SerialPortSetDigitalValue(channel, lightValue, ref mHandle);
                                        errMessage = GetCstError(result);
                                        break;
                                    }
                                case cCSTLightSourceType.Strobe:
                                    {
                                        result = CST_SerialPortSetStrobeValue(channel, lightValue, ref mHandle);
                                        errMessage = GetCstError(result);
                                        break;
                                    }
                            }
                            return result == 10000;
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
        internal bool WriteMultiValue(MulDigitalValue[] mulDigitalValue)
        {
            try
            {
                int RT2 = CST_EthernetSetMulDigitalValue(mulDigitalValue, mulDigitalValue.Length, ref mHandle);
                return RT2 == 10000;
            }
            catch
            {
                return false;
            }
        }
    }
}
