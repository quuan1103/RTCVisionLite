
namespace RTC_Vision_Lite.UserControls
{
    partial class ucDataSetActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDataSetActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpValue = new System.Windows.Forms.TabPage();
            this.ucMultiLink1 = new RTC_Vision_Lite.UserControls.ucMultiLink();
            this.tpImageArray = new System.Windows.Forms.TabPage();
            this.ucMultiLink2 = new RTC_Vision_Lite.UserControls.ucMultiLink();
            this.tpBlobList = new System.Windows.Forms.TabPage();
            this.ucMultiLink3 = new RTC_Vision_Lite.UserControls.ucMultiLink();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpValue.SuspendLayout();
            this.tpImageArray.SuspendLayout();
            this.tpBlobList.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.tabControl1);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(5, 5);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1153, 507);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(3, 48);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PageSetup.Size = new System.Drawing.Size(1186, 525);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ROI.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ROI.Size = new System.Drawing.Size(1561, 649);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PassFail.Size = new System.Drawing.Size(1561, 649);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1561, 649);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Location = new System.Drawing.Point(3, 2);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableROI.Size = new System.Drawing.Size(1555, 645);
            this.ScrollableROI.Paint += new System.Windows.Forms.PaintEventHandler(this.ScrollableROI_Paint);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.Method.Size = new System.Drawing.Size(1561, 649);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Display.Size = new System.Drawing.Size(1561, 649);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(3, 2);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableMethod.Size = new System.Drawing.Size(1555, 645);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Location = new System.Drawing.Point(5, 5);
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(1551, 639);
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
            this.imlLinkSummary.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlLinkSummary.ImageSize = new System.Drawing.Size(50, 16);
            this.imlLinkSummary.ImageStream = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(77, 20);
            this.RTCName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(1034, 22);
            this.RTCName.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpValue);
            this.tabControl1.Controls.Add(this.tpImageArray);
            this.tabControl1.Controls.Add(this.tpBlobList);
            this.tabControl1.Location = new System.Drawing.Point(21, 62);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1090, 431);
            this.tabControl1.TabIndex = 2;
            // 
            // tpValue
            // 
            this.tpValue.Controls.Add(this.ucMultiLink1);
            this.tpValue.Location = new System.Drawing.Point(4, 22);
            this.tpValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpValue.Name = "tpValue";
            this.tpValue.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpValue.Size = new System.Drawing.Size(1082, 405);
            this.tpValue.TabIndex = 0;
            this.tpValue.Text = "Value";
            this.tpValue.UseVisualStyleBackColor = true;
            // 
            // ucMultiLink1
            // 
            this.ucMultiLink1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMultiLink1.Location = new System.Drawing.Point(4, 4);
            this.ucMultiLink1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucMultiLink1.Name = "ucMultiLink1";
            this.ucMultiLink1.PropertyName = "Value";
            this.ucMultiLink1.RTCAction = null;
            this.ucMultiLink1.Size = new System.Drawing.Size(1074, 397);
            this.ucMultiLink1.TabIndex = 0;
            // 
            // tpImageArray
            // 
            this.tpImageArray.Controls.Add(this.ucMultiLink2);
            this.tpImageArray.Location = new System.Drawing.Point(4, 22);
            this.tpImageArray.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpImageArray.Name = "tpImageArray";
            this.tpImageArray.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpImageArray.Size = new System.Drawing.Size(1472, 405);
            this.tpImageArray.TabIndex = 1;
            this.tpImageArray.Text = "Image Array";
            this.tpImageArray.UseVisualStyleBackColor = true;
            // 
            // ucMultiLink2
            // 
            this.ucMultiLink2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMultiLink2.Location = new System.Drawing.Point(4, 4);
            this.ucMultiLink2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucMultiLink2.Name = "ucMultiLink2";
            this.ucMultiLink2.PropertyName = "ImageArray";
            this.ucMultiLink2.RTCAction = null;
            this.ucMultiLink2.Size = new System.Drawing.Size(1464, 397);
            this.ucMultiLink2.TabIndex = 1;
            // 
            // tpBlobList
            // 
            this.tpBlobList.Controls.Add(this.ucMultiLink3);
            this.tpBlobList.Location = new System.Drawing.Point(4, 22);
            this.tpBlobList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpBlobList.Name = "tpBlobList";
            this.tpBlobList.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpBlobList.Size = new System.Drawing.Size(1472, 405);
            this.tpBlobList.TabIndex = 2;
            this.tpBlobList.Text = "Blob List";
            this.tpBlobList.UseVisualStyleBackColor = true;
            // 
            // ucMultiLink3
            // 
            this.ucMultiLink3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMultiLink3.Location = new System.Drawing.Point(4, 4);
            this.ucMultiLink3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucMultiLink3.Name = "ucMultiLink3";
            this.ucMultiLink3.PropertyName = "BlobList";
            this.ucMultiLink3.RTCAction = null;
            this.ucMultiLink3.Size = new System.Drawing.Size(1464, 397);
            this.ucMultiLink3.TabIndex = 2;
            // 
            // ucDataSetActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucDataSetActionDetail";
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpValue.ResumeLayout(false);
            this.tpImageArray.ResumeLayout(false);
            this.tpBlobList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpValue;
        private UserControls.ucMultiLink ucMultiLink1;
        private System.Windows.Forms.TabPage tpImageArray;
        private System.Windows.Forms.TabPage tpBlobList;
        private UserControls.ucMultiLink ucMultiLink2;
        private UserControls.ucMultiLink ucMultiLink3;
    }
}
