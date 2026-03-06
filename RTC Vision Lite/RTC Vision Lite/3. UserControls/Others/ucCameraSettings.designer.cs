
namespace RTC_Vision_Lite.UserControls
{
    partial class ucCameraSettings
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
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tcMainSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkAcquisitionLineRate = new System.Windows.Forms.CheckBox();
            this.txtAcquisitionLineRate = new System.Windows.Forms.NumericUpDown();
            this.chkAcquisitionMode = new System.Windows.Forms.CheckBox();
            this.chkExposureMode = new System.Windows.Forms.CheckBox();
            this.chkGain = new System.Windows.Forms.CheckBox();
            this.chkExposureTime = new System.Windows.Forms.CheckBox();
            this.chkTriggerActivity = new System.Windows.Forms.CheckBox();
            this.chkTriggerSource = new System.Windows.Forms.CheckBox();
            this.chkTriggerMode = new System.Windows.Forms.CheckBox();
            this.chkTriggerDelay = new System.Windows.Forms.CheckBox();
            this.cbAcquisitionMode = new System.Windows.Forms.ComboBox();
            this.cbExposureMode = new System.Windows.Forms.ComboBox();
            this.txtGainRaw = new System.Windows.Forms.NumericUpDown();
            this.txtExposureTimeRaw = new System.Windows.Forms.NumericUpDown();
            this.cbTriggerActivation = new System.Windows.Forms.ComboBox();
            this.cbTriggerSource = new System.Windows.Forms.ComboBox();
            this.cbTriggerMode = new System.Windows.Forms.ComboBox();
            this.txtTriggerDelayRaw = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtBalanceBlue = new System.Windows.Forms.NumericUpDown();
            this.txtBalanceGreen = new System.Windows.Forms.NumericUpDown();
            this.txtBalanceRed = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkUseBalnceWhiteColor = new System.Windows.Forms.CheckBox();
            this.btnLoadDefault = new System.Windows.Forms.Button();
            this.btnSaveDefault = new System.Windows.Forms.Button();
            this.btnSetValue = new System.Windows.Forms.Button();
            this.btnRealValue = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbPixelFomat = new System.Windows.Forms.ComboBox();
            this.myTreeList1 = new RTC_Vision_Lite.UserControls.MyTreeList();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.tcMainSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcquisitionLineRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGainRaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExposureTimeRaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTriggerDelayRaw)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTreeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.CellEditUseWholeCell = false;
            this.treeListView1.HideSelection = false;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(121, 97);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            // 
            // treeView1
            // 
            this.treeView1.LineColor = System.Drawing.Color.Empty;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 0;
            // 
            // tcMainSettings
            // 
            this.tcMainSettings.Controls.Add(this.tabPage1);
            this.tcMainSettings.Controls.Add(this.tabPage2);
            this.tcMainSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcMainSettings.Location = new System.Drawing.Point(0, 0);
            this.tcMainSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tcMainSettings.Name = "tcMainSettings";
            this.tcMainSettings.SelectedIndex = 0;
            this.tcMainSettings.Size = new System.Drawing.Size(614, 203);
            this.tcMainSettings.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.chkAcquisitionLineRate);
            this.tabPage1.Controls.Add(this.txtAcquisitionLineRate);
            this.tabPage1.Controls.Add(this.chkAcquisitionMode);
            this.tabPage1.Controls.Add(this.chkExposureMode);
            this.tabPage1.Controls.Add(this.chkGain);
            this.tabPage1.Controls.Add(this.chkExposureTime);
            this.tabPage1.Controls.Add(this.chkTriggerActivity);
            this.tabPage1.Controls.Add(this.chkTriggerSource);
            this.tabPage1.Controls.Add(this.chkTriggerMode);
            this.tabPage1.Controls.Add(this.chkTriggerDelay);
            this.tabPage1.Controls.Add(this.cbAcquisitionMode);
            this.tabPage1.Controls.Add(this.cbExposureMode);
            this.tabPage1.Controls.Add(this.txtGainRaw);
            this.tabPage1.Controls.Add(this.txtExposureTimeRaw);
            this.tabPage1.Controls.Add(this.cbTriggerActivation);
            this.tabPage1.Controls.Add(this.cbTriggerSource);
            this.tabPage1.Controls.Add(this.cbTriggerMode);
            this.tabPage1.Controls.Add(this.txtTriggerDelayRaw);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(606, 177);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Common";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // chkAcquisitionLineRate
            // 
            this.chkAcquisitionLineRate.AutoSize = true;
            this.chkAcquisitionLineRate.Location = new System.Drawing.Point(7, 135);
            this.chkAcquisitionLineRate.Name = "chkAcquisitionLineRate";
            this.chkAcquisitionLineRate.Size = new System.Drawing.Size(126, 17);
            this.chkAcquisitionLineRate.TabIndex = 25;
            this.chkAcquisitionLineRate.Text = "Acquisition Line Rate";
            this.chkAcquisitionLineRate.UseVisualStyleBackColor = true;
            this.chkAcquisitionLineRate.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // txtAcquisitionLineRate
            // 
            this.txtAcquisitionLineRate.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtAcquisitionLineRate.Location = new System.Drawing.Point(144, 130);
            this.txtAcquisitionLineRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtAcquisitionLineRate.Name = "txtAcquisitionLineRate";
            this.txtAcquisitionLineRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcquisitionLineRate.Size = new System.Drawing.Size(161, 22);
            this.txtAcquisitionLineRate.TabIndex = 24;
            this.txtAcquisitionLineRate.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // chkAcquisitionMode
            // 
            this.chkAcquisitionMode.AutoSize = true;
            this.chkAcquisitionMode.Location = new System.Drawing.Point(316, 109);
            this.chkAcquisitionMode.Name = "chkAcquisitionMode";
            this.chkAcquisitionMode.Size = new System.Drawing.Size(107, 17);
            this.chkAcquisitionMode.TabIndex = 23;
            this.chkAcquisitionMode.Text = "Acquisition Mode";
            this.chkAcquisitionMode.UseVisualStyleBackColor = true;
            this.chkAcquisitionMode.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // chkExposureMode
            // 
            this.chkExposureMode.AutoSize = true;
            this.chkExposureMode.Location = new System.Drawing.Point(316, 81);
            this.chkExposureMode.Name = "chkExposureMode";
            this.chkExposureMode.Size = new System.Drawing.Size(97, 17);
            this.chkExposureMode.TabIndex = 22;
            this.chkExposureMode.Text = "ExposureMode";
            this.chkExposureMode.UseVisualStyleBackColor = true;
            this.chkExposureMode.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // chkGain
            // 
            this.chkGain.AutoSize = true;
            this.chkGain.Location = new System.Drawing.Point(316, 53);
            this.chkGain.Name = "chkGain";
            this.chkGain.Size = new System.Drawing.Size(48, 17);
            this.chkGain.TabIndex = 21;
            this.chkGain.Text = "Gain";
            this.chkGain.UseVisualStyleBackColor = true;
            this.chkGain.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // chkExposureTime
            // 
            this.chkExposureTime.AutoSize = true;
            this.chkExposureTime.Location = new System.Drawing.Point(316, 22);
            this.chkExposureTime.Name = "chkExposureTime";
            this.chkExposureTime.Size = new System.Drawing.Size(96, 17);
            this.chkExposureTime.TabIndex = 20;
            this.chkExposureTime.Text = "Exposure Time";
            this.chkExposureTime.UseVisualStyleBackColor = true;
            this.chkExposureTime.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // chkTriggerActivity
            // 
            this.chkTriggerActivity.AutoSize = true;
            this.chkTriggerActivity.Location = new System.Drawing.Point(7, 108);
            this.chkTriggerActivity.Name = "chkTriggerActivity";
            this.chkTriggerActivity.Size = new System.Drawing.Size(109, 17);
            this.chkTriggerActivity.TabIndex = 19;
            this.chkTriggerActivity.Text = "Trigger Activation";
            this.chkTriggerActivity.UseVisualStyleBackColor = true;
            this.chkTriggerActivity.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // chkTriggerSource
            // 
            this.chkTriggerSource.AutoSize = true;
            this.chkTriggerSource.Location = new System.Drawing.Point(7, 83);
            this.chkTriggerSource.Name = "chkTriggerSource";
            this.chkTriggerSource.Size = new System.Drawing.Size(96, 17);
            this.chkTriggerSource.TabIndex = 18;
            this.chkTriggerSource.Text = "Trigger Source";
            this.chkTriggerSource.UseVisualStyleBackColor = true;
            this.chkTriggerSource.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // chkTriggerMode
            // 
            this.chkTriggerMode.AutoSize = true;
            this.chkTriggerMode.Location = new System.Drawing.Point(7, 52);
            this.chkTriggerMode.Name = "chkTriggerMode";
            this.chkTriggerMode.Size = new System.Drawing.Size(89, 17);
            this.chkTriggerMode.TabIndex = 17;
            this.chkTriggerMode.Text = "Trigger Mode";
            this.chkTriggerMode.UseVisualStyleBackColor = true;
            this.chkTriggerMode.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // chkTriggerDelay
            // 
            this.chkTriggerDelay.AutoSize = true;
            this.chkTriggerDelay.Location = new System.Drawing.Point(7, 21);
            this.chkTriggerDelay.Name = "chkTriggerDelay";
            this.chkTriggerDelay.Size = new System.Drawing.Size(89, 17);
            this.chkTriggerDelay.TabIndex = 16;
            this.chkTriggerDelay.Text = "Trigger Delay";
            this.chkTriggerDelay.UseVisualStyleBackColor = true;
            this.chkTriggerDelay.CheckedChanged += new System.EventHandler(this.chkTriggerDelay_CheckedChanged);
            // 
            // cbAcquisitionMode
            // 
            this.cbAcquisitionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcquisitionMode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cbAcquisitionMode.FormattingEnabled = true;
            this.cbAcquisitionMode.Items.AddRange(new object[] {
            "Single Frame",
            "Multi Frame",
            "Continuous"});
            this.cbAcquisitionMode.Location = new System.Drawing.Point(434, 107);
            this.cbAcquisitionMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbAcquisitionMode.Name = "cbAcquisitionMode";
            this.cbAcquisitionMode.Size = new System.Drawing.Size(162, 21);
            this.cbAcquisitionMode.TabIndex = 15;
            // 
            // cbExposureMode
            // 
            this.cbExposureMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExposureMode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cbExposureMode.FormattingEnabled = true;
            this.cbExposureMode.Items.AddRange(new object[] {
            "Timed",
            "Trigger Width"});
            this.cbExposureMode.Location = new System.Drawing.Point(434, 79);
            this.cbExposureMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbExposureMode.Name = "cbExposureMode";
            this.cbExposureMode.Size = new System.Drawing.Size(162, 21);
            this.cbExposureMode.TabIndex = 14;
            // 
            // txtGainRaw
            // 
            this.txtGainRaw.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtGainRaw.Location = new System.Drawing.Point(434, 51);
            this.txtGainRaw.Margin = new System.Windows.Forms.Padding(2);
            this.txtGainRaw.Name = "txtGainRaw";
            this.txtGainRaw.Size = new System.Drawing.Size(161, 22);
            this.txtGainRaw.TabIndex = 13;
            this.txtGainRaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtExposureTimeRaw
            // 
            this.txtExposureTimeRaw.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtExposureTimeRaw.Location = new System.Drawing.Point(434, 21);
            this.txtExposureTimeRaw.Margin = new System.Windows.Forms.Padding(2);
            this.txtExposureTimeRaw.Name = "txtExposureTimeRaw";
            this.txtExposureTimeRaw.Size = new System.Drawing.Size(161, 22);
            this.txtExposureTimeRaw.TabIndex = 12;
            this.txtExposureTimeRaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbTriggerActivation
            // 
            this.cbTriggerActivation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTriggerActivation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cbTriggerActivation.FormattingEnabled = true;
            this.cbTriggerActivation.Items.AddRange(new object[] {
            "Rising Edge",
            "Falling Edge"});
            this.cbTriggerActivation.Location = new System.Drawing.Point(144, 105);
            this.cbTriggerActivation.Margin = new System.Windows.Forms.Padding(2);
            this.cbTriggerActivation.Name = "cbTriggerActivation";
            this.cbTriggerActivation.Size = new System.Drawing.Size(162, 21);
            this.cbTriggerActivation.TabIndex = 11;
            // 
            // cbTriggerSource
            // 
            this.cbTriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTriggerSource.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cbTriggerSource.FormattingEnabled = true;
            this.cbTriggerSource.Items.AddRange(new object[] {
            "Software",
            "Line 0",
            "Line 1",
            "Line 2",
            "Line 3",
            "Counter 0"});
            this.cbTriggerSource.Location = new System.Drawing.Point(144, 77);
            this.cbTriggerSource.Margin = new System.Windows.Forms.Padding(2);
            this.cbTriggerSource.Name = "cbTriggerSource";
            this.cbTriggerSource.Size = new System.Drawing.Size(162, 21);
            this.cbTriggerSource.TabIndex = 10;
            // 
            // cbTriggerMode
            // 
            this.cbTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTriggerMode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cbTriggerMode.FormattingEnabled = true;
            this.cbTriggerMode.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.cbTriggerMode.Location = new System.Drawing.Point(144, 49);
            this.cbTriggerMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbTriggerMode.Name = "cbTriggerMode";
            this.cbTriggerMode.Size = new System.Drawing.Size(162, 21);
            this.cbTriggerMode.TabIndex = 9;
            // 
            // txtTriggerDelayRaw
            // 
            this.txtTriggerDelayRaw.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtTriggerDelayRaw.Location = new System.Drawing.Point(144, 20);
            this.txtTriggerDelayRaw.Margin = new System.Windows.Forms.Padding(2);
            this.txtTriggerDelayRaw.Name = "txtTriggerDelayRaw";
            this.txtTriggerDelayRaw.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTriggerDelayRaw.Size = new System.Drawing.Size(161, 22);
            this.txtTriggerDelayRaw.TabIndex = 8;
            this.txtTriggerDelayRaw.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtBalanceBlue);
            this.tabPage2.Controls.Add(this.txtBalanceGreen);
            this.tabPage2.Controls.Add(this.txtBalanceRed);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.chkUseBalnceWhiteColor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(606, 177);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Balance White";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtBalanceBlue
            // 
            this.txtBalanceBlue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtBalanceBlue.Location = new System.Drawing.Point(146, 106);
            this.txtBalanceBlue.Margin = new System.Windows.Forms.Padding(2);
            this.txtBalanceBlue.Name = "txtBalanceBlue";
            this.txtBalanceBlue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBalanceBlue.Size = new System.Drawing.Size(161, 22);
            this.txtBalanceBlue.TabIndex = 11;
            this.txtBalanceBlue.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // txtBalanceGreen
            // 
            this.txtBalanceGreen.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtBalanceGreen.Location = new System.Drawing.Point(146, 76);
            this.txtBalanceGreen.Margin = new System.Windows.Forms.Padding(2);
            this.txtBalanceGreen.Name = "txtBalanceGreen";
            this.txtBalanceGreen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBalanceGreen.Size = new System.Drawing.Size(161, 22);
            this.txtBalanceGreen.TabIndex = 10;
            this.txtBalanceGreen.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // txtBalanceRed
            // 
            this.txtBalanceRed.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtBalanceRed.Location = new System.Drawing.Point(146, 49);
            this.txtBalanceRed.Margin = new System.Windows.Forms.Padding(2);
            this.txtBalanceRed.Name = "txtBalanceRed";
            this.txtBalanceRed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBalanceRed.Size = new System.Drawing.Size(161, 22);
            this.txtBalanceRed.TabIndex = 9;
            this.txtBalanceRed.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 109);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Balance Ratio Blue";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 80);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Balance Ratio Green";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 52);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Balance Ratio Red";
            // 
            // chkUseBalnceWhiteColor
            // 
            this.chkUseBalnceWhiteColor.AutoSize = true;
            this.chkUseBalnceWhiteColor.Location = new System.Drawing.Point(17, 20);
            this.chkUseBalnceWhiteColor.Margin = new System.Windows.Forms.Padding(2);
            this.chkUseBalnceWhiteColor.Name = "chkUseBalnceWhiteColor";
            this.chkUseBalnceWhiteColor.Size = new System.Drawing.Size(145, 17);
            this.chkUseBalnceWhiteColor.TabIndex = 0;
            this.chkUseBalnceWhiteColor.Text = "Use Balance White Color";
            this.chkUseBalnceWhiteColor.UseVisualStyleBackColor = true;
            // 
            // btnLoadDefault
            // 
            this.btnLoadDefault.BackColor = System.Drawing.Color.White;
            this.btnLoadDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnLoadDefault.Location = new System.Drawing.Point(10, 208);
            this.btnLoadDefault.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadDefault.Name = "btnLoadDefault";
            this.btnLoadDefault.Size = new System.Drawing.Size(83, 26);
            this.btnLoadDefault.TabIndex = 1;
            this.btnLoadDefault.Text = "Load Default";
            this.btnLoadDefault.UseVisualStyleBackColor = false;
            this.btnLoadDefault.Click += new System.EventHandler(this.btnLoadDefault_Click);
            // 
            // btnSaveDefault
            // 
            this.btnSaveDefault.BackColor = System.Drawing.Color.White;
            this.btnSaveDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDefault.Location = new System.Drawing.Point(116, 208);
            this.btnSaveDefault.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveDefault.Name = "btnSaveDefault";
            this.btnSaveDefault.Size = new System.Drawing.Size(83, 26);
            this.btnSaveDefault.TabIndex = 2;
            this.btnSaveDefault.Text = "Save Default";
            this.btnSaveDefault.UseVisualStyleBackColor = false;
            this.btnSaveDefault.Click += new System.EventHandler(this.btnSaveDefault_Click);
            // 
            // btnSetValue
            // 
            this.btnSetValue.BackColor = System.Drawing.Color.White;
            this.btnSetValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetValue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetValue.Location = new System.Drawing.Point(222, 208);
            this.btnSetValue.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(83, 26);
            this.btnSetValue.TabIndex = 3;
            this.btnSetValue.Text = "Set Value";
            this.btnSetValue.UseVisualStyleBackColor = false;
            this.btnSetValue.Click += new System.EventHandler(this.btnSetValue_Click);
            // 
            // btnRealValue
            // 
            this.btnRealValue.BackColor = System.Drawing.Color.White;
            this.btnRealValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealValue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealValue.Location = new System.Drawing.Point(328, 208);
            this.btnRealValue.Margin = new System.Windows.Forms.Padding(2);
            this.btnRealValue.Name = "btnRealValue";
            this.btnRealValue.Size = new System.Drawing.Size(83, 26);
            this.btnRealValue.TabIndex = 4;
            this.btnRealValue.Text = "Real Value";
            this.btnRealValue.UseVisualStyleBackColor = false;
            this.btnRealValue.Click += new System.EventHandler(this.btnRealValue_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label9.Location = new System.Drawing.Point(13, 245);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Pixel Format";
            // 
            // cbPixelFomat
            // 
            this.cbPixelFomat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPixelFomat.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cbPixelFomat.Items.AddRange(new object[] {
            "Mono 8",
            "Mono 10",
            "Mono 10 Packed",
            "Mono 12",
            "Mono 12 Packed",
            "Mono 14",
            "Mono 16",
            "RBG 8",
            "BGR 8",
            "YUV 422 (YUVV) Packed",
            "YUV 422 Packed",
            "YUV8 UYV",
            "YUV411 8 UYYVYY",
            "Bayer GR 8",
            "Bayer RG 8",
            "Bayer GB 8",
            "Bayer BG 8",
            "Bayer GR 10",
            "Bayer RG 10",
            "Bayer GB 10",
            "Bayer BG 10",
            "Bayer GR 10 Packed",
            "Bayer RG 10 Packed",
            "Bayer GB 10 Packed",
            "Bayer BG 10 Packed",
            "Bayer GR 12",
            "Bayer RG 12",
            "Bayer GB 12",
            "Bayer BG 12",
            "Bayer GR 12 Packed",
            "Bayer RG 12 Packed",
            "Bayer GB 12 Packed",
            "Bayer BG 12 Packed",
            "Bayer GR 16",
            "Bayer RG 16",
            "Bayer GB 16",
            "Bayer BG 16"});
            this.cbPixelFomat.Location = new System.Drawing.Point(108, 243);
            this.cbPixelFomat.Margin = new System.Windows.Forms.Padding(2);
            this.cbPixelFomat.Name = "cbPixelFomat";
            this.cbPixelFomat.Size = new System.Drawing.Size(130, 21);
            this.cbPixelFomat.TabIndex = 12;
            // 
            // myTreeList1
            // 
            this.myTreeList1.CellEditUseWholeCell = false;
            this.myTreeList1.HideSelection = false;
            this.myTreeList1.Location = new System.Drawing.Point(0, 0);
            this.myTreeList1.LockCalc = false;
            this.myTreeList1.Name = "myTreeList1";
            this.myTreeList1.OwnerDrawnHeader = true;
            this.myTreeList1.ShowGroups = false;
            this.myTreeList1.Size = new System.Drawing.Size(0, 0);
            this.myTreeList1.TabIndex = 0;
            this.myTreeList1.UseCompatibleStateImageBehavior = false;
            this.myTreeList1.View = System.Windows.Forms.View.Details;
            this.myTreeList1.VirtualMode = true;
            // 
            // ucCameraSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPixelFomat);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnRealValue);
            this.Controls.Add(this.btnSetValue);
            this.Controls.Add(this.btnSaveDefault);
            this.Controls.Add(this.btnLoadDefault);
            this.Controls.Add(this.tcMainSettings);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucCameraSettings";
            this.Size = new System.Drawing.Size(614, 277);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.tcMainSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcquisitionLineRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGainRaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExposureTimeRaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTriggerDelayRaw)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTreeList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RTC_Vision_Lite.UserControls.MyTreeList myTreeList1;
        private BrightIdeasSoftware.TreeListView treeListView1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tcMainSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbAcquisitionMode;
        private System.Windows.Forms.ComboBox cbExposureMode;
        private System.Windows.Forms.NumericUpDown txtGainRaw;
        private System.Windows.Forms.NumericUpDown txtExposureTimeRaw;
        private System.Windows.Forms.ComboBox cbTriggerActivation;
        private System.Windows.Forms.ComboBox cbTriggerSource;
        private System.Windows.Forms.ComboBox cbTriggerMode;
        private System.Windows.Forms.NumericUpDown txtTriggerDelayRaw;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown txtBalanceBlue;
        private System.Windows.Forms.NumericUpDown txtBalanceGreen;
        private System.Windows.Forms.NumericUpDown txtBalanceRed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkUseBalnceWhiteColor;
        private System.Windows.Forms.Button btnLoadDefault;
        private System.Windows.Forms.Button btnSaveDefault;
        private System.Windows.Forms.Button btnSetValue;
        private System.Windows.Forms.Button btnRealValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbPixelFomat;
        private System.Windows.Forms.CheckBox chkAcquisitionLineRate;
        private System.Windows.Forms.NumericUpDown txtAcquisitionLineRate;
        private System.Windows.Forms.CheckBox chkAcquisitionMode;
        private System.Windows.Forms.CheckBox chkExposureMode;
        private System.Windows.Forms.CheckBox chkGain;
        private System.Windows.Forms.CheckBox chkExposureTime;
        private System.Windows.Forms.CheckBox chkTriggerActivity;
        private System.Windows.Forms.CheckBox chkTriggerSource;
        private System.Windows.Forms.CheckBox chkTriggerMode;
        private System.Windows.Forms.CheckBox chkTriggerDelay;
    }
}
