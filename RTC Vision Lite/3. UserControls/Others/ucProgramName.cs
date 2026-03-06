using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.Forms;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.UserControls
{
    public partial class ucProgramName : UserControl
    {
        private TextBox textBox = null;
        #region PROPERTIES

        /// <summary>
        ///  Event queue for all listenners for all Listenners interrested in onTextEditValueChanged events.
        /// </summary>
        public event ProgramNameValueChanged OnProgramNameValueChangedEvent;
        /// <summary>
        /// True if Use Captione, False if not
        /// </summary>
        private bool IsUseCaption = true;
        public bool RTCIsUseCaption
        {
            get => IsUseCaption;
            set
            {
                IsUseCaption = value;
                lblCaption.Visible = value;
                tlpLayout.ColumnStyles[0].Width = value ? 100 : 0;
            }
        }
        public float RTCCaptionWidth
        {
            get => tlpLayout.ColumnStyles[0].Width;
            set => tlpLayout.ColumnStyles[0].Width = value;
        }
        private cAction _RTCAction = null;
        public cAction RTCAction
        {
            get => _RTCAction;
            set
            {
                _RTCAction = value;
                PreviewData();
            }
        }
        private bool isMultiChoose;
        public bool RTCIsMultiChoose
        {
            get { return isMultiChoose; }
            set
            {
                isMultiChoose = value;
                tlpLayout.ColumnStyles[2].Width = value ? 30 : 0;
                if (value)
                {
                    tlpLayout.Controls.Remove(cbValue);
                    if (textBox == null)
                    {
                        textBox = new TextBox();
                        textBox.KeyDown -= TextBoxKeyDownEvents;
                        textBox.KeyDown += TextBoxKeyDownEvents;
                    }
                    textBox.Dock = DockStyle.Fill;
                    tlpLayout.Controls.Add(textBox, 1, 0);

                }
                else
                {
                    if (textBox != null)
                        tlpLayout.Controls.Remove(textBox);
                    tlpLayout.Controls.Remove(cbValue);
                    tlpLayout.Controls.Add(cbValue, 1, 0);
                }
            }
        }
        public string RTCPropertyName { get; set; }
        private cProjectTypes project;
        public cProjectTypes RTCProject
        {
            set => project = value;
        }
        private string _programName = "";
        public string ProgramName
        {
            get => _programName;
            set
            {
                _programName = value;
                cbValue.Text = _programName;
            }
        }
        private bool _isUseThisCam = true;
        public bool RTCIsUseThisCam
        {
            get => _isUseThisCam;
            set => _isUseThisCam = value;
        }
        #endregion
        #region FUNCTIONS
        public ucProgramName()
        {
            InitializeComponent();
            RTCIsUseCaption = true;
            RTCIsUseThisCam = true;
            RTCIsMultiChoose = false;
        }

        private void TextBoxKeyDownEvents(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnProgramNameValueChangedEvent(RTCPropertyName, textBox.Text, isMultiChoose);
            }
        }
        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                if (RTCAction == null)
                    return;
                if (RTCIsMultiChoose)
                {
                    textBox.Text = string.Empty;
                    string propgramName = string.Empty;
                    RTCVariableType PropGetValueInfo = (RTCVariableType)RTCAction.GetType().GetProperty(RTCPropertyName)?.GetValue(RTCAction, null);
                    if (PropGetValueInfo != null)
                    {
                        PropertyInfo PropGetValue_Value = PropGetValueInfo.GetType().GetProperty(cPropertyName.rtcValue);
                        propgramName = GlobFuncs.Object2Str(PropGetValue_Value.GetValue(PropGetValueInfo, null));
                    }
                    textBox.Text = propgramName;
                }
                else
                {
                    cbValue.Items.Clear();
                    if (project == null || RTCAction == null)
                        return;
                    foreach (cCAMTypes cam in project.CAMs.Values)
                        if (RTCAction.MyGroup.MyCam.Name != cam.Name)
                            cbValue.Items.Add(cam.Name);
                        else
                            cbValue.Items.Add(cStrings.This);
                    string sOldName = string.Empty;
                    RTCVariableType PropGetValueInfo = (RTCVariableType)RTCAction.GetType().GetProperty(RTCPropertyName)?.GetValue(RTCAction, null);
                    if (PropGetValueInfo != null)
                    {
                        PropertyInfo PropGetValue_Value = PropGetValueInfo.GetType().GetProperty(cPropertyName.rtcValue);
                        sOldName = GlobFuncs.Object2Str(PropGetValue_Value.GetValue(PropGetValueInfo, null));
                    }
                    if (cbValue.Items.Count > 0)
                    {
                        if (cbValue.Items.IndexOf(sOldName) >= 0)
                            cbValue.SelectedIndex = cbValue.Items.IndexOf(sOldName);
                        else
                            cbValue.SelectedIndex = 0;
                    }
                }
            }
            finally
            {
                GlobVar.LockEvents = false;
            }
            #endregion

        }
        private void cbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnProgramNameValueChangedEvent != null)
            {
                OnProgramNameValueChangedEvent(RTCPropertyName, cbValue.Text, isMultiChoose);
            }
        }


        private void btnProgramChoose_Click(object sender, EventArgs e)
        {
            if (RTCAction == null)
                return;
            string programName = string.Empty;
            RTCVariableType PropGetValueInfo = (RTCVariableType)RTCAction.GetType().GetProperty(RTCPropertyName).GetValue(RTCAction, null);
            if (PropGetValueInfo != null)
            {
                PropertyInfo PropGetValue_Value = PropGetValueInfo.GetType().GetProperty(cPropertyName.rtcValue);
                programName = GlobFuncs.Object2Str(PropGetValue_Value.GetValue(PropGetValueInfo, null));
                string[] programNames = programName.Split(cChars.Comma);
                frmWindowChoosed frmWindowChoosed = new frmWindowChoosed();
                frmWindowChoosed.ListCamNameChoosed = new List<string>(programNames);

                if (frmWindowChoosed.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = string.Join(cChars.Comma.ToString(), frmWindowChoosed.ListCamNameChoosed.ToArray());
                    OnProgramNameValueChangedEvent(RTCPropertyName, textBox.Text, isMultiChoose);
                }
            }
        }
    }



}
