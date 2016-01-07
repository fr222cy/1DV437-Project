using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Game1.View;
using Game1.Model;

namespace Game1.Controller
{///TODO: FIX "GAME COMPLETE", Easier Sliding sound, Balance car setup.
    class GameController
    {
        PitView pitView;
        CarHandling carHandling;
        GameView gameView;
        GameCamera camera;
        GameSimulation gameSimulation;
        Levels level;
        SpriteFont font;
        Viewport port;
        SoundHandler sh;
        List<Texture2D> mapTexture = new List<Texture2D>();
        List<SoundEffectInstance> engineSounds = new List<SoundEffectInstance>();
        SoundEffectInstance crash, tire_scream, e0, air_horn;
        Texture2D player,
                  pitBackground,
                  red_particle,
                  smoke,
                  skidmark,
                  mudmark;

        float timeToBeat;
        int levelCounter = 1;
        const int MAX_LEVEL = 5;
        int[,] map;

  
        PlayerState CurrentPlayerState = PlayerState.NextLevel;
        enum PlayerState
        {
            OnTrack,
            InPit,
            NextLevel,
            GameCompleted,
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
            
            //Load Levels.
            level = new Levels();
            map = level.getLevel(levelCounter);
            
            // Add tile textures
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
            mapTexture.Add(Content.Load<Texture2D>("arrowLeft.png"));

            // Add sounds
            e0 = Content.Load<SoundEffect>("loop_0").CreateInstance();
            tire_scream = Content.Load<SoundEffect>("tire-scream").CreateInstance();
            crash = Content.Load<SoundEffect>("crash").CreateInstance();
            air_horn = Content.Load<SoundEffect>("air-horn").CreateInstance();
            //Particle Texture
            red_particle = Content.Load<Texture2D>("red.png");
            smoke = Content.Load<Texture2D>("smoke.png");
            skidmark = Content.Load<Texture2D>("black.png");
            mudmark = Content.Load<Texture2D>("mudMarks.png");
            timeToBeat = level.getLevelTime(levelCounter);
            sh = new SoundHandler();
            carHandling = new CarHandling();
            gameSimulation = new GameSimulation(map, carHandling, timeToBeat, sh);
            camera = new GameCamera(port, map, player);
            pitView = new PitView(camera);
            gameView = new GameView(camera, gameSimulation, sh);
            
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

            //Check if player is ontack, inpit or is loading the next level. 
            switch (CurrentPlayerState)
            {
                case PlayerState.OnTrack:
                    MediaPlayer.Pause();
                    gameSimulation.updateLap(elapsedTime);
                    gameSimulation.pitTimer(elapsedTime);
                    gameSimulation.carMovement(elapsedTime);
                    gameView.updateAnimations(elapsedTime);
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

                        MediaPlayer.Resume();
                        MediaPlayer.Volume = 0.05f;
                        e0.Volume = 0;
                        pitView.update(carHandling);
                        gameSimulation.depo();
                        break;

                case PlayerState.NextLevel:

                        if(levelCounter >= MAX_LEVEL)
                        {
                            CurrentPlayerState = PlayerState.GameCompleted;
                            break;
                        }
                        MediaPlayer.Resume();
                        MediaPlayer.Volume = 0.05f;
                        e0.Volume = 0;
                        map = level.getLevel(levelCounter);

                        timeToBeat = level.getLevelTime(levelCounter);
                        carHandling = new CarHandling();
                        gameSimulation = new GameSimulation(map, carHandling, timeToBeat, sh);
                        gameView = new GameView(camera, gameSimulation, sh);

                        if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        {
                            CurrentPlayerState = PlayerState.InPit;
                        }

                    break;

                case PlayerState.GameCompleted:

                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {

                            levelCounter = 1;
                            CurrentPlayerState = PlayerState.NextLevel;
                        }

                        if(Keyboard.GetState().IsKeyDown(Keys.Escape))
                        {
                        
                        }
                    break;
            }
           
        }

        public void Draw(SpriteBatch sBatch, float elapsedTime)
        {
            switch(CurrentPlayerState)
            {

                //Calling Drawmethods depending on the player state. 
                case PlayerState.OnTrack:
                gameView.drawMap(sBatch, map, mapTexture);
                gameView.drawAnimations(red_particle, sBatch, smoke, skidmark, mudmark);
                gameView.drawPlayer(sBatch, player, elapsedTime);
                gameView.drawText(sBatch, elapsedTime, font);
                gameView.animationsAndSounds(e0, elapsedTime, crash, tire_scream, air_horn);
               

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

                case PlayerState.GameCompleted:
                break;
            }
        }
    }
}
