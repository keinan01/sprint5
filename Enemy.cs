using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Time_Pilot
{
    class Enemy : Plane
    {
        static Random rnd = new Random();
        float baseAng;
        public Enemy(Texture2D tex, Vector2 pos, float rad)
        {
            base.tex = tex;
            base.size = new Vector2(72, 72);
            base.pos = new Vector2(rnd.Next(0, 900), rnd.Next(0, 1000));
            base.rad = rad;
            baseAng = rad;
            base.colour = new Color(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
        public override void Update()
        {
            double a = (rad % (2 * Math.PI) + 2 * Math.PI) % (2 * Math.PI);

            double b = baseAng;
            if ((player.pos - pos).Length() < 200)
            {
            b = Math.Atan2((pos - player.pos).Y, (pos - player.pos).X);
            }

            if ((b - a + 3 * Math.PI) % (2 * Math.PI) - Math.PI > 0.1)
            {
                rad += (float)Math.PI / 100;
            }
            else if ((b - a + 3 * Math.PI) % (2 * Math.PI) - Math.PI < -0.1)
            {
                rad -= (float)Math.PI / 100;
            }
            vel = -new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad)) * 2;

            base.Update();
        }
    }
}
