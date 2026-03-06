using RTCLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    internal class cLicense
    {
        internal string LicFileName { get; set; }
        internal cLicense()
        {
            LicFileName = GlobVar.RTCVision.Files.LicenseFile;
        }
        internal bool IsActivated()
        {
            //bool isActivated = false;
            //string version = string.Empty;
            //if (!string.IsNullOrEmpty(GlobVar.RTCVision.Files.LicenseFile))
            //{
            //    isActivated = RTCLicense.License.cLicense.CheckLicense(GlobVar.RTCVision.Files.LicenseFile,
            //        Application.ProductName, out version, out bool isUnlimited, out string errMessage) == 1;
            //    if (isActivated)
            //        LicFileName = GlobVar.RTCVision.Files.LicenseFile;
            //}
            //if (!isActivated && !string.IsNullOrEmpty(GlobVar.RTCVision.Files.LicenseFileDefault))
            //{
            //    isActivated = RTCLicense.License.cLicense.CheckLicense(GlobVar.RTCVision.Files.LicenseFileDefault,
            //        Application.ProductName, out version, out bool isUnlimited, out string errMessage) == 1;
            //    if (isActivated)
            //        LicFileName = GlobVar.RTCVision.Files.LicenseFileDefault;
            //}
            //if (!isActivated && !string.IsNullOrEmpty(GlobVar.RTCVision.Files.LicenseFileByMonth))
            //{
            //    isActivated = RTCLicense.License.cLicense.CheckLicense(GlobVar.RTCVision.Files.LicenseFileByMonth,
            //        Application.ProductName, out version, out bool isUnlimited, out string errMessage) == 1;
            //    if (isActivated)
            //        LicFileName = GlobVar.RTCVision.Files.LicenseFileByMonth;
            //}
            //isActivated = isActivated && version == cEncryptDecrypt.Decrypt("m/HpT5XUBlk=");
            //if (!isActivated)
            //    LicFileName = string.Empty;
            //return isActivated;
            return true;
        }
        internal bool ShowFormLicense()
        {
            //if (!RTCLicense.License.cLicense.ShowFormLicense(LicFileName, Application.ProductName, out string newLicFileName))
            //{
            //    LicFileName = string.Empty;
            //    return false;
            //}
            //else
            //{
            //    LicFileName = newLicFileName;
            //    GlobVar.RTCVision.Files.LicenseFile = newLicFileName;
            //    GlobVar.RTCVision.SaveIniConfig();
            return true;
            //}
        }
    }
}
