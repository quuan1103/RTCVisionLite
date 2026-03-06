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
    public partial class ucSendAlarmMessageActionDetail : ucBaseActionDetail
    {
        public ucSendAlarmMessageActionDetail()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Action != null)
                Action.Run_SendAlarmMessage_Test();
        }
    }
}
