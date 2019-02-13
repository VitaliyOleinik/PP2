
using System.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4 
{
    class Program
    {
        static void Main(string[] args)
        {
            // created||open a file "Path.txt" with FileStream
            FileStream fs = new FileStream(@"C:\Work\PP2\PP2\Week 2\Task4\Path\ded.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            // created function to write info to fs
            StreamWriter wr = new StreamWriter(fs);
            // created string
            string someInformation = "SALAM UALEYKUM VASYAAAA";
            // calling StreamWriter wr to write string into the file Path
            wr.WriteLine(someInformation);
            // close stream StreamWriter
            wr.Close();
            // close stream FileStream
            fs.Close();
            // copying from Path.txt to Path1.txt
            File.Copy(@"C:\Work\PP2\PP2\Week 2\Task4\Path\ded.txt", @"C:\Work\PP2\PP2\Week 2\Task4\Path1\ded.txt");
            // deleting Path.txt
            File.Delete(@"C:\Work\PP2\PP2\Week 2\Task4\Path\ded.txt");
        }
    }
}
