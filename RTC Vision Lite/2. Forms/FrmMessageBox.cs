using RTC_Vision_Lite.PublicFunctions;
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

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmMessageBox : FrmBase
    {
        public FrmMessageBox()
        {
            InitializeComponent();
        }
        public Image RTCInputImage
        {
            set
            {
                try
                {
                    if (value != null )
                    {
                        GlobFuncs.SmartSetPart(value, SmartWindow);
                        SmartWindow.Image = value;
                        SmartWindow.Visible = true;
                        tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
                        tableLayoutPanel1.RowStyles[0].Height = 100F;
                    }
                    else
                    {
                        tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;
                        tableLayoutPanel1.RowStyles[0].Height = 0;
                        SmartWindow.Visible = false;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        public string RTCDialogType
        {
            set => picMessage.Image = imageList1.Images[imageList1.Images.IndexOfKey(value)];
        }
        public string RTCCaption
        {
            set => this.Text = value;
        }
        public string RTCMessage
        {
            set => this.lblMessage.Text = value;
        }
        public string RTCMessageBoxButtons
        {
            set
            {
                if (value == cMessageBoxButtons.AbortRetryIgnore)
                {
                    btn4.Visible = false;
                    btn1.Text = cStrings.Abort1;
                    btn2.Text = cStrings.Retry1;
                    btn3.Text = cStrings.Ignore1;
                }
                else if (value == cMessageBoxButtons.OK)
                {
                    btn4.Visible = false;
                    btn3.Visible = false;
                    btn2.Visible = false;
                    btn1.Text = cStrings.OK1;
                }
                else if (value == cMessageBoxButtons.OKCancel)
                {
                    btn4.Visible = false;
                    btn3.Visible = false;
                    btn2.Text = cStrings.Cancel1;
                    btn1.Text = cStrings.OK1;
                }
                else if (value == cMessageBoxButtons.RetryCancel)
                {
                    btn4.Visible = false;
                    btn3.Visible = false;
                    btn2.Text = cStrings.Cancel1;
                    btn1.Text = cStrings.Retry;
                }
                else if (value == cMessageBoxButtons.YesNo)
                {
                    btn4.Visible = false;
                    btn3.Visible = false;
                    btn2.Text = cStrings.No1;
                    btn1.Text = cStrings.Yes1;
                }
                else if (value == cMessageBoxButtons.YesNoCancel)
                {
                    btn4.Visible = false;
                    btn3.Text = cStrings.Cancel1;
                    btn2.Text = cStrings.No1;
                    btn1.Text = cStrings.Yes1;
                }

            }
        }
        private int timeAutoClose = 3;
        public int RTCTimeAutoClose
        {
            set => timeAutoClose = value;
        }
        public bool RTCIsAutoClose { get; set; }
        private DialogResult dialogResult = DialogResult.None;
        public DialogResult RTCDialogResult => dialogResult;

        private void btn1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == cStrings.Yes1)
                dialogResult = DialogResult.Yes;
            else if (button.Text == cStrings.No1)
                dialogResult = DialogResult.No;
            else if (button.Text == cStrings.Cancel1)
                dialogResult = DialogResult.Cancel;
            else if (button.Text == cStrings.OK1)
                dialogResult = DialogResult.OK;
            else if (button.Text == cStrings.Abort1)
                dialogResult = DialogResult.Abort;
            else if (button.Text == cStrings.Retry1)
                dialogResult = DialogResult.Retry;
            else if (button.Text == cStrings.Ignore1)
                dialogResult = DialogResult.Ignore;
            else
                dialogResult = DialogResult.None;
            this.Close();
        }

        private void FrmMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            lblTimeAutoClose.Text = string.Empty;
            lblTimeAutoClose.Visible = RTCIsAutoClose;
            timerAutoClose.Enabled = RTCIsAutoClose;
        }
        private int timeClose = 0;

        private void timerAutoClose_Tick(object sender, EventArgs e)
        {
            if (lblTimeAutoClose.InvokeRequired)
                lblTimeAutoClose.Invoke((MethodInvoker)delegate
                {
                    if (timeClose == 0)
                        timeClose = timeAutoClose * 1000;
                    else
                        timeClose -= 100;
                    lblTimeAutoClose.Text = "Close After " + Math.Round((decimal)timeClose / 1000, 2).ToString() + "s";
                });
            else
            {
                if (timeClose == 0)
                    timeClose = timeAutoClose * 1000;
                else
                    timeClose -= 100;
                lblTimeAutoClose.Text = "Close After " + Math.Round((decimal)timeClose / 1000, 2).ToString() + "s";
            }
            if (timeClose <= 0)
                this.Close();
        }
    }

}
