
namespace RTC_Vision_Lite.UserControls
{
    partial class ucBrightnessActionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBrightnessActionDetails));
            this.ucOrigin1 = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.ucImageLink1 = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucBrightnessRange = new RTC_Vision_Lite.UserControls.ucRangeMaxMin();
            this.RTCBrightness = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RTCInvert = new System.Windows.Forms.CheckBox();
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
            // PageActionSetting
            // 
            this.PageActionSetting.SelectedIndexChanged += new System.EventHandler(this.PageActionSetting_SelectedIndexChanged);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin1);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink1);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label1);
            this.ScrollableGeneral.Location = new System.Drawing.Point(2, 2);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableGeneral.Size = new System.Drawing.Size(861, 387);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(2, 61);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(4);
            this.PageSetup.Size = new System.Drawing.Size(888, 399);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(2);
            this.ROI.Padding = new System.Windows.Forms.Padding(2);
            this.ROI.Size = new System.Drawing.Size(865, 391);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(2);
            this.PassFail.Size = new System.Drawing.Size(865, 391);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollablePassFail.Size = new System.Drawing.Size(865, 391);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Location = new System.Drawing.Point(2, 2);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableROI.Size = new System.Drawing.Size(861, 387);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(888, 59);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(2);
            this.General.Padding = new System.Windows.Forms.Padding(2);
            this.General.Size = new System.Drawing.Size(865, 391);
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
            this.Method.Size = new System.Drawing.Size(865, 391);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(2);
            this.Display.Size = new System.Drawing.Size(865, 391);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(2, 2);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableMethod.Size = new System.Drawing.Size(861, 387);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(859, 385);
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
            this.ucOrigin1.Location = new System.Drawing.Point(23, 153);
            this.ucOrigin1.Margin = new System.Windows.Forms.Padding(2);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(676, 91);
            this.ucOrigin1.TabIndex = 11;
            // 
            // ucImageLink1
            // 
            this.ucImageLink1.Action = null;
            this.ucImageLink1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink1.Caption = "Image";
            this.ucImageLink1.Location = new System.Drawing.Point(23, 63);
            this.ucImageLink1.Margin = new System.Windows.Forms.Padding(2);
            this.ucImageLink1.Name = "ucImageLink1";
            this.ucImageLink1.PropertyName = "InputImage";
            this.ucImageLink1.Size = new System.Drawing.Size(676, 65);
            this.ucImageLink1.TabIndex = 10;
            // 
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(58, 15);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(641, 22);
            this.RTCName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
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
            this.RTCPassed.TabIndex = 5;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Pass/Fail:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucBrightnessRange);
            this.groupBox1.Controls.Add(this.RTCBrightness);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RTCInvert);
            this.groupBox1.Location = new System.Drawing.Point(20, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range Limits";
            // 
            // ucBrightnessRange
            // 
            this.ucBrightnessRange.AutoSize = true;
            this.ucBrightnessRange.Location = new System.Drawing.Point(19, 29);
            this.ucBrightnessRange.Name = "ucBrightnessRange";
            this.ucBrightnessRange.RTCAction = null;
            this.ucBrightnessRange.RTCActualPropertyName = null;
            this.ucBrightnessRange.RTCAllowInfinityMaxValue = true;
            this.ucBrightnessRange.RTCCheckboxCaption = "Caption";
            this.ucBrightnessRange.RTCCheckboxPropertyName = null;
            this.ucBrightnessRange.RTCCheckboxSize = 50;
            this.ucBrightnessRange.RTCChecked = false;
            this.ucBrightnessRange.RTCEditMask = "n2";
            this.ucBrightnessRange.RTCFeaturesLabel = "";
            this.ucBrightnessRange.RTCIsLimit = true;
            this.ucBrightnessRange.RTCMaxLabel = "Max";
            this.ucBrightnessRange.RTCMinLabel = "Min";
            this.ucBrightnessRange.RTCTextboxSize = 50;
            this.ucBrightnessRange.RTCUseActual = false;
            this.ucBrightnessRange.RTCUseActualLabel = false;
            this.ucBrightnessRange.RTCUseCheckbox = false;
            this.ucBrightnessRange.RTCUseFeatures = false;
            this.ucBrightnessRange.RTCUseMaskAsDisplayFormat = false;
            this.ucBrightnessRange.RTCUseMinMaxAtLine = true;
            this.ucBrightnessRange.RTCUseMinMaxAtTop = false;
            this.ucBrightnessRange.RTCValuePropertyName = "BrightnessRange";
            this.ucBrightnessRange.Size = new System.Drawing.Size(244, 30);
            this.ucBrightnessRange.TabIndex = 7;
            // 
            // RTCBrightness
            // 
            this.RTCBrightness.AutoSize = true;
            this.RTCBrightness.ForeColor = System.Drawing.Color.Green;
            this.RTCBrightness.Location = new System.Drawing.Point(361, 43);
            this.RTCBrightness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCBrightness.Name = "RTCBrightness";
            this.RTCBrightness.Size = new System.Drawing.Size(39, 13);
            this.RTCBrightness.TabIndex = 7;
            this.RTCBrightness.Text = "Actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Actual";
            // 
            // RTCInvert
            // 
            this.RTCInvert.AutoSize = true;
            this.RTCInvert.Location = new System.Drawing.Point(266, 42);
            this.RTCInvert.Name = "RTCInvert";
            this.RTCInvert.Size = new System.Drawing.Size(55, 17);
            this.RTCInvert.TabIndex = 1;
            this.RTCInvert.Text = "Invert";
            this.RTCInvert.UseVisualStyleBackColor = true;
            // 
            // ucBrightnessActionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucBrightnessActionDetails";
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

        private ucOrigin ucOrigin1;
        private ucImageLink ucImageLink1;
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label RTCBrightness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox RTCInvert;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
        private ucRangeMaxMin ucBrightnessRange;
    }
}
