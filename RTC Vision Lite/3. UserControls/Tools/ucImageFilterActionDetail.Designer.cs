
namespace RTC_Vision_Lite.UserControls
{
    partial class ucImageFilterActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImageFilterActionDetail));
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRunStringBuilder = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.tlFilterList = new RTC_Vision_Lite.UserControls.MyTreeList();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colActive = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colOrderNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colFilterType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMaskWidth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMaskHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIterations = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colThresholdRange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colGreyValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRangeOutputPixel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colOutRangeOutputPixel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colScaleFactor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMargin = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRegion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEnable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colResult = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ABC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lblRegionLink = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlFilterList)).BeginInit();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            this.PageActionSetting.Size = new System.Drawing.Size(1200, 656);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label2);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Location = new System.Drawing.Point(5, 5);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1149, 556);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(5, 51);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PageSetup.Size = new System.Drawing.Size(1182, 574);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(5);
            this.ROI.Padding = new System.Windows.Forms.Padding(5);
            this.ROI.Size = new System.Drawing.Size(1159, 511);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(5);
            this.PassFail.Size = new System.Drawing.Size(1159, 511);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1159, 511);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.lblRegionLink);
            this.ScrollableROI.Controls.Add(this.tlFilterList);
            this.ScrollableROI.Controls.Add(this.flowLayoutPanel3);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Location = new System.Drawing.Point(5, 5);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableROI.Size = new System.Drawing.Size(1149, 501);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Size = new System.Drawing.Size(1182, 46);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(5);
            this.General.Padding = new System.Windows.Forms.Padding(5);
            this.General.Size = new System.Drawing.Size(1159, 566);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(5);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(5);
            this.TabSetUp.Size = new System.Drawing.Size(1192, 630);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(5);
            this.Method.Padding = new System.Windows.Forms.Padding(5);
            this.Method.Size = new System.Drawing.Size(1159, 511);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(5);
            this.Display.Size = new System.Drawing.Size(1159, 511);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(5, 5);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableMethod.Size = new System.Drawing.Size(1149, 501);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(1151, 503);
            // 
            // Selecticon
            // 
            this.Selecticon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Selecticon.ImageStream")));
            this.Selecticon.Images.SetKeyName(0, "Input");
            this.Selecticon.Images.SetKeyName(1, "Output");
            this.Selecticon.Images.SetKeyName(2, "Link");
            this.Selecticon.Images.SetKeyName(3, "Next");
            this.Selecticon.Images.SetKeyName(4, "System");
            this.Selecticon.Images.SetKeyName(5, "SaveInput");
            this.Selecticon.Images.SetKeyName(6, "RemoveLink.ico");
            this.Selecticon.Images.SetKeyName(7, "LinkProperty");
            this.Selecticon.Images.SetKeyName(8, "ViewListItem");
            this.Selecticon.Images.SetKeyName(9, "checkbox-checked");
            this.Selecticon.Images.SetKeyName(10, "checkbox-unchecked");
            this.Selecticon.Images.SetKeyName(11, "checkbox-indeterminate");
            // 
            // imlLinkSummary
            // 
            this.imlLinkSummary.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLinkSummary.ImageStream")));
            this.imlLinkSummary.Images.SetKeyName(0, "Right");
            this.imlLinkSummary.Images.SetKeyName(1, "Left");
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(109, 20);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 3;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Pass/Fail:";
            // 
            // btnRunStringBuilder
            // 
            this.btnRunStringBuilder.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x16;
            this.btnRunStringBuilder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunStringBuilder.Location = new System.Drawing.Point(4, 4);
            this.btnRunStringBuilder.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunStringBuilder.Name = "btnRunStringBuilder";
            this.btnRunStringBuilder.Size = new System.Drawing.Size(132, 28);
            this.btnRunStringBuilder.TabIndex = 0;
            this.btnRunStringBuilder.Text = "Run (F5)";
            this.btnRunStringBuilder.UseVisualStyleBackColor = true;
            this.btnRunStringBuilder.Click += new System.EventHandler(this.btnRunStringBuilder_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(144, 4);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(69, 28);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(221, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reorder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnRunStringBuilder);
            this.flowLayoutPanel3.Controls.Add(this.btnReset);
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.btnDown);
            this.flowLayoutPanel3.Controls.Add(this.btnUp);
            this.flowLayoutPanel3.Controls.Add(this.btnAdd);
            this.flowLayoutPanel3.Controls.Add(this.btnClone);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(27, 44);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(603, 38);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // btnDown
            // 
            this.btnDown.Image = global::RTC_Vision_Lite.Properties.Resources.Down;
            this.btnDown.Location = new System.Drawing.Point(282, 4);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 28);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::RTC_Vision_Lite.Properties.Resources.Up;
            this.btnUp.Location = new System.Drawing.Point(330, 4);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(37, 28);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(375, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClone
            // 
            this.btnClone.Location = new System.Drawing.Point(483, 4);
            this.btnClone.Margin = new System.Windows.Forms.Padding(4);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(100, 28);
            this.btnClone.TabIndex = 6;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // tlFilterList
            // 
            this.tlFilterList.AllColumns.Add(this.olvColumn1);
            this.tlFilterList.AllColumns.Add(this.colActive);
            this.tlFilterList.AllColumns.Add(this.colOrderNum);
            this.tlFilterList.AllColumns.Add(this.btnDelete);
            this.tlFilterList.AllColumns.Add(this.colFilterType);
            this.tlFilterList.AllColumns.Add(this.colMaskWidth);
            this.tlFilterList.AllColumns.Add(this.colMaskHeight);
            this.tlFilterList.AllColumns.Add(this.colIterations);
            this.tlFilterList.AllColumns.Add(this.colThresholdRange);
            this.tlFilterList.AllColumns.Add(this.colGreyValue);
            this.tlFilterList.AllColumns.Add(this.colRangeOutputPixel);
            this.tlFilterList.AllColumns.Add(this.colOutRangeOutputPixel);
            this.tlFilterList.AllColumns.Add(this.colScaleFactor);
            this.tlFilterList.AllColumns.Add(this.colMargin);
            this.tlFilterList.AllColumns.Add(this.colRegion);
            this.tlFilterList.AllColumns.Add(this.colEnable);
            this.tlFilterList.AllColumns.Add(this.colResult);
            this.tlFilterList.AllColumns.Add(this.colID);
            this.tlFilterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlFilterList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.tlFilterList.CellEditUseWholeCell = false;
            this.tlFilterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.colActive,
            this.colOrderNum,
            this.btnDelete,
            this.colFilterType,
            this.colMaskWidth,
            this.colMaskHeight,
            this.colIterations,
            this.colThresholdRange,
            this.colGreyValue,
            this.colRangeOutputPixel,
            this.colOutRangeOutputPixel,
            this.colScaleFactor,
            this.colMargin,
            this.colRegion,
            this.colResult});
            this.tlFilterList.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlFilterList.HeaderWordWrap = true;
            this.tlFilterList.HideSelection = false;
            this.tlFilterList.Location = new System.Drawing.Point(27, 103);
            this.tlFilterList.LockCalc = false;
            this.tlFilterList.Margin = new System.Windows.Forms.Padding(4);
            this.tlFilterList.MultiSelect = false;
            this.tlFilterList.Name = "tlFilterList";
            this.tlFilterList.OwnerDrawnHeader = true;
            this.tlFilterList.RightToLeftLayout = true;
            this.tlFilterList.ShowGroups = false;
            this.tlFilterList.ShowImagesOnSubItems = true;
            this.tlFilterList.Size = new System.Drawing.Size(1066, 415);
            this.tlFilterList.SmallImageList = this.imageList1;
            this.tlFilterList.TabIndex = 8;
            this.tlFilterList.UseAlternatingBackColors = true;
            this.tlFilterList.UseCellFormatEvents = true;
            this.tlFilterList.UseCompatibleStateImageBehavior = false;
            this.tlFilterList.UseSubItemCheckBoxes = true;
            this.tlFilterList.View = System.Windows.Forms.View.Details;
            this.tlFilterList.VirtualMode = true;
            this.tlFilterList.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlFilterList_ButtonClick);
            this.tlFilterList.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.tlFilterList_CellEditFinishing);
            this.tlFilterList.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.tlFilterList_CellEditStarting);
            this.tlFilterList.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlFilterList_CellClick_1);
            this.tlFilterList.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.tlFilterList_SubItemChecking);
            this.tlFilterList.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tlFilterList_FormatCell);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "";
            this.olvColumn1.Width = 1;
            // 
            // colActive
            // 
            this.colActive.AspectName = "Active";
            this.colActive.CheckBoxes = true;
            this.colActive.Text = "";
            this.colActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colActive.UseFiltering = false;
            this.colActive.Width = 25;
            // 
            // colOrderNum
            // 
            this.colOrderNum.AspectName = "OrderNum";
            this.colOrderNum.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colOrderNum.Text = "Order";
            this.colOrderNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colOrderNum.Width = 80;
            // 
            // btnDelete
            // 
            this.btnDelete.AspectName = "Delete";
            this.btnDelete.CellEditUseWholeCell = true;
            this.btnDelete.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDelete.MinimumWidth = 50;
            this.btnDelete.Text = "";
            this.btnDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDelete.Width = 50;
            // 
            // colFilterType
            // 
            this.colFilterType.AspectName = "FilterType";
            this.colFilterType.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.colFilterType.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFilterType.Text = "Filter Type";
            this.colFilterType.Width = 64;
            // 
            // colMaskWidth
            // 
            this.colMaskWidth.AspectName = "MaskWidth";
            this.colMaskWidth.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMaskWidth.Text = "Mask Width";
            this.colMaskWidth.Width = 76;
            // 
            // colMaskHeight
            // 
            this.colMaskHeight.AspectName = "MaskHeight";
            this.colMaskHeight.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMaskHeight.Text = "Mask Height";
            this.colMaskHeight.Width = 82;
            // 
            // colIterations
            // 
            this.colIterations.AspectName = "Iterations";
            this.colIterations.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colIterations.Text = "Iterations";
            this.colIterations.Width = 68;
            // 
            // colThresholdRange
            // 
            this.colThresholdRange.AspectName = "ThresholdRange";
            this.colThresholdRange.FillsFreeSpace = true;
            this.colThresholdRange.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colThresholdRange.Text = "Threshold Range";
            this.colThresholdRange.Width = 140;
            // 
            // colGreyValue
            // 
            this.colGreyValue.AspectName = "GrayValue";
            this.colGreyValue.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colGreyValue.Text = "Grey Value";
            this.colGreyValue.Width = 66;
            // 
            // colRangeOutputPixel
            // 
            this.colRangeOutputPixel.AspectName = "InRangeOutputPixel";
            this.colRangeOutputPixel.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colRangeOutputPixel.Text = "In Range Output Pixel";
            this.colRangeOutputPixel.Width = 126;
            // 
            // colOutRangeOutputPixel
            // 
            this.colOutRangeOutputPixel.AspectName = "OutRangeOutputPixel";
            this.colOutRangeOutputPixel.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colOutRangeOutputPixel.Text = "Out Range Output Pixel";
            this.colOutRangeOutputPixel.Width = 141;
            // 
            // colScaleFactor
            // 
            this.colScaleFactor.AspectName = "ScaleFactor";
            this.colScaleFactor.FillsFreeSpace = true;
            this.colScaleFactor.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colScaleFactor.Text = "Scale Factor";
            this.colScaleFactor.Width = 75;
            // 
            // colMargin
            // 
            this.colMargin.AspectName = "Margin";
            this.colMargin.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMargin.Text = "Margin";
            this.colMargin.Width = 50;
            // 
            // colRegion
            // 
            this.colRegion.AspectName = "Region";
            this.colRegion.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colRegion.Text = "Region";
            this.colRegion.Width = 52;
            // 
            // colEnable
            // 
            this.colEnable.AspectName = "Enable";
            this.colEnable.IsVisible = false;
            // 
            // colResult
            // 
            this.colResult.AspectName = "Result";
            this.colResult.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colResult.Text = "Result";
            // 
            // colID
            // 
            this.colID.AspectName = "ID";
            this.colID.IsVisible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Remove");
            // 
            // ABC
            // 
            this.ABC.DisplayIndex = 15;
            // 
            // lblRegionLink
            // 
            this.lblRegionLink.AutoSize = true;
            this.lblRegionLink.Location = new System.Drawing.Point(837, 41);
            this.lblRegionLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegionLink.Name = "lblRegionLink";
            this.lblRegionLink.Size = new System.Drawing.Size(65, 13);
            this.lblRegionLink.TabIndex = 9;
            this.lblRegionLink.Text = "RegionLink";
            this.lblRegionLink.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(77, 18);
            this.RTCName.Margin = new System.Windows.Forms.Padding(4);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(863, 22);
            this.RTCName.TabIndex = 8;
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(21, 47);
            this.ucImageLink.Margin = new System.Windows.Forms.Padding(2, 92, 2, 92);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(310, 111);
            this.ucImageLink.TabIndex = 9;
            // 
            // ucImageFilterActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ucImageFilterActionDetail";
            this.Size = new System.Drawing.Size(1200, 656);
            this.Load += new System.EventHandler(this.ucImageFilterActionDetail_Load);
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.ScrollableROI.ResumeLayout(false);
            this.ScrollableROI.PerformLayout();
            this.General.ResumeLayout(false);
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlFilterList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private UserControls.MyTreeList tlFilterList;
        private BrightIdeasSoftware.OLVColumn btnDelete;
        private BrightIdeasSoftware.OLVColumn colActive;
        private BrightIdeasSoftware.OLVColumn colOrderNum;
        private BrightIdeasSoftware.OLVColumn colFilterType;
        private BrightIdeasSoftware.OLVColumn colMaskWidth;
        private BrightIdeasSoftware.OLVColumn colMaskHeight;
        private BrightIdeasSoftware.OLVColumn colIterations;
        private BrightIdeasSoftware.OLVColumn colThresholdRange;
        private BrightIdeasSoftware.OLVColumn colGreyValue;
        private BrightIdeasSoftware.OLVColumn colRangeOutputPixel;
        private BrightIdeasSoftware.OLVColumn colOutRangeOutputPixel;
        private BrightIdeasSoftware.OLVColumn colScaleFactor;
        private BrightIdeasSoftware.OLVColumn colMargin;
        private BrightIdeasSoftware.OLVColumn colRegion;
        private BrightIdeasSoftware.OLVColumn colEnable;
        private BrightIdeasSoftware.OLVColumn colResult;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnRunStringBuilder;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClone;
        private BrightIdeasSoftware.OLVColumn colID;
        private BrightIdeasSoftware.OLVColumn ABC;
        private System.Windows.Forms.Label lblRegionLink;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label2;
        private ucImageLink ucImageLink;
        private System.Windows.Forms.ImageList imageList1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
    }
}
