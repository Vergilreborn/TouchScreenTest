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
    class Player
    {
        public Rectangle playableRegion;
        int playerId;
        List<TouchLocation> playerTouches;
            
        public Player(Rectangle playableRegion, int playerId)
        {
            this.playableRegion = playableRegion;
            this.playerId = playerId;
            playerTouches = new List<TouchLocation>();
        }
        public bool InsideRegion(Vector2 position)
        {
            return playableRegion.Contains(new Point((int)position.X, (int)position.Y));
        }


        public void Update(GameTime gameTime)
        {
            playerTouches.Clear();
        }

        public void Add(TouchLocation touchLocation)
        {
            playerTouches.Add(touchLocation);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice GraphicsDevice)
        {
            int radius = 30;
            Texture2D circle = Shapes.CreateCircle(radius
                ,GraphicsDevice);
            
            foreach (TouchLocation touch in playerTouches)
            {
                spriteBatch.Draw(circle,
                        new Vector2(touch.Position.X - radius, touch.Position.Y - radius), Color.Gold);
                spriteBatch.DrawString(spriteFont, "Player " + playerId, new Vector2(touch.Position.X - radius, touch.Position.Y + radius), Color.Aquamarine);
            }
        }
    }
}
