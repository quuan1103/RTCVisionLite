using System;
using RTCConst;
using RTC_Vision_Lite.PublicFunctions;

namespace RTC_Vision_Lite.Classes.Robot
{
    public delegate void ReceiveDataEvents();
    public class cModbusClient
    {
        #region Variables
        object LockCommunication = new object();
        public event ReceiveDataEvents OnReceiveDataEvents;
        private ModbusClient modbusClient;
        private bool _isConnected;

        public bool IsConnected
        {
            get
            {
                //if (modbusClient != null && modbusClient.Connected)
                //    return true;
                return _isConnected;
            }
            set => _isConnected = value;
        }

        //public bool IsConnected { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string ErrMessage { get; set; }
        #endregion Variables

        #region FUNCTIONS

        public cModbusClient()
        {
            modbusClient = new ModbusClient();
        }
        public cModbusClient(string ip, int port)
        {
            IP = ip; Port = port;
            modbusClient = new ModbusClient();
            modbusClient.IPAddress = ip;
            modbusClient.Port = port;
        }

        public void Connect()
        {
            try
            {
                ErrMessage = string.Empty;
                if (modbusClient.Connected)
                    modbusClient.Disconnect();
                modbusClient.SerialPort = null;
                modbusClient.Connect();
                IsConnected = modbusClient.Connected;
                ErrMessage = IsConnected ? string.Empty : cStrings.Disconnect;
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
            }
        }

        public void Connect(string ip, int port)
        {
            try
            {
                IP = ip; Port = port;
                if (modbusClient.Connected) modbusClient.Disconnect();
                modbusClient.IPAddress = ip;
                modbusClient.Port = port;
                modbusClient.SerialPort = null;
                modbusClient.Connect();
                IsConnected = true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        public void Disconnect()
        {
            modbusClient.Disconnect();
            IsConnected = false;
        }

        public float[] ReadFloats(int startAddress, int length, string functionMode, out bool success)
        {
            success = false;
            int lengthFloat = 0;
            if (length % 2 == 0) lengthFloat = length / 2; else lengthFloat = length / 2 + 1;
            float[] serverResponse = new float[lengthFloat];
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    for (int i = 0; i < lengthFloat; i++)
                    {
                        int startAdd = startAddress + i * 2;
                        if (functionMode == cModbusFunctionMode.InputRegisters)
                            serverResponse[i] = ModbusClient.ConvertRegistersToFloat(
                                modbusClient.ReadInputRegisters((startAdd), 2), ModbusClient.RegisterOrder.HighLow);
                        else
                            serverResponse[i] = ModbusClient.ConvertRegistersToFloat(
                                modbusClient.ReadHoldingRegisters((startAdd), 2), ModbusClient.RegisterOrder.HighLow);


                    }
                    success = true;
                    return serverResponse;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return serverResponse;
            }
        }

        public float ReadFloat(int startAddress, string functionMode, out bool success)
        {
            success = false;
            int lengthFloat = 2;
            float[] serverResponse = new float[lengthFloat];
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    for (int i = 0; i < lengthFloat; i++)
                    {
                        int startAdd = startAddress + i * 2;

                        if (functionMode == cModbusFunctionMode.InputRegisters)
                            serverResponse[i] = ModbusClient.ConvertRegistersToFloat(
                                modbusClient.ReadInputRegisters((startAdd), 2), ModbusClient.RegisterOrder.HighLow);
                        else
                            serverResponse[i] = ModbusClient.ConvertRegistersToFloat(
                                modbusClient.ReadHoldingRegisters((startAdd), 2), ModbusClient.RegisterOrder.HighLow);
                    }

                    if (serverResponse.Length <= 0)
                        return -1;
                    else
                    {
                        success = true;
                        return serverResponse[0];
                    }
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return -1;
            }
        }
        public double ReadDouble(int startAddress, string functionMode, out bool success)
        {
            success = false;
            int lengthDouble = 4;
            double[] serverResponse = new double[lengthDouble];
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);

