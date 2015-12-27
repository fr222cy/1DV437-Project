using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View
{
    class MenuView
    {

        MenuCamera camera;
        Vector2 playButtonPos;
        Vector2 mousePosition;
        Vector2 pos_800;
        Vector2 pos_1024;
        Vector2 pos_1280;
        Vector2 pos_1600;
        Vector2 pos_fullscreen;

        Texture2D playButton;
        float buttonScale = 1f;
        float minButtonscale = 1f;
        float maxButtonscale = 1.2f;
        float buttonModelWidth;
        float buttonModelHeight;

        

        public MenuView(MenuCamera camera)
        {
            this.camera = camera;
            mousePosition = Vector2.Zero;
            playButtonPos = new Vector2(0.3f, 0.3f);
            pos_800 = new Vector2(0.3f, 0.35f);
            pos_1024 = new Vector2(0.3f, 0.4f);
            pos_1280 = new Vector2(0.3f, 0.45f);
            pos_1600 = new Vector2(0.3f, 0.5f);
            pos_fullscreen = new Vector2(0.3f, 0.6f);
            
        }

        public bool Update(Vector2 mousePosition , Texture2D playButton, bool hasClicked, GraphicsDeviceManager graphics)
        {
            this.playButton = playButton;
            buttonModelWidth = camera.getModelWidth(playButton.Width);
            buttonModelHeight = camera.getModelHeight(playButton.Height);


            this.mousePosition = mousePosition;

             Vector2 mouseModelPosition = camera.getClickModelCoords(mousePosition);
          
      
            //TODO: FIX PLAYBUTTON FOR FULLSCREEN

            if (playButtonPos.X >= mouseModelPosition.X - buttonModelWidth && playButtonPos.X <=  mouseModelPosition.X + buttonModelWidth
            && playButtonPos.Y >= mouseModelPosition.Y - buttonModelHeight && playButtonPos.Y <= mouseModelPosition.Y + buttonModelHeight)
            {
                if(buttonScale < maxButtonscale)
                {
                    buttonScale += 0.01f;
                }
                if(hasClicked)
                {
                    return true;
                }
            }

            else
            {
                if(buttonScale > minButtonscale)
                {
                    buttonScale -= 0.01f;
                }
            }
            //800x600
            if (pos_800.X >= mouseModelPosition.X - buttonModelWidth && pos_800.X <= mouseModelPosition.X + buttonModelWidth
            && pos_800.Y >= mouseModelPosition.Y - buttonModelHeight && pos_800.Y <= mouseModelPosition.Y + buttonModelHeight)
            {
                if (hasClicked)
                {
                    graphics.PreferredBackBufferWidth = 800;
                    graphics.PreferredBackBufferHeight = 600;      
                    graphics.ApplyChanges();
                }
            }
            //1024x768
            if (pos_1024.X >= mouseModelPosition.X - buttonModelWidth && pos_1024.X <= mouseModelPosition.X + buttonModelWidth
            && pos_1024.Y >= mouseModelPosition.Y - buttonModelHeight && pos_1024.Y <= mouseModelPosition.Y + buttonModelHeight)
            {
                if (hasClicked)
                {
                    graphics.PreferredBackBufferWidth = 1024;
                    graphics.PreferredBackBufferHeight = 768;        
                    graphics.ApplyChanges();
                }
            }
            //1280x960
            if (pos_1280.X >= mouseModelPosition.X - buttonModelWidth && pos_1280.X <= mouseModelPosition.X + buttonModelWidth
            && pos_1280.Y >= mouseModelPosition.Y - buttonModelHeight && pos_1280.Y <= mouseModelPosition.Y + buttonModelHeight)
            {
                if (hasClicked)
                {
                    graphics.PreferredBackBufferWidth = 1280;
                    graphics.PreferredBackBufferHeight = 960;
                    graphics.ApplyChanges();
                }
            }
            //1600x1200
            if (pos_1600.X >= mouseModelPosition.X - buttonModelWidth && pos_1600.X <= mouseModelPosition.X + buttonModelWidth
            && pos_1600.Y >= mouseModelPosition.Y - buttonModelHeight && pos_1600.Y <= mouseModelPosition.Y + buttonModelHeight)
            {
                if (hasClicked)
                {
                    graphics.PreferredBackBufferWidth = 1600;
                    graphics.PreferredBackBufferHeight = 1200;
                    graphics.ApplyChanges();
                }
            }
            //Fullscreen Toggle
            if (pos_fullscreen.X >= mouseModelPosition.X - buttonModelWidth && pos_fullscreen.X <= mouseModelPosition.X + buttonModelWidth
            && pos_fullscreen.Y >= mouseModelPosition.Y - buttonModelHeight && pos_fullscreen.Y <= mouseModelPosition.Y + buttonModelHeight)
            {
                if (hasClicked)
                {
                    if (graphics.IsFullScreen)
                        graphics.IsFullScreen = false;
                    else
                    {
                        graphics.IsFullScreen = true;
                    }
                    
                    graphics.ApplyChanges();
                }
            }

            return false;
        }

        public void Draw(SpriteBatch sBatch, float elapsedSeconds, 
            Texture2D menuBackground,
            Texture2D res_800,
            Texture2D res_1024,
            Texture2D res_1280,
            Texture2D res_1600,
            Texture2D fullscreen,
            Texture2D cursor)
        {
            float scale = camera.getScale((float)menuBackground.Width);

            sBatch.Begin();
            sBatch.Draw(menuBackground, Vector2.Zero, menuBackground.Bounds, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.Draw(playButton, camera.getViewCoords(playButtonPos, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, buttonScale, SpriteEffects.None, 0);
            sBatch.Draw(res_800, camera.getViewCoords(pos_800, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            sBatch.Draw(res_1024, camera.getViewCoords(pos_1024, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            sBatch.Draw(res_1280, camera.getViewCoords(pos_1280, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            sBatch.Draw(res_1600, camera.getViewCoords(pos_1600, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            sBatch.Draw(fullscreen, camera.getViewCoords(pos_fullscreen, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            sBatch.Draw(cursor, mousePosition, cursor.Bounds, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.End();

            Console.WriteLine(mousePosition);
            Console.WriteLine(cursor.Width);
        }
        

    }
}
