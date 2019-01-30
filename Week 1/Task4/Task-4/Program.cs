using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // created value(int) and convert it to int from string
            int n = int.Parse(Console.ReadLine());
            // created an array sT and set size n*n 
            int[,] starTriangle = new int[n, n];
            // created a loop from 0 to size of line array
            for(int i = 0; i < n; i++)
            {
                // created a loop from 0 to size of line + 1
                for (int j = 0; j < i + 1; j++)
                {
                    // output [*]
                    Console.Write("[*]");

                }
                // new line
                Console.WriteLine();
            }
            // created for cmd, will close after click any key (cmd)
            Console.ReadKey();
        }
    }
}
