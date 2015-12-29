using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Game1
{
    class Tiles
    {
        
        List<Rectangle> collisionTiles = new List<Rectangle>();
        Rectangle pitStopTile;
        List<Rectangle> goalTiles = new List<Rectangle>();
        Rectangle checkPointTile;
        public Tiles(int[,] map)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int mapIndex = map[y, x];
                    if (mapIndex == -1)
                        continue;

                    int tileNumber = mapIndex;

                    // Collide with number 0 and 13.
                    if (tileNumber == 0 || tileNumber == 13)
                    {
                        Rectangle collisionTile = new Rectangle(x, y, 1, 1);
                        collisionTiles.Add(collisionTile);
                    }
                    //PITSTOPTILE HAS INDEX 15.
                    if(tileNumber == 15)
                    {
                        pitStopTile = new Rectangle(x, y, 1, 1);
                    }
                    //GOALTILE 

                    if(tileNumber == 12)
                    {
                        Rectangle goalTile = new Rectangle(x, y, 1, 1);
                        goalTiles.Add(goalTile);
                    }

                    // Checkpoint
                    if(tileNumber == 16)
                    {
                        checkPointTile = new Rectangle(x, y, 1, 1);
                    }

                }
            }
        }
      
        public List<Rectangle> getCollisionTiles()
        {   
            return collisionTiles;
        }

        public Rectangle getPitTile()
        {
            return pitStopTile;
        }

        public List<Rectangle> getGoalTiles()
        {
            return goalTiles;
        }

        public Rectangle getCheckPointTile()
        {
            return checkPointTile;
        }

    }
}
