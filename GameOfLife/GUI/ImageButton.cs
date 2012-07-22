using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife.GUI
{
    class ImageButton : Control
    {
        public Texture2D ClickTexture { get; set; }
        public Texture2D HoverTexture { get; set; }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (ControlState == GUI.ControlState.Inactive)
            {
                base.Draw(spriteBatch);
            }
            else if (ControlState == GUI.ControlState.Hover)
            {
                spriteBatch.Draw(HoverTexture, Position, null, Color.White);
            }
            else if (ControlState == GUI.ControlState.Clicked)
            {
                spriteBatch.Draw(ClickTexture, Position, null, Color.White);
            }
        }
    }
}