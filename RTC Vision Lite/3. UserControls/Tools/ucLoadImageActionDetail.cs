using Microsoft.WindowsAPICodePack.Dialogs;
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
    public partial class ucLoadImageActionDetail : ucBaseActionDetail
    {
        public ucLoadImageActionDetail()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Action != null)
                Action.Run_LoadImage_Test();
            // quan test
        }

        private void btnGetFileName_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = GlobVar.RTCVision.Paths.OldPathChooseFolder;
            dialog.Title = cStrings.ChooseImageFile;
            dialog.Filters.Add(new CommonFileDialogFilter("Image File", cStrings.ImageFilter));
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                RTCFileName.Text = dialog.FileName;
                RTCFileName.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

       
    }
}
