using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using System.IO;
namespace Lab1
{
    public partial class Form1 : Form
    {
        public OpenGL gl;
        public MyGl mgl = new MyGl();

        public int wx = 0;
        public int wy = 0;

        public int nx = 0;
        public int ny = 0;
        public bool adding = false;
        public figure[] mathfig = new figure[100];
        public int count = 0;
        public int selected = -1;
        public bool isdown = false;

        public float true_start_figure_X;
        public float true_start_figure_Y;
        public float true_start_figure_A;
        public float true_start_figure_B;
        public bool first_init = false;

        public MouseButtons t_event = MouseButtons.None;

        public void SetMaterial(float[] color)
        {
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, color);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, color);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, color);
        }

        public void DrawRoom()
        {
            SetMaterial(new float[4] { 0.92f, 0.92f, 0.92f, 1 });
            //back
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(15.0f, -10.0f, -40.0f);
            gl.Vertex(15.0f, 10.0f, -40.0f);
            gl.Vertex(-15.0f, 10.0f, -40.0f);
            gl.Vertex(-15.0f, -10.0f, -40.0f);
            gl.End();

            SetMaterial(new float[4] { 0.88f, 0.88f, 0.88f, 1 });
            //right
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(15.0f, -10.0f, 0.0f);
            gl.Vertex(15.0f, 10.0f, 0.0f);
            gl.Vertex(15.0f, 10.0f, -40.0f);
            gl.Vertex(15.0f, -10.0f, -40.0f);
            gl.End();

            //left
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(-15.0f, -10.0f, 0.0f);
            gl.Vertex(-15.0f, 10.0f, 0.0f);
            gl.Vertex(-15.0f, 10.0f, -40.0f);
            gl.Vertex(-15.0f, -10.0f, -40.0f);
            gl.End();

            SetMaterial(new float[4] { 0.83f, 0.83f, 0.83f, 1 });
            //top
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(15.0f, 10.0f, 0.0f);
            gl.Vertex(15.0f, 10.0f, -40.0f);
            gl.Vertex(-15.0f, 10.0f, -40.0f);
            gl.Vertex(-15.0f, 10.0f, 0.0f);
            gl.End();

            //bottom
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(15.0f, -10.0f, 0.0f);
            gl.Vertex(15.0f, -10.0f, -40.0f);
            gl.Vertex(-15.0f, -10.0f, -40.0f);
            gl.Vertex(-15.0f, -10.0f, 0.0f);
            gl.End();
        } 

        public void SetParamsAsFigure(figure now)
        {
            textBox_x.Text = now.x.ToString();
            trackBar_x.Value = (int)(now.x * 10.0f);

            textBox_y.Text = now.y.ToString();
            trackBar_y.Value = (int)(now.y * 10.0f);

            textBox_z.Text = (-now.z).ToString();
            trackBar_z.Value = -(int)(now.z * 10.0f);

            textBox_a.Text = now.alpha.ToString();
            trackBar_a.Value = (int)(now.alpha);

            textBox_b.Text = now.beta.ToString();
            trackBar_b.Value = (int)(now.beta);

            if(now.name == "cylinder")
            {
                radioButton_cylinder.Checked = true;
                radioButton_cone.Checked = false;
            };
            if (now.name == "cone")
            {
                radioButton_cylinder.Checked = false;
                radioButton_cone.Checked = true;
            }

            textBox_h.Text = now.height.ToString();
            trackBar_h.Value = (int)(now.height * 10.0f);
            textBox_r.Text = now.width.ToString();
            trackBar_r.Value = (int)(now.width * 10.0f);

            button_color_gr.BackColor = now.cbase;
            button_color_sn.BackColor = now.csurface;
        }

        public int FoundFigure(int x, int y)
        {
            int res = -1;
            double[] temp = gl.UnProject(x, y, 0);

            for(int i = 0; i < count; i++)
            {
                float pers_x_start = (float)temp[0] * (100 + (-(float)mathfig[i].z) * 10);
                float pers_y_start = (float)temp[1] * (100 + (-(float)mathfig[i].z) * 10);

                double radius = Math.Sqrt(mathfig[i].height * mathfig[i].height + mathfig[i].width * mathfig[i].width);
                double road = Math.Sqrt((pers_x_start - mathfig[i].x) * (pers_x_start - mathfig[i].x) + (pers_y_start - mathfig[i].y)*(pers_y_start - mathfig[i].y));

                if (road <= radius/2)
                    res = i;
            }
            return res;
        }

        public void MoveFigure()
        {
            double[] temp = gl.UnProject(wx, wy, 0);
            float start_x_start = (float)temp[0] * (100 + (-(float)mathfig[selected].z) * 10);
            float start_y_start = (float)temp[1] * (100 + (-(float)mathfig[selected].z) * 10);

            temp = gl.UnProject(nx, ny, 0);

            float pers_x_start = (float)temp[0] * (100 + (-(float)mathfig[selected].z) * 10);
            float pers_y_start = (float)temp[1] * (100 + (-(float)mathfig[selected].z) * 10);

            mathfig[selected].x = true_start_figure_X - start_x_start + pers_x_start;
            mathfig[selected].y = true_start_figure_Y - start_y_start + pers_y_start;
        }
        public void RotateFigure()
        {
            double[] temp = gl.UnProject(wx, wy, 0);
            float start_x_start = (float)temp[0] * (100 + (-(float)mathfig[selected].z) * 10);
            float start_y_start = (float)temp[1] * (100 + (-(float)mathfig[selected].z) * 10);

            temp = gl.UnProject(nx, ny, 0);

            float pers_x_start = (float)temp[0] * (100 + (-(float)mathfig[selected].z) * 10);
            float pers_y_start = (float)temp[1] * (100 + (-(float)mathfig[selected].z) * 10);

            float new_a = true_start_figure_A + (pers_y_start - start_y_start)*60;
            if (new_a > 180)
                new_a = new_a - 360;
            if (new_a < -180)
                new_a = 360 + new_a;

            float new_b = true_start_figure_B + (start_x_start - pers_x_start) *50;
            if (new_b > 180)
                new_b = new_b - 360;
            if (new_b < -180)
                new_b = 360 + new_b;

            mathfig[selected].beta = new_b;
            mathfig[selected].alpha = new_a;
        }

        public void delete_figure(int now)
        {
            for(int i = now; i < count -1; i++)
            {
                mathfig[i] = mathfig[i + 1];
            }
            count--;
        }

        public void write_to_file()
        {
            string path = @"D:\GitHub\Study\OOP\Term 4\Laboratory\Lab1\Lab1\Data.cyb";

            try
            {
                // создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    // записываем в файл значение каждого поля структуры
                    writer.Write(count);
                    for(int i = 0; i < count; i++)
                    {
                        writer.Write((double)mathfig[i].alpha);
                        writer.Write((double)mathfig[i].beta);

                        writer.Write(mathfig[i].cbase.A);
                        writer.Write(mathfig[i].cbase.R);
                        writer.Write(mathfig[i].cbase.G);
                        writer.Write(mathfig[i].cbase.B);

                        writer.Write(mathfig[i].csurface.A);
                        writer.Write(mathfig[i].csurface.R);
                        writer.Write(mathfig[i].csurface.G);
                        writer.Write(mathfig[i].csurface.B);
                        writer.Write((double)mathfig[i].height);
                        writer.Write((double)mathfig[i].width);
                        writer.Write((double)mathfig[i].x);
                        writer.Write((double)mathfig[i].y);
                        writer.Write((double)mathfig[i].z);
                        writer.Write(mathfig[i].name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void read_from_file()
        {
            string path = @"D:\GitHub\Study\OOP\Term 4\Laboratory\Lab1\Lab1\Data.cyb";

            try
            {
                // создаем объект BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    count = reader.ReadInt32();
                    Console.WriteLine("count = " + count);
                    for (int i = 0; i < count; i++)
                    {
                        mathfig[i].alpha = (float)reader.ReadDouble();
                        mathfig[i].beta = (float)reader.ReadDouble();
                        byte temp_a = reader.ReadByte();
                        byte temp_r = reader.ReadByte();
                        byte temp_g = reader.ReadByte();
                        byte temp_b = reader.ReadByte();

                        mathfig[i].cbase = Color.FromArgb(temp_a, temp_r, temp_g, temp_b);

                        temp_a = reader.ReadByte();
                        temp_r = reader.ReadByte();
                        temp_g = reader.ReadByte();
                        temp_b = reader.ReadByte();

                        mathfig[i].csurface = Color.FromArgb(temp_a, temp_r, temp_g, temp_b);

                        mathfig[i].height = (float)reader.ReadDouble();
                        mathfig[i].width = (float)reader.ReadDouble();
                        mathfig[i].x = (float)reader.ReadDouble();
                        mathfig[i].y = (float)reader.ReadDouble();
                        mathfig[i].z = (float)reader.ReadDouble();
                        mathfig[i].name = reader.ReadString();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public Form1()
        {
            InitializeComponent();
            gl = openGLControl1.OpenGL;
            mgl.gl = openGLControl1.OpenGL;
        }
        
        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openGLControl1_GDIDraw(object sender, RenderEventArgs args)
        {

        }


        public void DrawAll()
        {
            //Установка проекційної матриці
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //Очистка Матриці
            gl.LoadIdentity();

            //Установка перспективи
            gl.Perspective(trackBar_perspective.Value, (float)openGLControl1.Width / (float)openGLControl1.Height, 0.1, 100);
         
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();
            
            //Установка глибини, освітлення
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            //Очищення 
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);


            //Установка пера далі
            gl.Translate(0.0f, 0.0f, -10.1f);


            // СВЕТ, КАМЕРА, БЛЕТ БУНД
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);

            float[] ambient = { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] position = { 200.0f, 300.0f, 100.0f, 0.0f };

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, specular);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, position);

            float[] shininess = new float[1] {90};
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, shininess);

            // Боль клаустрофоба
            DrawRoom();

            // think about it
            if (selected >= 0 && selected < count)
            {
                mathfig[selected].z = -(float)System.Convert.ToDouble(textBox_z.Text);

                mathfig[selected].alpha = (float)System.Convert.ToDouble(textBox_a.Text);
                mathfig[selected].beta = (float)System.Convert.ToDouble(textBox_b.Text);

                mathfig[selected].csurface = button_color_sn.BackColor;
                mathfig[selected].cbase = button_color_gr.BackColor;

                if (radioButton_cylinder.Checked == true)
                    mathfig[selected].name = "cylinder";
                if (radioButton_cone.Checked == true)
                    mathfig[selected].name = "cone";

                mathfig[selected].height = (float)System.Convert.ToDouble(textBox_h.Text);
                mathfig[selected].width = (float)System.Convert.ToDouble(textBox_r.Text);
            };
            if (adding && isdown)
            {
                double[] res = gl.UnProject(nx,ny, 0);
                Console.WriteLine();
                Console.WriteLine("now");

                float pers_x_now = (float)res[0] * (100 + (-(float)mathfig[selected].z) * 10);
                float pers_y_now = (float)res[1] * (100 + (-(float)mathfig[selected].z) * 10);

                Console.WriteLine(res[0]);
                Console.WriteLine(pers_x_now);
                Console.WriteLine(res[1]);
                Console.WriteLine(pers_y_now);

                res = gl.UnProject(wx, wy, 0);
                Console.WriteLine("start");

                float pers_x_start = (float)res[0] * (100 + (-(float)mathfig[selected].z) * 10);
                float pers_y_start = (float)res[1] * (100 + (-(float)mathfig[selected].z) * 10);

                Console.WriteLine(res[0]);
                Console.WriteLine(pers_x_start);
                Console.WriteLine(res[1]);
                Console.WriteLine(pers_y_start);

                if(Math.Abs(pers_x_start - pers_x_now) <= 10.0)
                    mathfig[selected].width = Math.Abs(pers_x_start - pers_x_now);
                mathfig[selected].height = Math.Abs(pers_y_start - pers_y_now);
                mathfig[selected].x = (pers_x_start + pers_x_now) / 2;
                mathfig[selected].y = (pers_y_start + pers_y_now) / 2;

                SetParamsAsFigure(mathfig[selected]);
            }
            else
            {
                if (isdown)
                {
                    if(first_init)
                    {
                        selected = FoundFigure(nx, ny);
                        if (selected != -1)
                        {
                            true_start_figure_X = mathfig[selected].x;
                            true_start_figure_Y = mathfig[selected].y;
                            true_start_figure_A = mathfig[selected].alpha;
                            true_start_figure_B = mathfig[selected].beta;
                        };
                        first_init = false;
                    }
                    if (selected != -1)
                    {
                        

                        if(t_event == MouseButtons.Left)
                            MoveFigure();
                        if (t_event == MouseButtons.Right)
                            RotateFigure();
                        SetParamsAsFigure(mathfig[selected]);
                    }
                }
            }



            for (int i = 0; i < count; i++)
            {
                gl.LoadIdentity();
                gl.Translate(0.0f, 0.0f, -10.1f);
                mgl.DrawFigure(mathfig[i]);
            };
            if (selected != -1)
            {
                gl.LoadIdentity();
                gl.Translate(0.0f, 0.0f, -10.1f);
                mgl.DrawLines(mathfig[selected]);

                gl.LoadIdentity();
                gl.Translate(0.0f, 0.0f, -10.1f);
                label_info.Text =  (mgl.DrawProjectionLR(mathfig[selected])*180.0/Math.PI).ToString();
                gl.LoadIdentity();
                gl.Translate(0.0f, 0.0f, -10.1f);
                label_info.Text = (mgl.DrawProjection(mathfig[selected]) * 180.0 / Math.PI).ToString();
                gl.LoadIdentity();
                gl.Translate(0.0f, 0.0f, -10.1f);
                label_info.Text = (mgl.DrawProjectionTB(mathfig[selected]) * 180.0 / Math.PI).ToString();
            }
            gl.End();


        }
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            DrawAll();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Left == 280)
            {
                panel_setting.Left = -280;
                pictureBox1.Left = 0;
            }
            else
            if (pictureBox1.Left == 0)
            {
                panel_setting.Left = 0;
                pictureBox1.Left = 280;
            }
        }

        bool isfloat()
        {
            bool res = true;
            return res;
        }

        private void trackBar_perspective_Scroll(object sender, EventArgs e)
        {
            numericUpDown_perspective.Value = trackBar_perspective.Value;
        }

        private void numericUpDown_perspective_ValueChanged(object sender, EventArgs e)
        {
            trackBar_perspective.Value = (int)numericUpDown_perspective.Value;
        }

        private void trackBar_x_Scroll(object sender, EventArgs e)
        {
            textBox_x.Text = ((float)trackBar_x.Value / 10.0f).ToString();
        }

        private void textBox_x_TextChanged(object sender, EventArgs e)
        {
            trackBar_x.Value = (int)(System.Convert.ToDouble(textBox_x.Text) * 10.0);

            if (selected >= 0 && selected < count)
            {
                mathfig[selected].x = (float)System.Convert.ToDouble(textBox_x.Text);
            }
        }


        private void trackBar_y_Scroll(object sender, EventArgs e)
        {
            textBox_y.Text = ((float)trackBar_y.Value / 10.0f).ToString();
        }
        private void textBox_y_TextChanged(object sender, EventArgs e)
        {
            trackBar_y.Value = (int)(System.Convert.ToDouble(textBox_y.Text) * 10.0);
            if (selected >= 0 && selected < count)
            {
                mathfig[selected].y = (float)System.Convert.ToDouble(textBox_y.Text);
            }
        }

        private void trackBar_z_Scroll(object sender, EventArgs e)
        {
            textBox_z.Text = ((float)trackBar_z.Value / 10.0f).ToString();
        }
        private void textBox_z_TextChanged(object sender, EventArgs e)
        {
            trackBar_z.Value = (int)(System.Convert.ToDouble(textBox_z.Text) * 10.0);
        }

        private void trackBar_a_Scroll(object sender, EventArgs e)
        {
            textBox_a.Text = ((float)trackBar_a.Value).ToString();
        }

        private void trackBar_b_Scroll(object sender, EventArgs e)
        {
            textBox_b.Text = ((float)trackBar_b.Value).ToString();
        }


        private void textBox_a_TextChanged(object sender, EventArgs e)
        {
            trackBar_a.Value = (int)(System.Convert.ToDouble(textBox_a.Text));
        }

        private void textBox_b_TextChanged(object sender, EventArgs e)
        {
            trackBar_b.Value = (int)(System.Convert.ToDouble(textBox_b.Text));
        }

        private void button_color_gr_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button_color_gr.BackColor = colorDialog1.Color;
        }

        private void button_color_sn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button_color_sn.BackColor = colorDialog1.Color;
        }

        private void trackBar_h_Scroll(object sender, EventArgs e)
        {
            textBox_h.Text = ((float)trackBar_h.Value / 10.0).ToString();
        }

        private void textBox_h_TextChanged(object sender, EventArgs e)
        {
            trackBar_h.Value = (int)(System.Convert.ToDouble(textBox_h.Text) * 10);
        }

        private void textBox_r_TextChanged(object sender, EventArgs e)
        {
            trackBar_r.Value = (int)(System.Convert.ToDouble(textBox_r.Text) * 10);
        }

        private void trackBar_r_Scroll(object sender, EventArgs e)
        {
            textBox_r.Text = ((float)trackBar_r.Value / 10.0).ToString();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            mathfig[count] = new figure();
            selected = (int)count;
            count++;

            mathfig[selected].x = 0;
            mathfig[selected].y = 0;
            mathfig[selected].z = 0;
            mathfig[selected].name = "cylinder";
            mathfig[selected].cbase = Color.Blue;
            mathfig[selected].csurface = Color.Yellow;
            mathfig[selected].alpha = -90;
            mathfig[selected].beta = 0;
            mathfig[selected].height = 0;
            mathfig[selected].width = 0;

            SetParamsAsFigure(mathfig[selected]);

            adding = true;
        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= 0 && e.X < openGLControl1.Width)
                wx = e.X;
            if (e.Y >= 0 && e.Y < openGLControl1.Height)
                wy = openGLControl1.Height - e.Y;
            nx = wx;
            ny = wy;
            t_event = e.Button;
            first_init = true;
            isdown = true;

        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.X >= 0 && e.X < openGLControl1.Width)
                nx = e.X;
            if (e.Y >= 0 && e.Y < openGLControl1.Height)
                ny = openGLControl1.Height - e.Y;            
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            adding = false;
            isdown = false;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if(selected != -1)
            {
                delete_figure(selected);
                selected = -1;
            }
        }

        private void button_to_file_Click(object sender, EventArgs e)
        {
            write_to_file();
        }

        private void button_read_Click(object sender, EventArgs e)
        {
            read_from_file();
        }
    }
}
