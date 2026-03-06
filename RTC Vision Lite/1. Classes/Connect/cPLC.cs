using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCVision2101.Classes
{
    public static class cPLC
    {
        public static HTuple RecDataFromPLC(HTuple _DataType, HTuple _PLCAddress, HTuple _ValueLength, HTuple _Socket,out string _ErrMessage)
        {
            HTuple data = -1;
            _ErrMessage = string.Empty;
            try
            {
                HDevProcedure getDataPlc = new HDevProcedure("Melsoft_3E_Revc");
                HDevProcedureCall getDataPlcCall = new HDevProcedureCall(getDataPlc);
                getDataPlcCall.SetInputCtrlParamTuple("Data_Type", _DataType);
                getDataPlcCall.SetInputCtrlParamTuple("Destination", _PLCAddress);
                getDataPlcCall.SetInputCtrlParamTuple("Lenght", _ValueLength);
                getDataPlcCall.SetInputCtrlParamTuple("Socket", _Socket);
                getDataPlcCall.Execute();
                data = getDataPlcCall.GetOutputCtrlParamTuple("Data_Tuple");
            }
            catch (Exception ex)
            {
                _ErrMessage = ex.Message;
                data = "Error";
            }
            return data;
        }
        public static HTuple SendDataFromPLC(HTuple _DataType, HTuple _DataValue, HTuple _PLCAddress, HTuple _Socket, out string _ErrMessage)
        {
            HTuple data = -1;
            _ErrMessage = string.Empty;
            try
            {
                HDevProcedure setDataPlc = new HDevProcedure("Melsoft_3E_Send");
                HDevProcedureCall setDataPlcCall = new HDevProcedureCall(setDataPlc);
                setDataPlcCall.SetInputCtrlParamTuple("Data_Type", _DataType);
                setDataPlcCall.SetInputCtrlParamTuple("Data_Tuple", _DataValue);
                setDataPlcCall.SetInputCtrlParamTuple("Destination", _PLCAddress);
                setDataPlcCall.SetInputCtrlParamTuple("Socket", _Socket);
                setDataPlcCall.Execute();
                data = setDataPlcCall.GetOutputCtrlParamTuple("CCode");
            }
            catch (Exception ex)
            {
                _ErrMessage = ex.Message;
                data = "Error";
            }

            return data;

        }
        public static HTuple GetBitFromPLC(HTuple _PLCAddress, HTuple _IndexBit, HTuple _Socket, out string _ErrMessage)
        {
            HTuple data = -1;
            _ErrMessage = string.Empty;
            try
            {
                HDevProcedure getDataPlc = new HDevProcedure("Melsoft_3E_Revc");
                HDevProcedureCall getDataPlcCall = new HDevProcedureCall(getDataPlc);
                HDevProcedure GetBitPlc = new HDevProcedure("Get_Bit_Of_Word");
                HDevProcedureCall GetBitPlcCall = new HDevProcedureCall(GetBitPlc);
                getDataPlcCall.SetInputCtrlParamTuple("Data_Type", "Word");
                getDataPlcCall.SetInputCtrlParamTuple("Destination", _PLCAddress);
                getDataPlcCall.SetInputCtrlParamTuple("Lenght", 1);
                getDataPlcCall.SetInputCtrlParamTuple("Socket", _Socket);
                getDataPlcCall.Execute();
                data = getDataPlcCall.GetOutputCtrlParamTuple("Data_Tuple");
                GetBitPlcCall.SetInputCtrlParamTuple("Data", data);
                GetBitPlcCall.SetInputCtrlParamTuple("Order_Tuple", _IndexBit);
                GetBitPlcCall.Execute();
                data = GetBitPlcCall.GetOutputCtrlParamTuple("Out_Tuple");
            }
            catch (Exception ex)
            {
                _ErrMessage = ex.Message;
                data = "Error";
            }
            return data;
        }
        public static HTuple SetBitFromPLC(HTuple _PLCAddress, HTuple _IndexBit, HTuple _ValueBit, HTuple _Socket, out string _ErrMessage)
        {
            HTuple data = -1;
            _ErrMessage = string.Empty;
            try
            {
                HDevProcedure getDataPlc = new HDevProcedure("Melsoft_3E_Revc");
                HDevProcedureCall getDataPlcCall = new HDevProcedureCall(getDataPlc);
                HDevProcedure setBitPlc = new HDevProcedure("Set_Bit_To_Word");
                HDevProcedureCall setBitPlcCall = new HDevProcedureCall(setBitPlc);
                HDevProcedure setDataPlc = new HDevProcedure("Melsoft_3E_Send");
                HDevProcedureCall setDataPlcCall = new HDevProcedureCall(setDataPlc);
                getDataPlcCall.SetInputCtrlParamTuple("Data_Type", "Word");
                getDataPlcCall.SetInputCtrlParamTuple("Destination", _PLCAddress);
                getDataPlcCall.SetInputCtrlParamTuple("Lenght", 1);
                getDataPlcCall.SetInputCtrlParamTuple("Socket", _Socket);

                getDataPlcCall.Execute();
                data = getDataPlcCall.GetOutputCtrlParamTuple("Data_Tuple");
                setBitPlcCall.SetInputCtrlParamTuple("Data", data);
                setBitPlcCall.SetInputCtrlParamTuple("Order_Tuple", _IndexBit);
                setBitPlcCall.SetInputCtrlParamTuple("Order_Value", _ValueBit);
                setBitPlcCall.Execute();
                data = setBitPlcCall.GetOutputCtrlParamTuple("D_Out");


                setDataPlcCall.SetInputCtrlParamTuple("Data_Type", "Word");
                setDataPlcCall.SetInputCtrlParamTuple("Data_Tuple", data);
                setDataPlcCall.SetInputCtrlParamTuple("Destination", _PLCAddress);
                setDataPlcCall.SetInputCtrlParamTuple("Socket", _Socket);
                setDataPlcCall.Execute();
                data = setDataPlcCall.GetOutputCtrlParamTuple("CCode");

            }
            catch (Exception ex)
            {

                _ErrMessage = ex.Message;
                data = "Error";
            }
            return data;
        }
    }
}
