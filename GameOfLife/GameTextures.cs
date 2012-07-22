using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameOfLife
{
    internal static class GameTextures
    {
        internal static Texture2D CellAlive16 { get; private set; }
        internal static Texture2D CellAlive8 { get; private set; }
        internal static Texture2D CellAlive4 { get; private set; }
        internal static Texture2D CellAlive2 { get; private set; }
        internal static Texture2D CellAlive1 { get; private set; }

        internal static Texture2D CellDead16 { get; private set; }
        internal static Texture2D CellDead8 { get; private set; }
        internal static Texture2D CellDead4 { get; private set; }
        internal static Texture2D CellDead2 { get; private set; }
        internal static Texture2D CellDead1 { get; private set; }

        internal static Texture2D ButtonPlay { get; private set; }
        internal static Texture2D ButtonPause { get; private set; }
        internal static Texture2D ButtonStep { get; private set; }
        internal static Texture2D ButtonPlayHover { get; private set; }
        internal static Texture2D ButtonPauseHover { get; private set; }
        internal static Texture2D ButtonStepHover { get; private set; }
        internal static Texture2D ButtonPlayClick { get; private set; }
        internal static Texture2D ButtonPauseClick { get; private set; }
        internal static Texture2D ButtonStepClick { get; private set; }

        internal static Texture2D PanelPlayback { get; private set; }

        internal static void Load(ContentManager contentManager)
        {
            CellAlive16 = contentManager.Load<Texture2D>("CellOn16");
            CellAlive8 = contentManager.Load<Texture2D>("CellOn8");
            CellAlive4 = contentManager.Load<Texture2D>("CellOn4");
            CellAlive2 = contentManager.Load<Texture2D>("CellOn2");
            CellAlive1 = contentManager.Load<Texture2D>("CellOn1");

            CellDead16 = contentManager.Load<Texture2D>("CellOff16");
            CellDead8 = contentManager.Load<Texture2D>("CellOff8");
            CellDead4 = contentManager.Load<Texture2D>("CellOff4");
            CellDead2 = contentManager.Load<Texture2D>("CellOff2");
            CellDead1 = contentManager.Load<Texture2D>("CellOff1");

            ButtonPlay = contentManager.Load<Texture2D>("button-play");
            ButtonPause = contentManager.Load<Texture2D>("button-pause");
            ButtonStep = contentManager.Load<Texture2D>("button-step");
            ButtonPlayHover = contentManager.Load<Texture2D>("button-play-hover");
            ButtonPauseHover = contentManager.Load<Texture2D>("button-pause-hover");
            ButtonStepHover = contentManager.Load<Texture2D>("button-step-hover");
            ButtonPlayClick = contentManager.Load<Texture2D>("button-play-click");
            ButtonPauseClick = contentManager.Load<Texture2D>("button-pause-click");
            ButtonStepClick = contentManager.Load<Texture2D>("button-step-click");

            PanelPlayback = contentManager.Load<Texture2D>("panel-playback");
        }
    }
}