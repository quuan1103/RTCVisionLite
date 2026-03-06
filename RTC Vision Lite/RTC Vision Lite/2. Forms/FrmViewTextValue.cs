using Newtonsoft.Json.Linq;
using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmViewTextValue : Form
    {
        private EHTupleStyle _tupleStyle = EHTupleStyle.String;
        public EHTupleStyle RtcTupleStyle
        {
            get => _tupleStyle;
            set => _tupleStyle = value;
        }
        private string _propName;
        public string RtcPropName
        {
            get => _propName;
            set
            {
                _propName = value;
                this.Text = value;
            }
        }
        private string _value;
        public string RtcValue
        {
            get => meValue.Text;
            set
            {
                _value = value;
                ViewText();
            }
        }

        public bool RtcEnable
        {
            get => meValue.Enabled;
            set
            {
                meValue.Enabled = value;
                btnCopyToClipboard.Visible = value;
            }
        }
        private void GenValueView_RangeMinMax()
        {
            meValue.Text = "[" + _value + "]";
        }
        private void GenValueView_ValueList()
        {
            string rtcValue = _value;
            StringBuilder builder = new StringBuilder();
            int count = 0;
            if (rtcValue != null)
            if (chkSimpleText.Checked)
                builder.Append(builder.Length <= 0 ? rtcValue : "," + rtcValue);
            else
                builder.AppendLine(rtcValue);
            this.Text = _propName + " - " + count.ToString() + " Items";
            meValue.Text = builder.ToString();
        }
        private void ViewText()
        {
            GlobVar.LockEvents = true;
            switch (RtcTupleStyle)
            {
                case EHTupleStyle.RangeMinMax:
                    GenValueView_RangeMinMax();
                    break;
                //case EHTupleStyle.RangeMinMaxLimit:
                //    GenValueView_RangeMinMaxLimit();
                //    break;
                //case EHTupleStyle.PointList:
                //    GenValueView_PointList();
                //    break;
                //case EHTupleStyle.Rectangle:
                //    GenValueView_Rectangle();
                //    break;
                //case EHTupleStyle.Origin:
                //    GenValueView_Origin();
                //    break;
                //case EHTupleStyle.Line:
                //    GenValueView_Line();
                //    break;
                //case EHTupleStyle.StringRange:
                //    GenValueView_StringRange();
                //    break;
                //case EHTupleStyle.Tolerance:
                //    GenValueView_Tolerance();
                //    break;
                //case EHTupleStyle.OriginList:
                //    GenValueView_OriginList();
                //    break;
                //case EHTupleStyle.RectangleList:
                //    GenValueView_RectangleList();
                //    break;
                //case EHTupleStyle.Point:
                //    GenValueView_PointList();
                //    break;
                //case EHTupleStyle.StringList:
                //    GenValueView_StringRange();
                //    break;
                //case EHTupleStyle.Pose:
                //    GenValueView_PoseList();
                //    break;
                //case EHTupleStyle.PoseList:
                //    GenValueView_PoseList();
                //    break;
                default:
                    GenValueView_ValueList();
                    break;
            }
            GlobVar.LockEvents = false;
        }
        public FrmViewTextValue()
        {
            InitializeComponent();
            RtcValue = string.Empty;
        }

        private void chkSimpleText_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            ViewText();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(meValue.Text);
            lblStatus.RunTrue(cStrings.Copied);
        }

        private void FrmViewTextValue_Load(object sender, EventArgs e)
        {
            meValue.Focus();
            this.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
