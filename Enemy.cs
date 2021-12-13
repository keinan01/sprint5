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
        static Random rnd = new Random();
        public Enemy(Texture2D tex, Vector2 pos, float rad)
        {
            base.tex = tex;
            base.size = new Vector2(72, 72);
            base.pos = new Vector2(rnd.Next(0, 900), rnd.Next(0, 1000));
            base.rad = rad;
            base.colour = new Color(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
    }
}
