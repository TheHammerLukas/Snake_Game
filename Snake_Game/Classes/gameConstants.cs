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
        public const int standardPowerupDurationX2 = 30; // seconds
        public const int standardPowerupDurationPointTick = 20; // seconds
        public const int standardPowerupDurationSlowmotion = 10; // seconds
        public const int standardPowerupDurationNoclip = 15; // seconds
        public const int standardPowerupDurationX2PointTick = 20; // seconds
        public const int standardPowerupDurationX2Slowmotion = 10; // seconds
        public const int standardPowerupDurationX2Noclip = 20; // seconds
        public const int standardPowerupDurationPointTickSlowmotion = 10; // seconds
        public const int standardPowerupDurationPointTickNoclip = 20; // seconds
        public const int standardPowerupDurationSlowmotionNoclip = 10; // seconds
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
        public const string gameSpritesPUpX2PointTick = "SPRITESX2POINTTICK";
        public const string gameSpritesPUpX2Slowmotion = "SPRITESX2SLOWMOTION";
        public const string gameSpritesPUpX2Noclip = "SPRITESX2NOCLIP";
        public const string gameSpritesPUpPointTickSlowmotion = "SPRITESPOINTTICKSLOWMOTION";
        public const string gameSpritesPUpPointTickNoclip = "SPRITESPOINTTICKNOCLIP";
        public const string gameSpritesPUpSlowmotionNoclip = "SPRITESSLOWMOTIONNOCLIP";

        // User Interface constants
        public enum gameSound // Enum for different sounds
        {
            None,
            SnakeEat,
            PowerupEat,
            SnakeDie,
            NewHighscore,
            SnakeNoClip,
            SnakeChangeDir, // Not used because cutting out playing sounds too regularly
            FoodSpawn, // Not used because cutting out eating sounds completely
            PUpX2Activate,
            PUpX2Deactivate,
            PUpPointTickActivate,
            PUpPointTickDeactivate,
            PUpSlowmoActivate,
            PUpSlowmoDeactivate,
            PUpNoclipActivate,
            PUpNoclipDeactivate,
            PUpX2PointTickSynergy,
            PUpX2PointTickDeactivate,
            PUpX2SlowmoSynergy,
            PUpX2SlowmoDeactivate,
            PUpX2NoclipSynergy,
            PUpX2NoclipDeactivate,
            PUpPointTickSlowmoSynergy,
            PUpPointTickSlowmoDeactivate,
            PUpPointTickNoclipSynergy,
            PUpPointTickNoclipDeactivate,
            PUpSlowmoNoclipSynergy,
            PUpSlowmoNoclipDeactivate,
            ApplicationStartup
        }

        public enum gameAction // Enum for key input actions
        {
            None,
            UpKey,
            DownKey,
            LeftKey,
            RightKey,
            ResetKey,
            PauseKey,
            SpeedKey,
            BotKey,
            DevModeKey,
            PowerupKey,
            NoClipKey,
            ReloadSpritesKey,
            GrowSnakeKey,
            ShrinkSnakeKey,
            LoadDevSettingsKey
        };

        public enum gameColor // Enum for colors used in game
        {
            none,
            snakeHeadNormalColor,
            snakeHeadPUpX2Color,
            snakeHeadPUpPointTickColor,
            snakeHeadPUpSlowmoColor,
            snakeHeadPUpNoclipColor,
            snakeBodyNormalColor,
            snakeBodyPUpX2Color,
            snakeBodyPUpPointTickColor,
            snakeBodyPUpSlowmoColor,
            snakeBodyPUpNoclipColor,
            foodNormalColor,
            foodPUpX2Color,
            foodPUpPointTickColor,
            foodPUpSlowmoColor,
            foodPUpNoclipColor
        }

        public enum gameDrawingMode // Enum for different modes to draw the game
        {
            drawingModeNormal,
            drawingModeRainbow,
            drawingModeSprite
        }

        public enum rainbowMode // Enum for different rainbow modes
        {
            rainbowModeTiles,
            rainbowModeStretched
        }
    }
}
