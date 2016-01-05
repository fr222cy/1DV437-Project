using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Game1.Model;

namespace Game1.View
{
    class GameView 
    {
        float timeElapsedEngine = 0;
        float timeElapsedCrash = 0;
        GameCamera camera;
        GameSimulation car;
        SoundHandler soundHandler;
        Animations animations;
        public GameView(GameCamera camera, GameSimulation car, SoundHandler sh)
        {
            this.soundHandler = sh;
            this.car = car;
            this.camera = camera;
            this.animations = new Animations(camera);
        }

        public void drawPlayer(SpriteBatch sBatch, Texture2D player, float elapsedTime)
        {           
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

        public void drawLevel(SpriteBatch sBatch, SpriteFont font, int level)
        {
            float fontWidth = 30;
            float scale = camera.getScale(1, fontWidth);

            sBatch.Begin();
            sBatch.DrawString(font, "Level "+ level.ToString(), camera.getViewCoords(new Vector2(15, 10)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.DrawString(font, "Press Space To begin", camera.getViewCoords(new Vector2(14, 11)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.End();
        }

        public void drawWon(SpriteBatch sBatch, SpriteFont font, int level)
        {
            float fontWidth = 30;
            float scale = camera.getScale(1, fontWidth);

            sBatch.Begin();
            sBatch.DrawString(font, "Congratulations! \nYou won level " + level.ToString() + " !", camera.getViewCoords(new Vector2(15, 10)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
       
            sBatch.End();
        }

        public void updateAnimations(float elapsedTime)
        {
            if(animations.animationActive())
            {
                animations.update(elapsedTime);
                
            }
        }
        public void drawAnimations(float elapsedTime, Texture2D particle, SpriteBatch sbatch)
        {
            if (animations.animationActive())
            {
                animations.draw(particle, sbatch);
            }
        }

        public void animationsAndSounds(List<SoundEffect> engineSounds, float elapsedTime, SoundEffect crash)
        {
            
            timeElapsedEngine += 0.01f;
            timeElapsedCrash += 0.01f;
            
                var e0 = engineSounds.ElementAt(0).CreateInstance();
                var e1 = engineSounds.ElementAt(1).CreateInstance();
                var e2 = engineSounds.ElementAt(2).CreateInstance();
                var e3 = engineSounds.ElementAt(3).CreateInstance();
                var e4 = engineSounds.ElementAt(4).CreateInstance();
                var e5 = engineSounds.ElementAt(5).CreateInstance();
            
                
                var crashSound = crash.CreateInstance();
                float volume = 0.1f;
                if(timeElapsedEngine >= 0.35f)
                {
                    if (this.car.getSpeed() <= 1 && this.car.getSpeed() < 0)
                    {
                        if (e0.State != SoundState.Playing)
                        {
                            e0.Volume = volume;
                            e0.Play();
                        }
                        
                      
                    }
                                   
                    if (this.car.getSpeed() > 1 && this.car.getSpeed() < 40)
                    {
                        if(e1.State != SoundState.Playing)
                        {
                            e1.Volume = volume;
                            e1.Play();
                        }
                       
                        
                    }
                    if (this.car.getSpeed() >= 40 && this.car.getSpeed() < 80)
                    {
                        if (e2.State != SoundState.Playing)
                        {
                            e2.Volume = volume;
                            e2.Play();
                        }
                    }
                    if (this.car.getSpeed() > 80 && this.car.getSpeed() < 130)
                    {
                        if (e3.State != SoundState.Playing)
                        {
                            e3.Volume = volume;
                            e3.Play();
                        }
                    }
                    if (this.car.getSpeed() >= 130 && this.car.getSpeed() < 180)
                    {
                        if(e4.State != SoundState.Playing)
                        {
                            e4.Volume = volume;
                            e4.Play(); 
                        }
                        
                    }
                    if (this.car.getSpeed() >= 180)
                    {
                        if (e5.State != SoundState.Playing)
                        {
                            e5.Volume = volume;
                            e5.Play(); 
                        }
                        
                    }

                    timeElapsedEngine = 0;               
                }

                
                
            if(soundHandler.isCrashing())
            {
                
                if(crashSound.State != SoundState.Playing && timeElapsedCrash > 0.6f)
                {
                    crashSound.Volume = volume;
                    crashSound.Play();
                    animations.spawn(this.car.GetPosition());
                 
                    timeElapsedCrash = 0;
                }
                
            }
        }

      
    }
}
