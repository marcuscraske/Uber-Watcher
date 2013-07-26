namespace Uber_Watcher
{
    partial class FormDebug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDebug));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbCamerasDead = new System.Windows.Forms.Label();
            this.lbCamerasActive = new System.Windows.Forms.Label();
            this.lbTotalImages = new System.Windows.Forms.Label();
            this.lbCamerasDeadLabel = new System.Windows.Forms.Label();
            this.lbCamerasActiveLabel = new System.Windows.Forms.Label();
            this.lbTotalImagesLabel = new System.Windows.Forms.Label();
            this.lbDataUsage = new System.Windows.Forms.Label();
            this.lbDataUsageLabel = new System.Windows.Forms.Label();
            this.lbDebugMessages = new System.Windows.Forms.ListBox();
            this.updater = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbCamerasDead);
            this.splitContainer1.Panel1.Controls.Add(this.lbCamerasActive);
            this.splitContainer1.Panel1.Controls.Add(this.lbTotalImages);
            this.splitContainer1.Panel1.Controls.Add(this.lbCamerasDeadLabel);
            this.splitContainer1.Panel1.Controls.Add(this.lbCamerasActiveLabel);
            this.splitContainer1.Panel1.Controls.Add(this.lbTotalImagesLabel);
            this.splitContainer1.Panel1.Controls.Add(this.lbDataUsage);
            this.splitContainer1.Panel1.Controls.Add(this.lbDataUsageLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbDebugMessages);
            this.splitContainer1.Size = new System.Drawing.Size(527, 207);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbCamerasDead
            // 
            this.lbCamerasDead.AutoSize = true;
            this.lbCamerasDead.Location = new System.Drawing.Point(363, 30);
            this.lbCamerasDead.Name = "lbCamerasDead";
            this.lbCamerasDead.Size = new System.Drawing.Size(13, 13);
            this.lbCamerasDead.TabIndex = 7;
            this.lbCamerasDead.Text = "0";
            // 
            // lbCamerasActive
            // 
            this.lbCamerasActive.AutoSize = true;
            this.lbCamerasActive.Location = new System.Drawing.Point(363, 7);
            this.lbCamerasActive.Name = "lbCamerasActive";
            this.lbCamerasActive.Size = new System.Drawing.Size(13, 13);
            this.lbCamerasActive.TabIndex = 6;
            this.lbCamerasActive.Text = "0";
            // 
            // lbTotalImages
            // 
            this.lbTotalImages.AutoSize = true;
            this.lbTotalImages.Location = new System.Drawing.Point(160, 30);
            this.lbTotalImages.Name = "lbTotalImages";
            this.lbTotalImages.Size = new System.Drawing.Size(13, 13);
            this.lbTotalImages.TabIndex = 5;
            this.lbTotalImages.Text = "0";
            // 
            // lbCamerasDeadLabel
            // 
            this.lbCamerasDeadLabel.AutoSize = true;
            this.lbCamerasDeadLabel.Location = new System.Drawing.Point(264, 30);
            this.lbCamerasDeadLabel.Name = "lbCamerasDeadLabel";
            this.lbCamerasDeadLabel.Size = new System.Drawing.Size(78, 13);
            this.lbCamerasDeadLabel.TabIndex = 4;
            this.lbCamerasDeadLabel.Text = "Cameras dead:";
            // 
            // lbCamerasActiveLabel
            // 
            this.lbCamerasActiveLabel.AutoSize = true;
            this.lbCamerasActiveLabel.Location = new System.Drawing.Point(264, 7);
            this.lbCamerasActiveLabel.Name = "lbCamerasActiveLabel";
            this.lbCamerasActiveLabel.Size = new System.Drawing.Size(83, 13);
            this.lbCamerasActiveLabel.TabIndex = 3;
            this.lbCamerasActiveLabel.Text = "Cameras active:";
            // 
            // lbTotalImagesLabel
            // 
            this.lbTotalImagesLabel.AutoSize = true;
            this.lbTotalImagesLabel.Location = new System.Drawing.Point(6, 30);
            this.lbTotalImagesLabel.Name = "lbTotalImagesLabel";
            this.lbTotalImagesLabel.Size = new System.Drawing.Size(134, 13);
            this.lbTotalImagesLabel.TabIndex = 2;
            this.lbTotalImagesLabel.Text = "Total image frames parsed:";
            // 
            // lbDataUsage
            // 
            this.lbDataUsage.AutoSize = true;
            this.lbDataUsage.Location = new System.Drawing.Point(160, 7);
            this.lbDataUsage.Name = "lbDataUsage";
            this.lbDataUsage.Size = new System.Drawing.Size(13, 13);
            this.lbDataUsage.TabIndex = 1;
            this.lbDataUsage.Text = "0";
            // 
            // lbDataUsageLabel
            // 
            this.lbDataUsageLabel.AutoSize = true;
            this.lbDataUsageLabel.Location = new System.Drawing.Point(6, 7);
            this.lbDataUsageLabel.Name = "lbDataUsageLabel";
            this.lbDataUsageLabel.Size = new System.Drawing.Size(90, 13);
            this.lbDataUsageLabel.TabIndex = 0;
            this.lbDataUsageLabel.Text = "Total data usage:";
            // 
            // lbDebugMessages
            // 
            this.lbDebugMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDebugMessages.FormattingEnabled = true;
            this.lbDebugMessages.Location = new System.Drawing.Point(0, 0);
            this.lbDebugMessages.Name = "lbDebugMessages";
            this.lbDebugMessages.ScrollAlwaysVisible = true;
            this.lbDebugMessages.Size = new System.Drawing.Size(527, 153);
            this.lbDebugMessages.TabIndex = 0;
            // 
            // updater
            // 
            this.updater.Enabled = true;
            this.updater.Interval = 1000;
            this.updater.Tick += new System.EventHandler(this.updater_Tick);
            // 
            // FormDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 207);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDebug";
            this.Text = "Über Watcher - Debug";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDebug_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbCamerasDead;
        private System.Windows.Forms.Label lbCamerasActive;
        private System.Windows.Forms.Label lbTotalImages;
        private System.Windows.Forms.Label lbCamerasDeadLabel;
        private System.Windows.Forms.Label lbCamerasActiveLabel;
        private System.Windows.Forms.Label lbTotalImagesLabel;
        private System.Windows.Forms.Label lbDataUsage;
        private System.Windows.Forms.Label lbDataUsageLabel;
        private System.Windows.Forms.ListBox lbDebugMessages;
        private System.Windows.Forms.Timer updater;

    }
}