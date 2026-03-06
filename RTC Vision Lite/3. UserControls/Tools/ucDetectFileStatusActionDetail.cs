using RTCConst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucDetectFileStatusActionDetail : ucBaseActionDetail
    {
        public ucDetectFileStatusActionDetail()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Action == null)
                return;
            if(btnTest.Text == cStrings.Start)
            {
                Action.Run_DetectFileStatus_Test();
                if (Action.IsRunning.rtcValue)
                    btnTest.Text = cStrings.Stop;
            }
            else
            {
                Action.Stop_DetecFileStatus();
                if (!Action.IsRunning.rtcValue)
                    btnTest.Text = cStrings.Start;
            }
        }
    }
}
