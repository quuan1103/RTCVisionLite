
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureStringListInput
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
            this.UsePadOutput = new System.Windows.Forms.CheckBox();
            this.MiniumLength = new System.Windows.Forms.NumericUpDown();
            this.UseLimitInput = new System.Windows.Forms.CheckBox();
            this.MaxiumLength = new System.Windows.Forms.NumericUpDown();
            this.ElementDelimiter = new RTC_Vision_Lite.UserControls.ucInputDelimiterStringBulderItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxiumLength)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.ElementDelimiter);
            this.groupControl.Controls.Add(this.MaxiumLength);
            this.groupControl.Controls.Add(this.UseLimitInput);
            this.groupControl.Controls.Add(this.MiniumLength);
            this.groupControl.Controls.Add(this.UsePadOutput);
            this.groupControl.Controls.Add(this.ucTrallingText1);
            this.groupControl.Controls.Add(this.ucLeadingText1);
            this.groupControl.Controls.Add(this.PadWith);
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupControl.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupControl.Size = new System.Drawing.Size(645, 159);
            this.groupControl.Text = "Configure Origin Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 89);
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
            this.PadWith.Location = new System.Drawing.Point(84, 84);
            this.PadWith.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PadWith.Name = "PadWith";
            this.PadWith.Size = new System.Drawing.Size(141, 24);
            this.PadWith.TabIndex = 6;
            // 
            // ucLeadingText1
            // 
            this.ucLeadingText1.Location = new System.Drawing.Point(15, 117);
            this.ucLeadingText1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucLeadingText1.Name = "ucLeadingText1";
            this.ucLeadingText1.RTCCaption = "Leading";
            this.ucLeadingText1.RTCCaptionWidth = 63F;
            this.ucLeadingText1.RTCSBItem = null;
            this.ucLeadingText1.Size = new System.Drawing.Size(276, 32);
            this.ucLeadingText1.TabIndex = 8;
            // 
            // ucTrallingText1
            // 
            this.ucTrallingText1.Location = new System.Drawing.Point(365, 117);
            this.ucTrallingText1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucTrallingText1.Name = "ucTrallingText1";
            this.ucTrallingText1.RTCCaption = "Tralling";
            this.ucTrallingText1.RTCCaptionWidth = 66F;
            this.ucTrallingText1.RTCSBItem = null;
            this.ucTrallingText1.Size = new System.Drawing.Size(276, 32);
            this.ucTrallingText1.TabIndex = 9;
            // 
            // UsePadOutput
            // 
            this.UsePadOutput.AutoSize = true;
            this.UsePadOutput.Location = new System.Drawing.Point(147, 25);
            this.UsePadOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UsePadOutput.Name = "UsePadOutput";
            this.UsePadOutput.Size = new System.Drawing.Size(92, 20);
            this.UsePadOutput.TabIndex = 10;
            this.UsePadOutput.Text = "Pad Output";
            this.UsePadOutput.UseVisualStyleBackColor = true;
            // 
            // MiniumLength
            // 
            this.MiniumLength.Location = new System.Drawing.Point(260, 52);
            this.MiniumLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MiniumLength.Name = "MiniumLength";
            this.MiniumLength.Size = new System.Drawing.Size(67, 22);
            this.MiniumLength.TabIndex = 11;
            this.MiniumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MiniumLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MiniumLength.ValueChanged += new System.EventHandler(this.MiniumLength_ValueChanged);
            // 
            // UseLimitInput
            // 
            this.UseLimitInput.AutoSize = true;
            this.UseLimitInput.Location = new System.Drawing.Point(8, 25);
            this.UseLimitInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UseLimitInput.Name = "UseLimitInput";
            this.UseLimitInput.Size = new System.Drawing.Size(84, 20);
            this.UseLimitInput.TabIndex = 10;
            this.UseLimitInput.Text = "Limit Input";
            this.UseLimitInput.UseVisualStyleBackColor = true;
            // 
            // MaxiumLength
            // 
            this.MaxiumLength.Location = new System.Drawing.Point(90, 52);
            this.MaxiumLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaxiumLength.Name = "MaxiumLength";
            this.MaxiumLength.Size = new System.Drawing.Size(67, 22);
            this.MaxiumLength.TabIndex = 11;
            this.MaxiumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ElementDelimiter
            // 
            this.ElementDelimiter.Location = new System.Drawing.Point(335, 25);
            this.ElementDelimiter.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ElementDelimiter.Name = "ElementDelimiter";
            this.ElementDelimiter.RTCCaption = "List Element Delimiter";
            this.ElementDelimiter.RTCHideCustomButton = false;
            this.ElementDelimiter.RTCSBItem = null;
            this.ElementDelimiter.Size = new System.Drawing.Size(320, 85);
            this.ElementDelimiter.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Max Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Max Length";
            // 
            // ucConfigureStringListInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ucConfigureStringListInput";
            this.RTCCaption = "Configure Origin Input";
            this.Size = new System.Drawing.Size(645, 159);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxiumLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ucTrallingText ucTrallingText1;
        public ucLeadingText ucLeadingText1;
        public System.Windows.Forms.ComboBox PadWith;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown MiniumLength;
        public System.Windows.Forms.CheckBox UsePadOutput;
        public System.Windows.Forms.NumericUpDown MaxiumLength;
        public System.Windows.Forms.CheckBox UseLimitInput;
        public ucInputDelimiterStringBulderItem ElementDelimiter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}
