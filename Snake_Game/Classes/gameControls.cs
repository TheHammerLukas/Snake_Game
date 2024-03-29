﻿using System;
using System.Windows.Forms;

namespace Snake_Game
{
    class gameControls
    {
        public static Keys dirUpKey { get; set; } // User configured Up key 
        public static Keys dirDownKey { get; set; } // User configured Down key
        public static Keys dirLeftKey { get; set; } // User configured Left key
        public static Keys dirRightKey { get; set; } // User configured Right key
        public static Keys modRestartKey { get; set; } // User configured Restart key
        public static Keys modBotKey { get; set; } // User configured Bot key
        public static Keys modSpeedKey { get; set; } // User configured Speed key
        public static Keys modPauseKey { get; set; } // User configured Pause key
        public static Keys modPowerupKey { get; set; } // User configured Powerup key
        public static Keys modNoClipKey { get; set; } // User configured NoClip key
        public static Keys modDevModeKey { get; private set; } // Hardcoded DevMode key; Keycode 'Oem5' => '^'
        public static Keys modReloadSpritesKey { get; private set; } // Hardcoded Reload Sprites key; Only enabled when DevMode is active
        public static Keys modGrowSnakeKey { get; private set; } // Hardcoded Grow Snake key; Only enabled when DevMode is active
        public static Keys modShrinkSnakeKey { get; private set; } // Hardcoded Shrink Snake key; Only enabled when DevMode is active
        public static Keys modLoadDevSettingsKey { get; private set; } // Hardcoded Load Dev Settings key; Only enabled when DevMode is active

        public gameControls(bool useStandard)
        {
            gameController gamecontroller = new gameController();

            initAllControls();

            // Only call readControlsXML if the values of it should be used
            if (!useStandard)
            {
                gamecontroller.readControlsXML();
            }
        }

        // Set key press event to key used in config
        public static bool ConvKeyPressToKeyConfig(Keys key, gameConstants.gameAction action)
        {
            Keys _key = key;
            gameConstants.gameAction _action = action;
            bool _retCode = true;

            if (_action != gameConstants.gameAction.None)
            {
                switch (_action)
                {
                    case gameConstants.gameAction.UpKey:
                        _retCode = true;
                        dirUpKey = _key;
                        break;
                    case gameConstants.gameAction.DownKey:
                        _retCode = true;
                        dirDownKey = _key;
                        break;
                    case gameConstants.gameAction.LeftKey:
                        _retCode = true;
                        dirLeftKey = _key;
                        break;
                    case gameConstants.gameAction.RightKey:
                        _retCode = true;
                        dirRightKey = _key;
                        break;
                    case gameConstants.gameAction.ResetKey:
                        _retCode = true;
                        modRestartKey = _key;
                        break;
                    case gameConstants.gameAction.PauseKey:
                        _retCode = true;
                        modPauseKey = _key;
                        break;
                    case gameConstants.gameAction.SpeedKey:
                        _retCode = true;
                        modSpeedKey = _key;
                        break;
                    case gameConstants.gameAction.BotKey:
                        _retCode = true;
                        modBotKey = _key;
                        break;
                    case gameConstants.gameAction.NoClipKey:
                        _retCode = true;
                        modNoClipKey = _key;
                        break;
                    case gameConstants.gameAction.PowerupKey:
                        _retCode = true;
                        modPowerupKey = _key;
                        break;
                    default:
                        _retCode = false;
                        MessageBox.Show(
                                    "Invalid key tried to be configured in \nplayerInput.ConvKeyPressToKeyConfig procedure!\nkey=" + _key + ";action=" + _action,
                                    "Error!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                    );
                        break;
                }
            }

            return _retCode;
        }

        public static void initAllControls()
        {
            foreach (gameConstants.gameAction action in Enum.GetValues(typeof(gameConstants.gameAction)))
            {
                initControls(action);
            }
        }

        // Initializes controls according to passed gameAction
        public static void initControls(gameConstants.gameAction action)
        {
            gameController gamecontroller = new gameController();
            gameConstants.gameAction _action = action;

            if (_action != gameConstants.gameAction.None)
            {
                switch (_action)
                {
                    case gameConstants.gameAction.UpKey:
                        dirUpKey = gamecontroller.getKey("W");
                        break;
                    case gameConstants.gameAction.DownKey:
                        dirDownKey = gamecontroller.getKey("S");
                        break;
                    case gameConstants.gameAction.LeftKey:
                        dirLeftKey = gamecontroller.getKey("A");
                        break;
                    case gameConstants.gameAction.RightKey:
                        dirRightKey = gamecontroller.getKey("D");
                        break;
                    case gameConstants.gameAction.ResetKey:
                        modRestartKey = gamecontroller.getKey("R");
                        break;
                    case gameConstants.gameAction.PauseKey:
                        modPauseKey = gamecontroller.getKey("P");
                        break;
                    case gameConstants.gameAction.SpeedKey:
                        modSpeedKey = gamecontroller.getKey("N");
                        break;
                    case gameConstants.gameAction.BotKey:
                        modBotKey = gamecontroller.getKey("B");
                        break;
                    case gameConstants.gameAction.DevModeKey:
                        modDevModeKey = gamecontroller.getKey("Oem5"); // Oem5 => '^'
                        break;
                    case gameConstants.gameAction.PowerupKey:
                        modPowerupKey = gamecontroller.getKey("E");
                        break;
                    case gameConstants.gameAction.NoClipKey:
                        modNoClipKey = gamecontroller.getKey("K");
                        break;
                    case gameConstants.gameAction.ReloadSpritesKey:
                        modReloadSpritesKey = gamecontroller.getKey("L");
                        break;
                    case gameConstants.gameAction.GrowSnakeKey:
                        modGrowSnakeKey = gamecontroller.getKey("X");
                        break;
                    case gameConstants.gameAction.ShrinkSnakeKey:
                        modShrinkSnakeKey = gamecontroller.getKey("Y");
                        break;
                    case gameConstants.gameAction.LoadDevSettingsKey:
                        modLoadDevSettingsKey = gamecontroller.getKey("O");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
