
namespace RTC_Vision_Lite.Forms
{
    partial class FrmProject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProject));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.txtModelNote = new System.Windows.Forms.TextBox();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.txtModelImage = new System.Windows.Forms.TextBox();
            this.nmrModelID = new System.Windows.Forms.NumericUpDown();
            this.btnSetImage = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkPinned = new System.Windows.Forms.CheckBox();
            this.groupCAMs = new System.Windows.Forms.GroupBox();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetupImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsMaster = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsBackground = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsAlign = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsChangeJob = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsHide = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsViewResult = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsJoinResult = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFileNameActions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsMaximize = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRunOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnMoveDown = new System.Windows.Forms.ToolStripButton();
            this.btnMoveUp = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteAllCAM = new System.Windows.Forms.ToolStripButton();
            this.btnCloneCAM = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteCAM = new System.Windows.Forms.ToolStripButton();
            this.btnAddCAM = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrModelID)).BeginInit();
            this.groupCAMs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Model Note";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Save Folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Model Image";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(631, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Model ID";
            // 
            // txtModelName
            // 
            this.txtModelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(92, 11);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(533, 22);
            this.txtModelName.TabIndex = 1;
            this.txtModelName.TextChanged += new System.EventHandler(this.txtModelName_TextChanged);
            // 
            // txtModelNote
            // 
            this.txtModelNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelNote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelNote.Location = new System.Drawing.Point(92, 39);
            this.txtModelNote.Name = "txtModelNote";
            this.txtModelNote.Size = new System.Drawing.Size(680, 22);
            this.txtModelNote.TabIndex = 1;
            this.txtModelNote.TextChanged += new System.EventHandler(this.txtModelNote_TextChanged);
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveFolder.Enabled = false;
            this.txtSaveFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaveFolder.Location = new System.Drawing.Point(92, 67);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.Size = new System.Drawing.Size(680, 22);
            this.txtSaveFolder.TabIndex = 1;
            // 
            // txtModelImage
            // 
            this.txtModelImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelImage.Location = new System.Drawing.Point(92, 95);
            this.txtModelImage.Name = "txtModelImage";
            this.txtModelImage.Size = new System.Drawing.Size(599, 22);
            this.txtModelImage.TabIndex = 1;
            // 
            // nmrModelID
            // 
            this.nmrModelID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmrModelID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrModelID.Location = new System.Drawing.Point(691, 11);
            this.nmrModelID.Name = "nmrModelID";
            this.nmrModelID.Size = new System.Drawing.Size(81, 22);
            this.nmrModelID.TabIndex = 2;
            this.nmrModelID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrModelID.ValueChanged += new System.EventHandler(this.nmrModelID_ValueChanged);
            // 
            // btnSetImage
            // 
            this.btnSetImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetImage.Location = new System.Drawing.Point(697, 95);
            this.btnSetImage.Name = "btnSetImage";
            this.btnSetImage.Size = new System.Drawing.Size(75, 23);
            this.btnSetImage.TabIndex = 3;
            this.btnSetImage.Text = "Set Image";
            this.btnSetImage.UseVisualStyleBackColor = true;
            this.btnSetImage.Click += new System.EventHandler(this.btnSetImage_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::RTC_Vision_Lite.Properties.Resources.Remove_16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(697, 526);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::RTC_Vision_Lite.Properties.Resources.Apply_16x16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(616, 526);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkPinned
            // 
            this.chkPinned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPinned.AutoSize = true;
            this.chkPinned.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPinned.Location = new System.Drawing.Point(548, 532);
            this.chkPinned.Name = "chkPinned";
            this.chkPinned.Size = new System.Drawing.Size(62, 17);
            this.chkPinned.TabIndex = 4;
            this.chkPinned.Text = "Pinned";
            this.chkPinned.UseVisualStyleBackColor = true;
            // 
            // groupCAMs
            // 
            this.groupCAMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCAMs.Controls.Add(this.grdData);
            this.groupCAMs.Controls.Add(this.toolStrip1);
            this.groupCAMs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCAMs.Location = new System.Drawing.Point(15, 123);
            this.groupCAMs.Name = "groupCAMs";
            this.groupCAMs.Size = new System.Drawing.Size(757, 397);
            this.groupCAMs.TabIndex = 6;
            this.groupCAMs.TabStop = false;
            this.groupCAMs.Text = "Window Settings";
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.BackgroundColor = System.Drawing.Color.White;
            this.grdData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdData.ColumnHeadersHeight = 35;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colGroupID,
            this.colIsGroup,
            this.colOrderNum,
            this.colName,
            this.colDescription,
            this.colSetupImage,
            this.colIsActive,
            this.colIsMaster,
            this.colIsBackground,
            this.colIsAlign,
            this.colIsChangeJob,
            this.colIsHide,
            this.colIsViewResult,
            this.colIsJoinResult,
            this.colFileNameActions,
            this.colIsMaximize,
            this.colRunOrder});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.GridColor = System.Drawing.SystemColors.Control;
            this.grdData.Location = new System.Drawing.Point(3, 43);
            this.grdData.Name = "grdData";
            this.grdData.RowHeadersVisible = false;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(751, 351);
            this.grdData.TabIndex = 1;
            this.grdData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellValueChanged);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colGroupID
            // 
            this.colGroupID.DataPropertyName = "GroupID";
            this.colGroupID.HeaderText = "GroupID";
            this.colGroupID.Name = "colGroupID";
            this.colGroupID.Visible = false;
            // 
            // colIsGroup
            // 
            this.colIsGroup.DataPropertyName = "IsGroup";
            this.colIsGroup.HeaderText = "IsGroup";
            this.colIsGroup.Name = "colIsGroup";
            this.colIsGroup.Visible = false;
            // 
            // colOrderNum
            // 
            this.colOrderNum.DataPropertyName = "OrderNum";
            this.colOrderNum.HeaderText = "Order";
            this.colOrderNum.Name = "colOrderNum";
            this.colOrderNum.Width = 60;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.FillWeight = 300F;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 120;
            // 
            // colSetupImage
            // 
            this.colSetupImage.DataPropertyName = "Image";
            this.colSetupImage.HeaderText = "Image";
            this.colSetupImage.Name = "colSetupImage";
            this.colSetupImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSetupImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSetupImage.Width = 70;
            // 
            // colIsActive
            // 
            this.colIsActive.DataPropertyName = "IsActive";
            this.colIsActive.HeaderText = "Active";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsActive.Width = 50;
            // 
            // colIsMaster
            // 
            this.colIsMaster.DataPropertyName = "IsMaster";
            this.colIsMaster.HeaderText = "Master";
            this.colIsMaster.Name = "colIsMaster";
            this.colIsMaster.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsMaster.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsMaster.Width = 50;
            // 
            // colIsBackground
            // 
            this.colIsBackground.DataPropertyName = "IsBackground";
            this.colIsBackground.HeaderText = "Background";
            this.colIsBackground.Name = "colIsBackground";
            this.colIsBackground.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsBackground.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsBackground.Width = 80;
            // 
            // colIsAlign
            // 
            this.colIsAlign.DataPropertyName = "IsAlign";
            this.colIsAlign.HeaderText = "Align";
            this.colIsAlign.Name = "colIsAlign";
            this.colIsAlign.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsAlign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsAlign.Visible = false;
            // 
            // colIsChangeJob
            // 
            this.colIsChangeJob.DataPropertyName = "IsChangeJob";
            this.colIsChangeJob.HeaderText = "Change Job";
            this.colIsChangeJob.Name = "colIsChangeJob";
            this.colIsChangeJob.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsChangeJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsChangeJob.Visible = false;
            // 
            // colIsHide
            // 
            this.colIsHide.DataPropertyName = "IsHide";
            this.colIsHide.HeaderText = "Hide";
            this.colIsHide.Name = "colIsHide";
            this.colIsHide.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsHide.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsHide.Width = 50;
            // 
            // colIsViewResult
            // 
            this.colIsViewResult.DataPropertyName = "IsViewResult";
            this.colIsViewResult.HeaderText = "View Result";
            this.colIsViewResult.Name = "colIsViewResult";
            this.colIsViewResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsViewResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsViewResult.Width = 50;
            // 
            // colIsJoinResult
            // 
            this.colIsJoinResult.DataPropertyName = "IsJoinResult";
            this.colIsJoinResult.HeaderText = "Join Result";
            this.colIsJoinResult.Name = "colIsJoinResult";
            this.colIsJoinResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsJoinResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsJoinResult.Width = 50;
            // 
            // colFileNameActions
            // 
            this.colFileNameActions.DataPropertyName = "FileNameActions";
            this.colFileNameActions.HeaderText = "File Name Actions";
            this.colFileNameActions.Name = "colFileNameActions";
            this.colFileNameActions.Visible = false;
            // 
            // colIsMaximize
            // 
            this.colIsMaximize.DataPropertyName = "IsMaximize";
            this.colIsMaximize.HeaderText = "Maximize";
            this.colIsMaximize.Name = "colIsMaximize";
            this.colIsMaximize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsMaximize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsMaximize.Width = 60;
            // 
            // colRunOrder
            // 
            this.colRunOrder.DataPropertyName = "RunOrder";
            this.colRunOrder.HeaderText = "Run Order";
            this.colRunOrder.Name = "colRunOrder";
            this.colRunOrder.Width = 50;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMoveDown,
            this.btnMoveUp,
            this.btnDeleteAllCAM,
            this.btnCloneCAM,
            this.btnDeleteCAM,
            this.btnAddCAM});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(751, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(23, 22);
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.Click += new System.EventHandler(this.MoveCAMDown);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(23, 22);
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.Click += new System.EventHandler(this.MoveCamUp);
            // 
            // btnDeleteAllCAM
            // 
            this.btnDeleteAllCAM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteAllCAM.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteAllCAM.Image")));
            this.btnDeleteAllCAM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteAllCAM.Name = "btnDeleteAllCAM";
            this.btnDeleteAllCAM.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteAllCAM.Text = "Delete All CAM";
            this.btnDeleteAllCAM.Click += new System.EventHandler(this.DeleteAllCam);
            // 
            // btnCloneCAM
            // 
            this.btnCloneCAM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloneCAM.Image = ((System.Drawing.Image)(resources.GetObject("btnCloneCAM.Image")));
            this.btnCloneCAM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloneCAM.Name = "btnCloneCAM";
            this.btnCloneCAM.Size = new System.Drawing.Size(23, 22);
            this.btnCloneCAM.Text = "Clone CAM";
            this.btnCloneCAM.Click += new System.EventHandler(this.CloneCam);
            // 
            // btnDeleteCAM
            // 
            this.btnDeleteCAM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteCAM.Image = global::RTC_Vision_Lite.Properties.Resources.Delete16x16_2;
            this.btnDeleteCAM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteCAM.Name = "btnDeleteCAM";
            this.btnDeleteCAM.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteCAM.Text = "Delete CAM";
            this.btnDeleteCAM.Click += new System.EventHandler(this.DeleteCam);
            // 
            // btnAddCAM
            // 
            this.btnAddCAM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddCAM.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCAM.Image")));
            this.btnAddCAM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCAM.Name = "btnAddCAM";
            this.btnAddCAM.Size = new System.Drawing.Size(23, 22);
            this.btnAddCAM.Text = "Add CAM";
            this.btnAddCAM.Click += new System.EventHandler(this.btnAddCAM_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Image = global::RTC_Vision_Lite.Properties.Resources.Question_16x16;
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(15, 526);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(63, 29);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "&Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // FrmProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupCAMs);
            this.Controls.Add(this.chkPinned);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSetImage);
            this.Controls.Add(this.nmrModelID);
            this.Controls.Add(this.txtModelImage);
            this.Controls.Add(this.txtSaveFolder);
            this.Controls.Add(this.txtModelNote);
            this.Controls.Add(this.txtModelName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FrmProject";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Info";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmProject_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProject_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nmrModelID)).EndInit();
            this.groupCAMs.ResumeLayout(false);
            this.groupCAMs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.TextBox txtModelNote;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.TextBox txtModelImage;
        private System.Windows.Forms.NumericUpDown nmrModelID;
        private System.Windows.Forms.Button btnSetImage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.CheckBox chkPinned;
        private System.Windows.Forms.GroupBox groupCAMs;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnMoveDown;
        private System.Windows.Forms.ToolStripButton btnMoveUp;
        private System.Windows.Forms.ToolStripButton btnDeleteAllCAM;
        private System.Windows.Forms.ToolStripButton btnDeleteCAM;
        private System.Windows.Forms.ToolStripButton btnCloneCAM;
        private System.Windows.Forms.ToolStripButton btnAddCAM;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewButtonColumn colSetupImage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsActive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsMaster;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsBackground;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsAlign;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsChangeJob;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsHide;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsViewResult;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsJoinResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileNameActions;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsMaximize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunOrder;
    }
}