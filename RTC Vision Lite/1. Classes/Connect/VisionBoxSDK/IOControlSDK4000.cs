using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace NsIOControllerSDK.VC4000
{
    internal class CIOControllerSDK4000
    {
        // Fields
        public const int MV_OK = 0;
        public const int MV_E_HANDLE = -2_147_483_648;
        public const int MV_E_SUPPORT = -2_147_483_647;
        public const int MV_E_BUFOVER = -2_147_483_646;
        public const int MV_E_CALLORDER = -2_147_483_645;
        public const int MV_E_PARAMETER = -2_147_483_644;
        public const int MV_E_RESOURCE = -2_147_483_642;
        public const int MV_E_NODATA = -2_147_483_641;
        public const int MV_E_PRECONDITION = -2_147_483_640;
        public const int MV_E_VERSION = -2_147_483_639;
        public const int MV_E_NOENOUGH_BUF = -2_147_483_638;
        public const int MV_E_MATCH = -2_147_483_637;
        public const int MV_E_UPDATING = -2_147_483_636;
        public const int MV_E_UNKNOW = -2_147_483_393;
        public const int MV_E_GC_GENERIC = -2_147_483_392;
        public const int MV_E_GC_ARGUMENT = -2_147_483_391;
        public const int MV_E_GC_RANGE = -2_147_483_390;
        public const int MV_E_GC_PROPERTY = -2_147_483_389;
        public const int MV_E_GC_RUNTIME = -2_147_483_388;
        public const int MV_E_GC_LOGICAL = -2_147_483_387;
        public const int MV_E_GC_ACCESS = -2_147_483_386;
        public const int MV_E_GC_TIMEOUT = -2_147_483_385;
        public const int MV_E_GC_DYNAMICCAST = -2_147_483_384;
        public const int MV_E_GC_UNKNOW = -2_147_483_137;
        public const int MV_E_NOT_IMPLEMENTED = -2_147_483_136;
        public const int MV_E_INVALID_ADDRESS = -2_147_483_135;
        public const int MV_E_WRITE_PROTECT = -2_147_483_134;
        public const int MV_E_ACCESS_DENIED = -2_147_483_133;
        public const int MV_E_BUSY = -2_147_483_132;
        public const int MV_E_PACKET = -2_147_483_131;
        public const int MV_E_NETER = -2_147_483_130;
        public const int MV_E_USB_READ = -2_147_482_880;
        public const int MV_E_USB_WRITE = -2_147_482_879;
        public const int MV_E_USB_DEVICE = -2_147_482_878;
        public const int MV_E_USB_GENICAM = -2_147_482_877;
        public const int MV_E_USB_BANDWIDTH = -2_147_482_876;
        public const int MV_E_USB_UNKNOW = -2_147_482_625;
        public const int MV_E_UPG_FILE_MISMATCH = -2_147_482_624;
        public const int MV_E_UPG_LANGUSGE_MISMATCH = -2_147_482_623;
        public const int MV_E_UPG_CONFLICT = -2_147_482_622;
        public const int MV_E_UPG_INNER_ERR = -2_147_482_621;
        public const int MV_E_UPG_UNKNOW = -2_147_482_369;
        public const int nMaxDeviceNum = 0x20;
        public static IntPtr[] m_hDeviceHandleList;
        public static int nComIndex;

        // Methods
        [DllImport(@"VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_AssociatedOutPort(IntPtr handle, ref MV_IO_ASSOCIATEPORT_PARAM stParam);
        public static int MV_IO_AssociatedOutPort_CS(IntPtr handle, ref MV_IO_ASSOCIATEPORT_PARAM stParam) =>
            MV_IO_AssociatedOutPort(handle, ref stParam);

        [DllImport(@"VC4000\\MvIOInterfaceBox.dll")]
        private static extern void MV_IO_Close(IntPtr handle);
        public static void MV_IO_Close_CS(IntPtr handle)
        {
            MV_IO_Close(handle);
        }
        [DllImport(@"VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_CreateHandle(ref IntPtr handle);
        [DllImport(@"VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_DestroyHandle(IntPtr handle);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_GetFirmwareVersion(IntPtr handle, ref MV_IO_VERSION pstVersion);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_GetInputLevel(IntPtr handle, ref MV_IO_INPUT_LEVEL pstInputLevel);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_GetLightParam(IntPtr handle, ref MV_IO_LIGHT_PARAM pstLightParam);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_GetPortInputParam(IntPtr handle, ref MV_IO_SET_INPUT stParam);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_GetPortOutputParam(IntPtr handle, ref MV_IO_SET_OUTPUT stParam);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_GetSDKVersion(ref MV_IO_VERSION pstVersion);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_LocalUpgrade(IntPtr handle, byte[] pData, uint nLen, ref MV_IO_LOCAL_UPGRADE pstLocalUpgrade);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_Open(IntPtr handle, ref MV_IO_SERIAL pstSerial);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_Reboot(IntPtr handle);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_RegisterEdgeDetectionCallBack(IntPtr handle, cbOutputdelegate cbOutput, IntPtr pUser);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_ResetParam(IntPtr handle);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern void MV_IO_SetDebugView(int nFlag);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_SetInput(IntPtr handle, ref MV_IO_SET_INPUT stParam);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_SetLightParam(IntPtr handle, ref MV_IO_LIGHT_PARAM pstLightParam);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_SetOutput(IntPtr handle, ref MV_IO_SET_OUTPUT stParam);
        [DllImport("VC4000\\MvIOInterfaceBox.dll")]
        private static extern int MV_IO_SetOutputEnable(IntPtr handle, ref MV_IO_OUTPUT_ENABLE stParam);

        // Nested Types
        public delegate void cbOutputdelegate(IntPtr handle, ref MV_IO_INPUT_EDGE_TYPE stParam, IntPtr pUser);
        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_ASSOCIATEPORT_PARAM
        {
            public ushort nInPortNum;
            public ushort nOutPortNum;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] nReserved;
        }

        public enum MV_IO_EDGE_NOTICE_STATE
        {
            MV_IO_EDGE_NOTICE_DISABLE,
            MV_IO_EDGE_NOTICE_ENABLE
        }

        public enum MV_IO_EDGE_TYPE
        {
            MV_IO_EDGE_RISING = 1,
            MV_IO_EDGE_FALLING = 2
        }

        public enum MV_IO_ENABLE_TYPE
        {
            MV_IO_ENABLE_START,
            MV_IO_ENABLE_END
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_INPUT_EDGE_TYPE
        {
            public byte nPortNumber;
            public ushort nTriggerTimes;
            public MV_IO_EDGE_TYPE enEdgeType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public uint[] nReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_INPUT_LEVEL
        {
            public byte nPortNumber;
            public byte nLevel0;
            public byte nLevel1;
            public byte nLevel2;
            public byte nLevel3;
            public byte nLevel4;
            public byte nLevel5;
            public byte nLevel6;
            public byte nLevel7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public uint[] nReserved;
        }

        public enum MV_IO_LEVEL
        {
            MV_IO_LEVEL_LOW,
            MV_IO_LEVEL_HIGH
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_LIGHT_PARAM
        {
            public byte nPortNumber;
            public ushort nLightValue;
            public ushort nLightState;
            public ushort nLightEdge;
            public ushort nDurationTime;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public uint[] nReserved;
        }

        public enum MV_IO_LIGHTSTATE
        {
            MV_IO_LIGHTSTATE_ON = 1,
            MV_IO_LIGHTSTATE_OFF = 2
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_LOCAL_UPGRADE
        {
            public uint nProcPercent;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x40)]
            public string strProcState;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public uint[] nReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_OUTPUT_ENABLE
        {
            public byte nPortNumber;
            public byte nType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] nReserved;
        }

        public enum MV_IO_PATTERN_OUT
        {
            MV_IO_PATTERN_PWM = 5,
            MV_IO_PATTERN_SINGLE = 6
        }

        public enum MV_IO_PORT_NUMBER
        {
            MV_IO_PORT_1 = 1,
            MV_IO_PORT_2 = 2,
            MV_IO_PORT_3 = 4,
            MV_IO_PORT_4 = 8,
            MV_IO_PORT_5 = 0x10,
            MV_IO_PORT_6 = 0x20,
            MV_IO_PORT_7 = 0x40,
            MV_IO_PORT_8 = 0x80
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_SERIAL
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x40)]
            public string strComName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public uint[] nReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_SET_INPUT
        {
            public uint nPort;
            public uint nEnable;
            public uint nEdge;
            public uint nDelayTime;
            public uint nGlitch;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public uint[] nReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_SET_OUTPUT
        {
            public uint nPort;
            public uint nType;
            public uint nPulseWidth;
            public uint nPulsePeriod;
            public uint nDurationTime;
            public uint nValidLevel;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public uint[] nReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MV_IO_VERSION
        {
            public uint nMainVersion;
            public uint nSubVersion;
            public uint nModifyVersion;
            public uint nYear;
            public uint nMonth;
            public uint nDay;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public uint[] nReserved;
        }
    }
}