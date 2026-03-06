
namespace RTC_Vision_Lite.Layout
{
    partial class ucCycleTime
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
            this.lblVisionResult = new System.Windows.Forms.Label();
            this.lblCycleTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVisionResult
            // 
            this.lblVisionResult.AutoSize = true;
            this.lblVisionResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisionResult.ForeColor = System.Drawing.Color.White;
            this.lblVisionResult.Location = new System.Drawing.Point(97, 0);
            this.lblVisionResult.Name = "lblVisionResult";
            this.lblVisionResult.Size = new System.Drawing.Size(99, 21);
            this.lblVisionResult.TabIndex = 0;
            this.lblVisionResult.Text = "CYCLE TIME";
            this.lblVisionResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCycleTime
            // 
            this.lblCycleTime.AutoSize = true;
            this.lblCycleTime.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCycleTime.ForeColor = System.Drawing.Color.White;
            this.lblCycleTime.Location = new System.Drawing.Point(119, 32);
            this.lblCycleTime.Name = "lblCycleTime";
            this.lblCycleTime.Size = new System.Drawing.Size(52, 25);
            this.lblCycleTime.TabIndex = 1;
            this.lblCycleTime.Text = "-----";
            // 
            // ucCycleTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(119)))));
            this.Controls.Add(this.lblCycleTime);
            this.Controls.Add(this.lblVisionResult);
            this.Name = "ucCycleTime";
            this.Size = new System.Drawing.Size(300, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVisionResult;
        private System.Windows.Forms.Label lblCycleTime;
    }
}
