using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class gameInterface : Form
    {
        gameMenu gamemenu; // Needed here so the menu only opens once
        gameController gamecontroller;

        private long lastBotChangeTime = 0; // To prevent buggy behaviour when enabling or disabling the bot
        private long lastSpeedChangeTime = 0; // To prevent buggy behaviour when enabling or disabling the speed up
        private long lastPauseChangeTime = 0; // To prevent buggy behaviour when pausing or unpausing the game
        private long lastDevModeChangeTime = 0; // To prevent buggy behaviour when enabling or disabling the devmode
        private long lastNoClipChangeTime = 0; // To prevent buggy behaviour when enabling or disabling the noclip
        private long lastPUpX2ChangeTime = 0; // Powerup: To keep track of Multiplier duration
        private long lastPUpPointTickChangeTime = 0; // Powerup: To keep track of Point Tick duration
        private long lastPUpSlowmoChangeTime = 0; // Powerup: To keep track of Slowmo duration
        private long lastPUpNoclipChangeTime = 0; // Powerup: To keep track of Noclip duration
        private long currentTime = 0; // Current time; 1000 = 1 second 
        private gameDirection currentTickDir; // The direction the snake is heading at in the current game tick
        public static Image gameSprite; // Normal gameSprite 
        public static Image gameSpritePUpX2; // gameSprite used for 'X2' powerup
        public static Image gameSpritePUpPointTick; // gameSprite used for 'Point on Tick' powerup
        public static Image gameSpritePUpSlowmotion; // gameSprite used for 'Slowmotion' powerup
        public static Image gameSpritePUpNoclip; // gameSprite used for 'Noclip' powerup

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

            // Pause the game if the menu form is open
            gameSettings.MenuIsOpen = false;

            foreach (Form form in _openForms)
            {
                if (form.Name == "gameMenu")
                {
                    gameSettings.MenuIsOpen = true;
                }
            }

            if (gameSettings.MenuIsOpen)
            {
                gameSettings.GamePaused = true;
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
                    _lastChangeTime = lastPUpNoclipChangeTime;
                }
                else
                {
                    gameSettings.GamePowerup = gamePowerup.None;
                    gameSettings.GamePowerupActive = false;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.PUpNoclipDeactivate);
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

            // Determine snake color
            if ((gameSettings.GamePowerup == gamePowerup.X2 && (_blinkCheckX2 == 1 || _blinkCheckX2 == 3 || _blinkCheckX2 == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.PointOnTick && (_blinkCheckPointTick == 1 || _blinkCheckPointTick == 3 || _blinkCheckPointTick == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.Slowmotion && (_blinkCheckSlowmo == 1 || _blinkCheckSlowmo == 3 || _blinkCheckSlowmo == 5)) ||
                (gameSettings.GamePowerup == gamePowerup.Noclip && (_blinkCheckNoclip == 1 || _blinkCheckNoclip == 3 || _blinkCheckNoclip == 5)))
            {
                gamePowerup = gamePowerup.None;
            }
            else
            {
                gamePowerup = gameSettings.GamePowerup;
            }
        }

        private void DetermineSnakeColor(int i, ref int rainbowColorIndex, ref int cnt)
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
                    gameSettings.snakeBodyColor = gameSettings.snakeRainbowColor[rainbowColorIndex]; // Body color

                    cnt++;
                    // Cycle through different color indexes
                    switch (rainbowColorIndex)
                    {
                        case 0:
                            if (cnt > (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                rainbowColorIndex = 1;
                                cnt = 0;
                            }
                            break;
                        case 1:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                rainbowColorIndex = 2;
                                cnt = 0;
                            }
                            break;
                        case 2:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                rainbowColorIndex = 3;
                                cnt = 0;
                            }
                            break;
                        case 3:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                rainbowColorIndex = 4;
                                cnt = 0;
                            }
                            break;
                        case 4:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                rainbowColorIndex = 5;
                                cnt = 0;
                            }
                            break;
                        case 5:
                            if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
                            {
                                rainbowColorIndex = 0;
                                cnt = 0;
                            }
                            break;
                        default:
                            throw new ArgumentException(
                                        "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                        "_rainbowColorIndex=" + rainbowColorIndex
                                        );
                    }

                    if (gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeStretched)
                    {
                        gameSettings.snakeBodyColor = gameSettings.snakeRainbowColor[rainbowColorIndex]; // Body color
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
            int rainbowColorIndex = 0;
            Graphics Canvas = e.Graphics;

            if (!gameSettings.GameOver)
            {
                // Draw snake head & body
                for (int i = 0; i < gameObject.Snake.Count; i++)
                {
                    if (gameSettings.DrawingMode == gameConstants.gameDrawingMode.drawingModeNormal || gameSettings.DrawingMode == gameConstants.gameDrawingMode.drawingModeRainbow)
                    {
                        DetermineSnakeColor(i, ref rainbowColorIndex, ref cnt);
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

        private void gameInterface_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameSettings.GameOver)
            {
                // Check if key input is a direction key
                if ((e.KeyCode == gameControls.dirRightKey || e.KeyCode == Keys.Right)
                    && ((currentTickDir != gameDirection.Left && currentTickDir != gameDirection.Right
                    && !gameSettings.GamePaused) || gameSettings.DevModeEnabled))
                {
                    gameSettings.directionHead = gameDirection.Right;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.SnakeChangeDir);
                }
                else if ((e.KeyCode == gameControls.dirLeftKey || e.KeyCode == Keys.Left)
                          && ((currentTickDir != gameDirection.Right && currentTickDir != gameDirection.Left
                          && !gameSettings.GamePaused) || gameSettings.DevModeEnabled))
                {
                    gameSettings.directionHead = gameDirection.Left;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.SnakeChangeDir);
                }
                else if ((e.KeyCode == gameControls.dirUpKey || e.KeyCode == Keys.Up)
                          && ((currentTickDir != gameDirection.Down && currentTickDir != gameDirection.Up
                          && !gameSettings.GamePaused) || gameSettings.DevModeEnabled))
                {
                    gameSettings.directionHead = gameDirection.Up;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.SnakeChangeDir);
                }
                else if ((e.KeyCode == gameControls.dirDownKey || e.KeyCode == Keys.Down)
                          && ((currentTickDir != gameDirection.Up && currentTickDir != gameDirection.Down
                          && !gameSettings.GamePaused) || gameSettings.DevModeEnabled))
                {
                    gameSettings.directionHead = gameDirection.Down;
                    gamecontroller.PlayGameSound(gameConstants.gameSound.SnakeChangeDir);
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
                    if (gameSettings.SavedPowerup != gamePowerup.None && !gameSettings.GamePowerupActive)
                    {
                        gameSettings.GamePowerup = gameSettings.SavedPowerup;
                        gameSettings.SavedPowerup = gamePowerup.None;

                        switch (gameSettings.GamePowerup)
                        {
                            case gamePowerup.X2:
                                lastPUpX2ChangeTime = currentTime;
                                lastPUpPointTickChangeTime = 0;
                                lastPUpSlowmoChangeTime = 0;
                                lastPUpNoclipChangeTime = 0;
                                gameSettings.GamePowerupActive = true;
                                gamecontroller.PlayGameSound(gameConstants.gameSound.PUpX2Activate);
                                break;
                            case gamePowerup.PointOnTick:
                                lastPUpX2ChangeTime = 0;
                                lastPUpPointTickChangeTime = currentTime;
                                lastPUpSlowmoChangeTime = 0;
                                lastPUpNoclipChangeTime = 0;
                                gameSettings.GamePowerupActive = true;
                                gamecontroller.PlayGameSound(gameConstants.gameSound.PUpPointTickActivate);
                                break;
                            case gamePowerup.Slowmotion:
                                lastPUpX2ChangeTime = 0;
                                lastPUpPointTickChangeTime = 0;
                                lastPUpSlowmoChangeTime = currentTime;
                                lastPUpNoclipChangeTime = 0;
                                gamecontroller.PlayGameSound(gameConstants.gameSound.PUpSlowmoActivate);
                                break;
                            case gamePowerup.Noclip:
                                lastPUpX2ChangeTime = 0;
                                lastPUpPointTickChangeTime = 0;
                                lastPUpSlowmoChangeTime = 0;
                                lastPUpNoclipChangeTime = currentTime;
                                gameSettings.GamePowerupActive = true;
                                gamecontroller.PlayGameSound(gameConstants.gameSound.PUpNoclipActivate);
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (gameSettings.DevModeEnabled)
                {
                    if (e.KeyCode == gameControls.modReloadSpritesKey)
                    {
                        gamecontroller.LoadAllGameSprites();
                    }
                }
                if (e.KeyCode == gameControls.modNoClipKey && !gameSettings.MenuIsOpen)
                {
                    ToggleNoClipModifier();
                }
            }
            if (gameSettings.GameOver || gameSettings.DevModeEnabled)
            {
                if (e.KeyCode == gameControls.modRestartKey)
                {
                    new gameSettings(false);
                    new gameControls(false);
                    gamecontroller.SetTimerInterval(gameTimer, gameSettings.Speed, true);
                    gameController.maxPosX = gamecontroller.GetMaxPosX(pictureBox);
                    gameController.maxPosY = gamecontroller.GetMaxPosY(pictureBox);
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
