using Basler.Pylon;
using BrightIdeasSoftware;
using CommonTools;
using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using LineFindTool;
using MS.WindowsAPICodePack.Internal;
using MVSDK_Net;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.Log;
using RTC_Vision_Lite.Properties;
using RTC_Vision_Lite.UserControls;
using RTCBase.Drawing;
using RTCBaslerSdk;
using RTCConst;
using RTCDahuaSdk;
using RTCEnums;
using RTCHikSdk;
using RTCSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.PublicFunctions
{
    internal static class GlobFuncs
    {
        #region SYSTEM

        public static DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }
        //public static int Object2Int(object @object, int @default = 0)
        //{
        //    if (@object == null)
        //        return @default;
        //    if (int.TryParse(@object.ToString(), out int result))
        //        return result;
        //    return @default;
        //}
        public static List<string> V2NewType(List<string> Value, string valueType)
        {
            List<string> newValue = new List<string>();
            for (int i = 0; i < Value.Count; i++)
                switch (valueType)
                {
                    case cSLMPValueTypes.BIT:
                        newValue.Add(Ve2Interger(Value[i]).ToString());
                        break;
                    case cSLMPValueTypes.BITRegister:
                        newValue.Add(Ve2Interger(Value[i]).ToString());
                        break;
                    case cSLMPValueTypes.Word:
                        newValue.Add(Ve2Interger(Value[i]).ToString());
                        break;
                    case cSLMPValueTypes.Dword:
                        newValue.Add(Ve2Interger(Value[i]).ToString());
                        break;
                    case cSLMPValueTypes.Real:
                        newValue.Add(Ve2Interger(Value[i]).ToString());
                        break;
                    case cSLMPValueTypes.String:
                        newValue.Add(Ve2Str(Value[i]).ToString());
                        break;
                    case cSLMPValueTypes.IntegerList:
                        {
                            string sValue = Ve2Str(Value[i]);
                            string[] sValues = sValue.Split(cChars.Comma);
                            foreach (string item in sValues)
                            {
                                newValue.Add(int.TryParse(item, out int iValue) ? iValue.ToString() : "0");
                            }
                            break;
                        }

                    case cSLMPValueTypes.Integer:
                        {
                            string sValue = Ve2Str(Value[i]);
                            newValue.Add(int.TryParse(sValue, out int iValue) ? iValue.ToString() : "0");
                            break;
                        }

                    case cSLMPValueTypes.Float:
                        {
                            string sValue = Ve2Str(Value[i]);
                            newValue.Add(float.TryParse(sValue, out float iValue) ? iValue.ToString() : "0");
                            break;
                        }

                    case cSLMPValueTypes.FloatList:
                        {
                            string sValue = Ve2Str(Value[i]);
                            string[] sValues = sValue.Split(cChars.Comma);
                            foreach (string item in sValues)
                            {
                                newValue.Add(float.TryParse(item, out float fValue) ? Math.Round(fValue, 3).ToString() : "0");
                            }
                            break;
                        }

                    case cSLMPValueTypes.Double:
                        {
                            string sValue = Ve2Str(Value[i]);
                            newValue.Add(double.TryParse(sValue, out double iValue) ? iValue.ToString() : "0");
                            break;
                        }
                    case cSLMPValueTypes.DoubleList:
                        {
                            string sValue = Ve2Str(Value[i]);
                            string[] sValues = sValue.Split(cChars.Comma);
                            foreach (string item in sValues)
                            {
                                newValue.Add(double.TryParse(item, out double fValue) ? Math.Round(fValue, 3).ToString() : "0");
                            }
                            break;
                        }
                    case cSLMPValueTypes.BooleanFC1:
                        {
                            string sValue = Ve2Str(Value[i]);
                            if (sValue.ToLower() == "true" || sValue == "1")
                                newValue.Add("true");
                            else
                                newValue.Add("false");
                            break;

                        }
                    case cSLMPValueTypes.BooleanFC2:
                        {
                            string sValue = Ve2Str(Value[i]);
                            if (sValue.ToLower() == "true" || sValue == "1")
                                newValue.Add("true");
                            else
                                newValue.Add("false");
                            break;

                        }
                    case cSLMPValueTypes.BooleanListFC1:
                        {
                            string sValue = Ve2Str(Value[i]);
                            if (sValue.ToLower() == "true" || sValue == "1")
                                newValue.Add("true");
                            else
                                newValue.Add("false");
                            break;

                        }
                    case cSLMPValueTypes.BooleanListFC2:
                        {
                            string sValue = Ve2Str(Value[i]);
                            if (sValue.ToLower() == "true" || sValue == "1")
                                newValue.Add("true");
                            else
                                newValue.Add("false");
                            break;

                        }
                }
            return newValue;
        }

        internal static string AlphabetPositionToString(int Value)
        {
            switch (Value)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                default:
                    return "A";
            }
        }

        public static bool ListsEqual(List<object> list1, List<object> list2)
        {
            if (list1 == null || list2 == null) return false;
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (!(list1[i].ToString() == list2[i].ToString()))
                {
                    return false;
                }
            }
            return true;
        }
        internal static Parity GetParity(string parity)
        {
            switch (parity)
            {
                case cParity.None:
                    return System.IO.Ports.Parity.None;
                case cParity.Even:
                    return System.IO.Ports.Parity.Even;
                case cParity.Mark:
                    return System.IO.Ports.Parity.Mark;
                case cParity.Odd:
                    return System.IO.Ports.Parity.Odd;
                case cParity.Space:
                    return System.IO.Ports.Parity.Space;
                default:
                    return System.IO.Ports.Parity.None;
            }
        }
        internal static StopBits GetStopBits(string stopBits)
        {

            switch (stopBits)
            {
                case cStopBits.None:
                    return System.IO.Ports.StopBits.None;
                case cStopBits.One:
                    return System.IO.Ports.StopBits.One;
                case cStopBits.Two:
                    return System.IO.Ports.StopBits.Two;
                case cStopBits.OnePointFive:
                    return System.IO.Ports.StopBits.OnePointFive;
                default:
                    return System.IO.Ports.StopBits.None;
            }
        }
        /// <summary>
        /// Chạy câu lệnh bằng cửa sổ lệnh
        /// </summary>
        /// <param name="command"></param>
        internal static void ExecuteCommand(string command)
        {
            try
            {
                int exitCode;
                ProcessStartInfo processInfo;
                Process process;

                processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                // *** Redirect the output ***
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;

                process = Process.Start(processInfo);
                process.WaitForExit();

                // *** Read the streams ***
                // Warning: This approach can lead to deadlocks, see Edit #2
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                exitCode = process.ExitCode;

                Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
                Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
                Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
                process.Close();
            }
            catch
            {

            }
        }

        internal static bool CheckContainsValue(List<string> parentValue, string value, bool matchCase = false)
        {
            if (parentValue == null || parentValue.Count <= 0)
                return false;
            if (parentValue.Contains(value))
                return true;
            else
                return false;
        }

        public static void SetToolTipToControl(Control control, string title, string content)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = title;
            toolTip.SetToolTip(control, content);
        }
        public static string GetVendorName(string interfaceName)
        {
            string result = string.Empty;
            if (interfaceName == "") return result;
            string[] sp = new string[] { " | " };
            string[] s = interfaceName.Split(sp, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in s)
            {
                if (item.StartsWith("vendor:"))
                {
                    result = item.Substring(7);
                    break;
                }
            }
            return result;
        }

        public static void HIK_SetBalanceRatioToNumberic(MyHikCamera hikCamera, NumericUpDown edit, string balanceRatioSelector = cBalanceRatioSelector.Red)
        {
            edit.Maximum = 0;
            edit.Minimum = 0;
            edit.Value = 0;

            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            MyHikCamera.MVCC_INTVALUE intValue = new MyHikCamera.MVCC_INTVALUE();
            int nRet = -1;
            switch (balanceRatioSelector)
            {
                case cBalanceRatioSelector.Red:
                    {
                        nRet = hikCamera.MV_CC_GetBalanceRatioRed_NET(ref intValue);
                        break;
                    }
                case cBalanceRatioSelector.Green:
                    {
                        nRet = hikCamera.MV_CC_GetBalanceRatioRed_NET(ref intValue);
                        break;
                    }
                case cBalanceRatioSelector.Blue:
                    {
                        nRet = hikCamera.MV_CC_GetBalanceRatioRed_NET(ref intValue);
                        break;
                    }
            }
            if (0 != nRet)
                return;
            edit.Maximum = intValue.nMax;
            edit.Minimum = intValue.nMin;
            edit.Value = intValue.nCurValue;

        }

        public static IEnumerable<Control> GetAllUserControl(Control control, Type type)

        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllUserControl(ctrl, type))
                .Concat(controls)
                .Where(c => c is UserControl && c.GetType() == type);
        }

        public static void HIK_SetPixelFormatToComboBox(MyHikCamera hikCamera, ComboBox edit)
        {
            MyHikCamera.MVCC_ENUMVALUE pixelFormat = new MyHikCamera.MVCC_ENUMVALUE();
            edit.Text = string.Empty;
            edit.Items.Clear();
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            int nRet = hikCamera.MV_CC_GetPixelFormat_NET(ref pixelFormat);
            if (0 != nRet)
                return;
            #region Set Default
            edit.Items.Add(cPixelFormatName.Mono8);
            edit.Items.Add(cPixelFormatName.Mono10);
            edit.Items.Add(cPixelFormatName.Mono10Packed);
            edit.Items.Add(cPixelFormatName.Mono12);
            edit.Items.Add(cPixelFormatName.Mono12Packed);
            edit.Items.Add(cPixelFormatName.Mono14);
            edit.Items.Add(cPixelFormatName.Mono16);

            edit.Items.Add(cPixelFormatName.RGB8);
            edit.Items.Add(cPixelFormatName.BGR8);

            edit.Items.Add(cPixelFormatName.YUV422YUYVPacked);
            edit.Items.Add(cPixelFormatName.YUV422Packed);
            edit.Items.Add(cPixelFormatName.YUV8UYV);
            edit.Items.Add(cPixelFormatName.YUV4118UYYVYY);

            edit.Items.Add(cPixelFormatName.BayerGR8);
            edit.Items.Add(cPixelFormatName.BayerRG8);
            edit.Items.Add(cPixelFormatName.BayerRG8);
            edit.Items.Add(cPixelFormatName.BayerBG8);

            edit.Items.Add(cPixelFormatName.BayerGR10);
            edit.Items.Add(cPixelFormatName.BayerRG10);
            edit.Items.Add(cPixelFormatName.BayerRG10);
            edit.Items.Add(cPixelFormatName.BayerBG10);

            edit.Items.Add(cPixelFormatName.BayerGR10Packed);
            edit.Items.Add(cPixelFormatName.BayerRG10Packed);
            edit.Items.Add(cPixelFormatName.BayerRG10Packed);
            edit.Items.Add(cPixelFormatName.BayerBG10Packed);

            edit.Items.Add(cPixelFormatName.BayerGR12);
            edit.Items.Add(cPixelFormatName.BayerRG12);
            edit.Items.Add(cPixelFormatName.BayerRG12);
            edit.Items.Add(cPixelFormatName.BayerBG12);

            edit.Items.Add(cPixelFormatName.BayerGR12Packed);
            edit.Items.Add(cPixelFormatName.BayerRG12Packed);
            edit.Items.Add(cPixelFormatName.BayerRG12Packed);
            edit.Items.Add(cPixelFormatName.BayerBG12Packed);

            edit.Items.Add(cPixelFormatName.BayerGR16);
            edit.Items.Add(cPixelFormatName.BayerRG16);
            edit.Items.Add(cPixelFormatName.BayerRG16);
            edit.Items.Add(cPixelFormatName.BayerBG16);
            edit.Enabled = false;

            #endregion
            switch (pixelFormat.nCurValue)
            {
                case cPixelFormat.Mono8:
                    {
                        edit.SelectedIndex = 0;
                        break;
                    }
                case cPixelFormat.Mono10:
                    {
                        edit.SelectedIndex = 2;
                        break;
                    }
                case cPixelFormat.Mono10Packed:
                    {
                        edit.SelectedIndex = 3;
                        break;
                    }
                case cPixelFormat.Mono12:
                    {
                        edit.SelectedIndex = 4;
                        break;

                    }
                case cPixelFormat.Mono12Packed:
                    {
                        edit.SelectedIndex = 5;
                        break;
                    }
                case cPixelFormat.Mono14:
                    {
                        edit.SelectedIndex = 6;
                        break;
                    }
                case cPixelFormat.Mono16:
                    {
                        edit.SelectedIndex = 7;
                        break;
                    }
                case cPixelFormat.RGB8:
                    {
                        edit.SelectedIndex = 8;
                        break;
                    }
                case cPixelFormat.BGR8:
                    {
                        edit.SelectedIndex = 9;
                        break;
                    }

                case cPixelFormat.YUV422YUYVPacked:
                    {
                        edit.SelectedIndex = 10;
                        break;
                    }
                case cPixelFormat.YUV422Packed:
                    {
                        edit.SelectedIndex = 11;
                        break;
                    }
                case cPixelFormat.YUV8UYV:
                    {
                        edit.SelectedIndex = 12;
                        break;
                    }
                case cPixelFormat.YUV4118UYYVYY:
                    {
                        edit.SelectedIndex = 13;
                        break;
                    }
                case cPixelFormat.BayerGR8:
                    {
                        edit.SelectedIndex = 14;
                        break;
                    }
                case cPixelFormat.BayerRG8:
                    {
                        edit.SelectedIndex = 15;
                        break;
                    }
                case cPixelFormat.BayerGB8:
                    {
                        edit.SelectedIndex = 16;
                        break;
                    }
                case cPixelFormat.BayerBG8:
                    {
                        edit.SelectedIndex = 17;
                        break;
                    }
                case cPixelFormat.BayerGR10:
                    {
                        edit.SelectedIndex = 18;
                        break;
                    }
                case cPixelFormat.BayerRG10:
                    {
                        edit.SelectedIndex = 19;
                        break;
                    }
                case cPixelFormat.BayerGB10:
                    {
                        edit.SelectedIndex = 20;
                        break;
                    }
                case cPixelFormat.BayerBG10:
                    {
                        edit.SelectedIndex = 21;
                        break;
                    }
                case cPixelFormat.BayerGR10Packed:
                    {
                        edit.SelectedIndex = 22;
                        break;
                    }
                case cPixelFormat.BayerRG10Packed:
                    {
                        edit.SelectedIndex = 23;
                        break;
                    }
                case cPixelFormat.BayerGB10Packed:
                    {
                        edit.SelectedIndex = 24;
                        break;
                    }
                case cPixelFormat.BayerBG10Packed:
                    {
                        edit.SelectedIndex = 25;
                        break;
                    }
                case cPixelFormat.BayerGR12:
                    {
                        edit.SelectedIndex = 26;
                        break;
                    }
                case cPixelFormat.BayerRG12:
                    {
                        edit.SelectedIndex = 27;
                        break;
                    }
                case cPixelFormat.BayerGB12:
                    {
                        edit.SelectedIndex = 28;
                        break;
                    }
                case cPixelFormat.BayerBG12:
                    {
                        edit.SelectedIndex = 29;
                        break;
                    }
                case cPixelFormat.BayerGR12Packed:
                    {
                        edit.SelectedIndex = 30;
                        break;
                    }
                case cPixelFormat.BayerRG12Packed:
                    {
                        edit.SelectedIndex = 31;
                        break;
                    }
                case cPixelFormat.BayerGB12Packed:
                    {
                        edit.SelectedIndex = 32;
                        break;
                    }
                case cPixelFormat.BayerBG12Packed:
                    {
                        edit.SelectedIndex = 33;
                        break;
                    }
                case cPixelFormat.BayerGR16:
                    {
                        edit.SelectedIndex = 34;
                        break;
                    }
                case cPixelFormat.BayerRG16:
                    {
                        edit.SelectedIndex = 35;
                        break;
                    }
                case cPixelFormat.BayerGB16:
                    {
                        edit.SelectedIndex = 36;
                        break;
                    }
                case cPixelFormat.BayerBG16:
                    {
                        edit.SelectedIndex = 37;
                        break;
                    }
            }

        }



        public static string BuildRefString_DataItem(cGroupActions GroupActions, cAction Action, SStringBuilderItem dataItem)
        {
            if (Action == null) return string.Empty;
            if (Action.ObjectType == EObjectTypes.Group)
            {
                return string.Join(".",
                    "[" + Action.Name.rtcValue + (dataItem == null ? "" : ":" + dataItem.Name) + "]");
            }
            else
            {
                return string.Join(".",
                    "[" + GroupActions.Name.rtcValue, Action.Name.rtcValue + (dataItem == null ? "" : ":" + dataItem.Name) + "]");
            }
        }

        public static string BuildRefString_Property(cGroupActions GroupActions, cAction Action, PropertyInfo PropertyInfo)
        {
            if (Action == null) return String.Empty;
            if (Action.ObjectType == EObjectTypes.Group)
            {
                return string.Join(".",
                    "[" + Action.Name.rtcValue + (PropertyInfo == null ? "" : ":" + PropertyInfo.Name) + "]");
            }
            else
            {
                return string.Join(".", "[" + GroupActions.Name.rtcValue,
                    Action.Name.rtcValue + (PropertyInfo == null ? "" : ":" + PropertyInfo.Name) + "]");
            }
        }

        public static void SetTextEditValueByHtuple(TextBox _Textbox, double _Value)
        {
            _Textbox.Text = _Value.ToString();
        }

        public static List<double> Ve2Double(object ValueElement, bool isConsideringTheValue01 = false)
        {
            double result = 0;
            List<double> dValues = new List<double>();
            try
            {
                var Test = ValueElement.GetType();
                if (Test == typeof(List<string>))
                {
                    List<string> sValues = (List<string>)ValueElement;
                    foreach (string value in sValues)
                    {
                        if (double.TryParse(value, out double dvalue))
                        {
                            dValues.Add(dvalue);
                        }
                        else
                        {
                            dValues.Add(0);
                        }
                    }
                }
                else if (Test == typeof(List<double>))
                {
                    dValues = (List<double>)ValueElement;
                }
                else if (Test == typeof(double))
                {
                    dValues.Add((double)ValueElement);

                }

            }
            catch (Exception ex)
            {
                return new List<double>();
            }
            return dValues;


        }
        public static double Va2ListDouble(object ValueElement, bool isConsideringTheValue01 = false)
        {
            double result = 0;
            try
            {
                switch (ValueElement)
                {

                    case int intValue:

                        result = intValue;
                        break;

                    case long longValue:

                        result = longValue;
                        break;
                    case double doubleValue:

                        result = doubleValue;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;


        }
        public static int Ve2Interger(object ValueElement, bool isConsideringTheValue01 = false)
        {
            int result = 0;
            try
            {
                switch (ValueElement)
                {

                    case int intValue:

                        result = intValue;
                        break;

                    case long longValue:

                        result = (int)longValue;
                        break;
                    case double doubleValue:

                        result = (int)doubleValue;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }

        public static bool Ve2Bool(object ValueElement, bool isConsideringTheValue01 = false)
        {
            bool result = false;
            try
            {
                switch (ValueElement)
                {
                    case bool boolValue:
                        result = boolValue;
                        break;

                    case int intValue:
                        if (isConsideringTheValue01)
                            result = intValue == 1 ? true : false;
                        break;

                    case long longValue:
                        if (isConsideringTheValue01)
                            result = longValue == 1 ? true : false;
                        break;
                    case double doubleValue:
                        if (isConsideringTheValue01)
                            result = doubleValue == 1 ? true : false;
                        break;
                    case string stringValue:
                        if (!bool.TryParse(stringValue, out result))
                            result = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        internal static Font StrngtoFont(string fontInfo)
        {
            if (string.IsNullOrEmpty(fontInfo))
                return GlobVar.DefaultFont;
            string[] fontInfos = fontInfo.Split(',');
            if (fontInfo.Length < 3)
                return GlobVar.DefaultFont;
            fontInfos = fontInfo.Split(',');
            string fontName = fontInfos[0];
            if (!float.TryParse(fontInfos[fontInfos.Length - 1], out float fontSize))
                fontSize = 10;
            FontStyle fontStyle = FontStyle.Regular;
            for (int i = 1; i <= fontInfos.Length - 2; i++)
            {
                string style = fontInfos[i].Trim();
                switch (style)
                {
                    case "Bold":
                        {
                            fontStyle = fontStyle | FontStyle.Bold;
                            break;
                        }
                    case "Italic":
                        {
                            fontStyle = fontStyle | FontStyle.Italic;
                            break;
                        }
                    case "Strikeout":
                        {
                            fontStyle = fontStyle | FontStyle.Strikeout;
                            break;
                        }

                    case "Underline":
                        {
                            fontStyle = fontStyle | FontStyle.Underline;
                            break;
                        }
                    default:
                        break;
                }
            }
            return new Font(new FontFamily(fontName), fontSize, fontStyle);
        }

        public static string GetFileName(string filter,
            string directory = "",
            string caption = cStrings.ChooseImageFile)
        {
            string fileName = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.Title = caption;
            if (!string.IsNullOrEmpty(directory))
                openFileDialog.InitialDirectory = directory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                fileName = openFileDialog.FileName;
            return fileName;
        }

        public static int HTEToI(List<double> ValueElement)
        {
            return (int)HTEToD(ValueElement);
        }

        private static int HTEToD(List<double> valueElement)
        {
            return 1;
        }

        public static void ValidateTextDoubleValue(TextBox txt, double MaxValue = 0, double MinValue = 0,
            bool CheckMaxValue = false, bool CheckMinValue = false, bool AcceptInfinity = false)
        {
            double dvalue = 0;
            if ((txt.Text.ToLower() == "infinity" || txt.Text.ToLower() == "inf") && AcceptInfinity)
            {
                  txt.Text = "Inf";
            }
            else if (double.TryParse(txt.Text, out dvalue))
            {
                if (CheckMinValue && dvalue < MinValue)
                {
                    txt.Text = MinValue.ToString();
                }
                if (CheckMinValue && dvalue > MaxValue)
                {
                    txt.Text = MaxValue.ToString();
                }
            }
        }

        public static string ListDouble2Str(List<double> ldouble, int elementnumber = -1)
        {
            if (ldouble == null || ldouble.Count <= 0)
                return string.Empty;
            string result = string.Empty;
            int _elementnumber = elementnumber == -1 ? ldouble.Count : elementnumber;
            for (int i = 0; i < _elementnumber; i++)
            {
                if (result == string.Empty)
                    result = ldouble[i].ToString();
                else
                    result = result + "," + ldouble[i].ToString();
            }
            return result;
        }
        public static string ListInt2Str(List<int> lInt, int elementnumber = -1)
        {
            if (lInt == null || lInt.Count <= 0)
                return string.Empty;
            string result = string.Empty;
            int _elementnumber = elementnumber == -1 ? lInt.Count : elementnumber;
            for (int i = 0; i < _elementnumber; i++)
            {
                if (result == string.Empty)
                    result = lInt[i].ToString();
                else
                    result = result + "," + lInt[i].ToString();
            }
            return result;
        }
        public static bool GetBoolValueFromObject(object srcObject)
        {
            if (srcObject == null)
                return false;
            string value = srcObject.ToString();
            if (srcObject.GetType() == typeof(List<String>))
                value = srcObject.ToString();
            else if (srcObject.GetType() == typeof(List<double>))
                value = srcObject.ToString();
            if (bool.TryParse(value, out bool bResult))
                return bResult;
            if (int.TryParse(value, out int iResult))
                return iResult != 0;
            return false;
        }

        public static object GetPropDefaultValueByBaseType(string SuffixActionName, string PropName, Type PropType)
        {
            object obj = null;

            switch (PropType.Name)
            {
                case nameof(SString):
                    obj = CommonData.GetDefaultValues_Text(PropName + SuffixActionName);
                    break;
                case nameof(SInt):
                    obj = CommonData.GetDefaultValues_Int(PropName + SuffixActionName);
                    break;
                case nameof(SDouble):
                    obj = CommonData.GetDefaultValues_Double(PropName + SuffixActionName);
                    break;
                case nameof(SBool):
                    obj = CommonData.GetDefaultValues_Bool(PropName + SuffixActionName);
                    break;
                case nameof(Guid):
                    obj = Guid.Parse(CommonData.GetDefaultValues_Text(PropName + SuffixActionName));
                    break;
                case nameof(SListDouble):
                    obj = CommonData.GetDefaultValues_ListDouble(PropName + SuffixActionName);
                    break;
                case nameof(SListString):
                    obj = CommonData.GetDefaultValues_ListString(PropName + SuffixActionName);
                    break;
                case nameof(SListObject):
                    obj = CommonData.GetDefaultValues_ListObject(PropName + SuffixActionName);
                    break;
                case nameof(SImage):
                    {
                        break;
                    }

                default:
                    break;
            }

            return obj;

        }
        public static IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl, type)
            .Concat(controls)
            .Where(c => c.GetType() == type));
        }
        public static IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            var enumerable = controls as Control[] ?? controls.ToArray();
            return enumerable.SelectMany(ctrl => GetAllControls(ctrl)
                .Concat(enumerable));
        }
        public static IEnumerable<Control> GetAllUserControlWithBaseType(Control control, Type basetype)
        {

            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllUserControlWithBaseType(ctrl, basetype))
                .Concat(controls)
                .Where(c => c is UserControl && c.GetType().BaseType == basetype);
        }
        public static string Ve2Str(object valueElement, bool trueFalseTo01 = false, bool noneZeroTo1 = false, int decimalPlaces = 6)
        {
            string result = string.Empty;

            if (valueElement != null)
            {
                // Kiểm tra xem valueElement có phải là danh sách không
                if (valueElement is System.Collections.IEnumerable && !(valueElement is string))
                {
                    // Nếu là danh sách, chuyển đổi từng phần tử và ghép kết quả
                    var listElements = (System.Collections.IEnumerable)valueElement;
                    List<string> convertedElements = new List<string>();

                    foreach (var element in listElements)
                    {
                        convertedElements.Add(Ve2Str(element, trueFalseTo01, noneZeroTo1, decimalPlaces));
                    }
                    //if (convertedElements.Count > 0)
                    result = string.Join(",", convertedElements);
                    //else
                    //    result = string.Join(",", Lib.ToString(valueElement));
                }
                else
                {
                    // Xử lý các kiểu dữ liệu khác nhau như trước
                    switch (valueElement)
                    {
                        case int intValue:
                            result = intValue.ToString();
                            break;
                        case double doubleValue:
                            result = Math.Round(doubleValue, decimalPlaces).ToString();
                            break;
                        case string stringValue:
                            result = stringValue;
                            break;
                        case long longValue:
                            result = longValue.ToString();
                            break;
                        case bool boolValue:
                            result = trueFalseTo01 ? (boolValue ? "1" : "0") : boolValue.ToString();
                            break;
                        default:
                            result = valueElement.ToString();
                            break;
                    }

                    if (noneZeroTo1 && result == "0")
                    {
                        result = "1";
                    }
                }
            }

            return result;
        }

        public static List<double> GetValueDoubleByIndex(List<double> value, string index)
        {
            List<double> newValue = new List<double>();
            if (string.IsNullOrEmpty(index) || index == cStrings.None)
                return value;
            if (value == null)
                return null;
            if (int.TryParse(index, out int indexSrc))
            {
                if (indexSrc < value.Count)
                    newValue.Add(value[indexSrc]);
            }
            else if (index.Contains(cChars.Comma))
            {
                string[] rangeValue = index.Split(cChars.Comma);
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                    {
                        if (indexSrc < value.Count)
                            newValue.Add(value[indexSrc]);
                    }
                    else if (rangeValue[i].Contains(cChars.Minus))
                    {
                        List<double> newValue1 = GetValueDoubleByIndex(value, rangeValue[i]);
                        if (newValue1 != null && newValue1.Count > 0)
                            for (i = 0; i < newValue1.Count; i++)
                                newValue.Add(newValue1[i]);
                    }
            }
            else if (index.Contains(cChars.Minus))
            {
                string[] rangeValue = index.Split(cChars.Minus);
                List<int> irangeValue = new List<int>();
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                        irangeValue.Add(indexSrc);
                for (int i = 0; i < irangeValue.Count - 1; i++)
                {
                    int iMin = irangeValue[i];
                    int iMax = irangeValue[i + 1];
                    for (int j = iMin; j <= iMax; j++)
                        if (j < value.Count)
                            newValue.Add(value[j]);
                }
            }
            else
                return value;
            return newValue;

        }
        public static List<object> GetValueObjectByIndex(List<object> value, string index)
        {
            List<object> newValue = new List<object>();
            if (string.IsNullOrEmpty(index) || index == cStrings.None)
                return value;
            if (value == null)
                return null;
            if (int.TryParse(index, out int indexSrc))
            {
                if (indexSrc < value.Count)
                    newValue.Add(value[indexSrc]);
            }
            else if (index.Contains(cChars.Comma))
            {
                string[] rangeValue = index.Split(cChars.Comma);
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                    {
                        if (indexSrc < value.Count)
                            newValue.Add(value[indexSrc]);
                    }
                    else if (rangeValue[i].Contains(cChars.Minus))
                    {
                        List<object> newValue1 = GetValueObjectByIndex(value, rangeValue[i]);
                        if (newValue1 != null && newValue1.Count > 0)
                            for (i = 0; i < newValue1.Count; i++)
                                newValue.Add(newValue1[i]);
                    }
            }
            else if (index.Contains(cChars.Minus))
            {
                string[] rangeValue = index.Split(cChars.Minus);
                List<int> irangeValue = new List<int>();
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                        irangeValue.Add(indexSrc);
                for (int i = 0; i < irangeValue.Count - 1; i++)
                {
                    int iMin = irangeValue[i];
                    int iMax = irangeValue[i + 1];
                    for (int j = iMin; j <= iMax; j++)
                        if (j < value.Count)
                            newValue.Add(value[j]);
                }
            }
            else
                return value;
            return newValue;

        }

        internal static Image CopyImage(Image outputImage)
        {
            Image outImage = null;
            if (outputImage != null)
            {
                return (Image)outputImage.Clone();

            }
            else
                return outImage;
        }

        //internal static Image CopyImage(Image hImage)
        //{
        //    if (hImage != null)
        //        return  Image.(hImage.Clone());
        //    else
        //}

        public static List<string> GetValueStringByIndex(List<string> value, string index)
        {
            List<string> newValue = new List<string>();
            if (string.IsNullOrEmpty(index) || index == cStrings.None)
                return value;
            if (value == null)
                return null;
            if (int.TryParse(index, out int indexSrc))
            {
                if (indexSrc < value.Count)
                    newValue.Add(value[indexSrc]);
            }
            else if (index.Contains(cChars.Comma))
            {
                string[] rangeValue = index.Split(cChars.Comma);
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                    {
                        if (indexSrc < value.Count)
                            newValue.Add(value[indexSrc]);
                    }
                    else if (rangeValue[i].Contains(cChars.Minus))
                    {
                        List<string> newValue1 = GetValueStringByIndex(value, rangeValue[i]);
                        if (newValue1 != null && newValue1.Count > 0)
                            for (i = 0; i < newValue1.Count; i++)
                                newValue.Add(newValue1[i]);
                    }
            }
            else if (index.Contains(cChars.Minus))
            {
                string[] rangeValue = index.Split(cChars.Minus);
                List<int> irangeValue = new List<int>();
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                        irangeValue.Add(indexSrc);
                for (int i = 0; i < irangeValue.Count - 1; i++)
                {
                    int iMin = irangeValue[i];
                    int iMax = irangeValue[i + 1];
                    for (int j = iMin; j <= iMax; j++)
                        if (j < value.Count)
                            newValue.Add(value[j]);
                }
            }
            else
                return value;
            return newValue;

        }
        public static List<Emgu.CV.Util.VectorOfVectorOfPoint> GetValueListVectorByIndex(List<Emgu.CV.Util.VectorOfVectorOfPoint> value, string index)
        {
            List<Emgu.CV.Util.VectorOfVectorOfPoint> newValue = new List<Emgu.CV.Util.VectorOfVectorOfPoint>();
            if (string.IsNullOrEmpty(index) || index == cStrings.None)
                return value;
            if (value == null)
                return null;
            if (int.TryParse(index, out int indexSrc))
            {
                if (indexSrc < value.Count)
                    newValue.Add(value[indexSrc]);
            }
            else if (index.Contains(cChars.Comma))
            {
                string[] rangeValue = index.Split(cChars.Comma);
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                    {
                        if (indexSrc < value.Count)
                            newValue.Add(value[indexSrc]);
                    }
                    else if (rangeValue[i].Contains(cChars.Minus))
                    {
                        List<Emgu.CV.Util.VectorOfVectorOfPoint> newValue1 = GetValueListVectorByIndex(value, rangeValue[i]);
                        if (newValue1 != null && newValue1.Count > 0)
                            for (i = 0; i < newValue1.Count; i++)
                                newValue.Add(newValue1[i]);
                    }
            }
            else if (index.Contains(cChars.Minus))
            {
                string[] rangeValue = index.Split(cChars.Minus);
                List<int> irangeValue = new List<int>();
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                        irangeValue.Add(indexSrc);
                for (int i = 0; i < irangeValue.Count - 1; i++)
                {
                    int iMin = irangeValue[i];
                    int iMax = irangeValue[i + 1];
                    for (int j = iMin; j <= iMax; j++)
                        if (j < value.Count)
                            newValue.Add(value[j]);
                }
            }
            else
                return value;
            return newValue;

        }
        public static List<string> ListDoubleToListString(List<double> Value)
        {
            List<string> newList = new List<string>();
            if (Value.Count > 0)
            {
                foreach (double db in Value)
                    newList.Add(db.ToString());
            }
            return newList;

        }
        public static List<object> ListDoubleToListObject(List<double> Value)
        {
            List<object> newList = new List<object>();
            if (Value.Count > 0)
            {
                foreach (double db in Value)
                    newList.Add(db);
            }
            return newList;

        }
        public static List<double> TupleOriginToOrigin(List<Tuple<PointF, double>> Values)
        {
            List<double> Result = new List<double>();
            foreach (Tuple<PointF, double> value in Values)
            {
                Result.Add(value.Item1.X);
                Result.Add(value.Item1.Y);
                Result.Add(value.Item2);
            }
            return Result;
        }
        public static List<string> ListObjectToListString(List<object> Value)
        {
            List<string> newList = new List<string>();
            if (Value.Count > 0)
            {
                foreach (double db in Value)
                    newList.Add(db.ToString());
            }
            return newList;

        }
        //public static object GetValueByIndex(object value, string index)
        //{
        //    object newValue = new object()
        //    if (string.IsNullOrEmpty(index) || index == cStrings.None)
        //        return value;
        //    if (value == null)
        //        return null;
        //    if (int.TryParse(index, out int indexSrc))
        //    {
        //        if (indexSrc < value.Count)
        //            newValue.Add(value[indexSrc]);
        //    }
        //    else if (index.Contains(cChars.Comma))
        //    {
        //        string[] rangeValue = index.Split(cChars.Comma);
        //        for (int i = 0; i < rangeValue.Length; i++)
        //            if (int.TryParse(rangeValue[i], out indexSrc))
        //            {
        //                if (indexSrc < value.Count)
        //                    newValue.Add(value[indexSrc]);
        //            }
        //            else if (rangeValue[i].Contains(cChars.Minus))
        //            {
        //                List<string> newValue1 = GetValueStringByIndex(value, rangeValue[i]);
        //                if (newValue1 != null && newValue1.Count > 0)
        //                    for (i = 0; i < newValue1.Count; i++)
        //                        newValue.Add(newValue1[i]);
        //            }
        //    }
        //    else if (index.Contains(cChars.Minus))
        //    {
        //        string[] rangeValue = index.Split(cChars.Minus);
        //        List<int> irangeValue = new List<int>();
        //        for (int i = 0; i < rangeValue.Length; i++)
        //            if (int.TryParse(rangeValue[i], out indexSrc))
        //                irangeValue.Add(indexSrc);
        //        for (int i = 0; i < irangeValue.Count - 1; i++)
        //        {
        //            int iMin = irangeValue[i];
        //            int iMax = irangeValue[i + 1];
        //            for (int j = iMin; j <= iMax; j++)
        //                if (j < value.Count)
        //                    newValue.Add(value[j]);
        //        }
        //    }
        //    else
        //        return value;
        //    return newValue;

        //}



        /// <summary>
        /// Chuẩn hoá dấu phân cách trong đường dẫn
        /// </summary>
        /// <param name="path">đường dẫn cần chuẩn hoá</param>
        /// <returns>Đường dẫn sau khi chuẩn hoá</returns>
        public static string FixedDirSepChar(string path)
        {
            if (path != "" && !path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                return path + Path.DirectorySeparatorChar;
            return path;
        }
        #region CONTROLS VALUES
        internal static string GetComboBoxText(ComboBox comboBox)
        {
            string text = string.Empty;
            if (comboBox.InvokeRequired)
                comboBox.Invoke(new Action(() => text = comboBox.Text));
            else
                text = comboBox.Text;
            return text;
        }
        internal static void AddComboBoxValue(ComboBox comboBox, string value)
        {

            if (comboBox.InvokeRequired)
                comboBox.Invoke(new Action(() =>
                {
                    comboBox.Items.Add(value);
                }));
            else
                comboBox.Items.Add(value);

        }
        internal static void ClearComboBox(ComboBox comboBox)
        {

            if (comboBox.InvokeRequired)
                comboBox.Invoke(new MethodInvoker(() =>
                {
                    comboBox.Items.Clear();
                }));
            else
                comboBox.Items.Clear();

        }
        internal static void SetComboBoxText(ComboBox comboBox, string value)
        {

            if (comboBox.InvokeRequired)
                comboBox.Invoke(new Action(() =>
                {
                    comboBox.Text = value;
                }));
            else
                comboBox.Text = value;

        }
        internal static void SetComboBoxValue(ComboBox comboBox, string value)
        {

            if (comboBox.InvokeRequired)
                comboBox.Invoke(new Action(() =>
                {
                    comboBox.Text = value;
                }));
            else
                comboBox.Text = value;
        }
        internal static void SetLableText(Label label, string text, bool isRefresh = false)
        {

            if (label.InvokeRequired)
                label.Invoke(new Action(() =>
                {
                    label.Text = text;
                    if (isRefresh)
                        label.Refresh();
                }));
            else
            {
                label.Text = text;
                if (isRefresh)
                    label.Refresh();
            }

        }
        public static void SetTextBoxValueByStyle(TextBox textBox, object _Value)
        {

            switch (_Value)
            {
                case int intValue:
                    {

                        textBox.Text = intValue.ToString();
                        break;
                    }
                case double doubleValue:
                    {
                        textBox.Text = doubleValue.ToString();
                        break;
                    }
                case string StringValue:
                    {
                        textBox.Text = StringValue;
                        break;
                    }
                case long longValue:
                    {
                        textBox.Text = longValue.ToString();
                        break;
                    }
                case bool boolValue:
                    {
                        textBox.Text = boolValue.ToString();
                        break;
                    }
                default:
                    break;

            }
        }
        internal static void SetCheckBoxValue(CheckBox checkBox, bool value)
        {
            if (checkBox.InvokeRequired)
                checkBox.Invoke(new Action(() => checkBox.Checked = value));
            else
                checkBox.Checked = value;
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string CreateSaveFolderWithDay(string _Path)
        {
            if (_Path == "") return _Path;
            return FixedDirSepChar(FixedDirSepChar(_Path) + DateTime.Now.Date.ToString("ddMMyyyy"));

        }

        public static MyHikCamera.MV_GENTL_IF_INFO GetHikrobotGenICamTLInterfaceInfo(string interfaceName)
        {
            string ctiFileName = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
                                "MvFGProducerCML.cti");
                            break;
                        }
                    case 1:
                        {
                            ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
                                "MvFGProducerCXP.cti");
                            break;
                        }
                    case 2:
                        {
                            ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
                                "MvFGProducerGEV.cti");
                            break;
                        }
                    case 3:
                        {
                            ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
                                "MvProducerGEV.cti");
                            break;
                        }
                    case 4:
                        {
                            ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
                                "MvProducerU3V.cti");
                            break;
                        }
                    case 5:
                        {
                            ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
                                "MvProducerVIR.cti");
                            break;
                        }
                }
                if (!File.Exists(ctiFileName))
                    continue;
                MyHikCamera.MV_GENTL_IF_INFO_LIST m_stIFInfoList = GetHikrobotGenICamTLInterfaceInfoList(ctiFileName);
                if (m_stIFInfoList.nInterfaceNum != 0)
                    for (UInt32 j = 0; j < m_stIFInfoList.nInterfaceNum; j++)
                    {
                        MyHikCamera.MV_GENTL_IF_INFO stIFInfo = (MyHikCamera.MV_GENTL_IF_INFO)Marshal.PtrToStructure(
                            m_stIFInfoList.pIFInfo[j], typeof(MyHikCamera.MV_GENTL_IF_INFO));
                        if (stIFInfo.chTLType + " " + stIFInfo.chInterfaceID + " " + stIFInfo.chDisplayName ==
                        interfaceName)
                            return stIFInfo;

                    }
            }
            return new MyHikCamera.MV_GENTL_IF_INFO();
        }



        public static void HIK_SetExposureModeToComboBox(MyHikCamera hikCamera, ComboBox edit)
        {
            edit.Text = string.Empty;
            edit.Items.Clear();
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            MyHikCamera.MVCC_ENUMVALUE enumValue = new MyHikCamera.MVCC_ENUMVALUE();
            if (!HIK_GetEnumValue(hikCamera, cParamName.ExposureMode, ref enumValue))
                return;
            edit.Items.Add(cExposureMode.Timed);
            edit.Items.Add(cExposureMode.TriggerWidth);
            switch (enumValue.nCurValue)
            {
                case (uint)MyHikCamera.MV_CAM_EXPOSURE_MODE.MV_EXPOSURE_MODE_TIMED:
                    {
                        edit.Text = cExposureMode.Timed;
                        break;
                    }
                case (uint)MyHikCamera.MV_CAM_EXPOSURE_MODE.MV_EXPOSURE_MODE_TRIGGER_WIDTH:
                    {
                        edit.Text = cExposureMode.TriggerWidth;
                        break;
                    }
            }

        }
        public static void HIK_SetAcquisitionModeToComBoBox(MyHikCamera hikCamera, ComboBox edit)
        {
            edit.Text = string.Empty;
            edit.Items.Clear();
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            MyHikCamera.MVCC_ENUMVALUE enumValue = new MyHikCamera.MVCC_ENUMVALUE();
            if (!HIK_GetEnumValue(hikCamera, cParamName.AcquisitionMode, ref enumValue))
                return;
            edit.Items.Add(cAcquisitionMode.SingleFrame);
            edit.Items.Add(cAcquisitionMode.MultiFrame);
            edit.Items.Add(cAcquisitionMode.Continuous);
            switch (enumValue.nCurValue)
            {
                case (uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_SINGLE:
                    {
                        edit.SelectedIndex = 0;
                        break;
                    }
                case (uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_MUTLI:
                    {
                        edit.SelectedIndex = 1;
                        break;
                    }
                case (uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS:
                    {
                        edit.SelectedIndex = 2;
                        break;
                    }
            }

        }
        //public static List<double> GetValueFromSRegionByIndex(List<double> SourceObject, string index)
        //{
        //     List<double> Object = null;
        //    if (string.IsNullOrEmpty(index))
        //        return SourceObject;
        //    if (SourceObject == null)
        //        return null;
        //    int Count = GetCountObject(SourceObject);
        //    if (int.TryParse(index, out int indexSrc))
        //    {
        //        if (indexSrc < Count && indexSrc >= 0)
        //        {
        //            Object = SourceObject[indexSrc + 1];
        //        }    
        //    }    
        //}

        private static int GetCountObject(List<double> Value)
        {
            if (Value == null)
                return 0;
            return Value.Count;
        }

        public static List<Image> GetValueFromSImageByIndex(List<Image> hSourceImage, string index)
        {
            List<Image> hImage = new List<Image>();
            if (string.IsNullOrEmpty(index))
                return hSourceImage;
            if (hSourceImage == null)
                return null;
            int count = hSourceImage.Count;
            if (int.TryParse(index, out int indexSrc))
            {
                if (indexSrc < count && indexSrc >= 0)
                {
                    hImage = new List<Image>() { hSourceImage[indexSrc + 1] };
                }
            }
            else if (index.Contains(cChars.Comma))
            {
                string[] rangeValue = index.Split(cChars.Comma);
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                    {
                        if (indexSrc < count && indexSrc >= 0)
                            hImage = new List<Image>() { hSourceImage[indexSrc + 1] };
                    }
                    else if (rangeValue[i].Contains(cChars.Minus))
                    {
                        List<Image> hImage1 = GetValueFromSImageByIndex(hSourceImage, rangeValue[i]);
                        if (hImage.Count > 0)
                            hImage.AddRange(hImage1);
                    }
            }
            else if (index.Contains(cChars.Minus))
            {
                string[] rangeValue = index.Split(cChars.Minus);
                List<int> irangeValue = new List<int>();
                for (int i = 0; i < rangeValue.Length; i++)
                    if (int.TryParse(rangeValue[i], out indexSrc))
                        irangeValue.Add(indexSrc);
                for (int i = 0; i < irangeValue.Count - 1; i++)
                {
                    int iMin = irangeValue[i];
                    int iMax = irangeValue[i + 1];
                    for (int j = iMin; j <= iMax; j++)
                        if (j < count && j >= 0)
                            hImage.Add(hSourceImage[j + 1]);
                }

            }
            else
                return hSourceImage;
            return hImage;

        }


        //}
        #region BASLER FUNCTION
        public static bool Basler_IsTriggerOn(MyBaslerCamera baslerCamera)
        {
            if (baslerCamera == null || !baslerCamera.IsConnected)
                return false;
            IEnumParameter enumParameter = baslerCamera.Parameters[new EnumName(cParamName.TriggerMode)];
            if (enumParameter != null)
                return enumParameter.GetValue() == Basler.Pylon.PLCamera.TriggerMode.On;
            else
                return false;
        }

        public static object CloneStringList(List<string> source)
        {
            if (source == null)
                return null;
            List<string> des = new List<string>();
            for (int i = 0; i < source.Count; i++)
                des.Add(source[i]);
            return des;

        }


        public static List<object> CloneValue(List<object> source)
        {
            if (source == null)
                return null;
            List<object> des = new List<object>();
            for (int i = 0; i < source.Count; i++)
                des.Add(source[i]);
            return des;

        }
        public static void Basler_SetValue(MyBaslerCamera baslerCamera,
            string paramName,
            object value,
            ref string errMessage)
        {
            try
            {
                errMessage = string.Empty;
                if (baslerCamera == null || !baslerCamera.IsConnected)
                {
                    errMessage = cMessageContent.War_CAMCannotConnect;
                    return;
                }
                IParameter parameter = baslerCamera.Parameters.FirstOrDefault(x => x.Name == paramName);
                if (parameter == null)
                {
                    if (paramName == cParamName.TriggerDelay)
                        paramName = cParamName.TriggerDelayAbs;
                    else if (paramName == cParamName.ExposureTime)
                        paramName = cParamName.ExposureTimeAbs;
                    else if (paramName == cParamName.Gain)
                        paramName = cParamName.GainRaw;
                    parameter = baslerCamera.Parameters.FirstOrDefault(x => x.Name == paramName);
                    if (parameter == null)
                        return;
                }

                if (!parameter.IsWritable)
                    return;
                string paramTypeName = parameter.GetType().Name;
                switch (paramTypeName)
                {
                    case "GenApiFloatParameter":
                        {
                            IFloatParameter floatParameter = baslerCamera.Parameters[new FloatName(paramName)];
                            double dValue = Object2Double(value);
                            if (dValue < floatParameter.GetMinimum() || dValue > floatParameter.GetMaximum())
                            {
                                errMessage = cMessageContent.BuildMessage(cMessageContent.War_ValueOutOffRange,
                                    new string[]
                                    {
                                    paramName, floatParameter.GetMinimum().ToString(),
                                    floatParameter.GetMaximum().ToString()
                                    },
                                    new string[]
                                    {
                                    paramName, floatParameter.GetMinimum().ToString(),
                                    floatParameter.GetMaximum().ToString()
                                    });
                                return;
                            }

                            floatParameter.SetValue(dValue);
                            break;
                        }
                    case "GenApiIntegerParameter":
                        {
                            IIntegerParameter integerParameter = baslerCamera.Parameters[new IntegerName(paramName)];
                            int iValue = Object2Int(value);
                            if (iValue < integerParameter.GetMinimum() || iValue > integerParameter.GetMaximum())
                            {
                                errMessage = cMessageContent.BuildMessage(cMessageContent.War_ValueOutOffRange,
                                    new string[]
                                    {
                                    paramName, integerParameter.GetMinimum().ToString(),
                                    integerParameter.GetMaximum().ToString()
                                    },
                                    new string[]
                                    {
                                    paramName, integerParameter.GetMinimum().ToString(),
                                    integerParameter.GetMaximum().ToString()
                                    });
                                return;
                            }

                            integerParameter.SetValue(iValue);
                            break;
                        }
                    case "GenApiBooleanParameter":
                        {
                            IBooleanParameter booleanParameter = baslerCamera.Parameters[new BooleanName(paramName)];
                            bool bValue = Object2Bool(value);
                            booleanParameter.SetValue(bValue);
                            break;

                        }
                    case "GenApiEnumParameter":
                        {
                            IEnumParameter enumParameter = baslerCamera.Parameters[new EnumName(paramName)];
                            string sValue = Object2Str(value);
                            enumParameter.SetValue(sValue);
                            break;

                        }
                }
            }
            catch (Exception e)
            {
                errMessage = $"{e.Message}\n{e.StackTrace}";
            }
        }
        public static bool SetCameraPropValue_Dahua(MyDahuaCamera dahuaCamera, cPropCompare propCompare, ref string errMessage)
        {
            errMessage = string.Empty;
            switch (propCompare.PropCAMName)
            {
                case cParamName.TriggerDelay:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.TriggerDelay, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerSource:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.TriggerSource, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerMode:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.TriggerMode, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.TriggerActivation:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.TriggerActivation, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.ExposureTime:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.ExposureTime, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.Gain:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.Gain, (double)propCompare.DValue, ref errMessage);
                        break;
                    }
                case cParamName.ExposureMode:
                    {
                        GlobFuncs.Dahua_SetValue(dahuaCamera, cParamName.ExposureMode, propCompare.SValue, ref errMessage);
                        break;
                    }
                case cParamName.AcquisitionMode:
                    return true;
                    //case cParamName.BalanceRatioR:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue);
                    //case cParamName.BalanceRatioG:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue, cBalanceRatioSelector.Green);
                    //case cParamName.BalanceRatioB:
                    //    return GlobFuncs.HIK_SetBalanceRatioValue(hikCamera, propCompare.DValue, cBalanceRatioSelector.Blue);
            }

            return string.IsNullOrEmpty(errMessage);
        }
        public static void Dahua_SetValue(MyDahuaCamera dahuaCamera,
                   string paramName,
                   object value,
                   ref string errMessage)
        {
            try
            {
                errMessage = string.Empty;

                if (dahuaCamera == null || !dahuaCamera.IsConnected)
                {
                    errMessage = cMessageContent.War_CameraOffline;
                    return;
                }
                int res = dahuaCamera.MySelf.IMV_SetEnumFeatureSymbol(paramName, GlobFuncs.Object2Str(value));
                if (res != IMVDefine.IMV_OK)
                {
                    errMessage = $"Set {paramName} falled";
                    return;
                }
                else
                    return;

                res = dahuaCamera.MySelf.IMV_SetDoubleFeatureValue(paramName, GlobFuncs.Object2Double(value));
                if (res != IMVDefine.IMV_OK)
                {
                    errMessage = $"Set {paramName} falled";
                    return;
                }
                else
                    return;

                res = dahuaCamera.MySelf.IMV_SetBoolFeatureValue(paramName, GlobFuncs.Object2Bool(value));
                if (res != IMVDefine.IMV_OK)
                {
                    errMessage = $"Set {paramName} falled";
                    return;
                }
                else
                    return;

                res = dahuaCamera.MySelf.IMV_SetIntFeatureValue(paramName, GlobFuncs.Object2Int(value));
                if (res != IMVDefine.IMV_OK)
                {
                    errMessage = $"Set {paramName} falled";
                    return;
                }
                else
                    return;

                res = dahuaCamera.MySelf.IMV_SetStringFeatureValue(paramName, GlobFuncs.Object2Str(value));
                if (res != IMVDefine.IMV_OK)
                {
                    errMessage = $"Set {paramName} falled";
                    return;
                }
                else
                    return;

                res = dahuaCamera.MySelf.IMV_SetStringFeatureValue(paramName, GlobFuncs.Object2Str(value));
                if (res != IMVDefine.IMV_OK)
                {
                    errMessage = $"Set {paramName} falled";
                    return;
                }
                else
                    return;
            }
            catch (Exception e)
            {
                errMessage = $"{e.Message}\n{e.StackTrace}";
            }
        }
        public static string ListObject2StrWithType(List<object> _object)
        {

            if (_object == null || _object.Count <= 0)
                return string.Empty;
            string Result = string.Empty;
            for (int i = 0; i < _object.Count; i++)
            {
                if (Result == string.Empty)
                    Result = Ve2Str(_object[i]);
                else
                    Result = Result + "," + Ve2Str(_object[i]);
            }
            if (Result != "") Result = Result + cStrings.SepGDung + GlobFuncs.GetListType(_object.ToList());
            return Result;
        }
        public static string ListObject2Str(List<object> _object)
        {

            if (_object == null || _object.Count <= 0)
                return string.Empty;
            string Result = string.Empty;
            for (int i = 0; i < _object.Count; i++)
            {
                if (Result == string.Empty)
                    Result = Ve2Str(_object[i]);
                else
                    Result = Result + "," + Ve2Str(_object[i]);
            }
            if (Result != "") Result = Result;
            return Result;
        }
        public static List<string> ListObject2ListStr(List<object> _object)
        {

            if (_object == null || _object.Count <= 0)
                return new List<string>();
            List<string> list = new List<string>();
            for (int i = 0; i < _object.Count; i++)
                list.Add(GlobFuncs.Object2Str(_object[i]));
            return list;
        }
        public static string ListString2StrWithType(List<string> _string)
        {
            if (_string == null || _string.Count <= 0)
                return string.Empty;
            string Result = string.Empty;
            for (int i = 0; i < _string.Count; i++)
            {
                if (Result == string.Empty)
                    Result = Ve2Str(_string[i]);
                else
                    Result = Result + "," + Ve2Str(_string[i]);
            }
            if (Result != "") Result = Result + cStrings.SepGDung + GlobFuncs.GetListType(_string.Cast<object>().ToList());
            return Result;
        }
        public static string GetListType(List<object> ListValue)
        {
            string result = string.Empty;
            if (ListValue.Count == 0) return "NONE";
            else if (ListValue.Count == 1) return ListValue[0].GetType().Name.ToString().ToUpper();
            else
            {
                for (int i = 0; i < ListValue.Count - 1; i++)
                {

                    if (ListValue[i].GetType().Name == ListValue[i + 1].GetType().Name)
                    {
                        switch (ListValue[i].GetType().Name)
                        {
                            case "Int32":
                            case "Int64":
                                result = "INTERGER";
                                break;
                            case "String":
                                result = "STRING";
                                break;
                            case "Double":
                                result = "DOUBLE";
                                break;
                            case "Long":
                                result = "LONG";
                                break;
                            default:
                                result = ListValue[i].GetType().Name.ToString().ToUpper();
                                break;

                        }
                    }
                    else
                        result = "MIXED";

                }
            }
            return result;
        }
        public static string ListDouble2StrWithType(List<double> _double)
        {
            if (_double == null || _double.Count <= 0)
                return string.Empty;
            string Result = string.Empty;
            for (int i = 0; i < _double.Count; i++)
            {
                if (Result == string.Empty)
                    Result = Ve2Str(_double[i]);
                else
                    Result = Result + "," + Ve2Str(_double[i]);
            }
            if (Result != "") Result = Result + cStrings.SepGDung + GlobFuncs.GetListType(_double.Cast<object>().ToList());
            return Result;
        }

        public static object ListGuid2String(List<Guid> listGuid, char sep)
        {
            if (listGuid == null || listGuid.Count <= 0)
                return string.Empty;
            string value = string.Empty;
            foreach (Guid guid in listGuid)
                value = value + (value == string.Empty ? guid.ToString() : sep + guid.ToString());
            return value;
        }


        public static int Object2Int(object @object, int @default = 0)
        {
            try
            {
                return Convert.ToInt32(@object);
            }
            catch
            {
                return 0;
            }
        }
        public static double Object2Double(object @object, double @default = 0)
        {
            if (@object == null)
                return @default;
            if (double.TryParse(@object.ToString(), out double result))
                return result;
            return @default;
        }
        public static long Object2Long(object @object, long @default = 0)
        {
            if (@object == null)
                return @default;
            if (long.TryParse(@object.ToString(), out long result))
                return result;
            return @default;
        }
        #endregion
        #region CAMERA

        public static bool HIK_SetBalanceRatioValue(MyHikCamera hikCamera, decimal value, string balanceRatioSelector = cBalanceRatioSelector.Red)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (balanceRatioSelector)
            {
                case cBalanceRatioSelector.Red:
                    return hikCamera.MV_CC_SetBalanceRatioRed_NET((uint)value) == 0;
                case cBalanceRatioSelector.Green:
                    return hikCamera.MV_CC_SetBalanceRatioGreen_NET((uint)value) == 0;
                case cBalanceRatioSelector.Blue:
                    return hikCamera.MV_CC_SetBalanceRatioBlue_NET((uint)value) == 0;
            }
            return false;
        }
        public static bool HIK_SetAcquisitionMode(MyHikCamera hikCamera, string value)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (value)
            {
                case cAcquisitionMode.SingleFrame:
                    return hikCamera.MV_CC_SetAcquisitionMode_NET(
                       (uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_SINGLE) == 0;
                case cAcquisitionMode.MultiFrame:
                    return hikCamera.MV_CC_SetAcquisitionMode_NET(
                       (uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_MUTLI) == 0;
                case cAcquisitionMode.Continuous:
                    return hikCamera.MV_CC_SetAcquisitionMode_NET(
                       (uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS) == 0;
            }
            return false;
        }
        public static bool HIK_SetExposureMode(MyHikCamera hikCamera, string value)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (value)
            {
                case cExposureMode.Timed:
                    return hikCamera.MV_CC_SetEnumValue_NET(cParamName.ExposureMode,
                        (uint)MyHikCamera.MV_CAM_EXPOSURE_MODE.MV_EXPOSURE_MODE_TIMED) == 0;
                case cExposureMode.TriggerWidth:
                    return hikCamera.MV_CC_SetEnumValue_NET(cParamName.ExposureMode,
                        (uint)MyHikCamera.MV_CAM_EXPOSURE_MODE.MV_EXPOSURE_MODE_TRIGGER_WIDTH) == 0;
            }
            return false;
        }
        public static bool HIK_SetTriggerActivation(MyHikCamera hikCamera, string value)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (value)
            {
                case cTriggerActivation.RisingEdge:
                    return hikCamera.MV_CC_SetEnumValue_NET(cParamName.TriggerActivation, 0) == 0;
                case cTriggerActivation.FallingEdge:
                    return hikCamera.MV_CC_SetEnumValue_NET(cParamName.TriggerActivation, 1) == 0;
            }
            return false;
        }
        public static bool HIK_SetTriggerMode(MyHikCamera hikCamera, string value)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (value)
            {
                case cTriggerMode.On:
                    return hikCamera.MV_CC_SetTriggerMode_NET((uint)MyHikCamera.MV_CAM_TRIGGER_MODE.
                        MV_TRIGGER_MODE_ON) == 0;
                case cTriggerMode.Off:
                    return hikCamera.MV_CC_SetTriggerMode_NET((uint)MyHikCamera.MV_CAM_TRIGGER_MODE.
                        MV_TRIGGER_MODE_OFF) == 0;

            }
            return false;
        }
        public static bool HIK_SetTriggerSource(MyHikCamera hikCamera, string value)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (value)
            {
                case cTriggerSource.Software:
                    return hikCamera.MV_CC_SetTriggerSource_NET((uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.
                        MV_TRIGGER_SOURCE_SOFTWARE) == 0;
                case cTriggerSource.Line0:
                    return hikCamera.MV_CC_SetTriggerSource_NET((uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.
                        MV_TRIGGER_SOURCE_LINE0) == 0;
                case cTriggerSource.Line1:
                    return hikCamera.MV_CC_SetTriggerSource_NET((uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.
                        MV_TRIGGER_SOURCE_LINE1) == 0;
                case cTriggerSource.Line2:
                    return hikCamera.MV_CC_SetTriggerSource_NET((uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.
                        MV_TRIGGER_SOURCE_LINE2) == 0;
                case cTriggerSource.Line3:
                    return hikCamera.MV_CC_SetTriggerSource_NET((uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.
                        MV_TRIGGER_SOURCE_LINE3) == 0;
                case cTriggerSource.Counter0:
                    return hikCamera.MV_CC_SetTriggerSource_NET((uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.
                        MV_TRIGGER_SOURCE_COUNTER0) == 0;

            }
            return false;
        }
        public static MyHikCamera.MV_CC_DEVICE_INFO_LIST GetHikrobotDeviceInfoList()
        {
            try
            {
                GC.Collect();
                MyHikCamera.MV_CC_DEVICE_INFO_LIST mStDeviceList = new MyHikCamera.MV_CC_DEVICE_INFO_LIST();
                int nRet = MyHikCamera.MV_CC_EnumDevices_NET(MyHikCamera.MV_GIGE_DEVICE | MyHikCamera.MV_USB_DEVICE, ref mStDeviceList);
                if (0 != nRet)
                    return new MyHikCamera.MV_CC_DEVICE_INFO_LIST();
                return mStDeviceList;
            }
            catch
            {
                return new MyHikCamera.MV_CC_DEVICE_INFO_LIST();
            }
        }

        public static List<string> GetHikrobotGenICamTLInterfaces()
        {
            try
            {
                string ctiFileName = string.Empty; List<string> interfaceList = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL", "MvFGProducerCML.cti");
                                break;
                            }
                        case 1:
                            {
                                ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL", "MvFGProducerCXP.cti");
                                break;
                            }
                        case 2:
                            {
                                ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL", "MvFGProducerGEV.cti");
                                break;
                            }
                        case 3:
                            {
                                ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL", "MvProducerGEV.cti");
                                break;
                            }
                        case 4:
                            {
                                ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL", "MvProducerU3V.cti");
                                break;
                            }
                        case 5:
                            {
                                ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL", "MvProducerVIR.cti");
                                break;
                            }
                    }
                    if (!File.Exists(ctiFileName))
                        continue;
                    List<string> interfaceItemList = GetHikrobotGenICamTLInterfaces(ctiFileName);
                    if (interfaceItemList != null && interfaceItemList.Count > 0)
                        interfaceList.AddRange(interfaceItemList);
                }
                return interfaceList;
            }
            catch
            {
                return new List<string>();
            }
        }

        internal static List<double> StrToDoubleList(string _Value, char _Sep = cStrings.SepPhay)
        {
            List<double> Result = new List<double>();
            string[] _Values = _Value.Split(_Sep);
            for (int i = 0; i < _Values.Length; i++)
            {
                Result.Add(int.Parse(_Value[i].ToString()));
            }
            return Result;
        }

        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");
            IEnumerable<FileInfo> files = dir.EnumerateFiles();
            return files.Where(f => extensions.Contains(f.Extension));

        }

        private static List<string> GetHikrobotGenICamTLInterfaces(string ctiFileName)
        {
            List<string> interfaceList = null;
            System.GC.Collect();
            MyHikCamera.MV_GENTL_IF_INFO_LIST m_stIFInfoList = new MyHikCamera.MV_GENTL_IF_INFO_LIST();
            int nRet = MyHikCamera.MV_CC_EnumInterfacesByGenTL_NET(ref m_stIFInfoList, ctiFileName);
            if (0 != nRet)
                return interfaceList;
            for (UInt32 i = 0; i < m_stIFInfoList.nInterfaceNum; i++)
            {
                MyHikCamera.MV_GENTL_IF_INFO stIFInfo = (MyHikCamera.MV_GENTL_IF_INFO)Marshal.PtrToStructure(m_stIFInfoList.pIFInfo[i], typeof(MyHikCamera.MV_GENTL_IF_INFO));
                if (interfaceList == null)
                    interfaceList = new List<string>();
                interfaceList.Add(stIFInfo.chTLType + " " + stIFInfo.chInterfaceID + " " + stIFInfo.chDisplayName);
            }
            return interfaceList;
        }
        private static MyHikCamera.MV_GENTL_IF_INFO_LIST GetHikrobotGenICamTLInterfaceInfoList(string ctiFileName)
        {
            System.GC.Collect();
            MyHikCamera.MV_GENTL_IF_INFO_LIST m_stIFInfoList = new MyHikCamera.MV_GENTL_IF_INFO_LIST();
            int nRet = MyHikCamera.MV_CC_EnumInterfacesByGenTL_NET(ref m_stIFInfoList, ctiFileName);
            if (0 != nRet)
                return new MyHikCamera.MV_GENTL_IF_INFO_LIST();
            return m_stIFInfoList;
        }
        //public static MyHikCamera.MV_GENTL_IF_INFO GetHikrobotGenICamTLInterfaceInfo(string interfaceName)
        //{
        //    string ctiFileName = string.Empty;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        switch (i)
        //        {
        //            case 0:
        //                {
        //                    ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
        //                        "MvFGProducerCML.cti");
        //                    break;
        //                }
        //            case 1:
        //                {
        //                    ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
        //                        "MvFGProducerCXP.cti");
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
        //                        "MvFGProducerGEV.cti");
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
        //                        "MvProducerGEV.cti");
        //                    break;
        //                }
        //            case 4:
        //                {
        //                    ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
        //                        "MvProducerU3V.cti");
        //                    break;
        //                }
        //            case 5:
        //                {
        //                    ctiFileName = Path.Combine(GlobVar.RTCVision.Paths.Templates, "Hikrobot_GenICamTL",
        //                        "MvProducerVIR.cti");
        //                    break;
        //                }
        //        }
        //        if (!File.Exists(ctiFileName))
        //            continue;
        //        MyHikCamera.MV_GENTL_IF_INFO_LIST m_stIFInfoList = GetHikrobotGenICamTLInterfaceInfoList(ctiFileName);
        //        if (m_stIFInfoList.nInterfaceNum != 0)
        //            for (UInt32 j = 0; j < m_stIFInfoList.nInterfaceNum; j++)
        //            {
        //                MyHikCamera.MV_GENTL_IF_INFO stIFInfo = (MyHikCamera.MV_GENTL_IF_INFO)Marshal.PtrToStructure(m_stIFInfoList.pIFInfo[i],
        //                    typeof(MyHikCamera.MV_GENTL_IF_INFO));
        //                if (stIFInfo.chTLType + " " + stIFInfo.chInterfaceID + " " + stIFInfo.chDisplayName ==
        //                    interfaceName)
        //                    return stIFInfo;
        //            }


        //    }
        //    return new MyHikCamera.MV_GENTL_IF_INFO();
        //}
        public static Dictionary<string, ICameraInfo> GetBaslerCameraInfos()
        {
            Dictionary<string, ICameraInfo> foundCameraInfos = null;
            try
            {
                // Ask the camera finder for a list of cameras.
                List<ICameraInfo> cameraInfos = CameraFinder.Enumerate();

                if (cameraInfos.Count > 0)
                {
                    // Maps the camera name to the camera info for use with the combo box.
                    foundCameraInfos = new Dictionary<string, ICameraInfo>();
                    foreach (ICameraInfo cameraInfo in cameraInfos)
                    {
                        if (!foundCameraInfos.ContainsKey(cameraInfo[CameraInfoKey.FriendlyName]))
                            foundCameraInfos.Add(cameraInfo[CameraInfoKey.FriendlyName], cameraInfo);
                    }
                }
            }
            catch
            {
                foundCameraInfos = null;
            }
            return foundCameraInfos;
        }
        public static MyHikCamera.MV_CC_DEVICE_INFO GetHikrobotDeviceInfo(string deviceName, out bool isExists)
        {
            isExists = false;
            System.GC.Collect();
            MyHikCamera.MV_CC_DEVICE_INFO_LIST mStDeviceList = new MyHikCamera.MV_CC_DEVICE_INFO_LIST();
            int nRet = MyHikCamera.MV_CC_EnumDevices_NET(MyHikCamera.MV_GIGE_DEVICE | MyHikCamera.MV_USB_DEVICE, ref mStDeviceList);
            if (0 != nRet)
                return new MyHikCamera.MV_CC_DEVICE_INFO();
            isExists = true;
            for (var i = 0; i < mStDeviceList.nDeviceNum; i++)
            {
                MyHikCamera.MV_CC_DEVICE_INFO device =
                    (MyHikCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(mStDeviceList.pDeviceInfo[i],
                    typeof(MyHikCamera.MV_CC_DEVICE_INFO));
                if (device.nTLayerType == MyHikCamera.MV_GIGE_DEVICE)
                {
                    MyHikCamera.MV_GIGE_DEVICE_INFO gigeInfo =
                        (MyHikCamera.MV_GIGE_DEVICE_INFO)MyHikCamera.ByteToStruct(device.SpecialInfo.stGigEInfo,
                        typeof(MyHikCamera.MV_GIGE_DEVICE_INFO));

                    if (gigeInfo.chUserDefinedName != "" &&
                        "GEV: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")" == deviceName)
                        return device;
                    else if (gigeInfo.chUserDefinedName == "" &&
                         "GEV: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName +
                         " (" + gigeInfo.chSerialNumber + ")" == deviceName)
                        return device;
                }
                else if (device.nTLayerType == MyHikCamera.MV_USB_DEVICE)
                {
                    MyHikCamera.MV_USB3_DEVICE_INFO usbInfo =
                        (MyHikCamera.MV_USB3_DEVICE_INFO)MyHikCamera.ByteToStruct(device.SpecialInfo.stUsb3VInfo,
                        typeof(MyHikCamera.MV_USB3_DEVICE_INFO));
                    if (usbInfo.chUserDefinedName != "" &&
                        "U3V: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")" == deviceName)
                        return device;
                    else if (usbInfo.chUserDefinedName == "" &&
                        "U3V: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")" == deviceName)
                        return device;
                }

            }
            return new MyHikCamera.MV_CC_DEVICE_INFO();
        }
        public static string Hik_GetErrorMessage(int nErrorNum)
        {
            string errorMsg = string.Empty;
            if (nErrorNum != 0)
            {
                errorMsg = "Error =" + string.Format("{0:X}", nErrorNum);
                switch (nErrorNum)
                {
                    case MyHikCamera.MV_E_HANDLE: errorMsg += " Error or invalid handle "; break;
                    case MyHikCamera.MV_E_SUPPORT: errorMsg += " Not supported function "; break;
                    case MyHikCamera.MV_E_BUFOVER: errorMsg += " Cache is full "; break;
                    case MyHikCamera.MV_E_CALLORDER: errorMsg += " Function calling order error "; break;
                    case MyHikCamera.MV_E_PARAMETER: errorMsg += " Incorrect parameter "; break;
                    case MyHikCamera.MV_E_RESOURCE: errorMsg += " Applying resource failed "; break;
                    case MyHikCamera.MV_E_NODATA: errorMsg += " No data "; break;
                    case MyHikCamera.MV_E_PRECONDITION: errorMsg += " Precondition error, or running environment changed "; break;
                    case MyHikCamera.MV_E_VERSION: errorMsg += " Version mismatches "; break;
                    case MyHikCamera.MV_E_NOENOUGH_BUF: errorMsg += " Insufficient memory "; break;
                    case MyHikCamera.MV_E_UNKNOW: errorMsg += " Unknown error "; break;
                    case MyHikCamera.MV_E_GC_GENERIC: errorMsg += " General error "; break;
                    case MyHikCamera.MV_E_GC_ACCESS: errorMsg += " Node accessing condition error "; break;
                    case MyHikCamera.MV_E_ACCESS_DENIED: errorMsg += " No permission "; break;
                    case MyHikCamera.MV_E_BUSY: errorMsg += " Device is busy, or network disconnected "; break;
                    case MyHikCamera.MV_E_NETER: errorMsg += " Network error "; break;
                    case MyHikCamera.MV_E_ABNORMAL_IMAGE: errorMsg += " Abnormal image, maybe incomplete image because of lost packet "; break;
                    case MyHikCamera.MV_E_ENCRYPT: errorMsg += " Encryption error "; break;
                    case MyHikCamera.MV_E_GC_ARGUMENT: errorMsg += " Illegal parameters "; break;
                    case MyHikCamera.MV_E_GC_DYNAMICCAST: errorMsg += " Transformation exception "; break;
                    case MyHikCamera.MV_E_GC_LOGICAL: errorMsg += " Logical error "; break;
                    case MyHikCamera.MV_E_GC_PROPERTY: errorMsg += " Property "; break;
                    case MyHikCamera.MV_E_GC_RANGE: errorMsg += " The value is out of range "; break;
                    case MyHikCamera.MV_E_GC_RUNTIME: errorMsg += " Running environment error "; break;
                    case MyHikCamera.MV_E_GC_TIMEOUT: errorMsg += " Timeout "; break;
                    case MyHikCamera.MV_E_GC_UNKNOW: errorMsg += " GenICam unknown error "; break;
                    case MyHikCamera.MV_E_UPG_UNKNOW: errorMsg += " Unknown error during upgrade "; break;
                    case MyHikCamera.MV_E_UPG_INNER_ERR: errorMsg += " Camera internal error during upgrade "; break;
                    case MyHikCamera.MV_E_UPG_CONFLICT: errorMsg += " Upgrading conflicted (repeated upgrading requests during device upgrade) "; break;
                    case MyHikCamera.MV_E_UPG_LANGUSGE_MISMATCH: errorMsg += " Firmware language mismatches "; break;
                    case MyHikCamera.MV_E_UPG_FILE_MISMATCH: errorMsg += " Firmware mismatches "; break;
                    case MyHikCamera.MV_E_USB_UNKNOW: errorMsg += " USB unknown error "; break;
                    case MyHikCamera.MV_E_USB_DRIVER: errorMsg += " Driver mismatch or unmounted drive "; break;
                    case MyHikCamera.MV_E_USB_BANDWIDTH: errorMsg += " Insufficient bandwidth, this error code is newly added "; break;
                    case MyHikCamera.MV_E_USB_GENICAM: errorMsg += " GenICam error "; break;
                    case MyHikCamera.MV_E_USB_DEVICE: errorMsg += " Device exception "; break;
                    case MyHikCamera.MV_E_USB_WRITE: errorMsg += " Writing USB error "; break;
                    case MyHikCamera.MV_E_USB_READ: errorMsg += " Reading USB error "; break;
                    case MyHikCamera.MV_E_IP_CONFLICT: errorMsg += " Device IP conflict "; break;
                    case MyHikCamera.MV_E_PACKET: errorMsg += " Network data packet error "; break;
                    case MyHikCamera.MV_E_WRITE_PROTECT: errorMsg += " The target address is not writable "; break;
                    case MyHikCamera.MV_E_INVALID_ADDRESS: errorMsg += " The target address being accessed does not exist "; break;
                    case MyHikCamera.MV_E_NOT_IMPLEMENTED: errorMsg += " The command is not supported by device "; break;
                    case MyHikCamera.MV_E_LOAD_LIBRARY: errorMsg += " Load library failed "; break;
                }
            }
            return errorMsg;
        }

        #region SETVALUE TO CAMERA FROM CONTROLS
        public static bool HIK_SetFloatValue(MyHikCamera hikCamera, string paramName, decimal Value)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            int nRet = hikCamera.MV_CC_SetFloatValue_NET(paramName, (float)Value);
            return nRet == 0;
        }
        public static bool HIK_SetExposureTime(MyHikCamera hikCamera, decimal Value)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            int nRet = hikCamera.MV_CC_SetExposureTime_NET((float)Value);
            return nRet == 0;
        }
        public static bool HIK_SetFloatValueFromNumberic(MyHikCamera hikCamera, string paramName, NumericUpDown edit)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            int nret = hikCamera.MV_CC_SetFloatValue_NET(paramName, (float)edit.Value);
            if (nret != 0)
            {
                if (paramName == cParamName.TriggerDelay)
                    paramName = cParamName.TriggerDelayAbs;
                else if (paramName == cParamName.ExposureTime)
                    paramName = cParamName.ExposureTimeAbs;
                nret = hikCamera.MV_CC_SetFloatValue_NET(paramName, (float)edit.Value);
            }
            return nret == 0;
        }
        internal static bool HIK_SetTriggerSourceFromCombobox(MyHikCamera hikCamera, ComboBox edit)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (edit.Text)
            {
                case cTriggerSource.Software:
                    return hikCamera.MV_CC_SetTriggerSource_NET(
                        (uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE) == 0;
                case cTriggerSource.Line0:
                    return hikCamera.MV_CC_SetTriggerSource_NET(
                        (uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0) == 0;
                case cTriggerSource.Line1:
                    return hikCamera.MV_CC_SetTriggerSource_NET(
                        (uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE1) == 0;
                case cTriggerSource.Line2:
                    return hikCamera.MV_CC_SetTriggerSource_NET(
                        (uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE2) == 0;
                case cTriggerSource.Line3:
                    return hikCamera.MV_CC_SetTriggerSource_NET(
                        (uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE3) == 0;
                case cTriggerSource.Counter0:
                    return hikCamera.MV_CC_SetTriggerSource_NET(
                        (uint)MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_COUNTER0) == 0;
            }
            return false;
        }
        internal static bool HIK_SetTriggerModeFromCombobox(MyHikCamera hikCamera, ComboBox Edit)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (Edit.Text)
            {
                case cTriggerMode.On:
                    return hikCamera.MV_CC_SetTriggerMode_NET((uint)MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON) == 0;
                case cTriggerMode.Off:
                    return hikCamera.MV_CC_SetTriggerMode_NET((uint)MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF) == 0;
            }
            return false;

        }
        internal static bool HIK_SetTriggerActivitionFromCombobox(MyHikCamera hikCamera, ComboBox Edit)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (Edit.Text)
            {
                case cTriggerActivation.RisingEdge:
                    return hikCamera.MV_CC_SetEnumValue_NET(cParamName.TriggerActivation, 0) == 0;
                case cTriggerActivation.FallingEdge:
                    return hikCamera.MV_CC_SetEnumValue_NET(cParamName.TriggerActivation, 1) == 0;
            }
            return false;

        }
        public static bool HIK_SetIntValueFromNumberic(MyHikCamera hikCamera, string paramName, NumericUpDown edit)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            int nret = 0;
            if (paramName == cParamName.TriggerDelay || paramName == cParamName.GainRaw)
                nret = hikCamera.MV_CC_SetIntValue_NET(paramName, (uint)edit.Value);
            else
                nret = hikCamera.MV_CC_SetIntValue_NET(paramName, (uint)edit.Value);

            return nret == 0;
        }
        public static bool HIK_SetExposureModeFromCombobox(MyHikCamera hikCamera, ComboBox edit)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (edit.Text)
            {
                case cExposureMode.Timed:
                    return hikCamera.MV_CC_SetExposureAutoMode_NET((uint)MyHikCamera.MV_CAM_EXPOSURE_MODE.MV_EXPOSURE_MODE_TIMED) == 0;
                case cExposureMode.TriggerWidth:
                    return hikCamera.MV_CC_SetExposureAutoMode_NET((uint)MyHikCamera.MV_CAM_EXPOSURE_MODE.MV_EXPOSURE_MODE_TRIGGER_WIDTH) == 0;
            }
            return false;
        }
        public static bool HIK_AcquisitionModeFromCombobox(MyHikCamera hikCamera, ComboBox edit)
        {
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            switch (edit.Text)
            {
                case cAcquisitionMode.Continuous:
                    return hikCamera.MV_CC_SetAcquisitionMode_NET((uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS) == 0;
                case cAcquisitionMode.MultiFrame:
                    return hikCamera.MV_CC_SetAcquisitionMode_NET((uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_MUTLI) == 0;
                case cAcquisitionMode.SingleFrame:
                    return hikCamera.MV_CC_SetAcquisitionMode_NET((uint)MyHikCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_SINGLE) == 0;
            }
            return false;

        }
        public static void Dahua_SetFloatvalue(MyDahuaCamera dahuaCamera,
            string paramName,
            object Value,
            ref string errMessage)
        {
            try
            {
                errMessage = string.Empty;
                if (dahuaCamera == null || !dahuaCamera.IsConnected)
                {
                    errMessage = cMessageContent.War_CAMCannotConnect;
                    return;
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        #endregion
        #endregion

        #region SETVALUE TO CONTROL FROM CAMERA
        public static void HIK_SetFloatValueToNumberic(MyHikCamera hikCamera, string paramName, NumericUpDown edit)
        {
            try
            {
                MyHikCamera.MVCC_FLOATVALUE floatValue = new MyHikCamera.MVCC_FLOATVALUE();
                edit.Value = 0;
                edit.Maximum = 0;
                edit.Minimum = 0;
                bool Result = false;
                if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero ||
                    !hikCamera.GetFloatValue(paramName, ref floatValue))
                {
                    if (paramName == cParamName.Gain)
                        Hik_SetIntValueToNumberic(hikCamera, cParamName.GainRaw, edit);
                    else if (paramName == cParamName.ExposureTimeAbs)
                    {
                        Result = hikCamera.GetFloatValue(cParamName.ExposureTimeRaw, ref floatValue);
                        if (!Result)
                            Result = hikCamera.GetFloatValue(cParamName.ExposureTime, ref floatValue);
                    }
                }
                if (double.IsInfinity(floatValue.fMax))
                    edit.Maximum = decimal.MaxValue;
                else
                    edit.Maximum = (decimal)floatValue.fMax;
                if (double.IsInfinity(floatValue.fMin))
                    edit.Minimum = decimal.MinValue;
                else
                    edit.Minimum = (decimal)floatValue.fMin;
                edit.Value = (decimal)floatValue.fCurValue;

            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }

        public static void Hik_SetIntValueToNumberic(MyHikCamera hikCamera, string paramName, NumericUpDown edit)
        {
            MyHikCamera.MVCC_INTVALUE intValue = new MyHikCamera.MVCC_INTVALUE();
            edit.Value = 0;
            edit.Maximum = 0;
            edit.Minimum = 0;
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero || !hikCamera.GetIntValue(paramName, ref intValue))
            {
                if (paramName == cParamName.GainRaw)
                    Hik_SetIntValueToNumberic(hikCamera, cParamName.Gain, edit);

                return;
            }

        }


        public static void HIK_SetTriggerActivitionToComboBox(MyHikCamera hikCamera, ComboBox edit)
        {
            edit.Text = string.Empty;
            edit.Items.Clear();
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            MyHikCamera.MVCC_ENUMVALUE enumValue = new MyHikCamera.MVCC_ENUMVALUE();
            if (!HIK_GetEnumValue(hikCamera, cParamName.TriggerActivation, ref enumValue))
                return;
            edit.Items.Add(cTriggerActivation.RisingEdge);
            edit.Items.Add(cTriggerActivation.FallingEdge);
            switch (enumValue.nCurValue)
            {
                case 0:
                    {
                        edit.Text = cTriggerActivation.RisingEdge;
                        break;
                    }
                case 1:
                    {
                        edit.Text = cTriggerActivation.FallingEdge;
                        break;
                    }
            }

        }

        public static bool HIK_GetEnumValue(MyHikCamera hikCamera, string paramName, ref MyHikCamera.MVCC_ENUMVALUE enumValue)
        {
            enumValue = new MyHikCamera.MVCC_ENUMVALUE();
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            int nRet = hikCamera.MV_CC_GetEnumValue_NET(paramName, ref enumValue);
            if (0 == nRet)
                return true;
            else
            {
                enumValue = new MyHikCamera.MVCC_ENUMVALUE();
                return false;
            }
        }

        public static void HIK_SetTriggerModetoComboBox(MyHikCamera hikCamera, ComboBox edit)
        {
            MyHikCamera.MV_CAM_TRIGGER_MODE camTriggerMode = MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON;
            edit.Text = string.Empty;
            edit.Items.Clear();
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            if (!HIK_GetTriggerMode(hikCamera, ref camTriggerMode))
                return;
            edit.Items.Add(cTriggerMode.On);
            edit.Items.Add(cTriggerMode.Off);
            if (camTriggerMode == MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON)
            {
                edit.SelectedIndex = 0;
            }
            else
            {
                edit.SelectedIndex = 1;
            }
        }

        public static bool HIK_GetTriggerMode(MyHikCamera hikCamera, ref MyHikCamera.MV_CAM_TRIGGER_MODE camTriggerMode)
        {
            camTriggerMode = MyHikCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF;
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            MyHikCamera.MVCC_ENUMVALUE enumValue = new MyHikCamera.MVCC_ENUMVALUE();
            int result = hikCamera.MV_CC_GetTriggerMode_NET(ref enumValue);
            if (0 == result)
            {
                camTriggerMode = (MyHikCamera.MV_CAM_TRIGGER_MODE)enumValue.nCurValue;
                return true;
            }
            return false;
        }

        public static void HIK_SetTriggerDelaytoComboBox(MyHikCamera hikCamera, ComboBox edit)
        {
            MyHikCamera.MV_CAM_TRIGGER_SOURCE camTriggerSource = MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE;
            edit.Text = string.Empty;
            edit.Items.Clear();
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            if (!HIK_GetTriggerSource(hikCamera, ref camTriggerSource))
                return;
            edit.Items.Add(cTriggerSource.Software);
            edit.Items.Add(cTriggerSource.Line0);
            edit.Items.Add(cTriggerSource.Line1);
            edit.Items.Add(cTriggerSource.Line2);
            edit.Items.Add(cTriggerSource.Line3);
            edit.Items.Add(cTriggerSource.Counter0);
            switch (camTriggerSource)
            {
                case MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE:
                    {
                        edit.Text = cTriggerSource.Software;
                        break;
                    }
                case MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0:
                    {
                        edit.Text = cTriggerSource.Line0;
                        break;
                    }
                case MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE1:
                    {
                        edit.Text = cTriggerSource.Line1;
                        break;
                    }
                case MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE2:
                    {
                        edit.Text = cTriggerSource.Line2;
                        break;
                    }
                case MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE3:
                    {
                        edit.Text = cTriggerSource.Line3;
                        break;
                    }
                case MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_COUNTER0:
                    {
                        edit.Text = cTriggerSource.Counter0;
                        break;
                    }
            }



        }

        public static bool HIK_GetTriggerSource(MyHikCamera hikCamera, ref MyHikCamera.MV_CAM_TRIGGER_SOURCE camTriggerSource)
        {
            camTriggerSource = MyHikCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE;
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            MyHikCamera.MVCC_ENUMVALUE enumValue = new MyHikCamera.MVCC_ENUMVALUE();
            int result = hikCamera.MV_CC_GetTriggerSource_NET(ref enumValue);
            if (0 == result)
            {
                camTriggerSource = (MyHikCamera.MV_CAM_TRIGGER_SOURCE)enumValue.nCurValue;
                return true;
            }
            return false;
        }

        public static void HIK_SetTriggerDelaytoNumberic(MyHikCamera hikCamera, NumericUpDown edit)
        {
            edit.Value = 0;
            edit.Maximum = 0;
            edit.Minimum = 0;
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return;
            MyHikCamera.MVCC_FLOATVALUE floatValue = new MyHikCamera.MVCC_FLOATVALUE();
            int nRet = hikCamera.MV_CC_GetTriggerDelay_NET(ref floatValue);
            if (0 != nRet)
                return;
            edit.Maximum = (decimal)floatValue.fMax;
            edit.Minimum = (decimal)floatValue.fMin;
            edit.Value = (decimal)floatValue.fCurValue;
            edit.Enabled = true;

        }
        public static void Basler_SetFloatValueToNumberic(MyBaslerCamera baslerCamera, string paramName, NumericUpDown edit)
        {
            edit.Maximum = 0;
            edit.Minimum = 0;
            edit.Value = 0;
            if (baslerCamera == null || !baslerCamera.IsConnected)
                return;
            edit.Enabled = true;
            if (!baslerCamera.Parameters.Contains(new FloatName(paramName)))
            {
                if (paramName == cParamName.TriggerDelay)
                    paramName = cParamName.TriggerDelayAbs;
                else if (paramName == cParamName.ExposureTime)
                    paramName = cParamName.ExposureTimeAbs;
                else if (paramName == cParamName.AcquisitionLineRate)
                    paramName = cParamName.AcquisitionLineRateAbs;
                else if (paramName == cParamName.Gain)
                {
                    paramName = cParamName.GainAbs;
                    Basler_SetIntValueToNumberic(baslerCamera, paramName, edit);
                    return;
                }
                if (!baslerCamera.Parameters.Contains(new FloatName(paramName)))
                {
                    edit.Enabled = false;
                    return;
                }
            }
            IFloatParameter floatParameter = baslerCamera.Parameters[new FloatName(paramName)];
            edit.Maximum = (decimal)floatParameter.GetMaximum();
            edit.Minimum = (decimal)floatParameter.GetMinimum();
            edit.Value = (decimal)floatParameter.GetValue();
            edit.Enabled = floatParameter.IsWritable;


        }
        public static void Basler_SetIntValueToNumberic(MyBaslerCamera baslerCamera, string paramName, NumericUpDown edit)
        {
            edit.Maximum = 0;
            edit.Minimum = 0;
            edit.Value = 0;
            if (baslerCamera == null || !baslerCamera.IsConnected)
                return;
            edit.Enabled = true;
            if (!baslerCamera.Parameters.Contains(new IntegerName(paramName)))
            {
                edit.Enabled = false;
                return;
            }
            IIntegerParameter integerParameter = baslerCamera.Parameters[new IntegerName(paramName)];
            edit.Maximum = (decimal)integerParameter.GetMaximum();
            edit.Minimum = (decimal)integerParameter.GetMinimum();
            edit.Value = (decimal)integerParameter.GetValue();
            edit.Enabled = integerParameter.IsWritable;
        }
        public static void Basler_SetStringValueToCombobox(MyBaslerCamera baslerCamera, string paramName, ComboBox edit)
        {
            if (baslerCamera == null || !baslerCamera.IsConnected)
                return;
            edit.Enabled = true;
            if (!baslerCamera.Parameters.Contains(new StringName(paramName)))
            {
                if (paramName == cParamName.TriggerDelay)
                    paramName = cParamName.TriggerDelayAbs;
                else if (paramName == cParamName.ExposureTime)
                    paramName = cParamName.ExposureTimeAbs;
                else if (paramName == cParamName.AcquisitionLineRate)
                    paramName = cParamName.AcquisitionLineRateAbs;
                //else if (paramName == cParamName.Gain)
                //{
                //    paramName = cParamName.GainAbs;
                //    Basler_SetIntValueToNumberic(baslerCamera, paramName, edit);
                //    return;
                //}
                //if (!baslerCamera.Parameters.Contains(new FloatName(paramName)))
                //{
                //    edit.Enabled = false;
                //    return;
                //}
            }
            IStringParameter stringParameter = baslerCamera.Parameters[new StringName(paramName)];
            edit.Text = stringParameter.GetValue();
        }

        public static void Dahua_SetFloatValueToNumeric(MyDahuaCamera dahuaCamera, string paramName, NumericUpDown edit)
        {
            edit.Maximum = 0;
            edit.Minimum = 0;
            edit.Value = 0;
            edit.Enabled = true;

            if (dahuaCamera == null || !dahuaCamera.IsConnected)
            {
                edit.Enabled = false;
                return;
            }
            double value = 0;
            double maxValue = 0;
            double minValue = 0;
            int res = dahuaCamera.MySelf.IMV_GetDoubleFeatureMin(paramName, ref minValue);
            if (res != IMVDefine.IMV_OK)
                return;
            res = dahuaCamera.MySelf.IMV_GetDoubleFeatureMax(paramName, ref maxValue);
            if (res != IMVDefine.IMV_OK)
                return;
            res = dahuaCamera.MySelf.IMV_GetDoubleFeatureValue(paramName, ref value);
            if (res != IMVDefine.IMV_OK)
                return;
            edit.Minimum = (decimal)minValue;
            edit.Maximum = (decimal)maxValue;
            edit.Value = (decimal)value;
        }
        public static void Dahua_SetStringValueToCombobox(MyDahuaCamera dahuaCamera, string paramName, ComboBox edit)
        {
            edit.Text = string.Empty;
            edit.Items.Clear();
            edit.Enabled = false;

            if (dahuaCamera == null || !dahuaCamera.IsConnected)
                return;
            // get all Image Pixel Format
            uint nEntryNum = 0;
            ulong currentValue = 0;
            IMVDefine.IMV_EnumEntryList valueList = new IMVDefine.IMV_EnumEntryList();
            int res = dahuaCamera.MySelf.IMV_GetEnumFeatureEntryNum(paramName, ref nEntryNum);
            if (res != IMVDefine.IMV_OK)
            {
                if (paramName == cParamName.TriggerActivation)
                    paramName = cParamName.TimerTriggerActivation;
                res = dahuaCamera.MySelf.IMV_GetEnumFeatureEntryNum(paramName, ref nEntryNum);
                if (res != IMVDefine.IMV_OK)
                    return;
            }

            valueList.nEnumEntryBufferSize = (uint)Marshal.SizeOf(typeof(IMVDefine.IMV_EnumEntryInfo)) * nEntryNum;
            valueList.pEnumEntryInfo = Marshal.AllocHGlobal((int)valueList.nEnumEntryBufferSize);
            if (valueList.pEnumEntryInfo == IntPtr.Zero)
                return;
            res = dahuaCamera.MySelf.IMV_GetEnumFeatureEntrys(paramName, ref valueList);
            if (res != IMVDefine.IMV_OK)
                return;
            res = dahuaCamera.MySelf.IMV_GetEnumFeatureValue(paramName, ref currentValue);
            for (int i = 0; i < nEntryNum; i++)
            {
                IMVDefine.IMV_EnumEntryInfo entryInfo = (IMVDefine.IMV_EnumEntryInfo)Marshal.PtrToStructure(valueList.pEnumEntryInfo + Marshal.SizeOf(typeof(IMVDefine.IMV_EnumEntryInfo)) * i,
                    typeof(IMVDefine.IMV_EnumEntryInfo));
                edit.Items.Add(entryInfo.name);
                if (currentValue == entryInfo.value)
                    edit.SelectedIndex = i;
            }

            if (valueList.pEnumEntryInfo != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(valueList.pEnumEntryInfo);
                valueList.pEnumEntryInfo = IntPtr.Zero;
            }
            edit.Enabled = true;
        }
        #endregion
        #endregion


        private const int WM_SETREDRAW = 11;
        /// <summary>
        /// Suspends painting for the target control. Do NOT forget to call EndControlUpdate
        /// </summary>
        /// <param name="control"></param>
        public static void BeginControlUpdate(Control control)
        {
            Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgSuspendUpdate);
        }

        public static void EndControlUpdate(Control control)
        {
            try
            {

                IntPtr wparam = new IntPtr(1);
                Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam, IntPtr.Zero);
                NativeWindow window = NativeWindow.FromHandle(control.Handle);
                window.DefWndProc(ref msgResumeUpdate);
                control.Invalidate();
                control.Refresh();

            }
            catch
            {

            }
        }


        public static void ReadAppInfo()
        {
            GlobVar.RTCVision = new cSystemTypes();
            GlobVar.RTCVision.ReadIniConfig();
            GlobVar.DeepCopyFileName = Path.GetTempFileName();
            try
            {

            }
            catch (Exception)
            {

            }

        }


        /// <summary>
        /// Chuyển từ có dấu sang không dấu
        /// </summary>
        /// <param name="_Text"></param>
        /// <returns></returns>
        public static string SwitchToUnsigned(string _Text)
        {
            string[] CoDau = new[]
            {
                "aàáảãạăằắẳẵặâầấẩẫậ", "AÀÁÃẢẠĂẰẮẴẲẶÂẦẤẪẨẬ", "đ", "Đ", "eèéẽẻẹêềếễểệ", "EÈÉẼẺẸÊỀẾỄỂỆ", "iìíĩỉị",
                "IÌÍĨỈỊ", "oòóõỏọôồốỗổộơờớỡởợ", "OÒÓÕỎỌÔỒỐỖỔỘƠỜỚỠỞỢ", "uùúũủụưừứữửự", "UÙÚŨỦỤƯỪỨỮỬỰ", "yỳýỹỷỵ", "YỲÝỸỶỴ"
            };
            string[] KoDau = new[] { "a", "A", "d", "D", "e", "E", "i", "I", "o", "O", "u", "U", "y", "Y" };
            string str = _Text;
            string strReturn = "";
            for (int i = 0; i <= str.Length - 1; i++)
            {
                string iStr = str.Substring(i, 1);
                string rStr = iStr;
                for (int j = 0; j <= CoDau.Length - 1; j++)
                {
                    if (CoDau[j].IndexOf(iStr) >= 0)
                    {
                        rStr = KoDau[j];
                        break;
                    }
                }
                strReturn += rStr;
            }
            return strReturn;
        }

        private static Random random = new Random();
        /// <summary>
        /// Build 1 chuỗi ngẫu nhiên với độ dài thiết lập trong file config, độ dài nhỏ nhất là 3
        /// </summary>
        /// <returns></returns>
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, GlobVar.RTCVision.Options.RandomStringLenght).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Xóa các kí tự đặc biệt khỏi chuỗi
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string str)
        {
            string newStr = str;
            foreach (char c in Path.GetInvalidFileNameChars())
                newStr = newStr.Replace(c, '_');
            return newStr;
        }

        internal static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files width the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        public static Guid GetDataRowValue_Guid(DataRow _Row, string _ColName)
        {
            Guid Result = Guid.Empty;
            if (_Row == null) return Result;
            if (!Guid.TryParse(_Row[_ColName].ToString(), out Result)) Result = Guid.Empty;
            return Result;
        }

        public static string GetDataRowValue_String(DataRow row, string colName)
        {
            if (row == null) return string.Empty;
            return row[colName].ToString();
        }
        public static bool GetDataRowValue_Boolean(DataRow _Row, string _ColName)
        {
            bool Result = false;
            if (_Row == null) return Result;
            if (!bool.TryParse(_Row[_ColName].ToString(), out Result)) Result = false;
            return Result;
        }
        public static int GetDataRowValue_Int(DataRow _Row, string _ColName)
        {
            int Result = 0;
            if (_Row == null) return Result;
            if (!int.TryParse(_Row[_ColName].ToString(), out Result)) Result = 0;
            return Result;
        }
        public static long GetDataRowValue_Log(DataRow _Row, string _ColName)
        {
            long Result = -1;
            if (_Row == null) return Result;
            if (!long.TryParse(_Row[_ColName].ToString(), out Result)) Result = -1;
            return Result;
        }
        public static void ResizeImage(PictureBox pictureBox)
        {
            float ratio = Math.Min((float)pictureBox.Width / pictureBox.Image.Width, (float)pictureBox.Height / pictureBox.Image.Height);
            int newWidth = (int)(pictureBox.Image.Width * ratio);
            int newHeight = (int)(pictureBox.Image.Height * ratio);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(pictureBox.Image, 0, 0, newWidth, newHeight);
            }
            pictureBox.Image = newImage;
        }
        //public static void ResizeImage(PictureBox pictureBox)
        //{
        //    if (pictureBox.Image != null)
        //    {
        //        // Lấy kích thước thực tế của PictureBox
        //        float targetWidth = pictureBox.Width;
        //        float targetHeight = pictureBox.Height;

        //        // Lấy kích thước ban đầu của hình ảnh
        //        float originalWidth = pictureBox.Image.Width;
        //        float originalHeight = pictureBox.Image.Height;

        //        // Tính tỷ lệ giữa chiều rộng và chiều cao của hình ảnh ban đầu
        //        float ratio = (float)originalWidth / originalHeight;

        //        // Tính toán kích thước mới dựa trên chiều dài hoặc chiều rộng của PictureBox (tùy thuộc vào tỷ lệ của hình ảnh ban đầu)
        //        if (targetWidth / ratio <= targetHeight)
        //        {
        //            targetHeight = (float)(targetWidth / ratio);
        //        }
        //        else
        //        {
        //            targetWidth = (float)(targetHeight * ratio);
        //        }

        //        // Tạo một Bitmap mới với kích thước đã được điều chỉnh
        //        Bitmap resizedImage = new Bitmap((int)targetWidth, (int)targetHeight);

        //        // Sử dụng Graphics để vẽ hình ảnh mới vào Bitmap đã tạo
        //        using (Graphics g = Graphics.FromImage(resizedImage))
        //        {
        //            // Chọn chất lượng vẽ (có thể điều chỉnh nếu cần)
        //            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //            g.DrawImage(pictureBox.Image, 0, 0, targetWidth, targetHeight);
        //        }

        //        // Hiển thị hình ảnh đã điều chỉnh trong PictureBox
        //        pictureBox.Image = resizedImage;
        //    }

        //}
        public static double GetDataRowValue_Double(DataRow _Row, string _ColName)
        {
            double Result = 0;
            if (_Row == null) return Result;
            if (!double.TryParse(_Row[_ColName].ToString(), out Result)) Result = 0;
            return Result;
        }
        public static decimal GetDataRowValue_Decimal(DataRow _Row, string _ColName)
        {
            decimal Result = 0;
            if (_Row == null) return Result;
            if (!decimal.TryParse(_Row[_ColName].ToString(), out Result)) Result = 0;
            return Result;
        }

        public static List<string> String2ListString(string _Value, char _Sep)
        {
            string[] s = _Value.Split(_Sep);
            List<string> obj = new List<string>();
            obj.AddRange(s);
            return obj;
        }
        public static List<Guid> String2ListGuid(string _Value, char _Sep)
        {
            string[] s = _Value.Split(_Sep);
            List<Guid> obj = new List<Guid>();
            foreach (string item in s)
            {
                if (Guid.TryParse(item, out Guid gValue))
                    obj.Add(gValue);
            }
            return obj;
        }

        public static bool BackupFile(string fileName, string backupFileName)
        {
            try
            {
                if (!File.Exists(fileName) || string.IsNullOrEmpty(backupFileName))
                    return false;
                File.Copy(fileName, backupFileName, true);
                File.SetAttributes(backupFileName, File.GetAttributes(backupFileName) | FileAttributes.Hidden);

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Hàm lưu lỗi ra file html
        /// </summary>
        /// <param name="ErrMsg">Nội dung lỗi</param>
        /// <param name="moreInfo">Nội dung bổ sung</param>
        public static void SaveErr(string ErrMsg, string moreInfo = "")
        {
            GlobVar.Error?.SaveError(new Exception(ErrMsg));
        }
        public static void SaveErr(Exception exception, string AMoreInfo = "")
        {
            GlobVar.Error?.SaveError(exception);
            //if (GlobVar.RTCVision.ErrorOptions.IsSaveError)
            //    GlobVar.ErrHandle.SaveErrors(AEx, GlobVar.RTCVision.OSInfo.FullInfo, AMoreInfo);
        }
        public static List<string> GetDirectories(string path, string searchPatterm = "*",
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            if (searchOption == SearchOption.TopDirectoryOnly)
                return Directory.GetDirectories(path, searchPatterm).ToList();

            var directories = new List<string>(GetDirectories(path, searchPatterm));

            for (var i = 0; i < directories.Count; i++)
                directories.AddRange(GetDirectories(directories[i], searchPatterm));

            return directories;
        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        internal static void DisposeImage(Image Image, bool genEmptyObj = false)
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }
        }
        /// <summary>
        /// Set ảnh chi wun
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Window"></param>
        public static void SmartSetPart(Image Image, GraphicsWindow.GraphicsWindow Window)
        {

            if (Image == null)
                return;
            int imgRow;
            Window.Image = Image;
        }

        public static string BuildRefString2(cGroupActions groupActions, cAction action, string propertyName)
        {
            if (action == null) return string.Empty;
            if (action.ObjectType == EObjectTypes.Group)
            {
                return string.Join(".", "[" + action.Name.rtcValue + (propertyName == string.Empty ? "" : ":" + propertyName) + "]");
            }
            else
            {
                return string.Join(".", "[" + groupActions.Name.rtcValue, action.Name.rtcValue + (propertyName == string.Empty ? "" : ":" + propertyName) + "]");
            }
        }
        public static ENodeTypes GetNodeType(ActionTools node, ColumnHeader NodeTypeColumn)
        {
            if (node == null)
                return ENodeTypes.None;
            ENodeTypes eNodeTypes;

            try
            {
                eNodeTypes = (ENodeTypes)node.NodeType;
            }
            catch
            {
                eNodeTypes = ENodeTypes.None;
            }
            return eNodeTypes;
        }
        public static ENodeTypes GetNodePropertyType(MyPropertiesItem node, ColumnHeader NodeTypeColumn)
        {
            if (node == null)
                return ENodeTypes.None;
            ENodeTypes eNodeTypes;

            try
            {
                eNodeTypes = (ENodeTypes)node.NodeType;
            }
            catch
            {
                eNodeTypes = ENodeTypes.None;
            }
            return eNodeTypes;
        }

        public static string Object2Str(object _object)
        {
            string Result = string.Empty;

            if (_object == null)
                return Result;
            var test = _object.GetType().Name;
            if (_object != null)
                switch (_object.GetType().Name)
                {
                    case "String":
                        Result = _object.ToString();
                        break;
                    case "Int":
                        Result = _object.ToString();
                        break;
                    case "Int32":
                        Result = _object.ToString();
                        break;
                    case "Int64":
                        Result = _object.ToString();
                        break;
                    case nameof(Double):
                        Result = _object.ToString();
                        break;
                    case nameof(Boolean):
                        Result = _object.ToString().ToLower();
                        break;
                    case "SString":
                        Result = ((SString)_object).rtcValue;
                        break;
                        //case "List`1":
                        //    Result = ((SListDouble)_object).rtcValue;
                        break;

                    default:
                        break;
                }
            return Result;
        }
        public static Dictionary<long, RTCRectangle> GenShapeList(SListObject ShapeList)
        {
            Dictionary<long, RTCRectangle> Value = new Dictionary<long, RTCRectangle>();
            for (int Index = 0; Index < ShapeList.rtcValue.Count; Index += GlobVar.ShapeListCount)
            {
                double Row = Lib.Object2Double(ShapeList.rtcValue[Index + 0]);
                double Column = Lib.Object2Double(ShapeList.rtcValue[Index + 1]);
                double PhiFind = Lib.Object2Double(ShapeList.rtcValue[Index + 2]);
                double Width = Lib.Object2Double(ShapeList.rtcValue[Index + 3]);
                double Height = Lib.Object2Double(ShapeList.rtcValue[Index + 4]);
                EConnectTypes ConnectType = (EConnectTypes)(int)(ShapeList.rtcValue[Index + 6]);

                long key = Lib.Object2Long(ShapeList.rtcValue[Index + 8]);
                EDrawingtypes DrawingType = (EDrawingtypes)(int)(ShapeList.rtcValue[Index + 5]);
                switch (DrawingType)
                {
                    case EDrawingtypes.Rectang:
                        {
                            RTCRectangle Data = new RTCRectangle();
                            Data.Phi = (float)PhiFind * Math.PI / 180;
                            Data.Width = (float)Width * 2;
                            Data.Height = (float)Height * 2;
                            Data.Center = new RTCPoint(Row, Column, 0);
                            Data.ConnectType = ConnectType;
                            Value.Add(key, Data);
                            //SmartWindow.DrawROI(DataRoi);
                            break;
                        }
                    case EDrawingtypes.Ellipse:
                        {
                            RTCRectangle Data = new RTCRectangle();
                            Data.Phi = (float)PhiFind * Math.PI / 180;
                            Data.Width = (float)Width * 2;
                            Data.Height = (float)Height * 2;
                            Data.Center = new RTCPoint(Row, Column, 0);
                            Data.ConnectType = ConnectType;
                            Value.Add(key, Data);
                            //SmartWindow.DrawROI(DataRoi);
                            break;
                        }
                }
            }
            return Value;
        }
        public static int[] Ve2ArrayInt(List<string> Value)
        {
            if (Value == null || Value.Count <= 0)
                return new int[] { };
            List<int> list = new List<int>();
            for (int i = 0; i < Value.Count; i++)
            {
                //string value = Ve2Str(Value[i]);
                if (int.TryParse(Value[i], out int iValue))
                    list.Add(iValue);
            }

            return list.ToArray();
        }
        public static bool[] Ve2ArrayBool(List<object> _value)
        {
            List<bool> result = new List<bool>();

            if (_value == null || _value.Count <= 0)
                return new bool[] { };

            for (int i = 0; i < _value.Count; i++)
            {
                string value = Ve2Str(_value[i]);
                if (bool.TryParse(value, out bool bValue))
                    result.Add(bValue);
                else
                    result.Add(false);
            }

            return result.ToArray();
        }
        public static bool Object2Bool(object @object, bool @default = false)
        {
            if (@object == null)
                return @default;
            if (bool.TryParse(@object.ToString(), out bool result))
                return result;
            return @default;
        }
        public static Guid Object2Guid(object @object, Guid @default)
        {
            if (@object == null)
                return @default;
            if (Guid.TryParse(@object.ToString(), out Guid result))
                return result;
            return @default;
        }
        public static string Ve2StrWithoutComma(List<object> hTuple, int elementnumber = -1)
        {
            if (hTuple == null || hTuple.Count <= 0)
                return string.Empty;
            string Result = string.Empty;
            int _elementnumber = elementnumber == -1 ? hTuple.Count : elementnumber;
            for (int i = 0; i < _elementnumber; i++)
            {
                if (Result == string.Empty)
                    Result = Ve2Str(hTuple[i]);
                else
                    Result = Result + Ve2Str(hTuple[i]);
            }

            return Result;
        }
        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: return "";
                case "": return "";
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        internal static void SetLabelControlText(Label Label, string text, bool isRefesh = false)
        {
            if (Label.InvokeRequired)
                Label.Invoke(new Action(() =>
                {
                    Label.Text = text;
                    if (isRefesh)
                        Label.Refresh();
                }));
            else
            {
                Label.Text = text;
                if (isRefesh)
                    Label.Refresh();
            }
        }
        internal static void SetRichTextBox(RichTextBox Label, string text, bool isRefesh = false)
        {
            if (Label.InvokeRequired)
                Label.Invoke(new Action(() =>
                {
                    Label.Text = text;
                    if (isRefesh)
                        Label.Refresh();
                }));
            else
            {
                Label.Text = text;
                if (isRefesh)
                    Label.Refresh();
            }
        }

        public static void EnableControl(Control control, bool enable)
        {
            if (control.InvokeRequired)
                control.Invoke((MethodInvoker)delegate { control.Enabled = enable; });
            else control.Enabled = enable;
        }
        public static void VisibleControl(Control control, bool visible)
        {
            if (control.InvokeRequired)
                control.Invoke((MethodInvoker)delegate { control.Visible = visible; });
            else control.Visible = visible;
        }
        public static void VisibleControl(ToolStripMenuItem control, bool visible)
        {
            control.Visible = visible;
        }
        public static void VisibleControl(ToolStripSeparator control, bool visible)
        {
            control.Visible = visible;
        }
        public static IEnumerable<Control> GetAll(Control control, Type type, bool withRTCprefix = true)
        {
            var controls = control.Controls.Cast<Control>();
            if (withRTCprefix)
            {
                return controls.SelectMany(ctrl => GetAll(ctrl, type, withRTCprefix))
                    .Concat(controls)
                    .Where(c => c.GetType() == type && c.Name.StartsWith("RTC"));
            }
            else
                return controls.SelectMany(ctrl => GetAll(ctrl, type, withRTCprefix))
                    .Concat(controls)
                    .Where(c => c.GetType() == type && !c.Name.StartsWith("RTC"));
        }
        public static IEnumerable<Control> GetAll(Control control, Type type, string name, bool autoaddRTCprefix = true)
        {
            var controls = control.Controls.Cast<Control>();
            string _name = autoaddRTCprefix ? cStrings.RTC + name : name;
            return controls.SelectMany(ctrl => GetAll(ctrl, type, name, autoaddRTCprefix))
                .Concat(controls)
                .Where(c => c.GetType() == type && c.Name == _name);

        }
        public static IEnumerable<Control> GetAll(Control control, string propertyName, bool isUseRTCprefix = true)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, propertyName, isUseRTCprefix))
                .Concat(controls)
                .Where(c => c.Name == (isUseRTCprefix ? cStrings.RTC : "") + propertyName);

        }
        public static void ShowFormASCIITable(TextBox _TextBoxSetValue)
        {
            FrmASCIITable frmASCIITable = new FrmASCIITable();
            frmASCIITable.RTCTexEditSetValue = _TextBoxSetValue;
            Point locationOnForm = _TextBoxSetValue.FindForm().PointToClient(
                _TextBoxSetValue.Parent.PointToScreen(_TextBoxSetValue.Location));
            Rectangle screenRectangle = frmASCIITable.RectangleToScreen(frmASCIITable.ClientRectangle);

            int titleHeight = screenRectangle.Top - frmASCIITable.Top;

            frmASCIITable.Left = locationOnForm.X - frmASCIITable.Width;
            frmASCIITable.Top = locationOnForm.Y - frmASCIITable.Height + titleHeight + _TextBoxSetValue.Height / 2 +
                                1;
            if (frmASCIITable.Top < 0) frmASCIITable.Top = 0;
            if (frmASCIITable.Left < 0) frmASCIITable.Left = 0;

            frmASCIITable.ShowDialog();
        }

        public static void EnableTransparency(Control c, bool isSetDefaultForceColor = true)
        {
            MethodInfo method = c.GetType().GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(c,
                new object[]
                {
                    ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true
                });
            c.BackColor = Color.Transparent;
            if (isSetDefaultForceColor)
                c.ForeColor = Color.Black;
        }
        internal static int SVersionToIVersion(string version)
        {
            if (!string.IsNullOrEmpty(version))
                version = version.Replace(".", "");
            if (int.TryParse(version, out int iVersion))
                return iVersion;
            return -1;
        }

        public static string BuildRefString_Property_PropName(cGroupActions GroupActions, cAction sourceAction,
           string propSourceName)
        {
            if (sourceAction == null) return string.Empty;
            if (sourceAction.ObjectType == EObjectTypes.Group)
            {
                return string.Join(".",
                    "[" + sourceAction.Name.rtcValue + ":" + propSourceName + "]");
            }
            else
            {
                return string.Join(".", "[" + GroupActions.Name.rtcValue,
                    sourceAction.Name.rtcValue + ":" + propSourceName + "]");
            }
        }
        public static EPropertyState GetNodeState(MyPropertiesItem Node, OLVColumn NodeStateColumn)
        {
            if (Node == null)
            {
                return EPropertyState.None;
            }
            EPropertyState eNodeState;
            try
            {
                var test = NodeStateColumn.AspectName;
                eNodeState = (EPropertyState)NodeStateColumn.GetValue(Node);
            }
            catch
            {
                eNodeState = EPropertyState.None;
            }
            return eNodeState;
        }
        public static EPropertyState GetPropertyNodeState(MyPropertiesItem Node, OLVColumn NodeStateColumn)
        {
            if (Node == null)
            {
                return EPropertyState.None;
            }
            EPropertyState eNodeState;
            try
            {
                var test = NodeStateColumn.AspectName;
                eNodeState = (EPropertyState)NodeStateColumn.GetValue(Node);
            }
            catch
            {
                eNodeState = EPropertyState.None;
            }
            return eNodeState;
        }
        public static List<double> Str2DoubleArr(string sValue, char separator = cStrings.SepPhay)
        {
            List<double> result = new List<double>();
            string[] values = sValue.Split(separator);

            foreach (var t in values)
            {
                if (double.TryParse(t, out double dValue))
                    result.Add(dValue);
                else
                    result.Add(0);
            }
            return result;
        }

        public static List<string> Str2StringArr(string _Value, char _SEP = cStrings.SepPhay)
        {
            List<string> Result = new List<string>();
            string[] _Values = _Value.Split(_SEP);
            for (int i = 0; i < _Values.Length; i++)
            {
                Result.Add(_Values[i]);
            }
            return Result;
        }
        public static List<object> Str2StringObj(string _Value, char _SEP = cStrings.SepPhay)
        {
            List<object> Result = new List<object>();
            string[] _Values = _Value.Split(_SEP);
            for (int i = 0; i < _Values.Length; i++)
            {
                Result.Add(_Values[i]);
            }
            return Result;
        }
        public static List<object> Str2StringObj(string _Value, string _SEP)
        {
            return Str2StringObj(_Value);
        }


        public static bool IsNumeric(string _sNeedCheck)
        {
            return double.TryParse(_sNeedCheck, out double _dNeedCheck);
        }
        public static double GetPercent(int value, int total)
        {
            if (total == 0 || value == 0)
                return 0;
            double percent = (double)value / (double)total;
            percent = percent * 100;
            return Math.Round(percent, 2);
        }
        public static bool IsInt(string _sNeedCheck)
        {
            return int.TryParse(_sNeedCheck, out int _dNeedCheck);
        }

        public static long GetDataRowValue_Long(DataRow _Row, string _ColName)
        {
            long Result = -1;
            if (_Row == null) return Result;
            if (!long.TryParse(_Row[_ColName].ToString(), out Result)) Result = -1;
            return Result;
        }
        public static long ConvertGuidToLong(Guid guid)
        {
            byte[] bytes = guid.ToByteArray();

            // Nếu kiểu long có 8 byte, thì chuyển 8 byte đầu tiên thành giá trị long
            // Nếu kiểu long có 7 byte, hãy chỉ sử dụng 7 byte đầu tiên và bỏ qua byte thứ 8
            // Nếu có kiểu long khác, bạn có thể điều chỉnh tùy thuộc vào kích thước mong muốn
            long result = BitConverter.ToInt64(bytes, 0);

            return result;
        }
        public static Guid ConvertLongToGuid(long longValue)
        {
            byte[] bytes = BitConverter.GetBytes(longValue);

            // Đảm bảo rằng mảng bytes có đúng 16 bytes để tạo một Guid
            byte[] guidBytes = new byte[16];
            Array.Copy(bytes, guidBytes, Math.Min(bytes.Length, 16));

            return new Guid(guidBytes);
        }
        public static void SetDefaultValue(object objectNeedSetDefaultValue)
        {
            if (objectNeedSetDefaultValue != null)
            {
                switch (objectNeedSetDefaultValue.GetType().Name)
                {
                    case nameof(SString):
                        {
                            ((SString)objectNeedSetDefaultValue).rtcValue = string.Empty;
                            break;
                        }
                    case nameof(SInt):
                        {
                            ((SInt)objectNeedSetDefaultValue).rtcValue = 0;
                            break;
                        }
                    case nameof(SDouble):
                        {
                            ((SDouble)objectNeedSetDefaultValue).rtcValue = 0;
                            break;
                        }
                    case nameof(SBool):
                        {
                            ((SBool)objectNeedSetDefaultValue).rtcValue = false;
                            break;
                        }
                    case nameof(SLong):
                        {
                            ((SLong)objectNeedSetDefaultValue).rtcValue = 0;
                            break;
                        }
                    case nameof(SListDouble):
                        {
                            ((SListDouble)objectNeedSetDefaultValue).rtcValue = new List<double>() { };
                            break;
                        }
                    case nameof(SListString):
                        {
                            ((SListString)objectNeedSetDefaultValue).rtcValue = new List<string>() { };
                            break;
                        }
                    case nameof(SListObject):
                        {
                            ((SListObject)objectNeedSetDefaultValue).rtcValue = new List<object>() { };
                            break;
                        }
                    case nameof(SImage):
                        {
                            ((SImage)objectNeedSetDefaultValue).rtcValue = RTC_Vision_Lite.Properties.Resources.Default;
                            break;
                        }

                }
            }
        }
        public static List<Point> ListDoubleToListPoint(List<double> listDouble)
        {
            List<Point> listPoint = new List<Point>();
            for (int i = 0; i < listDouble.Count; i = i + 2)
            {
                listPoint.Add(new Point((int)listDouble[i], (int)listDouble[i + 1]));
            }
            return listPoint;
        }
        public static List<PointF[]> ListDoubleToListPointF(List<double> listDouble)
        {
            List<PointF[]> listPoint = new List<PointF[]>();
            PointF[] pROI = new PointF[4];
            int j = 0;
            for (int i = 0; i < listDouble.Count; i += 2)
            {
                pROI[j] = new PointF((float)listDouble[i], (float)listDouble[i + 1]);
                j++;
                if (j == 4)
                {
                    listPoint.Add(pROI);
                    j = 0;
                    pROI = new PointF[4];

                }
            }
            return listPoint;
        }
        public static List<double> ListPointFToListDouble(List<PointF[]> listPointF)
        {
            List<double> listDouble = new List<double>();
            foreach (PointF[] pointArray in listPointF)
            {
                foreach (PointF point in pointArray)
                {
                    listDouble.Add(point.X);
                    listDouble.Add(point.Y);
                }
            }
            return listDouble;
        }
        public static List<double> ListPointToListDouble(List<Point> ListPoint)
        {
            List<double> listDouble = new List<Double>();
            for (int i = 0; i < ListPoint.Count; i++)
            {
                listDouble.Add(ListPoint[i].X);
                listDouble.Add(ListPoint[i].Y);
            }
            return listDouble;
        }
        public static List<double> ListPointFToListDouble(List<PointF> ListPoint)
        {
            List<double> listDouble = new List<Double>();
            for (int i = 0; i < ListPoint.Count; i++)
            {
                listDouble.Add(ListPoint[i].X);
                listDouble.Add(ListPoint[i].Y);
            }
            return listDouble;
        }
        public static List<double> GetHTupleFromHTupleSaveData(string value)
        {
            List<double> hTuple = new List<double>();
            if (value != "")
            {
                string[] values = value.Split(cStrings.SepGDung);
                if (values.Length != 2)
                    return hTuple;
                else
                    hTuple = GlobFuncs.Str2DoubleArr(values[0]);
            }
            return hTuple;
        }
        public static bool HIK_GetFloatValue(MyHikCamera hikCamera, string paramName, ref MyHikCamera.MVCC_FLOATVALUE floatValue)
        {
            floatValue = new MyHikCamera.MVCC_FLOATVALUE();
            if (hikCamera == null || hikCamera.GetCameraHandle() == IntPtr.Zero)
                return false;
            int nRet = hikCamera.MV_CC_GetFloatValue_NET(paramName, ref floatValue);
            if (0 == nRet)
                return true;
            else
            {
                floatValue = new MyHikCamera.MVCC_FLOATVALUE();
                return false;
            }
        }
        internal static void ViewApplicationSettings()
        {
            //if(GlobVar.RTCVision.SecurityOptions.SecurityModes == cSecurityModes.SecurityModes_UseAccount)
            //{
            //    if(!cUser.Show)
            //}
            FrmSettings _frmSettings = new FrmSettings();
            _frmSettings.Settings = GlobFuncs.Clone(GlobVar.RTCVision);
            _frmSettings.ShowDialog();

            bool areEqual = System.Object.ReferenceEquals(_frmSettings.Settings, GlobVar.RTCVision);
            if (!areEqual)
            {
                GlobVar.RTCVision = GlobFuncs.Clone(_frmSettings.Settings);
                GlobVar.FormMain.ShowLogo();
                GlobVar.FormMain.ShowMainCounter();
                if (_frmSettings.IsChangeLayoutCam)
                    GlobVar.FormMain.ShowProjectCAMToLayoutControl();
                if (GlobVar.CurrentProject != null)
                    foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                    {
                        cam.View.RebuildWindow();
                    }
                GlobVar.RTCVision.SaveIniConfig();
                GlobVar.FrmActions?.ucTemplateTools.UpdateFont();
                GlobVar.FrmActions?.ucActionList.UpdateFont();
                GlobVar.RTCVision.SaveIniConfig();
            }
            else if (_frmSettings.IsChangeViewStyleResultLabelOkNg)
            {
                if (GlobVar.CurrentProject != null)
                    foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                        cam.View.RebuildWindow();
            }
            else if (_frmSettings.IsChangeViewStyleFormActions)
            {
                GlobVar.FrmActions?.ucTemplateTools.UpdateFont();
                GlobVar.FrmActions?.ucActionList.UpdateFont();
            }
        }
        public static T Clone<T>(T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);

        }
        public static string[] GetValuesFromValueView(string _sValue)
        {
            if (_sValue.Contains(cStrings.Point))
                _sValue = _sValue.Substring(_sValue.IndexOf("["));

            if (_sValue.Contains(cStrings.Items))
                _sValue = _sValue.Substring(_sValue.IndexOf("["));
            _sValue = _sValue.Replace("[", "");
            _sValue = _sValue.Replace("]", "");
            _sValue = _sValue.Replace("Limit =", "");
            _sValue = _sValue.Replace("°", "");
            _sValue = _sValue.Replace("(", "");
            _sValue = _sValue.Replace(")", "");

            _sValue = _sValue.TrimStart();
            _sValue = _sValue.TrimEnd();
            return _sValue.Split(cStrings.SepPhay);
        }
        public static double ExtractNumberOfString(string str, int mode, double defaultnumber = -1,
            bool isgetdecimaseparator = false, string decimaseparator = ",")
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                return defaultnumber;
            int ivalue = 0;
            string decimaseparatorculture =
                System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            StringBuilder sbValue = new StringBuilder();
            bool ishavedecimaseparator = false;
            switch (mode)
            {
                case 0:
                    foreach (char item in str)
                    {
                        if (int.TryParse(item.ToString(), out ivalue))
                            sbValue.Append(ivalue);
                        else if (isgetdecimaseparator && item.ToString() == decimaseparator && !ishavedecimaseparator)
                        {
                            sbValue.Append(item);
                            ishavedecimaseparator = true;
                        }
                    }


                    break;
                case 1:
                    foreach (char item in str)
                    {
                        if (int.TryParse(item.ToString(), out ivalue))
                            sbValue.Append(ivalue);
                        else if (isgetdecimaseparator && item.ToString() == decimaseparator)
                            sbValue.Append(item);
                    }

                    break;
                case 2:
                    foreach (char item in str)
                    {
                        if (int.TryParse(str[0].ToString(), out ivalue))
                            sbValue.Append(ivalue);
                        else if (isgetdecimaseparator && item.ToString() == decimaseparator)
                            sbValue.Append(item);
                    }

                    break;
                case 3:
                    if (int.TryParse(str[0].ToString(), out ivalue))
                        return ivalue;
                    break;
                case 4:
                    if (int.TryParse(str[str.Length - 1].ToString(), out ivalue))
                        return ivalue;
                    break;
                default:
                    break;
            }
            if (sbValue.Length > 0)
                if (double.TryParse(sbValue.ToString(), out double dValue))
                    return dValue;
            return defaultnumber;
        }
        public static bool CreateFolder(string folderName, out string errMessage)
        {
            errMessage = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(folderName.Trim()))
                {
                    return false;
                }
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);
                return true;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;

            }
        }
        public static bool CreateFolder(string folderName)
        {
            try
            {
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal static bool SetupEnvironment()
        {
            /* KHỞI TẠO MÔI TRƯỜNG SERVER NẾU CÓ */
            if (GlobVar.RTCVision.Options.IsServer)
            {
                GlobVar.SocketServer = new CSocketServer();
                GlobVar.SocketServer.Start();
            }

            /* Lấy thông tin ICON chương trình */
            if (File.Exists(GlobVar.RTCVision.Files.RTCIco))
            {
                try
                {
                    GlobVar.RTCIcon = Icon.ExtractAssociatedIcon(GlobVar.RTCVision.Files.RTCIco);
                }
                catch
                {
                    GlobVar.RTCIcon = Resources.RTCIcon;
                }
            }
            GlobVar.ProgramName = $"{GlobVar.RTCVision.ViewOptions.ProgramName} {GlobVar.Version}";
            /* KHỞI TẠO DỮ LIỆU ASCII */
            GenerateDicASCII();
            if (GlobVar.RTCVision.SWindowOptions.FontCamDisplay == string.Empty ||
                GlobVar.RTCVision.SWindowOptions.FontName == string.Empty ||
                GlobVar.RTCVision.SWindowOptions.FontLink == string.Empty)
                InitDefaultFont();
                            
            GlobVar.Log = new cLog();
            GlobVar.Error = new cError();

            ConfigUILogging();

            return true;
        }
        private static void InitDefaultFont()
        {
            GlobVar.RTCVision.SWindowOptions.FontCamDisplay = GlobVar.HsmartWindowFonts[0] + "-Normal-16";
            GlobVar.RTCVision.SWindowOptions.FontName = GlobVar.HsmartWindowFonts[0] + "-Normal-20";
            GlobVar.RTCVision.SWindowOptions.FontLink = GlobVar.HsmartWindowFonts[0] + "-Normal-16";
        }
        public static void AddROIToShapeList(object item, SListObject shapeList, int type)
        {
            cDrawingBaseType Normal = (cDrawingBaseType)item;
            switch (Normal.DrawingType)
            {
                case EDrawingtypes.Rectang:
                    {
                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cRectangType)item).Phi);
                        shapeList.rtcValue.Add(((cRectangType)item).Width);
                        shapeList.rtcValue.Add(((cRectangType)item).Height);
                        shapeList.rtcValue.Add((int)Normal.DrawingType);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);
                        break;
                    }
                case EDrawingtypes.Rectang1:
                    {
                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cRectangType)item).Phi);
                        shapeList.rtcValue.Add(((cRectangType)item).Width);
                        shapeList.rtcValue.Add(((cRectangType)item).Height);
                        shapeList.rtcValue.Add((int)Normal.DrawingType);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);
                        break;
                    }
                case EDrawingtypes.Ellipse:
                    {
                        shapeList.rtcValue.Add(Normal.Center.Row);
                        shapeList.rtcValue.Add(Normal.Center.Col);
                        shapeList.rtcValue.Add(((cEllipseType)item).Phi);
                        shapeList.rtcValue.Add(((cEllipseType)item).Radius1);
                        shapeList.rtcValue.Add(((cEllipseType)item).Radius2);
                        shapeList.rtcValue.Add((int)Normal.DrawingType);
                        shapeList.rtcValue.Add((int)Normal.ConnectType);
                        shapeList.rtcValue.Add(type);
                        shapeList.rtcValue.Add(Normal.ID);
                        shapeList.rtcValue.Add(Normal.Name);
                        break;
                    }
            }
        }
        internal static void AddValueToHTupleWittAutoDetectType(ref List<object> value, string input)
        {
            if (value == null)
                value = new List<object>();

            if (int.TryParse(input, out int iValue))
                value.Add(iValue);
            else if (double.TryParse(input, out double dValue))
                value.Add(dValue);
            else if (bool.TryParse(input, out bool bValue))
                value.Add(bValue.ToString().ToLower());
            else
                value.Add(input);
        }
        internal static void AddValueToHTupleWittAutoDetectType(ref List<object> value, string input, int stringIndex)
        {
            if (value == null)
                value = new List<object>();
            if (input.Length > stringIndex)
                input = input[stringIndex].ToString();
            else
                return;

            if (int.TryParse(input, out int iValue))
                value.Add(iValue);
            else if (double.TryParse(input, out double dValue))
                value.Add(dValue);
            else if (bool.TryParse(input, out bool bValue))
                value.Add(bValue.ToString().ToLower());
            else
                value.Add(input);
        }
        internal static void ReplaceValueToHTupleWithAutoDetectType(ref List<object> value, string input, int index)
        {
            value = value;

            if (value == null || value.Count <= index)
                return;
            if (int.TryParse(input, out int iValue))
                value[index] = iValue;
            else if (double.TryParse(input, out double dValue))
                value[index] = dValue;
            else if (bool.TryParse(input, out bool bValue))
                value[index] = bValue.ToString().ToLower();
            else if (input == cStrings.@null)
                value.RemoveAt(index);
            else
                value[index] = input;
        }

        private static void ConfigUILogging()
        {
            var fileTarget = new FileTarget();
            fileTarget.Layout = "${longdate} ${message}${exception:format=ToString}";//${logger}
            //fileTarget.FileName = "${basedir}/Logs/AppLog.{#}.txt";
            fileTarget.FileName = "${basedir}/Logs/AppLog.${shortdate}.txt";
            fileTarget.ArchiveFileName = "${basedir}/Logs/AppLog.{#}.txt";
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.DateAndSequence;
            fileTarget.ArchiveDateFormat = cDateTimeFormats.yyyyMMdd;
            fileTarget.MaxArchiveFiles = 30;
            fileTarget.ArchiveAboveSize = 104857600;

            LoggingConfiguration configuration = new LoggingConfiguration();
            configuration.AddTarget("fileLogging", fileTarget);

            LoggingRule logFileRule = new LoggingRule("LogFile", NLog.LogLevel.Info, fileTarget);
            configuration.LoggingRules.Add(logFileRule);

            fileTarget = new FileTarget();
            fileTarget.Layout = "${longdate} ${message}${exception:format=ToString}";//${logger}
            fileTarget.FileName = "${basedir}/Errors/AppError.${shortdate}.txt";
            fileTarget.ArchiveFileName = "${basedir}/Errors/AppError.{#}.txt";
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.DateAndSequence;
            fileTarget.ArchiveDateFormat = cDateTimeFormats.yyyyMMdd;
            fileTarget.MaxArchiveFiles = 30;
            fileTarget.ArchiveAboveSize = 104857600;

            configuration.AddTarget("fileError", fileTarget);

            logFileRule = new LoggingRule("ErrorFile", NLog.LogLevel.Error, fileTarget);
            configuration.LoggingRules.Add(logFileRule);

            LogManager.Configuration = configuration;
        }
        public static void GenerateDicASCII()
        {
            if (GlobVar.DicASCII != null) return;
            GlobVar.DicASCII = new Dictionary<string, byte>();
            for (int i = 0; i < ASCII.Length; i++)
            {
                GlobVar.DicASCII.Add(ToHex(new byte[] { ASCII[i] }), ASCII[i]);
            }
        }
        public static byte[] ASCII =
        {
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f,
            0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f,
            0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f,
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f,
            0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f,
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f,
            0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f,
            0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x7f,
            0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e, 0x8f,
            0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99, 0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f,
            0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf,
            0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf,
            0xc0, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcc, 0xcd, 0xce, 0xcf,
            0xd0, 0xd1, 0xd2, 0xd3, 0xd4, 0xd5, 0xd6, 0xd7, 0xd8, 0xd9, 0xda, 0xdb, 0xdc, 0xdd, 0xde, 0xdf,
            0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef,
            0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff
        };


        public static string ToHex(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];

            byte b;

            for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
            {
                b = ((byte)(bytes[bx] >> 4));
                c[cx] = (char)(b > 9 ? b - 10 + 'A' : b + '0');

                b = ((byte)(bytes[bx] & 0x0F));
                c[++cx] = (char)(b > 9 ? b - 10 + 'A' : b + '0');
            }

            string result = new string(c);
            return "0x" + result;
        }
        public static Image<Gray, byte> BitmapToGrayImage(Bitmap bitmapImage)
        {

            // Chuyển đổi Bitmap sang Image<Bgr, byte>
            //Image<Gray, byte> outputImage = bitmapImage.ToImage<Gray, byte>();
            //return outputImage;
           
                return bitmapImage.ToImage<Gray, byte>();
            

        }
        public static Image<Bgr, byte> BitmapToBgrImage(Bitmap bitmapImage)
        {

            // Chuyển đổi Bitmap sang Image<Bgr, byte>
            //Image<Bgr, byte> outputImage = bitmapImage.ToImage<Bgr, byte>();
            //return outputImage;
            return bitmapImage.ToImage<Bgr, byte>();
        }
        public static ImageFormat GetImageFormat(string Format)
        {
            ImageFormat _Format = ImageFormat.Bmp;
            switch (Format)
            {
                case "tiff":
                    _Format = ImageFormat.Tiff;
                    break;
                case "bmp":
                    _Format = ImageFormat.Bmp;
                    break;
                case "jpeg":
                    _Format = ImageFormat.Jpeg;
                    break;
                case "png":
                    _Format = ImageFormat.Png;
                    break;
                default:
                    _Format = ImageFormat.Bmp;
                    break;
            }
            return _Format;
        }
        internal static void WriteLog(cAction action)
        {
            if (GlobVar.Log != null)
                GlobVar.Log.WriteLog(action);
        }
        public static RTCRectangle GenRectangleImage(Image InputImage)
        {
            RTCRectangle Default = new RTCRectangle();
            try
            {
                if (InputImage == null) return Default;
                Default.Width = InputImage.Width;
                Default.Height = InputImage.Height;
                Default.Center = new RTCPoint(InputImage.Width / 2, InputImage.Height / 2, 0);
                return Default;
            }
            catch
            {
                return Default;
            }

        }
        public static void ViewValueInForm(cAction action, string propertyName)
        {
            if (action == null || string.IsNullOrEmpty(propertyName))
                return;
            if (propertyName.StartsWith(cStrings.RTC))
                propertyName = propertyName.Substring(3, propertyName.Length - 3);

            RTCVariableType propertyInfo = (RTCVariableType)action.GetType().GetProperty(propertyName).GetValue(action, null);
            if (propertyInfo == null) { return; }
            PropertyInfo propertyInfoValue = propertyInfo.GetType().GetProperty(cPropertyName.rtcValue);

            FrmViewTextValue frmViewTextValue = new FrmViewTextValue();
            if (propertyInfoValue.PropertyType == typeof(List<string>))
                frmViewTextValue.RtcTupleStyle = propertyInfo.ValueStyle;
            else if (propertyInfoValue.PropertyType == typeof(List<double>))
                frmViewTextValue.RtcTupleStyle = propertyInfo.ValueStyle;
            else if (propertyInfoValue.PropertyType == typeof(List<object>))
                frmViewTextValue.RtcTupleStyle = propertyInfo.ValueStyle;
            else
                frmViewTextValue.RtcTupleStyle = EHTupleStyle.None;
            frmViewTextValue.RtcPropName = propertyName + $" [{action.Name.rtcValue}]";
            frmViewTextValue.RtcValue = GlobFuncs.Ve2Str(propertyInfoValue.GetValue(propertyInfo, null));
            frmViewTextValue.RtcEnable = true;
            frmViewTextValue.Show();
        }

        internal static void AbortThread(Thread thread)
        {
            try
            {
                if (thread != null)
                    thread.Abort();
            }
            catch
            {
            }
        }
        public static List<Point> ConvertVectorOfVectorOfPointToList(VectorOfVectorOfPoint vectorOfVectors)
        {
            List<Point> pointsList = new List<Point>();

            // Lặp qua từng VectorOfPoint trong VectorOfVectorOfPoint
            for (int i = 0; i < vectorOfVectors.Size; i++)
            {
                VectorOfPoint vector = vectorOfVectors[i];

                // Lặp qua từng Point trong VectorOfPoint và thêm vào danh sách
                for (int j = 0; j < vector.Size; j++)
                {
                    pointsList.Add(vector[j]);
                }
            }

            return pointsList;
        }
        public static void DisplayGraphics(GraphicsWindow.GraphicsWindow smartWindow, object graphicsDisplay, ref Image<Bgr, byte> inputImage, Color color)
        {
            if (graphicsDisplay.GetType() == typeof(List<VectorOfVectorOfPoint>))
            {
                List<VectorOfVectorOfPoint> Region = (List<VectorOfVectorOfPoint>)graphicsDisplay;
                for (int i = 0; i < Region.Count; i++)
                {
                    //CvInvoke.DrawContours(imgShow, _outputBlobList[i], -1, new MCvScalar(0, 255, 0), -1);
                    CvInvoke.FillPoly(inputImage, Region[i], new MCvScalar(0, 255, 0));
                }
                smartWindow.Image = inputImage.ToBitmap();
            }
            else if (graphicsDisplay.GetType() == typeof(List<double>))
            {
                List<double> Region = (List<Double>)graphicsDisplay;
                if (Region.Count > 3)
                {
                    CvInvoke.ArrowedLine(inputImage, new Point(Lib.ToInt(Region[0]), Lib.ToInt(Region[1])), new Point(Lib.ToInt(Region[2]), Lib.ToInt(Region[3])), new MCvScalar(color.B, color.G, color.R), 1);
                }
                smartWindow.Image = inputImage.ToBitmap();
            }
        }
        public static bool IsHashEqual(Image img1, Image img2)
        {
            if (img1 == null || img2 == null) return false;

            // Tính hash của cả hai ảnh
            string hash1 = ComputeImageHash(img1);
            string hash2 = ComputeImageHash(img2);

            return hash1 == hash2;
        }
        #region WAITFORM

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Hàm show wait form. </summary>
        ///
        /// <remarks>   DATRUONG, 17/11/2021. </remarks>
        ///
        /// <param name="_Description"> (Optional) Nội dung cần đổi. </param>
        /// <param name="_Caption">     (Optional) Caption cần đổi. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ChangeWaitFormCaption(string _Caption = "")
        {
            if (_Caption != "")
                GlobVar.RTCSplashScreenManager.Caption = _Caption;
        }

        /// <summary>
        /// Thay đổi nội dung form wait
        /// </summary>
        /// <param name="description">Nội dung thông báo</param>
        public static void ChangeWaitFormDescription(string description = "")
        {
            if (description != "")
                GlobVar.RTCSplashScreenManager.Description = description;
        }

        /// <summary>
        /// Hiển thị wait form
        /// </summary>
        /// <param name="description">Nội dung thông báo</param>
        /// <param name="caption">Tiêu đề thông báo</param>
        public static async void ShowWaitForm(string description = "", string caption = "")
        {
            if (GlobVar.RTCSplashScreenManager == null || GlobVar.IsWaitFormActive)
                return;
            GlobVar.RTCSplashScreenManager = new Splasher("PleaseWait");
            GlobVar.IsWaitFormActive = true;


            if (caption != "")
                GlobVar.RTCSplashScreenManager.Caption = caption;
            if (description != "")
                GlobVar.RTCSplashScreenManager.Description = description;
            try
            {
                await GlobVar.RTCSplashScreenManager.ShowAsync();
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("Splash Form already shown"))
                    return;
            }
        }

        /// <summary>
        /// Đóng wait form
        /// </summary>
        public static void CloseWaitForm()
        {
            try
            {
                // Thread.Sleep(500);
                GlobVar.IsWaitFormActive = false;
                GlobVar.RTCSplashScreenManager?.Close();
                //if (!GlobVar.IsWaitFormActive || GlobVar.RTCSplashScreenManager == null)
                //    return;
                //GlobVar.IsWaitFormActive = false;
                //if (GlobVar.RTCSplashScreenManager.IsSplashFormVisible)
                //    GlobVar.RTCSplashScreenManager.CloseWaitForm();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Cài đặt nội dung của form chờ là Success
        /// </summary>
        public static void SetWaitFormSuccess()
        {
            SetWaitFormDescription(cStrings.Success);
        }
        /// <summary>
        /// Cài đặt nội dung của form chờ là Error
        /// </summary>
        public static void SetWaitFormError()
        {
            SetWaitFormDescription(cStrings.ERROR);
        }

        /// <summary>
        /// Cài đặt nội dung của form chờ là nội dung tùy chọn nhập
        /// </summary>
        /// <param name="description">Nội dung cần hiển thị lên form chờ</param>
        public static void SetWaitFormDescription(string description)
        {
            if (!GlobVar.IsWaitFormActive || GlobVar.RTCSplashScreenManager == null) return;
            GlobVar.RTCSplashScreenManager.Description = description;
        }

        #endregion

        public static string ComputeImageHash(Image img)
        {
            using (var ms = new MemoryStream())
            {
                // Lưu ảnh vào stream dưới dạng PNG để tính toán hash
                img.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                using (var md5 = MD5.Create())
                {
                    byte[] hashBytes = md5.ComputeHash(imageBytes);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
            }
        }

    }
}
