namespace VideoSourceFromImages
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.imageDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnStartPreview = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ics = new iConfServer.NET.iConfServerDotNet();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "My Video";
            // 
            // imageBox
            // 
            this.imageBox.Image = global::VideoSourceFromImages.Properties.Resources.waiting;
            this.imageBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("imageBox.InitialImage")));
            this.imageBox.Location = new System.Drawing.Point(356, 26);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(223, 207);
            this.imageBox.TabIndex = 12;
            this.imageBox.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(356, 240);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(223, 23);
            this.btnLoadImage.TabIndex = 13;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // imageDialog
            // 
            this.imageDialog.FileName = "openFileDialog1";
            // 
            // btnStartPreview
            // 
            this.btnStartPreview.Location = new System.Drawing.Point(33, 247);
            this.btnStartPreview.Name = "btnStartPreview";
            this.btnStartPreview.Size = new System.Drawing.Size(133, 23);
            this.btnStartPreview.TabIndex = 14;
            this.btnStartPreview.Text = "Start Preview";
            this.btnStartPreview.UseVisualStyleBackColor = true;
            this.btnStartPreview.Click += new System.EventHandler(this.btnStartPreview_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ics
            // 
            this.ics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ics.CallbackObject = null;
            this.ics.EncryptedData = false;
            this.ics.Location = new System.Drawing.Point(33, 26);
            this.ics.Name = "ics";
            this.ics.Size = new System.Drawing.Size(214, 207);
            this.ics.TabIndex = 10;
            this.ics.VideoRateControl = iConfServer.NET.iConfServerDotNet.RateControl.ConstantBitRate;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 340);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStartPreview);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ics);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private iConfServer.NET.iConfServerDotNet ics;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.OpenFileDialog imageDialog;
        private System.Windows.Forms.Button btnStartPreview;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

