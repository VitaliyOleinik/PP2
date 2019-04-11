using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello!");
            Console.WriteLine("Choose complexity");
            Console.WriteLine(" 1 - begginer \n 2 - normal \n 3 - hard \n 4 - if your life is too easy");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter only one number");
            int level = int.Parse(Console.ReadLine());
            int speed;

            if(level == 1)
            {
                speed = 400;
            }
            else if (level == 2)
            {
                speed = 300;
            }
            else if (level == 3)
            {
                 speed = 100;
            }
            else if (level == 4)
            {
                 speed = 10;
            }

            Console.Clear();

            Game game = new Game();

           
            while (true)
            {
                game.StartGame();
            }
        }
    }
}
