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
        public event EventHandler OnClick;

        public Texture2D BackgroundTexture { get; set; }
        public Rectangle Position { get; set; }
        public List<Control> ChildControls { get; set; }
        public ControlState ControlState { get; private set; }
        public ControlState LastControlState { get; private set; }
        protected UserInterface UserInterface { get; private set; }

        public Control(UserInterface userInterface)
        {
            this.ChildControls = new List<Control>();
            this.UserInterface = userInterface;
        }

        public virtual void HandleInput(InputState inputState)
        {
            foreach (Control thisControl in ChildControls)
            {
                thisControl.HandleInput(inputState);
            }

            LastControlState = ControlState;

            if (!inputState.MouseInputHandled && Position.Contains(inputState.MousePosition))
            {
                if (inputState.LeftMousePressed())
                {
                    ControlState = GUI.ControlState.Clicked;
                }
                else
                {
                    ControlState = GUI.ControlState.Hover;
                }

                inputState.MouseInputHandled = true;
            }
            else
            {
                ControlState = GUI.ControlState.Inactive;
            }

            //Handle Click Event
            if (LastControlState == GUI.ControlState.Clicked && ControlState != GUI.ControlState.Clicked)
            {
                if (OnClick != null)
                {
                    OnClick(this, EventArgs.Empty);
                }
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