using Game1.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Mastercontoller : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameController gameController;
        MenuController menuController;

        enum Gamestate
        {
            Menu,
            Playing,
        }

        Gamestate CurrentGameState = Gamestate.Menu;

        public Mastercontoller()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
          

            base.Initialize();
        }

      
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loads Menu Content.
            menuController.LoadContent(spriteBatch);

            //Loads Game Content.
            gameController.LoadContent(spriteBatch);

  
        }

     
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

     
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch(CurrentGameState)
            {
                case Gamestate.Menu:
                    break;

                case Gamestate.Playing:
                    break;
            }

            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (CurrentGameState)
            {
                case Gamestate.Menu:
                    break;

                case Gamestate.Playing:
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
