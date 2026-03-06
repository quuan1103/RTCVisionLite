using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cGroupActions
    {
        public void CleanData()
        {
            foreach (cAction action in Actions.Values)
                action.ResetMyPropertyValue();
            Refvalues.Clear();

            if (frmHsmartWindow != null)
                frmHsmartWindow.ResetImage();
            if (frmHsmartWindow.SmartWindow != null)
            {
                frmHsmartWindow.SmartWindow.ClearImage();

            }

        }
    }
}
