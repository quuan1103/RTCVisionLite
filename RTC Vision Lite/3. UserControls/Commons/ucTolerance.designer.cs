
namespace RTC_Vision_Lite.UserControls
{
    partial class ucTolerance
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
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.lblMinusTop = new System.Windows.Forms.Label();
            this.lblMinus = new System.Windows.Forms.Label();
            this.txtMinus = new System.Windows.Forms.TextBox();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.lblPlusTop = new System.Windows.Forms.Label();
            this.lblNominalTop = new System.Windows.Forms.Label();
            this.lblPlus = new System.Windows.Forms.Label();
            this.txtActual = new System.Windows.Forms.Label();
            this.txtNominal = new System.Windows.Forms.TextBox();
            this.txtPlus = new System.Windows.Forms.TextBox();
            this.lblNominal = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 11;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutPanel.Controls.Add(this.chkEnable, 0, 1);
            this.LayoutPanel.Controls.Add(this.lblMinusTop, 3, 0);
            this.LayoutPanel.Controls.Add(this.lblMinus, 2, 1);
            this.LayoutPanel.Controls.Add(this.txtMinus, 3, 1);
            this.LayoutPanel.Controls.Add(this.lblFeatures, 0, 0);
            this.LayoutPanel.Controls.Add(this.lblActual, 10, 0);
            this.LayoutPanel.Controls.Add(this.lblPlusTop, 9, 0);
            this.LayoutPanel.Controls.Add(this.lblNominalTop, 6, 0);
            this.LayoutPanel.Controls.Add(this.lblPlus, 8, 1);
            this.LayoutPanel.Controls.Add(this.txtActual, 10, 1);
            this.LayoutPanel.Controls.Add(this.txtNominal, 6, 1);
            this.LayoutPanel.Controls.Add(this.txtPlus, 9, 1);
            this.LayoutPanel.Controls.Add(this.lblNominal, 5, 1);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 2;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.LayoutPanel.Size = new System.Drawing.Size(793, 54);
            this.LayoutPanel.TabIndex = 13;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEnable.Location = new System.Drawing.Point(4, 25);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(179, 25);
            this.chkEnable.TabIndex = 24;
            this.chkEnable.Text = "CheckTolerance";
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // lblMinusTop
            // 
            this.lblMinusTop.AutoSize = true;
            this.lblMinusTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinusTop.Location = new System.Drawing.Point(284, 2);
            this.lblMinusTop.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblMinusTop.Name = "lblMinusTop";
            this.lblMinusTop.Size = new System.Drawing.Size(72, 17);
            this.lblMinusTop.TabIndex = 23;
            this.lblMinusTop.Text = "Minus";
            this.lblMinusTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinus
            // 
            this.lblMinus.AutoSize = true;
            this.lblMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinus.Location = new System.Drawing.Point(204, 23);
            this.lblMinus.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblMinus.Name = "lblMinus";
            this.lblMinus.Size = new System.Drawing.Size(72, 29);
            this.lblMinus.TabIndex = 22;
            this.lblMinus.Text = "Minus";
            // 
            // txtMinus
            // 
            this.txtMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMinus.Location = new System.Drawing.Point(284, 25);
            this.txtMinus.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinus.Name = "txtMinus";
            this.txtMinus.Size = new System.Drawing.Size(72, 22);
            this.txtMinus.TabIndex = 21;
            this.txtMinus.Text = "0";
            this.txtMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMinus_KeyDown);
            this.txtMinus.Validating += new System.ComponentModel.CancelEventHandler(this.txtMinus_Validating);
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFeatures.Location = new System.Drawing.Point(4, 2);
            this.lblFeatures.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(179, 17);
            this.lblFeatures.TabIndex = 20;
            this.lblFeatures.Text = "Features";
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActual.Location = new System.Drawing.Point(710, 2);
            this.lblActual.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(112, 17);
            this.lblActual.TabIndex = 19;
            this.lblActual.Text = "Actual";
            this.lblActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlusTop
            // 
            this.lblPlusTop.AutoSize = true;
            this.lblPlusTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlusTop.Location = new System.Drawing.Point(630, 2);
            this.lblPlusTop.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblPlusTop.Name = "lblPlusTop";
            this.lblPlusTop.Size = new System.Drawing.Size(72, 17);
            this.lblPlusTop.TabIndex = 18;
            this.lblPlusTop.Text = "Plus";
            this.lblPlusTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNominalTop
            // 
            this.lblNominalTop.AutoSize = true;
            this.lblNominalTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNominalTop.Location = new System.Drawing.Point(457, 2);
            this.lblNominalTop.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblNominalTop.Name = "lblNominalTop";
            this.lblNominalTop.Size = new System.Drawing.Size(72, 17);
            this.lblNominalTop.TabIndex = 17;
            this.lblNominalTop.Text = "Nominal";
            this.lblNominalTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlus
            // 
            this.lblPlus.AutoSize = true;
            this.lblPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlus.Location = new System.Drawing.Point(550, 23);
            this.lblPlus.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.Size = new System.Drawing.Size(72, 29);
            this.lblPlus.TabIndex = 16;
            this.lblPlus.Text = "Plus";
            // 
            // txtActual
            // 
            this.txtActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtActual.ForeColor = System.Drawing.Color.Lime;
            this.txtActual.Location = new System.Drawing.Point(710, 23);
            this.txtActual.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(112, 29);
            this.txtActual.TabIndex = 14;
            this.txtActual.Text = "Actual";
            this.txtActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNominal
            // 
            this.txtNominal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNominal.Location = new System.Drawing.Point(457, 25);
            this.txtNominal.Margin = new System.Windows.Forms.Padding(4);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(72, 22);
            this.txtNominal.TabIndex = 12;
            this.txtNominal.Text = "0";
            this.txtNominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNominal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNominal_KeyDown);
            this.txtNominal.Validating += new System.ComponentModel.CancelEventHandler(this.txtNominal_Validating);
            // 
            // txtPlus
            // 
            this.txtPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlus.Location = new System.Drawing.Point(630, 25);
            this.txtPlus.Margin = new System.Windows.Forms.Padding(4, 4, 5, 4);
            this.txtPlus.Name = "txtPlus";
            this.txtPlus.Size = new System.Drawing.Size(71, 22);
            this.txtPlus.TabIndex = 13;
            this.txtPlus.Text = "0";
            this.txtPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPlus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlus_KeyDown);
            this.txtPlus.Validating += new System.ComponentModel.CancelEventHandler(this.txtPlus_Validating);
            // 
            // lblNominal
            // 
            this.lblNominal.AutoSize = true;
            this.lblNominal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNominal.Location = new System.Drawing.Point(377, 23);
            this.lblNominal.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblNominal.Name = "lblNominal";
            this.lblNominal.Size = new System.Drawing.Size(72, 29);
            this.lblNominal.TabIndex = 15;
            this.lblNominal.Text = "Nominal";
            // 
            // ucTolerance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.LayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucTolerance";
            this.Size = new System.Drawing.Size(793, 54);
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.Label lblPlus;
        private System.Windows.Forms.Label lblNominal;
        private System.Windows.Forms.Label lblPlusTop;
        private System.Windows.Forms.Label lblNominalTop;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label lblFeatures;
        public System.Windows.Forms.TextBox txtPlus;
        public System.Windows.Forms.TextBox txtNominal;
        private System.Windows.Forms.Label lblMinus;
        public System.Windows.Forms.TextBox txtMinus;
        private System.Windows.Forms.Label lblMinusTop;
        public System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Label txtActual;
    }
}
