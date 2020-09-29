using System;

namespace Lab_1
{

    class Linear
    {
        public double min;
        public double max;

        public double FunctionF(double x)
        {
            return Math.Pow(x, 3) - 3 * x * x - 17 * x + 22;
        }
        public double DerivativeF(double x)
        {
            return 3 * x * x - 6 * x - 17;
        }
        public double Newton(double x, double exp)
        {
            Console.WriteLine(x);
            double temp = x;
            x = x - FunctionF(x) / DerivativeF(x);
            if (Math.Abs(temp - x) > exp)
                return Newton(x, exp);
            else
                return x;
        }
        public double Dichotomy(double x_min, double x_max, double exp)
        {
            Console.WriteLine(x_min.ToString() + " " + x_max.ToString());
            double temp = (x_min + x_max) / 2;

            if (FunctionF(x_min) * FunctionF(temp) < 0)
                x_max = temp;
            else
                x_min = temp;
            if (FunctionF(temp) != 0 && x_max - x_min > exp && x_max - x_min > 1E-10)
                return Dichotomy(x_min,x_max, exp);
            else
                return (x_min + x_max) / 2;
        }
        public double FixedPointIterarion(double x, double exp, double alpha)
        {
            Console.WriteLine(x);
            double temp = x;
            x = x + alpha * FunctionF(x);
            if (Math.Abs(temp - x) > exp)
                return FixedPointIterarion(x, exp , alpha);
            else
                return x;
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
    class Interface
    {
        public cyb ascii;
        public int status;
        public Linear go;
        private double[] solution = new double[3] { -3.5453, 1.1502, 5.3952 };
        private int ReadValue(int min, int max)
        {
            int res = Int32.MinValue;
            string str = "";

            while (res == Int32.MinValue)
            {
                str = Console.ReadLine();
                int temp;
                if (Int32.TryParse(str, out temp) && temp >= min && temp <= max)
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
        private int ReadKey(int min, int max)
        {
            int res = 0;
            while (res == 0)
            {
                Console.WriteLine();
                Console.Write(">>> ");
                System.ConsoleKeyInfo new_key = Console.ReadKey();
                int temp = new_key.KeyChar;
                if (temp >= min && temp <= max)
                    res = temp;
            };
            Console.WriteLine();
            return res;
        }

        private void NewInterval()
        {
            Console.WriteLine("New interval...");
            Console.WriteLine("from 1,7E-308 to " + (solution[2] - 0.1).ToString());

            double min = ReadValue(double.MinValue, solution[2] - 0.1);
            double max;
            if (min < solution[0])
            {
                Console.WriteLine("from " + (solution[0] + 0.1).ToString() + " to " + (solution[1] - 0.1).ToString());
                max = ReadValue(solution[0] + 0.1, solution[1] - 0.1);
            }
            else if (min < solution[1] - 0.1)
            {
                Console.WriteLine("from " + (solution[1] + 0.1).ToString() + " to " + (solution[2] - 0.1).ToString());
                max = ReadValue(solution[1] + 0.1, solution[2] - 0.1);
            }
            else
            {
                Console.WriteLine("from " + (solution[2] + 0.1).ToString() + " to 1,7E+308");
                max = ReadValue(solution[2] + 0.1, double.MaxValue);
            }

            go.min = min;
            go.max = max;
        }
        private void Solution_X()
        {
            int type = 0;
            double accuracy = 0;
            double res = 0;
            Console.WriteLine();
            Console.WriteLine("Press <1> to Dichotomy");
            Console.WriteLine("Press <2> to Newton's");
            Console.WriteLine("Press <3> to Fixed-point iteration");
            type = ReadKey(49,51);

            if (type != 4 && type != 1)
            {
                Console.WriteLine("Accuracy: ");
                accuracy = ReadValue(0, double.MaxValue);
            };

            switch (type)
            {
                case 49:
                    res = go.Dichotomy(go.min, go.max, accuracy);
                    break;
                case 50:
                    res = go.Newton((go.min + go.max) / 2, accuracy);
                    break;
                case 51:
                    double q = go.DerivativeF((go.min + go.max) / 2);
                    Console.WriteLine("q = " + q.ToString());
                    Console.WriteLine();
                    if (Math.Abs(q) > 1)
                        Console.WriteLine("Warning!!! The function does not match");
                    res = go.FixedPointIterarion((go.min + go.max) / 2, accuracy, q);
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Solution: " + res.ToString());

        }
        public void Start()
        {
            ascii = new cyb();
            ascii.DrawCybernetics();
            ascii.DrawNumerical();


            Console.WriteLine("Solutions: {" + solution[0].ToString() + ";   " + solution[1].ToString() + ";   " + solution[2].ToString() + "}");

            Console.WriteLine("Press any key to start ...");
            Console.ReadKey();
        }
        public void DoIT()
        {
            switch(status)
            {
                case 49:
                    NewInterval();
                    break;
                case 50:
                    Solution_X();
                    break;
            };
            ascii.DrawLines();
        }
        public int NewCommand()
        {
            int res = 0;
            Console.WriteLine();
            Console.WriteLine("Press <1> to set new interval");
            Console.WriteLine("Press <2> to find X");
            Console.WriteLine("Press <3> to exit");

            res = ReadKey(49,51);
            if (res == 51)
                status = -1;
            else status = res;
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Linear lab = new Linear();
            Interface main_process = new Interface();
            main_process.go = lab;
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
