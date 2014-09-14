/*
 * Kinect controlled Pong game
 * by Craig Chao, KUAS, Taiwan, R.O.C.
 * Spring 2012
 * All rights reserved, all non-permited copies are prohibited.
 */

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


namespace KinectPong
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Drawbar : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Private Members

        private Game game;
        private SpriteBatch spriteBatch;
        private ContentManager contentManager;

        // bar sprite
        //private Texture2D barSprite;
        private RenderTarget2D Texture_Bar; // �������զ⯾�z��
        //private Vector2 Pos = new Vector2(100,100); // �\�񪺦�m


        // bar location
        private Vector2 barPosition = new Vector2(100, 100); // �\�񪺦�m
        //private Color ForColor = Color.Blue;  // �e���C��
        private Color BackColor = Color.Red;  // �I���C��
        private int barWidth = 1; // ������ �e
        private int barHeight = 1; // ������ ��


        #endregion
        
        #region Properties


        /// <summary>
        /// Gets or sets the X position of the bar.
        /// </summary>
        public float X
        {
            get { return barPosition.X; }
            set { barPosition.X = value; }
        }

        /// <summary>
        /// Get/set or sets the Y position of the bar.
        /// </summary>
        public float Y
        {
            get { return barPosition.Y; }
            set { barPosition.Y = value; }
        }

        public int Width
        {
            get { return barWidth; }
            set { barWidth = value; }
        }

        /// <summary>
        /// Get/set the height of the bar's sprite.
        /// </summary>
        public int Height
        {
            get { return barHeight; }
            set { barHeight = value; }
        }

        /// <summary>
        /// Get/set the color of the bar.
        /// </summary>
        public Color Color
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        /// <summary>
        /// Get/set the rotation of the bar.
        /// </summary>
        public float Rotation
        {   get;  set; 
        }

        /// <summary>
        /// Gets the bounding rectangle of the bar.
        /// </summary>
        public Rectangle Boundary
        {
            get
            {
                return new Rectangle((int)barPosition.X, (int)barPosition.Y,
                    Width, Height);
            }
        }

        #endregion

        public Drawbar(Game game)
            : base(game)
        {
            this.game = game;
            contentManager = new ContentManager(game.Services);
        }


        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {


            // Make sure base.Initialize() is called before this or handSprite will be null
            //X = (GraphicsDevice.Viewport.Width - Width) / 2;
            //Y = GraphicsDevice.Viewport.Height - Height;

            // �s�W�@�i�զ�B���z�����z�� (1 * 1)
            Texture_Bar = new RenderTarget2D(game.GraphicsDevice, 1, 1);
            game.GraphicsDevice.SetRenderTarget(Texture_Bar);
            game.GraphicsDevice.Clear(Color.White);  // �զ� ���z�� ���z��
            game.GraphicsDevice.SetRenderTarget(null);

            //Width = Texture_Bar.Width;
            //Height = Texture_Bar.Height;

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
             
            /*
            barSprite = contentManager.Load<Texture2D>(@"Content\Images\hand");
             */
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {           
            spriteBatch.Begin();

            spriteBatch.Draw(Texture_Bar,  // 1x1����¦�զ⯾�z��
               barPosition,  // �\�񪺦�m (���W���y��)
               null,  // �����ϧγ��n�e�{
               Color, // �I���C�� red
               Rotation,   // ���ਤ��
               Vector2.Zero, // �ϧΪ����ߦ�m
               new Vector2(Width, Height), // ������ �e ��
               SpriteEffects.None, 0);

            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
