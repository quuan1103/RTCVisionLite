
namespace RTC_Vision_Lite.Forms
{
    partial class FrmProjectTemplates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProjectTemplates));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreateNewProjectBySelectedTemplate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnViewInExploer = new System.Windows.Forms.Button();
            this.btnEditRow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.grdSettingToolTemplates = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImageFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIconicFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoadFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPreview = new System.Windows.Forms.DataGridViewImageColumn();
            this.colLoadImageFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSettingToolTemplates)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdSettingToolTemplates, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.95349F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.04651F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(869, 443);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnCreateNewProjectBySelectedTemplate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 46);
            this.panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::RTC_Vision_Lite.Properties.Resources.Remove_16x16;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(776, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 29);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnCreateNewProjectBySelectedTemplate
            // 
            this.btnCreateNewProjectBySelectedTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNewProjectBySelectedTemplate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewProjectBySelectedTemplate.Image = global::RTC_Vision_Lite.Properties.Resources.Apply_16x161;
            this.btnCreateNewProjectBySelectedTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewProjectBySelectedTemplate.Location = new System.Drawing.Point(528, 8);
            this.btnCreateNewProjectBySelectedTemplate.Name = "btnCreateNewProjectBySelectedTemplate";
            this.btnCreateNewProjectBySelectedTemplate.Size = new System.Drawing.Size(242, 29);
            this.btnCreateNewProjectBySelectedTemplate.TabIndex = 0;
            this.btnCreateNewProjectBySelectedTemplate.Text = "Create New Project By Selected Template";
            this.btnCreateNewProjectBySelectedTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewProjectBySelectedTemplate.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteRow);
            this.panel1.Controls.Add(this.btnViewInExploer);
            this.panel1.Controls.Add(this.btnEditRow);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAddRow);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClearData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 48);
            this.panel1.TabIndex = 0;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRow.Image = global::RTC_Vision_Lite.Properties.Resources.DeleteDataSource_16x16;
            this.btnDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRow.Location = new System.Drawing.Point(173, 10);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(90, 29);
            this.btnDeleteRow.TabIndex = 0;
            this.btnDeleteRow.Text = "&Delete (F4)";
            this.btnDeleteRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            // 
            // btnViewInExploer
            // 
            this.btnViewInExploer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewInExploer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInExploer.Location = new System.Drawing.Point(563, 10);
            this.btnViewInExploer.Name = "btnViewInExploer";
            this.btnViewInExploer.Size = new System.Drawing.Size(111, 29);
            this.btnViewInExploer.TabIndex = 0;
            this.btnViewInExploer.Text = "View In Exploer";
            this.btnViewInExploer.UseVisualStyleBackColor = true;
            // 
            // btnEditRow
            // 
            this.btnEditRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRow.Image = global::RTC_Vision_Lite.Properties.Resources.EditDataSource_16x16;
            this.btnEditRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditRow.Location = new System.Drawing.Point(91, 10);
            this.btnEditRow.Name = "btnEditRow";
            this.btnEditRow.Size = new System.Drawing.Size(76, 29);
            this.btnEditRow.TabIndex = 0;
            this.btnEditRow.Text = "&Edit (F3)";
            this.btnEditRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditRow.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::RTC_Vision_Lite.Properties.Resources.Cancel_16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(464, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 29);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel (Esc)";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.Image = global::RTC_Vision_Lite.Properties.Resources.AddNewDataSource_16x16;
            this.btnAddRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRow.Location = new System.Drawing.Point(9, 10);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(76, 29);
            this.btnAddRow.TabIndex = 0;
            this.btnAddRow.Text = "&Add (F2)";
            this.btnAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRow.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::RTC_Vision_Lite.Properties.Resources.Apply_16x16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(356, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save (Ctrl + S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClearData
            // 
            this.btnClearData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearData.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearData.Image = global::RTC_Vision_Lite.Properties.Resources.Clear_16x16;
            this.btnClearData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearData.Location = new System.Drawing.Point(269, 10);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(81, 29);
            this.btnClearData.TabIndex = 0;
            this.btnClearData.Text = "&Clear (F5)";
            this.btnClearData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearData.UseVisualStyleBackColor = true;
            // 
            // grdSettingToolTemplates
            // 
            this.grdSettingToolTemplates.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSettingToolTemplates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSettingToolTemplates.ColumnHeadersHeight = 25;
            this.grdSettingToolTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colEditMode,
            this.colImageFileName,
            this.colIconicFileName,
            this.colOrderNum,
            this.colName,
            this.colFolderName,
            this.colLoadFile,
            this.colPreview,
            this.colLoadImageFile});
            this.grdSettingToolTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSettingToolTemplates.Location = new System.Drawing.Point(3, 57);
            this.grdSettingToolTemplates.Name = "grdSettingToolTemplates";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSettingToolTemplates.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSettingToolTemplates.RowHeadersVisible = false;
            this.grdSettingToolTemplates.RowHeadersWidth = 35;
            this.grdSettingToolTemplates.Size = new System.Drawing.Size(863, 331);
            this.grdSettingToolTemplates.TabIndex = 1;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colEditMode
            // 
            this.colEditMode.DataPropertyName = "EditMode";
            this.colEditMode.HeaderText = "Edit Mode";
            this.colEditMode.Name = "colEditMode";
            this.colEditMode.Visible = false;
            // 
            // colImageFileName
            // 
            this.colImageFileName.DataPropertyName = "ImageFileName";
            this.colImageFileName.HeaderText = "Image File Name";
            this.colImageFileName.Name = "colImageFileName";
            this.colImageFileName.Visible = false;
            // 
            // colIconicFileName
            // 
            this.colIconicFileName.DataPropertyName = "IconicFileName";
            this.colIconicFileName.HeaderText = "Iconic File Name";
            this.colIconicFileName.Name = "colIconicFileName";
            this.colIconicFileName.Visible = false;
            // 
            // colOrderNum
            // 
            this.colOrderNum.DataPropertyName = "OrderNum";
            this.colOrderNum.HeaderText = "Order";
            this.colOrderNum.Name = "colOrderNum";
            this.colOrderNum.Width = 50;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // colFolderName
            // 
            this.colFolderName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFolderName.DataPropertyName = "Folder";
            this.colFolderName.HeaderText = "Folder";
            this.colFolderName.Name = "colFolderName";
            // 
            // colLoadFile
            // 
            this.colLoadFile.HeaderText = "";
            this.colLoadFile.Name = "colLoadFile";
            this.colLoadFile.Width = 80;
            // 
            // colPreview
            // 
            this.colPreview.DataPropertyName = "Preview";
            this.colPreview.HeaderText = "Preview";
            this.colPreview.Name = "colPreview";
            this.colPreview.Width = 90;
            // 
            // colLoadImageFile
            // 
            this.colLoadImageFile.HeaderText = "Image File";
            this.colLoadImageFile.Name = "colLoadImageFile";
            this.colLoadImageFile.Width = 80;
            // 
            // FrmProjectTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 443);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProjectTemplates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Templates";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSettingToolTemplates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.DataGridView grdSettingToolTemplates;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCreateNewProjectBySelectedTemplate;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnViewInExploer;
        private System.Windows.Forms.Button btnEditRow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEditMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImageFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIconicFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolderName;
        private System.Windows.Forms.DataGridViewButtonColumn colLoadFile;
        private System.Windows.Forms.DataGridViewImageColumn colPreview;
        private System.Windows.Forms.DataGridViewButtonColumn colLoadImageFile;
    }
}