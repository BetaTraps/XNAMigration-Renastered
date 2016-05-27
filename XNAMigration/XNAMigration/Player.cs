using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace XNAMigration
{
    public class Player
    {
        AnimationPlayer animationPlayer;

        Animation Walk;
        Animation Idle;
        Animation Jump;
        Animation Attack;
        Animation Celebrate;

        private bool Right = false;
        private bool Left = false;
        private bool Up = false;
        private bool Down = false;
        private bool hasJumped = false;
        private bool isShoot = false;
        private bool isAttacking = false;
        private bool isStanding = true;

        private String lastDirection = "Right";

        List<Bullet> bullets = new List<Bullet>();

        private Vector2 Pos = Vector2.Zero;
        private Vector2 velocity;
        private Rectangle rect;

        public Vector2 Position
        {
            get { return Pos; }
        }

        public Player() { animationPlayer = new AnimationPlayer(); hasJumped = false; }

        public void Load(ContentManager Content)
        {

            Walk = new Animation(Content.Load<Texture2D>("Run"/*"mikuWalk"*/), /*77*/146, 75f, true);
            Idle = new Animation(Content.Load<Texture2D>("idle"/*"mikuIdle"*/), /*59*/88, 100f, true);
            Jump = new Animation(Content.Load<Texture2D>("mikuJump"), 78, 150f, true);
            Attack = new Animation(Content.Load<Texture2D>("Attack"/*"mikuYell"*/), /*85*/174, 100f, true);
            Celebrate = new Animation(Content.Load<Texture2D>("mikuCelebrate"), 84, 100f, true);
        }


        public void Update(GameTime gameTime)
        {


            Pos += velocity;
            
            Input();
            if (Right)
                velocity.X = 3f;
            else if (Left)
                velocity.X = -3f;
            else velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                Pos.Y -= 10f;
                velocity.Y = -7f;
                hasJumped = true; animationPlayer.PlayAnimation(Jump);
            }
            //float i = 1;
            //velocity.Y += 0.15f * i;

            if (isAttacking)
            {
                animationPlayer.PlayAnimation(Attack);
            }
            

            if (hasJumped)
                animationPlayer.PlayAnimation(Jump);

            if (Right == false && Left == false && hasJumped == false)
                isStanding = true;
            else isStanding = false;

            if ((Right == true || Left == true) && hasJumped == false)
                animationPlayer.PlayAnimation(Walk);
            if (isStanding)
                animationPlayer.PlayAnimation(Idle);
            if (isShoot == true && isStanding == true)
                animationPlayer.PlayAnimation(Attack);

            //if (isShoot == true && hasJumped == true)
            //animationPlayer.PlayAnimation(ShootJump);
            //if (isShoot == true && (Right == true || Left == true))
            //animationPlayer.PlayAnimation(ShootWalk);
            //rect = new Rectangle((int)Pos.X, (int)Pos.Y,59,66);
             rect = new Rectangle((int)Pos.X, (int)Pos.Y, 59, 66);

        }

        private void Input()
        {
            KeyboardState keys = Keyboard.GetState();
            GamePadState pad = GamePad.GetState(PlayerIndex.One);

            if (keys.IsKeyDown(Keys.Right) || keys.IsKeyDown(Keys.D) || pad.ThumbSticks.Left.X > 0) { Right = true; lastDirection = "Right"; }
            else { Right = false; }
            if (keys.IsKeyDown(Keys.Left) || keys.IsKeyDown(Keys.A) || pad.ThumbSticks.Left.X < 0) { Left = true; lastDirection = "Left"; }
            else { Left = false; }
            if (keys.IsKeyDown(Keys.Up) || keys.IsKeyDown(Keys.W) || pad.ThumbSticks.Left.Y > 0) { Up = true; }
            else { Up = false; }
            if (keys.IsKeyDown(Keys.Down) || keys.IsKeyDown(Keys.S) || pad.ThumbSticks.Left.Y < 0) { Down = true; }
            else { Down = false; }
            if (keys.IsKeyDown(Keys.C)) { isAttacking = true; }
            else { isAttacking = false; }
            


        }

        private void shootBullet()
        {

        }

        private void meleeAttack()
        {

        }

        public void Collision(Rectangle newRect, int xOffset, int yOffset)
        {
            if (rect.TouchTopOf(newRect))
            {
                rect.Y = newRect.Y - rect.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (rect.TouchLeftOf(newRect))
            {
                Pos.X = newRect.X - newRect.Width - 2;
            }
            if (rect.TouchRightOf(newRect))
            {
               Pos.X = newRect.X + newRect.Width + 2;
            }
           

            //collision with the map
            if (Pos.X < 0) Pos.X = 0;
            if (Pos.X > xOffset - rect.Width) Pos.X = xOffset - rect.Width;
            if (Pos.Y < 0) velocity.Y = 1f;
            if (Pos.Y > yOffset - rect.Height) Pos.Y = yOffset - rect.Height;
        }

        public void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            SpriteEffects flip = SpriteEffects.None;
            //Flip these to get the right orientatinon

            if (lastDirection == "Left")
                flip = SpriteEffects.None;
            else if (lastDirection == "Right")
                flip = SpriteEffects.FlipHorizontally;

            animationPlayer.Draw(gameTime, sprite, Pos, flip);
            
        }
    }
}
