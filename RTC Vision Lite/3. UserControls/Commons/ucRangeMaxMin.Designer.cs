
namespace RTC_Vision_Lite.UserControls
{
    partial class ucRangeMaxMin
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
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.lblMinTop = new System.Windows.Forms.Label();
            this.txtRangeMin = new System.Windows.Forms.MaskedTextBox();
            this.lblMaxTop = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.txtActual = new System.Windows.Forms.Label();
            this.txtRangeMax = new System.Windows.Forms.MaskedTextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.AutoSize = true;
            this.LayoutPanel.ColumnCount = 8;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutPanel.Controls.Add(this.lblFeatures, 0, 0);
            this.LayoutPanel.Controls.Add(this.chkEnable, 0, 1);
            this.LayoutPanel.Controls.Add(this.lblMinTop, 3, 0);
            this.LayoutPanel.Controls.Add(this.txtRangeMin, 3, 1);
            this.LayoutPanel.Controls.Add(this.lblMaxTop, 6, 0);
            this.LayoutPanel.Controls.Add(this.lblActual, 7, 0);
            this.LayoutPanel.Controls.Add(this.txtActual, 7, 1);
            this.LayoutPanel.Controls.Add(this.txtRangeMax, 6, 1);
            this.LayoutPanel.Controls.Add(this.lblMin, 2, 1);
            this.LayoutPanel.Controls.Add(this.lblMax, 5, 1);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 2;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.LayoutPanel.Size = new System.Drawing.Size(388, 42);
            this.LayoutPanel.TabIndex = 0;
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeatures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblFeatures.Location = new System.Drawing.Point(3, 2);
            this.lblFeatures.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(106, 17);
            this.lblFeatures.TabIndex = 20;
            this.lblFeatures.Text = "Features";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnable.Location = new System.Drawing.Point(3, 24);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(106, 15);
            this.chkEnable.TabIndex = 1;
            this.chkEnable.Text = "PropertyEnable";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.RTCEnable_CheckedChanged);
            // 
            // lblMinTop
            // 
            this.lblMinTop.AutoSize = true;
            this.lblMinTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinTop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblMinTop.Location = new System.Drawing.Point(173, 0);
            this.lblMinTop.Name = "lblMinTop";
            this.lblMinTop.Size = new System.Drawing.Size(50, 21);
            this.lblMinTop.TabIndex = 2;
            this.lblMinTop.Text = "Min";
            this.lblMinTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRangeMin
            // 
            this.txtRangeMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRangeMin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRangeMin.Location = new System.Drawing.Point(173, 24);
            this.txtRangeMin.Name = "txtRangeMin";
            this.txtRangeMin.Size = new System.Drawing.Size(50, 23);
            this.txtRangeMin.TabIndex = 5;
            this.txtRangeMin.Text = "0";
            this.txtRangeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRangeMin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTCRangeMin_KeyDown);
            this.txtRangeMin.Validating += new System.ComponentModel.CancelEventHandler(this.RTCRangeMin_Validating);
            // 
            // lblMaxTop
            // 
            this.lblMaxTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxTop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxTop.Location = new System.Drawing.Point(287, 0);
            this.lblMaxTop.Name = "lblMaxTop";
            this.lblMaxTop.Size = new System.Drawing.Size(50, 21);
            this.lblMaxTop.TabIndex = 8;
            this.lblMaxTop.Text = "Max";
            this.lblMaxTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActual.Location = new System.Drawing.Point(343, 0);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(42, 21);
            this.lblActual.TabIndex = 9;
            this.lblActual.Text = "Actual";
            this.lblActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtActual
            // 
            this.txtActual.AutoSize = true;
            this.txtActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtActual.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.txtActual.ForeColor = System.Drawing.Color.Green;
            this.txtActual.Location = new System.Drawing.Point(343, 24);
            this.txtActual.Margin = new System.Windows.Forms.Padding(3);
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(42, 15);
            this.txtActual.TabIndex = 10;
            this.txtActual.Text = "Actual";
            this.txtActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRangeMax
            // 
            this.txtRangeMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRangeMax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRangeMax.Location = new System.Drawing.Point(287, 24);
            this.txtRangeMax.Name = "txtRangeMax";
            this.txtRangeMax.Size = new System.Drawing.Size(50, 23);
            this.txtRangeMax.TabIndex = 11;
            this.txtRangeMax.Text = "0";
            this.txtRangeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRangeMax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTCRangeMax_KeyDown);
            this.txtRangeMax.Validating += new System.ComponentModel.CancelEventHandler(this.RTCRangeMax_Validating);
            // 
            // lblMin
            // 
            this.lblMin.AutoEllipsis = true;
            this.lblMin.AutoSize = true;
            this.lblMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(123, 23);
            this.lblMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblMin.Name = "lblMin";
            this.lblMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMin.Size = new System.Drawing.Size(44, 17);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "Min";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMax
            // 
            this.lblMax.AutoEllipsis = true;
            this.lblMax.AutoSize = true;
            this.lblMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMax.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(237, 21);
            this.lblMax.Name = "lblMax";
            this.lblMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMax.Size = new System.Drawing.Size(44, 21);
            this.lblMax.TabIndex = 7;
            this.lblMax.Text = "Max";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucRangeMaxMin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.Controls.Add(this.LayoutPanel);
            this.Name = "ucRangeMaxMin";
            this.Size = new System.Drawing.Size(388, 42);
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.Label lblFeatures;
        private System.Windows.Forms.Label lblMinTop;
        private System.Windows.Forms.Label lblMaxTop;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label txtActual;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        public System.Windows.Forms.CheckBox chkEnable;
        public System.Windows.Forms.MaskedTextBox txtRangeMin;
        public System.Windows.Forms.MaskedTextBox txtRangeMax;
    }
}
