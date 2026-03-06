using System;
using System.Runtime.InteropServices;

using BOOL = System.Boolean;
using BYTE = System.Char;
using WORD = System.UInt16;
using DWORD = System.UInt32;

namespace RTC_Vision_Lite.Classes
{
    public class WDT_DIO
    {
        public const BYTE DTIO_INIT_HIGN = (BYTE)0x01;
        public const BYTE DTFO_INIT_HIGN = (BYTE)0x01;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct COS_INT_SETUP
        {
            public WORD portMask;       // [in ] interrupt mask for corresponding DI channel(s), 0: disable 1: enable COS interrupt
            public WORD edgeMode;       // [in ] specify the condition of generating COS interrupt for corresponding DI channel(s), 0: level change 1: rising/falling edge
            public WORD edgeType;       // [in ] specify the rising/falling edge for corresponding DI channel(s), 0: rising edge 1: falling edge
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct COS_INT_CALLBACK_ARG
        {
            public WORD portData;       // [out] port input data
            public WORD intrFlag;       // [out] interrupt flag
            public BYTE intrSeq;        // [out] interrupt sequence number (0~255)
        }

        // Data structures for supporting Deterministic Trigger I/O (for Nuvo-3000 series and Nuvo-3304af)
        // If trigSrcDI is configured for multiple pulseTgtDO(s), the last rising/falling edge setting is effecitve
        //
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DTIO_SETUP
        {
            public BYTE trigMode;       // [in ] 0: never triggered (disabled mode), 1: always triggered, 2: rising edge, 3: falling edge
            public BYTE trigSrcDI;      // [in ] single DI channel used as trigger source input (ex: 0~7 for Nuvo-3000)
            public BYTE pulseTgtDO;     // [in ] single DO channel used as pulse target output (ex: 0~7 for Nuvo-3000)
            public BYTE pulseExtra;     // [in ] some extra-parameter combination for DTIO function (ex: DTIO_INIT_HIGN)
            public DWORD pulseDelay;     // [in ] output pulse delay tick count, range: 2~2147483647
            public DWORD pulseWidth;     // [in ] output pulse width tick count, range: 1~2147483647
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DTFO_SETUP
        {
            public BYTE trigMode;       // [in ] 0: never triggered (disabled mode), 1: reserved, 2: rising edge, 3: falling edge
            public BYTE trigSrcDI;      // [in ] single DI channel used as trigger source input (ex: 0~7 for Nuvo-3000)
            public BYTE pulseTgtDO;     // [in ] single DO channel used as pulse target output (ex: 0~7 for Nuvo-3000)
            public BYTE pulseExtra;     // [in ] some extra-parameter combination for DTFO function (ex: DTFO_INIT_HIGN)
            public DWORD pulseTag;       // [in ] reserved field
            public DWORD pulseWidth;     // [in ] output pulse width tick count, range: 1~2147483647
        }


        // Register WinIO driver for non-administrator operation
        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL RegisterWinIOService(); // Obselete function

        // Isolated Digital I/O function
        //
        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL InitDIO();

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL DIReadLine(byte ch);

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort DIReadPort();

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DOWriteLine(byte ch, bool value);

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DOWritePort(ushort value);

        // Watch-dog timer function
        //
        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitWDT();

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL StartWDT();

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL StopWDT();

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL SetWDT(ushort tick, byte unit);

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL ResetWDT();

        // PoE ports enable/disable & deterministic trigger I/O (for Nuvo-3304af only)
        //
        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BYTE GetStatusPoEPort(BYTE port);  //Get status of PoE port, 0: disabled 1: enabled

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL EnablePoEPort(BYTE port);  //Enable PoE port

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL DisablePoEPort(BYTE port);  //Disable PoE port

        // DI Change-of-State notification
        //
        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL SetupDICOS(ref COS_INT_SETUP lpSetup, DWORD cbSetup);  //Setup DI Change-of-State interrupt parameters

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL StartDICOS();  //Start DI Change-of-State interrupt

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL StopDICOS();  //Stop DI Change-of-State interrupt

        //typedef void (__stdcall* COS_INT_CALLBACK)(COS_INT_CALLBACK_ARG* arg);
        public delegate void COS_INT_CALLBACK(ref COS_INT_CALLBACK_ARG arg);

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL RegisterCallbackDICOS(COS_INT_CALLBACK callback);  //Register DI Change-of-State interrupt callback function


        // Deterministic Trigger I/O
        //
        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL SetupDTIO(ref DTIO_SETUP lpSetup, DWORD cbSetup);

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL StartDTIO();  //[NOTE] If DICOS is started, this will stop it by internal invocation of StopDICOS

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL StopDTIO();

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL SetUnitDTIO(WORD unit, int delta);  //unit: DTIO timing unit in micro-second (25~2500 us), delta: fine-tuning timing unit, each +/- is 0.04us

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern WORD GetUnitDTIO();  //Return current DTIO timing unit in micro-second

        // Deterministic Trigger Fan Out
        //
        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL SetupDTFO(ref DTFO_SETUP lpSetup, DWORD cbSetup);

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL StartDTFO();  //[NOTE] If DICOS is started, this will stop it by internal invocation of StopDICOS

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL StopDTFO();

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern BOOL SetUnitDTFO(WORD unit, int delta);  //unit: DTFO timing unit in micro-second (25~2500 us), delta: fine-tuning timing unit, each +/- is 0.04us

        [DllImport("WDT_DIO64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern WORD GetUnitDTFO();  //Return current DTFO timing unit in micro-second

    }
}
