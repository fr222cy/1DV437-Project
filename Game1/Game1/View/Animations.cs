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
    

        private float size;
        private const int MAX_SPLITTER_PARTICLES = 10;
        private GameCamera camera;
        int counter = 0;
        public Animations(GameCamera camera)
        {
            this.size = 0.05f;
            this.camera = camera;
    
        }

        public void spawn(Vector2 startPosition)
        {   
            for (int i = 0; i < MAX_SPLITTER_PARTICLES; i++)
            {
                
                splitterParticles.Add(new carSplitter(i, camera, size, startPosition));
             
                splitterParticles.ElementAt(i).spawn();
            }

            
        }
       

        public void update(float elapsedTime)
        { 
            foreach(carSplitter splitterParticle in splitterParticles)
            {
               
                splitterParticle.update(elapsedTime);
            }
           
        }

        public void draw(Texture2D splitter, SpriteBatch spriteBatch)
        {       
            foreach(carSplitter splitterParticle in splitterParticles)
            {
                splitterParticle.draw(splitter, spriteBatch);
            }
            
        }

        public bool animationActive()
        {
            if(splitterParticles != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
 }

