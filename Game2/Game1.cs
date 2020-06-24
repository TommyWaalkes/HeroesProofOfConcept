using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D texture;
        Texture2D megaman;
        private Vector2 position;
        private SpriteFont font;
        private AnimatedSprite animatedSprite;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            position = new Vector2(0, 0);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //texture = new Texture2D(this.GraphicsDevice, 100, 100);
            //Color[] colorData = new Color[100 * 100];
            //for (int i = 0; i < 10000; i++)
            //{
            //    colorData[i] = Color.Red;
            //}

            //texture.SetData<Color>(colorData);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            megaman = Content.Load<Texture2D>("megaman");
            font = Content.Load<SpriteFont>("test");
            Texture2D texture = Content.Load<Texture2D>("SmileyWalk");
            animatedSprite = new AnimatedSprite(texture, 4, 4);
            // base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            position.X += 1;
            if (position.X > this.GraphicsDevice.Viewport.Width)
            {
                position.X = 0;
            }

            animatedSprite.Update();
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.IndianRed);

            spriteBatch.Begin();
            spriteBatch.Draw(megaman, new Rectangle(0, 0, 100, 50), Color.White);
            spriteBatch.DrawString(font, "Hello World", new Vector2(100, 100), Color.Black);
            animatedSprite.Draw(spriteBatch, new Vector2(400, 200));
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
