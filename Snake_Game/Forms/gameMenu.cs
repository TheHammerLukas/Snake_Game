﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class gameMenu : Form
    {
        private static gameAction gameAction = gameAction.None;

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

            bool _showError = false;

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

            gameSettings.ApplySettings(_newWidth, _newHeight, _newSpeed, _newGrowMultiplicator, _newPoints, _newPUpSpawnGap);

            gameSettings.GameOver = true;

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
            textBoxPUpSpawnGap.Text = Convert.ToString(gameSettings.PowerupSpawnGap);
        }

        // Reset the 'Settings' to their standard values
        private void buttonReset_Click(object sender, EventArgs e)
        {
            gameController gamecontroller = new gameController();

            if (tabControlMenu.SelectedTab == tabPageSettings)
            {
                new gameSettings(true);

                gamecontroller.writeSettingsXML();
            }
            else if (tabControlMenu.SelectedTab == tabPageControls)
            {
                new gameControls(true);

                gamecontroller.writeControlsXML();
            }
            else if (tabControlMenu.SelectedTab == tabPageColors)
            {
                gameSettings.InitAllColors();

                gamecontroller.writeSettingsXML();
            }
            else if(tabControlMenu.SelectedTab == tabPagePowerups)
            {

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
            if (tabControlMenu.SelectedTab == tabPageControls)
            {
                if (gameControls.ConvKeyPressToKeyConfig(e.KeyCode, gameAction))
                {
                    setMenuValues();
                }

                gameAction = gameAction.None;

                gameSettings.GameOver = true;
            }
        }

        private void buttonSetUpKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.UpKey;
        }

        private void buttonSetDownKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.DownKey;
        }

        private void buttonSetLeftKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.LeftKey;
        }

        private void buttonSetRightKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.RightKey;
        }

        private void buttonSetRestartKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.ResetKey;
        }

        private void buttonSetPauseKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.PauseKey;
        }

        private void buttonSetSpeedKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.SpeedKey;
        }

        private void buttonSetBotKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.BotKey;
        }

        private void buttonSetPowerupKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.PowerupKey;
        }

        private void buttonSetNoClipKey_Click(object sender, EventArgs e)
        {
            gameAction = gameAction.NoClipKey;
        }

        private void buttonResetUpKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.UpKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetDownKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.DownKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetLeftKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.LeftKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetRightKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.RightKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetRestartKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.ResetKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetPauseKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.PauseKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetSpeedKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.SpeedKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetBotKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.BotKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetPowerupKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.PowerupKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetNoClipKey_Click(object sender, EventArgs e)
        {
            gameControls.InitControls(gameAction.NoClipKey);

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

        private void ButtonResetHeadColor_Click(object sender, EventArgs e)
        {
            gameSettings.InitSnakeHeadColor(gameColor.snakeHeadNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void ButtonResetBodyColor_Click(object sender, EventArgs e)
        {
            gameSettings.InitSnakeBodyColor(gameColor.snakeBodyNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void ButtonResetFoodColor_Click(object sender, EventArgs e)
        {
            gameSettings.InitFoodColor(gameColor.foodNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        #endregion
    }
}
