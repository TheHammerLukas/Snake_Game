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

            dirUpKey = (Keys)Enum.Parse(typeof(Keys), "W", true);
            dirDownKey = (Keys)Enum.Parse(typeof(Keys), "S", true);
            dirLeftKey = (Keys)Enum.Parse(typeof(Keys), "A", true);
            dirRightKey = (Keys)Enum.Parse(typeof(Keys), "D", true);
            modRestartKey = (Keys)Enum.Parse(typeof(Keys), "R", true);
            modBotKey = (Keys)Enum.Parse(typeof(Keys), "B", true);
            modSpeedKey = (Keys)Enum.Parse(typeof(Keys), "N", true);
            modPauseKey = (Keys)Enum.Parse(typeof(Keys), "P", true);

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
    }
}
