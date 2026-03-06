
namespace RTC_Vision_Lite.UserControls
{
    partial class ucOrigin
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRef = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
            this.lblvalue = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblRef);
            this.groupBox3.Controls.Add(this.lblvalue);
            this.groupBox3.Controls.Add(this.btnRemoveLink);
            this.groupBox3.Controls.Add(this.btnLink);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(925, 98);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Origin";
            // 
            // lblRef
            // 
            this.lblRef.BackColor = System.Drawing.SystemColors.Control;
            this.lblRef.BaseStylesheet = "";
            this.lblRef.Location = new System.Drawing.Point(173, 64);
            this.lblRef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(74, 20);
            this.lblRef.TabIndex = 4;
            this.lblRef.Text = "htmlLabel1";
            // 
            // lblvalue
            // 
            this.lblvalue.BackColor = System.Drawing.SystemColors.Control;
            this.lblvalue.BaseStylesheet = "";
            this.lblvalue.Location = new System.Drawing.Point(173, 32);
            this.lblvalue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblvalue.Name = "lblvalue";
            this.lblvalue.Size = new System.Drawing.Size(74, 20);
            this.lblvalue.TabIndex = 3;
            this.lblvalue.Text = "htmlLabel1";
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Image = global::RTC_Vision_Lite.Properties.Resources.Delete_16x16;
            this.btnRemoveLink.Location = new System.Drawing.Point(117, 32);
            this.btnRemoveLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(48, 32);
            this.btnRemoveLink.TabIndex = 0;
            this.btnRemoveLink.UseVisualStyleBackColor = true;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(23, 32);
            this.btnLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(87, 32);
            this.btnLink.TabIndex = 0;
            this.btnLink.Text = "Link";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // ucOrigin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucOrigin";
            this.Size = new System.Drawing.Size(925, 98);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Button btnLink;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel lblvalue;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel lblRef;
    }
}
