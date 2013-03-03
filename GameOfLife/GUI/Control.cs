using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife
{
    enum ControlState
    {
        Inactive,
        Hover,
        Clicked
    }

    abstract class Control
    {
        private bool ClickStartedHere = false;

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
            LastControlState = ControlState;

            foreach (Control child in ChildControls)
            {
                child.HandleInput(inputState);
            }

            if (!inputState.MouseInputHandled && Position.Contains(inputState.MousePosition))
            {
                inputState.MouseInputHandled = true;

                if (inputState.LeftMouseDown())
                {
                    ClickStartedHere = true;
                }

                if (inputState.LeftMousePressed())
                {
                    ControlState = ControlState.Clicked;
                }
                else if (inputState.LeftMouseUp())
                {
                    if (ClickStartedHere)
                    {
                        //Handle Click Event
                        if (OnClick != null)
                        {
                            OnClick(this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        //Don't handle event because it was a dragged click
                    }
                }
                else
                {
                    ControlState = ControlState.Hover;
                }
            }
            else
            {
                ClickStartedHere = false;
                ControlState = ControlState.Inactive;
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