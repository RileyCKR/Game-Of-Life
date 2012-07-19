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
        internal static Texture2D CellAlive16;
        internal static Texture2D CellAlive8;
        internal static Texture2D CellAlive4;
        internal static Texture2D CellAlive2;
        internal static Texture2D CellAlive1;

        internal static Texture2D CellDead16;
        internal static Texture2D CellDead8;
        internal static Texture2D CellDead4;
        internal static Texture2D CellDead2;
        internal static Texture2D CellDead1;

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
        }
    }
}