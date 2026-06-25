
namespace RTC_Vision_Lite.UserControls
{
    partial class ucRunProgramActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRunProgramActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.ucRangeMaxMinLimit1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RTCIsRunOneTime = new System.Windows.Forms.CheckBox();
            this.RTCRunMode = new System.Windows.Forms.ComboBox();
            this.ucProgramName1 = new RTC_Vision_Lite.UserControls.ucProgramName();
            this.label3 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStopTest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucRangeMaxMin1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.RTCInputString = new System.Windows.Forms.TextBox();
            this.RTCMatchString = new System.Windows.Forms.CheckBox();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollablePassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1155, 509);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(3, 48);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(5);
            this.PageSetup.Size = new System.Drawing.Size(1186, 525);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(5);
            this.ROI.Padding = new System.Windows.Forms.Padding(5);
            this.ROI.Size = new System.Drawing.Size(1163, 517);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(5);
            this.PassFail.Size = new System.Drawing.Size(1163, 517);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Controls.Add(this.groupBox1);
            this.ScrollablePassFail.Controls.Add(this.label6);
            this.ScrollablePassFail.Controls.Add(this.label7);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1163, 517);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.btnStopTest);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label5);
            this.ScrollableROI.Controls.Add(this.groupBox3);
            this.ScrollableROI.Location = new System.Drawing.Point(5, 5);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableROI.Size = new System.Drawing.Size(1153, 507);
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
            this.Method.Size = new System.Drawing.Size(1163, 517);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Display.Size = new System.Drawing.Size(1163, 517);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(3, 2);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableMethod.Size = new System.Drawing.Size(1157, 513);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(1155, 509);
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
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(77, 18);
            this.RTCName.Margin = new System.Windows.Forms.Padding(4);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(854, 22);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RTCIsRunOneTime);
            this.groupBox3.Controls.Add(this.RTCRunMode);
            this.groupBox3.Controls.Add(this.ucProgramName1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(22, 32);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(548, 122);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // RTCIsRunOneTime
            // 
            this.RTCIsRunOneTime.AutoSize = true;
            this.RTCIsRunOneTime.Location = new System.Drawing.Point(147, 87);
            this.RTCIsRunOneTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCIsRunOneTime.Name = "RTCIsRunOneTime";
            this.RTCIsRunOneTime.Size = new System.Drawing.Size(98, 17);
            this.RTCIsRunOneTime.TabIndex = 4;
            this.RTCIsRunOneTime.Text = "Run One Time";
            this.RTCIsRunOneTime.UseVisualStyleBackColor = true;
            // 
            // RTCRunMode
            // 
            this.RTCRunMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCRunMode.FormattingEnabled = true;
            this.RTCRunMode.Location = new System.Drawing.Point(147, 57);
            this.RTCRunMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCRunMode.Name = "RTCRunMode";
            this.RTCRunMode.Size = new System.Drawing.Size(379, 21);
            this.RTCRunMode.TabIndex = 2;
            // 
            // ucProgramName1
            // 
            this.ucProgramName1.Location = new System.Drawing.Point(9, 18);
            this.ucProgramName1.Margin = new System.Windows.Forms.Padding(5);
            this.ucProgramName1.Name = "ucProgramName1";
            this.ucProgramName1.ProgramName = "";
            this.ucProgramName1.RTCAction = null;
            this.ucProgramName1.RTCCaptionWidth = 75F;
            this.ucProgramName1.RTCIsMultiChoose = false;
            this.ucProgramName1.RTCIsUseCaption = true;
            this.ucProgramName1.RTCIsUseThisCam = true;
            this.ucProgramName1.RTCPropertyName = "ProgramName";
            this.ucProgramName1.Size = new System.Drawing.Size(521, 33);
            this.ucProgramName1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "RunMode";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(125, 6);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 3;
            this.RTCPassed.Text = "Passed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Pass/Fail:";
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.White;
            this.btnTest.Location = new System.Drawing.Point(22, 167);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(89, 33);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStopTest
            // 
            this.btnStopTest.BackColor = System.Drawing.Color.White;
            this.btnStopTest.Location = new System.Drawing.Point(154, 167);
            this.btnStopTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStopTest.Name = "btnStopTest";
            this.btnStopTest.Size = new System.Drawing.Size(95, 33);
            this.btnStopTest.TabIndex = 5;
            this.btnStopTest.Text = "Stop Test";
            this.btnStopTest.UseVisualStyleBackColor = false;
            this.btnStopTest.Click += new System.EventHandler(this.btnStopTest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(109, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Passed";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Pass/Fail:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucRangeMaxMin1);
            this.groupBox1.Controls.Add(this.RTCInputString);
            this.groupBox1.Controls.Add(this.RTCMatchString);
            this.groupBox1.Location = new System.Drawing.Point(27, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(592, 107);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // ucRangeMaxMin1
            // 
            this.ucRangeMaxMin1.AutoSize = true;
            this.ucRangeMaxMin1.Location = new System.Drawing.Point(4, 58);
            this.ucRangeMaxMin1.Margin = new System.Windows.Forms.Padding(4);
            this.ucRangeMaxMin1.Name = "ucRangeMaxMin1";
            this.ucRangeMaxMin1.RTCAction = null;
            this.ucRangeMaxMin1.RTCActualPropertyName = null;
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
            this.ucRangeMaxMin1.Size = new System.Drawing.Size(516, 37);
            this.ucRangeMaxMin1.TabIndex = 3;
            // 
            // RTCInputString
            // 
            this.RTCInputString.Location = new System.Drawing.Point(133, 23);
            this.RTCInputString.Margin = new System.Windows.Forms.Padding(4);
            this.RTCInputString.Name = "RTCInputString";
            this.RTCInputString.Size = new System.Drawing.Size(295, 22);
            this.RTCInputString.TabIndex = 2;
            // 
            // RTCMatchString
            // 
            this.RTCMatchString.AutoSize = true;
            this.RTCMatchString.Location = new System.Drawing.Point(8, 26);
            this.RTCMatchString.Margin = new System.Windows.Forms.Padding(4);
            this.RTCMatchString.Name = "RTCMatchString";
            this.RTCMatchString.Size = new System.Drawing.Size(91, 17);
            this.RTCMatchString.TabIndex = 0;
            this.RTCMatchString.Text = "Match string";
            this.RTCMatchString.UseVisualStyleBackColor = true;
            // 
            // ucRunProgramActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ucRunProgramActionDetail";
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
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox RTCRunMode;
        private System.Windows.Forms.Label label3;
        private ucProgramName ucProgramName1;
        private System.Windows.Forms.CheckBox RTCIsRunOneTime;
        private System.Windows.Forms.Button btnStopTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RTCInputString;
        private System.Windows.Forms.CheckBox RTCMatchString;
        private ucRangeMaxMin ucRangeMaxMin1;
    }
}
