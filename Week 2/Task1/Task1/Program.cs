using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        // created public void method(bool), which returns true || false statements
        public static bool Pr(string s)
        {
            // creat and optimized the loop of the check 
            for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
            {
                // check if s[i] is equal to s[j]
                if (s[i] == s[j])
                    // return 1 if it is equal
                    return true;
            }
            // return 0 if it is not equal
            return false;
        }

        static void Main(string[] args)
        {
            // calling streamreader operator and named it sr and creat a new file with name "input"
            StreamReader sr = new StreamReader("input.txt");
            // function for read all file
            String s = sr.ReadToEnd();
            // stopping readinng
            sr.Close();
            // truth test
            if(Pr(s) == true)
            {
                // if it is a polindrome, write YES
                Console.WriteLine("YES");
            }
            // if not, calling function else 
            else
            {
                // write NO 
                Console.WriteLine("NO");
            }

            Console.ReadKey();
        }
    }
}
