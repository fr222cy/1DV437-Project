using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View.View.Animations
{
    class Skidmark
    {
        private float size;
        private Vector2 position;
        GameCamera camera;
        public Skidmark(GameCamera camera, float size, Vector2 position)
        {
            this.camera = camera;
            this.size = size;
            this.position = position;
        }

        public void draw(Texture2D texture, SpriteBatch spriteBatch)
        {

            float scale = camera.getScale(size, texture.Width);

            spriteBatch.Begin();

            spriteBatch.Draw(texture, camera.getViewCoords(this.position), texture.Bounds, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);

            spriteBatch.End(); 
        }
    }
}
