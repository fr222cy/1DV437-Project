using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Model
{
    class CarSimulation
    {
        float speed;
        float maxspeed = -4f;
        float acceleration = 0.5f;
        float steeringAngle;
        float steeringModifier = 0.03f;
        PlayerCar playerCar;
        int[,] map;
        public CarSimulation(int[,] map)
        {
            this.map = map;
            playerCar = new PlayerCar();
        }


        public Vector2 GetPosition()
        {
            return playerCar.getPosition();
        }

        public void carMovement(float elapsedTime)
        {
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (speed > maxspeed)
                {
                    speed -= acceleration * elapsedTime;
                }
               
            }
            else
            {   
                if(speed > 0 || speed < 0)
                {
                    speed *= 0.98f;
                }          
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                speed += acceleration * elapsedTime;
            }               
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                steeringAngle += steeringModifier;
            }
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                steeringAngle -= steeringModifier;
            }


          

            
            playerCar.setPosition(elapsedTime, speed, steeringAngle);

            steeringAngle *= 0.8f;
            
        }

        public float getRotation()
        {
            return playerCar.getRotation();
        }

        public float getSize()
        {
            return playerCar.getSize();
        }

        public float getSpeed()
        {
            
            return speed;
        }
    }
}
