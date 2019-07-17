using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    public enum gameDirection // Enum for the current direction of the snake
    {
        Up = 0,
        Down= 1,
        Left = 2,
        Right = 3,
        Stop = 4
    };

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
        NoClipKey = 11
    };

    public enum gameColor // Enum for colors used in game
    {
        snakeHeadColor = 0,
        snakeBodyColor = 1,
        foodColor = 2
    }

    public enum rainbowMode // Enum for different rainbow modes
    {
        rainbowModeTiles = 0,
        rainbowModeStretched = 1
    }

    public enum gamePowerup // Enum for different powerups
    {
        None = 0,
        X2 = 1,
        PointOnTick = 2,
        Slowmotion = 3,
        Noclip = 4
    }

    public enum gameSound // Enum for different sounds
    {
        None = 0,
        SnakeEat = 1,
        PowerupEat = 2,
        SnakeDie = 3,
        SnakeChangeDir = 4,
        FoodSpawn = 5,
        PUX2Activate = 6,
        PUpX2Deactivate = 7,
        PUpPointTickActivate = 8,
        PUpPointTickDeactivate = 9,
        PUpSlowmoActivate = 10,
        PUpSlowmoDeactivate = 11,
        PUpNoclipActivate = 12,
        PUpNoclipDeactivate = 13
    }

    class gameSettings
    {
        public static int Width                 { get; set; } // Width of any game object
        public static int Height                { get; set; } // Height of any game object
        public static int Speed                 { get; set; } // Speed of the snake
        public static int Score                 { get; set; } // Score of the current game
        public static int HighScore             { get; set; } // Highscore of the player loaded from .xml file
        public static int GrowMultiplicator     { get; set; } // Defines how much the snake grows when a food is eaten
        public static int Points                { get; set; } // Amount of points that get added to the score when the player eats a food
        public static bool GameOver             { get; set; } // If false -> game continues, if true -> game ends
        public static bool BotEnabled           { get; set; } // To enable / disable the bot
        public static bool IsModifierRound      { get; set; } // To determine if any cheats/modifiers were enabled in the current round
        public static bool SpeedEnabled         { get; set; } // To check if the speed modifier is enabled or disabled
        public static bool GamePaused           { get; set; } // If false -> game isn't paused, if true -> game is paused
        public static bool DevModeEnabled       { get; set; } // When enabled no checks are made for key input, hence why it's called 'DevMode'
        public static gamePowerup GamePowerup   { get; set; } // To determine the currently enabled powerup
        public static gamePowerup SavedPowerup  { get; set; } // To save the Powerup after the foodPowerup has been eaten
        public static gamePowerup FoodPowerup   { get; set; } // Only used for generating powerup food
        public static bool GamePowerupActive    { get; set; } // Used to determine if the GamePowerup has been activated or is already active
        public static int PowerupSpawnGap       { get; set; } // To set the amount of food that has to be eaten in order for a powerup to spawn
        public static bool NoClipEnabled        { get; set; } // To detemrine if the NoClip feature is enabled or disabled
        public static bool RainbowEnabled       { get; set; } // To enable / disable the rainbow snake color
        public static rainbowMode RainbowMode   { get; set; } // To determine which rainbow mode is selected
        public static bool MenuIsOpen           { get; set; } // Determines if the gameMenu is open or not
        public static gameDirection direction   { get; set; } // Direction the snake is heading in
        public static Brush snakeHeadColor      { get; set; } // Color for the head of the snake
        public static Brush snakeBodyColor      { get; set; } // Color for the body of the snake
        public static Brush foodColor           { get; set; } // Color for the food

        // Array for the rainbow colors of the snake
        public static Brush[] snakeRainbowColor = { Brushes.Firebrick, Brushes.OrangeRed, Brushes.Gold, Brushes.LimeGreen, Brushes.Blue, Brushes.Purple };
        
        // Default constructor; called only directly for first init of the application
        public gameSettings(bool useStandard, bool firstInit)
        {
            gameController gamecontroller = new gameController();
            
            Width               = 15;
            Height              = 15;
            Speed               = 12;
            Score               = 0;  
            GrowMultiplicator   = 5;
            Points              = 100;
            GameOver            = false;
            BotEnabled          = false;
            IsModifierRound     = false;
            SpeedEnabled        = false;
            GamePaused          = false;
            MenuIsOpen          = false;
            SavedPowerup        = gamePowerup.None;
            direction           = gameDirection.Stop;

            initPowerupSpawnGap(useStandard);

            // Only on first init set the DevMode
            if (firstInit)
            {
                DevModeEnabled = false;
                NoClipEnabled  = false;
            }

            // Only call readSettingsXML if the values of it should be used
            if (!useStandard)
            {
                gamecontroller.readSettingsXML();
            }
            
            gamecontroller.readScoreXML();
        }

        // Overload of constructor; called by any except the first init
        public gameSettings(bool useStandard) : this(useStandard, false)
        {
            return;
        }

        // Initializes the PowerupSpawnGap
        public static void initPowerupSpawnGap(bool useStandard)
        {
            PowerupSpawnGap = 5;
            GamePowerup = gamePowerup.None;
            GamePowerupActive = false;

            // Only call readSettingsXML if the values of it should be used
            if (!useStandard)
            {
                new gameController().readSettingsXML();
            }
        }

        // Procedure to apply new settings values
        public static void ApplySettings(int newWidth, int newHeight, int newSpeed, int newGrowMultiplicator, int newPoints)
        {
            gameController gamecontroller = new gameController();
            
            // Alter settings if needed
            if (newWidth != Width)
            {
                Width = newWidth;
            }
            if (newHeight != Height)
            {
                Height = newHeight;
            }
            if (newSpeed != Speed)
            {
                Speed = newSpeed;
            }
            if (newGrowMultiplicator != GrowMultiplicator)
            {
                GrowMultiplicator = newGrowMultiplicator;
            }
            if (newPoints != Points)
            {
                Points = newPoints;
            }

            gamecontroller.writeSettingsXML();
            gamecontroller.writeControlsXML();
        }

        #region Color functions

        // Sets the passed colorToChange to the picked color
        public static void PickColor(gameColor colorToChange)
        {
            ColorDialog _colorDialog = new ColorDialog();

            _colorDialog.AllowFullOpen = true;
            _colorDialog.ShowHelp = true;

            // Set the initial color to the one currently in use by the setting
            switch (colorToChange)
            {
                case gameColor.snakeHeadColor:
                    _colorDialog.Color = (snakeHeadColor as SolidBrush).Color;
                    break;
                case gameColor.snakeBodyColor:
                    _colorDialog.Color = (snakeBodyColor as SolidBrush).Color;
                    break;
                default:
                    break;
            }
            
            // Update the color of the setting
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                switch (colorToChange)
                {
                    case gameColor.snakeHeadColor:
                        snakeHeadColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeBodyColor:
                        snakeBodyColor = new SolidBrush(_colorDialog.Color);
                        break;
                    default:
                        break;
                }
            }
        }

        // Calls initialize functions for colors
        public static void InitAllColors()
        {
            InitSnakeHeadColor();
            InitSnakeBodyColor();
            InitFoodColor();

            RainbowEnabled = false;
            RainbowMode = rainbowMode.rainbowModeTiles;
        }

        public static void InitSnakeHeadColor()
        {
            snakeHeadColor = Brushes.DarkGreen;
        }

        public static void InitSnakeBodyColor()
        {
            snakeBodyColor = Brushes.Green;
        }

        public static void InitFoodColor()
        {
            foodColor = Brushes.Red;
        }

        #endregion
    }
}
