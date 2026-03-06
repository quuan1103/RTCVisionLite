using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using RTC_Vision_Lite.PublicFunctions;
using System.Collections.Generic;
using System.IO.Ports;
using InControls.Common;
using InControls.PLC.FX;
using RTC_Vision_Lite.Classes;
using InControls.PLC;

namespace RTC_Vision_Lite.Classes
{
    /// <summary>
    /// Đối tượng đảm nhiệm vai trò khởi tạo một máy khách
    /// </summary>
    public class cCOMPLCMitsu
    {
        /// <summary>
        /// Cổng COM cần kết nối
        /// </summary>
        public string COMName { get; set; }
        public int COMNum { get; set; }
        /// <summary>
        /// Tốc độ truyền
        /// </summary>
        public int BaudRate { get; set; }
        /// <summary>
        /// Số bit dữ liệu
        /// </summary>
        public int DataBits { get; set; }
        /// <summary>
        /// Kiểm tra bit chẵn, lẻ
        /// </summary>
        public Parity Parity { get; set; }
        /// <summary>
        /// Bit dừng
        /// </summary>
        public StopBits StopBits { get; set; }
        /// <summary>
        /// Số byte muốn đọc về
        /// </summary>
        public string PLCAddress { get; set; }
        public int ByteLength { get; set; }
        public ControllerTypeConst ControllerTypeConst { get; set; }
        /// <summary>
        /// Dữ liệu tiếp nhận có phải dạng Hexa hay không
        /// </summary>
        public bool IsHex { get; set; }
        /// <summary>
        /// Thời gian đọc tối đa
        /// </summary>
        public int ReadTimeout { get; set; }
        /// <summary>
        /// Cờ báo đang connect đến PLC
        /// </summary>
        public bool Connected { get; set; }
        /// <summary>
        /// Đối tượng kết nối cổng COM
        /// </summary>
        private FxSerialDeamon FxSerial;
        private string _Value = string.Empty;
        private byte[] buffer;
        private Thread ThreadGetValue;
        private bool IsRun;
        public ReceiveDataEvents OnReceiveDataEvents;
        public cCOMPLCMitsu()
        {
            IsRun = false;
        }
        public cCOMPLCMitsu(string _COMName,
            int _BaudRate, int _DataBits, Parity _Parity, StopBits _StopBits, bool _IsHex,
            string _PLCAddress, int _ByteLength, ControllerTypeConst _ControllerTypeConst,
            int _ReadTimeout = 1000, bool _IsWithStart = true)
        {
            IsRun = false;
            COMName = _COMName;
            try
            {
                COMNum = int.Parse(Regex.Match(_COMName, @"\d+").Value);
            }
            catch
            {
                COMNum = -1;
            }
            BaudRate = _BaudRate;
            DataBits = _DataBits;
            Parity = _Parity;
            StopBits = _StopBits;
            IsHex = _IsHex;
            ReadTimeout = _ReadTimeout;
            ByteLength = _ByteLength;
            PLCAddress = _PLCAddress;
            ControllerTypeConst = _ControllerTypeConst;
            if (_IsWithStart)
                Start();
        }
        /// <summary>
        /// Khởi chạy kết nối cổng COM
        /// </summary>
        /// <returns></returns>
        public bool StartWithEvent()
        {
            try
            {
                if (COMNum == -1)
                    return false;
                string param = string.Empty;
                param = string.Format("{0},{1},{2},{3}", BaudRate.ToString(), Enum.GetName(typeof(Parity), Parity), DataBits.ToString(), ((int)StopBits).ToString());
                FxSerial = new FxSerialDeamon();
                Connected = FxSerial.Start(COMNum, param);

                IsRun = true;

                ThreadGetValue = new Thread(() => ProcessGetValue());
                ThreadGetValue.IsBackground = true;
                ThreadGetValue.Start();

                return Connected;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        public bool Start()
        {
            try
            {
                if (COMNum == -1)
                    return false;
                string param = string.Empty;
                param = string.Format("{0},{1},{2},{3}", BaudRate.ToString(), Enum.GetName(typeof(Parity), Parity), DataBits.ToString(), ((int)StopBits).ToString());
                FxSerial = new FxSerialDeamon();
                Connected = FxSerial.Start(COMNum, param);
                return Connected;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        /// <summary>
        /// Đóng kết nối COM
        /// </summary>
        public void Stop()
        {
            IsRun = false;
            ThreadGetValue.Abort();
            if (FxSerial != null)
            {
                FxSerial.Stop();
            }
            FxSerial = null;
            Connected = false;
        }
        /// <summary>
        /// Hàm đọc dữ liệu
        /// </summary>
        private void ProcessGetValue()
        {
            while (IsRun)
            {
                if (!IsRun) return;

                _Value = string.Empty;
                try
                {
                    if (FxSerial != null && Connected)
                    {
                        string cmd = string.Empty;
                        FxCommandResponse res = null;
                        //Tiến hành đọc giá trị thanh ghi
                        cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress(PLCAddress, ControllerTypeConst), ByteLength);
                        res = FxSerial.Send(0, cmd);
                        buffer = new byte[ByteLength];

                        //if (res.ResponseValue!=null && res.ResponseValue.Count == ByteLength)
                        //{
                        //    for (int i = 0; i < ByteLength; i++)
                        //        buffer.SetValue(res.ResponseValue[i], i);
                        //}
                        if (res.ResponseValue != null && res.ResponseValue.Count == ByteLength)
                        {
                            //Chuyển dữ liệu thanh ghi về dạng chuỗi
                            Array.Copy(res.ResponseValue.ToArray(), buffer, ByteLength);
                            if (IsHex)
                                _Value = BitConverter.ToString(buffer).Replace("-", "");
                            else
                                _Value = Encoding.ASCII.GetString(buffer);

                            //Reset giá trị sau khi đọc xong
                            List<uint> lst = new List<uint>();
                            for (int i = 0; i < ByteLength; i++)
                                lst.Add(0);
                            cmd = FxCommandHelper.Make<UInt32DataType>(FxCommandConst.FxCmdWrite, new FxAddress(PLCAddress, ControllerTypeConst), lst);
                            res = FxSerial.Send(0, cmd);
                        }
                    }
                }
                catch
                {
                    _Value = string.Empty;
                }
                if (_Value != string.Empty)
                {
                    if (OnReceiveDataEvents != null)
                    {
                        OnReceiveDataEvents(_Value);
                    }
                }
            }
        }

        public string GetValue()
        {
            _Value = string.Empty;
            try
            {
                if (FxSerial != null && Connected)
                {
                    string cmd = string.Empty;
                    FxCommandResponse res = null;
                    //Tiến hành đọc giá trị thanh ghi
                    cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress(PLCAddress, ControllerTypeConst), ByteLength);
                    res = FxSerial.Send(0, cmd);
                    buffer = new byte[ByteLength];

                    //if (res.ResponseValue!=null && res.ResponseValue.Count == ByteLength)
                    //{
                    //    for (int i = 0; i < ByteLength; i++)
                    //        buffer.SetValue(res.ResponseValue[i], i);
                    //}
                    if (res.ResponseValue != null && res.ResponseValue.Count == ByteLength)
                    {
                        //Chuyển dữ liệu thanh ghi về dạng chuỗi
                        Array.Copy(res.ResponseValue.ToArray(), buffer, ByteLength);
                        if (IsHex)
                            _Value = BitConverter.ToString(buffer).Replace("-", "");
                        else
                            _Value = Encoding.ASCII.GetString(buffer);

                        //Reset giá trị sau khi đọc xong
                        List<uint> lst = new List<uint>();
                        for (int i = 0; i < ByteLength; i++)
                            lst.Add(0);
                        cmd = FxCommandHelper.Make<UInt32DataType>(FxCommandConst.FxCmdWrite, new FxAddress(PLCAddress, ControllerTypeConst), lst);
                        res = FxSerial.Send(0, cmd);
                    }
                }
            }
            catch
            {
                _Value = string.Empty;
            }

            return _Value;
        }
    }
}
