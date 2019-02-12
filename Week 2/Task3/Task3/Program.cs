using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        // method for printing spaces
        public static void PrintSpaces(int level)
        {
            // make a loop
            for (int i = 0; i < level; i++)
                // write space
                Console.Write("     ");
        }
        public static void Put_num(DirectoryInfo dir, int level)
        {
            // created a loop of file info in directory 
            foreach (FileInfo f in dir.GetFiles())
            {
                // prints level "       "
                PrintSpaces(level);
                // write folde name or file
                Console.WriteLine(f.Name);
            }
            // created a loop of directory info in directory
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                // write level
                PrintSpaces(level);
                // the next auditory
                Console.WriteLine(d.Name);
                // calling method
                Put_num(d, level + 1);
            }
        }
        static void Main(string[] args)
        {
            // select the directory
            DirectoryInfo dir = new DirectoryInfo(@"C:\Work\PP2");
            // use method
            Put_num(dir, 0);
            Console.ReadKey();
        }
        
    }
}
