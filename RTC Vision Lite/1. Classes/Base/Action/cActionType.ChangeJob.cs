using RTC_Vision_Lite.Classes.ProjectFunctions;
using RTC_Vision_Lite.PublicFunctions;
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
        public void Run_ChangeJob_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_ChangeJob();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);

            if (GlobVar.IsChangeJob)
            {
                GlobFuncs.ShowWaitForm("Change Job...");
                Task.Delay(GlobVar.RTCVision.Options.TimeDelayWhenChangeJob).ContinueWith(t => cProjectFunctions.ChangeJob());
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the change job operation. </summary>
        ///
        /// <remarks>   DATRUONG, 24/11/2021. </remarks>
        ///
        /// <param name="isTest">   (Optional) True if is test, false if not. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_ChangeJob()
        {
            Passed.rtcValue = false;
            GlobVar.IsChangeJob = false;

            ErrMessage.rtcValue = new List<string>();

            if (GlobVar.DicProjects == null || GlobVar.DicProjects.Values.Count <= 0)
            {
                ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "Model" }, new string[] { "Model" }) };
                return;
            }

            if (IsUsingOrderNumber.rtcValue)
            {
                if (OrderNumber.rtcValue == GlobVar.CurrentProject.OrderNum)
                {
                    Passed.rtcValue = true;
                    //ErrMessage.rtcValue = cMessageContent.War_YouAreWorkingWithTheModelYouNeedToChange;
                    return;
                }

                if (GlobVar.DicProjects == null || GlobVar.DicProjects.Values.FirstOrDefault(x => x.OrderNum == OrderNumber.rtcValue) == null)
                {
                    ErrMessage.rtcValue = new List<string> { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                        new string[] { "Model" }, new string[] { "Model" }) };
                    return;
                }
            }
            else
            {
                if (ProjectName.rtcValue == string.Empty)
                {
                    ErrMessage.rtcValue = new List<string>() {cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                        new string[] { "Model" }, new string[] { "Model" }) };
                    return;
                }
                if (GlobVar.DicProjects.Values.FirstOrDefault(x =>
                    x.ProjectName.ToLower() == ProjectName.rtcValue.ToLower()) == null)
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                        new string[] { "Model" }, new string[] { "Model" }) };
                    return;
                }
                if (ProjectName.rtcValue == GlobVar.CurrentProject.ProjectName)
                {
                    Passed.rtcValue = true;
                    return;
                }
            }

            Passed.rtcValue = true;
            GlobVar.IsChangeJob = true;
            GlobVar.ChangeJob_ProjectName = ProjectName.rtcValue;
            GlobVar.ChangeJob_OrderNumber = OrderNumber.rtcValue;
            GlobVar.ChangeJob_AutoStart = AutoStart.rtcValue;
            GlobVar.ChangeJob_UseOrderNumber = IsUsingOrderNumber.rtcValue;
        }
    }
}
