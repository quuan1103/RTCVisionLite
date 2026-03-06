
namespace RTC_Vision_Lite.UserControls
{
    partial class ucImageLink
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRef = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.myLabel1 = new RTC_Vision_Lite.Commons.MyLabel(this.components);
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRef);
            this.groupBox2.Controls.Add(this.btnRemoveLink);
            this.groupBox2.Controls.Add(this.btnLink);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(714, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // lblRef
            // 
            this.lblRef.BackColor = System.Drawing.SystemColors.Control;
            this.lblRef.BaseStylesheet = null;
            this.lblRef.Location = new System.Drawing.Point(173, 38);
            this.lblRef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(74, 20);
            this.lblRef.TabIndex = 3;
            this.lblRef.Text = "htmlLabel1";
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Image = global::RTC_Vision_Lite.Properties.Resources.Delete_16x16;
            this.btnRemoveLink.Location = new System.Drawing.Point(117, 36);
            this.btnRemoveLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(48, 32);
            this.btnRemoveLink.TabIndex = 0;
            this.btnRemoveLink.UseVisualStyleBackColor = true;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(23, 36);
            this.btnLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(87, 32);
            this.btnLink.TabIndex = 0;
            this.btnLink.Text = "Link";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.Location = new System.Drawing.Point(0, 0);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.RTCBorderBottomColor = System.Drawing.Color.White;
            this.myLabel1.RTCBorderBottomDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.myLabel1.RTCBorderBottomPadding = 1;
            this.myLabel1.RTCBorderBottomVisible = false;
            this.myLabel1.RTCBorderLeftColor = System.Drawing.Color.White;
            this.myLabel1.RTCBorderLeftDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.myLabel1.RTCBorderLeftPadding = 1;
            this.myLabel1.RTCBorderLeftVisible = false;
            this.myLabel1.RTCBorderRightColor = System.Drawing.Color.White;
            this.myLabel1.RTCBorderRightDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.myLabel1.RTCBorderRightPadding = 1;
            this.myLabel1.RTCBorderRightVisible = false;
            this.myLabel1.RTCBorderTopColor = System.Drawing.Color.White;
            this.myLabel1.RTCBorderTopDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.myLabel1.RTCBorderTopPadding = 1;
            this.myLabel1.RTCBorderTopVisible = false;
            this.myLabel1.RTCFadeOutSpeed = 5;
            this.myLabel1.RTCInterval = 100;
            this.myLabel1.RTCUseCustomBorder = false;
            this.myLabel1.Size = new System.Drawing.Size(100, 23);
            this.myLabel1.TabIndex = 0;
            this.myLabel1.Text = "myLabel1";
            // 
            // ucImageLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucImageLink";
            this.Size = new System.Drawing.Size(714, 123);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Button btnLink;
        private Commons.MyLabel myLabel1;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel lblRef;
    }
}
