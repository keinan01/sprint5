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
using System.Diagnostics;

namespace Time_Pilot
{
    class Plane
    {
        public Vector2 pos, vel, size;
        public Texture2D tex;
        public Color colour;
        public float rad;
        public static Game1 game;
        public bool removed = false;
        public static Plane player;
        public bool friendly;
        public bool isBullet;
        public Plane()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 shift)
        {
            Vector2 origin = new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2);
            spriteBatch.Draw(tex, new Rectangle((int)(pos.X + shift.X), (int)(pos.Y + shift.Y), (int)size.X, (int)size.Y), null, colour, rad, origin, SpriteEffects.None, 0f);
        }

        public virtual void Update()
        {
            pos += vel;
        }
        public bool collides(Plane other)
        {
            return new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y).Intersects(new Rectangle((int)other.pos.X, (int)other.pos.Y, (int)other.size.X, (int)other.size.Y));
        }
    }
}

 
