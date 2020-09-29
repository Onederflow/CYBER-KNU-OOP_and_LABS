using System;
using System.Drawing;
using System.Windows.Forms;

namespace Splines
{
    public partial class MainForm : Form
    {
        private CSpline _model;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var random = new Random();

            var points = new CPoint[6];
            var interval = (pictureBox1.Width - 20) / 6;

            points[0] = new CPoint(-5, 25);
            points[1] = new CPoint(15, 60);
            points[2] = new CPoint(20, -35);
            points[3] = new CPoint(35, -70);
            points[4] = new CPoint(60, -100);
            points[5] = new CPoint(90, 20);
            _model = new CSpline(points);

            SetD1ToModel();
            Draw();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            SetD1ToModel();
            Draw();
        }

        private void SetD1ToModel()
        {
           // _model.Df1 = (double)vScrollBar1.Value / 1000;
          //  _model.Dfn = (double)vScrollBar2.Value / 1000;
            _model.GenerateSplines();
        }

            private void Draw()
        {
            var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            var canvas = Graphics.FromImage(bmp);

            _model.Draw(canvas);

            pictureBox1.Image = bmp;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
