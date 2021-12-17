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
        public Vector2 screen;


        public Background(Texture2D bgTex, Vector2 bgPos, Vector2 screen)
        {
            this.bg = bgTex;
            this.bgPos = bgPos;
            this.screen = screen;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 shift)
        {

            bgSize = new Rectangle((int)(bgPos.X + shift.X), (int)(bgPos.Y + shift.Y), (int)screen.X * 2, (int)screen.Y * 2);

            spriteBatch.Draw(bg, bgSize, Color.White);

        }
    }
}