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
        internal static Texture2D CellAlive;
        internal static Texture2D CellDead;

        internal static Texture2D CellAlive8;
        internal static Texture2D CellDead8;

        internal static void Load(ContentManager contentManager)
        {
            CellAlive = contentManager.Load<Texture2D>("CellOn");
            CellDead = contentManager.Load<Texture2D>("CellOff");
            CellAlive8 = contentManager.Load<Texture2D>("CellOn8");
            CellDead8 = contentManager.Load<Texture2D>("CellOff8");
        }
    }
}