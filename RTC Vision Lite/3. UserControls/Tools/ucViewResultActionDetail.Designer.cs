
namespace RTC_Vision_Lite.UserControls
{
    partial class ucViewResultActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucViewResultActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucProgramName1 = new RTC_Vision_Lite.UserControls.ucProgramName();
            this.RTCIsMasterView = new System.Windows.Forms.CheckBox();
            this.RTCResultOK = new System.Windows.Forms.CheckBox();
            this.RTCResultMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RTCIsRunByRunOrder = new System.Windows.Forms.CheckBox();
            this.RTCViewIn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panSaveImageSettings = new System.Windows.Forms.Panel();
            this.RTCOverwriteWhenExists = new System.Windows.Forms.CheckBox();
            this.RTCSaveMode = new System.Windows.Forms.ComboBox();
            this.RTCImageTypes = new System.Windows.Forms.ComboBox();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.RTCResizePercentage = new System.Windows.Forms.TextBox();
            this.RTCIsResize = new System.Windows.Forms.CheckBox();
            this.RTCOnlyNG = new System.Windows.Forms.CheckBox();
            this.RTCIsSaveScreenshot = new System.Windows.Forms.CheckBox();
            this.RTCIsSaveGraphicWindow = new System.Windows.Forms.CheckBox();
            this.RTCIsSaveOriginImage = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.RTCOutputFileName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panSaveImageSettings.SuspendLayout();
            this.panPrefixSuffixName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RTCResetNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCMaxNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCStartNumber)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(4);
            this.PageActionSetting.Size = new System.Drawing.Size(900, 576);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label4);
            this.ScrollableGeneral.Location = new System.Drawing.Point(4, 4);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableGeneral.Size = new System.Drawing.Size(853, 489);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(4, 41);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(4);
            this.PageSetup.Size = new System.Drawing.Size(884, 505);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(4);
            this.ROI.Padding = new System.Windows.Forms.Padding(4);
            this.ROI.Size = new System.Drawing.Size(861, 497);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(4);
            this.PassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCOutputFileName);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.groupBox2);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label1);
            this.ScrollableROI.Location = new System.Drawing.Point(4, 4);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableROI.Size = new System.Drawing.Size(853, 489);
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
            this.General.Size = new System.Drawing.Size(861, 497);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(4);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(4);
            this.TabSetUp.Size = new System.Drawing.Size(892, 550);
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
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableMethod.Size = new System.Drawing.Size(853, 401);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(855, 403);
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
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pass/Fail: ";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucProgramName1);
            this.groupBox1.Controls.Add(this.RTCIsMasterView);
            this.groupBox1.Controls.Add(this.RTCResultOK);
            this.groupBox1.Controls.Add(this.RTCResultMode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RTCIsRunByRunOrder);
            this.groupBox1.Controls.Add(this.RTCViewIn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(17, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // ucProgramName1
            // 
            this.ucProgramName1.Location = new System.Drawing.Point(104, 45);
            this.ucProgramName1.Margin = new System.Windows.Forms.Padding(4);
            this.ucProgramName1.Name = "ucProgramName1";
            this.ucProgramName1.ProgramName = "";
            this.ucProgramName1.RTCAction = null;
            this.ucProgramName1.RTCCaptionWidth = 0F;
            this.ucProgramName1.RTCIsMultiChoose = false;
            this.ucProgramName1.RTCIsUseCaption = false;
            this.ucProgramName1.RTCIsUseThisCam = true;
            this.ucProgramName1.RTCPropertyName = "ProgramName";
            this.ucProgramName1.Size = new System.Drawing.Size(303, 27);
            this.ucProgramName1.TabIndex = 7;
            // 
            // RTCIsMasterView
            // 
            this.RTCIsMasterView.AutoSize = true;
            this.RTCIsMasterView.Location = new System.Drawing.Point(480, 80);
            this.RTCIsMasterView.Name = "RTCIsMasterView";
            this.RTCIsMasterView.Size = new System.Drawing.Size(89, 17);
            this.RTCIsMasterView.TabIndex = 6;
            this.RTCIsMasterView.Text = "Master View";
            this.RTCIsMasterView.UseVisualStyleBackColor = true;
            // 
            // RTCResultOK
            // 
            this.RTCResultOK.AutoSize = true;
            this.RTCResultOK.Location = new System.Drawing.Point(414, 80);
            this.RTCResultOK.Name = "RTCResultOK";
            this.RTCResultOK.Size = new System.Drawing.Size(61, 17);
            this.RTCResultOK.TabIndex = 5;
            this.RTCResultOK.Text = "Passed";
            this.RTCResultOK.UseVisualStyleBackColor = true;
            // 
            // RTCResultMode
            // 
            this.RTCResultMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCResultMode.FormattingEnabled = true;
            this.RTCResultMode.Location = new System.Drawing.Point(107, 78);
            this.RTCResultMode.Name = "RTCResultMode";
            this.RTCResultMode.Size = new System.Drawing.Size(297, 21);
            this.RTCResultMode.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Result";
            // 
            // RTCIsRunByRunOrder
            // 
            this.RTCIsRunByRunOrder.AutoSize = true;
            this.RTCIsRunByRunOrder.Location = new System.Drawing.Point(413, 21);
            this.RTCIsRunByRunOrder.Name = "RTCIsRunByRunOrder";
            this.RTCIsRunByRunOrder.Size = new System.Drawing.Size(119, 17);
            this.RTCIsRunByRunOrder.TabIndex = 2;
            this.RTCIsRunByRunOrder.Text = "Run By Run Order";
            this.RTCIsRunByRunOrder.UseVisualStyleBackColor = true;
            // 
            // RTCViewIn
            // 
            this.RTCViewIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCViewIn.FormattingEnabled = true;
            this.RTCViewIn.Location = new System.Drawing.Point(107, 18);
            this.RTCViewIn.Name = "RTCViewIn";
            this.RTCViewIn.Size = new System.Drawing.Size(297, 21);
            this.RTCViewIn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Program";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "View In";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panSaveImageSettings);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.RTCOnlyNG);
            this.groupBox2.Controls.Add(this.RTCIsSaveScreenshot);
            this.groupBox2.Controls.Add(this.RTCIsSaveGraphicWindow);
            this.groupBox2.Controls.Add(this.RTCIsSaveOriginImage);
            this.groupBox2.Location = new System.Drawing.Point(18, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(821, 280);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save Image Settings";
            // 
            // panSaveImageSettings
            // 
            this.panSaveImageSettings.Controls.Add(this.RTCOverwriteWhenExists);
            this.panSaveImageSettings.Controls.Add(this.RTCSaveMode);
            this.panSaveImageSettings.Controls.Add(this.RTCImageTypes);
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
            this.panSaveImageSettings.Location = new System.Drawing.Point(6, 44);
            this.panSaveImageSettings.Name = "panSaveImageSettings";
            this.panSaveImageSettings.Size = new System.Drawing.Size(809, 230);
            this.panSaveImageSettings.TabIndex = 2;
            // 
            // RTCOverwriteWhenExists
            // 
            this.RTCOverwriteWhenExists.AutoSize = true;
            this.RTCOverwriteWhenExists.Location = new System.Drawing.Point(335, 193);
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
            this.RTCSaveMode.Location = new System.Drawing.Point(244, 191);
            this.RTCSaveMode.Name = "RTCSaveMode";
            this.RTCSaveMode.Size = new System.Drawing.Size(85, 21);
            this.RTCSaveMode.TabIndex = 7;
            // 
            // RTCImageTypes
            // 
            this.RTCImageTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCImageTypes.FormattingEnabled = true;
            this.RTCImageTypes.Location = new System.Drawing.Point(84, 191);
            this.RTCImageTypes.Name = "RTCImageTypes";
            this.RTCImageTypes.Size = new System.Drawing.Size(154, 21);
            this.RTCImageTypes.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 194);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Image Type";
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
            this.panPrefixSuffixName.Location = new System.Drawing.Point(6, 82);
            this.panPrefixSuffixName.Name = "panPrefixSuffixName";
            this.panPrefixSuffixName.Size = new System.Drawing.Size(798, 104);
            this.panPrefixSuffixName.TabIndex = 5;
            // 
            // RTCIsAutoResetWhenNewSession
            // 
            this.RTCIsAutoResetWhenNewSession.AutoSize = true;
            this.RTCIsAutoResetWhenNewSession.Location = new System.Drawing.Point(272, 72);
            this.RTCIsAutoResetWhenNewSession.Name = "RTCIsAutoResetWhenNewSession";
            this.RTCIsAutoResetWhenNewSession.Size = new System.Drawing.Size(150, 17);
            this.RTCIsAutoResetWhenNewSession.TabIndex = 11;
            this.RTCIsAutoResetWhenNewSession.Text = "Auto Reset New Session";
            this.RTCIsAutoResetWhenNewSession.UseVisualStyleBackColor = true;
            // 
            // RTCResetNumber
            // 
            this.RTCResetNumber.Location = new System.Drawing.Point(549, 42);
            this.RTCResetNumber.Name = "RTCResetNumber";
            this.RTCResetNumber.Size = new System.Drawing.Size(46, 22);
            this.RTCResetNumber.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(494, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Reset To";
            // 
            // RTCMaxNumber
            // 
            this.RTCMaxNumber.Location = new System.Drawing.Point(392, 42);
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
            this.label11.Location = new System.Drawing.Point(358, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Max";
            // 
            // RTCStartNumber
            // 
            this.RTCStartNumber.Location = new System.Drawing.Point(310, 41);
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
            this.label10.Location = new System.Drawing.Point(269, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Start";
            // 
            // RTCDateTimeFormat
            // 
            this.RTCDateTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDateTimeFormat.FormattingEnabled = true;
            this.RTCDateTimeFormat.Location = new System.Drawing.Point(109, 69);
            this.RTCDateTimeFormat.Name = "RTCDateTimeFormat";
            this.RTCDateTimeFormat.Size = new System.Drawing.Size(154, 21);
            this.RTCDateTimeFormat.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "DateTime Format";
            // 
            // RTCSuffixNameMode
            // 
            this.RTCSuffixNameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSuffixNameMode.FormattingEnabled = true;
            this.RTCSuffixNameMode.Location = new System.Drawing.Point(109, 42);
            this.RTCSuffixNameMode.Name = "RTCSuffixNameMode";
            this.RTCSuffixNameMode.Size = new System.Drawing.Size(154, 21);
            this.RTCSuffixNameMode.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Suffix Name";
            // 
            // ucLinkPrefixName
            // 
            this.ucLinkPrefixName.Location = new System.Drawing.Point(6, 6);
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
            this.ucLinkPrefixName.Size = new System.Drawing.Size(592, 22);
            this.ucLinkPrefixName.TabIndex = 1;
            // 
            // RTCFileName
            // 
            this.RTCFileName.Location = new System.Drawing.Point(160, 57);
            this.RTCFileName.Name = "RTCFileName";
            this.RTCFileName.Size = new System.Drawing.Size(644, 22);
            this.RTCFileName.TabIndex = 4;
            // 
            // RTCDateFormat
            // 
            this.RTCDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDateFormat.FormattingEnabled = true;
            this.RTCDateFormat.Location = new System.Drawing.Point(440, 30);
            this.RTCDateFormat.Name = "RTCDateFormat";
            this.RTCDateFormat.Size = new System.Drawing.Size(164, 21);
            this.RTCDateFormat.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "File Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Date Format";
            // 
            // RTCAutoCreateFolderByDate
            // 
            this.RTCAutoCreateFolderByDate.AutoSize = true;
            this.RTCAutoCreateFolderByDate.Location = new System.Drawing.Point(194, 34);
            this.RTCAutoCreateFolderByDate.Name = "RTCAutoCreateFolderByDate";
            this.RTCAutoCreateFolderByDate.Size = new System.Drawing.Size(165, 17);
            this.RTCAutoCreateFolderByDate.TabIndex = 1;
            this.RTCAutoCreateFolderByDate.Text = "Auto Create Folder By Date";
            this.RTCAutoCreateFolderByDate.UseVisualStyleBackColor = true;
            // 
            // RTCFixedFileName
            // 
            this.RTCFixedFileName.AutoSize = true;
            this.RTCFixedFileName.Location = new System.Drawing.Point(69, 59);
            this.RTCFixedFileName.Name = "RTCFixedFileName";
            this.RTCFixedFileName.Size = new System.Drawing.Size(85, 17);
            this.RTCFixedFileName.TabIndex = 1;
            this.RTCFixedFileName.Text = "Fixed Name";
            this.RTCFixedFileName.UseVisualStyleBackColor = true;
            // 
            // RTCIsUseProjectFolder
            // 
            this.RTCIsUseProjectFolder.AutoSize = true;
            this.RTCIsUseProjectFolder.Location = new System.Drawing.Point(69, 34);
            this.RTCIsUseProjectFolder.Name = "RTCIsUseProjectFolder";
            this.RTCIsUseProjectFolder.Size = new System.Drawing.Size(119, 17);
            this.RTCIsUseProjectFolder.TabIndex = 1;
            this.RTCIsUseProjectFolder.Text = "Use Project Folder";
            this.RTCIsUseProjectFolder.UseVisualStyleBackColor = true;
            // 
            // ucLink1
            // 
            this.ucLink1.Location = new System.Drawing.Point(6, 3);
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
            this.ucLink1.Size = new System.Drawing.Size(598, 22);
            this.ucLink1.TabIndex = 0;
            this.ucLink1.Load += new System.EventHandler(this.ucLink1_Load);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.RTCResizePercentage);
            this.panel2.Controls.Add(this.RTCIsResize);
            this.panel2.Location = new System.Drawing.Point(430, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 27);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "%";
            // 
            // RTCResizePercentage
            // 
            this.RTCResizePercentage.Location = new System.Drawing.Point(76, 4);
            this.RTCResizePercentage.Name = "RTCResizePercentage";
            this.RTCResizePercentage.Size = new System.Drawing.Size(52, 22);
            this.RTCResizePercentage.TabIndex = 1;
            // 
            // RTCIsResize
            // 
            this.RTCIsResize.AutoSize = true;
            this.RTCIsResize.Location = new System.Drawing.Point(12, 6);
            this.RTCIsResize.Name = "RTCIsResize";
            this.RTCIsResize.Size = new System.Drawing.Size(58, 17);
            this.RTCIsResize.TabIndex = 0;
            this.RTCIsResize.Text = "Resize";
            this.RTCIsResize.UseVisualStyleBackColor = true;
            // 
            // RTCOnlyNG
            // 
            this.RTCOnlyNG.AutoSize = true;
            this.RTCOnlyNG.Location = new System.Drawing.Point(363, 21);
            this.RTCOnlyNG.Name = "RTCOnlyNG";
            this.RTCOnlyNG.Size = new System.Drawing.Size(69, 17);
            this.RTCOnlyNG.TabIndex = 0;
            this.RTCOnlyNG.Text = "Only NG";
            this.RTCOnlyNG.UseVisualStyleBackColor = true;
            // 
            // RTCIsSaveScreenshot
            // 
            this.RTCIsSaveScreenshot.AutoSize = true;
            this.RTCIsSaveScreenshot.Location = new System.Drawing.Point(248, 21);
            this.RTCIsSaveScreenshot.Name = "RTCIsSaveScreenshot";
            this.RTCIsSaveScreenshot.Size = new System.Drawing.Size(109, 17);
            this.RTCIsSaveScreenshot.TabIndex = 0;
            this.RTCIsSaveScreenshot.Text = "Save Screenshot";
            this.RTCIsSaveScreenshot.UseVisualStyleBackColor = true;
            // 
            // RTCIsSaveGraphicWindow
            // 
            this.RTCIsSaveGraphicWindow.AutoSize = true;
            this.RTCIsSaveGraphicWindow.Location = new System.Drawing.Point(103, 21);
            this.RTCIsSaveGraphicWindow.Name = "RTCIsSaveGraphicWindow";
            this.RTCIsSaveGraphicWindow.Size = new System.Drawing.Size(139, 17);
            this.RTCIsSaveGraphicWindow.TabIndex = 0;
            this.RTCIsSaveGraphicWindow.Text = "Save Graphic Window";
            this.RTCIsSaveGraphicWindow.UseVisualStyleBackColor = true;
            // 
            // RTCIsSaveOriginImage
            // 
            this.RTCIsSaveOriginImage.AutoSize = true;
            this.RTCIsSaveOriginImage.Location = new System.Drawing.Point(12, 21);
            this.RTCIsSaveOriginImage.Name = "RTCIsSaveOriginImage";
            this.RTCIsSaveOriginImage.Size = new System.Drawing.Size(85, 17);
            this.RTCIsSaveOriginImage.TabIndex = 0;
            this.RTCIsSaveOriginImage.Text = "Save Origin";
            this.RTCIsSaveOriginImage.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(23, 439);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // RTCOutputFileName
            // 
            this.RTCOutputFileName.AutoSize = true;
            this.RTCOutputFileName.ForeColor = System.Drawing.Color.Yellow;
            this.RTCOutputFileName.Location = new System.Drawing.Point(104, 444);
            this.RTCOutputFileName.Name = "RTCOutputFileName";
            this.RTCOutputFileName.Size = new System.Drawing.Size(98, 13);
            this.RTCOutputFileName.TabIndex = 4;
            this.RTCOutputFileName.Text = "Output File Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Location = new System.Drawing.Point(63, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(634, 22);
            this.RTCName.TabIndex = 1;
            // 
            // ucViewResultActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucViewResultActionDetail";
            this.Size = new System.Drawing.Size(900, 576);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panSaveImageSettings.ResumeLayout(false);
            this.panSaveImageSettings.PerformLayout();
            this.panPrefixSuffixName.ResumeLayout(false);
            this.panPrefixSuffixName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RTCResetNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCMaxNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCStartNumber)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox RTCIsMasterView;
        private System.Windows.Forms.CheckBox RTCResultOK;
        private System.Windows.Forms.ComboBox RTCResultMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox RTCIsRunByRunOrder;
        private System.Windows.Forms.ComboBox RTCViewIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panSaveImageSettings;
        private ucLink ucLink1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RTCResizePercentage;
        private System.Windows.Forms.CheckBox RTCIsResize;
        private System.Windows.Forms.CheckBox RTCOnlyNG;
        private System.Windows.Forms.CheckBox RTCIsSaveScreenshot;
        private System.Windows.Forms.CheckBox RTCIsSaveGraphicWindow;
        private System.Windows.Forms.CheckBox RTCIsSaveOriginImage;
        private System.Windows.Forms.Label RTCOutputFileName;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox RTCOverwriteWhenExists;
        private System.Windows.Forms.ComboBox RTCSaveMode;
        private System.Windows.Forms.ComboBox RTCImageTypes;
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
        private ucProgramName ucProgramName1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label4;
    }
}
