using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Model;

namespace Game1.View
{
    class GameView
    {

        GameCamera camera;
        CarSimulation car;

        public GameView(GameCamera camera, CarSimulation car)
        {
            this.car = car;
            this.camera = camera;
        }

        public void Update()
        {

        }

        public void drawPlayer(SpriteBatch sBatch, Texture2D player, float elapsedTime)
        {

            //camera.Update( car.GetPosition(), player.Width);
            
           float scale = camera.getScale(car.getSize(), player.Width);

            sBatch.Begin();
            sBatch.Draw(player, camera.getViewCoords(car.GetPosition()), player.Bounds, Color.White, car.getRotation(), Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.End();
        }

        public void drawMap(SpriteBatch sBatch , int[,] map, List<Texture2D> mapTexture)
        {

            float tileSize = camera.getTileSize();
            float size = 2f;
            float scale = camera.getScale(size, (float)tileSize);
            tileSize *= scale;

            sBatch.Begin();
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;
                    
                    Texture2D texture = mapTexture[textureIndex];
                    
                    sBatch.Draw(texture, new Rectangle(x * (int)tileSize, y * (int)tileSize, (int)tileSize, (int)tileSize)  , Color.White);
                    
                    

                }  
            }
            sBatch.End();
        }


        

    }
}
