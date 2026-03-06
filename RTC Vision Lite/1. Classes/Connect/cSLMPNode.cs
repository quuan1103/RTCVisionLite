using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTCVision2101.MainModule.Enums;

namespace SLMPTcp
{
    public class cSLMPNode
    {
        public string Address { get; set; }
        public ESLMPDataType DataType { get; set; }
        public int Length { get; set; }
        public int[] Values { get; set; }
    }
}
