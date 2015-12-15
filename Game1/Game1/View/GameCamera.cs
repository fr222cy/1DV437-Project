using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1.View
{
    class GameCamera
    {
             

        float scaleX;
        float scaleY;
        Vector2 cameraOffset;
        private int tileSize;
              public GameCamera(Viewport port, int[,] map)
              {
                  tileSize = 1;
                  scaleX =  (map.GetLength(1));
                  scaleY =  (map.GetLength(0));
              }

              public void Update(Vector2 position, float width)
              {
                  if (position.X >= 30f)
                  {
                      cameraOffset.X = (position.X - 0.5f) * scaleX;
                  }

                  if (position.Y <= 30f)
                  {
                      cameraOffset.Y = (position.Y - 0.3f) * scaleY;
                  }
              }

              public int getTileSize()
              {
                  return tileSize;
              }

              public Vector2 getViewCoords(Vector2 position)
              {
                  float screenX = (scaleX * position.X) - cameraOffset.X;
                  float screenY = (scaleY * position.Y) - cameraOffset.Y;
                
                  return new Vector2(screenX, screenY);
              }

              public void center()
              {

              }

              public float getScale(float size, float width)
              {
                  return scaleX * size / width;
                   
              }

    }
}
