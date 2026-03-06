using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTC_Vision_Lite.PublicFunctions;

namespace RTC_Vision_Lite.Classes
{
    public partial class cProjectTypes
    {
        public bool Clone()
        {
            try
            {
                return GlobFuncs.BackupFile(FileName, FileNameBAK);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
