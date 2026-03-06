using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the save image reset operation. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SaveImage_Reset()
        {
            StartNumber.rtcValue = ResetNumber.rtcValue;
            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the save image test operation. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="group">    The group. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SaveImage_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MyGroup.GetValueToVariableIsRef(this);
            if (SaveMode.rtcValue == ETriggerType.Sync.ToString())
                Run_SaveImage();
            else
                Run_SaveImage_Async();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the save image operation. </summary>
        ///
        /// <remarks>   DATRUONG, 11/11/2021. </remarks>
        ///
        /// <param name="group">    The group. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Run_SaveImage_Async()
        {

            if (GlobFuncs.Ve2Str(ErrMessage.rtcValue) != "")
            {
                Passed.rtcValue = false;
                return;
            }

            Task.Factory.StartNew(() =>
            {
                try
                {
                    Run_SaveImage();
                    Passed.rtcValue = true;
                }
                catch (Exception ex)
                {
                    ErrMessage.rtcValue = new List<string> { ex.Message };
                    GlobFuncs.SaveErr(ex);
                }
            });
        }

        public void Run_SaveImage()
        {
            if (((InputImage == null || InputImage.rtcValue == null)))
            {
                ErrMessage.rtcValue = new List<string> { "Input Image Is Not Exists" };
                Passed.rtcValue = false;
                return;
            }

            if ((InputImage == null || InputImage.rtcValue == null) && !IsSaveMyWindow.rtcValue)
                return;

            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            OutputFileName.rtcValue = string.Empty;

            string sFolder;
            string sFileName = FileName.rtcValue.Trim();
            string sFileNameW = FileName.rtcValue.Trim();
            if (IsUseProjectFolder.rtcValue)
            {
                if (MyGroup != null)
                    sFolder = MyGroup.SourceImageSettings.CameraSettings.SaveImageFolder_Origin;
                else
                    sFolder = GlobVar.RTCVision.Paths.AppPath;
            }
            else
                sFolder = FolderName.rtcValue;

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
                            sFolder = Path.Combine(sFolder, DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(),
                                DateTime.Now.Day.ToString(), DateTime.Now.Hour.ToString());
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
                    ErrMessage.rtcValue = new List<string> {cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                        new string[] { "File name" }, new string[] { "Tên ảnh" }) };
                    return;
                }
                sFileName = GlobFuncs.FixedDirSepChar(sFolder) + FileName.rtcValue + "." + ImageTypes.rtcValue.ToLower();
            }
            else
            {
                sFileName = PrefixName.rtcValue;

                if (SuffixNameMode.rtcValue == cSuffixNameMode.UseDateTime)
                {
                    if (DateTimeFormat.rtcValue == cDateTimeFormats.Tick)
                        sFileName = sFileName != "" ? sFileName + "_" + DateTime.Now.Ticks.ToString() : DateTime.Now.Ticks.ToString();
                    else
                        sFileName = sFileName != "" ? sFileName + "_" + DateTime.Now.ToString(DateTimeFormat.rtcValue) : DateTime.Now.ToString(DateTimeFormat.rtcValue);
                }
                else if (SuffixNameMode.rtcValue == cSuffixNameMode.UseNumberOrder)
                {
                    sFileName = sFileName != "" ? sFileName + "_" + StartNumber.rtcValue.ToString() : StartNumber.rtcValue.ToString();
                    if (StartNumber.rtcIDRef == Guid.Empty)
                    {
                        StartNumber.rtcValue += 1;
                        if (MaxNumber.rtcValue > 0 && StartNumber.rtcValue == MaxNumber.rtcValue)
                            StartNumber.rtcValue = ResetNumber.rtcValue;
                    }
                }

                sFileNameW = sFileName + "W";
                sFileName = GlobFuncs.FixedDirSepChar(sFolder) + sFileName + "." + ImageTypes.rtcValue.ToLower();
                sFileNameW = GlobFuncs.FixedDirSepChar(sFolder) + sFileNameW + "." + ImageTypes.rtcValue.ToLower();

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

            try
            {
                if (IsSaveMyWindow.rtcValue)
                {
                        OutputFileName.rtcValue = sFileNameW;
                }

                if (InputImage.rtcValue != null)
                {
                    ImageFormat format = GlobFuncs.GetImageFormat(ImageTypes.rtcValue);
                    InputImage.rtcValue.Save(sFileName, format);
                    InputImage.rtcValue.Save(sFileName, format);
                    OutputFileName.rtcValue = sFileName;
                }
                Passed.rtcValue = true;
            }
          
            catch (Exception Ex)
            {
                ErrMessage.rtcValue = new List<string>() { Ex.Message };
            }
        }
    }
}

