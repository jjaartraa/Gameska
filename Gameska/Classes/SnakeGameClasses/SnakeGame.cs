using Gameska.Classes.SnakeGameClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Gameska.Classes
{
    class SnakeGame
    {

        // wall     ▓
        // food     ■
        // snake    @

        MapGenerator Map = new MapGenerator();
        List<Coordinates> SnakeBody = new List<Coordinates>();
        Coordinates Food = new Coordinates();
        string Direction = "";

        public SnakeGame(int GameSpeed, int GridWidht, int GridHeight)
        {
            StartGame(GridWidht, GridHeight, GameSpeed);
        }
        public void SetDirection(string dir)
        {
            Direction = dir;
        }

        private void StartGame(int Width, int Height, int Speed = 0)
        {
            Map.InicializeMap(Width, Height);
            SnakeBody.Add(new Coordinates(Width / 2, Height / 2));
            SnakeBody.Add(new Coordinates(Width / 2, Height / 2));
            SpawnFood();
        }

        public string MoveSnake()
        {
            Coordinates SnakePos = SnakeBody[SnakeBody.Count-1];
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
                    SnakeBody.Add(new Coordinates(SnakePos.x, SnakePos.y));
                    break;
                case 2:
                    SnakeBody.Add(new Coordinates(SnakePos.x, SnakePos.y));
                    SpawnFood();
                    break;
                case 3:
                    GameOver();
                    break;
                default:
                    break;
            }
            return DrawScene();
        }
        private void SpawnFood()
        {
            do
            {
                Food = Food.NewRandomCoordinates(Map.Width - 1, Map.Height - 1);
            } while (CheckPosition(Food) != 2);
        }

        private int CheckPosition(Coordinates pos)
        {
            if (Map.Grid[pos.x, pos.y] == '▓')
            {
                return 3;
            }
            else if (pos.x == Food.x && pos.y == Food.y)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        private string DrawScene()
        {
            string map = "";
            //char[,] TempMap = Map.Grid;
            MapGenerator TempMap = new MapGenerator()
            {
                Grid = (char[,])Map.Grid.Clone(),
                Width = Map.Width,
                Height = Map.Height
               
            };
            TempMap.Grid[SnakeBody[0].x, SnakeBody[0].y] = ' ';
            TempMap.Grid[Food.x, Food.y] = '■';
            foreach (var part in SnakeBody)
            {
                TempMap.Grid[part.x, part.y] = '@';
            }
            for (int Y = 0; Y < Map.Width; Y++)
            {
                for (int X = 0; X < Map.Height; X++)
                {
                    map += TempMap.Grid[X, Y];
                }
                map += '\n';
            }
            
            return map;
        }

        private void GameOver()
        {
            StartGame(1, 20, 20);
        }
    }
}
