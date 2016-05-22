using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    public class Tile
    {
        Texture2D Texture;
        int Width;
        int Height;

        int ID;

        static ContentManager content;
        public static ContentManager Content
        {
            set { content = value; }
        }

        public Tile(int ID,string TileName, int TileWidth, int TileHeight)
        {
            Texture = content.Load<Texture2D>(TileName);
            this.ID = ID;
            this.Width = TileWidth;
            this.Height = TileHeight;
        }
    }
}
