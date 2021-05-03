using Gameska.Classes.SnakeGameClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gameska.Classes
{
    class SnakeGame
    {
        MapGenerator Map = new MapGenerator();
        List<Coordinates> SnakeBody = new List<Coordinates>();
        Coordinates Food;
        Coordinates lastPost = new Coordinates();
        string Direction = "w";

        public SnakeGame(int GameSpeed, int GridWidht, int GridHeight)
        {
            StartGame(GridWidht, GridHeight, GameSpeed);
        }
        public void SetDirection(string dir)
        {
            Direction = dir;
        }

        private void StartGame(int Width, int Height, int Speed)
        {
            
            Timer t = new Timer(TimerCallback, null, 0, 2000);
            Map.InicializeMap(Width, Height);
            SnakeBody.Add(new Coordinates(Width / 2, Height / 2));

        }
        private void MoveSnake()
        {
            Coordinates SnakePos = SnakeBody[0];
            switch (Direction)
            {
                case "W":
                    SnakePos.y--;
                    break;

                case "A":
                    SnakePos.x--;
                    break;

                case "S":
                    SnakePos.y++;
                    break;

                case "D":
                    SnakePos.x++;
                    break;
                default:
                    break;
            }

            switch (CheckPosition(SnakePos))
            {
                case 1:
                    SnakeBody.RemoveAt(0);
                    SnakeBody.Add(SnakePos);
                    break;
                case 2:
                    SnakeBody.Add(SnakePos);
                    break;
                case 3:
                    GameOver();
                    break;
                default:
                    break;
            }
        }
        private void SpawnFood()
        {
            while (CheckPosition(Food)!=1)
            {
                Food = Food.NewRandomCoordinates(Map.Width, Map.Height);
            }
        }

        private void TimerCallback(Object o)
        {
            MoveSnake();
            GC.Collect();
        }
        private int CheckPosition(Coordinates pos)
        {


            return 1;
        }

        private void DrawScene()
        { 
        
        }

        private void GameOver()
        { 
        
        }
    }
}
