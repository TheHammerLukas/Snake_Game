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
        public const int standardSpeed = 7;
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
        public const int standardPowerupDurationX2PointTick = 20;
        public const int standardPowerupDurationX2Slowmotion = 10;
        public const int standardPowerupDurationX2Noclip = 20;
        public const int standardPowerupDurationPointTickSlowmotion = 10;
        public const int standardPowerupDurationPointTickNoclip = 20;
        public const int standardPowerupDurationSlowmotionNoclip = 10;
        public const gameDrawingMode standardDrawingMode = gameDrawingMode.drawingModeNormal;
        public const gameDirection standardDirectionHead = gameDirection.Stop;

        // Savefile constants
        public const string settingsXML = "SETTINGS";
        public const string controlsXML = "CONTROLS";
        public const string scoreXML = "SCORE";
        public const string gameSprites = "SPRITES";
        public const string gameSpritesPUpX2 = "SPRITESX2";
        public const string gameSpritesPUpPointTick = "SPRITESPOINTTICK";
        public const string gameSpritesPUpSlowmotion = "SPRITESSLOWMOTION";
        public const string gameSpritesPUpNoclip = "SPRITESNOCLIP";

        // User Interface constants
        public enum gameSound // Enum for different sounds
        {
            None = 0,
            SnakeEat = 1,
            PowerupEat = 2,
            SnakeDie = 3,
            SnakeNoClip = 4,
            SnakeChangeDir = 5, // Not used because cutting out playing sounds too regularly
            FoodSpawn = 6, // Not used because cutting out eating sounds completely
            PUpX2Activate = 7,
            PUpX2Deactivate = 8,
            PUpPointTickActivate = 9,
            PUpPointTickDeactivate = 10,
            PUpSlowmoActivate = 11,
            PUpSlowmoDeactivate = 12,
            PUpNoclipActivate = 13,
            PUpNoclipDeactivate = 14,
            ApplicationStartup = 15
        }

        public enum gameAction // Enum for key input actions
        {
            None = 0,
            UpKey = 1,
            DownKey = 2,
            LeftKey = 3,
            RightKey = 4,
            ResetKey = 5,
            PauseKey = 6,
            SpeedKey = 7,
            BotKey = 8,
            DevModeKey = 9,
            PowerupKey = 10,
            NoClipKey = 11,
            ReloadSpritesKey = 12
        };

        public enum gameColor // Enum for colors used in game
        {
            none = 0,
            snakeHeadNormalColor = 1,
            snakeHeadPUpX2Color = 2,
            snakeHeadPUpPointTickColor = 3,
            snakeHeadPUpSlowmoColor = 4,
            snakeHeadPUpNoclipColor = 5,
            snakeBodyNormalColor = 6,
            snakeBodyPUpX2Color = 7,
            snakeBodyPUpPointTickColor = 8,
            snakeBodyPUpSlowmoColor = 9,
            snakeBodyPUpNoclipColor = 10,
            foodNormalColor = 11,
            foodPUpX2Color = 12,
            foodPUpPointTickColor = 13,
            foodPUpSlowmoColor = 14,
            foodPUpNoclipColor = 15
        }

        public enum gameDrawingMode // Enum for different modes to draw the game
        {
            drawingModeNormal = 0,
            drawingModeRainbow = 1,
            drawingModeSprite = 2
        }

        public enum rainbowMode // Enum for different rainbow modes
        {
            rainbowModeTiles = 0,
            rainbowModeStretched = 1
        }
    }
}
