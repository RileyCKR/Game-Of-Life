using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife.GUI
{
    enum ControlState
    {
        Inactive,
        Hover,
        Clicked
    }

    abstract class Control
    {
        public Texture2D BackgroundTexture { get; set; }
        public Rectangle Position { get; set; }
        public List<Control> ChildControls { get; set; }
        public ControlState ControlState;

        public Control()
        {
            ChildControls = new List<Control>();
        }

        public virtual void HandleInput(InputState inputState)
        {
            if (Position.Contains(inputState.MousePosition))
            {
                if (inputState.LeftMousePressed())
                {
                    ControlState = GUI.ControlState.Clicked;
                }
                else
                {
                    ControlState = GUI.ControlState.Hover;
                }
            }
            else
            {
                ControlState = GUI.ControlState.Inactive;
            }

            foreach (Control thisControl in ChildControls)
            {
                thisControl.HandleInput(inputState);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (BackgroundTexture != null)
            {
                spriteBatch.Draw(BackgroundTexture, Position, null, Color.White);
            }

            foreach (Control thisControl in ChildControls)
            {
                thisControl.Draw(spriteBatch);
            }
        }
    }
}