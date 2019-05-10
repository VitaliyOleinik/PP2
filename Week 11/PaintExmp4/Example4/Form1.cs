using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example4
{
    enum Tool
    {
        Line,
        Rectangle,
        Eraser
    }
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Tool tool = Tool.Line;
        Graphics graphics;
        Point prevPoint;
        Point currentPoint;
        Pen pen = new Pen(Color.Black);

        public Form1()
        {
            InitializeComponent();

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            switch (tool)
            {
                case Tool.Line:
                    e.Graphics.DrawLine(pen, prevPoint, currentPoint);
                    break;
                case Tool.Eraser:
                    e.Graphics.Clear(Color.White);
                    break;
            }

            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.Line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.Rectangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = Tool.Eraser;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPoint = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            switch (tool)
            {
                case Tool.Line:
                    graphics.DrawLine(pen, prevPoint, currentPoint);
                    break;
                case Tool.Eraser:
                    graphics.FillRectangle(pen.Brush, 0, 0, 500, 500);
                    
                    break;
                default:
                    break;
            }

            pictureBox1.Refresh();
        }
    }
}
