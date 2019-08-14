using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class gameInterface : Form
    {
        gameMenu gamemenu; // Needed here so the menu only opens once
        gameController gamecontroller;

        private bool setInputForNextTick = false; // To improve the direction input
        private gameDirection nextTickDirection = gameDirection.Stop; // To improve the direction input
        private long lastBotChangeTime = 0; // To prevent buggy behaviour when enabling or disabling the bot
        private long lastSpeedChangeTime = 0; // To prevent buggy behaviour when enabling or disabling the speed up
        private long lastPauseChangeTime = 0; // To prevent buggy behaviour when pausing or unpausing the game
        private long lastDevModeChangeTime = 0; // To prevent buggy behaviour when enabling or disabling the devmode
        private long lastNoClipChangeTime = 0; // To prevent buggy behaviour when enabling or disabling the noclip
        private long lastPUpX2ChangeTime = 0; // Powerup: To keep track of Multiplier duration
        private long lastPUpPointTickChangeTime = 0; // Powerup: To keep track of Point Tick duration
        private long lastPUpSlowmoChangeTime = 0; // Powerup: To keep track of Slowmo duration
        private long lastPUpNoclipChangeTime = 0; // Powerup: To keep track of Noclip duration
        private long lastPUpX2PointTickChangeTime = 0; // Powerup: To keep track of X2/Point Tick duration
        private long lastPUpX2SlowmoChangeTime = 0; // Powerup: To keep track of X2/Slowmo duration
        private long lastPUpX2NoclipChangeTime = 0; // Powerup: To keep track of X2/Noclip duration
        private long lastPUpPointTickSlowmoChangeTime = 0; // Powerup: To keep track of Point Tick/Slowmo duration
        private long lastPUpPointTickNoclipChangeTime = 0; // Powerup: To keep track of Point Tick/Noclip duration
        private long lastPUpSlowmoNoclipChangeTime = 0; // Powerup: To keep track of Slowmo/Noclip duration
        private long currentTime = 0; // Current time; 1000 = 1 second 
        private gameDirection currentTickDir; // The direction the snake is heading at in the current game tick
        public static Image gameSprite; // Normal gameSprite 
        public static Image gameSpritePUpX2; // gameSprite used for 'X2' powerup
        public static Image gameSpritePUpPointTick; // gameSprite used for 'Point on Tick' powerup
        public static Image gameSpritePUpSlowmotion; // gameSprite used for 'Slowmotion' powerup
        public static Image gameSpritePUpNoclip; // gameSprite used for 'Noclip' powerup
        public static Image gameSpritePUpX2PointTick; // gameSprite used for 'X2 Point on Tick' powerup synergy
        public static Image gameSpritePUpX2Slowmotion; // gameSprite used for 'X2 Slowmotion' powerup synergy
        public static Image gameSpritePUpX2Noclip; // gameSprite used for 'X2 Noclip' powerup synergy
        public static Image gameSpritePUpPointTickSlowmotion; // gameSprite used for 'Point on Tick Slowmotion' powerup synergy
        public static Image gameSpritePUpPointTickNoclip; // gameSprite used for 'Point on Tick Noclip' powerup synergy
        public static Image gameSpritePUpSlowmotionNoclip; // gameSprite used for 'Slowmotion Noclip' powerup synergy

        public gameInterface()
        {
            InitializeComponent();

            // Set settings to default
            gameSettings.initAllColors();
            gameSettings gamesettings = new gameSettings(false, true);
            gameControls gamecontrols = new gameControls(false);
            gamecontroller = new gameController();
            gamecontroller.writeSettingsXML(); // Rewrite the settings .xml
            gamecontroller.writeControlsXML(); // Rewrite the controls .xml

            gameSettings.initGameSprites();
            gamecontroller.SaveLoadAllSprites();

            // Set game speed and start timer
            gamecontroller.SetTimerInterval(gameTimer, gameSettings.Speed, true);
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            // Start the timer for each second
            currentTime = 0;
            milliSecondTimer.Start();

            gameController.maxPosX = gamecontroller.GetMaxPosX(pictureBox);
            gameController.maxPosY = gamecontroller.GetMaxPosY(pictureBox);
            gamecontroller.SetScore(labelScoreValue);
            gamecontroller.SetPowerup(labelCurrentPowerupValue, labelSavedPowerupValue, labelPowerupTimerValue, currentTime, 0);
            gamecontroller.StartGame();
            gamecontroller.SetHighScore(labelHighscoreValue);
            gamecontroller.GenerateFood();
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            currentTickDir = gameSettings.directionHead;
            FormCollection _openForms = Application.OpenForms;
            bool _menuOpenOnLastCheck = gameSettings.MenuIsOpen; // To check if the game has to be unpause because the menu isn't open anymore

            // Pause the game if the menu form is open
            gameSettings.MenuIsOpen = false;

            foreach (Form form in _openForms)
            {
                if (form.Name == "gameMenu")
                {
                    gameSettings.MenuIsOpen = true;
                    break;
                }
            }
            
            if (gameSettings.MenuIsOpen)
            {
                gameSettings.GamePaused = true;
            }
            else if (_menuOpenOnLastCheck)
            {
                gameSettings.GamePaused = false;
            }

            // Check for game over & if the configured restart key is pressed
            if (!gameSettings.GameOver) // Check for player input
            { 
                // To allow the player to pause the game
                if (!gameSettings.GamePaused)
                {
                    gamecontroller.MovePlayer();
                    gamecontroller.SetScore(labelScoreValue);
                }
            }
            
            pictureBox.Invalidate();
        }

        private void CheckActivePowerup(gamePowerup Powerup)
        {
            long _lastChangeTime = 0;

            if (Powerup == gamePowerup.X2)
            {
                if (lastPUpX2ChangeTime >= currentTime - gameSettings.PowerupDurationX2)
                {
                    gameSettings.GamePowerupActive = true;
                    _lastChangeTime = lastPUpX2ChangeTime;
                }
                else
                {
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2Deactivate);
                }
            }
            if (Powerup == gamePowerup.PointOnTick)
            {
                if (lastPUpPointTickChangeTime >= currentTime - gameSettings.PowerupDurationPointTick)
                {
                    gameSettings.Score = gameSettings.Score + 50;
                    gameSettings.GamePowerupActive = true;
                    _lastChangeTime = lastPUpPointTickChangeTime;
                }
                else
                {
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpPointTickDeactivate);
                }
            }
            if (Powerup == gamePowerup.Slowmotion)
            {
                if (lastPUpSlowmoChangeTime >= currentTime - gameSettings.PowerupDurationSlowmo)
                {
                    if (!gameSettings.GamePowerupActive)
                    {
                        // Slow down the gameTimer
                        new gameController().SetTimerInterval(gameTimer, gameSettings.Speed / 3, true);
                        gameSettings.GamePowerupActive = true;
                    }
                    _lastChangeTime = lastPUpSlowmoChangeTime;
                }
                else
                {
                    // Reset the gameTimer interval to the originally determined speed 
                    new gameController().SetTimerInterval(gameTimer, gameSettings.Speed, true);
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpSlowmoDeactivate);
                }
            }
            if (Powerup == gamePowerup.Noclip)
            {
                if (lastPUpNoclipChangeTime >= currentTime - gameSettings.PowerupDurationNoclip)
                {
                    gameSettings.GamePowerupActive = true;
                    _lastChangeTime = lastPUpNoclipChangeTime;
                }
                else
                {
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpNoclipDeactivate);
                }
            }
            if (Powerup == gamePowerup.X2PointOnTick)
            {
                if (lastPUpX2PointTickChangeTime >= currentTime - gameSettings.PowerupDurationX2PointTick)
                {
                    gameSettings.Score = gameSettings.Score + 50;
                    gameSettings.GamePowerupActive = true;
                    _lastChangeTime = lastPUpX2PointTickChangeTime;
                }
                else
                {
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2PointTickDeactivate);
                }
            }
            if (Powerup == gamePowerup.X2Slowmotion)
            {
                if (lastPUpX2SlowmoChangeTime >= currentTime - gameSettings.PowerupDurationX2Slowmo)
                {
                    if (gameTimer.Interval != gameSettings.Speed / 3)
                    {
                        // Slow down the gameTimer
                        new gameController().SetTimerInterval(gameTimer, gameSettings.Speed / 3, true);
                        gameSettings.GamePowerupActive = true;
                    }
                    _lastChangeTime = lastPUpX2SlowmoChangeTime;
                }
                else
                {
                    // Reset the gameTimer interval to the originally determined speed 
                    new gameController().SetTimerInterval(gameTimer, gameSettings.Speed, true);
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2SlowmoDeactivate);
                }
            }
            if (Powerup == gamePowerup.X2Noclip)
            {
                if (lastPUpX2NoclipChangeTime >= currentTime - gameSettings.PowerupDurationX2Noclip)
                {
                    gameSettings.GamePowerupActive = true;
                    _lastChangeTime = lastPUpX2NoclipChangeTime;
                }
                else
                {
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2NoclipDeactivate);
                }
            }
            if (Powerup == gamePowerup.PointOnTickSlowmotion)
            {
                if (lastPUpPointTickSlowmoChangeTime >= currentTime - gameSettings.PowerupDurationPointTickSlowmo)
                {
                    gameSettings.Score = gameSettings.Score + 50;
                    if (gameTimer.Interval != gameSettings.Speed / 3)
                    {
                        // Slow down the gameTimer
                        new gameController().SetTimerInterval(gameTimer, gameSettings.Speed / 3, true);
                        gameSettings.GamePowerupActive = true;
                    }
                    _lastChangeTime = lastPUpPointTickSlowmoChangeTime;
                }
                else
                {
                    // Reset the gameTimer interval to the originally determined speed 
                    new gameController().SetTimerInterval(gameTimer, gameSettings.Speed, true);
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpPointTickSlowmoDeactivate);
                }
            }
            if (Powerup == gamePowerup.PointOnTickNoclip)
            {
                if (lastPUpPointTickNoclipChangeTime >= currentTime - gameSettings.PowerupDurationPointTickNoclip)
                {
                    gameSettings.Score = gameSettings.Score + 50;
                    gameSettings.GamePowerupActive = true;
                    _lastChangeTime = lastPUpPointTickNoclipChangeTime;
                }
                else
                {
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpPointTickNoclipDeactivate);
                }
            }
            if (Powerup == gamePowerup.SlowmotionNoclip)
            {
                if (lastPUpSlowmoNoclipChangeTime >= currentTime - gameSettings.PowerupDurationSlowmoNoclip)
                {
                    if (gameTimer.Interval != gameSettings.Speed / 3)
                    {
                        // Slow down the gameTimer
                        new gameController().SetTimerInterval(gameTimer, gameSettings.Speed / 3, true);
                        gameSettings.GamePowerupActive = true;
                    }
                    _lastChangeTime = lastPUpSlowmoNoclipChangeTime;
                }
                else
                {
                    // Reset the gameTimer interval to the originally determined speed 
                    new gameController().SetTimerInterval(gameTimer, gameSettings.Speed, true);
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpSlowmoNoclipDeactivate);
                }
            }
            new gameController().SetPowerup(labelCurrentPowerupValue, labelSavedPowerupValue, labelPowerupTimerValue, currentTime, _lastChangeTime);
        }

        private void DeterminePowerupBlink(out gamePowerup gamePowerup)
        {
            // To make the snake blink when powerup is about to run out
            int _blinkCheckX2 = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2 - (currentTime - lastPUpX2ChangeTime)),
                                                        gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckPointTick = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTick - (currentTime - lastPUpPointTickChangeTime)),
                                                               gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckSlowmo = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationSlowmo - (currentTime - lastPUpSlowmoChangeTime)),
                                                            gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckNoclip = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationNoclip - (currentTime - lastPUpNoclipChangeTime)),
                                                            gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckX2PointTick = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2PointTick - (currentTime - lastPUpX2PointTickChangeTime)),
                                                                 gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckX2Slowmo = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2Slowmo - (currentTime - lastPUpX2SlowmoChangeTime)),
                                                              gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckX2Noclip = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2Noclip - (currentTime - lastPUpX2NoclipChangeTime)),
                                                              gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckPointTickSlowmo = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTickSlowmo - (currentTime - lastPUpPointTickSlowmoChangeTime)),
                                                                 gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckPointTickNoclip = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTickNoclip - (currentTime - lastPUpPointTickNoclipChangeTime)),
                                                                 gameConstants.milliseconds, gameConstants.seconds);
            int _blinkCheckSlowmoNoclip = gamecontroller.ConvTime(Convert.ToInt32(gameSettings.PowerupDurationSlowmoNoclip - (currentTime - lastPUpSlowmoNoclipChangeTime)),
                                                                 gameConstants.milliseconds, gameConstants.seconds);

            // Determine snake color
            if ((gameSettings.GamePowerup == gamePowerup.X2 && (_blinkCheckX2 == 1 || _blinkCheckX2 == 3 || _blinkCheckX2 == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.PointOnTick && (_blinkCheckPointTick == 1 || _blinkCheckPointTick == 3 || _blinkCheckPointTick == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.Slowmotion && (_blinkCheckSlowmo == 1 || _blinkCheckSlowmo == 3 || _blinkCheckSlowmo == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.Noclip && (_blinkCheckNoclip == 1 || _blinkCheckNoclip == 3 || _blinkCheckNoclip == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.X2PointOnTick && (_blinkCheckX2PointTick == 1 || _blinkCheckX2PointTick == 3 || _blinkCheckX2PointTick == 5)) || 
                (gameSettings.GamePowerup == gamePowerup.X2Slowmotion && (_blinkCheckX2Slowmo == 1 || _blinkCheckX2Slowmo == 3 || _blinkCheckX2Slowmo == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.X2Noclip && (_blinkCheckX2Noclip == 1 || _blinkCheckX2Noclip == 3 || _blinkCheckX2Noclip == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.PointOnTickSlowmotion && (_blinkCheckPointTickSlowmo == 1 || _blinkCheckPointTickSlowmo == 3 || _blinkCheckPointTickSlowmo == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.PointOnTickNoclip && (_blinkCheckPointTickNoclip == 1 || _blinkCheckPointTickNoclip == 3 || _blinkCheckPointTickNoclip == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.SlowmotionNoclip && (_blinkCheckSlowmoNoclip == 1 || _blinkCheckSlowmoNoclip == 3 || _blinkCheckSlowmoNoclip == 5)))
            {
                gamePowerup = gamePowerup.None;
            }
            else
            {
                gamePowerup = gameSettings.GamePowerup;
            }
        }

        private void DetermineSnakeColor(int i, ref int colorIndex, ref int cnt)
        {
            gamePowerup _gamePowerup;

            // Decide the color of the snake
            if (gameSettings.DrawingMode == gameConstants.gameDrawingMode.drawingModeRainbow)
            {
                if (i == 0)
                {
                    gameSettings.snakeHeadColor = Brushes.Black; // Head color
                }
                else
                {
                    gameSettings.snakeBodyColor = gameSettings.snakeRainbowColor[colorIndex]; // Body color

                    cnt++;
                    // Cycle through different color indexes
                    switch (colorIndex)
                    {
                        case 0:
                            if (cnt > (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                colorIndex = 1;
                                cnt = 0;
                            }
                            break;
                        case 1:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                colorIndex = 2;
                                cnt = 0;
                            }
                            break;
                        case 2:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                colorIndex = 3;
                                cnt = 0;
                            }
                            break;
                        case 3:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                colorIndex = 4;
                                cnt = 0;
                            }
                            break;
                        case 4:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                colorIndex = 5;
                                cnt = 0;
                            }
                            break;
                        case 5:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                colorIndex = 0;
                                cnt = 0;
                            }
                            break;
                        default:
                            throw new ArgumentException(
                                        "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                        "colorIndex=" + colorIndex
                                        );
                    }

                    if (gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeStretched)
                    {
                        gameSettings.snakeBodyColor = gameSettings.snakeRainbowColor[colorIndex]; // Body color
                    }
                }
            }
            else
            {
                DeterminePowerupBlink(out _gamePowerup);

                switch (_gamePowerup)
                {
                    case gamePowerup.X2:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpX2Color;
                        gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpX2Color;
                        break;
                    case gamePowerup.PointOnTick:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpPointTickColor;
                        gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpPointTickColor;
                        break;
                    case gamePowerup.Slowmotion:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpSlowmoColor;
                        gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpSlowmoColor;
                        break;
                    case gamePowerup.Noclip:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpNoclipColor;
                        gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpNoclipColor;
                        break;
                    case gamePowerup.X2PointOnTick:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpPointTickColor;
                        switch (colorIndex)
                        {
                            case 0:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpPointTickColor;
                                colorIndex = 1;
                                break;
                            case 1:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpX2Color;
                                colorIndex = 0;
                                break;
                            default:
                                throw new ArgumentException(
                                            "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                            "colorIndex=" + colorIndex
                                            );
                        }
                        break;
                    case gamePowerup.X2Slowmotion:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpSlowmoColor;
                        switch (colorIndex)
                        {
                            case 0:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpSlowmoColor;
                                colorIndex = 1;
                                break;
                            case 1:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpX2Color;
                                colorIndex = 0;
                                break;
                            default:
                                throw new ArgumentException(
                                            "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                            "colorIndex=" + colorIndex
                                            );
                        }
                        break;
                    case gamePowerup.X2Noclip:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpNoclipColor;
                        switch (colorIndex)
                        {
                            case 0:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpNoclipColor;
                                colorIndex = 1;
                                break;
                            case 1:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpX2Color;
                                colorIndex = 0;
                                break;
                            default:
                                throw new ArgumentException(
                                            "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                            "colorIndex=" + colorIndex
                                            );
                        }
                        break;
                    case gamePowerup.PointOnTickSlowmotion:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpSlowmoColor;
                        switch (colorIndex)
                        {
                            case 0:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpSlowmoColor;
                                colorIndex = 1;
                                break;
                            case 1:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpPointTickColor;
                                colorIndex = 0;
                                break;
                            default:
                                throw new ArgumentException(
                                            "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                            "colorIndex=" + colorIndex
                                            );
                        }
                        break;
                    case gamePowerup.PointOnTickNoclip:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpNoclipColor;
                        switch (colorIndex)
                        {
                            case 0:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpNoclipColor;
                                colorIndex = 1;
                                break;
                            case 1:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpPointTickColor;
                                colorIndex = 0;
                                break;
                            default:
                                throw new ArgumentException(
                                            "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                            "colorIndex=" + colorIndex
                                            );
                        }
                        break;
                    case gamePowerup.SlowmotionNoclip:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadPUpNoclipColor;
                        switch (colorIndex)
                        {
                            case 0:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpNoclipColor;
                                colorIndex = 1;
                                break;
                            case 1:
                                gameSettings.snakeBodyColor = gameSettings.snakeBodyPUpSlowmoColor;
                                colorIndex = 0;
                                break;
                            default:
                                throw new ArgumentException(
                                            "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                            "colorIndex=" + colorIndex
                                            );
                        }
                        break;
                    case gamePowerup.None:
                        gameSettings.snakeHeadColor = gameSettings.snakeHeadNormalColor;
                        gameSettings.snakeBodyColor = gameSettings.snakeBodyNormalColor;
                        break;
                    default:
                        gameSettings.snakeHeadColor = Brushes.Maroon;
                        gameSettings.snakeBodyColor = Brushes.Maroon;
                        break;
                }
            }
        }

        private void DetermineFoodColor()
        {
            // Determine food color
            switch (gameSettings.FoodPowerup)
            {
                case gamePowerup.X2:
                    gameSettings.foodColor = gameSettings.foodPUpX2Color;
                    break;
                case gamePowerup.PointOnTick:
                    gameSettings.foodColor = gameSettings.foodPUpPointTickColor;
                    break;
                case gamePowerup.Slowmotion:
                    gameSettings.foodColor = gameSettings.foodPUpSlowmoColor;
                    break;
                case gamePowerup.Noclip:
                    gameSettings.foodColor = gameSettings.foodPUpNoclipColor;
                    break;
                case gamePowerup.None:
                    gameSettings.foodColor = gameSettings.foodNormalColor;
                    break;
                default:
                    gameSettings.foodColor = Brushes.Maroon;
                    break;
            }
        }

        private void DrawSnakeColor(int i, ref Graphics Canvas)
        {
            // Draw snake 
            Canvas.FillRectangle
            (
                i == 0 ? gameSettings.snakeHeadColor : gameSettings.snakeBodyColor,
                new Rectangle
                (
                    gameObject.Snake[i].X * gameSettings.Width,
                    gameObject.Snake[i].Y * gameSettings.Height,
                    gameSettings.Width,
                    gameSettings.Height
                )
            );
        }

        private void DrawFoodColor(ref Graphics Canvas)
        {
            // Draw food
            Canvas.FillRectangle
            (
                gameSettings.foodColor,
                new Rectangle
                (
                    gameObject.Food.X * gameSettings.Width,
                    gameObject.Food.Y * gameSettings.Height,
                    gameSettings.Width,
                    gameSettings.Height
                )
            );
        }

        private void DetermineSnakeSprite(int i, out Image spriteImage, out int spriteLocX, out int spriteLocY)
        {
            gamePowerup _gamePowerup;
            spriteImage = gameSprite;
            spriteLocX = 1;
            spriteLocY = 3;

            DeterminePowerupBlink(out _gamePowerup);

            // Determine which sprite file to use if any powerups are active
            if (gameSettings.GamePowerupActive)
            {
                switch (_gamePowerup)
                {
                    case gamePowerup.X2:
                        spriteImage = gameSpritePUpX2;
                        break;
                    case gamePowerup.PointOnTick:
                        spriteImage = gameSpritePUpPointTick;
                        break;
                    case gamePowerup.Slowmotion:
                        spriteImage = gameSpritePUpSlowmotion;
                        break;
                    case gamePowerup.Noclip:
                        spriteImage = gameSpritePUpNoclip;
                        break;
                    case gamePowerup.X2PointOnTick:
                        spriteImage = gameSpritePUpX2PointTick;
                        break;
                    case gamePowerup.X2Slowmotion:
                        spriteImage = gameSpritePUpX2Slowmotion;
                        break;
                    case gamePowerup.X2Noclip:
                        spriteImage = gameSpritePUpX2Noclip;
                        break;
                    case gamePowerup.PointOnTickSlowmotion:
                        spriteImage = gameSpritePUpPointTickSlowmotion;
                        break;
                    case gamePowerup.PointOnTickNoclip:
                        spriteImage = gameSpritePUpPointTickNoclip;
                        break;
                    case gamePowerup.SlowmotionNoclip:
                        spriteImage = gameSpritePUpSlowmotionNoclip;
                        break;
                }
            }

            if (i == 0) // Head
            {
                switch (gameSettings.directionHead)
                {
                    case gameDirection.Up:
                        spriteLocX = 3;
                        spriteLocY = 0;
                        break;
                    case gameDirection.Down:
                        spriteLocX = 4;
                        spriteLocY = 1;
                        break;
                    case gameDirection.Left:
                        spriteLocX = 3;
                        spriteLocY = 1;
                        break;
                    case gameDirection.Right:
                        spriteLocX = 4;
                        spriteLocY = 0;
                        break;
                    default:
                        spriteLocX = 3;
                        spriteLocY = 0;
                        break;
                }
            }
            else if (i > 0 && i < gameObject.Snake.Count - 1) // Body
            {
                gameObject currSnakeTile = gameObject.Snake[i];
                gameObject prevSnakeTile = gameObject.Snake[i - 1];
                gameObject nextSnakeTile = gameObject.Snake[i + 1];
                
                if (((currSnakeTile.X == 0 && 
                    ((nextSnakeTile.X == 0 && nextSnakeTile.Y > prevSnakeTile.Y && prevSnakeTile.X == gameController.maxPosX - 1) || 
                     (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y < prevSnakeTile.Y && prevSnakeTile.X == 0))) ||
                     (currSnakeTile.Y == gameController.maxPosY - 1 &&
                    ((nextSnakeTile.Y == gameController.maxPosY - 1 && nextSnakeTile.X < prevSnakeTile.X && prevSnakeTile.Y == 0) ||
                     (nextSnakeTile.Y == 0 && nextSnakeTile.X > prevSnakeTile.X && prevSnakeTile.Y == gameController.maxPosY - 1))) ||
                     (currSnakeTile.X == 0 && currSnakeTile.Y == gameController.maxPosY - 1 &&
                    ((nextSnakeTile.X == 0 && nextSnakeTile.Y == 0 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == gameController.maxPosY - 1) || 
                     (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == 0 && prevSnakeTile.Y == 0)))) &&
                    !(currSnakeTile.X == gameController.maxPosX - 1 && currSnakeTile.Y == gameController.maxPosY - 1 &&
                    ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == 0 && prevSnakeTile.X == 0 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                     (nextSnakeTile.X == 0 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == 0))) &&
                    !(currSnakeTile.X == 0 && currSnakeTile.Y == 0 &&
                    ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == 0 && prevSnakeTile.X == 0 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                     (nextSnakeTile.X == 0 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == 0))) &&
                    !(currSnakeTile.X == gameController.maxPosX - 1 && currSnakeTile.Y == 0 &&
                    ((nextSnakeTile.X == 0 && nextSnakeTile.Y == 0 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                     (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == 0 && prevSnakeTile.Y == 0))))
                {
                    // Up - Left Noclip
                    spriteLocX = 2;
                    spriteLocY = 0;
                }
                else if (((currSnakeTile.X == gameController.maxPosX - 1 && 
                         ((nextSnakeTile.X == 0 && nextSnakeTile.Y < prevSnakeTile.Y && prevSnakeTile.X == gameController.maxPosX - 1) ||
                          (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y > prevSnakeTile.Y && prevSnakeTile.X == 0))) ||
                          (currSnakeTile.Y == gameController.maxPosY - 1 &&
                         ((nextSnakeTile.Y == gameController.maxPosY - 1 && nextSnakeTile.X > prevSnakeTile.X && prevSnakeTile.Y == 0) ||
                          (nextSnakeTile.Y == 0 && nextSnakeTile.X < prevSnakeTile.X && prevSnakeTile.Y == gameController.maxPosY - 1))) ||
                          (currSnakeTile.X == gameController.maxPosX - 1 && currSnakeTile.Y == gameController.maxPosY - 1 &&
                         ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == 0 && prevSnakeTile.X == 0 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == 0 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == 0)))) &&
                         !(currSnakeTile.X == 0 && currSnakeTile.Y == gameController.maxPosY - 1 &&
                         ((nextSnakeTile.X == 0 && nextSnakeTile.Y == 0 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == 0 && prevSnakeTile.Y == 0))) &&
                         !(currSnakeTile.X == 0 && currSnakeTile.Y == 0 &&
                         ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == 0 && prevSnakeTile.X == 0 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == 0 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == 0))) &&
                         !(currSnakeTile.X == gameController.maxPosX - 1 && currSnakeTile.Y == 0 &&
                         ((nextSnakeTile.X == 0 && nextSnakeTile.Y == 0 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == 0 && prevSnakeTile.Y == 0))))
                {
                    // Up - Right Noclip
                    spriteLocX = 0;
                    spriteLocY = 0;
                }
                else if (((currSnakeTile.X == 0 && 
                         ((nextSnakeTile.X == 0 && nextSnakeTile.Y < prevSnakeTile.Y && prevSnakeTile.X == gameController.maxPosX - 1) || 
                          (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y > prevSnakeTile.Y && prevSnakeTile.X == 0))) ||
                          (currSnakeTile.Y == 0 &&
                         ((nextSnakeTile.Y == 0 && nextSnakeTile.X < prevSnakeTile.X && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.Y == gameController.maxPosY - 1 && nextSnakeTile.X > prevSnakeTile.X && prevSnakeTile.Y == 0))) ||
                          (currSnakeTile.X == 0 && currSnakeTile.Y == 0 &&
                         ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == 0 && prevSnakeTile.X == 0 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == 0 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == 0)))) &&
                         !(currSnakeTile.X == 0 && currSnakeTile.Y == gameController.maxPosY - 1 &&
                         ((nextSnakeTile.X == 0 && nextSnakeTile.Y == 0 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == 0 && prevSnakeTile.Y == 0))) &&
                         !(currSnakeTile.X == gameController.maxPosX - 1 && currSnakeTile.Y == gameController.maxPosY - 1 &&
                         ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == 0 && prevSnakeTile.X == 0 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == 0 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == 0))) &&
                         !(currSnakeTile.X == gameController.maxPosX - 1 && currSnakeTile.Y == 0 &&
                         ((nextSnakeTile.X == 0 && nextSnakeTile.Y == 0 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == 0 && prevSnakeTile.Y == 0))))
                {
                    // Down - Left Noclip
                    spriteLocX = 2;
                    spriteLocY = 2;
                }
                else if (((currSnakeTile.X == gameController.maxPosX - 1 &&
                         ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y < prevSnakeTile.Y && prevSnakeTile.X == 0) ||
                          (nextSnakeTile.X == 0 && nextSnakeTile.Y > prevSnakeTile.Y && prevSnakeTile.X == gameController.maxPosX - 1))) ||
                          (currSnakeTile.Y == 0 &&
                         ((nextSnakeTile.Y == 0 && nextSnakeTile.X > prevSnakeTile.X && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.Y == gameController.maxPosY - 1 && nextSnakeTile.X < prevSnakeTile.X && prevSnakeTile.Y == 0))) ||
                          (currSnakeTile.X == gameController.maxPosX - 1 && currSnakeTile.Y == 0 &&
                         ((nextSnakeTile.X == 0 && nextSnakeTile.Y == 0 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == 0 && prevSnakeTile.Y == 0)))) &&
                         !(currSnakeTile.X == 0 && currSnakeTile.Y == gameController.maxPosY - 1 &&
                         ((nextSnakeTile.X == 0 && nextSnakeTile.Y == 0 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == 0 && prevSnakeTile.Y == 0))) &&
                         !(currSnakeTile.X == gameController.maxPosX - 1 && currSnakeTile.Y == gameController.maxPosY - 1 &&
                         ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == 0 && prevSnakeTile.X == 0 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == 0 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == 0))) &&
                         !(currSnakeTile.X == 0 && currSnakeTile.Y == 0 &&
                         ((nextSnakeTile.X == gameController.maxPosX - 1 && nextSnakeTile.Y == 0 && prevSnakeTile.X == 0 && prevSnakeTile.Y == gameController.maxPosY - 1) ||
                          (nextSnakeTile.X == 0 && nextSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.Y == 0))))
                {
                    // Down - Right Noclip
                    spriteLocX = 0;
                    spriteLocY = 1;
                }
                else if ((prevSnakeTile.Y < currSnakeTile.Y && nextSnakeTile.Y > currSnakeTile.Y || nextSnakeTile.Y < currSnakeTile.Y && prevSnakeTile.Y > currSnakeTile.Y) ||
                        ((prevSnakeTile.Y == 0 || nextSnakeTile.Y == 0) && currSnakeTile.Y == gameController.maxPosY - 1) ||
                        ((prevSnakeTile.Y == gameController.maxPosY - 1 || nextSnakeTile.Y == gameController.maxPosY - 1) && currSnakeTile.Y == 0))
                {
                    // Vertical
                    spriteLocX = 2;
                    spriteLocY = 1;
                }
                else if ((prevSnakeTile.X < currSnakeTile.X && nextSnakeTile.X > currSnakeTile.X || nextSnakeTile.X < currSnakeTile.X && prevSnakeTile.X > currSnakeTile.X) ||
                        ((prevSnakeTile.X == 0 || nextSnakeTile.X == 0) && currSnakeTile.X == gameController.maxPosX - 1) ||
                        ((prevSnakeTile.X == gameController.maxPosX - 1 || nextSnakeTile.X == gameController.maxPosX - 1) && currSnakeTile.X == 0))
                { 
                    // Horizontal
                    spriteLocX = 1;
                    spriteLocY = 0;
                }
                else if (prevSnakeTile.X < currSnakeTile.X && nextSnakeTile.Y > currSnakeTile.Y || nextSnakeTile.X < currSnakeTile.X && prevSnakeTile.Y > currSnakeTile.Y) 
                {
                    // Up - Left
                    spriteLocX = 2;
                    spriteLocY = 0;
                }
                else if (prevSnakeTile.Y > currSnakeTile.Y && nextSnakeTile.X > currSnakeTile.X || nextSnakeTile.Y > currSnakeTile.Y && prevSnakeTile.X > currSnakeTile.X) 
                {
                    // Up - Right
                    spriteLocX = 0;
                    spriteLocY = 0;
                }
                else if (prevSnakeTile.Y < currSnakeTile.Y && nextSnakeTile.X < currSnakeTile.X || nextSnakeTile.Y < currSnakeTile.Y && prevSnakeTile.X < currSnakeTile.X) 
                {
                    // Down - Left
                    spriteLocX = 2;
                    spriteLocY = 2;
                }
                else if (prevSnakeTile.X > currSnakeTile.X && nextSnakeTile.Y < currSnakeTile.Y || nextSnakeTile.X > currSnakeTile.X && prevSnakeTile.Y < currSnakeTile.Y) 
                {
                    // Down - Right
                    spriteLocX = 0;
                    spriteLocY = 1;
                }
            }
            else // Tail
            {
                gameObject currSnakeTile = gameObject.Snake[i];
                gameObject prevSnakeTile = gameObject.Snake[i - 1];

                if ((prevSnakeTile.Y < currSnakeTile.Y && (currSnakeTile.Y != gameController.maxPosY - 1 || prevSnakeTile.Y != 0)) ||
                    (currSnakeTile.Y == 0 && prevSnakeTile.Y == gameController.maxPosY - 1)) // Up
                {
                    spriteLocX = 3;
                    spriteLocY = 2;
                }
                else if ((prevSnakeTile.Y > currSnakeTile.Y && (currSnakeTile.Y != 0 || prevSnakeTile.Y != gameController.maxPosY - 1)) ||
                         (currSnakeTile.Y == gameController.maxPosY - 1 && prevSnakeTile.Y == 0)) // Down
                {
                    spriteLocX = 4;
                    spriteLocY = 3;
                }
                else if ((prevSnakeTile.X < currSnakeTile.X && (currSnakeTile.X != gameController.maxPosX - 1 || prevSnakeTile.X != 0)) ||
                         (currSnakeTile.X == 0 && prevSnakeTile.X == gameController.maxPosX - 1)) // Left
                {
                    spriteLocX = 3;
                    spriteLocY = 3;
                }
                else if ((prevSnakeTile.X > currSnakeTile.X && (currSnakeTile.X != 0 || prevSnakeTile.X != gameController.maxPosX - 1)) ||
                         (currSnakeTile.X == gameController.maxPosX - 1 && prevSnakeTile.X == 0)) // Right
                {
                    spriteLocX = 4;
                    spriteLocY = 2;
                }
            }
        }

        private void DetermineFoodSprite(out Image spriteImage, out int spriteLocX, out int spriteLocY)
        {
            spriteImage = gameSprite;

            if (gameSettings.FoodPowerup != gamePowerup.None)
            {
                switch (gameSettings.FoodPowerup)
                {
                    case gamePowerup.X2:
                        spriteImage = gameSpritePUpX2;
                        break;
                    case gamePowerup.PointOnTick:
                        spriteImage = gameSpritePUpPointTick;
                        break;
                    case gamePowerup.Slowmotion:
                        spriteImage = gameSpritePUpSlowmotion;
                        break;
                    case gamePowerup.Noclip:
                        spriteImage = gameSpritePUpNoclip;
                        break;
                }
            }

            spriteLocX = 0;
            spriteLocY = 3;
        }

        private void DrawSnakeSprite(int i, ref Graphics Canvas, Image spriteImage, int spriteLocX, int spriteLocY)
        {
            Canvas.DrawImage
            (
                spriteImage,
                new Rectangle
                (
                    gameObject.Snake[i].X * gameSettings.Width,
                    gameObject.Snake[i].Y * gameSettings.Height,
                    gameSettings.Width,
                    gameSettings.Height
                ),
                spriteLocX * 64,
                spriteLocY * 64,
                64,
                64,
                GraphicsUnit.Pixel
            );
        }

        private void DrawFoodSprite(ref Graphics Canvas, Image spriteImage, int spriteLocX, int spriteLocY)
        {
            Canvas.DrawImage
            (
                spriteImage,
                new Rectangle
                (
                    gameObject.Food.X * gameSettings.Width,
                    gameObject.Food.Y * gameSettings.Height,
                    gameSettings.Width,
                    gameSettings.Height
                ),
                spriteLocX * 64,
                spriteLocY * 64,
                64,
                64,
                GraphicsUnit.Pixel
            );
        }

        private void DrawGameStatus(ref Graphics Canvas)
        {
            string _gameStatusText = " ";

            if (!gameSettings.GameOver)
            {
                // Show game paused message
                if (gameSettings.GamePaused)
                {
                    _gameStatusText = "Game paused!\nPress '" + gameControls.modPauseKey + "' to continue";
                }
            }
            else // Show game over message
            {
                _gameStatusText = "Game Over!\nYour score is: " + gameSettings.Score + "\nPress '" + gameControls.modRestartKey + "' to try again";
            }

            if (_gameStatusText != " " || _gameStatusText != "")
            {
                StringFormat _stringFormat = new StringFormat();
                _stringFormat.Alignment = StringAlignment.Center;

                // Draw the string with the specified _stringFormat
                Canvas.DrawString(_gameStatusText, new Font("Microsoft Sans Serif", 20), Brushes.Black, 300, 200, _stringFormat);
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            int cnt = 0;
            int colorIndex = 0; // Used for multicolored snake visuals
            Graphics Canvas = e.Graphics;

            if (!gameSettings.GameOver)
            {
                // Draw snake head & body
                for (int i = 0; i < gameObject.Snake.Count; i++)
                {
                    if (gameSettings.DrawingMode == gameConstants.gameDrawingMode.drawingModeNormal || gameSettings.DrawingMode == gameConstants.gameDrawingMode.drawingModeRainbow)
                    {
                        DetermineSnakeColor(i, ref colorIndex, ref cnt);
                        DrawSnakeColor(i, ref Canvas);
                        DetermineFoodColor();
                        DrawFoodColor(ref Canvas);
                    }
                    else if (gameSettings.DrawingMode == gameConstants.gameDrawingMode.drawingModeSprite)
                    {
                        Image _spriteImage;
                        int _spriteLocX;
                        int _spriteLocY;

                        DetermineSnakeSprite(i, out _spriteImage, out _spriteLocX, out _spriteLocY);
                        DrawSnakeSprite(i, ref Canvas, _spriteImage, _spriteLocX, _spriteLocY);
                        DetermineFoodSprite(out _spriteImage, out _spriteLocX, out _spriteLocY);
                        DrawFoodSprite(ref Canvas, _spriteImage, _spriteLocX, _spriteLocY);
                    }
                }

                gamecontroller.GrowSnake();

                if (setInputForNextTick)
                {
                    gameSettings.directionHead = nextTickDirection;
                    setInputForNextTick = false;
                }
            }
            
            // Draw the game status over the actual game graphics
            DrawGameStatus(ref Canvas);
        }

        // To toggle the bot modifier
        private void ToggleBotModifier()
        {
            if (lastBotChangeTime <= currentTime - gameConstants.keyInputDelay)
            {
                gameSettings.IsModifierRound = true;
                gameSettings.BotEnabled = gameSettings.BotEnabled ? false : true;
                toolStripMenuItemBot.BackColor = gameSettings.BotEnabled ? Color.Green : Color.Red;

                lastBotChangeTime = currentTime;
            }
        }

        // To toggle the speed modifier
        private void ToggleSpeedModifier()
        {
            if (lastSpeedChangeTime <= currentTime - gameConstants.keyInputDelay)
            {
                gameSettings.IsModifierRound = true;
                gameSettings.SpeedEnabled = gameSettings.SpeedEnabled ? false : true;
                gamecontroller.SetTimerInterval(gameTimer, gameSettings.SpeedEnabled ? 1000 : gameSettings.Speed, true);
                toolStripMenuItemSpeed.BackColor = gameSettings.SpeedEnabled ? Color.Green : Color.Red;

                lastSpeedChangeTime = currentTime;
            }
        }

        // To toggle the noclip modifier
        private void ToggleNoClipModifier()
        {
            if (lastNoClipChangeTime <= currentTime - gameConstants.keyInputDelay)
            {
                gameSettings.IsModifierRound = true;
                gameSettings.NoClipEnabled = gameSettings.NoClipEnabled ? false : true;
                toolStripMenuItemNoClip.BackColor = gameSettings.NoClipEnabled ? Color.Green : Color.Red;

                lastNoClipChangeTime = currentTime;
            }
        }

        // To determine the activated powerupOpen
        private gamePowerup DetermineGamePowerup()
        {
            gamePowerup _gamePowerup = gameSettings.GamePowerup;

            switch (gameSettings.SavedPowerup)
            {
                case gamePowerup.X2:
                    switch (gameSettings.GamePowerup)
                    {
                        case gamePowerup.PointOnTick:
                            _gamePowerup = gamePowerup.X2PointOnTick;
                            break;
                        case gamePowerup.Slowmotion:
                            _gamePowerup = gamePowerup.X2Slowmotion;
                            break;
                        case gamePowerup.Noclip:
                            _gamePowerup = gamePowerup.X2Noclip;
                            break;
                        default:
                            _gamePowerup = gameSettings.SavedPowerup;
                            break;
                    }
                    break;
                case gamePowerup.PointOnTick:
                    switch (gameSettings.GamePowerup)
                    {
                        case gamePowerup.X2:
                            _gamePowerup = gamePowerup.X2PointOnTick;
                            break;
                        case gamePowerup.Slowmotion:
                            _gamePowerup = gamePowerup.PointOnTickSlowmotion;
                            break;
                        case gamePowerup.Noclip:
                            _gamePowerup = gamePowerup.PointOnTickNoclip;
                            break;
                        default:
                            _gamePowerup = gameSettings.SavedPowerup;
                            break;
                    }
                    break;
                case gamePowerup.Slowmotion:
                    switch (gameSettings.GamePowerup)
                    {
                        case gamePowerup.X2:
                            _gamePowerup = gamePowerup.X2Slowmotion;
                            break;
                        case gamePowerup.PointOnTick:
                            _gamePowerup = gamePowerup.PointOnTickSlowmotion;
                            break;
                        case gamePowerup.Noclip:
                            _gamePowerup = gamePowerup.SlowmotionNoclip;
                            break;
                        default:
                            _gamePowerup = gameSettings.SavedPowerup;
                            break;
                    }
                    break;
                case gamePowerup.Noclip:
                    switch (gameSettings.GamePowerup)
                    {
                        case gamePowerup.X2:
                            _gamePowerup = gamePowerup.X2Noclip;
                            break;
                        case gamePowerup.PointOnTick:
                            _gamePowerup = gamePowerup.PointOnTickNoclip;
                            break;
                        case gamePowerup.Slowmotion:
                            _gamePowerup = gamePowerup.SlowmotionNoclip;
                            break;
                        default:
                            _gamePowerup = gameSettings.SavedPowerup;
                            break;
                    }
                    break;
            }

            return _gamePowerup;
        }

        private void gameInterface_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameSettings.GameOver)
            {
                // To assist the player in direction change over the next tick
                if (!setInputForNextTick)
                {
                    // Check if key input is a direction key
                    if ((e.KeyCode == gameControls.dirRightKey || e.KeyCode == Keys.Right) && 
                       ((currentTickDir != gameDirection.Left && currentTickDir != gameDirection.Right && !gameSettings.GamePaused) || 
                       gameSettings.DevModeEnabled))
                    {
                        gameSettings.directionHead = gameDirection.Right;
                        setInputForNextTick = true;
                        gamecontroller.PlayGameSound(gameConstants.gameSound.SnakeChangeDir);
                    }
                    else if ((e.KeyCode == gameControls.dirLeftKey || e.KeyCode == Keys.Left) && 
                            ((currentTickDir != gameDirection.Right && currentTickDir != gameDirection.Left && !gameSettings.GamePaused) || 
                            gameSettings.DevModeEnabled))
                    {
                        gameSettings.directionHead = gameDirection.Left;
                        setInputForNextTick = true;
                        gamecontroller.PlayGameSound(gameConstants.gameSound.SnakeChangeDir);
                    }
                    else if ((e.KeyCode == gameControls.dirUpKey || e.KeyCode == Keys.Up) && 
                            ((currentTickDir != gameDirection.Down && currentTickDir != gameDirection.Up && !gameSettings.GamePaused) || 
                            gameSettings.DevModeEnabled))
                    {
                        gameSettings.directionHead = gameDirection.Up;
                        setInputForNextTick = true;
                        gamecontroller.PlayGameSound(gameConstants.gameSound.SnakeChangeDir);
                    }
                    else if ((e.KeyCode == gameControls.dirDownKey || e.KeyCode == Keys.Down) && 
                            ((currentTickDir != gameDirection.Up && currentTickDir != gameDirection.Down && !gameSettings.GamePaused) || 
                            gameSettings.DevModeEnabled))
                    {
                        gameSettings.directionHead = gameDirection.Down;
                        setInputForNextTick = true;
                        gamecontroller.PlayGameSound(gameConstants.gameSound.SnakeChangeDir);
                    }
                    nextTickDirection = gameSettings.directionHead;
                }
                else
                {
                    if ((e.KeyCode == gameControls.dirRightKey || e.KeyCode == Keys.Right) && (gameSettings.directionHead != gameDirection.Left && !gameSettings.GamePaused))
                    {
                        nextTickDirection = gameDirection.Right;
                    }
                    else if ((e.KeyCode == gameControls.dirLeftKey || e.KeyCode == Keys.Left) && (gameSettings.directionHead != gameDirection.Right && !gameSettings.GamePaused))
                    {
                        nextTickDirection = gameDirection.Left;
                    }
                    else if ((e.KeyCode == gameControls.dirUpKey || e.KeyCode == Keys.Up) && (gameSettings.directionHead != gameDirection.Down && !gameSettings.GamePaused))
                    {
                        nextTickDirection = gameDirection.Up;
                    }
                    else if ((e.KeyCode == gameControls.dirDownKey || e.KeyCode == Keys.Down) && (gameSettings.directionHead != gameDirection.Up && !gameSettings.GamePaused))
                    {
                        nextTickDirection = gameDirection.Down;
                    }
                }
                // Check if player wants to activate / deactivate any modifiers
                if (e.KeyCode == gameControls.modBotKey)
                {
                    ToggleBotModifier();
                }
                else if (e.KeyCode == gameControls.modSpeedKey)
                {
                    ToggleSpeedModifier();
                }
                else if (e.KeyCode == gameControls.modNoClipKey && !gameSettings.MenuIsOpen)
                {
                    ToggleNoClipModifier();
                }
                else if (e.KeyCode == gameControls.modPauseKey && !gameSettings.MenuIsOpen && lastPauseChangeTime <= currentTime - gameConstants.keyInputDelay)
                {
                    gameSettings.GamePaused = gameSettings.GamePaused ? false : true;
                    lastPauseChangeTime = currentTime;
                }
                else if (e.KeyCode == gameControls.modDevModeKey && !gameSettings.MenuIsOpen && lastDevModeChangeTime <= currentTime - gameConstants.keyInputDelay)
                {
                    gameSettings.DevModeEnabled = gameSettings.DevModeEnabled ? false : true;
                    lastDevModeChangeTime = currentTime;
                }
                else if (e.KeyCode == gameControls.modPowerupKey && !gameSettings.MenuIsOpen)
                {
                    if (gameSettings.SavedPowerup != gamePowerup.None)
                    {
                        // Only enable a new powerup if there are not more than 2 powerups currently active
                        if (gameSettings.GamePowerup != gamePowerup.X2PointOnTick && gameSettings.GamePowerup != gamePowerup.X2Slowmotion && 
                            gameSettings.GamePowerup != gamePowerup.X2Noclip && gameSettings.GamePowerup != gamePowerup.PointOnTickSlowmotion &&
                            gameSettings.GamePowerup != gamePowerup.PointOnTickNoclip && gameSettings.GamePowerup != gamePowerup.SlowmotionNoclip)
                        {
                            gameSettings.GamePowerup = DetermineGamePowerup();
                            gameSettings.SavedPowerup = gamePowerup.None;

                            lastPUpX2ChangeTime = 0;
                            lastPUpPointTickChangeTime = 0;
                            lastPUpSlowmoChangeTime = 0;
                            lastPUpNoclipChangeTime = 0;
                            lastPUpX2PointTickChangeTime = 0;
                            lastPUpX2SlowmoChangeTime = 0;
                            lastPUpX2NoclipChangeTime = 0;
                            lastPUpPointTickSlowmoChangeTime = 0;
                            lastPUpPointTickNoclipChangeTime = 0;
                            lastPUpSlowmoNoclipChangeTime = 0;

                            switch (gameSettings.GamePowerup)
                            {
                                case gamePowerup.X2:
                                    lastPUpX2ChangeTime = currentTime;
                                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2Activate);
                                    break;
                                case gamePowerup.PointOnTick:
                                    lastPUpPointTickChangeTime = currentTime;
                                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpPointTickActivate);
                                    break;
                                case gamePowerup.Slowmotion:
                                    lastPUpSlowmoChangeTime = currentTime;
                                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpSlowmoActivate);
                                    break;
                                case gamePowerup.Noclip:
                                    lastPUpNoclipChangeTime = currentTime;
                                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpNoclipActivate);
                                    break;
                                case gamePowerup.X2PointOnTick:
                                    lastPUpX2PointTickChangeTime = currentTime;
                                     gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2PointTickSynergy);
                                    break;
                                case gamePowerup.X2Slowmotion:
                                    lastPUpX2SlowmoChangeTime = currentTime;
                                     gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2SlowmoSynergy);
                                    break;
                                case gamePowerup.X2Noclip:
                                    lastPUpX2NoclipChangeTime = currentTime;
                                     gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2NoclipSynergy);
                                    break;
                                case gamePowerup.PointOnTickSlowmotion:
                                    lastPUpPointTickSlowmoChangeTime = currentTime;
                                     gamecontroller.PlayGameSound(gameConstants.gameSound.PUpPointTickSlowmoSynergy);
                                    break;
                                case gamePowerup.PointOnTickNoclip:
                                    lastPUpPointTickNoclipChangeTime = currentTime;
                                     gamecontroller.PlayGameSound(gameConstants.gameSound.PUpPointTickNoclipSynergy);
                                    break;
                                case gamePowerup.SlowmotionNoclip:
                                    lastPUpSlowmoNoclipChangeTime = currentTime;
                                     gamecontroller.PlayGameSound(gameConstants.gameSound.PUpSlowmoNoclipSynergy);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                if (gameSettings.DevModeEnabled)
                {
                    if (e.KeyCode == gameControls.modReloadSpritesKey)
                    {
                        gamecontroller.LoadAllGameSprites();
                    }
                    else if (e.KeyCode == gameControls.modGrowSnakeKey)
                    {
                        gameController.growCnt = gameSettings.GrowMultiplicator - 1;
                    }
                    else if (e.KeyCode == gameControls.modShrinkSnakeKey)
                    {
                        gamecontroller.ShrinkSnake();
                    }
                    else if (e.KeyCode == gameControls.modLoadDevSettingsKey)
                    {
                        gamecontroller.SaveLoadDevmodeSettings();
                    }
                }
            }
            if (gameSettings.GameOver || gameSettings.DevModeEnabled)
            {
                if (e.KeyCode == gameControls.modRestartKey)
                {
                    if (!gameSettings.DevModeEnabled)
                    {
                        new gameSettings(false);
                    }
                    else
                    {
                        gameSettings.GameOver = false;
                        gameSettings.directionHead = gameDirection.Stop;
                    }
                    new gameControls(false);
                    gamecontroller.SetTimerInterval(gameTimer, gameSettings.Speed, true);
                    gameController.maxPosX = gamecontroller.GetMaxPosX(pictureBox);
                    gameController.maxPosY = gamecontroller.GetMaxPosY(pictureBox);
                    nextTickDirection = gameDirection.Stop;
                    gamecontroller.StartGame();
                    gamecontroller.SetHighScore(labelHighscoreValue);
                    gamecontroller.GenerateFood();
                    toolStripMenuItemBot.BackColor = gameSettings.BotEnabled ? Color.Green : Color.Red;
                    toolStripMenuItemSpeed.BackColor = gameSettings.SpeedEnabled ? Color.Green : Color.Red;
                    toolStripMenuItemNoClip.BackColor = gameSettings.NoClipEnabled ? Color.Green : Color.Red;
                    gameSettings.IsModifierRound = gameSettings.BotEnabled ? true : gameSettings.SpeedEnabled ? true : gameSettings.NoClipEnabled ? true : false;
                    lastPauseChangeTime = 0;
                }
            }
        }

        // Opens a new menu window / shows an already existing one
        private void toolStripMenuItemMenu_Click(object sender, EventArgs e)
        {
            try // Try to show the already open menu form
            {
                gamemenu.Show();
                gamemenu.WindowState = FormWindowState.Normal;
                gamemenu.BringToFront();
            }
            catch (Exception) // Create a new menu form if it isn't opened already
            {
                gamemenu = new gameMenu();
                gamemenu.Show();
            }
        }

        private void MilliSecondTimer_Tick(object sender, EventArgs e)
        {
            currentTime = currentTime + 500 <= long.MaxValue ? currentTime + 500 : 0;

            if (currentTime % 1000 == 0)
            {
                CheckActivePowerup(gameSettings.GamePowerup);
            }
        }

        private void toolStripMenuItemBot_Click(object sender, EventArgs e) 
        {
            ToggleBotModifier();
        }

        private void toolStripMenuItemSpeed_Click(object sender, EventArgs e) 
        {
            ToggleSpeedModifier();
        }

        private void toolStripMenuItemNoClip_Click(object sender, EventArgs e) 
        {
            ToggleNoClipModifier();
        }
    }
}
