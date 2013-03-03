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
        InputState inputState;
        UserInterface GUI;

        public SimulationGameState(Game game, InputState inputState)
        {
            this.Game = game;
            this.inputState = inputState;
            GUI = new SimulationUI(inputState);
        }

        public void Initialize()
        {
            Camera = new Camera(new Point(800, 600));
            SetupMap();
            
        }

        public void ContentLoaded()
        {
            GUI.Initialize();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            Ticks++;

            if (this.Game.IsActive)
            {
                GUI.Update();

                UserInterfaceMessage guiMessage;
                while (GUI.GetMessage(out guiMessage))
                {
                    switch (guiMessage)
                    {
                        case UserInterfaceMessage.Play:
                            this.State = GameState.Playing;
                            break;
                        case UserInterfaceMessage.Pause:
                            this.State = GameState.Paused;
                            break;
                        case UserInterfaceMessage.Step:
                            this.State = GameState.Paused;
                            Map.Tick();
                            Ticks = 0;
                            break;
                        default:
                            string message = "Unrecognized GUI Message '" + guiMessage.ToString() + "'.";
                            throw new InvalidOperationException(message);
                    }
                }

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

                if (!inputState.MouseInputHandled && inputState.LeftMouseUp())
                {
                    Point clickedCell = Camera.GetCellCoordinatesOfClick(inputState.MousePosition);
                    Map.FlipCell(clickedCell.X, clickedCell.Y);
                }
            }

            if (this.State == GameState.Playing && Ticks >= TickRate)
            {
                Map.Tick();
                Ticks = 0;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Rectangle screenBounds)
        {
            Map.Draw(spriteBatch, Camera, screenBounds);
            GUI.Draw(spriteBatch, screenBounds);
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
