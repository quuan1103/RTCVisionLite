using RTC_Vision_Lite.Classes;
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
    public partial class ucLoadConfigActionDetail : ucBaseActionDetail
    {
        public ucLoadConfigActionDetail()
        {
            InitializeComponent();
        }

        private void btnGetFileName_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = cStrings.ChooseConfigFile;
            openFileDialog.Filter = cStrings.ConfigFilter;
            openFileDialog.InitialDirectory = GlobVar.RTCVision.Paths.OldPathChooseFolder;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RTCFileName.Text = openFileDialog.FileName;
                RTCFileName.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Action != null)
            {
                Action.Run_LoadConfig_Test();
            }
        }
    }
}
