
namespace RTC_Vision_Lite.UserControls
{
    partial class ucOriginActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOriginActionDetail));
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.ucOrigin1 = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCOutlierDistanceThreshold = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.RTCDefaultOrigin = new System.Windows.Forms.TextBox();
            this.RTCMinEdgePointNumber = new System.Windows.Forms.TextBox();
            this.RTCROILegend = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.RTCSubpixelMethod = new System.Windows.Forms.ComboBox();
            this.RTCSamplingPercent = new System.Windows.Forms.TextBox();
            this.RTCEdgeDetectionThreshold = new System.Windows.Forms.TextBox();
            this.RTCEdgeType = new System.Windows.Forms.ComboBox();
            this.RTCEdgeTransition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lable10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMin3 = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMin1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMin2 = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblSetPropertiesToOtherROI = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblSetupPassed = new System.Windows.Forms.Label();
            this.RTCOriginType = new System.Windows.Forms.ComboBox();
            this.btnRunMultiROI = new System.Windows.Forms.Button();
            this.chkRunOnlyROISelect = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin1);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.label2);
            this.ScrollableGeneral.Location = new System.Drawing.Point(5, 5);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1149, 501);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(5, 51);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(5);
            this.PageSetup.Size = new System.Drawing.Size(1182, 519);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(5);
            this.ROI.Padding = new System.Windows.Forms.Padding(5);
            this.ROI.Size = new System.Drawing.Size(1159, 511);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(5);
            this.PassFail.Size = new System.Drawing.Size(1159, 511);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Controls.Add(this.groupBox2);
            this.ScrollablePassFail.Controls.Add(this.RTCPassed);
            this.ScrollablePassFail.Controls.Add(this.label10);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1159, 511);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.chkRunOnlyROISelect);
            this.ScrollableROI.Controls.Add(this.btnRunMultiROI);
            this.ScrollableROI.Controls.Add(this.RTCOriginType);
            this.ScrollableROI.Controls.Add(this.lblSetupPassed);
            this.ScrollableROI.Controls.Add(this.lblSetPropertiesToOtherROI);
            this.ScrollableROI.Controls.Add(this.label13);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Location = new System.Drawing.Point(5, 5);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableROI.Size = new System.Drawing.Size(1149, 501);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1182, 46);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(5);
            this.General.Padding = new System.Windows.Forms.Padding(5);
            this.General.Size = new System.Drawing.Size(1159, 511);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(5);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(5);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(5);
            this.Method.Padding = new System.Windows.Forms.Padding(5);
            this.Method.Size = new System.Drawing.Size(1159, 511);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(5);
            this.Display.Size = new System.Drawing.Size(1159, 511);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(5, 5);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableMethod.Size = new System.Drawing.Size(1149, 501);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(1151, 503);
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
            this.RTCName.Location = new System.Drawing.Point(77, 18);
            this.RTCName.Margin = new System.Windows.Forms.Padding(4);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(863, 22);
            this.RTCName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name";
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(8, 47);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(932, 92);
            this.ucImageLink.TabIndex = 12;
            // 
            // ucOrigin1
            // 
            this.ucOrigin1.Action = null;
            this.ucOrigin1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin1.Location = new System.Drawing.Point(8, 145);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(932, 97);
            this.ucOrigin1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCOutlierDistanceThreshold);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.RTCDefaultOrigin);
            this.groupBox1.Controls.Add(this.RTCMinEdgePointNumber);
            this.groupBox1.Controls.Add(this.RTCROILegend);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.RTCSubpixelMethod);
            this.groupBox1.Controls.Add(this.RTCSamplingPercent);
            this.groupBox1.Controls.Add(this.RTCEdgeDetectionThreshold);
            this.groupBox1.Controls.Add(this.RTCEdgeType);
            this.groupBox1.Controls.Add(this.RTCEdgeTransition);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lable10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(789, 228);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // RTCOutlierDistanceThreshold
            // 
            this.RTCOutlierDistanceThreshold.Location = new System.Drawing.Point(560, 143);
            this.RTCOutlierDistanceThreshold.Margin = new System.Windows.Forms.Padding(4);
            this.RTCOutlierDistanceThreshold.Name = "RTCOutlierDistanceThreshold";
            this.RTCOutlierDistanceThreshold.Size = new System.Drawing.Size(220, 22);
            this.RTCOutlierDistanceThreshold.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(419, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Outlier Threshold";
            // 
            // RTCDefaultOrigin
            // 
            this.RTCDefaultOrigin.Location = new System.Drawing.Point(560, 107);
            this.RTCDefaultOrigin.Margin = new System.Windows.Forms.Padding(4);
            this.RTCDefaultOrigin.Name = "RTCDefaultOrigin";
            this.RTCDefaultOrigin.Size = new System.Drawing.Size(220, 22);
            this.RTCDefaultOrigin.TabIndex = 23;
            // 
            // RTCMinEdgePointNumber
            // 
            this.RTCMinEdgePointNumber.Location = new System.Drawing.Point(560, 69);
            this.RTCMinEdgePointNumber.Margin = new System.Windows.Forms.Padding(4);
            this.RTCMinEdgePointNumber.Name = "RTCMinEdgePointNumber";
            this.RTCMinEdgePointNumber.Size = new System.Drawing.Size(220, 22);
            this.RTCMinEdgePointNumber.TabIndex = 22;
            // 
            // RTCROILegend
            // 
            this.RTCROILegend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCROILegend.FormattingEnabled = true;
            this.RTCROILegend.Location = new System.Drawing.Point(560, 32);
            this.RTCROILegend.Margin = new System.Windows.Forms.Padding(4);
            this.RTCROILegend.Name = "RTCROILegend";
            this.RTCROILegend.Size = new System.Drawing.Size(220, 21);
            this.RTCROILegend.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(419, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Default Origin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "ROI Legend";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Min Edge Point";
            // 
            // RTCSubpixelMethod
            // 
            this.RTCSubpixelMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSubpixelMethod.FormattingEnabled = true;
            this.RTCSubpixelMethod.Location = new System.Drawing.Point(171, 183);
            this.RTCSubpixelMethod.Margin = new System.Windows.Forms.Padding(4);
            this.RTCSubpixelMethod.Name = "RTCSubpixelMethod";
            this.RTCSubpixelMethod.Size = new System.Drawing.Size(220, 21);
            this.RTCSubpixelMethod.TabIndex = 17;
            // 
            // RTCSamplingPercent
            // 
            this.RTCSamplingPercent.Location = new System.Drawing.Point(171, 143);
            this.RTCSamplingPercent.Margin = new System.Windows.Forms.Padding(4);
            this.RTCSamplingPercent.Name = "RTCSamplingPercent";
            this.RTCSamplingPercent.Size = new System.Drawing.Size(220, 22);
            this.RTCSamplingPercent.TabIndex = 16;
            // 
            // RTCEdgeDetectionThreshold
            // 
            this.RTCEdgeDetectionThreshold.Location = new System.Drawing.Point(171, 105);
            this.RTCEdgeDetectionThreshold.Margin = new System.Windows.Forms.Padding(4);
            this.RTCEdgeDetectionThreshold.Name = "RTCEdgeDetectionThreshold";
            this.RTCEdgeDetectionThreshold.Size = new System.Drawing.Size(220, 22);
            this.RTCEdgeDetectionThreshold.TabIndex = 15;
            // 
            // RTCEdgeType
            // 
            this.RTCEdgeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCEdgeType.FormattingEnabled = true;
            this.RTCEdgeType.Location = new System.Drawing.Point(171, 32);
            this.RTCEdgeType.Margin = new System.Windows.Forms.Padding(4);
            this.RTCEdgeType.Name = "RTCEdgeType";
            this.RTCEdgeType.Size = new System.Drawing.Size(220, 21);
            this.RTCEdgeType.TabIndex = 14;
            // 
            // RTCEdgeTransition
            // 
            this.RTCEdgeTransition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCEdgeTransition.FormattingEnabled = true;
            this.RTCEdgeTransition.Location = new System.Drawing.Point(171, 68);
            this.RTCEdgeTransition.Margin = new System.Windows.Forms.Padding(4);
            this.RTCEdgeTransition.Name = "RTCEdgeTransition";
            this.RTCEdgeTransition.Size = new System.Drawing.Size(220, 21);
            this.RTCEdgeTransition.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Edge Type";
            // 
            // lable10
            // 
            this.lable10.AutoSize = true;
            this.lable10.Location = new System.Drawing.Point(29, 191);
            this.lable10.Name = "lable10";
            this.lable10.Size = new System.Drawing.Size(95, 13);
            this.lable10.TabIndex = 9;
            this.lable10.Text = "Subpixel Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sampling Percent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Edge Transition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Edge Threshold";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(129, 26);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 7;
            this.RTCPassed.Text = "Passed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Pass/Fail:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ucRangeMaxMin3);
            this.groupBox2.Controls.Add(this.ucRangeMaxMin1);
            this.groupBox2.Controls.Add(this.ucRangeMaxMin2);
            this.groupBox2.Location = new System.Drawing.Point(27, 78);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(541, 191);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // ucRangeMaxMin3
            // 
            this.ucRangeMaxMin3.AutoSize = true;
            this.ucRangeMaxMin3.Location = new System.Drawing.Point(52, 127);
            this.ucRangeMaxMin3.Margin = new System.Windows.Forms.Padding(4);
            this.ucRangeMaxMin3.Name = "ucRangeMaxMin3";
            this.ucRangeMaxMin3.RTCAction = null;
            this.ucRangeMaxMin3.RTCActualPropertyName = "ActualAngle";
            this.ucRangeMaxMin3.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMin3.RTCCheckboxCaption = "Angle";
            this.ucRangeMaxMin3.RTCCheckboxPropertyName = "EnableAngleRangeCheck";
            this.ucRangeMaxMin3.RTCCheckboxSize = 100;
            this.ucRangeMaxMin3.RTCChecked = false;
            this.ucRangeMaxMin3.RTCEditMask = "n2";
            this.ucRangeMaxMin3.RTCFeaturesLabel = "Features";
            this.ucRangeMaxMin3.RTCIsLimit = false;
            this.ucRangeMaxMin3.RTCMaxLabel = "Max";
            this.ucRangeMaxMin3.RTCMinLabel = "Min";
            this.ucRangeMaxMin3.RTCTextboxSize = 50;
            this.ucRangeMaxMin3.RTCUseActual = true;
            this.ucRangeMaxMin3.RTCUseActualLabel = false;
            this.ucRangeMaxMin3.RTCUseCheckbox = true;
            this.ucRangeMaxMin3.RTCUseFeatures = false;
            this.ucRangeMaxMin3.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMin3.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMin3.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMin3.RTCValuePropertyName = "AngleRange";
            this.ucRangeMaxMin3.Size = new System.Drawing.Size(417, 37);
            this.ucRangeMaxMin3.TabIndex = 5;
            // 
            // ucRangeMaxMin1
            // 
            this.ucRangeMaxMin1.AutoSize = true;
            this.ucRangeMaxMin1.Location = new System.Drawing.Point(52, 38);
            this.ucRangeMaxMin1.Margin = new System.Windows.Forms.Padding(4);
            this.ucRangeMaxMin1.Name = "ucRangeMaxMin1";
            this.ucRangeMaxMin1.RTCAction = null;
            this.ucRangeMaxMin1.RTCActualPropertyName = "ActualColumn";
            this.ucRangeMaxMin1.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMin1.RTCCheckboxCaption = "Column";
            this.ucRangeMaxMin1.RTCCheckboxPropertyName = "EnableColumnFilter";
            this.ucRangeMaxMin1.RTCCheckboxSize = 100;
            this.ucRangeMaxMin1.RTCChecked = false;
            this.ucRangeMaxMin1.RTCEditMask = "n2";
            this.ucRangeMaxMin1.RTCFeaturesLabel = "Features";
            this.ucRangeMaxMin1.RTCIsLimit = false;
            this.ucRangeMaxMin1.RTCMaxLabel = "Max";
            this.ucRangeMaxMin1.RTCMinLabel = "Min";
            this.ucRangeMaxMin1.RTCTextboxSize = 50;
            this.ucRangeMaxMin1.RTCUseActual = true;
            this.ucRangeMaxMin1.RTCUseActualLabel = false;
            this.ucRangeMaxMin1.RTCUseCheckbox = true;
            this.ucRangeMaxMin1.RTCUseFeatures = false;
            this.ucRangeMaxMin1.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMin1.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMin1.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMin1.RTCValuePropertyName = "ColumnRange";
            this.ucRangeMaxMin1.Size = new System.Drawing.Size(417, 37);
            this.ucRangeMaxMin1.TabIndex = 4;
            // 
            // ucRangeMaxMin2
            // 
            this.ucRangeMaxMin2.AutoSize = true;
            this.ucRangeMaxMin2.Location = new System.Drawing.Point(52, 82);
            this.ucRangeMaxMin2.Margin = new System.Windows.Forms.Padding(4);
            this.ucRangeMaxMin2.Name = "ucRangeMaxMin2";
            this.ucRangeMaxMin2.RTCAction = null;
            this.ucRangeMaxMin2.RTCActualPropertyName = "ActualRow";
            this.ucRangeMaxMin2.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMin2.RTCCheckboxCaption = "Row";
            this.ucRangeMaxMin2.RTCCheckboxPropertyName = "EnableRowFilter";
            this.ucRangeMaxMin2.RTCCheckboxSize = 100;
            this.ucRangeMaxMin2.RTCChecked = false;
            this.ucRangeMaxMin2.RTCEditMask = "n2";
            this.ucRangeMaxMin2.RTCFeaturesLabel = "Features";
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
            this.ucRangeMaxMin2.RTCValuePropertyName = "RowRange";
            this.ucRangeMaxMin2.Size = new System.Drawing.Size(417, 37);
            this.ucRangeMaxMin2.TabIndex = 3;
            // 
            // lblSetPropertiesToOtherROI
            // 
            this.lblSetPropertiesToOtherROI.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSetPropertiesToOtherROI.Image = global::RTC_Vision_Lite.Properties.Resources.ChartsShowLegend_16x16;
            this.lblSetPropertiesToOtherROI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSetPropertiesToOtherROI.Location = new System.Drawing.Point(23, 256);
            this.lblSetPropertiesToOtherROI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSetPropertiesToOtherROI.Name = "lblSetPropertiesToOtherROI";
            this.lblSetPropertiesToOtherROI.Size = new System.Drawing.Size(284, 25);
            this.lblSetPropertiesToOtherROI.TabIndex = 26;
            this.lblSetPropertiesToOtherROI.Text = "Appy Properties To Orther ROI";
            this.lblSetPropertiesToOtherROI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 299);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Origin Type";
            // 
            // lblSetupPassed
            // 
            this.lblSetupPassed.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSetupPassed.Image = global::RTC_Vision_Lite.Properties.Resources.ModelEditor_Settings1;
            this.lblSetupPassed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSetupPassed.Location = new System.Drawing.Point(327, 256);
            this.lblSetupPassed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSetupPassed.Name = "lblSetupPassed";
            this.lblSetupPassed.Size = new System.Drawing.Size(108, 25);
            this.lblSetupPassed.TabIndex = 27;
            this.lblSetupPassed.Text = "Setup";
            this.lblSetupPassed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RTCOriginType
            // 
            this.RTCOriginType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCOriginType.FormattingEnabled = true;
            this.RTCOriginType.Location = new System.Drawing.Point(135, 295);
            this.RTCOriginType.Margin = new System.Windows.Forms.Padding(4);
            this.RTCOriginType.Name = "RTCOriginType";
            this.RTCOriginType.Size = new System.Drawing.Size(283, 21);
            this.RTCOriginType.TabIndex = 26;
            // 
            // btnRunMultiROI
            // 
            this.btnRunMultiROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunMultiROI.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x161;
            this.btnRunMultiROI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunMultiROI.Location = new System.Drawing.Point(135, 338);
            this.btnRunMultiROI.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunMultiROI.Name = "btnRunMultiROI";
            this.btnRunMultiROI.Size = new System.Drawing.Size(100, 30);
            this.btnRunMultiROI.TabIndex = 28;
            this.btnRunMultiROI.Text = "Run(F5)";
            this.btnRunMultiROI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunMultiROI.UseVisualStyleBackColor = true;
            // 
            // chkRunOnlyROISelect
            // 
            this.chkRunOnlyROISelect.AutoSize = true;
            this.chkRunOnlyROISelect.Location = new System.Drawing.Point(261, 345);
            this.chkRunOnlyROISelect.Margin = new System.Windows.Forms.Padding(4);
            this.chkRunOnlyROISelect.Name = "chkRunOnlyROISelect";
            this.chkRunOnlyROISelect.Size = new System.Drawing.Size(118, 17);
            this.chkRunOnlyROISelect.TabIndex = 29;
            this.chkRunOnlyROISelect.Text = "Only ROI Selected";
            this.chkRunOnlyROISelect.UseVisualStyleBackColor = true;
            // 
            // ucOriginActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ucOriginActionDetail";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label2;
        private ucImageLink ucImageLink;
        private ucOrigin ucOrigin1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RTCSamplingPercent;
        private System.Windows.Forms.TextBox RTCEdgeDetectionThreshold;
        private System.Windows.Forms.ComboBox RTCEdgeType;
        private System.Windows.Forms.ComboBox RTCEdgeTransition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lable10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox RTCOutlierDistanceThreshold;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox RTCDefaultOrigin;
        private System.Windows.Forms.TextBox RTCMinEdgePointNumber;
        private System.Windows.Forms.ComboBox RTCROILegend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox RTCSubpixelMethod;
        private System.Windows.Forms.GroupBox groupBox2;
        private ucRangeMaxMin ucRangeMaxMin3;
        private ucRangeMaxMin ucRangeMaxMin1;
        private ucRangeMaxMin ucRangeMaxMin2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblSetPropertiesToOtherROI;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblSetupPassed;
        private System.Windows.Forms.Button btnRunMultiROI;
        private System.Windows.Forms.ComboBox RTCOriginType;
        private System.Windows.Forms.CheckBox chkRunOnlyROISelect;
    }
}
