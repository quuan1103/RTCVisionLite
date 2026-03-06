
namespace RTC_Vision_Lite.UserControls
{
    partial class ucFontInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfoName = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.cmsUcFontInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.popReset = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.cmsUcFontInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfoName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 25);
            this.panel1.TabIndex = 0;
            // 
            // lblInfoName
            // 
            this.lblInfoName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoName.AutoSize = true;
            this.lblInfoName.Location = new System.Drawing.Point(1, 6);
            this.lblInfoName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfoName.Name = "lblInfoName";
            this.lblInfoName.Size = new System.Drawing.Size(56, 13);
            this.lblInfoName.TabIndex = 0;
            this.lblInfoName.Text = "Info Name";
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtValue.Location = new System.Drawing.Point(76, 0);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(223, 25);
            this.txtValue.TabIndex = 1;
            this.txtValue.UseVisualStyleBackColor = true;
            this.txtValue.Click += new System.EventHandler(this.txtValue_Click);
            // 
            // cmsUcFontInfo
            // 
            this.cmsUcFontInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsUcFontInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popReset});
            this.cmsUcFontInfo.Name = "cmsUcFontInfo";
            this.cmsUcFontInfo.Size = new System.Drawing.Size(103, 26);
            // 
            // popReset
            // 
            this.popReset.Name = "popReset";
            this.popReset.Size = new System.Drawing.Size(102, 22);
            this.popReset.Text = "Reset";
            this.popReset.Click += new System.EventHandler(this.popReset_Click);
            // 
            // ucFontInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucFontInfo";
            this.Size = new System.Drawing.Size(299, 25);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsUcFontInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfoName;
        private System.Windows.Forms.Button txtValue;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ContextMenuStrip cmsUcFontInfo;
        private System.Windows.Forms.ToolStripMenuItem popReset;
    }
}
