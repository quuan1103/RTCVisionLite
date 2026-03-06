
namespace RTC_Vision_Lite.UserControls
{
    partial class ucImageMathActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImageMathActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.ucRangeMaxMinLimit1 = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RTCOffsetValue = new System.Windows.Forms.TextBox();
            this.RTCScaleFactor = new System.Windows.Forms.TextBox();
            this.RTCImageOperation = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RTCNextPressed = new System.Windows.Forms.Button();
            this.RTCPreviousPressed = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.ucImageLink1 = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
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
            this.ScrollableGeneral.Controls.Add(this.ucImageLink1);
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
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label4);
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
            this.RTCName.Size = new System.Drawing.Size(639, 22);
            this.RTCName.TabIndex = 1;
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
            this.groupBox3.Controls.Add(this.RTCOffsetValue);
            this.groupBox3.Controls.Add(this.RTCScaleFactor);
            this.groupBox3.Controls.Add(this.RTCImageOperation);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.RTCNextPressed);
            this.groupBox3.Controls.Add(this.RTCPreviousPressed);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(17, 41);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(293, 186);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // RTCOffsetValue
            // 
            this.RTCOffsetValue.Location = new System.Drawing.Point(93, 132);
            this.RTCOffsetValue.Name = "RTCOffsetValue";
            this.RTCOffsetValue.Size = new System.Drawing.Size(185, 22);
            this.RTCOffsetValue.TabIndex = 12;
            // 
            // RTCScaleFactor
            // 
            this.RTCScaleFactor.Location = new System.Drawing.Point(93, 97);
            this.RTCScaleFactor.Name = "RTCScaleFactor";
            this.RTCScaleFactor.Size = new System.Drawing.Size(185, 22);
            this.RTCScaleFactor.TabIndex = 11;
            // 
            // RTCImageOperation
            // 
            this.RTCImageOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCImageOperation.FormattingEnabled = true;
            this.RTCImageOperation.Location = new System.Drawing.Point(93, 64);
            this.RTCImageOperation.Name = "RTCImageOperation";
            this.RTCImageOperation.Size = new System.Drawing.Size(185, 21);
            this.RTCImageOperation.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 135);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Offset Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Scale Factor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Math Type";
            // 
            // RTCNextPressed
            // 
            this.RTCNextPressed.Location = new System.Drawing.Point(203, 28);
            this.RTCNextPressed.Name = "RTCNextPressed";
            this.RTCNextPressed.Size = new System.Drawing.Size(75, 23);
            this.RTCNextPressed.TabIndex = 6;
            this.RTCNextPressed.Text = "Image2";
            this.RTCNextPressed.UseVisualStyleBackColor = true;
            // 
            // RTCPreviousPressed
            // 
            this.RTCPreviousPressed.Location = new System.Drawing.Point(93, 28);
            this.RTCPreviousPressed.Name = "RTCPreviousPressed";
            this.RTCPreviousPressed.Size = new System.Drawing.Size(75, 23);
            this.RTCPreviousPressed.TabIndex = 5;
            this.RTCPreviousPressed.Text = "Image1";
            this.RTCPreviousPressed.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Preview:";
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(22, 63);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(675, 65);
            this.ucImageLink.TabIndex = 2;
            // 
            // ucImageLink1
            // 
            this.ucImageLink1.Action = null;
            this.ucImageLink1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink1.Caption = "Image";
            this.ucImageLink1.Location = new System.Drawing.Point(22, 156);
            this.ucImageLink1.Name = "ucImageLink1";
            this.ucImageLink1.PropertyName = "InputGrayImage2";
            this.ucImageLink1.Size = new System.Drawing.Size(675, 65);
            this.ucImageLink1.TabIndex = 3;
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 3;
            this.RTCPassed.Text = "Passed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Pass/Fail:";
            // 
            // ucImageMathActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucImageMathActionDetail";
            this.PageActionSettingTabIndex = 1;
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
        private UserControls.ucRangeMaxMinLimit ucRangeMaxMinLimit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ucImageLink ucImageLink;
        private ucImageLink ucImageLink1;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RTCNextPressed;
        private System.Windows.Forms.Button RTCPreviousPressed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RTCOffsetValue;
        private System.Windows.Forms.TextBox RTCScaleFactor;
        private System.Windows.Forms.ComboBox RTCImageOperation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}
