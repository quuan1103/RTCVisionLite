namespace GraphiscWindow
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.graphicsWindow1 = new GraphicsWindow.GraphicsWindow();
            ((System.ComponentModel.ISupportInitialize)(this.graphicsWindow1)).BeginInit();
            this.SuspendLayout();
            // 
            // graphicsWindow1
            // 
            this.graphicsWindow1.BackColor = System.Drawing.Color.Black;
            this.graphicsWindow1.FitImage = false;
            this.graphicsWindow1.GetXY = ((System.Drawing.PointF)(resources.GetObject("graphicsWindow1.GetXY")));
            this.graphicsWindow1.KeySelect = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.graphicsWindow1.Location = new System.Drawing.Point(0, 0);
            this.graphicsWindow1.LockRoi = false;
            this.graphicsWindow1.MoveImage = false;
            this.graphicsWindow1.Name = "graphicsWindow1";
            this.graphicsWindow1.Size = new System.Drawing.Size(100, 50);
            this.graphicsWindow1.TabIndex = 0;
            this.graphicsWindow1.TabStop = false;
            this.graphicsWindow1.ZoomClick = false;
            this.graphicsWindow1.ZoomIN = false;
            this.graphicsWindow1.ZoomMouseWheel = false;
            this.graphicsWindow1.ZoomOut = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.graphicsWindow1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graphicsWindow1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GraphicsWindow.GraphicsWindow graphicsWindow1;
    }
}

