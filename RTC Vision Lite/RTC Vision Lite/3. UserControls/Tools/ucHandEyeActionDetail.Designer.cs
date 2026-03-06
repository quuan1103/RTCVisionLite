
namespace RTC_Vision_Lite.UserControls
{
    partial class ucHandEyeActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHandEyeActionDetail));
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucImageLink = new RTC_Vision_Lite.UserControls.ucImageLink();
            this.ucOrigin1 = new RTC_Vision_Lite.UserControls.ucOrigin();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCHomMat_Image_To_World_Out = new System.Windows.Forms.TextBox();
            this.RTCHomMat_World_To_Image_Out = new System.Windows.Forms.TextBox();
            this.RTCListPointRobot = new System.Windows.Forms.TextBox();
            this.RTCListPointVision = new System.Windows.Forms.TextBox();
            this.RTCCameraType = new System.Windows.Forms.ComboBox();
            this.RTCUseRotatedPoints = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.PageActionSetting.Margin = new System.Windows.Forms.Padding(5);
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.ucOrigin1);
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.ucImageLink);
            this.ScrollableGeneral.Controls.Add(this.label2);
            this.ScrollableGeneral.Location = new System.Drawing.Point(4, 4);
            this.ScrollableGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableGeneral.Size = new System.Drawing.Size(853, 401);
            // 
            // PageSetup
            // 
            this.PageSetup.Location = new System.Drawing.Point(4, 41);
            this.PageSetup.Margin = new System.Windows.Forms.Padding(4);
            this.PageSetup.Size = new System.Drawing.Size(884, 417);
            // 
            // ROI
            // 
            this.ROI.Margin = new System.Windows.Forms.Padding(4);
            this.ROI.Padding = new System.Windows.Forms.Padding(4);
            this.ROI.Size = new System.Drawing.Size(861, 409);
            // 
            // PassFail
            // 
            this.PassFail.Margin = new System.Windows.Forms.Padding(4);
            this.PassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollablePassFail
            // 
            this.ScrollablePassFail.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollablePassFail.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.label6);
            this.ScrollableROI.Location = new System.Drawing.Point(4, 4);
            this.ScrollableROI.Margin = new System.Windows.Forms.Padding(4);
            this.ScrollableROI.Size = new System.Drawing.Size(853, 401);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(884, 37);
            // 
            // General
            // 
            this.General.Margin = new System.Windows.Forms.Padding(4);
            this.General.Padding = new System.Windows.Forms.Padding(4);
            this.General.Size = new System.Drawing.Size(861, 409);
            // 
            // TabSetUp
            // 
            this.TabSetUp.Margin = new System.Windows.Forms.Padding(4);
            this.TabSetUp.Padding = new System.Windows.Forms.Padding(4);
            // 
            // Method
            // 
            this.Method.Margin = new System.Windows.Forms.Padding(4);
            this.Method.Padding = new System.Windows.Forms.Padding(4);
            this.Method.Size = new System.Drawing.Size(861, 409);
            // 
            // Display
            // 
            this.Display.Margin = new System.Windows.Forms.Padding(4);
            this.Display.Size = new System.Drawing.Size(861, 409);
            // 
            // ScrollableMethod
            // 
            this.ScrollableMethod.Location = new System.Drawing.Point(4, 4);
            this.ScrollableMethod.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableMethod.Size = new System.Drawing.Size(853, 401);
            // 
            // ScrollableEndPointAndType
            // 
            this.ScrollableEndPointAndType.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollableEndPointAndType.Size = new System.Drawing.Size(855, 403);
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
            // RTCName
            // 
            this.RTCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTCName.Location = new System.Drawing.Point(68, 16);
            this.RTCName.Name = "RTCName";
            this.RTCName.Size = new System.Drawing.Size(629, 22);
            this.RTCName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name";
            // 
            // ucImageLink
            // 
            this.ucImageLink.Action = null;
            this.ucImageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucImageLink.Caption = "Image";
            this.ucImageLink.Location = new System.Drawing.Point(30, 77);
            this.ucImageLink.Margin = new System.Windows.Forms.Padding(4);
            this.ucImageLink.Name = "ucImageLink";
            this.ucImageLink.PropertyName = "InputImage";
            this.ucImageLink.Size = new System.Drawing.Size(667, 65);
            this.ucImageLink.TabIndex = 12;
            // 
            // ucOrigin1
            // 
            this.ucOrigin1.Action = null;
            this.ucOrigin1.Location = new System.Drawing.Point(30, 190);
            this.ucOrigin1.Name = "ucOrigin1";
            this.ucOrigin1.PropertyName = "ToolOrigin";
            this.ucOrigin1.Size = new System.Drawing.Size(667, 87);
            this.ucOrigin1.TabIndex = 13;
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(99, 19);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 5;
            this.RTCPassed.Text = "Passed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Pass/Fail:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCHomMat_Image_To_World_Out);
            this.groupBox1.Controls.Add(this.RTCHomMat_World_To_Image_Out);
            this.groupBox1.Controls.Add(this.RTCListPointRobot);
            this.groupBox1.Controls.Add(this.RTCListPointVision);
            this.groupBox1.Controls.Add(this.RTCCameraType);
            this.groupBox1.Controls.Add(this.RTCUseRotatedPoints);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 222);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // RTCHomMat_Image_To_World_Out
            // 
            this.RTCHomMat_Image_To_World_Out.Location = new System.Drawing.Point(210, 141);
            this.RTCHomMat_Image_To_World_Out.Name = "RTCHomMat_Image_To_World_Out";
            this.RTCHomMat_Image_To_World_Out.Size = new System.Drawing.Size(358, 22);
            this.RTCHomMat_Image_To_World_Out.TabIndex = 18;
            // 
            // RTCHomMat_World_To_Image_Out
            // 
            this.RTCHomMat_World_To_Image_Out.Location = new System.Drawing.Point(210, 174);
            this.RTCHomMat_World_To_Image_Out.Name = "RTCHomMat_World_To_Image_Out";
            this.RTCHomMat_World_To_Image_Out.Size = new System.Drawing.Size(358, 22);
            this.RTCHomMat_World_To_Image_Out.TabIndex = 17;
            // 
            // RTCListPointRobot
            // 
            this.RTCListPointRobot.Location = new System.Drawing.Point(210, 105);
            this.RTCListPointRobot.Name = "RTCListPointRobot";
            this.RTCListPointRobot.Size = new System.Drawing.Size(358, 22);
            this.RTCListPointRobot.TabIndex = 16;
            // 
            // RTCListPointVision
            // 
            this.RTCListPointVision.Location = new System.Drawing.Point(210, 74);
            this.RTCListPointVision.Name = "RTCListPointVision";
            this.RTCListPointVision.Size = new System.Drawing.Size(358, 22);
            this.RTCListPointVision.TabIndex = 15;
            // 
            // RTCCameraType
            // 
            this.RTCCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCCameraType.FormattingEnabled = true;
            this.RTCCameraType.Location = new System.Drawing.Point(210, 15);
            this.RTCCameraType.Name = "RTCCameraType";
            this.RTCCameraType.Size = new System.Drawing.Size(358, 21);
            this.RTCCameraType.TabIndex = 14;
            // 
            // RTCUseRotatedPoints
            // 
            this.RTCUseRotatedPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCUseRotatedPoints.FormattingEnabled = true;
            this.RTCUseRotatedPoints.Location = new System.Drawing.Point(210, 44);
            this.RTCUseRotatedPoints.Name = "RTCUseRotatedPoints";
            this.RTCUseRotatedPoints.Size = new System.Drawing.Size(358, 21);
            this.RTCUseRotatedPoints.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 177);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "HomMat World To Image";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Camera Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "HomMat Image To World";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "List Point Robot";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Use Rotated Points";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "List Point Vision";
            // 
            // ucHandEyeActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucHandEyeActionDetail";
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

        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.Label label2;
        private ucImageLink ucImageLink;
        private ucOrigin ucOrigin1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RTCHomMat_Image_To_World_Out;
        private System.Windows.Forms.TextBox RTCHomMat_World_To_Image_Out;
        private System.Windows.Forms.TextBox RTCListPointRobot;
        private System.Windows.Forms.TextBox RTCListPointVision;
        private System.Windows.Forms.ComboBox RTCCameraType;
        private System.Windows.Forms.ComboBox RTCUseRotatedPoints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label label6;
    }
}
