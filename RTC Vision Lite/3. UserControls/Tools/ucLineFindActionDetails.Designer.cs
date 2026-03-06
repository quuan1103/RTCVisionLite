
namespace RTC_Vision_Lite.UserControls
{
    partial class ucLineFindActionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLineFindActionDetails));
            this.ucImageLink1 = new RTC_Vision_Lite.UserControls.ucImageLink();
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
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCSamplingPercent = new System.Windows.Forms.TrackBar();
            this.RTCEdgeDetectionThreshold = new System.Windows.Forms.TextBox();
            this.RTCEdgeType = new System.Windows.Forms.ComboBox();
            this.RTCEdgeTransition = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.RTCSamplingPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin1);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink1);
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
            this.ScrollablePassFail.Controls.Add(this.RTCPassed);
            this.ScrollablePassFail.Controls.Add(this.label8);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
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
            this.imlLinkSummary.Images.SetKeyName(2, "");
            this.imlLinkSummary.Images.SetKeyName(3, "");
            this.imlLinkSummary.Images.SetKeyName(4, "");
            this.imlLinkSummary.Images.SetKeyName(5, "");
            this.imlLinkSummary.Images.SetKeyName(6, "");
            this.imlLinkSummary.Images.SetKeyName(7, "");
            this.imlLinkSummary.Images.SetKeyName(8, "");
            this.imlLinkSummary.Images.SetKeyName(9, "");
            this.imlLinkSummary.Images.SetKeyName(10, "");
            this.imlLinkSummary.Images.SetKeyName(11, "");
            // 
            // ucImageLink1
            // 
            this.ucImageLink1.Action = null;
            this.ucImageLink1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink1.Caption = "Image";
            this.ucImageLink1.Location = new System.Drawing.Point(23, 57);
            this.ucImageLink1.Margin = new System.Windows.Forms.Padding(2);
            this.ucImageLink1.Name = "ucImageLink1";
            this.ucImageLink1.PropertyName = "InputImage";
            this.ucImageLink1.Size = new System.Drawing.Size(676, 76);
            this.ucImageLink1.TabIndex = 14;
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(641, 22);
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
            this.ucOrigin1.Location = new System.Drawing.Point(23, 145);
            this.ucOrigin1.Margin = new System.Windows.Forms.Padding(2, 9, 2, 9);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(676, 95);
            this.ucOrigin1.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RTCLineAngleTolerance);
            this.groupBox3.Controls.Add(this.RTCLineLengthTolerance);
            this.groupBox3.Location = new System.Drawing.Point(20, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 135);
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
            this.groupBox4.Location = new System.Drawing.Point(20, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 118);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Edge Points:";
            // 
            // RTCMinEdgePointNumber
            // 
            this.RTCMinEdgePointNumber.Location = new System.Drawing.Point(315, 63);
            this.RTCMinEdgePointNumber.Name = "RTCMinEdgePointNumber";
            this.RTCMinEdgePointNumber.Size = new System.Drawing.Size(116, 22);
            this.RTCMinEdgePointNumber.TabIndex = 12;
            // 
            // RTCMaxPercentageOfOutliers
            // 
            this.RTCMaxPercentageOfOutliers.Location = new System.Drawing.Point(117, 63);
            this.RTCMaxPercentageOfOutliers.Name = "RTCMaxPercentageOfOutliers";
            this.RTCMaxPercentageOfOutliers.Size = new System.Drawing.Size(117, 22);
            this.RTCMaxPercentageOfOutliers.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "% Out of tolerance:";
            // 
            // ucRangeMaxMin2
            // 
            this.ucRangeMaxMin2.AutoSize = true;
            this.ucRangeMaxMin2.Location = new System.Drawing.Point(6, 33);
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
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 16;
            this.RTCPassed.Text = "Passed";
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
            this.groupBox1.Controls.Add(this.RTCSamplingPercent);
            this.groupBox1.Controls.Add(this.RTCEdgeDetectionThreshold);
            this.groupBox1.Controls.Add(this.RTCEdgeType);
            this.groupBox1.Controls.Add(this.RTCEdgeTransition);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(20, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(604, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // RTCSamplingPercent
            // 
            this.RTCSamplingPercent.AllowDrop = true;
            this.RTCSamplingPercent.LargeChange = 10;
            this.RTCSamplingPercent.Location = new System.Drawing.Point(450, 82);
            this.RTCSamplingPercent.Margin = new System.Windows.Forms.Padding(2);
            this.RTCSamplingPercent.Maximum = 100;
            this.RTCSamplingPercent.Name = "RTCSamplingPercent";
            this.RTCSamplingPercent.Size = new System.Drawing.Size(124, 45);
            this.RTCSamplingPercent.SmallChange = 10;
            this.RTCSamplingPercent.TabIndex = 7;
            this.RTCSamplingPercent.TickFrequency = 10;
            this.RTCSamplingPercent.Value = 25;
            // 
            // RTCEdgeDetectionThreshold
            // 
            this.RTCEdgeDetectionThreshold.Location = new System.Drawing.Point(459, 38);
            this.RTCEdgeDetectionThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEdgeDetectionThreshold.Name = "RTCEdgeDetectionThreshold";
            this.RTCEdgeDetectionThreshold.Size = new System.Drawing.Size(93, 22);
            this.RTCEdgeDetectionThreshold.TabIndex = 6;
            this.RTCEdgeDetectionThreshold.Text = "20";
            this.RTCEdgeDetectionThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RTCEdgeType
            // 
            this.RTCEdgeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCEdgeType.FormattingEnabled = true;
            this.RTCEdgeType.Location = new System.Drawing.Point(139, 80);
            this.RTCEdgeType.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEdgeType.Name = "RTCEdgeType";
            this.RTCEdgeType.Size = new System.Drawing.Size(138, 21);
            this.RTCEdgeType.TabIndex = 5;
            // 
            // RTCEdgeTransition
            // 
            this.RTCEdgeTransition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCEdgeTransition.FormattingEnabled = true;
            this.RTCEdgeTransition.Location = new System.Drawing.Point(139, 38);
            this.RTCEdgeTransition.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEdgeTransition.Name = "RTCEdgeTransition";
            this.RTCEdgeTransition.Size = new System.Drawing.Size(138, 21);
            this.RTCEdgeTransition.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(340, 87);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Sampling percent:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(340, 41);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Edge Threshold:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(31, 87);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Edge Type:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(31, 41);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Edge Transition:";
            // 
            // ucLineFindActionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucLineFindActionDetails";
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RTCSamplingPercent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ucImageLink ucImageLink1;
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
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar RTCSamplingPercent;
        private System.Windows.Forms.TextBox RTCEdgeDetectionThreshold;
        private System.Windows.Forms.ComboBox RTCEdgeType;
        private System.Windows.Forms.ComboBox RTCEdgeTransition;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
    }
}
