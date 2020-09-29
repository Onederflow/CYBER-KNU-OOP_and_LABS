using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class matrix
    {
        public int rank = 0;
        public double[,] A;
        public double[] x;
        public double[] b;

        public void WriteA()
        {
            Console.WriteLine("___________( Matrix A )___________");
            Console.WriteLine("Rank: " + rank + "\n");

            int lenght = 0;
            bool isdouble = false;

            for (int i = 0; i < rank; i++)
                for (int j = 0; j < rank; j++)
                {
                    if ((double)(int)(A[i, j]) - A[i, j] != 0)
                        isdouble = true;
                    
                    if(!isdouble)
                    {
                        if (A[i, j].ToString().Length > lenght)
                            lenght = A[i, j].ToString().Length;
                    }
                };

            string param;
            if (isdouble)
                param = "{0:0.0000}";
            else
                param = "{0," + (lenght + 1).ToString() + "}";

            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                    Console.Write(String.Format(param, A[i, j]) + " ");
                Console.WriteLine();
            }
        }
        public void WriteX()
        {
            Console.Write("x: {");

            for (int j = 0; j < rank; j++)
            {
                Console.Write(x[j]);
                if (j != rank - 1)
                    Console.Write(";  ");
            };
            Console.Write("}");
            Console.WriteLine();
        }
        public void WriteB()
        {
            Console.Write("b: {");

            for (int j = 0; j < rank; j++)
            {
                Console.Write(b[j]);
                if (j != rank - 1)
                    Console.Write(";  ");
            };
            Console.Write("}");
            Console.WriteLine();
        }

        public void GenerateRand(int min, int max, int n)
        {
            A = new double[n, n];
            rank = n;
            Random rand = new Random();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = rand.Next(min, max + 1);
                }
            /*
            rank = 2;
            A = new double[2, 2] { {1 , 2 }, { 2 ,1 } };
            rank = 3;
            A = new double[3, 3] { { 3, 2, 1 }, { 2, 2, 2 }, {1,2,3} };*/

        }
        public void GenerateHilbert(int n)
        {
            A = new double[n, n];
            rank = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = 1f / (double)(i + j + 2);
                }
            }
        }
        public void GenerateDiagonalSuperiority(int min, int max, int n)
        {
            A = new double[n, n];
            rank = n;
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                int summ = 0;
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = rand.Next(min, max + 1);
                    summ += Math.Abs((int)A[i, j]);
                }
                A[i, i] = summ + 1;
            }
        }

        public void GenerateDiagonalSuperiority2(int min, int max, int n)
        {
            A = new double[n, n];
            rank = n;
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                int summ = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j >= i)
                    {
                        A[i, j] = rand.Next(min, max + 1);
                        A[j, i] = A[i, j];
                    };
                    summ += Math.Abs((int)A[i, j]);
                }
                A[i, i] = summ + 1;
            }
        }

        public void GenerateDiagonal(int min, int max, int n)
        {
            A = new double[n, n];
            rank = n;
            Random rand = new Random();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < 3; j++)
                {
                    if(i + j - 1 >= 0 && i + j - 1 < rank)
                        A[i, i+j -1] = rand.Next(min, max + 1);
                }
        }

        public void StandartSolutionX()
        {
            x = new double[rank];
            for (int i = 0; i < rank; i++)
                x[i] = i + 1;
        }
        public void GiveB()
        {
            b = new double[rank];
            for(int i = 0; i < rank; i++)
            {
                double res = 0;
                for (int j = 0; j < rank; j++)
                    res += A[i, j] * x[j];
                b[i] = res;
            }
        }

        private double Manhattan_norm(double[] array)
        {
            double res = 0;
            for (int i = 0; i < array.Length; i++)
                res += Math.Abs(array[i]);
            return res;
        }
        private double Norm_norm(double[] array)
        {
            double res = 0;
            for (int i = 0; i < array.Length; i++)
                res += array[i] * array[i];

            return (double)Math.Sqrt(res);
        }
        private double row_2(double[] temp_x, int row)
        {
            double summ = 0;
            for(int i = 0; i < rank; i++)
            {
                if (i != row)
                    summ += A[row, i] * temp_x[i];
            }
            return (b[row] - summ) / A[row, row];
        }
        private double row_2_scalar(int row)
        {
            double summ = 0;
            for (int i = 0; i < rank; i++)
            {
                summ += A[row, i] * x[i];
            }
            return summ;
        }

        private double[] jacobi_recursion(double accuracy)
        {
            double[] res = new double[rank];
            double start_norm = Manhattan_norm(x);
            WriteX();
            for (int i = 0; i < rank; i++)
            {
                res[i] = row_2(x, i);
            };
            x = res;
            double new_accuracy = Math.Abs(Manhattan_norm(res) - start_norm);
            Console.Write("accuracy: " + (String.Format("{0,10}", new_accuracy)) + "        ");
            if (new_accuracy > accuracy)
                res = jacobi_recursion(accuracy);
            return res;
        }
        private double[] Gauss_Seidel_recursion(double accuracy)
        {
            double start_norm = Manhattan_norm(x);
            WriteX();
            for (int i = 0; i < rank; i++)
            {
                x[i] = row_2(x, i);
            };
            double new_accuracy = Math.Abs(Manhattan_norm(x) - start_norm);
            Console.Write("accuracy: " + (String.Format("{0,10}", new_accuracy)) + "        ");
            if (new_accuracy > accuracy)
                Gauss_Seidel_recursion(accuracy);
            return x;
        }
        private double[] Gauss(double accuracy)
        {
            return x;
        }

        public void Solution_jacobi(double accuracy)
        {
            Console.WriteLine("Jacobi method!");
            Console.WriteLine("Accuracy: " + accuracy);
            Console.WriteLine();
            for (int i = 0; i < rank; i++)
                x[i] = 1; 
            jacobi_recursion(accuracy);
        }
        public void Solution_Gauss_Seidel(double accuracy)
        {
            Console.WriteLine("Gauss_Seidel method!");
            Console.WriteLine("Accuracy: " + accuracy);
            Console.WriteLine();
            for (int i = 0; i < rank; i++)
                x[i] = 1;
            Gauss_Seidel_recursion(accuracy);
        }
        public void Solution_tridiagonal()
        {
            x = new double[rank];

            double[] a_st = new double[rank];
            double[] b_st = new double[rank];
            double[] c_st = new double[rank];

            double[] alpha = new double[rank];
            double[] beta = new double[rank];
            double[] gamma = new double[rank];


            for (int i = 0; i < rank; i++)
            {
                if(i != rank - 1)
                    a_st[i+1] = A[i + 1, i];
                b_st[i] = A[i, i];
                if (i != rank - 1)
                    c_st[i] = A[i, i + 1];
            }

            gamma[0] = b_st[0];
            alpha[0] = -c_st[0] / gamma[0];
            beta[0] = b[0] / gamma[0];

            for (int i = 1; i < rank; i++)
            {
                gamma[i] = b_st[i] + a_st[i] * alpha[i - 1];
                alpha[i] = -c_st[i] / gamma[i];
                beta[i] = (b[i] - a_st[i] * beta[i - 1]) / gamma[i];
            };

            x[rank - 1] = beta[rank - 1];
            for (int i = rank - 2; i >= 0; i--)
                x[i] = alpha[i] * x[i + 1] + beta[i];
        }
        public void Solution_Gauss()
        {
            Console.WriteLine("Gauss method!");
            Console.WriteLine();

            double[] b_now = b;
            double[,] A_now = A;

            for(int n = 0; n < rank; n++)
            {
                double temp;
                temp = A_now[n, n];
                    for (int i = n; i < rank; i++)
                    {
                        A_now[n, i] = A_now[n, i] / temp;
                    };
                b_now[n] = b_now[n] / temp;

                for (int i = 0; i < rank; i++)
                {
                    if (i != n)
                    {
                        double g = A_now[i, n] / A_now[n, n];
                        for (int j = n; j < rank; j++)
                            A_now[i, j] = A_now[i, j] - g * A_now[n, j];
                        b_now[i] = b_now[i] - g * b_now[n];
                    };
                }
            };
            x = b_now;
        }

        private double[] Kaczmarz_recursion(double accuracy, int j)
        {
            if (j >= rank)
                j = 0;
            double[] temp = new double[rank];
            for (int i = 0; i < rank; i++)
                temp[i] = A[j, i];
            double start_norm = Norm_norm(temp);
            //WriteX();

            for (int i = 0; i < rank; i++)
            {
                x[i] = x[i] + (b[j] - row_2_scalar(j)) * A[j,i] / (double)Math.Pow(start_norm,2);

            };

            double new_accuracy = Math.Abs(Norm_norm(x) - start_norm);
            //Console.Write("accuracy: " + (String.Format("{0,10}", new_accuracy)) + "        ");

            if (new_accuracy > accuracy)
                Kaczmarz_recursion(accuracy, j + 1);
            return x;
        }

        public void SolutionKaczmarz(double accuracy)
        {
            Console.WriteLine("Kaczmarz method!");
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < rank; i++)
                x[i] = 1;
            Kaczmarz_recursion(accuracy , 0);
        }
    }

    public class cyb
    {
        public void DrawCybernetics()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                   ▄████▄  ▓██   ██▓ ▄▄▄▄   ▓█████  ██▀███   ███▄    █ ▓█████ ▄▄▄█████▓ ██▓ ▄████▄    ██████ ");
            Console.WriteLine("                  ▒██▀ ▀█   ▒██  ██▒▓█████▄ ▓█   ▀ ▓██ ▒ ██▒ ██ ▀█   █ ▓█   ▀ ▓  ██▒ ▓▒▓██▒▒██▀ ▀█  ▒██    ▒ ");
            Console.WriteLine("                  ▒▓█    ▄   ▒██ ██░▒██▒ ▄██▒███   ▓██ ░▄█ ▒▓██  ▀█ ██▒▒███   ▒ ▓██░ ▒░▒██▒▒▓█    ▄ ░ ▓██▄   ");
            Console.WriteLine("                  ▒▓▓▄ ▄██▒  ░ ▐██▓░▒██░█▀  ▒▓█  ▄ ▒██▀▀█▄  ▓██▒  ▐▌██▒▒▓█  ▄ ░ ▓██▓ ░ ░██░▒▓▓▄ ▄██▒  ▒   ██▒");
            Console.WriteLine("                  ▒ ▓███▀ ░  ░ ██▒▓░░▓█  ▀█▓░▒████▒░██▓ ▒██▒▒██░   ▓██░░▒████▒  ▒██▒ ░ ░██░▒ ▓███▀ ░▒██████▒▒");
            Console.WriteLine("                  ░ ░▒ ▒  ░   ██▒▒▒ ░▒▓███▀▒░░ ▒░ ░░ ▒▓ ░▒▓░░ ▒░   ▒ ▒ ░░ ▒░ ░  ▒ ░░   ░▓  ░ ░▒ ▒  ░▒ ▒▓▒ ▒ ░");
            Console.WriteLine("                    ░  ▒    ▓██ ░▒░ ▒░▒   ░  ░ ░  ░  ░▒ ░ ▒░░ ░░   ░ ▒░ ░ ░  ░    ░     ▒ ░  ░  ▒   ░ ░▒  ░ ░");
            Console.WriteLine("                  ░         ▒ ▒ ░░   ░    ░    ░     ░░   ░    ░   ░ ░    ░     ░       ▒ ░░        ░  ░  ░  ");
            Console.WriteLine("                  ░ ░       ░ ░      ░         ░  ░   ░              ░    ░  ░          ░  ░ ░            ░  ");
            Console.WriteLine("                  ░         ░ ░           ░                                                ░                 ");
            Console.WriteLine("");

        }
        public void DrawNumerical()
        {


            Console.WriteLine("      _   _                                     _                  _                             _                 _       ");
            Console.WriteLine("     | \\ | |                                   (_)                | |                           | |               (_)      ");
            Console.WriteLine("     |  \\| |  _   _   _ __ ___     ___   _ __   _    ___    __ _  | |     __ _   _ __     __ _  | |  _   _   ___   _   ___ ");
            Console.WriteLine("     | . ` | | | | | | '_ ` _ \\   / _ \\ | '__| | |  / __|  / _` | | |    / _` | | '_ \\   / _` | | | | | | | / __| | | / __|");
            Console.WriteLine("     | |\\  | | |_| | | | | | | | |  __/ | |    | | | (__  | (_| | | |   | (_| | | | | | | (_| | | | | |_| | \\__ \\ | | \\__ \\");
            Console.WriteLine("     |_| \\_|  \\__,_| |_| |_| |_|  \\___| |_|    |_|  \\___|  \\__,_| |_|    \\__,_| |_| |_|  \\__,_| |_|  \\__, | |___/ |_| |___/");
            Console.WriteLine("                                                                                                      __/ |                ");
            Console.WriteLine("                                                                                                     |___/                 ");
            Console.WriteLine("");

        }
        public void DrawIncorrect()
        {
            Console.WriteLine();
            Console.WriteLine(" .  _   _  _   _  _  _  _ |_     .  _   _      |_ | | | ");
            Console.WriteLine(" | | ) (_ (_) |  |  (- (_ |_     | | ) |_) |_| |_ . . . ");
            Console.WriteLine("                                       |                ");
            Console.WriteLine();
        }
        public void DrawLines()
        {
            Console.WriteLine();
            Console.WriteLine("->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->");
        }

    }   
    public class my_interface
    {
        public matrix mx;
        public cyb ascii;

        public int status = 0;
        public int type_matrix = 0;

        private int ReadValue(int min, int max)
        {
            int res = Int32.MinValue;
            string str = "";

            while(res == Int32.MinValue)
            {
                str = Console.ReadLine();
                int temp;
                if (Int32.TryParse(str, out temp) &&  temp >= min && temp <= max)
                    res = temp;
                else
                {
                    ascii.DrawIncorrect();
                };
            }
            Console.WriteLine();
            return res;

        }
        private double ReadValue(double min, double max)
        {
            double res = double.MinValue;
            string str = "";
            while (res == double.MinValue)
            {
                str = Console.ReadLine();
                double temp;
                if (double.TryParse(str, out temp) && temp >= min && temp <= max)
                    res = temp;
                else
                {
                    ascii.DrawIncorrect();
                };
            }
            Console.WriteLine();
            return res;
        }
        private int ReadKey()
        {
            int res = 0;

            while (res == 0)
            {
                Console.WriteLine();
                Console.Write(">>> ");
                System.ConsoleKeyInfo new_key = Console.ReadKey();

                if (new_key.Key == ConsoleKey.D1)
                    res = 1;
                if (new_key.Key == ConsoleKey.D2)
                    res = 2;
                if (new_key.Key == ConsoleKey.D3)
                    res = 3;
                if (new_key.Key == ConsoleKey.D4)
                    res = 4;
                if (new_key.Key == ConsoleKey.D5)
                    res = 5;
            };
            Console.WriteLine();
            return res;
        }

        private void NewMatrix()
        {
            int rank = 0;
            int type = -1;
            int min = 0;
            int max = 0;

            Console.WriteLine();
            Console.WriteLine("Creating new matrix ...");

            Console.WriteLine();
            Console.WriteLine("Press <1> to random");
            Console.WriteLine("Press <2> to Hilbert");
            Console.WriteLine("Press <3> to diagonal superiority");
            Console.WriteLine("Press <4> to tridiagonal");
            Console.WriteLine("Press <5> to diagonal superiority version 2");

            type = ReadKey();
            type_matrix = type;

            Console.Write("Rank: ");
            rank = ReadValue(1, 500);
            if (type != 2)
            {
                Console.Write("Min value: ");
                min = ReadValue(Int32.MinValue,Int32.MaxValue);
                Console.Write("max value: ");
                max = ReadValue(min, Int32.MaxValue);
            };
            if (type == 1)
                mx.GenerateRand(min, max, rank);
            if (type == 2)
                mx.GenerateHilbert(rank);
            if (type == 3)
                mx.GenerateDiagonalSuperiority(min,max,rank);
            if (type == 4)
                mx.GenerateDiagonal(min, max, rank);
            if (type == 5)
                mx.GenerateDiagonalSuperiority2(min, max, rank);

            mx.WriteA();
        }
        private void Solution_X()
        {
            int type = 0;
            double accuracy = 0;
            Console.WriteLine();
            Console.WriteLine("Press <1> to Gauss");
            Console.WriteLine("Press <2> to Jacobi");
            Console.WriteLine("Press <3> to Gauss Seidel");
            Console.WriteLine("Press <4> to triagonal");
            Console.WriteLine("Press <5> to Kaczmarz");
            type = ReadKey();

            if (type != 4 && type != 1)
            {
                Console.WriteLine("Accuracy: ");
                accuracy = ReadValue(0, double.MaxValue);
            };

            mx.StandartSolutionX();
            mx.GiveB();

            Console.WriteLine("Standart solution >>>");
            mx.WriteX();
            mx.WriteB();

            if (type == 1)
                mx.Solution_Gauss();
            if (type == 2)
                mx.Solution_jacobi(accuracy);
            if (type == 3)
                mx.Solution_Gauss_Seidel(accuracy);
            if (type == 4 && mx.rank != 0)
                mx.Solution_tridiagonal();
            if (type == 5 && mx.rank != 0)
                mx.SolutionKaczmarz(accuracy);

            Console.WriteLine();
            Console.WriteLine("Solution: ");
            mx.WriteX();
        }

        public void Start()
        {
            ascii = new cyb();
            ascii.DrawCybernetics();
            ascii.DrawNumerical();

            Console.WriteLine("Press any key to start ...");
            Console.ReadKey();
        }

        public void DoIT()
        {
            if (status == 1)
                NewMatrix();
            if (status == 2)
                mx.WriteA();
            if (status == 3)
                Solution_X();

            ascii.DrawLines();
        }

        public int NewCommand()
        {
            int res = 0;
            Console.WriteLine();
            Console.WriteLine("Press <1> to create new matrix");
            Console.WriteLine("Press <2> to output matrix");
            Console.WriteLine("Press <3> to find X");
            Console.WriteLine("Press <4> to exit");

            res = ReadKey();
            if (res == 4)
                status = -1;
            else status = res;
           
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            matrix LinearSystem = new matrix();
            my_interface main_process = new my_interface();
            main_process.mx = LinearSystem;
            main_process.Start();

            while (main_process.status != -1)
            {
                main_process.NewCommand();
                if (main_process.status != -1)
                    main_process.DoIT();
            };
        }
    }
}
