using RTC_Vision_Lite.Classes;
using System;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {
            this.Icon = GlobVar.RTCIcon;
        }
    }
}
