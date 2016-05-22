using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    class Level
    {
        List<Tile> Tiles = new List<Tile>();
        Tile[,] tiles;

        public Level()
        {
            LoadTiles("content/test.tmx");
        }
        
        string[] line;
        private void LoadTiles(string Path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);
            XmlNode nodes;
            string xPath;
            List<string> lines = new List<string>();
            

            XmlNodeList xnList = doc.SelectNodes("/map/tileset");
            foreach (XmlNode xn in xnList)
            {
                Console.WriteLine("=======================TILE DATA============================");
                int id = int.Parse(xn.Attributes["firstgid"].InnerText);
                Console.WriteLine("ID: " + id);
                string tileName = xn.Attributes["name"].InnerText;
                Console.WriteLine("Tile Name: " + tileName);
                int tileWidth = int.Parse(xn.Attributes["tilewidth"].InnerText);
                Console.WriteLine("Tile Width: " + tileWidth);
                int tileHeight = int.Parse(xn.Attributes["tileheight"].InnerText);
                Console.WriteLine("Tile Height: " + tileHeight);

                Tiles.Add(new Tile(id, tileName, tileWidth, tileHeight));
            }

            Console.WriteLine("=====================MAP DATA==========================");
            xPath = "/map/layer/data";
            nodes = doc.SelectSingleNode(xPath);
            string Data = nodes.InnerText;
            line = Data.Split(',');
            foreach (string word in line)
                Console.Write(word);

            Console.WriteLine();
            Console.WriteLine("=============ARRAY DATA=================");
            Console.WriteLine();

            xPath = "/map/layer";
            nodes = doc.SelectSingleNode(xPath);

            int Width = int.Parse(nodes.Attributes["width"].InnerText);
            int Height = int.Parse(nodes.Attributes["height"].InnerText);

            Console.WriteLine("ARRAY WIDTH: " + Width);
            Console.WriteLine("ARRAY HEIGHT: " + Height);
            int count = 0;
            int j = 0;
            string newLine = null;
            for (int x = 0; x != (Width*Height); x++)
            {
                if (count <= 19)
                {
                     newLine += line[x];
                     //Console.Write(line[x]);
                     count++;
                }
                else
                {     
                   lines.Add(newLine);   

                   
                   newLine = null;
                    count = 0;
                }
            }
            for (int x = 0; x != 19; x++)
            {
                Console.WriteLine(lines[x]);
            }

                tiles = new Tile[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    char TileType;
                }
            }
            Console.WriteLine();
            Console.WriteLine("========================================");
         }   
    }
}
