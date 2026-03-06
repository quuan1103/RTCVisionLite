using System;
using System.Collections;
using RTCConst;
using System.Collections.Generic;
using System.Threading;
using RTC_Vision_Lite.PublicFunctions;
using System.Diagnostics;
using System.Threading.Tasks;
using NsIOControllerSDK.VC3000;
using RTC_Vision_Lite.UserControls;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        #region POCIOController FUNCTIONS
        public void Run_POCIORead_Test()
        {
            CTTest(Run_POCIORead);
            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        /// <summary>
        /// Chạy tool
        /// </summary>
        public void Run_POCIORead()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();
            Value.rtcValue = new List<string> { };

            if (GlobVar.IsSimulatorMode)
            {
                Value.rtcValue = SimulatorValue.rtcValue;
                Passed.rtcValue = true;
                if (IsCompareValue.rtcValue)
                {
                  
                    Passed.rtcValue = Value.rtcValue.Equals(CompareValue.rtcValue);
                }

                return;
            }

            if (!MyGroup.RunSimple && !WDT_DIO.InitDIO())
            {
                ErrMessage.rtcValue = new List<string> {cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "POC IO" }, new string[] { "POC IO" }) };
                return;
            }

            switch (SourceMode.rtcValue)
            {
                case cPOCIOSourceMode.Channel:
                    {
                        for (int i = 0; i < Channel.rtcValue.Count; i++)
                            try
                            {
                                Value.rtcValue.Add(WDT_DIO.DIReadLine((byte)Channel.rtcValue[i]) ? "1": "0");
                            }
                            catch (Exception e)
                            {
                                ErrMessage.rtcValue = new List<string> { e.Message };
                                return;
                            }

                        Value.rtcValue = Value.rtcValue;

                        if (IsCompareValue.rtcValue)
                        {
                            Passed.rtcValue = Value.rtcValue.Equals(CompareValue.rtcValue);
                        }
                        else
                            Passed.rtcValue = true;
                        break;
                    }
                case cPOCIOSourceMode.Port:
                    {
                        int value = WDT_DIO.DIReadPort();
                        switch (ValueTypes.rtcValue)
                        {
                            case cPOCIOValueTypes.Word:
                                {
                                    Value.rtcValue = new List<string> { value.ToString() };
                                    break;
                                }
                            case cPOCIOValueTypes.Hexa:
                                {
                                    Value.rtcValue = new List<string> { string.Format("0x{0:x}", value) };
                                    break;
                                }
                            case cPOCIOValueTypes.ByteArray:
                                {
                                    for (int i = 0; i < 16; i++)
                                        Value.rtcValue.Add(((value >> i) & 0x01).ToString());
                                    Value.rtcValue = Value.rtcValue;
                                    break;
                                }
                        }

                        if (IsCompareValue.rtcValue)
                        {
                            Passed.rtcValue = Value.rtcValue.Equals(CompareValue.rtcValue);
                        }
                        else
                            Passed.rtcValue = true;
                        break;
                    }
            }
        }
        /// <summary>
        /// Chạy truyền thông IO gửi dạng tín hiệu alive
        /// </summary>
        /// <param name="isUseDelay"></param>
        public void Run_POCIOWrite_Alive(bool isUseDelay = true)
        {
            if (GlobVar.IsSimulatorMode || !MyGroup.IsRun)
            {
                Passed.rtcValue = true;
                return;
            }
            if (!MyGroup.RunSimple && !WDT_DIO.InitDIO())
            {
                ErrMessage.rtcValue = new List<string> {cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "POC IO" }, new string[] { "POC IO" }) };
                return;
            }

            switch (SourceMode.rtcValue)
            {
                case cPOCIOSourceMode.Channel:
                    {
                        for (int i = 0; i < Channel.rtcValue.Count; i++)
                        {
                            int iChannel = GlobFuncs.Ve2Interger(Channel.rtcValue[i]);

                            if (ValueAfterDelay.rtcValue.Count > i)
                            {
                                int iValue = GlobFuncs.Ve2Interger(ValueAfterDelay.rtcValue[i]);
                                WDT_DIO.DOWriteLine((byte)iChannel, AliveValue != 0);
                            }
                            else
                            {
                                ErrMessage.rtcValue = new List<string> { "Data Can't Empty./nPlease Check Again." };
                                return;
                            }
                        }
                        break;
                    }
                case cPOCIOSourceMode.Port:
                    {
                        try
                        {
                            WDT_DIO.DOWritePort((ushort)AliveValue);
                        }
                        catch (Exception e)
                        {
                            ErrMessage.rtcValue = new List<string> { e.Message };
                            return;
                        }
                        break;
                    }
            }

            AliveValue = AliveValue == 0 ? 1 : 0;
            if (isUseDelay)
                Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_POCIOWrite_Alive());
        }
        /// <summary>
        /// Chạy truyền thông IO gửi 1 giá trị sau giá trị chính sau 1 khoảng thời gian thiết lập
        /// </summary>
        public void Run_POCIOWrite_AfterDelay()
        {
            switch (SourceMode.rtcValue)
            {
                case cPOCIOSourceMode.Channel:
                    {
                        for (int i = 0; i < Channel.rtcValue.Count; i++)
                        {
                            int iChannel = GlobFuncs.Ve2Interger(Channel.rtcValue[i]);

                            if (ValueAfterDelay.rtcValue.Count > i)
                            {
                                int iValue = GlobFuncs.Ve2Interger(ValueAfterDelay.rtcValue[i]);
                                WDT_DIO.DOWriteLine((byte)iChannel, iValue != 0);
                            }
                            else
                            {
                                ErrMessage.rtcValue = new List<string> { "Data Is Not Correct./nPlease Check Again." };
                                return;
                            }
                        }
                        break;
                    }
                case cPOCIOSourceMode.Port:
                    {
                        switch (ValueTypes.rtcValue)
                        {
                            case cPOCIOValueTypes.Word:
                                {
                                    if(ValueAfterDelay?.rtcValue.Count > 0)
                                    if (int.TryParse(ValueAfterDelay?.rtcValue[0], out int iValue))
                                        WDT_DIO.DOWritePort((ushort)iValue);
                                    break;
                                }
                            case cPOCIOValueTypes.Hexa:
                                {
                                    try
                                    {
                                        if (ValueAfterDelay?.rtcValue.Count > 0)
                                        {
                                            int iValue = Convert.ToInt32(ValueAfterDelay.rtcValue[0], 16);
                                            WDT_DIO.DOWritePort((ushort)iValue);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        ErrMessage.rtcValue = new List<string> { e.Message };
                                        return;
                                    }
                                    break;
                                }
                            case cPOCIOValueTypes.ByteArray:
                                {
                                    try
                                    {
                                        int value = 0;
                                        for (int i = 0; i < ValueAfterDelay.rtcValue.Count; i++)
                                        {
                                            if (i > 15)
                                                break;
                                            if (GlobFuncs.Ve2Interger(ValueAfterDelay.rtcValue[i]) != 0)
                                                value |= (UInt16)(1 << i);
                                        }
                                        WDT_DIO.DOWritePort((ushort)value);
                                    }
                                    catch (Exception e)
                                    {
                                        ErrMessage.rtcValue = new List<string> { e.Message };
                                        return;
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        /// <summary>
        /// Chạy truyền thông IO khi stop chu trình chạy
        /// </summary>
        public void Run_POCIOWrite_AfterStop()
        {
            switch (SourceMode.rtcValue)
            {
                case cPOCIOSourceMode.Channel:
                    {
                        for (int i = 0; i < Channel.rtcValue.Count; i++)
                        {
                            int iChannel = GlobFuncs.Ve2Interger(Channel.rtcValue[i]);

                            if (ValueAfterStop.rtcValue.Count > i)
                            {
                                int iValue = GlobFuncs.Ve2Interger(ValueAfterStop.rtcValue[i]);
                                WDT_DIO.DOWriteLine((byte)iChannel, iValue != 0);
                            }
                            else
                            {
                                ErrMessage.rtcValue = new List<string> { "Data Is Not Correct./nPlease Check Again." };
                                return;
                            }
                        }
                        break;
                    }
                case cPOCIOSourceMode.Port:
                    {
                        switch (ValueTypes.rtcValue)
                        {
                            case cPOCIOValueTypes.Word:
                                {
                                    if (ValueAfterDelay?.rtcValue.Count > 0)
                                        if (int.TryParse(ValueAfterStop.rtcValue[0], out int iValue))
                                        WDT_DIO.DOWritePort((ushort)iValue);
                                    break;
                                }
                            case cPOCIOValueTypes.Hexa:
                                {
                                    try
                                    {
                                        if (ValueAfterDelay?.rtcValue.Count > 0)
                                        {
                                            int iValue = Convert.ToInt32(ValueAfterStop.rtcValue[0], 16);
                                            WDT_DIO.DOWritePort((ushort)iValue);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        ErrMessage.rtcValue = new List<string> { e.Message };
                                        return;
                                    }
                                    break;
                                }
                            case cPOCIOValueTypes.ByteArray:
                                {
                                    try
                                    {
                                        int value = 0;
                                        for (int i = 0; i < ValueAfterStop.rtcValue.Count; i++)
                                        {
                                            if (i > 15)
                                                break;
                                            if (GlobFuncs.Ve2Interger(Value.rtcValue[i]) != 0)
                                                value |= (UInt16)(1 << i);
                                        }
                                        WDT_DIO.DOWritePort((ushort)value);
                                    }
                                    catch (Exception e)
                                    {
                                        ErrMessage.rtcValue = new List<string> { e.Message };
                                        return;
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        public void Run_POCIOWrite(bool isTest = false)
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string> { string.Empty };

            if (!MyGroup.RunSimple && !WDT_DIO.InitDIO() && !WDT_DIO.InitWDT())
            {
                ErrMessage.rtcValue = new List<string> { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "POC IO" }, new string[] { "POC IO" }) };
                return;
            }

            switch (SourceMode.rtcValue)
            {
                case cPOCIOSourceMode.Channel:
                    {
                        for (int i = 0; i < Channel.rtcValue.Count; i++)
                        {
                            int iChannel = GlobFuncs.Ve2Interger(Channel.rtcValue[i]);

                            if (Value.rtcValue.Count > i)
                            {
                                int iValue = GlobFuncs.Ve2Interger(Value.rtcValue[i]);
                                WDT_DIO.DOWriteLine((byte)iChannel, iValue != 0);
                            }
                            else
                            {
                                ErrMessage.rtcValue = new List<string> { "Data Is Not Correct./nPlease Check Again." };
                                return;
                            }
                        }

                        Passed.rtcValue = true;
                        if (IsRunOneTime.rtcValue && !isTest)
                            IsFinishRunOneTime.rtcValue = Passed.rtcValue;

                        if (Passed.rtcValue && TimeDelay.rtcValue > 0)
                        {
                            if (WaitMode.rtcValue == cStrings.ASync || isTest)
                                Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_POCIOWrite_AfterDelay());
                            else
                            {
                                Thread.Sleep(TimeDelay.rtcValue);
                                Run_POCIOWrite_AfterDelay();
                            }
                        }

                        break;
                    }
                case cPOCIOSourceMode.Port:
                    {
                        switch (ValueTypes.rtcValue)
                        {
                            case cPOCIOValueTypes.Word:
                                {
                                    if (ValueAfterDelay?.rtcValue.Count > 0)
                                        if (int.TryParse(Value.rtcValue[0], out int iValue))
                                        WDT_DIO.DOWritePort((ushort)iValue);
                                    break;
                                }
                            case cPOCIOValueTypes.Hexa:
                                {
                                    try
                                    {
                                        if (ValueAfterDelay?.rtcValue.Count > 0)
                                        {
                                            int iValue = Convert.ToInt32(Value.rtcValue[0], 16);
                                            WDT_DIO.DOWritePort((ushort)iValue);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        ErrMessage.rtcValue = new List<string> { e.Message };
                                        return;
                                    }
                                    break;
                                }
                            case cPOCIOValueTypes.ByteArray:
                                {
                                    try
                                    {
                                        int value = 0;
                                        for (int i = 0; i < Value.rtcValue.Count; i++)
                                        {
                                            if (i > 15)
                                                break;
                                            if (GlobFuncs.Ve2Interger(Value.rtcValue[i]) != 0)
                                                value |= (UInt16)(1 << i);
                                        }
                                        WDT_DIO.DOWritePort((ushort)value);
                                    }
                                    catch (Exception e)
                                    {
                                        ErrMessage.rtcValue = new List<string> { e.Message };
                                        return;
                                    }
                                    break;
                                }
                        }

                        Passed.rtcValue = true;
                        break;
                    }
            }
        }
        public void Run_POCIOWrite_Test()
        {
            CTTest(() =>
            {
                Run_POCIOWrite(true);
            });
        }

        #endregion
    }
}
