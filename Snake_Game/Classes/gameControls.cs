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

        public gameControls(bool useStandard)
        {
            gameController gamecontroller = new gameController();

            foreach (gameAction action in Enum.GetValues(typeof(gameAction)))
            {
                InitControls(action);
            }

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

        // Initializes controls according to passed gameAction
        public static void InitControls(gameAction action)
        {
            gameAction _action = action;
            if (_action != gameAction.None)
            {
                switch (_action)
                {
                    case gameAction.UpKey:
                        dirUpKey = (Keys)Enum.Parse(typeof(Keys), "W", true);
                        break;
                    case gameAction.DownKey:
                        dirDownKey = (Keys)Enum.Parse(typeof(Keys), "S", true);
                        break;
                    case gameAction.LeftKey:
                        dirLeftKey = (Keys)Enum.Parse(typeof(Keys), "A", true);
                        break;
                    case gameAction.RightKey:
                        dirRightKey = (Keys)Enum.Parse(typeof(Keys), "D", true);
                        break;
                    case gameAction.ResetKey:
                        modRestartKey = (Keys)Enum.Parse(typeof(Keys), "R", true);
                        break;
                    case gameAction.PauseKey:
                        modPauseKey = (Keys)Enum.Parse(typeof(Keys), "P", true);
                        break;
                    case gameAction.SpeedKey:
                        modSpeedKey = (Keys)Enum.Parse(typeof(Keys), "N", true);
                        break;
                    case gameAction.BotKey:
                        modBotKey = (Keys)Enum.Parse(typeof(Keys), "B", true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
