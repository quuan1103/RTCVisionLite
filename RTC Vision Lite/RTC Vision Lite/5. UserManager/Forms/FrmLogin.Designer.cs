namespace RTC_Vision_Lite.Forms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.labelControl1 = new System.Windows.Forms.Label();
            this.labelControl2 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblPasswordMatch = new System.Windows.Forms.Label();
            this.labelControl8 = new System.Windows.Forms.Label();
            this.panFormResultButton = new System.Windows.Forms.Panel();
            this.simpleButton1 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkKeepLogin = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.labelControl3 = new System.Windows.Forms.Label();
            this.labelControl4 = new System.Windows.Forms.Label();
            this.lblShowHide = new System.Windows.Forms.Label();
            this.panFormResultButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Image = global::RTC_Vision_Lite.Properties.Resources.BO_Security_Permission;
            this.labelControl1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.Location = new System.Drawing.Point(29, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(380, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "INPUT YOUR USERNAME AND  PASSWORD";
            this.labelControl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelControl2
            // 
            this.labelControl2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(29, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(172, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Your User Name";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassWord.Location = new System.Drawing.Point(29, 119);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(396, 20);
            this.txtPassWord.TabIndex = 5;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // lblPasswordMatch
            // 
            this.lblPasswordMatch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPasswordMatch.ForeColor = System.Drawing.Color.Green;
            this.lblPasswordMatch.Location = new System.Drawing.Point(335, 170);
            this.lblPasswordMatch.Name = "lblPasswordMatch";
            this.lblPasswordMatch.Size = new System.Drawing.Size(0, 13);
            this.lblPasswordMatch.TabIndex = 14;
            // 
            // labelControl8
            // 
            this.labelControl8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl8.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl8.Location = new System.Drawing.Point(29, 141);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(181, 13);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Enter your password to accept process.";
            // 
            // panFormResultButton
            // 
            this.panFormResultButton.Controls.Add(this.simpleButton1);
            this.panFormResultButton.Controls.Add(this.btnOK);
            this.panFormResultButton.Controls.Add(this.btnCancel);
            this.panFormResultButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panFormResultButton.Location = new System.Drawing.Point(0, 198);
            this.panFormResultButton.Name = "panFormResultButton";
            this.panFormResultButton.Size = new System.Drawing.Size(451, 40);
            this.panFormResultButton.TabIndex = 8;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.Location = new System.Drawing.Point(3, 14);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "&Help";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::RTC_Vision_Lite.Properties.Resources.Apply_16x16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(295, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::RTC_Vision_Lite.Properties.Resources.Cancel_16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(373, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkKeepLogin
            // 
            this.chkKeepLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKeepLogin.Location = new System.Drawing.Point(29, 163);
            this.chkKeepLogin.Name = "chkKeepLogin";
            this.chkKeepLogin.Size = new System.Drawing.Size(396, 20);
            this.chkKeepLogin.TabIndex = 7;
            this.chkKeepLogin.Text = "Keep me logged in 1 session.";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(29, 58);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(396, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl3.Location = new System.Drawing.Point(29, 80);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(185, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Enter your user name to accept process.";
            // 
            // labelControl4
            // 
            this.labelControl4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(29, 99);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(136, 17);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Your Password";
            // 
            // lblShowHide
            // 
            this.lblShowHide.AutoSize = true;
            this.lblShowHide.BackColor = System.Drawing.SystemColors.Window;
            this.lblShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShowHide.ForeColor = System.Drawing.Color.Green;
            this.lblShowHide.Location = new System.Drawing.Point(387, 122);
            this.lblShowHide.Name = "lblShowHide";
            this.lblShowHide.Size = new System.Drawing.Size(34, 13);
            this.lblShowHide.TabIndex = 15;
            this.lblShowHide.Text = "Show";
            this.lblShowHide.Click += new System.EventHandler(this.lblShowHide_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(451, 238);
            this.Controls.Add(this.lblShowHide);
            this.Controls.Add(this.chkKeepLogin);
            this.Controls.Add(this.panFormResultButton);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.lblPasswordMatch);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panFormResultButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelControl1;
        private System.Windows.Forms.Label labelControl2;
        private System.Windows.Forms.Label lblPasswordMatch;
        private System.Windows.Forms.Label labelControl8;
        private System.Windows.Forms.Panel panFormResultButton;
        private System.Windows.Forms.Button simpleButton1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtPassWord;
        public System.Windows.Forms.CheckBox chkKeepLogin;
        public System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label labelControl3;
        private System.Windows.Forms.Label labelControl4;
        private System.Windows.Forms.Label lblShowHide;
    }
}