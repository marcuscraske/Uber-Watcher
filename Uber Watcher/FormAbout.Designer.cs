namespace Uber_Watcher
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.label1 = new System.Windows.Forms.Label();
            this.lbAuthorSoftware = new System.Windows.Forms.Label();
            this.lbAuthorSoftware2 = new System.Windows.Forms.Label();
            this.lbAuthorIcon = new System.Windows.Forms.Label();
            this.lbAuthorIcon2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkGithub = new System.Windows.Forms.LinkLabel();
            this.lbSupport = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "About";
            // 
            // lbAuthorSoftware
            // 
            this.lbAuthorSoftware.AutoSize = true;
            this.lbAuthorSoftware.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthorSoftware.Location = new System.Drawing.Point(19, 21);
            this.lbAuthorSoftware.Name = "lbAuthorSoftware";
            this.lbAuthorSoftware.Size = new System.Drawing.Size(52, 13);
            this.lbAuthorSoftware.TabIndex = 1;
            this.lbAuthorSoftware.Text = "Software:";
            // 
            // lbAuthorSoftware2
            // 
            this.lbAuthorSoftware2.AutoSize = true;
            this.lbAuthorSoftware2.Location = new System.Drawing.Point(129, 21);
            this.lbAuthorSoftware2.Name = "lbAuthorSoftware2";
            this.lbAuthorSoftware2.Size = new System.Drawing.Size(184, 13);
            this.lbAuthorSoftware2.TabIndex = 2;
            this.lbAuthorSoftware2.Text = "limpygnome (limpygnome@gmail.com)";
            // 
            // lbAuthorIcon
            // 
            this.lbAuthorIcon.AutoSize = true;
            this.lbAuthorIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthorIcon.Location = new System.Drawing.Point(19, 44);
            this.lbAuthorIcon.Name = "lbAuthorIcon";
            this.lbAuthorIcon.Size = new System.Drawing.Size(31, 13);
            this.lbAuthorIcon.TabIndex = 3;
            this.lbAuthorIcon.Text = "Icon:";
            // 
            // lbAuthorIcon2
            // 
            this.lbAuthorIcon2.AutoSize = true;
            this.lbAuthorIcon2.Location = new System.Drawing.Point(129, 44);
            this.lbAuthorIcon2.Name = "lbAuthorIcon2";
            this.lbAuthorIcon2.Size = new System.Drawing.Size(142, 13);
            this.lbAuthorIcon2.TabIndex = 4;
            this.lbAuthorIcon2.Text = "Annie (lilacxlimb@gmail.com)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAuthorSoftware);
            this.groupBox1.Controls.Add(this.lbAuthorIcon2);
            this.groupBox1.Controls.Add(this.lbAuthorSoftware2);
            this.groupBox1.Controls.Add(this.lbAuthorIcon);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 69);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authors";
            // 
            // buttClose
            // 
            this.buttClose.Location = new System.Drawing.Point(310, 187);
            this.buttClose.Name = "buttClose";
            this.buttClose.Size = new System.Drawing.Size(75, 23);
            this.buttClose.TabIndex = 2;
            this.buttClose.Text = "Close";
            this.buttClose.UseVisualStyleBackColor = true;
            this.buttClose.Click += new System.EventHandler(this.buttClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkGithub);
            this.groupBox2.Controls.Add(this.lbSupport);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 69);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Support";
            // 
            // linkGithub
            // 
            this.linkGithub.AutoSize = true;
            this.linkGithub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkGithub.Location = new System.Drawing.Point(19, 47);
            this.linkGithub.Name = "linkGithub";
            this.linkGithub.Size = new System.Drawing.Size(216, 13);
            this.linkGithub.TabIndex = 1;
            this.linkGithub.TabStop = true;
            this.linkGithub.Text = "https://github.com/ubermeat/Uber-Watcher";
            this.linkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGithub_LinkClicked);
            // 
            // lbSupport
            // 
            this.lbSupport.AutoSize = true;
            this.lbSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSupport.Location = new System.Drawing.Point(19, 17);
            this.lbSupport.Name = "lbSupport";
            this.lbSupport.Size = new System.Drawing.Size(325, 26);
            this.lbSupport.TabIndex = 8;
            this.lbSupport.Text = "Contact the developers in the authors section; or visit the link below\r\n(where yo" +
    "u can find the source-code, report bugs and contribute):";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(12, 192);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(13, 13);
            this.lbVersion.TabIndex = 8;
            this.lbVersion.Text = "v";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 218);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAbout";
            this.Text = "Über Watcher - About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAbout_FormClosing);
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbAuthorSoftware;
        private System.Windows.Forms.Label lbAuthorSoftware2;
        private System.Windows.Forms.Label lbAuthorIcon;
        private System.Windows.Forms.Label lbAuthorIcon2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkGithub;
        private System.Windows.Forms.Label lbSupport;
        private System.Windows.Forms.Label lbVersion;
    }
}