namespace RTC_Vision_Lite.UserControls
{
    partial class ucInputDelimiterStringBulderItem
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.cbStandardListDelimiter = new System.Windows.Forms.ComboBox();
            this.RadStandardListDelimiter = new System.Windows.Forms.RadioButton();
            this.RadCustomListDelimiter = new System.Windows.Forms.RadioButton();
            this.txtCustomListDelimiter = new System.Windows.Forms.TextBox();
            this.btnCustomListDelimiter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(10, 3);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(107, 13);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "List Element Delimiter";
            // 
            // cbStandardListDelimiter
            // 
            this.cbStandardListDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStandardListDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStandardListDelimiter.FormattingEnabled = true;
            this.cbStandardListDelimiter.Items.AddRange(new object[] {
            "None",
            "Comma",
            "Space",
            "Tab",
            "Semicolon",
            "Underscore"});
            this.cbStandardListDelimiter.Location = new System.Drawing.Point(91, 19);
            this.cbStandardListDelimiter.Name = "cbStandardListDelimiter";
            this.cbStandardListDelimiter.Size = new System.Drawing.Size(140, 21);
            this.cbStandardListDelimiter.TabIndex = 1;
            this.cbStandardListDelimiter.SelectedIndexChanged += new System.EventHandler(this.cbStandard_SelectedIndexChanged);
            // 
            // RadStandardListDelimiter
            // 
            this.RadStandardListDelimiter.AutoSize = true;
            this.RadStandardListDelimiter.Location = new System.Drawing.Point(23, 19);
            this.RadStandardListDelimiter.Name = "RadStandardListDelimiter";
            this.RadStandardListDelimiter.Size = new System.Drawing.Size(62, 17);
            this.RadStandardListDelimiter.TabIndex = 2;
            this.RadStandardListDelimiter.Text = "Stanard";
            this.RadStandardListDelimiter.UseVisualStyleBackColor = true;
            this.RadStandardListDelimiter.CheckedChanged += new System.EventHandler(this.RadStandard_CheckedChanged);
            this.RadStandardListDelimiter.Validating += new System.ComponentModel.CancelEventHandler(this.RadStandardListDelimiter_Validating);
            // 
            // RadCustomListDelimiter
            // 
            this.RadCustomListDelimiter.AutoSize = true;
            this.RadCustomListDelimiter.Location = new System.Drawing.Point(23, 42);
            this.RadCustomListDelimiter.Name = "RadCustomListDelimiter";
            this.RadCustomListDelimiter.Size = new System.Drawing.Size(60, 17);
            this.RadCustomListDelimiter.TabIndex = 3;
            this.RadCustomListDelimiter.Text = "Custom";
            this.RadCustomListDelimiter.UseVisualStyleBackColor = true;
            this.RadCustomListDelimiter.CheckedChanged += new System.EventHandler(this.RadCustom_CheckedChanged);
            this.RadCustomListDelimiter.Validating += new System.ComponentModel.CancelEventHandler(this.RadCustomListDelimiter_Validating);
            // 
            // txtCustomListDelimiter
            // 
            this.txtCustomListDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomListDelimiter.Location = new System.Drawing.Point(91, 44);
            this.txtCustomListDelimiter.Name = "txtCustomListDelimiter";
            this.txtCustomListDelimiter.Size = new System.Drawing.Size(114, 20);
            this.txtCustomListDelimiter.TabIndex = 4;
            // 
            // btnCustomListDelimiter
            // 
            this.btnCustomListDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomListDelimiter.Location = new System.Drawing.Point(206, 43);
            this.btnCustomListDelimiter.Name = "btnCustomListDelimiter";
            this.btnCustomListDelimiter.Size = new System.Drawing.Size(25, 22);
            this.btnCustomListDelimiter.TabIndex = 5;
            this.btnCustomListDelimiter.Text = "...";
            this.btnCustomListDelimiter.UseVisualStyleBackColor = true;
            // 
            // ucInputDelimiterStringBulderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCustomListDelimiter);
            this.Controls.Add(this.txtCustomListDelimiter);
            this.Controls.Add(this.RadCustomListDelimiter);
            this.Controls.Add(this.RadStandardListDelimiter);
            this.Controls.Add(this.cbStandardListDelimiter);
            this.Controls.Add(this.lblCaption);
            this.Name = "ucInputDelimiterStringBulderItem";
            this.Size = new System.Drawing.Size(244, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ComboBox cbStandardListDelimiter;
        private System.Windows.Forms.RadioButton RadStandardListDelimiter;
        private System.Windows.Forms.RadioButton RadCustomListDelimiter;
        private System.Windows.Forms.TextBox txtCustomListDelimiter;
        private System.Windows.Forms.Button btnCustomListDelimiter;
    }
}
