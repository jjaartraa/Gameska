using Gameska.Classes;
using System;
using System.Threading;

namespace Gameska
{
    class Program
    {
        static SnakeGame Snek;
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("Please select Game: snake / maze." + Environment.NewLine + "Or type exit to exit");
                userInput = Console.ReadLine();

                switch (userInput.ToUpper())
                {
                    case "SNAKE":
                        Snake();
                        break;
                    case "MAZE":
                        Maze();
                        break;
                    case "EXIT":
                        break;
                    default:
                        Console.WriteLine("Sorry I don't see this as an option.");
                        break;
                }
            } while (userInput.ToUpper() != "EXIT");
        }

        static void Snake()
        {
            Snek = new SnakeGame(1,20,20);
            ConsoleKey lastkey = new ConsoleKey();

            Timer t = new Timer(TimerCallback, null, 500, 200);
            do
            {
                lastkey = Console.ReadKey().Key;
                Snek.SetDirection(lastkey.ToString());
            } while (lastkey != ConsoleKey.Escape);
        }

        static void Maze()
        {
            ConsoleKey lastkey = new ConsoleKey();

            Console.WriteLine("Press Any Key To Start");
            Config cfg = new Config();
            cfg.LoadConfig();
            Display display = new Display(cfg.map, cfg.ViewResolution, cfg.PPX, cfg.PPY);

            do
            {
                lastkey = Console.ReadKey().Key;
                display.PlayerMove(lastkey.ToString());
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(display.Refresh());

            } while (lastkey != ConsoleKey.Escape);
        }

        private static void TimerCallback(Object o)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(Snek.MoveSnake());
            GC.Collect();
        }

    }
}
