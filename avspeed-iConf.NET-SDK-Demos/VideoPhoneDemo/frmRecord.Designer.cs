namespace VideoPhoneDemo
{
    partial class frmRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecord));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVideoCompressors = new System.Windows.Forms.ComboBox();
            this.cbAudioCompressors = new System.Windows.Forms.ComboBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbVideoCompressors);
            this.groupBox3.Controls.Add(this.cbAudioCompressors);
            this.groupBox3.Controls.Add(this.btnRecord);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 172);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recording";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Audio compressor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Video compressor";
            // 
            // cbVideoCompressors
            // 
            this.cbVideoCompressors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoCompressors.FormattingEnabled = true;
            this.cbVideoCompressors.Location = new System.Drawing.Point(30, 40);
            this.cbVideoCompressors.Name = "cbVideoCompressors";
            this.cbVideoCompressors.Size = new System.Drawing.Size(151, 21);
            this.cbVideoCompressors.TabIndex = 24;
            // 
            // cbAudioCompressors
            // 
            this.cbAudioCompressors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioCompressors.FormattingEnabled = true;
            this.cbAudioCompressors.Location = new System.Drawing.Point(30, 89);
            this.cbAudioCompressors.Name = "cbAudioCompressors";
            this.cbAudioCompressors.Size = new System.Drawing.Size(151, 21);
            this.cbAudioCompressors.TabIndex = 25;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(30, 130);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(151, 23);
            this.btnRecord.TabIndex = 26;
            this.btnRecord.Text = "Click to Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // frmRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 196);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Record";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRecord_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRecord;
        public System.Windows.Forms.ComboBox cbVideoCompressors;
        public System.Windows.Forms.ComboBox cbAudioCompressors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}