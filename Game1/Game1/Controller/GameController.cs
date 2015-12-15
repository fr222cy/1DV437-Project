using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Game1.View;
using Game1.Model;

namespace Game1.Controller
{
    class GameController
    {
      
        GameView gameView;
        GameCamera camera;
        CarSimulation carSimulation;
        int[,] map;
        float speed;
        float steering;

        Texture2D player;

        private List<Texture2D> mapTexture = new List<Texture2D>();

        public GameController()
        {

        }

        public void LoadContent(SpriteBatch sBatch, ContentManager Content,Viewport port)
        {
            
            
            Texture2D asphaltTile = Content.Load<Texture2D>("AsphaltTile.png");
            Texture2D grassTile = Content.Load<Texture2D>("GrassTile.png");
            Texture2D barrier_B_L = Content.Load<Texture2D>("Track-Barrier-Down-Left.png");
            Texture2D barrier_B_R = Content.Load<Texture2D>("Track-Barrier-Down-Right.png");
            Texture2D barrier_T_L = Content.Load<Texture2D>("Track-Barrier-Up-Left.png");
            Texture2D barrier_T_R = Content.Load<Texture2D>("Track-Barrier-Up-Right.png");
            Texture2D asphaltGoal = Content.Load<Texture2D>("AsphaltGoal.png");
            player = Content.Load<Texture2D>("playerCar.png");
            //Create the TileMap
            //Inspired by http://xnatd.blogspot.se/2009/02/ok-so-first-part-of-our-tower-defence.html
            
            //Load Level 1.
            Level1 level_1 = new Level1();
            map = level_1.getMap();

            mapTexture.Add(grassTile);
            mapTexture.Add(asphaltTile);
            mapTexture.Add(barrier_B_L);
            mapTexture.Add(barrier_B_R);
            mapTexture.Add(barrier_T_L);
            mapTexture.Add(barrier_T_R);
            mapTexture.Add(asphaltGoal);

            carSimulation = new CarSimulation(map);
            camera = new GameCamera(port, map);
            gameView = new GameView(camera, carSimulation);
        }

        public void Update(float elapsedTime)
        {

                   
                carSimulation.carMovement(elapsedTime); 

            
        }

        public void Draw(SpriteBatch sBatch, float elapsedTime)
        {
            gameView.drawMap(sBatch, map, mapTexture);
            gameView.drawPlayer(sBatch, player, elapsedTime);
        }

       
    }
}
