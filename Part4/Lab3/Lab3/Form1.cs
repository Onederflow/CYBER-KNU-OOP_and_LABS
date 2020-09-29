using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab3
{
    public partial class Form1 : Form
    {
        public termite ant = new termite();

        public Form1()
        {
            InitializeComponent();
        }

        int number = 0;

        private void set_rules(int number)
        {
            Color c0 = Color.FromArgb(255, 0, 0, 0);
            Color c2 = Color.FromArgb(255, 100, 255, 50);
            Color c10 = Color.FromArgb(255, 220, 100, 50);
            Color c5 = Color.FromArgb(255, 255, 50, 50);

            Color c13 = Color.FromArgb(255, 10, 50, 250);
            Color c14 = Color.FromArgb(255, 20, 150, 150);
            Color c15 = Color.FromArgb(255, 30, 250, 100);

            Color x0 = Color.FromArgb(255, 0, 0, 0);
            Color x1 = Color.FromArgb(255, 50, 50, 255);
            Color x2 = Color.FromArgb(255, 50, 50, 240);
            Color x3 = Color.FromArgb(255, 50, 50, 220);
            Color x4 = Color.FromArgb(255, 50, 50, 200);
            Color x5 = Color.FromArgb(255, 50, 50, 180);
            Color x6 = Color.FromArgb(255, 50, 50, 160);
            Color x7 = Color.FromArgb(255, 50, 50, 140);
            Color x8 = Color.FromArgb(255, 50, 50, 120);
            Color x9 = Color.FromArgb(255, 50, 50, 100);
            Color x10 = Color.FromArgb(255, 50, 50, 80);
            Color x11 = Color.FromArgb(255, 50, 50, 60);
            Color x12 = Color.FromArgb(255, 50, 50, 40);
            Color x13 = Color.FromArgb(255, 50, 50, 30);
            Color x14 = Color.FromArgb(255, 50, 50, 20);
            Color x15 = Color.FromArgb(255, 50, 50, 10);

            //кактус
            if (number == 0)
            {
                ant.add_rule("A", c0, c2, 1, "A");
                ant.add_rule("A", c2, c10, -1, "B");
                ant.add_rule("A", c10, c0, -1, "B");
                ant.add_rule("B", c0, c2, 1, "A");
                ant.add_rule("B", c2, c2, -1, "A");
                ant.add_rule("B", c10, c2, -1, "A");
            }

            //спираль терка
            if (number == 1)
            {
                ant.add_rule("A", c0, c2, -1, "A");
                ant.add_rule("A", c2, c0, 0, "B");
                ant.add_rule("B", c0, c2, 1, "A");
                ant.add_rule("B", c2, c2, 1, "A");
            }

            //noname
            if (number == 2)
            {
                ant.add_rule("A", c0, c5, -1, "A");
                ant.add_rule("B", c0, c5, 1, "C");
                ant.add_rule("C", c0, c5, -1, "C");
                ant.add_rule("A", c5, c5, 1, "C");
                ant.add_rule("B", c5, c5, 1, "C");
                ant.add_rule("C", c5, c0, 1, "C");
            }
            //ромб
            if (number == 3)
            {
                ant.add_rule("A", c0, c2, 0, "B");
                ant.add_rule("B", c0, c2, -1, "C");
                ant.add_rule("C", c0, c2, 0, "A");
                ant.add_rule("A", c2, c0, -1, "A");
                ant.add_rule("B", c2, c0, 0, "A");
                ant.add_rule("C", c2, c0, 0, "A");
            }
            if (number == 4)
            {

                ant.add_rule("A", c0, x1, -1, "B");
                ant.add_rule("A", x1, x2, -1, "B");
                ant.add_rule("A", x2, x3, -1, "B");
                ant.add_rule("A", x3, x4, -1, "B");
                ant.add_rule("A", x4, x5, 1, "B");
                ant.add_rule("A", x5, x6, 1, "B");
                ant.add_rule("A", x6, x7, 1, "B");
                ant.add_rule("A", x7, x8, 1, "B");
                ant.add_rule("A", x8, x9, -1, "B");
                ant.add_rule("A", x9, x10, -1, "B");
                ant.add_rule("A", x10, x11, -1, "B");
                ant.add_rule("A", x11, x12, -1, "B");
                ant.add_rule("A", x12, x13, 1, "B");
                ant.add_rule("A", x13, x14, 1, "B");
                ant.add_rule("A", x14, x15, 1, "B");
                ant.add_rule("A", x15, c0, 1, "A");

                ant.add_rule("B", c0, x1, 1, "B");
                ant.add_rule("B", x1, x2, 1, "A");
                ant.add_rule("B", x2, x3, 1, "A");
                ant.add_rule("B", x3, x4, 1, "A");
                ant.add_rule("B", x4, x5, -1, "A");
                ant.add_rule("B", x5, x6, -1, "A");
                ant.add_rule("B", x6, x7, -1, "A");
                ant.add_rule("B", x7, x8, -1, "A");
                ant.add_rule("B", x8, x9, 1, "A");
                ant.add_rule("B", x9, x10, 1, "A");
                ant.add_rule("B", x10, x11, 1, "A");
                ant.add_rule("B", x11, x12, 1, "A");
                ant.add_rule("B", x12, x13, -1, "A");
                ant.add_rule("B", x13, x14, -1, "A");
                ant.add_rule("B", x14, x15, -1, "A");
                ant.add_rule("B", x15, c0, -1, "A");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                ant = new termite();
                ant.matrix = pictureBox1;
                set_rules(number);
                ant.init(pictureBox1.Width, pictureBox1.Height);
                ant.speed = (int)numericUpDown1.Value;
                timer1.Enabled = true;
            }
            else
                timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ant.next_step();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ant.speed = (int)numericUpDown1.Value;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            number = 0;
            ant = new termite();
            ant.matrix = pictureBox1;
            set_rules(number);
            ant.init(pictureBox1.Width, pictureBox1.Height);
            ant.speed = (int)numericUpDown1.Value;
            timer1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            number = 1;
            ant = new termite();
            ant.matrix = pictureBox1;
            set_rules(number);
            ant.init(pictureBox1.Width, pictureBox1.Height);
            ant.speed = (int)numericUpDown1.Value;
            timer1.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            number = 2;
            ant = new termite();
            ant.matrix = pictureBox1;
            set_rules(number);
            ant.init(pictureBox1.Width, pictureBox1.Height);
            ant.speed = (int)numericUpDown1.Value;
            timer1.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            number = 3;
            ant = new termite();
            ant.matrix = pictureBox1;
            set_rules(number);
            ant.init(pictureBox1.Width, pictureBox1.Height);
            ant.speed = (int)numericUpDown1.Value;
            timer1.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            number = 4;
            ant = new termite();
            ant.matrix = pictureBox1;
            set_rules(number);
            ant.init(pictureBox1.Width, pictureBox1.Height);
            ant.speed = (int)numericUpDown1.Value;
            timer1.Enabled = true;
        }
    }
}
