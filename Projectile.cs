using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Time_Pilot
{
    class Projectile : Plane
    {

        public Projectile(Texture2D tex, Vector2 pos, float rad)
        {
            base.colour = Color.White;
            base.tex = tex;
            size = new Vector2(25, 25);
            base.pos = pos;
            base.rad = rad;
            vel = new Vector2(0, 0);
        }
        public override void Update()
        {
            vel = -new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad)) * 10;

            if ((player.pos - pos).Length() > 2000)
            {
                removed = true;
            }

            base.Update();
        }
    }
}
