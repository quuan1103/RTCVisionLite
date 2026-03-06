
namespace RTC_Vision_Lite.UserControls
{
    partial class ucCAM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCAM));
            this.btnStop = new System.Windows.Forms.Button();
            this.lblCycleTime = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.picImageMode = new System.Windows.Forms.PictureBox();
            this.lblCamName = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRunNext = new System.Windows.Forms.Button();
            this.btnRunCurrent = new System.Windows.Forms.Button();
            this.btnRunBack = new System.Windows.Forms.Button();
            this.btnLive = new System.Windows.Forms.Button();
            this.btnStopLive = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnNG = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblTotalCounter = new System.Windows.Forms.Label();
            this.lblNGCounter = new System.Windows.Forms.Label();
            this.lblOKCounter = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.SmartWindow = new GraphicsWindow.GraphicsWindow();
            ((System.ComponentModel.ISupportInitialize)(this.picImageMode)).BeginInit();
            this.tlpFooter.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmartWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = true;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = global::RTC_Vision_Lite.Properties.Resources.Stop_16x16;
            this.btnStop.Location = new System.Drawing.Point(334, 0);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(28, 25);
            this.btnStop.TabIndex = 4;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblCycleTime
            // 
            this.lblCycleTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCycleTime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCycleTime.Location = new System.Drawing.Point(13, 0);
            this.lblCycleTime.Name = "lblCycleTime";
            this.lblCycleTime.Size = new System.Drawing.Size(281, 25);
            this.lblCycleTime.TabIndex = 3;
            this.lblCycleTime.Text = "T: 3s - Rc: 0";
            this.lblCycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCycleTime.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnRun
            // 
            this.btnRun.FlatAppearance.BorderSize = 0;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x16;
            this.btnRun.Location = new System.Drawing.Point(300, 0);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(28, 25);
            this.btnRun.TabIndex = 2;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Image = global::RTC_Vision_Lite.Properties.Resources.Settings16x16;
            this.btnSetting.Location = new System.Drawing.Point(368, 0);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(24, 25);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.AutoSize = true;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::RTC_Vision_Lite.Properties.Resources.Minimize16x16;
            this.btnMinimize.Location = new System.Drawing.Point(398, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 25);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Visible = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.AutoSize = true;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = global::RTC_Vision_Lite.Properties.Resources.Maximize16x16;
            this.btnMaximize.Location = new System.Drawing.Point(432, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(34, 25);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // picImageMode
            // 
            this.picImageMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.picImageMode.Location = new System.Drawing.Point(3, 3);
            this.picImageMode.Name = "picImageMode";
            this.picImageMode.Size = new System.Drawing.Size(39, 19);
            this.picImageMode.TabIndex = 2;
            this.picImageMode.TabStop = false;
            // 
            // lblCamName
            // 
            this.lblCamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamName.ForeColor = System.Drawing.Color.Yellow;
            this.lblCamName.Location = new System.Drawing.Point(48, 0);
            this.lblCamName.Name = "lblCamName";
            this.lblCamName.Size = new System.Drawing.Size(234, 25);
            this.lblCamName.TabIndex = 2;
            this.lblCamName.Text = "Cam Name";
            this.lblCamName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCamName.Click += new System.EventHandler(this.lblCamName_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PC20x201.png");
            this.imageList1.Images.SetKeyName(1, "Camera20x203.png");
            // 
            // tlpFooter
            // 
            this.tlpFooter.ColumnCount = 2;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Controls.Add(this.lblCoordinates, 0, 0);
            this.tlpFooter.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpFooter.Location = new System.Drawing.Point(0, 0);
            this.tlpFooter.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFooter.Size = new System.Drawing.Size(791, 25);
            this.tlpFooter.TabIndex = 2;
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.ForeColor = System.Drawing.Color.White;
            this.lblCoordinates.Location = new System.Drawing.Point(3, 6);
            this.lblCoordinates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(153, 13);
            this.lblCoordinates.TabIndex = 0;
            this.lblCoordinates.Text = "X: 526.65 Y: 355.25 - I: 100.00";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnRunNext);
            this.flowLayoutPanel1.Controls.Add(this.btnRunCurrent);
            this.flowLayoutPanel1.Controls.Add(this.btnRunBack);
            this.flowLayoutPanel1.Controls.Add(this.btnLive);
            this.flowLayoutPanel1.Controls.Add(this.btnStopLive);
            this.flowLayoutPanel1.Controls.Add(this.btnSnap);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveImage);
            this.flowLayoutPanel1.Controls.Add(this.btnMove);
            this.flowLayoutPanel1.Controls.Add(this.btnNG);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalCounter);
            this.flowLayoutPanel1.Controls.Add(this.lblNGCounter);
            this.flowLayoutPanel1.Controls.Add(this.lblOKCounter);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(162, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(626, 23);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnRunNext
            // 
            this.btnRunNext.FlatAppearance.BorderSize = 0;
            this.btnRunNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunNext.Image = global::RTC_Vision_Lite.Properties.Resources.btnRunNext_ImageOptions_Image;
            this.btnRunNext.Location = new System.Drawing.Point(603, 0);
            this.btnRunNext.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnRunNext.Name = "btnRunNext";
            this.btnRunNext.Size = new System.Drawing.Size(20, 19);
            this.btnRunNext.TabIndex = 17;
            this.btnRunNext.UseVisualStyleBackColor = true;
            // 
            // btnRunCurrent
            // 
            this.btnRunCurrent.FlatAppearance.BorderSize = 0;
            this.btnRunCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunCurrent.Image = global::RTC_Vision_Lite.Properties.Resources.btnRunCurrent_ImageOptions_Image;
            this.btnRunCurrent.Location = new System.Drawing.Point(577, 0);
            this.btnRunCurrent.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnRunCurrent.Name = "btnRunCurrent";
            this.btnRunCurrent.Size = new System.Drawing.Size(20, 19);
            this.btnRunCurrent.TabIndex = 16;
            this.btnRunCurrent.UseVisualStyleBackColor = true;
            // 
            // btnRunBack
            // 
            this.btnRunBack.FlatAppearance.BorderSize = 0;
            this.btnRunBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunBack.Image = global::RTC_Vision_Lite.Properties.Resources.btnRunBack_ImageOptions_Image;
            this.btnRunBack.Location = new System.Drawing.Point(551, 0);
            this.btnRunBack.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnRunBack.Name = "btnRunBack";
            this.btnRunBack.Size = new System.Drawing.Size(20, 19);
            this.btnRunBack.TabIndex = 15;
            this.btnRunBack.UseVisualStyleBackColor = true;
            // 
            // btnLive
            // 
            this.btnLive.FlatAppearance.BorderSize = 0;
            this.btnLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLive.Image = global::RTC_Vision_Lite.Properties.Resources.LiveCam16x161;
            this.btnLive.Location = new System.Drawing.Point(525, 0);
            this.btnLive.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(20, 19);
            this.btnLive.TabIndex = 14;
            this.btnLive.UseVisualStyleBackColor = true;
            // 
            // btnStopLive
            // 
            this.btnStopLive.FlatAppearance.BorderSize = 0;
            this.btnStopLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopLive.Image = global::RTC_Vision_Lite.Properties.Resources.stoplive16x16;
            this.btnStopLive.Location = new System.Drawing.Point(499, 0);
            this.btnStopLive.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnStopLive.Name = "btnStopLive";
            this.btnStopLive.Size = new System.Drawing.Size(20, 19);
            this.btnStopLive.TabIndex = 13;
            this.btnStopLive.UseVisualStyleBackColor = true;
            // 
            // btnSnap
            // 
            this.btnSnap.FlatAppearance.BorderSize = 0;
            this.btnSnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnap.Image = global::RTC_Vision_Lite.Properties.Resources.Image_16x16;
            this.btnSnap.Location = new System.Drawing.Point(473, 0);
            this.btnSnap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(20, 19);
            this.btnSnap.TabIndex = 12;
            this.btnSnap.UseVisualStyleBackColor = true;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.FlatAppearance.BorderSize = 0;
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImage.Image = global::RTC_Vision_Lite.Properties.Resources.SaveImage;
            this.btnSaveImage.Location = new System.Drawing.Point(447, 0);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(20, 19);
            this.btnSaveImage.TabIndex = 11;
            this.btnSaveImage.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.FlatAppearance.BorderSize = 0;
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove.Image = global::RTC_Vision_Lite.Properties.Resources.SwitchRowColumn_16x16;
            this.btnMove.Location = new System.Drawing.Point(421, 0);
            this.btnMove.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(20, 19);
            this.btnMove.TabIndex = 10;
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnNG
            // 
            this.btnNG.FlatAppearance.BorderSize = 0;
            this.btnNG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNG.Image = global::RTC_Vision_Lite.Properties.Resources.NG16x16;
            this.btnNG.Location = new System.Drawing.Point(395, 0);
            this.btnNG.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnNG.Name = "btnNG";
            this.btnNG.Size = new System.Drawing.Size(20, 19);
            this.btnNG.TabIndex = 9;
            this.btnNG.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::RTC_Vision_Lite.Properties.Resources.OK16x16;
            this.btnOK.Location = new System.Drawing.Point(369, 0);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(20, 19);
            this.btnOK.TabIndex = 8;
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblTotalCounter
            // 
            this.lblTotalCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCounter.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalCounter.Image = global::RTC_Vision_Lite.Properties.Resources.Reset2_16x16;
            this.lblTotalCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalCounter.Location = new System.Drawing.Point(253, 0);
            this.lblTotalCounter.Name = "lblTotalCounter";
            this.lblTotalCounter.Size = new System.Drawing.Size(110, 20);
            this.lblTotalCounter.TabIndex = 5;
            this.lblTotalCounter.Text = "TOTAL: 0";
            this.lblTotalCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNGCounter
            // 
            this.lblNGCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNGCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNGCounter.ForeColor = System.Drawing.Color.Red;
            this.lblNGCounter.Location = new System.Drawing.Point(167, 0);
            this.lblNGCounter.Name = "lblNGCounter";
            this.lblNGCounter.Size = new System.Drawing.Size(80, 20);
            this.lblNGCounter.TabIndex = 6;
            this.lblNGCounter.Text = "NG: 0 (0%)";
            this.lblNGCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOKCounter
            // 
            this.lblOKCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOKCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOKCounter.ForeColor = System.Drawing.Color.Lime;
            this.lblOKCounter.Location = new System.Drawing.Point(78, 0);
            this.lblOKCounter.Name = "lblOKCounter";
            this.lblOKCounter.Size = new System.Drawing.Size(83, 20);
            this.lblOKCounter.TabIndex = 7;
            this.lblOKCounter.Text = "OK: 0 (0%)";
            this.lblOKCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.tlpFooter);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 302);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(791, 25);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tlpHeader);
            this.panel5.Controls.Add(this.SmartWindow);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(791, 302);
            this.panel5.TabIndex = 5;
            // 
            // tlpHeader
            // 
            this.tlpHeader.BackColor = System.Drawing.Color.DimGray;
            this.tlpHeader.ColumnCount = 2;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpHeader.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tlpHeader.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(791, 33);
            this.tlpHeader.TabIndex = 6;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.picImageMode);
            this.flowLayoutPanel3.Controls.Add(this.lblCamName);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(310, 33);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnMaximize);
            this.flowLayoutPanel2.Controls.Add(this.btnMinimize);
            this.flowLayoutPanel2.Controls.Add(this.btnSetting);
            this.flowLayoutPanel2.Controls.Add(this.btnStop);
            this.flowLayoutPanel2.Controls.Add(this.btnRun);
            this.flowLayoutPanel2.Controls.Add(this.lblCycleTime);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(319, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(469, 27);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // SmartWindow
            // 
            this.SmartWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SmartWindow.BackColor = System.Drawing.Color.Black;
            this.SmartWindow.FitImage = true;
            this.SmartWindow.GetXY = ((System.Drawing.PointF)(resources.GetObject("SmartWindow.GetXY")));
            this.SmartWindow.KeySelect = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.SmartWindow.Location = new System.Drawing.Point(-1, 31);
            this.SmartWindow.LockRoi = false;
            this.SmartWindow.MoveImage = false;
            this.SmartWindow.Name = "SmartWindow";
            this.SmartWindow.Size = new System.Drawing.Size(789, 271);
            this.SmartWindow.TabIndex = 1;
            this.SmartWindow.TabStop = false;
            this.SmartWindow.ZoomClick = false;
            this.SmartWindow.ZoomIN = true;
            this.SmartWindow.ZoomMouseWheel = true;
            this.SmartWindow.ZoomOut = true;
            this.SmartWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SmartWindow_MouseMove);
            // 
            // ucCAM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Name = "ucCAM";
            this.Size = new System.Drawing.Size(791, 327);
            ((System.ComponentModel.ISupportInitialize)(this.picImageMode)).EndInit();
            this.tlpFooter.ResumeLayout(false);
            this.tlpFooter.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmartWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Label lblCamName;
        public System.Windows.Forms.Button btnRun;
        public System.Windows.Forms.Button btnSetting;
        public System.Windows.Forms.Button btnMinimize;
        public System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.PictureBox picImageMode;
        public System.Windows.Forms.Label lblCycleTime;
        public System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Label lblTotalCounter;
        public System.Windows.Forms.Label lblNGCounter;
        public System.Windows.Forms.Label lblOKCounter;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNG;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.Button btnStopLive;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Button btnRunBack;
        private System.Windows.Forms.Button btnRunCurrent;
        private System.Windows.Forms.Button btnRunNext;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        public GraphicsWindow.GraphicsWindow SmartWindow;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
    }
}
