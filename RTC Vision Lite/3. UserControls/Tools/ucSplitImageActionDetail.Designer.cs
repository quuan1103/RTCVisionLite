
namespace RTC_Vision_Lite.UserControls
{
    partial class ucSplitImageActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSplitImageActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.ucRangeMaxMinLimit1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.RTCColumnNumber = new System.Windows.Forms.TextBox();
            this.ucLinkFolder = new RTC_Vision_Lite.UserControls.ucLink();
            this.label5 = new System.Windows.Forms.Label();
            this.RTCSaveMode = new System.Windows.Forms.ComboBox();
            this.RTCRowNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RTCAdaptImageSize = new System.Windows.Forms.CheckBox();
            this.RTCShapeListROIType = new System.Windows.Forms.ComboBox();
            this.RTCSplitType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.ucOrigin = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollablePassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageActionSetting
            // 
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(4, 4);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(4);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(2, 39);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(4);
            this.PageSetup.Size = new System.Drawing.Size(888, 421);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(4);
            this.ROI.Padding = new System.Windows.Forms.Padding(4);
            this.ROI.Size = new System.Drawing.Size(865, 413);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(4);
            this.PassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Controls.Add(this.RTCPassed);
            this.ScrollablePassFail.Controls.Add(this.label6);
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.label7);
            this.ScrollableROI.Controls.Add(this.label9);
            this.ScrollableROI.Controls.Add(this.groupBox3);
            this.ScrollableROI.Location = new System.Drawing.Point(4, 4);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(2);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(888, 37);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(4);
            this.General.Padding = new System.Windows.Forms.Padding(4);
            this.General.Size = new System.Drawing.Size(865, 413);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(2);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(2);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(2);
            this.Method.Padding = new System.Windows.Forms.Padding(2);
            this.Method.Size = new System.Drawing.Size(865, 413);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(2);
            this.Display.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(2, 2);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableMethod.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(859, 407);
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
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(625, 22);
            this.RTCName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pass/Fail:";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(64, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 1;
            this.RTCPassed.Text = "Passed";
            // 
            // ucRangeMaxMinLimit1
            // 
            this.ucRangeMaxMinLimit1.Location = new System.Drawing.Point(6, 16);
            this.ucRangeMaxMinLimit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucRangeMaxMinLimit1.Name = "ucRangeMaxMinLimit1";
            this.ucRangeMaxMinLimit1.RTCAction = null;
            this.ucRangeMaxMinLimit1.RTCBeginValue = 0D;
            this.ucRangeMaxMinLimit1.RTCEndValue = 25D;
            this.ucRangeMaxMinLimit1.RTCMax = 100D;
            this.ucRangeMaxMinLimit1.RTCMin = 0D;
            this.ucRangeMaxMinLimit1.RTCPropertyName = null;
            this.ucRangeMaxMinLimit1.RTCStepChange = 0.1D;
            this.ucRangeMaxMinLimit1.RTCValuePropertyName = null;
            this.ucRangeMaxMinLimit1.Size = new System.Drawing.Size(244, 95);
            this.ucRangeMaxMinLimit1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.RTCColumnNumber);
            this.groupBox3.Controls.Add(this.ucLinkFolder);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.RTCSaveMode);
            this.groupBox3.Controls.Add(this.RTCRowNumber);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.RTCAdaptImageSize);
            this.groupBox3.Controls.Add(this.RTCShapeListROIType);
            this.groupBox3.Controls.Add(this.RTCSplitType);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(27, 37);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(809, 130);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(265, 50);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Column";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Row";
            // 
            // RTCColumnNumber
            // 
            this.RTCColumnNumber.Location = new System.Drawing.Point(318, 47);
            this.RTCColumnNumber.Margin = new System.Windows.Forms.Padding(2);
            this.RTCColumnNumber.Name = "RTCColumnNumber";
            this.RTCColumnNumber.Size = new System.Drawing.Size(103, 22);
            this.RTCColumnNumber.TabIndex = 11;
            // 
            // ucLinkFolder
            // 
            this.ucLinkFolder.Location = new System.Drawing.Point(6, 99);
            this.ucLinkFolder.Margin = new System.Windows.Forms.Padding(4);
            this.ucLinkFolder.Name = "ucLinkFolder";
            this.ucLinkFolder.RTCAction = null;
            this.ucLinkFolder.RTCCanEditValue = false;
            this.ucLinkFolder.RTCCaption = "Save Folder";
            this.ucLinkFolder.RTCCaptionWidth = 82;
            this.ucLinkFolder.RTCIsPreviewValue = true;
            this.ucLinkFolder.RTCIsUseGetFolderButton = true;
            this.ucLinkFolder.RTCPreviewValueWidth = 200;
            this.ucLinkFolder.RTCPropertyName = "FolderName";
            this.ucLinkFolder.Size = new System.Drawing.Size(628, 22);
            this.ucLinkFolder.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Split Mode";
            // 
            // RTCSaveMode
            // 
            this.RTCSaveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSaveMode.FormattingEnabled = true;
            this.RTCSaveMode.Location = new System.Drawing.Point(92, 73);
            this.RTCSaveMode.Margin = new System.Windows.Forms.Padding(2);
            this.RTCSaveMode.Name = "RTCSaveMode";
            this.RTCSaveMode.Size = new System.Drawing.Size(161, 21);
            this.RTCSaveMode.TabIndex = 8;
            // 
            // RTCRowNumber
            // 
            this.RTCRowNumber.Location = new System.Drawing.Point(318, 19);
            this.RTCRowNumber.Margin = new System.Windows.Forms.Padding(2);
            this.RTCRowNumber.Name = "RTCRowNumber";
            this.RTCRowNumber.Size = new System.Drawing.Size(103, 22);
            this.RTCRowNumber.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "ROI Type";
            // 
            // RTCAdaptImageSize
            // 
            this.RTCAdaptImageSize.AutoSize = true;
            this.RTCAdaptImageSize.Location = new System.Drawing.Point(268, 75);
            this.RTCAdaptImageSize.Margin = new System.Windows.Forms.Padding(2);
            this.RTCAdaptImageSize.Name = "RTCAdaptImageSize";
            this.RTCAdaptImageSize.Size = new System.Drawing.Size(114, 17);
            this.RTCAdaptImageSize.TabIndex = 3;
            this.RTCAdaptImageSize.Text = "Adapt Image Size";
            this.RTCAdaptImageSize.UseVisualStyleBackColor = true;
            // 
            // RTCShapeListROIType
            // 
            this.RTCShapeListROIType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCShapeListROIType.FormattingEnabled = true;
            this.RTCShapeListROIType.Items.AddRange(new object[] {
            "Fixed Threshold Range"});
            this.RTCShapeListROIType.Location = new System.Drawing.Point(92, 46);
            this.RTCShapeListROIType.Margin = new System.Windows.Forms.Padding(2);
            this.RTCShapeListROIType.Name = "RTCShapeListROIType";
            this.RTCShapeListROIType.Size = new System.Drawing.Size(161, 21);
            this.RTCShapeListROIType.TabIndex = 6;
            // 
            // RTCSplitType
            // 
            this.RTCSplitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCSplitType.FormattingEnabled = true;
            this.RTCSplitType.Location = new System.Drawing.Point(92, 19);
            this.RTCSplitType.Margin = new System.Windows.Forms.Padding(2);
            this.RTCSplitType.Name = "RTCSplitType";
            this.RTCSplitType.Size = new System.Drawing.Size(161, 21);
            this.RTCSplitType.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "SplitType";
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(12, 43);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(671, 75);
            this.ucImageLink.TabIndex = 2;
            // 
            // ucOrigin
            // 
            this.ucOrigin.Action = null;
            this.ucOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin.Location = new System.Drawing.Point(12, 122);
            this.ucOrigin.Margin = new System.Windows.Forms.Padding(2);
            this.ucOrigin.Name = "ucOrigin";
            this.ucOrigin.PropertyName = "ToolOrigin";
            this.ucOrigin.Size = new System.Drawing.Size(671, 79);
            this.ucOrigin.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(80, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Passed";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Pass/Fail:";
            // 
            // ucSplitImageActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucSplitImageActionDetail";
            this.PageActionSetting.ResumeLayout(false);
            this.ScrollableGeneral.ResumeLayout(false);
            this.ScrollableGeneral.PerformLayout();
            this.PageSetup.ResumeLayout(false);
            this.ROI.ResumeLayout(false);
            this.PassFail.ResumeLayout(false);
            this.ScrollablePassFail.ResumeLayout(false);
            this.ScrollablePassFail.PerformLayout();
            this.ScrollableROI.ResumeLayout(false);
            this.ScrollableROI.PerformLayout();
            this.General.ResumeLayout(false);
            this.TabSetUp.ResumeLayout(false);
            this.Method.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private UserControls.ucRangeMaxMinLimit ucRangeMaxMinLimit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox RTCSplitType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RTCShapeListROIType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RTCAdaptImageSize;
        private System.Windows.Forms.ComboBox RTCSaveMode;
        private System.Windows.Forms.TextBox RTCRowNumber;
        private ucOrigin ucOrigin;
        private ucImageLink ucImageLink;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private ucLink ucLinkFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox RTCColumnNumber;
    }
}
