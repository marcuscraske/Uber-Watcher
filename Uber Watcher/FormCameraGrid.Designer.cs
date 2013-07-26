namespace Uber_Watcher
{
    partial class FormCameraGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCameraGrid));
            this.cameraUpdater = new System.Windows.Forms.Timer(this.components);
            this.cameraCleaner = new System.Windows.Forms.Timer(this.components);
            this.cameraDeadTester = new System.Windows.Forms.Timer(this.components);
            this.vsbMain = new System.Windows.Forms.VScrollBar();
            this.bufferSwap = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cameraUpdater
            // 
            this.cameraUpdater.Enabled = true;
            this.cameraUpdater.Interval = 1000;
            this.cameraUpdater.Tick += new System.EventHandler(this.cameraUpdater_Tick);
            // 
            // cameraCleaner
            // 
            this.cameraCleaner.Enabled = true;
            this.cameraCleaner.Interval = 10000;
            this.cameraCleaner.Tick += new System.EventHandler(this.cameraCleaner_Tick);
            // 
            // cameraDeadTester
            // 
            this.cameraDeadTester.Enabled = true;
            this.cameraDeadTester.Interval = 60000;
            this.cameraDeadTester.Tick += new System.EventHandler(this.cameraDeadTester_Tick);
            // 
            // vsbMain
            // 
            this.vsbMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsbMain.Location = new System.Drawing.Point(943, 0);
            this.vsbMain.Name = "vsbMain";
            this.vsbMain.Size = new System.Drawing.Size(17, 594);
            this.vsbMain.TabIndex = 0;
            this.vsbMain.ValueChanged += new System.EventHandler(this.vsbMain_ValueChanged);
            // 
            // bufferSwap
            // 
            this.bufferSwap.Enabled = true;
            this.bufferSwap.Tick += new System.EventHandler(this.bufferSwap_Tick);
            // 
            // FormCameraGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 594);
            this.Controls.Add(this.vsbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCameraGrid";
            this.Text = "Über Watcher - Camera Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCameraGrid_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCameraGrid_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer cameraUpdater;
        public System.Windows.Forms.Timer cameraCleaner;
        public System.Windows.Forms.Timer cameraDeadTester;
        public System.Windows.Forms.VScrollBar vsbMain;
        private System.Windows.Forms.Timer bufferSwap;


    }
}

