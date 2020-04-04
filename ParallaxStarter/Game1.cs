using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;
using System;

namespace Game3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            // Set up size
            graphics.PreferredBackBufferWidth = 1042;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

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

            // TODO: use this.Content to load your game content here
            var spritesheet = Content.Load<Texture2D>("santa-small");
            player = new Player(spritesheet);

            // Player
            var playerLayer = new ParallaxLayer(this);
            playerLayer.Sprites.Add(player);

            playerLayer.DrawOrder = 2;
            Components.Add(playerLayer);

            // Sky
            var skyTexture = Content.Load<Texture2D>("Sky");
            var skySprite = new StaticSprite(skyTexture);

            var skyLayer = new ParallaxLayer(this);
            skyLayer.Sprites.Add(skySprite);
            skyLayer.DrawOrder = 0;
            Components.Add(skyLayer);

            // Background
            var backgroundTexture = Content.Load<Texture2D>("BG");
            var backgroundSprite = new StaticSprite(backgroundTexture);

            var backgroundLayer = new ParallaxLayer(this);
            backgroundLayer.Sprites.Add(backgroundSprite);
            backgroundLayer.DrawOrder = 0;
            Components.Add(backgroundLayer);

            // Midground
            var midgroundTextures = new Texture2D[]
            {
                Content.Load<Texture2D>("Middle"),
                Content.Load<Texture2D>("Middle")
            };
            var midgroundSprites = new StaticSprite[]
            {
                new StaticSprite(midgroundTextures[0]),
                new StaticSprite(midgroundTextures[1], new Vector2(1920, 0))
            };

            var midgroundLayer = new ParallaxLayer(this);
            midgroundLayer.Sprites.AddRange(midgroundSprites);
            midgroundLayer.DrawOrder = 1;
            Components.Add(midgroundLayer);

            // Foreground
            var foregroundTextures = new Texture2D[]
           {
                Content.Load<Texture2D>("Snow"),
                Content.Load<Texture2D>("Snow")
           };
            var foregroundSprites = new StaticSprite[]
            {
                new StaticSprite(foregroundTextures[0]),
                new StaticSprite(foregroundTextures[1], new Vector2(1920, 0))
            };

            var foregroundLayer = new ParallaxLayer(this);
            foregroundLayer.Sprites.AddRange(foregroundSprites);
            foregroundLayer.DrawOrder = 4;
            Components.Add(foregroundLayer);

            backgroundLayer.ScrollController = new PlayerTrackingScrollController(player, 0.1f);
            midgroundLayer.ScrollController = new PlayerTrackingScrollController(player, 0.4f);
            playerLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);
            foregroundLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);
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
            player.Update(gameTime);
            Console.WriteLine(player.Position.X);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
