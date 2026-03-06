using log4net;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserManager.Classes;
using RTCConst;
using RTCSystem;
using RTCUpdate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobFuncs.ReadAppInfo();
            if (!GlobFuncs.SetupEnvironment())
                return;
            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            // Handler for exceptions in threads behind forms.
            System.Windows.Forms.Application.ThreadException += GlobalThreadExceptionHandler;
            Application.Run(new FrmMain());
            //Application.EnableVisualStyles();
            ////Application.SetCompatibleTextRenderingDefault(false);
            //SplashScreen splashScreen = new SplashScreen();
            ////splashScreen.Status = "Load Settings...";
            ////splashScreen.Show();

            //GlobFuncs.ReadAppInfo();
            //if (GlobVar.RTCVision.UpdateOptions.IsAutoUpdate &&
            //    GlobVar.RTCVision.UpdateOptions.UpdateMode == EUpdateMode.StartProgram)
            //{
            //    cUpdate update = new cUpdate();
            //    if (update.CheckUpdate(out string newVersion) && File.Exists(GlobVar.RTCVision.Files.Update))
            //        if (cMessageBox.Question_YesNo(cMessageContent.BuildMessage(cMessageContent.Que_Update,
            //            new string[] { newVersion }, new string[] { newVersion })) == DialogResult.Yes)
            //        {
            //            Process.Start(GlobVar.RTCVision.Files.Update);
            //            return;
            //        }
            //}
            ////splashScreen.Status = "CheckUpdate";
            //if (!GlobFuncs.SetupEnvironment())
            //    return;
            //AppDomain currentDomain = default(AppDomain);
            //currentDomain = AppDomain.CurrentDomain;
            //// Handler for unhandled exceptions.
            //currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            //// Handler for exceptions in threads behind forms.
            //System.Windows.Forms.Application.ThreadException += GlobalThreadExceptionHandler;
            //cUser.AutoLogin();

            //if (GlobVar.User == null && GlobVar.RTCVision.SecurityOptions.SecurityModes == cSecurityModes.SecurityModes_UseAccount &&
            //    GlobVar.RTCVision.SecurityOptions.IsNeedLoginWhenOpenProgram)
            //{
            //    if (!cUser.ShowFormLogin())
            //        return;
            //}

            //if (GlobVar.IsMainMode)
            //{
            //    try
            //    {
            //        //splashScreen.Close();
            //        GlobVar.FormMain = new FrmMain();
            //        Application.Run(GlobVar.FormMain);
            //    }
            //    catch (Exception ex)
            //    {
            //        GlobFuncs.SaveErr(ex);
            //    }
            //}
        }
        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = (Exception)e.ExceptionObject;
            ILog log = LogManager.GetLogger(typeof(Program));
            log.Error(ex.Message + "\n" + ex.StackTrace);
        }

        private static void GlobalThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = e.Exception;
            ILog log = LogManager.GetLogger(typeof(Program)); //Log4NET
            log.Error(ex.Message + "\n" + ex.StackTrace);
        }
    }
}
