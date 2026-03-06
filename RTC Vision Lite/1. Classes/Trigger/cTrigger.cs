using InControls.Common;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cTrigger
    {
        public ETriggerType TriggerType { get; set; }
        public ETriggerMode TriggerMode { get; set; }

        public string COMName { get; set; }

        public int BaudRate { set; get; }

        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public bool IsHex { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public bool IsServer { get; set; }
        public EPLCReadType PLCReadType { get; set; }
        public string PLCAddress { get; set; }
        public int ByteLenght { get; set; }
        public string TriggerValue { get; set; }
        public ControllerTypeConst ControllerTypeConst { get; set; }

        public cTrigger()
        {
            TriggerType = ETriggerType.ASync;
            TriggerMode = ETriggerMode.None;
            COMName = string.Empty;
            BaudRate = 9600;
            DataBits = 8;
            Parity = Parity.None;
            StopBits = StopBits.One;
            IsHex = false;
            IsServer = false;
            IP = string.Empty;
            Port = 3000;
            PLCReadType = EPLCReadType.COM;
            PLCAddress = string.Empty;
            TriggerValue = cStrings.TriggerValueDefault;
        }
    }
}
