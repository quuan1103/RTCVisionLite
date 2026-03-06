
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureBooleanListInput
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
            this.ucLeadingText = new RTC_Vision_Lite.UserControls.ucLeadingText();
            this.ucTrallingText2 = new RTC_Vision_Lite.UserControls.ucTrallingText();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TrueText = new System.Windows.Forms.TextBox();
            this.FalseText = new System.Windows.Forms.TextBox();
            this.ElementDelimiter = new RTC_Vision_Lite.UserControls.ucInputDelimiterStringBulderItem();
            this.groupControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.ElementDelimiter);
            this.groupControl.Controls.Add(this.FalseText);
            this.groupControl.Controls.Add(this.TrueText);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.ucTrallingText2);
            this.groupControl.Controls.Add(this.ucLeadingText);
            this.groupControl.Size = new System.Drawing.Size(540, 107);
            // 
            // ucLeadingText
            // 
            this.ucLeadingText.Location = new System.Drawing.Point(335, 25);
            this.ucLeadingText.Name = "ucLeadingText";
            this.ucLeadingText.RTCCaption = "Leading";
            this.ucLeadingText.RTCCaptionWidth = 55F;
            this.ucLeadingText.RTCSBItem = null;
            this.ucLeadingText.Size = new System.Drawing.Size(197, 26);
            this.ucLeadingText.TabIndex = 0;
            // 
            // ucTrallingText2
            // 
            this.ucTrallingText2.Location = new System.Drawing.Point(335, 57);
            this.ucTrallingText2.Name = "ucTrallingText2";
            this.ucTrallingText2.RTCCaption = "Caption";
            this.ucTrallingText2.RTCCaptionWidth = 55F;
            this.ucTrallingText2.RTCSBItem = null;
            this.ucTrallingText2.Size = new System.Drawing.Size(197, 29);
            this.ucTrallingText2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "True:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "False:";
            // 
            // TrueText
            // 
            this.TrueText.Location = new System.Drawing.Point(44, 28);
            this.TrueText.Name = "TrueText";
            this.TrueText.Size = new System.Drawing.Size(100, 20);
            this.TrueText.TabIndex = 4;
            // 
            // FalseText
            // 
            this.FalseText.Location = new System.Drawing.Point(44, 62);
            this.FalseText.Name = "FalseText";
            this.FalseText.Size = new System.Drawing.Size(100, 20);
            this.FalseText.TabIndex = 5;
            // 
            // ElementDelimiter
            // 
            this.ElementDelimiter.Location = new System.Drawing.Point(147, 19);
            this.ElementDelimiter.Name = "ElementDelimiter";
            this.ElementDelimiter.RTCCaption = "List Element Delimiter";
            this.ElementDelimiter.RTCHideCustomButton = false;
            this.ElementDelimiter.RTCSBItem = null;
            this.ElementDelimiter.Size = new System.Drawing.Size(182, 80);
            this.ElementDelimiter.TabIndex = 6;
            // 
            // ucConfigureBooleanListInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucConfigureBooleanListInput";
            this.Size = new System.Drawing.Size(540, 107);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ucLeadingText ucLeadingText;
        private ucTrallingText ucTrallingText2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FalseText;
        private System.Windows.Forms.TextBox TrueText;
        public ucInputDelimiterStringBulderItem ElementDelimiter;
    }
}
