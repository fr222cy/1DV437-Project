using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.View.View.Animations
{
    class Smoke
    {
            private GameCamera camera;
            private Color color;
            private float size;
            private float minSize;
            private float maxSize;
            private float maxLifeTime;
            private float fade = 1;
            private float lifePercent;
            private float lifeTime;
            private Vector2 position;
            private bool smokeDone = false;

            public Smoke(GameCamera camera, float size, Vector2 position)
            {
                this.camera = camera;
                size *= 3f;
                this.minSize = size * 0.5f;
                this.maxSize = size * 10f;
                this.position = position;
                this.maxLifeTime = 3;                
            }


            public void update(float elapsedTime)
            {
                lifeTime += elapsedTime;

                lifePercent = lifeTime / maxLifeTime;

                size = minSize + lifePercent * maxSize;

               
                //fades the smoke depending on how long it is suppose to live. 
                fade = maxLifeTime - lifeTime;
               
                color = new Color(fade, fade, fade, fade);

                if(fade <= 0)
                {
                    smokeDone = true;
                }

            }


            public void draw(Texture2D texture, SpriteBatch spriteBatch)
            {

                float scale = camera.getScale(size, texture.Width);

                spriteBatch.Begin();

                spriteBatch.Draw(texture, camera.getViewCoords(this.position), texture.Bounds, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);

                spriteBatch.End();

            }
            
        public bool isSmokeDone()
        {
            return smokeDone;
        }

        }
    }

