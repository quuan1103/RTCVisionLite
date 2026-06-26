
namespace RTC_Vision_Lite.UserControls
{
    partial class ucBlobActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBlobActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMinRow = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinColumn = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMin5 = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMin4 = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinHeight = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxArea = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinWidth = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.label9 = new System.Windows.Forms.Label();
            this.RTCPositionMode = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RTCEnableOutputDimsList = new System.Windows.Forms.CheckBox();
            this.RTCEnableOutputAreaList = new System.Windows.Forms.CheckBox();
            this.RTCEnableOutputBlobList = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMinNumberOfBlob = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinLimit1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.RTCDynamicFeature = new System.Windows.Forms.ComboBox();
            this.RTCDynamicOffset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.RTCThresholdRange = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.RTCGreyLevelThresholdType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RTCFillHoles = new System.Windows.Forms.CheckBox();
            this.RTCDetectType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.ucOrigin = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollablePassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(5, 5);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1153, 501);
            this.ScrollableGeneral.Paint += new System.Windows.Forms.PaintEventHandler(this.ScrollableGeneral_Paint);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(3, 48);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PageSetup.Size = new System.Drawing.Size(1186, 519);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ROI.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ROI.Size = new System.Drawing.Size(1561, 642);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PassFail.Size = new System.Drawing.Size(1561, 642);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Controls.Add(this.groupBox9);
            this.ScrollablePassFail.Controls.Add(this.groupBox7);
            this.ScrollablePassFail.Controls.Add(this.groupBox6);
            this.ScrollablePassFail.Controls.Add(this.RTCPassed);
            this.ScrollablePassFail.Controls.Add(this.label6);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1561, 642);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.groupBox3);
            this.ScrollableROI.Location = new System.Drawing.Point(5, 5);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableROI.Size = new System.Drawing.Size(1551, 632);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Size = new System.Drawing.Size(1186, 46);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Method.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Method.Size = new System.Drawing.Size(1561, 642);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Display.Size = new System.Drawing.Size(1561, 642);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(3, 2);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableMethod.Size = new System.Drawing.Size(1555, 638);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Location = new System.Drawing.Point(5, 5);
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(1551, 632);
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
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTCName.Location = new System.Drawing.Point(77, 18);
            this.RTCName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(959, 26);
            this.RTCName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pass/Fail:";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(109, 20);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(51, 19);
            this.RTCPassed.TabIndex = 1;
            this.RTCPassed.Text = "Passed";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ucRangeMaxMinRow);
            this.groupBox6.Controls.Add(this.ucRangeMaxMinColumn);
            this.groupBox6.Controls.Add(this.ucRangeMaxMin5);
            this.groupBox6.Controls.Add(this.ucRangeMaxMin4);
            this.groupBox6.Controls.Add(this.ucRangeMaxMinHeight);
            this.groupBox6.Controls.Add(this.ucRangeMaxArea);
            this.groupBox6.Controls.Add(this.ucRangeMaxMinWidth);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.RTCPositionMode);
            this.groupBox6.Location = new System.Drawing.Point(27, 44);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(491, 434);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Filter";
            // 
            // ucRangeMaxMinRow
            // 
            this.ucRangeMaxMinRow.AutoSize = true;
            this.ucRangeMaxMinRow.Location = new System.Drawing.Point(11, 327);
            this.ucRangeMaxMinRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRangeMaxMinRow.Name = "ucRangeMaxMinRow";
            this.ucRangeMaxMinRow.RTCAction = null;
            this.ucRangeMaxMinRow.RTCActualPropertyName = "RowActual";
            this.ucRangeMaxMinRow.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinRow.RTCCheckboxCaption = "Row";
            this.ucRangeMaxMinRow.RTCCheckboxPropertyName = "EnableRowFilter";
            this.ucRangeMaxMinRow.RTCCheckboxSize = 110;
            this.ucRangeMaxMinRow.RTCChecked = false;
            this.ucRangeMaxMinRow.RTCEditMask = "n2";
            this.ucRangeMaxMinRow.RTCFeaturesLabel = "";
            this.ucRangeMaxMinRow.RTCIsLimit = false;
            this.ucRangeMaxMinRow.RTCMaxLabel = "";
            this.ucRangeMaxMinRow.RTCMinLabel = "";
            this.ucRangeMaxMinRow.RTCTextboxSize = 75;
            this.ucRangeMaxMinRow.RTCUseActual = true;
            this.ucRangeMaxMinRow.RTCUseActualLabel = false;
            this.ucRangeMaxMinRow.RTCUseCheckbox = true;
            this.ucRangeMaxMinRow.RTCUseFeatures = false;
            this.ucRangeMaxMinRow.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinRow.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinRow.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinRow.RTCValuePropertyName = "RowRange";
            this.ucRangeMaxMinRow.Size = new System.Drawing.Size(444, 43);
            this.ucRangeMaxMinRow.TabIndex = 11;
            // 
            // ucRangeMaxMinColumn
            // 
            this.ucRangeMaxMinColumn.AutoSize = true;
            this.ucRangeMaxMinColumn.Location = new System.Drawing.Point(11, 279);
            this.ucRangeMaxMinColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRangeMaxMinColumn.Name = "ucRangeMaxMinColumn";
            this.ucRangeMaxMinColumn.RTCAction = null;
            this.ucRangeMaxMinColumn.RTCActualPropertyName = "ColumnActual";
            this.ucRangeMaxMinColumn.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinColumn.RTCCheckboxCaption = "Column";
            this.ucRangeMaxMinColumn.RTCCheckboxPropertyName = "EnableColumnFilter";
            this.ucRangeMaxMinColumn.RTCCheckboxSize = 110;
            this.ucRangeMaxMinColumn.RTCChecked = false;
            this.ucRangeMaxMinColumn.RTCEditMask = "n2";
            this.ucRangeMaxMinColumn.RTCFeaturesLabel = "";
            this.ucRangeMaxMinColumn.RTCIsLimit = false;
            this.ucRangeMaxMinColumn.RTCMaxLabel = "";
            this.ucRangeMaxMinColumn.RTCMinLabel = "";
            this.ucRangeMaxMinColumn.RTCTextboxSize = 75;
            this.ucRangeMaxMinColumn.RTCUseActual = true;
            this.ucRangeMaxMinColumn.RTCUseActualLabel = false;
            this.ucRangeMaxMinColumn.RTCUseCheckbox = true;
            this.ucRangeMaxMinColumn.RTCUseFeatures = false;
            this.ucRangeMaxMinColumn.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinColumn.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinColumn.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinColumn.RTCValuePropertyName = "ColumnRange";
            this.ucRangeMaxMinColumn.Size = new System.Drawing.Size(444, 43);
            this.ucRangeMaxMinColumn.TabIndex = 10;
            // 
            // ucRangeMaxMin5
            // 
            this.ucRangeMaxMin5.AutoSize = true;
            this.ucRangeMaxMin5.Location = new System.Drawing.Point(11, 231);
            this.ucRangeMaxMin5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRangeMaxMin5.Name = "ucRangeMaxMin5";
            this.ucRangeMaxMin5.RTCAction = null;
            this.ucRangeMaxMin5.RTCActualPropertyName = "CircularityActual";
            this.ucRangeMaxMin5.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMin5.RTCCheckboxCaption = "Circularity";
            this.ucRangeMaxMin5.RTCCheckboxPropertyName = "EnableCircularityFilter";
            this.ucRangeMaxMin5.RTCCheckboxSize = 110;
            this.ucRangeMaxMin5.RTCChecked = false;
            this.ucRangeMaxMin5.RTCEditMask = "n2";
            this.ucRangeMaxMin5.RTCFeaturesLabel = "";
            this.ucRangeMaxMin5.RTCIsLimit = false;
            this.ucRangeMaxMin5.RTCMaxLabel = "";
            this.ucRangeMaxMin5.RTCMinLabel = "";
            this.ucRangeMaxMin5.RTCTextboxSize = 75;
            this.ucRangeMaxMin5.RTCUseActual = true;
            this.ucRangeMaxMin5.RTCUseActualLabel = false;
            this.ucRangeMaxMin5.RTCUseCheckbox = true;
            this.ucRangeMaxMin5.RTCUseFeatures = false;
            this.ucRangeMaxMin5.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMin5.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMin5.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMin5.RTCValuePropertyName = "CircularityRange";
            this.ucRangeMaxMin5.Size = new System.Drawing.Size(444, 43);
            this.ucRangeMaxMin5.TabIndex = 7;
            // 
            // ucRangeMaxMin4
            // 
            this.ucRangeMaxMin4.AutoSize = true;
            this.ucRangeMaxMin4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ucRangeMaxMin4.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.ucRangeMaxMin4.Location = new System.Drawing.Point(11, 188);
            this.ucRangeMaxMin4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRangeMaxMin4.Name = "ucRangeMaxMin4";
            this.ucRangeMaxMin4.RTCAction = null;
            this.ucRangeMaxMin4.RTCActualPropertyName = "OuterRadiusActual";
            this.ucRangeMaxMin4.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMin4.RTCCheckboxCaption = "Outer Radius";
            this.ucRangeMaxMin4.RTCCheckboxPropertyName = "EnableOuterRadiusFilter";
            this.ucRangeMaxMin4.RTCCheckboxSize = 110;
            this.ucRangeMaxMin4.RTCChecked = false;
            this.ucRangeMaxMin4.RTCEditMask = "n2";
            this.ucRangeMaxMin4.RTCFeaturesLabel = "";
            this.ucRangeMaxMin4.RTCIsLimit = false;
            this.ucRangeMaxMin4.RTCMaxLabel = "";
            this.ucRangeMaxMin4.RTCMinLabel = "";
            this.ucRangeMaxMin4.RTCTextboxSize = 75;
            this.ucRangeMaxMin4.RTCUseActual = true;
            this.ucRangeMaxMin4.RTCUseActualLabel = false;
            this.ucRangeMaxMin4.RTCUseCheckbox = true;
            this.ucRangeMaxMin4.RTCUseFeatures = false;
            this.ucRangeMaxMin4.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMin4.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMin4.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMin4.RTCValuePropertyName = "OuterRadiusRange";
            this.ucRangeMaxMin4.Size = new System.Drawing.Size(444, 43);
            this.ucRangeMaxMin4.TabIndex = 6;
            // 
            // ucRangeMaxMinHeight
            // 
            this.ucRangeMaxMinHeight.AutoSize = true;
            this.ucRangeMaxMinHeight.Location = new System.Drawing.Point(11, 149);
            this.ucRangeMaxMinHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRangeMaxMinHeight.Name = "ucRangeMaxMinHeight";
            this.ucRangeMaxMinHeight.RTCAction = null;
            this.ucRangeMaxMinHeight.RTCActualPropertyName = "HeightActual";
            this.ucRangeMaxMinHeight.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinHeight.RTCCheckboxCaption = "Height";
            this.ucRangeMaxMinHeight.RTCCheckboxPropertyName = "EnableHeightFilter";
            this.ucRangeMaxMinHeight.RTCCheckboxSize = 110;
            this.ucRangeMaxMinHeight.RTCChecked = false;
            this.ucRangeMaxMinHeight.RTCEditMask = "n2";
            this.ucRangeMaxMinHeight.RTCFeaturesLabel = "";
            this.ucRangeMaxMinHeight.RTCIsLimit = false;
            this.ucRangeMaxMinHeight.RTCMaxLabel = "";
            this.ucRangeMaxMinHeight.RTCMinLabel = "";
            this.ucRangeMaxMinHeight.RTCTextboxSize = 75;
            this.ucRangeMaxMinHeight.RTCUseActual = true;
            this.ucRangeMaxMinHeight.RTCUseActualLabel = false;
            this.ucRangeMaxMinHeight.RTCUseCheckbox = true;
            this.ucRangeMaxMinHeight.RTCUseFeatures = false;
            this.ucRangeMaxMinHeight.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinHeight.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinHeight.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinHeight.RTCValuePropertyName = "HeightRange";
            this.ucRangeMaxMinHeight.Size = new System.Drawing.Size(444, 43);
            this.ucRangeMaxMinHeight.TabIndex = 5;
            // 
            // ucRangeMaxArea
            // 
            this.ucRangeMaxArea.AutoSize = true;
            this.ucRangeMaxArea.Location = new System.Drawing.Point(11, 23);
            this.ucRangeMaxArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRangeMaxArea.Name = "ucRangeMaxArea";
            this.ucRangeMaxArea.RTCAction = null;
            this.ucRangeMaxArea.RTCActualPropertyName = "AreaActual";
            this.ucRangeMaxArea.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxArea.RTCCheckboxCaption = "Area";
            this.ucRangeMaxArea.RTCCheckboxPropertyName = "EnableAreaFilter";
            this.ucRangeMaxArea.RTCCheckboxSize = 110;
            this.ucRangeMaxArea.RTCChecked = true;
            this.ucRangeMaxArea.RTCEditMask = "n2";
            this.ucRangeMaxArea.RTCFeaturesLabel = "Features";
            this.ucRangeMaxArea.RTCIsLimit = false;
            this.ucRangeMaxArea.RTCMaxLabel = "Maximum";
            this.ucRangeMaxArea.RTCMinLabel = "Minimum";
            this.ucRangeMaxArea.RTCTextboxSize = 75;
            this.ucRangeMaxArea.RTCUseActual = true;
            this.ucRangeMaxArea.RTCUseActualLabel = true;
            this.ucRangeMaxArea.RTCUseCheckbox = true;
            this.ucRangeMaxArea.RTCUseFeatures = true;
            this.ucRangeMaxArea.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxArea.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxArea.RTCUseMinMaxAtTop = true;
            this.ucRangeMaxArea.RTCValuePropertyName = "AreaRange";
            this.ucRangeMaxArea.Size = new System.Drawing.Size(455, 75);
            this.ucRangeMaxArea.TabIndex = 4;
            // 
            // ucRangeMaxMinWidth
            // 
            this.ucRangeMaxMinWidth.AutoSize = true;
            this.ucRangeMaxMinWidth.Location = new System.Drawing.Point(11, 103);
            this.ucRangeMaxMinWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRangeMaxMinWidth.Name = "ucRangeMaxMinWidth";
            this.ucRangeMaxMinWidth.RTCAction = null;
            this.ucRangeMaxMinWidth.RTCActualPropertyName = "WidthActual";
            this.ucRangeMaxMinWidth.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinWidth.RTCCheckboxCaption = "Width";
            this.ucRangeMaxMinWidth.RTCCheckboxPropertyName = "EnableWidthFilter";
            this.ucRangeMaxMinWidth.RTCCheckboxSize = 110;
            this.ucRangeMaxMinWidth.RTCChecked = false;
            this.ucRangeMaxMinWidth.RTCEditMask = "n2";
            this.ucRangeMaxMinWidth.RTCFeaturesLabel = "";
            this.ucRangeMaxMinWidth.RTCIsLimit = false;
            this.ucRangeMaxMinWidth.RTCMaxLabel = "";
            this.ucRangeMaxMinWidth.RTCMinLabel = "";
            this.ucRangeMaxMinWidth.RTCTextboxSize = 75;
            this.ucRangeMaxMinWidth.RTCUseActual = true;
            this.ucRangeMaxMinWidth.RTCUseActualLabel = false;
            this.ucRangeMaxMinWidth.RTCUseCheckbox = true;
            this.ucRangeMaxMinWidth.RTCUseFeatures = false;
            this.ucRangeMaxMinWidth.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinWidth.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinWidth.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinWidth.RTCValuePropertyName = "WidthRange";
            this.ucRangeMaxMinWidth.Size = new System.Drawing.Size(444, 41);
            this.ucRangeMaxMinWidth.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 19);
            this.label9.TabIndex = 2;
            this.label9.Text = "Position Mode";
            // 
            // RTCPositionMode
            // 
            this.RTCPositionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCPositionMode.FormattingEnabled = true;
            this.RTCPositionMode.Location = new System.Drawing.Point(177, 383);
            this.RTCPositionMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCPositionMode.Name = "RTCPositionMode";
            this.RTCPositionMode.Size = new System.Drawing.Size(273, 27);
            this.RTCPositionMode.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RTCEnableOutputDimsList);
            this.groupBox7.Controls.Add(this.RTCEnableOutputAreaList);
            this.groupBox7.Controls.Add(this.RTCEnableOutputBlobList);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Location = new System.Drawing.Point(547, 44);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(312, 146);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Outputs";
            // 
            // RTCEnableOutputDimsList
            // 
            this.RTCEnableOutputDimsList.AutoSize = true;
            this.RTCEnableOutputDimsList.Location = new System.Drawing.Point(32, 106);
            this.RTCEnableOutputDimsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCEnableOutputDimsList.Name = "RTCEnableOutputDimsList";
            this.RTCEnableOutputDimsList.Size = new System.Drawing.Size(174, 23);
            this.RTCEnableOutputDimsList.TabIndex = 3;
            this.RTCEnableOutputDimsList.Text = "Enable Output Dim List";
            this.RTCEnableOutputDimsList.UseVisualStyleBackColor = true;
            // 
            // RTCEnableOutputAreaList
            // 
            this.RTCEnableOutputAreaList.AutoSize = true;
            this.RTCEnableOutputAreaList.Location = new System.Drawing.Point(32, 78);
            this.RTCEnableOutputAreaList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCEnableOutputAreaList.Name = "RTCEnableOutputAreaList";
            this.RTCEnableOutputAreaList.Size = new System.Drawing.Size(177, 23);
            this.RTCEnableOutputAreaList.TabIndex = 2;
            this.RTCEnableOutputAreaList.Text = "Enable Output Area List";
            this.RTCEnableOutputAreaList.UseVisualStyleBackColor = true;
            // 
            // RTCEnableOutputBlobList
            // 
            this.RTCEnableOutputBlobList.AutoSize = true;
            this.RTCEnableOutputBlobList.Checked = true;
            this.RTCEnableOutputBlobList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RTCEnableOutputBlobList.Location = new System.Drawing.Point(32, 48);
            this.RTCEnableOutputBlobList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCEnableOutputBlobList.Name = "RTCEnableOutputBlobList";
            this.RTCEnableOutputBlobList.Size = new System.Drawing.Size(176, 23);
            this.RTCEnableOutputBlobList.TabIndex = 1;
            this.RTCEnableOutputBlobList.Text = "Enable Output Blob List";
            this.RTCEnableOutputBlobList.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Feature";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ucRangeMaxMinNumberOfBlob);
            this.groupBox9.Location = new System.Drawing.Point(547, 206);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Size = new System.Drawing.Size(312, 130);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Filter Number of Blobs";
            // 
            // ucRangeMaxMinNumberOfBlob
            // 
            this.ucRangeMaxMinNumberOfBlob.AutoSize = true;
            this.ucRangeMaxMinNumberOfBlob.Location = new System.Drawing.Point(7, 30);
            this.ucRangeMaxMinNumberOfBlob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRangeMaxMinNumberOfBlob.Name = "ucRangeMaxMinNumberOfBlob";
            this.ucRangeMaxMinNumberOfBlob.RTCAction = null;
            this.ucRangeMaxMinNumberOfBlob.RTCActualPropertyName = "NumberOfBlobsFound";
            this.ucRangeMaxMinNumberOfBlob.RTCAllowInfinityMaxValue = false;
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxCaption = "Rectangularity";
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxPropertyName = "";
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxSize = 100;
            this.ucRangeMaxMinNumberOfBlob.RTCChecked = false;
            this.ucRangeMaxMinNumberOfBlob.RTCEditMask = "n0";
            this.ucRangeMaxMinNumberOfBlob.RTCFeaturesLabel = "";
            this.ucRangeMaxMinNumberOfBlob.RTCIsLimit = false;
            this.ucRangeMaxMinNumberOfBlob.RTCMaxLabel = "Max    ";
            this.ucRangeMaxMinNumberOfBlob.RTCMinLabel = "Min    ";
            this.ucRangeMaxMinNumberOfBlob.RTCTextboxSize = 75;
            this.ucRangeMaxMinNumberOfBlob.RTCUseActual = true;
            this.ucRangeMaxMinNumberOfBlob.RTCUseActualLabel = true;
            this.ucRangeMaxMinNumberOfBlob.RTCUseCheckbox = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseFeatures = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseMinMaxAtTop = true;
            this.ucRangeMaxMinNumberOfBlob.RTCValuePropertyName = "RequiredNumberOfBlobs";
            this.ucRangeMaxMinNumberOfBlob.Size = new System.Drawing.Size(308, 79);
            this.ucRangeMaxMinNumberOfBlob.TabIndex = 12;
            // 
            // ucRangeMaxMinLimit1
            // 
            this.ucRangeMaxMinLimit1.Location = new System.Drawing.Point(6, 16);
            this.ucRangeMaxMinLimit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucRangeMaxMinLimit1.Name = "ucRangeMaxMinLimit1";
            this.ucRangeMaxMinLimit1.RTCAction = null;
            this.ucRangeMaxMinLimit1.RTCBeginValue = 0D;
            this.ucRangeMaxMinLimit1.RTCEndValue = 25D;
            this.ucRangeMaxMinLimit1.RTCMax = 100D;
            this.ucRangeMaxMinLimit1.RTCMin = 0D;
            this.ucRangeMaxMinLimit1.RTCPropertyName = null;
            this.ucRangeMaxMinLimit1.RTCStepChange = 0.1D;
            this.ucRangeMaxMinLimit1.RTCValuePropertyName = null;
            this.ucRangeMaxMinLimit1.Size = new System.Drawing.Size(244, 95);
            this.ucRangeMaxMinLimit1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.RTCFillHoles);
            this.groupBox3.Controls.Add(this.RTCDetectType);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(13, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1121, 476);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.groupBox11);
            this.groupBox8.Controls.Add(this.RTCGreyLevelThresholdType);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Location = new System.Drawing.Point(27, 106);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(1071, 231);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Threshold";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.RTCDynamicFeature);
            this.groupBox10.Controls.Add(this.RTCDynamicOffset);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Location = new System.Drawing.Point(565, 79);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(324, 119);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Dynamic Threshold";
            // 
            // RTCDynamicFeature
            // 
            this.RTCDynamicFeature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDynamicFeature.FormattingEnabled = true;
            this.RTCDynamicFeature.Location = new System.Drawing.Point(121, 74);
            this.RTCDynamicFeature.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCDynamicFeature.Name = "RTCDynamicFeature";
            this.RTCDynamicFeature.Size = new System.Drawing.Size(167, 27);
            this.RTCDynamicFeature.TabIndex = 8;
            // 
            // RTCDynamicOffset
            // 
            this.RTCDynamicOffset.Location = new System.Drawing.Point(121, 31);
            this.RTCDynamicOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCDynamicOffset.Name = "RTCDynamicOffset";
            this.RTCDynamicOffset.Size = new System.Drawing.Size(167, 26);
            this.RTCDynamicOffset.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Offset";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Light / Dark";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.RTCThresholdRange);
            this.groupBox11.Location = new System.Drawing.Point(133, 79);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Size = new System.Drawing.Size(297, 119);
            this.groupBox11.TabIndex = 5;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Fixed Threshold Range";
            // 
            // RTCThresholdRange
            // 
            this.RTCThresholdRange.Location = new System.Drawing.Point(28, 23);
            this.RTCThresholdRange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCThresholdRange.Name = "RTCThresholdRange";
            this.RTCThresholdRange.RTCAction = null;
            this.RTCThresholdRange.RTCBeginValue = 0D;
            this.RTCThresholdRange.RTCEndValue = 25D;
            this.RTCThresholdRange.RTCMax = 255D;
            this.RTCThresholdRange.RTCMin = 0D;
            this.RTCThresholdRange.RTCPropertyName = "ThresholdRange";
            this.RTCThresholdRange.RTCStepChange = 1D;
            this.RTCThresholdRange.RTCValuePropertyName = "AutoThresholdRange";
            this.RTCThresholdRange.Size = new System.Drawing.Size(256, 90);
            this.RTCThresholdRange.TabIndex = 0;
            // 
            // RTCGreyLevelThresholdType
            // 
            this.RTCGreyLevelThresholdType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCGreyLevelThresholdType.FormattingEnabled = true;
            this.RTCGreyLevelThresholdType.Items.AddRange(new object[] {
            "Fixed Threshold Range"});
            this.RTCGreyLevelThresholdType.Location = new System.Drawing.Point(132, 31);
            this.RTCGreyLevelThresholdType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCGreyLevelThresholdType.Name = "RTCGreyLevelThresholdType";
            this.RTCGreyLevelThresholdType.Size = new System.Drawing.Size(235, 27);
            this.RTCGreyLevelThresholdType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Type";
            // 
            // RTCFillHoles
            // 
            this.RTCFillHoles.AutoSize = true;
            this.RTCFillHoles.Location = new System.Drawing.Point(27, 69);
            this.RTCFillHoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCFillHoles.Name = "RTCFillHoles";
            this.RTCFillHoles.Size = new System.Drawing.Size(116, 23);
            this.RTCFillHoles.TabIndex = 3;
            this.RTCFillHoles.Text = "Fill Blob Holes";
            this.RTCFillHoles.UseVisualStyleBackColor = true;
            // 
            // RTCDetectType
            // 
            this.RTCDetectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDetectType.FormattingEnabled = true;
            this.RTCDetectType.Location = new System.Drawing.Point(109, 30);
            this.RTCDetectType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCDetectType.Name = "RTCDetectType";
            this.RTCDetectType.Size = new System.Drawing.Size(235, 27);
            this.RTCDetectType.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Detect Type";
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(11, 81);
            this.ucImageLink.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputGrayImage";
            this.ucImageLink.Size = new System.Drawing.Size(1025, 117);
            this.ucImageLink.TabIndex = 2;
            // 
            // ucOrigin
            // 
            this.ucOrigin.Action = null;
            this.ucOrigin.Location = new System.Drawing.Point(11, 208);
            this.ucOrigin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucOrigin.Name = "ucOrigin";
            this.ucOrigin.PropertyName = "ToolOrigin";
            this.ucOrigin.Size = new System.Drawing.Size(1025, 121);
            this.ucOrigin.TabIndex = 3;
            // 
            // ucBlobActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ucBlobActionDetail";
            this.Load += new System.EventHandler(this.ucBlobActionDetail_Load);
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.ScrollablePassFail.ResumeLayout(false);
            this.ScrollablePassFail.PerformLayout();
            this.ScrollableROI.ResumeLayout(false);
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox RTCEnableOutputDimsList;
        private System.Windows.Forms.CheckBox RTCEnableOutputAreaList;
        private System.Windows.Forms.CheckBox RTCEnableOutputBlobList;
        private System.Windows.Forms.Label label7;
        private UserControls.ucRangeMaxMin ucRangeMaxArea;
        private UserControls.ucRangeMaxMin ucRangeMaxMinWidth;
        private UserControls.ucRangeMaxMin ucRangeMaxMin4;
        private UserControls.ucRangeMaxMin ucRangeMaxMinHeight;
        private UserControls.ucRangeMaxMin ucRangeMaxMin5;
        private UserControls.ucRangeMaxMin ucRangeMaxMinRow;
        private UserControls.ucRangeMaxMin ucRangeMaxMinColumn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox RTCPositionMode;
        private System.Windows.Forms.GroupBox groupBox9;
        private UserControls.ucRangeMaxMin ucRangeMaxMinNumberOfBlob;
        private UserControls.ucRangeMaxMinLimit ucRangeMaxMinLimit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox RTCDetectType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private UserControls.ucRangeMaxMinLimit RTCThresholdRange;
        private System.Windows.Forms.ComboBox RTCGreyLevelThresholdType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RTCFillHoles;
        private System.Windows.Forms.ComboBox RTCDynamicFeature;
        private System.Windows.Forms.TextBox RTCDynamicOffset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private ucImageLink ucImageLink;
        private ucOrigin ucOrigin;
    }
}
