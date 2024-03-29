﻿using CustomWinformsControls.GraphicsTooltip;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class gameMenu : Form
    {
        private static gameConstants.gameAction gameaction = gameConstants.gameAction.None;

        private static GraphicsTooltip graphicstooltipSpritesPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePath));
        private static GraphicsTooltip graphicstooltipSpritesX2Path = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpX2Path));
        private static GraphicsTooltip graphicstooltipSpritesPointTickPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickPath));
        private static GraphicsTooltip graphicstooltipSpritesSlowmoPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpSlowmotionPath));
        private static GraphicsTooltip graphicstooltipSpritesNoclipPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpNoclipPath));
        private static GraphicsTooltip graphicstooltipSpritesX2PointTickPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpX2PointTickPath));
        private static GraphicsTooltip graphicstooltipSpritesX2SlowmoPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath));
        private static GraphicsTooltip graphicstooltipSpritesX2NoclipPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpX2NoclipPath));
        private static GraphicsTooltip graphicstooltipSpritesPointTickSlowmoPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath));
        private static GraphicsTooltip graphicstooltipSpritesPointTickNoclipPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath));
        private static GraphicsTooltip graphicstooltipSpritesSlowmoNoclipPath = new GraphicsTooltip(Image.FromFile(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath));

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
            int _newPUpX2PointTickDuration = gameSettings.PowerupDurationX2PointTick;
            int _newPUpX2SlowmoDuration = gameSettings.PowerupDurationX2Slowmo;
            int _newPUpX2NoclipDuration = gameSettings.PowerupDurationX2Noclip;
            int _newPUpPointTickSlowmoDuration = gameSettings.PowerupDurationPointTickSlowmo;
            int _newPUpPointTickNoclipDuration = gameSettings.PowerupDurationPointTickNoclip;
            int _newPUpSlowmoNoclipDuration = gameSettings.PowerupDurationSlowmoNoclip;

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
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpX2PointTickDuration.Text, out _newPUpX2PointTickDuration);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpX2SlowmoDuration.Text, out _newPUpX2SlowmoDuration);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpX2NoclipDuration.Text, out _newPUpX2NoclipDuration);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpPointTickSlowmoDuration.Text, out _newPUpPointTickSlowmoDuration);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpPointTickNoclipDuration.Text, out _newPUpPointTickNoclipDuration);
                }
                if (!_showError)
                {
                    _showError = !int.TryParse(textBoxPUpSlowmoNoclipDuration.Text, out _newPUpSlowmoNoclipDuration);
                }

                gameSettings.ApplySettings(_newWidth, _newHeight, _newSpeed, _newGrowMultiplicator, _newPoints,
                                           _newPUpSpawnGap, _newPUpX2Duration, _newPUpPointTickDuration, _newPUpSlowmotionDuration, _newPUpNoclipDuration,
                                           _newPUpX2PointTickDuration, _newPUpX2SlowmoDuration, _newPUpX2NoclipDuration, _newPUpPointTickSlowmoDuration, _newPUpPointTickNoclipDuration, 
                                           _newPUpSlowmoNoclipDuration);

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
            switch (gameSettings.DrawingMode)
            {
                case gameConstants.gameDrawingMode.drawingModeNormal:
                    radioButtongameDrawingModeNormal.Checked = true;
                    break;
                case gameConstants.gameDrawingMode.drawingModeRainbow:
                    radioButtongameDrawingModeRainbow.Checked = true;
                    break;
                case gameConstants.gameDrawingMode.drawingModeSprite:
                    radioButtongameDrawingModeSprite.Checked = true;
                    break;
                default:
                    break;
            }
            if (gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles)
            {
                buttonSwitchRainbowMode.Text = "Switch rainbow mode to 'Stretched'";
            }
            else if (gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeStretched)
            {
                buttonSwitchRainbowMode.Text = "Switch rainbow mode to 'Tiles'";
            }
            // Powerups tab
            textBoxPUpSpawnGap.Text = Convert.ToString(gameSettings.PowerupSpawnGapConfigured);
            textBoxPUpX2Duration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationX2, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpPointTickDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationPointTick, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpSlowmoDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationSlowmo, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpNoclipDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationNoclip, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpX2PointTickDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationX2PointTick, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpX2SlowmoDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationX2Slowmo, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpX2NoclipDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationX2Noclip, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpPointTickSlowmoDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationPointTickSlowmo, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpPointTickNoclipDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationPointTickNoclip, gameConstants.milliseconds, gameConstants.seconds));
            textBoxPUpSlowmoNoclipDuration.Text = Convert.ToString(gamecontroller.ConvTime(gameSettings.PowerupDurationSlowmoNoclip, gameConstants.milliseconds, gameConstants.seconds));
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
            // Savefiles tab
            labelControlsXmlPath.Text = Properties.Settings.Default.controlsXmlPath;
            labelSettingsXmlPath.Text = Properties.Settings.Default.settingsXmlPath;
            labelScoreXmlPath.Text = Properties.Settings.Default.scoreXmlPath;
            graphicstooltipSpritesPath.ReloadToolTip(labelSavefilesSpritesPath, Image.FromFile(Properties.Settings.Default.gameSpritePath));
            graphicstooltipSpritesX2Path.ReloadToolTip(labelSavefilesSpritesX2Path, Image.FromFile(Properties.Settings.Default.gameSpritePUpX2Path));
            graphicstooltipSpritesPointTickPath.ReloadToolTip(labelSavefilesSpritesPointTickPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickPath));
            graphicstooltipSpritesSlowmoPath.ReloadToolTip(labelSavefilesSpritesSlowmotionPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpSlowmotionPath));
            graphicstooltipSpritesNoclipPath.ReloadToolTip(labelSavefilesSpritesNoclipPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpNoclipPath));
            graphicstooltipSpritesX2PointTickPath.ReloadToolTip(labelSavefilesSpritesX2PointTickPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpX2PointTickPath));
            graphicstooltipSpritesX2SlowmoPath.ReloadToolTip(labelSavefilesSpritesX2SlowmotionPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath));
            graphicstooltipSpritesX2NoclipPath.ReloadToolTip(labelSavefilesSpritesX2NoclipPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpX2NoclipPath));
            graphicstooltipSpritesPointTickSlowmoPath.ReloadToolTip(labelSavefilesSpritesPointTickSlowmotionPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath));
            graphicstooltipSpritesPointTickNoclipPath.ReloadToolTip(labelSavefilesSpritesPointTickNoclipPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath));
            graphicstooltipSpritesSlowmoNoclipPath.ReloadToolTip(labelSavefilesSpritesSlowmotionNoclipPath, Image.FromFile(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath));
            labelSavefilesSpritesPath.Text = Properties.Settings.Default.gameSpritePath;
            labelSavefilesSpritesPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePath);
            labelSavefilesSpritesX2Path.Text = Properties.Settings.Default.gameSpritePUpX2Path;
            labelSavefilesSpritesX2Path.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpX2Path);
            labelSavefilesSpritesPointTickPath.Text = Properties.Settings.Default.gameSpritePUpPointTickPath;
            labelSavefilesSpritesPointTickPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickPath);
            labelSavefilesSpritesSlowmotionPath.Text = Properties.Settings.Default.gameSpritePUpSlowmotionPath;
            labelSavefilesSpritesSlowmotionPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpSlowmotionPath);
            labelSavefilesSpritesNoclipPath.Text = Properties.Settings.Default.gameSpritePUpNoclipPath;
            labelSavefilesSpritesNoclipPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpNoclipPath);
            labelSavefilesSpritesX2PointTickPath.Text = Properties.Settings.Default.gameSpritePUpX2PointTickPath;
            labelSavefilesSpritesX2PointTickPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpX2PointTickPath);
            labelSavefilesSpritesX2SlowmotionPath.Text = Properties.Settings.Default.gameSpritePUpX2SlowmotionPath;
            labelSavefilesSpritesX2SlowmotionPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath);
            labelSavefilesSpritesX2NoclipPath.Text = Properties.Settings.Default.gameSpritePUpX2NoclipPath;
            labelSavefilesSpritesX2NoclipPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpX2NoclipPath);
            labelSavefilesSpritesPointTickSlowmotionPath.Text = Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath;
            labelSavefilesSpritesPointTickSlowmotionPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath);
            labelSavefilesSpritesPointTickNoclipPath.Text = Properties.Settings.Default.gameSpritePUpPointTickNoclipPath;
            labelSavefilesSpritesPointTickNoclipPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath);
            labelSavefilesSpritesSlowmotionNoclipPath.Text = Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath;
            labelSavefilesSpritesSlowmotionNoclipPath.Tag = Image.FromFile(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath);
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
            else if (tabControlMenu.SelectedTab == tabPagePowerups)
            {
                gameSettings.initPowerupSpawnGap(true);
                gameSettings.initAllPowerupDuration();
                gameSettings.GameOver = true;

                gamecontroller.writeSettingsXML();
            }
            else if (tabControlMenu.SelectedTab == tabPageSavefiles)
            {
                gamecontroller.ResetAllGameSprites();
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
            if (tabControlMenu.SelectedTab == tabPageControls && gameaction != gameConstants.gameAction.None)
            {
                if (gameControls.ConvKeyPressToKeyConfig(e.KeyCode, gameaction))
                {
                    setMenuValues();
                }

                gameaction = gameConstants.gameAction.None;
            }
        }

        private void buttonSetUpKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.UpKey;
        }

        private void buttonSetDownKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.DownKey;
        }

        private void buttonSetLeftKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.LeftKey;
        }

        private void buttonSetRightKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.RightKey;
        }

        private void buttonSetRestartKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.ResetKey;
        }

        private void buttonSetPauseKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.PauseKey;
        }

        private void buttonSetSpeedKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.SpeedKey;
        }

        private void buttonSetBotKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.BotKey;
        }

        private void buttonSetPowerupKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.PowerupKey;
        }

        private void buttonSetNoClipKey_Click(object sender, EventArgs e)
        {
            gameaction = gameConstants.gameAction.NoClipKey;
        }

        private void buttonResetUpKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.UpKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetDownKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.DownKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetLeftKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.LeftKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetRightKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.RightKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetRestartKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.ResetKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetPauseKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.PauseKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetSpeedKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.SpeedKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetBotKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.BotKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetPowerupKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.PowerupKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        private void buttonResetNoClipKey_Click(object sender, EventArgs e)
        {
            gameControls.initControls(gameConstants.gameAction.NoClipKey);

            setMenuValues();

            new gameController().writeControlsXML();
        }

        #endregion

        #region Color functions

        private void radioButtongameDrawingMode_Click(object sender, EventArgs e)
        {
            if (radioButtongameDrawingModeNormal.Checked)
            {
                gameSettings.DrawingMode = gameConstants.gameDrawingMode.drawingModeNormal;
            }
            else if (radioButtongameDrawingModeRainbow.Checked)
            {
                gameSettings.DrawingMode = gameConstants.gameDrawingMode.drawingModeRainbow;
            }
            else if (radioButtongameDrawingModeSprite.Checked)
            {
                gameSettings.DrawingMode = gameConstants.gameDrawingMode.drawingModeSprite;
            }

            new gameController().writeSettingsXML();
        }

        private void switchRainbowMode()
        {
            gameSettings.RainbowMode = gameSettings.RainbowMode == gameConstants.rainbowMode.rainbowModeTiles ? 
                                       gameConstants.rainbowMode.rainbowModeStretched : gameConstants.rainbowMode.rainbowModeTiles;
        }

        private void buttonSwitchRainbowMode_Click(object sender, EventArgs e)
        {
            switchRainbowMode();

            setMenuValues();
        }

        private void buttonSetHeadColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeHeadNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodyColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeBodyNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.foodNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameConstants.gameColor.snakeHeadNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodyColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameConstants.gameColor.snakeBodyNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodColor_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameConstants.gameColor.foodNormalColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        #endregion

        #region Powerup functions

        private void buttonSetHeadX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeHeadPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodyX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeBodyPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.foodPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetHeadPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeHeadPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodyPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeBodyPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.foodPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetHeadSlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeHeadPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodySlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeBodyPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodSlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.foodPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetHeadNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeHeadPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetBodyNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.snakeBodyPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonSetFoodNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.PickColor(gameConstants.gameColor.foodPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameConstants.gameColor.snakeHeadPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodyX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameConstants.gameColor.snakeBodyPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodX2Color_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameConstants.gameColor.foodPUpX2Color);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameConstants.gameColor.snakeHeadPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodyPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameConstants.gameColor.snakeBodyPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodPointTickColor_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameConstants.gameColor.foodPUpPointTickColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadSlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameConstants.gameColor.snakeHeadPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodySlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameConstants.gameColor.snakeBodyPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodSlowmoColor_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameConstants.gameColor.foodPUpSlowmoColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetHeadNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeHeadColor(gameConstants.gameColor.snakeHeadPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetBodyNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.initSnakeBodyColor(gameConstants.gameColor.snakeBodyPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        private void buttonResetFoodNoclipColor_Click(object sender, EventArgs e)
        {
            gameSettings.initFoodColor(gameConstants.gameColor.foodPUpNoclipColor);

            setMenuValues();

            new gameController().writeSettingsXML();
        }

        #endregion

        #region Save File functions

        private void ButtonOpenFileControls_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.controlsXML);
            setMenuValues();
        }

        private void ButtonOpenFileSettings_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.settingsXML);
            setMenuValues();
        }

        private void ButtonOpenFileScore_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.scoreXML);
            setMenuValues();
        }

        private void ButtonOpenFileSprites_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSprites);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpX2_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpX2);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpPointTick_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpPointTick);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpSlowmotion_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpSlowmotion);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpNoclip_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpNoclip);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpX2PointTick_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpX2PointTick);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpX2Slowmotion_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpX2Slowmotion);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpX2Noclip_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpX2Noclip);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpPointTickSlowmotion_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpPointTickSlowmotion);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpPointTickNoclip_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpPointTickNoclip);
            setMenuValues();
        }

        private void ButtonOpenFileSpritesPUpSlowmotionNoclip_Click(object sender, EventArgs e)
        {
            new gameController().OpenFileDialog(gameConstants.gameSpritesPUpSlowmotionNoclip);
            setMenuValues();
        }

        private void ButtonSaveFileControls_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.controlsXML);
            setMenuValues();
        }

        private void ButtonSaveFileSettings_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.settingsXML);
            setMenuValues();
        }

        private void ButtonSaveFileScore_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.scoreXML);
            setMenuValues();
        }

        private void ButtonSaveFileSprites_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSprites);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpX2_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpX2);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpPointTick_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpPointTick);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpSlowmotion_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpSlowmotion);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpNoclip_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpNoclip);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpX2PointTick_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpX2PointTick);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpX2Slowmotion_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpX2Slowmotion);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpX2Noclip_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpX2Noclip);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpPointTickSlowmotion_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpPointTickSlowmotion);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpPointTickNoclip_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpPointTickNoclip);
            setMenuValues();
        }

        private void ButtonSaveFileSpritesPUpSlowmotionNoclip_Click(object sender, EventArgs e)
        {
            new gameController().SaveFileDialog(gameConstants.gameSpritesPUpSlowmotionNoclip);
            setMenuValues();
        }

        #endregion
    }
}
