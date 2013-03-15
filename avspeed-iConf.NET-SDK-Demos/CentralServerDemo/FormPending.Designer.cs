namespace CentralServerDemo
{
    partial class FormPending
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
            this.btnIgnoreRequest = new System.Windows.Forms.ToolStripButton();
            this.lstPending = new System.Windows.Forms.ListBox();
            this.btnAcceptRequest = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIgnoreRequest
            // 
            this.btnIgnoreRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIgnoreRequest.Name = "btnIgnoreRequest";
            this.btnIgnoreRequest.Size = new System.Drawing.Size(45, 22);
            this.btnIgnoreRequest.Text = "Ignore";
            // 
            // lstPending
            // 
            this.lstPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPending.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPending.FormattingEnabled = true;
            this.lstPending.Location = new System.Drawing.Point(0, 0);
            this.lstPending.Name = "lstPending";
            this.lstPending.Size = new System.Drawing.Size(284, 225);
            this.lstPending.Sorted = true;
            this.lstPending.TabIndex = 0;
            // 
            // btnAcceptRequest
            // 
            this.btnAcceptRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptRequest.Name = "btnAcceptRequest";
            this.btnAcceptRequest.Size = new System.Drawing.Size(48, 22);
            this.btnAcceptRequest.Text = "Accept";
            this.btnAcceptRequest.Click += new System.EventHandler(this.btnAcceptRequest_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstPending);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 237);
            this.panel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAcceptRequest,
            this.btnIgnoreRequest});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FormPending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormPending";
            this.Text = "Pending Contacts";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lstPending;
        public System.Windows.Forms.ToolStripButton btnIgnoreRequest;
        public System.Windows.Forms.ToolStripButton btnAcceptRequest;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStrip toolStrip1;
    }
}