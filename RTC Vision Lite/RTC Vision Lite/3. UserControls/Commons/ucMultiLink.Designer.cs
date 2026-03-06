
namespace RTC_Vision_Lite.UserControls
{
    partial class ucMultiLink
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
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.tlLink = new RTC_Vision_Lite.UserControls.MyTreeList();
            this.colOrderNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSourceCam = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSourceTool = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSourceName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSourceIndex = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblValue = new System.Windows.Forms.Label();
            this.panActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnDulicate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlLink)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tlLink);
            this.grpMain.Controls.Add(this.flowLayoutPanel2);
            this.grpMain.Controls.Add(this.panActions);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(400, 154);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Image - InputImage";
            // 
            // tlLink
            // 
            this.tlLink.AllColumns.Add(this.colOrderNumber);
            this.tlLink.AllColumns.Add(this.colSourceCam);
            this.tlLink.AllColumns.Add(this.colSourceTool);
            this.tlLink.AllColumns.Add(this.colSourceName);
            this.tlLink.AllColumns.Add(this.colSourceIndex);
            this.tlLink.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.tlLink.CellEditUseWholeCell = false;
            this.tlLink.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrderNumber,
            this.colSourceCam,
            this.colSourceTool,
            this.colSourceName,
            this.colSourceIndex});
            this.tlLink.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlLink.HideSelection = false;
            this.tlLink.Location = new System.Drawing.Point(3, 43);
            this.tlLink.LockCalc = false;
            this.tlLink.Name = "tlLink";
            this.tlLink.OwnerDrawnHeader = true;
            this.tlLink.ShowGroups = false;
            this.tlLink.Size = new System.Drawing.Size(394, 86);
            this.tlLink.TabIndex = 2;
            this.tlLink.UseCompatibleStateImageBehavior = false;
            this.tlLink.View = System.Windows.Forms.View.Details;
            this.tlLink.VirtualMode = true;
            this.tlLink.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.tlLink_CellEditFinished);
            this.tlLink.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.tlLink_CellEditFinishing);
            this.tlLink.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.tlLink_CellEditStarting);
            this.tlLink.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlLink_CellClick);
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.AspectName = "OrderNumber";
            this.colOrderNumber.IsVisible = false;
            this.colOrderNumber.Text = "";
            this.colOrderNumber.Width = 0;
            // 
            // colSourceCam
            // 
            this.colSourceCam.AspectName = "SourceCam";
            this.colSourceCam.FillsFreeSpace = true;
            this.colSourceCam.Text = "Source Cam";
            this.colSourceCam.Width = 200;
            // 
            // colSourceTool
            // 
            this.colSourceTool.AspectName = "SourceTool";
            this.colSourceTool.FillsFreeSpace = true;
            this.colSourceTool.Text = "Source Tool";
            this.colSourceTool.Width = 200;
            // 
            // colSourceName
            // 
            this.colSourceName.AspectName = "SourceName";
            this.colSourceName.FillsFreeSpace = true;
            this.colSourceName.Text = "SourceName";
            this.colSourceName.Width = 200;
            // 
            // colSourceIndex
            // 
            this.colSourceIndex.AspectName = "SourceIndex";
            this.colSourceIndex.FillsFreeSpace = true;
            this.colSourceIndex.Text = "Index";
            this.colSourceIndex.Width = 200;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblValue);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 129);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(394, 22);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(3, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "Value";
            // 
            // panActions
            // 
            this.panActions.Controls.Add(this.btnDown);
            this.panActions.Controls.Add(this.btnUp);
            this.panActions.Controls.Add(this.btnReset);
            this.panActions.Controls.Add(this.btnRemove);
            this.panActions.Controls.Add(this.btnDulicate);
            this.panActions.Controls.Add(this.btnAdd);
            this.panActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panActions.Location = new System.Drawing.Point(3, 16);
            this.panActions.Name = "panActions";
            this.panActions.Size = new System.Drawing.Size(394, 27);
            this.panActions.TabIndex = 0;
            // 
            // btnDown
            // 
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Image = global::RTC_Vision_Lite.Properties.Resources.Down;
            this.btnDown.Location = new System.Drawing.Point(371, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(20, 20);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Image = global::RTC_Vision_Lite.Properties.Resources.Up;
            this.btnUp.Location = new System.Drawing.Point(345, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(20, 20);
            this.btnUp.TabIndex = 5;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Image = global::RTC_Vision_Lite.Properties.Resources.Clear_16x16;
            this.btnReset.Location = new System.Drawing.Point(319, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(20, 20);
            this.btnReset.TabIndex = 6;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Image = global::RTC_Vision_Lite.Properties.Resources.Close_16x16;
            this.btnRemove.Location = new System.Drawing.Point(293, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(20, 20);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnDulicate
            // 
            this.btnDulicate.BackColor = System.Drawing.SystemColors.Control;
            this.btnDulicate.FlatAppearance.BorderSize = 0;
            this.btnDulicate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDulicate.Image = global::RTC_Vision_Lite.Properties.Resources.Copy;
            this.btnDulicate.Location = new System.Drawing.Point(267, 3);
            this.btnDulicate.Name = "btnDulicate";
            this.btnDulicate.Size = new System.Drawing.Size(20, 20);
            this.btnDulicate.TabIndex = 7;
            this.btnDulicate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDulicate.UseVisualStyleBackColor = false;
            this.btnDulicate.Click += new System.EventHandler(this.btnDulicate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::RTC_Vision_Lite.Properties.Resources.Add_green_16x1;
            this.btnAdd.Location = new System.Drawing.Point(241, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(20, 20);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucMultiLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMain);
            this.Name = "ucMultiLink";
            this.Size = new System.Drawing.Size(400, 154);
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlLink)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.FlowLayoutPanel panActions;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnDulicate;
        private BrightIdeasSoftware.OLVColumn colOrderNumber;
        private BrightIdeasSoftware.OLVColumn colSourceCam;
        private BrightIdeasSoftware.OLVColumn colSourceTool;
        private BrightIdeasSoftware.OLVColumn colSourceName;
        private BrightIdeasSoftware.OLVColumn colSourceIndex;
        public UserControls.MyTreeList tlLink;
    }
}
