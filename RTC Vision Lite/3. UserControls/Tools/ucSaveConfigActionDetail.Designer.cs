namespace RTC_Vision_Lite.UserControls
{
    partial class ucSaveConfigActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSaveConfigActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.RTCErrMessage = new System.Windows.Forms.Label();
            this.ucLink1 = new RTC_Vision_Lite.UserControls.ucLink();
            this.RTCIsUseProjectFolder = new System.Windows.Forms.CheckBox();
            this.RTCAutoCreateFolderByDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RTCDateFormat = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RTCFixedFileName = new System.Windows.Forms.CheckBox();
            this.RTCFileName = new System.Windows.Forms.TextBox();
            this.RTCOverwriteWhenExists = new System.Windows.Forms.CheckBox();
            this.ucLink2 = new RTC_Vision_Lite.UserControls.ucLink();
            this.label6 = new System.Windows.Forms.Label();
            this.RTCSuffixNameMode = new System.Windows.Forms.ComboBox();
            this.RTCDateTimeFormat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RTCStartNumber = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.RTCMaxNumber = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.RTCResetNumber = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.RTCIsAutoResetWhenNewSession = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.RTCOutputFileName = new System.Windows.Forms.Label();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RTCStartNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCMaxNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCResetNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCOutputFileName);
            this.ScrollableROI.Controls.Add(this.btnReset);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.RTCErrMessage);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label2);
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
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(640, 22);
            this.RTCName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pass/Fail: ";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 0;
            this.RTCPassed.Text = "Passed";
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.RTCErrMessage.Location = new System.Drawing.Point(146, 16);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 0;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // ucLink1
            // 
            this.ucLink1.Location = new System.Drawing.Point(45, 22);
            this.ucLink1.Name = "ucLink1";
            this.ucLink1.RTCAction = null;
            this.ucLink1.RTCCanEditValue = false;
            this.ucLink1.RTCCaption = "Folder";
            this.ucLink1.RTCCaptionWidth = 100;
            this.ucLink1.RTCIsPreviewValue = true;
            this.ucLink1.RTCIsUseGetFolderButton = true;
            this.ucLink1.RTCPreviewValueWidth = 200;
            this.ucLink1.RTCPropertyName = "FolderName";
            this.ucLink1.Size = new System.Drawing.Size(766, 22);
            this.ucLink1.TabIndex = 0;
            // 
            // RTCIsUseProjectFolder
            // 
            this.RTCIsUseProjectFolder.AutoSize = true;
            this.RTCIsUseProjectFolder.Location = new System.Drawing.Point(111, 60);
            this.RTCIsUseProjectFolder.Name = "RTCIsUseProjectFolder";
            this.RTCIsUseProjectFolder.Size = new System.Drawing.Size(119, 17);
            this.RTCIsUseProjectFolder.TabIndex = 1;
            this.RTCIsUseProjectFolder.Text = "Use Project Folder";
            this.RTCIsUseProjectFolder.UseVisualStyleBackColor = true;
            // 
            // RTCAutoCreateFolderByDate
            // 
            this.RTCAutoCreateFolderByDate.AutoSize = true;
            this.RTCAutoCreateFolderByDate.Location = new System.Drawing.Point(236, 60);
            this.RTCAutoCreateFolderByDate.Name = "RTCAutoCreateFolderByDate";
            this.RTCAutoCreateFolderByDate.Size = new System.Drawing.Size(165, 17);
            this.RTCAutoCreateFolderByDate.TabIndex = 1;
            this.RTCAutoCreateFolderByDate.Text = "Auto Create Folder By Date";
            this.RTCAutoCreateFolderByDate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Date Format";
            // 
            // RTCDateFormat
            // 
            this.RTCDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDateFormat.FormattingEnabled = true;
            this.RTCDateFormat.Location = new System.Drawing.Point(482, 56);
            this.RTCDateFormat.Name = "RTCDateFormat";
            this.RTCDateFormat.Size = new System.Drawing.Size(150, 21);
            this.RTCDateFormat.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "File Name";
            // 
            // RTCFixedFileName
            // 
            this.RTCFixedFileName.AutoSize = true;
            this.RTCFixedFileName.Location = new System.Drawing.Point(111, 94);
            this.RTCFixedFileName.Name = "RTCFixedFileName";
            this.RTCFixedFileName.Size = new System.Drawing.Size(85, 17);
            this.RTCFixedFileName.TabIndex = 5;
            this.RTCFixedFileName.Text = "Fixed Name";
            this.RTCFixedFileName.UseVisualStyleBackColor = true;
            // 
            // RTCFileName
            // 
            this.RTCFileName.Location = new System.Drawing.Point(202, 89);
            this.RTCFileName.Name = "RTCFileName";
            this.RTCFileName.Size = new System.Drawing.Size(274, 22);
            this.RTCFileName.TabIndex = 6;
            // 
            // RTCOverwriteWhenExists
            // 
            this.RTCOverwriteWhenExists.AutoSize = true;
            this.RTCOverwriteWhenExists.Location = new System.Drawing.Point(482, 91);
            this.RTCOverwriteWhenExists.Name = "RTCOverwriteWhenExists";
            this.RTCOverwriteWhenExists.Size = new System.Drawing.Size(141, 17);
            this.RTCOverwriteWhenExists.TabIndex = 7;
            this.RTCOverwriteWhenExists.Text = "Overwrite When Exists";
            this.RTCOverwriteWhenExists.UseVisualStyleBackColor = true;
            // 
            // ucLink2
            // 
            this.ucLink2.Location = new System.Drawing.Point(44, 120);
            this.ucLink2.Name = "ucLink2";
            this.ucLink2.RTCAction = null;
            this.ucLink2.RTCCanEditValue = false;
            this.ucLink2.RTCCaption = "Prefix Name";
            this.ucLink2.RTCCaptionWidth = 100;
            this.ucLink2.RTCIsPreviewValue = true;
            this.ucLink2.RTCIsUseGetFolderButton = false;
            this.ucLink2.RTCPreviewValueWidth = 200;
            this.ucLink2.RTCPropertyName = "PrefixName";
            this.ucLink2.Size = new System.Drawing.Size(603, 24);
            this.ucLink2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Suffix Name";
            // 
            // RTCSuffixNameMode
            // 
            this.RTCSuffixNameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSuffixNameMode.FormattingEnabled = true;
            this.RTCSuffixNameMode.Location = new System.Drawing.Point(151, 161);
            this.RTCSuffixNameMode.Name = "RTCSuffixNameMode";
            this.RTCSuffixNameMode.Size = new System.Drawing.Size(152, 21);
            this.RTCSuffixNameMode.TabIndex = 10;
            // 
            // RTCDateTimeFormat
            // 
            this.RTCDateTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDateTimeFormat.FormattingEnabled = true;
            this.RTCDateTimeFormat.Location = new System.Drawing.Point(151, 197);
            this.RTCDateTimeFormat.Name = "RTCDateTimeFormat";
            this.RTCDateTimeFormat.Size = new System.Drawing.Size(152, 21);
            this.RTCDateTimeFormat.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Start";
            // 
            // RTCStartNumber
            // 
            this.RTCStartNumber.Location = new System.Drawing.Point(351, 161);
            this.RTCStartNumber.Name = "RTCStartNumber";
            this.RTCStartNumber.Size = new System.Drawing.Size(57, 22);
            this.RTCStartNumber.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(414, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Max";
            // 
            // RTCMaxNumber
            // 
            this.RTCMaxNumber.Location = new System.Drawing.Point(451, 160);
            this.RTCMaxNumber.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.RTCMaxNumber.Name = "RTCMaxNumber";
            this.RTCMaxNumber.Size = new System.Drawing.Size(57, 22);
            this.RTCMaxNumber.TabIndex = 14;
            this.RTCMaxNumber.Value = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(514, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Reset To";
            // 
            // RTCResetNumber
            // 
            this.RTCResetNumber.Location = new System.Drawing.Point(570, 160);
            this.RTCResetNumber.Name = "RTCResetNumber";
            this.RTCResetNumber.Size = new System.Drawing.Size(57, 22);
            this.RTCResetNumber.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "DateTime Format";
            // 
            // RTCIsAutoResetWhenNewSession
            // 
            this.RTCIsAutoResetWhenNewSession.AutoSize = true;
            this.RTCIsAutoResetWhenNewSession.Location = new System.Drawing.Point(315, 199);
            this.RTCIsAutoResetWhenNewSession.Name = "RTCIsAutoResetWhenNewSession";
            this.RTCIsAutoResetWhenNewSession.Size = new System.Drawing.Size(150, 17);
            this.RTCIsAutoResetWhenNewSession.TabIndex = 18;
            this.RTCIsAutoResetWhenNewSession.Text = "Auto Reset New Session";
            this.RTCIsAutoResetWhenNewSession.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCIsAutoResetWhenNewSession);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.RTCResetNumber);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.RTCMaxNumber);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.RTCStartNumber);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.RTCDateTimeFormat);
            this.groupBox1.Controls.Add(this.RTCSuffixNameMode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ucLink2);
            this.groupBox1.Controls.Add(this.RTCOverwriteWhenExists);
            this.groupBox1.Controls.Add(this.RTCFileName);
            this.groupBox1.Controls.Add(this.RTCFixedFileName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RTCDateFormat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RTCAutoCreateFolderByDate);
            this.groupBox1.Controls.Add(this.RTCIsUseProjectFolder);
            this.groupBox1.Controls.Add(this.ucLink1);
            this.groupBox1.Location = new System.Drawing.Point(20, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(818, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Object Settings";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(20, 286);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(104, 286);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // RTCOutputFileName
            // 
            this.RTCOutputFileName.AutoSize = true;
            this.RTCOutputFileName.ForeColor = System.Drawing.Color.IndianRed;
            this.RTCOutputFileName.Location = new System.Drawing.Point(185, 291);
            this.RTCOutputFileName.Name = "RTCOutputFileName";
            this.RTCOutputFileName.Size = new System.Drawing.Size(98, 13);
            this.RTCOutputFileName.TabIndex = 3;
            this.RTCOutputFileName.Text = "Output File Name";
            // 
            // ucSaveConfigActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucSaveConfigActionDetail";
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
            ((System.ComponentModel.ISupportInitialize)(this.RTCStartNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCMaxNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCResetNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Label RTCOutputFileName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox RTCIsAutoResetWhenNewSession;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown RTCResetNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown RTCMaxNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown RTCStartNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox RTCDateTimeFormat;
        private System.Windows.Forms.ComboBox RTCSuffixNameMode;
        private System.Windows.Forms.Label label6;
        private ucLink ucLink2;
        private System.Windows.Forms.CheckBox RTCOverwriteWhenExists;
        private System.Windows.Forms.TextBox RTCFileName;
        private System.Windows.Forms.CheckBox RTCFixedFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox RTCDateFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RTCAutoCreateFolderByDate;
        private System.Windows.Forms.CheckBox RTCIsUseProjectFolder;
        private ucLink ucLink1;
    }
}
