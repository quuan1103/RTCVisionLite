
namespace RTC_Vision_Lite.UserControls
{
    partial class ucRegionProcessingActionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRegionProcessingActionDetails));
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucOrigin1 = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RTCLineAngleTolerance = new RTC_Vision_Lite.UserControls.ucTolerance();
            this.RTCLineLengthTolerance = new RTC_Vision_Lite.UserControls.ucTolerance();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RTCMinEdgePointNumber = new System.Windows.Forms.TextBox();
            this.RTCMaxPercentageOfOutliers = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ucRangeMaxMin2 = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCMaskAngle = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RTCInterations = new System.Windows.Forms.TextBox();
            this.RTCMaskHeight = new System.Windows.Forms.TextBox();
            this.RTCMaskWidth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RTCMaskType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RTCMaskRadius = new System.Windows.Forms.TextBox();
            this.RTCMargin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RTCMorphologyType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.ucInputRegion = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.RTCIsMorphology = new System.Windows.Forms.CheckBox();
            this.RTCIsRegionMath = new System.Windows.Forms.CheckBox();
            this.RTCIsConnection = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.RTCRegionMath = new System.Windows.Forms.ComboBox();
            this.RTCPassed = new System.Windows.Forms.Label();
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
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            this.PageActionSetting.SelectedIndexChanged += new System.EventHandler(this.PageActionSetting_SelectedIndexChanged);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucInputRegion);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.ucOrigin1);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
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
            this.ScrollablePassFail.Controls.Add(this.groupBox3);
            this.ScrollablePassFail.Controls.Add(this.groupBox4);
            this.ScrollablePassFail.Controls.Add(this.label7);
            this.ScrollablePassFail.Controls.Add(this.label8);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.RTCRegionMath);
            this.ScrollableROI.Controls.Add(this.label14);
            this.ScrollableROI.Controls.Add(this.RTCIsConnection);
            this.ScrollableROI.Controls.Add(this.RTCIsRegionMath);
            this.ScrollableROI.Controls.Add(this.RTCIsMorphology);
            this.ScrollableROI.Controls.Add(this.label12);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Location = new System.Drawing.Point(2, 2);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableROI.Size = new System.Drawing.Size(861, 409);
            this.ScrollableROI.Paint += new System.Windows.Forms.PaintEventHandler(this.ScrollableROI_Paint);
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
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(640, 22);
            this.RTCName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // ucOrigin1
            // 
            this.ucOrigin1.Action = null;
            this.ucOrigin1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin1.Location = new System.Drawing.Point(15, 215);
            this.ucOrigin1.Margin = new System.Windows.Forms.Padding(2, 7, 2, 7);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(683, 86);
            this.ucOrigin1.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RTCLineAngleTolerance);
            this.groupBox3.Controls.Add(this.RTCLineLengthTolerance);
            this.groupBox3.Location = new System.Drawing.Point(20, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 136);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Length";
            // 
            // RTCLineAngleTolerance
            // 
            this.RTCLineAngleTolerance.AutoSize = true;
            this.RTCLineAngleTolerance.Location = new System.Drawing.Point(6, 78);
            this.RTCLineAngleTolerance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCLineAngleTolerance.Name = "RTCLineAngleTolerance";
            this.RTCLineAngleTolerance.RTCAction = null;
            this.RTCLineAngleTolerance.RTCAllowInfinityValue = true;
            this.RTCLineAngleTolerance.RTCCheckboxCaption = "Angle";
            this.RTCLineAngleTolerance.RTCCheckboxPropertyName = "EnableAngleRangeCheck";
            this.RTCLineAngleTolerance.RTCCheckboxSize = 100;
            this.RTCLineAngleTolerance.RTCChecked = false;
            this.RTCLineAngleTolerance.RTCFeaturesLabel = "Features";
            this.RTCLineAngleTolerance.RTCMinusLabel = "Minus";
            this.RTCLineAngleTolerance.RTCNominalLabel = "Nominal";
            this.RTCLineAngleTolerance.RTCPlusLabel = "Plus";
            this.RTCLineAngleTolerance.RTCPropertyName = "LineAngleTolerance";
            this.RTCLineAngleTolerance.RTCUseActual = true;
            this.RTCLineAngleTolerance.RTCUseActualLabel = false;
            this.RTCLineAngleTolerance.RTCUseCheckbox = true;
            this.RTCLineAngleTolerance.RTCUseFeatures = false;
            this.RTCLineAngleTolerance.RTCUseLabelAtLine = false;
            this.RTCLineAngleTolerance.RTCUseLabelAtTop = false;
            this.RTCLineAngleTolerance.Size = new System.Drawing.Size(498, 30);
            this.RTCLineAngleTolerance.TabIndex = 1;
            // 
            // RTCLineLengthTolerance
            // 
            this.RTCLineLengthTolerance.AutoSize = true;
            this.RTCLineLengthTolerance.Location = new System.Drawing.Point(6, 12);
            this.RTCLineLengthTolerance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCLineLengthTolerance.Name = "RTCLineLengthTolerance";
            this.RTCLineLengthTolerance.RTCAction = null;
            this.RTCLineLengthTolerance.RTCAllowInfinityValue = true;
            this.RTCLineLengthTolerance.RTCCheckboxCaption = "Length";
            this.RTCLineLengthTolerance.RTCCheckboxPropertyName = "EnableLineLengthCheck";
            this.RTCLineLengthTolerance.RTCCheckboxSize = 100;
            this.RTCLineLengthTolerance.RTCChecked = false;
            this.RTCLineLengthTolerance.RTCFeaturesLabel = "Features";
            this.RTCLineLengthTolerance.RTCMinusLabel = "Minus";
            this.RTCLineLengthTolerance.RTCNominalLabel = "Nominal";
            this.RTCLineLengthTolerance.RTCPlusLabel = "Plus";
            this.RTCLineLengthTolerance.RTCPropertyName = "LineLengthTolerance";
            this.RTCLineLengthTolerance.RTCUseActual = true;
            this.RTCLineLengthTolerance.RTCUseActualLabel = true;
            this.RTCLineLengthTolerance.RTCUseCheckbox = true;
            this.RTCLineLengthTolerance.RTCUseFeatures = false;
            this.RTCLineLengthTolerance.RTCUseLabelAtLine = false;
            this.RTCLineLengthTolerance.RTCUseLabelAtTop = true;
            this.RTCLineLengthTolerance.Size = new System.Drawing.Size(498, 60);
            this.RTCLineLengthTolerance.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.RTCMinEdgePointNumber);
            this.groupBox4.Controls.Add(this.RTCMaxPercentageOfOutliers);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.ucRangeMaxMin2);
            this.groupBox4.Location = new System.Drawing.Point(20, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 100);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Edge Points:";
            // 
            // RTCMinEdgePointNumber
            // 
            this.RTCMinEdgePointNumber.Location = new System.Drawing.Point(315, 61);
            this.RTCMinEdgePointNumber.Name = "RTCMinEdgePointNumber";
            this.RTCMinEdgePointNumber.Size = new System.Drawing.Size(116, 22);
            this.RTCMinEdgePointNumber.TabIndex = 12;
            // 
            // RTCMaxPercentageOfOutliers
            // 
            this.RTCMaxPercentageOfOutliers.Location = new System.Drawing.Point(117, 61);
            this.RTCMaxPercentageOfOutliers.Name = "RTCMaxPercentageOfOutliers";
            this.RTCMaxPercentageOfOutliers.Size = new System.Drawing.Size(117, 22);
            this.RTCMaxPercentageOfOutliers.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "% Out of tolerance:";
            // 
            // ucRangeMaxMin2
            // 
            this.ucRangeMaxMin2.AutoSize = true;
            this.ucRangeMaxMin2.Location = new System.Drawing.Point(6, 27);
            this.ucRangeMaxMin2.Name = "ucRangeMaxMin2";
            this.ucRangeMaxMin2.RTCAction = null;
            this.ucRangeMaxMin2.RTCActualPropertyName = "GreatestGapLength";
            this.ucRangeMaxMin2.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMin2.RTCCheckboxCaption = "Longest Gap";
            this.ucRangeMaxMin2.RTCCheckboxPropertyName = "EnableGapLengthCheck";
            this.ucRangeMaxMin2.RTCCheckboxSize = 100;
            this.ucRangeMaxMin2.RTCChecked = false;
            this.ucRangeMaxMin2.RTCEditMask = "n2";
            this.ucRangeMaxMin2.RTCFeaturesLabel = "";
            this.ucRangeMaxMin2.RTCIsLimit = false;
            this.ucRangeMaxMin2.RTCMaxLabel = "Max";
            this.ucRangeMaxMin2.RTCMinLabel = "Min";
            this.ucRangeMaxMin2.RTCTextboxSize = 50;
            this.ucRangeMaxMin2.RTCUseActual = true;
            this.ucRangeMaxMin2.RTCUseActualLabel = false;
            this.ucRangeMaxMin2.RTCUseCheckbox = true;
            this.ucRangeMaxMin2.RTCUseFeatures = false;
            this.ucRangeMaxMin2.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMin2.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMin2.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMin2.RTCValuePropertyName = "GapLengthRange";
            this.ucRangeMaxMin2.Size = new System.Drawing.Size(425, 30);
            this.ucRangeMaxMin2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(82, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Passed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Pass/Fail:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCMaskAngle);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.RTCInterations);
            this.groupBox1.Controls.Add(this.RTCMaskHeight);
            this.groupBox1.Controls.Add(this.RTCMaskWidth);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.RTCMaskType);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.RTCMaskRadius);
            this.groupBox1.Controls.Add(this.RTCMargin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RTCMorphologyType);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(19, 67);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(528, 127);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // RTCMaskAngle
            // 
            this.RTCMaskAngle.Location = new System.Drawing.Point(378, 47);
            this.RTCMaskAngle.Name = "RTCMaskAngle";
            this.RTCMaskAngle.Size = new System.Drawing.Size(138, 22);
            this.RTCMaskAngle.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(279, 53);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Mask Angle";
            // 
            // RTCInterations
            // 
            this.RTCInterations.Location = new System.Drawing.Point(378, 96);
            this.RTCInterations.Name = "RTCInterations";
            this.RTCInterations.Size = new System.Drawing.Size(138, 22);
            this.RTCInterations.TabIndex = 18;
            // 
            // RTCMaskHeight
            // 
            this.RTCMaskHeight.Location = new System.Drawing.Point(130, 69);
            this.RTCMaskHeight.Name = "RTCMaskHeight";
            this.RTCMaskHeight.Size = new System.Drawing.Size(138, 22);
            this.RTCMaskHeight.TabIndex = 17;
            // 
            // RTCMaskWidth
            // 
            this.RTCMaskWidth.Location = new System.Drawing.Point(130, 44);
            this.RTCMaskWidth.Name = "RTCMaskWidth";
            this.RTCMaskWidth.Size = new System.Drawing.Size(138, 22);
            this.RTCMaskWidth.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 104);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Interations:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // RTCMaskType
            // 
            this.RTCMaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCMaskType.FormattingEnabled = true;
            this.RTCMaskType.Location = new System.Drawing.Point(378, 19);
            this.RTCMaskType.Margin = new System.Windows.Forms.Padding(2);
            this.RTCMaskType.Name = "RTCMaskType";
            this.RTCMaskType.Size = new System.Drawing.Size(138, 21);
            this.RTCMaskType.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(279, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Mask Type:";
            // 
            // RTCMaskRadius
            // 
            this.RTCMaskRadius.Location = new System.Drawing.Point(378, 72);
            this.RTCMaskRadius.Name = "RTCMaskRadius";
            this.RTCMaskRadius.Size = new System.Drawing.Size(138, 22);
            this.RTCMaskRadius.TabIndex = 16;
            // 
            // RTCMargin
            // 
            this.RTCMargin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCMargin.FormattingEnabled = true;
            this.RTCMargin.Location = new System.Drawing.Point(130, 97);
            this.RTCMargin.Margin = new System.Windows.Forms.Padding(2);
            this.RTCMargin.Name = "RTCMargin";
            this.RTCMargin.Size = new System.Drawing.Size(138, 21);
            this.RTCMargin.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Margin Type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(279, 78);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Mask Radius:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mask Height:";
            // 
            // RTCMorphologyType
            // 
            this.RTCMorphologyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCMorphologyType.FormattingEnabled = true;
            this.RTCMorphologyType.Location = new System.Drawing.Point(130, 19);
            this.RTCMorphologyType.Margin = new System.Windows.Forms.Padding(2);
            this.RTCMorphologyType.Name = "RTCMorphologyType";
            this.RTCMorphologyType.Size = new System.Drawing.Size(138, 21);
            this.RTCMorphologyType.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 50);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Mask Width:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 23);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Mophology Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 16);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Pass/Fail:";
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(15, 49);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(683, 75);
            this.ucImageLink.TabIndex = 16;
            // 
            // ucInputRegion
            // 
            this.ucInputRegion.Action = null;
            this.ucInputRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucInputRegion.Caption = "Input Region";
            this.ucInputRegion.Location = new System.Drawing.Point(15, 130);
            this.ucInputRegion.Name = "ucInputRegion";
            this.ucInputRegion.PropertyName = "InputRegion";
            this.ucInputRegion.Size = new System.Drawing.Size(683, 75);
            this.ucInputRegion.TabIndex = 17;
            // 
            // RTCIsMorphology
            // 
            this.RTCIsMorphology.AutoSize = true;
            this.RTCIsMorphology.Location = new System.Drawing.Point(19, 39);
            this.RTCIsMorphology.Name = "RTCIsMorphology";
            this.RTCIsMorphology.Size = new System.Drawing.Size(128, 17);
            this.RTCIsMorphology.TabIndex = 19;
            this.RTCIsMorphology.Text = "Enable Morphology";
            this.RTCIsMorphology.UseVisualStyleBackColor = true;
            // 
            // RTCIsRegionMath
            // 
            this.RTCIsRegionMath.AutoSize = true;
            this.RTCIsRegionMath.Location = new System.Drawing.Point(150, 208);
            this.RTCIsRegionMath.Name = "RTCIsRegionMath";
            this.RTCIsRegionMath.Size = new System.Drawing.Size(131, 17);
            this.RTCIsRegionMath.TabIndex = 20;
            this.RTCIsRegionMath.Text = "Enable Region Math";
            this.RTCIsRegionMath.UseVisualStyleBackColor = true;
            // 
            // RTCIsConnection
            // 
            this.RTCIsConnection.AutoSize = true;
            this.RTCIsConnection.Location = new System.Drawing.Point(20, 208);
            this.RTCIsConnection.Name = "RTCIsConnection";
            this.RTCIsConnection.Size = new System.Drawing.Size(124, 17);
            this.RTCIsConnection.TabIndex = 21;
            this.RTCIsConnection.Text = "Enable Connection";
            this.RTCIsConnection.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(298, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Region Math";
            // 
            // RTCRegionMath
            // 
            this.RTCRegionMath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCRegionMath.FormattingEnabled = true;
            this.RTCRegionMath.Items.AddRange(new object[] {
            "union1",
            "union2",
            "difference",
            "intersection",
            "sketelon",
            "fillup",
            "concat",
            "shape_trans"});
            this.RTCRegionMath.Location = new System.Drawing.Point(397, 204);
            this.RTCRegionMath.Name = "RTCRegionMath";
            this.RTCRegionMath.Size = new System.Drawing.Size(138, 21);
            this.RTCRegionMath.TabIndex = 23;
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(91, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 24;
            this.RTCPassed.Text = "Passed";
            // 
            // ucRegionProcessingActionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucRegionProcessingActionDetails";
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.ScrollablePassFail.ResumeLayout(false);
            this.ScrollablePassFail.PerformLayout();
            this.ScrollableROI.ResumeLayout(false);
            this.ScrollableROI.PerformLayout();
            this.General.ResumeLayout(false);
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private ucOrigin ucOrigin1;
        private System.Windows.Forms.GroupBox groupBox3;
        private UserControls.ucTolerance RTCLineAngleTolerance;
        private UserControls.ucTolerance RTCLineLengthTolerance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RTCMinEdgePointNumber;
        private System.Windows.Forms.TextBox RTCMaxPercentageOfOutliers;
        private System.Windows.Forms.Label label5;
        private ucRangeMaxMin ucRangeMaxMin2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox RTCMorphologyType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox RTCMaskType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox RTCMargin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RTCInterations;
        private System.Windows.Forms.TextBox RTCMaskHeight;
        private System.Windows.Forms.TextBox RTCMaskRadius;
        private System.Windows.Forms.TextBox RTCMaskWidth;
        private System.Windows.Forms.Label label12;
        private ucImageLink ucImageLink;
        private ucImageLink ucInputRegion;
        private System.Windows.Forms.CheckBox RTCIsMorphology;
        private System.Windows.Forms.CheckBox RTCIsConnection;
        private System.Windows.Forms.CheckBox RTCIsRegionMath;
        private System.Windows.Forms.TextBox RTCMaskAngle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox RTCRegionMath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label RTCPassed;
    }
}
