using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace TouchScreenTest
{

    
    class GameBoard
    {
        private int NumberOfPlayers;
        private List<Player> Players;
        private Rectangle BoardBounds;

        public GameBoard(int width, int height) {
            NumberOfPlayers = 2;
            Players = new List<Player>();
            BoardBounds = new Rectangle(1, 1, width - 2, height - 2);

            //  TODO: --Dynamically Load Players
            Player player1 = new Player(new Rectangle(1, 1, BoardBounds.Width / 2 - 2, BoardBounds.Height - 2), 1);
            Player player2 = new Player(new Rectangle(BoardBounds.Width / 2 + 1, 1, BoardBounds.Width / 2 - 2, BoardBounds.Height - 2), 2);

            Players.Add(player1);
            Players.Add(player2);
        }

        public void Update(GameTime gameTime, TouchCollection touchStates)
        {
            for (int j = 0; j < Players.Count; j++)
            {
                Players[j].Update(gameTime);
                for (int i = 0; i < touchStates.Count; i++)
                {

                    if (Players[j].InsideRegion(touchStates[i].Position))
                    {
                        Players[j].Add(touchStates[i]);
                    }
                }
                // if (i < points.Count)
                // {

                //        points[i].Update(gameTime, touchStates[i].Position,points, "ID/P/S:" + touchStates[i].Id +"," + touchStates[i].Pressure + "," + touchStates[i].State  );
                //    }
                //    else
                //    {
                //TouchObjectV2 tchObj = new TouchObjectV2(i, ref r);
                //tchObj.Update(gameTime, touchStates[i].Position, points, "ID/P/S:" + touchStates[i].Id + "," + touchStates[i].Pressure + "," + touchStates[i].State);
                //points.Add(tchObj);
                //    }
                //  //  
            }

        }

        float timer = 0f;
        float changeTimer = 8000f;
        bool change = false;
        internal void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont, GameTime gameTime, GraphicsDevice GraphicsDevice)
        {
            timer += gameTime.ElapsedGameTime.Milliseconds;

            if (timer > changeTimer)
            {
                timer = 0f;
                change = !change;
            }

            int boardThickness = 8;

            //Player1 Boundary
            //Shapes.DrawRectangle(spriteBatch, new Rectangle(1, 1, BoardBounds.Width -2, BoardBounds.Height -2), Color.White, 6);
            //Shapes.DrawRectangle(spriteBatch, new Rectangle(BoardBounds.Width / 2 - 40, BoardBounds.Height/2 - 40, 80,80), Color.Red, 6);
          //  Shapes.DrawRectangle(spriteBatch, new Rectangle(1, 1, BoardBounds.Width/2 - 2, BoardBounds.Height - 2), Color.White, 6);
            //Shapes.DrawRectangle(spriteBatch, new Vector2(2, 2), new Vector2(BoardBounds.Width -2, BoardBounds.Height - 2), Color.AliceBlue, boardThickness, GraphicsDevice);
            //Shapes.DrawRectangle(spriteBatch, new Vector2(1, 1), new Vector2(BoardBounds.Width / 2, BoardBounds.Height), Color.AliceBlue, boardThickness, GraphicsDevice);
           // Shapes.DrawRectangle(spriteBatch, new Rectangle(1, 1, BoardBounds.Width / 2 - 2, BoardBounds.Height - 2), Color.White, 6);
            //Player2 Boundary
           // Shapes.DrawRectangle(spriteBatch, new Rectangle(BoardBounds.Width / 2 - 40, BoardBounds.Height / 2 - 40, 80, 80), Color.Green, 6);
           // Shapes.DrawRectangle(spriteBatch, new Rectangle(BoardBounds.Width / 2 + 1, 1, BoardBounds.Width / 2 -2, BoardBounds.Height - 2), Color.Blue, 6);
            //Shapes.DrawRectangle(spriteBatch, new Vector2(BoardBounds.Width / 2, 0), new Vector2(BoardBounds.Width, BoardBounds.Height), Color.Magenta, boardThickness, GraphicsDevice);

            if (change)
            {
                Shapes.DrawRectangle(spriteBatch, new Rectangle(1, 1, BoardBounds.Width / 2 - 2, BoardBounds.Height - 2), Color.DarkGray, boardThickness);
                Shapes.DrawRectangle(spriteBatch, new Rectangle(BoardBounds.Width / 2 + 1, 1, BoardBounds.Width / 2 - 2, BoardBounds.Height - 2), Color.Blue, boardThickness);
                Shapes.DrawRectangle(spriteBatch, new Rectangle(BoardBounds.Width / 2 - 40, BoardBounds.Height / 2 - 40, 80, 80), Color.Green, boardThickness);
            }
            else
            {
                Shapes.DrawRectangle(spriteBatch, new Rectangle(BoardBounds.Width / 2 + 1, 1, BoardBounds.Width / 2 - 2, BoardBounds.Height - 2), Color.Aqua, boardThickness);
                Shapes.DrawRectangle(spriteBatch, new Rectangle(1, 1, BoardBounds.Width / 2 - 2, BoardBounds.Height - 2), Color.White, boardThickness);
                Shapes.DrawRectangle(spriteBatch, new Rectangle(BoardBounds.Width / 2 - 40, BoardBounds.Height / 2 - 40, 80, 80), Color.Magenta, boardThickness);
           
            }

            for (int j = 0; j < Players.Count; j++)
            {
                Players[j].Draw(spriteBatch,spriteFont,GraphicsDevice);

            }
        }
    }
}
