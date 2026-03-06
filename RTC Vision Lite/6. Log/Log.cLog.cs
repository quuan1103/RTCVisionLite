using RTCConst;
using RTCEnums;
using RTC_Vision_Lite.PublicFunctions;
using System;
using System.Data;
using System.IO;
using NLog;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;
using System.Linq;
using System.Reflection;

namespace RTC_Vision_Lite.Log
{
    internal class cLog
    {
        /// <summary>
        /// Hiển thị hộp thoại log
        /// </summary>
        internal void ShowLog()
        {
            if (GlobVar.FormLogs == null || GlobVar.FormLogs.IsDisposed)
                GlobVar.FormLogs = new FrmLog();
            if (GlobVar.FormLogs.Visible)
                GlobVar.FormLogs.Activate();
            else
                GlobVar.FormLogs.Show();
        }

        private string GetActionLogMessage_ActionInfo(cAction action)
        {
            string message = "\n» Window Name:\t" + action.MyGroup.MyCam.Name;
            message = message + "\n» Action Name:\t" + action.Name.rtcValue + $"\t\t{(action.Passed.rtcValue ? "OK" : "NG")}";

            return message;
        }
        private string GetActionLogMessage_Properties(cAction action)
        {
            string message = string.Empty;
            var orderedProperty = action.GetType().GetProperties().Where(x =>
                ((RTCVariableType)x.GetValue(action, null)) != null
                && ((RTCVariableType)x.GetValue(action, null)).rtcDisplayValueInHistory).ToList();
            if (orderedProperty.Count <= 0)
                return message;
            foreach (PropertyInfo propertyInfo in orderedProperty)
            {
                message = string.IsNullOrEmpty(message) ? "" : message + "\n";
                message = message + "  - " + propertyInfo.Name + "=" +
                          ((RTCVariableType)propertyInfo.GetValue(action, null)).rtcValueView;
            }

            return message;
        }
        /// <summary>
        /// Lưu log cho tool
        /// </summary>
        /// <param name="action">Tool cần lưu trữ log</param>
        internal void WriteLog(cAction action)
        {
            try
            {
                if (action == null || GlobVar.FormLogs == null || !GlobVar.RTCVision.LogOptions.IsSaveLog)
                    return;

                string actionInfo = GetActionLogMessage_ActionInfo(action);
                string message = GetActionLogMessage_Properties(action);

                if (string.IsNullOrEmpty(message))
                    return;

                if (GlobVar.FormLogs != null && GlobVar.FormLogs.Visible)
                    //GlobVar.FormLogs.WriteLog(action, actionInfo + "\n" + message);

                if (!GlobVar.RTCVision.LogOptions.IsSaveLog)
                    return;

                // Lưu trữ log này vào dữ liệu
                if (GlobVar.RTCVision.LogOptions.IsSaveLogToDataFile && File.Exists(GlobVar.RTCVision.Files.LogData))
                    Lib.ExecuteQuery($"INSERT INTO Data(DateTime,Date,Time,ModelName,CamID,CamName,ActionID,ActionType,ActionName,Message) VALUES (" +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.yyyyMMddHHmmss)}'," +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.yyyyMMdd)}'," +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.HHmmss)}'," +
                                     $"'{(GlobVar.CurrentProject != null ? GlobVar.CurrentProject.ProjectName : string.Empty)}'," +
                                     $"'{action.MyGroup.MyCam.ID.ToString()}'," +
                                     $"'{action.MyGroup.MyCam.Name}'," +
                                     $"'{action.ID.ToString()}'," +
                                     $"'{Enum.GetName(typeof(EActionTypes), action.ActionType)}'," +
                                     $"'{action.Name.rtcValue}'," +
                                     $"'{actionInfo + "\n" + message}')", GlobVar.RTCVision.Files.LogData);

                if (GlobVar.RTCVision.LogOptions.IsSaveLogToTextFile)
                {
                    ILogger mLogger = LogManager.GetLogger("LogFile");
                    mLogger.Error(actionInfo + "\n" + message);
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        internal void WriteLog(string message)
        {
            try
            {
                if (GlobVar.RTCVision.LogOptions.IsSaveLog)
                    return;
                if (string.IsNullOrEmpty(message))
                    return;

                // Lưu trữ log này vào dữ liệu
                if (GlobVar.RTCVision.LogOptions.IsSaveLogToDataFile && File.Exists(GlobVar.RTCVision.Files.LogData))
                    Lib.ExecuteQuery($"INSERT INTO Data(DateTime,Date,Time,ModelName,CamID,CamName,ActionID,ActionType,ActionName,Message,StackTrace) VALUES (" +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.yyyyMMddHHmmss)}'," +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.yyyyMMdd)}'," +
                                     $"'{DateTime.Now.ToString(cDateTimeFormats.HHmmss)}'," +
                                     $"'{(GlobVar.CurrentProject != null ? GlobVar.CurrentProject.ProjectName : string.Empty)}'," +
                                     $"''," +
                                     $"''," +
                                     $"''," +
                                     $"''," +
                                     $"''," +
                                     $"'{message}')", GlobVar.RTCVision.Files.LogData);

                if (GlobVar.RTCVision.LogOptions.IsSaveLogToTextFile)
                {
                    ILogger mLogger = LogManager.GetLogger("LogFile");
                    mLogger.Error(message);
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
            }
        }
        //internal DataTable GetLogReport(string model, DateTime startTime, DateTime stopTime)
        //{
        //    return MyConn.GetDataTable("SELECT * FROM " + cTableName_Report.Data + " WHERE (DateValue BETWEEN '" +
        //                            startTime.ToString(GlobVar.RTCVision.LogOptions.DateFormat) + "' AND '" +
        //                            stopTime.ToString(GlobVar.RTCVision.LogOptions.DateFormat) + "')" +
        //                            (model == cStrings.All ? "" : " AND (Model='" + model + "') ORDER BY Model,Window,DateValue,TimeValue"));
        //}
    }
}
