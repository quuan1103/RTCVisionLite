using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCEnums;
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
    public partial class cAction
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the program test operation. </summary>
        ///
        /// <remarks>   DATRUONG, 16/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_Program_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_Program(true);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
            if (this.ViewInfo != null && !MyGroup.RunSimple)
                ((ucBaseActionDetail)ViewInfo).ReviewAllPropertyValueToViewInfo();
            ////((ucBaseActionDetail)ViewInfo).UpdatePropertyValueToAllControls(nameof(this.Passed));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the program stop operation. </summary>
        ///
        /// <remarks>   DATRUONG, 16/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_Program_Stop()
        {
            if (GlobVar.CurrentProject == null)
                return;
            if (string.IsNullOrEmpty(ProgramName.rtcValue))
                return;
            cCAMTypes camTypes =
                GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x =>
                    x.Name.ToLower() == ProgramName.rtcValue.ToLower());
            if (camTypes == null)
                return;

            camTypes.GroupActions.Setting_StopRun();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the program operation. </summary>
        ///
        /// <remarks>   DATRUONG, 12/11/2021. </remarks>
        ///
        /// <param name="isTest">   (Optional) True if is test, false if not. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_Program(bool isTest = false)
        {
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            IsRunning.rtcValue = true;

            if (GlobVar.CurrentProject == null)
            {
                IsRunning.rtcValue = false;
                return;
            }

            List<cCAMTypes> camTypesList = new List<cCAMTypes>();
            cCAMTypes camTypes = null;
            if (IsRunByRunOrder.rtcValue)
            {
                if (RunOrderCams.rtcValue != null && RunOrderCams.rtcValue.Count > 0)
                    for (int i = 0; i < RunOrderCams.rtcValue.Count; i++)
                    {
                        camTypes =
                            GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x =>
                                x.RunOrder == GlobFuncs.Ve2Interger(RunOrderCams.rtcValue[i]));
                        if (camTypes != null)
                            camTypesList.Add(camTypes);
                    }
            }
            else
            {
                camTypes =
                   GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x =>
                       x.Name.ToLower() == ProgramName.rtcValue.ToLower());
                if (camTypes != null)
                    camTypesList.Add(camTypes);
            }

            if (camTypesList.Count <= 0)
            {
                IsRunning.rtcValue = false;
                return;
            }

            foreach (cCAMTypes cam in camTypesList)
            {
                if (RunMode.rtcValue == cRunMode.Sync)
                {
                    cam.GroupActions.Setting_Run(ERunActionMode.Next);
                    if (string.IsNullOrEmpty(cam.GroupActions.ErrMessage))
                        Passed.rtcValue = true;
                    IsRunning.rtcValue = false;
                    ResultOK.rtcValue = cam.GroupActions.Actions[cam.GroupActions.IDMainAction].ResultOK.rtcValue;
                }
                else
                {
                    Task.Factory.StartNew(() => cam.GroupActions.Setting_Run(ERunActionMode.Next,
                         false, "", false, true, true, this));
                    if (string.IsNullOrEmpty(cam.GroupActions.ErrMessage))
                        Passed.rtcValue = true;
                }
            }

            if (IsRunOneTime.rtcValue && !isTest)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        }
    }

}
