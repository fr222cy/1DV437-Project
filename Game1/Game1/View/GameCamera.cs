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
        //Vector2 cameraOffset;
        private int tileSize;
        Viewport port;
        int[,] map;
              public GameCamera(Viewport port, int[,] map , Texture2D player)
              {
                  tileSize = 1 ;
                  this.map = map;
                  Vector2 ratio = new Vector2(4, 3);
                  this.port = port;
                  
                  scaleX = port.Width /map.GetLength(1);
                  scaleY = port.Height/ map.GetLength(0);
              }

              public int getTileSize()
              {
                  return tileSize;
              }

              public Vector2 getViewCoords(Vector2 position)
              {
                  float screenX = (scaleX * position.X);
                  float screenY = (scaleY * position.Y);
                  
                  return new Vector2(screenX, screenY);
              }

              public float getScale(float size, float width)
              {
                  return scaleX * size / width; 
              }

              
              public float getPitWindowScale(float width)
              {
                  float pitScale =   port.Width / width;

                  return pitScale;
              }

              public Vector2 getPitTextPosition(Vector2 position)
              {
                  float screenX = (port.Width * position.X);
                  float screenY = (port.Height * position.Y);

                  return new Vector2(screenX, screenY);
              }

              public void update()
              {
                  scaleX = port.Width / map.GetLength(1);
                  scaleY = port.Height / map.GetLength(0);
              }

    }
}
