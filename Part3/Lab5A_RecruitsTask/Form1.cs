using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5A_RecruitsTask
{
    public partial class Form1 : Form
    {
        Logic logic = new Logic();
        Graphics gs;
        public Form1()
        {
            InitializeComponent();
            gs = pictureBox1.CreateGraphics();
            logic = new Logic(gs);
        }

        private void ButtonRotation_Click(object sender, EventArgs e)
        {
            logic.Reset();
            logic = new Logic(gs);
            logic.sleepTime = 3 + 10 * trackBarSpeed.Value;
            logic.nSoldiers = (int)numericUpDownCount.Value;
            gs.Clear(Color.SlateGray);
            logic.SetNew();
            logic.Rotation();
            logic.StartProcess();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            logic.Reset();
        }

        private void TrackBarSpeed_Scroll(object sender, EventArgs e)
        {
            logic.sleepTime = 3 + 10 * trackBarSpeed.Value;
        }

        private void NumericUpDownCount_ValueChanged(object sender, EventArgs e)
        {
            logic.nSoldiers = (int)numericUpDownCount.Value;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            logic.Reset();
        }
    }
}
