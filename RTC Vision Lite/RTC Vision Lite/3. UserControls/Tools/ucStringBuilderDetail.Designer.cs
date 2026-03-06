
namespace RTC_Vision_Lite.UserControls
{
    partial class ucStringBuilderDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStringBuilderDetail));
            this.PanButton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRunStringBuilder = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnUnGroup = new System.Windows.Forms.Button();
            this.tlStringItem = new RTC_Vision_Lite.UserControls.MyTreeList();
            this.colDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSTT = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colItemName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRemove = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colLink = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRefID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRefPropName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEnable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupInput = new System.Windows.Forms.GroupBox();
            this.flpOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.ucStringBuilderItemProperty = new RTC_Vision_Lite.UserControls.ucStringBuilderItemProperty();
            this.panFormat = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RTCEnumTerminator = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucInputDelimiter = new RTC_Vision_Lite.UserControls.ucInputDelimiter();
            this.grpOutputString = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblOutput = new System.Windows.Forms.Label();
            this.grpOutputHeaderString = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblOutputHeader = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.PanButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlStringItem)).BeginInit();
            this.groupInput.SuspendLayout();
            this.flpOptions.SuspendLayout();
            this.panFormat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpOutputString.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpOutputHeaderString.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(4);
            this.PageActionSetting.Size = new System.Drawing.Size(900, 767);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label7);
            this.ScrollableGeneral.Location = new System.Drawing.Point(4, 4);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableGeneral.Size = new System.Drawing.Size(853, 680);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(4, 41);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(2);
            this.PageSetup.Size = new System.Drawing.Size(884, 696);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(4);
            this.ROI.Padding = new System.Windows.Forms.Padding(4);
            this.ROI.Size = new System.Drawing.Size(861, 688);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(4);
            this.PassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.PanButton);
            this.ScrollableROI.Controls.Add(this.flpOptions);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label8);
            this.ScrollableROI.Location = new System.Drawing.Point(4, 4);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableROI.Size = new System.Drawing.Size(853, 680);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(884, 37);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(4);
            this.General.Padding = new System.Windows.Forms.Padding(4);
            this.General.Size = new System.Drawing.Size(861, 688);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(4);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(4);
            this.TabSetUp.Size = new System.Drawing.Size(892, 741);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(4);
            this.Method.Padding = new System.Windows.Forms.Padding(4);
            this.Method.Size = new System.Drawing.Size(861, 688);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(4);
            this.Display.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(4, 4);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableMethod.Size = new System.Drawing.Size(853, 680);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(855, 403);
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
            this.Selecticon.Images.SetKeyName(6, "RemoveLink");
            this.Selecticon.Images.SetKeyName(7, "LinkProperty");
            this.Selecticon.Images.SetKeyName(8, "ViewListItem");
            this.Selecticon.Images.SetKeyName(9, "checkbox-checked");
            this.Selecticon.Images.SetKeyName(10, "checkbox-unchecked");
            this.Selecticon.Images.SetKeyName(11, "checkbox-indeterminate");
            this.Selecticon.Images.SetKeyName(12, "Delete");
            // 
            // imlLinkSummary
            // 
            this.imlLinkSummary.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLinkSummary.ImageStream")));
            this.imlLinkSummary.Images.SetKeyName(0, "Right");
            this.imlLinkSummary.Images.SetKeyName(1, "Left");
            // 
            // PanButton
            // 
            this.PanButton.Controls.Add(this.btnRunStringBuilder);
            this.PanButton.Controls.Add(this.btnReset);
            this.PanButton.Controls.Add(this.label1);
            this.PanButton.Controls.Add(this.btnDown);
            this.PanButton.Controls.Add(this.btnUp);
            this.PanButton.Controls.Add(this.btnAdd);
            this.PanButton.Controls.Add(this.btnClone);
            this.PanButton.Controls.Add(this.btnGroup);
            this.PanButton.Controls.Add(this.btnUnGroup);
            this.PanButton.Location = new System.Drawing.Point(110, 0);
            this.PanButton.Name = "PanButton";
            this.PanButton.Size = new System.Drawing.Size(743, 31);
            this.PanButton.TabIndex = 8;
            // 
            // btnRunStringBuilder
            // 
            this.btnRunStringBuilder.Image = global::RTC_Vision_Lite.Properties.Resources.Play_16x16;
            this.btnRunStringBuilder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunStringBuilder.Location = new System.Drawing.Point(3, 3);
            this.btnRunStringBuilder.Name = "btnRunStringBuilder";
            this.btnRunStringBuilder.Size = new System.Drawing.Size(99, 23);
            this.btnRunStringBuilder.TabIndex = 0;
            this.btnRunStringBuilder.Text = "Run (F5)";
            this.btnRunStringBuilder.UseVisualStyleBackColor = true;
            this.btnRunStringBuilder.Click += new System.EventHandler(this.btnRunStringBuilder_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(108, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(52, 23);
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
            this.label1.Location = new System.Drawing.Point(166, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reorder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDown
            // 
            this.btnDown.Image = global::RTC_Vision_Lite.Properties.Resources.Down;
            this.btnDown.Location = new System.Drawing.Point(225, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::RTC_Vision_Lite.Properties.Resources.Up;
            this.btnUp.Location = new System.Drawing.Point(261, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(295, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClone
            // 
            this.btnClone.Location = new System.Drawing.Point(376, 3);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 6;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(457, 3);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(75, 23);
            this.btnGroup.TabIndex = 7;
            this.btnGroup.Text = "Group";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Visible = false;
            // 
            // btnUnGroup
            // 
            this.btnUnGroup.Location = new System.Drawing.Point(538, 3);
            this.btnUnGroup.Name = "btnUnGroup";
            this.btnUnGroup.Size = new System.Drawing.Size(75, 23);
            this.btnUnGroup.TabIndex = 8;
            this.btnUnGroup.Text = "UnGroup";
            this.btnUnGroup.UseVisualStyleBackColor = true;
            this.btnUnGroup.Visible = false;
            // 
            // tlStringItem
            // 
            this.tlStringItem.AllColumns.Add(this.colDelete);
            this.tlStringItem.AllColumns.Add(this.colSTT);
            this.tlStringItem.AllColumns.Add(this.colItemName);
            this.tlStringItem.AllColumns.Add(this.colType);
            this.tlStringItem.AllColumns.Add(this.colRemove);
            this.tlStringItem.AllColumns.Add(this.colLink);
            this.tlStringItem.AllColumns.Add(this.colValue);
            this.tlStringItem.AllColumns.Add(this.colRefID);
            this.tlStringItem.AllColumns.Add(this.colRefPropName);
            this.tlStringItem.AllColumns.Add(this.colEnable);
            this.tlStringItem.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.tlStringItem.CellEditUseWholeCell = false;
            this.tlStringItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDelete,
            this.colItemName,
            this.colType,
            this.colRemove,
            this.colLink,
            this.colValue});
            this.tlStringItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlStringItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlStringItem.FullRowSelect = true;
            this.tlStringItem.HideSelection = false;
            this.tlStringItem.Location = new System.Drawing.Point(3, 18);
            this.tlStringItem.LockCalc = false;
            this.tlStringItem.Name = "tlStringItem";
            this.tlStringItem.OwnerDrawnHeader = true;
            this.tlStringItem.ShowGroups = false;
            this.tlStringItem.Size = new System.Drawing.Size(838, 171);
            this.tlStringItem.SmallImageList = this.Selecticon;
            this.tlStringItem.TabIndex = 9;
            this.tlStringItem.UseCellFormatEvents = true;
            this.tlStringItem.UseCompatibleStateImageBehavior = false;
            this.tlStringItem.View = System.Windows.Forms.View.Details;
            this.tlStringItem.VirtualMode = true;
            this.tlStringItem.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.tlStringItem_CellEditFinishing);
            this.tlStringItem.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.tlStringItem_CellEditStarting);
            this.tlStringItem.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlStringItem_CellClick);
            this.tlStringItem.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tlStringItem_FormatCell);
            this.tlStringItem.SelectionChanged += new System.EventHandler(this.tlStringItem_SelectionChanged);
            // 
            // colDelete
            // 
            this.colDelete.AspectName = "Delete";
            this.colDelete.ImageAspectName = "Delete";
            this.colDelete.Text = "";
            // 
            // colSTT
            // 
            this.colSTT.AspectName = "STT";
            this.colSTT.IsVisible = false;
            this.colSTT.Text = "";
            // 
            // colItemName
            // 
            this.colItemName.AspectName = "Name";
            this.colItemName.FillsFreeSpace = true;
            this.colItemName.Text = "ItemName";
            this.colItemName.Width = 128;
            // 
            // colType
            // 
            this.colType.AspectName = "Type";
            this.colType.Text = "Type";
            this.colType.Width = 68;
            // 
            // colRemove
            // 
            this.colRemove.Text = "";
            this.colRemove.Width = 80;
            // 
            // colLink
            // 
            this.colLink.Text = "";
            this.colLink.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLink.Width = 75;
            // 
            // colValue
            // 
            this.colValue.AspectName = "Value";
            this.colValue.FillsFreeSpace = true;
            this.colValue.Text = "Value";
            this.colValue.Width = 317;
            // 
            // colRefID
            // 
            this.colRefID.AspectName = "IDref";
            this.colRefID.DisplayIndex = 6;
            this.colRefID.IsVisible = false;
            this.colRefID.Text = "";
            this.colRefID.Width = 144;
            // 
            // colRefPropName
            // 
            this.colRefPropName.AspectName = "RefPropName";
            this.colRefPropName.IsVisible = false;
            this.colRefPropName.Text = "RefPropName";
            // 
            // colEnable
            // 
            this.colEnable.AspectName = "Enable";
            this.colEnable.IsVisible = false;
            this.colEnable.Text = "";
            // 
            // groupInput
            // 
            this.groupInput.Controls.Add(this.tlStringItem);
            this.groupInput.Location = new System.Drawing.Point(3, 3);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(844, 192);
            this.groupInput.TabIndex = 10;
            this.groupInput.TabStop = false;
            this.groupInput.Text = "Settings";
            // 
            // flpOptions
            // 
            this.flpOptions.Controls.Add(this.groupInput);
            this.flpOptions.Controls.Add(this.ucStringBuilderItemProperty);
            this.flpOptions.Controls.Add(this.panFormat);
            this.flpOptions.Controls.Add(this.grpOutputString);
            this.flpOptions.Controls.Add(this.grpOutputHeaderString);
            this.flpOptions.Location = new System.Drawing.Point(3, 32);
            this.flpOptions.Name = "flpOptions";
            this.flpOptions.Size = new System.Drawing.Size(847, 598);
            this.flpOptions.TabIndex = 11;
            // 
            // ucStringBuilderItemProperty
            // 
            this.ucStringBuilderItemProperty.Location = new System.Drawing.Point(3, 201);
            this.ucStringBuilderItemProperty.Name = "ucStringBuilderItemProperty";
            this.ucStringBuilderItemProperty.RTCSBItem = null;
            this.ucStringBuilderItemProperty.RTCStringBuilderItemType = RTCEnums.EStringBuilderItemTypes.BooleanList;
            this.ucStringBuilderItemProperty.Size = new System.Drawing.Size(841, 107);
            this.ucStringBuilderItemProperty.TabIndex = 11;
            // 
            // panFormat
            // 
            this.panFormat.Controls.Add(this.groupBox2);
            this.panFormat.Controls.Add(this.ucInputDelimiter);
            this.panFormat.Location = new System.Drawing.Point(3, 314);
            this.panFormat.Name = "panFormat";
            this.panFormat.Size = new System.Drawing.Size(555, 105);
            this.panFormat.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.RTCEnumTerminator);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fixed Text";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RTCEnumTerminator
            // 
            this.RTCEnumTerminator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCEnumTerminator.FormattingEnabled = true;
            this.RTCEnumTerminator.Location = new System.Drawing.Point(93, 76);
            this.RTCEnumTerminator.Name = "RTCEnumTerminator";
            this.RTCEnumTerminator.Size = new System.Drawing.Size(124, 21);
            this.RTCEnumTerminator.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 22);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Terminator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Trailing Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Leading Text:";
            // 
            // ucInputDelimiter
            // 
            this.ucInputDelimiter.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucInputDelimiter.Location = new System.Drawing.Point(277, 0);
            this.ucInputDelimiter.Name = "ucInputDelimiter";
            this.ucInputDelimiter.RTCAction = null;
            this.ucInputDelimiter.RTCPropertyCustomValueName = "DelimiterCustom";
            this.ucInputDelimiter.RTCPropertyStandardValueName = "DelimiterStandard";
            this.ucInputDelimiter.RTCPropertyTypeName = "DelimiterType";
            this.ucInputDelimiter.Size = new System.Drawing.Size(278, 105);
            this.ucInputDelimiter.TabIndex = 0;
            // 
            // grpOutputString
            // 
            this.grpOutputString.Controls.Add(this.panel4);
            this.grpOutputString.Location = new System.Drawing.Point(3, 425);
            this.grpOutputString.Name = "grpOutputString";
            this.grpOutputString.Size = new System.Drawing.Size(555, 50);
            this.grpOutputString.TabIndex = 12;
            this.grpOutputString.TabStop = false;
            this.grpOutputString.Text = "Output Header String - 0 characters";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.lblOutput);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 18);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 29);
            this.panel4.TabIndex = 3;
            // 
            // lblOutput
            // 
            this.lblOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOutput.Location = new System.Drawing.Point(0, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(549, 16);
            this.lblOutput.TabIndex = 1;
            // 
            // grpOutputHeaderString
            // 
            this.grpOutputHeaderString.Controls.Add(this.panel5);
            this.grpOutputHeaderString.Location = new System.Drawing.Point(3, 481);
            this.grpOutputHeaderString.Name = "grpOutputHeaderString";
            this.grpOutputHeaderString.Size = new System.Drawing.Size(555, 50);
            this.grpOutputHeaderString.TabIndex = 13;
            this.grpOutputHeaderString.TabStop = false;
            this.grpOutputHeaderString.Text = "Output Header String - 0 characters";
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.lblOutputHeader);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 18);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(549, 29);
            this.panel5.TabIndex = 2;
            // 
            // lblOutputHeader
            // 
            this.lblOutputHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOutputHeader.Location = new System.Drawing.Point(0, 0);
            this.lblOutputHeader.Name = "lblOutputHeader";
            this.lblOutputHeader.Size = new System.Drawing.Size(549, 16);
            this.lblOutputHeader.TabIndex = 1;
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(639, 22);
            this.RTCName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Name";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(61, 11);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 13;
            this.RTCPassed.Text = "Passed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Pass/Fail:";
            // 
            // ucStringBuilderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucStringBuilderDetail";
            this.Size = new System.Drawing.Size(900, 767);
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
            this.PanButton.ResumeLayout(false);
            this.PanButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlStringItem)).EndInit();
            this.groupInput.ResumeLayout(false);
            this.flpOptions.ResumeLayout(false);
            this.panFormat.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpOutputString.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.grpOutputHeaderString.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyTreeList tlStringItem;
        private System.Windows.Forms.Button btnRunStringBuilder;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnUnGroup;
        private BrightIdeasSoftware.OLVColumn colDelete;
        private BrightIdeasSoftware.OLVColumn colSTT;
        private BrightIdeasSoftware.OLVColumn colItemName;
        private BrightIdeasSoftware.OLVColumn colType;
        private BrightIdeasSoftware.OLVColumn colRemove;
        private BrightIdeasSoftware.OLVColumn colLink;
        private BrightIdeasSoftware.OLVColumn colValue;
        private BrightIdeasSoftware.OLVColumn colRefID;
        private BrightIdeasSoftware.OLVColumn colRefPropName;
        private BrightIdeasSoftware.OLVColumn colEnable;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox RTCEnumTerminator;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ucInputDelimiter ucInputDelimiter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblOutputHeader;
        public System.Windows.Forms.FlowLayoutPanel PanButton;
        public System.Windows.Forms.FlowLayoutPanel flpOptions;
        public ucStringBuilderItemProperty ucStringBuilderItemProperty;
        public System.Windows.Forms.Panel panFormat;
        public System.Windows.Forms.GroupBox grpOutputString;
        public System.Windows.Forms.GroupBox grpOutputHeaderString;
        public System.Windows.Forms.GroupBox groupInput;
    }
}
