using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCEnums
{
    /// <summary>
    /// Enum kiểu Device truyền thông
    /// </summary>
    public enum EDeviceTypes
    {
        None = 0,
        PLC = 1,
        Robot = 2,
        Other = 3
    }
    /// <summary>
    /// Enum kiểu Protocols
    /// </summary>
    public enum EProtocols
    {
        Modbus = 1,
        CCLink = 2,
        SLMP = 3,
        SLMPScaner = 4,
        EthernetIP = 5,
        PROFINET = 6,
        EthernetNR = 7,
        EthernetIR = 8,
        EthernetNS = 9,
        TCPIP = 10,
        UDP = 11
    }

    public enum EOutputStringMode
    {
        PassFailValue = 0,
        Advanced = 1,
        Tool = 2,
        None = 9999
    }
}
