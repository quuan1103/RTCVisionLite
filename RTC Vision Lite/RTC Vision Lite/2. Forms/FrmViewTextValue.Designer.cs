namespace RTC_Vision_Lite.Forms
{
    partial class FrmViewTextValue
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewTextValue));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSimpleText = new System.Windows.Forms.CheckBox();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.meValue = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new RTC_Vision_Lite.Commons.MyLabel(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.chkSimpleText);
            this.panel1.Controls.Add(this.btnCopyToClipboard);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 33);
            this.panel1.TabIndex = 0;
            // 
            // chkSimpleText
            // 
            this.chkSimpleText.AutoSize = true;
            this.chkSimpleText.Location = new System.Drawing.Point(84, 9);
            this.chkSimpleText.Name = "chkSimpleText";
            this.chkSimpleText.Size = new System.Drawing.Size(81, 17);
            this.chkSimpleText.TabIndex = 1;
            this.chkSimpleText.Text = "Simple Text";
            this.chkSimpleText.UseVisualStyleBackColor = true;
            this.chkSimpleText.CheckedChanged += new System.EventHandler(this.chkSimpleText_CheckedChanged);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(217, 5);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(136, 23);
            this.btnCopyToClipboard.TabIndex = 0;
            this.btnCopyToClipboard.Text = "&Copy To Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "&Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Help";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // meValue
            // 
            this.meValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meValue.Location = new System.Drawing.Point(0, 0);
            this.meValue.Name = "meValue";
            this.meValue.ReadOnly = true;
            this.meValue.Size = new System.Drawing.Size(437, 228);
            this.meValue.TabIndex = 1;
            this.meValue.Text = "";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(171, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RTCBorderBottomColor = System.Drawing.Color.White;
            this.lblStatus.RTCBorderBottomDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblStatus.RTCBorderBottomPadding = 1;
            this.lblStatus.RTCBorderBottomVisible = false;
            this.lblStatus.RTCBorderLeftColor = System.Drawing.Color.White;
            this.lblStatus.RTCBorderLeftDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblStatus.RTCBorderLeftPadding = 1;
            this.lblStatus.RTCBorderLeftVisible = false;
            this.lblStatus.RTCBorderRightColor = System.Drawing.Color.White;
            this.lblStatus.RTCBorderRightDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblStatus.RTCBorderRightPadding = 1;
            this.lblStatus.RTCBorderRightVisible = false;
            this.lblStatus.RTCBorderTopColor = System.Drawing.Color.White;
            this.lblStatus.RTCBorderTopDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblStatus.RTCBorderTopPadding = 1;
            this.lblStatus.RTCBorderTopVisible = false;
            this.lblStatus.RTCFadeOutSpeed = 5;
            this.lblStatus.RTCInterval = 100;
            this.lblStatus.RTCUseCustomBorder = false;
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Copied";
            this.lblStatus.Visible = false;
            // 
            // FrmViewTextValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 261);
            this.Controls.Add(this.meValue);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmViewTextValue";
            this.Text = "View Value";
            this.Load += new System.EventHandler(this.FrmViewTextValue_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSimpleText;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox meValue;
        private Commons.MyLabel lblStatus;
    }
}