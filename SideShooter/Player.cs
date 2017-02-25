using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideShooter
{
    class Player : Sprite2D
    {
        private float speed = 250;              // Pixels per second
        private float bulletSpeed = 1000;       // Pixels per second
        private float fireRate = 10;             // Bullets per second
        private double shootTime = 0;

        private List<Sprite2D> bullets;

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            bullets = new List<Sprite2D>();
        }
        public Player(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            bullets = new List<Sprite2D>();
        }

        public void HandleInput(KeyboardState kbd, GameTime time)
        {
            float y = speed * (float) time.ElapsedGameTime.TotalSeconds;
            if (kbd.IsKeyDown(Keys.Up))
            {
                TranslateY(-y);
                if (this.position.Y < 0)
                {
                    this.position.Y = 0;
                }
            }
            if (kbd.IsKeyDown(Keys.Down))
            {
                TranslateY(y);
                if (this.position.Y + this.Height > Game1.Height)
                {
                    this.position.Y = Game1.Height - this.Height;
                }
            }
            if (kbd.IsKeyDown(Keys.Space))
            {
                double gameTime = time.TotalGameTime.TotalSeconds;
                if (gameTime - shootTime > 1/fireRate)
                {
                    Shoot(Game1.bullet);
                    shootTime = gameTime;
                }
            }
        }

        public void Shoot(Texture2D texture)
        {
            Sprite2D b = new Sprite2D(texture, this.Tip);
            bullets.Add(b);
        }

        public void MoveBullets(GameTime time)
        {
            float disp = bulletSpeed * (float) time.ElapsedGameTime.TotalSeconds;
            foreach (Sprite2D bullet in bullets)
            {
                bullet.TranslateX(disp);
            }
        }

        public void DrawBullets(SpriteBatch batch)
        {
            foreach (Sprite2D bullet in bullets)
            {
                bullet.Draw(batch);
            }
        }

        private Vector2 Tip
        {
            get
            {
                return new Vector2(this.Width, this.position.Y + this.Height/2 - Game1.bullet.Height/2);
            }
        }
    }
}
