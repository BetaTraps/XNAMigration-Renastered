﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace XNAMigration
{
    class Bullet
    {
        Texture2D texture;
        Vector2 bulletPos;
        Vector2 OriginPos;
        float bulletSpeed = 1.0f;
        ContentManager Content;

        public Bullet()
        {
            
        }

        public void Load()
        {

        }
        public void UpdateBullet()
        {

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture,bulletPos,Color.White);    
        }

    }
}
