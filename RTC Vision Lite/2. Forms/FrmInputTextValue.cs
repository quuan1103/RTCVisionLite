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

namespace RTC_Vision_Lite.Forms
{
    public delegate void BeforeCheckValueEvents(ref bool isAccept, string key, string inputValue);
    public partial class FrmInputTextValue : FrmBase
    {
        public event BeforeCheckValueEvents OnBeforeCheckValueEvents;
        public bool RTCIsAcceptEmptyValue { get; set; }
        public string RTCKey { get; set; }
        public string RTCValue
        {
            get => txtValue.Text;
            set => txtValue.Text = value;
        }
        public string RTCCaption
        {
            get => Text;
            set => Text = value;
        }

        public FrmInputTextValue()
        {
            InitializeComponent();
            RTCValue = string.Empty;
            RTCIsAcceptEmptyValue = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "" && !RTCIsAcceptEmptyValue)
            {
                cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_ObjectIsNotEmpty,
                                    new string[] { "value" }, new string[] { "Giá trị" }));
                txtValue.Focus();
                return;
            }

            if (OnBeforeCheckValueEvents != null)
            {
                bool isAccept = false;
                OnBeforeCheckValueEvents(ref isAccept, RTCKey, RTCValue);
                if (!isAccept)
                    return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmInputTextValue_Load(object sender, EventArgs e)
        {
            txtValue.Focus();
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK.PerformClick();
        }
    }

}
