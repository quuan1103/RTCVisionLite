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
    public partial class ucCounterActionDetail : ucBaseActionDetail
    {
        public ucCounterActionDetail()
        {
            InitializeComponent();
        }

        private void btnRunCount_Click(object sender, EventArgs e)
        {
            if (Action != null)
                this.RunAction();
        }

        private void btnResetCount_Click(object sender, EventArgs e)
        {
            if (Action != null)
                Action.Run_ResetActionCount();
        }
    }
}
