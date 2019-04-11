using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Wall : Structure
    {
        public enum Level
        {
            first,
            second,
            third,
            fourth
        }

        public Level GLevel = Level.first;
        public Wall(char sign) : base(sign)
        {
        }

        public void GenerateLevel()
        {
            goodSpots.Clear();

            string level_path = @"Levels\level1.txt";
            if (GLevel == Level.second)
                level_path = @"Levels\level2.txt";
            if (GLevel == Level.third)
                level_path = @"Levels\level3.txt";
            if (GLevel == Level.fourth)
                level_path = @"Levels\level4.txt";

            StreamReader sr = new StreamReader(level_path);
            string[] lines = sr.ReadToEnd().Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '#')
                    {
                        game.Add(new Point { X = j, Y = i });
                    }
                    else if (lines[i][j] == '.')
                    {
                        goodSpots.Add(new Point { X = j, Y = i });
                    }
                }
            }
        }

        public void SwitchLevel()
        {
            if (GLevel == Level.first)
                GLevel = Level.second;
            else if (GLevel == Level.second)
                GLevel = Level.third;
            else if (GLevel == Level.third)
                GLevel = Level.fourth;
        }
    }
}
