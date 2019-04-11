using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Gun
{
    class Program
    {
        public static int i = 6;
        static void Main(string[] args)
        {
            Thread thread = new Thread(Draw);

            Console.WriteLine("######");
            Console.WriteLine("#.#");
            Console.WriteLine("##");

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
            {
                thread.Start();
            }

        }

        private static void Draw()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(i, 0);
                Console.Write('$');
                Console.SetCursorPosition(i - 1, 0);
                Console.Write(" ");
                i++;
                Thread.Sleep(200);
            }
        }
    }
}
