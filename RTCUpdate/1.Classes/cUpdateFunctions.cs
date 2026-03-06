using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCUpdate.Classes
{
    internal static class cUpdateFunctions
    {
        internal static bool CheckUpdate(out string newAppVersion)
        {
            newAppVersion = string.Empty;
            try
            {
                GlobFuncs.ReadAppInfo();
                cFTP ftp = new cFTP(GlobVar.Config.UpdateOptions.HostName, GlobVar.Config.UpdateOptions.UserName,
                    GlobVar.Config.UpdateOptions.Password);
                // Connect tới địa chỉ ftp này
                ftp.Connect();
                if (!ftp.IsConnected)
                    return false;
                // Lấy danh sách các file update trên thư mục
                string[] listFiles = ftp.GetFilesList(GlobVar.Config.UpdateOptions.FolderName);
                if (listFiles == null || listFiles.Length <= 0)
                    return false;
                List<string> lst = listFiles.ToList();
                lst = lst.Where(o => o.Contains(".zip")).ToList();
                int newVersion = lst.Max(o => GlobFuncs.FileNameToInt(Path.GetFileNameWithoutExtension(o)));
                int indexMax
                    = !lst.Any() ? -1 :
                        lst
                            .Select((value, index) => new { Value = value, Index = index })
                            .Aggregate((a, b) =>
                                (GlobFuncs.FileNameToInt(Path.GetFileNameWithoutExtension(a.Value)) >
                                 GlobFuncs.FileNameToInt(Path.GetFileNameWithoutExtension(b.Value)))
                                    ? a
                                    : b)
                            .Index;

                int currentVersion = GlobFuncs.FileNameToInt(GlobVar.Config.UpdateOptions.CurrentVersion);
                if (newVersion <= currentVersion)
                    return false;
                newAppVersion = GlobFuncs.FileNameToVersion(listFiles[indexMax]);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
