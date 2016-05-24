using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAMigration
{
    class ScreenState
    {
        bool isMenu;
        bool isGame;
        bool isGameOver;
        bool isChoseLevel;

        public ScreenState()
        {
            isMenu = true;
        }

        public void Load(ContentManager Content)
        {
                 //loads all that states data
        }

        public void Update(GameTime gameTime,Game game)
        {
              //set check what state the game is in.
        }
        public void Draw(SpriteBatch sprite)
        {
            //Draws the current state the game is in.
        }
    }
}
