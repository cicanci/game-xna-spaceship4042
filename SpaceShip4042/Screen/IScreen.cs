using Microsoft.Xna.Framework.Graphics;

namespace SpaceShip4042.Screen
{
    interface IScreen
    {
        void LoadContent(SpriteBatch spriteBatch);
        void Update();
        void Draw();
        void Init();
    }
}
