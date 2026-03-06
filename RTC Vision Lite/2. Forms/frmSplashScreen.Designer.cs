namespace RTC_Vision_Lite.Forms
{
    partial class frmSplashScreen
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
            this.peImage = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCopyRight = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.peLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.peImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // peImage
            // 
            this.peImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.peImage.Image = global::RTC_Vision_Lite.Properties.Resources.Splash1;
            this.peImage.Location = new System.Drawing.Point(0, 0);
            this.peImage.Name = "peImage";
            this.peImage.Size = new System.Drawing.Size(553, 212);
            this.peImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.peImage.TabIndex = 0;
            this.peImage.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(24, 215);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Starting...";
            // 
            // lblCopyRight
            // 
            this.lblCopyRight.AutoSize = true;
            this.lblCopyRight.Location = new System.Drawing.Point(24, 287);
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.Size = new System.Drawing.Size(51, 13);
            this.lblCopyRight.TabIndex = 2;
            this.lblCopyRight.Text = "Copyright";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 231);
            this.progressBar1.MarqueeAnimationSpeed = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(501, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 50;
            // 
            // peLogo
            // 
            this.peLogo.Image = global::RTC_Vision_Lite.Properties.Resources.RTCLogo;
            this.peLogo.Location = new System.Drawing.Point(410, 258);
            this.peLogo.Name = "peLogo";
            this.peLogo.Size = new System.Drawing.Size(115, 50);
            this.peLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.peLogo.TabIndex = 4;
            this.peLogo.TabStop = false;
            // 
            // frmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 320);
            this.ControlBox = false;
            this.Controls.Add(this.peLogo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblCopyRight);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.peImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.peImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox peImage;
        private System.Windows.Forms.Label lblCopyRight;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox peLogo;
        public System.Windows.Forms.Label lblStatus;
    }
}