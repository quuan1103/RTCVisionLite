
namespace RTC_Vision_Lite.UserControls
{
    partial class ucReturnActionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReturnActionDetails));
            this.colIDRef = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageListValue = new System.Windows.Forms.ImageList(this.components);
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucToolName = new RTC_Vision_Lite.Commons.ucToolName();
            this.RTCNumberOfRun = new System.Windows.Forms.NumericUpDown();
            this.RTCIsUseNumberOfRun = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RTCReturnMode = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.RTCNumberOfRun)).BeginInit();
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
            this.ScrollableROI.Controls.Add(this.label6);
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
            // colIDRef
            // 
            this.colIDRef.AspectName = "IDRef";
            this.colIDRef.DisplayIndex = 9;
            this.colIDRef.IsVisible = false;
            this.colIDRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colIDRef.Width = 0;
            // 
            // imageListValue
            // 
            this.imageListValue.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListValue.ImageStream")));
            this.imageListValue.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListValue.Images.SetKeyName(0, "true");
            this.imageListValue.Images.SetKeyName(1, "false");
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(64, 20);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(634, 22);
            this.RTCName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 5;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Pass/Fail:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucToolName);
            this.groupBox1.Controls.Add(this.RTCNumberOfRun);
            this.groupBox1.Controls.Add(this.RTCIsUseNumberOfRun);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RTCReturnMode);
            this.groupBox1.Location = new System.Drawing.Point(20, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 145);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // ucToolName
            // 
            this.ucToolName.Location = new System.Drawing.Point(20, 57);
            this.ucToolName.Name = "ucToolName";
            this.ucToolName.RTCAction = null;
            this.ucToolName.RTCCaptionWidth = 100F;
            this.ucToolName.RTCIsUseCaption = true;
            this.ucToolName.RTCPropertyName = "ToolName";
            this.ucToolName.Size = new System.Drawing.Size(305, 31);
            this.ucToolName.TabIndex = 7;
            // 
            // RTCNumberOfRun
            // 
            this.RTCNumberOfRun.Location = new System.Drawing.Point(124, 94);
            this.RTCNumberOfRun.Name = "RTCNumberOfRun";
            this.RTCNumberOfRun.Size = new System.Drawing.Size(120, 22);
            this.RTCNumberOfRun.TabIndex = 6;
            this.RTCNumberOfRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RTCIsUseNumberOfRun
            // 
            this.RTCIsUseNumberOfRun.AutoSize = true;
            this.RTCIsUseNumberOfRun.Location = new System.Drawing.Point(20, 99);
            this.RTCIsUseNumberOfRun.Name = "RTCIsUseNumberOfRun";
            this.RTCIsUseNumberOfRun.Size = new System.Drawing.Size(102, 17);
            this.RTCIsUseNumberOfRun.TabIndex = 5;
            this.RTCIsUseNumberOfRun.Text = "Number of run";
            this.RTCIsUseNumberOfRun.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Return Mode";
            // 
            // RTCReturnMode
            // 
            this.RTCReturnMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCReturnMode.FormattingEnabled = true;
            this.RTCReturnMode.Location = new System.Drawing.Point(124, 30);
            this.RTCReturnMode.Name = "RTCReturnMode";
            this.RTCReturnMode.Size = new System.Drawing.Size(198, 21);
            this.RTCReturnMode.TabIndex = 3;
            // 
            // ucReturnActionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucReturnActionDetails";
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
            ((System.ComponentModel.ISupportInitialize)(this.RTCNumberOfRun)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.OLVColumn colIDRef;
        private System.Windows.Forms.ImageList imageListValue;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown RTCNumberOfRun;
        private System.Windows.Forms.CheckBox RTCIsUseNumberOfRun;
        private System.Windows.Forms.ComboBox RTCReturnMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private Commons.ucToolName ucToolName;
    }
}
