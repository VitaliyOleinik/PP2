using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyThreadSalam
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(Date));
            thread.Start();
            string s = "hjklhgfd";
            string s1 = "";
            int cnt = 1;
            foreach(char a in s)
            {
                s1 += a;
                Console.SetCursorPosition(0, cnt);
                cnt++;
                Console.Write(s1);
                
                Thread.Sleep(1000);
            }
        }
        public static void Date()
        {
            while (true)
            {
                DateTime time = new DateTime();
                time = DateTime.Now;
                Console.SetCursorPosition(0, 0);
                Console.Write(time);
                Thread.Sleep(1000);
                
            }

        }
    }
}
