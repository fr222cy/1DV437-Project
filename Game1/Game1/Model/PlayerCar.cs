using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Model
{
    class PlayerCar
    {
        float size;
        
        Vector2 position;
        float wheelBase;
        float heading;
        Vector2 hitBox;

        public PlayerCar()
        {
            position = new Vector2(24, 21);
            size = 0.65f;
            wheelBase = 0.25f;
            hitBox = new Vector2(wheelBase, wheelBase/2);
        }

        public float getSize()
        {
            return size;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public float getRotation()
        {
            return heading;
        }

        public void setPosition(float elapsedTime, float speed, float steerAngle)
        {

            //http://engineeringdotnet.blogspot.se/2010/04/simple-2d-car-physics-in-games.html

            Vector2 frontWheel = position + wheelBase / 2 * new Vector2((float)Math.Cos(heading), (float)Math.Sin(heading));
            Vector2 backWheel = position - wheelBase / 2 * new Vector2((float)Math.Cos(heading), (float)Math.Sin(heading));

            backWheel += speed * elapsedTime * new Vector2((float)Math.Cos(heading + steerAngle), (float)Math.Sin(heading + steerAngle));
            frontWheel += speed * elapsedTime * new Vector2((float)Math.Cos(heading ), (float)Math.Sin(heading));

            position = (frontWheel + backWheel) / 2;
            heading = (float)Math.Atan2(frontWheel.Y - backWheel.Y, frontWheel.X - backWheel.X);
        }

        public Vector2 getHitBox()
        {
            return hitBox;
        }



        

    }
}
