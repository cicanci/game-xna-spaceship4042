using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShip4042.Class
{
    public class Sprite
    {
        #region Properties

        private bool _visible;
        private Color[] _textureData;
        private int _index, _move, _frame, _aux, _life;
        private Rectangle _rectangle;
        private List<Texture2D> _animation;
        private Vector2 _position;

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public Color[] TextureData
        {
            get { return _textureData; }
            set { _textureData = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public List<Texture2D> Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public enum Direction
        {
            UP,
            Down,
            Left,
            Right
        }

        #endregion

        #region Methods

        public Sprite(Vector2 position, Rectangle rectangle, int move, int frame, int index)
        {
            _animation = new List<Texture2D>();
            _position = position;
            _rectangle = rectangle;
            _move = move;
            _index = index;
            _aux = 0;
            _frame = frame;
            _life = 3;
            _visible = false;
        }

        /// <summary>
        /// Draw a Sprite.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation[_index + _aux], _position, Color.White);

            _textureData = new Color[_animation[_index + _aux].Width * _animation[_index + _aux].Height];
            _animation[_index + _aux].GetData(_textureData);

            if (_aux >= (_frame - 1))
            {
                _aux = 0;
            }
            else
            {
                _aux++;
            }
        }

        /// <summary>
        /// Move a Sprite.
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    _position.Y -= _move;
                    _rectangle.Y = (int)_position.Y;
                    break;
                case Direction.Down:
                    _position.Y += _move;
                    _rectangle.Y = (int)_position.Y;
                    break;
                case Direction.Left:
                    _position.X -= _move;
                    _rectangle.X = (int)_position.X;
                    break;
                case Direction.Right:
                    _position.X += _move;
                    _rectangle.X = (int)_position.X;
                    break;
                default:
                    break;
            }          
        }

        public void Hide(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    _position.Y = -1000;
                    _rectangle.Y = -1000;
                    break;
                case Direction.Down:
                    _position.Y = 1000;
                    _rectangle.Y = 1000;
                    break;
                default:
                    break;
            }
        }

        public void Damage()
        {
            _life--;
        }

        public bool Dead()
        {
            if (_life <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
