using RTC_Vision_Lite.Classes;
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
    public partial class ucRunProgramActionDetail : ucBaseActionDetail
    {
        public ucRunProgramActionDetail()
        {
            InitializeComponent();
        }
           
            
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Action != null)
                Action.Run_Program_Test();
        }

        private void btnStopTest_Click(object sender, EventArgs e)
        {
            if (Action != null)
                Action.Run_Program_Stop();
        }
    }
}
