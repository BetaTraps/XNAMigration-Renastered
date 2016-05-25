using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    struct Tile
    {
        private Texture2D Texture;
        public Texture2D TEXTURE
        {
            get { return Texture; }
        }

         int Width;
        public int WIDTH
        {
            get { return Width; }
        }

         int Height;
        public int HEIGHT
        {
            get { return Height; }
        }

        //private int ID;
        //public int id
        //{
        //    get { return ID; }
        //}

        static ContentManager content;
        public static ContentManager Content
        {
            set { content = value; }
        }

        Vector2 size;
        public Vector2 Size
        {
            get { return size; }
        }
        public Tile(Texture2D TileName, int TileWidth, int TileHeight)
        {
            Texture = TileName;
            this.Width = TileWidth;
            this.Height = TileHeight;
            size = new Vector2(Width, Height);
        }
    }
}
