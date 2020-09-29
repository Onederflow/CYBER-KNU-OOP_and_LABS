using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab_3
{
    class Graph
    {
        public PictureBox pb;
        public Graphics gs;
        public PageRank data;
        public int[,] adjacency_matrix;
        public int count = 2;

        public int selected = -1;

        private int radius = 40;
        private int main_ragius = 0;
        private int center_x;
        private int center_y;

        private Pen pen_line = new Pen(Color.FromArgb(255, 201, 101, 40));
        private Pen pen_node = new Pen(Color.FromArgb(255, 3, 22, 52));
        private Brush brush_node = new SolidBrush(Color.FromArgb(255,3,54,73));
        private Brush brush_clear = new SolidBrush(Color.FromArgb(255,232,221,203));
        private Brush brush_line = new SolidBrush(Color.FromArgb(255, 201, 101, 40));
        private Brush brush_text = new SolidBrush(Color.Gray);
        private Font font_text;
        private Font font_text2;


        private void Update()
        {
            pb.Invalidate();
            pb.Update();
        }

        public Graph(PictureBox newpb)
        {
            Bitmap flag = new Bitmap(newpb.Width, newpb.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            flagGraphics.FillRectangle(brush_clear, 0, 0, newpb.Width, newpb.Height);
            pb = newpb;
            pb.Image = flag;
            gs = Graphics.FromImage(pb.Image);

            if (pb.Width > pb.Height)
                main_ragius = pb.Height / 2 - 80;
            else main_ragius = pb.Width / 2 - 80;

            center_x = pb.Width / 2;
            center_y = pb.Height / 2;

            pen_node.Width = 4;
            pen_line.Width = 2;

            font_text = new Font("Arial", 8, FontStyle.Regular);
            font_text2 = new Font("Arial", 24, FontStyle.Regular);

            adjacency_matrix = new int[20, 20];
        }

        private void DrawNode(int i, int left, int top, bool more_now)
        {
            gs.FillEllipse(brush_node, left - radius, top - radius, 2 * radius, 2 * radius);
            if (more_now)
            {
                Pen temp = new Pen(Color.Orange);
                temp.Width = 5;
                gs.DrawEllipse(temp, left - radius - 1, top - radius - 1, 2 * radius + 2, 2 * radius + 2);
            }
            else
            gs.DrawEllipse(pen_node, left - radius, top - radius, 2 * radius, 2 * radius);
            gs.DrawString("№" + (i + 1).ToString(), font_text, brush_text, left - 6, top - 30);
            if(data != null && data.X != null && data.X.Length > i)
            gs.DrawString((data.X[i]).ToString(), font_text2, brush_text, left - 30, top - 8);

        }
        private double AbsoluteAngle(int x1, int y1, int x2, int y2)
        {
            double angle = Math.Atan2(y1 - y2, x1 - x2);
            return angle;
        }
        private int AbsolutePosX(int i)
        {
            double angle = 2 * Math.PI * (double)i / (double)count;
            return center_x + (int)(Math.Sin(angle) * main_ragius);
        }
        private int AbsolutePosY(int i)
        {
            double angle = 2 * Math.PI * (double)i / (double)count;
            return center_y - (int)(Math.Cos(angle) * main_ragius);
        }
        private int RotatePosX(double tangle, int tradius, int x, bool up)
        {
            double angle;
            if (up)
                angle = tangle + Math.PI / 20d;
            else
                angle = tangle - Math.PI / 20d;
            return x - (int)(Math.Cos(angle) * tradius);
        }
        private int RotatePosY(double tangle, int tradius, int y, bool up)
        {
            double angle;
            if (up)
                angle = tangle + Math.PI / 20d;
            else
                angle = tangle - Math.PI / 20d;
            return y - (int)(Math.Sin(angle) * tradius);
        }
        private int RotatePosX(double tangle, int tradius, int x)
        {
            return x - (int)(Math.Cos(tangle) * tradius);
        }
        private int RotatePosY(double tangle, int tradius, int y)
        {
            return y - (int)(Math.Sin(tangle) * tradius);
        }
        public void DrawTriangle(int x, int y, double angle)
        {
            Point[] triangle = new Point[4];
            triangle[0].X = RotatePosX(angle, 8, x);
            triangle[0].Y = RotatePosY(angle, 8, y);
            triangle[1].X = RotatePosX(angle + 2 * Math.PI / 3, 8, x);
            triangle[1].Y = RotatePosY(angle + 2 * Math.PI / 3, 8, y);
            triangle[2].X = RotatePosX(angle  - 2 * Math.PI / 3, 8, x);
            triangle[2].Y = RotatePosY(angle  - 2 * Math.PI / 3, 8, y);
            triangle[3].X = RotatePosX(angle, 8, x);
            triangle[3].Y = RotatePosY(angle, 8, y);
            gs.FillPolygon(brush_line, triangle);
        }
        public void DrawAllGraphics()
        {
            gs.Clear(Color.FromArgb(255, 232, 221, 203));
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                    if (i != j && adjacency_matrix[i,j] != 0)
                    {
                        int node_1_x = AbsolutePosX(i);
                        int node_1_y = AbsolutePosY(i);
                        int node_2_x = AbsolutePosX(j);
                        int node_2_y = AbsolutePosY(j);
                        double angle = AbsoluteAngle(node_1_x, node_1_y, node_2_x, node_2_y);

                        if (adjacency_matrix[j, i] == 0)
                        {
                            int new_x_1 = RotatePosX(angle, radius + 3, node_1_x);
                            int new_y_1 = RotatePosY(angle, radius + 3, node_1_y);
                            int new_x_2 = RotatePosX(angle + Math.PI, radius + 10, node_2_x);
                            int new_y_2 = RotatePosY(angle + Math.PI, radius + 10, node_2_y);
                            gs.DrawLine(pen_line, new_x_1, new_y_1, new_x_2, new_y_2);
                            DrawTriangle(new_x_2, new_y_2,angle);
                        }
                        else if (i < j)
                        {
                            int new_x_1 = RotatePosX(angle, radius + 3, node_1_x, true);
                            int new_y_1 = RotatePosY(angle, radius + 3, node_1_y, true);
                            angle += Math.PI;
                            int new_x_2 = RotatePosX(angle, radius + 10, node_2_x, false);
                            int new_y_2 = RotatePosY(angle, radius + 10, node_2_y, false);
                            gs.DrawLine(pen_line, new_x_1, new_y_1, new_x_2, new_y_2);
                            DrawTriangle(new_x_2, new_y_2, angle - Math.PI);

                            angle = AbsoluteAngle(node_1_x, node_1_y, node_2_x, node_2_y);
                            new_x_1 = RotatePosX(angle, radius + 10, node_1_x, false);
                            new_y_1 = RotatePosY(angle, radius + 10, node_1_y, false);
                            angle += Math.PI;
                            new_x_2 = RotatePosX(angle, radius + 3, node_2_x, true);
                            new_y_2 = RotatePosY(angle, radius + 3, node_2_y, true);
                            gs.DrawLine(pen_line, new_x_1, new_y_1, new_x_2, new_y_2);
                            DrawTriangle(new_x_1, new_y_1, angle);
                        }
                    };

            for (int i = 0; i < count; i++)
                if (i != selected)
                    DrawNode(i, AbsolutePosX(i), AbsolutePosY(i), false);
                else
                    DrawNode(i, AbsolutePosX(i), AbsolutePosY(i), true);

            Update();
        }

        public int Select(int x, int y)
        {
            int res = -1;
            for (int i = 0; i < count; i++)
            {
                int abs_x = AbsolutePosX(i);
                int abs_y = AbsolutePosY(i);
                if (Math.Abs(x - abs_x) <= radius && Math.Abs(y - abs_y) <= radius)
                    return i;
            };
            return res;
        }

        public void NewClick(MouseEventArgs e)
        {
            int new_select = Select(e.X, e.Y);
            if (selected == -1)
                selected = new_select;
            else
            {
                if(selected != new_select && new_select != -1)
                {
                    if(e.Button == MouseButtons.Left)
                        adjacency_matrix[selected, new_select] = 1;
                    if (e.Button == MouseButtons.Right)
                        adjacency_matrix[selected, new_select] = 0;
                }
                selected = -1;
            }
        }

        public void GraphToLogic()
        {
            data.A = new double[count, count];
            data.X = new double[count];
            data.rank = count;
            data.X[0] = 1;
            for (int i = 0; i < count; i++)
            {
                int summ = 0;
                for (int j = 0; j < count; j++)
                    if (i != j && adjacency_matrix[i, j] != 0)
                        summ++;
                for (int j = 0; j < count; j++)
                    if (i != j && adjacency_matrix[i, j] != 0)
                        data.A[i, j] = 1.0d / (double)summ;
            }
        }

        public void Clear()
        {
            adjacency_matrix = new int[20, 20];
            DrawAllGraphics();
            Update();
        }
    }

}
