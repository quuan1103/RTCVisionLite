
namespace RTC_Vision_Lite.UserControls
{
    partial class ucDialogMessageActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDialogMessageActionDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTCMessage = new System.Windows.Forms.TextBox();
            this.RTCPosition = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RTCIsShowDialogMode = new System.Windows.Forms.CheckBox();
            this.RTCIsAutoClose = new System.Windows.Forms.CheckBox();
            this.RTCAutoCloseWaitTime = new System.Windows.Forms.TextBox();
            this.RTCDialogCaption = new System.Windows.Forms.TextBox();
            this.RTCMessageBoxButtons = new System.Windows.Forms.ComboBox();
            this.RTCDialogType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RTCIsRunOneTime = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.RTCErrMessage = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.RTCYesButtonCaption = new System.Windows.Forms.TextBox();
            this.RTCNoButtonCaption = new System.Windows.Forms.TextBox();
            this.RTCCancelButtonCaption = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
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
            this.ScrollableGeneral.Controls.Add(this.label1);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCCancelButtonCaption);
            this.ScrollableROI.Controls.Add(this.RTCNoButtonCaption);
            this.ScrollableROI.Controls.Add(this.RTCYesButtonCaption);
            this.ScrollableROI.Controls.Add(this.label13);
            this.ScrollableROI.Controls.Add(this.label12);
            this.ScrollableROI.Controls.Add(this.label11);
            this.ScrollableROI.Controls.Add(this.label10);
            this.ScrollableROI.Controls.Add(this.RTCErrMessage);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.RTCIsRunOneTime);
            this.ScrollableROI.Controls.Add(this.groupBox1);
            this.ScrollableROI.Controls.Add(this.label3);
            this.ScrollableROI.Controls.Add(this.label2);
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
            this.RTCName.Size = new System.Drawing.Size(640, 22);
            this.RTCName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pass/Fail: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(82, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Passed";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTCMessage);
            this.groupBox1.Controls.Add(this.RTCPosition);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.RTCIsShowDialogMode);
            this.groupBox1.Controls.Add(this.RTCIsAutoClose);
            this.groupBox1.Controls.Add(this.RTCAutoCloseWaitTime);
            this.groupBox1.Controls.Add(this.RTCDialogCaption);
            this.groupBox1.Controls.Add(this.RTCMessageBoxButtons);
            this.groupBox1.Controls.Add(this.RTCDialogType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(20, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 254);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Setting";
            // 
            // RTCMessage
            // 
            this.RTCMessage.Location = new System.Drawing.Point(108, 87);
            this.RTCMessage.Multiline = true;
            this.RTCMessage.Name = "RTCMessage";
            this.RTCMessage.Size = new System.Drawing.Size(365, 74);
            this.RTCMessage.TabIndex = 7;
            // 
            // RTCPosition
            // 
            this.RTCPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCPosition.FormattingEnabled = true;
            this.RTCPosition.Location = new System.Drawing.Point(108, 197);
            this.RTCPosition.Name = "RTCPosition";
            this.RTCPosition.Size = new System.Drawing.Size(365, 21);
            this.RTCPosition.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Position";
            // 
            // RTCIsShowDialogMode
            // 
            this.RTCIsShowDialogMode.AutoSize = true;
            this.RTCIsShowDialogMode.Location = new System.Drawing.Point(108, 224);
            this.RTCIsShowDialogMode.Name = "RTCIsShowDialogMode";
            this.RTCIsShowDialogMode.Size = new System.Drawing.Size(136, 17);
            this.RTCIsShowDialogMode.TabIndex = 4;
            this.RTCIsShowDialogMode.Text = "Is Show Dialog Mode";
            this.RTCIsShowDialogMode.UseVisualStyleBackColor = true;
            // 
            // RTCIsAutoClose
            // 
            this.RTCIsAutoClose.AutoSize = true;
            this.RTCIsAutoClose.Location = new System.Drawing.Point(108, 170);
            this.RTCIsAutoClose.Name = "RTCIsAutoClose";
            this.RTCIsAutoClose.Size = new System.Drawing.Size(82, 17);
            this.RTCIsAutoClose.TabIndex = 4;
            this.RTCIsAutoClose.Text = "Auto Close";
            this.RTCIsAutoClose.UseVisualStyleBackColor = true;
            // 
            // RTCAutoCloseWaitTime
            // 
            this.RTCAutoCloseWaitTime.Location = new System.Drawing.Point(344, 167);
            this.RTCAutoCloseWaitTime.Name = "RTCAutoCloseWaitTime";
            this.RTCAutoCloseWaitTime.Size = new System.Drawing.Size(129, 22);
            this.RTCAutoCloseWaitTime.TabIndex = 2;
            // 
            // RTCDialogCaption
            // 
            this.RTCDialogCaption.Location = new System.Drawing.Point(108, 52);
            this.RTCDialogCaption.Name = "RTCDialogCaption";
            this.RTCDialogCaption.Size = new System.Drawing.Size(365, 22);
            this.RTCDialogCaption.TabIndex = 2;
            // 
            // RTCMessageBoxButtons
            // 
            this.RTCMessageBoxButtons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCMessageBoxButtons.FormattingEnabled = true;
            this.RTCMessageBoxButtons.Location = new System.Drawing.Point(320, 24);
            this.RTCMessageBoxButtons.Name = "RTCMessageBoxButtons";
            this.RTCMessageBoxButtons.Size = new System.Drawing.Size(153, 21);
            this.RTCMessageBoxButtons.TabIndex = 1;
            // 
            // RTCDialogType
            // 
            this.RTCDialogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCDialogType.FormattingEnabled = true;
            this.RTCDialogType.Location = new System.Drawing.Point(108, 24);
            this.RTCDialogType.Name = "RTCDialogType";
            this.RTCDialogType.Size = new System.Drawing.Size(153, 21);
            this.RTCDialogType.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Time Wait";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Message";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dialog Caption";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Buttons";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Dialog Type";
            // 
            // RTCIsRunOneTime
            // 
            this.RTCIsRunOneTime.AutoSize = true;
            this.RTCIsRunOneTime.Location = new System.Drawing.Point(18, 300);
            this.RTCIsRunOneTime.Name = "RTCIsRunOneTime";
            this.RTCIsRunOneTime.Size = new System.Drawing.Size(103, 17);
            this.RTCIsRunOneTime.TabIndex = 5;
            this.RTCIsRunOneTime.Text = "Send One Time";
            this.RTCIsRunOneTime.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(128, 296);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Send";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.Yellow;
            this.RTCErrMessage.Location = new System.Drawing.Point(232, 301);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 7;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Button Caption";
            // 
            // RTCYesButtonCaption
            // 
            this.RTCYesButtonCaption.Location = new System.Drawing.Point(129, 346);
            this.RTCYesButtonCaption.Name = "RTCYesButtonCaption";
            this.RTCYesButtonCaption.Size = new System.Drawing.Size(100, 22);
            this.RTCYesButtonCaption.TabIndex = 9;
            // 
            // RTCNoButtonCaption
            // 
            this.RTCNoButtonCaption.Location = new System.Drawing.Point(260, 346);
            this.RTCNoButtonCaption.Name = "RTCNoButtonCaption";
            this.RTCNoButtonCaption.Size = new System.Drawing.Size(100, 22);
            this.RTCNoButtonCaption.TabIndex = 9;
            // 
            // RTCCancelButtonCaption
            // 
            this.RTCCancelButtonCaption.Location = new System.Drawing.Point(393, 346);
            this.RTCCancelButtonCaption.Name = "RTCCancelButtonCaption";
            this.RTCCancelButtonCaption.Size = new System.Drawing.Size(100, 22);
            this.RTCCancelButtonCaption.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(157, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Yes (OK)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(300, 330);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "No";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(417, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Cancel";
            // 
            // ucDialogMessageActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucDialogMessageActionDetail";
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
        private System.Windows.Forms.TextBox RTCName;
        private System.Windows.Forms.TextBox RTCCancelButtonCaption;
        private System.Windows.Forms.TextBox RTCNoButtonCaption;
        private System.Windows.Forms.TextBox RTCYesButtonCaption;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox RTCIsRunOneTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox RTCPosition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox RTCIsShowDialogMode;
        private System.Windows.Forms.CheckBox RTCIsAutoClose;
        private System.Windows.Forms.TextBox RTCAutoCloseWaitTime;
        private System.Windows.Forms.TextBox RTCDialogCaption;
        private System.Windows.Forms.ComboBox RTCMessageBoxButtons;
        private System.Windows.Forms.ComboBox RTCDialogType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RTCMessage;
    }
}
