using Gameska.Classes;
using System;

namespace Gameska
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
