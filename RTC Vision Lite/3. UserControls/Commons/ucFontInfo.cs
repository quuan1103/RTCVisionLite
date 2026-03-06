using RTC_Vision_Lite.Classes;
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
    public partial class ucFontInfo : UserControl
    {
        private const string DefaultFont = "Segoe UI, Regular, 8.25";
        private string _fontInfo = DefaultFont;
        public event FontInfoValueChanged OnFontInfoValueChanged;
        private string _infoName = "Info Name";
        public string InfoName
        {
            get => _infoName;
            set
            {
                _infoName = value;
                if (lblInfoName.InvokeRequired)
                {
                    lblInfoName.Invoke(new Action(() =>
                    {
                        lblInfoName.Text = _infoName;
                    }));
                }
                else
                    lblInfoName.Text = _infoName;
            }
        }
        private int _infoNameWidth = 100;
        public int InfoNameWidth
        {
            get => _infoNameWidth;
            set
            {
                _infoNameWidth = value;
                if (lblInfoName.InvokeRequired)
                {
                    lblInfoName?.Invoke(new Action(() =>
                    {
                        lblInfoName.Width = _infoNameWidth;
                    }));
                }
                else
                    lblInfoName.Width = _infoNameWidth;
            }
        }
        private bool _isShowInfoName = true;
        public bool IsShowInfoName
        {
            get => _isShowInfoName;
            set
            {
                _isShowInfoName = value;
                lblInfoName?.Invoke(new Action(() =>
                {
                    lblInfoName.Visible = value;
                }));
            }
        }
        public string FontInfo
        {
            get => _fontInfo;
            set
            {
                _fontInfo = value;
                txtValue.Text = _fontInfo;
                txtValue.Font = StringToFont();
            }
        }
        public ucFontInfo()
        {
            InitializeComponent();
        }
        private Font StringToFont()
        {
            if (string.IsNullOrEmpty(_fontInfo))
                _fontInfo = DefaultFont;
            string[] fontInfos = _fontInfo.Split(',');
            if (fontInfos.Length < 3)
                _fontInfo = DefaultFont;
            fontInfos = _fontInfo.Split(',');
            string fontName = fontInfos[0];
            if (!float.TryParse(fontInfos[fontInfos.Length - 1], out float fontSize))
                fontSize = 10;
            FontStyle fontStyle = FontStyle.Regular;
            for (int i = 1; i < fontInfos.Length - 2; i++)
            {
                string style = fontInfos[i].Trim();
                switch (style)
                {
                    case "Bold":
                        {
                            fontStyle = fontStyle | FontStyle.Bold;
                            break;
                        }
                    case "Italic":
                        {
                            fontStyle = fontStyle | FontStyle.Italic;
                            break;
                        }
                    case "Strikeout":
                        {
                            fontStyle = fontStyle | FontStyle.Strikeout;
                            break;
                        }
                    case "Underline":
                        {
                            fontStyle = fontStyle | FontStyle.Underline;
                            break;
                        }
                    default:
                        break;
                }
            }
            return new Font(new FontFamily(fontName), fontSize, fontStyle);
        }
        public int FontInfoHeight
        {
            get
            {
                Font font = StringToFont();
                if (font != null)
                {
                    return font.Height;
                }
                else
                    return 0;
            }
        }
        private void FontToString(Font font)
        {
            _fontInfo = string.Empty;
            _fontInfo = $"{font.FontFamily.Name}, {font.Style.ToString()},{font.Size}";
            FontInfo = _fontInfo;
        }
        private void txtValue_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = StringToFont();
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                FontToString(fontDialog1.Font);
                if (OnFontInfoValueChanged != null)
                    OnFontInfoValueChanged(_fontInfo, InfoName);
            }
        }

        private void popReset_Click(object sender, EventArgs e)
        {
            FontInfo = DefaultFont;
            if (OnFontInfoValueChanged != null)
                OnFontInfoValueChanged(_fontInfo, InfoName);
        }
    }
}
