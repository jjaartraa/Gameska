using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Gameska.Classes
{
    class Config
    {
        int MapDimensions;                                                              // Defines size of map array [MapDimensions,MapDimensions]
        Dictionary<string, char> MapTiles = new Dictionary<string, char>();               // Defines Tiles used on map [ID of tile in CSV, CHAR representation of tile] E.g [1,#] - Wall / [4,~] - Water

        public char[,] map;         // Map Array
        public int PPX;             // Player Position X
        public int PPY;             // Player Position Y
        public int ViewResolution;  // Dimensions of displayed part of map char[DisplayResolution,DisplayResolution]

        public void LoadConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\\Users\Jaroslav\source\repos\Gameska\Gameska\Resources\Config.xml");

            MapDimensions = int.Parse(doc.DocumentElement.SelectSingleNode("/Config/Map/MapDimensions").InnerText);         //Get map size
            ViewResolution = int.Parse(doc.DocumentElement.SelectSingleNode("/Config/Display/Resolution").InnerText);       //Get Resolution
            string key;
            char val;

            foreach (XmlNode n in doc.DocumentElement.SelectSingleNode("/Config/Map/MapTiles").ChildNodes)
            {
                key = n.SelectSingleNode("CSV").InnerText;
                if (n.SelectSingleNode("CHAR").InnerText == "")
                {
                    val = ' ';
                }
                else
                {
                    val = char.Parse(n.SelectSingleNode("CHAR").InnerText);
                }
                
                MapTiles.Add(key, val);
            }

            LoadMap(MapTiles, MapDimensions);
        }

        private void LoadMap(Dictionary<string, char> TileTypes, int size)
        {
            map = new char[size, size];

            StreamReader reader = new StreamReader(@"C:\\Users\Jaroslav\source\repos\Gameska\Gameska\Resources\Map.csv");
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
        }
    }
}
