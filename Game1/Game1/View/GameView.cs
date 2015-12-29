﻿using System;
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
        GameSimulation car;

        public GameView(GameCamera camera, GameSimulation car)
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
            sBatch.Draw(
                player,
                camera.getViewCoords(car.GetPosition()),
                player.Bounds, Color.White, car.getRotation(),
                new Vector2(player.Bounds.Width/2, player.Bounds.Height/2),
                scale,
                SpriteEffects.None,
                0);
            sBatch.End();
        }

        public void drawMap(SpriteBatch sBatch , int[,] map, List<Texture2D> mapTexture)
        {

            float tileSize = camera.getTileSize();
            float size = 1f;
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

        public void drawText(SpriteBatch sBatch, float elapsedTime, SpriteFont font)
        {
            float fontWidth = 25;


            float scale = camera.getScale(1, fontWidth);

            sBatch.Begin();
            sBatch.DrawString(font, this.car.getBestLapTime(), camera.getViewCoords(new Vector2(0, 21)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.DrawString(font, this.car.getLapTime(), camera.getViewCoords(new Vector2(0, 22)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.DrawString(font,this.car.getSpeedToKPH(), camera.getViewCoords(new Vector2(0, 23)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None,0);
            sBatch.End();
        }


     

    }
}
