
namespace RTC_Vision_Lite.UserControls
{
    partial class ucLink
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
            this.tlpLink = new System.Windows.Forms.TableLayoutPanel();
            this.lblRef = new System.Windows.Forms.Label();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.btnGetFolder = new System.Windows.Forms.Button();
            this.tlpLink.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLink
            // 
            this.tlpLink.ColumnCount = 6;
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLink.Controls.Add(this.lblRef, 5, 0);
            this.tlpLink.Controls.Add(this.btnRemoveLink, 4, 0);
            this.tlpLink.Controls.Add(this.lblCaption, 0, 0);
            this.tlpLink.Controls.Add(this.txtValue, 1, 0);
            this.tlpLink.Controls.Add(this.btnLink, 2, 0);
            this.tlpLink.Controls.Add(this.btnGetFolder, 3, 0);
            this.tlpLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLink.Location = new System.Drawing.Point(0, 0);
            this.tlpLink.Name = "tlpLink";
            this.tlpLink.RowCount = 1;
            this.tlpLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLink.Size = new System.Drawing.Size(1068, 35);
            this.tlpLink.TabIndex = 0;
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRef.Location = new System.Drawing.Point(673, 0);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(392, 35);
            this.lblRef.TabIndex = 5;
            this.lblRef.Text = "Source:";
            this.lblRef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveLink.Image = global::RTC_Vision_Lite.Properties.Resources.Remove_16x16;
            this.btnRemoveLink.Location = new System.Drawing.Point(623, 0);
            this.btnRemoveLink.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(44, 35);
            this.btnRemoveLink.TabIndex = 4;
            this.btnRemoveLink.UseVisualStyleBackColor = true;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(3, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(114, 35);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Caption";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(123, 0);
            this.txtValue.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtValue.MaximumSize = new System.Drawing.Size(1000, 122);
            this.txtValue.MinimumSize = new System.Drawing.Size(40, 36);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(394, 36);
            this.txtValue.TabIndex = 1;
            // 
            // btnLink
            // 
            this.btnLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLink.Location = new System.Drawing.Point(523, 0);
            this.btnLink.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(44, 35);
            this.btnLink.TabIndex = 2;
            this.btnLink.Text = "Link";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnGetFolder
            // 
            this.btnGetFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetFolder.Image = global::RTC_Vision_Lite.Properties.Resources.LoadFrom_16x16;
            this.btnGetFolder.Location = new System.Drawing.Point(573, 0);
            this.btnGetFolder.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnGetFolder.Name = "btnGetFolder";
            this.btnGetFolder.Size = new System.Drawing.Size(44, 35);
            this.btnGetFolder.TabIndex = 3;
            this.btnGetFolder.UseVisualStyleBackColor = true;
            this.btnGetFolder.Click += new System.EventHandler(this.btnGetFolder_Click);
            // 
            // ucLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpLink);
            this.Name = "ucLink";
            this.Size = new System.Drawing.Size(1068, 35);
            this.tlpLink.ResumeLayout(false);
            this.tlpLink.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLink;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button btnGetFolder;
        public System.Windows.Forms.TextBox txtValue;
    }
}
