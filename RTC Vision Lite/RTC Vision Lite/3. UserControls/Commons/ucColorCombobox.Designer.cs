namespace RTC_Vision_Lite._3._UserControls.Commons
{
    partial class ucColorCombobox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucColorCombobox));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureColor = new System.Windows.Forms.PictureBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListColor = new System.Windows.Forms.ImageList(this.components);
            this.mnuWhite = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCyan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPink = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGray = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaroon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNavy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViolet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRed = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYellow = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureColor)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.pictureColor, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.cbColor, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(521, 28);
            this.tableLayoutPanel.TabIndex = 9;
            // 
            // pictureColor
            // 
            this.pictureColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureColor.Location = new System.Drawing.Point(3, 3);
            this.pictureColor.Name = "pictureColor";
            this.pictureColor.Size = new System.Drawing.Size(20, 22);
            this.pictureColor.TabIndex = 0;
            this.pictureColor.TabStop = false;
            // 
            // cbColor
            // 
            this.cbColor.ContextMenuStrip = this.contextMenuStrip1;
            this.cbColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(29, 3);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(489, 22);
            this.cbColor.TabIndex = 1;
            this.cbColor.Click += new System.EventHandler(this.cbColor_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBlack,
            this.mnuWhite,
            this.mnuCyan,
            this.mnuBlue,
            this.mnuPink,
            this.mnuGray,
            this.mnuGreen,
            this.mnuMaroon,
            this.mnuNavy,
            this.mnuViolet,
            this.mnuRed,
            this.mnuTail,
            this.mnuYellow});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 290);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // mnuBlack
            // 
            this.mnuBlack.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnuBlack.Image = global::RTC_Vision_Lite.Properties.Resources._2021_12_19_131017;
            this.mnuBlack.Name = "mnuBlack";
            this.mnuBlack.Size = new System.Drawing.Size(180, 22);
            this.mnuBlack.Text = "Black";
            // 
            // imageListColor
            // 
            this.imageListColor.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListColor.ImageStream")));
            this.imageListColor.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListColor.Images.SetKeyName(0, "Black");
            this.imageListColor.Images.SetKeyName(1, "White");
            this.imageListColor.Images.SetKeyName(2, "Cyan");
            this.imageListColor.Images.SetKeyName(3, "Blue");
            this.imageListColor.Images.SetKeyName(4, "Pink");
            this.imageListColor.Images.SetKeyName(5, "Gray");
            this.imageListColor.Images.SetKeyName(6, "Green");
            this.imageListColor.Images.SetKeyName(7, "Maroon");
            this.imageListColor.Images.SetKeyName(8, "Navy");
            this.imageListColor.Images.SetKeyName(9, "Violet");
            this.imageListColor.Images.SetKeyName(10, "Red");
            this.imageListColor.Images.SetKeyName(11, "Teal");
            this.imageListColor.Images.SetKeyName(12, "Yellow");
            // 
            // mnuWhite
            // 
            this.mnuWhite.Name = "mnuWhite";
            this.mnuWhite.Size = new System.Drawing.Size(180, 22);
            this.mnuWhite.Text = "White";
            // 
            // mnuCyan
            // 
            this.mnuCyan.Name = "mnuCyan";
            this.mnuCyan.Size = new System.Drawing.Size(180, 22);
            this.mnuCyan.Text = "Cyan";
            // 
            // mnuBlue
            // 
            this.mnuBlue.Name = "mnuBlue";
            this.mnuBlue.Size = new System.Drawing.Size(180, 22);
            this.mnuBlue.Text = "Blue";
            // 
            // mnuPink
            // 
            this.mnuPink.Name = "mnuPink";
            this.mnuPink.Size = new System.Drawing.Size(180, 22);
            this.mnuPink.Text = "Pink";
            // 
            // mnuGray
            // 
            this.mnuGray.Name = "mnuGray";
            this.mnuGray.Size = new System.Drawing.Size(180, 22);
            this.mnuGray.Text = "Gray";
            // 
            // mnuGreen
            // 
            this.mnuGreen.Name = "mnuGreen";
            this.mnuGreen.Size = new System.Drawing.Size(180, 22);
            this.mnuGreen.Text = "Green";
            // 
            // mnuMaroon
            // 
            this.mnuMaroon.Name = "mnuMaroon";
            this.mnuMaroon.Size = new System.Drawing.Size(180, 22);
            this.mnuMaroon.Text = "Maroon";
            // 
            // mnuNavy
            // 
            this.mnuNavy.Name = "mnuNavy";
            this.mnuNavy.Size = new System.Drawing.Size(180, 22);
            this.mnuNavy.Text = "Navy";
            // 
            // mnuViolet
            // 
            this.mnuViolet.Name = "mnuViolet";
            this.mnuViolet.Size = new System.Drawing.Size(180, 22);
            this.mnuViolet.Text = "Violet";
            // 
            // mnuRed
            // 
            this.mnuRed.Name = "mnuRed";
            this.mnuRed.Size = new System.Drawing.Size(180, 22);
            this.mnuRed.Text = "Red";
            // 
            // mnuTail
            // 
            this.mnuTail.Name = "mnuTail";
            this.mnuTail.Size = new System.Drawing.Size(116, 22);
            this.mnuTail.Text = "Teal";
            // 
            // mnuYellow
            // 
            this.mnuYellow.Name = "mnuYellow";
            this.mnuYellow.Size = new System.Drawing.Size(116, 22);
            this.mnuYellow.Text = "Yellow";
            // 
            // ucColorCombobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ucColorCombobox";
            this.Size = new System.Drawing.Size(521, 255);
            this.Load += new System.EventHandler(this.ucColorCombobox_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureColor)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureColor;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuBlack;
        private System.Windows.Forms.ImageList imageListColor;
        private System.Windows.Forms.ToolStripMenuItem mnuWhite;
        private System.Windows.Forms.ToolStripMenuItem mnuCyan;
        private System.Windows.Forms.ToolStripMenuItem mnuBlue;
        private System.Windows.Forms.ToolStripMenuItem mnuPink;
        private System.Windows.Forms.ToolStripMenuItem mnuGray;
        private System.Windows.Forms.ToolStripMenuItem mnuGreen;
        private System.Windows.Forms.ToolStripMenuItem mnuMaroon;
        private System.Windows.Forms.ToolStripMenuItem mnuNavy;
        private System.Windows.Forms.ToolStripMenuItem mnuViolet;
        private System.Windows.Forms.ToolStripMenuItem mnuRed;
        private System.Windows.Forms.ToolStripMenuItem mnuTail;
        private System.Windows.Forms.ToolStripMenuItem mnuYellow;
    }
}
