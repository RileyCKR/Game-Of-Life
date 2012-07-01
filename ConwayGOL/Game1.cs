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

namespace ConwayGOL
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameRules Rules { get; set; }
        SimpleMap Map { get; set; }

        Texture2D CellOnTexture;
        Texture2D CellOffTexture;

        KeyboardState OldState = Keyboard.GetState();
        KeyboardState NewState = Keyboard.GetState();

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
            this.Rules = new GameRules(new int[] { 3 }, new int[] { 2, 3 });
            this.Map = new SimpleMap(10, Rules);
            Random rng = new Random(1);

            int[] seed = new int[] { 34, 35, 36, 44, 45, 46, 54, 55, 56 };
            //Seed the map
            foreach (int index in seed)
            {
                Map.CellMap[index].IsAlive = true;
            }

            //for (int x = 0; x < 50; x++)
            //{
            //   int val = rng.Next(0, Map.CellMap.Length);
            //   Map.CellMap[val].IsAlive = true;
            //}

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

            CellOffTexture = this.Content.Load<Texture2D>("CellOff");
            CellOnTexture = this.Content.Load<Texture2D>("CellOn");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            OldState = NewState;
            NewState = Keyboard.GetState();

            if (NewState.IsKeyDown(Keys.Space) && !OldState.IsKeyDown(Keys.Space))
            {
                Map.Tick();
            }

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

            foreach (ICell cell in Map.CellMap)
            {
                Vector2 location = new Vector2(cell.XPos * 16, cell.YPos * 16);

                if (cell.IsAlive)
                {
                    spriteBatch.Draw(CellOnTexture, location, null, Color.White);
                }
                else
                {
                    spriteBatch.Draw(CellOffTexture, location, null, Color.White);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
