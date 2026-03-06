using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using RTCEnums;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using System.Diagnostics;
using System.Threading;
using RTCConst;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction : IDisposable
    {
        /// <summary>
        /// Sự kiện nhận dữ liệu của 1 cổng com gửi đến cổng com đang mở trên chương trình.
        /// </summary>
        /// <param name="data">Chuỗi dữ liệu nhận được</param>
        public void OnCOMReceiveDataEvents(string data)
        {
            if (ActionType != EActionTypes.COMReader)
                return;
            if (GlobVar.IsSimulatorMode)
            {
                Value.rtcValue = SimulatorValue.rtcValue;
                if (IsUseValueTypesConvert.rtcValue && ValueTypes.rtcValue != ValueTypesConvert.rtcValue)
                    Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);
                Passed.rtcValue = true;
                if (IsCompareValue.rtcValue)
                {
                    //List<string> equalValue = new List<string>() { "0" };
                    Passed.rtcValue = Value.rtcValue.Equals(CompareValue.rtcValue);

                }    
            }
            else if (data.Replace("\0", "").Trim() != string.Empty)
            {
                Value.rtcValue = new List<string>() { data.Replace("\0", "").Trim() };
                if (IsUseValueTypesConvert.rtcValue)
                    Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);
                if (IsCompareValue.rtcValue)
                {
                    Passed.rtcValue = Value.rtcValue.Equals(CompareValue.rtcValue);
                }    

            }
            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        /// <summary>
        /// Dừng quá trình đọc cổng com khi bấm nút Stop trong giao diện setup
        /// </summary>
        public void Stop_COMRead_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MyCOMReader = null;
            if (GlobVar.MyListCOMReader != null)
                MyCOMReader = GlobVar.MyListCOMReader.FirstOrDefault(x =>
                        x.ComName == COMName.rtcValue);

            if (MyCOMReader != null && MyCOMReader.IsConnected)
                MyCOMReader.Disconnect();

            stopwatch.Stop();
        }
        private void CheckConnectCOM()
        {
            MyCOMReader = null;
            if (string.IsNullOrEmpty(COMName.rtcValue))
            {
                ErrMessage.rtcValue = new List<string>() {cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                            new string[] { "COM port name" },
                            new string[] { "Tên cổng COM" })};
                return;
            }

            if (GlobVar.MyListCOMReader != null)
                MyCOMReader = GlobVar.MyListCOMReader.FirstOrDefault(x =>
                        x.ComName == COMName.rtcValue);

            if (MyCOMReader == null)
            {
                MyCOMReader = new cCOM(COMName.rtcValue,
                    int.Parse(BaudRate.rtcValue),
                    int.Parse(DataBits.rtcValue),
                    GlobFuncs.GetParity(Parity.rtcValue),
                    GlobFuncs.GetStopBits(StopBits.rtcValue),
                    IsHex.rtcValue);
                if (GlobVar.MyListCOMReader == null) GlobVar.MyListCOMReader = new List<cCOM>();
                GlobVar.MyListCOMReader.Add(MyCOMReader);
            }


            if (!MyCOMReader.IsConnected)
            {
                MyCOMReader.Disconnect();
                MyCOMReader.Connect();
            }

            MyCOMReader.OnReceiveDataEvents -= OnCOMReceiveDataEvents;
            MyCOMReader.OnReceiveDataEvents += OnCOMReceiveDataEvents;
        }
        public void Run_COMReader()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { };

            if (GlobVar.IsSimulatorMode)
            {
                Value.rtcValue = SimulatorValue.rtcValue;
                if (IsUseValueTypesConvert.rtcValue && ValueTypes.rtcValue != ValueTypesConvert.rtcValue)
                    Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);
                Passed.rtcValue = true;

                if (IsCompareValue.rtcValue)
                {
                    //HTuple equalHTuple = new HTuple(0);
                    // equalHTuple = Value.rtcValue.TupleEqual(CompareValue.rtcValue);
                    Passed.rtcValue = Value.rtcValue.Equals(CompareValue.rtcValue);
                }
            }
            else
            {
                CheckConnectCOM();

                if (MyCOMReader != null && MyCOMReader.IsConnected)
                {
                    MyCOMReader.IsHex = IsHex.rtcValue;
                    Passed.rtcValue = true;
                }
                else
                {
                    if (ErrMessage.rtcValue.Count ==0)
                        ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_COMNameActionCanNotConnect,
                            new string[] { Name.rtcValue, MyCOMReader.ComName },
                            new string[] { Name.rtcValue, MyCOMReader.ComName }) };
                }
            }

            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        /// <summary>
        /// Hàm chạy ghi tín hiệu cổng COM với cơ chế Alive
        /// </summary>
        /// <param name="isUseDelay">Lựa chọn có delay khi gửi hay không</param>
        public void Run_COMWrite_Alive(bool isUseDelay = true)
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            Passed.rtcValue = false;

            CheckConnectCOM();

            if (!MyCOMReader.IsConnected)
                return;

            MyCOMReader.IsHex = IsHex.rtcValue;

            MyCOMReader.Write(GlobFuncs.Ve2Str(AliveValue == 1
                ? ReplaceDelemiterStringToSendDataString(AliveValueOn.rtcValue)
                : ReplaceDelemiterStringToSendDataString(AliveValueOff.rtcValue)));

            AliveValue = AliveValue == 0 ? 1 : 0;

            if (isUseDelay)
                Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_COMWrite_Alive(false));
        }
        /// <summary>
        /// Hàm chạy ghi tín hiệu cổng COM sau khi hết thời gian delay
        /// </summary>
        public void Run_COMWrite_AfterDelay()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            if (ValueAfterDelay.rtcValue == null || ValueAfterDelay.rtcValue.Count <= 0)
                return;

            CheckConnectCOM();

            if (MyCOMReader != null && !MyCOMReader.IsConnected)
            {
                MyCOMReader.Disconnect();
                MyCOMReader.Connect();
                if (!MyCOMReader.IsConnected)
                    ErrMessage.rtcValue = new List<string>() {cMessageContent.BuildMessage(cMessageContent.War_COMNameActionCanNotConnect,
                        new string[] { Name.rtcValue, MyCOMReader.ComName },
                        new string[] { Name.rtcValue, MyCOMReader.ComName }) };
            }

            if (!MyCOMReader.IsConnected)
                return;

            MyCOMReader.IsHex = IsHex.rtcValue;
            MyCOMReader.Write(ReplaceDelemiterStringToSendDataString(GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue)));
        }
        /// <summary>
        /// Hàm chạy ghi tín hiệu cổng COM sau khi dừng chương trình
        /// </summary>
        public void Run_COMWrite_AfterStop()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            if (ValueAfterStop.rtcValue == null || ValueAfterStop.rtcValue.Count <= 0)
                return;

            CheckConnectCOM();

            if (MyCOMReader != null && !MyCOMReader.IsConnected)
            {
                MyCOMReader.Disconnect();
                MyCOMReader.Connect();
                if (!MyCOMReader.IsConnected)
                    ErrMessage.rtcValue =new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_COMNameActionCanNotConnect,
                        new string[] { Name.rtcValue, MyCOMReader.ComName },
                        new string[] { Name.rtcValue, MyCOMReader.ComName }) };
            }

            if (!MyCOMReader.IsConnected)
                return;

            if (ValueAfterStop.rtcValue == null || ValueAfterStop.rtcValue.Count <= 0)
                return;

            MyCOMReader.IsHex = IsHex.rtcValue;

            MyCOMReader.Write(ReplaceDelemiterStringToSendDataString(GlobFuncs.Ve2Str(ValueAfterStop.rtcValue)));
        }
        /// <summary>
        /// Hàm chạy ghi tín hiệu cổng COM.
        /// </summary>
        public void Run_COMWriter(bool isTest = false)
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { };

            if (IsAliveControl.rtcValue)
            {
                if (isTest)
                    Run_COMWrite_Alive();
                return;
            }

            CheckConnectCOM();

            if (MyCOMReader.IsConnected)
            {
                Passed.rtcValue = true;

                MyCOMReader.IsHex = IsHex.rtcValue;

                if (Value.rtcValue == null || Value.rtcValue.Count <= 0)
                    return;
                if (IsCompareValue.rtcValue)
                {
                  
                    Passed.rtcValue = (Value.rtcValue.Equals(CompareValue.rtcValue));
                }

                if (Passed.rtcValue)
                    Passed.rtcValue = MyCOMReader.Write(ReplaceDelemiterStringToSendDataString(GlobFuncs.Ve2Str(Value.rtcValue)));

                if (IsRunOneTime.rtcValue && !isTest)
                    IsFinishRunOneTime.rtcValue = Passed.rtcValue;

                if (Passed.rtcValue && TimeDelay.rtcValue > 0)
                {
                    if (WaitMode.rtcValue == cStrings.ASync || isTest)
                        Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_COMWrite_AfterDelay());
                    else
                    {
                        Thread.Sleep(TimeDelay.rtcValue);
                        Run_COMWrite_AfterDelay();
                    }
                }
            }
            else
            {
                if (ErrMessage.rtcValue.Count > 0)
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_COMNameActionCanNotConnect,
                        new string[] { Name.rtcValue, MyCOMReader.ComName },
                        new string[] { Name.rtcValue, MyCOMReader.ComName }) };
            }
        }
        /// <summary>
        /// Hàm chạy ghi tín hiệu cổng COM khi nhấn nút Write trên giao diện setup.
        /// </summary>
        public void Run_COMWrite_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_COMWriter(true);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_COMRead_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_COMReader();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);

            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}
