using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class GameOverShow : Structure
    {
        public GameOverShow(char sign) : base(sign)
        {
        }

        public void DeathGenerate()
        {
            string[] symb = File.ReadAllText(@"GameOver\gameover.txt").Split('\n');

            for (int i = 0; i < symb.Length; i++)
            {
                for (int j = 0; j < symb[i].Length; j++)
                {
                    if (symb[i][j] == '*')
                    {
                        game.Add(new Point { X = j, Y = i });
                    }
                }
            }

        }
    }
}
