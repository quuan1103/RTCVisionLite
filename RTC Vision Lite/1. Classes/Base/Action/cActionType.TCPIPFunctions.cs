using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using RtcTcpIp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        #region TCPIP FUNCTIONS
        /// <summary>
        /// Set data cho tool TCPIP
        /// </summary>
        /// <param name="data">Dữ liệu nhận được</param>
        internal void SetTcpIpData(string data)
        {
            Value.rtcValue = new List<string>() { data };

            if (IsUseValueTypesConvert.rtcValue)
                Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);
            if (IsCompareValue.rtcValue)
            {
                var equalValue = Value.rtcValue.Equals(CompareValue.rtcValue);
                Passed.rtcValue = equalValue;
            }

            GlobFuncs.WriteLog(this);
            if (this.ViewInfo != null && !MyGroup.RunSimple)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        /// <summary>
        /// Event đón dữ liệu của socket
        /// </summary>
        /// <param name="data">Dữ liệu nhận được</param>
        internal void OnReceiveDataEvents(string data)
        {
            try
            {
                Value.rtcValue = new List<string>() { data };

                if (IsUseValueTypesConvert.rtcValue)
                    Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);
                if (IsCompareValue.rtcValue)
                {
                    var equalHTuple = Value.rtcValue.Equals(CompareValue.rtcValue);
                    Passed.rtcValue = equalHTuple;
                }

                GlobFuncs.WriteLog(this);
                if (this.ViewInfo != null && !MyGroup.RunSimple)
                    ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
                if (this.MyGroup != null)
                {
                    var listActions = this.MyGroup.Actions.Values.Where(x => x.ActionType == EActionTypes.TCPIPRead && x.IPAddress.rtcValue == this.IPAddress.rtcValue &&
                                                                            x.PortNumber.rtcValue == this.PortNumber.rtcValue &&
                                                                            x.ID != this.ID).ToList();
                    foreach (var action in listActions)
                        action.SetTcpIpData(data);

                    // Trong trạng thái chạy tổng
                    if (this.MyGroup.RunSimple && GlobVar.CurrentProject != null)
                    {
                        foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                            if (cam.ID != this.MyGroup.MyCam.ID)
                            {
                                listActions = cam.GroupActions.Actions.Values.Where(x => x.ActionType == EActionTypes.TCPIPRead
                                                                             && ((x.IPAddress.rtcValue == this.IPAddress.rtcValue && x.PortNumber.rtcValue == this.PortNumber.rtcValue && this.IsServer.rtcValue) ||
                                                                                 (x.PortNumber.rtcValue == this.PortNumber.rtcValue && !this.IsServer.rtcValue))
                                                                             && x.ID != this.ID).ToList();
                                foreach (var action in listActions)
                                    action.SetTcpIpData(data);
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        /// <summary>
        /// Hàm test nhận tín hiệu TCP/IP khi setting
        /// </summary>
        internal void Run_TCPIPRead_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_TCPIPRead();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);

            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        /// <summary>
        /// Hàm dừng test nhận tín hiệu TCP/IP khi setting
        /// </summary>
        internal void Stop_TCPIPRead_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MySocket = null;
            if (GlobVar.MyListTCPIP != null)
                MySocket =
                    GlobVar.MyListTCPIP.FirstOrDefault(x =>
                        x.HostName == IPAddress.rtcValue && x.Port == PortNumber.rtcValue);

            if (MySocket == null)
            {
                MySocket = new CSocketClient(IPAddress.rtcValue, PortNumber.rtcValue, false, null);
                if (GlobVar.MyListTCPIP == null) GlobVar.MyListTCPIP = new List<CSocketClient>();
                GlobVar.MyListTCPIP.Add(MySocket);
            }

            if (MySocket != null && MySocket.IsConnected)
                MySocket.Disconnect();

            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);

            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();

        }
        /// <summary>
        /// Kiểm tra connection
        /// </summary>
        /// <param name="isRead">Thiết lập là connection để đọc hay gửi kết quả</param>
        /// <returns>True: Kết nối thành công; False: Kết nối thất bại</returns>
        private bool CheckTCPIPConnect(bool isRead = true)
        {
            if (MySocket == null || !MySocket.IsConnected)
            {
                MySocket = null;

                if (GlobVar.MyListTCPIP != null)
                {
                    if (IsServer.rtcValue)
                        MySocket =
                            GlobVar.MyListTCPIP.FirstOrDefault(x => x.Port == PortNumber.rtcValue && x.IsServer);
                    else
                        MySocket =
                            GlobVar.MyListTCPIP.FirstOrDefault(x =>
                                x.HostName == IPAddress.rtcValue && x.Port == PortNumber.rtcValue && !x.IsServer);
                }

                if (MySocket == null)
                {
                    MySocket = new CSocketClient(IPAddress.rtcValue, PortNumber.rtcValue, false, null, ProtocolType.Tcp, IsServer.rtcValue, false);
                    if (GlobVar.MyListTCPIP == null) GlobVar.MyListTCPIP = new List<CSocketClient>();
                    GlobVar.MyListTCPIP.Add(MySocket);
                }

                if (!MySocket.IsConnected)
                    if (MySocket.Connect())
                    {
                        if (isRead)
                        {
                            MySocket.OnReceiveDataEvents -= OnReceiveDataEvents;
                            MySocket.OnReceiveDataEvents += OnReceiveDataEvents;
                            Value.rtcValue = new List<string>();
                        }
                    }
                    else
                    {
                        MySocket.OnReceiveDataEvents -= OnReceiveDataEvents;
                        if (string.IsNullOrEmpty(GlobFuncs.Ve2Str(ErrMessage.rtcValue)))
                            ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_TCPIPOfActionCanNotConnect,
                        new string[] { Name.rtcValue, MySocket.HostName, MySocket.Port.ToString() },
                        new string[] { Name.rtcValue, MySocket.HostName, MySocket.Port.ToString() }) };
                    }

                return (MySocket != null && MySocket.IsConnected);
            }
            else
                return true;
        }
        /// <summary>
        /// Hàm đọc tín hiệu TCP/IP
        /// </summary>
        internal void Run_TCPIPRead()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            if (GlobVar.IsSimulatorMode)
            {
                Value.rtcValue = SimulatorValue.rtcValue;
                if (IsUseValueTypesConvert.rtcValue)
                    Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);

                Passed.rtcValue = true;

                if (IsCompareValue.rtcValue)
                {
                   
                   var equalHTuple = Value.rtcValue.Equals(CompareValue.rtcValue);
                    Passed.rtcValue = equalHTuple;
                }
            }
            else if (CheckTCPIPConnect())
            {
                MySocket.IsHex = IsHex.rtcValue;
                Passed.rtcValue = true;
            }                                                                                                          
        }

        /// <summary>
        /// Chạy tool ghi tín hiệu tcp với mode alive
        /// </summary>
        /// <param name="isUseDelay">Có sử dụng cơ chế delay thời gian gửi hay không</param>
        internal void Run_TCPIPWrite_Alive(bool isUseDelay = true)
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            Passed.rtcValue = false;
            if (CheckTCPIPConnect(false))
            {
                MySocket.IsHex = IsHex.rtcValue;

                MySocket.SendData(GlobFuncs.Ve2Str(AliveValue.ToString()));

                AliveValue = AliveValue == 0 ? 1 : 0;

                if (isUseDelay)
                    Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_TCPIPWrite_Alive(false));
            }
        }
        /// <summary>
        /// Hàm ghi tín hiệu TCP/IP sau quá trình delay
        /// </summary>
        internal void Run_TCPIPWrite_AfterDelay()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            if (ValueAfterDelay.rtcValue == null || ValueAfterDelay.rtcValue.Count <= 0)
                return;
            if (CheckTCPIPConnect(false))
            {
                if (ValueAfterDelay.rtcValue == null || ValueAfterDelay.rtcValue.Count <= 0)
                    return;

                MySocket.IsHex = IsHex.rtcValue;
                string sValue = GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue);
                if (!IsSendOriginalValue.rtcValue)
                    sValue = ReplaceDelemiterStringToSendDataString(sValue);
                Passed.rtcValue = MySocket.SendData(sValue);
            }
        }
        /// <summary>
        /// Hàm ghi tín hiệu TCP/IP khi dừng chương trình
        /// </summary>
        internal void Run_TCPIPWrite_AfterStop()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            if (ValueAfterStop.rtcValue == null || ValueAfterStop.rtcValue.Count <= 0)
                return;
            if (CheckTCPIPConnect(false))
            {
                if (ValueAfterStop.rtcValue == null || ValueAfterStop.rtcValue.Count <= 0)
                    return;

                MySocket.IsHex = IsHex.rtcValue;
                string sValue = GlobFuncs.Ve2Str(ValueAfterStop.rtcValue);
                if (!IsSendOriginalValue.rtcValue)
                    sValue = ReplaceDelemiterStringToSendDataString(sValue);
                Passed.rtcValue = MySocket.SendData(sValue);
            }
        }
        /// <summary>
        /// Hàm khi tín hiệu TCP/IP
        /// </summary>
        /// <param name="isTest">Thiết lập để nhận dạng hàm chạy test hay chạy thực</param>
        internal void Run_TCPIPWrite(bool isTest = false)
        {
            try
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
                        Run_TCPIPWrite_Alive();
                    return;
                }
                if (CheckTCPIPConnect(false))
                {
                    Passed.rtcValue = true;

                    MySocket.IsHex = IsHex.rtcValue;

                    if (Value.rtcValue == null || Value.rtcValue.Count <= 0)
                        return;
                    if (IsCompareValue.rtcValue)
                    {
                       
                       var  equalHTuple = Value.rtcValue.Equals(CompareValue.rtcValue);
                        Passed.rtcValue = equalHTuple;
                    }

                    if (Passed.rtcValue)
                    {
                        string sValue = GlobFuncs.Ve2Str(Value.rtcValue);
                        if (!IsSendOriginalValue.rtcValue)
                            sValue = ReplaceDelemiterStringToSendDataString(sValue);
                        Passed.rtcValue = MySocket.SendData(sValue);
                    }

                    if (IsRunOneTime.rtcValue && !isTest)
                        IsFinishRunOneTime.rtcValue = Passed.rtcValue;

                    if (Passed.rtcValue && TimeDelay.rtcValue > 0)
                    {
                        if (WaitMode.rtcValue == cStrings.ASync)
                            Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_TCPIPWrite_AfterDelay());
                        else
                        {
                            Thread.Sleep(TimeDelay.rtcValue);
                            Run_TCPIPWrite_AfterDelay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        /// <summary>
        /// Hàm test gửi tín hiệu TCP/IP khi setting
        /// </summary>
        internal void Run_TCPIPWrite_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_TCPIPWrite(true);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }

        #endregion
    }
}

