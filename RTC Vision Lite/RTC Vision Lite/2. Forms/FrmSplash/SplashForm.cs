using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RTC_Vision_Lite.Forms
{
    
    internal partial class SplashForm : Form
    {
        internal SplashForm()
        {
            InitializeComponent();
        }
        private void SplashForm_Load(object sender, EventArgs e)
        {
            AppNameLabel.Text = Name;
            AppVersionLabel.Text = (string)Tag;
        }
    }
    
}
