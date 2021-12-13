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
        public Vector2 cameraPos;

        public Player(Texture2D tex, Vector2 pos, float rad)
        {
            base.colour = Color.White;
            base.tex = tex;
            size = new Vector2(72, 72);
            base.pos = pos;
            base.rad = rad;
            vel = new Vector2(0, 0);
        }
        public override void Update()
        {
            MouseState mouseState = Mouse.GetState();

            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y) - cameraPos;

            Vector2 dPos = this.pos - mousePosition;

            rad = (float)Math.Atan2(dPos.Y, dPos.X);

            vel = -new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad)) * 5;

            base.Update();
        }
    }
}
