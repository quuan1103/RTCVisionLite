
namespace RTC_Vision_Lite.UserControls
{
    partial class ucProgramName
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
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnProgramChoose = new System.Windows.Forms.Button();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.tlpLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 3;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLayout.Controls.Add(this.btnProgramChoose, 2, 0);
            this.tlpLayout.Controls.Add(this.cbValue, 1, 0);
            this.tlpLayout.Controls.Add(this.lblCaption, 0, 0);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpLayout.Margin = new System.Windows.Forms.Padding(4);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 1;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Size = new System.Drawing.Size(400, 33);
            this.tlpLayout.TabIndex = 0;
            // 
            // btnProgramChoose
            // 
            this.btnProgramChoose.Location = new System.Drawing.Point(364, 4);
            this.btnProgramChoose.Margin = new System.Windows.Forms.Padding(4);
            this.btnProgramChoose.Name = "btnProgramChoose";
            this.btnProgramChoose.Size = new System.Drawing.Size(32, 25);
            this.btnProgramChoose.TabIndex = 0;
            this.btnProgramChoose.Text = "...";
            this.btnProgramChoose.UseVisualStyleBackColor = true;
            this.btnProgramChoose.Click += new System.EventHandler(this.btnProgramChoose_Click);
            // 
            // cbValue
            // 
            this.cbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(137, 4);
            this.cbValue.Margin = new System.Windows.Forms.Padding(4);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(219, 24);
            this.cbValue.TabIndex = 1;
            this.cbValue.SelectedIndexChanged += new System.EventHandler(this.cbValue_SelectedIndexChanged);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(4, 0);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(125, 33);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Program Name";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucProgramName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucProgramName";
            this.Size = new System.Drawing.Size(400, 33);
            this.tlpLayout.ResumeLayout(false);
            this.tlpLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.Button btnProgramChoose;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label lblCaption;
    }
}
