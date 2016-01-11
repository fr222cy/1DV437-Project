using Game1.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Mastercontoller : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song song;
        GameController gameController;
        MenuController menuController;
     
        enum Gamestate
        {
            Menu,
            Playing,
        }

        int hasClickedOnSomething = 0;

        Gamestate CurrentGameState = Gamestate.Menu;

        public Mastercontoller()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 960;
            graphics.IsFullScreen = false;
        }

        
        protected override void Initialize()
        {
            base.Initialize();
        }
       
      
        protected override void LoadContent()
        {
            song = Content.Load<Song>("Motorbike-rock-3");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.1f; 
            MediaPlayer.Play(song);
            
            
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menuController = new MenuController(graphics);
            gameController = new GameController();

            //Loads Menu Content.
            menuController.LoadContent(spriteBatch, Content, GraphicsDevice.Viewport);
        
            //Loads Game Content.
            gameController.LoadContent(spriteBatch, Content, GraphicsDevice.Viewport);
        }

     
        protected override void UnloadContent()
        {
            Content.Unload(); 
        }

     
        protected override void Update(GameTime gameTime)
        {
           
            switch(CurrentGameState)
            {
                case Gamestate.Menu:
                    
                    //this.IsMouseVisible = true;
                    hasClickedOnSomething = menuController.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                    
                    if (hasClickedOnSomething == 1)
                    {
                        CurrentGameState = Gamestate.Playing;
                    }
                    else if (hasClickedOnSomething == 2)
                    {
                        quit();
                    }
                    else if (hasClickedOnSomething == 3)
                    {
                        gameController.LoadContent(spriteBatch, Content, GraphicsDevice.Viewport);
                        CurrentGameState = Gamestate.Playing;
                    }
                    
                    break; 

                case Gamestate.Playing:
                    
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        CurrentGameState = Gamestate.Menu;
                    }

                    gameController.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                    break;
            }

            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);
            
            switch (CurrentGameState)
            {
                case Gamestate.Menu:
                    menuController.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
                    break;

                case Gamestate.Playing:
                    gameController.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
                    break;
            }

            base.Draw(gameTime);
        }

        public void quit()
        {
            this.Exit();
        }
    }
}
