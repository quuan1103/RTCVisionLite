namespace RTC_Vision_Lite.UserControls
{
    partial class ucObjectLink
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.lblRef = new System.Windows.Forms.Label();
            this.btnLink = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveLink);
            this.groupBox2.Controls.Add(this.lblRef);
            this.groupBox2.Controls.Add(this.btnLink);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 76);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object";
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Image = global::RTC_Vision_Lite.Properties.Resources.Delete_16x16;
            this.btnRemoveLink.Location = new System.Drawing.Point(88, 28);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(36, 26);
            this.btnRemoveLink.TabIndex = 0;
            this.btnRemoveLink.UseVisualStyleBackColor = true;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Location = new System.Drawing.Point(129, 35);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(44, 13);
            this.lblRef.TabIndex = 2;
            this.lblRef.Text = "Source:";
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(17, 28);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(65, 26);
            this.btnLink.TabIndex = 0;
            this.btnLink.Text = "Link";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // ucObjectLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "ucObjectLink";
            this.Size = new System.Drawing.Size(466, 76);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Button btnLink;
    }
}
