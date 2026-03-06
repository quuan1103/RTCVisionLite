using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmpCustom
{
    public class cSlmpCustom
    {
        #region PROPERTIES
        public string IPAddress { get; set; }
        public int Port { get; set; }
        #endregion

        #region VARIABLE
        private bool _connected = false;

        public bool Connected
        {
            get
            {
                if (PLC != null && PLC.CheckSocketConnect())
                    return true;
                return false; 
            }
            set => _connected = value;
        }
        public PLC3eClient PLC;
        #endregion

        public cSlmpCustom(string ipAddress, int port)
        {
            IPAddress = ipAddress;
            Port = port;
        }

        #region FUNCIONS
        public bool ConnectSocket()
        {
            if (PLC != null && PLC.CheckSocketConnect())
                return true;

            if (PLC!=null)
            {
                PLC.PLCClientInit(IPAddress, Port);
                return PLC.Connected;
            }
            else
            {
                PLC = new PLC3eClient(IPAddress, Port);
                return PLC.Connected;
            }
        }
        public bool CloseSocket()
        {
            try
            {
                bool value = false;
                if (PLC.CloseSecket()) value = true; else value = false;
                return value;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool SendBit(byte data, string Device)
        {
            try
            {
                if (!Device.Contains(".") || !Device.Contains("D")) return false;
                string[] DeviceAndBit = Device.Split('.');
                string strDeviceNum = DeviceAndBit[0].Replace("D", string.Empty);
                string strBitNum = DeviceAndBit[1];
                if (!Int32.TryParse(strDeviceNum, out int DeviceNum) ||
                    !Int32.TryParse(strBitNum, out int BitNum)) return false;
                byte[] ValueBit = PLC.GetBitData(DeviceNum, 1);
                byte[] ValueBitSend = new byte[ValueBit.Length];
                for (int i = 0; i < ValueBit.Length; i++)
                {
                    if (i == BitNum)
                        ValueBitSend[i] = data;
                    else
                        ValueBitSend[i] = ValueBit[i];
                }

                int[] vs = new int[1];
                for (int i = 0; i < ValueBitSend.Length; i++)
                {
                    if (ValueBitSend[i] == 1)
                    {
                        vs[0] = vs[0] + (int)Math.Pow(2, i);
                    }
                }
                PLC.SendDataToPLC(vs, DeviceNum);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SendWord(int[] data, string Device)
        {
            try
            {
                if (!Device.Contains("D")) return false;
                string strDeviceNum = Device.Replace("D", string.Empty);
                if (!Int32.TryParse(strDeviceNum, out int DeviceNum)) return false;
                PLC.SendDataToPLC(data, DeviceNum);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SendDWord(int[] data, string Device)
        {
            try
            {
                byte[] BufferDwordByte;
                int[] intputPLC = new int[2];
                BufferDwordByte = BitConverter.GetBytes(System.Convert.ToInt32(data[0]));
                intputPLC[0] = BitConverter.ToInt16(BufferDwordByte, 0);
                intputPLC[1] = BitConverter.ToInt16(BufferDwordByte, 2);
                // BitConverter.ToInt32


                if (!Device.Contains("D")) return false;
                string strDeviceNum = Device.Replace("D", string.Empty);
                if (!Int32.TryParse(strDeviceNum, out int DeviceNum)) return false;
                PLC.SendDataToPLC(intputPLC, DeviceNum);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SendArrayDWord(int[] data, string Device)
        {
            try
            {
                byte[] BufferDwordByte;
                int[] intputPLC = new int[data.Length * 2];
                for (int i = 0; i < data.Length; i++)
                {
                    BufferDwordByte = BitConverter.GetBytes(System.Convert.ToInt32(data[i]));
                    intputPLC[i * 2] = BitConverter.ToInt16(BufferDwordByte, 0);
                    intputPLC[i * 2 + 1] = BitConverter.ToInt16(BufferDwordByte, 2);
                }
                // BitConverter.ToInt32

                if (!Device.Contains("D")) return false;
                string strDeviceNum = Device.Replace("D", string.Empty);
                if (!Int32.TryParse(strDeviceNum, out int DeviceNum)) return false;
                PLC.SendDataToPLC(intputPLC, DeviceNum);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Bit(string Device, out bool bitReuslt)
        {
            try
            {
                bitReuslt = false;
                if (!Device.Contains(".") || !Device.Contains("D")) return false;
                string[] DeviceAndBit = Device.Split('.');
                string strDeviceNum = DeviceAndBit[0].Replace("D", string.Empty);
                string strBitNum = DeviceAndBit[1];
                if (!Int32.TryParse(strDeviceNum, out int DeviceNum) ||
                    !Int32.TryParse(strBitNum, out int BitNum)) return false;
                byte[] ValueBit = PLC.GetBitData(DeviceNum, 1);
                if (ValueBit[BitNum] == 0)
                    bitReuslt = false;
                else
                    bitReuslt = true;
                return true;
            }
            catch (Exception ex)
            {
                bitReuslt = false;
                return false;
            }
        }
        public bool ReceiveBitArr(string Device, out byte[] bitReuslt)
        {
            try
            {
                bitReuslt = new byte[16];
                if (!Device.Contains("D")) return false;
                string strDeviceNum = Device.Replace("D", string.Empty);
                if (!Int32.TryParse(strDeviceNum, out int DeviceNum)) return false;
                bitReuslt = PLC.GetBitData(DeviceNum, 1);
                return true;
            }
            catch (Exception ex)
            {
                bitReuslt = new byte[16];
                return false;
            }
        }
        public int ArrayIntToDword(int[] dataIN)
        {
            byte[] byarrBufferByte = new byte[4];
            byte[] byarrTemp;
            int iNumber;
            for (iNumber = 0; iNumber <= 2 - 1; iNumber++)
            {
                byarrTemp = BitConverter.GetBytes(dataIN[iNumber]);
                byarrBufferByte[iNumber * 2] = byarrTemp[0];
                byarrBufferByte[iNumber * 2 + 1] = byarrTemp[1];
            }
            int outputPLC = System.Convert.ToInt32(BitConverter.ToInt32(byarrBufferByte, 0));
            return outputPLC;
        }
        public bool ReceiveDWord(string Device, out int result)
        {
            try
            {
                result = 0;
                int iAddress1 = ExtractNumberOfString(Device);
                int iAddress2 = iAddress1 + 1;

                if (iAddress1 != -1)
                {
                    int[] result1 = PLC.ReceiveDataFromPLC(iAddress1, 1);
                    int[] result2 = PLC.ReceiveDataFromPLC(iAddress2, 1);
                    result = ArrayIntToDword(new int[] {result1[0], result2[0]});
                }
                else
                    return false;

                return true;
            }
            catch(Exception ex)
            {
                result = 0;
                return false;
            }
        }
        public bool ReceiveWord(string Device, out int[] result)
        {
            try
            {
                result = new int[16];
                int iAddress = ExtractNumberOfString(Device);
                if (iAddress != -1)
                    result = PLC.ReceiveDataFromPLC(iAddress, 1);
                else
                    return false;

                return true;
            }
            catch
            {
                result = new int[16];
                return false;
            }
        }
        private int ExtractNumberOfString(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                return -1;
            int ivalue = 0;
            StringBuilder sbValue = new StringBuilder();
            foreach (char item in str)
            {
                if (int.TryParse(item.ToString(), out ivalue))
                    sbValue.Append(ivalue);
            }

            if (sbValue.Length > 0)
                if (int.TryParse(sbValue.ToString(), out ivalue))
                    return ivalue;
            return -1;
        }
        #endregion
    }
}
