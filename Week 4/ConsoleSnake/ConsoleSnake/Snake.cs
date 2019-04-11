using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Snake : Structure
    {
        public Snake(char sign) : base(sign)
        {
            game.Add(new Point { X = 10, Y = 10 });
        }
        public void Move(Direction dir)
        {
            for (int i = game.Count - 1; i > 0; --i)
            {
                game[i].X = game[i - 1].X;
                game[i].Y = game[i - 1].Y;
            }
            game[0].X += dir.Dx;
            game[0].Y += dir.Dy;

            if (game[0].X > 79)
                game[0].X = 0;
            else if (game[0].X < 0)
                game[0].X = 79;

            if (game[0].Y > 29)
                game[0].Y = 0;
            else if (game[0].Y < 0)
                game[0].Y = 29;
        }
    }
}
