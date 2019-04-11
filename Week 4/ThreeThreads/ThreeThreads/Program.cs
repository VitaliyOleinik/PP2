using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FourThreads
{
    class Company
    {
        public static void Main(string[] args)
        {
            new Thread(new ThreadStart(Instruction)).Start();
            new Thread(new ThreadStart(Instruction)).Start();
            new Thread(new ThreadStart(Instruction)).Start();
            new Thread(new ThreadStart(Instruction)).Start();
        }

        public static void Instruction()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            while (true)
            {
                Console.Write(threadId + " ");
                Thread.Sleep(500);
            }
        }
        public void Instruction2()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            {
                Console.WriteLine(threadId + " ");
                Thread.Sleep(500);
            }
        }
        public void Instruction3()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            {
                Console.WriteLine(threadId + " ");
                Thread.Sleep(500);
            }
        }
    }
}
