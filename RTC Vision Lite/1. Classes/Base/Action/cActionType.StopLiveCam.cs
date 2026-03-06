using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_StopLiveCam()
        {
            try
            {
                Passed.rtcValue = false;
                ErrMessage.rtcValue = new List<string>();
                Passed.rtcValue = MyGroup.SetLiveCamera(false);
                if (!Passed.rtcValue)
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_CannotLiveCamera };
            }
            catch (Exception ex)
            {
                ErrMessage.rtcValue = new List<string>() { ex.Message };
                Passed.rtcValue = false;
            }
        }
    }
}
