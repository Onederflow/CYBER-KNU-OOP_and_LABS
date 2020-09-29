using System;
using System.Drawing;
using System.Windows.Forms;

namespace Splines
{
    internal class CSplineSubinterval : IDraw
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public double D { get; }

        private readonly CPoint _p1;
        private readonly CPoint _p2;

        public CSplineSubinterval(CPoint p1, CPoint p2, double df, double ddf)
        {
            _p1 = p1;
            _p2 = p2;

            B = ddf;
            C = df;
            D = p1.Y;
            A = (_p2.Y - B * Math.Pow(_p2.X - _p1.X, 2) - C * (_p2.X - _p1.X) - D) / Math.Pow(_p2.X - _p1.X, 3);
        }

        public double F(int x)
        {
            return A * Math.Pow(x - _p1.X, 3) + B * Math.Pow(x - _p1.X, 2) + C * (x - _p1.X) + D;
        }

        public double Df(int x)
        {
            return 3 * A * Math.Pow(x - _p1.X, 2) + 2 * B * (x - _p1.X) + C;
        }

        public double Ddf(int x)
        {
            return 6 * A * (x - _p1.X) + 2 * B;
        }

        public void Draw(Graphics canvas)
        {
            Pen pen = new Pen(Color.Green, 1);

            for (int k = _p1.X; k < _p2.X; k++)
            {
                canvas.DrawLine(pen, k+150, 150 - (int)F(k), k + 1+150, 150 - (int)F(k + 1));
            }

            canvas.DrawLine(new Pen(Color.Black), 150, 0, 150, 300);
            canvas.DrawLine(new Pen(Color.Black), 0, 150, 300, 150);
            if (_p1.X < 25 && 25 < _p2.X)
            {
                canvas.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(25 + 150 - 2, 150 - (int)F(25) - 2, 4, 4));
                Brush b = new SolidBrush(Color.Black);
                Font f = new Font("Arial", 15);
                canvas.DrawString(Math.Round(F(25) / 10,5).ToString(), f, b, 40, 40);
            }
        }
    }
}
