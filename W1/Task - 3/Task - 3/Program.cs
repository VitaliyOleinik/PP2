using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task___3
{
    class Program
    {
        static void Main(string[] args)
        {
            // created new var(int) and converted it to int from string
            int n = int.Parse(Console.ReadLine());
            // created string s
            string s = Console.ReadLine();
            // created array of string s, without " "
            string[] arr = s.Split();
            // created a loop, which outputs values of array
            for (int i = 0; i < n; i++)
            {
                // outputs a variable two times
                Console.Write("{0} {0} ", arr[i]);
            }
            // created for cmd, will close after click any key (cmd)
            Console.ReadKey();
        }
    }
}
