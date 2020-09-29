using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Splines
{
    class CArtInstruments
    {
        public Pen line = new Pen(Color.FromArgb(255, 201, 101, 40));
        public Brush node = new SolidBrush(Color.FromArgb(255, 3, 54, 73));
        public Brush text = new SolidBrush(Color.Black);
        public Font ftext = new Font("Lucida Console", 8, FontStyle.Regular);

    }
    public class TheGraphics
    {
        Graphics canvas;
        private int height;
        private int width;
        private int center_x;
        private int center_y;

        private int des = 50;
        CArtInstruments ArtInstruments = new CArtInstruments();
        public TheGraphics(Graphics new_canvas, int i_height, int i_width)
        {
            height = i_height;
            width = i_width;
            center_y = i_height / 2;
            center_x = i_width / 2;
            canvas = new_canvas;
        }
        private void DrawCords(int stroke)
        {
            int count_y = (height) / des;
            int count_x = (width) / des;
            canvas.DrawLine(ArtInstruments.line, 10, center_y, width - 10, center_y);
            canvas.DrawLine(ArtInstruments.line, center_x, 10, center_x, height - 10);

            canvas.DrawLine(ArtInstruments.line, width - 10, center_y, width - 15, center_y + 5);
            canvas.DrawLine(ArtInstruments.line, width - 10, center_y, width - 15, center_y - 5);
            canvas.DrawLine(ArtInstruments.line, center_x, 10, center_x - 5, 15);
            canvas.DrawLine(ArtInstruments.line, center_x, 10, center_x + 5, 15);


            for (int i = 0; i < count_y; i++)
            {
                canvas.DrawLine(ArtInstruments.line, center_x - stroke / 2, center_y - des * (count_y / 2 - i), center_x + stroke / 2, center_y - des * (count_y / 2 - i));
                if(des * (count_y / 2 - i) != 0)
                    canvas.DrawString((des * (count_y / 2 - i)).ToString(), ArtInstruments.ftext, ArtInstruments.text, center_x + stroke / 2 + 4, center_y - des * (count_y / 2 - i) - 4);
            }
            for (int i = 0; i < count_x; i++)
            {
                canvas.DrawLine(ArtInstruments.line, center_x - des * (count_x / 2 - i), center_y - stroke / 2, center_x - des * (count_x / 2 - i), center_y + stroke / 2);
                if (des * (count_x / 2 - i) != 0)
                    canvas.DrawString((-des * (count_x / 2 - i)).ToString(), ArtInstruments.ftext, ArtInstruments.text, center_x - des * (count_x / 2 - i) - 4, center_y - stroke / 2 - 12);
            }
        }
        private void DrawNode(int x, int y)
        {
            canvas.FillEllipse(ArtInstruments.node, x - 3, y - 3, 6, 6);
        }
        public void DrawAll()
        {
            DrawCords(8);
        }
    }
}
