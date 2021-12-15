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
    class Background
    {
        Texture2D bg;
        public Rectangle bgSize;
        public Vector2 bgPos;

        public Background(Texture2D bgTex, Vector2 bgPos, Vector2 screen)
        {
            this.bg = bgTex;
            this.bgPos = bgPos;
            bgSize = new Rectangle((int)bgPos.X, (int)bgPos.Y, (int)screen.X * 2, (int)screen.Y * 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(bg, bgSize, Color.White);

        }
    }
}
