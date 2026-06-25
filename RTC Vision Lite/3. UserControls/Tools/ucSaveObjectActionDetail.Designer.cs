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
            this.ScrollableGeneral.Location = new System.Drawing.Point(5, 5);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1149, 501);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(5, 51);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PageSetup.Size = new System.Drawing.Size(1182, 519);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ROI.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ROI.Size = new System.Drawing.Size(1159, 511);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PassFail.Size = new System.Drawing.Size(1556, 644);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1556, 644);
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
            this.ScrollableROI.Location = new System.Drawing.Point(5, 5);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableROI.Size = new System.Drawing.Size(1149, 501);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Size = new System.Drawing.Size(1182, 46);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Method.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Method.Size = new System.Drawing.Size(1556, 644);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Display.Size = new System.Drawing.Size(1556, 644);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(5, 5);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableMethod.Size = new System.Drawing.Size(1546, 634);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Location = new System.Drawing.Point(5, 5);
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(1546, 634);
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
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Location = new System.Drawing.Point(77, 18);
            this.RTCName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(1053, 22);
            this.RTCName.TabIndex = 1;
            // 
            // ucObjectLink1
            // 
            this.ucObjectLink1.Location = new System.Drawing.Point(12, 40);
            this.ucObjectLink1.Name = "ucObjectLink1";
            this.ucObjectLink1.RTCAction = null;
            this.ucObjectLink1.RTCCaption = "Object";
            this.ucObjectLink1.RTCPropertyName = "InputObject";
            this.ucObjectLink1.Size = new System.Drawing.Size(624, 71);
            this.ucObjectLink1.TabIndex = 2;
            // 
            // RTCOutputFileName
            // 
            this.RTCOutputFileName.AutoSize = true;
            this.RTCOutputFileName.ForeColor = System.Drawing.Color.IndianRed;
            this.RTCOutputFileName.Location = new System.Drawing.Point(244, 407);
            this.RTCOutputFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RTCOutputFileName.Name = "RTCOutputFileName";
            this.RTCOutputFileName.Size = new System.Drawing.Size(98, 13);
            this.RTCOutputFileName.TabIndex = 14;
            this.RTCOutputFileName.Text = "Output File Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 401);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(27, 401);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 28);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panSaveImageSettings);
            this.groupBox2.Location = new System.Drawing.Point(27, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1107, 345);
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
            this.panSaveImageSettings.Location = new System.Drawing.Point(8, 26);
            this.panSaveImageSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panSaveImageSettings.Name = "panSaveImageSettings";
            this.panSaveImageSettings.Size = new System.Drawing.Size(1091, 311);
            this.panSaveImageSettings.TabIndex = 2;
            // 
            // RTCOverwriteWhenExists
            // 
            this.RTCOverwriteWhenExists.AutoSize = true;
            this.RTCOverwriteWhenExists.Location = new System.Drawing.Point(367, 256);
            this.RTCOverwriteWhenExists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.RTCSaveMode.Location = new System.Drawing.Point(147, 254);
            this.RTCSaveMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCSaveMode.Name = "RTCSaveMode";
            this.RTCSaveMode.Size = new System.Drawing.Size(204, 21);
            this.RTCSaveMode.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 257);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.panPrefixSuffixName.Location = new System.Drawing.Point(0, 119);
            this.panPrefixSuffixName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panPrefixSuffixName.Name = "panPrefixSuffixName";
            this.panPrefixSuffixName.Size = new System.Drawing.Size(1087, 128);
            this.panPrefixSuffixName.TabIndex = 5;
            // 
            // RTCIsAutoResetWhenNewSession
            // 
            this.RTCIsAutoResetWhenNewSession.AutoSize = true;
            this.RTCIsAutoResetWhenNewSession.Location = new System.Drawing.Point(368, 78);
            this.RTCIsAutoResetWhenNewSession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCIsAutoResetWhenNewSession.Name = "RTCIsAutoResetWhenNewSession";
            this.RTCIsAutoResetWhenNewSession.Size = new System.Drawing.Size(150, 17);
            this.RTCIsAutoResetWhenNewSession.TabIndex = 11;
            this.RTCIsAutoResetWhenNewSession.Text = "Auto Reset New Session";
            this.RTCIsAutoResetWhenNewSession.UseVisualStyleBackColor = true;
            // 
            // RTCResetNumber
            // 
            this.RTCResetNumber.Location = new System.Drawing.Point(733, 39);
            this.RTCResetNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCResetNumber.Name = "RTCResetNumber";
            this.RTCResetNumber.Size = new System.Drawing.Size(61, 22);
            this.RTCResetNumber.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(660, 43);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Reset To";
            // 
            // RTCMaxNumber
            // 
            this.RTCMaxNumber.Location = new System.Drawing.Point(524, 39);
            this.RTCMaxNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCMaxNumber.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.RTCMaxNumber.Name = "RTCMaxNumber";
            this.RTCMaxNumber.Size = new System.Drawing.Size(128, 22);
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
            this.label11.Location = new System.Drawing.Point(479, 43);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Max";
            // 
            // RTCStartNumber
            // 
            this.RTCStartNumber.Location = new System.Drawing.Point(409, 38);
            this.RTCStartNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCStartNumber.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.RTCStartNumber.Name = "RTCStartNumber";
            this.RTCStartNumber.Size = new System.Drawing.Size(61, 22);
            this.RTCStartNumber.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(364, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Start";
            // 
            // RTCDateTimeFormat
            // 
            this.RTCDateTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDateTimeFormat.FormattingEnabled = true;
            this.RTCDateTimeFormat.Location = new System.Drawing.Point(147, 73);
            this.RTCDateTimeFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCDateTimeFormat.Name = "RTCDateTimeFormat";
            this.RTCDateTimeFormat.Size = new System.Drawing.Size(204, 21);
            this.RTCDateTimeFormat.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 76);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "DateTime Format";
            // 
            // RTCSuffixNameMode
            // 
            this.RTCSuffixNameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSuffixNameMode.FormattingEnabled = true;
            this.RTCSuffixNameMode.Location = new System.Drawing.Point(147, 39);
            this.RTCSuffixNameMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCSuffixNameMode.Name = "RTCSuffixNameMode";
            this.RTCSuffixNameMode.Size = new System.Drawing.Size(204, 21);
            this.RTCSuffixNameMode.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 43);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Suffix Name";
            // 
            // ucLinkPrefixName
            // 
            this.ucLinkPrefixName.Location = new System.Drawing.Point(8, 4);
            this.ucLinkPrefixName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucLinkPrefixName.Name = "ucLinkPrefixName";
            this.ucLinkPrefixName.RTCAction = null;
            this.ucLinkPrefixName.RTCCanEditValue = false;
            this.ucLinkPrefixName.RTCCaption = "Prefix Name";
            this.ucLinkPrefixName.RTCCaptionWidth = 100;
            this.ucLinkPrefixName.RTCIsPreviewValue = true;
            this.ucLinkPrefixName.RTCIsUseGetFolderButton = false;
            this.ucLinkPrefixName.RTCPreviewValueWidth = 200;
            this.ucLinkPrefixName.RTCPropertyName = "PrefixName";
            this.ucLinkPrefixName.Size = new System.Drawing.Size(785, 27);
            this.ucLinkPrefixName.TabIndex = 1;
            // 
            // RTCFileName
            // 
            this.RTCFileName.Location = new System.Drawing.Point(213, 89);
            this.RTCFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCFileName.Name = "RTCFileName";
            this.RTCFileName.Size = new System.Drawing.Size(872, 22);
            this.RTCFileName.TabIndex = 4;
            // 
            // RTCDateFormat
            // 
            this.RTCDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDateFormat.FormattingEnabled = true;
            this.RTCDateFormat.Location = new System.Drawing.Point(587, 55);
            this.RTCDateFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCDateFormat.Name = "RTCDateFormat";
            this.RTCDateFormat.Size = new System.Drawing.Size(217, 21);
            this.RTCDateFormat.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "File Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 62);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Date Format";
            // 
            // RTCAutoCreateFolderByDate
            // 
            this.RTCAutoCreateFolderByDate.AutoSize = true;
            this.RTCAutoCreateFolderByDate.Location = new System.Drawing.Point(259, 60);
            this.RTCAutoCreateFolderByDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCAutoCreateFolderByDate.Name = "RTCAutoCreateFolderByDate";
            this.RTCAutoCreateFolderByDate.Size = new System.Drawing.Size(165, 17);
            this.RTCAutoCreateFolderByDate.TabIndex = 1;
            this.RTCAutoCreateFolderByDate.Text = "Auto Create Folder By Date";
            this.RTCAutoCreateFolderByDate.UseVisualStyleBackColor = true;
            // 
            // RTCFixedFileName
            // 
            this.RTCFixedFileName.AutoSize = true;
            this.RTCFixedFileName.Location = new System.Drawing.Point(92, 91);
            this.RTCFixedFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCFixedFileName.Name = "RTCFixedFileName";
            this.RTCFixedFileName.Size = new System.Drawing.Size(85, 17);
            this.RTCFixedFileName.TabIndex = 1;
            this.RTCFixedFileName.Text = "Fixed Name";
            this.RTCFixedFileName.UseVisualStyleBackColor = true;
            // 
            // RTCIsUseProjectFolder
            // 
            this.RTCIsUseProjectFolder.AutoSize = true;
            this.RTCIsUseProjectFolder.Location = new System.Drawing.Point(92, 60);
            this.RTCIsUseProjectFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCIsUseProjectFolder.Name = "RTCIsUseProjectFolder";
            this.RTCIsUseProjectFolder.Size = new System.Drawing.Size(119, 17);
            this.RTCIsUseProjectFolder.TabIndex = 1;
            this.RTCIsUseProjectFolder.Text = "Use Project Folder";
            this.RTCIsUseProjectFolder.UseVisualStyleBackColor = true;
            // 
            // ucLink1
            // 
            this.ucLink1.Location = new System.Drawing.Point(8, 7);
            this.ucLink1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucLink1.Name = "ucLink1";
            this.ucLink1.RTCAction = null;
            this.ucLink1.RTCCanEditValue = false;
            this.ucLink1.RTCCaption = "Folder";
            this.ucLink1.RTCCaptionWidth = 60;
            this.ucLink1.RTCIsPreviewValue = true;
            this.ucLink1.RTCIsUseGetFolderButton = true;
            this.ucLink1.RTCPreviewValueWidth = 200;
            this.ucLink1.RTCPropertyName = "FolderName";
            this.ucLink1.Size = new System.Drawing.Size(1077, 27);
            this.ucLink1.TabIndex = 0;
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.RTCErrMessage.Location = new System.Drawing.Point(184, 20);
            this.RTCErrMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 8;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(109, 20);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 9;
            this.RTCPassed.Text = "Passed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pass/Fail: ";
            // 
            // ucSaveObjectActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ucSaveObjectActionDetail";
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.ScrollableROI.ResumeLayout(false);
            this.ScrollableROI.PerformLayout();
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
