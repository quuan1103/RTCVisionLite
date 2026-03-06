
namespace RTC_Vision_Lite.UserControls
{
    partial class ucConfigureDateTimeInput
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DateFormat = new System.Windows.Forms.ComboBox();
            this.DelimiterDate = new System.Windows.Forms.ComboBox();
            this.TimeFormat = new System.Windows.Forms.ComboBox();
            this.DelimiterTime = new System.Windows.Forms.ComboBox();
            this.ucLeadingText1 = new RTC_Vision_Lite.UserControls.ucLeadingText();
            this.ucTrallingText1 = new RTC_Vision_Lite.UserControls.ucTrallingText();
            this.UseDecimalPlaces = new System.Windows.Forms.CheckBox();
            this.DecimalPlaces = new System.Windows.Forms.NumericUpDown();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.DecimalPlaces);
            this.groupControl.Controls.Add(this.UseDecimalPlaces);
            this.groupControl.Controls.Add(this.ucTrallingText1);
            this.groupControl.Controls.Add(this.ucLeadingText1);
            this.groupControl.Controls.Add(this.DelimiterTime);
            this.groupControl.Controls.Add(this.TimeFormat);
            this.groupControl.Controls.Add(this.DelimiterDate);
            this.groupControl.Controls.Add(this.DateFormat);
            this.groupControl.Controls.Add(this.label4);
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Controls.Add(this.label2);
            this.groupControl.Controls.Add(this.label1);
            this.groupControl.Size = new System.Drawing.Size(545, 107);
            this.groupControl.Text = "Configure Date Time Input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Format";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Delimiter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time Format";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Delimiter";
            // 
            // DateFormat
            // 
            this.DateFormat.FormattingEnabled = true;
            this.DateFormat.Items.AddRange(new object[] {
            "yymmdd",
            "yyyymmdd",
            "ddmmyy",
            "ddmmyyyy",
            "mmddyy",
            "mmddyyyy",
            "None"});
            this.DateFormat.Location = new System.Drawing.Point(68, 22);
            this.DateFormat.Name = "DateFormat";
            this.DateFormat.Size = new System.Drawing.Size(80, 21);
            this.DateFormat.TabIndex = 4;
            this.DateFormat.Text = "yyyymmdd";
            // 
            // DelimiterDate
            // 
            this.DelimiterDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DelimiterDate.FormattingEnabled = true;
            this.DelimiterDate.Items.AddRange(new object[] {
            "/",
            "-",
            ".",
            "Space",
            "None"});
            this.DelimiterDate.Location = new System.Drawing.Point(68, 52);
            this.DelimiterDate.Name = "DelimiterDate";
            this.DelimiterDate.Size = new System.Drawing.Size(80, 21);
            this.DelimiterDate.TabIndex = 5;
            // 
            // TimeFormat
            // 
            this.TimeFormat.FormattingEnabled = true;
            this.TimeFormat.Items.AddRange(new object[] {
            "hhmmss 24hr",
            "hhmmss 12hr",
            "None"});
            this.TimeFormat.Location = new System.Drawing.Point(218, 22);
            this.TimeFormat.Name = "TimeFormat";
            this.TimeFormat.Size = new System.Drawing.Size(90, 21);
            this.TimeFormat.TabIndex = 6;
            this.TimeFormat.Text = "hhmmss 24hr";
            // 
            // DelimiterTime
            // 
            this.DelimiterTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DelimiterTime.FormattingEnabled = true;
            this.DelimiterTime.Items.AddRange(new object[] {
            ":",
            ".",
            "Space",
            "None"});
            this.DelimiterTime.Location = new System.Drawing.Point(218, 52);
            this.DelimiterTime.Name = "DelimiterTime";
            this.DelimiterTime.Size = new System.Drawing.Size(90, 21);
            this.DelimiterTime.TabIndex = 7;
            // 
            // ucLeadingText1
            // 
            this.ucLeadingText1.Location = new System.Drawing.Point(308, 19);
            this.ucLeadingText1.Name = "ucLeadingText1";
            this.ucLeadingText1.RTCCaption = "Leading";
            this.ucLeadingText1.RTCCaptionWidth = 51F;
            this.ucLeadingText1.RTCSBItem = null;
            this.ucLeadingText1.Size = new System.Drawing.Size(231, 29);
            this.ucLeadingText1.TabIndex = 8;
            // 
            // ucTrallingText1
            // 
            this.ucTrallingText1.Location = new System.Drawing.Point(308, 48);
            this.ucTrallingText1.Name = "ucTrallingText1";
            this.ucTrallingText1.RTCCaption = "Tralling";
            this.ucTrallingText1.RTCCaptionWidth = 51F;
            this.ucTrallingText1.RTCSBItem = null;
            this.ucTrallingText1.Size = new System.Drawing.Size(231, 29);
            this.ucTrallingText1.TabIndex = 9;
            // 
            // UseDecimalPlaces
            // 
            this.UseDecimalPlaces.AutoSize = true;
            this.UseDecimalPlaces.Location = new System.Drawing.Point(154, 80);
            this.UseDecimalPlaces.Name = "UseDecimalPlaces";
            this.UseDecimalPlaces.Size = new System.Drawing.Size(99, 17);
            this.UseDecimalPlaces.TabIndex = 10;
            this.UseDecimalPlaces.Text = "Decimal Places";
            this.UseDecimalPlaces.UseVisualStyleBackColor = true;
            // 
            // DecimalPlaces
            // 
            this.DecimalPlaces.Location = new System.Drawing.Point(260, 79);
            this.DecimalPlaces.Name = "DecimalPlaces";
            this.DecimalPlaces.Size = new System.Drawing.Size(48, 20);
            this.DecimalPlaces.TabIndex = 11;
            this.DecimalPlaces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DecimalPlaces.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ucConfigureDateTimeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucConfigureDateTimeInput";
            this.RTCCaption = "Configure Date Time Input";
            this.Size = new System.Drawing.Size(545, 107);
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ucTrallingText ucTrallingText1;
        public ucLeadingText ucLeadingText1;
        public System.Windows.Forms.ComboBox DelimiterTime;
        public System.Windows.Forms.ComboBox TimeFormat;
        public System.Windows.Forms.ComboBox DelimiterDate;
        public System.Windows.Forms.ComboBox DateFormat;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown DecimalPlaces;
        public System.Windows.Forms.CheckBox UseDecimalPlaces;
    }
}
