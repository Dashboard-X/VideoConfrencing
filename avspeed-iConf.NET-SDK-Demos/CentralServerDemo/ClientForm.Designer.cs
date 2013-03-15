//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;


namespace CentralServerDemo
{

	public partial class ClientForm : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.icc = new iConfClient.NET.iConfClientDotNet();
            this.SuspendLayout();
            // 
            // icc
            // 
            this.icc.BackColor = System.Drawing.Color.Gray;
            this.icc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.icc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icc.Location = new System.Drawing.Point(0, 0);
            this.icc.Name = "icc";
            this.icc.Size = new System.Drawing.Size(284, 262);
            this.icc.TabIndex = 0;
            this.icc.NewVideoFrameBytesAvailable += new iConfClient.NET.iConfClientDotNet.NewVideoFrameBytesAvailableDelegate(this.icc_NewVideoFrameBytesAvailable);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.icc);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);

		}
		internal iConfClient.NET.iConfClientDotNet icc;
	}

} //end of root namespace