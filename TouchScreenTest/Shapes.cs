using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TouchScreenTest
{
    class Shapes
    {

        public static void DrawRectangle(SpriteBatch sb, Vector2 start, Vector2 end,Color color, int thickness,GraphicsDevice GraphicsDevice)
        {

            //Simple Colored Pixel
            Texture2D t = new Texture2D(GraphicsDevice, 1, 1);
            t.SetData<Color>(
                new Color[] { Color.White });

            Vector2 edge = end - start;
            //Draw Order:
            //  horizontal Top 
            //  vertical left
            //  horizontal bottom
            //  vertical right
        //    DrawLine(sb, start, new Vector2(end.X, start.Y), thickness, color, GraphicsDevice);
         //   DrawLine(sb, start, new Vector2(start.X, end.Y), thickness, color, GraphicsDevice);
          //  DrawLine(sb, end, new Vector2(start.X, end.Y), thickness, color, GraphicsDevice);
           // DrawLine(sb, end, new Vector2(end.X, start.Y), thickness, color, GraphicsDevice);
        }

        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int lineWidth)
        {
                Texture2D _pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                _pointTexture.SetData<Color>(new Color[] { Color.White });
            

            //top left -> top right
                spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, lineWidth),color);
            //top left -> bottom left
                spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height), color);
            //bottom left -> bottom right
                spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height - lineWidth + 2, rectangle.Width, lineWidth), color);
            //top right -> bottom right
                spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X + rectangle.Width - lineWidth + 2, rectangle.Y, lineWidth, rectangle.Height + 2), color);

            //spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height), color);
            //spriteBatch.Draw(_pointTexture, new Rectangle(), color);
            //spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            //spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
        }


        public static Texture2D CreateCircle(int radius, GraphicsDevice GraphicsDevice)
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
                // Use the parametric definition of a circle: http://en.wikipedia.org/wiki/Circle#Cartesian_coordinates
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));

                data[y * outerRadius + x + 1] = Color.White;
            }

            texture.SetData(data);
            return texture;
        }

        public static void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, int thickness, Color color, GraphicsDevice GraphicsDevice)
        {

            //Simple Colored Pixel
            Texture2D t = new Texture2D(GraphicsDevice, 1, 1);
            t.SetData<Color>(
                new Color[] { Color.White });

            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);

            int deg = (int)(angle * (180 / Math.PI));

            int addX = deg == 0 ? 0 : deg == 180 ? 1 : deg == -90 ? -thickness + 1 : thickness;
            int addY = deg == 180 ? 0 : deg == -90 ? thickness / 2 : 0;

            sb.Draw(t,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X + addX,
                    (int)start.Y + addY,// - thickness,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    thickness), //width of line, change this to make thicker line
                null,
                color, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }
    }
}
