
namespace RTC_Vision_Lite.UserControls
{
    partial class ucRangeMaxMinLimit
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
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.lblMinR = new System.Windows.Forms.Label();
            this.lblMaxR = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtBeginValue = new System.Windows.Forms.TextBox();
            this.txtEndValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // hScrollBar
            // 
            this.hScrollBar.LargeChange = 1;
            this.hScrollBar.Location = new System.Drawing.Point(22, 26);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(131, 24);
            this.hScrollBar.TabIndex = 0;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_ValueChanged);
            // 
            // lblMinR
            // 
            this.lblMinR.Location = new System.Drawing.Point(47, 3);
            this.lblMinR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinR.Name = "lblMinR";
            this.lblMinR.Size = new System.Drawing.Size(72, 20);
            this.lblMinR.TabIndex = 1;
            this.lblMinR.Text = "0";
            this.lblMinR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMinR.DoubleClick += new System.EventHandler(this.lblMinR_DoubleClick);
            // 
            // lblMaxR
            // 
            this.lblMaxR.Location = new System.Drawing.Point(48, 50);
            this.lblMaxR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxR.Name = "lblMaxR";
            this.lblMaxR.Size = new System.Drawing.Size(70, 22);
            this.lblMaxR.TabIndex = 2;
            this.lblMaxR.Text = "25";
            this.lblMaxR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMaxR.DoubleClick += new System.EventHandler(this.lblMaxR_DoubleClick);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(159, 32);
            this.lblMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(25, 13);
            this.lblMax.TabIndex = 3;
            this.lblMax.Text = "100";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(5, 32);
            this.lblMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(13, 13);
            this.lblMin.TabIndex = 4;
            this.lblMin.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtBeginValue
            // 
            this.txtBeginValue.Location = new System.Drawing.Point(47, 7);
            this.txtBeginValue.MaximumSize = new System.Drawing.Size(100, 16);
            this.txtBeginValue.Name = "txtBeginValue";
            this.txtBeginValue.Size = new System.Drawing.Size(60, 20);
            this.txtBeginValue.TabIndex = 5;
            this.txtBeginValue.Visible = false;
            this.txtBeginValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBeginValue_KeyDown);
            // 
            // txtEndValue
            // 
            this.txtEndValue.Location = new System.Drawing.Point(59, 56);
            this.txtEndValue.MaximumSize = new System.Drawing.Size(100, 16);
            this.txtEndValue.Name = "txtEndValue";
            this.txtEndValue.Size = new System.Drawing.Size(60, 20);
            this.txtEndValue.TabIndex = 6;
            this.txtEndValue.Visible = false;
            this.txtEndValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndValue_KeyDown);
            // 
            // ucRangeMaxMinLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMaxR);
            this.Controls.Add(this.lblMinR);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.txtBeginValue);
            this.Controls.Add(this.txtEndValue);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucRangeMaxMinLimit";
            this.Size = new System.Drawing.Size(200, 76);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Label lblMinR;
        private System.Windows.Forms.Label lblMaxR;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtBeginValue;
        private System.Windows.Forms.TextBox txtEndValue;
    }
}
