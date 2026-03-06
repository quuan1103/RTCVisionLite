using RTC_Vision_Lite.Classes;
using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
using RTCConst;
using RTCEnums;
using RTCSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class FrmSettings : FrmBase
    {
        private List<ucFontInfo> _ucFontInfos = null;
        private cSystemTypes _Settings;
        int t;
        internal cSystemTypes Settings
        {
            get => _Settings;
            set
            {
                _Settings = value;
                ViewSettings();
            }
        }
        public FrmSettings()
        {
            InitializeComponent();
        }
        public bool IsChangeLayoutCam { get; set; }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.White, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
                
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void ViewSettings_Options()
        {

            ckbTool.Checked = Settings.Options.ApplyActions_Tools;
            ckbImage.Checked = Settings.Options.ApplyActions_Images;
            c = (int)Settings.Options.ViewCamInMainFormMode;
            if(c ==0)
                radNomal.Checked = true;
            else if(c==1)
                radGroupWithTab.Checked = true;
            else if (c==2)
                radGroupWithoutTab.Checked = true;
            else if (c==3)
                radradGroupWithTabInRow.Checked = true;
            txtMaximumColumnCAM.Value = Settings.Options.MaximumColumnCAM;
            chkIsUseSaveLog.Checked = Settings.Options.IsSaveLog;
            chkIsAutoRunProjectWhenStartProgram.Checked = Settings.Options.IsAutorunProgramWhenStartWindows;
            chkIsLimitProcessRunning.Checked = Settings.Options.IsLimitProcessRunning;

        }
        private void ViewSettings_HSmartOptions()
        {
            chkIsUseResultLabel.Checked = Settings.SWindowOptions.IsUseOKNGLabel;
            chkIsUseOKFrameColor.Checked = Settings.SWindowOptions.IsUseOKFrameColor;
            chkIsUseNGFrameColor.Checked = Settings.SWindowOptions.IsUseNGFrameColor;

            //cbOKColor.SelectedItem = Settings.SWindowOptions.OKFrameColor;
            cbColorOK.RTCHalconColor = Settings.SWindowOptions.OKFrameColor;
            cbNGColor.RTCHalconColor = Settings.SWindowOptions.NGFrameColor;
            //cbOKColor. 
            //cbNGColor.

        }
        private void ViewSettings_ViewOptions()
        {
            chkViewCycleTimeInWindowCheck.Checked = Settings.ViewOptions.IsViewCycleTimeInWindow;
            chkViewRunCountInWindowCheck.Checked = Settings.ViewOptions.IsViewRunCountInWindow;
            chkSetOKNG.Checked = Settings.ViewOptions.CamFooter_IsViewOKNGButton;
            chkMoveRobot.Checked = Settings.ViewOptions.CamFooter_IsViewRobotMoveButton;
            chkSnapImage.Checked = Settings.ViewOptions.CamFooter_IsViewSnapImageButton;
            chkSaveImage.Checked = Settings.ViewOptions.CamFooter_IsViewSaveImageButton;
            chkLiveCAM.Checked = Settings.ViewOptions.CamFooter_IsViewLiveCamButton;
            chkStopLive.Checked = Settings.ViewOptions.CamFooter_IsViewStopLiveCamButton;
            chkVIewCoordinates.Checked = Settings.ViewOptions.CamFooter_IsViewCoordinates;
            txtListModelFontSize.Value = Settings.ViewOptions.ListModelFontSize;

            chkPreviewImageEmbedToGrid.Checked = Settings.ViewOptions.IsPreviewImageEmbedToGrid;
            chkIsShowPreviewImage.Checked = Settings.ViewOptions.IsShowPreviewImage;
            cbDrawingMode.Text = Settings.ViewOptions.DrawingMode;
            txtDrawingLineWidth.Value = (decimal)Settings.ViewOptions.DrawingLineWidth;
            txtNumberOfDigitsToRound.Value = Settings.ViewOptions.NumberOfDigitsToRound;
            chkManualRun.Checked = Settings.ViewOptions.CamFooter_IsViewRunButton;
            chkViewResultTab.Checked = Settings.ViewOptions.IsViewResultTab;
            chkIsShowLogo.Checked = Settings.ViewOptions.IsShowLogo;
            chkViewMainCounter.Checked = Settings.ViewOptions.IsShowMainCounter;
            chkIsShowTime.Checked = Settings.ViewOptions.IsShowTime;
            txtLogoFileName.Text = Settings.ViewOptions.LogoFileName;
            txtLogoFileName.Enabled = chkIsShowLogo.Checked;
        }
        private void ViewSettings_ImageOptions()
        {
            chkIsAutoCleanImage.Checked = Settings.ImageOptions.IsAutoCleanImage;
            cbCleanImageEvent.Text = Settings.ImageOptions.CleanImageEvent;
            txtNumberOfDayCleanImage.Text = Settings.ImageOptions.NumberOfTimeCleanImage.ToString();
            txtCleanImageWithin_NumberOfTime.Text = Settings.ImageOptions.NumberOfTimeCleanImageWithin.ToString();

            int t = (int)Settings.ImageOptions.OKNGConfirm_SaveImageMode;
            if (t == 0)
                radNone.Checked = true;
            else if (t == 1)
                radOnlyOK.Checked = true;
            else if (t == 2)
                radOnlyNG.Checked = true;
            else
                radBoth.Checked = true;

            txtOKNGConfirm_SaveFolder.Text = Settings.ImageOptions.OKNGConfirm_SaveFolder;
            chkOKNGConfirm_UseChildFolder.Checked = Settings.ImageOptions.OKNGConfirm_UseChildFolder;
            chkOKNGConfirm_FolderByMonth.Checked = Settings.ImageOptions.OKNGConfirm_ChildFolder_ByMonth;
            chkOKNGConfirm_FolderByday.Checked = Settings.ImageOptions.OKNGConfirm_ChildFolder_ByDay;
            chkOKNGConfirm_FolderByModelName.Checked = Settings.ImageOptions.OKNGConfirm_ChildFolder_ByModel;
            txtNumberOfDayCleanImage.Text = Settings.ImageOptions.NumberOfTimeCleanImage.ToString();

            chkIsQuestionBeforeClean.Checked = Settings.ImageOptions.IsQuestionBeforeClean;
            //radCleanImageFolderMode.SelectedIndex = (int)Settings.ImageOptions.CleanImageFolderMode;
            //txtCleanImageFolder.Text = Settings.ImageOptions.CleanImageFolder;
        }
        private void ViewSettings_UpdateOptions()
        {
            chkIsAutoUpdate.Checked = Settings.UpdateOptions.IsAutoUpdate;
            txtUpdate_HostName.Text = Settings.UpdateOptions.HostName;
            txtUpdate_UserName.Text = Settings.UpdateOptions.UserName;
            txtUpdate_Password.Text = Settings.UpdateOptions.Password;
            txtUpdate_FolderName.Text = Settings.UpdateOptions.FolderName;
        }
        private void ViewSettings_LogOptions()
        {
            chkIsUseSaveLog.Checked = GlobVar.RTCVision.LogOptions.IsSaveLog;
            chkIsSaveLogToData.Checked = GlobVar.RTCVision.LogOptions.IsSaveLogToDataFile;
            chkIsSaveLogToTextFile.Checked = GlobVar.RTCVision.LogOptions.IsSaveLogToTextFile;
            txtLogMaxLine.Value = GlobVar.RTCVision.LogOptions.MaxLine;
        }
        private void ViewSettings_ReportOptions()
        {
            chkIsUseSaveReport.Checked = GlobVar.RTCVision.ReportOptions.IsSaveReport;
        }
        private void ViewSettings_ErrorOptions()
        {
            chkIsUseSaveError.Checked = GlobVar.RTCVision.ErrorOptions.IsSaveError;
            chkIsSaveErrorToData.Checked = GlobVar.RTCVision.ErrorOptions.IsSaveErrorToDataFile;
            chkIsSaveErrorToTextFile.Checked = GlobVar.RTCVision.ErrorOptions.IsSaveErrorToTextFile;
        }
        private void ViewSetting_FontStyles_Clear()
        {
            tpViewStyle.Controls.Clear();
            tpViewStyle.RowStyles.Clear();
            tpViewStyle.RowCount = 1;
            if (_ucFontInfos != null)
                foreach (var t in _ucFontInfos)
                    t.Dispose();
            _ucFontInfos = null;
        }
        private void ViewSetting_FontStyles()
        {
            try
            {
                GlobFuncs.BeginControlUpdate(tpViewStyle);

                ViewSetting_FontStyles_Clear();
                _ucFontInfos = new List<ucFontInfo>();
                // Nạp danh sách các loại style lên
                DataTable dataTable = CommonData.ViewStyles;

                tpViewStyle.RowCount = 1;
                int rowCount = 2;
                if (dataTable != null)
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ucFontInfo fontInfo = new ucFontInfo();
                        fontInfo.Padding = new Padding(2);
                        fontInfo.InfoNameWidth = 250;
                        fontInfo.InfoName = GlobVar.RTCVision.Language == ELanguage.Eng
                            ? GlobFuncs.GetDataRowValue_String(row, cColName.CaptionEng)
                            : GlobFuncs.GetDataRowValue_String(row, cColName.CaptionVi);
                        fontInfo.FontInfo = GlobFuncs.GetDataRowValue_String(row, cColName.Font);
                        fontInfo.OnFontInfoValueChanged -= OnFontInfoValueChanged;
                        fontInfo.OnFontInfoValueChanged += OnFontInfoValueChanged;
                        tpViewStyle.RowCount = rowCount;
                        fontInfo.Tag = rowCount - 2;
                        tpViewStyle.RowStyles.Add(new RowStyle(SizeType.Absolute, fontInfo.FontInfoHeight * 2));
                        tpViewStyle.Controls.Add(fontInfo, 0, rowCount - 2);
                        fontInfo.Dock = DockStyle.Fill;
                        _ucFontInfos.Add(fontInfo);
                        rowCount += 1;
                    }
            }
            catch (Exception e)
            {
                GlobFuncs.SaveErr(e);
            }
            finally
            {
                GlobFuncs.EndControlUpdate(tpViewStyle);
            }
        }
        private void ViewSettings_SecurityOptions()
        {
            GlobVar.LockEvents = true;
            ///
            GlobVar.LockEvents = false;
            switch (Settings.SecurityOptions.SecurityModes)
            {
                case cSecurityModes.SecurityModes_UseAccount:
                    cbSecurityMode.SelectedIndex = 0;
                    break;
                case cSecurityModes.SecurityModes_None:
                    cbSecurityMode.SelectedIndex = 1;
                    break;
                default:
                    cbSecurityMode.SelectedIndex = 1;
                    break;
            }
            chkIsNeedLoginWhenOpenProgram.Checked = Settings.SecurityOptions.IsNeedLoginWhenOpenProgram;
        }
        private void ViewSettings()
        {
            txtProjectPath.Text = Settings.Paths.Projects;
            ViewSettings_Options();
            ViewSettings_HSmartOptions();
            ViewSettings_ViewOptions();
            ViewSettings_RunOptions();
            ViewSettings_ImageOptions();
            ViewSettings_ReportOptions();
            ViewSettings_UpdateOptions();
            ViewSettings_LogOptions();
            ViewSettings_ErrorOptions();
            ViewSetting_FontStyles();
            ViewSettings_SecurityOptions();
        }
        
        private void ViewSetting_ViewStyle()
        {
            try
            {
                
            }
            catch (Exception e)
            {

                throw;
            }
        }
        private void ViewSetting_ViewStyle_Clear()
        {

        }
        private void ViewSettings_RunOptions()
        {
            chkIsAutoRunProjectWhenStartProgram.Checked = Settings.RunOptions.IsAutoRunProjectWhenStartProgram;
        }
        
        private void GetSettings_ViewOptions()
        {
            Settings.ViewOptions.IsViewCycleTimeInWindow = chkViewCycleTimeInWindowCheck.Checked;
            Settings.ViewOptions.IsViewRunCountInWindow = chkViewRunCountInWindowCheck.Checked;
            Settings.ViewOptions.CamFooter_IsViewOKNGButton = chkSetOKNG.Checked;
            Settings.ViewOptions.CamFooter_IsViewRobotMoveButton = chkMoveRobot.Checked;
            Settings.ViewOptions.CamFooter_IsViewSnapImageButton = chkSnapImage.Checked;
            Settings.ViewOptions.CamFooter_IsViewSaveImageButton = chkSaveImage.Checked;
            Settings.ViewOptions.CamFooter_IsViewLiveCamButton = chkLiveCAM.Checked;
            Settings.ViewOptions.CamFooter_IsViewStopLiveCamButton = chkStopLive.Checked;
            Settings.ViewOptions.CamFooter_IsViewCoordinates = chkVIewCoordinates.Checked;
            //Settings.ViewOptions.CamFooter_IsViewTriggerSoftware = chkTriggerBySoftware.Checked;
            Settings.ViewOptions.IsPreviewImageEmbedToGrid = chkPreviewImageEmbedToGrid.Checked;
            Settings.ViewOptions.IsShowPreviewImage = chkIsShowPreviewImage.Checked;
            Settings.ViewOptions.DrawingMode = cbDrawingMode.Text;
            Settings.ViewOptions.DrawingLineWidth = (double)txtDrawingLineWidth.Value;
            Settings.ViewOptions.NumberOfDigitsToRound = (int)txtNumberOfDigitsToRound.Value;
            Settings.ViewOptions.CamFooter_IsViewRunButton = chkManualRun.Checked;
            Settings.ViewOptions.IsViewResultTab = chkViewResultTab.Checked;
            Settings.ViewOptions.IsShowLogo = chkIsShowLogo.Checked;
            Settings.ViewOptions.IsShowMainCounter = chkViewMainCounter.Checked;
            Settings.ViewOptions.IsShowTime = chkIsShowTime.Checked;
            Settings.ViewOptions.LogoFileName = txtLogoFileName.Text;
            Settings.ViewOptions.ListModelFontSize = (int)txtListModelFontSize.Value;
            Settings.Options.LimitProcessRunning = (int)numLimitProcessRunning.Value;
        }


        int c;
        private void GetSetting_Options()
        {
            t = (int)Settings.Options.ViewCamInMainFormMode;
            Settings.Options.ApplyActions_Tools = ckbTool.Checked;
            Settings.Options.ApplyActions_Images = ckbImage.Checked;
            if (radNomal.Checked)
                c = 0;
            else if (radGroupWithTab.Checked)
                c = 1;
            else if (radGroupWithoutTab.Checked)
                c = 2;
            else if (radradGroupWithTabInRow.Checked)
                c = 3;
            if (Settings.Options.ViewCamInMainFormMode != (EViewCamInMainFormMode)c)
            {
                Settings.Options.ViewCamInMainFormMode = (EViewCamInMainFormMode)c;
                IsChangeLayoutCam = true;
            }
            if(int.TryParse(txtMaximumColumnCAM.Text, out int iMaximumColumnCAM))
                if(Settings.Options.MaximumColumnCAM != iMaximumColumnCAM)
                {
                    Settings.Options.MaximumColumnCAM = iMaximumColumnCAM;
                    IsChangeLayoutCam = true;
                }
            
            Settings.Options.IsAutorunProgramWhenStartWindows = chkIsAutoRunProjectWhenStartProgram.Checked;
            Settings.Options.LimitProcessRunning = (int)numLimitProcessRunning.Value;
            Settings.Options.IsLimitProcessRunning = chkIsLimitProcessRunning.Checked;

        }
        private void GetSettings_ReportOptions()
        {
            Settings.ReportOptions.IsSaveReport = chkIsUseSaveReport.Checked;
        }
        private void GetSettings_LogOptions()
        {
            Settings.LogOptions.IsSaveLog = chkIsUseSaveLog.Checked;
            Settings.LogOptions.IsSaveLogToDataFile = chkIsSaveLogToData.Checked;
            Settings.LogOptions.IsSaveLogToTextFile = chkIsSaveLogToTextFile.Checked;
            if (txtLogMaxLine.Value >= 0)
                Settings.LogOptions.MaxLine = (int)txtLogMaxLine.Value;
            else
                Settings.LogOptions.MaxLine = 10000;
        }
        private void GetSettings_Paths()
        {
            Settings.Paths.Projects = txtProjectPath.Text;
        }
        private void GetSettings_ErrorOptions()
        {
            Settings.ErrorOptions.IsSaveError = chkIsUseSaveError.Checked;
            Settings.ErrorOptions.IsSaveErrorToDataFile = chkIsSaveErrorToData.Checked;
            Settings.ErrorOptions.IsSaveErrorToTextFile = chkIsSaveErrorToTextFile.Checked;
        }
        private void GetSettings_RunOptions()
        {
            Settings.RunOptions.IsAutoRunProjectWhenStartProgram = chkIsAutoRunProjectWhenStartProgram.Checked;
        }
        private void GetSettings_ImageOptions()
        {
            Settings.ImageOptions.IsAutoCleanImage = chkIsAutoCleanImage.Checked;
            if (Settings.ImageOptions.CleanImageEvent != cbCleanImageEvent.Text)
            {
                if (cbCleanImageEvent.Text == cCleanImageEvent.ByTime)
                    Settings.ImageOptions.BeginTimeClean = DateTime.Now;
            }
            Settings.ImageOptions.CleanImageEvent = cbCleanImageEvent.Text;
            if (int.TryParse(txtNumberOfDayCleanImage.Text, out int iTime))
                Settings.ImageOptions.NumberOfTimeCleanImage = iTime;

            Settings.ImageOptions.IsQuestionBeforeClean = chkIsQuestionBeforeClean.Checked;

            if (int.TryParse(txtCleanImageWithin_NumberOfTime.Text, out iTime))
                Settings.ImageOptions.NumberOfTimeCleanImageWithin = iTime;
            else
                Settings.ImageOptions.NumberOfTimeCleanImageWithin = -1;
        }
        private void GetSettings_SecurityOptions()
        {
            switch (cbSecurityMode.SelectedIndex)
            {
                case 0:
                    Settings.SecurityOptions.SecurityModes = cSecurityModes.SecurityModes_UseAccount;
                    break;
                case 1:
                    Settings.SecurityOptions.SecurityModes = cSecurityModes.SecurityModes_None;
                    break;
                default:
                    Settings.SecurityOptions.SecurityModes = cSecurityModes.SecurityModes_None;
                    break;
            }
            Settings.SecurityOptions.IsNeedLoginWhenOpenProgram = chkIsNeedLoginWhenOpenProgram.Checked;
        }
        private void GetSettings_UpdateOptions()
        {
            Settings.UpdateOptions.IsAutoUpdate = chkIsAutoUpdate.Checked;
            Settings.UpdateOptions.HostName = txtUpdate_HostName.Text;
            Settings.UpdateOptions.UserName = txtUpdate_UserName.Text;
            Settings.UpdateOptions.Password = txtUpdate_Password.Text;
            Settings.UpdateOptions.FolderName = txtUpdate_FolderName.Text;
        }
        private void GetSettings_HSmartOptions()
        {
            Settings.SWindowOptions.IsUseOKNGLabel = chkIsUseResultLabel.Checked;
            Settings.SWindowOptions.IsUseOKFrameColor = chkIsUseOKFrameColor.Checked;
            Settings.SWindowOptions.IsUseNGFrameColor = chkIsUseNGFrameColor.Checked;

            //Settings.SWindowOptions.OKFrameColor = cbOKColor.Text;
            Settings.SWindowOptions.NGFrameColor = cbNGColor.Text;
        }
        
        private void GetSettings()
        {
            GetSetting_Options();
            GetSettings_ViewOptions();
            GetSettings_RunOptions();
            GetSettings_ReportOptions();
            GetSettings_ErrorOptions();
            GetSettings_LogOptions();
            GetSettings_ImageOptions();
            GetSettings_SecurityOptions();
            GetSettings_UpdateOptions();
            GetSettings_HSmartOptions();

        }
        private void SaveViewStyle()
        {
            if(_ucFontInfos != null)
            {
                foreach (ucFontInfo fontInfo in _ucFontInfos)
                {
                    switch (GlobVar.RTCVision.Language)
                    {
                        case RTCEnums.ELanguage.Eng:
                            {
                                CommonData.ExecuteQuery(
                                    $"UPDATE {cTableName_Common.ViewStyles} SET Font = '{fontInfo.FontInfo}' WHERE {cColName.CaptionEng}='{fontInfo.InfoName}'");
                                break;
                            }
                        case RTCEnums.ELanguage.VN:
                            CommonData.ExecuteQuery(
                                    $"UPDATE {cTableName_Common.ViewStyles} SET Font = '{fontInfo.FontInfo}' WHERE {cColName.CaptionVi}='{fontInfo.InfoName}'");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private bool ValidateData()
        {
            try
            {
                if (!Directory.Exists(txtProjectPath.Text))
                {
                    cMessageBox.Warning(cMessageContent.BuildMessage(cMessageContent.War_DicrectoryNotExists,
                            new string[] { txtProjectPath.Text }, new string[] { txtProjectPath.Text }));
                    return false;
                }

                if (chkIsAutoCleanImage.Checked)
                {
                    if (!int.TryParse(txtNumberOfDayCleanImage.Text.ToString(), out int _PortNumber))
                    {
                        cMessageBox.Warning(cMessageContent.War_NumberOfDayCleanImageOnlyNumber);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);

                return false;
            }
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ValidateData())
                GetSettings();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                GetSettings();
                SaveViewStyle();
                DialogResult = DialogResult.OK;
            }
        }
        public bool IsChangeViewStyleResultLabelOkNg { get; set; }
        public bool IsChangeViewStyleFormActions { get; set; }
        private void OnFontInfoValueChanged(string fontInfo,string infoName = "")
        {
            if (_ucFontInfos == null)
                return;
            ucFontInfo info = _ucFontInfos.FirstOrDefault(x => x.InfoName == infoName);
            if (info == null || info.Tag == null)
                return;

            int layoutIndex = GlobFuncs.Object2Int(info.Tag);
            if (layoutIndex < 0 || layoutIndex >= tpViewStyle.RowCount)
                return;
            tpViewStyle.RowStyles[layoutIndex].Height = info.FontInfoHeight * 2;
            IsChangeViewStyleResultLabelOkNg = infoName == cFontStyles.ResultLabelOkNg;
            IsChangeViewStyleFormActions = (infoName == cFontStyles.ListOfToolOfProgram ||
                                            infoName == cFontStyles.ListOfToolOfModelSmall ||
                                            infoName == cFontStyles.ListOfToolOfModelNomal ||
                                            infoName == cFontStyles.ListOfToolOfModelLarge);
            
        }

        private void txtProjectPath_Click_1(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.SelectedPath = @"C:\";
            DialogResult result = path.ShowDialog();

            // Check if the user selected a folder
            if (result == DialogResult.OK)
            {
                // Set the selected folder path in the textbox
                txtProjectPath.Text = path.SelectedPath;
            }
        }

        private void txtLogoFileName_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(txtLogoFileName.Text))
            {
                try
                {
                    picLogo.Image = Image.FromFile(txtLogoFileName.Text);
                }
                catch(Exception ex)
                {
                    picLogo.Image = null;
                }
            }
            else
                picLogo.Image = null;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageOpenFileDialog = new OpenFileDialog();
            if (File.Exists(GlobVar.RTCVision.ViewOptions.LogoFileName))
            {
                imageOpenFileDialog.InitialDirectory = Path.GetFullPath(GlobVar.RTCVision.ViewOptions.LogoFileName);
                imageOpenFileDialog.FileName = GlobVar.RTCVision.ViewOptions.LogoFileName;
            }
            else
                imageOpenFileDialog.InitialDirectory = GlobVar.RTCVision.Paths.OldPathChooseFolder;
            imageOpenFileDialog.Filter = cStrings.ImageFilter;
            if(imageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLogoFileName.Text = imageOpenFileDialog.FileName;
                if (txtLogoFileName.Text.Contains(GlobVar.RTCVision.Paths.AppPath))
                {
                    txtLogoFileName.Text = txtLogoFileName.Text.Replace(GlobVar.RTCVision.Paths.AppPath, string.Empty);
                }
            }
        }

        private void chkIsShowLogo_CheckedChanged(object sender, EventArgs e)
        {
            txtLogoFileName.Enabled = chkIsShowLogo.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void ckbLimitProcessRunning_CheckedChanged(object sender, EventArgs e)
        {
            numLimitProcessRunning.Enabled = chkIsLimitProcessRunning.Checked;
        }

        private void chkIsAutoCleanImage_CheckedChanged(object sender, EventArgs e)
        {
            cbCleanImageEvent.Enabled = chkIsAutoCleanImage.Checked;
            txtNumberOfDayCleanImage.Enabled = chkIsAutoCleanImage.Checked && cbCleanImageEvent.Text == cCleanImageEvent.ByTime;
        }

        private void cbCleanImageEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumberOfDayCleanImage.Enabled = chkIsAutoCleanImage.Checked && cbCleanImageEvent.Text == cCleanImageEvent.ByTime;
        }

        private void cbSecurityMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkIsNeedLoginWhenOpenProgram.Enabled = cbSecurityMode.SelectedIndex == 0;
        }

        private void chkIsAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            grpSourceOptions.Enabled = chkIsAutoUpdate.Checked;
        }

        private void chkIsUseSaveLog_CheckedChanged(object sender, EventArgs e)
        {
            Settings.LogOptions.IsSaveLog = chkIsUseSaveLog.Checked;
        }

        private void cbColorOK_OnColorComboboxValueChanged(string propName, string value)
        {
            Settings.SWindowOptions.OKFrameColor = value;

        }

        private void chkIsUseNGFrameColor_CheckedChanged(object sender, EventArgs e)
        {
            cbNGColor.Enabled = chkIsUseNGFrameColor.Checked;
            Settings.SWindowOptions.IsUseNGFrameColor = chkIsUseNGFrameColor.Checked;

        }

        private void cbNGColor_OnColorComboboxValueChanged(string propName, string value)
        {
            Settings.SWindowOptions.NGFrameColor = value;

        }
    }


}
