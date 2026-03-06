
namespace RTC_Vision_Lite.UserControls
{
    partial class ucLoadImageActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoadImageActionDetail));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCIsBringImageToMain = new System.Windows.Forms.CheckBox();
            this.RTCIsKeepImage = new System.Windows.Forms.CheckBox();
            this.RTCIsRunOneTime = new System.Windows.Forms.CheckBox();
            this.btnGetFileName = new System.Windows.Forms.Button();
            this.RTCFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.RTCErrMessage = new System.Windows.Forms.Label();
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
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label7);
            this.ScrollableGeneral.Location = new System.Drawing.Point(5, 5);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1149, 501);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(5, 51);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PageSetup.Size = new System.Drawing.Size(1182, 519);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ROI.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ROI.Size = new System.Drawing.Size(1159, 511);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PassFail.Size = new System.Drawing.Size(1556, 644);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1556, 644);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCErrMessage);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Location = new System.Drawing.Point(5, 5);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableROI.Size = new System.Drawing.Size(1149, 501);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(1182, 46);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.General.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.General.Size = new System.Drawing.Size(1159, 511);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Method.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Method.Size = new System.Drawing.Size(1556, 644);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Display.Size = new System.Drawing.Size(1556, 644);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(5, 5);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableMethod.Size = new System.Drawing.Size(1546, 634);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Location = new System.Drawing.Point(5, 5);
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(1546, 634);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCIsBringImageToMain);
            this.groupBox1.Controls.Add(this.RTCIsKeepImage);
            this.groupBox1.Controls.Add(this.RTCIsRunOneTime);
            this.groupBox1.Controls.Add(this.btnGetFileName);
            this.groupBox1.Controls.Add(this.RTCFileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(908, 113);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Setting";
            // 
            // RTCIsBringImageToMain
            // 
            this.RTCIsBringImageToMain.AutoSize = true;
            this.RTCIsBringImageToMain.Location = new System.Drawing.Point(437, 75);
            this.RTCIsBringImageToMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCIsBringImageToMain.Name = "RTCIsBringImageToMain";
            this.RTCIsBringImageToMain.Size = new System.Drawing.Size(155, 17);
            this.RTCIsBringImageToMain.TabIndex = 15;
            this.RTCIsBringImageToMain.Text = "BringImageToMainAction";
            this.RTCIsBringImageToMain.UseVisualStyleBackColor = true;
            // 
            // RTCIsKeepImage
            // 
            this.RTCIsKeepImage.AutoSize = true;
            this.RTCIsKeepImage.Location = new System.Drawing.Point(268, 75);
            this.RTCIsKeepImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCIsKeepImage.Name = "RTCIsKeepImage";
            this.RTCIsKeepImage.Size = new System.Drawing.Size(82, 17);
            this.RTCIsKeepImage.TabIndex = 14;
            this.RTCIsKeepImage.Text = "KeepImage";
            this.RTCIsKeepImage.UseVisualStyleBackColor = true;
            // 
            // RTCIsRunOneTime
            // 
            this.RTCIsRunOneTime.AutoSize = true;
            this.RTCIsRunOneTime.Location = new System.Drawing.Point(97, 75);
            this.RTCIsRunOneTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnGetFileName.Location = new System.Drawing.Point(832, 32);
            this.btnGetFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetFileName.Name = "btnGetFileName";
            this.btnGetFileName.Size = new System.Drawing.Size(39, 28);
            this.btnGetFileName.TabIndex = 12;
            this.btnGetFileName.UseVisualStyleBackColor = false;
            this.btnGetFileName.Click += new System.EventHandler(this.btnGetFileName_Click);
            // 
            // RTCFileName
            // 
            this.RTCFileName.Location = new System.Drawing.Point(97, 32);
            this.RTCFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCFileName.Name = "RTCFileName";
            this.RTCFileName.Size = new System.Drawing.Size(711, 22);
            this.RTCFileName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "File Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Pass/Fail:";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(109, 20);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 29;
            this.RTCPassed.Text = "Passed";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(77, 18);
            this.RTCName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(863, 22);
            this.RTCName.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Name";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(27, 174);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(68, 28);
            this.btnTest.TabIndex = 31;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.Red;
            this.RTCErrMessage.Location = new System.Drawing.Point(120, 180);
            this.RTCErrMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 32;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // ucLoadImageActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ucLoadImageActionDetail";
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RTCFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGetFileName;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox RTCIsBringImageToMain;
        private System.Windows.Forms.CheckBox RTCIsKeepImage;
        private System.Windows.Forms.CheckBox RTCIsRunOneTime;
    }
}
