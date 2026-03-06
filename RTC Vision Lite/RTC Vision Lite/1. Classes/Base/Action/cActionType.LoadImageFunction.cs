using RTC_Vision_Lite.PublicFunctions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_LoadImage_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_LoadImage();
            stopwatch.Start();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_LoadImage()
        {
            try
            {
                Passed.rtcValue = false;
                ErrMessage.rtcValue = new List<string>();

                if (!File.Exists(FileName.rtcValue))
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists, new string[] { "file name" }, new string[] { "ten file" }) };
                    return;
                }

                if (OutputImage.rtcValue != null)
                {
                    OutputImage.rtcValue.Dispose();
                    OutputImage.rtcValue = null;
                }

                OutputImage.rtcValue = new Bitmap(FileName.rtcValue);
                if (!MyGroup.RunSimple && MyGroup.frmHsmartWindow != null)
                    MyGroup.frmHsmartWindow.Image = GlobFuncs.CopyImage(OutputImage.rtcValue);

                IsFinishRunOneTime.rtcValue = true;

                MyGroup.IsSnapSuccess = (OutputImage.rtcValue != null);

                if (IsBringImageToMain.rtcValue)
                    MyGroup.Actions[MyGroup.IDMainAction].InputImage.rtcValue = OutputImage.rtcValue;

                Passed.rtcValue = MyGroup.IsSnapSuccess;
                if (!Passed.rtcValue)
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_CannotLoadImage,
                        new string[] { Name.rtcValue }, new string[] { Name.rtcValue }) };
            }
            catch (Exception ex)
            {
                ErrMessage.rtcValue = new List<string>() { ex.Message };
            }
        }    
    }
}
