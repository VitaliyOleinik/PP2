using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleSnake
{
    class Food : Structure
    {
        public Food(char sign) : base(sign)
        {
        }

        /*public void CorrectGoodSpots(Structure structure)
        {
            foreach (Point p in structure.game)
            {
                goodSpots.Remove(p);
            }
        }

        public void GenerateFood(List<Point> goodSpots, List<Point> bad)
        {
            Random random = new Random();

            game[0] = goodSpots[random.Next(0, goodSpots.Count - 1)];

           // DrawGame();
        }*/
        private bool GoodPoint(Point p, List<Point> usedPoints)
        {
            bool res = true;

            foreach (Point t in usedPoints)
            {
                if (t.X == p.X && t.Y == p.Y)
                {
                    res = false;
                    break;
                }
            }

            return res;
        }

        public void GenerateFood(List<Point> usedPoints1, List<Point> usedPoints2)
        {
            game.Clear();
            Random random = new Random(DateTime.Now.Second);
            Point p = new Point
            {
                X = random.Next(1, 50),
                Y = random.Next(1, 29)
            };
            while (!GoodPoint(p, usedPoints1) || !GoodPoint(p, usedPoints2))
            {
                p = new Point
                {
                    X = random.Next(1, 50),
                    Y = random.Next(1, 29)
                };
            }
            game.Add(p);
        }
    }
}
