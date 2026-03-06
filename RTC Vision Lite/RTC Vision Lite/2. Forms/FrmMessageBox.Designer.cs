
namespace RTC_Vision_Lite.Forms
{
    partial class FrmMessageBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageBox));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SmartWindow = new GraphicsWindow.GraphicsWindow();
            this.picMessage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerAutoClose = new System.Windows.Forms.Timer(this.components);
            this.lblTimeAutoClose = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmartWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMessage)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.27083F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.72916F));
            this.tableLayoutPanel1.Controls.Add(this.SmartWindow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picMessage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 141);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SmartWindow
            // 
            this.SmartWindow.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.SmartWindow, 2);
            this.SmartWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SmartWindow.FitImage = false;
            this.SmartWindow.GetXY = ((System.Drawing.PointF)(resources.GetObject("SmartWindow.GetXY")));
            this.SmartWindow.KeySelect = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.SmartWindow.Location = new System.Drawing.Point(3, 3);
            this.SmartWindow.MoveImage = false;
            this.SmartWindow.Name = "SmartWindow";
            this.SmartWindow.Size = new System.Drawing.Size(378, 5);
            this.SmartWindow.TabIndex = 2;
            this.SmartWindow.TabStop = false;
            this.SmartWindow.ZoomClick = false;
            this.SmartWindow.ZoomIN = false;
            this.SmartWindow.ZoomMouseWheel = false;
            this.SmartWindow.ZoomOut = false;
            // 
            // picMessage
            // 
            this.picMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMessage.Location = new System.Drawing.Point(3, 14);
            this.picMessage.Name = "picMessage";
            this.picMessage.Size = new System.Drawing.Size(68, 75);
            this.picMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMessage.TabIndex = 3;
            this.picMessage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(77, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 75);
            this.panel1.TabIndex = 4;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(3, 25);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(90, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message Content";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Information");
            this.imageList1.Images.SetKeyName(1, "Question");
            this.imageList1.Images.SetKeyName(2, "Warning");
            this.imageList1.Images.SetKeyName(3, "Error");
            // 
            // timerAutoClose
            // 
            this.timerAutoClose.Tick += new System.EventHandler(this.timerAutoClose_Tick);
            // 
            // lblTimeAutoClose
            // 
            this.lblTimeAutoClose.AutoSize = true;
            this.lblTimeAutoClose.Location = new System.Drawing.Point(9, 11);
            this.lblTimeAutoClose.Name = "lblTimeAutoClose";
            this.lblTimeAutoClose.Size = new System.Drawing.Size(72, 13);
            this.lblTimeAutoClose.TabIndex = 0;
            this.lblTimeAutoClose.Text = "Close After 3s";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(116, 6);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(60, 23);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "Retry";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(182, 6);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(60, 23);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "Yes";
            this.btn2.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(248, 6);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(60, 23);
            this.btn3.TabIndex = 1;
            this.btn3.Text = "No";
            this.btn3.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(314, 6);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(60, 23);
            this.btn4.TabIndex = 1;
            this.btn4.Text = "Cancel";
            this.btn4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.btn4);
            this.panel2.Controls.Add(this.btn3);
            this.panel2.Controls.Add(this.btn2);
            this.panel2.Controls.Add(this.btn1);
            this.panel2.Controls.Add(this.lblTimeAutoClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 34);
            this.panel2.TabIndex = 5;
            // 
            // FrmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 141);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessageBox";
            this.Text = "Notify ";
            this.Load += new System.EventHandler(this.FrmMessageBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMessageBox_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SmartWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMessage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public GraphicsWindow.GraphicsWindow SmartWindow;
        private System.Windows.Forms.PictureBox picMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerAutoClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label lblTimeAutoClose;
    }
}