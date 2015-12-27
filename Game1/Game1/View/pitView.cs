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
    class PitView
    {

        GameCamera camera;
        string maxspeed = "";
        string acceleration = "";
        string steering = "";
        public PitView(GameCamera camera)
        {
            this.camera = camera;
        }

        public void update(CarHandling handling)
        {
            maxspeed = String.Format("Max Speed: {0:0.0} {1} ",(-handling.getMaxSpeed() * 50), "KM/H");
            acceleration = String.Format("Acceleration: {0:0.00}",handling.getAcceleration());
            steering = String.Format("Steering Modifier: {0:0.0000}", handling.getSteeringModifier());
        }

      
        public void draw(SpriteBatch sBatch, Texture2D background, SpriteFont font)
        {

            float pitScale = camera.getPitWindowScale(background.Width);
            float textScale = camera.getPitWindowScale(background.Width);
            sBatch.Begin();
            sBatch.Draw(background, Vector2.Zero, background.Bounds, Color.White, 0f, Vector2.Zero, pitScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, maxspeed, camera.getPitTextPosition(new Vector2(0.5f, 0.33f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, acceleration, camera.getPitTextPosition(new Vector2(0.5f, 0.35f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, steering, camera.getPitTextPosition(new Vector2(0.5f, 0.37f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, "Press 'R' to Reset", camera.getPitTextPosition(new Vector2(0.5f, 0.39f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.End();
        }
        
        
    }
}
