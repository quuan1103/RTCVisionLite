
namespace RTC_Vision_Lite.UserControls
{
    partial class ucPixelCountActionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPixelCountActionDetails));
            this.ucOrigin1 = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RTCPixelColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RTCThresholdRange = new RTC_Vision_Lite.UserControls.ucRangeMaxMinLimit();
            this.label3 = new System.Windows.Forms.Label();
            this.RTCThresholdMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCPixels = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PixelCountRange = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.PageActionSetting.SuspendLayout();
            this.ScrollableGeneral.SuspendLayout();
            this.PageSetup.SuspendLayout();
            this.ROI.SuspendLayout();
            this.PassFail.SuspendLayout();
            this.ScrollableROI.SuspendLayout();
            this.General.SuspendLayout();
            this.TabSetUp.SuspendLayout();
            this.Method.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin1);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(2, 2);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableGeneral.Size = new System.Drawing.Size(861, 409);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(2, 39);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(4);
            this.PageSetup.Size = new System.Drawing.Size(888, 421);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(2);
            this.ROI.Padding = new System.Windows.Forms.Padding(2);
            this.ROI.Size = new System.Drawing.Size(865, 413);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(2);
            this.PassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 413);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.groupBox2);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Location = new System.Drawing.Point(2, 2);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableROI.Size = new System.Drawing.Size(861, 409);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(888, 37);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(2);
            this.General.Padding = new System.Windows.Forms.Padding(2);
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
            // ucOrigin1
            // 
            this.ucOrigin1.Action = null;
            this.ucOrigin1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrigin1.Location = new System.Drawing.Point(20, 146);
            this.ucOrigin1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(679, 100);
            this.ucOrigin1.TabIndex = 7;
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(20, 54);
            this.ucImageLink.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(679, 65);
            this.ucImageLink.TabIndex = 6;
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(641, 22);
            this.RTCName.TabIndex = 5;
            this.RTCName.Text = "Pixel Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 7;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pass/Fail:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RTCPixelColor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.RTCThresholdRange);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RTCThresholdMode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(19, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 176);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // RTCPixelColor
            // 
            this.RTCPixelColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCPixelColor.FormattingEnabled = true;
            this.RTCPixelColor.Location = new System.Drawing.Point(144, 138);
            this.RTCPixelColor.Name = "RTCPixelColor";
            this.RTCPixelColor.Size = new System.Drawing.Size(299, 21);
            this.RTCPixelColor.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Pixel Color:";
            // 
            // RTCThresholdRange
            // 
            this.RTCThresholdRange.Location = new System.Drawing.Point(144, 52);
            this.RTCThresholdRange.Margin = new System.Windows.Forms.Padding(2);
            this.RTCThresholdRange.Name = "RTCThresholdRange";
            this.RTCThresholdRange.RTCAction = null;
            this.RTCThresholdRange.RTCBeginValue = 0D;
            this.RTCThresholdRange.RTCEndValue = 25D;
            this.RTCThresholdRange.RTCMax = 100D;
            this.RTCThresholdRange.RTCMin = 0D;
            this.RTCThresholdRange.RTCPropertyName = "ThresholdRange";
            this.RTCThresholdRange.RTCStepChange = 0.1D;
            this.RTCThresholdRange.RTCValuePropertyName = null;
            this.RTCThresholdRange.Size = new System.Drawing.Size(299, 76);
            this.RTCThresholdRange.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Threshold Range:";
            // 
            // RTCThresholdMode
            // 
            this.RTCThresholdMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCThresholdMode.FormattingEnabled = true;
            this.RTCThresholdMode.Location = new System.Drawing.Point(144, 18);
            this.RTCThresholdMode.Name = "RTCThresholdMode";
            this.RTCThresholdMode.Size = new System.Drawing.Size(299, 21);
            this.RTCThresholdMode.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Threshold Mode:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCPixels);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PixelCountRange);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Location = new System.Drawing.Point(19, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 93);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // RTCPixels
            // 
            this.RTCPixels.AutoSize = true;
            this.RTCPixels.ForeColor = System.Drawing.Color.LightGreen;
            this.RTCPixels.Location = new System.Drawing.Point(187, 55);
            this.RTCPixels.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPixels.Name = "RTCPixels";
            this.RTCPixels.Size = new System.Drawing.Size(64, 13);
            this.RTCPixels.TabIndex = 18;
            this.RTCPixels.Text = "Pixel Color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Actual:";
            // 
            // PixelCountRange
            // 
            this.PixelCountRange.AutoSize = true;
            this.PixelCountRange.Location = new System.Drawing.Point(126, 21);
            this.PixelCountRange.Name = "PixelCountRange";
            this.PixelCountRange.RTCAction = null;
            this.PixelCountRange.RTCActualPropertyName = null;
            this.PixelCountRange.RTCAllowInfinityMaxValue = true;
            this.PixelCountRange.RTCCheckboxCaption = "Invert";
            this.PixelCountRange.RTCCheckboxPropertyName = null;
            this.PixelCountRange.RTCCheckboxSize = 100;
            this.PixelCountRange.RTCChecked = false;
            this.PixelCountRange.RTCEditMask = "n2";
            this.PixelCountRange.RTCFeaturesLabel = "";
            this.PixelCountRange.RTCIsLimit = false;
            this.PixelCountRange.RTCMaxLabel = "Max";
            this.PixelCountRange.RTCMinLabel = "Min";
            this.PixelCountRange.RTCTextboxSize = 50;
            this.PixelCountRange.RTCUseActual = false;
            this.PixelCountRange.RTCUseActualLabel = false;
            this.PixelCountRange.RTCUseCheckbox = false;
            this.PixelCountRange.RTCUseFeatures = false;
            this.PixelCountRange.RTCUseMaskAsDisplayFormat = false;
            this.PixelCountRange.RTCUseMinMaxAtLine = true;
            this.PixelCountRange.RTCUseMinMaxAtTop = false;
            this.PixelCountRange.RTCValuePropertyName = "PixelCountRange";
            this.PixelCountRange.Size = new System.Drawing.Size(317, 30);
            this.PixelCountRange.TabIndex = 13;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(9, 29);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Invert";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // ucPixelCountActionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucPixelCountActionDetails";
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucOrigin ucOrigin1;
        private ucImageLink ucImageLink;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ucRangeMaxMinLimit RTCThresholdRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RTCThresholdMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label RTCPixels;
        private System.Windows.Forms.Label label5;
        private ucRangeMaxMin PixelCountRange;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox RTCPixelColor;
        private System.Windows.Forms.Label label4;
    }
}
