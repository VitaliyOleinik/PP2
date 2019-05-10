using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exmple2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pen pen = new Pen(Color.Brown);
        Color[] colors = new Color[] { Color.Yellow, Color.Red, Color.Blue, Color.Green };
        int d = 0;
        int index = 0;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(pen.Brush, 400 - 2 * d, 300 - 2 * d, 40 + 2 * d, 40 + 2 * d);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (d != 50)
                d += 5;
                index = (index + 1) % colors.Length;
                pen.Color = colors[index];
                toolStripStatusLabel1.Text = string.Format(d + " - d");
                Refresh();
            
            toolStripStatusLabel2.Text = string.Format("Date and Time: " + DateTime.Now.ToLongTimeString()
                + " " + DateTime.Now.ToLongDateString());
            
        }

        
    }
}
