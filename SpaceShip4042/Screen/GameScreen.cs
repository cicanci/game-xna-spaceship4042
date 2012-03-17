using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceShip4042.Class;

namespace SpaceShip4042.Screen
{
    public class GameScreen : IScreen
    {
        #region Properties

        private bool _fire, _gameOver, _difficult, _power;
        private int _meteor_rate, _gameScore, _frame_rate, _item_life_rate, _item_power_rate;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Sprite _player, _item_life, _item_power;
        private List<Texture2D> _animation_meteor, _animation_shoot, _animation_ship01, _animation_ship02;
        private List<Sprite> _meteors, _shoots;
        private ContentManager _content;
        private SpriteFont _font;

        public bool GameOver
        {
            get { return _gameOver; }
            set { _gameOver = value; }
        }

        public bool Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public int GameScore
        {
            get { return _gameScore; }
            set { _gameScore = value; }
        }

        public int Frame_Rate
        {
            get { return _frame_rate; }
            set { _frame_rate = value; }
        }

        #endregion

        #region Constructor

        public GameScreen(ContentManager content, GraphicsDeviceManager graphics)
        {
            // TODO: Add your initialization logic here
            _player = new Sprite(new Vector2(565, 285),
                new Rectangle(565, 285, 150, 150), 50, 5, 5);
            _item_life = new Sprite(new Vector2(-75, 0), 
                new Rectangle(-75, 0, 75, 75), 30, 1, 0);
            _item_power = new Sprite(new Vector2(-75, 0), 
                new Rectangle(-75, 0, 75, 75), 30, 1, 0);
            _meteors = new List<Sprite>();
            _shoots = new List<Sprite>();
            _content = content;
            _graphics = graphics;
            _item_life_rate = 750;
            _item_power_rate = 750;
            _frame_rate = Type.FRAME_RATE;
        }

        #endregion

        #region IScreen Members

        public void Init()
        {
            _player = new Sprite(new Vector2(565, 285),
                new Rectangle(565, 285, 150, 150), 50, 5, 5);
            _item_life = new Sprite(new Vector2(-75, 0),
                new Rectangle(-75, 0, 75, 75), 30, 1, 0);
            _item_power = new Sprite(new Vector2(-75, 0),
                new Rectangle(-75, 0, 75, 75), 30, 1, 0);
            _meteors = new List<Sprite>();
            _shoots = new List<Sprite>();
            _fire = false;
            _gameOver = false;
            _difficult = false;
            _power = false;
            _gameScore = 0;
            _meteor_rate = 0;
            _item_life_rate = 750;
            _item_power_rate = 750;
            _frame_rate = Type.FRAME_RATE;

            LoadContent(_spriteBatch);
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            // TODO: use this.Content to load your game content here
            _spriteBatch = spriteBatch;

            #region Player

            _animation_ship01 = new List<Texture2D>();
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Left01"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Left02"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Left03"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Left04"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Left05"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Center01"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Center02"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Center03"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Center04"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Center05"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Right01"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Right02"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Right03"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Right04"));
            _animation_ship01.Add(_content.Load<Texture2D>("SpaceShip01\\SS_Right05"));
            _player.Animation = _animation_ship01;

