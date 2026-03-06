using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        #region CSTLight FUNCTIONS
        private void CheckConnectCSTLight()
        {
            MyCSTLight = null;
            if (GlobVar.MyListCSTLight != null)
                MyCSTLight =
                    GlobVar.MyListCSTLight.FirstOrDefault(x =>
                        (x.SourceMode == cCSTLightSourceMode.Ethernet && x.IPAddress == IPAddress.rtcValue) ||
                        (x.SourceMode == cCSTLightSourceMode.SerialPort && x.SerialPort == SerialPort.rtcValue));

            if (MyCSTLight == null)
            {
                MyCSTLight = new CSTLightClientNew
                {
                    IPAddress = IPAddress.rtcValue,
                    SourceMode = SourceMode.rtcValue,
                    SerialPort = SerialPort.rtcValue
                };
                if (GlobVar.MyListCSTLight == null)
                    GlobVar.MyListCSTLight = new List<CSTLightClientNew>();
                GlobVar.MyListCSTLight.Add(MyCSTLight);
            }

            if (MyCSTLight != null && !MyCSTLight.IsConnected)
            {
                MyCSTLight.Disconnect();
                MyCSTLight.Connect();
                if (ErrMessage.rtcValue.Count > 0 && ErrMessage.rtcValue[0] == cStrings.Disconnect)
                    ErrMessage.rtcValue = new List<string> { cMessageContent.War_CSTLightOfActionCanNotConnect };
            }

            if (MyCSTLight == null || !MyCSTLight.IsConnected)
                if (ErrMessage.rtcValue.Count > 0)
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_CSTLightOfActionCanNotConnect };
        }
        /// <summary>
        /// Chạy test đèn CST khi setting
        /// </summary>
        public void Run_CSTLightRead_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_CSTLightRead();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }

        /// <summary>
        /// Đọc độ sáng hiện tại của đèn
        /// </summary>
        public void Run_CSTLightRead()
        {

            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();
            Value.rtcValue = new List<string>();

            if (GlobVar.IsSimulatorMode)
            {
                Value.rtcValue = SimulatorValue.rtcValue;

                Passed.rtcValue = true;

                if (IsCompareValue.rtcValue)
                {
                    Passed.rtcValue = GlobFuncs.ListsEqual(CompareValue.rtcValue.Cast<object>().ToList()
                        , Value.rtcValue.Cast<object>().ToList());
                }
                return;
            }

            CheckConnectCSTLight();

            if (MyCSTLight == null || !MyCSTLight.IsConnected) return;
            
            bool success = false;
            string[] channels = Address.rtcValue.Contains(cChars.Semicolon) ? Address.rtcValue.Split(cChars.Semicolon) : Address.rtcValue.Split(cChars.Comma);
            foreach (string channel in channels)
            {
                if (int.TryParse(channel, out int iChannel))
                {
                    Value.rtcValue.AddRange(new List<string>(){(MyCSTLight.Read(iChannel, out success, out string errMessage
                       ).ToString()) });
                    ErrMessage.rtcValue = new List<string>() { errMessage };
                }
                else
                    Value.rtcValue.Add("-1");
                if (!success) break;
            }

            Value.rtcValue = Value.rtcValue;
            ErrMessage.rtcValue = Value.rtcValue;
            Passed.rtcValue = success;
            if (IsCompareValue.rtcValue)
            {
                Passed.rtcValue = GlobFuncs.ListsEqual(CompareValue.rtcValue.Cast<object>().ToList()
                         , Value.rtcValue.Cast<object>().ToList());
            }
        }

        /// <summary>
        /// Ghi độ sáng đèn sau khi delay 1 khoảng thời gian
        /// </summary>
        public void Run_CSTLightWrite_AfterDelay()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            if (ValueAfterDelay.rtcValue == null || ValueAfterDelay.rtcValue.Count <= 0)
                return;

            CheckConnectCSTLight();

            if (MyCSTLight == null || !MyCSTLight.IsConnected) return;

            string[] channels = Address.rtcValue.Contains(cChars.Semicolon) ? Address.rtcValue.Split(cChars.Semicolon) : Address.rtcValue.Split(cChars.Comma);
            int iIndexTuple = 0;
            foreach (string channel in channels)
            {
                if (iIndexTuple >= ValueAfterDelay.rtcValue.Count)
                    break;
                Passed.rtcValue = false;
                if (!int.TryParse(channel, out int iChannel))
                {
                    ErrMessage.rtcValue = new List<string>() { "Channel Is Not Correct!!!" };
                    break;
                }
                string sValue = GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue[iIndexTuple]);
                if (int.TryParse(sValue, out int iValue))
                {
                    Passed.rtcValue = MyCSTLight.Write(iChannel, iValue, out string errMessage);
                    if (!GlobFuncs.CheckContainsValue(ErrMessage.rtcValue, errMessage))
                        if (ErrMessage.rtcValue.Count == 1)
                            ErrMessage.rtcValue = new List<string>() { errMessage };
                        else
                            ErrMessage.rtcValue.Append(errMessage);
                }
                iIndexTuple += 1;
            }
            Passed.rtcValue = ErrMessage.rtcValue.Count > 0;
        }

        /// <summary>
        /// Ghi độ sáng đèn sau khi stop vision
        /// </summary>
        public void Run_CSTLightWrite_AfterStop()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            if (ValueAfterStop.rtcValue == null || ValueAfterStop.rtcValue.Count <= 0)
                return;

            CheckConnectCSTLight();

            if (MyCSTLight == null || !MyCSTLight.IsConnected) return;

            string[] channels = Address.rtcValue.Contains(cChars.Semicolon) ? Address.rtcValue.Split(cChars.Semicolon) : Address.rtcValue.Split(cChars.Comma);
            int iIndexTuple = 0;
            foreach (string channel in channels)
            {
                if (iIndexTuple >= ValueAfterStop.rtcValue.Count)
                    break;
                Passed.rtcValue = false;
                if (!int.TryParse(channel, out int iChannel))
                {
                    ErrMessage.rtcValue = new List<string>() { "Channel Is Not Correct!!!" };
                    break;
                }
                string sValue = GlobFuncs.Ve2Str(ValueAfterStop.rtcValue[iIndexTuple]);
                if (int.TryParse(sValue, out int iValue))
                {
                    Passed.rtcValue = MyCSTLight.Write(iChannel, iValue, out string errMessage);
                    if (!GlobFuncs.CheckContainsValue(ErrMessage.rtcValue, errMessage))
                        if (ErrMessage.rtcValue.Count == 1)
                            ErrMessage.rtcValue = new List<string>() { errMessage };
                        else
                            ErrMessage.rtcValue.Append(errMessage);
                }
                iIndexTuple += 1;
            }
            Passed.rtcValue = ErrMessage.rtcValue.Count > 0;
        }

        /// <summary>
        /// Ghi độ sáng mới cho đèn
        /// </summary>
        /// <param name="isTest">Có ở chế độ test hay không</param>
        public void Run_CSTLightWrite(bool isTest = false)
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();

            CheckConnectCSTLight();

            if (MyCSTLight == null || !MyCSTLight.IsConnected) return;

            Passed.rtcValue = true;
            if (Value.rtcValue == null || Value.rtcValue.Count <= 0)
                return;
            if (IsCompareValue.rtcValue)
            {
                Passed.rtcValue = GlobFuncs.ListsEqual(CompareValue.rtcValue.Cast<object>().ToList()
                         , Value.rtcValue.Cast<object>().ToList());
            }

            if (Passed.rtcValue)
            {
                string[] channels = new string[] { };
                if (Address.rtcValue.Contains(cChars.Semicolon))
                    channels = Address.rtcValue.Split(cChars.Semicolon);
                else
                    channels = Address.rtcValue.Split(cChars.Comma);

                int iIndexHtuple = 0;
                foreach (string channel in channels)
                {
                    if (iIndexHtuple >= Value.rtcValue.Count)
                        break;
                    Passed.rtcValue = false;
                    if (!int.TryParse(channel, out int iChannel))
                    {
                        ErrMessage.rtcValue =new List<string>() { "Channel Is Not Correct!!!" };
                        break;
                    }
                    string sValue = GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple]);
                    if (int.TryParse(sValue, out int iValue))
                    {
                        Passed.rtcValue =
                            MyCSTLight.Write(iChannel, iValue, out string errMessage);
                        if (!GlobFuncs.CheckContainsValue(ErrMessage.rtcValue, errMessage))
                            if (ErrMessage.rtcValue.Count == 1)
                                ErrMessage.rtcValue =new List<string>() { errMessage };
                            else
                                ErrMessage.rtcValue.Append(errMessage);
                    }

                    iIndexHtuple += 1;
                }
            }

            Passed.rtcValue = GlobFuncs.Ve2Str(ErrMessage.rtcValue) == string.Empty;

            if (IsRunOneTime.rtcValue && !isTest)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;

            if (Passed.rtcValue && TimeDelay.rtcValue > 0)
            {
                if (WaitMode.rtcValue == cStrings.ASync || isTest)
                    Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_CSTLightWrite_AfterDelay());
                else
                {
                    Thread.Sleep(TimeDelay.rtcValue);
                    Run_CSTLightWrite_AfterDelay();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Run CSTLight Write with test mode. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_CSTLightWrite_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_CSTLightWrite(true);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void DisconnectCST()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MyCSTLight.Disconnect();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }

        #endregion

    }
}
