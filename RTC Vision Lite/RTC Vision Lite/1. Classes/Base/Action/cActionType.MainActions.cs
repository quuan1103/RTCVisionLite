using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void UpdatePropertyToNodeValue(string propertyName)
        {
            if (this.MyNode == null || this.MyNode.child == null || this.MyNode.child.Count <= 0)
                return;
            RTCVariableType rtcvar = (RTCVariableType)this.GetType().GetProperty(propertyName).GetValue(this, null);
            if (rtcvar == null)
                return;
            if (this.MyNode != null)
            {
                if(GlobVar.tl.InvokeRequired)
                {
                    GlobVar.tl.Invoke((MethodInvoker)delegate
                        {
                            ActionTools result = this.MyNode.child.FirstOrDefault(x => x.Name == propertyName);
                            result.Description = "[" + propertyName + "] " + (rtcvar.rtcIDRef != Guid.Empty ? rtcvar.rtcValueViewFull + " " + rtcvar.rtcRef : rtcvar.rtcValueViewFull);
                            GlobVar.tl.RefreshObject(this.MyNode);
                        });
                } 
                else
                {
                    ActionTools result = this.MyNode.child.FirstOrDefault(x => x.Name == propertyName);
                    result.Description = "[" + propertyName + "] " + (rtcvar.rtcIDRef != Guid.Empty ? rtcvar.rtcValueViewFull + " " + rtcvar.rtcRef : rtcvar.rtcValueViewFull);
                    GlobVar.tl.RefreshObject(this.MyNode);
                }    
             
            }    
        }    
    }
}
