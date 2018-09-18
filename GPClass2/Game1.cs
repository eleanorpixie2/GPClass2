using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GPClass2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 pacManLoc;
        Vector2 pacManDir;
        float pacManSpeed;
        Texture2D pac;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Change the frame fate to 30 Frames per second the default is 60fps
            //TargetElapsedTime = TimeSpan.FromTicks(333333); // you may need to add using System; to get the TimeSpan function
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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
            pac = Content.Load<Texture2D>("PacmanSingle");
            //center pacman
            pacManLoc = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);//Start Pacmanloc in the center of the screen
            pacManDir = new Vector2(1, 0);//start moving left

            pacManSpeed = 200  ;//initial pacman speed
            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic here
            //Elapsed time since last update will be used to correct movement speed
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Turn PacMan Around if it hits the edge of the screen
            if((pacManLoc.X>graphics.GraphicsDevice.Viewport.Width-pac.Width)||(pacManLoc.X<0))
            {
                pacManDir = Vector2.Negate(pacManDir);
            }

            //Move Pacman
            //simple move moves pacman by pacmandir on every update
            pacManLoc = pacManLoc + ((pacManDir * pacManSpeed) * (time / 1000));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(pac, pacManLoc, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
