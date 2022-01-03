using System;
using System.Collections.Generic;
using System.Text;

namespace Gameska.Classes.SnakeGameClasses
{
    class Coordinates
    {
        public int x;
        public int y;

        public Coordinates()
        { }
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinates NewRandomCoordinates(int maxWidth, int maxHeight)
        {
            Random rnd = new Random();
            return new Coordinates(rnd.Next(0, maxWidth),rnd.Next(0, maxHeight));
        }
    }
}
