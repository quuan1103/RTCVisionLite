
namespace RTC_Vision_Lite.UserControls
{
    partial class ucLine
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLine));
            this.stateicon = new System.Windows.Forms.ImageList(this.components);
            this.labelControl2 = new System.Windows.Forms.Label();
            this.labelControl1 = new System.Windows.Forms.Label();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.lblRef = new System.Windows.Forms.Label();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.labelControl3 = new System.Windows.Forms.Label();
            this.labelControl4 = new System.Windows.Forms.Label();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stateicon
            // 
            this.stateicon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateicon.ImageStream")));
            this.stateicon.TransparentColor = System.Drawing.Color.Transparent;
            this.stateicon.Images.SetKeyName(0, "Input");
            this.stateicon.Images.SetKeyName(1, "Output");
            this.stateicon.Images.SetKeyName(2, "Link");
            this.stateicon.Images.SetKeyName(3, "System");
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(145, 11);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 18);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Y1:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 10);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 18);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "X1:";
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(31, 7);
            this.txtX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(109, 22);
            this.txtX1.TabIndex = 10;
            this.txtX1.Text = "0";
            this.txtX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtX1.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(172, 6);
            this.txtY1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(107, 22);
            this.txtY1.TabIndex = 11;
            this.txtY1.Text = "0";
            this.txtY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtY1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtY1.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // lblRef
            // 
            this.lblRef.Location = new System.Drawing.Point(148, 54);
            this.lblRef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(141, 16);
            this.lblRef.TabIndex = 9;
            this.lblRef.Text = "Source:";
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Image = global::RTC_Vision_Lite.Properties.Resources.Remove_16x16;
            this.btnRemoveLink.Location = new System.Drawing.Point(106, 48);
            this.btnRemoveLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(33, 25);
            this.btnRemoveLink.TabIndex = 8;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(32, 48);
            this.btnLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(67, 25);
            this.btnLink.TabIndex = 7;
            this.btnLink.Text = "Link";
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(429, 10);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 22);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Y2:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(283, 10);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 20);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "X2:";
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(311, 6);
            this.txtX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(109, 22);
            this.txtX2.TabIndex = 14;
            this.txtX2.Text = "0";
            this.txtX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtX2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtX2.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(459, 7);
            this.txtY2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(107, 22);
            this.txtY2.TabIndex = 15;
            this.txtY2.Text = "0";
            this.txtY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtY2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtY2.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // ucLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtX2);
            this.Controls.Add(this.txtY2);
            this.Controls.Add(this.txtX1);
            this.Controls.Add(this.txtY1);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.btnRemoveLink);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucLine";
            this.Size = new System.Drawing.Size(667, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList stateicon;
        private System.Windows.Forms.Label labelControl2;
        private System.Windows.Forms.Label labelControl1;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Label labelControl3;
        private System.Windows.Forms.Label labelControl4;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.TextBox txtY2;
    }
}
