using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes.ProjectFunctions
{
    public static partial class cProjectFunctions
    {
        #region RUN FUNCTIONS

        public static bool IsStillCamRunning(cProjectTypes project)
        {
            if (project == null)
                return false;

            foreach (var projectCam in project.CAMs)
                if (projectCam.Value.IsCamCanRunAuto() && projectCam.Value.GroupActions.IsRun)
                {
                    return true;
                }
            return false;
        }


        public static bool IsAllCamRunning(cProjectTypes project)
        {
            if (project == null)
                return false;
            bool bResult = true;
            foreach (var projectCam in project.CAMs)
                if (projectCam.Value.IsCamCanRunAuto() && !projectCam.Value.GroupActions.IsRun)
                {
                    bResult = false;
                    break;
                }    
            return bResult;
        }
        public static void Stop(cCAMTypes cam)
        {
            cam.GroupActions.Setting_StopRun();
        }

        public static void StopAllCam(cProjectTypes project)
        {
            foreach (var projectCam in project.CAMs)
                projectCam.Value.GroupActions.Setting_StopRun();
            project.IsRun = false;
        }
        public static void RebuildContent(string status)
        {

            GlobVar.LockEvents = true;
            if (GlobVar.FormMain.InvokeRequired)
                GlobVar.FormMain.Invoke((MethodInvoker)delegate
                {
                    GlobVar.FormMain.mnuRun.Enabled = true;
                });
            else
                GlobVar.FormMain.mnuRun.Enabled = true;
            GlobVar.LockEvents = false;
        }
        public static void Run(cCAMTypes cam)
        {
            cam.GroupActions.IstheFirstTimeRunning = true;
            var ListRunProgram = cam.GroupActions.Actions.Values
                .Where(x => x.ActionType == EActionTypes.RunProgram).ToList();
            if (ListRunProgram.Any())
                foreach (cAction action in ListRunProgram)
                    if (action.IsRunByRunOrder.rtcValue)
                    {
                        if (action.RunOrderCams.rtcValue != null && action.RunOrderCams.rtcValue.Count > 0)
                            for (int i = 0; i < action.RunOrderCams.rtcValue.Count; i++)
                            {
                                cCAMTypes cam1 = GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x =>
                                x.RunOrder == GlobFuncs.Ve2Interger(action.RunOrderCams.rtcValue[i]));
                                if (cam1 != null)
                                    cam1.GroupActions.IstheFirstTimeRunning = true;
                            }
                    }
                    else
                    {
                        cCAMTypes cam1 =
                            GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x =>
                            x.Name.ToLower() == action.ProgramName.rtcValue.ToLower());
                        if (cam1 != null)
                            cam1.GroupActions.IstheFirstTimeRunning = true;
                    }

            var listViewResultActions = cam.GroupActions.Actions.Values
                .Where(x=> x.ActionType == EActionTypes.ViewResult).ToList();
            if(listViewResultActions.Any())
                foreach (cAction action in listViewResultActions)
                    if(action.IsRunByRunOrder.rtcValue)
                    {
                        cCAMTypes cam1 = GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.RunOrder == action.RunOrder.rtcValue);
                        if (cam1 != null)
                            cam1.GroupActions.IstheFirstTimeRunning = true;
                    }    
                    else
                    {
                        cCAMTypes cam1 = GlobVar.CurrentProject.CAMs.Values.FirstOrDefault(x => x.ID.ToString() == action.ProgramID.ToString());
                        if (cam1 != null)
                            cam1.GroupActions.IstheFirstTimeRunning = true;
                    }
            cam.GroupActions.IsRunInThread = true;
            cam.GroupActions.Setting_StartRun(ERunActionMode.Endless, false, "", true, true);
            //Thread threadRun = new Thread(() => cam.GroupActions.Setting_Run(ERunActionMode.Endless, false, "", true, true))
            //{
            //    IsBackground = true
            //};
            //threadRun.Start();
            //threadRun.Join();
        }

        public static void Run(cProjectTypes project)
        {
            // Tại đậy chạy toàn bộ các CAM thành nhiều luồng khác nhau
            foreach (var projectCam in project.CAMs)
                if (projectCam.Value.IsCamCanRunAuto() && !projectCam.Value.IsRun)//Nó phải là active, là master và không phải background cam đồng thời chưa chạy
                {
                    projectCam.Value.GroupActions.Actions[projectCam.Value.GroupActions.IDMainAction].ProgramMode.rtcValue = GlobVar.ProgramMode;
                    projectCam.Value.GroupActions.Actions[projectCam.Value.GroupActions.IDMainAction].ManualAction.rtcValue = cManualAction.None;
                    projectCam.Value.GroupActions.Actions[projectCam.Value.GroupActions.IDMainAction].IsHaveError.rtcValue = false;
                    projectCam.Value.GroupActions.Actions[projectCam.Value.GroupActions.IDMainAction].IsHaveWarning.rtcValue = false;

                    cProjectFunctions.Run(projectCam.Value);
                }
            project.IsRun = true;
        }
        internal static void UpdateCounterToForm()
        {
            if (GlobVar.FormMain == null || GlobVar.CurrentProject == null)
                return;
            if (GlobVar.FormMain.InvokeRequired)
                GlobVar.FormMain.Invoke((MethodInvoker)UpdateCounterToFormCalculator);
            else UpdateCounterToFormCalculator();
        }
        public static void UpdateCounterToFormCalculator()
        {
            GlobVar.FormMain.lblOK.Text = "OK: " + GlobVar.CurrentProject.OKCount.ToString() + " (" +
                                             GlobFuncs.GetPercent(GlobVar.CurrentProject.OKCount,
                                                 GlobVar.CurrentProject.TotalCount).ToString() + "%)";
            GlobVar.FormMain.lblNG.Text = "NG: " + GlobVar.CurrentProject.NGCount.ToString() + " (" +
                                             GlobFuncs.GetPercent(GlobVar.CurrentProject.NGCount,
                                                 GlobVar.CurrentProject.TotalCount).ToString() + "%)";
            GlobVar.FormMain.lblTotal.Text = "TOTAL: " + GlobVar.CurrentProject.TotalCount.ToString();
        }

        #endregion
    }
}
