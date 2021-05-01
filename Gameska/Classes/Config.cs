using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Gameska.Classes
{
    class Config
    {
        int MapDimensions;              // Defines size of map array [MapDimensions,MapDimensions]
        string[,] MapTiles;             // Defines Tiles used on map [ID of tile in CSV, CHAR representation of tile] E.g [1,#] - Wall / [4,~] - Water

        public void LoadConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("\\config.xml");

            MapDimensions = int.Parse(doc.DocumentElement.SelectSingleNode("/Config/Map/MapDimensions").InnerText);     //Get map size

            XmlNode TilesParent = doc.DocumentElement.SelectSingleNode("/Config/Map/MapTiles");                         //Get parent node of Tile types for easy manipulation

            MapTiles = new string[TilesParent.ChildNodes.Count, TilesParent.ChildNodes.Count];                          //Set size of TyleType array

            int TypeIteration = 0;                                                                                      
            foreach (XmlNode n in TilesParent.ChildNodes)
            {
                MapTiles[TypeIteration, 0] = n.SelectSingleNode("/CSV").InnerText;
                MapTiles[TypeIteration, 1] = n.SelectSingleNode("/CHAR").InnerText;
            }


        }
    }
}
