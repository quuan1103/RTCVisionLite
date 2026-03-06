
namespace RTC_Vision_Lite.Forms
{
    partial class FrmActionsChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActionsChoose));
            this.rdCurrentProject = new System.Windows.Forms.RadioButton();
            this.rdOrtherFile = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cbCamName = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.tlChoosedActions = new RTC_Vision_Lite.UserControls.MyTreeList();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSelect = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colActionType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlChoosedActions)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdCurrentProject
            // 
            this.rdCurrentProject.AutoSize = true;
            this.rdCurrentProject.Checked = true;
            this.rdCurrentProject.Location = new System.Drawing.Point(12, 12);
            this.rdCurrentProject.Name = "rdCurrentProject";
            this.rdCurrentProject.Size = new System.Drawing.Size(95, 17);
            this.rdCurrentProject.TabIndex = 0;
            this.rdCurrentProject.TabStop = true;
            this.rdCurrentProject.Text = "Current Project";
            this.rdCurrentProject.UseVisualStyleBackColor = true;
            this.rdCurrentProject.CheckedChanged += new System.EventHandler(this.rdCurrentProject_CheckedChanged);
            // 
            // rdOrtherFile
            // 
            this.rdOrtherFile.AutoSize = true;
            this.rdOrtherFile.Location = new System.Drawing.Point(12, 35);
            this.rdOrtherFile.Name = "rdOrtherFile";
            this.rdOrtherFile.Size = new System.Drawing.Size(75, 17);
            this.rdOrtherFile.TabIndex = 1;
            this.rdOrtherFile.Text = "Other Files";
            this.rdOrtherFile.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelectFile);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.cbCamName);
            this.panel1.Controls.Add(this.rdOrtherFile);
            this.panel1.Controls.Add(this.rdCurrentProject);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 73);
            this.panel1.TabIndex = 2;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSelectFile.Location = new System.Drawing.Point(612, 38);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(23, 20);
            this.btnSelectFile.TabIndex = 4;
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(123, 38);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(488, 20);
            this.txtFileName.TabIndex = 3;
            this.txtFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFileName_KeyDown);
            // 
            // cbCamName
            // 
            this.cbCamName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamName.FormattingEnabled = true;
            this.cbCamName.Location = new System.Drawing.Point(123, 11);
            this.cbCamName.Name = "cbCamName";
            this.cbCamName.Size = new System.Drawing.Size(512, 21);
            this.cbCamName.TabIndex = 2;
            this.cbCamName.SelectedIndexChanged += new System.EventHandler(this.cbCamName_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-119, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSelectAll);
            this.groupBox1.Controls.Add(this.tlChoosedActions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 488);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Of Tool";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkSelectAll.Location = new System.Drawing.Point(26, 19);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(37, 17);
            this.chkSelectAll.TabIndex = 1;
            this.chkSelectAll.Text = "All";
            this.chkSelectAll.UseVisualStyleBackColor = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // tlChoosedActions
            // 
            this.tlChoosedActions.AllColumns.Add(this.olvColumn1);
            this.tlChoosedActions.AllColumns.Add(this.colSelect);
            this.tlChoosedActions.AllColumns.Add(this.colName);
            this.tlChoosedActions.AllColumns.Add(this.colID);
            this.tlChoosedActions.AllColumns.Add(this.colActionType);
            this.tlChoosedActions.CellEditUseWholeCell = false;
            this.tlChoosedActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.colSelect,
            this.colName});
            this.tlChoosedActions.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlChoosedActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlChoosedActions.HideSelection = false;
            this.tlChoosedActions.Location = new System.Drawing.Point(3, 16);
            this.tlChoosedActions.LockCalc = false;
            this.tlChoosedActions.Name = "tlChoosedActions";
            this.tlChoosedActions.OwnerDrawnHeader = true;
            this.tlChoosedActions.ShowGroups = false;
            this.tlChoosedActions.ShowImagesOnSubItems = true;
            this.tlChoosedActions.Size = new System.Drawing.Size(678, 469);
            this.tlChoosedActions.TabIndex = 0;
            this.tlChoosedActions.UseCellFormatEvents = true;
            this.tlChoosedActions.UseCompatibleStateImageBehavior = false;
            this.tlChoosedActions.UseSubItemCheckBoxes = true;
            this.tlChoosedActions.View = System.Windows.Forms.View.Details;
            this.tlChoosedActions.VirtualMode = true;
            this.tlChoosedActions.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlChoosedActions_CellClick);
            this.tlChoosedActions.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.tlChoosedActions_SubItemChecking);
            this.tlChoosedActions.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tlChoosedActions_FormatCell);
            this.tlChoosedActions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tlChoosedActions_ItemCheck);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "";
            this.olvColumn1.Width = 10;
            // 
            // colSelect
            // 
            this.colSelect.AspectName = "Select";
            this.colSelect.CheckBoxes = true;
            this.colSelect.Text = "";
            this.colSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSelect.Width = 51;
            // 
            // colName
            // 
            this.colName.AspectName = "Name";
            this.colName.FillsFreeSpace = true;
            this.colName.Text = "ToolName";
            this.colName.Width = 557;
            // 
            // colID
            // 
            this.colID.AspectName = "ID";
            this.colID.IsVisible = false;
            // 
            // colActionType
            // 
            this.colActionType.AspectName = "ActionType";
            this.colActionType.IsVisible = false;
            this.colActionType.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 511);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 50);
            this.panel2.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(603, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(503, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(3, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Help";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FrmActionsChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmActionsChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Tools";
            this.Load += new System.EventHandler(this.FrmActionsChoose_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlChoosedActions)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdCurrentProject;
        private System.Windows.Forms.RadioButton rdOrtherFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ComboBox cbCamName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private UserControls.MyTreeList tlChoosedActions;
        private BrightIdeasSoftware.OLVColumn colSelect;
        private BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn colID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button3;
        private BrightIdeasSoftware.OLVColumn colActionType;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
    }
}