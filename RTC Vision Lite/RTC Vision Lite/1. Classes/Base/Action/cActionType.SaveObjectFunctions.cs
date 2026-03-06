using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
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
        public void Run_SaveObject_Reset()
        {
            StartNumber.rtcValue = ResetNumber.rtcValue;
            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        public void Run_SaveObject_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MyGroup.GetValueToVariableIsRef(this);
            Run_SaveObject();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_SaveObject()
        {
            Passed.rtcValue = true;
            if (InputObject?.rtcValue == null)
                return;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            OutputFileName.rtcValue = string.Empty;
            string sFolder;
            string sFileName = FileName.rtcValue.Trim();
            sFolder = IsUseProjectFolder.rtcValue ? MyGroup.SaveFileFolder : FolderName.rtcValue;
            if (AutoCreateFolderByDate.rtcValue)
            {
                switch (DateFormat.rtcValue)
                {
                    case cDateTimeFormats.Split1:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString());
                            break;
                        }
                    case cDateTimeFormats.Split2:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());
                            break;
                        }
                    case cDateTimeFormats.Split3:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
                            break;
                        }
                    case cDateTimeFormats.Split4:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString());
                            break;
                        }
                    default:
                        {
                            sFolder = Path.Combine(sFolder, DateTime.Now.ToString(DateFormat.rtcValue));
                            break;
                        }
                }
            }
            if (FixedFileName.rtcValue)
            {
                if (string.IsNullOrEmpty(sFileName))
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                        new string[]{"File Name"},new string[] {"Tên ảnh"})};
                    return;
                }
                sFileName = GlobFuncs.FixedDirSepChar(sFolder) + FileName.rtcValue;
            }
            else
            {
                sFileName = PrefixName.rtcValue;

                if (SuffixNameMode.rtcValue == cSuffixNameMode.UseDateTime)
                {
                    if (DateTimeFormat.rtcValue == cDateTimeFormats.Tick)
                        sFileName = sFileName != "" ? sFileName + DateTime.Now.Ticks.ToString() : DateTime.Now.Ticks.ToString();
                    else
                        sFileName = sFileName != "" ? sFileName + DateTime.Now.ToString(DateTimeFormat.rtcValue) : DateTime.Now.ToString(DateTimeFormat.rtcValue);
                }
                else if (SuffixNameMode.rtcValue == cSuffixNameMode.UseNumberOrder)
                {
                    sFileName = sFileName != "" ? sFileName + StartNumber.rtcValue.ToString() : StartNumber.rtcValue.ToString();
                    if (StartNumber.rtcIDRef == Guid.Empty)
                    {
                        StartNumber.rtcValue += 1;
                        if (MaxNumber.rtcValue > 0 && StartNumber.rtcValue == MaxNumber.rtcValue)
                            StartNumber.rtcValue = ResetNumber.rtcValue;
                    }
                }
                sFileName = GlobFuncs.FixedDirSepChar(sFolder) + sFileName;
                if (File.Exists(sFileName) && !OverwriteWhenExists.rtcValue)
                {
                    Passed.rtcValue = false;
                    return;
                }
            }
            if (!GlobFuncs.CreateFolder(sFolder, out string errMessage))
            {
                ErrMessage.rtcValue = new List<string>() { errMessage };
                return;
            }
        }
    }
}
