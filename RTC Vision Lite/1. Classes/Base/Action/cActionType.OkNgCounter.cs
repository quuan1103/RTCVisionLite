using RTC_Vision_Lite.Classes.ProjectFunctions;
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
        public void Run_OkNgCounter_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_OkNgCounter(true);
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }

        public void Run_OkNgCounter(bool isTest = false)
        {
            Passed.rtcValue = false;
            if (GlobVar.CurrentProject == null)
                return;
            switch (RunMode.rtcValue)
            {
                case cOKNGCounterRunMode.MainCounter:
                    {
                        switch (this.CounterType.rtcValue)
                        {
                            case cStrings.OK:
                                {
                                    GlobVar.CurrentProject.OKCount += 1;
                                    break;
                                }
                            case cStrings.NG:
                                {
                                    GlobVar.CurrentProject.NGCount += 1;
                                    break;
                                }
                        }
                        GlobVar.CurrentProject.TotalCount += 1;
                        this.MyGroup.MainAction.ModelTotalCount.rtcValue += 1;
                        //OkCount.rtcValue = GlobVar.CurrentProject.OKCount;
                        //NgCount.rtcValue = GlobVar.CurrentProject.NGCount;
                        //TotalCount.rtcValue = GlobVar.CurrentProject.TotalCount;
                        cProjectFunctions.UpdateCounterToForm();
                        cProjectFunctions.SaveProject_OnlyCounter(GlobVar.CurrentProject);

                        //
                        break;
                    }
                case cOKNGCounterRunMode.Window:
                    {
                        switch (this.CounterType.rtcValue)
                        {
                            case cStrings.OK:
                                {
                                    this.MyGroup.MyCam.OKCount += 1;
                                    break;
                                }
                            case cStrings.NG:
                                {
                                    this.MyGroup.MyCam.NGCount += 1;
                                    break;
                                }
                        }
                        this.MyGroup.MyCam.TotalCount += 1;
                        this.MyGroup.MainAction.ModelTotalCount.rtcValue += 1;
                        cProjectFunctions.UpdateCounterToForm();
                        cProjectFunctions.SaveProject_OnlyCounter(GlobVar.CurrentProject);
                        //camTypes.View?.Update

                        break;
                    }
                case cOKNGCounterRunMode.Both:
                    {
                        cCAMTypes camTypes = GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.Name.ToLower() == MyGroup.MyCam.Name.ToLower());
                        if (this.CounterType.rtcValue == cStrings.OK)
                        {
                            GlobVar.CurrentProject.OKCount += 1;
                            MyGroup.MainAction.OkCount.rtcValue += 1;
                            break;
                        }
                        else if (this.CounterNG.rtcValue == cStrings.NG)
                        {
                            GlobVar.CurrentProject.NGCount += 1;
                            MyGroup.MainAction.NgCount.rtcValue += 1;
                            break;
                        }
                        GlobVar.CurrentProject.TotalCount += 1;
                        this.MyGroup.MyCam.TotalCount += 1;
                        this.MyGroup?.MyCam?.View?.UpdateCounterToUI();
                        cProjectFunctions.SaveCamSetting_OnlyCounter(GlobVar.CurrentProject, this.MyGroup?.MyCam);
                        break;
                    }
            }
            if(MyGroup.RunSimple)
                foreach (cCAMTypes cam in GlobVar.CurrentProject.CAMs.Values)
                {
                    cam.GroupActions.MainAction.ModelOkCount.rtcValue = GlobVar.CurrentProject.OKCount;
                    cam.GroupActions.MainAction.ModelNgCount.rtcValue = GlobVar.CurrentProject.NGCount;
                    cam.GroupActions.MainAction.ModelTotalCount.rtcValue = GlobVar.CurrentProject.TotalCount;
                }
            Passed.rtcValue = true;
        }

    }
}
