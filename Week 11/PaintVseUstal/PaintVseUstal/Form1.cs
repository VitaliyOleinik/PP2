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

namespace PaintVseUstal
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Red);
        Graphics graphics;
        Bitmap bitmap;
        GraphicsPath gp = new GraphicsPath();
        Point curPoint;
        int x = 200, y = 200, r = 100;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            gp.AddEllipse(new Rectangle(x - r, y - r, 2 * r, 2 * r));
            gp.AddRectangle(new Rectangle(x, y, r, r));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPath(pen.Brush, gp);
            e.Graphics.FillPolygon(new Pen(Color.Blue).Brush, new Point[]
            {
                new Point(50, 50),
                new Point(100, 50),
                new Point(50, 100)
            });
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // при нажатии на фигуру меняет цвет
            curPoint = e.Location;
            if (gp.IsVisible(curPoint))
            {
                pen = new Pen(Color.Black);
            }
            else
            {
                pen = new Pen(Color.Blue);
            }
            Refresh();
        }
    }
}
