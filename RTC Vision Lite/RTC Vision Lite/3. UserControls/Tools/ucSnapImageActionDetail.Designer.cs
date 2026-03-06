
namespace RTC_Vision_Lite.UserControls
{
    partial class ucSnapImageActionDetail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSnapImageActionDetail));
            this.ucOrigin1 = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucProgramName1 = new RTC_Vision_Lite.UserControls.ucProgramName();
            this.tlCameraSettings = new RTC_Vision_Lite.UserControls.MyTreeList();
            this.colPropName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEnable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnRefreshTemplate = new System.Windows.Forms.Button();
            this.RTCTemplateName = new System.Windows.Forms.ComboBox();
            this.RTCUseCameraSettings = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.RTCCameraMode = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.RTCIsBringImageToMain = new System.Windows.Forms.CheckBox();
            this.RTCIsKeepImage = new System.Windows.Forms.CheckBox();
            this.RTCSnapMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.RTCErrMessage = new System.Windows.Forms.Label();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlCameraSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin1);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(2, 2);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableGeneral.Size = new System.Drawing.Size(861, 409);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(2, 39);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(4);
            this.PageSetup.Size = new System.Drawing.Size(888, 421);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(2);
            this.ROI.Padding = new System.Windows.Forms.Padding(2);
            this.ROI.Size = new System.Drawing.Size(865, 413);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(2);
            this.PassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCErrMessage);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.groupBox2);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Location = new System.Drawing.Point(2, 2);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableROI.Size = new System.Drawing.Size(861, 409);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(888, 37);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(2);
            this.General.Padding = new System.Windows.Forms.Padding(2);
            this.General.Size = new System.Drawing.Size(865, 413);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(2);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(2);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(2);
            this.Method.Padding = new System.Windows.Forms.Padding(2);
            this.Method.Size = new System.Drawing.Size(865, 413);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(2);
            this.Display.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(2, 2);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableMethod.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(859, 407);
            // 
            // Selecticon
            // 
            this.Selecticon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Selecticon.ImageStream")));
            this.Selecticon.Images.SetKeyName(0, "Input");
            this.Selecticon.Images.SetKeyName(1, "Output");
            this.Selecticon.Images.SetKeyName(2, "Link");
            this.Selecticon.Images.SetKeyName(3, "Next");
            this.Selecticon.Images.SetKeyName(4, "System");
            this.Selecticon.Images.SetKeyName(5, "SaveInput");
            this.Selecticon.Images.SetKeyName(6, "RemoveLink");
            this.Selecticon.Images.SetKeyName(7, "LinkProperty");
            this.Selecticon.Images.SetKeyName(8, "ViewListItem");
            this.Selecticon.Images.SetKeyName(9, "checkbox-checked");
            this.Selecticon.Images.SetKeyName(10, "checkbox-unchecked");
            this.Selecticon.Images.SetKeyName(11, "checkbox-indeterminate");
            // 
            // imlLinkSummary
            // 
            this.imlLinkSummary.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLinkSummary.ImageStream")));
            this.imlLinkSummary.Images.SetKeyName(0, "Right");
            this.imlLinkSummary.Images.SetKeyName(1, "Left");
            // 
            // ucOrigin1
            // 
            this.ucOrigin1.Action = null;
            this.ucOrigin1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin1.Location = new System.Drawing.Point(20, 153);
            this.ucOrigin1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(679, 100);
            this.ucOrigin1.TabIndex = 7;
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(20, 58);
            this.ucImageLink.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(679, 65);
            this.ucImageLink.TabIndex = 6;
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(641, 22);
            this.RTCName.TabIndex = 5;
            this.RTCName.Text = "Snap Image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 7;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pass/Fail:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ucProgramName1);
            this.groupBox2.Controls.Add(this.tlCameraSettings);
            this.groupBox2.Controls.Add(this.btnRefreshTemplate);
            this.groupBox2.Controls.Add(this.RTCTemplateName);
            this.groupBox2.Controls.Add(this.RTCUseCameraSettings);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.RTCCameraMode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RTCIsBringImageToMain);
            this.groupBox2.Controls.Add(this.RTCIsKeepImage);
            this.groupBox2.Controls.Add(this.RTCSnapMode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(19, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 313);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Snap Settings";
            // 
            // ucProgramName1
            // 
            this.ucProgramName1.Location = new System.Drawing.Point(252, 56);
            this.ucProgramName1.Name = "ucProgramName1";
            this.ucProgramName1.ProgramName = "";
            this.ucProgramName1.RTCAction = null;
            this.ucProgramName1.RTCCaptionWidth = 100F;
            this.ucProgramName1.RTCIsMultiChoose = false;
            this.ucProgramName1.RTCIsUseCaption = true;
            this.ucProgramName1.RTCIsUseThisCam = true;
            this.ucProgramName1.RTCPropertyName = "ProgramName";
            this.ucProgramName1.Size = new System.Drawing.Size(418, 27);
            this.ucProgramName1.TabIndex = 27;
            // 
            // tlCameraSettings
            // 
            this.tlCameraSettings.AllColumns.Add(this.colPropName);
            this.tlCameraSettings.AllColumns.Add(this.colValue);
            this.tlCameraSettings.AllColumns.Add(this.colEnable);
            this.tlCameraSettings.CellEditUseWholeCell = false;
            this.tlCameraSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPropName,
            this.colValue,
            this.colEnable});
            this.tlCameraSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlCameraSettings.HideSelection = false;
            this.tlCameraSettings.Location = new System.Drawing.Point(8, 117);
            this.tlCameraSettings.LockCalc = false;
            this.tlCameraSettings.Name = "tlCameraSettings";
            this.tlCameraSettings.OwnerDrawnHeader = true;
            this.tlCameraSettings.ShowGroups = false;
            this.tlCameraSettings.Size = new System.Drawing.Size(662, 180);
            this.tlCameraSettings.TabIndex = 26;
            this.tlCameraSettings.UseCompatibleStateImageBehavior = false;
            this.tlCameraSettings.View = System.Windows.Forms.View.Details;
            this.tlCameraSettings.VirtualMode = true;
            // 
            // colPropName
            // 
            this.colPropName.AspectName = "PropName";
            this.colPropName.FillsFreeSpace = true;
            this.colPropName.Text = "PropName";
            this.colPropName.Width = 242;
            // 
            // colValue
            // 
            this.colValue.AspectName = "Value";
            this.colValue.FillsFreeSpace = true;
            this.colValue.Text = "Value";
            this.colValue.Width = 274;
            // 
            // colEnable
            // 
            this.colEnable.AspectName = "Enable";
            this.colEnable.FillsFreeSpace = true;
            this.colEnable.Text = "";
            this.colEnable.Width = 213;
            // 
            // btnRefreshTemplate
            // 
            this.btnRefreshTemplate.Image = global::RTC_Vision_Lite.Properties.Resources.Reset_16x16;
            this.btnRefreshTemplate.Location = new System.Drawing.Point(648, 88);
            this.btnRefreshTemplate.Name = "btnRefreshTemplate";
            this.btnRefreshTemplate.Size = new System.Drawing.Size(22, 23);
            this.btnRefreshTemplate.TabIndex = 25;
            this.btnRefreshTemplate.UseVisualStyleBackColor = true;
            this.btnRefreshTemplate.Click += new System.EventHandler(this.btnRefreshTemplate_Click);
            // 
            // RTCTemplateName
            // 
            this.RTCTemplateName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCTemplateName.FormattingEnabled = true;
            this.RTCTemplateName.Location = new System.Drawing.Point(354, 89);
            this.RTCTemplateName.Name = "RTCTemplateName";
            this.RTCTemplateName.Size = new System.Drawing.Size(290, 21);
            this.RTCTemplateName.TabIndex = 24;
            this.RTCTemplateName.SelectedIndexChanged += new System.EventHandler(this.RTCTemplateName_SelectedIndexChanged);
            // 
            // RTCUseCameraSettings
            // 
            this.RTCUseCameraSettings.AutoSize = true;
            this.RTCUseCameraSettings.Location = new System.Drawing.Point(258, 92);
            this.RTCUseCameraSettings.Name = "RTCUseCameraSettings";
            this.RTCUseCameraSettings.Size = new System.Drawing.Size(90, 17);
            this.RTCUseCameraSettings.TabIndex = 23;
            this.RTCUseCameraSettings.Text = "Use Settings";
            this.RTCUseCameraSettings.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(445, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 17);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Other Main";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // RTCCameraMode
            // 
            this.RTCCameraMode.AutoSize = true;
            this.RTCCameraMode.Checked = true;
            this.RTCCameraMode.Location = new System.Drawing.Point(330, 38);
            this.RTCCameraMode.Name = "RTCCameraMode";
            this.RTCCameraMode.Size = new System.Drawing.Size(93, 17);
            this.RTCCameraMode.TabIndex = 21;
            this.RTCCameraMode.TabStop = true;
            this.RTCCameraMode.Text = "Current Main";
            this.RTCCameraMode.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Choose";
            // 
            // RTCIsBringImageToMain
            // 
            this.RTCIsBringImageToMain.AutoSize = true;
            this.RTCIsBringImageToMain.Location = new System.Drawing.Point(20, 59);
            this.RTCIsBringImageToMain.Name = "RTCIsBringImageToMain";
            this.RTCIsBringImageToMain.Size = new System.Drawing.Size(167, 17);
            this.RTCIsBringImageToMain.TabIndex = 18;
            this.RTCIsBringImageToMain.Text = "Bring Image To Main Action";
            this.RTCIsBringImageToMain.UseVisualStyleBackColor = true;
            // 
            // RTCIsKeepImage
            // 
            this.RTCIsKeepImage.AutoSize = true;
            this.RTCIsKeepImage.Location = new System.Drawing.Point(21, 36);
            this.RTCIsKeepImage.Name = "RTCIsKeepImage";
            this.RTCIsKeepImage.Size = new System.Drawing.Size(85, 17);
            this.RTCIsKeepImage.TabIndex = 17;
            this.RTCIsKeepImage.Text = "Keep Image";
            this.RTCIsKeepImage.UseVisualStyleBackColor = true;
            // 
            // RTCSnapMode
            // 
            this.RTCSnapMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSnapMode.FormattingEnabled = true;
            this.RTCSnapMode.Location = new System.Drawing.Point(89, 89);
            this.RTCSnapMode.Name = "RTCSnapMode";
            this.RTCSnapMode.Size = new System.Drawing.Size(99, 21);
            this.RTCSnapMode.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Snap Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Threshold Mode:";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(19, 352);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "Snap";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.RTCErrMessage.Location = new System.Drawing.Point(113, 357);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(80, 13);
            this.RTCErrMessage.TabIndex = 11;
            this.RTCErrMessage.Text = "Error Message";
            // 
            // ucSnapImageActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucSnapImageActionDetail";
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.ScrollableROI.ResumeLayout(false);
            this.ScrollableROI.PerformLayout();
            this.General.ResumeLayout(false);
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlCameraSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucOrigin ucOrigin1;
        private ucImageLink ucImageLink;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox RTCSnapMode;
        private System.Windows.Forms.Label label4;
        private MyTreeList tlCameraSettings;
        private BrightIdeasSoftware.OLVColumn colPropName;
        private BrightIdeasSoftware.OLVColumn colValue;
        private BrightIdeasSoftware.OLVColumn colEnable;
        private System.Windows.Forms.Button btnRefreshTemplate;
        private System.Windows.Forms.ComboBox RTCTemplateName;
        private System.Windows.Forms.CheckBox RTCUseCameraSettings;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton RTCCameraMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox RTCIsBringImageToMain;
        private System.Windows.Forms.CheckBox RTCIsKeepImage;
        private ucProgramName ucProgramName1;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Button btnTest;
    }
}
