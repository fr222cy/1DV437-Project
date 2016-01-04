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
        PitView pitView;
        CarHandling carHandling;
        GameView gameView;
        GameCamera camera;
        GameSimulation gameSimulation;
        SpriteFont font;     
        Texture2D player;
        Texture2D pitBackground;
        Levels level;
        float timeToBeat;
        int levelCounter = 3;
        Viewport port;
        private List<Texture2D> mapTexture = new List<Texture2D>();

        PlayerState CurrentPlayerState = PlayerState.NextLevel;

        int[,] map;
        
        enum PlayerState
        {
            OnTrack,
            InPit,
            NextLevel,
        }
       
        public void LoadContent(SpriteBatch sBatch, ContentManager Content,Viewport port)
        {
            Texture2D grassTile = Content.Load<Texture2D>("GrassTile.png");
            pitBackground = Content.Load<Texture2D>("pitBackground.png");
            player = Content.Load<Texture2D>("playerCar.png");
            font = Content.Load<SpriteFont>("LapTimeFont");
            this.port = port;
            //Create the TileMap
            //Inspired by http://xnatd.blogspot.se/2009/02/ok-so-first-part-of-our-tower-defence.html
            
            //Load Level 1.
            level = new Levels();
            map = level.getLevel(levelCounter);
            
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
            mapTexture.Add(Content.Load<Texture2D>("checkPoint.png"));
            mapTexture.Add(Content.Load<Texture2D>("mudTile.png"));

            timeToBeat = level.getLevelTime(levelCounter);

            carHandling = new CarHandling();
            gameSimulation = new GameSimulation(map, carHandling, timeToBeat);
            camera = new GameCamera(port, map, player);
            pitView = new PitView(camera);
            gameView = new GameView(camera, gameSimulation);
            
        }

        public void Update(float elapsedTime)
        {
       
            //Check if player is in the pitlane || is changing level || on track.
            if (gameSimulation.isInPit() && CurrentPlayerState != PlayerState.NextLevel)
            {
                CurrentPlayerState = PlayerState.InPit;
            }
            else if(CurrentPlayerState == PlayerState.NextLevel)
            {
                CurrentPlayerState = PlayerState.NextLevel;
            }
            else
            {
                CurrentPlayerState = PlayerState.OnTrack;
            }

            switch (CurrentPlayerState)
            {
                case PlayerState.OnTrack:

                    gameSimulation.updateLap(elapsedTime);
                    gameSimulation.pitTimer(elapsedTime);
                    gameSimulation.carMovement(elapsedTime);

                    if (gameSimulation.isPlayerWinner())
                    {

                        if(gameSimulation.isWonDelayTimerFinished(elapsedTime))
                        {
                            CurrentPlayerState = PlayerState.NextLevel;
                            levelCounter++;
                        }
                    }
                    break;

                case PlayerState.InPit:

                    pitView.update(carHandling);
                    gameSimulation.depo();
                    break;

                case PlayerState.NextLevel:
                                   
                  
                    map = level.getLevel(levelCounter);

                    timeToBeat = level.getLevelTime(levelCounter);
                    carHandling = new CarHandling();
                    gameSimulation = new GameSimulation(map, carHandling, timeToBeat);
                    gameView = new GameView(camera, gameSimulation);

                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        CurrentPlayerState = PlayerState.InPit;
                    }
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

                if (gameSimulation.isPlayerWinner())
                {
                    gameView.drawWon(sBatch, font, levelCounter);
                }

                break;

                case PlayerState.InPit:
                pitView.draw(sBatch, pitBackground, font, timeToBeat);
                break;
                
                case PlayerState.NextLevel:
                gameView.drawLevel(sBatch, font, levelCounter);
                break;
            }
        }
    }
}
