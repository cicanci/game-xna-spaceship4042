using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShip4042.Class;

namespace SpaceShip4042.Screen
{
    public class CreditoScreen : IScreen
    {
        #region Properties

        private bool _menu;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private Texture2D _background;

        public bool Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        #endregion

        #region Constructor

        public CreditoScreen(ContentManager content, GraphicsDeviceManager graphics)
        {
            _content = content;
            _graphics = graphics;
        }

        #endregion

        #region IScreen Members

        public void Init()
        {
            _menu = false;
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _background = _content.Load<Texture2D>("Screen\\creditos_screen");
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

            _spriteBatch.End();
        }

        #endregion
    }
}
