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
        public void Run_SendAlarmMessage_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_SendAlarmMessage();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
        }
        public void Run_SendAlarmMessage(bool isTest = false)
        {
            IsFinishRunOneTime.rtcValue = false;
            Passed.rtcValue = false;
            ErrMessage.rtcValue = new List<string>() { string.Empty };
            if (GlobVar.CurrentProject == null)
            {
                ErrMessage.rtcValue = new List<string>(){ cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "Model" }, new string[] { "Model" }) };
                return;
            }
            if (Destination.rtcValue == cDestinationAlarm.AlarmControl && !GlobVar.CurrentProject.IsUseAlarm)
            {
                ErrMessage.rtcValue = new List<string>(){ cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "Alarm Module" }, new string[] { "Mô đun cảnh báo" }) };
                return;
            }
            else if (Destination.rtcValue == cDestinationAlarm.PLCStatus && !GlobVar.CurrentProject.IsUsePLCStatus)
            {
                ErrMessage.rtcValue = new List<string>(){ cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "PLC status module" }, new string[] { "Mô đun trạng thái plc" }) };
                return;
            }
            else if (Destination.rtcValue == cDestinationAlarm.RobotStatus && !GlobVar.CurrentProject.IsUseRobotStatus)
            {
                ErrMessage.rtcValue = new List<string>(){ cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "Robot status module" }, new string[] { "Mô đun trạng thái robot" }) };
                return;
            }
            else if (Destination.rtcValue == cDestinationAlarm.CheckStatus && !GlobVar.CurrentProject.IsUseCheckStatus)
            {
                ErrMessage.rtcValue = new List<string>(){ cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists,
                    new string[] { "Check Vision status module" }, new string[] { "Mô đun kiểm tra vision" }) };
                return;
            }
            if (Destination.rtcValue == cDestinationAlarm.AlarmControl && (Message.rtcValue == null || Message.rtcValue.Length > 0))
            {
                ErrMessage.rtcValue = new List<string>(){ cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                    new string[] { "Alarm message" }, new string[] { "Thông điệp cảnh báo" }) };
                return;
            }
            if (Destination.rtcValue == cDestinationAlarm.TrayResult && (Message.rtcValue == null || Message.rtcValue.Length > 0))
            {
                ErrMessage.rtcValue = new List<string>(){ cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                    new string[] { "Tray message" }, new string[] { "Thông điệp tray kết quả" }) };
                return;
            }

            switch (Destination.rtcValue)
            {
                case cDestinationAlarm.AlarmControl:
                    break;
                case cDestinationAlarm.PLCStatus:
                    {
                        if (GlobVar.FormMain == null)
                            return;
                        break;
                    }
                case cDestinationAlarm.CheckStatus:
                    {
                        if (GlobVar.FormMain == null)
                            return;
                        break;
                    }
                case cDestinationAlarm.RobotStatus:
                    {
                        if (GlobVar.FormMain == null)
                            return;
                        break;
                    }
                case cDestinationAlarm.SystemStatus:
                    {
                        if (GlobVar.FormMain == null)
                            return;
                        cProjectFunctions.RebuildContent(StatusTypeConnect.rtcValue);
                        break;
                    }
                case cDestinationAlarm.ModelInfor:
                    {
                        if (GlobVar.FormMain == null)
                            return;
                        switch (ModelInfor.rtcValue)
                        {
                            case cModelInfors.ModelName:
                                break;
                            case cModelInfors.Serial:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case cDestinationAlarm.TrayResult:
                    {
                        cProjectFunctions.RebuildContent(Message.rtcValue);
                        break;
                    }
            }
            Passed.rtcValue = true;
            if (IsRunOneTime.rtcValue && !isTest)
                IsFinishRunOneTime.rtcValue = Passed.rtcValue;
        }

    }
}
