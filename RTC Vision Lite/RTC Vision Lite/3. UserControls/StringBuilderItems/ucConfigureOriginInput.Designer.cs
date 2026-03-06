
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureOriginInput
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
            this.UseLimitInput = new System.Windows.Forms.CheckBox();
            this.MaximumLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupingBracket = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.XYDelimiter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DecimalPlaces = new System.Windows.Forms.NumericUpDown();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupingBracket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.DecimalPlaces);
            this.groupControl.Controls.Add(this.label4);
            this.groupControl.Controls.Add(this.XYDelimiter);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.GroupingBracket);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.MaximumLength);
            this.groupControl.Controls.Add(this.UseLimitInput);
            this.groupControl.Controls.Add(this.MiniumLength);
            this.groupControl.Controls.Add(this.UseMiniumLength);
            this.groupControl.Controls.Add(this.ucTrallingText1);
            this.groupControl.Controls.Add(this.ucLeadingText1);
            this.groupControl.Controls.Add(this.PadWith);
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Size = new System.Drawing.Size(553, 107);
            this.groupControl.Text = "Configure Origin Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
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
            this.PadWith.Location = new System.Drawing.Point(77, 72);
            this.PadWith.Name = "PadWith";
            this.PadWith.Size = new System.Drawing.Size(100, 21);
            this.PadWith.TabIndex = 6;
            // 
            // ucLeadingText1
            // 
            this.ucLeadingText1.Location = new System.Drawing.Point(306, 6);
            this.ucLeadingText1.Name = "ucLeadingText1";
            this.ucLeadingText1.RTCCaption = "Leading";
            this.ucLeadingText1.RTCCaptionWidth = 51F;
            this.ucLeadingText1.RTCSBItem = null;
            this.ucLeadingText1.Size = new System.Drawing.Size(221, 26);
            this.ucLeadingText1.TabIndex = 8;
            // 
            // ucTrallingText1
            // 
            this.ucTrallingText1.Location = new System.Drawing.Point(306, 33);
            this.ucTrallingText1.Name = "ucTrallingText1";
            this.ucTrallingText1.RTCCaption = "Tralling";
            this.ucTrallingText1.RTCCaptionWidth = 51F;
            this.ucTrallingText1.RTCSBItem = null;
            this.ucTrallingText1.Size = new System.Drawing.Size(221, 26);
            this.ucTrallingText1.TabIndex = 9;
            // 
            // UseMiniumLength
            // 
            this.UseMiniumLength.AutoSize = true;
            this.UseMiniumLength.Checked = true;
            this.UseMiniumLength.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseMiniumLength.Location = new System.Drawing.Point(13, 49);
            this.UseMiniumLength.Name = "UseMiniumLength";
            this.UseMiniumLength.Size = new System.Drawing.Size(95, 17);
            this.UseMiniumLength.TabIndex = 10;
            this.UseMiniumLength.Text = "Minium Length";
            this.UseMiniumLength.UseVisualStyleBackColor = true;
            // 
            // MiniumLength
            // 
            this.MiniumLength.Location = new System.Drawing.Point(119, 48);
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
            // UseLimitInput
            // 
            this.UseLimitInput.AutoSize = true;
            this.UseLimitInput.Checked = true;
            this.UseLimitInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseLimitInput.Location = new System.Drawing.Point(13, 26);
            this.UseLimitInput.Name = "UseLimitInput";
            this.UseLimitInput.Size = new System.Drawing.Size(82, 17);
            this.UseLimitInput.TabIndex = 10;
            this.UseLimitInput.Text = "Max Length";
            this.UseLimitInput.UseVisualStyleBackColor = true;
            // 
            // MaximumLength
            // 
            this.MaximumLength.Location = new System.Drawing.Point(119, 22);
            this.MaximumLength.Name = "MaximumLength";
            this.MaximumLength.Size = new System.Drawing.Size(58, 20);
            this.MaximumLength.TabIndex = 11;
            this.MaximumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaximumLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Grouping Bracket";
            // 
            // GroupingBracket
            // 
            this.GroupingBracket.Location = new System.Drawing.Point(201, 31);
            this.GroupingBracket.Name = "GroupingBracket";
            this.GroupingBracket.Size = new System.Drawing.Size(87, 20);
            this.GroupingBracket.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "X Y Parameter";
            // 
            // XYDelimiter
            // 
            this.XYDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XYDelimiter.FormattingEnabled = true;
            this.XYDelimiter.Items.AddRange(new object[] {
            "Leading Zeros",
            "Leading Spaces",
            "Tralling Spaces"});
            this.XYDelimiter.Location = new System.Drawing.Point(201, 73);
            this.XYDelimiter.Name = "XYDelimiter";
            this.XYDelimiter.Size = new System.Drawing.Size(87, 21);
            this.XYDelimiter.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Decimal Places";
            // 
            // DecimalPlaces
            // 
            this.DecimalPlaces.Location = new System.Drawing.Point(391, 62);
            this.DecimalPlaces.Name = "DecimalPlaces";
            this.DecimalPlaces.Size = new System.Drawing.Size(104, 20);
            this.DecimalPlaces.TabIndex = 17;
            this.DecimalPlaces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DecimalPlaces.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ucConfigureOriginInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucConfigureOriginInput";
            this.RTCCaption = "Configure Origin Input";
            this.Size = new System.Drawing.Size(553, 107);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupingBracket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucTrallingText ucTrallingText1;
        private ucLeadingText ucLeadingText1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown GroupingBracket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DecimalPlaces;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox PadWith;
        public System.Windows.Forms.NumericUpDown MiniumLength;
        public System.Windows.Forms.NumericUpDown MaximumLength;
        public System.Windows.Forms.ComboBox XYDelimiter;
        public System.Windows.Forms.CheckBox UseMiniumLength;
        public System.Windows.Forms.CheckBox UseLimitInput;
    }
}
