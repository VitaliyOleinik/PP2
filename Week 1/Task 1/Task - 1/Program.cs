using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task___1
{
    class Program
    {
        // created public void method(bool), which returns true || false statements
        public static bool Pr(int n)
        {
            // created a loop for chech numbers of array on prime numbers
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            // created a value (int) and convert it to int from string
            int n = int.Parse(Console.ReadLine());
            // created an array of n numbers (int)
            int[] arr = new int[n];
            // created an array of string without " ", which operator writed 
            string [] a = Console.ReadLine().Split();
            // created a loop, which will convert array of string to int
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(a[i]);
            }
            // declared var(int) count, which will count, how many times the variable check prime number and for that I created a loop
            int cnt = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                // call method and test for prime numbers, if output of method is TRUE and number is not equal 1 then cnt++
                if (Pr(arr[i]))
                {
                    if (arr[i] != 1)
                    {
                        cnt++;
                    }
                }
            }
            // output cnt
            Console.WriteLine(cnt);
            // similar loop which was above
            for (int i = 0; i < arr.Length; i++)
            {
                // call method
                if (Pr(arr[i]))
                {
                    if (arr[i] != 1)
                    {
                        // output numbers of array, which has been tested
                        Console.Write(arr[i] + " ");
                    }
                }
            }
            // created for cmd, will close after click any key (cmd)
            Console.ReadKey();
        }
    }
}
