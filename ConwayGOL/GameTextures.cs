using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ConwayGOL
{
    internal static class GameTextures
    {
        internal static Texture2D CellAlive;
        internal static Texture2D CellDead;

        internal static void Load(ContentManager contentManager)
        {
            CellAlive = contentManager.Load<Texture2D>("CellOn");
            CellDead = contentManager.Load<Texture2D>("CellOff");
        }
    }
}