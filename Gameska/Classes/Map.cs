using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gameska.Classes
{
    class Map
    {
        char[,] map;
        int PlayerPosX;
        int PlayerPosY;

        public Map(Dictionary<string,char> TileTypes, int size)
        {
            map = new char[size, size];

            StreamReader reader = new StreamReader(@"C:\Users\Jaroslav\source\repos\Gameska\Gameska\Resources\Map.csv");
            int posx = 0, posy = 0;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                foreach (var Tile in values)
                {
                    map[posx, posy] = TileTypes[Tile];
                    posx++;
                }
                posx = 0;
                posy++;

            }
        }
    }
}
