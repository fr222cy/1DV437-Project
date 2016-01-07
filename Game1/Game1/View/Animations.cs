using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.View.View.Animations;

namespace Game1.View
{
    class Animations
    {


        List<carSplitter> splitterParticles = new List<carSplitter>();
        List<Skidmark> skidmarks = new List<Skidmark>();
        List<Skidmark> mudMarks = new List<Skidmark>();
        List<Smoke> smokes = new List<Smoke>();
        List<Smoke> smokesToRemove = new List<Smoke>();
        private float size;
        private const int MAX_SPLITTER_PARTICLES = 13;
        private const int MAX_SMOKE_PARTICLES = 10;
        private GameCamera camera;

        public Animations(GameCamera camera)
        {
            this.size = 0.05f;
            this.camera = camera;
        }

        public void spawnParticles(Vector2 startPosition)
        {
            for (int i = 0; i < MAX_SPLITTER_PARTICLES; i++)
            {
                splitterParticles.Add(new carSplitter(i, camera, size, startPosition));
                splitterParticles.ElementAt(i).spawn();
            }
        }

        public void spawnSmoke(Vector2 startPosition)
        {
            smokes.Add(new Smoke(camera, size, startPosition));      
        }

        public void spawnSkidMarks(Vector2 startPosition)
        {
            skidmarks.Add(new Skidmark(camera, size, startPosition));
        }

        public void spawnMudMarks(Vector2 startPosition)
        {
            mudMarks.Add(new Skidmark(camera, size, startPosition));
        }



        public void update(float elapsedTime)
        {
            foreach (carSplitter splitterParticle in splitterParticles)
            {
                splitterParticle.update(elapsedTime);
            }
                

            foreach (Smoke smokeParticle in smokes)
            {
                smokeParticle.update(elapsedTime);       
            
                if(smokeParticle.isSmokeDone())
                {
                    smokesToRemove.Add(smokeParticle);
                }
            }

            foreach (Smoke smoke in smokesToRemove)
            {
                smokes.Remove(smoke);
            }
   
        }

        public void draw(Texture2D splitter, SpriteBatch spriteBatch, Texture2D smoke, Texture2D skidmarkTexture, Texture2D mudMarkTexture)
        {
                foreach (carSplitter splitterParticle in splitterParticles)
                {
                    splitterParticle.draw(splitter, spriteBatch);
                }

                foreach (Smoke smokeParticle in smokes)
                {
                    smokeParticle.draw(smoke, spriteBatch);
                }

                foreach(Skidmark skidmark in skidmarks)
                {
                    skidmark.draw(skidmarkTexture, spriteBatch);
                }

                foreach(Skidmark mudmark in mudMarks)
                {
                    mudmark.draw(mudMarkTexture, spriteBatch);
                }
        }

    } 
 }

