using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntroToThreading
{
    class Program
    {
        public static int sharedStaticValue = 0;
        public static void PrintChar(char c, bool isToPlus)
        {
            int threadValue = 0;

            if (isToPlus)
            {
                while (true)
                {
                    threadValue++;
                    sharedStaticValue++;
                    Console.WriteLine("SHARED = " + sharedStaticValue);
                    Console.WriteLine("THREAD = " + threadValue);
                }
            }
            else
            {
                while (true)
                {
                    threadValue--;
                    sharedStaticValue--;
                    Console.WriteLine("SHARED = " + sharedStaticValue);
                    Console.WriteLine("THREAD = " + threadValue);
                }
            }

            //Random random = new Random();
            //string guid = Guid.NewGuid().ToString();

            //int someVariable = random.Next(0, 10);

            //for(int i = 0; i < 100; i++)
            //{
            //    Console.Write(c);
            //}
        }

        static void StringManipulationThreaded(int count, int threadsCount)
        {
            Thread[] threads = new Thread[threadsCount];
            int countPerThread = count / threadsCount;

            for (int i = 0; i < threadsCount; i++)
            {
                threads[i] = new Thread(() =>
                {
                    string initial = string.Empty;
                    for (int j = 0; j < countPerThread; j++)
                    {
                        initial += Guid.NewGuid().ToString();
                    }
                });
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (var item in threads)
            {
                item.Start();
                item.Join();
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
        static void StringManipulation(int count)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string initial = string.Empty;
            for (int i = 0; i < count; i++)
            {
                initial += Guid.NewGuid().ToString();
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
        static void Main(string[] args)
        {
            // Race condition
            //Thread newThread = 
            //    new Thread(() => PrintChar('B', false));
            //newThread.Start();

            //PrintChar('C', true);

            StringManipulationThreaded(50000, 5);

            Console.ReadLine();
        }
    }
}
