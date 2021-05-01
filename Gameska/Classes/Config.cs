using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Gameska.Classes
{
    class Config
    {
        int MapDimensions;                              // Defines size of map array [MapDimensions,MapDimensions]
        Dictionary<string, char> MapTiles;              // Defines Tiles used on map [ID of tile in CSV, CHAR representation of tile] E.g [1,#] - Wall / [4,~] - Water

        public int PPX;                                 // Player Position X
        public int PPY;                                 // Player Position Y
        public int DisplayResolution;                   // Dimensions of displayed part of map char[DisplayResolution,DisplayResolution]

        public char[,] LoadConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("\\config.xml");

            MapDimensions = int.Parse(doc.DocumentElement.SelectSingleNode("/Config/Map/MapDimensions").InnerText);     //Get map size
            DisplayResolution = int.Parse(doc.DocumentElement.SelectSingleNode("/Config/Display/Resolution").InnerText);

            foreach (XmlNode n in doc.DocumentElement.SelectSingleNode("/Config/Map/MapTiles").ChildNodes)
            {
                MapTiles.Add(n.SelectSingleNode("/CSV").InnerText, char.Parse(n.SelectSingleNode("/CHAR").InnerText));
            }

            return LoadMap(MapTiles, MapDimensions);
        }

        private char[,] LoadMap(Dictionary<string, char> TileTypes, int size)
        {
            char[,] map = new char[size, size];

            StreamReader reader = new StreamReader(@"C:\Users\Jaroslav\source\repos\Gameska\Gameska\Resources\Map.csv");
            int posx = 0, posy = 0;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                foreach (var Tile in values)
                {
                    if (TileTypes[Tile] == '@')
                    {
                        PPX = posx;
                        PPY = posy;
                    }

                    map[posx, posy] = TileTypes[Tile];
                    posx++;
                }
                posx = 0;
                posy++;
            }

            return map;
        }
    }
}
