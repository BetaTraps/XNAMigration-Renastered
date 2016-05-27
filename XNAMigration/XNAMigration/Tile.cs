using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    enum TileCollision
    {
        Passable = 0,
        impassable = 1,
        Platform = 2,
    }

    struct Tile
    {
        private Texture2D Texture;
        public Texture2D TEXTURE
        {
            get { return Texture; }
        }

        public TileCollision Collision;

        public const int Width = 32;

        public const int Height = 32;

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

        public static Vector2 size = new Vector2(Width,Height);
        public Vector2 Size
        {
            get { return size; }
        }
        public Tile(Texture2D TileName, TileCollision collision)
        {
            Texture = TileName;
            Collision = collision;
        }
    }
}
