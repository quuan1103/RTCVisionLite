using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class cLinkPassFail
    {
        public Guid ID { get; set; }

        public bool rtcActive { get; set; }
        public int rtcSTT { get; set; }
        public Guid rtcIDref { get; set; }

        public string rtcPropNameRef { get; set; }
        public string rtcRef {get; set;}
        public bool rtcInvert { get; set; }

        public bool rtcGetResult { get; set; }
        public Guid rtcIDGetResult { get; set; }

    }
}
