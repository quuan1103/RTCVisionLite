using RTC_Vision_Lite.PublicFunctions;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    internal static class cKeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_KEYUP = 0x0101;

        //private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public static List<int> keys = new List<int>();
        private static string logName = "Log_";
        private static string logExtendtion = ".txt";
        private static bool isHooking = false;
        //private static LowLevelKeyboardProc _proc = HookCallback;


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// Delegate a LowLevelKeyboardProc to use user32.dll
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private delegate IntPtr LowLevelKeyboardProc(
        int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Set hook into all current process
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }
        internal static void HookKeyboard_Start()
        {
            if (isHooking)
                return;
            //_hookID = SetHook(_proc);
            keys = new List<int>();
            isHooking = true;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        /// <summary>
        /// Every time the OS call back pressed key. Catch them 
        /// then cal the CallNextHookEx to wait for the next key
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        /// 
        //    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        //    {
        //        var activatedHandle = GetForegroundWindow();
        //        if (activatedHandle == IntPtr.Zero)
        //        {
        //            return CallNextHookEx(_hookID, nCode, wParam, lParam);       // No window is currently activated
        //        }

        //        var procId = Process.GetCurrentProcess().Id;
        //        int activeProcId;
        //        GetWindowThreadProcessId(activatedHandle, out activeProcId);
        //        if (activeProcId != procId)
        //            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        //        if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
        //        {

        //            int vkCode = Marshal.ReadInt32(lParam);
        //            if (!keys.Contains(vkCode))
        //                keys.Add(vkCode);

        //            //if (GlobVar.CurrentProject != null)
        //            //    foreach (var cam in GlobVar.CurrentProject.CAMs.Values)
        //            //        if (cam.IsActive && !cam.IsHide && cam.GroupActions.IsRun)
        //            //        {
        //            //            var listHookKeyboardTools = cam.GroupActions.Actions.Values.Where(x => x.ActionType == EActionTypes.HookKeyboard).ToList();
        //            //            if (listHookKeyboardTools.Any())
        //            //                foreach (var action in listHookKeyboardTools)
        //            //                    action.keys = GlobFuncs.DeepClone(keys);
        //            //        }
        //            //if (GlobVar.GroupActions != null && GlobVar.GroupActions.IsRun)
        //            //{
        //            //    var listHookKeyboardTools = GlobVar.GroupActions.Actions.Values.Where(x => x.ActionType == EActionTypes.HookKeyboard).ToList();
        //            //    if (listHookKeyboardTools.Any())
        //            //        foreach (var action in listHookKeyboardTools)
        //            //            action.keys = GlobFuncs.DeepClone(keys);
        //            //}
        //            //if (keys.Contains((int)Keys.LControlKey) && keys.Contains((int)Keys.C))
        //            //    MessageBox.Show("Ctrl + C");
        //        }
        //        else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
        //        {
        //            int vkCode = Marshal.ReadInt32(lParam);
        //            if (keys.Contains(vkCode))
        //                keys.Remove(vkCode);

        //            if (GlobVar.CurrentProject != null)
        //                foreach (var cam in GlobVar.CurrentProject.CAMs.Values)
        //                    if (cam.IsActive && !cam.IsHide && cam.GroupActions.IsRun)
        //                    {
        //                        var listHookKeyboardTools = cam.GroupActions.Actions.Values.Where(x => x.ActionType == EActionTypes.HookKeyboard).ToList();
        //                        //if (listHookKeyboardTools.Any())
        //                        //    foreach (var action in listHookKeyboardTools)
        //                        //        action.keys = GlobFuncs.DeepClone(keys);
        //                    }
        //        }
        //    }
        //}
    }
}
