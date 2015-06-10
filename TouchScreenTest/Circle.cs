using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TouchScreenTest
{
    class Circle
    {
        public float Radius;
        public Vector2 Location;
        public Circle(Vector2 location, float Radius)
        {
            this.Radius = Radius;
            this.Location = location;
        }

        public bool Intersects(Circle secCircle)
        {
            //double combinedRadius = Math.Sqrt((double)(this.Radius * this.Radius) + (secCircle.Radius * secCircle.Radius));
            float distanceBetween = Vector2.Distance(this.Location,secCircle.Location);

            return distanceBetween < (Radius * 2);
            
        }
    }
}
