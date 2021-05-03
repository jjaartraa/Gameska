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

        public Coordinates NewRandomCoordinates(int min, int max)
        {
            Random rnd = new Random();
            return new Coordinates(rnd.Next(min,max),rnd.Next(min,max));
        }
        public Coordinates NewRandomCoordinates(int minx, int maxx, int miny, int maxy)
        {
            Random rnd = new Random();
            return new Coordinates(rnd.Next(minx, maxx), rnd.Next(miny, maxy));
        }
    }
}
