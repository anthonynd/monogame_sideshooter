using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SideShooter
{
    public class Game1 : Game
    {
        static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        public static Texture2D bullet;
        Texture2D enemy;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadEntities();
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboard.IsKeyDown(Keys.Escape))
                Exit();

            player.HandleInput(keyboard, gameTime);
            player.MoveBullets(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(color: new Color(25, 25, 30));

            spriteBatch.Begin();
            player.Draw(spriteBatch);
            player.DrawBullets(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        private void LoadEntities()
        {
            Texture2D playerTx = this.Content.Load<Texture2D>("graphics/player");
            Vector2 playerPos = new Vector2(5, (graphics.GraphicsDevice.Viewport.Height - playerTx.Height) / 2);
            player = new Player(playerTx, playerPos);

            bullet = this.Content.Load<Texture2D>("graphics/bullet");
            enemy = this.Content.Load<Texture2D>("graphics/enemy");
        }

        public static bool Contains(Vector2 point)
        {
            return point.X >= 0 &&
                point.X <= graphics.GraphicsDevice.Viewport.Width &&
                point.Y >= 0 &&
                point.Y <= graphics.GraphicsDevice.Viewport.Height;
        }

        public static int Height
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Height;
            }
        }

        public static int Width
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Width;
            }
        }
    }
}
