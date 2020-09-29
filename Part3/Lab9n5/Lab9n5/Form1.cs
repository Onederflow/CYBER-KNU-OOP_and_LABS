using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9n5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Matrix A;
        Matrix B;

        MyMainThreading ThreadTool;

        private void button1_Click(object sender, EventArgs e)
        {
            Matrix A = new Matrix(31, 31);
            Matrix B = new Matrix(31, 31);
            //A.data = new int[3,2]{{2,5},{-3,4},{ 1,-2}};
            //B.data = new int[2, 3] { { -7, 2, 4 }, { 5, -1, 3 } };
            for(int i = 0; i< 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    A.data[i, j] = 1;
                    B.data[i, j] = 1;
                }
            }

            A.Print();
            Console.WriteLine();
            B.Print();
            ThreadTool = new MyMainThreading(A, B, 6);
            Matrix res = ThreadTool.Start();
            Console.WriteLine();
            res.Print();
        }
    }
}
