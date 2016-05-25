using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace XNAMigration
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        Level level;
        Camera camera;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
            player = new Player();
            

            base.Initialize();
        }

        protected override void LoadContent()
        {     
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tile.Content = Content;

            level = new Level(Content);

            camera = new Camera(GraphicsDevice.Viewport);

            player.Load(Content);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                 player.Update(gameTime);
            // create a collioin loop for the player to move one and also put camera update in the loop so the camera can move
            /*================================================================================================================*/
            //player Collision
            //camera.Update(player position, map with, map height);
            /*================================================================================================================*/

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //*This is to Render The Camera*spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            spriteBatch.Begin();

            level.DrawTiles(spriteBatch);
            
            player.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
