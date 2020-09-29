using System;
using System.Drawing;
using System.Windows.Forms;

namespace Splines
{
    public partial class MainForm : Form
    {
        private CSpline _model;
        TheGraphics _graph;
        

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var points = new Point[3];

            points[0] = new Point(10, 20);
            points[1] = new Point(20, 50);
            points[2] = new Point(30, 100);


            _model = new CSpline(points);
            _model.GenerateSplines();

            var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var canvas = Graphics.FromImage(bmp);
            _model.Draw(canvas);
            pictureBox1.Image = bmp;
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var canvas = Graphics.FromImage(bmp);
            _graph = new TheGraphics(canvas, pictureBox1.Height, pictureBox1.Width);
            _graph.DrawAll();
            pictureBox1.Image = bmp;
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
