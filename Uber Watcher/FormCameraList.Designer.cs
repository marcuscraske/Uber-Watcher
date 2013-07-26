namespace Uber_Watcher
{
    partial class FormCameraList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCameraList));
            this.lbCameras = new System.Windows.Forms.ListBox();
            this.buttRemove = new System.Windows.Forms.Button();
            this.buttAdd = new System.Windows.Forms.Button();
            this.txtAddUrl = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAddUrl = new System.Windows.Forms.Label();
            this.lbAddTitle = new System.Windows.Forms.Label();
            this.txtAddTitle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttDump = new System.Windows.Forms.Button();
            this.buttMassAdd = new System.Windows.Forms.Button();
            this.txtCopypasta = new System.Windows.Forms.TextBox();
            this.buttSaveClose = new System.Windows.Forms.Button();
            this.buttClose = new System.Windows.Forms.Button();
            this.buttRemoveDead = new System.Windows.Forms.Button();
            this.buttEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCameras
            // 
            this.lbCameras.FormattingEnabled = true;
            this.lbCameras.Location = new System.Drawing.Point(12, 12);
            this.lbCameras.Name = "lbCameras";
            this.lbCameras.ScrollAlwaysVisible = true;
            this.lbCameras.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbCameras.Size = new System.Drawing.Size(662, 290);
            this.lbCameras.TabIndex = 4;
            // 
            // buttRemove
            // 
            this.buttRemove.Location = new System.Drawing.Point(680, 12);
            this.buttRemove.Name = "buttRemove";
            this.buttRemove.Size = new System.Drawing.Size(75, 62);
            this.buttRemove.TabIndex = 1;
            this.buttRemove.Text = "Remove Selected Camera(s)";
            this.buttRemove.UseVisualStyleBackColor = true;
            this.buttRemove.Click += new System.EventHandler(this.buttRemove_Click);
            // 
            // buttAdd
            // 
            this.buttAdd.Location = new System.Drawing.Point(581, 17);
            this.buttAdd.Name = "buttAdd";
            this.buttAdd.Size = new System.Drawing.Size(75, 23);
            this.buttAdd.TabIndex = 7;
            this.buttAdd.Text = "Add";
            this.buttAdd.UseVisualStyleBackColor = true;
            this.buttAdd.Click += new System.EventHandler(this.buttAdd_Click);
            // 
            // txtAddUrl
            // 
            this.txtAddUrl.Location = new System.Drawing.Point(257, 19);
            this.txtAddUrl.Name = "txtAddUrl";
            this.txtAddUrl.Size = new System.Drawing.Size(318, 20);
            this.txtAddUrl.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAddUrl);
            this.groupBox1.Controls.Add(this.lbAddTitle);
            this.groupBox1.Controls.Add(this.txtAddTitle);
            this.groupBox1.Controls.Add(this.txtAddUrl);
            this.groupBox1.Controls.Add(this.buttAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 326);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 48);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Camera";
            // 
            // lbAddUrl
            // 
            this.lbAddUrl.AutoSize = true;
            this.lbAddUrl.Location = new System.Drawing.Point(219, 22);
            this.lbAddUrl.Name = "lbAddUrl";
            this.lbAddUrl.Size = new System.Drawing.Size(32, 13);
            this.lbAddUrl.TabIndex = 6;
            this.lbAddUrl.Text = "URL:";
            // 
            // lbAddTitle
            // 
            this.lbAddTitle.AutoSize = true;
            this.lbAddTitle.Location = new System.Drawing.Point(6, 22);
            this.lbAddTitle.Name = "lbAddTitle";
            this.lbAddTitle.Size = new System.Drawing.Size(30, 13);
            this.lbAddTitle.TabIndex = 5;
            this.lbAddTitle.Text = "Title:";
            // 
            // txtAddTitle
            // 
            this.txtAddTitle.Location = new System.Drawing.Point(42, 19);
            this.txtAddTitle.Name = "txtAddTitle";
            this.txtAddTitle.Size = new System.Drawing.Size(171, 20);
            this.txtAddTitle.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttDump);
            this.groupBox2.Controls.Add(this.buttMassAdd);
            this.groupBox2.Controls.Add(this.txtCopypasta);
            this.groupBox2.Location = new System.Drawing.Point(12, 380);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 161);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Copypasta";
            // 
            // buttDump
            // 
            this.buttDump.Location = new System.Drawing.Point(581, 67);
            this.buttDump.Name = "buttDump";
            this.buttDump.Size = new System.Drawing.Size(75, 54);
            this.buttDump.TabIndex = 9;
            this.buttDump.Text = "Dump My Current List";
            this.buttDump.UseVisualStyleBackColor = true;
            this.buttDump.Click += new System.EventHandler(this.buttDump_Click);
            // 
            // buttMassAdd
            // 
            this.buttMassAdd.Location = new System.Drawing.Point(581, 19);
            this.buttMassAdd.Name = "buttMassAdd";
            this.buttMassAdd.Size = new System.Drawing.Size(75, 42);
            this.buttMassAdd.TabIndex = 8;
            this.buttMassAdd.Text = "Add Copypasta";
            this.buttMassAdd.UseVisualStyleBackColor = true;
            this.buttMassAdd.Click += new System.EventHandler(this.buttMassAdd_Click);
            // 
            // txtCopypasta
            // 
            this.txtCopypasta.Location = new System.Drawing.Point(6, 19);
            this.txtCopypasta.Multiline = true;
            this.txtCopypasta.Name = "txtCopypasta";
            this.txtCopypasta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCopypasta.Size = new System.Drawing.Size(569, 136);
            this.txtCopypasta.TabIndex = 10;
            // 
            // buttSaveClose
            // 
            this.buttSaveClose.Location = new System.Drawing.Point(680, 468);
            this.buttSaveClose.Name = "buttSaveClose";
            this.buttSaveClose.Size = new System.Drawing.Size(75, 42);
            this.buttSaveClose.TabIndex = 11;
            this.buttSaveClose.Text = "Save and Close";
            this.buttSaveClose.UseVisualStyleBackColor = true;
            this.buttSaveClose.Click += new System.EventHandler(this.buttSaveClose_Click);
            // 
            // buttClose
            // 
            this.buttClose.Location = new System.Drawing.Point(680, 516);
            this.buttClose.Name = "buttClose";
            this.buttClose.Size = new System.Drawing.Size(75, 25);
            this.buttClose.TabIndex = 12;
            this.buttClose.Text = "Close";
            this.buttClose.UseVisualStyleBackColor = true;
            this.buttClose.Click += new System.EventHandler(this.buttClose_Click);
            // 
            // buttRemoveDead
            // 
            this.buttRemoveDead.Location = new System.Drawing.Point(680, 80);
            this.buttRemoveDead.Name = "buttRemoveDead";
            this.buttRemoveDead.Size = new System.Drawing.Size(75, 62);
            this.buttRemoveDead.TabIndex = 2;
            this.buttRemoveDead.Text = "Remove Dead Cameras";
            this.buttRemoveDead.UseVisualStyleBackColor = true;
            this.buttRemoveDead.Click += new System.EventHandler(this.buttRemoveDead_Click);
            // 
            // buttEdit
            // 
            this.buttEdit.Location = new System.Drawing.Point(680, 148);
            this.buttEdit.Name = "buttEdit";
            this.buttEdit.Size = new System.Drawing.Size(75, 26);
            this.buttEdit.TabIndex = 3;
            this.buttEdit.Text = "Edit";
            this.buttEdit.UseVisualStyleBackColor = true;
            this.buttEdit.Click += new System.EventHandler(this.buttEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Note: cameras with the same title will dump frames to the same directory.";
            // 
            // FormCameraList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 551);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttEdit);
            this.Controls.Add(this.buttRemoveDead);
            this.Controls.Add(this.buttClose);
            this.Controls.Add(this.buttSaveClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttRemove);
            this.Controls.Add(this.lbCameras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCameraList";
            this.Text = "Über Watcher - Camera List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCameraList_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCameraList_FormClosed);
            this.Load += new System.EventHandler(this.FormCameraList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCameras;
        private System.Windows.Forms.Button buttRemove;
        private System.Windows.Forms.Button buttAdd;
        private System.Windows.Forms.TextBox txtAddUrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCopypasta;
        private System.Windows.Forms.Button buttDump;
        private System.Windows.Forms.Button buttMassAdd;
        private System.Windows.Forms.Button buttSaveClose;
        private System.Windows.Forms.Button buttClose;
        private System.Windows.Forms.Button buttRemoveDead;
        private System.Windows.Forms.Label lbAddUrl;
        private System.Windows.Forms.Label lbAddTitle;
        private System.Windows.Forms.TextBox txtAddTitle;
        private System.Windows.Forms.Button buttEdit;
        private System.Windows.Forms.Label label1;
    }
}