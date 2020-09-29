using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SharpGL;
using SharpGL.OpenGLAttributes;

namespace Lab1
{   
    
    //фігура
    public struct figure
    {
        public string name;

        public float x;
        public float y;
        public float z;

        public float height;
        public float width;

        public float alpha;
        public float beta;

        public Color cbase;
        public Color csurface;


    }

    public class MyGl
    {
        public OpenGL gl;
        //open GL
        public void DrawLines(figure now)
        {
            float morethan = 2.0f;
            gl.Translate(now.x, now.y, now.z);
            gl.Rotate(now.alpha, now.beta, 0.0f);

            float[] dif = { 250f, 0 , 0, 1f};
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, dif);

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0, 0, -now.height / 2 - morethan);
            gl.Vertex(0, 0, now.height / 2 + morethan);
            gl.End();


            float[] dif2 = {0, 250f, 0, 1f };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, dif2);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, dif2);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, dif2);
            gl.Rotate(90.0f, 0.0f, 0.0f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0, 0, -now.width / 2 - morethan);
            gl.Vertex(0, 0, now.width / 2 + morethan);
            gl.End();

            float[] dif3 = { 0, 0, 250f, 1f };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, dif3);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, dif3);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, dif3);
            gl.Color(0, 0, 255);
            gl.Rotate(0.0f, 90.0f, 0.0f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0, 0, -now.width / 2 - morethan);
            gl.Vertex(0, 0, now.width / 2 + morethan);
            gl.End();

            gl.End();
        }

        public float DrawProjection(figure now)
        {
            int countsegments = 50;

            IntPtr q = gl.NewQuadric();
            gl.Translate(now.x, now.y, -39.9f);

            gl.QuadricDrawStyle(q, OpenGL.GLU_FILL);
            //color of proection
            float[] dif = {1.0f, 0.1f, 0.1f, 1.0f};
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, dif);


            //кути в радіанах
            double t_alpha = Math.PI * now.alpha / 180.0f;
            double t_beta = Math.PI * now.beta / 180.0f;
            //вектор, який будемо повертати
            double[] tv = { 0, 0, 1 };
            //матриці повороту
            double[,] matrix_x = { { 1, 0, 0 }, { 0, Math.Cos(t_alpha), -Math.Sin(t_alpha) }, { 0, Math.Sin(t_alpha), Math.Cos(t_alpha) } };
            double[,] matrix_y = { { Math.Cos(t_beta), 0, Math.Sin(t_beta) }, { 0, 1, 0 }, { -Math.Sin(t_beta), 0, Math.Cos(t_beta) } };
            //повороти по осям
            double[] firstrotate = { tv[0] * matrix_x[0, 0] + tv[1] * matrix_x[0, 1] + tv[2] * matrix_x[0, 2], tv[0] * matrix_x[1, 0] + tv[1] * matrix_x[1, 1] + tv[2] * matrix_x[1, 2], tv[0] * matrix_x[2, 0] + tv[1] * matrix_x[2, 1] + tv[2] * matrix_x[2, 2] };
            double[] secondtrotate = { firstrotate[0] * matrix_y[0, 0] + firstrotate[1] * matrix_y[0, 1] + firstrotate[2] * matrix_y[0, 2], firstrotate[0] * matrix_y[1, 0] + firstrotate[1] * matrix_y[1, 1] + firstrotate[2] * matrix_y[1, 2], firstrotate[0] * matrix_y[2, 0] + firstrotate[1] * matrix_y[2, 1] + firstrotate[2] * matrix_y[2, 2] };

            //результат. кути відносно Z & OZ
            double back_sinres = (secondtrotate[2]);
            double back_tanres = 0;

            double one_a = 1;
            double one_b = 1;

            if (now.alpha > 0)
                one_a = -1;
            if (now.beta > 90 || (now.beta < 0 && now.beta > -90))
                one_b = -1;

            back_tanres = Math.Atan(Math.Abs(secondtrotate[0] / secondtrotate[1]) + Math.Abs(secondtrotate[0] / secondtrotate[2]));

            //if (now.beta < 0 && now.beta >= -90)
              //  back_tanres = -back_tanres;
            if (one_a * one_b == -1)
                back_tanres = Math.PI - back_tanres;
            if (now.beta < 0)
                back_tanres = back_tanres - Math.PI;
            
            if(now.alpha == 0 & now.beta == 0)
                back_tanres = 0;

            //поворот координат на кут фігури
            gl.Rotate(-180 * back_tanres / Math.PI, 0, 0, 20.0);
            gl.Translate(0, -now.height * (float)(Math.Cos(Math.Asin(back_sinres))) / 2, 0);

            //draw основу
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Normal(0, 0, 1.0f);
            for (int i = 0; i <= countsegments; i++)
            {
                float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                float dx = now.width * (float)Math.Cos(angle) / 2f;
                float dy = now.width * (float)back_sinres * (float)Math.Sin(angle) / 2f;
                gl.Vertex(dx, dy, 0.0f);
            }
            gl.End();

            
            if (now.name == "cylinder")
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                for (int i = 0; i <= countsegments; i++)
                {
                    float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                    float dx = now.width * (float)Math.Cos(angle) / 2f;
                    float dy = now.width * (float)back_sinres * (float)Math.Sin(angle) / 2f;
                    gl.Vertex(dx, dy + now.height * (float)(Math.Cos(Math.Asin(back_sinres))), 0.0f);
                }
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width/2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, now.height * (float)(Math.Cos(Math.Asin(back_sinres))), 0.0f);
                gl.Vertex(-now.width / 2, now.height * (float)(Math.Cos(Math.Asin(back_sinres))), 0.0f);
                gl.End();
            }
            else
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, 0.0f, 0.0f);
                gl.Vertex(0.0f, now.height * (float)(Math.Cos(Math.Asin(back_sinres))), 0.0f);
                gl.End();
            }
            


            gl.End();
            gl.DeleteQuadric(q);
            return (float)(back_tanres);
        }

        public float DrawProjectionLR(figure now)
        {
            int countsegments = 50;

            IntPtr q = gl.NewQuadric();
            gl.Translate(14.9f, now.y, now.z);

            gl.QuadricDrawStyle(q, OpenGL.GLU_FILL);
            //color of proection
            float[] dif = { 1.0f, 0.1f, 0.1f, 1.0f };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, dif);


            //кути в радіанах
            double t_alpha = Math.PI * now.alpha / 180.0f;
            double t_beta = Math.PI * now.beta / 180.0f;
            //вектор, який будемо повертати
            double[] tv = { 0, 0, 1 };
            //матриці повороту
            double[,] matrix_x = { { 1, 0, 0 }, { 0, Math.Cos(t_alpha), -Math.Sin(t_alpha) }, { 0, Math.Sin(t_alpha), Math.Cos(t_alpha) } };
            double[,] matrix_y = { { Math.Cos(t_beta), 0, Math.Sin(t_beta) }, { 0, 1, 0 }, { -Math.Sin(t_beta), 0, Math.Cos(t_beta) } };
            //повороти по осям
            double[] firstrotate = { tv[0] * matrix_x[0, 0] + tv[1] * matrix_x[0, 1] + tv[2] * matrix_x[0, 2], tv[0] * matrix_x[1, 0] + tv[1] * matrix_x[1, 1] + tv[2] * matrix_x[1, 2], tv[0] * matrix_x[2, 0] + tv[1] * matrix_x[2, 1] + tv[2] * matrix_x[2, 2] };
            double[] secondtrotate = { firstrotate[0] * matrix_y[0, 0] + firstrotate[1] * matrix_y[0, 1] + firstrotate[2] * matrix_y[0, 2], firstrotate[0] * matrix_y[1, 0] + firstrotate[1] * matrix_y[1, 1] + firstrotate[2] * matrix_y[1, 2], firstrotate[0] * matrix_y[2, 0] + firstrotate[1] * matrix_y[2, 1] + firstrotate[2] * matrix_y[2, 2] };

            double[] tv2 = {1, 0, 0 };
            double[] firstrotate2 = { tv2[0] * matrix_x[0, 0] + tv2[1] * matrix_x[0, 1] + tv2[2] * matrix_x[0, 2], tv2[0] * matrix_x[1, 0] + tv2[1] * matrix_x[1, 1] + tv2[2] * matrix_x[1, 2], tv2[0] * matrix_x[2, 0] + tv2[1] * matrix_x[2, 1] + tv2[2] * matrix_x[2, 2] };
            double[] secondtrotate2 = { firstrotate2[0] * matrix_y[0, 0] + firstrotate2[1] * matrix_y[0, 1] + firstrotate2[2] * matrix_y[0, 2], firstrotate2[0] * matrix_y[1, 0] + firstrotate2[1] * matrix_y[1, 1] + firstrotate2[2] * matrix_y[1, 2], firstrotate2[0] * matrix_y[2, 0] + firstrotate2[1] * matrix_y[2, 1] + firstrotate2[2] * matrix_y[2, 2] };


            //результат. кути відносно X & OX
            double back_sinres = secondtrotate2[0];
            double back_tanres = 0;
                
            back_tanres = Math.Atan(Math.Abs(secondtrotate[2] / secondtrotate[1]) + Math.Abs(secondtrotate[0] / secondtrotate[1]));


            if ((now.alpha <= 0 && now.alpha >= -90) || (now.alpha >= 90))
                back_tanres = -back_tanres;
            if (now.alpha > 0 )
                back_tanres = back_tanres - Math.PI;
            
            if (now.alpha == 0 & now.beta == 0)
                back_tanres = -Math.PI/2;

            //поворот координат на кут фігури
            gl.Rotate(90, 0, 20.0, 0);
            gl.Rotate(-180 * back_tanres / Math.PI, 0, 0, 20.0);
            gl.Translate(0, -now.height * back_sinres / 2, 0);

            //draw основу
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Normal(0, 0, 1.0f);
            for (int i = 0; i <= countsegments; i++)
            {
                float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                float dx = now.width * (float)Math.Cos(angle) / 2f;
                float dy = now.width * (float)(Math.Cos(Math.Asin(back_sinres))) * (float)Math.Sin(angle) / 2f;
                gl.Vertex(dx, dy, 0.0f);
            }
            gl.End();
            //left panel
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Normal(0, 0, 1.0f);
            for (int i = 0; i <= countsegments; i++)
            {
                float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                float dx = now.width * (float)Math.Cos(angle) / 2f;
                float dy = now.width * (float)(Math.Cos(Math.Asin(back_sinres))) * (float)Math.Sin(angle) / 2f;
                gl.Vertex(dx, dy, -29.8f);
            }
            gl.End();

            if (now.name == "cylinder")
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                for (int i = 0; i <= countsegments; i++)
                {
                    float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                    float dx = now.width * (float)Math.Cos(angle) / 2f;
                    float dy = now.width * (float)(Math.Cos(Math.Asin(back_sinres))) * (float)Math.Sin(angle) / 2f;
                    gl.Vertex(dx, dy + now.height * back_sinres, 0.0f);
                }
                gl.End();
                //left
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                for (int i = 0; i <= countsegments; i++)
                {
                    float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                    float dx = now.width * (float)Math.Cos(angle) / 2f;
                    float dy = now.width * (float)(Math.Cos(Math.Asin(back_sinres))) * (float)Math.Sin(angle) / 2f;
                    gl.Vertex(dx, dy + now.height * back_sinres, -29.8f);
                }
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, now.height * back_sinres, 0.0f);
                gl.Vertex(-now.width / 2, now.height * back_sinres, 0.0f);
                gl.End();
                //left
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, -29.8f);
                gl.Vertex(now.width / 2, 0.0f, -29.8f);
                gl.Vertex(now.width / 2, now.height * back_sinres, -29.8f);
                gl.Vertex(-now.width / 2, now.height * back_sinres, -29.8f);
                gl.End();
            }
            else
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, 0.0f, 0.0f);
                gl.Vertex(0.0f, now.height * back_sinres, 0.0f);
                gl.End();
                //left
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, -29.8f);
                gl.Vertex(now.width / 2, 0.0f, -29.8f);
                gl.Vertex(0.0f, now.height * back_sinres, -29.8f);
                gl.End();
            }



            gl.End();
            gl.DeleteQuadric(q);
            return (float)(back_tanres);
        }



        public float DrawProjectionTB(figure now)
        {
            int countsegments = 50;

            IntPtr q = gl.NewQuadric();
            gl.Translate(now.x, 9.9f, now.z);

            gl.QuadricDrawStyle(q, OpenGL.GLU_FILL);
            //color of proection
            float[] dif = { 1.0f, 0.1f, 0.1f, 1.0f };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, dif);


            //кути в радіанах
            double t_alpha = Math.PI * now.alpha / 180.0f;
            double t_beta = Math.PI * now.beta / 180.0f;
            //вектор, який будемо повертати
            double[] tv = { 0, 0, 1 };
            //матриці повороту
            double[,] matrix_x = { { 1, 0, 0 }, { 0, Math.Cos(t_alpha), -Math.Sin(t_alpha) }, { 0, Math.Sin(t_alpha), Math.Cos(t_alpha) } };
            double[,] matrix_y = { { Math.Cos(t_beta), 0, Math.Sin(t_beta) }, { 0, 1, 0 }, { -Math.Sin(t_beta), 0, Math.Cos(t_beta) } };
            //повороти по осям
            double[] firstrotate = { tv[0] * matrix_x[0, 0] + tv[1] * matrix_x[0, 1] + tv[2] * matrix_x[0, 2], tv[0] * matrix_x[1, 0] + tv[1] * matrix_x[1, 1] + tv[2] * matrix_x[1, 2], tv[0] * matrix_x[2, 0] + tv[1] * matrix_x[2, 1] + tv[2] * matrix_x[2, 2] };
            double[] secondtrotate = { firstrotate[0] * matrix_y[0, 0] + firstrotate[1] * matrix_y[0, 1] + firstrotate[2] * matrix_y[0, 2], firstrotate[0] * matrix_y[1, 0] + firstrotate[1] * matrix_y[1, 1] + firstrotate[2] * matrix_y[1, 2], firstrotate[0] * matrix_y[2, 0] + firstrotate[1] * matrix_y[2, 1] + firstrotate[2] * matrix_y[2, 2] };


            double[] tv2 = { 0, 0, 1 };
            double[] firstrotate2 = { tv2[0] * matrix_y[0, 0] + tv2[1] * matrix_y[0, 1] + tv2[2] * matrix_y[0, 2], tv2[0] * matrix_y[1, 0] + tv2[1] * matrix_y[1, 1] + tv2[2] * matrix_y[1, 2], tv2[0] * matrix_y[2, 0] + tv2[1] * matrix_y[2, 1] + tv2[2] * matrix_y[2, 2] };
            double[] secondtrotate2 = { firstrotate2[0] * matrix_x[0, 0] + firstrotate2[1] * matrix_x[0, 1] + firstrotate2[2] * matrix_x[0, 2], firstrotate2[0] * matrix_x[1, 0] + firstrotate2[1] * matrix_x[1, 1] + firstrotate2[2] * matrix_x[1, 2], firstrotate2[0] * matrix_x[2, 0] + firstrotate2[1] * matrix_x[2, 1] + firstrotate2[2] * matrix_x[2, 2] };


            //результат. кути відносно X & OX
            double back_sinres = Math.Cos(Math.Asin(secondtrotate2[1]));
            double back_tanres = 0;

            double xsr = secondtrotate[0] * secondtrotate[0] + secondtrotate[1] * secondtrotate[1] + secondtrotate[2] * secondtrotate[2];

            back_tanres = Math.PI/2 - Math.Atan(Math.Abs(secondtrotate[2] / secondtrotate[0]) + Math.Abs(secondtrotate[2] / secondtrotate[1]));

            if (now.beta < 90 || (now.beta >= 0 && now.beta < 90))
                back_tanres = -back_tanres;

            if (now.beta >= -90 && now.beta < 0)
                back_tanres = Math.PI - back_tanres;

            if (now.beta >= 0 && now.beta < 90)
                back_tanres = back_tanres - Math.PI;

            if (now.alpha < -90 || now.alpha > 90)
                back_tanres = Math.PI - back_tanres;
                

            if (now.alpha == 0 & now.beta == 0)
                back_tanres = Math.PI;

            //поворот координат на кут фігури
            gl.Rotate(-90, 20.0, 0, 0);
            gl.Rotate(-180 * back_tanres / Math.PI, 0, 0, 20.0f);
            gl.Translate(0, -now.height * back_sinres / 2, 0);

            //draw основу
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Normal(0, 0, 1.0f);
            for (int i = 0; i <= countsegments; i++)
            {
                float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                float dx = now.width * (float)Math.Cos(angle) / 2f;
                float dy = now.width * (float)(Math.Cos(Math.Asin(back_sinres))) * (float)Math.Sin(angle) / 2f;
                gl.Vertex(dx, dy, 0.0f);
            }
            gl.End();
            //buttom panel
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Normal(0, 0, 1.0f);
            for (int i = 0; i <= countsegments; i++)
            {
                float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                float dx = now.width * (float)Math.Cos(angle) / 2f;
                float dy = now.width * (float)(Math.Cos(Math.Asin(back_sinres))) * (float)Math.Sin(angle) / 2f;
                gl.Vertex(dx, dy, -19.8f);
            }
            gl.End();

            if (now.name == "cylinder")
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                for (int i = 0; i <= countsegments; i++)
                {
                    float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                    float dx = now.width * (float)Math.Cos(angle) / 2f;
                    float dy = now.width * (float)(Math.Cos(Math.Asin(back_sinres))) * (float)Math.Sin(angle) / 2f;
                    gl.Vertex(dx, dy + now.height * back_sinres, 0.0f);
                }
                gl.End();
                //buttom
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                for (int i = 0; i <= countsegments; i++)
                {
                    float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                    float dx = now.width * (float)Math.Cos(angle) / 2f;
                    float dy = now.width * (float)(Math.Cos(Math.Asin(back_sinres))) * (float)Math.Sin(angle) / 2f;
                    gl.Vertex(dx, dy + now.height * back_sinres, -19.8f);
                }
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, now.height * back_sinres, 0.0f);
                gl.Vertex(-now.width / 2, now.height * back_sinres, 0.0f);
                gl.End();
                //buttom
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, -19.8f);
                gl.Vertex(now.width / 2, 0.0f, -19.8f);
                gl.Vertex(now.width / 2, now.height * back_sinres, -19.8f);
                gl.Vertex(-now.width / 2, now.height * back_sinres, -19.8f);
                gl.End();
            }
            else
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, 0.0f);
                gl.Vertex(now.width / 2, 0.0f, 0.0f);
                gl.Vertex(0.0f, now.height * back_sinres, 0.0f);
                gl.End();
                //buttom
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                gl.Vertex(-now.width / 2, 0.0f, -19.8f);
                gl.Vertex(now.width / 2, 0.0f, -19.8f);
                gl.Vertex(0.0f, now.height * back_sinres, -19.8f);
                gl.End();
            }



            gl.End();
            gl.DeleteQuadric(q);








            return (float)(back_tanres);
        }


        public void DrawFigure(figure now)
        {
            int countsegments = 50;

            IntPtr q = gl.NewQuadric();
            gl.Translate(now.x, now.y, now.z);
            gl.Rotate(now.alpha, now.beta, 0.0f);
            gl.Translate(0, 0, -now.height/2);
            gl.QuadricDrawStyle(q, OpenGL.GLU_FILL);
            //gl.QuadricDrawStyle(q, OpenGL.GLU_LINE);
            float[] dif = { (float)now.csurface.R / 256f, (float)now.csurface.G / 256f, (float)now.csurface.B / 256f, (float)now.csurface.A / 256f };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, dif);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, dif);

            float second_oval = 0;
            if (now.name == "cylinder")
                second_oval = now.width / 2;

            gl.Cylinder(q, now.width / 2, second_oval, now.height, countsegments, countsegments);

            float[] dif2 = { (float)now.cbase.R / 256f, (float)now.cbase.G / 256f, (float)now.cbase.B / 256f, (float)now.cbase.A / 256f };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, dif2);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, dif2);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, dif2);

            gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                 for (int i = 0; i <= countsegments; i++)
                 {
                     float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                     float dx = now.width * (float)Math.Cos(angle) / 2f;
                     float dy = now.width * (float)Math.Sin(angle) / 2f;
                     gl.Vertex(dx, dy, 0.0f);
                 }
                 gl.End();
            if (now.name == "cylinder")
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Normal(0, 0, 1.0f);
                for (int i = 0; i <= countsegments; i++)
                {
                    float angle = 2.0f * (float)Math.PI * (float)i / (float)countsegments;
                    float dx = now.width * (float)Math.Cos(angle) / 2f;
                    float dy = now.width * (float)Math.Sin(angle) / 2f;
                    gl.Vertex(dx, dy, now.height);
                }
                gl.End();
            }
            
            gl.End();
            gl.DeleteQuadric(q);

        }
       
    }

    class Main
    {
    }
}