            _animation_ship02 = new List<Texture2D>();
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Left01"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Left02"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Left03"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Left04"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Left05"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Center01"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Center02"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Center03"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Center04"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Center05"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Right01"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Right02"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Right03"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Right04"));
            _animation_ship02.Add(_content.Load<Texture2D>("SpaceShip02\\SS_Right05"));

            #endregion

            #region Meteor

            _animation_meteor = new List<Texture2D>();
            _animation_meteor.Add(_content.Load<Texture2D>("Meteor\\Meteor01"));
            _animation_meteor.Add(_content.Load<Texture2D>("Meteor\\Meteor02"));
            _animation_meteor.Add(_content.Load<Texture2D>("Meteor\\Meteor03"));
            _animation_meteor.Add(_content.Load<Texture2D>("Meteor\\Meteor04"));
            _animation_meteor.Add(_content.Load<Texture2D>("Meteor\\Meteor05"));

            #endregion

            #region Shoot

            _animation_shoot = new List<Texture2D>();
            _animation_shoot.Add(_content.Load<Texture2D>("Shoot\\Shoot01"));
            _animation_shoot.Add(_content.Load<Texture2D>("Shoot\\Shoot02"));

            #endregion

            #region Item
            List<Texture2D> animation = new List<Texture2D>();
            animation.Add(_content.Load<Texture2D>("Item\\item_vida"));
            _item_life.Animation = animation;

            animation = new List<Texture2D>();
            animation.Add(_content.Load<Texture2D>("Item\\item_poder"));
            _item_power.Animation = animation;
            #endregion

            #region Font
            _font = _content.Load<SpriteFont>("Font\\impact2");
            #endregion
        }

        public void Update()
        {
            // TODO: Add your update logic here
            _player.Index = 5;

            #region Input

            KeyboardState kbsKeyboard = Keyboard.GetState();

            if ((kbsKeyboard.IsKeyDown(Keys.Escape)) ||
                (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed))
            {
                _gameOver = true;
            }
            if ((kbsKeyboard.IsKeyDown(Keys.Space)) ||
                (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed))
            {
                Fire();
            }
            if ((kbsKeyboard.IsKeyUp(Keys.Space)) || 
                (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Released))
            {
                _fire = false;
            }
            if ((kbsKeyboard.IsKeyDown(Keys.Up)) ||
                (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed))
            {
                _player.Index = 5;
                if (_player.Position.Y > 0)
                {
                    _player.Move(Sprite.Direction.UP);
                }
            }
            if ((kbsKeyboard.IsKeyDown(Keys.Down)) ||
                (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed))
            {
                _player.Index = 5;
                if (_player.Position.Y < 570)
                {
                    _player.Move(Sprite.Direction.Down);
                }
            }
            if ((kbsKeyboard.IsKeyDown(Keys.Left)) ||
                (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed))
            {
                _player.Index = 0;
                if (_player.Position.X > 0)
                {
                    _player.Move(Sprite.Direction.Left);
                }
            }
            if ((kbsKeyboard.IsKeyDown(Keys.Right)) ||
                (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)) 
            {
                _player.Index = 10;
                if (_player.Position.X < 1130)
                {
                    _player.Move(Sprite.Direction.Right);
                }
            }

            #endregion

            GenerateMeteor();
            TestCollision();
            RemoveSprite();
            item();
            difficult();

            if (_player.Dead())
            {
                _gameOver = true;
            }
         }

        public void Draw()
        {
            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (Sprite shoot in _shoots)
            {
                shoot.Move(Sprite.Direction.UP);
                shoot.Draw(_spriteBatch);
            }

            if (_power)
            {
                _player.Animation = _animation_ship02;
                _player.Draw(_spriteBatch);
            }
            else
            {
                _player.Animation = _animation_ship01;
                _player.Draw(_spriteBatch);
            }            

            foreach (Sprite meteor in _meteors)
            {
                meteor.Move(Sprite.Direction.Down);
                meteor.Draw(_spriteBatch);
            }

            if (_item_life.Visible)
            {
                _item_life.Move(Sprite.Direction.Down);
                _item_life.Draw(_spriteBatch);
            }

            if (_item_power.Visible)
            {
                _item_power.Move(Sprite.Direction.Down);
                _item_power.Draw(_spriteBatch);
            }

            _spriteBatch.DrawString(_font, "PONTOS: " + _gameScore.ToString(), new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(_font, "VIDAS: " + _player.Life.ToString(), new Vector2(0, 20), Color.White);

            _spriteBatch.End();
        }

        #endregion

        #region Methods

        private void difficult()
        {
            if ((_difficult) && (_gameScore != 0) && ((_gameScore % 100) == 0))
            {
                // Aumenta a frequencia de meteoros
                /*if (METEOR_RATE >= 1)
                {
                    METEOR_RATE--;
                }*/

                // Aumenta a velocidade dos meteoros
                if (_frame_rate >= 1)
                {
                    _frame_rate--;
                }

                _difficult = false;
            }
        }

        private void item()
        {
            if (!_power)
            {
                if (_item_life_rate >= Type.LIFE_ITEM_RATE)
                {
                    _item_life_rate = 0;
                    _item_life.Visible = true;
                    Random r = new Random();
                    int x = r.Next(0, (1280 - 75));
                    _item_life.Position = new Vector2(x, -75);
                    _item_life.Rectangle = new Rectangle(x, -75, 75, 75);
                }
                else
                {
                    _item_life_rate++;
                }

                if (_item_power_rate >= Type.POWER_ITEM_RATE)
                {
                    _item_power_rate = 0;
                    _item_power.Visible = true;
                    Random r = new Random();
                    int x = r.Next(0, (1280 - 75));
                    _item_power.Position = new Vector2(x, -75);
                    _item_power.Rectangle = new Rectangle(x, -75, 75, 75);
                }
                else
                {
                    _item_power_rate++;
                }
            }
        }

        private void GenerateMeteor()
        {
            if (_meteor_rate >= Type.METEOR_RATE)
            {
                _meteor_rate = 0;

                Random r = new Random();
                int x = r.Next(0, (1280 - 150));
                Sprite meteor = new Sprite(new Vector2(x, -150),
                    new Rectangle(x, -150, 150, 150), 25, 1, 0);
                meteor.Animation = _animation_meteor;
                meteor.Index = r.Next(0, 4);

                _meteors.Add(meteor);
            }
            else
            {
                _meteor_rate++;
            }
        }

        private void RemoveSprite()
        {
            foreach (Sprite meteor in _meteors)
            {
                if (meteor.Dead())
                {
                    _gameScore += 30;
                    _meteors.Remove(meteor);
                    _difficult = true;
                    break;
                }
                else if (meteor.Position.Y >= 720) 
                {
                     _gameScore += 10;
                    _meteors.Remove(meteor);
                    _difficult = true;
                    break;
                }
            }

            foreach (Sprite shoot in _shoots)
            {
                if (shoot.Position.Y <= 0)
                {
                    _shoots.Remove(shoot);
                    break;
                }
            }

            if ((_item_life.Visible) && (_item_life.Position.Y >= 720))
            {
                _item_life.Visible = false;
            }

            if ((_item_power.Visible) && (_item_power.Position.Y >= 720))
            {
                _item_power.Visible = false;
            }
        }

        private void Fire()
        {
            if (!_fire)
            {
                _fire = true;

                int index = 0;
                if (_power)
                {
                    index = 1;
                }               

                Sprite shoot = new Sprite(new Vector2(_player.Position.X + 72, _player.Position.Y + 30),
                    new Rectangle((int)_player.Position.X + 72, (int)_player.Position.Y + 30, 6, 18), 50, 1, index);
                shoot.Animation = _animation_shoot;

                _shoots.Add(shoot);
            }
        }

        private void TestCollision()
        {
            foreach (Sprite meteor in _meteors)
            {
                if (Collision.IntersectPixels(_player.Rectangle, _player.TextureData,
                    meteor.Rectangle, meteor.TextureData))
                {
                    if (_power)
                    {
                        _power = false;
                    }
                    else
                    {
                        _player.Damage();
                    }

                    meteor.Hide(Sprite.Direction.Down);
                    break;
                }
            }

            foreach (Sprite shoot in _shoots)
            {
                foreach (Sprite meteor in _meteors)
                {
                    if (Collision.IntersectPixels(shoot.Rectangle, shoot.TextureData,
                        meteor.Rectangle, meteor.TextureData))
                    {
                        if ((_power) || (meteor.Dead()))
                        {
                            meteor.Hide(Sprite.Direction.Down);
                        }
                        else
                        {
                            meteor.Damage();
                        }

                        shoot.Hide(Sprite.Direction.UP);
                        break;
                    }
                }
            }

            if (_item_life.Visible)
            {
                if (Collision.IntersectPixels(_player.Rectangle, _player.TextureData,
                    _item_life.Rectangle, _item_life.TextureData))
                {
                    _item_life.Visible = false;
                    _player.Life = _player.Life + 1;
                }
            }

            if (_item_power.Visible)
            {
                if (Collision.IntersectPixels(_player.Rectangle, _player.TextureData,
                    _item_power.Rectangle, _item_power.TextureData))
                {
                    _item_power.Visible = false;
                    _power = true;
                }
            }
        }

        #endregion
    }
}
