using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShip4042.Class;

namespace SpaceShip4042.Screen
{
    public class SplashScreen : IScreen
    {
        #region Properties

        private bool _current;
        private int _count;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private Texture2D _background;

        public bool Current
        {
            get { return _current; }
            set { _current = value; }
        }

        #endregion

        #region Constructor

        public SplashScreen(ContentManager content, GraphicsDeviceManager graphics)
        {
            _content = content;
            _graphics = graphics;
        }

        #endregion

        #region IScreen Members

        public void Init()
        {

        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _background = _content.Load<Texture2D>("Screen\\splash_screen");
        }

        public void Update()
        {
            if (_count >= Type.DELAY)
            {
                _current = false;
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

            _spriteBatch.End();
        }

        #endregion
    }
}
