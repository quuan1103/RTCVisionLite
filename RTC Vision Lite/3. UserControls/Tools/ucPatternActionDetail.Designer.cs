
namespace RTC_Vision_Lite.UserControls
{
    partial class ucPatternActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPatternActionDetail));
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.label2 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMinAngleRangePattern = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.RTCPossibleRotations = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RTCTrainPressed = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.RTCNumberToFindRange = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.RTCMinPassScore = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RTCPositionAccuracy = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.RTCFindSubsamplingLevelMode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.RTCFindSubsamplingLevel = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ucOrigin = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollablePassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(2);
            this.PageActionSetting.Size = new System.Drawing.Size(900, 466);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label2);
            this.ScrollableGeneral.Location = new System.Drawing.Point(5, 5);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableGeneral.Size = new System.Drawing.Size(855, 381);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(2, 39);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(2);
            this.PageSetup.Size = new System.Drawing.Size(888, 399);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(5);
            this.ROI.Padding = new System.Windows.Forms.Padding(5);
            this.ROI.Size = new System.Drawing.Size(865, 391);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(5);
            this.PassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Controls.Add(this.button1);
            this.ScrollablePassFail.Controls.Add(this.groupBox8);
            this.ScrollablePassFail.Controls.Add(this.groupBox9);
            this.ScrollablePassFail.Controls.Add(this.groupBox7);
            this.ScrollablePassFail.Controls.Add(this.RTCPassed);
            this.ScrollablePassFail.Controls.Add(this.label11);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCTrainPressed);
            this.ScrollableROI.Controls.Add(this.groupBox2);
            this.ScrollableROI.Location = new System.Drawing.Point(5, 5);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableROI.Size = new System.Drawing.Size(855, 381);
            this.ScrollableROI.Paint += new System.Windows.Forms.PaintEventHandler(this.ScrollableROI_Paint);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(888, 37);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(5);
            this.General.Padding = new System.Windows.Forms.Padding(5);
            this.General.Size = new System.Drawing.Size(865, 391);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(2);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(2);
            this.TabSetUp.Size = new System.Drawing.Size(892, 440);
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
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableMethod.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(2);
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
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(22, 50);
            this.ucImageLink.Margin = new System.Windows.Forms.Padding(2, 1674, 2, 1674);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(674, 73);
            this.ucImageLink.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(638, 22);
            this.RTCName.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ucRangeMaxMinAngleRangePattern);
            this.groupBox2.Controls.Add(this.RTCPossibleRotations);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(20, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(305, 117);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Limits";
            // 
            // ucRangeMaxMinAngleRangePattern
            // 
            this.ucRangeMaxMinAngleRangePattern.AutoSize = true;
            this.ucRangeMaxMinAngleRangePattern.Location = new System.Drawing.Point(9, 69);
            this.ucRangeMaxMinAngleRangePattern.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinAngleRangePattern.Name = "ucRangeMaxMinAngleRangePattern";
            this.ucRangeMaxMinAngleRangePattern.RTCAction = null;
            this.ucRangeMaxMinAngleRangePattern.RTCActualPropertyName = null;
            this.ucRangeMaxMinAngleRangePattern.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinAngleRangePattern.RTCCheckboxCaption = "Caption";
            this.ucRangeMaxMinAngleRangePattern.RTCCheckboxPropertyName = null;
            this.ucRangeMaxMinAngleRangePattern.RTCCheckboxSize = 100;
            this.ucRangeMaxMinAngleRangePattern.RTCChecked = false;
            this.ucRangeMaxMinAngleRangePattern.RTCEditMask = "n2";
            this.ucRangeMaxMinAngleRangePattern.RTCFeaturesLabel = "Features";
            this.ucRangeMaxMinAngleRangePattern.RTCIsLimit = false;
            this.ucRangeMaxMinAngleRangePattern.RTCMaxLabel = "Max";
            this.ucRangeMaxMinAngleRangePattern.RTCMinLabel = "Min";
            this.ucRangeMaxMinAngleRangePattern.RTCTextboxSize = 70;
            this.ucRangeMaxMinAngleRangePattern.RTCUseActual = false;
            this.ucRangeMaxMinAngleRangePattern.RTCUseActualLabel = false;
            this.ucRangeMaxMinAngleRangePattern.RTCUseCheckbox = false;
            this.ucRangeMaxMinAngleRangePattern.RTCUseFeatures = false;
            this.ucRangeMaxMinAngleRangePattern.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinAngleRangePattern.RTCUseMinMaxAtLine = true;
            this.ucRangeMaxMinAngleRangePattern.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinAngleRangePattern.RTCValuePropertyName = "AngleRangePattern";
            this.ucRangeMaxMinAngleRangePattern.Size = new System.Drawing.Size(284, 30);
            this.ucRangeMaxMinAngleRangePattern.TabIndex = 2;
            // 
            // RTCPossibleRotations
            // 
            this.RTCPossibleRotations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCPossibleRotations.FormattingEnabled = true;
            this.RTCPossibleRotations.Location = new System.Drawing.Point(9, 44);
            this.RTCPossibleRotations.Margin = new System.Windows.Forms.Padding(2);
            this.RTCPossibleRotations.Name = "RTCPossibleRotations";
            this.RTCPossibleRotations.Size = new System.Drawing.Size(246, 21);
            this.RTCPossibleRotations.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Possible Rorations";
            // 
            // RTCTrainPressed
            // 
            this.RTCTrainPressed.BackColor = System.Drawing.Color.White;
            this.RTCTrainPressed.Location = new System.Drawing.Point(21, 146);
            this.RTCTrainPressed.Margin = new System.Windows.Forms.Padding(2);
            this.RTCTrainPressed.Name = "RTCTrainPressed";
            this.RTCTrainPressed.Size = new System.Drawing.Size(83, 34);
            this.RTCTrainPressed.TabIndex = 4;
            this.RTCTrainPressed.Text = "Train";
            this.RTCTrainPressed.UseVisualStyleBackColor = false;
            this.RTCTrainPressed.Click += new System.EventHandler(this.RTCTrainPressed_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Controls.Add(this.RTCNumberToFindRange);
            this.groupBox9.Controls.Add(this.RTCMinPassScore);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Location = new System.Drawing.Point(20, 35);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(296, 175);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Mathches";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.radioButton1);
            this.groupBox10.Controls.Add(this.radioButton2);
            this.groupBox10.Location = new System.Drawing.Point(4, 63);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(248, 56);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Number To Find";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(4, 27);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.Text = "All Instances";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(109, 27);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Range";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // RTCNumberToFindRange
            // 
            this.RTCNumberToFindRange.AutoSize = true;
            this.RTCNumberToFindRange.Location = new System.Drawing.Point(4, 132);
            this.RTCNumberToFindRange.Margin = new System.Windows.Forms.Padding(2);
            this.RTCNumberToFindRange.Name = "RTCNumberToFindRange";
            this.RTCNumberToFindRange.RTCAction = null;
            this.RTCNumberToFindRange.RTCActualPropertyName = "OutputScore";
            this.RTCNumberToFindRange.RTCAllowInfinityMaxValue = true;
            this.RTCNumberToFindRange.RTCCheckboxCaption = "Column";
            this.RTCNumberToFindRange.RTCCheckboxPropertyName = "";
            this.RTCNumberToFindRange.RTCCheckboxSize = 110;
            this.RTCNumberToFindRange.RTCChecked = false;
            this.RTCNumberToFindRange.RTCEditMask = "n2";
            this.RTCNumberToFindRange.RTCFeaturesLabel = "";
            this.RTCNumberToFindRange.RTCIsLimit = false;
            this.RTCNumberToFindRange.RTCMaxLabel = "Max";
            this.RTCNumberToFindRange.RTCMinLabel = "Min";
            this.RTCNumberToFindRange.RTCTextboxSize = 75;
            this.RTCNumberToFindRange.RTCUseActual = true;
            this.RTCNumberToFindRange.RTCUseActualLabel = false;
            this.RTCNumberToFindRange.RTCUseCheckbox = false;
            this.RTCNumberToFindRange.RTCUseFeatures = false;
            this.RTCNumberToFindRange.RTCUseMaskAsDisplayFormat = false;
            this.RTCNumberToFindRange.RTCUseMinMaxAtLine = true;
            this.RTCNumberToFindRange.RTCUseMinMaxAtTop = false;
            this.RTCNumberToFindRange.RTCValuePropertyName = "NumberToFindRange";
            this.RTCNumberToFindRange.Size = new System.Drawing.Size(290, 30);
            this.RTCNumberToFindRange.TabIndex = 11;
            // 
            // RTCMinPassScore
            // 
            this.RTCMinPassScore.Location = new System.Drawing.Point(119, 21);
            this.RTCMinPassScore.Margin = new System.Windows.Forms.Padding(2);
            this.RTCMinPassScore.Name = "RTCMinPassScore";
            this.RTCMinPassScore.Size = new System.Drawing.Size(134, 22);
            this.RTCMinPassScore.TabIndex = 2;
            this.RTCMinPassScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Minimum Pass Core";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RTCPositionAccuracy);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Location = new System.Drawing.Point(322, 36);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(295, 174);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Acurracy";
            // 
            // RTCPositionAccuracy
            // 
            this.RTCPositionAccuracy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCPositionAccuracy.FormattingEnabled = true;
            this.RTCPositionAccuracy.Location = new System.Drawing.Point(8, 42);
            this.RTCPositionAccuracy.Margin = new System.Windows.Forms.Padding(2);
            this.RTCPositionAccuracy.Name = "RTCPositionAccuracy";
            this.RTCPositionAccuracy.Size = new System.Drawing.Size(260, 21);
            this.RTCPositionAccuracy.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 24);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Position Accuracy";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 9;
            this.RTCPassed.Text = "Passed";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Pass/Fail:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.RTCFindSubsamplingLevelMode);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.RTCFindSubsamplingLevel);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Location = new System.Drawing.Point(876, 210);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(294, 80);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Find Subsampling Level";
            this.groupBox8.Visible = false;
            // 
            // RTCFindSubsamplingLevelMode
            // 
            this.RTCFindSubsamplingLevelMode.FormattingEnabled = true;
            this.RTCFindSubsamplingLevelMode.Location = new System.Drawing.Point(64, 19);
            this.RTCFindSubsamplingLevelMode.Margin = new System.Windows.Forms.Padding(2);
            this.RTCFindSubsamplingLevelMode.Name = "RTCFindSubsamplingLevelMode";
            this.RTCFindSubsamplingLevelMode.Size = new System.Drawing.Size(203, 21);
            this.RTCFindSubsamplingLevelMode.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 50);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Value:";
            // 
            // RTCFindSubsamplingLevel
            // 
            this.RTCFindSubsamplingLevel.Location = new System.Drawing.Point(64, 50);
            this.RTCFindSubsamplingLevel.Margin = new System.Windows.Forms.Padding(2);
            this.RTCFindSubsamplingLevel.Name = "RTCFindSubsamplingLevel";
            this.RTCFindSubsamplingLevel.Size = new System.Drawing.Size(203, 22);
            this.RTCFindSubsamplingLevel.TabIndex = 12;
            this.RTCFindSubsamplingLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 21);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Model:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 225);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 16;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ucOrigin
            // 
            this.ucOrigin.Action = null;
            this.ucOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin.Location = new System.Drawing.Point(22, 129);
            this.ucOrigin.Name = "ucOrigin";
            this.ucOrigin.PropertyName = "ToolOrigin";
            this.ucOrigin.Size = new System.Drawing.Size(674, 85);
            this.ucOrigin.TabIndex = 11;
            // 
            // ucPatternActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ucPatternActionDetail";
            this.Size = new System.Drawing.Size(900, 466);
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.ScrollablePassFail.ResumeLayout(false);
            this.ScrollablePassFail.PerformLayout();
            this.ScrollableROI.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ucImageLink ucImageLink;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox RTCPossibleRotations;
        private System.Windows.Forms.Label label3;
        private UserControls.ucRangeMaxMin ucRangeMaxMinAngleRangePattern;
        private System.Windows.Forms.Button RTCTrainPressed;
        private System.Windows.Forms.GroupBox groupBox9;
        private UserControls.ucRangeMaxMin RTCNumberToFindRange;
        private System.Windows.Forms.TextBox RTCMinPassScore;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox RTCPositionAccuracy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox RTCFindSubsamplingLevelMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox RTCFindSubsamplingLevel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox10;
        private ucOrigin ucOrigin;
    }
}
