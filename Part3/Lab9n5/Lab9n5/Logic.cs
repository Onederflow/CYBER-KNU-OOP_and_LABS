using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab9n5
{
    public class Matrix
    {
        public int height;
        public int width;
        public int[,] data;

        public Matrix(int new_width, int new_height)
        {
            height = new_height;
            width = new_width;
            data = new int[width, height];
        }

        public void Print()
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(data[i, j].ToString() + "  ");
                }
                Console.WriteLine();
            }
        }
    }

    public class MyMainThreading
    {
        static Matrix A;
        static Matrix B;
        static Matrix C;

        static int count;

        public MyMainThreading(Matrix newA, Matrix newB, int count_of_thread)
        {
            A = newA;
            B = newB;
            C = new Matrix(A.height, B.width);
            count = count_of_thread;
        }

        public Matrix Start()
        {
            Parallel.For(0, count, TempThread);
            Console.WriteLine("End game.");
            return C;
        }

        static void TempThread(int n)
        {
            int part = C.height / count + 1;
            for (int i = 0; i < part; i++)
            {
                int new_b = i * count + n;
                if (new_b < C.height)
                    for (int j = 0; j < C.width; j++)
                        C.data[j, new_b] = ComputingElement(j, new_b);
            }
            Console.WriteLine("Thread number " + n.ToString() + " i love dicks");
        }

        static int ComputingElement(int x,int y)
        {
            int res = 0;
            for (int i = 0; i < A.width; i++)
            {
                res += A.data[i, y] * B.data[x, i];
            }
            return res;
        }
    }
}
