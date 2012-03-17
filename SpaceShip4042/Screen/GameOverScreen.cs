using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShip4042.Class;

namespace SpaceShip4042.Screen
{
    public class GameOverScreen : IScreen
    {
        #region Properties

        private bool _menu;
        private int _count, _newScore;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private Texture2D _background;
        private SpriteFont _font;

        public bool Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        public int NewScore
        {
            get { return _newScore; }
            set { _newScore = value; }
        }

        #endregion

        #region Constructor

        public GameOverScreen(ContentManager content, GraphicsDeviceManager graphics)
        {
            _content = content;
            _graphics = graphics;
        }

        #endregion

        #region IScreen Members

        public void Init()
        {
            _menu = false;
            _count = 0;
            _newScore = 0;
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _background = _content.Load<Texture2D>("Screen\\gameover_screen");
            _font = _content.Load<SpriteFont>("Font\\impact");
        }

        public void Update()
        {
            if (_count >= Type.DELAY)
            {
                _menu = true;
                
                if (_newScore > 0)
                {
                    SaveHighScore();
                }

                _count = 0;
            }
            else
            {
                _count++;
            }
        }

        public void Draw()
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            _spriteBatch.DrawString(_font, "PONTOS: " + _newScore.ToString(), new Vector2(500, 400), Color.White);

            _spriteBatch.End();
        }

        #endregion

        #region Methods

        private void SaveHighScore()
        {
            // Create the data to save
            Score.HighScoreData data = Score.LoadHighScores(Type.HighScoresFilename);

            int scoreIndex = -1;
            for (int i = 0; i < data.Count; i++)
            {
                if (_newScore > data.Score[i])
                {
                    scoreIndex = i;
                    break;
                }
            }

            if (scoreIndex > -1)
            {
                //New high score found ... do swaps
                for (int i = data.Count - 1; i > scoreIndex; i--)
                {
                    data.PlayerName[i] = data.PlayerName[i - 1];
                    data.Score[i] = data.Score[i - 1];
                    data.Level[i] = data.Level[i - 1];
                }

                //data.PlayerName[scoreIndex] = "Player1"; //Retrieve User Name Here
                data.Score[scoreIndex] = _newScore;
                //data.Level[scoreIndex] = currentLevel + 1;

                Score.SaveHighScores(data, Type.HighScoresFilename);
            }
        }

        #endregion
    }
}
