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
    class Player : Plane
    {

        public Player(Texture2D tex, Vector2 pos, float rad)
        {
            base.tex = tex;
            base.size = new Vector2(72, 72);
            base.pos = pos;
            base.rad = rad;
        }
    }
}
