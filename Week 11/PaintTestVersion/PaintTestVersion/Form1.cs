using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintTestVersion
{
    public partial class Form1 : Form
    {
        Bitmap bitMap;
        Pen pen;
        Graphics graphics;
        float x1, y1;
        public Form1()
        {
            InitializeComponent();
            bitMap = new Bitmap(1000, 1000);
            graphics = Graphics.FromImage(bitMap);
            x1 = y1 = 0;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName != "")
            {
                bitMap.Save(saveFileDialog1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                bitMap = Image.FromFile(openFileDialog1.FileName) as Bitmap;
                pictureBox1.Image = bitMap;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pen = new Pen(Color.Black);
            if (e.Button == MouseButtons.Left)
            {
                graphics.DrawLine(pen, x1, y1, e.X, e.Y);
                pictureBox1.Image = bitMap;
            }
            x1 = e.X;
            y1 = e.Y;
        }
    }
}
