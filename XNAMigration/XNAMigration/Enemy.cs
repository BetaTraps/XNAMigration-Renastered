﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace XNAMigration
{
    class Enemy
    {
        AnimationPlayer animationPlayer;
          //Animation class to set the the current animation

        Rectangle HitBox;
        Vector2 Pos = Vector2.Zero;
        Vector2 Velocity;

        String Direction;

        public Enemy() { }

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
