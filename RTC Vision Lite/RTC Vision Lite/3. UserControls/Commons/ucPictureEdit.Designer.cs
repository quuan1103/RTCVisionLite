namespace RTC_Vision_Lite.Commons
{
    partial class ucPictureEdit
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
            this.lblImageName = new System.Windows.Forms.TextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnGetImage = new System.Windows.Forms.Button();
            this.btnViewImage = new System.Windows.Forms.Button();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblImageName
            // 
            this.lblImageName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblImageName.Location = new System.Drawing.Point(0, 84);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(120, 20);
            this.lblImageName.TabIndex = 0;
            this.lblImageName.Text = "Image Name";
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Image = global::RTC_Vision_Lite.Properties.Resources.NoImage;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(120, 84);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // btnGetImage
            // 
            this.btnGetImage.FlatAppearance.BorderSize = 0;
            this.btnGetImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetImage.Image = global::RTC_Vision_Lite.Properties.Resources.Open2_16x16;
            this.btnGetImage.Location = new System.Drawing.Point(74, 0);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(23, 20);
            this.btnGetImage.TabIndex = 2;
            this.btnGetImage.UseVisualStyleBackColor = true;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // btnViewImage
            // 
            this.btnViewImage.FlatAppearance.BorderSize = 0;
            this.btnViewImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewImage.Image = global::RTC_Vision_Lite.Properties.Resources.Show_16x16;
            this.btnViewImage.Location = new System.Drawing.Point(97, 0);
            this.btnViewImage.Name = "btnViewImage";
            this.btnViewImage.Size = new System.Drawing.Size(23, 20);
            this.btnViewImage.TabIndex = 3;
            this.btnViewImage.UseVisualStyleBackColor = true;
            this.btnViewImage.Click += new System.EventHandler(this.btnViewImage_Click);
            // 
            // lblSelect
            // 
            this.lblSelect.BackColor = System.Drawing.Color.Lime;
            this.lblSelect.Location = new System.Drawing.Point(3, 64);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(23, 18);
            this.lblSelect.TabIndex = 4;
            this.lblSelect.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Teal;
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(3, 4);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(42, 13);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Passed";
            this.lblResult.Visible = false;
            // 
            // ucPictureEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.btnViewImage);
            this.Controls.Add(this.btnGetImage);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lblImageName);
            this.Name = "ucPictureEdit";
            this.Size = new System.Drawing.Size(120, 104);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblImageName;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnGetImage;
        private System.Windows.Forms.Button btnViewImage;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblResult;
    }
}
