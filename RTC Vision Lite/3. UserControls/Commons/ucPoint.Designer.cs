
namespace RTC_Vision_Lite.UserControls
{
    partial class ucPoint
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
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRef = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(41, 7);
            this.txtX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(107, 22);
            this.txtX.TabIndex = 1;
            this.txtX.Text = "0";
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtX_KeyDown);
            this.txtX.Validating += new System.ComponentModel.CancelEventHandler(this.txtX_Validating);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(175, 7);
            this.txtY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(107, 22);
            this.txtY.TabIndex = 3;
            this.txtY.Text = "0";
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtY_KeyDown);
            this.txtY.Validating += new System.ComponentModel.CancelEventHandler(this.txtY_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y:";
            // 
            // cbItems
            // 
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(311, 7);
            this.cbItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(81, 24);
            this.cbItems.TabIndex = 4;
            this.cbItems.SelectedIndexChanged += new System.EventHandler(this.cbItems_SelectedIndexChanged);
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(41, 39);
            this.btnLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(79, 28);
            this.btnLink.TabIndex = 5;
            this.btnLink.Text = "Link";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Image = global::RTC_Vision_Lite.Properties.Resources.Remove_16x16;
            this.btnRemoveLink.Location = new System.Drawing.Point(127, 39);
            this.btnRemoveLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(27, 28);
            this.btnRemoveLink.TabIndex = 6;
            this.btnRemoveLink.UseVisualStyleBackColor = true;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Location = new System.Drawing.Point(177, 46);
            this.lblRef.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(53, 16);
            this.lblRef.TabIndex = 7;
            this.lblRef.Text = "Source:";
            // 
            // ucPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.btnRemoveLink);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.cbItems);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucPoint";
            this.Size = new System.Drawing.Size(667, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRef;
    }
}
