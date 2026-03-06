
namespace RTC_Vision_Lite.Forms
{
    partial class frmWindowChoosed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWindowChoosed));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.tlChoosedCams = new RTC_Vision_Lite.UserControls.MyTreeList();
            this.colSelect = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colActionType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlChoosedCams)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.tlChoosedCams);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 561);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Of Tool";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 19);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(37, 17);
            this.chkSelectAll.TabIndex = 1;
            this.chkSelectAll.Text = "All";
            this.chkSelectAll.UseVisualStyleBackColor = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // tlChoosedCams
            // 
            this.tlChoosedCams.AllColumns.Add(this.colSelect);
            this.tlChoosedCams.AllColumns.Add(this.colName);
            this.tlChoosedCams.AllColumns.Add(this.colID);
            this.tlChoosedCams.AllColumns.Add(this.colActionType);
            this.tlChoosedCams.CellEditUseWholeCell = false;
            this.tlChoosedCams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSelect,
            this.colName});
            this.tlChoosedCams.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlChoosedCams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlChoosedCams.HideSelection = false;
            this.tlChoosedCams.Location = new System.Drawing.Point(3, 16);
            this.tlChoosedCams.LockCalc = false;
            this.tlChoosedCams.Name = "tlChoosedCams";
            this.tlChoosedCams.OwnerDrawnHeader = true;
            this.tlChoosedCams.ShowGroups = false;
            this.tlChoosedCams.ShowImagesOnSubItems = true;
            this.tlChoosedCams.Size = new System.Drawing.Size(678, 542);
            this.tlChoosedCams.TabIndex = 0;
            this.tlChoosedCams.UseCellFormatEvents = true;
            this.tlChoosedCams.UseCompatibleStateImageBehavior = false;
            this.tlChoosedCams.UseSubItemCheckBoxes = true;
            this.tlChoosedCams.View = System.Windows.Forms.View.Details;
            this.tlChoosedCams.VirtualMode = true;
            this.tlChoosedCams.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlChoosedActions_CellClick);
            this.tlChoosedCams.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.tlChoosedActions_SubItemChecking);
            this.tlChoosedCams.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tlChoosedActions_FormatCell);
            // 
            // colSelect
            // 
            this.colSelect.AspectName = "Select";
            this.colSelect.CheckBoxes = true;
            this.colSelect.Text = "";
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
            this.btnOK.Location = new System.Drawing.Point(498, 16);
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
            // frmWindowChoosed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWindowChoosed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Tools";
            this.Load += new System.EventHandler(this.FrmActionsChoose_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlChoosedCams)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private UserControls.MyTreeList tlChoosedCams;
        private BrightIdeasSoftware.OLVColumn colSelect;
        private BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn colID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button3;
        private BrightIdeasSoftware.OLVColumn colActionType;
    }
}