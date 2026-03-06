namespace RTC_Vision_Lite.Forms
{
    partial class FrmASCIITable
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmASCIITable));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCustom = new System.Windows.Forms.TextBox();
            this.tlASCII = new RTC_Vision_Lite.UserControls.MyTreeList();
            this.H1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.A1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.H2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.A2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.H3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.A3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.H4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.A4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.H5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.A5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.H6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.A6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.H7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.A7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.H8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.A8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ucFooterForm = new RTC_Vision_Lite.UserControls.ucFooterForm();
            ((System.ComponentModel.ISupportInitialize)(this.tlASCII)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(327, 460);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 25);
            this.textBox1.TabIndex = 1;
            // 
            // txtCustom
            // 
            this.txtCustom.Location = new System.Drawing.Point(522, 460);
            this.txtCustom.Multiline = true;
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(169, 25);
            this.txtCustom.TabIndex = 2;
            // 
            // tlASCII
            // 
            this.tlASCII.AllColumns.Add(this.H1);
            this.tlASCII.AllColumns.Add(this.A1);
            this.tlASCII.AllColumns.Add(this.H2);
            this.tlASCII.AllColumns.Add(this.A2);
            this.tlASCII.AllColumns.Add(this.H3);
            this.tlASCII.AllColumns.Add(this.A3);
            this.tlASCII.AllColumns.Add(this.H4);
            this.tlASCII.AllColumns.Add(this.A4);
            this.tlASCII.AllColumns.Add(this.H5);
            this.tlASCII.AllColumns.Add(this.A5);
            this.tlASCII.AllColumns.Add(this.H6);
            this.tlASCII.AllColumns.Add(this.A6);
            this.tlASCII.AllColumns.Add(this.H7);
            this.tlASCII.AllColumns.Add(this.A7);
            this.tlASCII.AllColumns.Add(this.H8);
            this.tlASCII.AllColumns.Add(this.A8);
            this.tlASCII.CellEditUseWholeCell = false;
            this.tlASCII.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.H1,
            this.A1,
            this.H2,
            this.A2,
            this.H3,
            this.A3,
            this.H4,
            this.A4,
            this.H5,
            this.A5,
            this.H6,
            this.A6,
            this.H7,
            this.A7,
            this.H8,
            this.A8});
            this.tlASCII.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlASCII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlASCII.HideSelection = false;
            this.tlASCII.Location = new System.Drawing.Point(0, 0);
            this.tlASCII.LockCalc = false;
            this.tlASCII.Name = "tlASCII";
            this.tlASCII.OwnerDrawnHeader = true;
            this.tlASCII.ShowGroups = false;
            this.tlASCII.Size = new System.Drawing.Size(828, 454);
            this.tlASCII.TabIndex = 3;
            this.tlASCII.UseCompatibleStateImageBehavior = false;
            this.tlASCII.View = System.Windows.Forms.View.Details;
            this.tlASCII.VirtualMode = true;
            this.tlASCII.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.tlASCII_CellClick);
            // 
            // H1
            // 
            this.H1.AspectName = "Hex";
            this.H1.FillsFreeSpace = true;
            this.H1.Text = "Hex";
            this.H1.Width = 50;
            // 
            // A1
            // 
            this.A1.AspectName = "ASCII";
            this.A1.FillsFreeSpace = true;
            this.A1.Text = "ASCII";
            this.A1.Width = 50;
            // 
            // H2
            // 
            this.H2.AspectName = "Hex2";
            this.H2.FillsFreeSpace = true;
            this.H2.Text = "Hex";
            this.H2.Width = 50;
            // 
            // A2
            // 
            this.A2.AspectName = "ASCII2";
            this.A2.FillsFreeSpace = true;
            this.A2.Text = "ASCII";
            this.A2.Width = 50;
            // 
            // H3
            // 
            this.H3.AspectName = "Hex3";
            this.H3.FillsFreeSpace = true;
            this.H3.Text = "Hex";
            this.H3.Width = 50;
            // 
            // A3
            // 
            this.A3.AspectName = "ASCII3";
            this.A3.FillsFreeSpace = true;
            this.A3.Text = "ASCII";
            this.A3.Width = 50;
            // 
            // H4
            // 
            this.H4.AspectName = "Hex4";
            this.H4.FillsFreeSpace = true;
            this.H4.Text = "Hex";
            this.H4.Width = 50;
            // 
            // A4
            // 
            this.A4.AspectName = "ASCII4";
            this.A4.FillsFreeSpace = true;
            this.A4.Text = "ASCII";
            this.A4.Width = 50;
            // 
            // H5
            // 
            this.H5.AspectName = "Hex5";
            this.H5.FillsFreeSpace = true;
            this.H5.Text = "Hex";
            this.H5.Width = 50;
            // 
            // A5
            // 
            this.A5.AspectName = "ASCII5";
            this.A5.FillsFreeSpace = true;
            this.A5.Text = "ASCII";
            this.A5.Width = 50;
            // 
            // H6
            // 
            this.H6.AspectName = "Hex6";
            this.H6.FillsFreeSpace = true;
            this.H6.Text = "Hex";
            this.H6.Width = 50;
            // 
            // A6
            // 
            this.A6.AspectName = "ASCII6";
            this.A6.FillsFreeSpace = true;
            this.A6.Text = "ASCII";
            this.A6.Width = 50;
            // 
            // H7
            // 
            this.H7.AspectName = "Hex7";
            this.H7.FillsFreeSpace = true;
            this.H7.Text = "Hex";
            this.H7.Width = 50;
            // 
            // A7
            // 
            this.A7.AspectName = "ASCII7";
            this.A7.FillsFreeSpace = true;
            this.A7.Text = "ASCII";
            this.A7.Width = 50;
            // 
            // H8
            // 
            this.H8.AspectName = "Hex8";
            this.H8.FillsFreeSpace = true;
            this.H8.Text = "Hex";
            this.H8.Width = 50;
            // 
            // A8
            // 
            this.A8.AspectName = "ASCII8";
            this.A8.FillsFreeSpace = true;
            this.A8.Text = "ASCII";
            this.A8.Width = 50;
            // 
            // ucFooterForm
            // 
            this.ucFooterForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucFooterForm.Location = new System.Drawing.Point(0, 454);
            this.ucFooterForm.Name = "ucFooterForm";
            this.ucFooterForm.RTCbtnApplyEnabled = true;
            this.ucFooterForm.RTCbtnApplyVisible = false;
            this.ucFooterForm.RTCbtnCancelEnabled = true;
            this.ucFooterForm.RTCbtnCancelVisible = true;
            this.ucFooterForm.RTCbtnHelpEnabled = true;
            this.ucFooterForm.RTCbtnHelpVisible = true;
            this.ucFooterForm.RTCbtnOKEnabled = true;
            this.ucFooterForm.RTCbtnOKVisible = false;
            this.ucFooterForm.RTCbtnSaveEnabled = true;
            this.ucFooterForm.RTCbtnSaveVisible = false;
            this.ucFooterForm.Size = new System.Drawing.Size(828, 40);
            this.ucFooterForm.TabIndex = 0;
            // 
            // FrmASCIITable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 494);
            this.Controls.Add(this.tlASCII);
            this.Controls.Add(this.txtCustom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ucFooterForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmASCIITable";
            this.Text = "FrmASCIITable";
            this.Load += new System.EventHandler(this.FrmASCIITable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tlASCII)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ucFooterForm ucFooterForm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCustom;
        private UserControls.MyTreeList tlASCII;
        private BrightIdeasSoftware.OLVColumn H1;
        private BrightIdeasSoftware.OLVColumn A1;
        private BrightIdeasSoftware.OLVColumn H2;
        private BrightIdeasSoftware.OLVColumn A2;
        private BrightIdeasSoftware.OLVColumn H3;
        private BrightIdeasSoftware.OLVColumn A3;
        private BrightIdeasSoftware.OLVColumn H4;
        private BrightIdeasSoftware.OLVColumn A4;
        private BrightIdeasSoftware.OLVColumn H5;
        private BrightIdeasSoftware.OLVColumn A5;
        private BrightIdeasSoftware.OLVColumn H6;
        private BrightIdeasSoftware.OLVColumn A6;
        private BrightIdeasSoftware.OLVColumn H7;
        private BrightIdeasSoftware.OLVColumn A7;
        private BrightIdeasSoftware.OLVColumn H8;
        private BrightIdeasSoftware.OLVColumn A8;
    }
}