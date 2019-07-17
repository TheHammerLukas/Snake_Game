﻿using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Xml;

namespace Snake_Game
{
    class gameController
    {
        private static int cntFoodSpawned = 0;
        public static int maxPosX = 0;
        public static int maxPosY = 0;
        public string scoreXmlPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Snake_Game\\Snake_Game_Score.xml";
        public string settingsXmlPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Snake_Game\\Snake_Game_Settings.xml";
        public string controlsXmlPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Snake_Game\\Snake_Game_Controls.xml";

        #region Game logic

        // Start new game
        public void StartGame()
        {
            // Create new player object
            gameObject.Snake.Clear();
            gameObject Head = new gameObject(false);
            Head.X = maxPosX / 2;
            Head.Y = maxPosY / 2;
            gameObject.Snake.Add(Head);
            
            // Reset food counter so powerups keep spawning with the same interval
            cntFoodSpawned = 0;
        }

        // Generate a new food object
        public void GenerateFood()
        {
            int _RandX;
            int _RandY;
            bool _IsClipping; // To check if the food would be spawned in the snake
            gamePowerup _foodPowerup;

            Random random = new Random();
            gameObject.Food = new gameObject(true);

            do
            {
                _IsClipping = false;

                // Generate new coordinates for food gameObject
                _RandX = random.Next(0, maxPosX);
                _RandY = random.Next(0, maxPosY);

                for (int i = 0; i < gameObject.Snake.Count; i++)
                {
                    // If food has the same location as the snake -> new random coordinates for food
                    if (gameObject.Snake[i].X == _RandX && gameObject.Snake[i].Y == _RandY)
                    {
                        _IsClipping = true;
                        break;
                    }
                }
            } while (_IsClipping);

            // Generate new gameObject for food
            gameObject.Food.X = _RandX;
            gameObject.Food.Y = _RandY;
            if (gameSettings.DevModeEnabled)
            {
                _foodPowerup = (gamePowerup)random.Next(1, 5);
                gameSettings.PowerupSpawnGap = 0;
            }
            else
            {
                _foodPowerup = (gamePowerup)random.Next(0, 5);
                gameSettings.initPowerupSpawnGap(false);
            }

            if (cntFoodSpawned >= gameSettings.PowerupSpawnGap && !gameSettings.GamePowerupActive)
            {
                if (_foodPowerup != gamePowerup.None)
                {
                    gameSettings.FoodPowerup = _foodPowerup;
                    cntFoodSpawned = 0;
                }
                else
                {
                    cntFoodSpawned++;
                }
            }
            else
            {
                gameSettings.FoodPowerup = gamePowerup.None;
                cntFoodSpawned++;
            }
        }

