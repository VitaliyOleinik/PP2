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
        // created boolean value/ which return 1 or 2
        bool ok;
        // created method FarManager
        public FarManager()
        {
            // where cursor is equal 0, because it's startpoint from 0 to ..
            cursor = 0;
            // ok is true value
            ok = true;
        }
        // created method Color wit values (FSInfo and index)
        public void Color(FileSystemInfo fs, int index)
        {
            // if 
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

        }
        public void Show(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();
            size = fileSystemInfos.Length;
            int index = 0;
            foreach(FileSystemInfo fs in fileSystemInfos)
            {
                if (ok && fs.Name.StartsWith("."))
                {
                    size--;
                    continue;
                }
                Color(fs, index);

                Console.WriteLine(fs.Name);
                index++;
            }
        }
        public void Down()
        {
            cursor++;
            if (cursor == size)
                cursor = 0;
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = size - 1;
        }
        public void Start(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            FileSystemInfo fs = null;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Backspace)
                {
                    cursor = 0;
                    directory = directory.Parent;
                    path = directory.FullName;
                }
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.RightArrow)
                    ok = false;
                if (consoleKey.Key == ConsoleKey.LeftArrow)
                    ok = true;
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    int k = 0;
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        if (ok && directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                            continue;
                        if (cursor == k)
                        {
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        k++;
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        directory = new DirectoryInfo(fs.FullName);
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
            FarManager farManager = new FarManager();
            farManager.Start(@"C:\Work\PP2\PP2");
        }
    }
}
