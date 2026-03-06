using NsIOControllerSDK.VC3000;
using RTCConst;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NsIOControllerSDK.VC3000X;
using RTCEnums;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        internal CIOControllerSDK3000X MyVC3000X = null;
        private int[] _visionBoxAddress = new int[] { };
        #region IOController FUNCTIONS
        private enum PNP_ENABLE_STATE
        {
            PNP = 0x01,
            NPN = 0x02,
        };
        /// <summary>
        /// Tạo vùng địa chỉ cho tool
        /// </summary>
        private void RebuildVisionBoxAddress()
        {
            List<int> portIndexes = new List<int>();
            switch (SourceMode.rtcValue)
            {
                case cIOControllerType.VC3000:
                    {

                        break;
                    }
                case cIOControllerType.VC3000X:
                    {
                        if (ActionType == EActionTypes.IOControllerRead)
                        {
                            if (GPI1.rtcValue)
                                portIndexes.Add(0);
                            if (GPI2.rtcValue)
                                portIndexes.Add(1);
                            if (GPI3.rtcValue)
                                portIndexes.Add(2);
                            if (GPI4.rtcValue)
                                portIndexes.Add(3);
                            if (GPI5.rtcValue)
                                portIndexes.Add(4);
                            if (GPI6.rtcValue)
                                portIndexes.Add(5);
                            if (GPI7.rtcValue)
                                portIndexes.Add(6);
                            if (GPI8.rtcValue)
                                portIndexes.Add(7);
                        }
                        else
                        {
                            if (GP01.rtcValue)
                                portIndexes.Add(0);
                            if (GP02.rtcValue)
                                portIndexes.Add(1);
                            if (GP03.rtcValue)
                                portIndexes.Add(2);
                            if (GP04.rtcValue)
                                portIndexes.Add(3);
                            if (GP05.rtcValue)
                                portIndexes.Add(4);
                            if (GP06.rtcValue)
                                portIndexes.Add(5);
                            if (GP07.rtcValue)
                                portIndexes.Add(6);
                            if (GP08.rtcValue)
                                portIndexes.Add(7);
                            if (GP09.rtcValue)
                                portIndexes.Add(8);
                            if (GP10.rtcValue)
                                portIndexes.Add(9);
                            if (GP11.rtcValue)
                                portIndexes.Add(10);
                            if (GP12.rtcValue)
                                portIndexes.Add(11);
                            if (GP13.rtcValue)
                                portIndexes.Add(12);
                            if (GP14.rtcValue)
                                portIndexes.Add(13);
                            if (GP15.rtcValue)
                                portIndexes.Add(14);
                            if (GP16.rtcValue)
                                portIndexes.Add(15);
                        }

                        break;
                    }
            }

            _visionBoxAddress = portIndexes.ToArray();
        }
        internal bool VisionBoxConnect()
        {
            try
            {
                switch (SourceMode.rtcValue)
                {
                    case cIOControllerType.VC3000:
                        {
                            if (!GlobVar.IsVC3000Register)
                            {
                                int nRet = CIOControllerSDK3000.MV_OK;
                                nRet = CIOControllerSDK3000.MV_IO_WinIO_Init_CS();
                                if (nRet != CIOControllerSDK3000.MV_OK)
                                {
                                    ErrMessage.rtcValue = new List<string> { cMessageContent.Err_FailedRegisterVC3000 };
                                    CIOControllerSDK3000.MV_IO_WinIO_DeInit_CS();
                                    return false;
                                }
                                else GlobVar.IsVC3000Register = true;
                            }
                            break;
                        }
                    case cIOControllerType.VC3000X:
                        {
                            if (MyVC3000X != null &&
                                MyVC3000X.ComName == COMName.rtcValue &&
                                MyVC3000X.IsConnected)
                                return true;

                            if (GlobVar.MyListVC3000X != null)
                                MyVC3000X =
                                    GlobVar.MyListVC3000X.FirstOrDefault(x =>
                                        x.ComName == COMName.rtcValue);

                            if (MyVC3000X == null)
                            {
                                MyVC3000X = new CIOControllerSDK3000X(COMName.rtcValue);
                                if (GlobVar.MyListVC3000X == null)
                                    GlobVar.MyListVC3000X = new List<CIOControllerSDK3000X>();
                                GlobVar.MyListVC3000X.Add(MyVC3000X);
                            }

                            if (!MyVC3000X.IsConnected && !MyVC3000X.Connect())
                            {
                                if (MyVC3000X.ErrorMessage != "")
                                    ErrMessage.rtcValue = new List<string> { $"Tool: {Name.rtcValue} error with message:\n{MyVC3000X.ErrorMessage}" };
                                else
                                    ErrMessage.rtcValue = new List<string>{cMessageContent.BuildMessage(cMessageContent.War_COMNameActionCanNotConnect,
                                        new string[] { Name.rtcValue, COMName.rtcValue },
                                        new string[] { Name.rtcValue, COMName.rtcValue })};
                                return false;
                            }

                            break;
                        }
                    case cIOControllerType.VC4000:
                        {
                            //if (!GlobVar.IsVC4000Register)
                            //{
                            //    //int nRet = CIOControllerSDK4000.MV_OK;
                            //    //nRet = CIOControllerSDK4000.();
                            //    //if (nRet != CIOControllerSDK3000.MV_OK)
                            //    //{ 
                            //    //    ErrMessage.rtcValue = cMessageContent.Err_FailedRegisterVC3000;
                            //    //    CIOControllerSDK3000.MV_IO_WinIO_DeInit_CS();
                            //    //    return false;
                            //    //}
                            //    //else GlobVar.IsVC3000Register = true;
                            //}
                            break;
                        }
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrMessage.rtcValue = new List<string> { ex.Message };
                return false;
            }
        }
        internal void VisionBoxDisconnect()
        {
            switch (SourceMode.rtcValue)
            {
                case cIOControllerType.VC3000:
                    {
                        //Kiểm tra lại xem địa chỉ này còn được sử dụng ở đâu nữa không
                        // Do hiện tại có việc vừa setting vừa chạy ở dưới, có thể có trường hợp bên kia vẫn đang chạy, bên này lại close lại.
                        foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                            if (cam.ID != MyGroup.MyCam.ID && cam.GroupActions.IsRun)
                            {
                                var listVisionBox = cam.GroupActions.Actions.Values.Where(x =>
                                    (x.ActionType == EActionTypes.IOControllerRead || x.ActionType == EActionTypes.IOControllerWrite) && x.Enable.rtcValue).ToList();
                                // Kiểm tra xem có tool nào dùng chung thông số đang chạy hay ko
                                if (listVisionBox.Any() && listVisionBox.FirstOrDefault(
                                    x => x.SourceMode.rtcValue == cIOControllerType.VC3000) != null)
                                    return;
                            }

                        try
                        {
                            CIOControllerSDK3000.MV_IO_WinIO_DeInit_CS();
                            GlobVar.IsVC3000Register = false;
                        }
                        catch
                        {
                            // ignored
                        }
                        break;
                    }
                case cIOControllerType.VC3000X:
                    {
                        if (MyVC3000X != null && MyVC3000X.IsConnected)
                        {
                            foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                                if (cam.ID != MyGroup.MyCam.ID && cam.GroupActions.IsRun)
                                {
                                    var listVisionBox = cam.GroupActions.Actions.Values.Where(x =>
                                        (x.ActionType == EActionTypes.IOControllerRead || x.ActionType == EActionTypes.IOControllerWrite) && x.Enable.rtcValue).ToList();
                                    // Kiểm tra xem có tool nào dùng chung thông số đang chạy hay ko
                                    if (listVisionBox.Any() && listVisionBox.FirstOrDefault(
                                        x => x.SourceMode.rtcValue == cIOControllerType.VC3000X && x.COMName.rtcValue == COMName.rtcValue) != null)
                                        return;
                                }

                            MyVC3000X.Disconnect();
                            GlobVar.MyListVC3000X.Remove(MyVC3000X);
                            if (GlobVar.MyListVC3000X.Count <= 0)
                                CIOControllerSDK3000X.DeInitInitVcx3000();
                        }
                        break;
                    }
                case cIOControllerType.VC4000:
                    {
                        break;
                    }
            }
        }
        public void Run_IOControllerRead_Test()
        {
            CTTest(() =>
            {
                if (VisionBoxConnect())
                    Run_IOControllerRead();
            });
            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }

        private bool Run_IOController3000ReadProcess()
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return true;
            }
            if (VisionBoxConnect())
            {
                int iValue = 0;
                List<string> address = new List<string>();
                if (GPI1.rtcValue)
                    address.Add(nameof(GPI1));
                if (GPI2.rtcValue)
                    address.Add(nameof(GPI2));
                if (GPI3.rtcValue)
                    address.Add(nameof(GPI3));

                byte[] byteStatus = new byte[1024];
                int nRet = CIOControllerSDK3000.MV_IO_GetMainInputLevel_CS(ref byteStatus[0]);
                // int nRet = CIOControllerSDK3000.MV_IO_GetMainInputLevel_CS(ref byteStatus[0]);

                int nGPIStatus = BitConverter.ToInt32(byteStatus, 0);
                if (CIOControllerSDK3000.MV_OK != nRet)
                {
                    Log.cLog log = new Log.cLog();
                    log.WriteLog(GlobFuncs.Hik_GetErrorMessage(nRet));

                    return false;
                }
                if (address.Contains(nameof(GPI1)))
                    if ((nGPIStatus & 0x01) == 0x01)
                        Value.rtcValue.Add("1");
                    else
                        Value.rtcValue.Add("0");
                if (address.Contains(nameof(GPI2)))
                    if ((nGPIStatus & 0x02) == 0x02)
                        Value.rtcValue.Add("1");
                    else
                        Value.rtcValue.Add("0");
                if (address.Contains(nameof(GPI3)))
                    if ((nGPIStatus & 0x04) == 0x04)
                        Value.rtcValue.Add("1");
                    else
                        Value.rtcValue.Add("0");
                Thread.Sleep(15);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Chạy tool
        /// </summary>
        public void Run_IOControllerRead()
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
                    //    HTuple equalHTuple = new HTuple(0);
                    //string equalHTuple = "0";
                    //equalHTuple = Value.rtcValue.TupleEqual(CompareValue.rtcValue);
                    //Passed.rtcValue = (equalHTuple.TupleInt().TupleSelect(0) == 1);
                    //string equalHTuple = "0";
                    //equalHTuple = Value.rtcValue.TupleEqual(CompareValue.rtcValue);
                    Passed.rtcValue = Value.rtc.Equals(CompareValue.rtcValue);
                }

                return;
            }

            switch (SourceMode.rtcValue)
            {
                case cIOControllerType.VC3000:
                    {
                        if (Run_IOController3000ReadProcess())
                        {
                            Passed.rtcValue = true;

                            if (IsCompareValue.rtcValue)
                            {
                                Passed.rtcValue = Value.rtc.Equals(CompareValue.rtcValue);
                            }
                        }
                        break;
                    }
                case cIOControllerType.VC3000X:
                    {
                        RebuildVisionBoxAddress();
                        int[] readValues = MyVC3000X.Read(_visionBoxAddress, out bool success);
                        if (success)
                            foreach (int item in readValues)
                            {
                                Value.rtcValue.Add(item.ToString());
                            }

                        ErrMessage.rtcValue = new List<string> { MyVC3000X.ErrorMessage };
                        Passed.rtcValue = success;

                        break;
                    }
                case cIOControllerType.VC4000:
                    {
                        Passed.rtcValue = true;
                        break;
                    }
            }
        }

        public void Run_IOControllerWrite_Test()
        {
            CTTest(() =>
            {
                if (VisionBoxConnect())
                    Run_IOControllerWrite(true);
            });
        }

        private bool Run_IOController3000WriteProcess(List<string> value)
        {
            if (GlobVar.IsSimulatorMode || value == null || value.Count <= 0)
            {
                Passed.rtcValue = true;
                return true;
            }

            if (VisionBoxConnect())
            {
                //Đăng kí polarity
                int nType = (int)PNP_ENABLE_STATE.NPN;
                if (OutputPolarity.rtcValue == cOutputPolarityType.PNP)
                    nType = (int)PNP_ENABLE_STATE.PNP;
                int nRet = CIOControllerSDK3000.MV_IO_SetMainGPO_NPN_CS(nType);
                if (CIOControllerSDK3000.MV_OK != nRet)
                {
                    ErrMessage.rtcValue = new List<string> { cMessageContent.Err_UnableToSetOutputPolarity };
                    return false;
                }
                int iValue = 0;
                List<string> address = new List<string>();
                if (GP01.rtcValue)
                    address.Add(nameof(GP01));
                if (GP02.rtcValue)
                    address.Add(nameof(GP02));
                if (GP03.rtcValue)
                    address.Add(nameof(GP03));
                if (GP04.rtcValue)
                    address.Add(nameof(GP04));
                if (GP05.rtcValue)
                    address.Add(nameof(GP05));
                if (GP06.rtcValue)
                    address.Add(nameof(GP06));
                if (GP07.rtcValue)
                    address.Add(nameof(GP07));
                if (GP08.rtcValue)
                    address.Add(nameof(GP08));
                for (int i = 0; i < value.Count; i++)
                {
                    iValue = GlobFuncs.Ve2Interger(value[i]);
                    CIOControllerSDK3000.MV_GIO_LEVEL gioLevel = iValue == 0
                        ? CIOControllerSDK3000.MV_GIO_LEVEL.MV_GIO_LEVEL_LOW
                        : CIOControllerSDK3000.MV_GIO_LEVEL.MV_GIO_LEVEL_HIGH;
                    bool result = true;
                    if (address.Count > i)
                    {
                        switch (address[i])
                        {
                            case nameof(GP01):
                                {
                                    result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_1, gioLevel);
                                    break;
                                }
                            case nameof(GP02):
                                {
                                    result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_2, gioLevel);
                                    break;
                                }
                            case nameof(GP03):
                                {
                                    result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_3, gioLevel);
                                    break;
                                }
                            case nameof(GP04):
                                {
                                    result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_4, gioLevel);
                                    break;
                                }
                            case nameof(GP05):
                                {
                                    result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_5, gioLevel);
                                    break;
                                }
                            case nameof(GP06):
                                {
                                    result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_6, gioLevel);
                                    break;
                                }
                            case nameof(GP07):
                                {
                                    result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_7, gioLevel);
                                    break;
                                }
                            case nameof(GP08):
                                {
                                    result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_8, gioLevel);
                                    break;
                                }
                        }
                        Thread.Sleep(15);
                        if (!result)
                        {
                            ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.Err_WriteIO_IsFail,
                                new string[] { address[i] }, new string[] { address[i] }) };
                            return false;
                        }
                    }
                    else
                        break;
                }

                return true;
            }
            return false;
        }

        public void Run_IOControllerWrite(bool isTest = false)
        {
            if (GlobVar.IsSimulatorMode)
            {
                Passed.rtcValue = true;
                return;
            }

            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>();

            switch (SourceMode.rtcValue)
            {
                case cIOControllerType.VC3000:
                    {
                        if (Run_IOController3000WriteProcess(Value.rtcValue))
                        {
                            Passed.rtcValue = true;
                            if (IsRunOneTime.rtcValue && !isTest)
                                IsFinishRunOneTime.rtcValue = Passed.rtcValue;

                            if (Passed.rtcValue && TimeDelay.rtcValue > 0)
                            {
                                if (WaitMode.rtcValue == cStrings.ASync || isTest)
                                    Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_IOControllerWrite_AfterDelay());
                                else
                                {
                                    Thread.Sleep(TimeDelay.rtcValue);
                                    Run_IOControllerWrite_AfterDelay();
                                }
                            }
                        }
                        break;
                    }
                case cIOControllerType.VC3000X:
                    {
                        RebuildVisionBoxAddress();
                        int[] values = GlobFuncs.Ve2ArrayInt(Value.rtcValue);
                        Passed.rtcValue = MyVC3000X.Write(_visionBoxAddress, values, OutputPolarity.rtcValue);
                        ErrMessage.rtcValue = new List<string> { MyVC3000X.ErrorMessage };
                        if (Passed.rtcValue)
                        {
                            if (IsRunOneTime.rtcValue && !isTest)
                                IsFinishRunOneTime.rtcValue = Passed.rtcValue;

                            if (Passed.rtcValue && TimeDelay.rtcValue > 0)
                            {
                                if (WaitMode.rtcValue == cStrings.ASync || isTest)
                                    Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_IOControllerWrite_AfterDelay());
                                else
                                {
                                    Thread.Sleep(TimeDelay.rtcValue);
                                    Run_IOControllerWrite_AfterDelay();
                                }
                            }
                        }
                        break;
                    }
                case cIOControllerType.VC4000:
                    {
                        Passed.rtcValue = true;
                        break;
                    }
            }
        }

        /// <summary>
        /// Chạy truyền thông IO gửi 1 giá trị sau giá trị chính sau 1 khoảng thời gian thiết lập
        /// </summary>
        public void Run_IOControllerWrite_AfterDelay()
        {
            switch (SourceMode.rtcValue)
            {
                case cIOControllerType.VC3000:
                    {
                        Run_IOController3000WriteProcess(ValueAfterDelay.rtcValue);
                        break;
                    }
                case cIOControllerType.VC3000X:
                    {
                        RebuildVisionBoxAddress();
                        int[] values = GlobFuncs.Ve2ArrayInt(ValueAfterDelay.rtcValue);
                        Passed.rtcValue = MyVC3000X.Write(_visionBoxAddress, values, OutputPolarity.rtcValue);
                        ErrMessage.rtcValue = new List<string> { MyVC3000X.ErrorMessage };
                        break;
                    }
                case cIOControllerType.VC4000:
                    {
                        break;
                    }
            }
        }
        /// <summary>
        /// Chạy truyền thông IO khi stop chu trình chạy
        /// </summary>
        public void Run_IOControllerWrite_AfterStop()
        {
            switch (SourceMode.rtcValue)
            {
                case cIOControllerType.VC3000:
                    {
                        Run_IOController3000WriteProcess(ValueAfterStop.rtcValue);
                        break;
                    }
                case cIOControllerType.VC3000X:
                    {
                        if (MyVC3000X == null)
                            return;
                        RebuildVisionBoxAddress();
                        int[] values = GlobFuncs.Ve2ArrayInt(ValueAfterStop.rtcValue);
                        Passed.rtcValue = MyVC3000X.Write(_visionBoxAddress, values, OutputPolarity.rtcValue);
                        ErrMessage.rtcValue = new List<string> { MyVC3000X.ErrorMessage };
                        break;
                    }
                case cIOControllerType.VC4000:
                    {
                        break;
                    }
            }
        }
        /// <summary>
        /// Chạy truyền thông IO gửi dạng tín hiệu alive
        /// </summary>
        /// <param name="isUseDelay"></param>
        public void Run_IOController3000Write_Alive(bool isUseDelay = true)
        {
            if (GlobVar.IsSimulatorMode || !MyGroup.IsRun)
            {
                Passed.rtcValue = true;
                return;
            }

            switch (SourceMode.rtcValue)
            {
                case cIOControllerType.VC3000:
                    {
                        //Đăng kí polarity
                        int nType = (int)PNP_ENABLE_STATE.NPN;
                        if (Polarity.rtcValue == cOutputPolarityType.PNP)
                            nType = (int)PNP_ENABLE_STATE.PNP;
                        int nRet = CIOControllerSDK3000.MV_IO_SetMainGPO_NPN_CS(nType);
                        if (CIOControllerSDK3000.MV_OK != nRet)
                        {
                            ErrMessage.rtcValue = new List<string> { cMessageContent.Err_UnableToSetOutputPolarity };
                            return;
                        }

                        List<string> address = new List<string>();
                        if (GP01.rtcValue)
                            address.Add(nameof(GP01));
                        if (GP02.rtcValue)
                            address.Add(nameof(GP02));
                        if (GP03.rtcValue)
                            address.Add(nameof(GP03));
                        if (GP04.rtcValue)
                            address.Add(nameof(GP04));
                        if (GP05.rtcValue)
                            address.Add(nameof(GP05));
                        if (GP06.rtcValue)
                            address.Add(nameof(GP06));
                        if (GP07.rtcValue)
                            address.Add(nameof(GP07));
                        if (GP08.rtcValue)
                            address.Add(nameof(GP08));
                        AliveValue = AliveValue == 0 ? 1 : 0;
                        for (int i = 0; i < address.Count; i++)
                        {
                            CIOControllerSDK3000.MV_GIO_LEVEL gioLevel = AliveValue == 0
                                ? CIOControllerSDK3000.MV_GIO_LEVEL.MV_GIO_LEVEL_LOW
                                : CIOControllerSDK3000.MV_GIO_LEVEL.MV_GIO_LEVEL_HIGH;
                            bool result = true;
                            switch (address[i])
                            {
                                case nameof(GP01):
                                    {
                                        result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_1,
                                            gioLevel);
                                        break;
                                    }
                                case nameof(GP02):
                                    {
                                        result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_2,
                                            gioLevel);
                                        break;
                                    }
                                case nameof(GP03):
                                    {
                                        result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_3,
                                            gioLevel);
                                        break;
                                    }
                                case nameof(GP04):
                                    {
                                        result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_4,
                                            gioLevel);
                                        break;
                                    }
                                case nameof(GP05):
                                    {
                                        result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_5,
                                            gioLevel);
                                        break;
                                    }
                                case nameof(GP06):
                                    {
                                        result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_6,
                                            gioLevel);
                                        break;
                                    }
                                case nameof(GP07):
                                    {
                                        result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_7,
                                            gioLevel);
                                        break;
                                    }
                                case nameof(GP08):
                                    {
                                        result = WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER.MV_MAINIO_PORT_8,
                                            gioLevel);
                                        break;
                                    }
                            }
                            if (!result)
                            {
                                ErrMessage.rtcValue = new List<string> { cMessageContent.BuildMessage(cMessageContent.Err_WriteIO_IsFail,
                                    new string[] { address[i] }, new string[] { address[i] }) };
                                return;
                            }
                        }
                        break;
                    }
                case cIOControllerType.VC3000X:
                    {
                        RebuildVisionBoxAddress();
                        AliveValue = AliveValue == 0 ? 1 : 0;
                        int[] values = { Lib.ToInt(AliveValue) };

                        Passed.rtcValue = MyVC3000X.Write(_visionBoxAddress, values, OutputPolarity.rtcValue);
                        ErrMessage.rtcValue = new List<string> { MyVC3000X.ErrorMessage };
                        break;
                    }
                case cIOControllerType.VC4000:
                    {
                        break;
                    }
            }

            if (isUseDelay)
                Task.Delay(TimeDelay.rtcValue).ContinueWith(t => Run_IOController3000Write_Alive(true));
        }

        private bool WriteIO3000(CIOControllerSDK3000.MV_IO_MAINPORT_NUMBER mainportNumber,
            CIOControllerSDK3000.MV_GIO_LEVEL gioLevel)
        {
            var nRet = CIOControllerSDK3000.MV_IO_SetMainOutputLevel_CS(mainportNumber, gioLevel);
            return CIOControllerSDK3000.MV_OK == nRet;
        }

        #endregion
    }
}
