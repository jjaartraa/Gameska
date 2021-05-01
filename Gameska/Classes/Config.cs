using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Gameska.Classes
{
    class Config
    {
        int MapDimensions;              // Defines size of map array [MapDimensions,MapDimensions]
        Dictionary<string,char> MapTiles;             // Defines Tiles used on map [ID of tile in CSV, CHAR representation of tile] E.g [1,#] - Wall / [4,~] - Water

        public void LoadConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("\\config.xml");

            MapDimensions = int.Parse(doc.DocumentElement.SelectSingleNode("/Config/Map/MapDimensions").InnerText);     //Get map size


            int TypeIteration = 0;
            foreach (XmlNode n in doc.DocumentElement.SelectSingleNode("/Config/Map/MapTiles").ChildNodes)
            {
                MapTiles.Add(n.SelectSingleNode("/CSV").InnerText,char.Parse(n.SelectSingleNode("/CHAR").InnerText));
            }

            Map map = new Map(MapTiles, MapDimensions);
        }
    }
}
