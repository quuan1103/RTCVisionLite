namespace RTC_Vision_Lite.UserControls
{
    partial class ucInputDelimiter
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
            this.btnCustom = new System.Windows.Forms.Button();
            this.txtCustom = new System.Windows.Forms.TextBox();
            this.RadCustomList = new System.Windows.Forms.RadioButton();
            this.RadStandard = new System.Windows.Forms.RadioButton();
            this.cbStandard = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCustom
            // 
            this.btnCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustom.Location = new System.Drawing.Point(199, 43);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(25, 22);
            this.btnCustom.TabIndex = 11;
            this.btnCustom.Text = "...";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // txtCustom
            // 
            this.txtCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustom.Location = new System.Drawing.Point(84, 44);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(114, 20);
            this.txtCustom.TabIndex = 10;
            this.txtCustom.TextChanged += new System.EventHandler(this.txtCustom_EditValueChanged);
            // 
            // RadCustomList
            // 
            this.RadCustomList.AutoSize = true;
            this.RadCustomList.Location = new System.Drawing.Point(16, 42);
            this.RadCustomList.Name = "RadCustomList";
            this.RadCustomList.Size = new System.Drawing.Size(60, 17);
            this.RadCustomList.TabIndex = 9;
            this.RadCustomList.Text = "Custom";
            this.RadCustomList.UseVisualStyleBackColor = true;
            this.RadCustomList.CheckedChanged += new System.EventHandler(this.RadCustom_CheckedChanged);
            // 
            // RadStandard
            // 
            this.RadStandard.AutoSize = true;
            this.RadStandard.Checked = true;
            this.RadStandard.Location = new System.Drawing.Point(16, 19);
            this.RadStandard.Name = "RadStandard";
            this.RadStandard.Size = new System.Drawing.Size(62, 17);
            this.RadStandard.TabIndex = 8;
            this.RadStandard.TabStop = true;
            this.RadStandard.Text = "Stanard";
            this.RadStandard.UseVisualStyleBackColor = true;
            this.RadStandard.CheckedChanged += new System.EventHandler(this.RadStandard_CheckedChanged);
            // 
            // cbStandard
            // 
            this.cbStandard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStandard.FormattingEnabled = true;
            this.cbStandard.Items.AddRange(new object[] {
            "None",
            "Comma",
            "Space",
            "Tab",
            "Semicolon",
            "Underscore"});
            this.cbStandard.Location = new System.Drawing.Point(84, 19);
            this.cbStandard.Name = "cbStandard";
            this.cbStandard.Size = new System.Drawing.Size(140, 21);
            this.cbStandard.TabIndex = 7;
            this.cbStandard.SelectedIndexChanged += new System.EventHandler(this.cbStandard_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCustom);
            this.groupBox1.Controls.Add(this.txtCustom);
            this.groupBox1.Controls.Add(this.RadCustomList);
            this.groupBox1.Controls.Add(this.RadStandard);
            this.groupBox1.Controls.Add(this.cbStandard);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 75);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Delimiter";
            // 
            // ucInputDelimiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ucInputDelimiter";
            this.Size = new System.Drawing.Size(244, 75);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.TextBox txtCustom;
        private System.Windows.Forms.RadioButton RadCustomList;
        private System.Windows.Forms.RadioButton RadStandard;
        private System.Windows.Forms.ComboBox cbStandard;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
