using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoSourceFromImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ics.ReadyForImageAsSource += new iConfServer.NET.iConfServerDotNet.ReadyForImageAsSourceDelegate(ics_ReadyForImageAsSource);
        }

        void ics_ReadyForImageAsSource()
        {
             Invoke(new MethodInvoker(delegate
            {
            ics.FeedImage(new Bitmap(imageBox.Image));
            }));
        }

       

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            if (imageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageBox.Image = new Bitmap(imageDialog.FileName);

                //ics.SetImagesAsVideoSource(new Bitmap(imageBox.Image));
               
            }

        }

        private void btnStartPreview_Click(object sender, EventArgs e)
        {
            ics.SetImagesAsVideoSource(new Bitmap(imageBox.Image));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ics.FeedImage(new Bitmap(imageBox.Image));
            //ics.SelectVideoDevice(0);
            //ics.StartPreview(0);
        }
    }
}
