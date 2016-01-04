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
        string steerSlowdown = "";
        string resources = "";
        public PitView(GameCamera camera)
        {
            this.camera = camera;
        }

        public void update(CarHandling handling)
        {
            maxspeed = String.Format("Max Speed: {0:0.0} {1} ",(-handling.getMaxSpeed() * 50), "KM/H");
            acceleration = String.Format("Acceleration: {0:0.00}",handling.getAcceleration());
            steering = String.Format("Steering Modifier: {0:0.0000}", handling.getSteeringModifier());
            steerSlowdown = String.Format("Steer Slowdown: {0:0.0000}%", handling.getSteerSlowdown() * 100 );
            resources = String.Format("Resouces: {0:0}%", handling.getResources() * 6.666667);
        }
              
        public void draw(SpriteBatch sBatch, Texture2D background, SpriteFont font, float timeToBeat)
        {

            float pitScale = camera.getPitWindowScale(background.Width);
            float textScale = camera.getPitWindowScale(background.Width);
            sBatch.Begin();
            sBatch.Draw(background, Vector2.Zero, background.Bounds, Color.White, 0f, Vector2.Zero, pitScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, timeToBeat.ToString()+".00", camera.getPitTextPosition(new Vector2(0.125f, 0.135f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, maxspeed, camera.getPitTextPosition(new Vector2(0.45f, 0.32f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, acceleration, camera.getPitTextPosition(new Vector2(0.45f, 0.34f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, steering, camera.getPitTextPosition(new Vector2(0.45f, 0.36f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, steerSlowdown, camera.getPitTextPosition(new Vector2(0.45f, 0.38f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, resources, camera.getPitTextPosition(new Vector2(0.45f, 0.07f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.DrawString(font, "Press 'R' to Reset", camera.getPitTextPosition(new Vector2(0.45f, 0.40f)), Color.Black, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0);
            sBatch.End();
        }
        
        
    }
}
