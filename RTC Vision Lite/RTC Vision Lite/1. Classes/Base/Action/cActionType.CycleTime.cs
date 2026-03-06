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
        internal Stopwatch cycleTimeStopwatch = null;
        public void Run_CycleTimeStart()
        {
            Passed.rtcValue = true;
            cycleTimeStopwatch = new Stopwatch();
            cycleTimeStopwatch.Start();
            if (GlobVar.CycleTime != null)
                GlobVar.CycleTime.Reset();
        }
        public void Run_CycleTimeStop(Guid cycleTimeStartId)
        {
            cAction cycleTimeStart = MyGroup.Actions.Values.FirstOrDefault(x => x.ID.Equals(cycleTimeStartId));
            Passed.rtcValue = true;
            ElapsedTime.rtcValue = 0;
            if (cycleTimeStart != null && cycleTimeStart.cycleTimeStopwatch != null)
            {
                cycleTimeStart.cycleTimeStopwatch.Stop();
                ElapsedTime.rtcValue = cycleTimeStart.cycleTimeStopwatch.ElapsedMilliseconds - cycleTimeStart.CycleTime.rtcValue;
                cycleTimeStart.cycleTimeStopwatch = null;
            }
            if (IsSaveDetailCycleTimeToFile.rtcValue)
            {
                StringBuilder builder = new StringBuilder();
                int startOrder = MyGroup.MainAction.STT;
                if (cycleTimeStart != null)
                    startOrder = cycleTimeStart.STT;
                var nameLengthMax = MyGroup.Actions.Values.Where(x => x.STT > startOrder && x.STT < this.STT).Max(x => x.Name.rtcValue.Length);
                string format = "{0," + $"-{nameLengthMax}" + "}\t\t{1}\t\t{2, -25}\t\t{3}";
                long totalTime = 0;
                string folderName = Path.Combine(MyGroup.SaveFileFolder, DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);
                string fileName = string.Empty;
                if (IsSaveDetailToOneFile.rtcValue)
                {
                    fileName = $"{this.Name.rtcValue}.txt";
                    fileName = Path.Combine(folderName, fileName);
                    if (!File.Exists(fileName))
                        builder.AppendFormat(format, "Tool Name", "CT", "Start Time", "OK/NG\n");
                    if (!string.IsNullOrEmpty(SegmentText.rtcValue.Trim()))
                    {
                        builder.AppendLine();
                        builder.AppendFormat(format, SegmentText.rtcValue.Trim(), "", "", "\n");
                    }
                }
                else
                {
                    fileName = this.Name.rtcValue;
                    fileName = !string.IsNullOrEmpty(SegmentText.rtcValue.Trim()) ? $"{fileName}_{SegmentText.rtcValue.Trim()}.txt" : $"{fileName}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";
                    fileName = Path.Combine(folderName, fileName);
                    if (!File.Exists(fileName))
                        builder.AppendFormat(format, "Tool Name", "CT", "Start Time", "OK/NG\n");
                }
                for (int i = startOrder + 1; i < this.STT; i++)
                {
                    var action = MyGroup.Actions.Values.FirstOrDefault(x => x.STT == i);
                    if(action != null)
                    {
                        totalTime += action.CycleTime.rtcValue;
                        builder.AppendFormat(format, $"{action.Name.rtcValue}:", $"{action.CycleTime.rtcValue} ms", $"{StartTime.rtcValue}", $"{(action.Passed.rtcValue ? "OK" : "NG")}\n");
                    }
                }
                File.AppendAllText(fileName, builder.ToString());
            }
            if (GlobVar.CycleTime != null)
                GlobVar.CycleTime.SetTime(ElapsedTime.rtcValue);
        }
    }
}
