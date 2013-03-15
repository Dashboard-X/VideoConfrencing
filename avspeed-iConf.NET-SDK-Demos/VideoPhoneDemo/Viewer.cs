using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoPhoneDemo
{
    public partial class Viewer : Form
    {
        public Bitmap bmp;
        public iConfClient.NET.iConfClientDotNet _icc;

        public Viewer(iConfClient.NET.iConfClientDotNet icc)
        {
            _icc = icc;
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (bmp != null)
            {
                e.Graphics.DrawImage(bmp, 0, 0, this.ClientRectangle.Width,
                    this.ClientRectangle.Height);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                bmp = _icc.GetUserScr(this.Tag.ToString());
                Invalidate();
            }));
            
        }
    }
}
