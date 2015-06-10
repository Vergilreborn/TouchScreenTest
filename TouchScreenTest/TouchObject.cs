using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TouchScreenTest
{
    class TouchObject
    {
        public Texture2D Texture;
        public Vector2 Location;
        public Color Color;
        public int Counter;
        public string debugData;

        public TouchObject(Texture2D texture, int counter, ref Random r)
        {
            this.Texture = texture;
            this.Location = Vector2.Zero;
            this.Color = new Color((r.Next() % 255), (r.Next() % 255), (r.Next() % 255));
            this.Counter = counter;
            debugData = "";

        }

        public void Update(GameTime gameTime, Vector2 location, string touchInfo)
        {
            this.Location = location;
            this.debugData = touchInfo;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.Draw(Texture, Location - new Vector2(Texture.Width / 2, Texture.Height / 2), Color);
            spriteBatch.DrawString(spriteFont, debugData, Location + new Vector2(0, Texture.Height / 2 + 10), Color);
        }
    }
}
