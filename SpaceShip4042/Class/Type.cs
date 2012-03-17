using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceShip4042
{
    public class Type
    {
        public enum Menu
        {
            Menu = 0,
            Jogar = 1,
            Ranking = 2, 
            Creditos = 3,
            Sair = 4,
            GameOver = 5
        }

        public const int DELAY = 30;

        public const string HighScoresFilename = "highscores.lst";

        public const int FRAME_RATE = 100;

        public const int METEOR_RATE = 5;

        public const int LIFE_ITEM_RATE = 1250;

        public const int POWER_ITEM_RATE = 1000;
    }
}
