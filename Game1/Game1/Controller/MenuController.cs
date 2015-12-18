using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Game1.View;

namespace Game1.Controller
{
    class MenuController
    {
        Texture2D menuBackground;
        Texture2D playButton;
        MenuView menuView;
        MenuCamera menuCamera;
        MouseState lastMouseState;
        MouseState currentMouseState;
        bool hasClicked = false;
        bool hasClickedPlay = false;
        public MenuController()
        {

        }

        public void LoadContent(SpriteBatch sBatch, ContentManager Content, Viewport port)
        {
            //Loads Menu Content.
            menuCamera = new MenuCamera(port);
            menuBackground = Content.Load<Texture2D>("GameMenu.png");
            playButton = Content.Load<Texture2D>("playButton.png");
            menuView = new MenuView(menuCamera);
        }

        public bool Update(float elapsedSeconds)
        {
            lastMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
            var mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            hasClickedPlay = menuView.Update(mousePosition, playButton, hasClicked);

            if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                hasClicked = true;
                // Returns true if the mouse click is within the Playbutton area. 
                hasClickedPlay = menuView.Update(mousePosition, playButton, hasClicked);
                hasClicked = false;
            }
            return hasClickedPlay;
        }

        public void Draw(SpriteBatch sBatch, float elapsedSeconds)
        {
            menuView.Draw(sBatch, elapsedSeconds, menuBackground);            
        }
    }
}
