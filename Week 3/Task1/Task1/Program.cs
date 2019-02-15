using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    // created class FarManager 
    class FarManager
    {
        // created public value cursor
        public int cursor;
        // created public value size
        public int size;
        
        // created method FarManager
        public FarManager()
        {
            // where cursor is equal 0, because it's startpoint from 0 to ..
            cursor = 0;
            
        }
        // created method Color wit values (FSInfo and index)
        public void Color(FileSystemInfo fs, int index)
        {
            // if is equal index
            if (cursor == index)
            {
                // painted BC red
                Console.BackgroundColor = ConsoleColor.Red;
                // painted FC white
                Console.ForegroundColor = ConsoleColor.White;
            }
            // iff fs is equal directory info
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                // painted black
                Console.BackgroundColor = ConsoleColor.Black;
                // painted white
                Console.ForegroundColor = ConsoleColor.White;
            }
            // else ..
            else
            {
                // BC painted black
                Console.BackgroundColor = ConsoleColor.Black;
                // FC yellow
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

        }
        // created method Show for showing files
        public void Show(string path)
        {
            // new DI path
            DirectoryInfo directory = new DirectoryInfo(path);
            // created an array of folders and files
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();
            // size is equal length
            size = fileSystemInfos.Length;
            // created new value index
            int index = 0;
            // a loop conteins folders and files
            foreach(FileSystemInfo fs in fileSystemInfos)
            {
                
                // called method Color (fs, index)
                Color(fs, index);
                // output fs name
                Console.WriteLine(fs.Name);
                // index increasing
                index++;
            }
        }
        // void method Down
        public void Down()
        {
            // cursor increasing
            cursor++;
            // iff cursor is equal size then
            if (cursor == size)
                // cursor is equal 0
                cursor = 0;
        }
        // void method Up
        public void Up()
        {
            // cursor decreasing
            cursor--;
            // if cursor <0 then
            if (cursor < 0)
                // cursor is equal size of contain - 1
                cursor = size - 1;
        }
        // void method Start
        public void Start(string path)
        {
            // directory info of path
            DirectoryInfo directory = new DirectoryInfo(path);
            // created checking for readkey
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            // fs is equal null
            FileSystemInfo fs = null;
            // loop for true
            while (true)
            {
                // BC colored black
                Console.BackgroundColor = ConsoleColor.Black;
                // cleaning cmd with color black
                Console.Clear();
                // calling method of path
                Show(path);
                // readkey
                consoleKey = Console.ReadKey();
                // if consolekey is equal backspace 
                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    // cursor is equal 0
                    cursor = 0;
                    // upper directory
                    directory = directory.Parent;
                    // path is equal directory full name
                    path = directory.FullName;
                }
                // if console key Up arrow
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    // calling method Up
                    Up();
                // if console key Down arrow
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    // calling method Down
                    Down();
                // if console key enter
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    // created k
                    int k = 0;
                    // a loop for checking files
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        
                        if (cursor == k)
                        {
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        k++;
                    }
                    // fs type is equal typeof directory info
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        // cursor is equal 0
                        cursor = 0;
                        // directory with new path fs
                        directory = new DirectoryInfo(fs.FullName);
                        // path is equal fs
                        path = fs.FullName;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // created FarManager
            FarManager farManager = new FarManager();
            // start with auditory
            farManager.Start(@"C:\Work\PP2\PP2");
        }
    }
}
