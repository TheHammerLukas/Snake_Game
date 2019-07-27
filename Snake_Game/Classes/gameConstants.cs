namespace Snake_Game
{
    static class gameConstants
    {
        // Time constants
        public const string gameTime = "GT";
        public const string gameSpeed = "GS";
        public const string milliseconds = "MS";
        public const string seconds = "S";
        public const string minutes = "M";

        // Key constants
        public const int keyInputDelay = 1000; // 1000 = 1 second

        // Settings constants
        public const int standardWidth = 20;
        public const int standardHeight = 20;
        public const int standardSpeed = 8;
        public const int standardScore = 0;  
        public const int standardGrowMultiplicator = 5;
        public const int standardPoints = 100;
        public const int standardPowerupSpawnGap = 5;
        public const gamePowerup standardSavedPowerup = gamePowerup.None;
        public const gamePowerup standardGamePowerup = gamePowerup.None;
        public const int standardPowerupDurationX2 = 30;
        public const int standardPowerupDurationPointTick = 20;
        public const int standardPowerupDurationSlowmotion = 10;
        public const int standardPowerupDurationNoclip = 15;
        public const gameDrawingMode standardDrawingMode = gameDrawingMode.drawingModeNormal;
        public const gameDirection standarddirectionHead = gameDirection.Stop;
    }
}
