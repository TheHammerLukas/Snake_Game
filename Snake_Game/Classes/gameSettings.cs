using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    public enum gameDirection // Enum for the current direction of the snake
    {
        Stop = 0,
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4
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
        SnakeNoClip = 4,
        SnakeChangeDir = 5, // Not used because cutting out playing sounds too regularly
        FoodSpawn = 6, // Not used because cutting out eating sounds too completely
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

    class gameSettings
    {
        public static int Width                         { get; set; } // Width of any game object
        public static int Height                        { get; set; } // Height of any game object
        public static int Speed                         { get; set; } // Speed of the snake
        public static int Score                         { get; set; } // Score of the current game
        public static int HighScore                     { get; set; } // Highscore of the player loaded from .xml file
        public static int GrowMultiplicator             { get; set; } // Defines how much the snake grows when a food is eaten
        public static int Points                        { get; set; } // Amount of points that get added to the score when the player eats a food
        public static bool GameOver                     { get; set; } // If false -> game continues, if true -> game ends
        public static bool BotEnabled                   { get; set; } // To enable / disable the bot
        public static bool IsModifierRound              { get; set; } // To determine if any cheats/modifiers were enabled in the current round
        public static bool SpeedEnabled                 { get; set; } // To check if the speed modifier is enabled or disabled
        public static bool GamePaused                   { get; set; } // If false -> game isn't paused, if true -> game is paused
        public static bool DevModeEnabled               { get; set; } // When enabled no checks are made for key input, hence why it's called 'DevMode'
        public static gamePowerup GamePowerup           { get; set; } // To determine the currently enabled powerup
        public static gamePowerup SavedPowerup          { get; set; } // To save the Powerup after the foodPowerup has been eaten
        public static gamePowerup FoodPowerup           { get; set; } // Only used for generating powerup food
        public static bool GamePowerupActive            { get; set; } // Used to determine if the GamePowerup has been activated or is already active
        public static int PowerupSpawnGapConfigured     { get; private set; } // Used to reinitialize the user configured spawn gap; this value is read from the settings .xml
        public static int PowerupSpawnGap               { get; set; } // To set the amount of food that has to be eaten in order for a powerup to spawn
        public static int PowerupDurationX2             { get; set; } // To determine the duration of the X2 powerup
        public static int PowerupDurationPointTick      { get; set; } // To determine the duration of the Point on Tick powerup
        public static int PowerupDurationSlowmo         { get; set; } // To determine the duration of the Slowmotion powerup
        public static int PowerupDurationNoclip         { get; set; } // To determine the duration of the Noclip powerup
        public static bool NoClipEnabled                { get; set; } // To detemrine if the NoClip feature is enabled or disabled
        public static gameDrawingMode DrawingMode       { get; set; } // To determine how the game should be drawn
        public static rainbowMode RainbowMode           { get; set; } // To determine which rainbow mode is selected
        public static bool MenuIsOpen                   { get; set; } // Determines if the gameMenu is open or not
        public static gameDirection directionHead       { get; set; } // Direction the snake is heading in
        public static gameDirection directionTail       { get; set; } // Direction the snake tail is heading
        public static Brush snakeHeadColor              { get; set; } // Color for the head of the snake; set in gameInterface.pictureBox_Paint according to which powerup is active
        public static Brush snakeHeadNormalColor        { get; set; } // Color used for normal snake head
        public static Brush snakeHeadPUpX2Color         { get; set; } // Color used for X2 Powerup snake head
        public static Brush snakeHeadPUpPointTickColor  { get; set; } // Color used for Point on Tick Powerup snake head
        public static Brush snakeHeadPUpSlowmoColor     { get; set; } // Color used for Slowmotion Powerup snake head
        public static Brush snakeHeadPUpNoclipColor     { get; set; } // Color used for Noclip Powerup snake head
        public static Brush snakeBodyColor              { get; set; } // Color for the body of the snake; set in gameInterface.pictureBox_Paint according to which powerup is active
        public static Brush snakeBodyNormalColor        { get; set; } // Color used for normal snake body
        public static Brush snakeBodyPUpX2Color         { get; set; } // Color used for X2 Powerup snake body
        public static Brush snakeBodyPUpPointTickColor  { get; set; } // Color used for Point on Tick Powerup snake body
        public static Brush snakeBodyPUpSlowmoColor     { get; set; } // Color used for Slowmotion Powerup snake body
        public static Brush snakeBodyPUpNoclipColor     { get; set; } // Color used for Noclip Powerup snake body
        public static Brush foodColor                   { get; set; } // Color for the food; gets set in gameInterface.pictureBox_Paint according to which kind of food is spawned
        public static Brush foodNormalColor             { get; set; } // Color used for normal food
        public static Brush foodPUpX2Color              { get; set; } // Color used for X2 Powerup food
        public static Brush foodPUpPointTickColor       { get; set; } // Color used for Point on Tick Powerup food
        public static Brush foodPUpSlowmoColor          { get; set; } // Color used for Slowmotion Powerup food
        public static Brush foodPUpNoclipColor          { get; set; } // Color used for Noclip Powerup food

        // Array for the rainbow colors of the snake
        public static Brush[] snakeRainbowColor = { Brushes.Firebrick, Brushes.OrangeRed, Brushes.Gold, Brushes.LimeGreen, Brushes.Blue, Brushes.Purple };
        
        // Default constructor; called only directly for first init of the application
        public gameSettings(bool useStandard, bool firstInit)
        {
            gameController gamecontroller = new gameController();
            
            Width               = gameConstants.standardWidth;
            Height              = gameConstants.standardHeight;
            Speed               = gameConstants.standardSpeed;
            Score               = gameConstants.standardScore;  
            GrowMultiplicator   = gameConstants.standardGrowMultiplicator;
            Points              = gameConstants.standardPoints;
            GameOver            = false;
            BotEnabled          = false;
            IsModifierRound     = false;
            SpeedEnabled        = false;
            GamePaused          = false;
            MenuIsOpen          = false;
            SavedPowerup        = gameConstants.standardSavedPowerup;
            GamePowerup         = gameConstants.standardGamePowerup;
            GamePowerupActive   = false;
            DrawingMode         = gameConstants.standardDrawingMode;
            directionHead       = gameConstants.standarddirectionHead;

            // Only on first init set the DevMode
            if (firstInit)
            {
                DevModeEnabled = false;
                NoClipEnabled  = false;

                initPowerupSpawnGap(useStandard);
                initAllPowerupDuration();
            }

            // Only call readSettingsXML if the values of it should be used
            if (!useStandard)
            {
                gamecontroller.readSettingsXML();
            }

            if (!DevModeEnabled)
            {
                PowerupSpawnGapConfigured = PowerupSpawnGap;
            }

            gamecontroller.readScoreXML();
        }

        // Overload of constructor; called by any except the first init
        public gameSettings(bool useStandard) : this(useStandard, false)
        {
            return;
        }

        // Procedure to apply new settings values
        public static void ApplySettings(int newWidth, int newHeight, int newSpeed, int newGrowMultiplicator, int newPoints, 
                                         int newPUpSpawnGap, int newPUpX2Duration, int newPUpPointTickDuration, int newPUpSlowmotionDuration, int newPUpNoclipDuration)
        {
            gameController gamecontroller = new gameController();

            int _newPUpX2Duration           = gamecontroller.ConvTime(newPUpX2Duration        , gameConstants.seconds, gameConstants.milliseconds);
            int _newPUpPointTickDuration    = gamecontroller.ConvTime(newPUpPointTickDuration , gameConstants.seconds, gameConstants.milliseconds);
            int _newPUpSlowmotionDuration   = gamecontroller.ConvTime(newPUpSlowmotionDuration, gameConstants.seconds, gameConstants.milliseconds);
            int _newPUpNoclipDuration       = gamecontroller.ConvTime(newPUpNoclipDuration    , gameConstants.seconds, gameConstants.milliseconds);


            // Alter settings if needed
            Width                       = newWidth              != Width 
                                        ? newWidth              :  Width;
            Height                      = newHeight             != Height
                                        ? newHeight             :  Height;
            Speed                       = newSpeed              != Speed
                                        ? newSpeed              :  Speed;
            GrowMultiplicator           = newGrowMultiplicator  != GrowMultiplicator
                                        ? newGrowMultiplicator  :  GrowMultiplicator;
            Points                      = newPoints             != Points
                                        ? newPoints             :  Points;

            // Alter powerup settings if needed
            PowerupSpawnGapConfigured   = newPUpSpawnGap            != PowerupSpawnGap
                                        ? newPUpSpawnGap            :  PowerupSpawnGap;
            PowerupSpawnGap             = PowerupSpawnGapConfigured;

            PowerupDurationX2           = _newPUpX2Duration         != PowerupDurationX2
                                        ? _newPUpX2Duration         :  PowerupDurationX2;
            PowerupDurationPointTick    = _newPUpPointTickDuration  != PowerupDurationPointTick
                                        ? _newPUpPointTickDuration  :  PowerupDurationPointTick;
            PowerupDurationSlowmo       = _newPUpSlowmotionDuration != PowerupDurationSlowmo
                                        ? _newPUpSlowmotionDuration :  PowerupDurationSlowmo;
            PowerupDurationNoclip       = _newPUpNoclipDuration     != PowerupDurationNoclip
                                        ? _newPUpNoclipDuration     :  PowerupDurationNoclip;
            
            gamecontroller.writeSettingsXML();
        }

        #region Powerup functions

        // Initializes the PowerupSpawnGap
        public static void initPowerupSpawnGap(bool useStandard)
        {
            PowerupSpawnGap = gameConstants.standardPowerupSpawnGap;

            // Only call readSettingsXML if the values of it should be used
            if (!useStandard)
            {
                PowerupSpawnGap = PowerupSpawnGapConfigured;
            }
        }

        public static void initAllPowerupDuration()
        {
            foreach (gamePowerup powerup in Enum.GetValues(typeof(gamePowerup)))
            {
                initPowerupDuration(powerup);
            }
        }

        public static void initPowerupDuration(gamePowerup powerup)
        {
            gameController gamecontroller = new gameController();
            gamePowerup _powerup = powerup;

            switch (_powerup)
            {
                case gamePowerup.X2:
                    PowerupDurationX2 = gamecontroller.ConvTime(gameConstants.standardPowerupDurationX2, gameConstants.seconds, gameConstants.milliseconds);
                    break;
                case gamePowerup.PointOnTick:
                    PowerupDurationPointTick = gamecontroller.ConvTime(gameConstants.standardPowerupDurationPointTick, gameConstants.seconds, gameConstants.milliseconds);
                    break;
                case gamePowerup.Slowmotion:
                    PowerupDurationSlowmo = gamecontroller.ConvTime(gameConstants.standardPowerupDurationSlowmotion, gameConstants.seconds, gameConstants.milliseconds);
                    break;
                case gamePowerup.Noclip:
                    PowerupDurationNoclip = gamecontroller.ConvTime(gameConstants.standardPowerupDurationNoclip, gameConstants.seconds, gameConstants.milliseconds);
                    break;
                case gamePowerup.None:
                    break;
                default:
                    MessageBox.Show(
                                "Invalid gamePowerup duration tried to be initialized in \ngameSettings.initPowerupDuration procedure!\npowerup=" + _powerup,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                    break;

            }
        }

        #endregion

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
                case gameColor.snakeHeadNormalColor:
                    _colorDialog.Color = (snakeHeadNormalColor as SolidBrush).Color;
                    break;
                case gameColor.snakeBodyNormalColor:
                    _colorDialog.Color = (snakeBodyNormalColor as SolidBrush).Color;
                    break;
                case gameColor.foodNormalColor:
                    _colorDialog.Color = (foodNormalColor as SolidBrush).Color;
                    break;
                case gameColor.snakeHeadPUpX2Color:
                    _colorDialog.Color = (snakeHeadPUpX2Color as SolidBrush).Color;
                    break;
                case gameColor.snakeHeadPUpPointTickColor:
                    _colorDialog.Color = (snakeHeadPUpPointTickColor as SolidBrush).Color;
                    break;
                case gameColor.snakeHeadPUpSlowmoColor:
                    _colorDialog.Color = (snakeHeadPUpSlowmoColor as SolidBrush).Color;
                    break;
                case gameColor.snakeHeadPUpNoclipColor:
                    _colorDialog.Color = (snakeHeadPUpNoclipColor as SolidBrush).Color;
                    break;
                case gameColor.snakeBodyPUpX2Color:
                    _colorDialog.Color = (snakeBodyPUpX2Color as SolidBrush).Color;
                    break;
                case gameColor.snakeBodyPUpPointTickColor:
                    _colorDialog.Color = (snakeBodyPUpPointTickColor as SolidBrush).Color;
                    break;
                case gameColor.snakeBodyPUpSlowmoColor:
                    _colorDialog.Color = (snakeBodyPUpSlowmoColor as SolidBrush).Color;
                    break;
                case gameColor.snakeBodyPUpNoclipColor:
                    _colorDialog.Color = (snakeBodyPUpNoclipColor as SolidBrush).Color;
                    break;
                case gameColor.foodPUpX2Color:
                    _colorDialog.Color = (foodPUpX2Color as SolidBrush).Color;
                    break;
                case gameColor.foodPUpPointTickColor:
                    _colorDialog.Color = (foodPUpPointTickColor as SolidBrush).Color;
                    break;
                case gameColor.foodPUpSlowmoColor:
                    _colorDialog.Color = (foodPUpSlowmoColor as SolidBrush).Color;
                    break;
                case gameColor.foodPUpNoclipColor:
                    _colorDialog.Color = (foodPUpNoclipColor as SolidBrush).Color;
                    break;
                default:
                    break;
            }
            
            // Update the color of the setting
            if (_colorDialog.ShowDialog() == DialogResult.OK)
            {
                switch (colorToChange)
                {
                    case gameColor.snakeHeadNormalColor:
                        snakeHeadNormalColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeBodyNormalColor:
                        snakeBodyNormalColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.foodNormalColor:
                        foodNormalColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeHeadPUpX2Color:
                        snakeHeadPUpX2Color = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeHeadPUpPointTickColor:
                        snakeHeadPUpPointTickColor = new SolidBrush(_colorDialog.Color);;
                        break;
                    case gameColor.snakeHeadPUpSlowmoColor:
                        snakeHeadPUpSlowmoColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeHeadPUpNoclipColor:
                        snakeHeadPUpNoclipColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeBodyPUpX2Color:
                        snakeBodyPUpX2Color = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeBodyPUpPointTickColor:
                        snakeBodyPUpPointTickColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeBodyPUpSlowmoColor:
                        snakeBodyPUpSlowmoColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.snakeBodyPUpNoclipColor:
                        snakeBodyPUpNoclipColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.foodPUpX2Color:
                        foodPUpX2Color = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.foodPUpPointTickColor:
                        foodPUpPointTickColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.foodPUpSlowmoColor:
                        foodPUpSlowmoColor = new SolidBrush(_colorDialog.Color);
                        break;
                    case gameColor.foodPUpNoclipColor:
                        foodPUpNoclipColor = new SolidBrush(_colorDialog.Color);
                        break;
                    default:
                        break;
                }
            }
        }

        // Calls initialize functions for colors
        public static void initAllColors()
        {
            
            foreach (gameColor color in Enum.GetValues(typeof(gameColor)))
            {
                initSnakeHeadColor(color);
                initSnakeBodyColor(color);
                initFoodColor(color);
            }
            
            DrawingMode = gameDrawingMode.drawingModeNormal;
            RainbowMode = rainbowMode.rainbowModeTiles;
        }

        public static void initSnakeHeadColor(gameColor color)
        {
            gameColor _color = color;

            if (_color < gameColor.snakeHeadNormalColor || _color > gameColor.snakeHeadPUpNoclipColor)
            {
                _color = gameColor.none;
            }
            switch (_color)
            {
                case gameColor.snakeHeadNormalColor:
                    snakeHeadNormalColor       = Brushes.DarkGreen;
                    break;
                case gameColor.snakeHeadPUpX2Color:
                    snakeHeadPUpX2Color        = Brushes.LawnGreen;
                    break;
                case gameColor.snakeHeadPUpPointTickColor:
                    snakeHeadPUpPointTickColor = Brushes.Goldenrod;
                    break;
                case gameColor.snakeHeadPUpSlowmoColor:
                    snakeHeadPUpSlowmoColor    = Brushes.MediumTurquoise;
                    break;
                case gameColor.snakeHeadPUpNoclipColor:
                    snakeHeadPUpNoclipColor    = Brushes.DarkMagenta;
                    break;
                case gameColor.none:
                    break;
                default:
                    MessageBox.Show(
                                "Invalid snakeHead color tried to be initialized in \ngameSettings.InitSnakeHeadColor procedure!\ncolor=" + _color,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                    break;
            }
        }

        public static void initSnakeBodyColor(gameColor color)
        {
            gameColor _color = color;

            if (_color < gameColor.snakeBodyNormalColor || _color > gameColor.snakeBodyPUpNoclipColor)
            {
                _color = gameColor.none;
            }
            switch (_color)
            {
                case gameColor.snakeBodyNormalColor:
                    snakeBodyNormalColor       = Brushes.Green;
                    break;
                case gameColor.snakeBodyPUpX2Color:
                    snakeBodyPUpX2Color        = Brushes.GreenYellow;
                    break;
                case gameColor.snakeBodyPUpPointTickColor:
                    snakeBodyPUpPointTickColor = Brushes.Yellow;
                    break;
                case gameColor.snakeBodyPUpSlowmoColor:
                    snakeBodyPUpSlowmoColor    = Brushes.Aqua;
                    break;
                case gameColor.snakeBodyPUpNoclipColor:
                    snakeBodyPUpNoclipColor    = Brushes.DarkOrchid;
                    break;
                case gameColor.none:
                    break;
                default:
                    MessageBox.Show(
                                "Invalid snakeBody color tried to be initialized in \ngameSettings.InitSnakeHeadColor procedure!\ncolor=" + _color,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                    break;
            }
        }

        public static void initFoodColor(gameColor color)
        { 
            gameColor _color = color;

            if (_color < gameColor.foodNormalColor || _color > gameColor.foodPUpNoclipColor)
            {
                _color = gameColor.none;
            }
            switch (_color)
            {
                case gameColor.foodNormalColor:
                    foodNormalColor       = Brushes.Red;
                    break;
                case gameColor.foodPUpX2Color:
                    foodPUpX2Color        = Brushes.Lime;
                    break;
                case gameColor.foodPUpPointTickColor:
                    foodPUpPointTickColor = Brushes.Gold;
                    break;
                case gameColor.foodPUpSlowmoColor:
                    foodPUpSlowmoColor    = Brushes.Turquoise;
                    break;
                case gameColor.foodPUpNoclipColor:
                    foodPUpNoclipColor    = Brushes.BlueViolet;
                    break;
                case gameColor.none:
                    break;
                default:
                    MessageBox.Show(
                                "Invalid food color tried to be initialized in \ngameSettings.InitFoodColor procedure!\ncolor=" + _color,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                    break;
            }
        }

        #endregion
    }
}
