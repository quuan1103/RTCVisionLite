using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
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
        public void Run_SaveConfig_Reset()
        {
            StartNumber.rtcValue = ResetNumber.rtcValue;
            OutputFileName.rtcValue = string.Empty;
            if (this.ViewInfo != null)
            {
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
            }
        }
        public void Run_SaveConfig_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MyGroup.GetValueToVariableIsRef(this);
            Run_SaveConfig();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_SaveConfig()
        {
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>()
            {
                string.Empty
            };
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
                            sFolder = Path.Combine(sFolder, DateTime.Now.ToString());
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
                            sFolder = Path.Combine(sFolder, DateTime.Now.ToString(DateTimeFormat.rtcValue));
                            break;
                        }
                }
            }
            if (FixedFileName.rtcValue)
            {
                if (string.IsNullOrEmpty(sFileName))
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty, new string[] { "File name" }, new string[] { "Tên tệp" }) };
                    return;
                }
                sFileName = GlobFuncs.FixedDirSepChar(sFolder) + FileName.rtcValue + cExtFile.DCONFIG;
            }
            else
            {
                sFileName = PrefixName.rtcValue;
                if (SuffixNameMode.rtcValue == cStrings.UseDateTime)
                {
                    if (DateTimeFormat.rtcValue == cDateTimeFormats.Tick)
                        sFileName = sFileName != "" ? sFileName + DateTime.Now.Ticks.ToString() : DateTime.Now.Ticks.ToString();
                    else
                        sFileName = sFileName != "" ? sFileName + DateTime.Now.ToString(DateTimeFormat.rtcValue) : DateTime.Now.ToString(DateTimeFormat.rtcValue);
                }
                else
                {
                    sFileName = sFileName != "" ? sFileName + StartNumber.rtcValue.ToString() : StartNumber.rtcValue.ToString();
                    if (StartNumber.rtcIDRef == Guid.Empty)
                    {
                        StartNumber.rtcValue += 1;
                        if (MaxNumber.rtcValue > 0 && StartNumber.rtcValue == MaxNumber.rtcValue)
                        {
                            StartNumber.rtcValue = ResetNumber.rtcValue;
                        }
                    }
                    else
                    {
                        sFileName = sFileName != "" ? sFileName + StartNumber.rtcValue.ToString() : StartNumber.rtcValue.ToString();
                        if (StartNumber.rtcIDRef == Guid.Empty)
                        {
                            StartNumber.rtcValue += 1;
                            if (MaxNumber.rtcValue > 0 && StartNumber.rtcValue == MaxNumber.rtcValue)
                            {
                                StartNumber.rtcValue = ResetNumber.rtcValue;
                            }
                        }
                    }
                    sFileName = GlobFuncs.FixedDirSepChar(sFolder) + sFileName + cExtFile.DCONFIG;
                    if (File.Exists(sFileName) && !OverwriteWhenExists.rtcValue)
                    {
                        ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsExists, new string[] { sFileName }, new string[] { sFileName }) };
                        Passed.rtcValue = false;
                        return;
                    }
                }
                string sIconicFileName = Path.ChangeExtension(sFileName, cExtFile.CONFIGDICT);

                if (!GlobFuncs.CreateFolder(sFolder))
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists, new string[] { "Save Folder" }, new string[] { "Thư mục lưu" }) };
                    return;
                }
                cSaveOpenFiles saveOpenFiles = new cSaveOpenFiles();
                if(saveOpenFiles.SaveConfig(MyGroup,sFileName,sIconicFileName, out string errMessage) == EFunctionReturn.Error)
                {
                    ErrMessage.rtcValue = new List<string>() { errMessage};
                    Passed.rtcValue = false;
                }
                else
                {
                    Passed.rtcValue = true;
                    OutputFileName.rtcValue = sFileName;
                }
            }
        }
    }
}
