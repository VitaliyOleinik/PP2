using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;


namespace ConsoleSnake
{
    class Game
    {
        Snake snake;
        Wall wall = new Wall('#');
        Food food = new Food('%');

        Direction dir = new Direction();

        private bool GameOverFlag = false;
        ConsoleKeyInfo key;

        public int lenghtOut; // для вывода длины змеи
        public long scoreOut = 0; // для вывода типа рекорда
        //public string[] warning = new string[8]; // для предупреждения о переходе на след уровень
        //public long check_for_warning; // для проверки перехода
        public Game()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 30);
            //speed = s;
        }



        Timer timer;


        public void StartGame()
        {
            timer = new Timer(100);
            
            snake = new Snake('O');
            timer.Elapsed += GameTimeElapsed;
            timer.Start();


            food.GenerateFood(wall.game, snake.game);

            food.DrawGame();

            Console.ForegroundColor = ConsoleColor.Blue;
            wall.GenerateLevel();
            wall.DrawGame();

            while (!GameOverFlag)
            {
                dir.SnakeDirection(key);
                key = Console.ReadKey();
            }
        }

        private void GameTimeElapsed(object sender, ElapsedEventArgs e)
        {
            snake.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            //Point tail = new Point { X = snake.game[snake.game.Count - 1].X, Y = snake.game[snake.game.Count - 1].Y };
            //Console.SetCursorPosition(tail.X, tail.Y);
            //Console.Write(" ");
            snake.Move(dir);
            snake.DrawGame();

            lenghtSnakeOutput(); // вывод длины змеи


            if (snake.Cross(food))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                food.GenerateFood(wall.game, snake.game);
                food.DrawGame();

                snake.game.Add(new Point { X = snake.game[0].X, Y = snake.game[0].Y });

                Console.ForegroundColor = ConsoleColor.White;
                ScoreOutput(); // вывод рекорда

                

                Console.SetCursorPosition(53, 10);
                //Console.Write(warning); // вывод предупреждения
                WarningPrint(scoreOut);


                if (scoreOut % 1500 == 0)
                {
                    NextLevel();
                }
            }
            else if (snake.Cross(snake, 1) || snake.Cross(wall))
            {
                gameOwer();
            }
        }

        private void lenghtSnakeOutput()
        {
            lenghtOut = snake.game.Count;
            Console.SetCursorPosition(55, 5);
            string outp = "Snake lenght: " + lenghtOut;
            Console.Write(outp);
        }

        private void ScoreOutput()
        {
            scoreOut += 6000;
            Console.SetCursorPosition(55, 7);
            Console.Write("Current score: " + scoreOut);
        }

        private void NextLevel()
        {
            wall.game.Clear();
            food.game.Clear();
            snake.game.Clear();
            Console.Clear();
            timer.Enabled = false;

            if (wall.GLevel == Wall.Level.first && scoreOut == 6000)
            {
                VictoryShow();
            }
            else if (wall.GLevel != Wall.Level.first && scoreOut != 6000)
            {
                wall.SwitchLevel();
            }
            
            StartGame();
        }

        private void VictoryShow()
        {

            //timer.Enabled = false;
            Console.Clear();

            //Console.ForegroundColor = ConsoleColor.Green;
            wall.game.Clear();
            snake.game.Clear();
            food.game.Clear();
            VinShow vs = new VinShow('*');
            vs.VictoryGenerate();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            vs.DrawGame();
        }

        private void WarningPrint(long s)
        {
            if (s == 1450 || s == 2850 || s == 3850 || s == 4850)
            {
                Console.Write("To go to the next level: " , Console.ForegroundColor = ConsoleColor.White);
                Console.Write("3 ", Console.ForegroundColor = ConsoleColor.Red);
                Console.Write("food left", Console.ForegroundColor = ConsoleColor.White);
            }
            else if (s == 1400 || s == 2900|| s == 3900|| s == 4800)
            {
                Console.Write("To go to the next level: ", Console.ForegroundColor = ConsoleColor.White);
                Console.Write("3 ", Console.ForegroundColor = ConsoleColor.Red);
                Console.Write("food left", Console.ForegroundColor = ConsoleColor.White);
            }
            else if (s == 1450 || s == 2950 || s == 3950 || s == 4950)
            {
                Console.Write("To go to the next level: ", Console.ForegroundColor = ConsoleColor.White);
                Console.Write("3 ", Console.ForegroundColor = ConsoleColor.Red);
                Console.Write("food left", Console.ForegroundColor = ConsoleColor.White);
            }
        }


        private void gameOwer()
        {
            Console.Clear();
            timer.Stop();

            Console.Clear();
            wall.game.Clear();

            wall.GLevel = Wall.Level.first;
            wall.GenerateLevel();
            

            Console.ForegroundColor = ConsoleColor.Red;
            wall.DrawGame();

            GameOverShow go = new GameOverShow('*');
            go.DeathGenerate();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            go.DrawGame();
        }
    }
}
