using RTC_Vision_Lite.Properties;

namespace RTC_Vision_Lite.UserControls
{
    partial class ucSaveObjectActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSaveObjectActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.ucObjectLink1 = new RTC_Vision_Lite.UserControls.ucObjectLink();
            this.RTCOutputFileName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panSaveImageSettings = new System.Windows.Forms.Panel();
            this.RTCOverwriteWhenExists = new System.Windows.Forms.CheckBox();
            this.RTCSaveMode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panPrefixSuffixName = new System.Windows.Forms.Panel();
            this.RTCIsAutoResetWhenNewSession = new System.Windows.Forms.CheckBox();
            this.RTCResetNumber = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.RTCMaxNumber = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.RTCStartNumber = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.RTCDateTimeFormat = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RTCSuffixNameMode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ucLinkPrefixName = new RTC_Vision_Lite.UserControls.ucLink();
            this.RTCFileName = new System.Windows.Forms.TextBox();
            this.RTCDateFormat = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RTCAutoCreateFolderByDate = new System.Windows.Forms.CheckBox();
            this.RTCFixedFileName = new System.Windows.Forms.CheckBox();
            this.RTCIsUseProjectFolder = new System.Windows.Forms.CheckBox();
            this.ucLink1 = new RTC_Vision_Lite.UserControls.ucLink();
            this.RTCErrMessage = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panSaveImageSettings.SuspendLayout();
            this.panPrefixSuffixName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RTCResetNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCMaxNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCStartNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucObjectLink1);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(4, 4);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableGeneral.Size = new System.Drawing.Size(853, 401);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(4, 41);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(2);
            this.PageSetup.Size = new System.Drawing.Size(884, 417);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(4);
            this.ROI.Padding = new System.Windows.Forms.Padding(4);
            this.ROI.Size = new System.Drawing.Size(861, 409);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(4);
            this.PassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollablePassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCOutputFileName);
            this.ScrollableROI.Controls.Add(this.button1);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.groupBox2);
            this.ScrollableROI.Controls.Add(this.RTCErrMessage);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label2);
            this.ScrollableROI.Location = new System.Drawing.Point(4, 4);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableROI.Size = new System.Drawing.Size(853, 401);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(884, 37);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(4);
            this.General.Padding = new System.Windows.Forms.Padding(4);
            this.General.Size = new System.Drawing.Size(861, 409);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(4);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(4);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(4);
            this.Method.Padding = new System.Windows.Forms.Padding(4);
            this.Method.Size = new System.Drawing.Size(861, 409);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(4);
            this.Display.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(4, 4);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableMethod.Size = new System.Drawing.Size(853, 401);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(855, 403);
            // 
            // Selecticon
            // 
            this.Selecticon.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.Selecticon.ImageSize = new System.Drawing.Size(16, 16);
            this.Selecticon.ImageStream = null;
            // 
            // imlLinkSummary
            // 
            this.imlLinkSummary.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLinkSummary.ImageStream")));
            this.imlLinkSummary.Images.SetKeyName(0, "Right");
            this.imlLinkSummary.Images.SetKeyName(1, "Left");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(791, 22);
            this.RTCName.TabIndex = 1;
            // 
            // ucObjectLink1
            // 
            this.ucObjectLink1.Location = new System.Drawing.Point(16, 49);
            this.ucObjectLink1.Name = "ucObjectLink1";
            this.ucObjectLink1.RTCAction = null;
            this.ucObjectLink1.RTCCaption = "Object";
            this.ucObjectLink1.RTCPropertyName = "InputObject";
            this.ucObjectLink1.Size = new System.Drawing.Size(832, 87);
            this.ucObjectLink1.TabIndex = 2;
            // 
            // RTCOutputFileName
            // 
            this.RTCOutputFileName.AutoSize = true;
            this.RTCOutputFileName.ForeColor = System.Drawing.Color.IndianRed;
            this.RTCOutputFileName.Location = new System.Drawing.Point(183, 331);
            this.RTCOutputFileName.Name = "RTCOutputFileName";
            this.RTCOutputFileName.Size = new System.Drawing.Size(98, 13);
            this.RTCOutputFileName.TabIndex = 14;
            this.RTCOutputFileName.Text = "Output File Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(20, 326);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panSaveImageSettings);
            this.groupBox2.Location = new System.Drawing.Point(20, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(830, 280);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save Image Settings";
            // 
            // panSaveImageSettings
            // 
            this.panSaveImageSettings.Controls.Add(this.RTCOverwriteWhenExists);
            this.panSaveImageSettings.Controls.Add(this.RTCSaveMode);
            this.panSaveImageSettings.Controls.Add(this.label14);
            this.panSaveImageSettings.Controls.Add(this.panPrefixSuffixName);
            this.panSaveImageSettings.Controls.Add(this.RTCFileName);
            this.panSaveImageSettings.Controls.Add(this.RTCDateFormat);
            this.panSaveImageSettings.Controls.Add(this.label8);
            this.panSaveImageSettings.Controls.Add(this.label7);
            this.panSaveImageSettings.Controls.Add(this.RTCAutoCreateFolderByDate);
            this.panSaveImageSettings.Controls.Add(this.RTCFixedFileName);
            this.panSaveImageSettings.Controls.Add(this.RTCIsUseProjectFolder);
            this.panSaveImageSettings.Controls.Add(this.ucLink1);
            this.panSaveImageSettings.Location = new System.Drawing.Point(6, 21);
            this.panSaveImageSettings.Name = "panSaveImageSettings";
            this.panSaveImageSettings.Size = new System.Drawing.Size(818, 253);
            this.panSaveImageSettings.TabIndex = 2;
            // 
            // RTCOverwriteWhenExists
            // 
            this.RTCOverwriteWhenExists.AutoSize = true;
            this.RTCOverwriteWhenExists.Location = new System.Drawing.Point(275, 208);
            this.RTCOverwriteWhenExists.Name = "RTCOverwriteWhenExists";
            this.RTCOverwriteWhenExists.Size = new System.Drawing.Size(141, 17);
            this.RTCOverwriteWhenExists.TabIndex = 12;
            this.RTCOverwriteWhenExists.Text = "Overwrite When Exists";
            this.RTCOverwriteWhenExists.UseVisualStyleBackColor = true;
            // 
            // RTCSaveMode
            // 
            this.RTCSaveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSaveMode.FormattingEnabled = true;
            this.RTCSaveMode.Location = new System.Drawing.Point(110, 206);
            this.RTCSaveMode.Name = "RTCSaveMode";
            this.RTCSaveMode.Size = new System.Drawing.Size(154, 21);
            this.RTCSaveMode.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 209);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Save Mode";
            // 
            // panPrefixSuffixName
            // 
            this.panPrefixSuffixName.Controls.Add(this.RTCIsAutoResetWhenNewSession);
            this.panPrefixSuffixName.Controls.Add(this.RTCResetNumber);
            this.panPrefixSuffixName.Controls.Add(this.label12);
            this.panPrefixSuffixName.Controls.Add(this.RTCMaxNumber);
            this.panPrefixSuffixName.Controls.Add(this.label11);
            this.panPrefixSuffixName.Controls.Add(this.RTCStartNumber);
            this.panPrefixSuffixName.Controls.Add(this.label10);
            this.panPrefixSuffixName.Controls.Add(this.RTCDateTimeFormat);
            this.panPrefixSuffixName.Controls.Add(this.label13);
            this.panPrefixSuffixName.Controls.Add(this.RTCSuffixNameMode);
            this.panPrefixSuffixName.Controls.Add(this.label9);
            this.panPrefixSuffixName.Controls.Add(this.ucLinkPrefixName);
            this.panPrefixSuffixName.Location = new System.Drawing.Point(0, 97);
            this.panPrefixSuffixName.Name = "panPrefixSuffixName";
            this.panPrefixSuffixName.Size = new System.Drawing.Size(815, 104);
            this.panPrefixSuffixName.TabIndex = 5;
            // 
            // RTCIsAutoResetWhenNewSession
            // 
            this.RTCIsAutoResetWhenNewSession.AutoSize = true;
            this.RTCIsAutoResetWhenNewSession.Location = new System.Drawing.Point(276, 63);
            this.RTCIsAutoResetWhenNewSession.Name = "RTCIsAutoResetWhenNewSession";
            this.RTCIsAutoResetWhenNewSession.Size = new System.Drawing.Size(150, 17);
            this.RTCIsAutoResetWhenNewSession.TabIndex = 11;
            this.RTCIsAutoResetWhenNewSession.Text = "Auto Reset New Session";
            this.RTCIsAutoResetWhenNewSession.UseVisualStyleBackColor = true;
            // 
            // RTCResetNumber
            // 
            this.RTCResetNumber.Location = new System.Drawing.Point(550, 32);
            this.RTCResetNumber.Name = "RTCResetNumber";
            this.RTCResetNumber.Size = new System.Drawing.Size(46, 22);
            this.RTCResetNumber.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(495, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Reset To";
            // 
            // RTCMaxNumber
            // 
            this.RTCMaxNumber.Location = new System.Drawing.Point(393, 32);
            this.RTCMaxNumber.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.RTCMaxNumber.Name = "RTCMaxNumber";
            this.RTCMaxNumber.Size = new System.Drawing.Size(96, 22);
            this.RTCMaxNumber.TabIndex = 8;
            this.RTCMaxNumber.Value = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(359, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Max";
            // 
            // RTCStartNumber
            // 
            this.RTCStartNumber.Location = new System.Drawing.Point(307, 31);
            this.RTCStartNumber.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.RTCStartNumber.Name = "RTCStartNumber";
            this.RTCStartNumber.Size = new System.Drawing.Size(46, 22);
            this.RTCStartNumber.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Start";
            // 
            // RTCDateTimeFormat
            // 
            this.RTCDateTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDateTimeFormat.FormattingEnabled = true;
            this.RTCDateTimeFormat.Location = new System.Drawing.Point(110, 59);
            this.RTCDateTimeFormat.Name = "RTCDateTimeFormat";
            this.RTCDateTimeFormat.Size = new System.Drawing.Size(154, 21);
            this.RTCDateTimeFormat.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "DateTime Format";
            // 
            // RTCSuffixNameMode
            // 
            this.RTCSuffixNameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSuffixNameMode.FormattingEnabled = true;
            this.RTCSuffixNameMode.Location = new System.Drawing.Point(110, 32);
            this.RTCSuffixNameMode.Name = "RTCSuffixNameMode";
            this.RTCSuffixNameMode.Size = new System.Drawing.Size(154, 21);
            this.RTCSuffixNameMode.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Suffix Name";
            // 
            // ucLinkPrefixName
            // 
            this.ucLinkPrefixName.Location = new System.Drawing.Point(6, 3);
            this.ucLinkPrefixName.Margin = new System.Windows.Forms.Padding(4);
            this.ucLinkPrefixName.Name = "ucLinkPrefixName";
            this.ucLinkPrefixName.RTCAction = null;
            this.ucLinkPrefixName.RTCCanEditValue = false;
            this.ucLinkPrefixName.RTCCaption = "Prefix Name";
            this.ucLinkPrefixName.RTCCaptionWidth = 100;
            this.ucLinkPrefixName.RTCIsPreviewValue = true;
            this.ucLinkPrefixName.RTCIsUseGetFolderButton = false;
            this.ucLinkPrefixName.RTCPreviewValueWidth = 200;
            this.ucLinkPrefixName.RTCPropertyName = "PrefixName";
            this.ucLinkPrefixName.Size = new System.Drawing.Size(589, 22);
            this.ucLinkPrefixName.TabIndex = 1;
            // 
            // RTCFileName
            // 
            this.RTCFileName.Location = new System.Drawing.Point(160, 72);
            this.RTCFileName.Name = "RTCFileName";
            this.RTCFileName.Size = new System.Drawing.Size(655, 22);
            this.RTCFileName.TabIndex = 4;
            // 
            // RTCDateFormat
            // 
            this.RTCDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDateFormat.FormattingEnabled = true;
            this.RTCDateFormat.Location = new System.Drawing.Point(440, 45);
            this.RTCDateFormat.Name = "RTCDateFormat";
            this.RTCDateFormat.Size = new System.Drawing.Size(164, 21);
            this.RTCDateFormat.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "File Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Date Format";
            // 
            // RTCAutoCreateFolderByDate
            // 
            this.RTCAutoCreateFolderByDate.AutoSize = true;
            this.RTCAutoCreateFolderByDate.Location = new System.Drawing.Point(194, 49);
            this.RTCAutoCreateFolderByDate.Name = "RTCAutoCreateFolderByDate";
            this.RTCAutoCreateFolderByDate.Size = new System.Drawing.Size(165, 17);
            this.RTCAutoCreateFolderByDate.TabIndex = 1;
            this.RTCAutoCreateFolderByDate.Text = "Auto Create Folder By Date";
            this.RTCAutoCreateFolderByDate.UseVisualStyleBackColor = true;
            // 
            // RTCFixedFileName
            // 
            this.RTCFixedFileName.AutoSize = true;
            this.RTCFixedFileName.Location = new System.Drawing.Point(69, 74);
            this.RTCFixedFileName.Name = "RTCFixedFileName";
            this.RTCFixedFileName.Size = new System.Drawing.Size(85, 17);
            this.RTCFixedFileName.TabIndex = 1;
            this.RTCFixedFileName.Text = "Fixed Name";
            this.RTCFixedFileName.UseVisualStyleBackColor = true;
            // 
            // RTCIsUseProjectFolder
            // 
            this.RTCIsUseProjectFolder.AutoSize = true;
            this.RTCIsUseProjectFolder.Location = new System.Drawing.Point(69, 49);
            this.RTCIsUseProjectFolder.Name = "RTCIsUseProjectFolder";
            this.RTCIsUseProjectFolder.Size = new System.Drawing.Size(119, 17);
            this.RTCIsUseProjectFolder.TabIndex = 1;
            this.RTCIsUseProjectFolder.Text = "Use Project Folder";
            this.RTCIsUseProjectFolder.UseVisualStyleBackColor = true;
            // 
            // ucLink1
            // 
            this.ucLink1.Location = new System.Drawing.Point(6, 6);
            this.ucLink1.Margin = new System.Windows.Forms.Padding(4);
            this.ucLink1.Name = "ucLink1";
            this.ucLink1.RTCAction = null;
            this.ucLink1.RTCCanEditValue = false;
            this.ucLink1.RTCCaption = "Folder";
            this.ucLink1.RTCCaptionWidth = 60;
            this.ucLink1.RTCIsPreviewValue = true;
            this.ucLink1.RTCIsUseGetFolderButton = true;
            this.ucLink1.RTCPreviewValueWidth = 200;
            this.ucLink1.RTCPropertyName = "FolderName";
            this.ucLink1.Size = new System.Drawing.Size(808, 22);
            this.ucLink1.TabIndex = 0;
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.RTCErrMessage.Location = new System.Drawing.Point(138, 16);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 8;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 9;
            this.RTCPassed.Text = "Passed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pass/Fail: ";
            // 
            // ucSaveObjectActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucSaveObjectActionDetail";
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
            this.panSaveImageSettings.ResumeLayout(false);
            this.panSaveImageSettings.PerformLayout();
            this.panPrefixSuffixName.ResumeLayout(false);
            this.panPrefixSuffixName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RTCResetNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCMaxNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCStartNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RTCName;
        private ucObjectLink ucObjectLink1;
        private System.Windows.Forms.Label RTCOutputFileName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panSaveImageSettings;
        private System.Windows.Forms.CheckBox RTCOverwriteWhenExists;
        private System.Windows.Forms.ComboBox RTCSaveMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panPrefixSuffixName;
        private System.Windows.Forms.CheckBox RTCIsAutoResetWhenNewSession;
        private System.Windows.Forms.NumericUpDown RTCResetNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown RTCMaxNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown RTCStartNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox RTCDateTimeFormat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox RTCSuffixNameMode;
        private System.Windows.Forms.Label label9;
        private ucLink ucLinkPrefixName;
        private System.Windows.Forms.TextBox RTCFileName;
        private System.Windows.Forms.ComboBox RTCDateFormat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox RTCAutoCreateFolderByDate;
        private System.Windows.Forms.CheckBox RTCFixedFileName;
        private System.Windows.Forms.CheckBox RTCIsUseProjectFolder;
        private ucLink ucLink1;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label2;
    }
}
