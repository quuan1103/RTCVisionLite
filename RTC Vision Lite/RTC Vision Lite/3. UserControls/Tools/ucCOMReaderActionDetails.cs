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
    public partial class ucCOMReaderActionDetails : ucBaseActionDetail
    {
        public ucCOMReaderActionDetails()
        {
            InitializeComponent();
        }

        private void btnRess_Click(object sender, EventArgs e)
        {
            if (Action != null)
                ((ucBaseActionDetail)Action.ViewInfo).BindingDataControl_ComboBox_Normal(RTCCOMName);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
           if (Action != null && btnTest.Text != "Stop")
            {
                Action.Run_COMRead_Test();
                btnTest.Text = "Stop";
            }
           else
            {
                Action.Stop_COMRead_Test();
                btnTest.Text = "Start";
            }    
        }
    }
}
