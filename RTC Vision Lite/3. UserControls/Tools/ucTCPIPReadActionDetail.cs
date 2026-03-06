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
    public partial class ucTCPIPReadActionDetail : ucBaseActionDetail
    {
        public ucTCPIPReadActionDetail()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Action != null)
            {
                if (btnTest.Text == cStrings.Read)
                {
                    Action.Run_TCPIPRead_Test();
                    if (Action.Passed.rtcValue)
                        btnTest.Text = cStrings.Stop;
                }
                else
                {
                    Action.Stop_TCPIPRead_Test();
                    btnTest.Text = cStrings.Read;
                }
            }
        }
    }
}
