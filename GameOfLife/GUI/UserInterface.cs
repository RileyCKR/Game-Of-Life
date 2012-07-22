using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife.GUI
{
    class UserInterface
    {
        private InputState inputState;

        public List<object> Controls { get; set; }

        public UserInterface(InputState inputState)
        {
            this.inputState = inputState;
        }

        public void Initialize()
        {
            ImageButton btnPlay = new ImageButton();
            btnPlay.BackgroundTexture = GameTextures.ButtonPlay;
            btnPlay.Position = new Microsoft.Xna.Framework.Rectangle(20, 20, 64, 64);
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