using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5A_RecruitsTask
{
    public class Soldier
    {
        public byte direction; // 0 - up   1 - right   2 - down    3 - left
        public Soldier()
        {
            direction = 0;
        }
        public Soldier(byte where)
        {
            direction = where;
        }
    }
    class Logic
    {
        public List<Soldier> soldiers;
        public List<Thread> threads;
        public int quantityPerThread = 50;
        public int sleepTime = 100;
        public int nSoldiers = 200;
        private bool drawing = false;

        private bool isWorking = true;
        private int tempWorking = 1;
        public Graphics gs;
        Random rand = new Random();

        public Logic()
        {
            soldiers = new List<Soldier>();
            threads = new List<Thread>();
        }
        public Logic(Graphics ngs)
        {
            soldiers = new List<Soldier>();
            threads = new List<Thread>();
            gs = ngs;
        }

        public void SetNew(int count)
        {
            nSoldiers = count;
            for (int i = 0; i < count; i++)
                soldiers.Add(new Soldier());
        }
        public void SetNew()
        {
            for (int i = 0; i < nSoldiers; i++)
                soldiers.Add(new Soldier());
        }

        public void Rotation()
        {
            for (int i = 0; i < soldiers.Count; i++)
            {
                soldiers[i].direction = (byte)(rand.Next(2) * 2 + 1);
            };
        }

        public bool DoYouKnowTheWay(int a) // if return true - need to swap
        {
            Soldier theRecruit = soldiers[a];
            if(theRecruit.direction == 1)
            {
                if (a == soldiers.Count - 1)
                    return false;
                if (soldiers[a + 1].direction == 3)
                {
                    SwapRecruitDirection(a);
                    SwapRecruitDirection(a + 1);
                    return true;
                }
            }
            else if(theRecruit.direction == 3)
            {
                if (a == 0)
                    return false;
                if (soldiers[a - 1].direction == 1)
                {
                    SwapRecruitDirection(a);
                    SwapRecruitDirection(a - 1);
                    return true;
                }
            }
            return false;
        }

        public void SwapRecruitDirection(int a)
        {
            if (soldiers[a].direction == 1)
                soldiers[a].direction = 3;
            else if (soldiers[a].direction == 3)
                soldiers[a].direction = 1;
            tempWorking++;
        }

        public void DrawRes()
        {
            if (!drawing)
            {
                drawing = true;
                SolidBrush brRed = new SolidBrush(Color.Red);
                SolidBrush brGreen = new SolidBrush(Color.Green);
                for (int i = 0; i < soldiers.Count; i++)
                {
                    if (soldiers[i].direction == 1)
                        gs.FillRectangle(brRed, 10 + 3 * i, 100, 3, 30);
                    if (soldiers[i].direction == 3)
                        gs.FillRectangle(brGreen, 10 + 3 * i, 100, 3, 30);
                }
                drawing = false;
            };
        }
        public void DrawRes(int i)
        {
            if (!drawing)
            {
                drawing = true;
                SolidBrush brRed = new SolidBrush(Color.Red);
                SolidBrush brGreen = new SolidBrush(Color.Green);
                if (soldiers[i].direction == 1)
                    gs.FillRectangle(brRed, 10 + 3 * i, 100, 3, 30);
                if (soldiers[i].direction == 3)
                    gs.FillRectangle(brGreen, 10 + 3 * i, 100, 3, 30);
                drawing = false;
            };
        }

        public void DoIt(int iFrom, int iTo) // process 
        {
            while (isWorking)
            {
                if (iTo == nSoldiers)
                {
                    DrawRes();
                    if (tempWorking == 0)
                        tempWorking = int.MinValue;
                    else if (tempWorking == int.MinValue)
                        isWorking = false;
                    else tempWorking = 0;
                }
                for (int i = iFrom; i < iTo; i++)
                {
                    DoYouKnowTheWay(i);       
                };
                Console.WriteLine($" tempW = {tempWorking} ");
                Thread.Sleep(sleepTime);
            }
        }

        public void StartProcess()
        {
            int n = nSoldiers / quantityPerThread;
            if (n == 0)
                n = 1;
            int part = nSoldiers / n;
            isWorking = true;
            for(int i = 0; i < n; i++)
            {
                int min = i * part;
                int max = (i + 1) * part;
                if (i == n - 1)
                    max = nSoldiers;
                threads.Add(new Thread(() => DoIt(min, max)));
                threads[i].Start();
                Console.WriteLine($"i = {i}  from {min}  to {max}    {threads[i].ThreadState}");
            }
        }

        public void Reset()
        {
            isWorking = false;
            for(int i = 0; i < threads.Count; i++)
            {
                threads[i].Abort();
            }
            threads = new List<Thread>();
            soldiers = new List<Soldier>();
        }
    }
}
