using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        enum calc
        {
             plus = 1,
             minus = 2,
             dived = 3,
             multi = 4,
             divisionWithRem = 5,
             sqrt = 6,
             power = 7,
             fuct = 8
        }
        float a, b;
        double c;
        int fuc;

        bool plusOrMinus = true;

        public Form1()
        {
            InitializeComponent();
        }
        // click 0
        private void button16_Click(object sender, EventArgs e) 
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + 0;
        }
        // click 1
        private void button10_Click(object sender, EventArgs e) 
        {
            textBox1.Text = textBox1.Text + 1;
        }
        // click 2
        private void button11_Click(object sender, EventArgs e) 
        {
            textBox1.Text = textBox1.Text + 2;
        }
        // click 3
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }
        // click 4
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }
        // click 5
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }
        // click 6
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }
        // click 7
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }
        // click 8
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }
        // click 9
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }


        calc calcool = new calc();
        // added sign + to the label
        private void button12_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            calcool = calc.plus;
            label1.Text = "+";
            plusOrMinus = true;
        }
        // added sign - to the label
        private void button13_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            calcool = calc.minus;
            label1.Text = "-";
        }
        // added sign * to the label
        private void button14_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            calcool = calc.multi;
            label1.Text = "*";
        }
        // added sign / to the label
        private void button19_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            calcool = calc.dived;
            label1.Text = "/";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Calculate();
            label1.Text = "";
        }

        private void Calculate()
        {
            switch (calcool)
            {
                case calc.plus:
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case calc.minus:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case calc.multi:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case calc.dived:
                    b = a * float.Parse(textBox1.Text);
                    break;
                case calc.divisionWithRem:
                    b = a % float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case calc.sqrt:
                    textBox1.Text = Math.Sqrt(c).ToString();
                    break;
                case calc.power:
                    textBox1.Text = Math.Pow(a, 2).ToString();
                    break;
                case calc.fuct:
                    a = fuctorial(fuc);
                    textBox1.Text = a.ToString();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (plusOrMinus == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                plusOrMinus = false;
            }
            else if (plusOrMinus == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                plusOrMinus = true;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            calcool = calc.divisionWithRem;
            label1.Text = "%";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (plusOrMinus)
            {
                c = double.Parse(textBox1.Text);
                textBox1.Clear();
                calcool = calc.sqrt;
                label1.Text = "sqrt";
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            calcool = calc.power;
            label1.Text = "Double Power";
        }

        public int fuctorial(int n)
        {
            if (n == 1 || n == 0)
                return 1;
            else
                return n * fuctorial(n - 1);
        }
        
        private void button23_Click(object sender, EventArgs e)
        {
            if (!plusOrMinus)
                textBox1.Text = "Error!";
            else
            {
                fuc = int.Parse(textBox1.Text);
                calcool = calc.fuct;
                label1.Text = "!";
            }
        }


        // click .
        private void button17_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(",") && textBox1.Text != "")
            {
                
                textBox1.Text = textBox1.Text + ",";
            }
        }
    }
}
