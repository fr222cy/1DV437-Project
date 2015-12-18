using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Model
{
    class GameSimulation
    {
        float speed;
        float maxspeed = -4f;
        float acceleration = 0.5f;
        float steeringAngle;
        float steeringModifier = 0.04f;
        int hit = 0;
        PlayerCar playerCar;
        List<Rectangle> collisionTiles;
        Vector2 hitBox;
        int[,] map;
        bool carHit = false;
        float hitTimer;
        public GameSimulation(int[,] map, List<Rectangle> collisionTiles)
        {
            this.collisionTiles = collisionTiles;
            this.map = map;
            playerCar = new PlayerCar();
            hitBox = playerCar.getHitBox();
        }


        public Vector2 GetPosition()
        {
            return playerCar.getPosition();
        }

        public void carMovement(float elapsedTime)
        {
            //Console.WriteLine(playerCar.getPosition());
            collision(elapsedTime);

         
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (speed > maxspeed)
                    {
                        speed -= acceleration * elapsedTime;
                    }
                }
                else
                {
                    if (speed > 0 )
                    {
                        speed *= 0.98f;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    speed += acceleration * elapsedTime;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    steeringAngle += steeringModifier;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    steeringAngle -= steeringModifier;
                }
                
                
                if(!carHit)
                {
                    playerCar.setPosition(elapsedTime, speed, steeringAngle);
                    steeringAngle *= 0.8f;
                }
                else
                {
                    playerCar.setPosition(elapsedTime, -speed/4, steeringAngle);
                    
                }
          
              
            
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

        public void collision(float elapsedTime)
        {
            
            if(Math.Floor(playerCar.getPosition().X + hitBox.X) > map.GetLength(1) ||
               Math.Floor(playerCar.getPosition().X - hitBox.X) < 0 ||
               Math.Floor(playerCar.getPosition().Y + hitBox.Y) >= map.GetLength(0) ||
               Math.Floor(playerCar.getPosition().Y - hitBox.Y) <= 0
            )
            {
                carHit = true;
            }



            foreach(Rectangle tile in collisionTiles)
            {

                if (tile.X <=  Math.Floor(playerCar.getPosition().X + hitBox.X) &&
                    tile.X >=  Math.Floor(playerCar.getPosition().X - hitBox.X) &&
                    tile.Y <=  Math.Floor(playerCar.getPosition().Y + hitBox.Y) &&
                    tile.Y >=  Math.Floor(playerCar.getPosition().Y - hitBox.Y) )
                {
                    hit++;
                    //Console.WriteLine("hit" + tile.X + " " + tile.Y);

                    carHit = true; 
                }        
            }

            if(carHit)
            {
                hitTimer += 1f * elapsedTime;
                Console.WriteLine(hitTimer);
                if(hitTimer > 1)
                {
                    speed = 0;
                    carHit = false;
                    hitTimer = 0;
                }
                
            }

            

            
        }
    }
}
