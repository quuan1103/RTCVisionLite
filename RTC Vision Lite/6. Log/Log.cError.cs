using RTCConst;
using RTCEnums;
using RTC_Vision_Lite.PublicFunctions;
using System;
using System.Data;
using System.IO;
using System.Linq;
using NLog;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;

namespace RTC_Vision_Lite.Log
{
    internal class cError
    {
        internal void SaveError(Exception ex, cAction action = null)
        {
            if (!GlobVar.RTCVision.ErrorOptions.IsSaveError)
                return;

            if (GlobVar.RTCVision.ErrorOptions.IsSaveErrorToDataFile)
                if (File.Exists(GlobVar.RTCVision.Files.ErrorData))
                {
                    Lib.ExecuteQuery($"INSERT INTO Data(DateTime,Date,Time,ModelName,CamID,CamName,ActionID,ActionType,ActionName,Message,StackTrace) VALUES (" +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.yyyyMMddHHmmss)}'," +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.yyyyMMdd)}'," +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.HHmmss)}'," +
                                     $"'{(GlobVar.CurrentProject != null ? GlobVar.CurrentProject.ProjectName : string.Empty)}'," +
                                     $"'{(action != null ? action.MyGroup.MyCam.ID.ToString() : string.Empty)}'," +
                                     $"'{(action != null ? action.MyGroup.MyCam.Name : string.Empty)}'," +
                                     $"'{(action != null ? action.ID.ToString() : string.Empty)}'," +
                                     $"'{(action != null ? Enum.GetName(typeof(EActionTypes),action.ActionType) : string.Empty)}'," +
                                     $"'{(action != null ? action.Name.rtcValue : string.Empty)}'," +
                                     $"'{ex.Message.Replace("'", "")}'," +
                                     $"'{ex.StackTrace.Replace("'", "")}')", GlobVar.RTCVision.Files.ErrorData);
                }

            if (GlobVar.RTCVision.ErrorOptions.IsSaveErrorToTextFile)
            {
                string message = string.Empty;
                if (action != null)
                {
                    message = "\n» Window Name:\t" + action.MyGroup.MyCam.Name + $"\t\t[{action.MyGroup.MyCam.ID}]";
                    message = message + "\n» Action Name:\t" + action.Name.rtcValue + $"\t\t[{action.ID}]";
                }
                if (ex != null)
                {
                    message = (!string.IsNullOrEmpty(message) ? message : string.Empty) + "\n» Message:\t" + ex.Message;
                    message = message + "\n» Stack Trace:\t" + ex.StackTrace;
                }

                ILogger mLogger = LogManager.GetLogger("ErrorFile");
                mLogger.Error(message);
            }
        }
    }
}
