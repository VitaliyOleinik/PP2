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

namespace Paint
{
    public partial class Form1 : Form
    {
        public static System.Drawing.Drawing2D.GraphicsContainer kraya;
        public static Graphics graphics;
        public static System.Drawing.Drawing2D.GraphicsState graphicsState;
        public static bool Is_Drawing, Is_Curve;
        public static Pen pen;
        public static SolidBrush brush;
        public Point a, b;
        public List<Point> CurvaPoints;
        public Tool tool;

        public Form1()
        {
            InitializeComponent();
        }

        Pen pen = new Pen(Color.Red, 10);
        SolidBrush solidBrush = new SolidBrush(Color.White);
        Pen pen1 = new Pen(Color.Black, 6);

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*e.Graphics.FillEllipse(solidBrush, 10, 10, 300, 300);
            e.Graphics.DrawEllipse(pen1, 10, 10, 300, 300);
            e.Graphics.DrawLine(pen, 10, 10, 300, 300);*/
            GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
            graphicsPath.AddRectangle(new Rectangle(53, 53, 100, 100));
            graphicsPath.AddRectangle(new Rectangle(253, 53, 100, 100));
            e.Graphics.DrawLine(pen1, 250, 0, 500, 250);
            e.Graphics.DrawLine(pen1, 0, 250, 500, 250);
            e.Graphics.DrawLine(pen1, 0, 250, 250, 0);
            e.Graphics.FillPath(pen.Brush, graphicsPath);
        }
    }
}
