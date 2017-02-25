using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideShooter
{
    class Sprite2D
    {
        protected enum SpriteState { Enabled, Disabled };

        protected Vector2 position;
        protected Texture2D texture;
        protected int width;
        protected int height;
        protected Sprite2D.SpriteState state;

        public Sprite2D(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.width = texture.Width;
            this.height = texture.Height;
            this.position = position;
            this.state = SpriteState.Enabled;
        }

        public Sprite2D(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.width = texture.Width;
            this.height = texture.Height;
            this.position.X = x;
            this.position.Y = y;
            this.state = SpriteState.Enabled;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, position);
        }

        public Boolean IsEnabled()
        {
            return state == SpriteState.Enabled;
        }

        public void Translate(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

        public void TranslateX(float x)
        {
            Translate(x, 0);
        }

        public void TranslateY(float y)
        {
            Translate(0, y);
        }

        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle
                (
                    (int) position.X,
                    (int) position.Y,
                    width,
                    height
                );
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public float X
        {
            get
            {
                return position.X;
            }
            set
            {
                position.X = value;
            }
        }

        public float Y
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

    }
}
