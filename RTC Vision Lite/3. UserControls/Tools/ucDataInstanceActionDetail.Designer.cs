
namespace RTC_Vision_Lite.UserControls
{
    partial class ucDataIntanceActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDataIntanceActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.label11);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1155, 503);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(3, 48);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(5);
            this.PageSetup.Size = new System.Drawing.Size(1186, 519);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ROI.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ROI.Size = new System.Drawing.Size(1163, 511);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PassFail.Size = new System.Drawing.Size(1163, 511);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1163, 511);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Location = new System.Drawing.Point(3, 2);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableROI.Size = new System.Drawing.Size(1157, 507);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
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
            this.Method.Size = new System.Drawing.Size(1163, 511);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Display.Size = new System.Drawing.Size(1163, 511);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(3, 2);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableMethod.Size = new System.Drawing.Size(1157, 507);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(5);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(1155, 503);
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
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(77, 18);
            this.RTCName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(860, 26);
            this.RTCName.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(73, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(313, 19);
            this.label11.TabIndex = 2;
            this.label11.Text = "Please go to the Properties tab to setup this tool";
            // 
            // ucDataIntanceActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucDataIntanceActionDetail";
            this.PageActionSettingTabIndex = 1;
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label11;
    }
}
