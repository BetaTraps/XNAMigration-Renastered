using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAMigration
{
    class Menu: ScreenState
    {
        Texture2D playButton;

        public Menu()
        {

        }

        public void Load(ContentManager Content)
        {
              //loads the buttons images
        }

        public void Update(Game game)
        {
            MouseState mouse;
            game.IsMouseVisible = true;
            
               //allows mouseinput and checks if button clicked
        }

        public void Draw(SpriteBatch sprite)
        {
               //draws the buttons
        }
    }
}
