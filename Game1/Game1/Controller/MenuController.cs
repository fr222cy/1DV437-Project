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
        GraphicsDeviceManager graphics;

        Texture2D menuBackground;
        Texture2D playButton;
        Texture2D res_800x600;
        Texture2D res_1024x768;
        Texture2D res_1280x960;
        Texture2D res_1600x1200;
        Texture2D fullscreen;
        MenuView menuView;
        MenuCamera menuCamera;
        MouseState lastMouseState;
        MouseState currentMouseState;
        Texture2D cursor;
        bool hasClicked = false;
        bool hasClickedPlay = false;
        public MenuController(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
        }

        public void LoadContent(SpriteBatch sBatch, ContentManager Content, Viewport port)
        {
            //Loads Menu Content.
            menuCamera = new MenuCamera(port);

            cursor = Content.Load<Texture2D>("cursor.png");
            menuBackground = Content.Load<Texture2D>("GameMenu.png");
            playButton = Content.Load<Texture2D>("playButton.png");
            res_800x600 = Content.Load<Texture2D>("800x600.png");
            res_1024x768 = Content.Load<Texture2D>("1024x768.png");
            res_1280x960 = Content.Load<Texture2D>("1280x960.png");
            res_1600x1200 = Content.Load<Texture2D>("1600x1200.png");
            fullscreen = Content.Load<Texture2D>("Fullscreen.png");
            menuView = new MenuView(menuCamera);
        }

        public bool Update(float elapsedSeconds)
        {
            lastMouseState = currentMouseState;

            currentMouseState = Mouse.GetState();
            var mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            hasClickedPlay = menuView.Update(mousePosition, playButton, hasClicked, graphics);

            if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                hasClicked = true;
                // Returns true if the mouse click is within the Playbutton area. 
                hasClickedPlay = menuView.Update(mousePosition, playButton, hasClicked, graphics);
                hasClicked = false;
            }
            return hasClickedPlay;
        }

        public void Draw(SpriteBatch sBatch, float elapsedSeconds)
        {
            menuView.Draw(sBatch, elapsedSeconds,
                menuBackground,
                res_800x600,
                res_1024x768,
                res_1280x960,
                res_1600x1200,
                fullscreen,
                cursor);            
        }
    }
}
