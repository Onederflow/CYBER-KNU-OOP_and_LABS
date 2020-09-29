using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab3
{
    public struct my_rule
    {
        public string state;
        public Color color;
        public Color next_color;
        public int course;
        public string next_state;
    }

    public class termite
    {
        public int x;
        public int y;
        public int course;
        public string state;

        public int speed = 1;
        public int x_max = 0;
        public int y_max = 0;

        public PictureBox matrix;
        public Bitmap bitmapx;
        private int count_rules = 0;
        public int count_steps = 0;
        private my_rule[] rules = new my_rule[100];

        private Thread[] thr;


        public void add_rule(string state, Color color, Color next_color, int course, string next_state)
        {
            rules[count_rules].state = state;
            rules[count_rules].color = color;
            rules[count_rules].next_color = next_color;
            rules[count_rules].course = course;
            rules[count_rules].next_state = next_state;
            count_rules++;
        }

        public void init(int width, int height)
        {
            x_max = width;
            y_max = height;

            x = x_max / 2;
            y = y_max / 2;
            course = 0;
            if (count_rules != 0)
            {
                state = rules[0].state;
                Bitmap new_z = new Bitmap(width, height);
                Graphics gs = Graphics.FromImage(new_z);
                gs.Clear(rules[0].color);
                matrix.Image = new_z;
            }
            bitmapx = matrix.Image as Bitmap;
        }

        private void change_course(int where)
        {
            int res = course;

            res += where;
            if (res > 3)
                res = 0;
            if (res < 0)
                res = 3;
            course = res;
        }

        private void change_xy()
        {
            if (course == 0)
                y--;
            if (course == 1)
                x--;
            if (course == 2)
                y++;
            if (course == 3)
                x++;

            if (x >= x_max)
                x = 0;
            if (x < 0)
                x = x_max - 1;
            if (y >= y_max)
                y = 0;
            if (y < 0)
                y = y_max - 1;
        }

        private void move(my_rule r)
        {
            bitmapx.SetPixel(x, y, r.next_color);
            change_course(r.course);
            change_xy();
            state = r.next_state;
            count_steps++;
        }

        public bool next_step()
        {
            bool res = true;
            for (int n = 0; n < speed; n++)
            {
                int i = 0;
                while (i < count_rules && i != -1)
                {
                    if (state == rules[i].state && bitmapx.GetPixel(x, y) == rules[i].color)
                    {

                        move(rules[i]);
                        i = -1;
                    }
                    else
                        i++;
                };
                if (i == count_rules)
                    res = false;
            }
            matrix.Image = bitmapx;
            return res;
        }
    }
}
