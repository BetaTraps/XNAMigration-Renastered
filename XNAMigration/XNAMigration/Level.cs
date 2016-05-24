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
            //Data.Split('r').Join<string>;
            //Data.Remove('\r');
            line = Data.Split(new[] { Environment.NewLine },
                                     StringSplitOptions.RemoveEmptyEntries);
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


            int[][] tileData = new int[Height][];
            

            for (int y = 0; y <= Height - 1; y++ )
            {
                string[] tempStorage = line[y].Split(',');
                tileData[y] = new int[Width];
                for (int x = 0; x <= Width - 1; x++)
                {

                    tileData[y][x] = int.Parse(tempStorage[x]);
                    //Console.WriteLine(tileData[y][x]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("========================================");
         }

        private void getTiles()
        {

        }

        public void Collision()
        {

        }

        public void Load(ContentManager Content)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch sprite)
        {

        }
    }
}
