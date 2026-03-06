using Microsoft.WindowsAPICodePack.Dialogs;
using RTC_Vision_Lite.Classes;
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
    
    public partial class ucLink : UserControl
    {
        public event ButtonLinkClickEvent OnButtonLinkClickEvent;
        public event ButtonRemoveLinkClickEvent OnButtonRemoveLinkClickEvent;
        public event TextBoxValueChanged OnTextBoxValueChanged; 
        public ucLink()
        {
            InitializeComponent();
            RTCAction = null;
            RTCPropertyName = string.Empty;
            RTCIsPreviewValue = false;
            RTCCaptionWidth = 60;
            RTCPreviewValueWidth = 200;
            RTCCanEditValue = false;
            RTCIsUseGetFolderButton = false;
        }
        #region PROPERTIES
        private string _Caption = cStrings.Caption;
        /// <summary>
        /// GET OR SET RTC CAPTION
        /// </summary>
        public string RTCCaption
        {
            get => _Caption;
            set
            {
                _Caption = value;
                lblCaption.Text = _Caption;

            }
        }
        public string RTCFolderName;
        private int _CaptionWidth = 60;
        /// <summary>
        /// GET OR SET WIDTH OF CAPTION
        /// </summary>
        public int RTCCaptionWidth
        {
            get => _CaptionWidth;
            set
            {
                _CaptionWidth = value;
                tlpLink.ColumnStyles[0].Width = _CaptionWidth;
            }
        }
        private string _propertyName;
        /// <summary>
        /// GET OR SET THE NAME OF THE RTC PROPERTY
        /// </summary>
        public string RTCPropertyName
        {
            get => _propertyName;
            set
            {
                _propertyName = value;
                txtValue.Name = value;
                PreviewData();
            }
        }
        private int _previewValueWidth = 200;
        public int RTCPreviewValueWidth
        {
            get => _previewValueWidth;
            set
            {
                _previewValueWidth = value;
                if (_isPreviewValue)
                    tlpLink.ColumnStyles[1].Width = _previewValueWidth;
            }
        }
        private bool _isPreviewValue = false;
        public bool RTCIsPreviewValue
        {
            get => _isPreviewValue;
            set
            {
                _isPreviewValue = value;
                tlpLink.ColumnStyles[1].Width = _isPreviewValue ? _previewValueWidth : 0;
            }
        }

        private bool _isUseGetFolderButton = false;

        public bool RTCIsUseGetFolderButton
        {
            get => _isUseGetFolderButton;
            set
            {
                _isUseGetFolderButton = value;
                btnGetFolder.Visible = value;
                tlpLink.ColumnStyles[3].Width = _isUseGetFolderButton ? 60 : 0;
            }
        }

        private bool _canEditValue = false;
        public bool RTCCanEditValue
        {
            get => _canEditValue;
            set
            {
                _canEditValue = value;
                txtValue.ReadOnly = !_canEditValue;
            }
        }
        private cAction _action;
        /// <summary>
        /// GET OR SET RTC action
        /// </summary>
        public cAction RTCAction
        {
            get => _action;
            set
            {
                _action = value;
                PreviewData();
            }
        }
        #endregion
        #region FUNCTIONS
        public void PreviewData()
        {
            lblRef.Text = cStrings.lblRefSource;
            btnRemoveLink.Enabled = false;
            if (RTCAction != null && _propertyName != string.Empty)
            {
                RTCVariableType value = (RTCVariableType)RTCAction.GetType().GetProperty(_propertyName)?.GetValue(RTCAction, null);
                PropertyInfo propertyInfoValue = RTCAction.GetType().GetProperty(_propertyName)?.PropertyType.GetProperty(cPropertyName.rtcValue);
                if (!(propertyInfoValue == null))
                {
                    object oValue =
                        propertyInfoValue.GetValue(RTCAction.GetType().GetProperty(_propertyName)?.GetValue(RTCAction, null), null);
                    if (oValue == null)
                        txtValue.Text = string.Empty;
                    else if (oValue.GetType() == typeof(List<double>))
                    {
                        if (oValue.GetType().FullName == nameof(List<double>))

                            txtValue.Text = GlobFuncs.Ve2Str((List<double>)(oValue));
                        else if (oValue.GetType().FullName == nameof(List<string>))
                        {
                            txtValue.Text = GlobFuncs.Ve2Str((List<string>)(oValue));
                        }
                        else if (oValue.GetType().FullName == nameof(List<object>))
                        {
                            txtValue.Text = GlobFuncs.Ve2Str((List<object>)(oValue));
                        }
                    }
                    else if (oValue.GetType() == typeof(List<string>))
                    {
                        if (oValue.GetType().FullName == nameof(List<double>))

                            txtValue.Text = GlobFuncs.Ve2Str((List<double>)(oValue));
                        else if (oValue.GetType().FullName == nameof(List<string>))
                        {
                            txtValue.Text = GlobFuncs.Ve2Str((List<string>)(oValue));
                        }
                        else if (oValue.GetType().FullName == nameof(List<object>))
                        {
                            txtValue.Text = GlobFuncs.Ve2Str((List<object>)(oValue));
                        }
                    }
                    else if (oValue.GetType() == typeof(string))
                    {
                        
                            txtValue.Text = GlobFuncs.Ve2Str((string)(oValue));
                        
                    }

                }
                if (value != null && value.rtcIDRef != Guid.Empty)
                {
                    lblRef.Text = cStrings.lblRefSource + value.rtcRef;
                    txtValue.Text = value.rtcRef;
                    btnRemoveLink.Enabled = true;
                }
            }
        }
        #endregion
        #region EVENT
        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            if (RTCPropertyName == "" || RTCAction == null) { return; }
            RTCE_ButtonRemoveLinkClickEventArgs eRTC = new RTCE_ButtonRemoveLinkClickEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            if (OnButtonRemoveLinkClickEvent != null)
            {
                OnButtonRemoveLinkClickEvent(sender, eRTC);
            }    
        }
        private void btnLink_Click (object sender, EventArgs e)
         {
            if (RTCPropertyName == "" || RTCAction == null) { return; }
            RTCE_ButtonLinkClickEventArgs eRTC = new RTCE_ButtonLinkClickEventArgs();
            eRTC.PropertyName = RTCPropertyName;
            if (OnButtonLinkClickEvent != null)
            {
                OnButtonLinkClickEvent(sender, eRTC);
            }
        }    
        private void btnGetFolder_Click(object sender, EventArgs e)
        {
            
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = GlobVar.RTCVision.Paths.OldPathChooseFolder;
            dialog.IsFolderPicker = true;
            dialog.Title = "Choose Folder";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                GlobVar.RTCVision.Paths.OldPathChooseFolder = dialog.FileName;
                txtValue.Text = dialog.FileName;
                RTCAction.FolderName.rtcValue = dialog.FileName;
            }
          
        }    
        #endregion
    }

}

