using RTCConst;
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
        public void Run_RunCommandTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_RunCommand();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_RunCommand()
        {
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = Command.rtcValue,
                    Arguments = Arguments.rtcValue,
                    CreateNoWindow = IsCreateNoWindow.rtcValue
                };
                if (!startInfo.CreateNoWindow)
                    switch (WindowStyle.rtcValue)
                    {
                        case cWindowStyle.Normal:
                            {
                                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                                break;
                            }
                        case cWindowStyle.Maximized:
                            {
                                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                                break;
                            }
                        case cWindowStyle.Minimized:
                            {
                                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                                break;
                            }
                        case cWindowStyle.Hidden:
                            {
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                break;
                            }
                    }
                process.StartInfo = startInfo;
                process.Start();
                Passed.rtcValue = true;
            }
            catch (Exception ex)
            {
                Passed.rtcValue = false;
                ErrMessage.rtcValue[0] = ex.Message;

            }
            if (IsRunOneTime.rtcValue)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        }
    }
}
