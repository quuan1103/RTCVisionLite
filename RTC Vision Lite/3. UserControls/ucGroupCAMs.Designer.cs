
namespace RTC_Vision_Lite.UserControls
{
    partial class ucGroupCAMs
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
            this.LayoutCAM_Maximize = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCAMName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPassFail = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.LayoutCAM = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutCAM_Maximize.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutCAM_Maximize
            // 
            this.LayoutCAM_Maximize.BackColor = System.Drawing.Color.Black;
            this.LayoutCAM_Maximize.ColumnCount = 2;
            this.LayoutCAM_Maximize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.73899F));
            this.LayoutCAM_Maximize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.26101F));
            this.LayoutCAM_Maximize.Controls.Add(this.panel2, 0, 0);
            this.LayoutCAM_Maximize.Controls.Add(this.panel1, 1, 0);
            this.LayoutCAM_Maximize.Controls.Add(this.LayoutCAM, 0, 1);
            this.LayoutCAM_Maximize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutCAM_Maximize.Location = new System.Drawing.Point(0, 0);
            this.LayoutCAM_Maximize.Name = "LayoutCAM_Maximize";
            this.LayoutCAM_Maximize.RowCount = 2;
            this.LayoutCAM_Maximize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.771987F));
            this.LayoutCAM_Maximize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.22801F));
            this.LayoutCAM_Maximize.Size = new System.Drawing.Size(516, 307);
            this.LayoutCAM_Maximize.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.lblCAMName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(95, 23);
            this.panel2.TabIndex = 1;
            // 
            // lblCAMName
            // 
            this.lblCAMName.AutoSize = true;
            this.lblCAMName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCAMName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCAMName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCAMName.Location = new System.Drawing.Point(0, 0);
            this.lblCAMName.Margin = new System.Windows.Forms.Padding(3);
            this.lblCAMName.Name = "lblCAMName";
            this.lblCAMName.Padding = new System.Windows.Forms.Padding(3);
            this.lblCAMName.Size = new System.Drawing.Size(93, 25);
            this.lblCAMName.TabIndex = 0;
            this.lblCAMName.Text = "CAMERA 01";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btnPassFail);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnMaximize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(104, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 23);
            this.panel1.TabIndex = 0;
            // 
            // btnPassFail
            // 
            this.btnPassFail.BackColor = System.Drawing.Color.Green;
            this.btnPassFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassFail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassFail.ForeColor = System.Drawing.Color.Transparent;
            this.btnPassFail.Location = new System.Drawing.Point(176, 0);
            this.btnPassFail.Name = "btnPassFail";
            this.btnPassFail.Size = new System.Drawing.Size(28, 23);
            this.btnPassFail.TabIndex = 0;
            this.btnPassFail.Text = "P";
            this.btnPassFail.UseVisualStyleBackColor = false;
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.DimGray;
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Image = global::RTC_Vision_Lite.Properties.Resources.Pause_16x16;
            this.btnPause.Location = new System.Drawing.Point(210, 0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(28, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.UseVisualStyleBackColor = false;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.Transparent;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x16;
            this.btnRun.Location = new System.Drawing.Point(244, 0);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(28, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.UseVisualStyleBackColor = false;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Image = global::RTC_Vision_Lite.Properties.Resources.ModelEditor_Settings;
            this.btnSetting.Location = new System.Drawing.Point(278, 0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(28, 23);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.UseVisualStyleBackColor = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Location = new System.Drawing.Point(312, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 23);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::RTC_Vision_Lite.Properties.Resources.Cancel_16x16;
            this.btnClose.Location = new System.Drawing.Point(381, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnMaximize
            // 
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.Location = new System.Drawing.Point(346, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(28, 23);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // LayoutCAM
            // 
            this.LayoutCAM.ColumnCount = 1;
            this.LayoutCAM_Maximize.SetColumnSpan(this.LayoutCAM, 2);
            this.LayoutCAM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutCAM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutCAM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutCAM.Location = new System.Drawing.Point(3, 32);
            this.LayoutCAM.Name = "LayoutCAM";
            this.LayoutCAM.RowCount = 1;
            this.LayoutCAM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutCAM.Size = new System.Drawing.Size(510, 272);
            this.LayoutCAM.TabIndex = 2;
            // 
            // ucGroupCAMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutCAM_Maximize);
            this.Name = "ucGroupCAMs";
            this.Size = new System.Drawing.Size(516, 307);
            this.LayoutCAM_Maximize.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutCAM_Maximize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCAMName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel LayoutCAM;
        public System.Windows.Forms.Button btnPassFail;
        public System.Windows.Forms.Button btnPause;
        public System.Windows.Forms.Button btnRun;
        public System.Windows.Forms.Button btnSetting;
        public System.Windows.Forms.Button btnMinimize;
        public System.Windows.Forms.Button btnMaximize;
        public System.Windows.Forms.Button btnClose;
    }
}
