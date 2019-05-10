using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintExample3
{
    public partial class Form1 : Form
    {
        enum Tool
        {
            Pen,
            Line, 
            Rectangle
        }

        Point prevPoint, curPoint;
        Pen pen = new Pen(Color.Chocolate);
        Bitmap bMap;
        Graphics graphics;
        GraphicsPath gp = new GraphicsPath();
        Tool tool = new Tool();


        int x = 200, y = 200, r = 100;

        public Form1()
        {
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            InitializeComponent();
            bMap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bMap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            // graphics.DrawLine(pen, 0, 0, 200, 200);
            pictureBox1.Image = bMap;
            gp.AddEllipse(new Rectangle(x - r, y - r, 2 * r, 2 * r));
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            Rectangle res = new Rectangle();
            res.X = Math.Min(p1.X, p2.X);
            res.Y = Math.Min(p1.Y, p2.Y);
            res.Width = Math.Abs(p1.X - p2.X);
            res.Height = Math.Abs(p1.Y - p2.Y);
            return res;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPath(pen.Brush, gp);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (tool)
            {
                case Tool.Pen:
                    e.Graphics.DrawLine(pen, prevPoint, curPoint);
                        break;
                case Tool.Line:
                    e.Graphics.DrawLine(pen, prevPoint, curPoint);
                    break;
                case Tool.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(prevPoint, curPoint));
                    break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //toolStripStatusLabel1.Text = Cursor.Position.ToString(); // координаты мыши!

            if (e.Button == MouseButtons.Left)
            {
                curPoint = e.Location;
                pictureBox1.Refresh();
            }


            if (e.Button == MouseButtons.Left)
            {
                curPoint = e.Location;
                pictureBox1.Refresh();
            }

            if (e.Button == MouseButtons.Left)
            {
                 toolStripStatusLabel1.Text = MouseLeave.Location.ToString(); // координаты при нажатие мыши
                graphics.DrawLine(pen, prevPoint, e.Location);
                prevPoint = e.Location;
                pictureBox1.Refresh();
            }

            if (e.Button != MouseButtons.Left)
            {
                prevPoint = e.Location;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.Line;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (tool)
            {
                case Tool.Pen:
                    graphics.DrawLine(pen, prevPoint, e.Location);
                    prevPoint = e.Location;
                    break;
                case Tool.Line:
                    graphics.DrawLine(pen, prevPoint, e.Location);
                    break;
                case Tool.Rectangle:
                    graphics.DrawRectangle(pen, GetRectangle(prevPoint, e.Location));
                    break;
                default:
                    break;
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.Pen;
        }

        private void toolStripStatusLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }
    }
}
