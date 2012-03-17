using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShip4042.Class;

namespace SpaceShip4042.Screen
{
    public class MenuScreen : IScreen
    {
        #region Properties

        private Type.Menu _menu, _selected;
        private bool _restart;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private Texture2D _background, _btjogar, _btranking, _btcreditos, _btsair;

        public Type.Menu Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public bool Restart
        {
            get { return _restart; }
            set { _restart = value; }
        }

        #endregion

        #region Constructor

        public MenuScreen(ContentManager content, GraphicsDeviceManager graphics)
        {
            _content = content;
            _graphics = graphics;
            _selected = Type.Menu.Menu;
            _menu = Type.Menu.Jogar;
        }

        #endregion

        #region IScreen Members

        public void Init()
        {

        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _btjogar = _content.Load<Texture2D>("Screen\\bt_jogar");
            _btranking = _content.Load<Texture2D>("Screen\\bt_ranking");
            _btcreditos = _content.Load<Texture2D>("Screen\\bt_creditos");
            _btsair = _content.Load<Texture2D>("Screen\\bt_sair");
            _background = _content.Load<Texture2D>("Screen\\menu_screen"); 
        }

        public void Update()
        {
            KeyboardState kbsKeyboard = Keyboard.GetState();

            if (kbsKeyboard.IsKeyDown(Keys.Up))
            {
                if (_menu == Type.Menu.Sair)
                {
                    _menu = Type.Menu.Creditos;
                }
                else if (_menu == Type.Menu.Creditos)
                {
                    _menu = Type.Menu.Ranking;
                }
                else if (_menu == Type.Menu.Ranking)
                {
                    _menu = Type.Menu.Jogar;
                }
            }
            if (kbsKeyboard.IsKeyDown(Keys.Down))
            {
                if (_menu == Type.Menu.Jogar)
                {
                    _menu = Type.Menu.Ranking;
                }
                else if (_menu == Type.Menu.Ranking)
                {
                    _menu = Type.Menu.Creditos;
                }
                else if (_menu == Type.Menu.Creditos)
                {
                    _menu = Type.Menu.Sair;
                }
            }
            if ((kbsKeyboard.IsKeyDown(Keys.Enter)) ||
                (kbsKeyboard.IsKeyDown(Keys.Space)))
            {
                _restart = true;
                _selected = _menu;
            }
        }

        public void Draw()
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            switch (_menu)
            {
                case Type.Menu.Jogar:
                    Draw(Color.White, Color.Gray, Color.Gray, Color.Gray);
                    break;
                case Type.Menu.Ranking:
                    Draw(Color.Gray, Color.White, Color.Gray, Color.Gray);
                    break;
                case Type.Menu.Creditos:
                    Draw(Color.Gray, Color.Gray, Color.White, Color.Gray);
                    break;
                case Type.Menu.Sair:
                    Draw(Color.Gray, Color.Gray, Color.Gray, Color.White);
                    break;
            }

            _spriteBatch.End();
        }

        public void Draw(Color bt1, Color bt2, Color bt3, Color bt4)
        {
            _spriteBatch.Draw(_btjogar, new Vector2(720, 370), bt1);
            _spriteBatch.Draw(_btranking, new Vector2(720, 450), bt2);
            _spriteBatch.Draw(_btcreditos, new Vector2(720, 530), bt3);
            _spriteBatch.Draw(_btsair, new Vector2(720, 610), bt4);
        }

        #endregion
    }
}
