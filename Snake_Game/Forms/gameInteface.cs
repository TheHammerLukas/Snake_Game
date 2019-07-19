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
        private int keyInputDelay = 1000; // 1000 = 1 second
        private gameDirection currentTickDir; // The direction the snake is heading at in the current game tick
        
        public gameInterface()
        {
            InitializeComponent();

            // Set settings to default
            gameSettings.InitAllColors();
            gameSettings gamesettings = new gameSettings(false, true);
            gameControls gamecontrols = new gameControls(false);
            gamecontroller = new gameController();
            gamecontroller.writeSettingsXML(); // Rewrite the settings .xml
            gamecontroller.writeControlsXML(); // Rewrite the controls .xml

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
            gamecontroller.SetGameOverFalse(labelGameStatus);
            gamecontroller.SetPowerup(labelCurrentPowerupValue, labelSavedPowerupValue, labelPowerupTimerValue, currentTime, 0);
            gamecontroller.StartGame();
            gamecontroller.SetHighScore(labelHighscoreValue);
            gamecontroller.GenerateFood();
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            currentTickDir = gameSettings.direction;
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

            switch (Powerup)
            {
                case gamePowerup.X2:
                    if (lastPUpX2ChangeTime >= currentTime - 30000)
                    {
                        _lastChangeTime = lastPUpX2ChangeTime;
                    }
                    else
                    {
                        gameSettings.GamePowerup = gamePowerup.None;
                        gameSettings.GamePowerupActive = false;
                    }
                    break;
                case gamePowerup.PointOnTick:
                    if (lastPUpPointTickChangeTime >= currentTime - 20000)
                    {
                        gameSettings.Score = gameSettings.Score + 50;
                        _lastChangeTime = lastPUpPointTickChangeTime;
                    }
                    else
                    {
                        gameSettings.GamePowerup = gamePowerup.None;
                        gameSettings.GamePowerupActive = false;
                    }
                    break;
                case gamePowerup.Slowmotion:
                    if (lastPUpSlowmoChangeTime >= currentTime - 10000)
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
                    }
                    break;
                case gamePowerup.Noclip:
                    if (lastPUpNoclipChangeTime >= currentTime - 15000)
                    {
                        _lastChangeTime = lastPUpNoclipChangeTime;
                    }
                    else
                    {
                        gameSettings.GamePowerup = gamePowerup.None;
                        gameSettings.GamePowerupActive = false;
                    }
                    break;
            }

            new gameController().SetPowerup(labelCurrentPowerupValue, labelSavedPowerupValue, labelPowerupTimerValue, currentTime, _lastChangeTime);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            int cnt = 0;
            if (!gameSettings.GameOver)
            {
                // Color of snake
                Brush _snakeColor;
                int _rainbowColorIndex = 0;

                // Draw snake head & body
                for (int i = 0; i < gameObject.Snake.Count; i++)
                {
                    // Decide the color of the snake
                    if (gameSettings.RainbowEnabled)
                    {
                        if (i == 0)
                        {
                            _snakeColor = Brushes.Black; // Head color
                        }
                        else
                        {
                            _snakeColor = gameSettings.snakeRainbowColor[_rainbowColorIndex]; // Body color

                            cnt ++;
                            // Cycle through different color indexes
                            switch (_rainbowColorIndex)
                            {
                                case 0:
                                    if (cnt > (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == rainbowMode.rainbowModeTiles)
                                    {
                                        _rainbowColorIndex = 1;
                                        cnt = 0;
                                    }
                                    break;
                                case 1:
                                    if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == rainbowMode.rainbowModeTiles)
                                    {
                                        _rainbowColorIndex = 2;
                                        cnt = 0;
                                    }
                                    break;
                                case 2:
                                    if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == rainbowMode.rainbowModeTiles)
                                    {
                                        _rainbowColorIndex = 3;
                                        cnt = 0;
                                    }
                                    break;
                                case 3:
                                    if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == rainbowMode.rainbowModeTiles)
                                    {
                                        _rainbowColorIndex = 4;
                                        cnt = 0;
                                    }
                                    break;
                                case 4:
                                    if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == rainbowMode.rainbowModeTiles)
                                    {
                                        _rainbowColorIndex = 5;
                                        cnt = 0;
                                    }
                                    break;
                                case 5:
                                    if (cnt >= (Convert.ToDouble(gameObject.Snake.Count) - 1) / 6 || gameSettings.RainbowMode == rainbowMode.rainbowModeTiles)
                                    {
                                        _rainbowColorIndex = 0;
                                        cnt = 0;
                                    }
                                    break;
                                default:
                                    throw new ArgumentException(
                                                "-E- Unspecified error in gameInterface.pictureBox_Paint procedure!",
                                                "_rainbowColorIndex=" + _rainbowColorIndex
                                                );
                            }

                            if (gameSettings.RainbowMode == rainbowMode.rainbowModeStretched)
                            {
                                _snakeColor = gameSettings.snakeRainbowColor[_rainbowColorIndex]; // Body color
                            }
                        }
                    }
                    else
                    {
                        switch (gameSettings.GamePowerup)
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
                        if (i == 0)
                        {
                            _snakeColor = gameSettings.snakeHeadColor; // Head color
                        }
                        else
                        {
                            _snakeColor = gameSettings.snakeBodyColor; // Body color
                        }
                    }

                    // Draw snake 
                    Canvas.FillRectangle
                    (
                        _snakeColor,
                        new Rectangle
                        (
                            gameObject.Snake[i].X * gameSettings.Width,
                            gameObject.Snake[i].Y * gameSettings.Height,
                            gameSettings.Width,
                            gameSettings.Height
                        )
                    );

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

                // Show game paused message
                if (gameSettings.GamePaused)
                {
                    string _gamePausedText = "Game paused!\nPress '" + gameControls.modPauseKey + "' to continue";
                    labelGameStatus.Text = _gamePausedText;
                    labelGameStatus.Visible = true;
                }
                else
                {
                    labelGameStatus.Visible = false;
                }
            }
            else // Show game over message
            {
                string _gameOverText = "Game Over!\nYour score is: " + gameSettings.Score + "\nPress '" + gameControls.modRestartKey + "' to try again";
                labelGameStatus.Text = _gameOverText;
                labelGameStatus.Visible = true;
            }
        }

        // To toggle the bot modifier
        private void ToggleBotModifier()
        {
            if (lastBotChangeTime <= currentTime - keyInputDelay)
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
            if (lastSpeedChangeTime <= currentTime - keyInputDelay)
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
            if (lastNoClipChangeTime <= currentTime - keyInputDelay)
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
                    gameSettings.direction = gameDirection.Right;
                    gamecontroller.PlayGameSound(gameSound.SnakeChangeDir);
                }
                else if ((e.KeyCode == gameControls.dirLeftKey || e.KeyCode == Keys.Left)
                          && ((currentTickDir != gameDirection.Right && currentTickDir != gameDirection.Left
                          && !gameSettings.GamePaused) || gameSettings.DevModeEnabled))
                {
                    gameSettings.direction = gameDirection.Left;
                    gamecontroller.PlayGameSound(gameSound.SnakeChangeDir);
                }
                else if ((e.KeyCode == gameControls.dirUpKey || e.KeyCode == Keys.Up)
                          && ((currentTickDir != gameDirection.Down && currentTickDir != gameDirection.Up
                          && !gameSettings.GamePaused) || gameSettings.DevModeEnabled))
                {
                    gameSettings.direction = gameDirection.Up;
                    gamecontroller.PlayGameSound(gameSound.SnakeChangeDir);
                }
                else if ((e.KeyCode == gameControls.dirDownKey || e.KeyCode == Keys.Down)
                          && ((currentTickDir != gameDirection.Up && currentTickDir != gameDirection.Down
                          && !gameSettings.GamePaused) || gameSettings.DevModeEnabled))
                {
                    gameSettings.direction = gameDirection.Down;
                    gamecontroller.PlayGameSound(gameSound.SnakeChangeDir);
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
                else if (e.KeyCode == gameControls.modPauseKey && !gameSettings.MenuIsOpen && lastPauseChangeTime <= currentTime - keyInputDelay)
                {
                    gameSettings.GamePaused = gameSettings.GamePaused ? false : true;
                    lastPauseChangeTime = currentTime;
                }
                else if (e.KeyCode == gameControls.modDevModeKey && !gameSettings.MenuIsOpen && lastDevModeChangeTime <= currentTime - keyInputDelay)
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
                                break;
                            case gamePowerup.PointOnTick:
                                lastPUpX2ChangeTime = 0;
                                lastPUpPointTickChangeTime = currentTime;
                                lastPUpSlowmoChangeTime = 0;
                                lastPUpNoclipChangeTime = 0;
                                gameSettings.GamePowerupActive = true;
                                break;
                            case gamePowerup.Slowmotion:
                                lastPUpX2ChangeTime = 0;
                                lastPUpPointTickChangeTime = 0;
                                lastPUpSlowmoChangeTime = currentTime;
                                lastPUpNoclipChangeTime = 0;
                                break;
                            case gamePowerup.Noclip:
                                lastPUpX2ChangeTime = 0;
                                lastPUpPointTickChangeTime = 0;
                                lastPUpSlowmoChangeTime = 0;
                                lastPUpNoclipChangeTime = currentTime;
                                gameSettings.GamePowerupActive = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (gameSettings.DevModeEnabled)
                {
                    
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
                    gamecontroller.SetGameOverFalse(labelGameStatus);
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
