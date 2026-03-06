using RTCEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_LiveCam_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_LiveCam();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_LiveCam()
        {
            try
            {
                Passed.rtcValue = false;
                ErrMessage.rtcValue = new List<string>() { string.Empty };
                IsFinishRunOneTime.rtcValue = false;

                if (MyGroup.SourceImageSettings.ImageSourceType != EImageSourceTypes.Camera)
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_SourceImageNotIsCamera };
                    return;
                }
                if (!MyGroup.ConnectCamera())
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_CAMCannotConnectCamera };
                    return;
                }
                Passed.rtcValue = MyGroup.SetLiveCamera(true);
                if (IsRunOneTime.rtcValue)
                    IsFinishRunOneTime.rtcValue = Passed.rtcValue;
                if (!Passed.rtcValue)
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.War_CannotLiveCamera };
            }
            catch (Exception ex)
            {
                ErrMessage.rtcValue = new List<string> { ex.Message };
                Passed.rtcValue = false;
            }
        }
    }
}