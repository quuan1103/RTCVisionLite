
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureRealListInput
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
            this.PadWith = new System.Windows.Forms.ComboBox();
            this.ucLeadingText1 = new RTC_Vision_Lite.UserControls.ucLeadingText();
            this.ucTrallingText1 = new RTC_Vision_Lite.UserControls.ucTrallingText();
            this.UseMiniumLength = new System.Windows.Forms.CheckBox();
            this.MiniumLength = new System.Windows.Forms.NumericUpDown();
            this.ElementDelimiter = new RTC_Vision_Lite.UserControls.ucInputDelimiterStringBulderItem();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxiumLength = new System.Windows.Forms.NumericUpDown();
            this.UseLimitInput = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DecimalPlaces = new System.Windows.Forms.NumericUpDown();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxiumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.DecimalPlaces);
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.MaxiumLength);
            this.groupControl.Controls.Add(this.UseLimitInput);
            this.groupControl.Controls.Add(this.ElementDelimiter);
            this.groupControl.Controls.Add(this.MiniumLength);
            this.groupControl.Controls.Add(this.UseMiniumLength);
            this.groupControl.Controls.Add(this.ucTrallingText1);
            this.groupControl.Controls.Add(this.ucLeadingText1);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.PadWith);
            this.groupControl.Size = new System.Drawing.Size(487, 133);
            this.groupControl.Text = "Configure Real List Input";
            // 
            // PadWith
            // 
            this.PadWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PadWith.FormattingEnabled = true;
            this.PadWith.Items.AddRange(new object[] {
            "Leading Zeros",
            "Leading Spaces",
            "Tralling Spaces"});
            this.PadWith.Location = new System.Drawing.Point(163, 79);
            this.PadWith.Name = "PadWith";
            this.PadWith.Size = new System.Drawing.Size(91, 21);
            this.PadWith.TabIndex = 6;
            // 
            // ucLeadingText1
            // 
            this.ucLeadingText1.Location = new System.Drawing.Point(276, 73);
            this.ucLeadingText1.Name = "ucLeadingText1";
            this.ucLeadingText1.RTCCaption = "Leading";
            this.ucLeadingText1.RTCCaptionWidth = 66F;
            this.ucLeadingText1.RTCSBItem = null;
            this.ucLeadingText1.Size = new System.Drawing.Size(198, 26);
            this.ucLeadingText1.TabIndex = 8;
            // 
            // ucTrallingText1
            // 
            this.ucTrallingText1.Location = new System.Drawing.Point(276, 101);
            this.ucTrallingText1.Name = "ucTrallingText1";
            this.ucTrallingText1.RTCCaption = "Tralling";
            this.ucTrallingText1.RTCCaptionWidth = 66F;
            this.ucTrallingText1.RTCSBItem = null;
            this.ucTrallingText1.Size = new System.Drawing.Size(198, 26);
            this.ucTrallingText1.TabIndex = 9;
            // 
            // UseMiniumLength
            // 
            this.UseMiniumLength.AutoSize = true;
            this.UseMiniumLength.Location = new System.Drawing.Point(96, 55);
            this.UseMiniumLength.Name = "UseMiniumLength";
            this.UseMiniumLength.Size = new System.Drawing.Size(95, 17);
            this.UseMiniumLength.TabIndex = 10;
            this.UseMiniumLength.Text = "Minium Length";
            this.UseMiniumLength.UseVisualStyleBackColor = true;
            // 
            // MiniumLength
            // 
            this.MiniumLength.Location = new System.Drawing.Point(196, 52);
            this.MiniumLength.Name = "MiniumLength";
            this.MiniumLength.Size = new System.Drawing.Size(58, 20);
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
            this.ElementDelimiter.Location = new System.Drawing.Point(254, 3);
            this.ElementDelimiter.Name = "ElementDelimiter";
            this.ElementDelimiter.RTCCaption = "List Element Delimiter";
            this.ElementDelimiter.RTCHideCustomButton = false;
            this.ElementDelimiter.RTCSBItem = null;
            this.ElementDelimiter.Size = new System.Drawing.Size(226, 69);
            this.ElementDelimiter.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pad Width";
            // 
            // MaxiumLength
            // 
            this.MaxiumLength.Location = new System.Drawing.Point(12, 78);
            this.MaxiumLength.Name = "MaxiumLength";
            this.MaxiumLength.Size = new System.Drawing.Size(58, 20);
            this.MaxiumLength.TabIndex = 14;
            this.MaxiumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaxiumLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UseLimitInput
            // 
            this.UseLimitInput.AutoSize = true;
            this.UseLimitInput.Location = new System.Drawing.Point(15, 27);
            this.UseLimitInput.Name = "UseLimitInput";
            this.UseLimitInput.Size = new System.Drawing.Size(74, 17);
            this.UseLimitInput.TabIndex = 13;
            this.UseLimitInput.Text = "Limit Input";
            this.UseLimitInput.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Max Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Decimal Places";
            // 
            // DecimalPlaces
            // 
            this.DecimalPlaces.Location = new System.Drawing.Point(196, 26);
            this.DecimalPlaces.Name = "DecimalPlaces";
            this.DecimalPlaces.Size = new System.Drawing.Size(58, 20);
            this.DecimalPlaces.TabIndex = 17;
            this.DecimalPlaces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DecimalPlaces.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ucConfigureRealListInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucConfigureRealListInput";
            this.RTCCaption = "Configure Real List Input";
            this.Size = new System.Drawing.Size(487, 133);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxiumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ucTrallingText ucTrallingText1;
        public ucLeadingText ucLeadingText1;
        public System.Windows.Forms.ComboBox PadWith;
        public System.Windows.Forms.NumericUpDown MiniumLength;
        public System.Windows.Forms.CheckBox UseMiniumLength;
        public ucInputDelimiterStringBulderItem ElementDelimiter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown DecimalPlaces;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown MaxiumLength;
        public System.Windows.Forms.CheckBox UseLimitInput;
    }
}
