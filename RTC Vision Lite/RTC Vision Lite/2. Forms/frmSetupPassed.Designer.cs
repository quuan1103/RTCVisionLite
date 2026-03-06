namespace RTC_Vision_Lite.Forms
{
    partial class frmSetupPassed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupPassed));
            this.GroupCAMs = new System.Windows.Forms.GroupBox();
            this.chkViewOutput = new System.Windows.Forms.CheckBox();
            this.chkNeedPass = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.tlSetup = new BrightIdeasSoftware.TreeListView();
            this.colHide = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colActive = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colX = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colY = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colNeedPassed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDrawingType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIsDisplayOutput = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.bntHelp = new System.Windows.Forms.Button();
            this.GroupCAMs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlSetup)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupCAMs
            // 
            this.GroupCAMs.Controls.Add(this.chkViewOutput);
            this.GroupCAMs.Controls.Add(this.chkNeedPass);
            this.GroupCAMs.Controls.Add(this.chkActive);
            this.GroupCAMs.Controls.Add(this.tlSetup);
            this.GroupCAMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupCAMs.Location = new System.Drawing.Point(0, 0);
            this.GroupCAMs.Name = "GroupCAMs";
            this.GroupCAMs.Size = new System.Drawing.Size(800, 450);
            this.GroupCAMs.TabIndex = 0;
            this.GroupCAMs.TabStop = false;
            this.GroupCAMs.Text = "List of ROIs";
            // 
            // chkViewOutput
            // 
            this.chkViewOutput.BackColor = System.Drawing.Color.White;
            this.chkViewOutput.Location = new System.Drawing.Point(541, 19);
            this.chkViewOutput.Name = "chkViewOutput";
            this.chkViewOutput.Size = new System.Drawing.Size(102, 23);
            this.chkViewOutput.TabIndex = 4;
            this.chkViewOutput.Text = "View Ouput";
            this.chkViewOutput.UseVisualStyleBackColor = false;
            this.chkViewOutput.CheckedChanged += new System.EventHandler(this.chkViewOutput_CheckedChanged);
            // 
            // chkNeedPass
            // 
            this.chkNeedPass.BackColor = System.Drawing.Color.White;
            this.chkNeedPass.Location = new System.Drawing.Point(356, 18);
            this.chkNeedPass.Name = "chkNeedPass";
            this.chkNeedPass.Size = new System.Drawing.Size(95, 24);
            this.chkNeedPass.TabIndex = 3;
            this.chkNeedPass.Text = "Need Pass";
            this.chkNeedPass.UseVisualStyleBackColor = false;
            this.chkNeedPass.CheckedChanged += new System.EventHandler(this.chkNeedPass_CheckedChanged);
            // 
            // chkActive
            // 
            this.chkActive.BackColor = System.Drawing.Color.White;
            this.chkActive.Location = new System.Drawing.Point(6, 17);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(67, 25);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = false;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // tlSetup
            // 
            this.tlSetup.AllColumns.Add(this.colHide);
            this.tlSetup.AllColumns.Add(this.colActive);
            this.tlSetup.AllColumns.Add(this.colID);
            this.tlSetup.AllColumns.Add(this.colName);
            this.tlSetup.AllColumns.Add(this.colX);
            this.tlSetup.AllColumns.Add(this.colY);
            this.tlSetup.AllColumns.Add(this.colNeedPassed);
            this.tlSetup.AllColumns.Add(this.colDrawingType);
            this.tlSetup.AllColumns.Add(this.colIsDisplayOutput);
            this.tlSetup.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.tlSetup.CellEditUseWholeCell = false;
            this.tlSetup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHide,
            this.colActive,
            this.colName,
            this.colX,
            this.colY,
            this.colNeedPassed,
            this.colDrawingType,
            this.colIsDisplayOutput});
            this.tlSetup.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlSetup.HideSelection = false;
            this.tlSetup.Location = new System.Drawing.Point(3, 16);
            this.tlSetup.Name = "tlSetup";
            this.tlSetup.ShowGroups = false;
            this.tlSetup.Size = new System.Drawing.Size(794, 431);
            this.tlSetup.TabIndex = 0;
            this.tlSetup.UseCompatibleStateImageBehavior = false;
            this.tlSetup.View = System.Windows.Forms.View.Details;
            this.tlSetup.VirtualMode = true;
            this.tlSetup.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.tlSetup_CellEditFinishing);
            this.tlSetup.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.tlSetup_CellEditStarting);
            this.tlSetup.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.tlSetup_SubItemChecking);
            // 
            // colHide
            // 
            this.colHide.Text = "";
            this.colHide.Width = 0;
            // 
            // colActive
            // 
            this.colActive.AspectName = "Active";
            this.colActive.CheckBoxes = true;
            this.colActive.Text = "";
            this.colActive.Width = 61;
            // 
            // colID
            // 
            this.colID.AspectName = "ID";
            this.colID.DisplayIndex = 0;
            this.colID.IsVisible = false;
            this.colID.Text = "";
            // 
            // colName
            // 
            this.colName.AspectName = "Name";
            this.colName.Text = "Name";
            this.colName.Width = 166;
            // 
            // colX
            // 
            this.colX.AspectName = "X";
            this.colX.Text = "X";
            this.colX.Width = 74;
            // 
            // colY
            // 
            this.colY.AspectName = "Y";
            this.colY.Text = "Y";
            this.colY.Width = 50;
            // 
            // colNeedPassed
            // 
            this.colNeedPassed.AspectName = "NeedPass";
            this.colNeedPassed.CheckBoxes = true;
            this.colNeedPassed.Text = "";
            this.colNeedPassed.Width = 96;
            // 
            // colDrawingType
            // 
            this.colDrawingType.AspectName = "Type";
            this.colDrawingType.Text = "Type";
            this.colDrawingType.Width = 88;
            // 
            // colIsDisplayOutput
            // 
            this.colIsDisplayOutput.AspectName = "IsDisplayOutput";
            this.colIsDisplayOutput.CheckBoxes = true;
            this.colIsDisplayOutput.Text = "";
            this.colIsDisplayOutput.Width = 106;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.bntHelp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 40);
            this.panel1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::RTC_Vision_Lite.Properties.Resources.Apply_16x16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(557, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::RTC_Vision_Lite.Properties.Resources.Action_Delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(681, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bntHelp
            // 
            this.bntHelp.Location = new System.Drawing.Point(12, 11);
            this.bntHelp.Name = "bntHelp";
            this.bntHelp.Size = new System.Drawing.Size(75, 23);
            this.bntHelp.TabIndex = 0;
            this.bntHelp.Text = "Help";
            this.bntHelp.UseVisualStyleBackColor = true;
            // 
            // frmSetupPassed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupCAMs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetupPassed";
            this.Text = "Setup Passed";
            this.GroupCAMs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlSetup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupCAMs;
        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.TreeListView tlSetup;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button bntHelp;
        private BrightIdeasSoftware.OLVColumn colID;
        private BrightIdeasSoftware.OLVColumn colActive;
        private BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn colX;
        private BrightIdeasSoftware.OLVColumn colY;
        private BrightIdeasSoftware.OLVColumn colNeedPassed;
        private BrightIdeasSoftware.OLVColumn colDrawingType;
        private BrightIdeasSoftware.OLVColumn colIsDisplayOutput;
        private System.Windows.Forms.CheckBox chkViewOutput;
        private System.Windows.Forms.CheckBox chkNeedPass;
        private System.Windows.Forms.CheckBox chkActive;
        private BrightIdeasSoftware.OLVColumn colHide;
    }
}