using ActUtlType64Lib;
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
        #region MXComponentRead Functions

        public void Run_MXComponentRead_Test()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            Run_MXComponentRead();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void GetMXComponentConnection()
        {
            if (MyMXComponent != null)
                return;
            if (GlobVar.MyListMXComponent != null)
                MyMXComponent = GlobVar.MyListMXComponent.FirstOrDefault(x => x.ActLogicalStationNumber == LogicalStationNumber.rtcValue);
            if (MyMXComponent == null)
            {
                MyMXComponent = new ActUtlType64
                {
                    ActLogicalStationNumber = LogicalStationNumber.rtcValue
                };
                if (MyMXComponent.Open() != 0)
                {
                    MyMXComponent = null;
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_MXComponentActionCanNotConnect };
                    return;
                }
                if (GlobVar.MyListMXComponent == null)
                    GlobVar.MyListMXComponent = new List<ActUtlType64>();
                GlobVar.MyListMXComponent.Add(MyMXComponent);
            }
        }
        public void Run_MXComponentRead()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            Value.rtcValue = new List<string>();

            if (GlobVar.IsSimulatorMode)
            {
                Value.rtcValue = SimulatorValue.rtcValue;
                Passed.rtcValue = true;
                if (IsCompareValue.rtcValue)
                {
                    bool equal = Value.rtcValue.Equals(CompareValue.rtcValue);
                    Passed.rtcValue = equal;
                }
                return;
            }
            GetMXComponentConnection();

            if (MyMXComponent != null)
            {
                bool Success = false;
                string[] arrAddress = new string[] { };
                if (Address.rtcValue.Contains(cChars.Semicolon))
                    arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                else
                    arrAddress = Address.rtcValue.Split(cChars.Comma);
                foreach (string address in arrAddress)
                {
                    Success = MyMXComponent.GetDevice(address, out int Data) == 0;
                    if (Success)
                        Value.rtcValue.Add(Data.ToString());
                    if (!Success)
                        break;
                }
                Value.rtcValue = Value.rtcValue;
                Passed.rtcValue = Success;
                if (IsCompareValue.rtcValue)
                {
                    bool equal = Value.rtcValue.Equals(CompareValue.rtcValue);
                    Passed.rtcValue = equal;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(ErrMessage.rtcValue[0]))
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_MXComponentActionCanNotConnect };
            }
        }
        public void RUN_MXComponentWrite(bool isTest = false)
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            if (IsAliveControl.rtcValue)
            {
                if (isTest)
                    Run_MXComponentWrite_Alive();
                return;
            }
            GetMXComponentConnection();
            if (MyMXComponent != null)
            {
                Passed.rtcValue = true;
                if (Value.rtcValue == null || Value.rtcValue.Count == 0)
                    return;
                if (IsCompareValue.rtcValue)
                {
                    bool equal = Value.rtcValue.Equals(CompareValue.rtcValue);
                    Passed.rtcValue = equal;
                }
                if (Passed.rtcValue)
                {
                    string[] arrAddress = new string[] { };
                    if (Address.rtcValue.Contains(cChars.Semicolon))
                        arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                    else
                        arrAddress = Address.rtcValue.Split(cChars.Comma);
                    int iIndex = 0;
                    foreach (string address in arrAddress)
                    {
                        if (iIndex >= Value.rtcValue.Count) break;
                        Passed.rtcValue = MyMXComponent.SetDevice(address, Lib.ToInt(Value.rtcValue[iIndex])) == 0;
                        if (!Passed.rtcValue) break;
                        iIndex += 1;
                    }
                }
                if (IsRunOneTime.rtcValue && !isTest)
                    IsFinishRunOneTime.rtcValue = Passed.rtcValue;
                if (Passed.rtcValue && TimeDelay.rtcValue > 0)
                {
                    if (WaitMode.rtcValue == cStrings.ASync || isTest)
                        Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_MXComponentWrite_AfterDelay());
                    else
                    {
                        Thread.Sleep(TimeDelay.rtcValue);
                        Run_MXComponentWrite_AfterDelay();
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(ErrMessage.rtcValue[0]))
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_MXComponentActionCanNotConnect };
                }
            }
        }
        public void Run_MXComponentWrite_Alive(bool isUseDelay = true)
        {
            Passed.rtcValue = false;
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = false;
                return;
            }
            GetMXComponentConnection();
            if (MyMXComponent != null)
            {
                string[] arrAddress = new string[] { };
                if (Address.rtcValue.Contains(cChars.Semicolon))
                    arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                else
                    arrAddress = Address.rtcValue.Split(cChars.Comma);
                foreach (string address in arrAddress)
                {
                    Passed.rtcValue = MyMXComponent.SetDevice(address, AliveValue) == 0;
                    if (!Passed.rtcValue)
                        break;
                }
                AliveValue = AliveValue == 0 ? 1 : 0;
            }
            if (isUseDelay)
                Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_SLMPWrite_Alive(false));
        }
        public void Run_MXComponentWrite_AfterDelay()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = false;
                return;
            }
            if (ValueAfterDelay.rtcValue == null || ValueAfterDelay.rtcValue.Count == 0)
                return;
            GetMXComponentConnection();
            if (MyMXComponent != null)
            {
                string[] arrAddress = new string[] { };
                if (Address.rtcValue.Contains(cChars.Semicolon))
                    arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                else
                    arrAddress = Address.rtcValue.Split(cChars.Comma);
                int iIndex = 0;
                foreach (string address in arrAddress)
                {
                    if (iIndex > ValueAfterDelay.rtcValue.Count) break;
                    Passed.rtcValue = MyMXComponent.SetDevice(address, Lib.ToInt(ValueAfterDelay.rtcValue[iIndex])) == 0;
                    if (!Passed.rtcValue) break;
                    iIndex += 1;
                }
            }

        }
        #endregion
        public void Run_MXComponentWrite_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            RUN_MXComponentWrite(true);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
    }
}
