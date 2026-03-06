using RTC_Vision_Lite.UserControls;
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
        internal void Run_ViewResult_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);

            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }

        internal void Run_ViewResult()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;

            if(GlobVar.CurrentProject == null)
            {
                IsRunning.rtcValue = false;
                return;
            }
            //Run_ViewResult_BuildSaveImagePath();

            //if (IsRunByRunOrder.rtcValue)
            //    this.MyGroup.ViewRe
        }

    }
}
