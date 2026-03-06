using RTCUpdate.Classes;
using RTCUpdate.Forms;

namespace RTCUpdate
{
    public class cUpdate
    {
        public bool CheckUpdate(out string newVersion)
        {
            return cUpdateFunctions.CheckUpdate(out newVersion);
        }
        public void AutoUpdate(bool autoOpenWhenUpdateFinished = true, bool isSilent = false)
        {
            switch (GlobVar.Config.UpdateOptions.UpdateSource)
            {
                case EUpdateSource.FTP:
                    FrmMain frmMain = new FrmMain();
                    //frmMain.FtpAutoUpdate(autoOpenWhenUpdateFinished, isSilent);
                    break;
                case EUpdateSource.HTTP:
                    break;
            }
        }
    }
}
