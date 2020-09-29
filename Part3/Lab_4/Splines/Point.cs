using System;
using System.Drawing;

namespace Splines
{
    internal class Point : IDraw
    {
        public int X { get; }
        public int Y { get; }

        public double Df { get; set; }
        public double Ddf { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics canvas)
        {
            double angleDf = Math.Atan(Df);

            canvas.DrawLine(new Pen(Color.Blue), 
                (int)(X - Math.Cos(angleDf) * 50)+150, 150 - (int)(Y - Math.Sin(angleDf) * 50),
                (int)(X + Math.Cos(angleDf) * 50)+150, 150 - (int)(Y + Math.Sin(angleDf) * 50)
                );
            canvas.DrawEllipse(new Pen(Color.Blue, 3), new Rectangle(X - 2+150, 150 - Y - 2, 4, 4));

        }
    }
}
