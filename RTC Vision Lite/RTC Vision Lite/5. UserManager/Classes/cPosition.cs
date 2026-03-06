using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.UserManager.Classes
{
    public partial class cPosition
    {
        public Guid ID { get; set; }
        public int OrderNum { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
