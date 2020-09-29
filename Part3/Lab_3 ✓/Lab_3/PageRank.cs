using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class PageRank
    {
        public double[,] A;
        public double[] X;
        public int rank;
        public double esc = 0.01;

        private double[,] B;
        private double alpha = 0.15;

        public Graph vs;
        public void RegenWithB()
        {
            B = new double[rank, rank];
            for (int i = 0; i < rank; i++)
                for (int j = 0; j < rank; j++)
                    B[i, j] = 1.0 / (double)rank;
            double[,] M = new double[rank, rank];
            for (int i = 0; i < rank; i++)
                for (int j = 0; j < rank; j++)
                    M[i, j] = alpha * B[i, j] + (1.0 - alpha) * A[i, j];
            A = M;
        }
        private double Norm(double[] data)
        {
            double res = 0;
            for (int i = 0; i < data.Length; i++)
                res += (i + 1) * Math.Abs(data[i]);
            return res;
        }
        public void Ressult(double esc)
        {
            double start_norm = Norm(X);
            double[] next = new double[rank];
            for (int i = 0; i < rank; i++)
                for(int k = 0; k < rank; k++)
                    next[k] += A[i, k] * X[i];
            X = next;

            vs.DrawAllGraphics();
            if (Math.Abs(Norm(X) - start_norm) > esc)
                Ressult(esc);
        }


    }
}
