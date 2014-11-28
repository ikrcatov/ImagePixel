using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ImagePixel
{
    public partial class Form1 : Form
    {
        List<PictureBox> listPB;
        Point myPoint = new Point(-1, -1);

        public Form1()
        {
            InitializeComponent();
            listPB = new List<PictureBox>();
            listPB.Add(pictureBox1);
            listPB.Add(pictureBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Loop through the picture boxes
                foreach (PictureBox pb in listPB)
                {
                    //Find an empty picture box
                    if (pb.Image == null)
                    {
                        //Load the image
                        pb.Load(openFileDialog1.FileName);
                        Image img = pb.Image;
                        //Adjust the image size after loading it to Picture box
                        if (pb.Width < img.Width && pb.Height < img.Height)
                        {
                            pb.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {

                            pb.SizeMode = PictureBoxSizeMode.Normal;
                        }
                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Loop through the picture boxes
                foreach (PictureBox pb in listPB)
                {
                    //Find an empty picture box
                    if (pb.Image == null)
                    {
                        //Load the image
                        pb.Load(openFileDialog1.FileName);
                        Image img = pb.Image;
                        //Adjust the image size after loading it to Picture box
                        if (pb.Width < img.Width && pb.Height < img.Height)
                        {
                            pb.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {

                            pb.SizeMode = PictureBoxSizeMode.Normal;
                        }
                        break;
                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (myPoint.X != -1 || myPoint.Y != -1)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Green), myPoint.X, myPoint.Y, 10, 10);
                //e.Graphics.FillRectangle(Brushes.Green, myPoint.X, myPoint.Y, 10, 10);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1 != null && pictureBox1.Image != null)
            {
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(this.pictureBox1, "Hello");
                //MessageBox.Show(string.Format("X: {0} Y: {1}", MousePosition.X, MousePosition.Y));

                Bitmap b = new Bitmap(pictureBox1.Image);
                myPoint = new Point(e.X, e.Y);

                pictureBox1.Invalidate(); 
                pictureBox2.Invalidate();
            }
        }
    }
}
