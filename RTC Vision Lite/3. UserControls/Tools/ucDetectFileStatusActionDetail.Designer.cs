
namespace RTC_Vision_Lite.UserControls
{
    partial class ucDetectFileStatusActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDetectFileStatusActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.RTCErrMessage = new System.Windows.Forms.Label();
            this.ucLink1 = new RTC_Vision_Lite.UserControls.ucLink();
            this.RTCIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RTCIsDeleted = new System.Windows.Forms.CheckBox();
            this.RTCIsRenamed = new System.Windows.Forms.CheckBox();
            this.RTCIsChanged = new System.Windows.Forms.CheckBox();
            this.RTCIsCreated = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.RTCOutputFileName = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.Nam = new System.Windows.Forms.Label();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.Nam);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCOutputFileName);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.RTCIncludeSubdirectories);
            this.ScrollableROI.Controls.Add(this.ucLink1);
            this.ScrollableROI.Controls.Add(this.RTCErrMessage);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pass/Fail:";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 1;
            this.RTCPassed.Text = "Passed";
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.MidnightBlue;
            this.RTCErrMessage.Location = new System.Drawing.Point(146, 16);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 2;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // ucLink1
            // 
            this.ucLink1.Location = new System.Drawing.Point(14, 36);
            this.ucLink1.Name = "ucLink1";
            this.ucLink1.RTCAction = null;
            this.ucLink1.RTCCanEditValue = true;
            this.ucLink1.RTCCaption = "Folder Detect";
            this.ucLink1.RTCCaptionWidth = 96;
            this.ucLink1.RTCIsPreviewValue = true;
            this.ucLink1.RTCIsUseGetFolderButton = false;
            this.ucLink1.RTCPreviewValueWidth = 300;
            this.ucLink1.RTCPropertyName = "FolderName";
            this.ucLink1.Size = new System.Drawing.Size(570, 22);
            this.ucLink1.TabIndex = 3;
            // 
            // RTCIncludeSubdirectories
            // 
            this.RTCIncludeSubdirectories.AutoSize = true;
            this.RTCIncludeSubdirectories.Location = new System.Drawing.Point(113, 75);
            this.RTCIncludeSubdirectories.Name = "RTCIncludeSubdirectories";
            this.RTCIncludeSubdirectories.Size = new System.Drawing.Size(141, 17);
            this.RTCIncludeSubdirectories.TabIndex = 4;
            this.RTCIncludeSubdirectories.Text = "Include Subdirectories";
            this.RTCIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCFilter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RTCIsDeleted);
            this.groupBox1.Controls.Add(this.RTCIsRenamed);
            this.groupBox1.Controls.Add(this.RTCIsChanged);
            this.groupBox1.Controls.Add(this.RTCIsCreated);
            this.groupBox1.Location = new System.Drawing.Point(20, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 95);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detect Options";
            // 
            // RTCFilter
            // 
            this.RTCFilter.Location = new System.Drawing.Point(124, 53);
            this.RTCFilter.Name = "RTCFilter";
            this.RTCFilter.Size = new System.Drawing.Size(410, 22);
            this.RTCFilter.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Notify Filter";
            // 
            // RTCIsDeleted
            // 
            this.RTCIsDeleted.AutoSize = true;
            this.RTCIsDeleted.Location = new System.Drawing.Point(468, 26);
            this.RTCIsDeleted.Name = "RTCIsDeleted";
            this.RTCIsDeleted.Size = new System.Drawing.Size(66, 17);
            this.RTCIsDeleted.TabIndex = 4;
            this.RTCIsDeleted.Text = "Deleted";
            this.RTCIsDeleted.UseVisualStyleBackColor = true;
            // 
            // RTCIsRenamed
            // 
            this.RTCIsRenamed.AutoSize = true;
            this.RTCIsRenamed.Location = new System.Drawing.Point(360, 26);
            this.RTCIsRenamed.Name = "RTCIsRenamed";
            this.RTCIsRenamed.Size = new System.Drawing.Size(74, 17);
            this.RTCIsRenamed.TabIndex = 4;
            this.RTCIsRenamed.Text = "Renamed";
            this.RTCIsRenamed.UseVisualStyleBackColor = true;
            // 
            // RTCIsChanged
            // 
            this.RTCIsChanged.AutoSize = true;
            this.RTCIsChanged.Location = new System.Drawing.Point(238, 26);
            this.RTCIsChanged.Name = "RTCIsChanged";
            this.RTCIsChanged.Size = new System.Drawing.Size(73, 17);
            this.RTCIsChanged.TabIndex = 4;
            this.RTCIsChanged.Text = "Changed";
            this.RTCIsChanged.UseVisualStyleBackColor = true;
            // 
            // RTCIsCreated
            // 
            this.RTCIsCreated.AutoSize = true;
            this.RTCIsCreated.Location = new System.Drawing.Point(124, 26);
            this.RTCIsCreated.Name = "RTCIsCreated";
            this.RTCIsCreated.Size = new System.Drawing.Size(66, 17);
            this.RTCIsCreated.TabIndex = 4;
            this.RTCIsCreated.Text = "Created";
            this.RTCIsCreated.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(20, 208);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Start";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // RTCOutputFileName
            // 
            this.RTCOutputFileName.AutoSize = true;
            this.RTCOutputFileName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.RTCOutputFileName.Location = new System.Drawing.Point(101, 213);
            this.RTCOutputFileName.Name = "RTCOutputFileName";
            this.RTCOutputFileName.Size = new System.Drawing.Size(57, 13);
            this.RTCOutputFileName.TabIndex = 7;
            this.RTCOutputFileName.Text = "File Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(640, 22);
            this.RTCName.TabIndex = 4;
            // 
            // Nam
            // 
            this.Nam.AutoSize = true;
            this.Nam.Location = new System.Drawing.Point(20, 18);
            this.Nam.Name = "Nam";
            this.Nam.Size = new System.Drawing.Size(36, 13);
            this.Nam.TabIndex = 3;
            this.Nam.Text = "Name";
            // 
            // ucDetectFileStatusActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucDetectFileStatusActionDetail";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label RTCOutputFileName;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RTCFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RTCIsDeleted;
        private System.Windows.Forms.CheckBox RTCIsRenamed;
        private System.Windows.Forms.CheckBox RTCIsChanged;
        private System.Windows.Forms.CheckBox RTCIsCreated;
        private System.Windows.Forms.CheckBox RTCIncludeSubdirectories;
        private ucLink ucLink1;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label Nam;
    }
}
