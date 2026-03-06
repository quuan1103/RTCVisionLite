using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite._3._UserControls.Commons
{
    public partial class ucColorCombobox : UserControl
    {
        public ucColorCombobox()
        {
            InitializeComponent();
        }
       

        /// <summary>
        public event ColorComboboxValueChanged OnColorComboboxValueChanged;
        /// </summary>

        #region PROPERTIES
        private string _RTCPropertyName = string.Empty;

        public string RTCPropertyName
        {
            get { return _RTCPropertyName; }
            set
            {
                _RTCPropertyName = value;
                PreviewData();
            }
        }

        private cAction _RTCAction;

        public cAction RTCAction
        {
            get { return _RTCAction; }
            set
            {
                _RTCAction = value;
                PreviewData();
            }
        }

        private bool _RTCColorInbound = false;

        public bool RTCColorInbound
        {
            get { return _RTCColorInbound; }
            set
            {
                _RTCColorInbound = value;
                if (_RTCColorInbound)
                {
                    tableLayoutPanel.ColumnStyles[0].Width = 0;
                    cbColor.BackColor = Color.FromName(cbColor.Text);
                    if (cbColor.Text == EColor.Black.ToString() ||
                        cbColor.Text == EColor.Maroon.ToString() ||
                        cbColor.Text == EColor.Blue.ToString() ||
                        cbColor.Text == EColor.Gray.ToString() ||
                        cbColor.Text == EColor.Green.ToString() ||
                        cbColor.Text == EColor.Navy.ToString())
                    {
                        cbColor.ForeColor = Color.White;
                        
                    }
                    else
                        cbColor.ForeColor = Color.Black;
                }
                else
                {
                    pictureColor.Image = imageListColor.Images[imageListColor.Images.IndexOfKey(_RTCColor.ToString())];
                    cbColor.BackColor = Color.White;
                    cbColor.ForeColor = Color.Black;
                    tableLayoutPanel.ColumnStyles[0].Width = 30;
                }
            }
        }

        private EColor _RTCColor;
        [Browsable(true), DefaultValue(EColor.Black), Description("Color values")]
        [ListBindable(true), Editor(typeof(System.Windows.Forms.ComboBox), typeof(System.Windows.Forms.ComboBox))]
        public EColor RTCColor
        {
            get
            {
                _RTCColor = (EColor)imageListColor.Images.IndexOfKey(cbColor.Text);
                return _RTCColor;
            }
            set
            {
                try
                {
                    _RTCColor = value;
                    bool isChange = cbColor.Text != null && cbColor.Text.ToString() != _RTCColor.ToString();
                    cbColor.Text = _RTCColor.ToString();
                    if (_RTCColorInbound)
                    {
                        cbColor.BackColor = Color.FromName(cbColor.Text);
                        if (cbColor.Text == EColor.Black.ToString() ||
                            cbColor.Text == EColor.Maroon.ToString() ||
                            cbColor.Text == EColor.Blue.ToString() ||
                            cbColor.Text == EColor.Gray.ToString() ||
                            cbColor.Text == EColor.Green.ToString() ||
                            cbColor.Text == EColor.Navy.ToString())
                            cbColor.ForeColor = Color.White;
                        else
                            cbColor.ForeColor = Color.Black;
                    }
                    else
                        pictureColor.Image = imageListColor.Images[imageListColor.Images.IndexOfKey(_RTCColor.ToString())];
                    if (isChange && OnColorComboboxValueChanged != null)
                        OnColorComboboxValueChanged(RTCPropertyName, _RTCColor.ToString());
                }
                catch (Exception e)
                {
                    GlobFuncs.SaveErr(e);
                }
            }
        }

        private string _RTCHalconColor;
        [Browsable(true), DefaultValue("black"), Description("Color values by Halcon")]
        public string RTCHalconColor
        {
            get
            {
                if (cbColor.Text.ToLower() == Enum.GetName(typeof(EColor), EColor.Teal))
                    return "dark olive green";
                else
                    return cbColor.Text.ToLower();
            }
            set
            {
                if (value == null)
                    return;

                _RTCHalconColor = value.ToLower();
                if (Enum.IsDefined(typeof(EColor), GlobFuncs.FirstCharToUpper(value.ToLower())))
                {
                    _RTCHalconColor = value.ToLower();
                    RTCColor = (EColor)imageListColor.Images.IndexOfKey(GlobFuncs.FirstCharToUpper(value.ToLower()));
                }
            }
        }

        #endregion

        private void PreviewData()
        {
            if (RTCAction != null && !string.IsNullOrEmpty(_RTCPropertyName))
            {
                SString rtcvar = (SString)RTCAction.GetType().GetProperty(_RTCPropertyName)?.GetValue(RTCAction, null);
                if (rtcvar != null)
                {
                    cbColor.Text = rtcvar.rtcValue;
                    RTCHalconColor = rtcvar.rtcValue;
                }
            }
        }

        private void ucColorCombobox_Load(object sender, EventArgs e)
        {
            mnuBlack.Image = imageListColor.Images[(int)EColor.Black];
            mnuBlue.Image = imageListColor.Images[(int)EColor.Blue];
            mnuCyan.Image = imageListColor.Images[(int)EColor.Cyan];
            mnuGray.Image = imageListColor.Images[(int)EColor.Gray];
            mnuGreen.Image = imageListColor.Images[(int)EColor.Green];
            mnuMaroon.Image = imageListColor.Images[(int)EColor.Maroon];
            mnuNavy.Image = imageListColor.Images[(int)EColor.Navy];
            mnuPink.Image = imageListColor.Images[(int)EColor.Pink];
            mnuRed.Image = imageListColor.Images[(int)EColor.Red];
            mnuTail.Image = imageListColor.Images[(int)EColor.Teal];
            mnuViolet.Image = imageListColor.Images[(int)EColor.Violet];
            mnuWhite.Image = imageListColor.Images[(int)EColor.White];
            mnuYellow.Image = imageListColor.Images[(int)EColor.Yellow];
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null)
              return;
            RTCColor = (EColor)imageListColor.Images.IndexOfKey(e.ClickedItem.Text);
        }

        private void cbColor_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(cbColor, cbColor.Location);
        }
        //private void tlSetup_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        //{
        //    

        //    //cbColor.Text = e.Node.GetValue(colColor).ToString();
        //}


    }
}
