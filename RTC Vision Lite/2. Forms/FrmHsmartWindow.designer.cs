
namespace RTC_Vision_Lite.Forms
{
    partial class FrmHsmartWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHsmartWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCordinate = new System.Windows.Forms.Label();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnLockROI = new System.Windows.Forms.Button();
            this.btnMoveROIWithKey = new System.Windows.Forms.Button();
            this.btnMultiSelect = new System.Windows.Forms.Button();
            this.mnuViewMarkName = new System.Windows.Forms.CheckBox();
            this.isViewMarkRoi = new System.Windows.Forms.CheckBox();
            this.mnuViewRoiName = new System.Windows.Forms.CheckBox();
            this.mnuIsViewNormalRoi = new System.Windows.Forms.CheckBox();
            this.mnuIsViewMasterRoi = new System.Windows.Forms.CheckBox();
            this.mnuIsViewMasterName = new System.Windows.Forms.CheckBox();
            this.pnlTools = new System.Windows.Forms.ToolStrip();
            this.btnStep1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDraw = new System.Windows.Forms.ToolStripSplitButton();
            this.btnDrawRectang = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrawCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnStep2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.btnZoomEX = new System.Windows.Forms.ToolStripButton();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnFitImageEx = new System.Windows.Forms.ToolStripButton();
            this.btnStep3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRenameROI = new System.Windows.Forms.ToolStripButton();
            this.btnMoveROI = new System.Windows.Forms.ToolStripButton();
            this.btnStep4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConnectCamera = new System.Windows.Forms.ToolStripButton();
            this.lblLive_Run = new System.Windows.Forms.ToolStripButton();
            this.lblLive_Stop = new System.Windows.Forms.ToolStripButton();
            this.lblSnap = new System.Windows.Forms.ToolStripButton();
            this.btnSaveImage = new System.Windows.Forms.ToolStripButton();
            this.btnDirectSave = new System.Windows.Forms.ToolStripButton();
            this.btnStep5 = new System.Windows.Forms.ToolStripSeparator();
            this.lblLockROIEdit = new System.Windows.Forms.ToolStripButton();
            this.lblUnlockRoiEdit = new System.Windows.Forms.ToolStripButton();
            this.lblTest = new System.Windows.Forms.ToolStripButton();
            this.mnuMenuShape = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddRectangSub = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRectang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRectang1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRectang_Diff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRectang1_Diff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRectang_I = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRectang1_I = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRectang_U = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRectang1_U = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCircleSub = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCircle_Diff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCircle_I = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCircle_U = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddMasterRoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddMarkRoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddShapeWithRangMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyROI = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPatseRoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPasteWithLink = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPasteOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyThisROIToMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLinkToMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChange = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMultiSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.SmartWindow = new GraphicsWindow.GraphicsWindow();
            this.pnlQuickInfo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMinG = new System.Windows.Forms.Label();
            this.lblRangeG = new System.Windows.Forms.Label();
            this.lblMaxG = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblRegionIndex = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblCordinatePreview = new System.Windows.Forms.Label();
            this.lblPopup = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.pnlTools.SuspendLayout();
            this.mnuMenuShape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmartWindow)).BeginInit();
            this.pnlQuickInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCordinate);
            this.panel1.Controls.Add(this.lblImagePath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 33);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblCordinate
            // 
            this.lblCordinate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCordinate.AutoSize = true;
            this.lblCordinate.Location = new System.Drawing.Point(864, 10);
            this.lblCordinate.Name = "lblCordinate";
            this.lblCordinate.Size = new System.Drawing.Size(153, 13);
            this.lblCordinate.TabIndex = 0;
            this.lblCordinate.Text = "X: 526.65 Y: 355.25 - I: 100.00";
            // 
            // lblImagePath
            // 
            this.lblImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImagePath.Location = new System.Drawing.Point(12, 6);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(746, 20);
            this.lblImagePath.TabIndex = 0;
            this.lblImagePath.Text = "F:\\";
            this.lblImagePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.btnLockROI);
            this.panel2.Controls.Add(this.btnMoveROIWithKey);
            this.panel2.Controls.Add(this.btnMultiSelect);
            this.panel2.Controls.Add(this.mnuViewMarkName);
            this.panel2.Controls.Add(this.isViewMarkRoi);
            this.panel2.Controls.Add(this.mnuViewRoiName);
            this.panel2.Controls.Add(this.mnuIsViewNormalRoi);
            this.panel2.Controls.Add(this.mnuIsViewMasterRoi);
            this.panel2.Controls.Add(this.mnuIsViewMasterName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 633);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1204, 37);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(847, 8);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnLockROI
            // 
            this.btnLockROI.Location = new System.Drawing.Point(766, 7);
            this.btnLockROI.Name = "btnLockROI";
            this.btnLockROI.Size = new System.Drawing.Size(75, 23);
            this.btnLockROI.TabIndex = 1;
            this.btnLockROI.Text = "LOCK";
            this.btnLockROI.UseVisualStyleBackColor = true;
            // 
            // btnMoveROIWithKey
            // 
            this.btnMoveROIWithKey.Location = new System.Drawing.Point(682, 7);
            this.btnMoveROIWithKey.Name = "btnMoveROIWithKey";
            this.btnMoveROIWithKey.Size = new System.Drawing.Size(75, 23);
            this.btnMoveROIWithKey.TabIndex = 1;
            this.btnMoveROIWithKey.Text = "None";
            this.btnMoveROIWithKey.UseVisualStyleBackColor = true;
            // 
            // btnMultiSelect
            // 
            this.btnMultiSelect.Location = new System.Drawing.Point(601, 7);
            this.btnMultiSelect.Name = "btnMultiSelect";
            this.btnMultiSelect.Size = new System.Drawing.Size(75, 23);
            this.btnMultiSelect.TabIndex = 1;
            this.btnMultiSelect.Text = "MULTI";
            this.btnMultiSelect.UseVisualStyleBackColor = true;
            this.btnMultiSelect.Click += new System.EventHandler(this.btnMultiSelect_Click);
            // 
            // mnuViewMarkName
            // 
            this.mnuViewMarkName.AutoSize = true;
            this.mnuViewMarkName.Location = new System.Drawing.Point(319, 10);
            this.mnuViewMarkName.Name = "mnuViewMarkName";
            this.mnuViewMarkName.Size = new System.Drawing.Size(81, 17);
            this.mnuViewMarkName.TabIndex = 0;
            this.mnuViewMarkName.Text = "Mark Name";
            this.mnuViewMarkName.UseVisualStyleBackColor = true;
            // 
            // isViewMarkRoi
            // 
            this.isViewMarkRoi.AutoSize = true;
            this.isViewMarkRoi.Location = new System.Drawing.Point(263, 10);
            this.isViewMarkRoi.Name = "isViewMarkRoi";
            this.isViewMarkRoi.Size = new System.Drawing.Size(50, 17);
            this.isViewMarkRoi.TabIndex = 0;
            this.isViewMarkRoi.Text = "Mark";
            this.isViewMarkRoi.UseVisualStyleBackColor = true;
            // 
            // mnuViewRoiName
            // 
            this.mnuViewRoiName.AutoSize = true;
            this.mnuViewRoiName.Location = new System.Drawing.Point(483, 10);
            this.mnuViewRoiName.Name = "mnuViewRoiName";
            this.mnuViewRoiName.Size = new System.Drawing.Size(112, 17);
            this.mnuViewRoiName.TabIndex = 0;
            this.mnuViewRoiName.Text = "Normal ROI Name";
            this.mnuViewRoiName.UseVisualStyleBackColor = true;
            // 
            // mnuIsViewNormalRoi
            // 
            this.mnuIsViewNormalRoi.AutoSize = true;
            this.mnuIsViewNormalRoi.Location = new System.Drawing.Point(406, 10);
            this.mnuIsViewNormalRoi.Name = "mnuIsViewNormalRoi";
            this.mnuIsViewNormalRoi.Size = new System.Drawing.Size(78, 17);
            this.mnuIsViewNormalRoi.TabIndex = 0;
            this.mnuIsViewNormalRoi.Text = "Nomal ROI";
            this.mnuIsViewNormalRoi.UseVisualStyleBackColor = true;
            // 
            // mnuIsViewMasterRoi
            // 
            this.mnuIsViewMasterRoi.AutoSize = true;
            this.mnuIsViewMasterRoi.Location = new System.Drawing.Point(104, 10);
            this.mnuIsViewMasterRoi.Name = "mnuIsViewMasterRoi";
            this.mnuIsViewMasterRoi.Size = new System.Drawing.Size(58, 17);
            this.mnuIsViewMasterRoi.TabIndex = 0;
            this.mnuIsViewMasterRoi.Text = "Master";
            this.mnuIsViewMasterRoi.UseVisualStyleBackColor = true;
            this.mnuIsViewMasterRoi.CheckedChanged += new System.EventHandler(this.mnuIsViewMasterRoi_CheckedChanged);
            // 
            // mnuIsViewMasterName
            // 
            this.mnuIsViewMasterName.AutoSize = true;
            this.mnuIsViewMasterName.Location = new System.Drawing.Point(0, 0);
            this.mnuIsViewMasterName.Name = "mnuIsViewMasterName";
            this.mnuIsViewMasterName.Size = new System.Drawing.Size(89, 17);
            this.mnuIsViewMasterName.TabIndex = 0;
            this.mnuIsViewMasterName.Text = "Master Name";
            this.mnuIsViewMasterName.UseVisualStyleBackColor = true;
            // 
            // pnlTools
            // 
            this.pnlTools.AutoSize = false;
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.pnlTools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.pnlTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStep1,
            this.btnDraw,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.btnDelete,
            this.btnStep2,
            this.btnZoom,
            this.btnZoomEX,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnFitImageEx,
            this.btnStep3,
            this.btnRenameROI,
            this.btnMoveROI,
            this.btnStep4,
            this.btnConnectCamera,
            this.lblLive_Run,
            this.lblLive_Stop,
            this.lblSnap,
            this.btnSaveImage,
            this.btnDirectSave,
            this.btnStep5,
            this.lblLockROIEdit,
            this.lblUnlockRoiEdit,
            this.lblTest});
            this.pnlTools.Location = new System.Drawing.Point(0, 0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(30, 670);
            this.pnlTools.TabIndex = 6;
            this.pnlTools.Text = "toolStrip2";
            this.pnlTools.Visible = false;
            // 
            // btnStep1
            // 
            this.btnStep1.Name = "btnStep1";
            this.btnStep1.Size = new System.Drawing.Size(28, 6);
            // 
            // btnDraw
            // 
            this.btnDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDraw.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDrawRectang,
            this.btnDrawCircle,
            this.polygonToolStripMenuItem});
            this.btnDraw.Image = ((System.Drawing.Image)(resources.GetObject("btnDraw.Image")));
            this.btnDraw.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(28, 24);
            this.btnDraw.Text = "toolStripSplitButton1";
            // 
            // btnDrawRectang
            // 
            this.btnDrawRectang.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawRectang.Image")));
            this.btnDrawRectang.Name = "btnDrawRectang";
            this.btnDrawRectang.Size = new System.Drawing.Size(126, 22);
            this.btnDrawRectang.Text = "Rectangle";
            this.btnDrawRectang.Click += new System.EventHandler(this.btnDrawRectang_Click);
            // 
            // btnDrawCircle
            // 
            this.btnDrawCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawCircle.Image")));
            this.btnDrawCircle.Name = "btnDrawCircle";
            this.btnDrawCircle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDrawCircle.Size = new System.Drawing.Size(126, 22);
            this.btnDrawCircle.Text = "Circle";
            this.btnDrawCircle.Click += new System.EventHandler(this.btnDrawCircle_Click);
            // 
            // polygonToolStripMenuItem
            // 
            this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            this.polygonToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.polygonToolStripMenuItem.Text = "Polygon";
            this.polygonToolStripMenuItem.Visible = false;
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Image = global::RTC_Vision_Lite.Properties.Resources.Cut_16x16;
            this.btnCut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(28, 24);
            this.btnCut.Text = "toolStripButton1";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 24);
            this.btnCopy.Text = "toolStripButton2";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(28, 24);
            this.btnPaste.Text = "toolStripButton3";
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 24);
            this.btnDelete.Text = "toolStripButton4";
            // 
            // btnStep2
            // 
            this.btnStep2.Name = "btnStep2";
            this.btnStep2.Size = new System.Drawing.Size(28, 6);
            // 
            // btnZoom
            // 
            this.btnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnZoom.Image")));
            this.btnZoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(28, 24);
            this.btnZoom.Text = "toolStripSplitButton1";
            // 
            // btnZoomEX
            // 
            this.btnZoomEX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomEX.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomEX.Image")));
            this.btnZoomEX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoomEX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomEX.Name = "btnZoomEX";
            this.btnZoomEX.Size = new System.Drawing.Size(28, 24);
            this.btnZoomEX.Text = "toolStripButton6";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = global::RTC_Vision_Lite.Properties.Resources.ZoomIn_16x161;
            this.btnZoomIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(28, 24);
            this.btnZoomIn.Text = "toolStripButton7";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(28, 24);
            this.btnZoomOut.Text = "toolStripButton8";
            // 
            // btnFitImageEx
            // 
            this.btnFitImageEx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFitImageEx.Image = global::RTC_Vision_Lite.Properties.Resources.Zoom2_16x16;
            this.btnFitImageEx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFitImageEx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFitImageEx.Name = "btnFitImageEx";
            this.btnFitImageEx.Size = new System.Drawing.Size(28, 24);
            this.btnFitImageEx.Text = "toolStripButton9";
            // 
            // btnStep3
            // 
            this.btnStep3.Name = "btnStep3";
            this.btnStep3.Size = new System.Drawing.Size(28, 6);
            // 
            // btnRenameROI
            // 
            this.btnRenameROI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRenameROI.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameROI.Image")));
            this.btnRenameROI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenameROI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRenameROI.Name = "btnRenameROI";
            this.btnRenameROI.Size = new System.Drawing.Size(28, 24);
            this.btnRenameROI.Text = "toolStripButton10";
            // 
            // btnMoveROI
            // 
            this.btnMoveROI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveROI.Image = global::RTC_Vision_Lite.Properties.Resources.Close16x16_1;
            this.btnMoveROI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoveROI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveROI.Name = "btnMoveROI";
            this.btnMoveROI.Size = new System.Drawing.Size(28, 24);
            // 
            // btnStep4
            // 
            this.btnStep4.Name = "btnStep4";
            this.btnStep4.Size = new System.Drawing.Size(28, 6);
            // 
            // btnConnectCamera
            // 
            this.btnConnectCamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnectCamera.Image = global::RTC_Vision_Lite.Properties.Resources.camera1;
            this.btnConnectCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectCamera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnectCamera.Margin = new System.Windows.Forms.Padding(0);
            this.btnConnectCamera.Name = "btnConnectCamera";
            this.btnConnectCamera.Size = new System.Drawing.Size(28, 24);
            this.btnConnectCamera.Text = "toolStripButton12";
            this.btnConnectCamera.Click += new System.EventHandler(this.btnConnectCamera_Click);
            // 
            // lblLive_Run
            // 
            this.lblLive_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblLive_Run.Image = ((System.Drawing.Image)(resources.GetObject("lblLive_Run.Image")));
            this.lblLive_Run.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLive_Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblLive_Run.Name = "lblLive_Run";
            this.lblLive_Run.Size = new System.Drawing.Size(28, 24);
            this.lblLive_Run.Text = "toolStripButton13";
            // 
            // lblLive_Stop
            // 
            this.lblLive_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblLive_Stop.Image = ((System.Drawing.Image)(resources.GetObject("lblLive_Stop.Image")));
            this.lblLive_Stop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLive_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblLive_Stop.Name = "lblLive_Stop";
            this.lblLive_Stop.Size = new System.Drawing.Size(28, 24);
            this.lblLive_Stop.Text = "toolStripButton14";
            // 
            // lblSnap
            // 
            this.lblSnap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblSnap.Image = ((System.Drawing.Image)(resources.GetObject("lblSnap.Image")));
            this.lblSnap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSnap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblSnap.Name = "lblSnap";
            this.lblSnap.Size = new System.Drawing.Size(28, 24);
            this.lblSnap.Text = "toolStripButton15";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
            this.btnSaveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(28, 24);
            this.btnSaveImage.Text = "toolStripButton16";
            // 
            // btnDirectSave
            // 
            this.btnDirectSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDirectSave.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectSave.Image")));
            this.btnDirectSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDirectSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDirectSave.Name = "btnDirectSave";
            this.btnDirectSave.Size = new System.Drawing.Size(28, 24);
            this.btnDirectSave.Text = "toolStripButton17";
            // 
            // btnStep5
            // 
            this.btnStep5.Name = "btnStep5";
            this.btnStep5.Size = new System.Drawing.Size(28, 6);
            // 
            // lblLockROIEdit
            // 
            this.lblLockROIEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblLockROIEdit.Image = ((System.Drawing.Image)(resources.GetObject("lblLockROIEdit.Image")));
            this.lblLockROIEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblLockROIEdit.Name = "lblLockROIEdit";
            this.lblLockROIEdit.Size = new System.Drawing.Size(28, 24);
            this.lblLockROIEdit.Text = "toolStripButton18";
            // 
            // lblUnlockRoiEdit
            // 
            this.lblUnlockRoiEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblUnlockRoiEdit.Image = ((System.Drawing.Image)(resources.GetObject("lblUnlockRoiEdit.Image")));
            this.lblUnlockRoiEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblUnlockRoiEdit.Name = "lblUnlockRoiEdit";
            this.lblUnlockRoiEdit.Size = new System.Drawing.Size(28, 24);
            this.lblUnlockRoiEdit.Text = "toolStripButton19";
            // 
            // lblTest
            // 
            this.lblTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblTest.Image = ((System.Drawing.Image)(resources.GetObject("lblTest.Image")));
            this.lblTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(28, 24);
            this.lblTest.Text = "toolStripButton20";
            // 
            // mnuMenuShape
            // 
            this.mnuMenuShape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddRectangSub,
            this.mnuAddCircleSub,
            this.mnuAddMasterRoi,
            this.mnuAddMarkRoi,
            this.mnuAddShapeWithRangMode,
            this.mnuCopyROI,
            this.mnuPatseRoi,
            this.mnuPasteWithLink,
            this.mnuPasteOrigin,
            this.mnuCopyThisROIToMaster,
            this.mnuLinkToMaster,
            this.mnuChangeName,
            this.mnuChange,
            this.mnuSelectAll,
            this.mnuDeselectAll,
            this.mnuDelete,
            this.mnuClearAll,
            this.mnuMultiSelect});
            this.mnuMenuShape.Name = "mnuMenuShape";
            this.mnuMenuShape.Size = new System.Drawing.Size(224, 400);
            // 
            // mnuAddRectangSub
            // 
            this.mnuAddRectangSub.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddRectang,
            this.mnuAddRectang1,
            this.mnuAddRectang_Diff,
            this.mnuAddRectang1_Diff,
            this.mnuAddRectang_I,
            this.mnuAddRectang1_I,
            this.mnuAddRectang_U,
            this.mnuAddRectang1_U});
            this.mnuAddRectangSub.Name = "mnuAddRectangSub";
            this.mnuAddRectangSub.Size = new System.Drawing.Size(223, 22);
            this.mnuAddRectangSub.Text = "Add Rectang";
            this.mnuAddRectangSub.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.mnuAddRectangSub.Click += new System.EventHandler(this.mnuAddRectangSub_Click);
            // 
            // mnuAddRectang
            // 
            this.mnuAddRectang.Name = "mnuAddRectang";
            this.mnuAddRectang.Size = new System.Drawing.Size(197, 22);
            this.mnuAddRectang.Text = "Normal";
            this.mnuAddRectang.Click += new System.EventHandler(this.mnuAddRectang_Click);
            // 
            // mnuAddRectang1
            // 
            this.mnuAddRectang1.Name = "mnuAddRectang1";
            this.mnuAddRectang1.Size = new System.Drawing.Size(197, 22);
            this.mnuAddRectang1.Text = "Normal (No Angle)";
            this.mnuAddRectang1.Click += new System.EventHandler(this.mnuAddRectang1_Click);
            // 
            // mnuAddRectang_Diff
            // 
            this.mnuAddRectang_Diff.Name = "mnuAddRectang_Diff";
            this.mnuAddRectang_Diff.Size = new System.Drawing.Size(197, 22);
            this.mnuAddRectang_Diff.Text = "Difference";
            this.mnuAddRectang_Diff.Click += new System.EventHandler(this.mnuAddRectang_Diff_Click);
            // 
            // mnuAddRectang1_Diff
            // 
            this.mnuAddRectang1_Diff.Name = "mnuAddRectang1_Diff";
            this.mnuAddRectang1_Diff.Size = new System.Drawing.Size(197, 22);
            this.mnuAddRectang1_Diff.Text = "Diff (No Angle)";
            this.mnuAddRectang1_Diff.Click += new System.EventHandler(this.mnuAddRectang1_Diff_Click);
            // 
            // mnuAddRectang_I
            // 
            this.mnuAddRectang_I.Name = "mnuAddRectang_I";
            this.mnuAddRectang_I.Size = new System.Drawing.Size(197, 22);
            this.mnuAddRectang_I.Text = "Intersection";
            this.mnuAddRectang_I.Click += new System.EventHandler(this.mnuAddRectang_I_Click);
            // 
            // mnuAddRectang1_I
            // 
            this.mnuAddRectang1_I.Name = "mnuAddRectang1_I";
            this.mnuAddRectang1_I.Size = new System.Drawing.Size(197, 22);
            this.mnuAddRectang1_I.Text = "Intersection (No Angle)";
            this.mnuAddRectang1_I.Click += new System.EventHandler(this.mnuAddRectang1_I_Click);
            // 
            // mnuAddRectang_U
            // 
            this.mnuAddRectang_U.Name = "mnuAddRectang_U";
            this.mnuAddRectang_U.Size = new System.Drawing.Size(197, 22);
            this.mnuAddRectang_U.Text = "Union";
            this.mnuAddRectang_U.Click += new System.EventHandler(this.mnuAddRectang_U_Click);
            // 
            // mnuAddRectang1_U
            // 
            this.mnuAddRectang1_U.Name = "mnuAddRectang1_U";
            this.mnuAddRectang1_U.Size = new System.Drawing.Size(197, 22);
            this.mnuAddRectang1_U.Text = "Union (No Angle)";
            this.mnuAddRectang1_U.Click += new System.EventHandler(this.mnuAddRectang1_U_Click);
            // 
            // mnuAddCircleSub
            // 
            this.mnuAddCircleSub.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddCircle,
            this.mnuAddCircle_Diff,
            this.mnuAddCircle_I,
            this.mnuAddCircle_U});
            this.mnuAddCircleSub.Name = "mnuAddCircleSub";
            this.mnuAddCircleSub.Size = new System.Drawing.Size(223, 22);
            this.mnuAddCircleSub.Text = "Add Circle";
            // 
            // mnuAddCircle
            // 
            this.mnuAddCircle.Name = "mnuAddCircle";
            this.mnuAddCircle.Size = new System.Drawing.Size(136, 22);
            this.mnuAddCircle.Text = "Nomal";
            this.mnuAddCircle.Click += new System.EventHandler(this.mnuAddCircle_Click);
            // 
            // mnuAddCircle_Diff
            // 
            this.mnuAddCircle_Diff.Name = "mnuAddCircle_Diff";
            this.mnuAddCircle_Diff.Size = new System.Drawing.Size(136, 22);
            this.mnuAddCircle_Diff.Text = "Difference";
            this.mnuAddCircle_Diff.Click += new System.EventHandler(this.mnuAddCircle_Diff_Click);
            // 
            // mnuAddCircle_I
            // 
            this.mnuAddCircle_I.Name = "mnuAddCircle_I";
            this.mnuAddCircle_I.Size = new System.Drawing.Size(136, 22);
            this.mnuAddCircle_I.Text = "Intersection";
            this.mnuAddCircle_I.Click += new System.EventHandler(this.mnuAddCircle_I_Click);
            // 
            // mnuAddCircle_U
            // 
            this.mnuAddCircle_U.Name = "mnuAddCircle_U";
            this.mnuAddCircle_U.Size = new System.Drawing.Size(136, 22);
            this.mnuAddCircle_U.Text = "Union";
            // 
            // mnuAddMasterRoi
            // 
            this.mnuAddMasterRoi.Name = "mnuAddMasterRoi";
            this.mnuAddMasterRoi.Size = new System.Drawing.Size(223, 22);
            this.mnuAddMasterRoi.Text = "Add Master ROI";
            this.mnuAddMasterRoi.Visible = false;
            // 
            // mnuAddMarkRoi
            // 
            this.mnuAddMarkRoi.Name = "mnuAddMarkRoi";
            this.mnuAddMarkRoi.Size = new System.Drawing.Size(223, 22);
            this.mnuAddMarkRoi.Text = "toolStripMenuItem1";
            this.mnuAddMarkRoi.Visible = false;
            // 
            // mnuAddShapeWithRangMode
            // 
            this.mnuAddShapeWithRangMode.Name = "mnuAddShapeWithRangMode";
            this.mnuAddShapeWithRangMode.Size = new System.Drawing.Size(223, 22);
            this.mnuAddShapeWithRangMode.Text = "Add Shape With Rang Mode";
            this.mnuAddShapeWithRangMode.Visible = false;
            // 
            // mnuCopyROI
            // 
            this.mnuCopyROI.Name = "mnuCopyROI";
            this.mnuCopyROI.Size = new System.Drawing.Size(223, 22);
            this.mnuCopyROI.Text = "Copy";
            this.mnuCopyROI.Click += new System.EventHandler(this.mnuCopyROI_Click);
            // 
            // mnuPatseRoi
            // 
            this.mnuPatseRoi.Name = "mnuPatseRoi";
            this.mnuPatseRoi.Size = new System.Drawing.Size(223, 22);
            this.mnuPatseRoi.Text = "Paste";
            this.mnuPatseRoi.Click += new System.EventHandler(this.mnuPatseRoi_Click);
            // 
            // mnuPasteWithLink
            // 
            this.mnuPasteWithLink.Name = "mnuPasteWithLink";
            this.mnuPasteWithLink.Size = new System.Drawing.Size(223, 22);
            this.mnuPasteWithLink.Text = "Patse With Link";
            this.mnuPasteWithLink.Visible = false;
            // 
            // mnuPasteOrigin
            // 
            this.mnuPasteOrigin.Name = "mnuPasteOrigin";
            this.mnuPasteOrigin.Size = new System.Drawing.Size(223, 22);
            this.mnuPasteOrigin.Text = "Paste Origin";
            this.mnuPasteOrigin.Visible = false;
            // 
            // mnuCopyThisROIToMaster
            // 
            this.mnuCopyThisROIToMaster.Name = "mnuCopyThisROIToMaster";
            this.mnuCopyThisROIToMaster.Size = new System.Drawing.Size(223, 22);
            this.mnuCopyThisROIToMaster.Text = "Copy This ROI To Master";
            this.mnuCopyThisROIToMaster.Visible = false;
            // 
            // mnuLinkToMaster
            // 
            this.mnuLinkToMaster.Name = "mnuLinkToMaster";
            this.mnuLinkToMaster.Size = new System.Drawing.Size(223, 22);
            this.mnuLinkToMaster.Text = "Link To Master...";
            this.mnuLinkToMaster.Visible = false;
            // 
            // mnuChangeName
            // 
            this.mnuChangeName.Name = "mnuChangeName";
            this.mnuChangeName.Size = new System.Drawing.Size(223, 22);
            this.mnuChangeName.Text = "Change Name";
            this.mnuChangeName.Visible = false;
            this.mnuChangeName.Click += new System.EventHandler(this.mnuChangeName_Click);
            // 
            // mnuChange
            // 
            this.mnuChange.Name = "mnuChange";
            this.mnuChange.Size = new System.Drawing.Size(223, 22);
            this.mnuChange.Text = "Change To...";
            this.mnuChange.Visible = false;
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(223, 22);
            this.mnuSelectAll.Text = "Select All";
            this.mnuSelectAll.Visible = false;
            // 
            // mnuDeselectAll
            // 
            this.mnuDeselectAll.Name = "mnuDeselectAll";
            this.mnuDeselectAll.Size = new System.Drawing.Size(223, 22);
            this.mnuDeselectAll.Text = "Deselect All";
            this.mnuDeselectAll.Visible = false;
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(223, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuClearAll
            // 
            this.mnuClearAll.Image = global::RTC_Vision_Lite.Properties.Resources.Clear_16x16;
            this.mnuClearAll.Name = "mnuClearAll";
            this.mnuClearAll.Size = new System.Drawing.Size(223, 22);
            this.mnuClearAll.Text = "ClearAll";
            this.mnuClearAll.Click += new System.EventHandler(this.mnuClearAll_Click);
            // 
            // mnuMultiSelect
            // 
            this.mnuMultiSelect.Name = "mnuMultiSelect";
            this.mnuMultiSelect.ShortcutKeyDisplayString = "Middle Mouse";
            this.mnuMultiSelect.Size = new System.Drawing.Size(223, 22);
            this.mnuMultiSelect.Text = "Multi Select";
            this.mnuMultiSelect.Visible = false;
            this.mnuMultiSelect.Click += new System.EventHandler(this.mnuMultiSelect_Click);
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
            this.SmartWindow.Location = new System.Drawing.Point(26, 50);
            this.SmartWindow.LockRoi = true;
            this.SmartWindow.MoveImage = true;
            this.SmartWindow.Name = "SmartWindow";
            this.SmartWindow.Size = new System.Drawing.Size(1155, 600);
            this.SmartWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SmartWindow.TabIndex = 7;
            this.SmartWindow.TabStop = false;
            this.SmartWindow.ZoomClick = false;
            this.SmartWindow.ZoomIN = true;
            this.SmartWindow.ZoomMouseWheel = true;
            this.SmartWindow.ZoomOut = true;
            this.SmartWindow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SmartWindow_MouseClick);
            this.SmartWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SmartWindow_MouseDown);
            this.SmartWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SmartWindow_MouseMove);
            this.SmartWindow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SmartWindow_MouseUp);
            // 
            // pnlQuickInfo
            // 
            this.pnlQuickInfo.Controls.Add(this.label4);
            this.pnlQuickInfo.Controls.Add(this.label1);
            this.pnlQuickInfo.Controls.Add(this.lblMinG);
            this.pnlQuickInfo.Controls.Add(this.lblRangeG);
            this.pnlQuickInfo.Controls.Add(this.lblMaxG);
            this.pnlQuickInfo.Controls.Add(this.lblH);
            this.pnlQuickInfo.Controls.Add(this.lblV);
            this.pnlQuickInfo.Controls.Add(this.lblS);
            this.pnlQuickInfo.Controls.Add(this.label10);
            this.pnlQuickInfo.Controls.Add(this.lblG);
            this.pnlQuickInfo.Controls.Add(this.lblI);
            this.pnlQuickInfo.Controls.Add(this.lblB);
            this.pnlQuickInfo.Controls.Add(this.lblRegionIndex);
            this.pnlQuickInfo.Controls.Add(this.lblR);
            this.pnlQuickInfo.Controls.Add(this.lblCordinatePreview);
            this.pnlQuickInfo.Location = new System.Drawing.Point(334, 291);
            this.pnlQuickInfo.Name = "pnlQuickInfo";
            this.pnlQuickInfo.Size = new System.Drawing.Size(215, 138);
            this.pnlQuickInfo.TabIndex = 8;
            this.pnlQuickInfo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(141, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Image";
            // 
            // lblMinG
            // 
            this.lblMinG.AutoSize = true;
            this.lblMinG.Location = new System.Drawing.Point(141, 40);
            this.lblMinG.Name = "lblMinG";
            this.lblMinG.Size = new System.Drawing.Size(43, 13);
            this.lblMinG.TabIndex = 17;
            this.lblMinG.Text = "minG: 0";
            // 
            // lblRangeG
            // 
            this.lblRangeG.AutoSize = true;
            this.lblRangeG.Location = new System.Drawing.Point(141, 76);
            this.lblRangeG.Name = "lblRangeG";
            this.lblRangeG.Size = new System.Drawing.Size(54, 13);
            this.lblRangeG.TabIndex = 16;
            this.lblRangeG.Text = "rangeG: 0";
            // 
            // lblMaxG
            // 
            this.lblMaxG.AutoSize = true;
            this.lblMaxG.Location = new System.Drawing.Point(141, 58);
            this.lblMaxG.Name = "lblMaxG";
            this.lblMaxG.Size = new System.Drawing.Size(46, 13);
            this.lblMaxG.TabIndex = 15;
            this.lblMaxG.Text = "maxG: 0";
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Location = new System.Drawing.Point(81, 40);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(27, 13);
            this.lblH.TabIndex = 12;
            this.lblH.Text = "H: 0";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Location = new System.Drawing.Point(81, 76);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(26, 13);
            this.lblV.TabIndex = 11;
            this.lblV.Text = "V: 0";
            // 
            // lblS
            // 
            this.lblS.AutoSize = true;
            this.lblS.Location = new System.Drawing.Point(81, 58);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(26, 13);
            this.lblS.TabIndex = 10;
            this.lblS.Text = "S: 0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Image";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(26, 58);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(27, 13);
            this.lblG.TabIndex = 7;
            this.lblG.Text = "G: 0";
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Location = new System.Drawing.Point(30, 94);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(22, 13);
            this.lblI.TabIndex = 6;
            this.lblI.Text = "I: 0";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(26, 76);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(26, 13);
            this.lblB.TabIndex = 5;
            this.lblB.Text = "B: 0";
            // 
            // lblRegionIndex
            // 
            this.lblRegionIndex.AutoSize = true;
            this.lblRegionIndex.Location = new System.Drawing.Point(26, 112);
            this.lblRegionIndex.Name = "lblRegionIndex";
            this.lblRegionIndex.Size = new System.Drawing.Size(99, 13);
            this.lblRegionIndex.TabIndex = 4;
            this.lblRegionIndex.Text = "Region InputThree:";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(26, 40);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(27, 13);
            this.lblR.TabIndex = 1;
            this.lblR.Text = "R: 0";
            // 
            // lblCordinatePreview
            // 
            this.lblCordinatePreview.AutoSize = true;
            this.lblCordinatePreview.Location = new System.Drawing.Point(15, 0);
            this.lblCordinatePreview.Name = "lblCordinatePreview";
            this.lblCordinatePreview.Size = new System.Drawing.Size(102, 13);
            this.lblCordinatePreview.TabIndex = 0;
            this.lblCordinatePreview.Text = "X: 526.65 Y: 355.25";
            // 
            // lblPopup
            // 
            this.lblPopup.AutoSize = true;
            this.lblPopup.Location = new System.Drawing.Point(977, 50);
            this.lblPopup.Name = "lblPopup";
            this.lblPopup.Size = new System.Drawing.Size(48, 13);
            this.lblPopup.TabIndex = 20;
            this.lblPopup.Text = "lblPopup";
            this.lblPopup.Visible = false;
            // 
            // FrmHsmartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1204, 670);
            this.ControlBox = false;
            this.Controls.Add(this.lblPopup);
            this.Controls.Add(this.pnlQuickInfo);
            this.Controls.Add(this.SmartWindow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTools);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHsmartWindow";
            this.Text = "FrmHsmartWindow";
            this.Load += new System.EventHandler(this.FrmHsmartWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.mnuMenuShape.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SmartWindow)).EndInit();
            this.pnlQuickInfo.ResumeLayout(false);
            this.pnlQuickInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCordinate;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnLockROI;
        private System.Windows.Forms.Button btnMoveROIWithKey;
        private System.Windows.Forms.Button btnMultiSelect;
        private System.Windows.Forms.CheckBox mnuViewMarkName;
        private System.Windows.Forms.CheckBox isViewMarkRoi;
        private System.Windows.Forms.CheckBox mnuViewRoiName;
        private System.Windows.Forms.CheckBox mnuIsViewNormalRoi;
        private System.Windows.Forms.ToolStrip pnlTools;
        private System.Windows.Forms.ToolStripSplitButton btnDraw;
        private System.Windows.Forms.ToolStripSeparator btnStep1;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator btnStep2;
        private System.Windows.Forms.ToolStripSplitButton btnZoom;
        private System.Windows.Forms.ToolStripButton btnZoomEX;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripButton btnFitImageEx;
        private System.Windows.Forms.ToolStripSeparator btnStep3;
        private System.Windows.Forms.ToolStripButton btnRenameROI;
        private System.Windows.Forms.ToolStripButton btnMoveROI;
        private System.Windows.Forms.ToolStripSeparator btnStep4;
        private System.Windows.Forms.ToolStripButton btnConnectCamera;
        private System.Windows.Forms.ToolStripButton lblLive_Run;
        private System.Windows.Forms.ToolStripButton lblLive_Stop;
        private System.Windows.Forms.ToolStripButton lblSnap;
        private System.Windows.Forms.ToolStripButton btnSaveImage;
        private System.Windows.Forms.ToolStripButton btnDirectSave;
        private System.Windows.Forms.ToolStripSeparator btnStep5;
        private System.Windows.Forms.ToolStripButton lblLockROIEdit;
        private System.Windows.Forms.ToolStripButton lblUnlockRoiEdit;
        private System.Windows.Forms.ToolStripButton lblTest;
        private System.Windows.Forms.CheckBox mnuIsViewMasterName;
        private System.Windows.Forms.CheckBox mnuIsViewMasterRoi;
        private System.Windows.Forms.ToolStripMenuItem btnDrawCircle;
        private System.Windows.Forms.ToolStripMenuItem btnDrawRectang;
        private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnuMenuShape;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectangSub;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCircleSub;
        private System.Windows.Forms.ToolStripMenuItem mnuAddMasterRoi;
        private System.Windows.Forms.ToolStripMenuItem mnuAddShapeWithRangMode;
        private System.Windows.Forms.ToolStripMenuItem mnuPatseRoi;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteOrigin;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyThisROIToMaster;
        private System.Windows.Forms.ToolStripMenuItem mnuLinkToMaster;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeName;
        private System.Windows.Forms.ToolStripMenuItem mnuAddMarkRoi;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyROI;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteWithLink;
        private System.Windows.Forms.ToolStripMenuItem mnuChange;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuDeselectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAll;
        private System.Windows.Forms.ToolStripMenuItem mnuMultiSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectang;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectang1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectang_Diff;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectang1_Diff;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectang_I;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectang1_I;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectang_U;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRectang1_U;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCircle;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCircle_Diff;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCircle_I;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCircle_U;
        public GraphicsWindow.GraphicsWindow SmartWindow;
        private System.Windows.Forms.Panel pnlQuickInfo;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblRegionIndex;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblCordinatePreview;
        private System.Windows.Forms.Label lblMinG;
        private System.Windows.Forms.Label lblRangeG;
        private System.Windows.Forms.Label lblMaxG;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPopup;
    }
}