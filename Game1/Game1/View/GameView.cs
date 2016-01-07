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
        float timeElapsedTireScream = 0;
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
            sBatch.DrawString(font, (GC.GetTotalMemory(false) / 1000).ToString() , camera.getViewCoords(new Vector2(0, 20)), Color.White, 0f, Vector2.Zero,scale, SpriteEffects.None, 0);
            sBatch.DrawString(font, this.car.getBestLapTime(), camera.getViewCoords(new Vector2(0, 21)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.DrawString(font, this.car.getLapTime(), camera.getViewCoords(new Vector2(0, 22)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.DrawString(font,this.car.getSpeedToKPH(), camera.getViewCoords(new Vector2(0, 23)), Color.Snow, 0f, Vector2.Zero, scale, SpriteEffects.None,0);

            if(this.car.shouldShowStuckTips())
            {
                sBatch.DrawString(font, "Stuck? Press 'T' to get back to pit.", camera.getViewCoords(this.car.GetPosition()), Color.Snow, 0f, Vector2.Zero, scale/2, SpriteEffects.None, 0);
            }

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
                animations.update(elapsedTime);    
        }
        public void drawAnimations(Texture2D particle, SpriteBatch sbatch, Texture2D smoke, Texture2D skidmark, Texture2D mudmark)
        {
                animations.draw(particle, sbatch, smoke, skidmark, mudmark);
        }

        public void animationsAndSounds(
            SoundEffectInstance engineSound,
            float elapsedTime,
            SoundEffectInstance crash,
            SoundEffectInstance tire_scream,
            SoundEffectInstance goalSound)
        {
            
            timeElapsedEngine += elapsedTime;
            timeElapsedCrash += elapsedTime;
            timeElapsedTireScream += elapsedTime;
         

                float volume = 0.1f;
                if(timeElapsedEngine >= 0.1f)
                {

                    if (this.car.getSpeed() > 0)
                    {
                            engineSound.Volume = volume;
                            engineSound.Pitch = 0f;                      
                    }
                                   
                    if (this.car.getSpeed() > 1 && this.car.getSpeed() < 40)
                    {
                        engineSound.Pitch = 0.2f;
                    }

                    if (this.car.getSpeed() >= 40 && this.car.getSpeed() < 80)
                    {
                        engineSound.Pitch = 0.3f;      
                    }

                    if (this.car.getSpeed() > 80 && this.car.getSpeed() < 130)
                    {
                        engineSound.Pitch = 0.4f;    
                    }

                    if (this.car.getSpeed() >= 130 && this.car.getSpeed() < 180)
                    {
                        engineSound.Pitch = 0.5f;   
                    }

                    if (this.car.getSpeed() >= 180)
                    {
                        engineSound.Pitch = 0.6f;   
                    }
                    
                    timeElapsedEngine = 0;
                    engineSound.Volume = volume;
                    engineSound.Play();
                    engineSound.IsLooped = true;
                }

    
                
            if(soundHandler.isCrashing())
            {
                
                if(crash.State != SoundState.Playing && timeElapsedCrash > 0.6f)
                {
                    crash.Volume = volume;
                    crash.Play();
                    animations.spawnParticles(this.car.GetPosition());
                    
                    timeElapsedCrash = 0;
                }
                
            }
          

            if (soundHandler.isTireScreaming())
            {

                if (tire_scream.State != SoundState.Playing && timeElapsedTireScream > 0.6f)
                {
                    tire_scream.Volume = volume;
                    tire_scream.Play();

                    timeElapsedTireScream = 0;
                }
                animations.spawnSkidMarks(this.car.GetPosition());               
                animations.spawnSmoke(this.car.GetPosition());
            }
            else
            {
                tire_scream.Stop();
            }

            if(soundHandler.isInMud())
            {
                animations.spawnMudMarks(this.car.GetPosition());
            }


            if(soundHandler.isInGoal())
            {
                goalSound.Volume = 0.1f;
                goalSound.Play();
            }
            
        }
           

    } 
}

