using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintRunningPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dx = 15;
        int dy = 10;
        int x = 100, y = 100, r = 20;
        Pen pen = new Pen(Color.Black);

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.Location.X; // движение после клика
            y = e.Location.Y;
            toolStripStatusLabel1.Text = x + ";" + y;

            timer1.Start();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(pen.Brush, x - r, y - r, 2 * r, 2 * r);
            x += dx;
            y -= dy;
            
            if (y + 2 * r >= this.Height || y <= 0)
                dy = -dy;
            if (x + 2 * r >= this.Width)
                dx = -dx;
            if (x <= 0)
                return;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
