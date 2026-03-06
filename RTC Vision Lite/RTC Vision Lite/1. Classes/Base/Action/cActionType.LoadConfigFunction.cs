using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_LoadConfig_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_LoadConfig();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_LoadConfig()
        {
            try
            {
                Passed.rtcValue = false;
                ErrMessage.rtcValue = new List<string>() { string.Empty };
                if (!File.Exists(FileName.rtcValue))
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists, new string[] { "file name" }, new string[] { "tên file" }) };
                    return;
                }
                string iconicFileName = Path.ChangeExtension(FileName.rtcValue, cExtFile.CONFIGDICT);
                try
                {
                    if ((IsRunOneTime.rtcValue && !IsFinishRunOneTime.rtcValue) || !IsRunOneTime.rtcValue)
                    {
                        cSaveOpenFiles saveOpenFiles = new cSaveOpenFiles();
                        Passed.rtcValue = saveOpenFiles.LoadConfig(MyGroup, FileName.rtcValue, iconicFileName, out string errMessage) != EFunctionReturn.Error;
                        ErrMessage.rtcValue = new List<string>()
                        {
                            errMessage
                        };
                    }
                }
                catch (Exception ex)
                {
                    ErrMessage.rtcValue = new List<string> { ex.Message };
                }
            }
            catch (Exception ex)
            {
                ErrMessage.rtcValue = new List<string>() { ex.Message };
            }
        }
    }
}
