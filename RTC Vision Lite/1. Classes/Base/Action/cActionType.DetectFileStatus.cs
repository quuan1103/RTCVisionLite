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
        private FileSystemWatcher watcher = null;
        private bool IsSetCreatedEvent = false;
        private bool IsSetChangedEvent = false;
        private bool IsSetRenamedEvent = false;
        private bool IsSetDeletedEvent = false;

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            OldFullPath.rtcValue = String.Empty;
            OldFileName.rtcValue = String.Empty;
            FullPath.rtcValue = e.FullPath;
            FileName.rtcValue = e.Name;
            Status.rtcValue = cFileStatus.Created;
            GlobFuncs.WriteLog(this);
            if (this.ViewInfo != null && !MyGroup.RunSimple)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            OldFullPath.rtcValue = String.Empty;
            OldFileName.rtcValue = String.Empty;
            FullPath.rtcValue = e.FullPath;
            Status.rtcValue = cFileStatus.Changed;
            FileName.rtcValue = e.Name;
        }
        private void OnRenamed(object sender, FileSystemEventArgs e)
        {
            OldFullPath.rtcValue = String.Empty;
            OldFileName.rtcValue = String.Empty;
            FullPath.rtcValue = e.FullPath;
            FileName.rtcValue = e.Name;
            Status.rtcValue = cFileStatus.Renamed;
            GlobFuncs.WriteLog(this);
            if (this.ViewInfo != null && !MyGroup.RunSimple)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            OldFullPath.rtcValue = String.Empty;
            OldFileName.rtcValue = String.Empty;
            FullPath.rtcValue = e.FullPath;
            Status.rtcValue = cFileStatus.Deleted;
            FileName.rtcValue = e.Name;
        }
        public void Run_DetectFileStatus_Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Run_DetectFileStatus();
            stopwatch.Stop();
            ViewResultWhenAfterRun(stopwatch);
            GlobFuncs.WriteLog(this);
            if (this.ViewInfo != null)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
        public void Run_DetectFileStatus()
        {
            if (IsRunning.rtcValue && watcher != null)
            {
                if (!IsSetCreatedEvent && IsCreated.rtcValue)
                {
                    watcher.Created += new FileSystemEventHandler(OnCreated);
                    IsSetCreatedEvent = true;
                }
                else if (IsSetCreatedEvent && !IsCreated.rtcValue)
                {
                    watcher.Created -= new FileSystemEventHandler(OnCreated);
                    IsSetCreatedEvent = false;
                }

                if (!IsSetChangedEvent && IsChanged.rtcValue)
                {
                    watcher.Changed += new FileSystemEventHandler(OnChanged);
                    IsSetChangedEvent = true;
                }
                else if (IsSetChangedEvent && !IsChanged.rtcValue)
                {
                    watcher.Changed -= new FileSystemEventHandler(OnChanged);
                    IsSetChangedEvent = false;
                }

                if (!IsSetRenamedEvent && IsRenamed.rtcValue)
                {
                    watcher.Renamed += new RenamedEventHandler(OnRenamed);
                    IsSetRenamedEvent = true;
                }
                else if (IsSetRenamedEvent && !IsRenamed.rtcValue)
                {
                    watcher.Renamed -= new RenamedEventHandler(OnRenamed);
                    IsSetRenamedEvent = false;
                }

                if (!IsSetDeletedEvent && IsDeleted.rtcValue)
                {
                    watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                    IsSetDeletedEvent = true;
                }
                else if (IsSetDeletedEvent && !IsCreated.rtcValue)
                {
                    watcher.Deleted -= new FileSystemEventHandler(OnDeleted);
                    IsSetDeletedEvent = false;
                }
            }
            else
            {
                Passed.rtcValue = false;
                IsRunning.rtcValue = false;
                ErrMessage.rtcValue = new List<string>() { string.Empty };
                Status.rtcValue = string.Empty;
                FileName.rtcValue = string.Empty;
                FullPath.rtcValue = string.Empty;

                if (!Directory.Exists(FolderName.rtcValue))
                {
                    ErrMessage.rtcValue = new List<string>() { cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotExists, new string[] { "Folder" }, new string[] { "Thư mục" }) };
                    return;
                }
                watcher = new FileSystemWatcher();
                watcher.Path = FolderName.rtcValue;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Filter = Filter.rtcValue;
                watcher.IncludeSubdirectories = IncludeSubdirectories.rtcValue;
                if (IsCreated.rtcValue)
                {
                    watcher.Created += new FileSystemEventHandler(OnCreated);
                    IsSetCreatedEvent = true;
                }
                if (IsChanged.rtcValue)
                {
                    watcher.Changed += new FileSystemEventHandler(OnChanged);
                    IsSetChangedEvent = true;
                }
                if (IsRenamed.rtcValue)
                {
                    watcher.Renamed += new RenamedEventHandler(OnRenamed);
                    IsSetRenamedEvent = true;
                }
                if (IsDeleted.rtcValue)
                {
                    watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                    IsSetDeletedEvent = true;
                }
                watcher.EnableRaisingEvents = true;
                IsRunning.rtcValue = true;
                Passed.rtcValue = true;
            }
        }
        public void Stop_DetecFileStatus()
        {
            if (watcher == null)
                return;
            watcher.Dispose();
            watcher = null;
            IsRunning.rtcValue = false;
            IsSetCreatedEvent = false;
            IsSetDeletedEvent = false;
            IsSetChangedEvent = false;
            IsSetRenamedEvent = false;
            if (this.ViewInfo != null && !MyGroup.RunSimple)
                ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
        }
    }
}
