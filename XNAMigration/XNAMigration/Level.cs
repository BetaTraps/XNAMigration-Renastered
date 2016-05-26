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
        int[][] tileData;
        int Width;
        int Height;

        ContentManager Content;

        public Level(ContentManager content)
        {
            Content = content;
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

                //Tiles.Add(new Tile(tileName, tileWidth, tileHeight));
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

            Width = int.Parse(nodes.Attributes["width"].InnerText);
            Height = int.Parse(nodes.Attributes["height"].InnerText);

            Console.WriteLine("ARRAY WIDTH: " + Width);
            Console.WriteLine("ARRAY HEIGHT: " + Height);


            tileData = new int[Height][];
            

            for (int y = 0; y <= Height - 1; y++ )
            {
                string[] tempStorage = line[y].Split(',');
                tileData[y] = new int[Width];
                for (int x = 0; x <= Width - 1; x++)
                {

                    tileData[y][x] = int.Parse(tempStorage[x]);
                }
            }

            tiles = new Tile[Width+1,Height+1];

            for (int y = 0; y <= Height - 1; y++)
            {
                for (int x = 0; x <= Width - 1; x++)
                {
                    tiles[x, y] = getTiles(tileData[y][x],x,y);
                }
            }

            Console.WriteLine();
            Console.WriteLine("========================================");
         }

        private Tile getTiles(int number,int x, int y)
        {
            switch(number)
            {
                case 0:
                    return new Tile(null, 32, 32);
                case 1://Tile 1
                    return new Tile(Content.Load<Texture2D>("Tile1"), 32, 32);    
                case 2://Tile 2
                    return new Tile(Content.Load<Texture2D>("Tile2"), 32, 32);   
                case 3://Tile 3
                    return new Tile(Content.Load<Texture2D>("Tile3"), 32, 32);
                case 4://Tile 4
                    return new Tile(Content.Load<Texture2D>("Tile4"), 32, 32);
                default:
                    throw new NotSupportedException(String.Format("Unsupported tile type character '{0}' at position {1}, {2}.", number,x,y));
            }
            //return new Tile("Tile1", Tiles[1].WIDTH, Tiles[1].HEIGHT);
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

        public void DrawTiles(SpriteBatch sprite)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Texture2D texture = tiles[x,y].TEXTURE;
                    if (texture != null)
                    {
                       Vector2 pos = new Vector2(x, y) * tiles[x,y].Size;
                       sprite.Draw(texture, pos, Color.White);
                    }
                    
                }
            }
        }
    }
}
