
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureBooleanInput
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
            this.ucTrallingText = new RTC_Vision_Lite.UserControls.ucLeadingText();
            this.ucLeadingText = new RTC_Vision_Lite.UserControls.ucTrallingText();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TrueText = new System.Windows.Forms.TextBox();
            this.FalseText = new System.Windows.Forms.TextBox();
            this.groupControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.FalseText);
            this.groupControl.Controls.Add(this.TrueText);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.ucLeadingText);
            this.groupControl.Controls.Add(this.ucTrallingText);
            this.groupControl.Text = "Configure Boolean Input";
            // 
            // ucTrallingText
            // 
            this.ucTrallingText.Location = new System.Drawing.Point(165, 22);
            this.ucTrallingText.Name = "ucTrallingText";
            this.ucTrallingText.RTCCaption = "Leading";
            this.ucTrallingText.RTCCaptionWidth = 55F;
            this.ucTrallingText.RTCSBItem = null;
            this.ucTrallingText.Size = new System.Drawing.Size(233, 26);
            this.ucTrallingText.TabIndex = 0;
            // 
            // ucLeadingText
            // 
            this.ucLeadingText.Location = new System.Drawing.Point(165, 54);
            this.ucLeadingText.Name = "ucLeadingText";
            this.ucLeadingText.RTCCaption = "Tralling";
            this.ucLeadingText.RTCCaptionWidth = 55F;
            this.ucLeadingText.RTCSBItem = null;
            this.ucLeadingText.Size = new System.Drawing.Size(233, 29);
            this.ucLeadingText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "True:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "False:";
            // 
            // TrueText
            // 
            this.TrueText.Location = new System.Drawing.Point(44, 25);
            this.TrueText.Name = "TrueText";
            this.TrueText.Size = new System.Drawing.Size(100, 20);
            this.TrueText.TabIndex = 4;
            // 
            // FalseText
            // 
            this.FalseText.Location = new System.Drawing.Point(44, 58);
            this.FalseText.Name = "FalseText";
            this.FalseText.Size = new System.Drawing.Size(100, 20);
            this.FalseText.TabIndex = 5;
            // 
            // ucConfigureBooleanInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucConfigureBooleanInput";
            this.RTCCaption = "Configure Boolean Input";
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ucLeadingText ucTrallingText;
        private ucTrallingText ucLeadingText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FalseText;
        private System.Windows.Forms.TextBox TrueText;
    }
}
