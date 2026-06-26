
namespace RTC_Vision_Lite.UserControls
{
    partial class ucResetToolActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucResetToolActionDetail));
            this.tlInputPassCriteria = new BrightIdeasSoftware.TreeListView();
            this.colRef = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colActive = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSetting = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSettingValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIDRef = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageListValue = new System.Windows.Forms.ImageList(this.components);
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollablePassFail.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlInputPassCriteria)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(5, 5);
            this.ScrollableGeneral.Size = new System.Drawing.Size(1149, 501);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(5, 51);
            this.PageSetup.Size = new System.Drawing.Size(1182, 519);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ROI.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PassFail.Size = new System.Drawing.Size(1159, 511);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Controls.Add(this.RTCPassed);
            this.ScrollablePassFail.Controls.Add(this.label6);
            this.ScrollablePassFail.Controls.Add(this.groupBox1);
            this.ScrollablePassFail.Size = new System.Drawing.Size(1159, 511);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Location = new System.Drawing.Point(5, 5);
            this.ScrollableROI.Size = new System.Drawing.Size(1151, 503);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Size = new System.Drawing.Size(1182, 46);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Method.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(5, 5);
            this.ScrollableMethod.Size = new System.Drawing.Size(1151, 503);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Location = new System.Drawing.Point(5, 5);
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
            this.Selecticon.Images.SetKeyName(6, "RemoveLink");
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
            // tlInputPassCriteria
            // 
            this.tlInputPassCriteria.AllColumns.Add(this.colRef);
            this.tlInputPassCriteria.AllColumns.Add(this.colActive);
            this.tlInputPassCriteria.AllColumns.Add(this.colType);
            this.tlInputPassCriteria.AllColumns.Add(this.colSetting);
            this.tlInputPassCriteria.AllColumns.Add(this.colSettingValue);
            this.tlInputPassCriteria.AllColumns.Add(this.colIDRef);
            this.tlInputPassCriteria.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.tlInputPassCriteria.CellEditUseWholeCell = false;
            this.tlInputPassCriteria.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRef,
            this.colActive,
            this.colType,
            this.colSetting});
            this.tlInputPassCriteria.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlInputPassCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlInputPassCriteria.FullRowSelect = true;
            this.tlInputPassCriteria.HideSelection = false;
            this.tlInputPassCriteria.Location = new System.Drawing.Point(4, 19);
            this.tlInputPassCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlInputPassCriteria.Name = "tlInputPassCriteria";
            this.tlInputPassCriteria.ShowGroups = false;
            this.tlInputPassCriteria.ShowImagesOnSubItems = true;
            this.tlInputPassCriteria.Size = new System.Drawing.Size(1151, 427);
            this.tlInputPassCriteria.TabIndex = 0;
            this.tlInputPassCriteria.UseCellFormatEvents = true;
            this.tlInputPassCriteria.UseCompatibleStateImageBehavior = false;
            this.tlInputPassCriteria.UseSubItemCheckBoxes = true;
            this.tlInputPassCriteria.View = System.Windows.Forms.View.Details;
            this.tlInputPassCriteria.VirtualMode = true;
            this.tlInputPassCriteria.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlInputPassCriteria_ButtonClick);
            this.tlInputPassCriteria.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlInputPassCriteria_CellClick);
            this.tlInputPassCriteria.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.tlInputPassCriteria_SubItemChecking);
            this.tlInputPassCriteria.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tlInputPassCriteria_FormatCell);
            // 
            // colRef
            // 
            this.colRef.AspectName = "ToolName";
            this.colRef.FillsFreeSpace = true;
            this.colRef.Text = "Tool Name";
            this.colRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colRef.Width = 467;
            // 
            // colActive
            // 
            this.colActive.AspectName = "IsReset";
            this.colActive.CheckBoxes = true;
            this.colActive.Text = "IsReset";
            this.colActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colActive.TriStateCheckBoxes = true;
            this.colActive.Width = 137;
            // 
            // colType
            // 
            this.colType.AspectName = "Type";
            this.colType.FillsFreeSpace = true;
            this.colType.Text = "Type";
            this.colType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colType.Width = 70;
            // 
            // colSetting
            // 
            this.colSetting.AspectName = "Settings";
            this.colSetting.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.colSetting.IsButton = true;
            this.colSetting.Text = "Setting";
            this.colSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSetting.Width = 98;
            // 
            // colSettingValue
            // 
            this.colSettingValue.AspectName = "SettingsValue";
            this.colSettingValue.DisplayIndex = 4;
            this.colSettingValue.IsVisible = false;
            this.colSettingValue.Text = "Invert";
            this.colSettingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSettingValue.Width = 130;
            // 
            // colIDRef
            // 
            this.colIDRef.AspectName = "IDRef";
            this.colIDRef.DisplayIndex = 9;
            this.colIDRef.IsVisible = false;
            this.colIDRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colIDRef.Width = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlInputPassCriteria);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1159, 450);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Tool Pass/Fail Criteria";
            // 
            // imageListValue
            // 
            this.imageListValue.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListValue.ImageStream")));
            this.imageListValue.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListValue.Images.SetKeyName(0, "true");
            this.imageListValue.Images.SetKeyName(1, "false");
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(77, 18);
            this.RTCName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(848, 22);
            this.RTCName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(125, 6);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 3;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Pass/Fail:";
            // 
            // ucResetToolActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ucResetToolActionDetail";
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.ScrollablePassFail.ResumeLayout(false);
            this.ScrollablePassFail.PerformLayout();
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlInputPassCriteria)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private BrightIdeasSoftware.TreeListView tlInputPassCriteria;
        private BrightIdeasSoftware.OLVColumn colRef;
        private BrightIdeasSoftware.OLVColumn colIDRef;
        private BrightIdeasSoftware.OLVColumn colActive;
        private BrightIdeasSoftware.OLVColumn colType;
        private BrightIdeasSoftware.OLVColumn colSetting;
        private BrightIdeasSoftware.OLVColumn colSettingValue;
        private System.Windows.Forms.ImageList imageListValue;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
    }
}
