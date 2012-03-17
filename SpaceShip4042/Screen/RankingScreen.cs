using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShip4042.Class;

namespace SpaceShip4042.Screen
{
    public class RankingScreen : IScreen
    {
        #region Properties

        private bool _menu;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private Texture2D _background;
        private Score.HighScoreData _data;
        private SpriteFont _font;

        public bool Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        #endregion

        #region Constructor

        public RankingScreen(ContentManager content, GraphicsDeviceManager graphics)
        {
            _content = content;
            _graphics = graphics;
            _data = Score.LoadHighScores(Type.HighScoresFilename);
            
        }

        #endregion

        #region IScreen Members

        public void Init()
        {
            _menu = false;
            _data = Score.LoadHighScores(Type.HighScoresFilename);
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _background = _content.Load<Texture2D>("Screen\\ranking_screen");
            _font = _content.Load<SpriteFont>("Font\\impact");
        }

        public void Update()
        {
            KeyboardState kbsKeyboard = Keyboard.GetState();

            if ((kbsKeyboard.IsKeyDown(Keys.Enter)) ||
                (kbsKeyboard.IsKeyDown(Keys.Space)) ||
                (kbsKeyboard.IsKeyDown(Keys.Back)) ||
                (kbsKeyboard.IsKeyDown(Keys.Escape)) ||
                (kbsKeyboard.IsKeyDown(Keys.Up)) ||
                (kbsKeyboard.IsKeyDown(Keys.Down)) ||
                (kbsKeyboard.IsKeyDown(Keys.Left)) ||
                (kbsKeyboard.IsKeyDown(Keys.Right)))
            {
                _menu = true;
            }
        }

        public void Draw()
        {
            _spriteBatch.Begin();
                        
            _spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            _spriteBatch.DrawString(_font, getText(0), new Vector2(500, 300), Color.White);
            _spriteBatch.DrawString(_font, getText(1), new Vector2(500, 350), Color.White);
            _spriteBatch.DrawString(_font, getText(2), new Vector2(500, 400), Color.White);
            _spriteBatch.DrawString(_font, getText(3), new Vector2(500, 450), Color.White);
            _spriteBatch.DrawString(_font, getText(4), new Vector2(500, 500), Color.White);

            _spriteBatch.End();
        }

        #endregion

        #region

        private string getText(int index)
        {
            return (index + 1) + ". " + _data.Score[index].ToString();
        }

        #endregion
    }
}
