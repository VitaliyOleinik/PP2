using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class VinShow : Structure
    {
        public VinShow(char sign) : base(sign)
        {
        }

        public void VictoryGenerate()
        {
            string[] symb2 = File.ReadAllText(@"Victory\victory.txt").Split('\n');

            for (int i = 0; i < symb2.Length; i++)
            {
                for (int j = 0; j < symb2[i].Length; j++)
                {
                    if (symb2[i][j] == '*')
                    {
                        game.Add(new Point { X = j, Y = i });
                    }
                }
            }

        }
    }
}
