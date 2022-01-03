using System;
using System.Collections.Generic;
using System.Text;

namespace Gameska.Classes.SnakeGameClasses
{
    class MapGenerator
    {
        public int Width;
        public int Height;
        public char[,] Grid;

        public MapGenerator()
        {
        }
        public void InicializeMap(int width, int height = 0)
        {
            if (width < 10)
            {
                width = 10;
            }
            if (height < 10)
            {
                height = 10;
            }
            Grid = new char[width, height];

            this.Width = width;
            this.Height = height;

            SetBounds();
        }
        private void SetBounds()
        {
            for (int Y = 0; Y < Height; Y++)
            {
                for (int X = 0; X < Width; X++)
                {
                    Grid[X, Y] = ' ';
                }
            }

            for (int Y = 0; Y < Height; Y++)
            {
                if (Y == 0 || Y == Height - 1)
                {
                    for (int X = 0; X < Width; X++)
                    {
                        Grid[X, Y] = '▓';
                    }
                }
                else
                {
                    Grid[0, Y] = '▓';
                    Grid[Width - 1, Y] = '▓';
                }
            }
        }
    }
}
