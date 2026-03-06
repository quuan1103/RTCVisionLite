namespace RTC_Vision_Lite.UserControls
{
    partial class ucCounterActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCounterActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetCount = new System.Windows.Forms.Button();
            this.btnRunCount = new System.Windows.Forms.Button();
            this.RTCFailNumber = new System.Windows.Forms.TextBox();
            this.RTCResetNumber = new System.Windows.Forms.TextBox();
            this.RTCNumberBeginRestart = new System.Windows.Forms.TextBox();
            this.RTCStep = new System.Windows.Forms.TextBox();
            this.RTCStartNumber = new System.Windows.Forms.TextBox();
            this.RTCKeepValueToNextSession = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label2);
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
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Location = new System.Drawing.Point(62, 12);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(636, 22);
            this.RTCName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pass/Fail: ";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 0;
            this.RTCPassed.Text = "Passed";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetCount);
            this.groupBox1.Controls.Add(this.btnRunCount);
            this.groupBox1.Controls.Add(this.RTCFailNumber);
            this.groupBox1.Controls.Add(this.RTCResetNumber);
            this.groupBox1.Controls.Add(this.RTCNumberBeginRestart);
            this.groupBox1.Controls.Add(this.RTCStep);
            this.groupBox1.Controls.Add(this.RTCStartNumber);
            this.groupBox1.Controls.Add(this.RTCKeepValueToNextSession);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 212);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnResetCount
            // 
            this.btnResetCount.Location = new System.Drawing.Point(413, 24);
            this.btnResetCount.Name = "btnResetCount";
            this.btnResetCount.Size = new System.Drawing.Size(55, 23);
            this.btnResetCount.TabIndex = 3;
            this.btnResetCount.Text = "Reset";
            this.btnResetCount.UseVisualStyleBackColor = true;
            this.btnResetCount.Click += new System.EventHandler(this.btnResetCount_Click);
            // 
            // btnRunCount
            // 
            this.btnRunCount.Location = new System.Drawing.Point(352, 24);
            this.btnRunCount.Name = "btnRunCount";
            this.btnRunCount.Size = new System.Drawing.Size(55, 23);
            this.btnRunCount.TabIndex = 3;
            this.btnRunCount.Text = "Run";
            this.btnRunCount.UseVisualStyleBackColor = true;
            this.btnRunCount.Click += new System.EventHandler(this.btnRunCount_Click);
            // 
            // RTCFailNumber
            // 
            this.RTCFailNumber.Location = new System.Drawing.Point(199, 138);
            this.RTCFailNumber.Name = "RTCFailNumber";
            this.RTCFailNumber.Size = new System.Drawing.Size(147, 22);
            this.RTCFailNumber.TabIndex = 2;
            // 
            // RTCResetNumber
            // 
            this.RTCResetNumber.Location = new System.Drawing.Point(199, 108);
            this.RTCResetNumber.Name = "RTCResetNumber";
            this.RTCResetNumber.Size = new System.Drawing.Size(147, 22);
            this.RTCResetNumber.TabIndex = 2;
            // 
            // RTCNumberBeginRestart
            // 
            this.RTCNumberBeginRestart.Location = new System.Drawing.Point(199, 80);
            this.RTCNumberBeginRestart.Name = "RTCNumberBeginRestart";
            this.RTCNumberBeginRestart.Size = new System.Drawing.Size(147, 22);
            this.RTCNumberBeginRestart.TabIndex = 2;
            // 
            // RTCStep
            // 
            this.RTCStep.Location = new System.Drawing.Point(199, 52);
            this.RTCStep.Name = "RTCStep";
            this.RTCStep.Size = new System.Drawing.Size(147, 22);
            this.RTCStep.TabIndex = 2;
            // 
            // RTCStartNumber
            // 
            this.RTCStartNumber.Location = new System.Drawing.Point(199, 24);
            this.RTCStartNumber.Name = "RTCStartNumber";
            this.RTCStartNumber.Size = new System.Drawing.Size(147, 22);
            this.RTCStartNumber.TabIndex = 2;
            // 
            // RTCKeepValueToNextSession
            // 
            this.RTCKeepValueToNextSession.AutoSize = true;
            this.RTCKeepValueToNextSession.Location = new System.Drawing.Point(19, 177);
            this.RTCKeepValueToNextSession.Name = "RTCKeepValueToNextSession";
            this.RTCKeepValueToNextSession.Size = new System.Drawing.Size(164, 17);
            this.RTCKeepValueToNextSession.TabIndex = 1;
            this.RTCKeepValueToNextSession.Text = "Keep Value To Next Session";
            this.RTCKeepValueToNextSession.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fail when count is ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Reset count to";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Reset when the count is ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Increment count by";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Set count to";
            // 
            // ucCounterActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucCounterActionDetail";
            this.PageActionSettingTabIndex = 1;
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
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResetCount;
        private System.Windows.Forms.Button btnRunCount;
        private System.Windows.Forms.TextBox RTCFailNumber;
        private System.Windows.Forms.TextBox RTCResetNumber;
        private System.Windows.Forms.TextBox RTCNumberBeginRestart;
        private System.Windows.Forms.TextBox RTCStep;
        private System.Windows.Forms.TextBox RTCStartNumber;
        private System.Windows.Forms.CheckBox RTCKeepValueToNextSession;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
