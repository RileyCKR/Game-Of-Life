using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife.GUI
{
    class PlaybackDock : Panel
    {
        ImageButton btnPlay;
        ImageButton btnPause;
        ImageButton btnStep;

        public PlaybackDock()
        {
            this.BackgroundTexture = GameTextures.PanelPlayback;
            this.Position = new Rectangle(0, 0, 272, 104);

            btnPlay = new ImageButton()
            {
                BackgroundTexture = GameTextures.ButtonPlay,
                Position = new Rectangle(20, 20, 64, 64)
            };
            ChildControls.Add(btnPlay);

            btnPause = new ImageButton()
            {
                BackgroundTexture = GameTextures.ButtonPause,
                Position = new Rectangle(104, 20, 64, 64)
            };
            ChildControls.Add(btnPause);

            btnStep = new ImageButton()
            {
                BackgroundTexture = GameTextures.ButtonStep,
                Position = new Rectangle(188, 20, 64, 64)
            };
            ChildControls.Add(btnStep);
        }
    }
}
