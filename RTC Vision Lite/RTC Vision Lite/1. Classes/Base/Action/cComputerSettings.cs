using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class cComputerSettings
    {
        public bool IsFolder { get; set; }
        public string FolderPath { get; set; }
        public int CurrentImgIndex { get; set; }

        public List<cImage> Images { get; set; }

        public cComputerSettings()
        {
            IsFolder = true;
            FolderPath = string.Empty;
            Images = new List<cImage>();
            CurrentImgIndex = -1;
        }
    }
}
