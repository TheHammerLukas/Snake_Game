using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class gameMenu : Form
    {
        private static gameAction gameaction = gameAction.None;

        public gameMenu()
        {
            InitializeComponent();
            setMenuValues();
        }

        #region General menu functions

        // Apply the new configured settings
        private void buttonApply_Click(object sender, EventArgs e)
        {
            int _newWidth = gameSettings.Width;
            int _newHeight = gameSettings.Height;
            int _newSpeed = gameSettings.Speed;
            int _newGrowMultiplicator = gameSettings.GrowMultiplicator;
            int _newPoints = gameSettings.Points;
            int _newPUpSpawnGap = gameSettings.PowerupSpawnGap;
            int _newPUpX2Duration = gameSettings.PowerupDurationX2;
            int _newPUpPointTickDuration = gameSettings.PowerupDurationPointTick;
            int _newPUpSlowmotionDuration = gameSettings.PowerupDurationSlowmo;
            int _newPUpNoclipDuration = gameSettings.PowerupDurationNoclip;

            bool _showError = false;

            if (tabControlMenu.SelectedTab == tabPageSettings || tabControlMenu.SelectedTab == tabPageColors || tabControlMenu.SelectedTab == tabPagePowerups)
            { 
                _showError = !int.TryParse(textBoxWidth.Text, out _newWidth);
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxHeight.Text, out _newHeight);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxSpeed.Text, out _newSpeed);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxGrowMultiplicator.Text, out _newGrowMultiplicator);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPoints.Text, out _newPoints);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpSpawnGap.Text, out _newPUpSpawnGap);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpX2Duration.Text, out _newPUpX2Duration);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpPointTickDuration.Text, out _newPUpPointTickDuration);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpSlowmoDuration.Text, out _newPUpSlowmotionDuration);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpNoclipDuration.Text, out _newPUpNoclipDuration);
                }

                gameSettings.ApplySettings(_newWidth, _newHeight, _newSpeed, _newGrowMultiplicator, _newPoints,
                                           _newPUpSpawnGap, _newPUpX2Duration, _newPUpPointTickDuration, _newPUpSlowmotionDuration, _newPUpNoclipDuration);

                gameSettings.GameOver = true;
            }
            else if (tabControlMenu.SelectedTab == tabPageControls)
            {
                new gameController().writeControlsXML();
            }

            setMenuValues();

            if (_showError)
            {
                MessageBox.Show(
                                "Not all changes could be applied successfully!",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                               );
            }
        }

        // Set values of the 'Settings' textboxes
        private void setMenuValues()
        {
            gameController gamecontroller = new gameController();

            // Settings tab
            textBoxWidth.Text = Convert.ToString(gameSettings.Width);
            textBoxHeight.Text = Convert.ToString(gameSettings.Height);
            textBoxSpeed.Text = Convert.ToString(gameSettings.Speed);
            textBoxGrowMultiplicator.Text = Convert.ToString(gameSettings.GrowMultiplicator);
            textBoxPoints.Text = Convert.ToString(gameSettings.Points);
            // Controls tab
            textBoxUpKey.Text = Convert.ToString(gameControls.dirUpKey);
            textBoxDownKey.Text = Convert.ToString(gameControls.dirDownKey);
            textBoxLeftKey.Text = Convert.ToString(gameControls.dirLeftKey);
            textBoxRightKey.Text = Convert.ToString(gameControls.dirRightKey);
            textBoxRestartKey.Text = Convert.ToString(gameControls.modRestartKey);
            textBoxBotKey.Text = Convert.ToString(gameControls.modBotKey);
            textBoxSpeedKey.Text = Convert.ToString(gameControls.modSpeedKey);
            textBoxPauseKey.Text = Convert.ToString(gameControls.modPauseKey);
            textBoxPowerupKey.Text = Convert.ToString(gameControls.modPowerupKey);
            textBoxNoClipKey.Text = Convert.ToString(gameControls.modNoClipKey);
            // Colors tab
            labelSnakeHeadPrev.BackColor = (gameSettings.snakeHeadNormalColor as SolidBrush).Color;
            labelSnakeBodyPrev.BackColor = (gameSettings.snakeBodyNormalColor as SolidBrush).Color;
            labelFoodPrev.BackColor = (gameSettings.foodNormalColor as SolidBrush).Color;
            checkBoxRainbowColor.Checked = gameSettings.RainbowEnabled;
            if (gameSettings.RainbowMode == rainbowMode.rainbowModeTiles)
            {
                buttonSwitchRainbowMode.Text = "Switch rainbow mode to 'Stretched'";
            }
            else if (gameSettings.RainbowMode == rainbowMode.rainbowModeStretched)
            {
                buttonSwitchRainbowMode.Text = "Switch rainbow mode to 'Tiles'";
            }
            // Powerups tab
            textBoxPUpSpawnGap.Text = Convert.ToString(gameSettings.PowerupSpawnGapConfigured);
            textBoxPUpX2Duration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationX2, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpPointTickDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationPointTick, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpSlowmoDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationSlowmo, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpNoclipDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationNoclip, gameConstants.milliseconds, gameConstants.seconds));
            labelSnakeHeadX2Prev.BackColor = (gameSettings.snakeHeadPUpX2Color as SolidBrush).Color;
            labelSnakeBodyX2Prev.BackColor = (gameSettings.snakeBodyPUpX2Color as SolidBrush).Color;
            labelFoodX2Prev.BackColor = (gameSettings.foodPUpX2Color as SolidBrush).Color;
            labelSnakeHeadPointTickPrev.BackColor = (gameSettings.snakeHeadPUpPointTickColor as SolidBrush).Color;
            labelSnakeBodyPointTickPrev.BackColor = (gameSettings.snakeBodyPUpPointTickColor as SolidBrush).Color;
            labelFoodPointTickPrev.BackColor = (gameSettings.foodPUpPointTickColor as SolidBrush).Color;
            labelSnakeHeadSlowmoPrev.BackColor = (gameSettings.snakeHeadPUpSlowmoColor as SolidBrush).Color;
            labelSnakeBodySlowmoPrev.BackColor = (gameSettings.snakeBodyPUpSlowmoColor as SolidBrush).Color;
            labelFoodSlowmoPrev.BackColor = (gameSettings.foodPUpSlowmoColor as SolidBrush).Color;
            labelSnakeHeadNoclipPrev.BackColor = (gameSettings.snakeHeadPUpNoclipColor as SolidBrush).Color;
            labelSnakeBodyNoclipPrev.BackColor = (gameSettings.snakeBodyPUpNoclipColor as SolidBrush).Color;
            labelFoodNoclipPrev.BackColor = (gameSettings.foodPUpNoclipColor as SolidBrush).Color;
        }

        // Reset the 'Settings' to their standard values
        private void buttonReset_Click(object sender, EventArgs e)
        {
            gameController gamecontroller = new gameController();

            if (tabControlMenu.SelectedTab == tabPageSettings)
            {
                new gameSettings(true);
                gameSettings.GameOver = true;

                gamecontroller.writeSettingsXML();
            }
            else if (tabControlMenu.SelectedTab == tabPageControls)
            {
                new gameControls(true);

                gamecontroller.writeControlsXML();
            }
            else if (tabControlMenu.SelectedTab == tabPageColors)
            {
                gameSettings.initAllColors();

                gamecontroller.writeSettingsXML();
            }
            else if(tabControlMenu.SelectedTab == tabPagePowerups)
            {
                gameSettings.initPowerupSpawnGap(true);
                gameSettings.initAllPowerupDuration();
                gameSettings.GameOver = true;

                gamecontroller.writeSettingsXML();
            }

            setMenuValues();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Control functions

        private void gameMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControlMenu.SelectedTab == tabPageControls && gameaction != gameAction.None)
            {
                if (gameControls.ConvKeyPressToKeyConfig(e.KeyCode, gameaction))
                {
                    setMenuValues();
                }

                gameaction = gameAction.None;
            }
        }

        private void buttonSetUpKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.UpKey;
        }

        private void buttonSetDownKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.DownKey;
        }

        private void buttonSetLeftKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.LeftKey;
        }

        private void buttonSetRightKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.RightKey;
        }

        private void buttonSetRestartKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.ResetKey;
        }

        private void buttonSetPauseKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.PauseKey;
        }

        private void buttonSetSpeedKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.SpeedKey;
        }

        private void buttonSetBotKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.BotKey;
        }

        private void buttonSetPowerupKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.PowerupKey;
        }

        private void buttonSetNoClipKey_Click(object sender, EventArgs e)
        {
            gameaction = gameAction.NoClipKey;
        }

        private void buttonResetUpKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.UpKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetDownKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.DownKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetLeftKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.LeftKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetRightKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.RightKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetRestartKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.ResetKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetPauseKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.PauseKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetSpeedKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.SpeedKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetBotKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.BotKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetPowerupKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.PowerupKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetNoClipKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameAction.NoClipKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        #endregion

        #region Color functions

        private void checkBoxRainbowColor_Click(object sender, EventArgs e)
        {
            gameSettings.RainbowEnabled = checkBoxRainbowColor.Checked;

            new gameController().writeSettingsXML();
        }

        private void switchRainbowMode()
        {
            gameSettings.RainbowMode = gameSettings.RainbowMode == rainbowMode.rainbowModeTiles ? rainbowMode.rainbowModeStretched : rainbowMode.rainbowModeTiles;
        }

        private void buttonSwitchRainbowMode_Click(object sender, EventArgs e)
        {
            switchRainbowMode();

            setMenuValues();
        }

        private void buttonSetHeadColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeHeadNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodyColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeBodyNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.foodNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameColor.snakeHeadNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodyColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameColor.snakeBodyNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodColor_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameColor.foodNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        #endregion

        #region Powerup functions

        private void buttonSetHeadX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeHeadPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodyX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeBodyPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.foodPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetHeadPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeHeadPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodyPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeBodyPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.foodPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetHeadSlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeHeadPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodySlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeBodyPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodSlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.foodPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetHeadNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeHeadPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodyNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.snakeBodyPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameColor.foodPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameColor.snakeHeadPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodyX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameColor.snakeBodyPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameColor.foodPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameColor.snakeHeadPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodyPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameColor.snakeBodyPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameColor.foodPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadSlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameColor.snakeHeadPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodySlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameColor.snakeBodyPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodSlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameColor.foodPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameColor.snakeHeadPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodyNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameColor.snakeBodyPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameColor.foodPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        #endregion
    }
}
