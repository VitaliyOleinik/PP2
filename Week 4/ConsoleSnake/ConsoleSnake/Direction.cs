using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Direction
    {
        public int Dx;
        public int Dy;

        public Direction()
        {
            Dx = Dy = 0;
        }

        public void SnakeDirection(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow && Dy != 1)
            {
                Dx = 0;
                Dy = -1;
            }
            else if (key.Key == ConsoleKey.DownArrow && Dy != -1)
            {
                Dx = 0;
                Dy = 1;
            }
            else if (key.Key == ConsoleKey.RightArrow && Dx != -1)
            {
                Dx = 1;
                Dy = 0;
            }
            else if (key.Key == ConsoleKey.LeftArrow && Dx != 1)
            {
                Dx = -1;
                Dy = 0;
            }
        }
    }
}
