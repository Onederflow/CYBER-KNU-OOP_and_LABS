using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        PageRank logic;
        Graph visual;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logic = new PageRank();
            visual = new Graph(pictureBoxMain);
            visual.data = logic;
            logic.vs = visual;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            visual.GraphToLogic();
            if (checkBox1.Checked == true)
                logic.RegenWithB();
            logic.Ressult(logic.esc);
        }

        private void panel_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            visual.NewClick(e);
            visual.DrawAllGraphics();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            visual.count = trackBar1.Value;
            visual.DrawAllGraphics();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            logic.esc = System.Convert.ToDouble(textBox1.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            visual.Clear();
        }

        private void pictureBoxMain_Click(object sender, EventArgs e)
        {

        }
    }
}
