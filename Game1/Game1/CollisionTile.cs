using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Game1
{
    class CollisionTile
    {

        public List<Rectangle> getCollisionTiles(int[,] map)
        {
            Rectangle collisionTile;
            List<Rectangle> collisionTiles = new List<Rectangle>();
            
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int mapIndex = map[y, x];
                    if (mapIndex == -1)
                        continue;

                    int tileNumber = mapIndex;

                    // Collide with number 0.
                    if (tileNumber == 0)
                    {
                        collisionTile = new Rectangle(x, y, 1, 1);
                        collisionTiles.Add(collisionTile);
                    }
                }
            }
            
            return collisionTiles;
        }

    }
}
