using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class frmWait : Form
    {
        public string Caption = string.Empty;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                const int CS_NOCLOSE = 0x200;
                myCp.ClassStyle |= CS_NOCLOSE;  // Add the CS_NOCLOSE class style to hide the close button
                return myCp;
            }
        }
        public frmWait()
        {
            InitializeComponent();

        }
    }
}
