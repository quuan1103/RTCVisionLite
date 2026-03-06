using RTC_Vision_Lite.UserControls;
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
    public partial class ucDataSetActionDetail : ucBaseActionDetail
    {
        public ucDataSetActionDetail()
        {
            InitializeComponent();
        }
        public void LoadLinkProperty()
        {
            ucMultiLink1.LoadLinkProperty();
            ucMultiLink2.LoadLinkProperty();
            ucMultiLink3.LoadLinkProperty();
        }

        private void ScrollableROI_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
