using RTCEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cProjectTypes
    {
        internal void SetOfflineCam(cCAMTypes cam)
        {
            if (GlobVar.IsOnlineMode)
                if (cam != null && cam.IsActive && !cam.IsRun)
                {
                    cam.GroupActions.SourceImageSettings.ImageSourceType = cam.GroupActions.SourceImageSettings.OldImageSourceType;
                    if (cam.View != null)
                        cam.View.ViewImageMode();
                }    
        }
        internal void SetOnlineCam(cCAMTypes cam)
        {
            if (GlobVar.IsOnlineMode)
                if (cam != null && cam.IsActive && !cam.IsRun)
                {
                    switch (cam.GroupActions.SourceImageSettings.DefaultImageSourceType)
                    {
                        case EImageSourceTypes.Computer:
                            {
                                cam.GroupActions.SourceImageSettings.ImageSourceType = EImageSourceTypes.Computer;
                                break;
                            }
                        case EImageSourceTypes.Camera:
                            {
                                cam.GroupActions.SourceImageSettings.ImageSourceType = EImageSourceTypes.Camera;
                                break;
                            }
                        default:
                            {
                                cam.GroupActions.SourceImageSettings.ImageSourceType = EImageSourceTypes.Camera;
                                break;
                            }
                    }
                    if (cam.View != null)
                        cam.View.ViewImageMode();
                }    
        }
    }
}
