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
    public partial class ucCOMWriterActionDetails : ucBaseActionDetail
    {
        public ucCOMWriterActionDetails()
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
           if (Action != null)
            {
                Action.Run_COMWrite_Test();
            }    
        }
    }
}
