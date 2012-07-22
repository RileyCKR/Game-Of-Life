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
            ImageButton btnPlay = new ImageButton()
            {
                BackgroundTexture = GameTextures.ButtonPlay,
                Position = new Rectangle(20, 20, 64, 64)
            };
            Controls.Add(btnPlay);

            ImageButton btnPause = new ImageButton()
            {
                BackgroundTexture = GameTextures.ButtonPause,
                Position = new Rectangle(104, 20, 64, 64)
            };
            Controls.Add(btnPause);

            ImageButton btnStep = new ImageButton()
            {
                BackgroundTexture = GameTextures.ButtonStep,
                Position = new Rectangle(188, 20, 64, 64)
            };
            Controls.Add(btnStep);
        }

        public void Update()
        {
            
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