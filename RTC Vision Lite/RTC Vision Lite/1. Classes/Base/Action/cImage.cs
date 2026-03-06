using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class cImage
    {
        public string FileName;

        //public HImage

        public bool Passed;
        public bool Ran;

        public cImage()
        {
            FileName = string.Empty;
            Passed = false;
            Ran = false;
        }
    }
}
