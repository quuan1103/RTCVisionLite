namespace RTC_Vision_Lite._3._UserControls.Tools
{
    partial class ucLoadObjectActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoadObjectActionDetail));
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RTCErrMessage = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCIsRunOneTime = new System.Windows.Forms.CheckBox();
            this.btnGetFileName = new System.Windows.Forms.Button();
            this.RTCFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.ucOrigin = new RTC_Vision_Lite.UserControls.ucOrigin();
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
            this.ScrollableGeneral.Controls.Add(this.label7);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.ucOrigin);
            this.ScrollableROI.Controls.Add(this.RTCErrMessage);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
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
            this.RTCName.Location = new System.Drawing.Point(50, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(639, 22);
            this.RTCName.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Name";
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.Red;
            this.RTCErrMessage.Location = new System.Drawing.Point(91, 232);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 37;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(21, 227);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(51, 23);
            this.btnTest.TabIndex = 36;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCIsRunOneTime);
            this.groupBox1.Controls.Add(this.btnGetFileName);
            this.groupBox1.Controls.Add(this.RTCFileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 92);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Setting";
            // 
            // RTCIsRunOneTime
            // 
            this.RTCIsRunOneTime.AutoSize = true;
            this.RTCIsRunOneTime.Location = new System.Drawing.Point(73, 61);
            this.RTCIsRunOneTime.Name = "RTCIsRunOneTime";
            this.RTCIsRunOneTime.Size = new System.Drawing.Size(98, 17);
            this.RTCIsRunOneTime.TabIndex = 13;
            this.RTCIsRunOneTime.Text = "Run One Time";
            this.RTCIsRunOneTime.UseVisualStyleBackColor = true;
            // 
            // btnGetFileName
            // 
            this.btnGetFileName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetFileName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetFileName.Image = global::RTC_Vision_Lite.Properties.Resources.LoadFrom_16x16;
            this.btnGetFileName.Location = new System.Drawing.Point(624, 26);
            this.btnGetFileName.Name = "btnGetFileName";
            this.btnGetFileName.Size = new System.Drawing.Size(29, 23);
            this.btnGetFileName.TabIndex = 12;
            this.btnGetFileName.UseVisualStyleBackColor = false;
            // 
            // RTCFileName
            // 
            this.RTCFileName.Location = new System.Drawing.Point(73, 26);
            this.RTCFileName.Name = "RTCFileName";
            this.RTCFileName.Size = new System.Drawing.Size(534, 22);
            this.RTCFileName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "File Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Pass/Fail:";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(83, 15);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 34;
            this.RTCPassed.Text = "Passed";
            // 
            // ucOrigin
            // 
            this.ucOrigin.Action = null;
            this.ucOrigin.Location = new System.Drawing.Point(20, 33);
            this.ucOrigin.Name = "ucOrigin";
            this.ucOrigin.PropertyName = "ToolOrigin";
            this.ucOrigin.Size = new System.Drawing.Size(769, 86);
            this.ucOrigin.TabIndex = 38;
            // 
            // ucLoadObjectActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucLoadObjectActionDetail";
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

        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox RTCIsRunOneTime;
        private System.Windows.Forms.Button btnGetFileName;
        private System.Windows.Forms.TextBox RTCFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label RTCPassed;
        private UserControls.ucOrigin ucOrigin;
    }
}
