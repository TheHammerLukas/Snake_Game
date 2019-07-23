using System;
using System.Windows.Forms;

namespace Snake_Game
{
    class gameControls
    {
        public static Keys dirUpKey         { get; set; } // User configured Up key 
        public static Keys dirDownKey       { get; set; } // User configured Down key
        public static Keys dirLeftKey       { get; set; } // User configured Left key
        public static Keys dirRightKey      { get; set; } // User configured Right key
        public static Keys modRestartKey    { get; set; } // User configured Restart key
        public static Keys modBotKey        { get; set; } // User configured Bot key
        public static Keys modSpeedKey      { get; set; } // User configured Speed key
        public static Keys modPauseKey      { get; set; } // User configured Pause key
        public static Keys modPowerupKey    { get; set; } // User configured Powerup key
        public static Keys modNoClipKey     { get; set; } // User configured NoClip key
        public static Keys modDevModeKey    { get; private set; } // Hardcoded DevMode key; Keycode 'Oem5' => '^'

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
        public static bool ConvKeyPressToKeyConfig(Keys key, gameAction action)
        {
            Keys _key = key;
            gameAction _action = action;
            bool _retCode = true;

            if (_action != gameAction.None)
            {
                try
                {
                    switch (_action)
                    {
                        case gameAction.UpKey:
                            _retCode = true;
                            dirUpKey = _key;
                            break;
                        case gameAction.DownKey:
                            _retCode = true;
                            dirDownKey = _key;
                            break;
                        case gameAction.LeftKey:
                            _retCode = true;
                            dirLeftKey = _key;
                            break;
                        case gameAction.RightKey:
                            _retCode = true;
                            dirRightKey = _key;
                            break;
                        case gameAction.ResetKey:
                            _retCode = true;
                            modRestartKey = _key;
                            break;
                        case gameAction.PauseKey:
                            _retCode = true;
                            modPauseKey = _key;
                            break;
                        case gameAction.SpeedKey:
                            _retCode = true;
                            modSpeedKey = _key;
                            break;
                        case gameAction.BotKey:
                            _retCode = true;
                            modBotKey = _key;
                            break;
                        case gameAction.NoClipKey:
                            _retCode = true;
                            modNoClipKey = _key;
                            break;
                        case gameAction.PowerupKey:
                            _retCode = true;
                            modPowerupKey = _key;
                            break;
                    default:
                            _retCode = true;
                            break;
                    }
                }
                catch (Exception)
                {
                    _retCode = false;
                    MessageBox.Show(
                                "Invalid key tried to be configured in \nplayerInput.ConvKeyPressToKeyConfig procedure!\nkey=" + _key + ";action=" + _action,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                }
            }

            return _retCode;
        }

        public static void initAllControls()
        {
            foreach (gameAction action in Enum.GetValues(typeof(gameAction)))
            {
                initControls(action);
            }
        }

        // Initializes controls according to passed gameAction
        public static void initControls(gameAction action)
        {
            gameController gamecontroller = new gameController();
            gameAction _action = action;

            if (_action != gameAction.None)
            {
                switch (_action)
                {
                    case gameAction.UpKey:
                        dirUpKey = gamecontroller.getKey("W");
                        break;
                    case gameAction.DownKey:
                        dirDownKey = gamecontroller.getKey("S");
                        break;
                    case gameAction.LeftKey:
                        dirLeftKey = gamecontroller.getKey("A");
                        break;
                    case gameAction.RightKey:
                        dirRightKey = gamecontroller.getKey("D");
                        break;
                    case gameAction.ResetKey:
                        modRestartKey = gamecontroller.getKey("R");
                        break;
                    case gameAction.PauseKey:
                        modPauseKey = gamecontroller.getKey("P");
                        break;
                    case gameAction.SpeedKey:
                        modSpeedKey = gamecontroller.getKey("N");
                        break;
                    case gameAction.BotKey:
                        modBotKey = gamecontroller.getKey("B");
                        break;
                    case gameAction.DevModeKey:
                        modDevModeKey = gamecontroller.getKey("Oem5"); // Oem5 => '^'
                        break;
                    case gameAction.PowerupKey:
                        modPowerupKey = gamecontroller.getKey("E");
                        break;
                    case gameAction.NoClipKey:
                        modNoClipKey = gamecontroller.getKey("K");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
