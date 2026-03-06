
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
            this.label9 = new System.Windows.Forms.Label();
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
            this.ScrollableGeneral.Location = new System.Drawing.Point(4, 4);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableGeneral.Size = new System.Drawing.Size(853, 401);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(4, 41);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(4);
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
            this.ScrollablePassFail.Controls.Add(this.groupBox2);
            this.ScrollablePassFail.Controls.Add(this.label9);
            this.ScrollablePassFail.Controls.Add(this.label10);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(861, 409);
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
            this.ScrollableROI.Location = new System.Drawing.Point(4, 4);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableROI.Size = new System.Drawing.Size(853, 401);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
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
            this.RTCName.Size = new System.Drawing.Size(639, 22);
            this.RTCName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 18);
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
            this.ucImageLink.Location = new System.Drawing.Point(20, 59);
            this.ucImageLink.Margin = new System.Windows.Forms.Padding(4);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(677, 65);
            this.ucImageLink.TabIndex = 12;
            // 
            // ucOrigin1
            // 
            this.ucOrigin1.Action = null;
            this.ucOrigin1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin1.Location = new System.Drawing.Point(20, 156);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(677, 87);
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
            this.groupBox1.Location = new System.Drawing.Point(20, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 185);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // RTCOutlierDistanceThreshold
            // 
            this.RTCOutlierDistanceThreshold.Location = new System.Drawing.Point(420, 125);
            this.RTCOutlierDistanceThreshold.Name = "RTCOutlierDistanceThreshold";
            this.RTCOutlierDistanceThreshold.Size = new System.Drawing.Size(166, 22);
            this.RTCOutlierDistanceThreshold.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(314, 128);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Outlier Threshold";
            // 
            // RTCDefaultOrigin
            // 
            this.RTCDefaultOrigin.Location = new System.Drawing.Point(420, 96);
            this.RTCDefaultOrigin.Name = "RTCDefaultOrigin";
            this.RTCDefaultOrigin.Size = new System.Drawing.Size(166, 22);
            this.RTCDefaultOrigin.TabIndex = 23;
            // 
            // RTCMinEdgePointNumber
            // 
            this.RTCMinEdgePointNumber.Location = new System.Drawing.Point(420, 65);
            this.RTCMinEdgePointNumber.Name = "RTCMinEdgePointNumber";
            this.RTCMinEdgePointNumber.Size = new System.Drawing.Size(166, 22);
            this.RTCMinEdgePointNumber.TabIndex = 22;
            // 
            // RTCROILegend
            // 
            this.RTCROILegend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCROILegend.FormattingEnabled = true;
            this.RTCROILegend.Location = new System.Drawing.Point(420, 35);
            this.RTCROILegend.Name = "RTCROILegend";
            this.RTCROILegend.Size = new System.Drawing.Size(166, 21);
            this.RTCROILegend.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Default Origin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "ROI Legend";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(314, 68);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Min Edge Point";
            // 
            // RTCSubpixelMethod
            // 
            this.RTCSubpixelMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSubpixelMethod.FormattingEnabled = true;
            this.RTCSubpixelMethod.Location = new System.Drawing.Point(128, 158);
            this.RTCSubpixelMethod.Name = "RTCSubpixelMethod";
            this.RTCSubpixelMethod.Size = new System.Drawing.Size(166, 21);
            this.RTCSubpixelMethod.TabIndex = 17;
            // 
            // RTCSamplingPercent
            // 
            this.RTCSamplingPercent.Location = new System.Drawing.Point(128, 125);
            this.RTCSamplingPercent.Name = "RTCSamplingPercent";
            this.RTCSamplingPercent.Size = new System.Drawing.Size(166, 22);
            this.RTCSamplingPercent.TabIndex = 16;
            // 
            // RTCEdgeDetectionThreshold
            // 
            this.RTCEdgeDetectionThreshold.Location = new System.Drawing.Point(128, 94);
            this.RTCEdgeDetectionThreshold.Name = "RTCEdgeDetectionThreshold";
            this.RTCEdgeDetectionThreshold.Size = new System.Drawing.Size(166, 22);
            this.RTCEdgeDetectionThreshold.TabIndex = 15;
            // 
            // RTCEdgeType
            // 
            this.RTCEdgeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCEdgeType.FormattingEnabled = true;
            this.RTCEdgeType.Location = new System.Drawing.Point(128, 35);
            this.RTCEdgeType.Name = "RTCEdgeType";
            this.RTCEdgeType.Size = new System.Drawing.Size(166, 21);
            this.RTCEdgeType.TabIndex = 14;
            // 
            // RTCEdgeTransition
            // 
            this.RTCEdgeTransition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCEdgeTransition.FormattingEnabled = true;
            this.RTCEdgeTransition.Location = new System.Drawing.Point(128, 64);
            this.RTCEdgeTransition.Name = "RTCEdgeTransition";
            this.RTCEdgeTransition.Size = new System.Drawing.Size(166, 21);
            this.RTCEdgeTransition.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Edge Type";
            // 
            // lable10
            // 
            this.lable10.AutoSize = true;
            this.lable10.Location = new System.Drawing.Point(22, 164);
            this.lable10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lable10.Name = "lable10";
            this.lable10.Size = new System.Drawing.Size(95, 13);
            this.lable10.TabIndex = 9;
            this.lable10.Text = "Subpixel Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sampling Percent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Edge Transition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Edge Threshold";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(97, 21);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Passed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.groupBox2.Location = new System.Drawing.Point(20, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 155);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // ucRangeMaxMin3
            // 
            this.ucRangeMaxMin3.AutoSize = true;
            this.ucRangeMaxMin3.Location = new System.Drawing.Point(39, 103);
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
            this.ucRangeMaxMin3.Size = new System.Drawing.Size(313, 30);
            this.ucRangeMaxMin3.TabIndex = 5;
            // 
            // ucRangeMaxMin1
            // 
            this.ucRangeMaxMin1.AutoSize = true;
            this.ucRangeMaxMin1.Location = new System.Drawing.Point(39, 31);
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
            this.ucRangeMaxMin1.Size = new System.Drawing.Size(313, 30);
            this.ucRangeMaxMin1.TabIndex = 4;
            // 
            // ucRangeMaxMin2
            // 
            this.ucRangeMaxMin2.AutoSize = true;
            this.ucRangeMaxMin2.Location = new System.Drawing.Point(39, 67);
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
            this.ucRangeMaxMin2.Size = new System.Drawing.Size(313, 30);
            this.ucRangeMaxMin2.TabIndex = 3;
            // 
            // lblSetPropertiesToOtherROI
            // 
            this.lblSetPropertiesToOtherROI.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSetPropertiesToOtherROI.Image = global::RTC_Vision_Lite.Properties.Resources.ChartsShowLegend_16x16;
            this.lblSetPropertiesToOtherROI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSetPropertiesToOtherROI.Location = new System.Drawing.Point(17, 216);
            this.lblSetPropertiesToOtherROI.Name = "lblSetPropertiesToOtherROI";
            this.lblSetPropertiesToOtherROI.Size = new System.Drawing.Size(213, 20);
            this.lblSetPropertiesToOtherROI.TabIndex = 26;
            this.lblSetPropertiesToOtherROI.Text = "Appy Properties To Orther ROI";
            this.lblSetPropertiesToOtherROI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 251);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Origin Type";
            // 
            // lblSetupPassed
            // 
            this.lblSetupPassed.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSetupPassed.Image = global::RTC_Vision_Lite.Properties.Resources.ModelEditor_Settings1;
            this.lblSetupPassed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSetupPassed.Location = new System.Drawing.Point(245, 216);
            this.lblSetupPassed.Name = "lblSetupPassed";
            this.lblSetupPassed.Size = new System.Drawing.Size(81, 20);
            this.lblSetupPassed.TabIndex = 27;
            this.lblSetupPassed.Text = "Setup";
            this.lblSetupPassed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RTCOriginType
            // 
            this.RTCOriginType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCOriginType.FormattingEnabled = true;
            this.RTCOriginType.Location = new System.Drawing.Point(101, 248);
            this.RTCOriginType.Name = "RTCOriginType";
            this.RTCOriginType.Size = new System.Drawing.Size(213, 21);
            this.RTCOriginType.TabIndex = 26;
            // 
            // btnRunMultiROI
            // 
            this.btnRunMultiROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunMultiROI.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x161;
            this.btnRunMultiROI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunMultiROI.Location = new System.Drawing.Point(101, 283);
            this.btnRunMultiROI.Name = "btnRunMultiROI";
            this.btnRunMultiROI.Size = new System.Drawing.Size(75, 24);
            this.btnRunMultiROI.TabIndex = 28;
            this.btnRunMultiROI.Text = "Run(F5)";
            this.btnRunMultiROI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunMultiROI.UseVisualStyleBackColor = true;
            // 
            // chkRunOnlyROISelect
            // 
            this.chkRunOnlyROISelect.AutoSize = true;
            this.chkRunOnlyROISelect.Location = new System.Drawing.Point(196, 288);
            this.chkRunOnlyROISelect.Name = "chkRunOnlyROISelect";
            this.chkRunOnlyROISelect.Size = new System.Drawing.Size(118, 17);
            this.chkRunOnlyROISelect.TabIndex = 29;
            this.chkRunOnlyROISelect.Text = "Only ROI Selected";
            this.chkRunOnlyROISelect.UseVisualStyleBackColor = true;
            // 
            // ucOriginActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Label label9;
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
