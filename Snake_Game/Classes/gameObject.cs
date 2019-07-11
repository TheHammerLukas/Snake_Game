using System.Collections.Generic;

namespace Snake_Game
{
    class gameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static List<gameObject> Snake = new List<gameObject>();
        public static gameObject Food = new gameObject(true);

        public gameObject(bool newFood)
        {
            X = 0;
            Y = 0;

            if (newFood)
            {
                gameSettings.FoodPowerup = gamePowerup.None;
            }
        }
    }
}
