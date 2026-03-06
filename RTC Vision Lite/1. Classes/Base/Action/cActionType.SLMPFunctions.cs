using System;
using RTCConst;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RTC_Vision_Lite.PublicFunctions;
using System.Diagnostics;
using System.Threading.Tasks;
using SlmpCustom;
using SLMPTcp;
using RTC_Vision_Lite.Classes;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        #region SLMP FUNCTIONS

        private void GetConnection()
        {
            switch (GlobVar.RTCVision.RunOptions.SLMPType)
            {
                case 0:
                    {
                        MyMCProtocolTCP = null;
                        if (GlobVar.MyListMCPTCP != null)
                            MyMCProtocolTCP =
                                GlobVar.MyListMCPTCP.FirstOrDefault(x =>
                                    x.IP == IPAddress.rtcValue && x.Port == PortNumber.rtcValue);

                        if (MyMCProtocolTCP == null)
                        {
                            MyMCProtocolTCP = new SLMPClient(IPAddress.rtcValue, PortNumber.rtcValue);
                            if (GlobVar.MyListMCPTCP == null) GlobVar.MyListMCPTCP = new List<SLMPClient>();
                            GlobVar.MyListMCPTCP.Add(MyMCProtocolTCP);
                        }

                        if (MyMCProtocolTCP != null && !MyMCProtocolTCP.IsConnected)
                        {
                            MyMCProtocolTCP.Disconnect();
                            MyMCProtocolTCP.Connect();
                            ErrMessage.rtcValue = new List<String>() { MyMCProtocolTCP.ErrMessage };
                            if (ErrMessage.rtcValue[0] == cStrings.Disconnect)
                                ErrMessage.rtcValue = new List<string> {cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() },
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() }) };
                        }
                        break;
                    }
                case 1:
                    {
                        SLMP1 = null;
                        if (GlobVar.MyListSLMP1 != null)
                            SLMP1 =
                                GlobVar.MyListSLMP1.FirstOrDefault(x =>
                                    x.IPAddress == IPAddress.rtcValue && x.Port == PortNumber.rtcValue);

                        if (SLMP1 == null)
                        {
                            SLMP1 = new cSlmpCustom(IPAddress.rtcValue, PortNumber.rtcValue);
                            SLMP1.ConnectSocket();
                            if (GlobVar.MyListSLMP1 == null) GlobVar.MyListSLMP1 = new List<cSlmpCustom>();
                            GlobVar.MyListSLMP1.Add(SLMP1);
                        }

                        if (SLMP1 != null && !SLMP1.Connected)
                        {
                            SLMP1.CloseSocket();
                            SLMP1.ConnectSocket();
                            if (!SLMP1.Connected)
                                ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { Name.rtcValue, SLMP1.IPAddress, SLMP1.Port.ToString() },
                                    new string[] { Name.rtcValue, SLMP1.IPAddress, SLMP1.Port.ToString() }) };
                        }
                        break;
                    }
            }

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Run SLMP Read with test mode. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SLMPRead_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_SLMPRead();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
            //if (this.ViewInfo != null)
            //    ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Runs the SLMP read. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SLMPRead()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>(){string.Empty};
            Value.rtcValue = new List<string>();

            if (GlobVar.IsSimulatorMode)
            {
                Value.rtcValue = SimulatorValue.rtcValue;
                if (IsUseValueTypesConvert.rtcValue && ValueTypes.rtcValue != ValueTypesConvert.rtcValue)
                    Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);

                Passed.rtcValue = true;

                if (IsCompareValue.rtcValue)
                {
                   
                    bool equal = Value.rtcValue.Equals(CompareValue.rtcValue);
                    Passed.rtcValue = equal;
                }
                return;
            }

            GetConnection();

            switch (GlobVar.RTCVision.RunOptions.SLMPType)
            {
                case 0:
                    {
                        if (MyMCProtocolTCP.IsConnected)
                        {
                            bool success = false;
                            string[] arrAddress = new string[] { };
                            if (Address.rtcValue.Contains(cChars.Semicolon))
                                arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                            else
                                arrAddress = Address.rtcValue.Split(cChars.Comma);
                            foreach (string address in arrAddress)
                            {
                                switch (ValueTypes.rtcValue)
                                {
                                    case cSLMPValueTypes.BIT:
                                        //Value.rtcValue.Append(new HTuple(MyMCProtocolTCP.ReadBit(address, out success)));
                                        Value.rtcValue.Add(GlobFuncs.ListInt2Str(MyMCProtocolTCP.ReadBitBlock(address, ValueLength.rtcValue, out success).ToList()));
                                        break;
                                    case cSLMPValueTypes.BITRegister:
                                        Value.rtcValue.Add((MyMCProtocolTCP.ReadBitRegister(address, out success)).ToString());
                                        break;
                                    case cSLMPValueTypes.Word:
                                        //Value.rtcValue.Append(new HTuple(MyMCProtocolTCP.ReadWord(address, out success)));
                                        Value.rtcValue.Add(GlobFuncs.ListInt2Str(MyMCProtocolTCP.ReadWordBlock(address, ValueLength.rtcValue, out success).ToList()));

                                        break;
                                    case cSLMPValueTypes.Dword:
                                        //Value.rtcValue.Append(new HTuple(MyMCProtocolTCP.ReadDword(address, out success)));
                                        Value.rtcValue.Add(GlobFuncs.ListInt2Str(MyMCProtocolTCP.ReadDwordBlock(address, ValueLength.rtcValue, out success).ToList()));

                                        break;
                                    case cSLMPValueTypes.Real:
                                        Value.rtcValue.Add(MyMCProtocolTCP.ReadFloatBlock(address, ValueLength.rtcValue, out success).ToString());
                                        break;
                                    case cSLMPValueTypes.String:
                                        Value.rtcValue.Append((MyMCProtocolTCP.ReadString(address, ValueLength.rtcValue, out success)));
                                        break;
                                }
                                //Thread.Sleep(50);
                                if (!success) break;
                            }

                            Value.rtcValue = Value.rtcValue;

                            if (IsUseValueTypesConvert.rtcValue && ValueTypes.rtcValue != ValueTypesConvert.rtcValue)
                                Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);

                            Passed.rtcValue = success;

                            if (IsCompareValue.rtcValue)
                            {
                               
                                bool IsEqual = Value.rtcValue.Equals(CompareValue.rtcValue);
                                Passed.rtcValue = IsEqual;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(ErrMessage.rtcValue[0]))
                                ErrMessage.rtcValue = new List<string>() {cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() },
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() })};
                        }
                        break;
                    }
                case 1:
                    {
                        if (SLMP1.Connected)
                        {
                            bool success = false;
                            string[] arrAddress = new string[] { };
                            if (Address.rtcValue.Contains(cChars.Semicolon))
                                arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                            else
                                arrAddress = Address.rtcValue.Split(cChars.Comma);
                            foreach (string address in arrAddress)
                            {
                                switch (ValueTypes.rtcValue)
                                {
                                    case cSLMPValueTypes.BITRegister:
                                        {
                                            success = SLMP1.Bit(address, out bool valueResult);
                                            Value.rtcValue.Add(valueResult ? "1" : "0");
                                            break;
                                        }
                                    case cSLMPValueTypes.Word:
                                        {
                                            success = SLMP1.ReceiveWord(address, out int[] valueResult);
                                            Value.rtcValue.Add(valueResult[0].ToString());
                                            break;
                                        }
                                    case cSLMPValueTypes.Dword:
                                        {
                                            if (address.Contains("."))
                                                success = false;
                                            else
                                            {
                                                success = SLMP1.ReceiveDWord(address, out int valueResult);
                                                if (success)
                                                    Value.rtcValue.Add(valueResult.ToString());
                                            }
                                            break;
                                        }
                                }

                                //success = SLMP1.ReceiveWord(address, out int[] valueResult);
                                //Value.rtcValue.Append(new HTuple(valueResult[0]));
                                if (!success) break;
                            }

                            Value.rtcValue = Value.rtcValue;

                            if (IsUseValueTypesConvert.rtcValue && ValueTypes.rtcValue != ValueTypesConvert.rtcValue)
                                Value.rtcValue = GlobFuncs.V2NewType(Value.rtcValue, ValueTypesConvert.rtcValue);

                            Passed.rtcValue = success;

                            if (IsCompareValue.rtcValue)
                            {
                                
                                bool IsEqual = Value.rtcValue.Equals(CompareValue.rtcValue);
                                Passed.rtcValue = IsEqual;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(ErrMessage.rtcValue[0]))
                                ErrMessage.rtcValue = new List<string>() {cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() },
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() }) };
                        }
                        break;
                    }
            }
        }

        //private void Run_SLMPWrite_Process(string address, int value)
        //{
        //    switch (ValueTypes.rtcValue)
        //    {
        //        case cSLMPValueTypes.BIT:
        //            Passed.rtcValue = MyMCProtocolTCP.WriteBit(address, SLMPClient.ObToInt(value));
        //            break;
        //        case cSLMPValueTypes.BITRegister:
        //            Passed.rtcValue = MyMCProtocolTCP.WriteBitRegister(address, SLMPClient.ObToInt(value));
        //            break;
        //        case cSLMPValueTypes.Word:
        //            Passed.rtcValue = MyMCProtocolTCP.WriteInt(address, SLMPClient.ObToInt(value));
        //            break;
        //        case cSLMPValueTypes.DWord:
        //            Passed.rtcValue = MyMCProtocolTCP.WriteDword(address, SLMPClient.ObToInt(value));
        //            break;
        //        case cSLMPValueTypes.Real:
        //            Passed.rtcValue = MyMCProtocolTCP.WriteFloat(address, SLMPClient.ObToFloat(value));
        //            break;
        //        case cSLMPValueTypes.String:
        //            Passed.rtcValue = MyMCProtocolTCP.WriteString(address, SLMPClient.ObToString(value));
        //            break;
        //    }
        //}
        /// <summary>Executes the slmp write alive operation.</summary>
        /// <remarks>DATRUONG, 11/11/2021.</remarks>
        /// <param name="isUseDelay">(Optional) True if is use delay, false if not.</param>

        public void Run_SLMPWrite_Alive(bool isUseDelay = true)
        {
            Passed.rtcValue = false;

            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            switch (GlobVar.RTCVision.RunOptions.SLMPType)
            {
                case 0:
                    {
                        MyMCProtocolTCP = null;
                        if (GlobVar.MyListMCPTCP != null)
                            MyMCProtocolTCP =
                                GlobVar.MyListMCPTCP.FirstOrDefault(x =>
                                    x.IP == IPAddress.rtcValue && x.Port == PortNumber.rtcValue);

                        if (MyMCProtocolTCP == null)
                        {
                            MyMCProtocolTCP = new SLMPClient(IPAddress.rtcValue, PortNumber.rtcValue);
                            MyMCProtocolTCP.Connect();
                            if (GlobVar.MyListMCPTCP == null) GlobVar.MyListMCPTCP = new List<SLMPClient>();
                            GlobVar.MyListMCPTCP.Add(MyMCProtocolTCP);
                        }
                        else if (!MyMCProtocolTCP.IsConnected)
                            MyMCProtocolTCP.Connect();

                        if (MyMCProtocolTCP.IsConnected)
                        {
                            string[] arrAddress = new string[] { };
                            if (Address.rtcValue.Contains(cChars.Semicolon))
                                arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                            else
                                arrAddress = Address.rtcValue.Split(cChars.Comma);
                            foreach (string address in arrAddress)
                            {
                                switch (ValueTypes.rtcValue)
                                {
                                    case cSLMPValueTypes.BIT:
                                        Passed.rtcValue = MyMCProtocolTCP.WriteBit(address, SLMPClient.ObToInt(AliveValue));
                                        break;
                                    case cSLMPValueTypes.BITRegister:
                                        Passed.rtcValue = MyMCProtocolTCP.WriteBitRegister(address, SLMPClient.ObToInt(AliveValue));
                                        break;
                                    case cSLMPValueTypes.Word:
                                        Passed.rtcValue = MyMCProtocolTCP.WriteInt(address, SLMPClient.ObToInt(AliveValue));
                                        break;
                                    case cSLMPValueTypes.Dword:
                                        Passed.rtcValue = MyMCProtocolTCP.WriteDword(address, SLMPClient.ObToInt(AliveValue));
                                        break;
                                    case cSLMPValueTypes.Real:
                                        Passed.rtcValue = MyMCProtocolTCP.WriteFloat(address, SLMPClient.ObToFloat(AliveValue));
                                        break;
                                    case cSLMPValueTypes.String:
                                        Passed.rtcValue = MyMCProtocolTCP.WriteString(address, SLMPClient.ObToString(AliveValue));
                                        break;
                                }

                                if (!Passed.rtcValue) break;
                            }
                            AliveValue = AliveValue == 0 ? 1 : 0;
                        }

                        if (isUseDelay)
                            Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_SLMPWrite_Alive(false));
                        break;
                    }
                case 1:
                    {
                        SLMP1 = null;
                        if (GlobVar.MyListSLMP1 != null)
                            SLMP1 =
                                GlobVar.MyListSLMP1.FirstOrDefault(x =>
                                    x.IPAddress == IPAddress.rtcValue && x.Port == PortNumber.rtcValue);

                        if (SLMP1 == null)
                        {
                            SLMP1 = new cSlmpCustom(IPAddress.rtcValue, PortNumber.rtcValue);
                            SLMP1.ConnectSocket();
                            if (GlobVar.MyListSLMP1 == null) GlobVar.MyListSLMP1 = new List<cSlmpCustom>();
                            GlobVar.MyListSLMP1.Add(SLMP1);
                        }
                        else if (!SLMP1.Connected)
                            SLMP1.ConnectSocket();

                        if (SLMP1.ConnectSocket())
                        {
                            string[] arrAddress = new string[] { };
                            if (Address.rtcValue.Contains(cChars.Semicolon))
                                arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                            else
                                arrAddress = Address.rtcValue.Split(cChars.Comma);

                            foreach (string address in arrAddress)
                            {
                                Passed.rtcValue = SLMP1.SendWord(new int[] { SLMPClient.ObToInt(AliveValue) }, address);
                                if (!Passed.rtcValue) break;
                            }
                            AliveValue = AliveValue == 0 ? 1 : 0;
                        }

                        if (isUseDelay)
                            Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_SLMPWrite_Alive(false));
                        break;
                    }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Run SLMP Write with delay mode. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SLMPWrite_AfterDelay()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            if (ValueAfterDelay.rtcValue == null || ValueAfterDelay.rtcValue.Count <= 0)
                return;

            switch (GlobVar.RTCVision.RunOptions.SLMPType)
            {
                case 0:
                    {
                        MyMCProtocolTCP = null;
                        if (GlobVar.MyListMCPTCP != null)
                            MyMCProtocolTCP =
                                GlobVar.MyListMCPTCP.FirstOrDefault(x =>
                                    x.IP == IPAddress.rtcValue && x.Port == PortNumber.rtcValue);

                        if (MyMCProtocolTCP == null)
                        {
                            MyMCProtocolTCP = new SLMPClient(IPAddress.rtcValue, PortNumber.rtcValue);
                            if (GlobVar.MyListMCPTCP == null) GlobVar.MyListMCPTCP = new List<SLMPClient>();
                            GlobVar.MyListMCPTCP.Add(MyMCProtocolTCP);
                        }

                        if (MyMCProtocolTCP != null && !MyMCProtocolTCP.IsConnected)
                        {
                            MyMCProtocolTCP.Disconnect();
                            MyMCProtocolTCP.Connect();
                            ErrMessage.rtcValue = new List<string>() { MyMCProtocolTCP.ErrMessage };
                            if (ErrMessage.rtcValue[0] == cStrings.Disconnect)
                                ErrMessage.rtcValue = new List<string> {cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() },
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() }) };
                        }

                        if (!MyMCProtocolTCP.IsConnected) return;

                        MyMCProtocolTCP.BitMode = (BitMode.rtcValue == cSLMPWriteBitMode.BIT16 ? 16 : 32);

                        string[] arrAddress = new string[] { };
                        if (Address.rtcValue.Contains(cChars.Semicolon))
                            arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                        else
                            arrAddress = Address.rtcValue.Split(cChars.Comma);
                        int iIndexHtuple = 0;
                        foreach (string address in arrAddress)
                        {
                            if (iIndexHtuple >= ValueAfterDelay.rtcValue.Count) break;

                            switch (ValueTypes.rtcValue)
                            {
                                case cSLMPValueTypes.BIT:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteBit(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue[iIndexHtuple], true, true)));
                                    break;
                                case cSLMPValueTypes.BITRegister:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteBitRegister(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue[iIndexHtuple], true, true)));
                                    break;
                                case cSLMPValueTypes.Word:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteInt(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue[iIndexHtuple])));
                                    break;
                                case cSLMPValueTypes.Dword:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteDword(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue[iIndexHtuple])));
                                    break;
                                case cSLMPValueTypes.Real:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteFloat(address, SLMPClient.ObToFloat(GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue[iIndexHtuple])));
                                    break;
                                case cSLMPValueTypes.String:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteString(address, SLMPClient.ObToString(GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue[iIndexHtuple])));
                                    break;
                            }
                            //Thread.Sleep(50);
                            if (!Passed.rtcValue) break;
                            iIndexHtuple += 1;
                        }
                        break;
                    }
                case 1:
                    {
                        GetConnection();

                        if (SLMP1 == null || !SLMP1.Connected) return;

                        string[] arrAddress = new string[] { };
                        if (Address.rtcValue.Contains(cChars.Semicolon))
                            arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                        else
                            arrAddress = Address.rtcValue.Split(cChars.Comma);
                        int iIndexHtuple = 0;
                        foreach (string address in arrAddress)
                        {
                            if (iIndexHtuple >= ValueAfterDelay.rtcValue.Count) break;
                            Passed.rtcValue = SLMP1.SendWord(new int[] { SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterDelay.rtcValue[iIndexHtuple])) }, address);
                            if (!Passed.rtcValue) break;
                            //Thread.Sleep(50);
                            if (!Passed.rtcValue) break;
                            iIndexHtuple += 1;
                        }
                        break;
                    }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Run SLMP Write when run stop. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SLMPWrite_AfterStop()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            if (ValueAfterStop.rtcValue == null || ValueAfterStop.rtcValue.Count <= 0)
                return;
            switch (GlobVar.RTCVision.RunOptions.SLMPType)
            {
                case 0:
                    {
                        MyMCProtocolTCP = null;
                        if (GlobVar.MyListMCPTCP != null)
                            MyMCProtocolTCP =
                                GlobVar.MyListMCPTCP.FirstOrDefault(x =>
                                    x.IP == IPAddress.rtcValue && x.Port == PortNumber.rtcValue);

                        if (MyMCProtocolTCP == null)
                        {
                            MyMCProtocolTCP = new SLMPClient(IPAddress.rtcValue, PortNumber.rtcValue);
                            if (GlobVar.MyListMCPTCP == null) GlobVar.MyListMCPTCP = new List<SLMPClient>();
                            GlobVar.MyListMCPTCP.Add(MyMCProtocolTCP);
                        }

                        if (MyMCProtocolTCP != null && !MyMCProtocolTCP.IsConnected)
                        {
                            MyMCProtocolTCP.Disconnect();
                            MyMCProtocolTCP.Connect();
                            ErrMessage.rtcValue = new List<string>() { MyMCProtocolTCP.ErrMessage };
                            if (ErrMessage.rtcValue[0] == cStrings.Disconnect)
                                ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() },
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() }) };
                        }

                        if (!MyMCProtocolTCP.IsConnected) return;

                        MyMCProtocolTCP.BitMode = (BitMode.rtcValue == cSLMPWriteBitMode.BIT16 ? 16 : 32);

                        string[] arrAddress = new string[] { };
                        if (Address.rtcValue.Contains(cChars.Semicolon))
                            arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                        else
                            arrAddress = Address.rtcValue.Split(cChars.Comma);
                        int iIndexHtuple = 0;
                        foreach (string address in arrAddress)
                        {
                            if (iIndexHtuple >= ValueAfterStop.rtcValue.Count) break;

                            switch (ValueTypes.rtcValue)
                            {
                                case cSLMPValueTypes.BIT:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteBit(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterStop.rtcValue[iIndexHtuple], true, true)));
                                    break;
                                case cSLMPValueTypes.BITRegister:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteBitRegister(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterStop.rtcValue[iIndexHtuple], true, true)));
                                    break;
                                case cSLMPValueTypes.Word:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteInt(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterStop.rtcValue[iIndexHtuple])));
                                    break;
                                case cSLMPValueTypes.Dword:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteDword(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterStop.rtcValue[iIndexHtuple])));
                                    break;
                                case cSLMPValueTypes.Real:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteFloat(address, SLMPClient.ObToFloat(GlobFuncs.Ve2Str(ValueAfterStop.rtcValue[iIndexHtuple])));
                                    break;
                                case cSLMPValueTypes.String:
                                    Passed.rtcValue = MyMCProtocolTCP.WriteString(address, SLMPClient.ObToString(GlobFuncs.Ve2Str(ValueAfterStop.rtcValue[iIndexHtuple])));
                                    break;
                            }
                            if (!Passed.rtcValue) break;
                            iIndexHtuple += 1;
                        }
                        break;
                    }
                case 1:
                    {
                        GetConnection();
                        if (SLMP1 == null || !SLMP1.Connected) return;

                        string[] arrAddress = new string[] { };
                        if (Address.rtcValue.Contains(cChars.Semicolon))
                            arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                        else
                            arrAddress = Address.rtcValue.Split(cChars.Comma);
                        int iIndexHtuple = 0;
                        foreach (string address in arrAddress)
                        {
                            if (iIndexHtuple >= ValueAfterStop.rtcValue.Count) break;
                            Passed.rtcValue = SLMP1.SendWord(new int[] { SLMPClient.ObToInt(GlobFuncs.Ve2Str(ValueAfterStop.rtcValue[iIndexHtuple], true, true)) }, address);
                            if (!Passed.rtcValue) break;
                            //Thread.Sleep(50);
                            if (!Passed.rtcValue) break;
                            iIndexHtuple += 1;
                        }
                        break;
                    }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Runs the SLMP write. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="isTest">   (Optional) True if is test, false if not. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SLMPWrite(bool isTest = false)
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
                    Run_SLMPWrite_Alive();
                return;
            }

            GetConnection();

            switch (GlobVar.RTCVision.RunOptions.SLMPType)
            {
                case 0:
                    {
                        if (MyMCProtocolTCP.IsConnected)
                        {
                            Passed.rtcValue = true;
                            MyMCProtocolTCP.BitMode = (BitMode.rtcValue == cSLMPWriteBitMode.BIT16 ? 16 : 32);

                            if (Value.rtcValue == null || Value.rtcValue.Count <= 0)
                                return;
                            if (IsCompareValue.rtcValue)
                            {
                                
                                bool IsEqual = Value.rtcValue.Equals(CompareValue.rtcValue);
                                Passed.rtcValue = IsEqual;
                            }

                            if (Passed.rtcValue)
                            {
                                string[] arrAddress = new string[] { };
                                if (Address.rtcValue.Contains(cChars.Semicolon))
                                    arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                                else
                                    arrAddress = Address.rtcValue.Split(cChars.Comma);

                                int iIndexHtuple = 0;
                                foreach (string address in arrAddress)
                                {
                                    if (iIndexHtuple >= Value.rtcValue.Count) break;

                                    switch (ValueTypes.rtcValue)
                                    {
                                        case cSLMPValueTypes.BIT:
                                            Passed.rtcValue = MyMCProtocolTCP.WriteBit(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple], true, true)));
                                            break;
                                        case cSLMPValueTypes.BITRegister:
                                            Passed.rtcValue = MyMCProtocolTCP.WriteBitRegister(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple], true, true)));
                                            break;
                                        case cSLMPValueTypes.Word:
                                           // string[] test= Value.rtcValue[0].Split(',');
                                            Passed.rtcValue = MyMCProtocolTCP.WriteInt(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple])));
                                            break;
                                        case cSLMPValueTypes.Dword:
                                            Passed.rtcValue = MyMCProtocolTCP.WriteDword(address, SLMPClient.ObToInt(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple])));
                                            break;
                                        case cSLMPValueTypes.Real:
                                            Passed.rtcValue = MyMCProtocolTCP.WriteFloat(address, SLMPClient.ObToFloat(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple])));
                                            break;
                                        case cSLMPValueTypes.String:
                                            Passed.rtcValue = MyMCProtocolTCP.WriteString(address, SLMPClient.ObToString(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple])));
                                            break;
                                    }
                                    //Thread.Sleep(50);
                                    if (!Passed.rtcValue) break;
                                    iIndexHtuple += 1;
                                }
                            }
                            if (IsRunOneTime.rtcValue && !isTest)
                                IsFinishRunOneTime.rtcValue = Passed.rtcValue;

                            if (Passed.rtcValue && TimeDelay.rtcValue > 0)
                            {
                                if (WaitMode.rtcValue == cStrings.ASync || isTest)
                                    Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_SLMPWrite_AfterDelay());
                                else
                                {
                                    Thread.Sleep(TimeDelay.rtcValue);
                                    Run_SLMPWrite_AfterDelay();
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(ErrMessage.rtcValue[0]))
                                ErrMessage.rtcValue = new List<string> {cMessageContent.BuildMessage(cMessageContent.War_SLMPOfActionCanNotConnect,
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() },
                                    new string[] { Name.rtcValue, MyMCProtocolTCP.IP, MyMCProtocolTCP.Port.ToString() }) };
                        }
                        break;
                    }
                case 1:
                    {
                        GetConnection();
                        if (SLMP1 == null || !SLMP1.Connected) return;
                        if (ValueTypes.rtcValue == cSLMPValueTypes.ArrayDWord)
                        {
                            int[] arrayDword = GlobFuncs.Ve2ArrayInt(Value.rtcValue);
                            Passed.rtcValue = SLMP1.SendArrayDWord(arrayDword, Address.rtcValue);
                        }
                        else
                        {
                            string[] arrAddress = new string[] { };
                            if (Address.rtcValue.Contains(cChars.Semicolon))
                                arrAddress = Address.rtcValue.Split(cChars.Semicolon);
                            else
                                arrAddress = Address.rtcValue.Split(cChars.Comma);
                            int iIndexHtuple = 0;
                            foreach (string address in arrAddress)
                            {
                                if (iIndexHtuple >= Value.rtcValue.Count) break;
                                switch (ValueTypes.rtcValue)
                                {
                                    case cSLMPValueTypes.BITRegister:
                                        Passed.rtcValue = SLMP1.SendBit(SLMPClient.ObToByte(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple])), address);
                                        break;
                                    case cSLMPValueTypes.Word:
                                        Passed.rtcValue = SLMP1.SendWord(new int[] { SLMPClient.ObToInt(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple])) }, address);
                                        break;
                                    case cSLMPValueTypes.Dword:
                                        Passed.rtcValue = SLMP1.SendDWord(new int[] { SLMPClient.ObToInt(GlobFuncs.Ve2Str(Value.rtcValue[iIndexHtuple])) }, address);
                                        break;
                                }
                                if (!Passed.rtcValue) break;
                                iIndexHtuple += 1;
                            }
                        }
                        
                        break;
                    }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Run SLMP Write with test mode. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SLMPWrite_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_SLMPWrite(true);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }

        #endregion
    }
}
