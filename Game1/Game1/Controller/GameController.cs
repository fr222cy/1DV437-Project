﻿using System;
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
        GameSimulation gameSimulation;
        SpriteFont font;     
        Texture2D player;
        private List<Texture2D> mapTexture = new List<Texture2D>();

        PlayerState CurrentPlayerState = PlayerState.OnTrack;

        int[,] map;
        

        enum PlayerState
        {
            OnTrack,
            InPit,
        }
       
        public void LoadContent(SpriteBatch sBatch, ContentManager Content,Viewport port)
        {

           

            Texture2D grassTile = Content.Load<Texture2D>("GrassTile.png");

            player = Content.Load<Texture2D>("playerCar.png");
            font = Content.Load<SpriteFont>("LapTimeFont");
            //Create the TileMap
            //Inspired by http://xnatd.blogspot.se/2009/02/ok-so-first-part-of-our-tower-defence.html
            
            //Load Level 1.
            Level1 level_1 = new Level1();
            map = level_1.getMap();
            
            mapTexture.Add(grassTile);
            mapTexture.Add(Content.Load<Texture2D>("borderUpDown.png"));
            mapTexture.Add(Content.Load<Texture2D>("borderUp.png"));
            mapTexture.Add(Content.Load<Texture2D>("borderDown.png"));
            mapTexture.Add(Content.Load<Texture2D>("borderLeft.png"));
            mapTexture.Add(Content.Load<Texture2D>("borderRight.png"));
            mapTexture.Add(Content.Load<Texture2D>("Regular.png"));        
            mapTexture.Add(Content.Load<Texture2D>("borderLeftTop.png"));
            mapTexture.Add(Content.Load<Texture2D>("borderRightTop.png"));
            mapTexture.Add(Content.Load<Texture2D>("borderLeftDown.png"));
            mapTexture.Add(Content.Load<Texture2D>("borderRightDown.png"));
            mapTexture.Add(Content.Load<Texture2D>("borderLeftRight.png"));
            mapTexture.Add(Content.Load<Texture2D>("goal.png"));
            mapTexture.Add(Content.Load<Texture2D>("stand.png"));
            mapTexture.Add(Content.Load<Texture2D>("PitlaneArrow.png"));
            mapTexture.Add(Content.Load<Texture2D>("PitlaneStop.png"));

          
            gameSimulation = new GameSimulation(map);
            camera = new GameCamera(port, map, player);
            gameView = new GameView(camera, gameSimulation);
        }

        public void Update(float elapsedTime)
        {

            switch(CurrentPlayerState)
            {
                case PlayerState.OnTrack:
                gameSimulation.carMovement(elapsedTime);
                break;

                case PlayerState.InPit:
                break;
            }
           
        }

        public void Draw(SpriteBatch sBatch, float elapsedTime)
        {
            switch(CurrentPlayerState)
            {
                case PlayerState.OnTrack:

                gameView.drawMap(sBatch, map, mapTexture);
                gameView.drawPlayer(sBatch, player, elapsedTime);
                gameView.drawText(sBatch, elapsedTime, font);
                break;

                case PlayerState.InPit:
                break;

            }
                
            
           
        }
    }
}
