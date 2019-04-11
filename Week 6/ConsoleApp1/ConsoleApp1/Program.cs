using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] thread = new Thread[3];
            for (int i = 0; i < thread.Length; i++)
            {
                Thread.Sleep(1000);
                thread[i] = new Thread(OutPut);
                thread[i].Name = i.ToString();
                thread[i].Start();
            }
        }

        private static void OutPut()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
            }
        }
    }
}
