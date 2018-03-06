using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace synchronization
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void Task_1()
        { 
            List<double> S = new List<double>();
            List<double> R = new List<double>();
            Thread A = new Thread(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    S.Add(i);
                }
            });

            Thread B = new Thread(() =>
            {
                while (S.Count < 10)
                {
                    if (S.Count == 0)
                        Thread.Sleep(1000);

                    var item = S[S.Count - 1];
                    item *= item;
                    R.Add(item);
                }
            });

            Thread C = new Thread(() =>
            {
                while (S.Count < 10)
                {
                    if (S.Count == 0)
                        Thread.Sleep(1000);

                    var item = S[S.Count - 1];
                    item /= 3;
                    R.Add(item);
                }
            });
            Thread D = new Thread(() =>
            {
                while (S.Count < 10)
                {
                    if (R.Count == 0)
                    {
                        Console.WriteLine(" List R is empty");
                        Thread.Sleep(1000);
                    }

                    var item = R[R.Count - 1];
                    Console.WriteLine(item);
                }
            });

            A.Start();
            B.Start();
            C.Start();
            D.Start();


            A.Join();
            B.Join();
            C.Join();
            D.Join();
        }
        static void Task_2()
        {
            List<double> S = new List<double>();
            List<double> R = new List<double>();
            Object Loker_S = new object();
            Object Loker_R = new object();


            Thread A = new Thread(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    lock (Loker_S)
                    {
                        S.Add(i);
                    }
                }
            });

            Thread B = new Thread(() =>
            {
                double item;

                while (R.Count < S.Count)
                {
                    lock (Loker_S)
                    {
                        if (S.Count == 0)
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                        else
                            item = S[S.Count - 1];
                    }

                    item *= item;

                    lock (Loker_R)
                    {
                        R.Add(item);
                    }

                    Thread.Sleep(100);
                }
            });

            Thread C = new Thread(() =>
            {
                double item;

                while (R.Count < S.Count)
                {
                    lock (Loker_S)
                    {
                        if (S.Count == 0)
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                        else
                            item = S[S.Count - 1];
                    }
                    item /= 3;
                    lock (Loker_R)
                    {
                        R.Add(item);
                    }
                    Thread.Sleep(100);
                }
            });
            Thread D = new Thread(() =>
            {
                double item;
                while (R.Count < S.Count)
                {
                    lock (Loker_R)
                    {
                        if (R.Count == 0)
                        {
                            Console.WriteLine(" List R is empty");
                            Thread.Sleep(100);
                            continue;
                        }

                        item = R[R.Count - 1];
                    }
                    Console.WriteLine(item);
                    Thread.Sleep(100);
                }
            });

            A.Start();
            B.Start();
            C.Start();
            D.Start();


            A.Join();
            B.Join();
            C.Join();
            D.Join();
        } 
        static void Task_3()
        {

            List<double> S = new List<double>();
            List<double> R = new List<double>();
            Object Loker_S = new object();
            Object Loker_R = new object();


            Thread A = new Thread(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    lock (Loker_S)
                    {
                        S.Add(i);
                    }
                }
            });

            Thread B = new Thread(() =>
            {
                double item;

                while (R.Count < S.Count)
                {
                    lock (Loker_S)
                    {
                        Thread.Sleep(1000);
                        lock (Loker_R)
                        {
                            if (S.Count == 0)
                            {
                                Thread.Sleep(100);
                                continue;
                            }
                            else
                            {
                                item = S[S.Count - 1];
                                item *= item;
                                R.Add(item);
                            }
                        }
                    }


                    Thread.Sleep(100);
                }
            });

            Thread C = new Thread(() =>
            {
                double item;

                while (R.Count < S.Count)
                {
                    lock (Loker_S)
                    {
                        if (S.Count == 0)
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                        else
                            item = S[S.Count - 1];
                    }
                    item /= 3;
                    lock (Loker_R)
                    {
                        R.Add(item);
                    }
                    Thread.Sleep(100);
                }
            });
            Thread D = new Thread(() =>
            {
                double item;
                while (R.Count < S.Count)
                {
                    lock (Loker_R)
                    {
                        if (R.Count == 0)
                        {
                            Console.WriteLine(" List R is empty");
                            Thread.Sleep(100);
                            continue;
                        }

                        item = R[R.Count - 1];
                    }
                    Console.WriteLine(item);
                    Thread.Sleep(100);
                }
            });

            A.Start();
            B.Start();
            C.Start();
            D.Start();


            A.Join();
            B.Join();
            C.Join();
            D.Join();
        }

    }
}
