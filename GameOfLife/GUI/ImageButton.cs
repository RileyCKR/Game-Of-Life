using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife
{
    class ImageButton : Control
    {
        public ImageButton(UserInterface userInterface)
            : base(userInterface)
        {
        }

        public Texture2D ClickTexture { get; set; }
        public Texture2D HoverTexture { get; set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (ControlState == ControlState.Inactive)
            {
                base.Draw(spriteBatch);
            }
            else if (ControlState == ControlState.Hover)
            {
                spriteBatch.Draw(HoverTexture, Position, null, Color.White);
            }
            else if (ControlState == ControlState.Clicked)
            {
                spriteBatch.Draw(ClickTexture, Position, null, Color.White);
            }
        }
    }
}