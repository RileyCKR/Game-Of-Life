using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife.GUI
{
    class UserInterface
    {
        private InputState inputState;

        public List<Control> Controls { get; set; }

        public UserInterface(InputState inputState)
        {
            this.inputState = inputState;
            this.Controls = new List<Control>();
        }

        public void Initialize()
        {
            PlaybackDock playbackDock = new PlaybackDock();
            Controls.Add(playbackDock);
        }

        public void Update()
        {
            foreach (Control thisControl in Controls)
            {
                thisControl.HandleInput(inputState);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control thisControl in Controls)
            {
                thisControl.Draw(spriteBatch);
            }
        }
    }
}