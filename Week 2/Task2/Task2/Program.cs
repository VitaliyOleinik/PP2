using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        // created public void method(bool), which returns true || false statements
        public static bool Pr(int n)
        {
            // created a loop for chech numbers of array on prime numbers
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                // if a diveded is equal zero, then return 0
                if (n % i == 0)
                    
                    return false;
            }
            // else 1
            return true;
        }

        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream(@"C:\Work\PP2\PP2\Week 2\Task2\Task2\bin\Debug\input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileStream);
            String line = sr.ReadLine();
            String[] stringNumbers = line.Split();
            int[] arr = new int[stringNumbers.Length];
            for (int i = 0; i < stringNumbers.Length; ++i)
            {
                arr[i] = int.Parse(stringNumbers[i]);
            }
            sr.Close();

            fileStream.Close();
            FileStream fs = new FileStream(@"C:\Work\PP2\PP2\Week 2\Task2\Task2\bin\Debug\output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            
            
            for (int i = 0; i < arr.Length; i++)
            {
                // call method
                if (Pr(arr[i]))
                {
                    if (arr[i] != 1)
                    {
                        sw.Write(i + " ");
                    }
                }
            }
            sr.Close();

            fileStream.Close();
            Console.ReadKey();
        }
    }
}
