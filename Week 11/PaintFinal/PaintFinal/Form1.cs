using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintFinal
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black);
        Graphics graphics;
        Point prevPoint;
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
            
        }




        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void trackBar1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = Cursor.Position.ToString(); // координаты мыши!

            if (e.Button == MouseButtons.Left)
            {
                // toolStripStatusLabel1.Text = MouseLeave.Location.ToString(); // координаты при нажатие мыши
                graphics.DrawLine(pen, prevPoint, e.Location);
                prevPoint = e.Location;
                pictureBox1.Refresh();
            }

            if (e.Button != MouseButtons.Left)
            {
                prevPoint = e.Location;
            }
        }

        private void toolStripStatusLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }
    }
}
