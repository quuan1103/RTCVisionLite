
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureRealInput
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
            this.MaximumLength = new System.Windows.Forms.NumericUpDown();
            this.UseLimitInput = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DecimalPlaces = new System.Windows.Forms.NumericUpDown();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.DecimalPlaces);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.MaximumLength);
            this.groupControl.Controls.Add(this.UseLimitInput);
            this.groupControl.Controls.Add(this.MiniumLength);
            this.groupControl.Controls.Add(this.UseMiniumLength);
            this.groupControl.Controls.Add(this.ucTrallingText1);
            this.groupControl.Controls.Add(this.ucLeadingText1);
            this.groupControl.Controls.Add(this.PadWith);
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Size = new System.Drawing.Size(402, 96);
            this.groupControl.Text = "Configure Real Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
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
            this.PadWith.Location = new System.Drawing.Point(79, 66);
            this.PadWith.Name = "PadWith";
            this.PadWith.Size = new System.Drawing.Size(100, 21);
            this.PadWith.TabIndex = 6;
            // 
            // ucLeadingText1
            // 
            this.ucLeadingText1.Location = new System.Drawing.Point(194, 39);
            this.ucLeadingText1.Name = "ucLeadingText1";
            this.ucLeadingText1.RTCCaption = "Leading";
            this.ucLeadingText1.RTCCaptionWidth = 51F;
            this.ucLeadingText1.RTCSBItem = null;
            this.ucLeadingText1.Size = new System.Drawing.Size(204, 26);
            this.ucLeadingText1.TabIndex = 8;
            // 
            // ucTrallingText1
            // 
            this.ucTrallingText1.Location = new System.Drawing.Point(194, 66);
            this.ucTrallingText1.Name = "ucTrallingText1";
            this.ucTrallingText1.RTCCaption = "Tralling";
            this.ucTrallingText1.RTCCaptionWidth = 51F;
            this.ucTrallingText1.RTCSBItem = null;
            this.ucTrallingText1.Size = new System.Drawing.Size(204, 26);
            this.ucTrallingText1.TabIndex = 9;
            // 
            // UseMiniumLength
            // 
            this.UseMiniumLength.AutoSize = true;
            this.UseMiniumLength.Location = new System.Drawing.Point(15, 43);
            this.UseMiniumLength.Name = "UseMiniumLength";
            this.UseMiniumLength.Size = new System.Drawing.Size(79, 17);
            this.UseMiniumLength.TabIndex = 10;
            this.UseMiniumLength.Text = "Min Length";
            this.UseMiniumLength.UseVisualStyleBackColor = true;
            // 
            // MiniumLength
            // 
            this.MiniumLength.Location = new System.Drawing.Point(121, 42);
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
            // MaximumLength
            // 
            this.MaximumLength.Location = new System.Drawing.Point(121, 19);
            this.MaximumLength.Name = "MaximumLength";
            this.MaximumLength.Size = new System.Drawing.Size(58, 20);
            this.MaximumLength.TabIndex = 13;
            this.MaximumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UseLimitInput
            // 
            this.UseLimitInput.AutoSize = true;
            this.UseLimitInput.Location = new System.Drawing.Point(15, 20);
            this.UseLimitInput.Name = "UseLimitInput";
            this.UseLimitInput.Size = new System.Drawing.Size(82, 17);
            this.UseLimitInput.TabIndex = 12;
            this.UseLimitInput.Text = "Max Length";
            this.UseLimitInput.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Decimal Places";
            // 
            // DecimalPlaces
            // 
            this.DecimalPlaces.Location = new System.Drawing.Point(284, 17);
            this.DecimalPlaces.Name = "DecimalPlaces";
            this.DecimalPlaces.Size = new System.Drawing.Size(80, 20);
            this.DecimalPlaces.TabIndex = 15;
            this.DecimalPlaces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DecimalPlaces.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ucConfigureRealInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucConfigureRealInput";
            this.RTCCaption = "Configure Real Input";
            this.Size = new System.Drawing.Size(402, 96);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ucTrallingText ucTrallingText1;
        public ucLeadingText ucLeadingText1;
        public System.Windows.Forms.ComboBox PadWith;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown MiniumLength;
        public System.Windows.Forms.CheckBox UseMiniumLength;
        public System.Windows.Forms.NumericUpDown DecimalPlaces;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown MaximumLength;
        public System.Windows.Forms.CheckBox UseLimitInput;
    }
}
