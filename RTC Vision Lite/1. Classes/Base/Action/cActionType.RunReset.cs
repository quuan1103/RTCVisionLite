using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_ResetTool()
        {
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = true;

            if (ListResetTools == null) return;
            foreach (var tool in ListResetTools)
            {
                if (!tool.rtcActive) continue;
                cAction action = MyGroup.Actions.Values.FirstOrDefault(x => x.ID == tool.rtcIDref);
                if (action != null)
                    Passed.rtcValue = action.ResetPropertyValue(ID);
                if (!Passed.rtcValue) return;
            }
            //this.MyGroup.frmHsmartWindow.Image.Dispose();
            //this.MyGroup.frmHsmartWindow.hSmartWindowControl.HalconWindow.ClearWindow();
            //this.MyGroup.SmartWindowControl.HalconWindow.ClearWindow();
            if (IsRunOneTime.rtcValue)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        }
    }
}
