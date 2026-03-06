
namespace RTC_Vision_Lite.UserControls
{
    partial class ucTemplateTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTemplateTools));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddTool = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.Label();
            this.imlStatusIcon = new System.Windows.Forms.ImageList(this.components);
            this.tl_template = new BrightIdeasSoftware.TreeListView();
            this.colCaption = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colNodeType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colActionType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIsLocate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIsConstructor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIsNew = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIsUpdate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colUpdateDescription = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imlActionType24 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCollapse = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tl_template)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddTool);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnAddTool
            // 
            this.btnAddTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTool.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTool.Location = new System.Drawing.Point(349, 13);
            this.btnAddTool.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddTool.Name = "btnAddTool";
            this.btnAddTool.Size = new System.Drawing.Size(100, 28);
            this.btnAddTool.TabIndex = 2;
            this.btnAddTool.Text = "Add tool";
            this.btnAddTool.UseVisualStyleBackColor = true;
            this.btnAddTool.Click += new System.EventHandler(this.btnAddTool_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(85, 16);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(23, 22);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search";
            // 
            // txtNote
            // 
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtNote.Location = new System.Drawing.Point(0, 312);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(453, 130);
            this.txtNote.TabIndex = 2;
            this.txtNote.Text = "Note:";
            // 
            // imlStatusIcon
            // 
            this.imlStatusIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlStatusIcon.ImageStream")));
            this.imlStatusIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imlStatusIcon.Images.SetKeyName(0, "RunCurrentImage2.png");
            // 
            // tl_template
            // 
            this.tl_template.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.tl_template.AllColumns.Add(this.colCaption);
            this.tl_template.AllColumns.Add(this.colStatus);
            this.tl_template.AllColumns.Add(this.colName);
            this.tl_template.AllColumns.Add(this.colNodeType);
            this.tl_template.AllColumns.Add(this.colActionType);
            this.tl_template.AllColumns.Add(this.colIsLocate);
            this.tl_template.AllColumns.Add(this.colIsConstructor);
            this.tl_template.AllColumns.Add(this.colIsNew);
            this.tl_template.AllColumns.Add(this.colIsUpdate);
            this.tl_template.AllColumns.Add(this.colUpdateDescription);
            this.tl_template.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.tl_template.CellEditEnterChangesRows = true;
            this.tl_template.CellEditTabChangesRows = true;
            this.tl_template.CellEditUseWholeCell = false;
            this.tl_template.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCaption,
            this.colStatus});
            this.tl_template.Cursor = System.Windows.Forms.Cursors.Default;
            this.tl_template.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_template.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tl_template.FullRowSelect = true;
            this.tl_template.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.tl_template.HideSelection = false;
            this.tl_template.Location = new System.Drawing.Point(0, 60);
            this.tl_template.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tl_template.Name = "tl_template";
            this.tl_template.RowHeight = 25;
            this.tl_template.ShowGroups = false;
            this.tl_template.ShowImagesOnSubItems = true;
            this.tl_template.Size = new System.Drawing.Size(453, 252);
            this.tl_template.SmallImageList = this.imlActionType24;
            this.tl_template.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.tl_template.TabIndex = 5;
            this.tl_template.UseCellFormatEvents = true;
            this.tl_template.UseCompatibleStateImageBehavior = false;
            this.tl_template.UseFilterIndicator = true;
            this.tl_template.UseFiltering = true;
            this.tl_template.View = System.Windows.Forms.View.Details;
            this.tl_template.VirtualMode = true;
            this.tl_template.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tl_template_CellClick);
            this.tl_template.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tl_template_FormatCell_1);
            this.tl_template.DoubleClick += new System.EventHandler(this.tl_template_DoubleClick);
            // 
            // colCaption
            // 
            this.colCaption.AspectName = "ActionCaption";
            this.colCaption.Text = "";
            this.colCaption.Width = 250;
            // 
            // colStatus
            // 
            this.colStatus.AspectName = "Status";
            this.colStatus.Text = "";
            // 
            // colName
            // 
            this.colName.AspectName = "ActionName";
            this.colName.DisplayIndex = 0;
            this.colName.IsVisible = false;
            this.colName.Text = "";
            this.colName.Width = 250;
            // 
            // colNodeType
            // 
            this.colNodeType.AspectName = "NodeType";
            this.colNodeType.DisplayIndex = 1;
            this.colNodeType.IsEditable = false;
            this.colNodeType.IsVisible = false;
            this.colNodeType.Text = "";
            this.colNodeType.Width = 30;
            // 
            // colActionType
            // 
            this.colActionType.AspectName = "Type";
            this.colActionType.CheckBoxes = true;
            this.colActionType.DisplayIndex = 2;
            this.colActionType.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colActionType.IsVisible = false;
            this.colActionType.Text = "Enable";
            this.colActionType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colIsLocate
            // 
            this.colIsLocate.AspectName = "IsLocate";
            this.colIsLocate.CheckBoxes = true;
            this.colIsLocate.DisplayIndex = 3;
            this.colIsLocate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colIsLocate.IsTileViewColumn = true;
            this.colIsLocate.IsVisible = false;
            this.colIsLocate.Text = "Run Count";
            this.colIsLocate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colIsLocate.Width = 70;
            // 
            // colIsConstructor
            // 
            this.colIsConstructor.AspectName = "IsConstructor";
            this.colIsConstructor.CheckBoxes = true;
            this.colIsConstructor.DisplayIndex = 4;
            this.colIsConstructor.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colIsConstructor.IsVisible = false;
            this.colIsConstructor.Text = "Fail Count";
            this.colIsConstructor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colIsConstructor.Width = 70;
            // 
            // colIsNew
            // 
            this.colIsNew.AspectName = "IsNew";
            this.colIsNew.CheckBoxes = true;
            this.colIsNew.DisplayIndex = 5;
            this.colIsNew.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colIsNew.IsVisible = false;
            this.colIsNew.Text = "Process Time";
            this.colIsNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colIsNew.Width = 80;
            // 
            // colIsUpdate
            // 
            this.colIsUpdate.AspectName = "IsUpdate";
            this.colIsUpdate.CheckBoxes = true;
            this.colIsUpdate.DisplayIndex = 6;
            this.colIsUpdate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colIsUpdate.IsVisible = false;
            this.colIsUpdate.Text = "Total Time";
            this.colIsUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colIsUpdate.Width = 70;
            // 
            // colUpdateDescription
            // 
            this.colUpdateDescription.AspectName = "UpdateDescription";
            this.colUpdateDescription.CheckBoxes = true;
            this.colUpdateDescription.DisplayIndex = 7;
            this.colUpdateDescription.IsVisible = false;
            this.colUpdateDescription.Text = "Abort Cause";
            this.colUpdateDescription.Width = 70;
            // 
            // imlActionType24
            // 
            this.imlActionType24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlActionType24.ImageStream")));
            this.imlActionType24.TransparentColor = System.Drawing.Color.Transparent;
            this.imlActionType24.Images.SetKeyName(0, "Morphology");
            this.imlActionType24.Images.SetKeyName(1, "RegionTransform");
            this.imlActionType24.Images.SetKeyName(2, "MorphologyImage");
            this.imlActionType24.Images.SetKeyName(3, "MultipleBranch");
            this.imlActionType24.Images.SetKeyName(4, "RunDLL");
            this.imlActionType24.Images.SetKeyName(5, "OpticalFlowImage");
            this.imlActionType24.Images.SetKeyName(6, "RunCommand");
            this.imlActionType24.Images.SetKeyName(7, "WindowSettings");
            this.imlActionType24.Images.SetKeyName(8, "RunDeep");
            this.imlActionType24.Images.SetKeyName(9, "GaugeDualROI");
            this.imlActionType24.Images.SetKeyName(10, "ImageMath");
            this.imlActionType24.Images.SetKeyName(11, "PixelCount");
            this.imlActionType24.Images.SetKeyName(12, "PoseManipulation");
            this.imlActionType24.Images.SetKeyName(13, "VariationModel");
            this.imlActionType24.Images.SetKeyName(14, "DrawingROI");
            this.imlActionType24.Images.SetKeyName(15, "DetectFileStatus");
            this.imlActionType24.Images.SetKeyName(16, "SaveConfig");
            this.imlActionType24.Images.SetKeyName(17, "LoadConfig");
            this.imlActionType24.Images.SetKeyName(18, "Metrology");
            this.imlActionType24.Images.SetKeyName(19, "AffineImage");
            this.imlActionType24.Images.SetKeyName(20, "ImageSplit");
            this.imlActionType24.Images.SetKeyName(21, "OCR");
            this.imlActionType24.Images.SetKeyName(22, "CodeReader");
            this.imlActionType24.Images.SetKeyName(23, "BranchItem");
            this.imlActionType24.Images.SetKeyName(24, "Count");
            this.imlActionType24.Images.SetKeyName(25, "CounterLoop");
            this.imlActionType24.Images.SetKeyName(26, "PassFail");
            this.imlActionType24.Images.SetKeyName(27, "Switch");
            this.imlActionType24.Images.SetKeyName(28, "LineFind");
            this.imlActionType24.Images.SetKeyName(29, "MainAction");
            this.imlActionType24.Images.SetKeyName(30, "ClearWindows");
            this.imlActionType24.Images.SetKeyName(31, "CycleTimeStop");
            this.imlActionType24.Images.SetKeyName(32, "CycleTimeStart");
            this.imlActionType24.Images.SetKeyName(33, "DistanceMeasurement");
            this.imlActionType24.Images.SetKeyName(34, "RegionProcessing");
            this.imlActionType24.Images.SetKeyName(35, "ChangeJob");
            this.imlActionType24.Images.SetKeyName(36, "StringBuilder");
            this.imlActionType24.Images.SetKeyName(37, "DialogMessage");
            this.imlActionType24.Images.SetKeyName(38, "HookKeyboard");
            this.imlActionType24.Images.SetKeyName(39, "OkNgCounter");
            this.imlActionType24.Images.SetKeyName(40, "Branch");
            this.imlActionType24.Images.SetKeyName(41, "Alignment");
            this.imlActionType24.Images.SetKeyName(42, "CalibrationCheckBoard");
            this.imlActionType24.Images.SetKeyName(43, "Pattern");
            this.imlActionType24.Images.SetKeyName(44, "DeformablePattern");
            this.imlActionType24.Images.SetKeyName(45, "CorrelationPattern");
            this.imlActionType24.Images.SetKeyName(46, "HandEye");
            this.imlActionType24.Images.SetKeyName(47, "ManualAlignment");
            this.imlActionType24.Images.SetKeyName(48, "Origin");
            this.imlActionType24.Images.SetKeyName(49, "COMReader");
            this.imlActionType24.Images.SetKeyName(50, "COMWriter");
            this.imlActionType24.Images.SetKeyName(51, "FTPDownload");
            this.imlActionType24.Images.SetKeyName(52, "FTPUpload");
            this.imlActionType24.Images.SetKeyName(53, "CameraIOReader");
            this.imlActionType24.Images.SetKeyName(54, "IOControllerWrite");
            this.imlActionType24.Images.SetKeyName(55, "IOControllerRead");
            this.imlActionType24.Images.SetKeyName(56, "DataSet");
            this.imlActionType24.Images.SetKeyName(57, "DataInstance");
            this.imlActionType24.Images.SetKeyName(58, "SnapImage");
            this.imlActionType24.Images.SetKeyName(59, "ResetTool");
            this.imlActionType24.Images.SetKeyName(60, "Return");
            this.imlActionType24.Images.SetKeyName(61, "Blob");
            this.imlActionType24.Images.SetKeyName(62, "BlobMultipleROI");
            this.imlActionType24.Images.SetKeyName(63, "Brightness");
            this.imlActionType24.Images.SetKeyName(64, "BlobFilter");
            this.imlActionType24.Images.SetKeyName(65, "ColorBlobMultipleROI");
            this.imlActionType24.Images.SetKeyName(66, "ColorBlob");
            this.imlActionType24.Images.SetKeyName(67, "SaveProject");
            this.imlActionType24.Images.SetKeyName(68, "RunProgram");
            this.imlActionType24.Images.SetKeyName(69, "SendMessage");
            this.imlActionType24.Images.SetKeyName(70, "Stop");
            this.imlActionType24.Images.SetKeyName(71, "SystemInfo");
            this.imlActionType24.Images.SetKeyName(72, "ViewResult");
            this.imlActionType24.Images.SetKeyName(73, "ViewText");
            this.imlActionType24.Images.SetKeyName(74, "Wait");
            this.imlActionType24.Images.SetKeyName(75, "LinkValue");
            this.imlActionType24.Images.SetKeyName(76, "LiveCam");
            this.imlActionType24.Images.SetKeyName(77, "StopLiveCam");
            this.imlActionType24.Images.SetKeyName(78, "CameraSettings");
            this.imlActionType24.Images.SetKeyName(79, "LoadImage");
            this.imlActionType24.Images.SetKeyName(80, "SaveImage");
            this.imlActionType24.Images.SetKeyName(81, "LoadObject");
            this.imlActionType24.Images.SetKeyName(82, "CsvWrite");
            this.imlActionType24.Images.SetKeyName(83, "ExcelWrite");
            this.imlActionType24.Images.SetKeyName(84, "DataArchiveRead");
            this.imlActionType24.Images.SetKeyName(85, "DataArchive");
            this.imlActionType24.Images.SetKeyName(86, "SLMPWrite");
            this.imlActionType24.Images.SetKeyName(87, "SLMPRead");
            this.imlActionType24.Images.SetKeyName(88, "TCPIPRead");
            this.imlActionType24.Images.SetKeyName(89, "TCPIPWrite");
            this.imlActionType24.Images.SetKeyName(90, "ModBusWrite");
            this.imlActionType24.Images.SetKeyName(91, "ModBusRead");
            this.imlActionType24.Images.SetKeyName(92, "ImageFilter");
            this.imlActionType24.Images.SetKeyName(93, "UdpRead");
            this.imlActionType24.Images.SetKeyName(94, "UdpWrite");
            this.imlActionType24.Images.SetKeyName(95, "PhotometricStereo");
            this.imlActionType24.Images.SetKeyName(96, "VSTLightWrite");
            this.imlActionType24.Images.SetKeyName(97, "VSTLightRead");
            this.imlActionType24.Images.SetKeyName(98, "CSTLightRead");
            this.imlActionType24.Images.SetKeyName(99, "CSTLightWrite");
            this.imlActionType24.Images.SetKeyName(100, "Math");
            this.imlActionType24.Images.SetKeyName(101, "CalibrateEdgeToEdge");
            this.imlActionType24.Images.SetKeyName(102, "SaveObject");
            this.imlActionType24.Images.SetKeyName(103, "Script");
            this.imlActionType24.Images.SetKeyName(104, "MXComponentWrite");
            this.imlActionType24.Images.SetKeyName(105, "MXComponentRead");
            this.imlActionType24.Images.SetKeyName(106, "View3DImage");
            this.imlActionType24.Images.SetKeyName(107, "Get3DImage");
            this.imlActionType24.Images.SetKeyName(108, "PatliteWrite");
            this.imlActionType24.Images.SetKeyName(109, "AnomalyDetection");
            this.imlActionType24.Images.SetKeyName(110, "Classification");
            this.imlActionType24.Images.SetKeyName(111, "ObjectDetection");
            this.imlActionType24.Images.SetKeyName(112, "SemanticSegmentation");
            this.imlActionType24.Images.SetKeyName(113, "POCIOWrite");
            this.imlActionType24.Images.SetKeyName(114, "POCIORead");
            this.imlActionType24.Images.SetKeyName(115, "MitsuSLMPWrite");
            this.imlActionType24.Images.SetKeyName(116, "MitsuSLMPRead");
            this.imlActionType24.Images.SetKeyName(117, "BreakPointPause");
            this.imlActionType24.Images.SetKeyName(118, "BreakPoint");
            this.imlActionType24.Images.SetKeyName(119, "Input");
            this.imlActionType24.Images.SetKeyName(120, "Output");
            this.imlActionType24.Images.SetKeyName(121, "APIWrite");
            this.imlActionType24.Images.SetKeyName(122, "Ping");
            this.imlActionType24.Images.SetKeyName(123, "EasyHandEye");
            this.imlActionType24.Images.SetKeyName(124, "ExcelRead");
            this.imlActionType24.Images.SetKeyName(125, "CCLinkIEWriter");
            this.imlActionType24.Images.SetKeyName(126, "CCLinkIEReader");
            this.imlActionType24.Images.SetKeyName(127, "AdlinkIOReader");
            this.imlActionType24.Images.SetKeyName(128, "AdlinkIOWriter");
            this.imlActionType24.Images.SetKeyName(129, "GroupAction");
            this.imlActionType24.Images.SetKeyName(130, "NeuroClassification");
            this.imlActionType24.Images.SetKeyName(131, "NeuroSegmentation");
            this.imlActionType24.Images.SetKeyName(132, "NeuroAnomalySegmentation");
            this.imlActionType24.Images.SetKeyName(133, "NeuroAnomalyClassification");
            this.imlActionType24.Images.SetKeyName(134, "NeuroObjectDetection");
            this.imlActionType24.Images.SetKeyName(135, "NeuroOCR");
            this.imlActionType24.Images.SetKeyName(136, "EasyAlign");
            this.imlActionType24.Images.SetKeyName(137, "CleanData");
            this.imlActionType24.Images.SetKeyName(138, "CustomProcedure");
            this.imlActionType24.Images.SetKeyName(139, "VerifyEndLog");
            this.imlActionType24.Images.SetKeyName(140, "VerifyBeginLog");
            this.imlActionType24.Images.SetKeyName(141, "ModbusRTURead");
            this.imlActionType24.Images.SetKeyName(142, "ModbusRTUWrite");
            this.imlActionType24.Images.SetKeyName(143, "blank");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCollapse,
            this.btnExpand,
            this.btnExpandAll,
            this.btnCollapseAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 92);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(133, 22);
            this.btnCollapse.Text = "Collapse";
            // 
            // btnExpand
            // 
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(133, 22);
            this.btnExpand.Text = "Expand";
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(133, 22);
            this.btnExpandAll.Text = "ExpandAll";
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(133, 22);
            this.btnCollapseAll.Text = "CollapseAll";
            // 
            // ucTemplateTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tl_template);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucTemplateTools";
            this.Size = new System.Drawing.Size(453, 442);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tl_template)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddTool;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label txtNote;
        private System.Windows.Forms.ImageList imlStatusIcon;
        private BrightIdeasSoftware.TreeListView tl_template;
        private BrightIdeasSoftware.OLVColumn colCaption;
        private BrightIdeasSoftware.OLVColumn colStatus;
        private BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn colNodeType;
        private BrightIdeasSoftware.OLVColumn colActionType;
        private BrightIdeasSoftware.OLVColumn colIsLocate;
        private BrightIdeasSoftware.OLVColumn colIsConstructor;
        private BrightIdeasSoftware.OLVColumn colIsNew;
        private BrightIdeasSoftware.OLVColumn colIsUpdate;
        private BrightIdeasSoftware.OLVColumn colUpdateDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCollapse;
        private System.Windows.Forms.ToolStripMenuItem btnExpand;
        private System.Windows.Forms.ToolStripMenuItem btnExpandAll;
        private System.Windows.Forms.ToolStripMenuItem btnCollapseAll;
        private System.Windows.Forms.ImageList imlActionType24;
    }
}
