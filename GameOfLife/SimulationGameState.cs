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

namespace GameOfLife
{
    public class SimulationGameState
    {
        private enum GameState
        {
            Paused,
            Playing
        }

        IMap Map { get; set; }
        Camera Camera;
        Game Game;
        int Ticks = 0;
        int TickRate = 10;
        GameState State = GameState.Paused;

        public SimulationGameState(Game game)
        {
            this.Game = game;
        }

        public void Initialize()
        {
            Camera = new Camera(new Point(800, 600));
            SetupMap();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime, InputState inputState)
        {
            Ticks++;

            if (this.Game.IsActive)
            {
                if (inputState.KeyDown(Keys.Space))
                {
                    if (this.State == GameState.Paused)
                    {
                        this.State = GameState.Playing;
                    }
                    else
                    {
                        this.State = GameState.Paused;
                    }
                }

                if (inputState.KeyDown(Keys.Escape))
                {
                    SetupMap();
                }

                Camera.Update(gameTime, inputState);

                if (inputState.LeftMouseUp())
                {
                    int xRow = inputState.MousePosition.X / 16;
                    int yRow = inputState.MousePosition.Y / 16;
                    Point cellPoint = new Point(Camera.Screen.X / 16, Camera.Screen.Y / 16);
                    cellPoint.X = cellPoint.X + xRow;
                    cellPoint.Y = cellPoint.Y + yRow;
                    Map.FlipCell(cellPoint.X, cellPoint.Y);
                }
            }

            if (this.State == GameState.Playing && Ticks >= TickRate)
            {
                Map.Tick();
                Ticks = 0;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch, Camera);
        }

        private void SetupMap()
        {
            GameRules rules = GameRules.Standard();
            this.Map = new InfiniteMap(rules);
            this.State = GameState.Paused;
            this.Map.FlipCell(14, 12);
            this.Map.FlipCell(15, 12);
            this.Map.FlipCell(13, 13);
            this.Map.FlipCell(14, 13);
            this.Map.FlipCell(14, 14);

        }
    }
}
