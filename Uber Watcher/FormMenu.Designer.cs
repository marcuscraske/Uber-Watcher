namespace Uber_Watcher
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.buttCameraList = new System.Windows.Forms.Button();
            this.buttSettings = new System.Windows.Forms.Button();
            this.buttDebug = new System.Windows.Forms.Button();
            this.buttExit = new System.Windows.Forms.Button();
            this.buttAbout = new System.Windows.Forms.Button();
            this.buttDump = new System.Windows.Forms.Button();
            this.buttCameraMonitor = new System.Windows.Forms.Button();
            this.buttStopDumping = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttCameraList
            // 
            this.buttCameraList.Location = new System.Drawing.Point(137, 10);
            this.buttCameraList.Name = "buttCameraList";
            this.buttCameraList.Size = new System.Drawing.Size(119, 23);
            this.buttCameraList.TabIndex = 2;
            this.buttCameraList.Text = "Camera List";
            this.buttCameraList.UseVisualStyleBackColor = true;
            this.buttCameraList.Click += new System.EventHandler(this.buttCameraList_Click);
            // 
            // buttSettings
            // 
            this.buttSettings.Location = new System.Drawing.Point(262, 10);
            this.buttSettings.Name = "buttSettings";
            this.buttSettings.Size = new System.Drawing.Size(119, 23);
            this.buttSettings.TabIndex = 3;
            this.buttSettings.Text = "Settings";
            this.buttSettings.UseVisualStyleBackColor = true;
            this.buttSettings.Click += new System.EventHandler(this.buttSettings_Click);
            // 
            // buttDebug
            // 
            this.buttDebug.Location = new System.Drawing.Point(387, 10);
            this.buttDebug.Name = "buttDebug";
            this.buttDebug.Size = new System.Drawing.Size(119, 23);
            this.buttDebug.TabIndex = 4;
            this.buttDebug.Text = "Debug";
            this.buttDebug.UseVisualStyleBackColor = true;
            this.buttDebug.Click += new System.EventHandler(this.buttDebug_Click);
            // 
            // buttExit
            // 
            this.buttExit.Location = new System.Drawing.Point(887, 10);
            this.buttExit.Name = "buttExit";
            this.buttExit.Size = new System.Drawing.Size(119, 23);
            this.buttExit.TabIndex = 8;
            this.buttExit.Text = "Exit";
            this.buttExit.UseVisualStyleBackColor = true;
            this.buttExit.Click += new System.EventHandler(this.buttExit_Click);
            // 
            // buttAbout
            // 
            this.buttAbout.Location = new System.Drawing.Point(512, 10);
            this.buttAbout.Name = "buttAbout";
            this.buttAbout.Size = new System.Drawing.Size(119, 23);
            this.buttAbout.TabIndex = 5;
            this.buttAbout.Text = "About";
            this.buttAbout.UseVisualStyleBackColor = true;
            this.buttAbout.Click += new System.EventHandler(this.buttAbout_Click);
            // 
            // buttDump
            // 
            this.buttDump.Location = new System.Drawing.Point(637, 10);
            this.buttDump.Name = "buttDump";
            this.buttDump.Size = new System.Drawing.Size(119, 23);
            this.buttDump.TabIndex = 6;
            this.buttDump.Text = "Open Dump Directory";
            this.buttDump.UseVisualStyleBackColor = true;
            this.buttDump.Click += new System.EventHandler(this.buttDump_Click);
            // 
            // buttCameraMonitor
            // 
            this.buttCameraMonitor.Location = new System.Drawing.Point(12, 10);
            this.buttCameraMonitor.Name = "buttCameraMonitor";
            this.buttCameraMonitor.Size = new System.Drawing.Size(119, 23);
            this.buttCameraMonitor.TabIndex = 1;
            this.buttCameraMonitor.Text = "Camera Monitor";
            this.buttCameraMonitor.UseVisualStyleBackColor = true;
            this.buttCameraMonitor.Click += new System.EventHandler(this.buttCameraMonitor_Click);
            // 
            // buttStopDumping
            // 
            this.buttStopDumping.Location = new System.Drawing.Point(762, 10);
            this.buttStopDumping.Name = "buttStopDumping";
            this.buttStopDumping.Size = new System.Drawing.Size(119, 23);
            this.buttStopDumping.TabIndex = 7;
            this.buttStopDumping.Text = "Stop All Dumping";
            this.buttStopDumping.UseVisualStyleBackColor = true;
            this.buttStopDumping.Click += new System.EventHandler(this.buttStopDumping_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 42);
            this.Controls.Add(this.buttStopDumping);
            this.Controls.Add(this.buttCameraMonitor);
            this.Controls.Add(this.buttDump);
            this.Controls.Add(this.buttAbout);
            this.Controls.Add(this.buttExit);
            this.Controls.Add(this.buttDebug);
            this.Controls.Add(this.buttSettings);
            this.Controls.Add(this.buttCameraList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.Text = "Über Watcher - Menu - v";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenu_FormClosing);
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttCameraList;
        private System.Windows.Forms.Button buttSettings;
        private System.Windows.Forms.Button buttDebug;
        private System.Windows.Forms.Button buttExit;
        private System.Windows.Forms.Button buttAbout;
        private System.Windows.Forms.Button buttDump;
        private System.Windows.Forms.Button buttCameraMonitor;
        private System.Windows.Forms.Button buttStopDumping;
    }
}