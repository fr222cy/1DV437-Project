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
        //LEVEL
        int[,] map; 
  
        //PLAYER VARIABLES
        float speed;
        float steeringAngle;
        float hitTimer;
        bool carHit = false;
        Vector2 hitBox;
        Vector2 startPosition = new Vector2(16.5f, 23.5f);

        //OBJECTS
        Tiles tiles;
        CarHandling handling;
        PlayerCar playerCar;

        //PIT VARIABLES
        float timePit = 0;
        bool pitted = true;
        bool canPit = false;
        
        public GameSimulation(int[,] map, CarHandling handling)
        {
            this.map = map;
            this.handling = handling;
            this.tiles = new Tiles(map);
            this.playerCar = new PlayerCar(startPosition);
            this.hitBox = playerCar.getHitBox();
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
                    if (speed > handling.getMaxSpeed())
                    {
                        speed -= handling.getAcceleration() * elapsedTime;
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
                    speed += handling.getAcceleration() * elapsedTime;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    steeringAngle += handling.getSteeringModifier();
                    speed *= 0.994f;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    steeringAngle -= handling.getSteeringModifier();
                    speed *= 0.994f;
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

        public bool isInPit()
        {
            //Checking for pitstopTile.
            Rectangle pitStopTile = tiles.getPitTile();
            if(canPit)
            {           
                if (pitStopTile.X <= Math.Floor(playerCar.getPosition().X + hitBox.X) &&
                pitStopTile.X >= Math.Floor(playerCar.getPosition().X - hitBox.X) &&
                pitStopTile.Y <= Math.Floor(playerCar.getPosition().Y + hitBox.Y) &&
                pitStopTile.Y >= Math.Floor(playerCar.getPosition().Y - hitBox.Y))
                {
                    pitted = true;
                }
                else
                {
                    pitted = false;
                }
            }
            return pitted;
        }

        public void pitTimer(float elapsedTime)
        {
            timePit += elapsedTime;

            if(timePit > 10)
            {
                canPit = true;
                timePit = 0;
            }
        }

        public void depo()
        {
            //Front Spoiler
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
               
                handling.setAcceleration(0.002f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                handling.setAcceleration(-0.002f);
              
            }
            //Engine Limiter
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                handling.setMaxSpeed(0.001f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {    
                handling.setMaxSpeed(-0.001f);
            }    
            //Turn Radius
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                handling.setSteeringModifier(-0.00001f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                handling.setSteeringModifier(0.00001f);
            }
            //Reset Values.
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                handling.reset();
            }

            //Go to Track
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                pitted = false;
                canPit = false;
            }


        }
    }
}
