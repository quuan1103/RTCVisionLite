using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCEnums
{
    public enum EAlarmTypes
    {
        PLC = 0
    }

   public enum ECamTypes
    {
        Normal = 0,
        Align = 1,
        ChangeJob = 2,
        Manual = 3
    }

    public enum ESdkModes
    {
        Hikrobot = 0,
        HikrobotGenTL = 1,
        Basler = 2,
        Dahua =  3
    }
}
