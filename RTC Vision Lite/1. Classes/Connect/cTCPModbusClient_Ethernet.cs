using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
//using InControls.Common;
//using InControls.PLC.FX;
using System.IO.Ports;
using RTC_Vision_Lite.PublicFunctions;
//using InControls.PLC;
using System.Collections.Generic;
//using LIB_MCProtocol.Mitsubishi;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using RTC_Vision_Lite.Classes;
using EasyModbus;

//using EasyModbus;

namespace RTC_Vision_Lite.Classes
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A TCP modbus client ethernet./ </summary>
    ///
    /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class cTCPModbusClient_Ethernet
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the IP address. </summary>
        ///
        /// <value> The IP address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string IPAddress { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the port. </summary>
        ///
        /// <value> The port. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public int Port { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this object is connected. </summary>
        ///
        /// <value> True if this object is connected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool IsConnected { get; set; }
        /// <summary>   The modbus client. </summary>
        private ModbusClient modbusClient;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public cTCPModbusClient_Ethernet()
        {
            IsConnected = false;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_IPAddress">       The IP address. </param>
        /// <param name="_Port">            The port. </param>
        /// <param name="_IsWithConnect">   (Optional) True if is with connect, false if not. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public cTCPModbusClient_Ethernet(string _IPAddress, int _Port, bool _IsWithConnect = true)
        {
            IsConnected = false;
            Port = _Port;
            IPAddress = _IPAddress;
            if (_IsWithConnect)
                Connect();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Connect </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Connect()
        {
            try
            {
                modbusClient = new ModbusClient(IPAddress, Port);
                modbusClient.Connect();
                IsConnected = modbusClient.Connected;
                //ThreadGetValue = new Thread(() => ProcessGetValue());
                //ThreadGetValue.IsBackground = true;
                //ThreadGetValue.Start();
                return IsConnected;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                return false;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Disconnect </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Disconnect()
        {
            //IsRun = false;
            //ThreadGetValue.Abort();
            if (modbusClient != null)
                modbusClient.Disconnect();
            modbusClient = null;
            IsConnected = false;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   [FC1] Reads the coils. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_StartingAddress"> The starting address. </param>
        /// <param name="_Quantity">        The quantity. </param>
        ///
        /// <returns>   An array of bool. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool[] ReadCoils(int _StartingAddress, int _Quantity)
        {
            bool[] value = new bool[] { };
            if (IsConnected)
            {
                value = modbusClient.ReadCoils(_StartingAddress, _Quantity);
            }

            return value;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   [FC2] Reads discrete inputs. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_StartingAddress"> The starting address. </param>
        /// <param name="_Quantity">        The quantity. </param>
        ///
        /// <returns>   An array of bool. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool[] ReadDiscreteInputs(int _StartingAddress, int _Quantity)
        {
            bool[] value = new bool[] { };
            if (IsConnected)
                value = modbusClient.ReadDiscreteInputs(_StartingAddress, _Quantity);

            return value;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   [FC3] Reads holding registers. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_StartingAddress"> The starting address. </param>
        /// <param name="_Quantity">        The quantity. </param>
        ///
        /// <returns>   An array of int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private int[] ReadHoldingRegisters(int _StartingAddress, int _Quantity)
        {
            int[] value = new int[] { };
            if (IsConnected)
                value = modbusClient.ReadHoldingRegisters(_StartingAddress, _Quantity);

            return value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   [FC4] Reads input registers. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_StartingAddress"> The starting address. </param>
        /// <param name="_Quantity">        The quantity. </param>
        ///
        /// <returns>   An array of int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int[] ReadInputRegisters(int _StartingAddress, int _Quantity)
        {
            int[] value = new int[] { };
            if (IsConnected)
                value = modbusClient.ReadInputRegisters(_StartingAddress, _Quantity);

            return value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   [FC5] Writes a single coil. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_StartingAddress"> The starting address. </param>
        /// <param name="_Value">           Value need write. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void WriteSingleCoil(int _StartingAddress, bool _Value)
        {
            if (IsConnected)
                modbusClient.WriteSingleCoil(_StartingAddress, _Value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   [FC6] Writes a single register. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_StartingAddress"> The starting address. </param>
        /// <param name="_Value">           Value need write. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void WriteSingleRegister(int _StartingAddress, int _Value)
        {
            if (IsConnected)
                modbusClient.WriteSingleRegister(_StartingAddress, _Value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   [FC15] Writes a multiple coils. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_StartingAddress"> The starting address. </param>
        /// <param name="_Value">           Value need write. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void WriteMultipleCoils(int _StartingAddress, bool[] _Value)
        {
            if (IsConnected)
                modbusClient.WriteMultipleCoils(_StartingAddress, _Value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   [FC16] Writes a multiple registers. </summary>
        ///
        /// <remarks>   Mr. Trường, 8/13/2021. </remarks>
        ///
        /// <param name="_StartingAddress"> The starting address. </param>
        /// <param name="_Value">           Value need write. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void WriteMultipleRegisters(int _StartingAddress, int[] _Value)
        {
            if (IsConnected)
                modbusClient.WriteMultipleRegisters(_StartingAddress, _Value);
        }
    }
}
