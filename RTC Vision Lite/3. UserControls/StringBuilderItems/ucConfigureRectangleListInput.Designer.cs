
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureRectangleListInput
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.MaxiumLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Delimiter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.GroupingBracket = new System.Windows.Forms.ComboBox();
            this.ElementDelimiter = new RTC_Vision_Lite.UserControls.ucInputDelimiterStringBulderItem();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxiumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.ElementDelimiter);
            this.groupControl.Controls.Add(this.GroupingBracket);
            this.groupControl.Controls.Add(this.numericUpDown2);
            this.groupControl.Controls.Add(this.label4);
            this.groupControl.Controls.Add(this.Delimiter);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Controls.Add(this.MaxiumLength);
            this.groupControl.Controls.Add(this.checkBox1);
            this.groupControl.Controls.Add(this.MiniumLength);
            this.groupControl.Controls.Add(this.UseMiniumLength);
            this.groupControl.Controls.Add(this.ucTrallingText1);
            this.groupControl.Controls.Add(this.ucLeadingText1);
            this.groupControl.Controls.Add(this.PadWith);
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Size = new System.Drawing.Size(511, 141);
            this.groupControl.Text = "Configure Rectangle Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 113);
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
            this.PadWith.Location = new System.Drawing.Point(69, 110);
            this.PadWith.Name = "PadWith";
            this.PadWith.Size = new System.Drawing.Size(99, 21);
            this.PadWith.TabIndex = 6;
            // 
            // ucLeadingText1
            // 
            this.ucLeadingText1.Location = new System.Drawing.Point(291, 78);
            this.ucLeadingText1.Name = "ucLeadingText1";
            this.ucLeadingText1.RTCCaption = "Leading";
            this.ucLeadingText1.RTCCaptionWidth = 66F;
            this.ucLeadingText1.RTCSBItem = null;
            this.ucLeadingText1.Size = new System.Drawing.Size(217, 26);
            this.ucLeadingText1.TabIndex = 8;
            // 
            // ucTrallingText1
            // 
            this.ucTrallingText1.Location = new System.Drawing.Point(291, 110);
            this.ucTrallingText1.Name = "ucTrallingText1";
            this.ucTrallingText1.RTCCaption = "Tralling";
            this.ucTrallingText1.RTCCaptionWidth = 66F;
            this.ucTrallingText1.RTCSBItem = null;
            this.ucTrallingText1.Size = new System.Drawing.Size(217, 26);
            this.ucTrallingText1.TabIndex = 9;
            // 
            // UseMiniumLength
            // 
            this.UseMiniumLength.AutoSize = true;
            this.UseMiniumLength.Location = new System.Drawing.Point(95, 59);
            this.UseMiniumLength.Name = "UseMiniumLength";
            this.UseMiniumLength.Size = new System.Drawing.Size(79, 17);
            this.UseMiniumLength.TabIndex = 10;
            this.UseMiniumLength.Text = "Min Length";
            this.UseMiniumLength.UseVisualStyleBackColor = true;
            // 
            // MiniumLength
            // 
            this.MiniumLength.Location = new System.Drawing.Point(95, 83);
            this.MiniumLength.Name = "MiniumLength";
            this.MiniumLength.Size = new System.Drawing.Size(73, 20);
            this.MiniumLength.TabIndex = 11;
            this.MiniumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MiniumLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 59);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Max Length";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MaxiumLength
            // 
            this.MaxiumLength.Location = new System.Drawing.Point(8, 83);
            this.MaxiumLength.Name = "MaxiumLength";
            this.MaxiumLength.Size = new System.Drawing.Size(77, 20);
            this.MaxiumLength.TabIndex = 11;
            this.MaxiumLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaxiumLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Grouping Bracket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "X Y Delimiter";
            // 
            // Delimiter
            // 
            this.Delimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Delimiter.FormattingEnabled = true;
            this.Delimiter.Items.AddRange(new object[] {
            "Leading Zeros",
            "Leading Spaces",
            "Tralling Spaces"});
            this.Delimiter.Location = new System.Drawing.Point(179, 110);
            this.Delimiter.Name = "Delimiter";
            this.Delimiter.Size = new System.Drawing.Size(87, 21);
            this.Delimiter.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Decimal Places";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(95, 33);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(73, 20);
            this.numericUpDown2.TabIndex = 17;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // GroupingBracket
            // 
            this.GroupingBracket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupingBracket.FormattingEnabled = true;
            this.GroupingBracket.Location = new System.Drawing.Point(178, 59);
            this.GroupingBracket.Name = "GroupingBracket";
            this.GroupingBracket.Size = new System.Drawing.Size(87, 21);
            this.GroupingBracket.TabIndex = 18;
            // 
            // ElementDelimiter
            // 
            this.ElementDelimiter.Location = new System.Drawing.Point(269, 11);
            this.ElementDelimiter.Name = "ElementDelimiter";
            this.ElementDelimiter.RTCCaption = "List Element Delimiter";
            this.ElementDelimiter.RTCHideCustomButton = false;
            this.ElementDelimiter.RTCSBItem = null;
            this.ElementDelimiter.Size = new System.Drawing.Size(249, 69);
            this.ElementDelimiter.TabIndex = 19;
            // 
            // ucConfigureRectangleListInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucConfigureRectangleListInput";
            this.RTCCaption = "Configure Rectangle Input";
            this.Size = new System.Drawing.Size(511, 141);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MiniumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxiumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ucTrallingText ucTrallingText1;
        public ucLeadingText ucLeadingText1;
        public System.Windows.Forms.ComboBox PadWith;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown MiniumLength;
        public System.Windows.Forms.CheckBox UseMiniumLength;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown MaxiumLength;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.ComboBox Delimiter;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numericUpDown2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox GroupingBracket;
        public ucInputDelimiterStringBulderItem ElementDelimiter;
    }
}
