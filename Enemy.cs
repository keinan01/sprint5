using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Time_Pilot
{
    class Enemy : Plane
    {
        public Enemy(Texture2D tex, Vector2 pos, float rad)
        {
            base.tex = tex;
            base.size = new Vector2(72, 72);
            base.pos = pos;
            base.rad = rad;
        }
    }
}
