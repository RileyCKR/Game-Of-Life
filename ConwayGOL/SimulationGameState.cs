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
    public class SimulationGameState
    {
        SimpleMap Map { get; set; }

        public SimulationGameState()
        {
        }

        public void Initialize()
        {
            SetupMap();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime, InputState inputState)
        {
            if (inputState.KeyDown(Keys.Space))
            {
                Map.Tick();
            }

            if (inputState.KeyDown(Keys.Escape))
            {
                SetupMap();
            }

            if (inputState.LeftMouseUp())
            {
                int xRow = inputState.MousePosition.X / 16;
                int yRow = inputState.MousePosition.Y / 16;
                Map.FlipCell(xRow, yRow);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
        }

        private void SetupMap()
        {
            GameRules rules = GameRules.Standard();
            this.Map = new SimpleMap(30, rules);
        }
    }
}
