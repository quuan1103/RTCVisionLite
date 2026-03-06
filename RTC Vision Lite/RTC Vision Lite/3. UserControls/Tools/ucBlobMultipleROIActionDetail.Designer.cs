
namespace RTC_Vision_Lite.UserControls
{
    partial class ucBlobMultipleROIActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBlobMultipleROIActionDetail));
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ucConfigureDataTimeInput1 = new RTC_Vision_Lite.UserControls.ucConfigureDateTimeInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucRangeMaxMinLimit1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.ucOrigin = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.lblSetupPassed = new System.Windows.Forms.Label();
            this.chkRunOnlyROISelect = new System.Windows.Forms.CheckBox();
            this.btnRunMultiROI = new System.Windows.Forms.Button();
            this.ucRangeMaxMinNumberOfBlob = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.RTCEnableOutputBlobList = new System.Windows.Forms.CheckBox();
            this.RTCEnableOutputAreaList = new System.Windows.Forms.CheckBox();
            this.RTCEnableOutputDimsList = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RTCDetectType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RTCFillHoles = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.RTCThresholdRange = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.label8 = new System.Windows.Forms.Label();
            this.RTCGreyLevelThresholdType = new System.Windows.Forms.ComboBox();
            this.lblSetPropertiesToOtherROI = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMinWidth = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinHeight = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinArea = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.ucRangeMaxMinOuterRadius = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Location = new System.Drawing.Point(2, 2);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableGeneral.Size = new System.Drawing.Size(861, 409);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(2, 39);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(2);
            this.PageSetup.Size = new System.Drawing.Size(888, 421);
            // 
            // ROI
            // 
            this.ROI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.lblSetupPassed);
            this.ScrollableROI.Controls.Add(this.chkRunOnlyROISelect);
            this.ScrollableROI.Controls.Add(this.btnRunMultiROI);
            this.ScrollableROI.Controls.Add(this.groupBox10);
            this.ScrollableROI.Controls.Add(this.groupBox7);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Controls.Add(this.groupBox5);
            this.ScrollableROI.Controls.Add(this.groupBox11);
            this.ScrollableROI.Location = new System.Drawing.Point(2, 2);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableROI.Size = new System.Drawing.Size(861, 409);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
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
            this.RTCName.Size = new System.Drawing.Size(641, 22);
            this.RTCName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(24, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 308);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(20, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Apply Properties To Others RÓI";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(24, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 197);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Threshold";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ucConfigureDataTimeInput1);
            this.groupBox4.Location = new System.Drawing.Point(19, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(290, 118);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fixed Threshold Range";
            // 
            // ucConfigureDataTimeInput1
            // 
            this.ucConfigureDataTimeInput1.Location = new System.Drawing.Point(137, 72);
            this.ucConfigureDataTimeInput1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucConfigureDataTimeInput1.Name = "ucConfigureDataTimeInput1";
            this.ucConfigureDataTimeInput1.RTCCaption = "Configure Date Time Input";
            this.ucConfigureDataTimeInput1.RTCSBItem = null;
            this.ucConfigureDataTimeInput1.Size = new System.Drawing.Size(8, 8);
            this.ucConfigureDataTimeInput1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detect Type";
            // 
            // ucRangeMaxMinLimit1
            // 
            this.ucRangeMaxMinLimit1.Location = new System.Drawing.Point(0, 0);
            this.ucRangeMaxMinLimit1.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinLimit1.Name = "ucRangeMaxMinLimit1";
            this.ucRangeMaxMinLimit1.RTCAction = null;
            this.ucRangeMaxMinLimit1.RTCBeginValue = 0D;
            this.ucRangeMaxMinLimit1.RTCEndValue = 25D;
            this.ucRangeMaxMinLimit1.RTCMax = 100D;
            this.ucRangeMaxMinLimit1.RTCMin = 0D;
            this.ucRangeMaxMinLimit1.RTCPropertyName = null;
            this.ucRangeMaxMinLimit1.RTCStepChange = 0.1D;
            this.ucRangeMaxMinLimit1.RTCValuePropertyName = null;
            this.ucRangeMaxMinLimit1.Size = new System.Drawing.Size(241, 88);
            this.ucRangeMaxMinLimit1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pass/Fail";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(23, 63);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(676, 65);
            this.ucImageLink.TabIndex = 8;
            // 
            // ucOrigin
            // 
            this.ucOrigin.Action = null;
            this.ucOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin.Location = new System.Drawing.Point(23, 153);
            this.ucOrigin.Margin = new System.Windows.Forms.Padding(2, 30, 2, 30);
            this.ucOrigin.Name = "ucOrigin";
            this.ucOrigin.PropertyName = "ToolOrigin";
            this.ucOrigin.Size = new System.Drawing.Size(676, 91);
            this.ucOrigin.TabIndex = 9;
            // 
            // lblSetupPassed
            // 
            this.lblSetupPassed.Image = global::RTC_Vision_Lite.Properties.Resources.SaveAndNew_16x16;
            this.lblSetupPassed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSetupPassed.Location = new System.Drawing.Point(618, 311);
            this.lblSetupPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSetupPassed.Name = "lblSetupPassed";
            this.lblSetupPassed.Size = new System.Drawing.Size(68, 18);
            this.lblSetupPassed.TabIndex = 10;
            this.lblSetupPassed.Text = "Setup";
            this.lblSetupPassed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkRunOnlyROISelect
            // 
            this.chkRunOnlyROISelect.AutoSize = true;
            this.chkRunOnlyROISelect.Checked = true;
            this.chkRunOnlyROISelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunOnlyROISelect.Location = new System.Drawing.Point(489, 309);
            this.chkRunOnlyROISelect.Margin = new System.Windows.Forms.Padding(2);
            this.chkRunOnlyROISelect.Name = "chkRunOnlyROISelect";
            this.chkRunOnlyROISelect.Size = new System.Drawing.Size(117, 17);
            this.chkRunOnlyROISelect.TabIndex = 3;
            this.chkRunOnlyROISelect.Text = "Only ROI selected";
            this.chkRunOnlyROISelect.UseVisualStyleBackColor = true;
            // 
            // btnRunMultiROI
            // 
            this.btnRunMultiROI.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x16;
            this.btnRunMultiROI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunMultiROI.Location = new System.Drawing.Point(380, 302);
            this.btnRunMultiROI.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunMultiROI.Name = "btnRunMultiROI";
            this.btnRunMultiROI.Size = new System.Drawing.Size(86, 28);
            this.btnRunMultiROI.TabIndex = 9;
            this.btnRunMultiROI.Text = "Run (F5)";
            this.btnRunMultiROI.UseVisualStyleBackColor = true;
            // 
            // ucRangeMaxMinNumberOfBlob
            // 
            this.ucRangeMaxMinNumberOfBlob.AutoSize = true;
            this.ucRangeMaxMinNumberOfBlob.Location = new System.Drawing.Point(4, 19);
            this.ucRangeMaxMinNumberOfBlob.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinNumberOfBlob.Name = "ucRangeMaxMinNumberOfBlob";
            this.ucRangeMaxMinNumberOfBlob.RTCAction = null;
            this.ucRangeMaxMinNumberOfBlob.RTCActualPropertyName = null;
            this.ucRangeMaxMinNumberOfBlob.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxCaption = "Rectangularity";
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxPropertyName = null;
            this.ucRangeMaxMinNumberOfBlob.RTCCheckboxSize = 100;
            this.ucRangeMaxMinNumberOfBlob.RTCChecked = false;
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
            this.ucRangeMaxMinNumberOfBlob.RTCUseMinMaxAtLine = true;
            this.ucRangeMaxMinNumberOfBlob.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMinNumberOfBlob.RTCValuePropertyName = "RequiredNumberOfBlobs";
            this.ucRangeMaxMinNumberOfBlob.Size = new System.Drawing.Size(294, 30);
            this.ucRangeMaxMinNumberOfBlob.TabIndex = 0;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ucRangeMaxMinNumberOfBlob);
            this.groupBox11.Location = new System.Drawing.Point(380, 226);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox11.Size = new System.Drawing.Size(292, 61);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Filtered Number of Blobs";
            // 
            // RTCEnableOutputBlobList
            // 
            this.RTCEnableOutputBlobList.AutoSize = true;
            this.RTCEnableOutputBlobList.Checked = true;
            this.RTCEnableOutputBlobList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RTCEnableOutputBlobList.Location = new System.Drawing.Point(15, 20);
            this.RTCEnableOutputBlobList.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEnableOutputBlobList.Name = "RTCEnableOutputBlobList";
            this.RTCEnableOutputBlobList.Size = new System.Drawing.Size(152, 17);
            this.RTCEnableOutputBlobList.TabIndex = 0;
            this.RTCEnableOutputBlobList.Text = "Enabled Output Bob List";
            this.RTCEnableOutputBlobList.UseVisualStyleBackColor = true;
            // 
            // RTCEnableOutputAreaList
            // 
            this.RTCEnableOutputAreaList.AutoSize = true;
            this.RTCEnableOutputAreaList.Location = new System.Drawing.Point(181, 20);
            this.RTCEnableOutputAreaList.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEnableOutputAreaList.Name = "RTCEnableOutputAreaList";
            this.RTCEnableOutputAreaList.Size = new System.Drawing.Size(148, 17);
            this.RTCEnableOutputAreaList.TabIndex = 1;
            this.RTCEnableOutputAreaList.Text = "Enable Output Area List";
            this.RTCEnableOutputAreaList.UseVisualStyleBackColor = true;
            // 
            // RTCEnableOutputDimsList
            // 
            this.RTCEnableOutputDimsList.AutoSize = true;
            this.RTCEnableOutputDimsList.Location = new System.Drawing.Point(14, 44);
            this.RTCEnableOutputDimsList.Margin = new System.Windows.Forms.Padding(2);
            this.RTCEnableOutputDimsList.Name = "RTCEnableOutputDimsList";
            this.RTCEnableOutputDimsList.Size = new System.Drawing.Size(145, 17);
            this.RTCEnableOutputDimsList.TabIndex = 2;
            this.RTCEnableOutputDimsList.Text = "Enable Output Dim List";
            this.RTCEnableOutputDimsList.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RTCEnableOutputDimsList);
            this.groupBox7.Controls.Add(this.RTCEnableOutputAreaList);
            this.groupBox7.Controls.Add(this.RTCEnableOutputBlobList);
            this.groupBox7.Location = new System.Drawing.Point(20, 293);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(345, 81);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Outputs";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 4;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Pass/Fail:";
            // 
            // RTCDetectType
            // 
            this.RTCDetectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDetectType.FormattingEnabled = true;
            this.RTCDetectType.Location = new System.Drawing.Point(86, 18);
            this.RTCDetectType.Margin = new System.Windows.Forms.Padding(2);
            this.RTCDetectType.Name = "RTCDetectType";
            this.RTCDetectType.Size = new System.Drawing.Size(177, 21);
            this.RTCDetectType.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Detect Type";
            // 
            // RTCFillHoles
            // 
            this.RTCFillHoles.AutoSize = true;
            this.RTCFillHoles.Location = new System.Drawing.Point(86, 46);
            this.RTCFillHoles.Margin = new System.Windows.Forms.Padding(2);
            this.RTCFillHoles.Name = "RTCFillHoles";
            this.RTCFillHoles.Size = new System.Drawing.Size(99, 17);
            this.RTCFillHoles.TabIndex = 2;
            this.RTCFillHoles.Text = "Fill Blob Holes";
            this.RTCFillHoles.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.RTCGreyLevelThresholdType);
            this.groupBox6.Location = new System.Drawing.Point(15, 72);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(262, 147);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Threshold";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.RTCThresholdRange);
            this.groupBox8.Location = new System.Drawing.Point(14, 41);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(233, 94);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Fixed Threshold Range";
            // 
            // RTCThresholdRange
            // 
            this.RTCThresholdRange.Location = new System.Drawing.Point(32, 17);
            this.RTCThresholdRange.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RTCThresholdRange.Name = "RTCThresholdRange";
            this.RTCThresholdRange.RTCAction = null;
            this.RTCThresholdRange.RTCBeginValue = 0D;
            this.RTCThresholdRange.RTCEndValue = 25D;
            this.RTCThresholdRange.RTCMax = 255D;
            this.RTCThresholdRange.RTCMin = 0D;
            this.RTCThresholdRange.RTCPropertyName = "ThresholdRange";
            this.RTCThresholdRange.RTCStepChange = 0.1D;
            this.RTCThresholdRange.RTCValuePropertyName = "AutoThresholdRange";
            this.RTCThresholdRange.Size = new System.Drawing.Size(168, 72);
            this.RTCThresholdRange.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Type";
            // 
            // RTCGreyLevelThresholdType
            // 
            this.RTCGreyLevelThresholdType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCGreyLevelThresholdType.FormattingEnabled = true;
            this.RTCGreyLevelThresholdType.Location = new System.Drawing.Point(61, 20);
            this.RTCGreyLevelThresholdType.Margin = new System.Windows.Forms.Padding(2);
            this.RTCGreyLevelThresholdType.Name = "RTCGreyLevelThresholdType";
            this.RTCGreyLevelThresholdType.Size = new System.Drawing.Size(198, 21);
            this.RTCGreyLevelThresholdType.TabIndex = 4;
            // 
            // lblSetPropertiesToOtherROI
            // 
            this.lblSetPropertiesToOtherROI.AutoSize = true;
            this.lblSetPropertiesToOtherROI.ForeColor = System.Drawing.Color.Yellow;
            this.lblSetPropertiesToOtherROI.Location = new System.Drawing.Point(24, 219);
            this.lblSetPropertiesToOtherROI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSetPropertiesToOtherROI.Name = "lblSetPropertiesToOtherROI";
            this.lblSetPropertiesToOtherROI.Size = new System.Drawing.Size(166, 13);
            this.lblSetPropertiesToOtherROI.TabIndex = 4;
            this.lblSetPropertiesToOtherROI.Text = "Apply Properties To Other ROIs";
            this.lblSetPropertiesToOtherROI.Click += new System.EventHandler(this.lblSetPropertiesToOtherRoi_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblSetPropertiesToOtherROI);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.RTCFillHoles);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.RTCDetectType);
            this.groupBox5.Location = new System.Drawing.Point(20, 36);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(345, 251);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search";
            // 
            // ucRangeMaxMinWidth
            // 
            this.ucRangeMaxMinWidth.AutoSize = true;
            this.ucRangeMaxMinWidth.Location = new System.Drawing.Point(4, 82);
            this.ucRangeMaxMinWidth.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinWidth.Name = "ucRangeMaxMinWidth";
            this.ucRangeMaxMinWidth.RTCAction = null;
            this.ucRangeMaxMinWidth.RTCActualPropertyName = "WidthActual";
            this.ucRangeMaxMinWidth.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinWidth.RTCCheckboxCaption = "Width";
            this.ucRangeMaxMinWidth.RTCCheckboxPropertyName = "EnableWidthFilter";
            this.ucRangeMaxMinWidth.RTCCheckboxSize = 120;
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
            this.ucRangeMaxMinWidth.Size = new System.Drawing.Size(428, 34);
            this.ucRangeMaxMinWidth.TabIndex = 1;
            // 
            // ucRangeMaxMinHeight
            // 
            this.ucRangeMaxMinHeight.AutoSize = true;
            this.ucRangeMaxMinHeight.Location = new System.Drawing.Point(4, 116);
            this.ucRangeMaxMinHeight.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinHeight.Name = "ucRangeMaxMinHeight";
            this.ucRangeMaxMinHeight.RTCAction = null;
            this.ucRangeMaxMinHeight.RTCActualPropertyName = "HeightActual";
            this.ucRangeMaxMinHeight.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinHeight.RTCCheckboxCaption = "Height";
            this.ucRangeMaxMinHeight.RTCCheckboxPropertyName = "EnableHeightFilter";
            this.ucRangeMaxMinHeight.RTCCheckboxSize = 120;
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
            this.ucRangeMaxMinHeight.Size = new System.Drawing.Size(428, 34);
            this.ucRangeMaxMinHeight.TabIndex = 2;
            // 
            // ucRangeMaxMinArea
            // 
            this.ucRangeMaxMinArea.AutoSize = true;
            this.ucRangeMaxMinArea.Location = new System.Drawing.Point(4, 19);
            this.ucRangeMaxMinArea.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinArea.Name = "ucRangeMaxMinArea";
            this.ucRangeMaxMinArea.RTCAction = null;
            this.ucRangeMaxMinArea.RTCActualPropertyName = "AreaActual";
            this.ucRangeMaxMinArea.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinArea.RTCCheckboxCaption = "Area";
            this.ucRangeMaxMinArea.RTCCheckboxPropertyName = "EnableAreaFilter";
            this.ucRangeMaxMinArea.RTCCheckboxSize = 120;
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
            this.ucRangeMaxMinArea.Size = new System.Drawing.Size(428, 60);
            this.ucRangeMaxMinArea.TabIndex = 3;
            // 
            // ucRangeMaxMinOuterRadius
            // 
            this.ucRangeMaxMinOuterRadius.AutoSize = true;
            this.ucRangeMaxMinOuterRadius.Location = new System.Drawing.Point(4, 154);
            this.ucRangeMaxMinOuterRadius.Margin = new System.Windows.Forms.Padding(2);
            this.ucRangeMaxMinOuterRadius.Name = "ucRangeMaxMinOuterRadius";
            this.ucRangeMaxMinOuterRadius.RTCAction = null;
            this.ucRangeMaxMinOuterRadius.RTCActualPropertyName = "OuterRadiusActual";
            this.ucRangeMaxMinOuterRadius.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMinOuterRadius.RTCCheckboxCaption = "Outer Radius";
            this.ucRangeMaxMinOuterRadius.RTCCheckboxPropertyName = "EnableOuterRadiusFilter";
            this.ucRangeMaxMinOuterRadius.RTCCheckboxSize = 120;
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
            this.ucRangeMaxMinOuterRadius.Size = new System.Drawing.Size(428, 34);
            this.ucRangeMaxMinOuterRadius.TabIndex = 4;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ucRangeMaxMinOuterRadius);
            this.groupBox10.Controls.Add(this.ucRangeMaxMinArea);
            this.groupBox10.Controls.Add(this.ucRangeMaxMinHeight);
            this.groupBox10.Controls.Add(this.ucRangeMaxMinWidth);
            this.groupBox10.Location = new System.Drawing.Point(384, 36);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(465, 186);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Filters";
            // 
            // ucBlobMultipleROIActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucBlobMultipleROIActionDetail";
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private UserControls.ucConfigureDateTimeInput ucConfigureDataTimeInput1;
        private UserControls.ucRangeMaxMinLimit ucRangeMaxMinLimit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private ucOrigin ucOrigin;
        private ucImageLink ucImageLink;
        private System.Windows.Forms.Label lblSetupPassed;
        private System.Windows.Forms.CheckBox chkRunOnlyROISelect;
        private System.Windows.Forms.Button btnRunMultiROI;
        private System.Windows.Forms.GroupBox groupBox11;
        private ucRangeMaxMin ucRangeMaxMinNumberOfBlob;
        private System.Windows.Forms.GroupBox groupBox10;
        private ucRangeMaxMin ucRangeMaxMinOuterRadius;
        private ucRangeMaxMin ucRangeMaxMinArea;
        private ucRangeMaxMin ucRangeMaxMinHeight;
        private ucRangeMaxMin ucRangeMaxMinWidth;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox RTCEnableOutputDimsList;
        private System.Windows.Forms.CheckBox RTCEnableOutputAreaList;
        private System.Windows.Forms.CheckBox RTCEnableOutputBlobList;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblSetPropertiesToOtherROI;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private ucRangeMaxMinLimit RTCThresholdRange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox RTCGreyLevelThresholdType;
        private System.Windows.Forms.CheckBox RTCFillHoles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox RTCDetectType;
    }
}
