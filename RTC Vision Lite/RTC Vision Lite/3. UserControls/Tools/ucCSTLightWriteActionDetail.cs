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
    public partial class ucCSTLightWriteActionDetail : ucBaseActionDetail
    {
        public ucCSTLightWriteActionDetail()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Action != null)
            {
                Action.Run_CSTLightWrite_Test();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Action.DisconnectCST();
        }
    }
}
