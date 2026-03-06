
namespace RTC_Vision_Lite.Forms
{
    partial class FrmActions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActions));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSaveJob = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.btnIInsertTool = new System.Windows.Forms.ToolStripButton();
            this.mnuRunprevius = new System.Windows.Forms.ToolStripButton();
            this.mnuRunJob = new System.Windows.Forms.ToolStripButton();
            this.mnuStop = new System.Windows.Forms.ToolStripButton();
            this.mnuRunOneJob = new System.Windows.Forms.ToolStripButton();
            this.mnuRunNext = new System.Windows.Forms.ToolStripButton();
            this.mnuRunCurrentImage = new System.Windows.Forms.ToolStripButton();
            this.mnuResetCounter = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAndClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveSettingAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuApplyActionsToOtherCAMs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationStepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locatePartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inspectPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.mnuCreateData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewData = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanHsmartWindow = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.PanActionInfo = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucActionList = new RTC_Vision_Lite.UserControls.ucActionList();
            this.pnlTemplate = new System.Windows.Forms.Panel();
            this.ucTemplateTools = new RTC_Vision_Lite.UserControls.ucTemplateTools();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlTemplate.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveJob,
            this.btnSaveAndClose,
            this.btnIInsertTool,
            this.mnuRunprevius,
            this.mnuRunJob,
            this.mnuStop,
            this.mnuRunOneJob,
            this.mnuRunNext,
            this.mnuRunCurrentImage,
            this.mnuResetCounter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1284, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSaveJob
            // 
            this.btnSaveJob.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveJob.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveJob.Image = global::RTC_Vision_Lite.Properties.Resources.SaveTo_16x161;
            this.btnSaveJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveJob.Name = "btnSaveJob";
            this.btnSaveJob.Size = new System.Drawing.Size(51, 22);
            this.btnSaveJob.Text = "Save";
            this.btnSaveJob.Click += new System.EventHandler(this.btnSaveJob_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveAndClose.Image = global::RTC_Vision_Lite.Properties.Resources.Export_16x16;
            this.btnSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(96, 22);
            this.btnSaveAndClose.Text = "Save && Close";
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnIInsertTool
            // 
            this.btnIInsertTool.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnIInsertTool.Image = global::RTC_Vision_Lite.Properties.Resources.InsertSectionBreakEvenPage_16x16;
            this.btnIInsertTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIInsertTool.Name = "btnIInsertTool";
            this.btnIInsertTool.Size = new System.Drawing.Size(81, 22);
            this.btnIInsertTool.Text = "Insert Tool";
            this.btnIInsertTool.Click += new System.EventHandler(this.btnIInsertTool_Click);
            // 
            // mnuRunprevius
            // 
            this.mnuRunprevius.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuRunprevius.Image = ((System.Drawing.Image)(resources.GetObject("mnuRunprevius.Image")));
            this.mnuRunprevius.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRunprevius.Name = "mnuRunprevius";
            this.mnuRunprevius.Size = new System.Drawing.Size(23, 22);
            this.mnuRunprevius.Text = "toolStripButton2";
            this.mnuRunprevius.Click += new System.EventHandler(this.mnuRunprevius_Click);
            // 
            // mnuRunJob
            // 
            this.mnuRunJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuRunJob.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x161;
            this.mnuRunJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRunJob.Name = "mnuRunJob";
            this.mnuRunJob.Size = new System.Drawing.Size(23, 22);
            this.mnuRunJob.Click += new System.EventHandler(this.mnuRunJob_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuStop.Image = global::RTC_Vision_Lite.Properties.Resources.Stop_16x16;
            this.mnuStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuStop.Name = "mnuStop";
            this.mnuStop.Size = new System.Drawing.Size(23, 22);
            this.mnuStop.Text = "toolStripButton2";
            this.mnuStop.Visible = false;
            this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
            // 
            // mnuRunOneJob
            // 
            this.mnuRunOneJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuRunOneJob.Image = global::RTC_Vision_Lite.Properties.Resources.RunOneJob;
            this.mnuRunOneJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRunOneJob.Name = "mnuRunOneJob";
            this.mnuRunOneJob.Size = new System.Drawing.Size(23, 22);
            this.mnuRunOneJob.Text = "toolStripButton3";
            this.mnuRunOneJob.Click += new System.EventHandler(this.mnuRunOneJob_Click);
            // 
            // mnuRunNext
            // 
            this.mnuRunNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuRunNext.Image = ((System.Drawing.Image)(resources.GetObject("mnuRunNext.Image")));
            this.mnuRunNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRunNext.Name = "mnuRunNext";
            this.mnuRunNext.Size = new System.Drawing.Size(23, 22);
            this.mnuRunNext.Text = "toolStripButton1";
            this.mnuRunNext.Click += new System.EventHandler(this.mnuRunNext_Click);
            // 
            // mnuRunCurrentImage
            // 
            this.mnuRunCurrentImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuRunCurrentImage.Image = global::RTC_Vision_Lite.Properties.Resources.RunCurrentImage;
            this.mnuRunCurrentImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRunCurrentImage.Name = "mnuRunCurrentImage";
            this.mnuRunCurrentImage.Size = new System.Drawing.Size(23, 22);
            this.mnuRunCurrentImage.Text = "Run Current Image";
            this.mnuRunCurrentImage.Click += new System.EventHandler(this.mnuRunCurrentImage_Click);
            // 
            // mnuResetCounter
            // 
            this.mnuResetCounter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mnuResetCounter.Image = ((System.Drawing.Image)(resources.GetObject("mnuResetCounter.Image")));
            this.mnuResetCounter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuResetCounter.Name = "mnuResetCounter";
            this.mnuResetCounter.Size = new System.Drawing.Size(101, 22);
            this.mnuResetCounter.Text = "Reset Counter";
            this.mnuResetCounter.Click += new System.EventHandler(this.mnuResetCounter_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuSettings,
            this.applicationStepsToolStripMenuItem,
            this.runToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.skinToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuLoadSetting,
            this.mnuSaveAndClose,
            this.mnuSaveJob,
            this.mnuSave,
            this.mnuSaveSettingAs,
            this.toolStripSeparator1,
            this.mnuApplyActionsToOtherCAMs,
            this.toolStripSeparator2,
            this.mnuClose});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(185, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuLoadSetting
            // 
            this.mnuLoadSetting.Name = "mnuLoadSetting";
            this.mnuLoadSetting.Size = new System.Drawing.Size(185, 22);
            this.mnuLoadSetting.Text = "Insert Tools";
            this.mnuLoadSetting.Click += new System.EventHandler(this.btnIInsertTool_Click);
            // 
            // mnuSaveAndClose
            // 
            this.mnuSaveAndClose.Name = "mnuSaveAndClose";
            this.mnuSaveAndClose.Size = new System.Drawing.Size(185, 22);
            this.mnuSaveAndClose.Text = "Save && Close";
            this.mnuSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // mnuSaveJob
            // 
            this.mnuSaveJob.Name = "mnuSaveJob";
            this.mnuSaveJob.Size = new System.Drawing.Size(185, 22);
            this.mnuSaveJob.Text = "Save Model To File";
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(185, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.btnSaveJob_Click);
            // 
            // mnuSaveSettingAs
            // 
            this.mnuSaveSettingAs.Name = "mnuSaveSettingAs";
            this.mnuSaveSettingAs.Size = new System.Drawing.Size(185, 22);
            this.mnuSaveSettingAs.Text = "Save setting as...";
            this.mnuSaveSettingAs.Click += new System.EventHandler(this.mnuSaveSettingAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // mnuApplyActionsToOtherCAMs
            // 
            this.mnuApplyActionsToOtherCAMs.Name = "mnuApplyActionsToOtherCAMs";
            this.mnuApplyActionsToOtherCAMs.Size = new System.Drawing.Size(185, 22);
            this.mnuApplyActionsToOtherCAMs.Text = "Apply to other CAMs";
            this.mnuApplyActionsToOtherCAMs.Click += new System.EventHandler(this.mnuApplyActionsToOtherCAMs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(185, 22);
            this.mnuClose.Text = "Close";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(61, 20);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // applicationStepsToolStripMenuItem
            // 
            this.applicationStepsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.getConnectToolStripMenuItem,
            this.setupImageToolStripMenuItem,
            this.locatePartToolStripMenuItem,
            this.inspectPartToolStripMenuItem});
            this.applicationStepsToolStripMenuItem.Name = "applicationStepsToolStripMenuItem";
            this.applicationStepsToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.applicationStepsToolStripMenuItem.Text = "Application Steps";
            this.applicationStepsToolStripMenuItem.Visible = false;
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // getConnectToolStripMenuItem
            // 
            this.getConnectToolStripMenuItem.Name = "getConnectToolStripMenuItem";
            this.getConnectToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.getConnectToolStripMenuItem.Text = "Get Connect";
            // 
            // setupImageToolStripMenuItem
            // 
            this.setupImageToolStripMenuItem.Name = "setupImageToolStripMenuItem";
            this.setupImageToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.setupImageToolStripMenuItem.Text = "Setup Image";
            // 
            // locatePartToolStripMenuItem
            // 
            this.locatePartToolStripMenuItem.Name = "locatePartToolStripMenuItem";
            this.locatePartToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.locatePartToolStripMenuItem.Text = "Locate part";
            // 
            // inspectPartToolStripMenuItem
            // 
            this.inspectPartToolStripMenuItem.Name = "inspectPartToolStripMenuItem";
            this.inspectPartToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.inspectPartToolStripMenuItem.Text = "Inspect part";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Visible = false;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Visible = false;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // skinToolStripMenuItem
            // 
            this.skinToolStripMenuItem.Name = "skinToolStripMenuItem";
            this.skinToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.skinToolStripMenuItem.Text = "Skin";
            this.skinToolStripMenuItem.Visible = false;
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.mnuCreateData,
            this.mnuViewData,
            this.showDetailToolStripMenuItem,
            this.setValueToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // mnuCreateData
            // 
            this.mnuCreateData.Name = "mnuCreateData";
            this.mnuCreateData.Size = new System.Drawing.Size(160, 22);
            this.mnuCreateData.Text = "Create Data";
            this.mnuCreateData.Click += new System.EventHandler(this.mnuCreateData_Click);
            // 
            // mnuViewData
            // 
            this.mnuViewData.Name = "mnuViewData";
            this.mnuViewData.Size = new System.Drawing.Size(160, 22);
            this.mnuViewData.Text = "ViewData";
            // 
            // showDetailToolStripMenuItem
            // 
            this.showDetailToolStripMenuItem.Name = "showDetailToolStripMenuItem";
            this.showDetailToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showDetailToolStripMenuItem.Text = "Show Detail";
            // 
            // setValueToolStripMenuItem
            // 
            this.setValueToolStripMenuItem.Name = "setValueToolStripMenuItem";
            this.setValueToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.setValueToolStripMenuItem.Text = "Set Value";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(235, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1049, 813);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanHsmartWindow);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.PanActionInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(680, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 813);
            this.panel1.TabIndex = 12;
            // 
            // PanHsmartWindow
            // 
            this.PanHsmartWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanHsmartWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanHsmartWindow.Location = new System.Drawing.Point(0, 0);
            this.PanHsmartWindow.Name = "PanHsmartWindow";
            this.PanHsmartWindow.Size = new System.Drawing.Size(369, 336);
            this.PanHsmartWindow.TabIndex = 1;
            this.PanHsmartWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.PanHsmartWindow_Paint);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 336);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(369, 3);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // PanActionInfo
            // 
            this.PanActionInfo.BackColor = System.Drawing.SystemColors.Control;
            this.PanActionInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanActionInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanActionInfo.Location = new System.Drawing.Point(0, 339);
            this.PanActionInfo.Name = "PanActionInfo";
            this.PanActionInfo.Size = new System.Drawing.Size(369, 474);
            this.PanActionInfo.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(677, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 813);
            this.splitter2.TabIndex = 13;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ucActionList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(677, 813);
            this.panel4.TabIndex = 15;
            // 
            // ucActionList
            // 
            this.ucActionList.BackColor = System.Drawing.Color.Gainsboro;
            this.ucActionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucActionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucActionList.Location = new System.Drawing.Point(0, 0);
            this.ucActionList.Margin = new System.Windows.Forms.Padding(4);
            this.ucActionList.ModelViewGrid = RTCEnums.EModeViewGrid.MainView;
            this.ucActionList.Name = "ucActionList";
            this.ucActionList.Size = new System.Drawing.Size(677, 813);
            this.ucActionList.TabIndex = 10;
            this.ucActionList.OnFocusedNodeChanged += new RTC_Vision_Lite.UserControls.FocusedNodeChanged(this.ucActionList1_OnFocusedNodeChanged);
            this.ucActionList.Load += new System.EventHandler(this.ucActionList_Load);
            // 
            // pnlTemplate
            // 
            this.pnlTemplate.Controls.Add(this.ucTemplateTools);
            this.pnlTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTemplate.Location = new System.Drawing.Point(0, 0);
            this.pnlTemplate.Name = "pnlTemplate";
            this.pnlTemplate.Size = new System.Drawing.Size(232, 813);
            this.pnlTemplate.TabIndex = 14;
            // 
            // ucTemplateTools
            // 
            this.ucTemplateTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucTemplateTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemplateTools.IsDaNap = false;
            this.ucTemplateTools.IsLocate = false;
            this.ucTemplateTools.Location = new System.Drawing.Point(0, 0);
            this.ucTemplateTools.Margin = new System.Windows.Forms.Padding(4);
            this.ucTemplateTools.Name = "ucTemplateTools";
            this.ucTemplateTools.Size = new System.Drawing.Size(232, 813);
            this.ucTemplateTools.TabIndex = 9;
            this.ucTemplateTools.OnAddAction += new RTC_Vision_Lite.Classes.AddAction(this.ucTemplateTools_OnAddAction);
            this.ucTemplateTools.Load += new System.EventHandler(this.ucTemplateTools_Load);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnlTemplate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 813);
            this.panel3.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.splitter3);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 49);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1284, 813);
            this.panel5.TabIndex = 10;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(232, 0);
            this.splitter3.MinExtra = 5;
            this.splitter3.MinSize = 5;
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 813);
            this.splitter3.TabIndex = 10;
            this.splitter3.TabStop = false;
            // 
            // FrmActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 862);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmActions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RTC Vision";
            this.TransparencyKey = System.Drawing.SystemColors.ControlLight;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmActions_FormClosing);
            this.Load += new System.EventHandler(this.FrmActions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmActions_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlTemplate.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSaveJob;
        private System.Windows.Forms.ToolStripButton btnIInsertTool;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadSetting;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAndClose;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveJob;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveSettingAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuApplyActionsToOtherCAMs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem applicationStepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locatePartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inspectPartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateData;
        private System.Windows.Forms.ToolStripMenuItem mnuViewData;
        private System.Windows.Forms.ToolStripMenuItem showDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setValueToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanHsmartWindow;
        private System.Windows.Forms.Panel PanActionInfo;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton mnuRunJob;
        private System.Windows.Forms.ToolStripButton mnuRunOneJob;
        private System.Windows.Forms.Panel pnlTemplate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripButton mnuResetCounter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter2;
        public UserControls.ucActionList ucActionList;
        public UserControls.ucTemplateTools ucTemplateTools;
        private System.Windows.Forms.ToolStripButton mnuRunNext;
        private System.Windows.Forms.ToolStripButton mnuRunprevius;
        public System.Windows.Forms.ToolStripButton btnSaveAndClose;
        public System.Windows.Forms.ToolStripButton mnuStop;
        private System.Windows.Forms.ToolStripButton mnuRunCurrentImage;
        private System.Windows.Forms.Splitter splitter3;
    }
}