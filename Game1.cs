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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        List<Plane> planes;

        Texture2D bg;
        Texture2D playerTex;
        Texture2D bullet;
        Vector2 screen, cameraPos;
        float rotationRadians = 0f;
        MouseState mouseState;
        List<Background> bgArray = new List<Background>();
        public Game1()
        {
            this.Window.AllowUserResizing = true;


            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            Plane.game = this;
            screen = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTex = this.Content.Load<Texture2D>("player");
            bg = this.Content.Load<Texture2D>("bg");
            bullet = this.Content.Load<Texture2D>("bullet");
            Plane.player = player = new Player(playerTex, screen / 2, rotationRadians);
            planes = new Plane[] { player, new Enemy(playerTex, screen / 2, rotationRadians) }.ToList();
            for (int i = 0; i < 10; i++)
            {
                planes.Add(new Enemy(playerTex, screen / 2, rotationRadians));
            }

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            for (int i = 0; i < planes.Count; i++)
            {
                planes[i].Update();
            }

            bgArray = new List<Background>();

            player.cameraPos = cameraPos = new Vector2(-player.pos.X + GraphicsDevice.Viewport.Width / 2, -player.pos.Y + GraphicsDevice.Viewport.Height / 2);

            bgArray.Add(new Background(bg, new Vector2((float)Math.Floor(-cameraPos.X / screen.X / 2) * screen.X * 2, (float)Math.Floor(-cameraPos.Y / screen.Y / 2) * screen.Y * 2), screen));
            bgArray.Add(new Background(bg, new Vector2((float)Math.Ceiling(-cameraPos.X / screen.X / 2) * screen.X * 2, (float)Math.Floor(-cameraPos.Y / screen.Y / 2) * screen.Y * 2), screen));
            bgArray.Add(new Background(bg, new Vector2((float)Math.Floor(-cameraPos.X / screen.X / 2) * screen.X * 2, (float)Math.Ceiling(-cameraPos.Y / screen.Y / 2) * screen.Y * 2), screen));
            bgArray.Add(new Background(bg, new Vector2((float)Math.Ceiling(-cameraPos.X / screen.X / 2) * screen.X * 2, (float)Math.Ceiling(-cameraPos.Y / screen.Y / 2) * screen.Y * 2), screen));
            

            for (int i = planes.Count - 1; i >= 0; i--)
            {
                if (planes[i].removed)
                {
                    planes.RemoveAt(i);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            for (int i = 0; i < bgArray.Count; i++)
            {
                bgArray[i].Draw(spriteBatch, cameraPos);
            }
            for (int i = 0; i < planes.Count; i++)
            {
                planes[i].Draw(spriteBatch, cameraPos);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Shoot(Vector2 pos, float rad)
        {
            planes.Add(new Projectile(bullet, pos, rad));
        }
    }
}