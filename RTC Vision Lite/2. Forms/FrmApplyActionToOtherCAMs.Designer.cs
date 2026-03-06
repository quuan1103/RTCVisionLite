
namespace RTC_Vision_Lite.Forms
{
    partial class FrmApplyActionToOtherCAMs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApplyActionToOtherCAMs));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tl = new RTC_Vision_Lite.UserControls.MyTreeList();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSelect = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkCopyTools = new System.Windows.Forms.CheckBox();
            this.chkCopyImages = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tl)).BeginInit();
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
            this.groupBox1.Controls.Add(this.tl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 219);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose other CAMs need apply by current CAM actions";
            // 
            // tl
            // 
            this.tl.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.tl.AllColumns.Add(this.olvColumn1);
            this.tl.AllColumns.Add(this.colSelect);
            this.tl.AllColumns.Add(this.colName);
            this.tl.AllColumns.Add(this.colID);
            this.tl.AllowDrop = true;
            this.tl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tl.CellEditUseWholeCell = false;
            this.tl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.colSelect,
            this.colName});
            this.tl.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.tl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tl.FullRowSelect = true;
            this.tl.HideSelection = false;
            this.tl.Location = new System.Drawing.Point(3, 16);
            this.tl.LockCalc = false;
            this.tl.Name = "tl";
            this.tl.OverlayImage.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tl.OverlayImage.InsetX = 50;
            this.tl.OverlayImage.InsetY = 50;
            this.tl.OverlayImage.Offset = new System.Drawing.Size(50, 0);
            this.tl.OverlayText.Offset = new System.Drawing.Size(50, 0);
            this.tl.OwnerDrawnHeader = true;
            this.tl.RowHeight = 30;
            this.tl.SelectedBackColor = System.Drawing.Color.LemonChiffon;
            this.tl.SelectedForeColor = System.Drawing.Color.Black;
            this.tl.ShowGroups = false;
            this.tl.ShowImagesOnSubItems = true;
            this.tl.ShowSortIndicators = false;
            this.tl.Size = new System.Drawing.Size(472, 200);
            this.tl.TabIndex = 5;
            this.tl.TileSize = new System.Drawing.Size(50, 50);
            this.tl.UseCellFormatEvents = true;
            this.tl.UseCompatibleStateImageBehavior = false;
            this.tl.UseSubItemCheckBoxes = true;
            this.tl.UseWaitCursor = true;
            this.tl.View = System.Windows.Forms.View.Details;
            this.tl.VirtualMode = true;
            this.tl.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.tlCAMs_SubItemChecking);
            this.tl.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tlCAMs_FormatCell);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "";
            this.olvColumn1.Width = 5;
            // 
            // colSelect
            // 
            this.colSelect.AspectName = "SelectCam";
            this.colSelect.CellEditUseWholeCell = true;
            this.colSelect.CheckBoxes = true;
            this.colSelect.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSelect.Text = "Select";
            this.colSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSelect.TriStateCheckBoxes = true;
            // 
            // colName
            // 
            this.colName.AspectName = "CamName";
            this.colName.FillsFreeSpace = true;
            this.colName.Text = "Name";
            this.colName.Width = 301;
            // 
            // colID
            // 
            this.colID.AspectName = "ID";
            this.colID.DisplayIndex = 0;
            this.colID.IsVisible = false;
            this.colID.Text = "";
            this.colID.Width = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkCopyTools);
            this.panel2.Controls.Add(this.chkCopyImages);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 53);
            this.panel2.TabIndex = 5;
            // 
            // chkCopyTools
            // 
            this.chkCopyTools.AutoSize = true;
            this.chkCopyTools.Location = new System.Drawing.Point(12, 20);
            this.chkCopyTools.Name = "chkCopyTools";
            this.chkCopyTools.Size = new System.Drawing.Size(79, 17);
            this.chkCopyTools.TabIndex = 4;
            this.chkCopyTools.Text = "Copy Tools";
            this.chkCopyTools.UseVisualStyleBackColor = true;
            // 
            // chkCopyImages
            // 
            this.chkCopyImages.AutoSize = true;
            this.chkCopyImages.Location = new System.Drawing.Point(109, 20);
            this.chkCopyImages.Name = "chkCopyImages";
            this.chkCopyImages.Size = new System.Drawing.Size(87, 17);
            this.chkCopyImages.TabIndex = 3;
            this.chkCopyImages.Text = "Copy Images";
            this.chkCopyImages.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(373, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cancel";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(258, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmApplyActionToOtherCAMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 274);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmApplyActionToOtherCAMs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Tools";
            this.Load += new System.EventHandler(this.FrmApplyActionToOtherCAMs_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tl)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkCopyTools;
        private System.Windows.Forms.CheckBox chkCopyImages;
        private BrightIdeasSoftware.OLVColumn colID;
        public UserControls.MyTreeList tl;
        public BrightIdeasSoftware.OLVColumn colSelect;
        public BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
    }
}