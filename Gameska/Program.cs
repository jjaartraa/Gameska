﻿using Gameska.Classes;
using System;
using System.Threading;

namespace Gameska
{
    class Program
    {
        /*
        // Gameska Main
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
        */
        // Snake Game Main
        
        static SnakeGame Snek = new SnakeGame(1, 20, 20);
        static void Main(string[] args)
        {

            ConsoleKey lastkey = new ConsoleKey();

            Timer t = new Timer(TimerCallback, null, 500, 500);
            do
            {
                lastkey = Console.ReadKey().Key;
                Snek.SetDirection(lastkey.ToString());
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
