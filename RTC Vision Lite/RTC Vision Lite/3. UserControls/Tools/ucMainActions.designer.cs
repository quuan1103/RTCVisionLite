
namespace RTC_Vision_Lite.UserControls
{
    partial class ucMainActions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMainActions));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDeviceInfo = new System.Windows.Forms.Label();
            this.lblLive_Run = new System.Windows.Forms.Label();
            this.pageMain = new System.Windows.Forms.TabControl();
            this.tpImageSeting = new System.Windows.Forms.TabPage();
            this.PageSetting = new System.Windows.Forms.TabControl();
            this.tabComputer = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ListFiles = new System.Windows.Forms.DataGridView();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrMessage = new System.Windows.Forms.Label();
            this.panSelectFiles = new System.Windows.Forms.Panel();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.radChooseFile = new System.Windows.Forms.RadioButton();
            this.radChooseFolder = new System.Windows.Forms.RadioButton();
            this.tabCamera = new System.Windows.Forms.TabPage();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTemplateSettingCam = new System.Windows.Forms.ComboBox();
            this.chkAutoSetDefaultCamSettingWhenConnect = new System.Windows.Forms.CheckBox();
            this.btnIpConfig = new System.Windows.Forms.Button();
            this.cbSdkMode = new System.Windows.Forms.ComboBox();
            this.btnAddNewDeviceManual = new System.Windows.Forms.Button();
            this.btnDetectInterfaces = new System.Windows.Forms.Button();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.cbInterfaces = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.ucCameraSettings1 = new RTC_Vision_Lite.UserControls.ucCameraSettings();
            this.lblNoticeConnect = new RTC_Vision_Lite.Commons.MyLabel(this.components);
            this.tpCameraSeting = new System.Windows.Forms.TabPage();
            this.btnTriggerBySoftware = new System.Windows.Forms.Button();
            this.chkIsTriggerBySoftware = new System.Windows.Forms.CheckBox();
            this.chkIsGetResultByRunningTool = new System.Windows.Forms.CheckBox();
            this.chkEnableSnap = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsUseSetOKButton = new System.Windows.Forms.CheckBox();
            this.chkIsUseRunOneTime = new System.Windows.Forms.CheckBox();
            this.chkIsUseSnapImage = new System.Windows.Forms.CheckBox();
            this.chkIsUseLiveCamera = new System.Windows.Forms.CheckBox();
            this.chkIsUseSetNGButton = new System.Windows.Forms.CheckBox();
            this.chkIsUseMovingRobot = new System.Windows.Forms.CheckBox();
            this.chkAutoSaveImage = new System.Windows.Forms.CheckBox();
            this.lblSetDefault = new System.Windows.Forms.Label();
            this.lblTriggerBySoftware = new System.Windows.Forms.Label();
            this.lblOpenImageFolder = new System.Windows.Forms.Label();
            this.lblSnap = new System.Windows.Forms.Label();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnComputer = new System.Windows.Forms.Button();
            this.lblLive_Stop = new System.Windows.Forms.Label();
            this.OpenFileImage = new System.Windows.Forms.OpenFileDialog();
            this.FadeTimer = new System.Windows.Forms.Timer(this.components);
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.tpImageSeting.SuspendLayout();
            this.PageSetting.SuspendLayout();
            this.tabComputer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListFiles)).BeginInit();
            this.panel3.SuspendLayout();
            this.panSelectFiles.SuspendLayout();
            this.tabCamera.SuspendLayout();
            this.tpCameraSeting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDeviceInfo);
            this.groupBox1.Controls.Add(this.lblLive_Run);
            this.groupBox1.Controls.Add(this.pageMain);
            this.groupBox1.Controls.Add(this.chkAutoSaveImage);
            this.groupBox1.Controls.Add(this.lblSetDefault);
            this.groupBox1.Controls.Add(this.lblTriggerBySoftware);
            this.groupBox1.Controls.Add(this.lblOpenImageFolder);
            this.groupBox1.Controls.Add(this.lblSnap);
            this.groupBox1.Controls.Add(this.btnCamera);
            this.groupBox1.Controls.Add(this.btnComputer);
            this.groupBox1.Controls.Add(this.lblLive_Stop);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Settings";
            // 
            // lblDeviceInfo
            // 
            this.lblDeviceInfo.AutoSize = true;
            this.lblDeviceInfo.Location = new System.Drawing.Point(3, 476);
            this.lblDeviceInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeviceInfo.Name = "lblDeviceInfo";
            this.lblDeviceInfo.Size = new System.Drawing.Size(80, 13);
            this.lblDeviceInfo.TabIndex = 5;
            this.lblDeviceInfo.Text = "Manufactuner";
            // 
            // lblLive_Run
            // 
            this.lblLive_Run.AutoSize = true;
            this.lblLive_Run.Location = new System.Drawing.Point(12, 116);
            this.lblLive_Run.Name = "lblLive_Run";
            this.lblLive_Run.Size = new System.Drawing.Size(26, 13);
            this.lblLive_Run.TabIndex = 1;
            this.lblLive_Run.Text = "Live";
            this.lblLive_Run.Click += new System.EventHandler(this.lblLive_Run_Click);
            // 
            // pageMain
            // 
            this.pageMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageMain.Controls.Add(this.tpImageSeting);
            this.pageMain.Controls.Add(this.tpCameraSeting);
            this.pageMain.Location = new System.Drawing.Point(114, 25);
            this.pageMain.Name = "pageMain";
            this.pageMain.SelectedIndex = 0;
            this.pageMain.Size = new System.Drawing.Size(646, 431);
            this.pageMain.TabIndex = 3;
            this.pageMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.pageMain_Selected);
            // 
            // tpImageSeting
            // 
            this.tpImageSeting.Controls.Add(this.PageSetting);
            this.tpImageSeting.Location = new System.Drawing.Point(4, 22);
            this.tpImageSeting.Name = "tpImageSeting";
            this.tpImageSeting.Padding = new System.Windows.Forms.Padding(3);
            this.tpImageSeting.Size = new System.Drawing.Size(638, 405);
            this.tpImageSeting.TabIndex = 0;
            this.tpImageSeting.Text = "Image Settings";
            this.tpImageSeting.UseVisualStyleBackColor = true;
            // 
            // PageSetting
            // 
            this.PageSetting.Controls.Add(this.tabComputer);
            this.PageSetting.Controls.Add(this.tabCamera);
            this.PageSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageSetting.ItemSize = new System.Drawing.Size(1, 1);
            this.PageSetting.Location = new System.Drawing.Point(3, 3);
            this.PageSetting.Margin = new System.Windows.Forms.Padding(0);
            this.PageSetting.Name = "PageSetting";
            this.PageSetting.SelectedIndex = 0;
            this.PageSetting.Size = new System.Drawing.Size(632, 399);
            this.PageSetting.TabIndex = 0;
            // 
            // tabComputer
            // 
            this.tabComputer.BackColor = System.Drawing.Color.White;
            this.tabComputer.Controls.Add(this.panel2);
            this.tabComputer.Controls.Add(this.lblErrMessage);
            this.tabComputer.Controls.Add(this.panSelectFiles);
            this.tabComputer.Controls.Add(this.radChooseFile);
            this.tabComputer.Controls.Add(this.radChooseFolder);
            this.tabComputer.Location = new System.Drawing.Point(4, 5);
            this.tabComputer.Margin = new System.Windows.Forms.Padding(2);
            this.tabComputer.Name = "tabComputer";
            this.tabComputer.Padding = new System.Windows.Forms.Padding(2);
            this.tabComputer.Size = new System.Drawing.Size(624, 390);
            this.tabComputer.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.ListFiles);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(10, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 344);
            this.panel2.TabIndex = 13;
            // 
            // ListFiles
            // 
            this.ListFiles.AllowUserToAddRows = false;
            this.ListFiles.AllowUserToDeleteRows = false;
            this.ListFiles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ListFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrder,
            this.FileName});
            this.ListFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFiles.Location = new System.Drawing.Point(0, 29);
            this.ListFiles.Name = "ListFiles";
            this.ListFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListFiles.Size = new System.Drawing.Size(612, 315);
            this.ListFiles.TabIndex = 12;
            this.ListFiles.SelectionChanged += new System.EventHandler(this.listFiles_SelectionChanged);
            // 
            // colOrder
            // 
            this.colOrder.DataPropertyName = "STT";
            this.colOrder.HeaderText = "STT";
            this.colOrder.Name = "colOrder";
            this.colOrder.Width = 50;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtPath);
            this.panel3.Controls.Add(this.btnChooseFolder);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(612, 29);
            this.panel3.TabIndex = 13;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(82, 3);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(499, 22);
            this.txtPath.TabIndex = 9;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChooseFolder.Location = new System.Drawing.Point(584, 2);
            this.btnChooseFolder.Margin = new System.Windows.Forms.Padding(0);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(25, 24);
            this.btnChooseFolder.TabIndex = 11;
            this.btnChooseFolder.Text = "...";
            this.btnChooseFolder.UseVisualStyleBackColor = false;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChoosePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Folder";
            this.label1.Click += new System.EventHandler(this.lblSetDefault_Click);
            // 
            // lblErrMessage
            // 
            this.lblErrMessage.AutoSize = true;
            this.lblErrMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrMessage.Location = new System.Drawing.Point(7, 400);
            this.lblErrMessage.Name = "lblErrMessage";
            this.lblErrMessage.Size = new System.Drawing.Size(66, 13);
            this.lblErrMessage.TabIndex = 4;
            this.lblErrMessage.Text = "ErrMessage";
            // 
            // panSelectFiles
            // 
            this.panSelectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSelectFiles.Controls.Add(this.btnRemoveAll);
            this.panSelectFiles.Controls.Add(this.btnRemoveFile);
            this.panSelectFiles.Controls.Add(this.btnSelectFiles);
            this.panSelectFiles.Location = new System.Drawing.Point(159, -1);
            this.panSelectFiles.Name = "panSelectFiles";
            this.panSelectFiles.Size = new System.Drawing.Size(460, 39);
            this.panSelectFiles.TabIndex = 8;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveAll.Location = new System.Drawing.Point(168, 8);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 25);
            this.btnRemoveAll.TabIndex = 1;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveFile.Location = new System.Drawing.Point(87, 8);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(75, 25);
            this.btnRemoveFile.TabIndex = 1;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFiles.Location = new System.Drawing.Point(6, 8);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(75, 25);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "Select Files";
            this.btnSelectFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // radChooseFile
            // 
            this.radChooseFile.AutoSize = true;
            this.radChooseFile.Checked = true;
            this.radChooseFile.Location = new System.Drawing.Point(74, 11);
            this.radChooseFile.Name = "radChooseFile";
            this.radChooseFile.Size = new System.Drawing.Size(85, 17);
            this.radChooseFile.TabIndex = 6;
            this.radChooseFile.TabStop = true;
            this.radChooseFile.Text = "Choose File";
            this.radChooseFile.UseVisualStyleBackColor = true;
            this.radChooseFile.CheckedChanged += new System.EventHandler(this.radChooseFile_CheckedChanged);
            // 
            // radChooseFolder
            // 
            this.radChooseFolder.AutoSize = true;
            this.radChooseFolder.Location = new System.Drawing.Point(10, 11);
            this.radChooseFolder.Name = "radChooseFolder";
            this.radChooseFolder.Size = new System.Drawing.Size(58, 17);
            this.radChooseFolder.TabIndex = 7;
            this.radChooseFolder.Text = "Folder";
            this.radChooseFolder.UseVisualStyleBackColor = true;
            this.radChooseFolder.CheckedChanged += new System.EventHandler(this.radChooseFolder_CheckedChanged);
            // 
            // tabCamera
            // 
            this.tabCamera.BackColor = System.Drawing.Color.White;
            this.tabCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCamera.Controls.Add(this.btnConnect);
            this.tabCamera.Controls.Add(this.label8);
            this.tabCamera.Controls.Add(this.cbTemplateSettingCam);
            this.tabCamera.Controls.Add(this.chkAutoSetDefaultCamSettingWhenConnect);
            this.tabCamera.Controls.Add(this.btnIpConfig);
            this.tabCamera.Controls.Add(this.cbSdkMode);
            this.tabCamera.Controls.Add(this.btnAddNewDeviceManual);
            this.tabCamera.Controls.Add(this.btnDetectInterfaces);
            this.tabCamera.Controls.Add(this.cbDevices);
            this.tabCamera.Controls.Add(this.cbInterfaces);
            this.tabCamera.Controls.Add(this.label7);
            this.tabCamera.Controls.Add(this.label6);
            this.tabCamera.Controls.Add(this.btnDisconnect);
            this.tabCamera.Controls.Add(this.ucCameraSettings1);
            this.tabCamera.Controls.Add(this.lblNoticeConnect);
            this.tabCamera.Location = new System.Drawing.Point(4, 5);
            this.tabCamera.Margin = new System.Windows.Forms.Padding(2);
            this.tabCamera.Name = "tabCamera";
            this.tabCamera.Padding = new System.Windows.Forms.Padding(2);
            this.tabCamera.Size = new System.Drawing.Size(624, 390);
            this.tabCamera.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(438, 50);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(74, 24);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 93);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Templates";
            // 
            // cbTemplateSettingCam
            // 
            this.cbTemplateSettingCam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplateSettingCam.FormattingEnabled = true;
            this.cbTemplateSettingCam.Items.AddRange(new object[] {
            "Hikrobot",
            "Hikrobot (GenTL)",
            "Basler",
            "FujiMV"});
            this.cbTemplateSettingCam.Location = new System.Drawing.Point(360, 90);
            this.cbTemplateSettingCam.Margin = new System.Windows.Forms.Padding(2);
            this.cbTemplateSettingCam.Name = "cbTemplateSettingCam";
            this.cbTemplateSettingCam.Size = new System.Drawing.Size(248, 21);
            this.cbTemplateSettingCam.TabIndex = 12;
            // 
            // chkAutoSetDefaultCamSettingWhenConnect
            // 
            this.chkAutoSetDefaultCamSettingWhenConnect.AutoSize = true;
            this.chkAutoSetDefaultCamSettingWhenConnect.Location = new System.Drawing.Point(20, 90);
            this.chkAutoSetDefaultCamSettingWhenConnect.Margin = new System.Windows.Forms.Padding(2);
            this.chkAutoSetDefaultCamSettingWhenConnect.Name = "chkAutoSetDefaultCamSettingWhenConnect";
            this.chkAutoSetDefaultCamSettingWhenConnect.Size = new System.Drawing.Size(176, 17);
            this.chkAutoSetDefaultCamSettingWhenConnect.TabIndex = 11;
            this.chkAutoSetDefaultCamSettingWhenConnect.Text = "Load Settings When Connect";
            this.chkAutoSetDefaultCamSettingWhenConnect.UseVisualStyleBackColor = true;
            // 
            // btnIpConfig
            // 
            this.btnIpConfig.BackColor = System.Drawing.Color.White;
            this.btnIpConfig.Location = new System.Drawing.Point(534, 51);
            this.btnIpConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnIpConfig.Name = "btnIpConfig";
            this.btnIpConfig.Size = new System.Drawing.Size(74, 24);
            this.btnIpConfig.TabIndex = 10;
            this.btnIpConfig.Text = "IP Config";
            this.btnIpConfig.UseVisualStyleBackColor = false;
            this.btnIpConfig.Click += new System.EventHandler(this.btnIpConfig_Click);
            // 
            // cbSdkMode
            // 
            this.cbSdkMode.FormattingEnabled = true;
            this.cbSdkMode.Items.AddRange(new object[] {
            "Hikrobot",
            "Hikrobot (GenTL)",
            "Basler",
            "FujiMV"});
            this.cbSdkMode.Location = new System.Drawing.Point(534, 15);
            this.cbSdkMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbSdkMode.Name = "cbSdkMode";
            this.cbSdkMode.Size = new System.Drawing.Size(74, 21);
            this.cbSdkMode.TabIndex = 9;
            this.cbSdkMode.Text = "Hikrobot";
            this.cbSdkMode.SelectedValueChanged += new System.EventHandler(this.cbSdkMode_SelectedValueChanged);
            // 
            // btnAddNewDeviceManual
            // 
            this.btnAddNewDeviceManual.BackColor = System.Drawing.Color.White;
            this.btnAddNewDeviceManual.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddNewDeviceManual.BackgroundImage")));
            this.btnAddNewDeviceManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNewDeviceManual.Location = new System.Drawing.Point(373, 50);
            this.btnAddNewDeviceManual.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewDeviceManual.Name = "btnAddNewDeviceManual";
            this.btnAddNewDeviceManual.Size = new System.Drawing.Size(46, 24);
            this.btnAddNewDeviceManual.TabIndex = 7;
            this.btnAddNewDeviceManual.UseVisualStyleBackColor = false;
            // 
            // btnDetectInterfaces
            // 
            this.btnDetectInterfaces.BackColor = System.Drawing.Color.White;
            this.btnDetectInterfaces.Location = new System.Drawing.Point(438, 15);
            this.btnDetectInterfaces.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetectInterfaces.Name = "btnDetectInterfaces";
            this.btnDetectInterfaces.Size = new System.Drawing.Size(74, 24);
            this.btnDetectInterfaces.TabIndex = 6;
            this.btnDetectInterfaces.Text = "Detect";
            this.btnDetectInterfaces.UseVisualStyleBackColor = false;
            this.btnDetectInterfaces.Click += new System.EventHandler(this.btnDetectInterfaces_Click);
            // 
            // cbDevices
            // 
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(96, 50);
            this.cbDevices.Margin = new System.Windows.Forms.Padding(2);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(272, 21);
            this.cbDevices.TabIndex = 3;
            this.cbDevices.SelectedIndexChanged += new System.EventHandler(this.cbDevices_SelectedIndexChanged);
            // 
            // cbInterfaces
            // 
            this.cbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterfaces.FormattingEnabled = true;
            this.cbInterfaces.Location = new System.Drawing.Point(96, 15);
            this.cbInterfaces.Margin = new System.Windows.Forms.Padding(2);
            this.cbInterfaces.Name = "cbInterfaces";
            this.cbInterfaces.Size = new System.Drawing.Size(323, 21);
            this.cbInterfaces.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Devices";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Interfaces";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(438, 51);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(74, 24);
            this.btnDisconnect.TabIndex = 15;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // ucCameraSettings1
            // 
            this.ucCameraSettings1.Enabled = false;
            this.ucCameraSettings1.GroupActions = null;
            this.ucCameraSettings1.Location = new System.Drawing.Point(4, 120);
            this.ucCameraSettings1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ucCameraSettings1.Name = "ucCameraSettings1";
            this.ucCameraSettings1.Size = new System.Drawing.Size(604, 270);
            this.ucCameraSettings1.TabIndex = 14;
            // 
            // lblNoticeConnect
            // 
            this.lblNoticeConnect.AutoSize = true;
            this.lblNoticeConnect.Location = new System.Drawing.Point(451, 56);
            this.lblNoticeConnect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoticeConnect.Name = "lblNoticeConnect";
            this.lblNoticeConnect.RTCBorderBottomColor = System.Drawing.Color.White;
            this.lblNoticeConnect.RTCBorderBottomDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblNoticeConnect.RTCBorderBottomPadding = 1;
            this.lblNoticeConnect.RTCBorderBottomVisible = false;
            this.lblNoticeConnect.RTCBorderLeftColor = System.Drawing.Color.White;
            this.lblNoticeConnect.RTCBorderLeftDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblNoticeConnect.RTCBorderLeftPadding = 1;
            this.lblNoticeConnect.RTCBorderLeftVisible = false;
            this.lblNoticeConnect.RTCBorderRightColor = System.Drawing.Color.White;
            this.lblNoticeConnect.RTCBorderRightDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblNoticeConnect.RTCBorderRightPadding = 1;
            this.lblNoticeConnect.RTCBorderRightVisible = false;
            this.lblNoticeConnect.RTCBorderTopColor = System.Drawing.Color.White;
            this.lblNoticeConnect.RTCBorderTopDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblNoticeConnect.RTCBorderTopPadding = 1;
            this.lblNoticeConnect.RTCBorderTopVisible = false;
            this.lblNoticeConnect.RTCFadeOutSpeed = 5;
            this.lblNoticeConnect.RTCInterval = 100;
            this.lblNoticeConnect.RTCUseCustomBorder = false;
            this.lblNoticeConnect.Size = new System.Drawing.Size(50, 13);
            this.lblNoticeConnect.TabIndex = 16;
            this.lblNoticeConnect.Text = "Connect";
            this.lblNoticeConnect.Visible = false;
            // 
            // tpCameraSeting
            // 
            this.tpCameraSeting.Controls.Add(this.btnTriggerBySoftware);
            this.tpCameraSeting.Controls.Add(this.chkIsTriggerBySoftware);
            this.tpCameraSeting.Controls.Add(this.chkIsGetResultByRunningTool);
            this.tpCameraSeting.Controls.Add(this.chkEnableSnap);
            this.tpCameraSeting.Controls.Add(this.groupBox2);
            this.tpCameraSeting.Location = new System.Drawing.Point(4, 22);
            this.tpCameraSeting.Name = "tpCameraSeting";
            this.tpCameraSeting.Padding = new System.Windows.Forms.Padding(3);
            this.tpCameraSeting.Size = new System.Drawing.Size(638, 405);
            this.tpCameraSeting.TabIndex = 1;
            this.tpCameraSeting.Text = "Camera Settings";
            this.tpCameraSeting.UseVisualStyleBackColor = true;
            // 
            // btnTriggerBySoftware
            // 
            this.btnTriggerBySoftware.Location = new System.Drawing.Point(320, 249);
            this.btnTriggerBySoftware.Name = "btnTriggerBySoftware";
            this.btnTriggerBySoftware.Size = new System.Drawing.Size(75, 23);
            this.btnTriggerBySoftware.TabIndex = 2;
            this.btnTriggerBySoftware.Text = "Trigger";
            this.btnTriggerBySoftware.UseVisualStyleBackColor = true;
            this.btnTriggerBySoftware.Visible = false;
            // 
            // chkIsTriggerBySoftware
            // 
            this.chkIsTriggerBySoftware.AutoSize = true;
            this.chkIsTriggerBySoftware.Location = new System.Drawing.Point(189, 253);
            this.chkIsTriggerBySoftware.Name = "chkIsTriggerBySoftware";
            this.chkIsTriggerBySoftware.Size = new System.Drawing.Size(125, 17);
            this.chkIsTriggerBySoftware.TabIndex = 1;
            this.chkIsTriggerBySoftware.Text = "Trigger By Software";
            this.chkIsTriggerBySoftware.UseVisualStyleBackColor = true;
            this.chkIsTriggerBySoftware.Visible = false;
            this.chkIsTriggerBySoftware.CheckedChanged += new System.EventHandler(this.chkIsTriggerBySoftware_CheckedChanged);
            // 
            // chkIsGetResultByRunningTool
            // 
            this.chkIsGetResultByRunningTool.AutoSize = true;
            this.chkIsGetResultByRunningTool.Location = new System.Drawing.Point(17, 44);
            this.chkIsGetResultByRunningTool.Name = "chkIsGetResultByRunningTool";
            this.chkIsGetResultByRunningTool.Size = new System.Drawing.Size(190, 17);
            this.chkIsGetResultByRunningTool.TabIndex = 1;
            this.chkIsGetResultByRunningTool.Text = "Get the results by running tools";
            this.chkIsGetResultByRunningTool.UseVisualStyleBackColor = true;
            this.chkIsGetResultByRunningTool.CheckedChanged += new System.EventHandler(this.chkIsGetResultByRunningTool_CheckedChanged);
            // 
            // chkEnableSnap
            // 
            this.chkEnableSnap.AutoSize = true;
            this.chkEnableSnap.Location = new System.Drawing.Point(17, 22);
            this.chkEnableSnap.Name = "chkEnableSnap";
            this.chkEnableSnap.Size = new System.Drawing.Size(90, 17);
            this.chkEnableSnap.TabIndex = 1;
            this.chkEnableSnap.Text = "Enable Snap";
            this.chkEnableSnap.UseVisualStyleBackColor = true;
            this.chkEnableSnap.CheckedChanged += new System.EventHandler(this.chkEnableSnap_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkIsUseSetOKButton);
            this.groupBox2.Controls.Add(this.chkIsUseRunOneTime);
            this.groupBox2.Controls.Add(this.chkIsUseSnapImage);
            this.groupBox2.Controls.Add(this.chkIsUseLiveCamera);
            this.groupBox2.Controls.Add(this.chkIsUseSetNGButton);
            this.groupBox2.Controls.Add(this.chkIsUseMovingRobot);
            this.groupBox2.Location = new System.Drawing.Point(17, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(678, 172);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual Button Setting";
            this.groupBox2.Visible = false;
            // 
            // chkIsUseSetOKButton
            // 
            this.chkIsUseSetOKButton.AutoSize = true;
            this.chkIsUseSetOKButton.Location = new System.Drawing.Point(15, 32);
            this.chkIsUseSetOKButton.Name = "chkIsUseSetOKButton";
            this.chkIsUseSetOKButton.Size = new System.Drawing.Size(121, 17);
            this.chkIsUseSetOKButton.TabIndex = 1;
            this.chkIsUseSetOKButton.Text = "Use Set OK Button";
            this.chkIsUseSetOKButton.UseVisualStyleBackColor = true;
            // 
            // chkIsUseRunOneTime
            // 
            this.chkIsUseRunOneTime.AutoSize = true;
            this.chkIsUseRunOneTime.Location = new System.Drawing.Point(15, 145);
            this.chkIsUseRunOneTime.Name = "chkIsUseRunOneTime";
            this.chkIsUseRunOneTime.Size = new System.Drawing.Size(120, 17);
            this.chkIsUseRunOneTime.TabIndex = 1;
            this.chkIsUseRunOneTime.Text = "Use Run One Time";
            this.chkIsUseRunOneTime.UseVisualStyleBackColor = true;
            // 
            // chkIsUseSnapImage
            // 
            this.chkIsUseSnapImage.AutoSize = true;
            this.chkIsUseSnapImage.Location = new System.Drawing.Point(15, 101);
            this.chkIsUseSnapImage.Name = "chkIsUseSnapImage";
            this.chkIsUseSnapImage.Size = new System.Drawing.Size(108, 17);
            this.chkIsUseSnapImage.TabIndex = 1;
            this.chkIsUseSnapImage.Text = "Use Snap Image";
            this.chkIsUseSnapImage.UseVisualStyleBackColor = true;
            // 
            // chkIsUseLiveCamera
            // 
            this.chkIsUseLiveCamera.AutoSize = true;
            this.chkIsUseLiveCamera.Location = new System.Drawing.Point(15, 123);
            this.chkIsUseLiveCamera.Name = "chkIsUseLiveCamera";
            this.chkIsUseLiveCamera.Size = new System.Drawing.Size(108, 17);
            this.chkIsUseLiveCamera.TabIndex = 1;
            this.chkIsUseLiveCamera.Text = "Use Live Camera";
            this.chkIsUseLiveCamera.UseVisualStyleBackColor = true;
            // 
            // chkIsUseSetNGButton
            // 
            this.chkIsUseSetNGButton.AutoSize = true;
            this.chkIsUseSetNGButton.Location = new System.Drawing.Point(15, 54);
            this.chkIsUseSetNGButton.Name = "chkIsUseSetNGButton";
            this.chkIsUseSetNGButton.Size = new System.Drawing.Size(122, 17);
            this.chkIsUseSetNGButton.TabIndex = 1;
            this.chkIsUseSetNGButton.Text = "Use Set NG Button";
            this.chkIsUseSetNGButton.UseVisualStyleBackColor = true;
            // 
            // chkIsUseMovingRobot
            // 
            this.chkIsUseMovingRobot.AutoSize = true;
            this.chkIsUseMovingRobot.Location = new System.Drawing.Point(15, 78);
            this.chkIsUseMovingRobot.Name = "chkIsUseMovingRobot";
            this.chkIsUseMovingRobot.Size = new System.Drawing.Size(189, 17);
            this.chkIsUseMovingRobot.TabIndex = 1;
            this.chkIsUseMovingRobot.Text = "Use Moving Robot To This Point";
            this.chkIsUseMovingRobot.UseVisualStyleBackColor = true;
            // 
            // chkAutoSaveImage
            // 
            this.chkAutoSaveImage.AutoSize = true;
            this.chkAutoSaveImage.Location = new System.Drawing.Point(12, 161);
            this.chkAutoSaveImage.Name = "chkAutoSaveImage";
            this.chkAutoSaveImage.Size = new System.Drawing.Size(83, 17);
            this.chkAutoSaveImage.TabIndex = 2;
            this.chkAutoSaveImage.Text = "Save Image";
            this.chkAutoSaveImage.UseVisualStyleBackColor = true;
            this.chkAutoSaveImage.CheckedChanged += new System.EventHandler(this.chkAutoSaveImage_CheckedChanged);
            // 
            // lblSetDefault
            // 
            this.lblSetDefault.AutoSize = true;
            this.lblSetDefault.Location = new System.Drawing.Point(12, 92);
            this.lblSetDefault.Name = "lblSetDefault";
            this.lblSetDefault.Size = new System.Drawing.Size(64, 13);
            this.lblSetDefault.TabIndex = 1;
            this.lblSetDefault.Text = "Set Default";
            this.lblSetDefault.Click += new System.EventHandler(this.lblSetDefault_Click);
            // 
            // lblTriggerBySoftware
            // 
            this.lblTriggerBySoftware.AutoSize = true;
            this.lblTriggerBySoftware.Location = new System.Drawing.Point(12, 213);
            this.lblTriggerBySoftware.Name = "lblTriggerBySoftware";
            this.lblTriggerBySoftware.Size = new System.Drawing.Size(106, 13);
            this.lblTriggerBySoftware.TabIndex = 1;
            this.lblTriggerBySoftware.Text = "Trigger By Software";
            this.lblTriggerBySoftware.Click += new System.EventHandler(this.lblTriggerBySoftware_Click);
            // 
            // lblOpenImageFolder
            // 
            this.lblOpenImageFolder.AutoSize = true;
            this.lblOpenImageFolder.Location = new System.Drawing.Point(12, 190);
            this.lblOpenImageFolder.Name = "lblOpenImageFolder";
            this.lblOpenImageFolder.Size = new System.Drawing.Size(74, 13);
            this.lblOpenImageFolder.TabIndex = 1;
            this.lblOpenImageFolder.Text = "Image Folder";
            this.lblOpenImageFolder.Click += new System.EventHandler(this.lblOpenImageFolder_Click);
            // 
            // lblSnap
            // 
            this.lblSnap.AutoSize = true;
            this.lblSnap.Location = new System.Drawing.Point(12, 139);
            this.lblSnap.Name = "lblSnap";
            this.lblSnap.Size = new System.Drawing.Size(33, 13);
            this.lblSnap.TabIndex = 1;
            this.lblSnap.Text = "Snap";
            this.lblSnap.Click += new System.EventHandler(this.lblSnap_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCamera.Location = new System.Drawing.Point(12, 54);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(96, 25);
            this.btnCamera.TabIndex = 0;
            this.btnCamera.Text = "CAMERA";
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnComputer
            // 
            this.btnComputer.AutoSize = true;
            this.btnComputer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComputer.Location = new System.Drawing.Point(12, 25);
            this.btnComputer.Name = "btnComputer";
            this.btnComputer.Size = new System.Drawing.Size(96, 25);
            this.btnComputer.TabIndex = 0;
            this.btnComputer.Text = "COMPUTER";
            this.btnComputer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComputer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComputer.UseVisualStyleBackColor = true;
            this.btnComputer.Click += new System.EventHandler(this.btnComputer_Click);
            // 
            // lblLive_Stop
            // 
            this.lblLive_Stop.AutoSize = true;
            this.lblLive_Stop.Location = new System.Drawing.Point(12, 116);
            this.lblLive_Stop.Name = "lblLive_Stop";
            this.lblLive_Stop.Size = new System.Drawing.Size(53, 13);
            this.lblLive_Stop.TabIndex = 4;
            this.lblLive_Stop.Text = "Live Stop";
            this.lblLive_Stop.Click += new System.EventHandler(this.lblLive_Stop_Click);
            // 
            // OpenFileImage
            // 
            this.OpenFileImage.FileName = "openFileDialog1";
            this.OpenFileImage.Multiselect = true;
            // 
            // FadeTimer
            // 
            this.FadeTimer.Tick += new System.EventHandler(this.FadeTimer_Tick);
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // ucMainActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Name = "ucMainActions";
            this.Size = new System.Drawing.Size(763, 479);
            this.Load += new System.EventHandler(this.ucMainActions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pageMain.ResumeLayout(false);
            this.tpImageSeting.ResumeLayout(false);
            this.PageSetting.ResumeLayout(false);
            this.tabComputer.ResumeLayout(false);
            this.tabComputer.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListFiles)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panSelectFiles.ResumeLayout(false);
            this.tabCamera.ResumeLayout(false);
            this.tabCamera.PerformLayout();
            this.tpCameraSeting.ResumeLayout(false);
            this.tpCameraSeting.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoSaveImage;
        private System.Windows.Forms.Label lblSetDefault;
        private System.Windows.Forms.Label lblTriggerBySoftware;
        private System.Windows.Forms.Label lblOpenImageFolder;
        private System.Windows.Forms.Label lblSnap;
        private System.Windows.Forms.Label lblLive_Run;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnComputer;
        private System.Windows.Forms.OpenFileDialog OpenFileImage;
        public System.Windows.Forms.TabControl pageMain;
        private System.Windows.Forms.TabPage tpImageSeting;
        private System.Windows.Forms.TabControl PageSetting;
        private System.Windows.Forms.TabPage tabComputer;
        private System.Windows.Forms.Label lblErrMessage;
        private System.Windows.Forms.Panel panSelectFiles;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.RadioButton radChooseFile;
        private System.Windows.Forms.RadioButton radChooseFolder;
        private System.Windows.Forms.TabPage tabCamera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTemplateSettingCam;
        private System.Windows.Forms.CheckBox chkAutoSetDefaultCamSettingWhenConnect;
        private System.Windows.Forms.Button btnIpConfig;
        private System.Windows.Forms.ComboBox cbSdkMode;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnAddNewDeviceManual;
        private System.Windows.Forms.Button btnDetectInterfaces;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.ComboBox cbInterfaces;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tpCameraSeting;
        private System.Windows.Forms.Button btnTriggerBySoftware;
        private System.Windows.Forms.CheckBox chkIsTriggerBySoftware;
        private System.Windows.Forms.CheckBox chkIsGetResultByRunningTool;
        private System.Windows.Forms.CheckBox chkEnableSnap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkIsUseSetOKButton;
        private System.Windows.Forms.CheckBox chkIsUseRunOneTime;
        private System.Windows.Forms.CheckBox chkIsUseSnapImage;
        private System.Windows.Forms.CheckBox chkIsUseLiveCamera;
        private System.Windows.Forms.CheckBox chkIsUseSetNGButton;
        private System.Windows.Forms.CheckBox chkIsUseMovingRobot;
        private UserControls.ucCameraSettings ucCameraSettings1;
        private System.Windows.Forms.Label lblLive_Stop;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Timer FadeTimer;
        private Commons.MyLabel lblNoticeConnect;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblDeviceInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.DataGridView ListFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.Label label1;
    }
}
