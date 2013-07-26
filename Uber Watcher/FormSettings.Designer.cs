namespace Uber_Watcher
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtCamHeight = new System.Windows.Forms.TextBox();
            this.txtCamWidth = new System.Windows.Forms.TextBox();
            this.lbColumnsLabel = new System.Windows.Forms.Label();
            this.lbCamHeightLabel = new System.Windows.Forms.Label();
            this.lbCamWidthLabel = new System.Windows.Forms.Label();
            this.lbStyleLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHide = new System.Windows.Forms.TextBox();
            this.txtRetest = new System.Windows.Forms.TextBox();
            this.txtUpdating = new System.Windows.Forms.TextBox();
            this.lbHideLabel = new System.Windows.Forms.Label();
            this.lbRetestLabel = new System.Windows.Forms.Label();
            this.lbUpdatingLabel = new System.Windows.Forms.Label();
            this.buttSave = new System.Windows.Forms.Button();
            this.buttClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbStyle);
            this.groupBox1.Controls.Add(this.txtColumns);
            this.groupBox1.Controls.Add(this.txtCamHeight);
            this.groupBox1.Controls.Add(this.txtCamWidth);
            this.groupBox1.Controls.Add(this.lbColumnsLabel);
            this.groupBox1.Controls.Add(this.lbCamHeightLabel);
            this.groupBox1.Controls.Add(this.lbCamWidthLabel);
            this.groupBox1.Controls.Add(this.lbStyleLabel);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(17, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid Style";
            // 
            // cbStyle
            // 
            this.cbStyle.ForeColor = System.Drawing.Color.Black;
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Location = new System.Drawing.Point(179, 16);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(126, 21);
            this.cbStyle.TabIndex = 1;
            // 
            // txtColumns
            // 
            this.txtColumns.ForeColor = System.Drawing.Color.Black;
            this.txtColumns.Location = new System.Drawing.Point(179, 95);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(126, 20);
            this.txtColumns.TabIndex = 4;
            // 
            // txtCamHeight
            // 
            this.txtCamHeight.ForeColor = System.Drawing.Color.Black;
            this.txtCamHeight.Location = new System.Drawing.Point(179, 69);
            this.txtCamHeight.Name = "txtCamHeight";
            this.txtCamHeight.Size = new System.Drawing.Size(126, 20);
            this.txtCamHeight.TabIndex = 3;
            // 
            // txtCamWidth
            // 
            this.txtCamWidth.ForeColor = System.Drawing.Color.Black;
            this.txtCamWidth.Location = new System.Drawing.Point(179, 43);
            this.txtCamWidth.Name = "txtCamWidth";
            this.txtCamWidth.Size = new System.Drawing.Size(126, 20);
            this.txtCamWidth.TabIndex = 2;
            // 
            // lbColumnsLabel
            // 
            this.lbColumnsLabel.AutoSize = true;
            this.lbColumnsLabel.ForeColor = System.Drawing.Color.Black;
            this.lbColumnsLabel.Location = new System.Drawing.Point(6, 98);
            this.lbColumnsLabel.Name = "lbColumnsLabel";
            this.lbColumnsLabel.Size = new System.Drawing.Size(50, 13);
            this.lbColumnsLabel.TabIndex = 3;
            this.lbColumnsLabel.Text = "Columns:";
            // 
            // lbCamHeightLabel
            // 
            this.lbCamHeightLabel.AutoSize = true;
            this.lbCamHeightLabel.ForeColor = System.Drawing.Color.Black;
            this.lbCamHeightLabel.Location = new System.Drawing.Point(6, 72);
            this.lbCamHeightLabel.Name = "lbCamHeightLabel";
            this.lbCamHeightLabel.Size = new System.Drawing.Size(80, 13);
            this.lbCamHeightLabel.TabIndex = 2;
            this.lbCamHeightLabel.Text = "Camera Height:";
            // 
            // lbCamWidthLabel
            // 
            this.lbCamWidthLabel.AutoSize = true;
            this.lbCamWidthLabel.ForeColor = System.Drawing.Color.Black;
            this.lbCamWidthLabel.Location = new System.Drawing.Point(6, 46);
            this.lbCamWidthLabel.Name = "lbCamWidthLabel";
            this.lbCamWidthLabel.Size = new System.Drawing.Size(77, 13);
            this.lbCamWidthLabel.TabIndex = 1;
            this.lbCamWidthLabel.Text = "Camera Width:";
            // 
            // lbStyleLabel
            // 
            this.lbStyleLabel.AutoSize = true;
            this.lbStyleLabel.ForeColor = System.Drawing.Color.Black;
            this.lbStyleLabel.Location = new System.Drawing.Point(6, 19);
            this.lbStyleLabel.Name = "lbStyleLabel";
            this.lbStyleLabel.Size = new System.Drawing.Size(33, 13);
            this.lbStyleLabel.TabIndex = 0;
            this.lbStyleLabel.Text = "Style:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtHide);
            this.groupBox2.Controls.Add(this.txtRetest);
            this.groupBox2.Controls.Add(this.txtUpdating);
            this.groupBox2.Controls.Add(this.lbHideLabel);
            this.groupBox2.Controls.Add(this.lbRetestLabel);
            this.groupBox2.Controls.Add(this.lbUpdatingLabel);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(17, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 107);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera Intervals";
            // 
            // txtHide
            // 
            this.txtHide.ForeColor = System.Drawing.Color.Black;
            this.txtHide.Location = new System.Drawing.Point(179, 75);
            this.txtHide.Name = "txtHide";
            this.txtHide.Size = new System.Drawing.Size(126, 20);
            this.txtHide.TabIndex = 7;
            // 
            // txtRetest
            // 
            this.txtRetest.ForeColor = System.Drawing.Color.Black;
            this.txtRetest.Location = new System.Drawing.Point(179, 49);
            this.txtRetest.Name = "txtRetest";
            this.txtRetest.Size = new System.Drawing.Size(126, 20);
            this.txtRetest.TabIndex = 6;
            // 
            // txtUpdating
            // 
            this.txtUpdating.ForeColor = System.Drawing.Color.Black;
            this.txtUpdating.Location = new System.Drawing.Point(179, 23);
            this.txtUpdating.Name = "txtUpdating";
            this.txtUpdating.Size = new System.Drawing.Size(126, 20);
            this.txtUpdating.TabIndex = 5;
            // 
            // lbHideLabel
            // 
            this.lbHideLabel.AutoSize = true;
            this.lbHideLabel.ForeColor = System.Drawing.Color.Black;
            this.lbHideLabel.Location = new System.Drawing.Point(6, 78);
            this.lbHideLabel.Name = "lbHideLabel";
            this.lbHideLabel.Size = new System.Drawing.Size(105, 13);
            this.lbHideLabel.TabIndex = 2;
            this.lbHideLabel.Text = "Hide Dead Cameras:";
            // 
            // lbRetestLabel
            // 
            this.lbRetestLabel.AutoSize = true;
            this.lbRetestLabel.ForeColor = System.Drawing.Color.Black;
            this.lbRetestLabel.Location = new System.Drawing.Point(6, 52);
            this.lbRetestLabel.Name = "lbRetestLabel";
            this.lbRetestLabel.Size = new System.Drawing.Size(117, 13);
            this.lbRetestLabel.TabIndex = 1;
            this.lbRetestLabel.Text = "Re-test Dead Cameras:";
            // 
            // lbUpdatingLabel
            // 
            this.lbUpdatingLabel.AutoSize = true;
            this.lbUpdatingLabel.ForeColor = System.Drawing.Color.Black;
            this.lbUpdatingLabel.Location = new System.Drawing.Point(6, 26);
            this.lbUpdatingLabel.Name = "lbUpdatingLabel";
            this.lbUpdatingLabel.Size = new System.Drawing.Size(85, 13);
            this.lbUpdatingLabel.TabIndex = 0;
            this.lbUpdatingLabel.Text = "Image Updating:";
            // 
            // buttSave
            // 
            this.buttSave.Location = new System.Drawing.Point(258, 281);
            this.buttSave.Name = "buttSave";
            this.buttSave.Size = new System.Drawing.Size(75, 23);
            this.buttSave.TabIndex = 9;
            this.buttSave.Text = "Save";
            this.buttSave.UseVisualStyleBackColor = true;
            this.buttSave.Click += new System.EventHandler(this.buttSave_Click);
            // 
            // buttClose
            // 
            this.buttClose.Location = new System.Drawing.Point(17, 281);
            this.buttClose.Name = "buttClose";
            this.buttClose.Size = new System.Drawing.Size(75, 23);
            this.buttClose.TabIndex = 8;
            this.buttClose.Text = "Close";
            this.buttClose.UseVisualStyleBackColor = true;
            this.buttClose.Click += new System.EventHandler(this.buttClose_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 313);
            this.Controls.Add(this.buttClose);
            this.Controls.Add(this.buttSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Über Watcher -  Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbColumnsLabel;
        private System.Windows.Forms.Label lbCamHeightLabel;
        private System.Windows.Forms.Label lbCamWidthLabel;
        private System.Windows.Forms.Label lbStyleLabel;
        private System.Windows.Forms.Label lbRetestLabel;
        private System.Windows.Forms.Label lbUpdatingLabel;
        private System.Windows.Forms.Label lbHideLabel;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.TextBox txtCamHeight;
        private System.Windows.Forms.TextBox txtCamWidth;
        private System.Windows.Forms.TextBox txtHide;
        private System.Windows.Forms.TextBox txtRetest;
        private System.Windows.Forms.TextBox txtUpdating;
        private System.Windows.Forms.Button buttSave;
        private System.Windows.Forms.Button buttClose;
        private System.Windows.Forms.ComboBox cbStyle;
    }
}