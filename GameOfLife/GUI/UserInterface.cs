﻿using System;
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
        protected Queue<string> MessageQueue { get; private set; }

        public UserInterface(InputState inputState)
        {
            this.inputState = inputState;
            this.Controls = new List<Control>();
            MessageQueue = new Queue<string>();
        }

        public void Initialize()
        {
            PlaybackDock playbackDock = new PlaybackDock(this);
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

        public void AddMessage(string message)
        {
            MessageQueue.Enqueue(message);
        }

        public bool GetMessage(out string message)
        {
            if (MessageQueue.Count > 0)
            {
                message = MessageQueue.Dequeue();
                return true;
            }
            else
            {
                message = null;
                return false;
            }
        }
    }
}