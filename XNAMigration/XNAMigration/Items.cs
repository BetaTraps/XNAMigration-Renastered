using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    class Items
    {
        Vector2 pos;
        Vector2 DropPos;

        float dropRate;
        float decayRate;

        AnimationPlayer animateObjects;
        //animations if the objects float

        Texture2D Texture;

        public Items()
        {

        }

        public void Load(ContentManager Content)
        {
                 //loads the items image
        }

        public void Update()
        {
               //update if item used of droped or picked up
        }

        public void Draw(SpriteBatch sprite)
        {
                //draw item
        }
    }
}
