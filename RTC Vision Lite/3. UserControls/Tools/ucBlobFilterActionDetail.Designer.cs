
namespace RTC_Vision_Lite.UserControls
{
    partial class ucBlobFilterActionDetail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBlobFilterActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMinWidth = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinRow = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinColumn = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinHeight = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinArea = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.label9 = new System.Windows.Forms.Label();
            this.RTCPositionMode = new System.Windows.Forms.ComboBox();
            this.ucRangeMaxMinRectangularity = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinCircularity = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinOuterRadius = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.RTCSelectedIndex = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.RTCRowOrCol = new System.Windows.Forms.ComboBox();
            this.RTCSortMode = new System.Windows.Forms.ComboBox();
            this.RTCOrder = new System.Windows.Forms.ComboBox();
            this.RTCEnableSortRegion = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMinNumberOfBlob = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucOrigin2 = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.BackColor = System.Drawing.Color.Transparent;
            this.ScrollableGeneral.Controls.Add(this.ucOrigin2);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(4, 4);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(2);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(2, 39);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(2);
            this.PageSetup.Size = new System.Drawing.Size(888, 421);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(4);
            this.ROI.Padding = new System.Windows.Forms.Padding(4);
            this.ROI.Size = new System.Drawing.Size(865, 413);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(4);
            this.PassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.BackColor = System.Drawing.Color.Transparent;
            this.ScrollableROI.Controls.Add(this.groupBox9);
            this.ScrollableROI.Controls.Add(this.ucRangeMaxMinRectangularity);
            this.ScrollableROI.Controls.Add(this.groupBox8);
            this.ScrollableROI.Controls.Add(this.groupBox7);
            this.ScrollableROI.Controls.Add(this.label8);
            this.ScrollableROI.Controls.Add(this.ucRangeMaxMinCircularity);
            this.ScrollableROI.Controls.Add(this.label10);
            this.ScrollableROI.Controls.Add(this.ucRangeMaxMinOuterRadius);
            this.ScrollableROI.Location = new System.Drawing.Point(4, 4);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(2);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(888, 37);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(4);
            this.General.Padding = new System.Windows.Forms.Padding(4);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(632, 22);
            this.RTCName.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ucRangeMaxMinWidth);
            this.groupBox7.Controls.Add(this.ucRangeMaxMinRow);
            this.groupBox7.Controls.Add(this.ucRangeMaxMinColumn);
            this.groupBox7.Controls.Add(this.ucRangeMaxMinHeight);
            this.groupBox7.Controls.Add(this.ucRangeMaxMinArea);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.RTCPositionMode);
            this.groupBox7.Location = new System.Drawing.Point(14, 36);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(393, 268);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Filters";
            // 
            // ucRangeMaxMinWidth
            // 
            this.ucRangeMaxMinWidth.AutoSize = true;
            this.ucRangeMaxMinWidth.Location = new System.Drawing.Point(2, 78);
            this.ucRangeMaxMinWidth.Margin = new System.Windows.Forms.Padding(2);
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
            this.ucRangeMaxMinWidth.Size = new System.Drawing.Size(393, 31);
            this.ucRangeMaxMinWidth.TabIndex = 3;
            // 
            // ucRangeMaxMinRow
            // 
            this.ucRangeMaxMinRow.AutoSize = true;
            this.ucRangeMaxMinRow.Location = new System.Drawing.Point(2, 183);
            this.ucRangeMaxMinRow.Margin = new System.Windows.Forms.Padding(2);
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
            this.ucRangeMaxMinRow.Size = new System.Drawing.Size(393, 31);
            this.ucRangeMaxMinRow.TabIndex = 11;
            // 
            // ucRangeMaxMinColumn
            // 
            this.ucRangeMaxMinColumn.AutoSize = true;
            this.ucRangeMaxMinColumn.Location = new System.Drawing.Point(2, 148);
            this.ucRangeMaxMinColumn.Margin = new System.Windows.Forms.Padding(2);
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
            this.ucRangeMaxMinColumn.Size = new System.Drawing.Size(393, 31);
            this.ucRangeMaxMinColumn.TabIndex = 10;
            // 
            // ucRangeMaxMinHeight
            // 
            this.ucRangeMaxMinHeight.AutoSize = true;
            this.ucRangeMaxMinHeight.Location = new System.Drawing.Point(2, 113);
            this.ucRangeMaxMinHeight.Margin = new System.Windows.Forms.Padding(2);
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
            this.ucRangeMaxMinHeight.Size = new System.Drawing.Size(393, 31);
            this.ucRangeMaxMinHeight.TabIndex = 5;
            // 
            // ucRangeMaxMinArea
            // 
            this.ucRangeMaxMinArea.AutoSize = true;
            this.ucRangeMaxMinArea.Location = new System.Drawing.Point(2, 13);
            this.ucRangeMaxMinArea.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinArea.Name = "ucRangeMaxMinArea";
            this.ucRangeMaxMinArea.RTCAction = null;
            this.ucRangeMaxMinArea.RTCActualPropertyName = "AreaActual";
            this.ucRangeMaxMinArea.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinArea.RTCCheckboxCaption = "Area";
            this.ucRangeMaxMinArea.RTCCheckboxPropertyName = "EnableAreaFilter";
            this.ucRangeMaxMinArea.RTCCheckboxSize = 110;
            this.ucRangeMaxMinArea.RTCChecked = true;
            this.ucRangeMaxMinArea.RTCEditMask = "n2";
            this.ucRangeMaxMinArea.RTCFeaturesLabel = "Features";
            this.ucRangeMaxMinArea.RTCIsLimit = false;
            this.ucRangeMaxMinArea.RTCMaxLabel = "Maximum";
            this.ucRangeMaxMinArea.RTCMinLabel = "Minimum";
            this.ucRangeMaxMinArea.RTCTextboxSize = 75;
            this.ucRangeMaxMinArea.RTCUseActual = true;
            this.ucRangeMaxMinArea.RTCUseActualLabel = true;
            this.ucRangeMaxMinArea.RTCUseCheckbox = true;
            this.ucRangeMaxMinArea.RTCUseFeatures = true;
            this.ucRangeMaxMinArea.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinArea.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinArea.RTCUseMinMaxAtTop = true;
            this.ucRangeMaxMinArea.RTCValuePropertyName = "AreaRange";
            this.ucRangeMaxMinArea.Size = new System.Drawing.Size(393, 61);
            this.ucRangeMaxMinArea.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 224);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Position Mode";
            // 
            // RTCPositionMode
            // 
            this.RTCPositionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCPositionMode.FormattingEnabled = true;
            this.RTCPositionMode.Location = new System.Drawing.Point(127, 221);
            this.RTCPositionMode.Margin = new System.Windows.Forms.Padding(2);
            this.RTCPositionMode.Name = "RTCPositionMode";
            this.RTCPositionMode.Size = new System.Drawing.Size(158, 21);
            this.RTCPositionMode.TabIndex = 1;
            // 
            // ucRangeMaxMinRectangularity
            // 
            this.ucRangeMaxMinRectangularity.AutoSize = true;
            this.ucRangeMaxMinRectangularity.Location = new System.Drawing.Point(63, 379);
            this.ucRangeMaxMinRectangularity.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinRectangularity.Name = "ucRangeMaxMinRectangularity";
            this.ucRangeMaxMinRectangularity.RTCAction = null;
            this.ucRangeMaxMinRectangularity.RTCActualPropertyName = "RectangularityActual";
            this.ucRangeMaxMinRectangularity.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinRectangularity.RTCCheckboxCaption = "Rectangularity";
            this.ucRangeMaxMinRectangularity.RTCCheckboxPropertyName = "EnableRectangularityFilter";
            this.ucRangeMaxMinRectangularity.RTCCheckboxSize = 110;
            this.ucRangeMaxMinRectangularity.RTCChecked = false;
            this.ucRangeMaxMinRectangularity.RTCEditMask = "n2";
            this.ucRangeMaxMinRectangularity.RTCFeaturesLabel = "";
            this.ucRangeMaxMinRectangularity.RTCIsLimit = false;
            this.ucRangeMaxMinRectangularity.RTCMaxLabel = "";
            this.ucRangeMaxMinRectangularity.RTCMinLabel = "";
            this.ucRangeMaxMinRectangularity.RTCTextboxSize = 75;
            this.ucRangeMaxMinRectangularity.RTCUseActual = true;
            this.ucRangeMaxMinRectangularity.RTCUseActualLabel = false;
            this.ucRangeMaxMinRectangularity.RTCUseCheckbox = true;
            this.ucRangeMaxMinRectangularity.RTCUseFeatures = false;
            this.ucRangeMaxMinRectangularity.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinRectangularity.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinRectangularity.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinRectangularity.RTCValuePropertyName = "RectangularityRange";
            this.ucRangeMaxMinRectangularity.Size = new System.Drawing.Size(322, 24);
            this.ucRangeMaxMinRectangularity.TabIndex = 12;
            this.ucRangeMaxMinRectangularity.Visible = false;
            // 
            // ucRangeMaxMinCircularity
            // 
            this.ucRangeMaxMinCircularity.AutoSize = true;
            this.ucRangeMaxMinCircularity.Location = new System.Drawing.Point(433, 379);
            this.ucRangeMaxMinCircularity.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinCircularity.Name = "ucRangeMaxMinCircularity";
            this.ucRangeMaxMinCircularity.RTCAction = null;
            this.ucRangeMaxMinCircularity.RTCActualPropertyName = "CircularityActual";
            this.ucRangeMaxMinCircularity.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinCircularity.RTCCheckboxCaption = "Circularity";
            this.ucRangeMaxMinCircularity.RTCCheckboxPropertyName = "EnableCircularityFilter";
            this.ucRangeMaxMinCircularity.RTCCheckboxSize = 110;
            this.ucRangeMaxMinCircularity.RTCChecked = false;
            this.ucRangeMaxMinCircularity.RTCEditMask = "n2";
            this.ucRangeMaxMinCircularity.RTCFeaturesLabel = "";
            this.ucRangeMaxMinCircularity.RTCIsLimit = false;
            this.ucRangeMaxMinCircularity.RTCMaxLabel = "";
            this.ucRangeMaxMinCircularity.RTCMinLabel = "";
            this.ucRangeMaxMinCircularity.RTCTextboxSize = 75;
            this.ucRangeMaxMinCircularity.RTCUseActual = true;
            this.ucRangeMaxMinCircularity.RTCUseActualLabel = false;
            this.ucRangeMaxMinCircularity.RTCUseCheckbox = true;
            this.ucRangeMaxMinCircularity.RTCUseFeatures = false;
            this.ucRangeMaxMinCircularity.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinCircularity.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinCircularity.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinCircularity.RTCValuePropertyName = "CircularityRange";
            this.ucRangeMaxMinCircularity.Size = new System.Drawing.Size(322, 24);
            this.ucRangeMaxMinCircularity.TabIndex = 7;
            this.ucRangeMaxMinCircularity.Visible = false;
            // 
            // ucRangeMaxMinOuterRadius
            // 
            this.ucRangeMaxMinOuterRadius.AutoSize = true;
            this.ucRangeMaxMinOuterRadius.Location = new System.Drawing.Point(301, 379);
            this.ucRangeMaxMinOuterRadius.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinOuterRadius.Name = "ucRangeMaxMinOuterRadius";
            this.ucRangeMaxMinOuterRadius.RTCAction = null;
            this.ucRangeMaxMinOuterRadius.RTCActualPropertyName = "OuterRadiusActual";
            this.ucRangeMaxMinOuterRadius.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinOuterRadius.RTCCheckboxCaption = "Outer Radius";
            this.ucRangeMaxMinOuterRadius.RTCCheckboxPropertyName = "EnableOuterRadiusFilter";
            this.ucRangeMaxMinOuterRadius.RTCCheckboxSize = 110;
            this.ucRangeMaxMinOuterRadius.RTCChecked = false;
            this.ucRangeMaxMinOuterRadius.RTCEditMask = "n2";
            this.ucRangeMaxMinOuterRadius.RTCFeaturesLabel = "";
            this.ucRangeMaxMinOuterRadius.RTCIsLimit = false;
            this.ucRangeMaxMinOuterRadius.RTCMaxLabel = "";
            this.ucRangeMaxMinOuterRadius.RTCMinLabel = "";
            this.ucRangeMaxMinOuterRadius.RTCTextboxSize = 75;
            this.ucRangeMaxMinOuterRadius.RTCUseActual = true;
            this.ucRangeMaxMinOuterRadius.RTCUseActualLabel = false;
            this.ucRangeMaxMinOuterRadius.RTCUseCheckbox = true;
            this.ucRangeMaxMinOuterRadius.RTCUseFeatures = false;
            this.ucRangeMaxMinOuterRadius.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinOuterRadius.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinOuterRadius.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinOuterRadius.RTCValuePropertyName = "OuterRadiusRange";
            this.ucRangeMaxMinOuterRadius.Size = new System.Drawing.Size(322, 24);
            this.ucRangeMaxMinOuterRadius.TabIndex = 6;
            this.ucRangeMaxMinOuterRadius.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(82, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Passed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Pass/Fail:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.RTCSelectedIndex);
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.RTCRowOrCol);
            this.groupBox8.Controls.Add(this.RTCSortMode);
            this.groupBox8.Controls.Add(this.RTCOrder);
            this.groupBox8.Controls.Add(this.RTCEnableSortRegion);
            this.groupBox8.Location = new System.Drawing.Point(413, 36);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(257, 150);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Filtered Number of Blobs";
            // 
            // RTCSelectedIndex
            // 
            this.RTCSelectedIndex.Location = new System.Drawing.Point(129, 103);
            this.RTCSelectedIndex.Name = "RTCSelectedIndex";
            this.RTCSelectedIndex.Size = new System.Drawing.Size(109, 22);
            this.RTCSelectedIndex.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 104);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Selected Region";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 77);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Row or Column";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 51);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Sort Order";
            // 
            // RTCRowOrCol
            // 
            this.RTCRowOrCol.FormattingEnabled = true;
            this.RTCRowOrCol.Location = new System.Drawing.Point(129, 74);
            this.RTCRowOrCol.Margin = new System.Windows.Forms.Padding(2);
            this.RTCRowOrCol.Name = "RTCRowOrCol";
            this.RTCRowOrCol.Size = new System.Drawing.Size(109, 21);
            this.RTCRowOrCol.TabIndex = 4;
            // 
            // RTCSortMode
            // 
            this.RTCSortMode.FormattingEnabled = true;
            this.RTCSortMode.Location = new System.Drawing.Point(129, 19);
            this.RTCSortMode.Margin = new System.Windows.Forms.Padding(2);
            this.RTCSortMode.Name = "RTCSortMode";
            this.RTCSortMode.Size = new System.Drawing.Size(109, 21);
            this.RTCSortMode.TabIndex = 3;
            // 
            // RTCOrder
            // 
            this.RTCOrder.FormattingEnabled = true;
            this.RTCOrder.Location = new System.Drawing.Point(129, 45);
            this.RTCOrder.Margin = new System.Windows.Forms.Padding(2);
            this.RTCOrder.Name = "RTCOrder";
            this.RTCOrder.Size = new System.Drawing.Size(109, 21);
            this.RTCOrder.TabIndex = 1;
            // 
            // RTCEnableSortRegion
            // 
            this.RTCEnableSortRegion.Location = new System.Drawing.Point(15, 23);
            this.RTCEnableSortRegion.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEnableSortRegion.Name = "RTCEnableSortRegion";
            this.RTCEnableSortRegion.Size = new System.Drawing.Size(85, 25);
            this.RTCEnableSortRegion.TabIndex = 0;
            this.RTCEnableSortRegion.Text = "Enable Sort";
            this.RTCEnableSortRegion.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ucRangeMaxMinNumberOfBlob);
            this.groupBox9.Location = new System.Drawing.Point(413, 190);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(257, 114);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Filtered Number of Blobs";
            // 
            // ucRangeMaxMinNumberOfBlob
            // 
            this.ucRangeMaxMinNumberOfBlob.AutoSize = true;
            this.ucRangeMaxMinNumberOfBlob.Location = new System.Drawing.Point(24, 32);
            this.ucRangeMaxMinNumberOfBlob.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinNumberOfBlob.Name = "ucRangeMaxMinNumberOfBlob";
            this.ucRangeMaxMinNumberOfBlob.RTCAction = null;
            this.ucRangeMaxMinNumberOfBlob.RTCActualPropertyName = null;
            this.ucRangeMaxMinNumberOfBlob.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxCaption = "Rectangularity";
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxPropertyName = null;
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxSize = 100;
            this.ucRangeMaxMinNumberOfBlob.RTCChecked = true;
            this.ucRangeMaxMinNumberOfBlob.RTCEditMask = "n0";
            this.ucRangeMaxMinNumberOfBlob.RTCFeaturesLabel = "";
            this.ucRangeMaxMinNumberOfBlob.RTCIsLimit = false;
            this.ucRangeMaxMinNumberOfBlob.RTCMaxLabel = "Max";
            this.ucRangeMaxMinNumberOfBlob.RTCMinLabel = "Min";
            this.ucRangeMaxMinNumberOfBlob.RTCTextboxSize = 75;
            this.ucRangeMaxMinNumberOfBlob.RTCUseActual = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseActualLabel = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseCheckbox = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseFeatures = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMinNumberOfBlob.RTCUseMinMaxAtTop = true;
            this.ucRangeMaxMinNumberOfBlob.RTCValuePropertyName = "RequiredNumberOfBlobs";
            this.ucRangeMaxMinNumberOfBlob.Size = new System.Drawing.Size(224, 76);
            this.ucRangeMaxMinNumberOfBlob.TabIndex = 0;
            // 
            // ucOrigin2
            // 
            this.ucOrigin2.Action = null;
            this.ucOrigin2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin2.Location = new System.Drawing.Point(18, 139);
            this.ucOrigin2.Margin = new System.Windows.Forms.Padding(2, 41, 2, 41);
            this.ucOrigin2.Name = "ucOrigin2";
            this.ucOrigin2.PropertyName = "ToolOrigin";
            this.ucOrigin2.Size = new System.Drawing.Size(672, 86);
            this.ucOrigin2.TabIndex = 6;
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(16, 48);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(674, 75);
            this.ucImageLink.TabIndex = 4;
            // 
            // ucBlobFilterActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucBlobFilterActionDetail";
            this.Controls.SetChildIndex(this.PageActionSetting, 0);
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
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox7;
        private UserControls.ucRangeMaxMin ucRangeMaxMinRow;
        private UserControls.ucRangeMaxMin ucRangeMaxMinColumn;
        private UserControls.ucRangeMaxMin ucRangeMaxMinCircularity;
        private UserControls.ucRangeMaxMin ucRangeMaxMinOuterRadius;
        private UserControls.ucRangeMaxMin ucRangeMaxMinHeight;
        private UserControls.ucRangeMaxMin ucRangeMaxMinArea;
        private UserControls.ucRangeMaxMin ucRangeMaxMinWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox RTCPositionMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox9;
        private UserControls.ucRangeMaxMin ucRangeMaxMinNumberOfBlob;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox RTCRowOrCol;
        private System.Windows.Forms.ComboBox RTCSortMode;
        private System.Windows.Forms.ComboBox RTCOrder;
        private System.Windows.Forms.CheckBox RTCEnableSortRegion;
        private ucOrigin ucOrigin2;
        private UserControls.ucRangeMaxMin ucRangeMaxMinRectangularity;
        private System.Windows.Forms.TextBox RTCSelectedIndex;
        private ucImageLink ucImageLink;
    }
}
