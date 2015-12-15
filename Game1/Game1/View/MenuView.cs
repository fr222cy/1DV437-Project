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
        Texture2D playButton;
        float buttonScale = 1f;
        float minButtonscale = 1f;
        float maxButtonscale = 1.2f;
        float buttonModelWidth;
        float buttonModelHeight;


        public MenuView(MenuCamera camera)
        {
            this.camera = camera;
           
            playButtonPos = new Vector2(0.3f, 0.3f);
           
        }

        public bool Update(Vector2 mousePosition , Texture2D playButton, bool hasClicked)
        {
            this.playButton = playButton;
            buttonModelWidth = camera.getModelWidth(playButton.Width);
            buttonModelHeight = camera.getModelHeight(playButton.Height);
            


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
            return false;
        }

        public void Draw(SpriteBatch sBatch, float elapsedSeconds, Texture2D menuBackground)
        {
            float scale = camera.getScale((float)menuBackground.Width);

            sBatch.Begin();
            sBatch.Draw(menuBackground, Vector2.Zero, menuBackground.Bounds, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            sBatch.Draw(playButton, camera.getViewCoords(playButtonPos, playButton.Width, playButton.Height), playButton.Bounds, Color.White, 0f, Vector2.Zero, buttonScale, SpriteEffects.None, 0);
            sBatch.End();
        }
        

    }
}