        // Move the player
        public void MovePlayer()
        {
            for (int i = gameObject.Snake.Count - 1; i >= 0; i--)
            {
                // Move head
                if (i == 0)
                {
                    // Call of bot
                    gameModifiers bot = new gameModifiers();
                    bot.BotLogic();

                    switch (gameSettings.direction)
                    {
                        case gameDirection.Right:
                            gameObject.Snake[i].X++;
                            break;
                        case gameDirection.Left:
                            gameObject.Snake[i].X--;
                            break;
                        case gameDirection.Up:
                            gameObject.Snake[i].Y--;
                            break;
                        case gameDirection.Down:
                            gameObject.Snake[i].Y++;
                            break;
                        case gameDirection.Stop:
                            break;
                    }

                    // Detect collision with game border 
                    if (gameObject.Snake[i].X < 0 || gameObject.Snake[i].X >= maxPosX ||
                        gameObject.Snake[i].Y < 0 || gameObject.Snake[i].Y >= maxPosY)
                    {
                        Die();
                    }

                    // Detect collision with body
                    for (int j = 1; j < gameObject.Snake.Count; j++)
                    {
                        if (gameObject.Snake[i].X == gameObject.Snake[j].X &&
                            gameObject.Snake[i].Y == gameObject.Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    if (gameObject.Snake[0].X == gameObject.Food.X && gameObject.Snake[0].Y == gameObject.Food.Y)
                    {
                        Eat();
                    }
                }
                else
                {
                    // Move body
                    gameObject.Snake[i].X = gameObject.Snake[i - 1].X;
                    gameObject.Snake[i].Y = gameObject.Snake[i - 1].Y;
                }
            }
        }

        // Elongate the snake
        private void Eat()
        {
            if (gameSettings.FoodPowerup != gamePowerup.None)
            {
                gameSettings.SavedPowerup = gameSettings.FoodPowerup;
                gameSettings.FoodPowerup = gamePowerup.None;

                PlayGameSound(gameSound.PowerupEat);
            }
            else
            {
                PlayGameSound(gameSound.SnakeEat);
            }

            if (gameObject.Snake.Count + gameSettings.GrowMultiplicator < maxPosX * maxPosY) // If snake has enough room to grow add new gameObjects to it
            {
                for (int i = 1; i <= gameSettings.GrowMultiplicator; i++) // Adds as much gameObjects as defined in GrowMultiplicator to Snake
                {
                    // Add gameObject to body of snake
                    gameObject Food = new gameObject(false);
                    Food.X = gameObject.Snake[gameObject.Snake.Count - 1].X;
                    Food.Y = gameObject.Snake[gameObject.Snake.Count - 1].Y;
                    gameObject.Snake.Add(Food);
                }
            }

            // Update score
            if (gameSettings.GamePowerup == gamePowerup.X2 && !gameSettings.GamePowerupActive || gameSettings.GamePowerup != gamePowerup.X2)
            {
                gameSettings.Score += gameSettings.Points;
            }
            else if (gameSettings.GamePowerup == gamePowerup.X2 && gameSettings.GamePowerupActive)
            {
                gameSettings.Score += gameSettings.Points * 2;
            }
            GenerateFood();
        }

        // Kill the player
        private void Die()
        {
            if (gameSettings.GamePowerup == gamePowerup.Noclip && gameSettings.GamePowerupActive || gameSettings.NoClipEnabled)
            {
                // Don't die because of noclip
                return;
            }
            else // Die because noclip is not enabled
            {
                gameSettings.GameOver = true;
                gameSettings.GamePowerup = gamePowerup.None;

                if (gameSettings.Score > gameSettings.HighScore && !gameSettings.IsModifierRound)
                {
                    writeScoreXML();
                }
            }
        }

        // Gets passed in the gameSound that should be played and plays the corresponding sound resource
        public void PlayGameSound(gameSound sound)
        {
            SoundPlayer audio = new SoundPlayer();
            gameSound _sound = sound;

            switch (_sound)
            {
                case gameSound.SnakeEat:
                    audio = new SoundPlayer(Properties.Resources.gameSoundSnakeEat);
                    break;
                case gameSound.PowerupEat:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPowerupEat);
                    break;
                case gameSound.None:
                    audio = new SoundPlayer();
                    break;
                default:
                    MessageBox.Show(
                                "Invalid sound tried to be played in \ngameController.PlayGameSound procedure!\nsound=" + _sound,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
                    break;
            }
            audio.Play();
        }

        #endregion

        #region XML functions

        // Get the settings from the .xml
        public void readSettingsXML()
        {
            try // Try to get the .xml data
            {
                // Open .xml
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(settingsXmlPath);

                XmlElement _xmlRoot = _xmlDoc.DocumentElement;
                
                foreach (XmlAttribute _xmlAttrib in _xmlRoot.Attributes)
                {
                    if (_xmlAttrib.Name == "Width")
                    {
                        if ((Convert.ToInt32(_xmlAttrib.Value) > 200 && Convert.ToInt32(_xmlAttrib.Value) % 100 == 0 ||
                             Convert.ToInt32(_xmlAttrib.Value) < 200 && Convert.ToInt32(_xmlAttrib.Value) % 2 == 0 && Convert.ToInt32(_xmlAttrib.Value) % 5 == 0) &&
                             Convert.ToInt32(_xmlAttrib.Value) > 0 && Convert.ToInt32(_xmlAttrib.Value) <= 300)
                        {
                            gameSettings.Width = Convert.ToInt32(_xmlAttrib.Value);
                        }
                    }
                    if (_xmlAttrib.Name == "Height")
                    {
                        if ((Convert.ToInt32(_xmlAttrib.Value) > 200 && Convert.ToInt32(_xmlAttrib.Value) % 100 == 0 || 
                             Convert.ToInt32(_xmlAttrib.Value) < 200 && Convert.ToInt32(_xmlAttrib.Value) % 2 == 0 && Convert.ToInt32(_xmlAttrib.Value) % 5 == 0) && 
                             Convert.ToInt32(_xmlAttrib.Value) > 0 && Convert.ToInt32(_xmlAttrib.Value) <= 300)
                        {
                            gameSettings.Height = Convert.ToInt32(_xmlAttrib.Value);
                        }
                    }
                    if (_xmlAttrib.Name == "Speed")
                    {
                        if (Convert.ToInt32(_xmlAttrib.Value) > 0 && Convert.ToInt32(_xmlAttrib.Value) <= 1000)
                        {
                            gameSettings.Speed = Convert.ToInt32(_xmlAttrib.Value);
                        }
                    }
                    if (_xmlAttrib.Name == "GrowMultiplicator")
                    {
                        if (Convert.ToInt32(_xmlAttrib.Value) >= 0)
                        {
                            gameSettings.GrowMultiplicator = Convert.ToInt32(_xmlAttrib.Value);
                        }
                    }
                    if (_xmlAttrib.Name == "Points")
                    {
                        gameSettings.Points = Convert.ToInt32(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "SnakeHeadColor")
                    {
                        gameSettings.snakeHeadColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "SnakeBodyColor")
                    {
                        gameSettings.snakeBodyColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "RainbowEnabled")
                    {
                        gameSettings.RainbowEnabled = Convert.ToBoolean(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "RainbowMode")
                    {
                        gameSettings.RainbowMode = (rainbowMode)Convert.ToInt32(_xmlAttrib.Value);
                    }
                }
            }
            catch (Exception) // If no xml is found use standard values
            {
                MessageBox.Show("Unexpected error ocurred reading the settings XML!\nUsing standart settings instead.", 
                                "Unexpected error while reading settings XML",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error
                                );
            }
        }

        // Write the settings to the .xml
        public void writeSettingsXML()
        {
            // Create .xml
            (new FileInfo(settingsXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            XmlWriter _xmlDoc = XmlWriter.Create(settingsXmlPath);
            _xmlDoc.WriteStartDocument();

            // Settings
            _xmlDoc.WriteStartElement("Settings");
                // Width
                _xmlDoc.WriteStartAttribute("Width"); 
                _xmlDoc.WriteString(gameSettings.Width.ToString());
                _xmlDoc.WriteEndAttribute();
                // Height
                _xmlDoc.WriteStartAttribute("Height"); 
                _xmlDoc.WriteString(gameSettings.Height.ToString());
                _xmlDoc.WriteEndAttribute();
                // Speed
                _xmlDoc.WriteStartAttribute("Speed"); 
                _xmlDoc.WriteString(gameSettings.Speed.ToString());
                _xmlDoc.WriteEndAttribute();
                // GrowMultiplicator
                _xmlDoc.WriteStartAttribute("GrowMultiplicator"); 
                _xmlDoc.WriteString(gameSettings.GrowMultiplicator.ToString());
                _xmlDoc.WriteEndAttribute();
                // Points
                _xmlDoc.WriteStartAttribute("Points"); 
                _xmlDoc.WriteString(gameSettings.Points.ToString());
                _xmlDoc.WriteEndAttribute();
                // SnakeHeadColor
                _xmlDoc.WriteStartAttribute("SnakeHeadColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // SnakeBodyColor
                _xmlDoc.WriteStartAttribute("SnakeBodyColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // RainbowEnabled
                _xmlDoc.WriteStartAttribute("RainbowEnabled");
                _xmlDoc.WriteString(gameSettings.RainbowEnabled.ToString());
                _xmlDoc.WriteEndAttribute();
                // RainbowMode
                _xmlDoc.WriteStartAttribute("RainbowMode");
                _xmlDoc.WriteString(Convert.ToString(Convert.ToInt32(gameSettings.RainbowMode)));
                _xmlDoc.WriteEndAttribute();
            // End .xml
            _xmlDoc.WriteEndDocument();
            _xmlDoc.Flush();
            _xmlDoc.Close(); // Close .xml
        }

        // Get the key config from the .xml
        public void readControlsXML()
        {
            try // Try to get the .xml data
            {
                // Open .xml
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(controlsXmlPath);

                XmlElement _xmlRoot = _xmlDoc.DocumentElement;

                foreach (XmlAttribute _xmlAttrib in _xmlRoot.Attributes)
                {
                    if (_xmlAttrib.Name == "UpKey")
                    {
                        gameControls.dirUpKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "DownKey")
                    {
                        gameControls.dirDownKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "LeftKey")
                    {
                        gameControls.dirLeftKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "RightKey")
                    {
                        gameControls.dirRightKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "RestartKey")
                    {
                        gameControls.modRestartKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "BotKey")
                    {
                        gameControls.modBotKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "SpeedKey")
                    {
                        gameControls.modSpeedKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "PauseKey")
                    {
                        gameControls.modPauseKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "NoClipKey")
                    {
                        gameControls.modNoClipKey = getKey(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "PowerupKey")
                    {
                        gameControls.modPowerupKey = getKey(_xmlAttrib.Value);
                    }
                }
            }
            catch(Exception) // If no .XML found or no Keys found then use standard keys
            {
                foreach (gameAction action in Enum.GetValues(typeof(gameAction)))
                {
                    gameControls.InitControls(action);
                }
            }
        }

        // Write the key config to the .xml
        public void writeControlsXML()
        {
            // Create .xml
            (new FileInfo(controlsXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            XmlWriter _xmlDoc = XmlWriter.Create(controlsXmlPath);
            _xmlDoc.WriteStartDocument();

            // Controls
            _xmlDoc.WriteStartElement("Controls");
                // Up Key
                _xmlDoc.WriteStartAttribute("UpKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.dirUpKey));
                _xmlDoc.WriteEndAttribute();
                // Down Key
                _xmlDoc.WriteStartAttribute("DownKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.dirDownKey));
                _xmlDoc.WriteEndAttribute();
                // Left Key
                _xmlDoc.WriteStartAttribute("LeftKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.dirLeftKey));
                _xmlDoc.WriteEndAttribute();
                // Right Key
                _xmlDoc.WriteStartAttribute("RightKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.dirRightKey));
                _xmlDoc.WriteEndAttribute();
                // Restart Key
                _xmlDoc.WriteStartAttribute("RestartKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modRestartKey));
                _xmlDoc.WriteEndAttribute();
                // Bot Key
                _xmlDoc.WriteStartAttribute("BotKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modBotKey));
                _xmlDoc.WriteEndAttribute();
                // Speed Key
                _xmlDoc.WriteStartAttribute("SpeedKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modSpeedKey));
                _xmlDoc.WriteEndAttribute();
                // Pause Key
                _xmlDoc.WriteStartAttribute("PauseKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modPauseKey));
                _xmlDoc.WriteEndAttribute();
                // NoClip Key
                _xmlDoc.WriteStartAttribute("NoClipKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modNoClipKey));
                _xmlDoc.WriteEndAttribute();
                // Powerup Key
                _xmlDoc.WriteStartAttribute("PowerupKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modPowerupKey));
                _xmlDoc.WriteEndAttribute();
            _xmlDoc.WriteEndElement();

            // End .xml
            _xmlDoc.WriteEndDocument();
            _xmlDoc.Flush();
            _xmlDoc.Close(); // Close .xml
        }

        // Get the highscore from the .xml
        public void readScoreXML()
        {
            try // Try to get the .xml data
            {
                // Open .xml
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(scoreXmlPath);

                XmlElement _xmlRoot = _xmlDoc.DocumentElement;

                foreach (XmlAttribute _xmlAttrib in _xmlRoot.Attributes)
                {
                    if (_xmlAttrib.Name == "HighScore")
                    {
                        gameSettings.HighScore = Convert.ToInt32(_xmlAttrib.Value);
                    }
                }
            }
            catch (Exception)
            {
                gameSettings.HighScore = 0;
            }
        }

        // Write the highscore to the .xml
        private void writeScoreXML()
        {
            // Create .xml
            (new FileInfo(scoreXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            XmlWriter _xmlDoc = XmlWriter.Create(scoreXmlPath);
            _xmlDoc.WriteStartDocument();

            // Scores
            _xmlDoc.WriteStartElement("Scores");
                // HighScore
                _xmlDoc.WriteStartAttribute("HighScore");
                _xmlDoc.WriteString(gameSettings.Score.ToString());
                _xmlDoc.WriteEndAttribute();
            _xmlDoc.WriteEndElement();

            // End .xml
            _xmlDoc.WriteEndDocument();
            _xmlDoc.Flush();
            _xmlDoc.Close(); // Close .xml
        }

        // Function called by readControlsXML to parse a single key from Keys enum
        public Keys getKey(string Key)
        {
            return (Keys)Enum.Parse(typeof(Keys), Key, true);
        }

        // Function that converts color from XML to Brush
        public Brush getBrush(string ColorString)
        {
            Brush _brush = Brushes.Black;

            try // First try to handle the input as a hex value
            {
                int _posStartA = ColorString.IndexOf('A', 0) + 2;
                int _posStartR = ColorString.IndexOf('R', 0) + 2;
                int _posStartG = ColorString.IndexOf('G', 0) + 2;
                int _posStartB = ColorString.IndexOf('B', 0) + 2;

                int[] _actColor = { Convert.ToInt32(ColorString.Substring(_posStartA, _posStartR - 4 - _posStartA)),
                                    Convert.ToInt32(ColorString.Substring(_posStartR, _posStartG - 4 - _posStartR)),
                                    Convert.ToInt32(ColorString.Substring(_posStartG, _posStartB - 4 - _posStartG)),
                                    Convert.ToInt32(ColorString.Substring(_posStartB, ColorString.Length - 1 - _posStartB))};

                _brush = new SolidBrush(Color.FromArgb(_actColor[0], _actColor[1], _actColor[2], _actColor[3]));
            }
            catch (Exception) // If handling as hex value doesn't work, try to handle as color name
            {
                int _posColorName = ColorString.IndexOf('[', 0) + 1;
                int _lenColorName = ColorString.IndexOf(']', 0) - _posColorName;
                string _actColorName = ColorString.Substring(_posColorName, _lenColorName);

                _brush = new SolidBrush(Color.FromName(_actColorName));
            }
            return _brush;
        }

        #endregion
        
        #region Functions called by gameInterface

        public void SetGameOverFalse(Label labelGameOver)
        {
            labelGameOver.Visible = false;
        }

        public void SetScore( Label labelScoreValue)
        {
            labelScoreValue.Text = gameSettings.Score.ToString();
        }

        public void SetHighScore(Label labelHighScoreValue)
        {
            labelHighScoreValue.Text = gameSettings.HighScore.ToString();
        }

        // To set the powerup controls
        public void SetPowerup(Label labelCurrentPowerupValue, Label labelSavedPowerupValue, Label labelPowerupTimerValue, long currentTime, long lastChangeTime)
        {
            string _CurrentPowerup = "None";
            string _SavedPowerup = "None";
            int _PowerupDuration = 0;

            switch (gameSettings.GamePowerup)
            {
                case gamePowerup.X2:
                    _CurrentPowerup = "x2 Points";
                    _PowerupDuration = Convert.ToInt32((30000 - (currentTime - lastChangeTime)) / 1000);
                    break;
                case gamePowerup.PointOnTick:
                    _CurrentPowerup = "Point on Tick";
                    _PowerupDuration = Convert.ToInt32((20000 - (currentTime - lastChangeTime)) / 1000);
                    break;
                case gamePowerup.Slowmotion:
                    _CurrentPowerup = "Slowmotion";
                    _PowerupDuration = Convert.ToInt32((10000 - (currentTime - lastChangeTime)) / 1000);
                    break;
                case gamePowerup.Noclip:
                    _CurrentPowerup = "NoClip";
                    _PowerupDuration = Convert.ToInt32((15000 - (currentTime - lastChangeTime)) / 1000);
                    break;
            }

            switch (gameSettings.SavedPowerup)
            {
                case gamePowerup.X2:
                    _SavedPowerup = "x2 Points";
                    break;
                case gamePowerup.PointOnTick:
                    _SavedPowerup = "Point on Tick";
                    break;
                case gamePowerup.Slowmotion:
                    _SavedPowerup = "Slowmotion";
                    break;
                case gamePowerup.Noclip:
                    _SavedPowerup = "NoClip";
                    break;
            }

            labelCurrentPowerupValue.Text = _CurrentPowerup;
            labelSavedPowerupValue.Text = _SavedPowerup;
            labelPowerupTimerValue.Text = _PowerupDuration.ToString();
        }

        public int GetMaxPosX(PictureBox pictureBox)
        {
            return pictureBox.Size.Width / gameSettings.Width;
        }

        public int GetMaxPosY(PictureBox pictureBox)
        {
            return pictureBox.Size.Height / gameSettings.Height;
        }

        public int ConvToGameTime(int normalSpeed)
        {
            return 1000 / normalSpeed;
        }

        public void SetTimerInterval(Timer timer, int speed, bool isGameTime)
        {
            // Determine whether speed has to be converted to gametime or not
            timer.Interval = isGameTime ? ConvToGameTime(speed) : speed;
        }

        #endregion
    }
}
