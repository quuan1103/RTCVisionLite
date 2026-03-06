
namespace RTC_Vision_Lite.UserControls
{
    partial class ucCodeReaderActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCodeReaderActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.ucRangeMaxMinLimit1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.label2 = new System.Windows.Forms.Label();
            this.ucOrigin = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RTCCode = new System.Windows.Forms.ComboBox();
            this.RTCTrainCodeMode = new System.Windows.Forms.ComboBox();
            this.RTCMaximumNumberOfCodeToFind = new System.Windows.Forms.TextBox();
            this.RTCBarcodeHeightMin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.RTCPLESSEY = new System.Windows.Forms.CheckBox();
            this.RTCMSI = new System.Windows.Forms.CheckBox();
            this.RTCUPC_EAN_EXTENSION = new System.Windows.Forms.CheckBox();
            this.RTCRSS_EXPANDED = new System.Windows.Forms.CheckBox();
            this.RTCIMB = new System.Windows.Forms.CheckBox();
            this.RTCRSS_14 = new System.Windows.Forms.CheckBox();
            this.RTCUPC_E = new System.Windows.Forms.CheckBox();
            this.RTCPDF_417 = new System.Windows.Forms.CheckBox();
            this.RTCUPC_A = new System.Windows.Forms.CheckBox();
            this.RTCEAN_13 = new System.Windows.Forms.CheckBox();
            this.RTCEAN_8 = new System.Windows.Forms.CheckBox();
            this.RTCPHARMA_CODE = new System.Windows.Forms.CheckBox();
            this.RTCCODE_128 = new System.Windows.Forms.CheckBox();
            this.RTCInterleaved = new System.Windows.Forms.CheckBox();
            this.RTCCODE_93 = new System.Windows.Forms.CheckBox();
            this.RTCCODABAR = new System.Windows.Forms.CheckBox();
            this.RTCCODE_39 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RTCAZTEC = new System.Windows.Forms.CheckBox();
            this.RTCMAXICODE = new System.Windows.Forms.CheckBox();
            this.RTCQR_CODE = new System.Windows.Forms.CheckBox();
            this.RTCDATA_MATRIX = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RTCDefaultOutputString = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ucRangeMaxMin1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.RTCInputString = new System.Windows.Forms.TextBox();
            this.RTCMatchString = new System.Windows.Forms.CheckBox();
            this.chkRunOnlyROISelect = new System.Windows.Forms.CheckBox();
            this.RTCTrainPressed = new System.Windows.Forms.Button();
            this.btnRunMultiROI = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            this.PageActionSetting.Size = new System.Drawing.Size(900, 550);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(4, 4);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableGeneral.Size = new System.Drawing.Size(857, 467);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(2, 39);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(4);
            this.PageSetup.Size = new System.Drawing.Size(888, 483);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(4);
            this.ROI.Padding = new System.Windows.Forms.Padding(4);
            this.ROI.Size = new System.Drawing.Size(865, 475);
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
            this.ScrollableROI.Controls.Add(this.btnRunMultiROI);
            this.ScrollableROI.Controls.Add(this.RTCTrainPressed);
            this.ScrollableROI.Controls.Add(this.chkRunOnlyROISelect);
            this.ScrollableROI.Controls.Add(this.groupBox7);
            this.ScrollableROI.Controls.Add(this.groupBox3);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.RTCBarcodeHeightMin);
            this.ScrollableROI.Controls.Add(this.RTCMaximumNumberOfCodeToFind);
            this.ScrollableROI.Controls.Add(this.RTCTrainCodeMode);
            this.ScrollableROI.Controls.Add(this.RTCCode);
            this.ScrollableROI.Controls.Add(this.label7);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Controls.Add(this.label5);
            this.ScrollableROI.Controls.Add(this.label3);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label4);
            this.ScrollableROI.Location = new System.Drawing.Point(4, 4);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableROI.Size = new System.Drawing.Size(857, 467);
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
            this.General.Size = new System.Drawing.Size(865, 475);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(2);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(2);
            this.TabSetUp.Size = new System.Drawing.Size(892, 524);
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
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(639, 22);
            this.RTCName.TabIndex = 1;
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
            // ucOrigin
            // 
            this.ucOrigin.Action = null;
            this.ucOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin.Location = new System.Drawing.Point(11, 142);
            this.ucOrigin.Name = "ucOrigin";
            this.ucOrigin.PropertyName = "ToolOrigin";
            this.ucOrigin.Size = new System.Drawing.Size(686, 91);
            this.ucOrigin.TabIndex = 3;
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 3;
            this.RTCPassed.Text = "Passed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Pass/Fail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Train Mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(561, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Bar Code Height Min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(559, 101);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Maximum Number of Code";
            // 
            // RTCCode
            // 
            this.RTCCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCCode.FormattingEnabled = true;
            this.RTCCode.Location = new System.Drawing.Point(132, 33);
            this.RTCCode.Name = "RTCCode";
            this.RTCCode.Size = new System.Drawing.Size(115, 21);
            this.RTCCode.TabIndex = 8;
            // 
            // RTCTrainCodeMode
            // 
            this.RTCTrainCodeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCTrainCodeMode.FormattingEnabled = true;
            this.RTCTrainCodeMode.Location = new System.Drawing.Point(673, 68);
            this.RTCTrainCodeMode.Name = "RTCTrainCodeMode";
            this.RTCTrainCodeMode.Size = new System.Drawing.Size(115, 21);
            this.RTCTrainCodeMode.TabIndex = 9;
            // 
            // RTCMaximumNumberOfCodeToFind
            // 
            this.RTCMaximumNumberOfCodeToFind.Location = new System.Drawing.Point(722, 98);
            this.RTCMaximumNumberOfCodeToFind.Name = "RTCMaximumNumberOfCodeToFind";
            this.RTCMaximumNumberOfCodeToFind.Size = new System.Drawing.Size(68, 22);
            this.RTCMaximumNumberOfCodeToFind.TabIndex = 10;
            // 
            // RTCBarcodeHeightMin
            // 
            this.RTCBarcodeHeightMin.Location = new System.Drawing.Point(722, 128);
            this.RTCBarcodeHeightMin.Name = "RTCBarcodeHeightMin";
            this.RTCBarcodeHeightMin.Size = new System.Drawing.Size(68, 22);
            this.RTCBarcodeHeightMin.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 163);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Code 1D";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.RTCPLESSEY);
            this.panel4.Controls.Add(this.RTCMSI);
            this.panel4.Controls.Add(this.RTCUPC_EAN_EXTENSION);
            this.panel4.Controls.Add(this.RTCRSS_EXPANDED);
            this.panel4.Controls.Add(this.RTCIMB);
            this.panel4.Controls.Add(this.RTCRSS_14);
            this.panel4.Controls.Add(this.RTCUPC_E);
            this.panel4.Controls.Add(this.RTCPDF_417);
            this.panel4.Controls.Add(this.RTCUPC_A);
            this.panel4.Controls.Add(this.RTCEAN_13);
            this.panel4.Controls.Add(this.RTCEAN_8);
            this.panel4.Controls.Add(this.RTCPHARMA_CODE);
            this.panel4.Controls.Add(this.RTCCODE_128);
            this.panel4.Controls.Add(this.RTCInterleaved);
            this.panel4.Controls.Add(this.RTCCODE_93);
            this.panel4.Controls.Add(this.RTCCODABAR);
            this.panel4.Controls.Add(this.RTCCODE_39);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 18);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(221, 142);
            this.panel4.TabIndex = 8;
            // 
            // RTCPLESSEY
            // 
            this.RTCPLESSEY.AutoSize = true;
            this.RTCPLESSEY.Location = new System.Drawing.Point(8, 288);
            this.RTCPLESSEY.Name = "RTCPLESSEY";
            this.RTCPLESSEY.Size = new System.Drawing.Size(62, 17);
            this.RTCPLESSEY.TabIndex = 17;
            this.RTCPLESSEY.Text = "Plessey";
            this.RTCPLESSEY.UseVisualStyleBackColor = true;
            // 
            // RTCMSI
            // 
            this.RTCMSI.AutoSize = true;
            this.RTCMSI.Location = new System.Drawing.Point(8, 269);
            this.RTCMSI.Name = "RTCMSI";
            this.RTCMSI.Size = new System.Drawing.Size(45, 17);
            this.RTCMSI.TabIndex = 16;
            this.RTCMSI.Text = "MSI";
            this.RTCMSI.UseVisualStyleBackColor = true;
            // 
            // RTCUPC_EAN_EXTENSION
            // 
            this.RTCUPC_EAN_EXTENSION.AutoSize = true;
            this.RTCUPC_EAN_EXTENSION.Location = new System.Drawing.Point(8, 193);
            this.RTCUPC_EAN_EXTENSION.Name = "RTCUPC_EAN_EXTENSION";
            this.RTCUPC_EAN_EXTENSION.Size = new System.Drawing.Size(122, 17);
            this.RTCUPC_EAN_EXTENSION.TabIndex = 15;
            this.RTCUPC_EAN_EXTENSION.Text = "UPC Ean Extension";
            this.RTCUPC_EAN_EXTENSION.UseVisualStyleBackColor = true;
            // 
            // RTCRSS_EXPANDED
            // 
            this.RTCRSS_EXPANDED.AutoSize = true;
            this.RTCRSS_EXPANDED.Location = new System.Drawing.Point(8, 231);
            this.RTCRSS_EXPANDED.Name = "RTCRSS_EXPANDED";
            this.RTCRSS_EXPANDED.Size = new System.Drawing.Size(99, 17);
            this.RTCRSS_EXPANDED.TabIndex = 14;
            this.RTCRSS_EXPANDED.Text = "RSS Expended";
            this.RTCRSS_EXPANDED.UseVisualStyleBackColor = true;
            // 
            // RTCIMB
            // 
            this.RTCIMB.AutoSize = true;
            this.RTCIMB.Location = new System.Drawing.Point(8, 307);
            this.RTCIMB.Name = "RTCIMB";
            this.RTCIMB.Size = new System.Drawing.Size(46, 17);
            this.RTCIMB.TabIndex = 13;
            this.RTCIMB.Text = "IMB";
            this.RTCIMB.UseVisualStyleBackColor = true;
            // 
            // RTCRSS_14
            // 
            this.RTCRSS_14.AutoSize = true;
            this.RTCRSS_14.Location = new System.Drawing.Point(8, 212);
            this.RTCRSS_14.Name = "RTCRSS_14";
            this.RTCRSS_14.Size = new System.Drawing.Size(57, 17);
            this.RTCRSS_14.TabIndex = 12;
            this.RTCRSS_14.Text = "RSS14";
            this.RTCRSS_14.UseVisualStyleBackColor = true;
            // 
            // RTCUPC_E
            // 
            this.RTCUPC_E.AutoSize = true;
            this.RTCUPC_E.Location = new System.Drawing.Point(8, 174);
            this.RTCUPC_E.Name = "RTCUPC_E";
            this.RTCUPC_E.Size = new System.Drawing.Size(57, 17);
            this.RTCUPC_E.TabIndex = 11;
            this.RTCUPC_E.Text = "UPC-E";
            this.RTCUPC_E.UseVisualStyleBackColor = true;
            // 
            // RTCPDF_417
            // 
            this.RTCPDF_417.AutoSize = true;
            this.RTCPDF_417.Location = new System.Drawing.Point(8, 250);
            this.RTCPDF_417.Name = "RTCPDF_417";
            this.RTCPDF_417.Size = new System.Drawing.Size(64, 17);
            this.RTCPDF_417.TabIndex = 2;
            this.RTCPDF_417.Text = "PDF417";
            this.RTCPDF_417.UseVisualStyleBackColor = true;
            // 
            // RTCUPC_A
            // 
            this.RTCUPC_A.AutoSize = true;
            this.RTCUPC_A.Location = new System.Drawing.Point(8, 155);
            this.RTCUPC_A.Name = "RTCUPC_A";
            this.RTCUPC_A.Size = new System.Drawing.Size(58, 17);
            this.RTCUPC_A.TabIndex = 10;
            this.RTCUPC_A.Text = "UPC-A";
            this.RTCUPC_A.UseVisualStyleBackColor = true;
            // 
            // RTCEAN_13
            // 
            this.RTCEAN_13.AutoSize = true;
            this.RTCEAN_13.Location = new System.Drawing.Point(8, 136);
            this.RTCEAN_13.Name = "RTCEAN_13";
            this.RTCEAN_13.Size = new System.Drawing.Size(63, 17);
            this.RTCEAN_13.TabIndex = 9;
            this.RTCEAN_13.Text = "EAN-13";
            this.RTCEAN_13.UseVisualStyleBackColor = true;
            // 
            // RTCEAN_8
            // 
            this.RTCEAN_8.AutoSize = true;
            this.RTCEAN_8.Location = new System.Drawing.Point(8, 117);
            this.RTCEAN_8.Name = "RTCEAN_8";
            this.RTCEAN_8.Size = new System.Drawing.Size(57, 17);
            this.RTCEAN_8.TabIndex = 8;
            this.RTCEAN_8.Text = "EAN-8";
            this.RTCEAN_8.UseVisualStyleBackColor = true;
            // 
            // RTCPHARMA_CODE
            // 
            this.RTCPHARMA_CODE.AutoSize = true;
            this.RTCPHARMA_CODE.Location = new System.Drawing.Point(8, 98);
            this.RTCPHARMA_CODE.Name = "RTCPHARMA_CODE";
            this.RTCPHARMA_CODE.Size = new System.Drawing.Size(91, 17);
            this.RTCPHARMA_CODE.TabIndex = 7;
            this.RTCPHARMA_CODE.Text = "PharmaCode";
            this.RTCPHARMA_CODE.UseVisualStyleBackColor = true;
            // 
            // RTCCODE_128
            // 
            this.RTCCODE_128.AutoSize = true;
            this.RTCCODE_128.Location = new System.Drawing.Point(8, 60);
            this.RTCCODE_128.Name = "RTCCODE_128";
            this.RTCCODE_128.Size = new System.Drawing.Size(74, 17);
            this.RTCCODE_128.TabIndex = 6;
            this.RTCCODE_128.Text = "Code 128";
            this.RTCCODE_128.UseVisualStyleBackColor = true;
            // 
            // RTCInterleaved
            // 
            this.RTCInterleaved.AutoSize = true;
            this.RTCInterleaved.Location = new System.Drawing.Point(8, 79);
            this.RTCInterleaved.Name = "RTCInterleaved";
            this.RTCInterleaved.Size = new System.Drawing.Size(40, 17);
            this.RTCInterleaved.TabIndex = 5;
            this.RTCInterleaved.Text = "ITF";
            this.RTCInterleaved.UseVisualStyleBackColor = true;
            // 
            // RTCCODE_93
            // 
            this.RTCCODE_93.AutoSize = true;
            this.RTCCODE_93.Location = new System.Drawing.Point(8, 41);
            this.RTCCODE_93.Name = "RTCCODE_93";
            this.RTCCODE_93.Size = new System.Drawing.Size(68, 17);
            this.RTCCODE_93.TabIndex = 4;
            this.RTCCODE_93.Text = "Code 93";
            this.RTCCODE_93.UseVisualStyleBackColor = true;
            // 
            // RTCCODABAR
            // 
            this.RTCCODABAR.AutoSize = true;
            this.RTCCODABAR.Location = new System.Drawing.Point(8, 3);
            this.RTCCODABAR.Name = "RTCCODABAR";
            this.RTCCODABAR.Size = new System.Drawing.Size(70, 17);
            this.RTCCODABAR.TabIndex = 3;
            this.RTCCODABAR.Text = "Codabar";
            this.RTCCODABAR.UseVisualStyleBackColor = true;
            // 
            // RTCCODE_39
            // 
            this.RTCCODE_39.AutoSize = true;
            this.RTCCODE_39.Location = new System.Drawing.Point(8, 22);
            this.RTCCODE_39.Name = "RTCCODE_39";
            this.RTCCODE_39.Size = new System.Drawing.Size(68, 17);
            this.RTCCODE_39.TabIndex = 2;
            this.RTCCODE_39.Text = "Code 39";
            this.RTCCODE_39.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Location = new System.Drawing.Point(300, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 163);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code 2D";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.RTCAZTEC);
            this.panel2.Controls.Add(this.RTCMAXICODE);
            this.panel2.Controls.Add(this.RTCQR_CODE);
            this.panel2.Controls.Add(this.RTCDATA_MATRIX);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 142);
            this.panel2.TabIndex = 9;
            // 
            // RTCAZTEC
            // 
            this.RTCAZTEC.AutoSize = true;
            this.RTCAZTEC.Location = new System.Drawing.Point(8, 53);
            this.RTCAZTEC.Name = "RTCAZTEC";
            this.RTCAZTEC.Size = new System.Drawing.Size(83, 17);
            this.RTCAZTEC.TabIndex = 4;
            this.RTCAZTEC.Text = "Aztec Code";
            this.RTCAZTEC.UseVisualStyleBackColor = true;
            // 
            // RTCMAXICODE
            // 
            this.RTCMAXICODE.AutoSize = true;
            this.RTCMAXICODE.Location = new System.Drawing.Point(8, 37);
            this.RTCMAXICODE.Name = "RTCMAXICODE";
            this.RTCMAXICODE.Size = new System.Drawing.Size(80, 17);
            this.RTCMAXICODE.TabIndex = 3;
            this.RTCMAXICODE.Text = "Maxi Code";
            this.RTCMAXICODE.UseVisualStyleBackColor = true;
            // 
            // RTCQR_CODE
            // 
            this.RTCQR_CODE.AutoSize = true;
            this.RTCQR_CODE.Location = new System.Drawing.Point(8, 20);
            this.RTCQR_CODE.Name = "RTCQR_CODE";
            this.RTCQR_CODE.Size = new System.Drawing.Size(71, 17);
            this.RTCQR_CODE.TabIndex = 1;
            this.RTCQR_CODE.Text = "QR Code";
            this.RTCQR_CODE.UseVisualStyleBackColor = true;
            // 
            // RTCDATA_MATRIX
            // 
            this.RTCDATA_MATRIX.AutoSize = true;
            this.RTCDATA_MATRIX.Location = new System.Drawing.Point(8, 3);
            this.RTCDATA_MATRIX.Name = "RTCDATA_MATRIX";
            this.RTCDATA_MATRIX.Size = new System.Drawing.Size(126, 17);
            this.RTCDATA_MATRIX.TabIndex = 0;
            this.RTCDATA_MATRIX.Text = "Data Matrix ECC200";
            this.RTCDATA_MATRIX.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RTCDefaultOutputString);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.ucRangeMaxMin1);
            this.groupBox7.Controls.Add(this.RTCInputString);
            this.groupBox7.Controls.Add(this.RTCMatchString);
            this.groupBox7.Location = new System.Drawing.Point(20, 229);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(503, 123);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Settings";
            // 
            // RTCDefaultOutputString
            // 
            this.RTCDefaultOutputString.Location = new System.Drawing.Point(108, 92);
            this.RTCDefaultOutputString.Name = "RTCDefaultOutputString";
            this.RTCDefaultOutputString.Size = new System.Drawing.Size(379, 22);
            this.RTCDefaultOutputString.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 95);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Default String:";
            // 
            // ucRangeMaxMin1
            // 
            this.ucRangeMaxMin1.AutoSize = true;
            this.ucRangeMaxMin1.Location = new System.Drawing.Point(3, 54);
            this.ucRangeMaxMin1.Name = "ucRangeMaxMin1";
            this.ucRangeMaxMin1.RTCAction = null;
            this.ucRangeMaxMin1.RTCActualPropertyName = "NumberOfCodeFound";
            this.ucRangeMaxMin1.RTCAllowInfinityMaxValue = true;
            this.ucRangeMaxMin1.RTCCheckboxCaption = "Quanlity";
            this.ucRangeMaxMin1.RTCCheckboxPropertyName = "CheckQuantity";
            this.ucRangeMaxMin1.RTCCheckboxSize = 100;
            this.ucRangeMaxMin1.RTCChecked = false;
            this.ucRangeMaxMin1.RTCEditMask = "n2";
            this.ucRangeMaxMin1.RTCFeaturesLabel = "Features";
            this.ucRangeMaxMin1.RTCIsLimit = false;
            this.ucRangeMaxMin1.RTCMaxLabel = "Max";
            this.ucRangeMaxMin1.RTCMinLabel = "Min";
            this.ucRangeMaxMin1.RTCTextboxSize = 50;
            this.ucRangeMaxMin1.RTCUseActual = false;
            this.ucRangeMaxMin1.RTCUseActualLabel = false;
            this.ucRangeMaxMin1.RTCUseCheckbox = true;
            this.ucRangeMaxMin1.RTCUseFeatures = false;
            this.ucRangeMaxMin1.RTCUseMaskAsDisplayFormat = false;
            this.ucRangeMaxMin1.RTCUseMinMaxAtLine = false;
            this.ucRangeMaxMin1.RTCUseMinMaxAtTop = false;
            this.ucRangeMaxMin1.RTCValuePropertyName = "NumberCodeRequired";
            this.ucRangeMaxMin1.Size = new System.Drawing.Size(484, 30);
            this.ucRangeMaxMin1.TabIndex = 15;
            // 
            // RTCInputString
            // 
            this.RTCInputString.Location = new System.Drawing.Point(108, 16);
            this.RTCInputString.Name = "RTCInputString";
            this.RTCInputString.Size = new System.Drawing.Size(379, 22);
            this.RTCInputString.TabIndex = 14;
            // 
            // RTCMatchString
            // 
            this.RTCMatchString.AutoSize = true;
            this.RTCMatchString.Location = new System.Drawing.Point(6, 21);
            this.RTCMatchString.Name = "RTCMatchString";
            this.RTCMatchString.Size = new System.Drawing.Size(92, 17);
            this.RTCMatchString.TabIndex = 13;
            this.RTCMatchString.Text = "Match String";
            this.RTCMatchString.UseVisualStyleBackColor = true;
            // 
            // chkRunOnlyROISelect
            // 
            this.chkRunOnlyROISelect.AutoSize = true;
            this.chkRunOnlyROISelect.Location = new System.Drawing.Point(20, 368);
            this.chkRunOnlyROISelect.Name = "chkRunOnlyROISelect";
            this.chkRunOnlyROISelect.Size = new System.Drawing.Size(118, 17);
            this.chkRunOnlyROISelect.TabIndex = 18;
            this.chkRunOnlyROISelect.Text = "Only ROI Selected";
            this.chkRunOnlyROISelect.UseVisualStyleBackColor = true;
            // 
            // RTCTrainPressed
            // 
            this.RTCTrainPressed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RTCTrainPressed.Location = new System.Drawing.Point(169, 364);
            this.RTCTrainPressed.Name = "RTCTrainPressed";
            this.RTCTrainPressed.Size = new System.Drawing.Size(75, 23);
            this.RTCTrainPressed.TabIndex = 19;
            this.RTCTrainPressed.Text = "Train";
            this.RTCTrainPressed.UseVisualStyleBackColor = true;
            this.RTCTrainPressed.Click += new System.EventHandler(this.RTCTrainPressed_Click);
            // 
            // btnRunMultiROI
            // 
            this.btnRunMultiROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunMultiROI.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x16;
            this.btnRunMultiROI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunMultiROI.Location = new System.Drawing.Point(259, 364);
            this.btnRunMultiROI.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunMultiROI.Name = "btnRunMultiROI";
            this.btnRunMultiROI.Size = new System.Drawing.Size(86, 25);
            this.btnRunMultiROI.TabIndex = 20;
            this.btnRunMultiROI.Text = "Run (F5)";
            this.btnRunMultiROI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRunMultiROI.UseVisualStyleBackColor = true;
            this.btnRunMultiROI.Click += new System.EventHandler(this.btnRunMultiROI_Click);
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(10, 50);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputGrayImage";
            this.ucImageLink.Size = new System.Drawing.Size(687, 79);
            this.ucImageLink.TabIndex = 2;
            // 
            // ucCodeReaderActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucCodeReaderActionDetail";
            this.Size = new System.Drawing.Size(900, 550);
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
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private UserControls.ucRangeMaxMinLimit ucRangeMaxMinLimit1;
        private System.Windows.Forms.Label label2;
        private ucOrigin ucOrigin;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RTCBarcodeHeightMin;
        private System.Windows.Forms.TextBox RTCMaximumNumberOfCodeToFind;
        private System.Windows.Forms.ComboBox RTCTrainCodeMode;
        private System.Windows.Forms.ComboBox RTCCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox RTCRSS_14;
        private System.Windows.Forms.CheckBox RTCUPC_E;
        private System.Windows.Forms.CheckBox RTCUPC_A;
        private System.Windows.Forms.CheckBox RTCEAN_13;
        private System.Windows.Forms.CheckBox RTCEAN_8;
        private System.Windows.Forms.CheckBox RTCPHARMA_CODE;
        private System.Windows.Forms.CheckBox RTCCODE_128;
        private System.Windows.Forms.CheckBox RTCInterleaved;
        private System.Windows.Forms.CheckBox RTCCODE_93;
        private System.Windows.Forms.CheckBox RTCCODABAR;
        private System.Windows.Forms.CheckBox RTCCODE_39;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox RTCAZTEC;
        private System.Windows.Forms.CheckBox RTCMAXICODE;
        private System.Windows.Forms.CheckBox RTCPDF_417;
        private System.Windows.Forms.CheckBox RTCQR_CODE;
        private System.Windows.Forms.CheckBox RTCDATA_MATRIX;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox RTCInputString;
        private System.Windows.Forms.CheckBox RTCMatchString;
        private ucRangeMaxMin ucRangeMaxMin1;
        private System.Windows.Forms.Button RTCTrainPressed;
        private System.Windows.Forms.CheckBox chkRunOnlyROISelect;
        private System.Windows.Forms.TextBox RTCDefaultOutputString;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRunMultiROI;
        private System.Windows.Forms.CheckBox RTCRSS_EXPANDED;
        private System.Windows.Forms.CheckBox RTCIMB;
        private System.Windows.Forms.CheckBox RTCUPC_EAN_EXTENSION;
        private System.Windows.Forms.CheckBox RTCPLESSEY;
        private System.Windows.Forms.CheckBox RTCMSI;
        private ucImageLink ucImageLink;
    }
}
