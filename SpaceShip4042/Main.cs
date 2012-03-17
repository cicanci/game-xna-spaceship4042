using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShip4042.Screen;
using SpaceShip4042.Class;
using System.IO;
using Microsoft.Xna.Framework.Storage;

namespace SpaceShip4042
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SplashScreen _splashScreen;
        private GameScreen _gameScreen;
        private MenuScreen _menuScreen;
        private GameOverScreen _gameOverScreen;
        private CreditoScreen _creditoScreen;
        private RankingScreen _rankingScreen;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(100);

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _splashScreen = new SplashScreen(Content, graphics);
            _splashScreen.Current = true;
            _gameScreen = new GameScreen(Content, graphics);
            _menuScreen = new MenuScreen(Content, graphics);
            _gameOverScreen = new GameOverScreen(Content, graphics);
            _creditoScreen = new CreditoScreen(Content, graphics);
            _rankingScreen = new RankingScreen(Content, graphics);

            Pontuacao();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _splashScreen.LoadContent(spriteBatch);
            _gameScreen.LoadContent(spriteBatch);
            _menuScreen.LoadContent(spriteBatch);
            _gameOverScreen.LoadContent(spriteBatch);
            _creditoScreen.LoadContent(spriteBatch);
            _rankingScreen.LoadContent(spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            // TODO: Add your update logic here
            if (_splashScreen.Current)
            {
                _splashScreen.Update();
            }
            else
            {
                Init();
                SelectMenu(true);                
            }

            base.Update(gameTime);           
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            if (_splashScreen.Current)
            {
                _splashScreen.Draw();
            }
            else
            {
                Init();
                SelectMenu(false);                
            }

            base.Draw(gameTime);
        }        

        private void Pontuacao()
        {
            // Get the path of the save game
            string fullpath = Path.Combine(StorageContainer.TitleLocation, Type.HighScoresFilename);

            // Check to see if the save exists
            if (!File.Exists(fullpath))
            {
                //If the file doesn't exist, make a fake one...
                // Create the data to save
                Score.HighScoreData data = new Score.HighScoreData(5);
                data.PlayerName[0] = "1.";
                data.Level[0] = 0;
                data.Score[0] = 0;

                data.PlayerName[1] = "2.";
                data.Level[1] = 0;
                data.Score[1] = 0;

                data.PlayerName[2] = "3.";
                data.Level[2] = 0;
                data.Score[2] = 0;

                data.PlayerName[3] = "4.";
                data.Level[3] = 0;
                data.Score[3] = 0;

                data.PlayerName[4] = "5.";
                data.Level[4] = 0;
                data.Score[4] = 0;

                Score.SaveHighScores(data, Type.HighScoresFilename);
            }

        }

        private void Init()
        {
            if (_menuScreen.Restart)
            {
                _gameScreen.Init();
                _rankingScreen.Init();
                _creditoScreen.Init();
                _gameOverScreen.Init();
                switch (_menuScreen.Selected)
                {
                    case Type.Menu.Menu:
                        break;
                    case Type.Menu.Jogar:
                        _gameScreen.Init();
                        _gameOverScreen.Init();
                        break;
                    case Type.Menu.Ranking:
                        _rankingScreen.Init();
                        break;
                    case Type.Menu.Creditos:
                        _creditoScreen.Init();
                        break;
                    case Type.Menu.Sair:
                        break;
                    case Type.Menu.GameOver:
                        break;
                }

                _menuScreen.Restart = false;
            }
        }

        private void SelectMenu(bool update)
        {   
            switch (_menuScreen.Selected)
            {
                case Type.Menu.Menu:
                    if (update)
                    {
                        _menuScreen.Update();
                    }
                    else
                    {
                        _menuScreen.Draw();
                    }
                    break;
                case Type.Menu.Jogar:
                    if (!_gameScreen.GameOver)
                    {
                        if (update)
                        {
                            _gameScreen.Update();
                        }
                        else
                        {
                            _gameScreen.Draw();
                        }

                        if (_gameScreen.Power)
                        {
                            TargetElapsedTime = TimeSpan.FromMilliseconds(_gameScreen.Frame_Rate / 2);
                        }
                        else
                        {
                            TargetElapsedTime = TimeSpan.FromMilliseconds(_gameScreen.Frame_Rate);
                        }
                    }
                    else
                    {
                        _gameOverScreen.Menu = false;
                        _gameOverScreen.NewScore = _gameScreen.GameScore;
                        _menuScreen.Selected = Type.Menu.GameOver;
                        TargetElapsedTime = TimeSpan.FromMilliseconds(Type.FRAME_RATE);
                    }
                    break;
                case Type.Menu.Ranking:
                    if (!_rankingScreen.Menu)
                    {
                        if (update)
                        {
                            _rankingScreen.Update();
                        }
                        else
                        {
                            _rankingScreen.Draw();
                        }
                    }
                    else
                    {
                        _menuScreen.Selected = Type.Menu.Menu;
                    }
                    break;
                case Type.Menu.Creditos:
                    if (!_creditoScreen.Menu)
                    {
                        if (update)
                        {
                            _creditoScreen.Update();
                        }
                        else
                        {
                            _creditoScreen.Draw();
                        }
                    }
                    else
                    {
                        _menuScreen.Selected = Type.Menu.Menu;
                    }
                    break;
                case Type.Menu.Sair:
                    this.Exit();
                    break;
                case Type.Menu.GameOver:
                    if (!_gameOverScreen.Menu)
                    {
                        if (update)
                        {
                            _gameOverScreen.Update();
                        }
                        else
                        {
                            _gameOverScreen.Draw();
                        }
                    }
                    else
                    {
                        _menuScreen.Selected = Type.Menu.Menu;
                    }
                    break;
            }
        }
    }
}
