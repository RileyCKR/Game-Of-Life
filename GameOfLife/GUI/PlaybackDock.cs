using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife
{
    class PlaybackDock : Panel
    {
        ImageButton btnPlay;
        ImageButton btnPause;
        ImageButton btnStep;

        public PlaybackDock(UserInterface userInterface)
            : base(userInterface)
        {
            this.BackgroundTexture = GameTextures.PanelPlayback;
            this.Position = new Rectangle(0, 0, 272, 104);

            btnPlay = new ImageButton(userInterface)
            {
                BackgroundTexture = GameTextures.ButtonPlay,
                HoverTexture = GameTextures.ButtonPlayHover,
                ClickTexture = GameTextures.ButtonPlayClick,
                Position = new Rectangle(20, 20, 64, 64)
            };
            btnPlay.OnClick += new EventHandler(PlayButton_OnClick);
            ChildControls.Add(btnPlay);

            btnPause = new ImageButton(userInterface)
            {
                BackgroundTexture = GameTextures.ButtonPause,
                HoverTexture = GameTextures.ButtonPauseHover,
                ClickTexture = GameTextures.ButtonPauseClick,
                Position = new Rectangle(104, 20, 64, 64)
            };
            btnPause.OnClick += new EventHandler(btnPause_OnClick);
            ChildControls.Add(btnPause);

            btnStep = new ImageButton(userInterface)
            {
                BackgroundTexture = GameTextures.ButtonStep,
                HoverTexture = GameTextures.ButtonStepHover,
                ClickTexture = GameTextures.ButtonStepClick,
                Position = new Rectangle(188, 20, 64, 64)
            };
            btnStep.OnClick += new EventHandler(btnStep_OnClick);
            ChildControls.Add(btnStep);
        }

        void PlayButton_OnClick(object sender, EventArgs e)
        {
            UserInterface.AddMessage("PLAY");
        }

        void btnPause_OnClick(object sender, EventArgs e)
        {
            UserInterface.AddMessage("PAUSE");
        }

        void btnStep_OnClick(object sender, EventArgs e)
        {
            UserInterface.AddMessage("STEP");
        }
    }
}