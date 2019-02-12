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
        // created public method(bool), which returns true || false statements
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
        // crated public method(string)
        public static string Ans(string s)
        {
            // created empty string
            string res = "";
            // created an array of sting without " "
            string[] arr = s.Split();
            // check our array of string on Prime numbers
            foreach (var a in arr)
            {
                // created temparary value and parse it to int from string
                int temp = int.Parse(a);
                // checking on prime numbers
                if (Pr(temp))
                {
                    // res is equal res and temp value
                    res = res + " " + temp;
                }
            }
            // cut the first " " and last
            return res.Trim();
        }

        static void Main(string[] args)
        {
            // selected the way to .txt
            FileStream fileStream = new FileStream(@"C:\Work\PP2\PP2\Week 2\Task2\Task2\bin\Debug\input.txt", FileMode.Open, FileAccess.Read);
            // reading the file
            StreamReader sr = new StreamReader(fileStream);
            // created and equaling the line to file
            string line = sr.ReadLine();
            // close the way
            fileStream.Close();
            // close reading of file
            sr.Close();
            // created a value and equaled it to method with line value
            string result = Ans(line);
            // selected the way to .txt
            FileStream fileStream1 = new FileStream(@"C:\Work\PP2\PP2\Week 2\Task2\Task2\bin\Debug\output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            // writing into the file
            StreamWriter sw = new StreamWriter(fileStream1);
            // calling sw and write the our result to this .txt
            sw.WriteLine(result);
            // close sw
            sw.Close();
            // close fs
            fileStream1.Close();
            Console.ReadKey();
        }
    }
}
