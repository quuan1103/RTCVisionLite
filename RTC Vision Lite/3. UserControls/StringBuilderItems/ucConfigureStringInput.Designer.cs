
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureStringInput
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
            this.ucTrallingText1 = new RTC_Vision_Lite.UserControls.ucLeadingText();
            this.ucTrallingText2 = new RTC_Vision_Lite.UserControls.ucTrallingText();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PadWith = new System.Windows.Forms.ComboBox();
            this.MaximumLength = new System.Windows.Forms.NumericUpDown();
            this.MinimumLength = new System.Windows.Forms.NumericUpDown();
            this.UseLimitInput = new System.Windows.Forms.CheckBox();
            this.UsePadOutput = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumLength)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Controls.Add(this.UsePadOutput);
            this.groupControl.Controls.Add(this.UseLimitInput);
            this.groupControl.Controls.Add(this.MinimumLength);
            this.groupControl.Controls.Add(this.MaximumLength);
            this.groupControl.Controls.Add(this.PadWith);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.ucTrallingText2);
            this.groupControl.Controls.Add(this.ucTrallingText1);
            this.groupControl.Text = "Configure String Input";
            // 
            // ucTrallingText1
            // 
            this.ucTrallingText1.Location = new System.Drawing.Point(283, 37);
            this.ucTrallingText1.Name = "ucTrallingText1";
            this.ucTrallingText1.RTCCaption = "Leading";
            this.ucTrallingText1.RTCCaptionWidth = 51F;
            this.ucTrallingText1.RTCSBItem = null;
            this.ucTrallingText1.Size = new System.Drawing.Size(173, 26);
            this.ucTrallingText1.TabIndex = 0;
            // 
            // ucTrallingText2
            // 
            this.ucTrallingText2.Location = new System.Drawing.Point(283, 69);
            this.ucTrallingText2.Name = "ucTrallingText2";
            this.ucTrallingText2.RTCCaption = "Tralling";
            this.ucTrallingText2.RTCCaptionWidth = 51F;
            this.ucTrallingText2.RTCSBItem = null;
            this.ucTrallingText2.Size = new System.Drawing.Size(173, 26);
            this.ucTrallingText2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minimum Length";
            // 
            // PadWith
            // 
            this.PadWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PadWith.FormattingEnabled = true;
            this.PadWith.Items.AddRange(new object[] {
            "Leading Zeros",
            "Leading Spaces",
            "Tralling Zeros",
            "Tralling Spaces",
            "Tralling Decimal"});
            this.PadWith.Location = new System.Drawing.Point(212, 72);
            this.PadWith.Name = "PadWith";
            this.PadWith.Size = new System.Drawing.Size(65, 21);
            this.PadWith.TabIndex = 4;
            // 
            // MaximumLength
            // 
            this.MaximumLength.Location = new System.Drawing.Point(10, 73);
            this.MaximumLength.Name = "MaximumLength";
            this.MaximumLength.Size = new System.Drawing.Size(94, 20);
            this.MaximumLength.TabIndex = 5;
            this.MaximumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MinimumLength
            // 
            this.MinimumLength.Location = new System.Drawing.Point(212, 43);
            this.MinimumLength.Name = "MinimumLength";
            this.MinimumLength.Size = new System.Drawing.Size(65, 20);
            this.MinimumLength.TabIndex = 6;
            this.MinimumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UseLimitInput
            // 
            this.UseLimitInput.AutoSize = true;
            this.UseLimitInput.Location = new System.Drawing.Point(10, 19);
            this.UseLimitInput.Name = "UseLimitInput";
            this.UseLimitInput.Size = new System.Drawing.Size(74, 17);
            this.UseLimitInput.TabIndex = 7;
            this.UseLimitInput.Text = "Limit Input";
            this.UseLimitInput.UseVisualStyleBackColor = true;
            // 
            // UsePadOutput
            // 
            this.UsePadOutput.AutoSize = true;
            this.UsePadOutput.Location = new System.Drawing.Point(120, 20);
            this.UsePadOutput.Name = "UsePadOutput";
            this.UsePadOutput.Size = new System.Drawing.Size(80, 17);
            this.UsePadOutput.TabIndex = 8;
            this.UsePadOutput.Text = "Pad Output";
            this.UsePadOutput.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pad With";
            // 
            // ucConfigureStringInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucConfigureStringInput";
            this.RTCCaption = "Configure String Input";
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ucLeadingText ucTrallingText1;
        public ucTrallingText ucTrallingText2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox UsePadOutput;
        public System.Windows.Forms.CheckBox UseLimitInput;
        public System.Windows.Forms.NumericUpDown MinimumLength;
        public System.Windows.Forms.NumericUpDown MaximumLength;
        public System.Windows.Forms.ComboBox PadWith;
        public System.Windows.Forms.Label label3;
    }
}
