using System.Collections.Generic;

namespace Snake_Game
{
    class gameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static List<gameObject> Snake = new List<gameObject>();
        public static gameObject Food = new gameObject();

        public gameObject()
        {
            X = 0;
            Y = 0;
            gameSettings.GenPowerup = gamePowerup.None;
        }
    }
}
