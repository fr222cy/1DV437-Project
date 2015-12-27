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
        Vector2 hitBox;
        float speed;
        float maxspeed = -4f;
        float acceleration = 1f;
        float steeringAngle;
        float steeringModifier = 0.030f;
        float hitTimer;
        Vector2 startPosition = new Vector2(16.5f, 23.5f);
        Tiles tiles;
        int[,] map; 
        bool carHit = false;
        
        PlayerCar playerCar;
        
        public GameSimulation(int[,] map)
        {
            this.map = map;
            playerCar = new PlayerCar(startPosition);
            hitBox = playerCar.getHitBox();
            this.tiles = new Tiles(map);
        }

        public void carTuning()
        {
            maxspeed = -6f;
            acceleration = 0.5f;
            steeringModifier = 0.035f;
        }

        public void resetGame()
        {
            playerCar.resetPosition(startPosition);
        }


        public Vector2 GetPosition()
        {
            return playerCar.getPosition();
        }

        public void carMovement(float elapsedTime)
        {
         
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
                    if (speed < 0 )
                    {
                        speed *= 0.999f;
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

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    speed *= 0.92f;
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

        public string getSpeedToKPH()
        {
            return String.Format("{0:0}KPH", -speed * 50);
        }

        public void collision(float elapsedTime)
        {
            //Checking for Level Bounds.
            if(Math.Floor(playerCar.getPosition().X + hitBox.X) > map.GetLength(1) ||
               Math.Floor(playerCar.getPosition().X - hitBox.X) < 0 ||
               Math.Floor(playerCar.getPosition().Y + hitBox.Y) >= map.GetLength(0) ||
               Math.Floor(playerCar.getPosition().Y - hitBox.Y) <= 0
            )
            {
                carHit = true;
            }

            //Checking for collisionTiles.
            foreach(Rectangle tile in tiles.getCollisionTiles())
            {
                if (tile.X <=  Math.Floor(playerCar.getPosition().X + hitBox.X) &&
                tile.X >=  Math.Floor(playerCar.getPosition().X - hitBox.X) &&
                tile.Y <=  Math.Floor(playerCar.getPosition().Y + hitBox.Y) &&
                tile.Y >=  Math.Floor(playerCar.getPosition().Y - hitBox.Y) )
                {
                    carHit = true; 
                }        
            }

            //Checking for pitstopTile.
            Rectangle pitStopTile = tiles.getPitTile();

            if(pitStopTile.X <=  Math.Floor(playerCar.getPosition().X + hitBox.X) &&
            pitStopTile.X >=  Math.Floor(playerCar.getPosition().X - hitBox.X) &&
            pitStopTile.Y <= Math.Floor(playerCar.getPosition().Y + hitBox.Y) &&
            pitStopTile.Y >= Math.Floor(playerCar.getPosition().Y - hitBox.Y))
            {
                Console.WriteLine("IN PIT");
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
