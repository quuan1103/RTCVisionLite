
namespace RTC_Vision_Lite.UserControls
{
    partial class ucMXComponentWriteActionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMXComponentWriteActionDetail));
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RTCWaitMode = new System.Windows.Forms.ComboBox();
            this.RTCIsCompareValue = new System.Windows.Forms.CheckBox();
            this.RTCValueAfterStop = new System.Windows.Forms.TextBox();
            this.RTCValueAfterDelay = new System.Windows.Forms.TextBox();
            this.RTCCompareValue = new System.Windows.Forms.TextBox();
            this.RTCValue = new System.Windows.Forms.TextBox();
            this.RTCAddress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.RTCTimeDelay = new System.Windows.Forms.NumericUpDown();
            this.RTCLogicalStationNumber = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.RTCIsAliveControl = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RTCIsRunOneTime = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.RTCPassed = new System.Windows.Forms.Label();
            this.RTCErrMessage = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.RTCName = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.RTCTimeDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCLogicalStationNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // ScrollableGeneral
            // 
            this.ScrollableGeneral.Controls.Add(this.RTCName);
            this.ScrollableGeneral.Controls.Add(this.label20);
            // 
            // ScrollableROI
            // 
            this.ScrollableROI.Controls.Add(this.RTCErrMessage);
            this.ScrollableROI.Controls.Add(this.RTCPassed);
            this.ScrollableROI.Controls.Add(this.btnTest);
            this.ScrollableROI.Controls.Add(this.RTCIsRunOneTime);
            this.ScrollableROI.Controls.Add(this.RTCIsAliveControl);
            this.ScrollableROI.Controls.Add(this.groupBox3);
            this.ScrollableROI.Controls.Add(this.label12);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Pass/Fail:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RTCWaitMode);
            this.groupBox3.Controls.Add(this.RTCIsCompareValue);
            this.groupBox3.Controls.Add(this.RTCValueAfterStop);
            this.groupBox3.Controls.Add(this.RTCValueAfterDelay);
            this.groupBox3.Controls.Add(this.RTCCompareValue);
            this.groupBox3.Controls.Add(this.RTCValue);
            this.groupBox3.Controls.Add(this.RTCAddress);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.RTCTimeDelay);
            this.groupBox3.Controls.Add(this.RTCLogicalStationNumber);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(20, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(411, 202);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Setting";
            // 
            // RTCWaitMode
            // 
            this.RTCWaitMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RTCWaitMode.FormattingEnabled = true;
            this.RTCWaitMode.Location = new System.Drawing.Point(261, 135);
            this.RTCWaitMode.Name = "RTCWaitMode";
            this.RTCWaitMode.Size = new System.Drawing.Size(124, 21);
            this.RTCWaitMode.TabIndex = 33;
            // 
            // RTCIsCompareValue
            // 
            this.RTCIsCompareValue.AutoSize = true;
            this.RTCIsCompareValue.Location = new System.Drawing.Point(10, 103);
            this.RTCIsCompareValue.Name = "RTCIsCompareValue";
            this.RTCIsCompareValue.Size = new System.Drawing.Size(103, 17);
            this.RTCIsCompareValue.TabIndex = 32;
            this.RTCIsCompareValue.Text = "Compare Value";
            this.RTCIsCompareValue.UseVisualStyleBackColor = true;
            // 
            // RTCValueAfterStop
            // 
            this.RTCValueAfterStop.Location = new System.Drawing.Point(261, 166);
            this.RTCValueAfterStop.Name = "RTCValueAfterStop";
            this.RTCValueAfterStop.Size = new System.Drawing.Size(124, 22);
            this.RTCValueAfterStop.TabIndex = 3;
            // 
            // RTCValueAfterDelay
            // 
            this.RTCValueAfterDelay.Location = new System.Drawing.Point(140, 166);
            this.RTCValueAfterDelay.Name = "RTCValueAfterDelay";
            this.RTCValueAfterDelay.Size = new System.Drawing.Size(85, 22);
            this.RTCValueAfterDelay.TabIndex = 3;
            // 
            // RTCCompareValue
            // 
            this.RTCCompareValue.Location = new System.Drawing.Point(140, 101);
            this.RTCCompareValue.Name = "RTCCompareValue";
            this.RTCCompareValue.Size = new System.Drawing.Size(245, 22);
            this.RTCCompareValue.TabIndex = 3;
            // 
            // RTCValue
            // 
            this.RTCValue.Location = new System.Drawing.Point(140, 71);
            this.RTCValue.Name = "RTCValue";
            this.RTCValue.Size = new System.Drawing.Size(245, 22);
            this.RTCValue.TabIndex = 3;
            // 
            // RTCAddress
            // 
            this.RTCAddress.Location = new System.Drawing.Point(140, 43);
            this.RTCAddress.Name = "RTCAddress";
            this.RTCAddress.Size = new System.Drawing.Size(245, 22);
            this.RTCAddress.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(228, 169);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Stop";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(228, 138);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "ms";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 169);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Value After: Delay";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 138);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Time Delay";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Value";
            // 
            // RTCTimeDelay
            // 
            this.RTCTimeDelay.Location = new System.Drawing.Point(140, 136);
            this.RTCTimeDelay.Name = "RTCTimeDelay";
            this.RTCTimeDelay.Size = new System.Drawing.Size(85, 22);
            this.RTCTimeDelay.TabIndex = 2;
            // 
            // RTCLogicalStationNumber
            // 
            this.RTCLogicalStationNumber.Location = new System.Drawing.Point(140, 15);
            this.RTCLogicalStationNumber.Name = "RTCLogicalStationNumber";
            this.RTCLogicalStationNumber.Size = new System.Drawing.Size(85, 22);
            this.RTCLogicalStationNumber.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Address";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Logical Station Number";
            // 
            // RTCIsAliveControl
            // 
            this.RTCIsAliveControl.AutoSize = true;
            this.RTCIsAliveControl.Location = new System.Drawing.Point(20, 37);
            this.RTCIsAliveControl.Name = "RTCIsAliveControl";
            this.RTCIsAliveControl.Size = new System.Drawing.Size(103, 17);
            this.RTCIsAliveControl.TabIndex = 32;
            this.RTCIsAliveControl.Text = "Is Alive Control";
            this.RTCIsAliveControl.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // RTCIsRunOneTime
            // 
            this.RTCIsRunOneTime.AutoSize = true;
            this.RTCIsRunOneTime.Location = new System.Drawing.Point(19, 272);
            this.RTCIsRunOneTime.Name = "RTCIsRunOneTime";
            this.RTCIsRunOneTime.Size = new System.Drawing.Size(106, 17);
            this.RTCIsRunOneTime.TabIndex = 32;
            this.RTCIsRunOneTime.Text = "Write One Time";
            this.RTCIsRunOneTime.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(146, 268);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(71, 23);
            this.btnTest.TabIndex = 33;
            this.btnTest.Text = "Write";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // RTCPassed
            // 
            this.RTCPassed.AutoSize = true;
            this.RTCPassed.ForeColor = System.Drawing.Color.Green;
            this.RTCPassed.Location = new System.Drawing.Point(82, 16);
            this.RTCPassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCPassed.Name = "RTCPassed";
            this.RTCPassed.Size = new System.Drawing.Size(42, 13);
            this.RTCPassed.TabIndex = 34;
            this.RTCPassed.Text = "Passed";
            // 
            // RTCErrMessage
            // 
            this.RTCErrMessage.AutoSize = true;
            this.RTCErrMessage.ForeColor = System.Drawing.Color.IndianRed;
            this.RTCErrMessage.Location = new System.Drawing.Point(232, 273);
            this.RTCErrMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RTCErrMessage.Name = "RTCErrMessage";
            this.RTCErrMessage.Size = new System.Drawing.Size(66, 13);
            this.RTCErrMessage.TabIndex = 35;
            this.RTCErrMessage.Text = "ErrMessage";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Name";
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
            // ucMXComponentWriteActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ucMXComponentWriteActionDetail";
            this.Controls.SetChildIndex(this.PageActionSetting, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.RTCTimeDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTCLogicalStationNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RTCPortNumber;
        private System.Windows.Forms.TextBox RTCIPAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox RTCBitMode;
        private System.Windows.Forms.ComboBox RTCValueTypes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox RTCIsAliveControl;
        private System.Windows.Forms.TextBox RTCValue;
        private System.Windows.Forms.TextBox RTCAddress;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown RTCLogicalStationNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox RTCIsCompareValue;
        private System.Windows.Forms.TextBox RTCCompareValue;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox RTCWaitMode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown RTCTimeDelay;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox RTCIsRunOneTime;
        private System.Windows.Forms.TextBox RTCValueAfterStop;
        private System.Windows.Forms.TextBox RTCValueAfterDelay;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label RTCPassed;
        private System.Windows.Forms.Label RTCErrMessage;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox RTCName;
    }
}
