using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleSnake
{
    class Structure
    {
        public List<Point> goodSpots = new List<Point>();
        public List<Point> game = new List<Point>();
        public char sign;

        public Structure(char sign)
        {
            this.sign = sign;
        }

        public void DrawGame()
        {
            foreach (Point p in game)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }

        public void Clear()
        {
            foreach (Point p in game)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }

        public bool Cross(Structure a, int x = 0)
        {
            for (int i = x; i < a.game.Count; i++)
            {
                if (a.game[i].X == game[0].X && a.game[i].Y == game[0].Y)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
