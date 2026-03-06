using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class cLinkProperty
    {
        public Guid ID { get; set; }
        public int OrderNum { get; set; }
        public Guid SourceCamID { get; set; }
        public Guid SourceID { get; set; }
        public string SourceName { get; set; }
        public List<object> SourceIndex { get; set; }
        public Guid TargetCamID { get; set; }
        public Guid TargetID { get; set; }
        public string TargetName { get; set; }
        public List<object> TargetIndex { get; set; }
        public List<object> DefaultValue { get; set; }
        public cLinkProperty()
        {
            ID = Guid.NewGuid();
        }
        public cLinkProperty Clone()
        {
            cLinkProperty cloneProperty = new cLinkProperty
            {
                OrderNum = this.OrderNum,
                DefaultValue = this.DefaultValue,
                SourceCamID = this.SourceCamID,
                SourceID = this.SourceID,
                SourceName = this.SourceName,
                SourceIndex = this.SourceIndex,
                TargetCamID = this.TargetCamID,
                TargetID = this.TargetID,
                TargetName = this.TargetName,
                TargetIndex = this.TargetIndex
            };

            return cloneProperty;
        }
    }
}