                lock (LockCommunication)
                {
                    for (int i = 0; i < lengthDouble; i++)
                    {
                        int startAdd = startAddress + i * 4;
                        if (functionMode == cModbusFunctionMode.InputRegisters)
                            serverResponse[i] = ModbusClient.ConvertRegistersToDouble(
                                modbusClient.ReadInputRegisters((startAdd), 4), ModbusClient.RegisterOrder.HighLow);
                        else
                            serverResponse[i] = ModbusClient.ConvertRegistersToDouble(
                                modbusClient.ReadHoldingRegisters((startAdd), 4), ModbusClient.RegisterOrder.HighLow);

                    }

                    if (serverResponse.Length <= 0)
                        return -1;
                    else
                    {
                        success = true;
                        return serverResponse[0];
                    }
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return -1;
            }
        }
        public double[] ReadDoubles(int startAddress, int length, string functionMode, out bool success)
        {
            success = false;
            int lengthDouble = 0;
            if (length % 4 == 0) lengthDouble = length / 4; else lengthDouble = length / 4 + 1;
            double[] serverResponse = new double[lengthDouble];
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);

                lock (LockCommunication)
                {
                    for (int i = 0; i < lengthDouble; i++)
                    {
                        int startAdd = startAddress + i * 4;
                        if (functionMode == cModbusFunctionMode.InputRegisters)
                            serverResponse[i] = ModbusClient.ConvertRegistersToDouble(
                                modbusClient.ReadInputRegisters((startAdd), 4), ModbusClient.RegisterOrder.HighLow);
                        else
                            serverResponse[i] = ModbusClient.ConvertRegistersToDouble(
                                modbusClient.ReadHoldingRegisters((startAdd), 4), ModbusClient.RegisterOrder.HighLow);
                    }
                    success = true;
                    return serverResponse;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return serverResponse;
            }
        }
        public bool[] ReadCoilA(int startAddress, int length, out bool success)
        {
            success = false;
            if (!IsConnected) return null;
            try
            {
                bool[] serverResponse = new bool[length];
                if (!modbusClient.Connected && !IsConnected)
                {
                    Connect(IP, Port);
                }
                lock (LockCommunication)
                {
                    serverResponse = modbusClient.ReadCoils(startAddress, length);
                    success = true;
                    return serverResponse;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                return null;
            }
        }
        public bool ReadCoil(int startAddress, out bool success)
        {
            success = false;
            if (!IsConnected)
                return false;
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && !IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    var serverResponse = modbusClient.ReadCoils(startAddress, 1);
                    if (serverResponse == null || serverResponse.Length <= 0)
                        return false;
                    else
                    {
                        success = true;
                        return serverResponse[0];
                    }
                }
            }
            catch (Exception exc)
            {   
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return false;
            }
        }
        public bool[] ReadCoils(int startAddress, int length, out bool success)
        {
            success = false;
            if (!IsConnected)
                return null;
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && !IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    var serverResponse = modbusClient.ReadCoils(startAddress, length);
                    success = true;
                    return serverResponse;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return null;
            }
        }
        public bool ReadDiscreteInput(int startAddress, out bool success)
        {
            success = false;
            if (!IsConnected)
                return false;
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    var serverResponse = modbusClient.ReadDiscreteInputs((startAddress - 1), 1);
                    if (serverResponse == null || serverResponse.Length <= 0)
                        return false;
                    else
                    {
                        success = true;
                        return serverResponse[0];
                    }
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return false;
            }
        }
        public bool[] ReadDiscreteInputs(int startAddress, int length, out bool success)
        {
            success = false;
            if (!IsConnected)
                return null;
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    var serverResponse = modbusClient.ReadDiscreteInputs((startAddress - 1), length);
                    success = true;
                    return serverResponse;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return null;
            }
        }

        public int[] ReadHoldingRegisters(int startAddress, int length, out bool success)
        {
            success = false;
            if (!IsConnected)
                return null;
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    int[] serverResponse = modbusClient.ReadHoldingRegisters(startAddress, length);
                    success = true;
                    return serverResponse;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return null;
            }
        }
        public int ReadHoldingRegister(int startAddress, out bool success)
        {
            success = false;
            if (!IsConnected)
                return -1;
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {

                    int[] serverResponse = modbusClient.ReadHoldingRegisters(startAddress, 1);
                    if (serverResponse == null || serverResponse.Length <= 0)
                        return -1;
                    else
                    {
                        success = true;
                        return serverResponse[0];
                    }
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return -1;
            }
        }
        public int ReadInputRegister(int startAddress, out bool success)
        {
            success = false;
            if (!IsConnected)
                return -1;
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    int[] serverResponse = modbusClient.ReadInputRegisters(startAddress, 1);
                    if (serverResponse == null || serverResponse.Length <= 0)
                        return -1;
                    else
                    {
                        success = true;
                        return serverResponse[0];
                    }
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return -1;
            }
        }
        public int[] ReadInputRegisters(int startAddress, int length, out bool success)
        {
            success = false;
            if (!IsConnected)
                return null;
            try
            {
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                lock (LockCommunication)
                {
                    int[] serverResponse = modbusClient.ReadInputRegisters(startAddress, length);
                    success = true;
                    return serverResponse;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return null;
            }
        }
        public bool WriteFloatToServer(int startAddress, float value)
        {
            try
            {
                if (!IsConnected)
                    return false;
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                if (!modbusClient.Connected && IsConnected)
                    return false;
                lock (LockCommunication)
                {
                    int[] registersToSend = ModbusClient.ConvertFloatToRegisters(value, ModbusClient.RegisterOrder.HighLow);
                    modbusClient.WriteMultipleRegistersA((startAddress), registersToSend);
                    return true;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return false;
            }
        }
        public bool WriteDoubleToServer(int startAddress, double value)
        {
            try
            {
                if (!IsConnected)
                    return false;
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                if (!modbusClient.Connected && IsConnected)
                    return false;
                lock (LockCommunication)
                {
                    int[] registersToSend = ModbusClient.ConvertDoubleToRegisters(value, ModbusClient.RegisterOrder.HighLow);
                    modbusClient.WriteMultipleRegistersA((startAddress), registersToSend);
                    return true;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return false;
            }
        }
        public bool WriteSingleRegister(int startAddress, int value)
        {
            try
            {
                if (!IsConnected)
                    return false;
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                if (!modbusClient.Connected && IsConnected)
                    return false;
                lock (LockCommunication)
                {
                    modbusClient.WriteSingleRegister(startAddress, value);
                    return true;
                }

            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return false;
            }
        }
        public bool WriteSingleCoil(int startAddress, bool value)
        {
            try
            {
                if (!IsConnected)
                    return false;
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                if (!modbusClient.Connected && IsConnected)
                    return false;
                lock (LockCommunication)
                {
                    modbusClient.WriteSingleCoil(startAddress, value);
                }
                return true;
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return false;
            }
        }
        public bool WriteMultiCoil(int startAddress, bool[] value)
        {
            try
            {
                if (!IsConnected)
                    return false;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                if (!modbusClient.Connected && IsConnected)
                    return false;
                lock (LockCommunication)
                {
                    modbusClient.WriteMultipleCoils(startAddress, value);
                }
                return true;
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                return false;
            }
        }
        public bool WriteStringToServer(int startAddress, string value)
        {
            try
            {
                if (!IsConnected)
                    return false;
                ErrMessage = string.Empty;
                if (!modbusClient.Connected && IsConnected)
                    Connect(IP, Port);
                if (!modbusClient.Connected && IsConnected)
                    return false;
                lock (LockCommunication)
                {
                    int[] registersToSend = ModbusClient.ConvertStringToRegisters(value);
                    modbusClient.WriteMultipleRegistersA((startAddress), registersToSend);
                    return true;
                }
            }
            catch (Exception exc)
            {
                GlobFuncs.SaveErr(exc);
                ErrMessage = exc.Message;
                IsConnected = false;
                return false;
            }
        }
        #endregion

    }
}
