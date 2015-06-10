using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TouchScreenTest
{
    class TouchObjectV2 : ICloneable
    {
        public Texture2D Texture;
        public Vector2 Location;
        public Color Color;
        public int Counter;
        public string debugData;
        public List<Vector2> playerFingers;
       // public Circle CollisionElement;

        public TouchObjectV2 Clone()
        {
            return (TouchObjectV2)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public TouchObjectV2( int counter, ref Random r)
        {
           // this.Texture = texture;
            this.Location = Vector2.Zero;
            this.Color = new Color((r.Next() % 255), (r.Next() % 255), (r.Next() % 255));
            this.Counter = counter;
            debugData = "";
            playerFingers = new List<Vector2>();
            //this.CollisionElement = new Circle(Vector2.Zero, texture.Width / 2);

        }

        public void Update(GameTime gameTime, Vector2 location, List<TouchObjectV2> objectList, string touchInfo)
        {
            playerFingers.Clear();
            //TouchObjectV2 copy = (TouchObjectV2)this.Clone();
            //Vector2 savedLocation = copy.Location;
         //   Vector2 backupCircleLocation = copy.CollisionElement.Location;
         //   bool noCollision = true;
         //   CollisionElement.Location = location - new Vector2(Texture.Width / 2, Texture.Height / 2);

         //   foreach (TouchObjectV2 fingerObj in objectList)
         //   {
         //       if (this != fingerObj && this.CollisionElement.Intersects(fingerObj.CollisionElement))
         //       {
         //           noCollision = false;
         //           break;
         //       } 
         //   }

            //if (noCollision)
            //{ 
            //    this.Location = location;
            //    this.debugData = "No collision";
            //}
            //else
            //{
            //    CollisionElement.Location = backupCircleLocation;
            //  //  this.Location = savedLocation;
            //    this.debugData = "Collision";

            //}
           
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice graphicsDevice)
        {
           // spriteBatch.Draw(Texture, Location - new Vector2(Texture.Width / 2, Texture.Height / 2), Color);
            //spriteBatch.DrawString(spriteFont, debugData, Location + new Vector2(0, Texture.Height / 2 + 10), Color);

           Texture2D circle = CreateCircle((int)20,graphicsDevice);

            spriteBatch.Draw(circle, Location - new Vector2(Texture.Width / 2, Texture.Height / 2) , Color.Red);
        }

        public Texture2D CreateCircle(int radius, GraphicsDevice GraphicsDevice)
        {
            int outerRadius = radius * 2 + 2; // So circle doesn't go out of bounds
            Texture2D texture = new Texture2D(GraphicsDevice, outerRadius, outerRadius);

            Color[] data = new Color[outerRadius * outerRadius];

            // Colour the entire texture transparent first.
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;

            // Work out the minimum step necessary using trigonometry + sine approximation.
            double angleStep = 1f / radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));

                data[y * outerRadius + x + 1] = Color.White;
            }

            texture.SetData(data);
            return texture;
        }
       
    }
}
