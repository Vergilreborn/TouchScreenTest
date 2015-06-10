using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;

namespace TouchScreenTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Random r;
        Texture2D pointer;
        List<TouchObjectV2> points;
        GameBoard mainBoard;
        SpellBoard spellBoard;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Intializing the points in which the 
            //points = new List<TouchObjectV2>();
            r = new Random(DateTime.Now.Millisecond);
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
            pointer = Content.Load<Texture2D>("Pointer");
            spriteFont = Content.Load<SpriteFont>("Debug");


            mainBoard = new GameBoard(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            spellBoard = new SpellBoard(Content.Load<Texture2D>("SpellBoard/notselected"),
                                        Content.Load<Texture2D>("SpellBoard/selected"),new Rectangle(80, 80, 200, 200), new Vector2(80, 80));
            spellBoard.LoadBoard(2);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
           // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
             //   Exit();

            TouchCollection touchStates= TouchPanel.GetState();

            mainBoard.Update(gameTime, touchStates);
            spellBoard.Update(gameTime, touchStates);

            //for (int i = 0; i < touchStates.Count; i++)
            //{
            //    if (i < points.Count)
            //    {
                    
            //        points[i].Update(gameTime, touchStates[i].Position,points, "ID/P/S:" + touchStates[i].Id +"," + touchStates[i].Pressure + "," + touchStates[i].State  );
            //    }
            //    else
            //    {
            //        TouchObjectV2 tchObj = new TouchObjectV2(pointer, i, ref r);
            //        tchObj.Update(gameTime, touchStates[i].Position, points, "ID/P/S:" + touchStates[i].Id + "," + touchStates[i].Pressure + "," + touchStates[i].State);
            //        points.Add(tchObj);
            //    }
            //  //  
            //}


                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //for (int i = 0; i < points.Count; i++)
            //{
            //    points[i].Draw(spriteBatch, spriteFont, GraphicsDevice);
            //  //  spriteBatch.Draw(pointer, points[i] - new Vector2(pointer.Width/2, pointer.Height/2), Color.White);
            //}

            mainBoard.Draw(spriteBatch, spriteFont, gameTime, GraphicsDevice);
            spellBoard.Draw(spriteBatch, spriteFont, GraphicsDevice);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
