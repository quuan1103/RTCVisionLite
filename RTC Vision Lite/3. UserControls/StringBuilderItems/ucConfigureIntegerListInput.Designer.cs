
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureIntegerListInput
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
            this.label3 = new System.Windows.Forms.Label();
            this.PadWith = new System.Windows.Forms.ComboBox();
            this.ucLeadingText1 = new RTC_Vision_Lite.UserControls.ucLeadingText();
            this.ucTrallingText1 = new RTC_Vision_Lite.UserControls.ucTrallingText();
            this.UseMiniumLength = new System.Windows.Forms.CheckBox();
            this.MiniumLength = new System.Windows.Forms.NumericUpDown();
            this.ElementDelimiter = new RTC_Vision_Lite.UserControls.ucInputDelimiterStringBulderItem();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.ElementDelimiter);
            this.groupControl.Controls.Add(this.MiniumLength);
            this.groupControl.Controls.Add(this.UseMiniumLength);
            this.groupControl.Controls.Add(this.ucTrallingText1);
            this.groupControl.Controls.Add(this.ucLeadingText1);
            this.groupControl.Controls.Add(this.PadWith);
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupControl.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupControl.Size = new System.Drawing.Size(728, 122);
            this.groupControl.Text = "Configure Integer List Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pad Width";
            // 
            // PadWith
            // 
            this.PadWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PadWith.FormattingEnabled = true;
            this.PadWith.Items.AddRange(new object[] {
            "Leading Zeros",
            "Leading Spaces",
            "Tralling Spaces"});
            this.PadWith.Location = new System.Drawing.Point(93, 81);
            this.PadWith.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PadWith.Name = "PadWith";
            this.PadWith.Size = new System.Drawing.Size(120, 24);
            this.PadWith.TabIndex = 6;
            // 
            // ucLeadingText1
            // 
            this.ucLeadingText1.Location = new System.Drawing.Point(464, 44);
            this.ucLeadingText1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucLeadingText1.Name = "ucLeadingText1";
            this.ucLeadingText1.RTCCaption = "Leading";
            this.ucLeadingText1.RTCCaptionWidth = 55F;
            this.ucLeadingText1.RTCSBItem = null;
            this.ucLeadingText1.Size = new System.Drawing.Size(256, 32);
            this.ucLeadingText1.TabIndex = 8;
            // 
            // ucTrallingText1
            // 
            this.ucTrallingText1.Location = new System.Drawing.Point(464, 78);
            this.ucTrallingText1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucTrallingText1.Name = "ucTrallingText1";
            this.ucTrallingText1.RTCCaption = "Tralling";
            this.ucTrallingText1.RTCCaptionWidth = 55F;
            this.ucTrallingText1.RTCSBItem = null;
            this.ucTrallingText1.Size = new System.Drawing.Size(256, 32);
            this.ucTrallingText1.TabIndex = 9;
            // 
            // UseMiniumLength
            // 
            this.UseMiniumLength.AutoSize = true;
            this.UseMiniumLength.Location = new System.Drawing.Point(8, 53);
            this.UseMiniumLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UseMiniumLength.Name = "UseMiniumLength";
            this.UseMiniumLength.Size = new System.Drawing.Size(111, 20);
            this.UseMiniumLength.TabIndex = 10;
            this.UseMiniumLength.Text = "Minium Length";
            this.UseMiniumLength.UseVisualStyleBackColor = true;
            // 
            // MiniumLength
            // 
            this.MiniumLength.Location = new System.Drawing.Point(137, 52);
            this.MiniumLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MiniumLength.Name = "MiniumLength";
            this.MiniumLength.Size = new System.Drawing.Size(77, 22);
            this.MiniumLength.TabIndex = 11;
            this.MiniumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MiniumLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ElementDelimiter
            // 
            this.ElementDelimiter.Location = new System.Drawing.Point(223, 25);
            this.ElementDelimiter.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ElementDelimiter.Name = "ElementDelimiter";
            this.ElementDelimiter.RTCCaption = "List Element Delimiter";
            this.ElementDelimiter.RTCHideCustomButton = false;
            this.ElementDelimiter.RTCSBItem = null;
            this.ElementDelimiter.Size = new System.Drawing.Size(231, 85);
            this.ElementDelimiter.TabIndex = 12;
            // 
            // ucConfigureIntegerListInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ucConfigureIntegerListInput";
            this.RTCCaption = "Configure Integer List Input";
            this.Size = new System.Drawing.Size(728, 122);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox PadWith;
        public System.Windows.Forms.NumericUpDown MiniumLength;
        public ucTrallingText ucTrallingText1;
        public ucLeadingText ucLeadingText1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox UseMiniumLength;
        public ucInputDelimiterStringBulderItem ElementDelimiter;
    }
}
