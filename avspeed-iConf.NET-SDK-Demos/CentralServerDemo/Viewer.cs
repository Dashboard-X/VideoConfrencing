using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CentralServerDemo
{
    public partial class Viewer : Form
    {
        public Bitmap bmp;
        public iConfServer.NET.iConfServerDotNet _ics;

        public Viewer(iConfServer.NET.iConfServerDotNet ics)
        {
            _ics = ics;
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
            bmp = _ics.GetUserScr(Convert.ToInt32(this.Tag));
            Invalidate();
        }
    }
}
