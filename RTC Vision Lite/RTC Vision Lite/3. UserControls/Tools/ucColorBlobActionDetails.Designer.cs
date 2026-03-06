
namespace RTC_Vision_Lite.UserControls
{
    partial class ucColorBlobActionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucColorBlobActionDetails));
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMinNumberOfBlob = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RTCEnableOutputDimsList = new System.Windows.Forms.CheckBox();
            this.RTCEnableOutputAreaList = new System.Windows.Forms.CheckBox();
            this.RTCEnableOutputBlobList = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMinRow = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinColumn = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinHeight = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxArea = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinWidth = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCErrMessage = new System.Windows.Forms.Label();
            this.RTCTrainPressed = new System.Windows.Forms.Button();
            this.RTCBlueToleranceOut = new RTC_Vision_Lite.UserControls.ucTolerance();
            this.RTCGreenToleranceOut = new RTC_Vision_Lite.UserControls.ucTolerance();
            this.RTCRedToleranceOut = new RTC_Vision_Lite.UserControls.ucTolerance();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.RTCIntensityToleranceOut = new RTC_Vision_Lite.UserControls.ucTolerance();
            this.RTCSaturationToleranceOut = new RTC_Vision_Lite.UserControls.ucTolerance();
            this.RTCHueToleranceOut = new RTC_Vision_Lite.UserControls.ucTolerance();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RTCColorSpace = new System.Windows.Forms.ComboBox();
            this.RTCFillHoles = new System.Windows.Forms.CheckBox();
            this.ucOrigin1 = new RTC_Vision_Lite.UserControls.ucOrigin();
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
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin1);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
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
            this.ScrollablePassFail.Controls.Add(this.label2);
            this.ScrollablePassFail.Controls.Add(this.groupBox9);
            this.ScrollablePassFail.Controls.Add(this.label3);
            this.ScrollablePassFail.Controls.Add(this.groupBox7);
            this.ScrollablePassFail.Controls.Add(this.groupBox6);
            this.ScrollablePassFail.Controls.Add(this.RTCPassed);
            this.ScrollablePassFail.Controls.Add(this.label6);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollablePassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCFillHoles);
            this.ScrollableROI.Controls.Add(this.RTCColorSpace);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.label4);
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
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(23, 63);
            this.ucImageLink.Margin = new System.Windows.Forms.Padding(2);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(674, 65);
            this.ucImageLink.TabIndex = 5;
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(639, 22);
            this.RTCName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ucRangeMaxMinNumberOfBlob);
            this.groupBox9.Location = new System.Drawing.Point(384, 165);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(234, 114);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Filter Number of Blobs";
            // 
            // ucRangeMaxMinNumberOfBlob
            // 
            this.ucRangeMaxMinNumberOfBlob.AutoSize = true;
            this.ucRangeMaxMinNumberOfBlob.Location = new System.Drawing.Point(5, 24);
            this.ucRangeMaxMinNumberOfBlob.Margin = new System.Windows.Forms.Padding(2);
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
            this.ucRangeMaxMinNumberOfBlob.Size = new System.Drawing.Size(221, 64);
            this.ucRangeMaxMinNumberOfBlob.TabIndex = 12;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RTCEnableOutputDimsList);
            this.groupBox7.Controls.Add(this.RTCEnableOutputAreaList);
            this.groupBox7.Controls.Add(this.RTCEnableOutputBlobList);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Location = new System.Drawing.Point(384, 42);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(234, 119);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Outputs";
            // 
            // RTCEnableOutputDimsList
            // 
            this.RTCEnableOutputDimsList.AutoSize = true;
            this.RTCEnableOutputDimsList.Location = new System.Drawing.Point(24, 86);
            this.RTCEnableOutputDimsList.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEnableOutputDimsList.Name = "RTCEnableOutputDimsList";
            this.RTCEnableOutputDimsList.Size = new System.Drawing.Size(145, 17);
            this.RTCEnableOutputDimsList.TabIndex = 3;
            this.RTCEnableOutputDimsList.Text = "Enable Output Dim List";
            this.RTCEnableOutputDimsList.UseVisualStyleBackColor = true;
            // 
            // RTCEnableOutputAreaList
            // 
            this.RTCEnableOutputAreaList.AutoSize = true;
            this.RTCEnableOutputAreaList.Location = new System.Drawing.Point(24, 63);
            this.RTCEnableOutputAreaList.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEnableOutputAreaList.Name = "RTCEnableOutputAreaList";
            this.RTCEnableOutputAreaList.Size = new System.Drawing.Size(148, 17);
            this.RTCEnableOutputAreaList.TabIndex = 2;
            this.RTCEnableOutputAreaList.Text = "Enable Output Area List";
            this.RTCEnableOutputAreaList.UseVisualStyleBackColor = true;
            // 
            // RTCEnableOutputBlobList
            // 
            this.RTCEnableOutputBlobList.AutoSize = true;
            this.RTCEnableOutputBlobList.Checked = true;
            this.RTCEnableOutputBlobList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RTCEnableOutputBlobList.Location = new System.Drawing.Point(24, 39);
            this.RTCEnableOutputBlobList.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEnableOutputBlobList.Name = "RTCEnableOutputBlobList";
            this.RTCEnableOutputBlobList.Size = new System.Drawing.Size(149, 17);
            this.RTCEnableOutputBlobList.TabIndex = 1;
            this.RTCEnableOutputBlobList.Text = "Enable Output Blob List";
            this.RTCEnableOutputBlobList.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Feature";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ucRangeMaxMinRow);
            this.groupBox6.Controls.Add(this.ucRangeMaxMinColumn);
            this.groupBox6.Controls.Add(this.ucRangeMaxMinHeight);
            this.groupBox6.Controls.Add(this.ucRangeMaxArea);
            this.groupBox6.Controls.Add(this.ucRangeMaxMinWidth);
            this.groupBox6.Location = new System.Drawing.Point(20, 42);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(355, 237);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Filter";
            // 
            // ucRangeMaxMinRow
            // 
            this.ucRangeMaxMinRow.AutoSize = true;
            this.ucRangeMaxMinRow.Location = new System.Drawing.Point(7, 191);
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
            this.ucRangeMaxMinRow.Size = new System.Drawing.Size(331, 35);
            this.ucRangeMaxMinRow.TabIndex = 11;
            // 
            // ucRangeMaxMinColumn
            // 
            this.ucRangeMaxMinColumn.AutoSize = true;
            this.ucRangeMaxMinColumn.Location = new System.Drawing.Point(7, 153);
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
            this.ucRangeMaxMinColumn.Size = new System.Drawing.Size(331, 35);
            this.ucRangeMaxMinColumn.TabIndex = 10;
            // 
            // ucRangeMaxMinHeight
            // 
            this.ucRangeMaxMinHeight.AutoSize = true;
            this.ucRangeMaxMinHeight.Location = new System.Drawing.Point(7, 121);
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
            this.ucRangeMaxMinHeight.Size = new System.Drawing.Size(331, 35);
            this.ucRangeMaxMinHeight.TabIndex = 5;
            // 
            // ucRangeMaxArea
            // 
            this.ucRangeMaxArea.AutoSize = true;
            this.ucRangeMaxArea.Location = new System.Drawing.Point(7, 21);
            this.ucRangeMaxArea.Margin = new System.Windows.Forms.Padding(2);
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
            this.ucRangeMaxArea.Size = new System.Drawing.Size(331, 59);
            this.ucRangeMaxArea.TabIndex = 4;
            // 
            // ucRangeMaxMinWidth
            // 
            this.ucRangeMaxMinWidth.AutoSize = true;
            this.ucRangeMaxMinWidth.Location = new System.Drawing.Point(7, 84);
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
            this.ucRangeMaxMinWidth.Size = new System.Drawing.Size(331, 35);
            this.ucRangeMaxMinWidth.TabIndex = 3;
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(308, -21);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 7;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, -21);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pass/Fail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(82, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Passed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pass/Fail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Color Space";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Hue";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCErrMessage);
            this.groupBox1.Controls.Add(this.RTCTrainPressed);
            this.groupBox1.Controls.Add(this.RTCBlueToleranceOut);
            this.groupBox1.Controls.Add(this.RTCGreenToleranceOut);
            this.groupBox1.Controls.Add(this.RTCRedToleranceOut);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.RTCIntensityToleranceOut);
            this.groupBox1.Controls.Add(this.RTCSaturationToleranceOut);
            this.groupBox1.Controls.Add(this.RTCHueToleranceOut);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(20, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 209);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Train Color Tolerance";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.Red;
            this.RTCErrMessage.Location = new System.Drawing.Point(79, 170);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 15;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // RTCTrainPressed
            // 
            this.RTCTrainPressed.Location = new System.Drawing.Point(12, 165);
            this.RTCTrainPressed.Name = "RTCTrainPressed";
            this.RTCTrainPressed.Size = new System.Drawing.Size(59, 23);
            this.RTCTrainPressed.TabIndex = 14;
            this.RTCTrainPressed.Text = "Train";
            this.RTCTrainPressed.UseVisualStyleBackColor = true;
            // 
            // RTCBlueToleranceOut
            // 
            this.RTCBlueToleranceOut.AutoSize = true;
            this.RTCBlueToleranceOut.Location = new System.Drawing.Point(434, 119);
            this.RTCBlueToleranceOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCBlueToleranceOut.Name = "RTCBlueToleranceOut";
            this.RTCBlueToleranceOut.RTCAction = null;
            this.RTCBlueToleranceOut.RTCAllowInfinityValue = true;
            this.RTCBlueToleranceOut.RTCCheckboxCaption = "Hue";
            this.RTCBlueToleranceOut.RTCCheckboxPropertyName = null;
            this.RTCBlueToleranceOut.RTCCheckboxSize = 100;
            this.RTCBlueToleranceOut.RTCChecked = true;
            this.RTCBlueToleranceOut.RTCFeaturesLabel = "Features";
            this.RTCBlueToleranceOut.RTCMinusLabel = "Minus";
            this.RTCBlueToleranceOut.RTCNominalLabel = "Nominal";
            this.RTCBlueToleranceOut.RTCPlusLabel = "Plus";
            this.RTCBlueToleranceOut.RTCPropertyName = "BlueToleranceOut";
            this.RTCBlueToleranceOut.RTCUseActual = false;
            this.RTCBlueToleranceOut.RTCUseActualLabel = false;
            this.RTCBlueToleranceOut.RTCUseCheckbox = false;
            this.RTCBlueToleranceOut.RTCUseFeatures = false;
            this.RTCBlueToleranceOut.RTCUseLabelAtLine = false;
            this.RTCBlueToleranceOut.RTCUseLabelAtTop = false;
            this.RTCBlueToleranceOut.Size = new System.Drawing.Size(215, 30);
            this.RTCBlueToleranceOut.TabIndex = 13;
            // 
            // RTCGreenToleranceOut
            // 
            this.RTCGreenToleranceOut.AutoSize = true;
            this.RTCGreenToleranceOut.Location = new System.Drawing.Point(434, 69);
            this.RTCGreenToleranceOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCGreenToleranceOut.Name = "RTCGreenToleranceOut";
            this.RTCGreenToleranceOut.RTCAction = null;
            this.RTCGreenToleranceOut.RTCAllowInfinityValue = true;
            this.RTCGreenToleranceOut.RTCCheckboxCaption = "Hue";
            this.RTCGreenToleranceOut.RTCCheckboxPropertyName = null;
            this.RTCGreenToleranceOut.RTCCheckboxSize = 100;
            this.RTCGreenToleranceOut.RTCChecked = true;
            this.RTCGreenToleranceOut.RTCFeaturesLabel = "Features";
            this.RTCGreenToleranceOut.RTCMinusLabel = "Minus";
            this.RTCGreenToleranceOut.RTCNominalLabel = "Nominal";
            this.RTCGreenToleranceOut.RTCPlusLabel = "Plus";
            this.RTCGreenToleranceOut.RTCPropertyName = "GreenToleranceOut";
            this.RTCGreenToleranceOut.RTCUseActual = false;
            this.RTCGreenToleranceOut.RTCUseActualLabel = false;
            this.RTCGreenToleranceOut.RTCUseCheckbox = false;
            this.RTCGreenToleranceOut.RTCUseFeatures = false;
            this.RTCGreenToleranceOut.RTCUseLabelAtLine = false;
            this.RTCGreenToleranceOut.RTCUseLabelAtTop = false;
            this.RTCGreenToleranceOut.Size = new System.Drawing.Size(215, 30);
            this.RTCGreenToleranceOut.TabIndex = 12;
            // 
            // RTCRedToleranceOut
            // 
            this.RTCRedToleranceOut.AutoSize = true;
            this.RTCRedToleranceOut.Location = new System.Drawing.Point(435, 21);
            this.RTCRedToleranceOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCRedToleranceOut.Name = "RTCRedToleranceOut";
            this.RTCRedToleranceOut.RTCAction = null;
            this.RTCRedToleranceOut.RTCAllowInfinityValue = true;
            this.RTCRedToleranceOut.RTCCheckboxCaption = "Hue";
            this.RTCRedToleranceOut.RTCCheckboxPropertyName = null;
            this.RTCRedToleranceOut.RTCCheckboxSize = 100;
            this.RTCRedToleranceOut.RTCChecked = true;
            this.RTCRedToleranceOut.RTCFeaturesLabel = "Features";
            this.RTCRedToleranceOut.RTCMinusLabel = "Minus";
            this.RTCRedToleranceOut.RTCNominalLabel = "Nominal";
            this.RTCRedToleranceOut.RTCPlusLabel = "Plus";
            this.RTCRedToleranceOut.RTCPropertyName = "RedToleranceOut";
            this.RTCRedToleranceOut.RTCUseActual = false;
            this.RTCRedToleranceOut.RTCUseActualLabel = false;
            this.RTCRedToleranceOut.RTCUseCheckbox = false;
            this.RTCRedToleranceOut.RTCUseFeatures = false;
            this.RTCRedToleranceOut.RTCUseLabelAtLine = false;
            this.RTCRedToleranceOut.RTCUseLabelAtTop = false;
            this.RTCRedToleranceOut.Size = new System.Drawing.Size(207, 30);
            this.RTCRedToleranceOut.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(366, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Blue";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(363, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Green";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(366, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Red";
            // 
            // RTCIntensityToleranceOut
            // 
            this.RTCIntensityToleranceOut.AutoSize = true;
            this.RTCIntensityToleranceOut.Location = new System.Drawing.Point(77, 119);
            this.RTCIntensityToleranceOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCIntensityToleranceOut.Name = "RTCIntensityToleranceOut";
            this.RTCIntensityToleranceOut.RTCAction = null;
            this.RTCIntensityToleranceOut.RTCAllowInfinityValue = true;
            this.RTCIntensityToleranceOut.RTCCheckboxCaption = "Hue";
            this.RTCIntensityToleranceOut.RTCCheckboxPropertyName = null;
            this.RTCIntensityToleranceOut.RTCCheckboxSize = 100;
            this.RTCIntensityToleranceOut.RTCChecked = true;
            this.RTCIntensityToleranceOut.RTCFeaturesLabel = "Features";
            this.RTCIntensityToleranceOut.RTCMinusLabel = "Minus";
            this.RTCIntensityToleranceOut.RTCNominalLabel = "Nominal";
            this.RTCIntensityToleranceOut.RTCPlusLabel = "Plus";
            this.RTCIntensityToleranceOut.RTCPropertyName = "IntensityToleranceOut";
            this.RTCIntensityToleranceOut.RTCUseActual = false;
            this.RTCIntensityToleranceOut.RTCUseActualLabel = false;
            this.RTCIntensityToleranceOut.RTCUseCheckbox = false;
            this.RTCIntensityToleranceOut.RTCUseFeatures = false;
            this.RTCIntensityToleranceOut.RTCUseLabelAtLine = false;
            this.RTCIntensityToleranceOut.RTCUseLabelAtTop = false;
            this.RTCIntensityToleranceOut.Size = new System.Drawing.Size(215, 30);
            this.RTCIntensityToleranceOut.TabIndex = 7;
            // 
            // RTCSaturationToleranceOut
            // 
            this.RTCSaturationToleranceOut.AutoSize = true;
            this.RTCSaturationToleranceOut.Location = new System.Drawing.Point(77, 69);
            this.RTCSaturationToleranceOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCSaturationToleranceOut.Name = "RTCSaturationToleranceOut";
            this.RTCSaturationToleranceOut.RTCAction = null;
            this.RTCSaturationToleranceOut.RTCAllowInfinityValue = true;
            this.RTCSaturationToleranceOut.RTCCheckboxCaption = "Hue";
            this.RTCSaturationToleranceOut.RTCCheckboxPropertyName = null;
            this.RTCSaturationToleranceOut.RTCCheckboxSize = 100;
            this.RTCSaturationToleranceOut.RTCChecked = true;
            this.RTCSaturationToleranceOut.RTCFeaturesLabel = "Features";
            this.RTCSaturationToleranceOut.RTCMinusLabel = "Minus";
            this.RTCSaturationToleranceOut.RTCNominalLabel = "Nominal";
            this.RTCSaturationToleranceOut.RTCPlusLabel = "Plus";
            this.RTCSaturationToleranceOut.RTCPropertyName = "SaturationToleranceOut";
            this.RTCSaturationToleranceOut.RTCUseActual = false;
            this.RTCSaturationToleranceOut.RTCUseActualLabel = false;
            this.RTCSaturationToleranceOut.RTCUseCheckbox = false;
            this.RTCSaturationToleranceOut.RTCUseFeatures = false;
            this.RTCSaturationToleranceOut.RTCUseLabelAtLine = false;
            this.RTCSaturationToleranceOut.RTCUseLabelAtTop = false;
            this.RTCSaturationToleranceOut.Size = new System.Drawing.Size(215, 30);
            this.RTCSaturationToleranceOut.TabIndex = 6;
            // 
            // RTCHueToleranceOut
            // 
            this.RTCHueToleranceOut.AutoSize = true;
            this.RTCHueToleranceOut.Location = new System.Drawing.Point(78, 21);
            this.RTCHueToleranceOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RTCHueToleranceOut.Name = "RTCHueToleranceOut";
            this.RTCHueToleranceOut.RTCAction = null;
            this.RTCHueToleranceOut.RTCAllowInfinityValue = true;
            this.RTCHueToleranceOut.RTCCheckboxCaption = "Hue";
            this.RTCHueToleranceOut.RTCCheckboxPropertyName = null;
            this.RTCHueToleranceOut.RTCCheckboxSize = 100;
            this.RTCHueToleranceOut.RTCChecked = true;
            this.RTCHueToleranceOut.RTCFeaturesLabel = "Features";
            this.RTCHueToleranceOut.RTCMinusLabel = "Minus";
            this.RTCHueToleranceOut.RTCNominalLabel = "Nominal";
            this.RTCHueToleranceOut.RTCPlusLabel = "Plus";
            this.RTCHueToleranceOut.RTCPropertyName = "HueToleranceOut";
            this.RTCHueToleranceOut.RTCUseActual = false;
            this.RTCHueToleranceOut.RTCUseActualLabel = false;
            this.RTCHueToleranceOut.RTCUseCheckbox = false;
            this.RTCHueToleranceOut.RTCUseFeatures = false;
            this.RTCHueToleranceOut.RTCUseLabelAtLine = false;
            this.RTCHueToleranceOut.RTCUseLabelAtTop = false;
            this.RTCHueToleranceOut.Size = new System.Drawing.Size(207, 30);
            this.RTCHueToleranceOut.TabIndex = 4;
            this.RTCHueToleranceOut.Load += new System.EventHandler(this.ucTolerance1_Load);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Intensity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Saturation";
            // 
            // RTCColorSpace
            // 
            this.RTCColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCColorSpace.FormattingEnabled = true;
            this.RTCColorSpace.Location = new System.Drawing.Point(102, 15);
            this.RTCColorSpace.Name = "RTCColorSpace";
            this.RTCColorSpace.Size = new System.Drawing.Size(192, 21);
            this.RTCColorSpace.TabIndex = 3;
            // 
            // RTCFillHoles
            // 
            this.RTCFillHoles.AutoSize = true;
            this.RTCFillHoles.Location = new System.Drawing.Point(333, 17);
            this.RTCFillHoles.Name = "RTCFillHoles";
            this.RTCFillHoles.Size = new System.Drawing.Size(100, 17);
            this.RTCFillHoles.TabIndex = 4;
            this.RTCFillHoles.Text = "Fill Blob Holes";
            this.RTCFillHoles.UseVisualStyleBackColor = true;
            // 
            // ucOrigin1
            // 
            this.ucOrigin1.Action = null;
            this.ucOrigin1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin1.Location = new System.Drawing.Point(23, 153);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(674, 91);
            this.ucOrigin1.TabIndex = 6;
            // 
            // ucColorBlobActionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucColorBlobActionDetails";
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
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucImageLink ucImageLink;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox9;
        private ucRangeMaxMin ucRangeMaxMinNumberOfBlob;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox RTCEnableOutputDimsList;
        private System.Windows.Forms.CheckBox RTCEnableOutputAreaList;
        private System.Windows.Forms.CheckBox RTCEnableOutputBlobList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox6;
        private ucRangeMaxMin ucRangeMaxMinRow;
        private ucRangeMaxMin ucRangeMaxMinColumn;
        private ucRangeMaxMin ucRangeMaxMinHeight;
        private ucRangeMaxMin ucRangeMaxArea;
        private ucRangeMaxMin ucRangeMaxMinWidth;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RTCColorSpace;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ucTolerance RTCHueToleranceOut;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Button RTCTrainPressed;
        private UserControls.ucTolerance RTCBlueToleranceOut;
        private UserControls.ucTolerance RTCGreenToleranceOut;
        private UserControls.ucTolerance RTCRedToleranceOut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private UserControls.ucTolerance RTCIntensityToleranceOut;
        private UserControls.ucTolerance RTCSaturationToleranceOut;
        private System.Windows.Forms.CheckBox RTCFillHoles;
        private ucOrigin ucOrigin1;
    }
}
