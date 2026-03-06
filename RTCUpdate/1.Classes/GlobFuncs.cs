using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCUpdate.Classes
{
    internal static class GlobFuncs
    {
        internal static bool FileIsUsed(string filename)
        {
            bool Locked = false;
            try
            {
                FileStream fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch(IOException)
            {
                Locked = true;
            }
            return Locked;
        }
        public static void ReadAppInfo()
        {
            GlobVar.Config = new cSystemTypes();
            GlobVar.Config.ReadIniConfig();
        }

        public static int FileNameToInt(string fileName, int defaultValue = 0)
        {
            try
            {
                fileName = fileName.Trim();
                if (string.IsNullOrEmpty(fileName))
                    return defaultValue;
                fileName = fileName.Replace(GlobVar.Config.UpdateOptions.AppName + "_", "").Replace(".", "");
                if (fileName.Length == 4) // Với các phiên abnr cũ khi đánh
                    return -1;
                if (int.TryParse(fileName, out int iValue))
                    return iValue;
                else
                    return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string FileNameToVersion(string fileName)
        {
            try
            {
                fileName = fileName.Trim();
                if (string.IsNullOrEmpty(fileName))
                    return string.Empty;
                fileName = Path.GetFileNameWithoutExtension(fileName).Replace(GlobVar.Config.UpdateOptions.AppName + "_", "");
                return fileName;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
