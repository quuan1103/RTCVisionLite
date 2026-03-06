using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction : IDisposable
    {
        public void Run_ClearWindows_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_ClearWindow();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        private void Run_ClearWindowProcess()
        {
            if (IsAllWindows.rtcValue)
            {
                foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                {
                    cam.View?.ClearWindow();
                }
            }
            else
            {
                if (IsRunByRunOrder.rtcValue)
                {
                    if (RunOrderCams.rtcValue != null && RunOrderCams.rtcValue.Count > 0)
                    {
                        for (int i = 0; i < RunOrderCams.rtcValue.Count; i++)
                        {
                            cCAMTypes camTypes = GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.RunOrder == GlobFuncs.Ve2Interger(RunOrderCams.rtcValue[i]));
                            camTypes?.View?.ClearWindow();
                        }
                    }
                }
                else
                {
                    string[] programNames = ProgramName.rtcValue.Split(cChars.Comma);
                    foreach (string programName in programNames)
                    {
                        cCAMTypes cam = GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name.ToLower() == programName.ToLower());
                        cam?.View?.ClearWindow();

                    }
                }
            }
        }
        public void Run_ClearWindow(bool isTest = false)
        {
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            if (GlobVar.CurrentProject == null)
                return;
            if (RunMode.rtcValue == cRunMode.Sync)
                Run_ClearWindowProcess();
            else
            {
                Thread threadRun = new Thread(Run_ClearWindowProcess)
                {
                    IsBackground = true
                };
                threadRun.Start();
            }
            Passed.rtcValue = true;
            if (IsRunOneTime.rtcValue && !isTest)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        }
    }
}
