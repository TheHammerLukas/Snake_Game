using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Xml;

namespace Snake_Game
{
    class gameController
    {
        private Timer checkSoundTimer = new Timer();

        private static int cntFoodSpawned = 0;
        private static long soundCheckTime = 0;
        private static long lastSoundPlayTime = 0;
        public static int growCnt = 0;
        public static int maxPosX = 0;
        public static int maxPosY = 0;

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

            // Run checkSoundTimer
            checkSoundTimer.Interval = 500; // 0.5 seconds
            checkSoundTimer.Tick += new EventHandler(checkSoundTimer_Tick);
            checkSoundTimer.Start();
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

            PlayGameSound(gameConstants.gameSound.FoodSpawn);
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

                    switch (gameSettings.directionHead)
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

        // Prepare for the snake to grow
        private void Eat()
        {
            if (gameSettings.FoodPowerup != gamePowerup.None)
            {
                gameSettings.SavedPowerup = gameSettings.FoodPowerup;
                gameSettings.FoodPowerup = gamePowerup.None;

                PlayGameSound(gameConstants.gameSound.PowerupEat);
            }
            else
            {
                PlayGameSound(gameConstants.gameSound.SnakeEat);
            }

            // Set growCnt to 0 so the snake will grow
            growCnt = 0;

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

        // Grow the snake as long as growCnt < GrowMultiplicator
        public void GrowSnake()
        {
            if (gameObject.Snake.Count + gameSettings.GrowMultiplicator < maxPosX * maxPosY) // If snake has enough room to grow add new gameObjects to it
            {
                if (growCnt < gameSettings.GrowMultiplicator) // Adds as much gameObjects as defined in GrowMultiplicator to Snake
                {
                    // Add gameObject to body of snake
                    gameObject Food = new gameObject(false);
                    Food.X = gameObject.Snake[gameObject.Snake.Count - 1].X;
                    Food.Y = gameObject.Snake[gameObject.Snake.Count - 1].Y;

                    if (gameObject.Snake.Count == 1)
                    {
                        switch (gameSettings.directionHead)
                        {
                            case gameDirection.Up:
                                gameSettings.directionTail = gameDirection.Down;
                                break;
                            case gameDirection.Down:
                                gameSettings.directionTail = gameDirection.Up;
                                break;
                            case gameDirection.Left:
                                gameSettings.directionTail = gameDirection.Right;
                                break;
                            case gameDirection.Right:
                                gameSettings.directionTail = gameDirection.Left;
                                break;
                        }
                    }
                    else
                    {
                        if (gameObject.Snake[gameObject.Snake.Count - (gameObject.Snake.Count == 2 ? 1 : 2)].Y <
                            gameObject.Snake[gameObject.Snake.Count - (gameObject.Snake.Count == 2 ? 2 : 3)].Y)
                        {
                            gameSettings.directionTail = gameDirection.Up;
                        }
                        else if (gameObject.Snake[gameObject.Snake.Count - (gameObject.Snake.Count == 2 ? 1 : 2)].Y > 
                                 gameObject.Snake[gameObject.Snake.Count - (gameObject.Snake.Count == 2 ? 2 : 3)].Y)
                        {
                            gameSettings.directionTail = gameDirection.Down;
                        }
                        else if (gameObject.Snake[gameObject.Snake.Count - (gameObject.Snake.Count == 2 ? 1 : 2)].X <
                                 gameObject.Snake[gameObject.Snake.Count - (gameObject.Snake.Count == 2 ? 2 : 3)].X)
                        {
                            gameSettings.directionTail = gameDirection.Left;
                        }
                        else if (gameObject.Snake[gameObject.Snake.Count - (gameObject.Snake.Count == 2 ? 1 : 2)].X >
                                 gameObject.Snake[gameObject.Snake.Count - (gameObject.Snake.Count == 2 ? 2 : 3)].X)
                        {
                            gameSettings.directionTail = gameDirection.Right;
                        }
                    }

                    switch (gameSettings.directionTail)
                    {
                        case gameDirection.Up:
                            Food.Y--;
                            break;
                        case gameDirection.Down:
                            Food.Y++;
                            break;
                        case gameDirection.Left:
                            Food.X--;
                            break;
                        case gameDirection.Right:
                            Food.X++;
                            break;
                    }

                    gameObject.Snake.Add(Food);

                    growCnt++;
                }
            }
        }

        // Kill the player
        private void Die()
        {
            if (gameSettings.GamePowerup == gamePowerup.Noclip && gameSettings.GamePowerupActive || gameSettings.NoClipEnabled)
            {
                // Don't die because of noclip but play noclip sound
                PlayGameSound(gameConstants.gameSound.SnakeNoClip);

                if (gameObject.Snake[0].X < 0)
                {
                    gameObject.Snake[0].X = maxPosX - 1;
                }
                else if (gameObject.Snake[0].X >= maxPosX)
                {
                    gameObject.Snake[0].X = 0;
                }
                else if (gameObject.Snake[0].Y < 0)
                {
                    gameObject.Snake[0].Y = maxPosY - 1;
                }
                else if (gameObject.Snake[0].Y >= maxPosY)
                {
                    gameObject.Snake[0].Y = 0;
                }
            }
            else // Die because noclip is not enabled
            {
                gameSettings.GameOver = true;
                gameSettings.GamePowerup = gamePowerup.None;
                PlayGameSound(gameConstants.gameSound.SnakeDie);

                if (gameSettings.Score > gameSettings.HighScore && !gameSettings.IsModifierRound)
                {
                    writeScoreXML();
                }
            }
        }

        // Gets passed in the gameConstants.gameSound that should be played and plays the corresponding sound resource
        public void PlayGameSound(gameConstants.gameSound sound)
        {
            SoundPlayer audio = new SoundPlayer();
            gameConstants.gameSound _sound = sound;

            int _PUpDeactivateSound = 0;

            if (_sound == gameConstants.gameSound.PUpX2Deactivate || _sound == gameConstants.gameSound.PUpPointTickDeactivate ||
                _sound == gameConstants.gameSound.PUpSlowmoDeactivate || _sound == gameConstants.gameSound.PUpNoclipDeactivate)
            {
                Random random = new Random();
                _PUpDeactivateSound = random.Next(0, 2);
            }

            switch (_sound)
            {
                case gameConstants.gameSound.SnakeEat:
                    audio = new SoundPlayer(Properties.Resources.gameSoundSnakeEat);
                    break;
                case gameConstants.gameSound.PowerupEat:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPowerupEat);
                    break;
                case gameConstants.gameSound.SnakeDie:
                    audio = new SoundPlayer(Properties.Resources.gameSoundSnakeDie);
                    break;
                case gameConstants.gameSound.SnakeNoClip:
                    audio = new SoundPlayer(Properties.Resources.gameSoundSnakeNoClip);
                    break;
                case gameConstants.gameSound.SnakeChangeDir:
                    audio = new SoundPlayer(Properties.Resources.gameSoundSnakeChangeDir);
                    break;
                case gameConstants.gameSound.FoodSpawn:
                    audio = new SoundPlayer(Properties.Resources.gameSoundFoodSpawn);
                    break;
                case gameConstants.gameSound.PUpX2Activate:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPUpX2);
                    break;
                case gameConstants.gameSound.PUpX2Deactivate:
                    audio = new SoundPlayer(_PUpDeactivateSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01 
                                                                     : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpPointTickActivate:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPUpPointTick);
                    break;
                case gameConstants.gameSound.PUpPointTickDeactivate:
                    audio = new SoundPlayer(_PUpDeactivateSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                                     : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpSlowmoActivate:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPUpSlowmotion);
                    break;
                case gameConstants.gameSound.PUpSlowmoDeactivate:
                    audio = new SoundPlayer(_PUpDeactivateSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                                     : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpNoclipActivate:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPUpNoclip);
                    break;
                case gameConstants.gameSound.PUpNoclipDeactivate:
                    audio = new SoundPlayer(_PUpDeactivateSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                                     : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.ApplicationStartup:
                    audio = new SoundPlayer(Properties.Resources.gameSoundHelloMan);
                    break;
                case gameConstants.gameSound.None:
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
            // Outer if is used to disable sounds that should not be played
            if (_sound != gameConstants.gameSound.None && _sound != gameConstants.gameSound.SnakeChangeDir && _sound != gameConstants.gameSound.FoodSpawn)
            {
                if (_sound != gameConstants.gameSound.SnakeNoClip || (soundCheckTime > lastSoundPlayTime && (_sound == gameConstants.gameSound.SnakeNoClip)))
                {
                    audio.Play();
                    lastSoundPlayTime = soundCheckTime;
                }
            }
        }

        private void checkSoundTimer_Tick(object sender, EventArgs e)
        {
            soundCheckTime = soundCheckTime + 1 <= long.MaxValue ? soundCheckTime + 1 : 0;
        }

        #endregion

        #region Savefile functions

        // Get the settings from the .xml
        public void readSettingsXML()
        {
            try // Try to get the .xml data
            {
                // Open .xml
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(Properties.Settings.Default.settingsXmlPath);

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
                            growCnt = gameSettings.GrowMultiplicator;
                        }
                    }
                    if (_xmlAttrib.Name == "Points")
                    {
                        gameSettings.Points = Convert.ToInt32(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "DrawingMode")
                    {
                        gameSettings.DrawingMode = (gameConstants.gameDrawingMode)Convert.ToInt32(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "RainbowMode")
                    {
                        gameSettings.RainbowMode = (gameConstants.rainbowMode)Convert.ToInt32(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "PowerupSpawnGap")
                    {
                        gameSettings.PowerupSpawnGap = Convert.ToInt32(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "PowerupDurationX2")
                    {
                        gameSettings.PowerupDurationX2 = ConvTime(Convert.ToInt32(_xmlAttrib.Value), gameConstants.seconds, gameConstants.milliseconds);
                    }
                    if (_xmlAttrib.Name == "PowerupDurationPointTick")
                    {
                        gameSettings.PowerupDurationPointTick = ConvTime(Convert.ToInt32(_xmlAttrib.Value), gameConstants.seconds, gameConstants.milliseconds);
                    }
                    if (_xmlAttrib.Name == "PowerupDurationSlowmo")
                    {
                        gameSettings.PowerupDurationSlowmo = ConvTime(Convert.ToInt32(_xmlAttrib.Value), gameConstants.seconds, gameConstants.milliseconds);
                    }
                    if (_xmlAttrib.Name == "PowerupDurationNoclip")
                    {
                        gameSettings.PowerupDurationNoclip = ConvTime(Convert.ToInt32(_xmlAttrib.Value), gameConstants.seconds, gameConstants.milliseconds);
                    }
                    if (_xmlAttrib.Name == "snakeHeadNormalColor")
                    {
                        gameSettings.snakeHeadNormalColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeHeadPUpX2Color")
                    {
                        gameSettings.snakeHeadPUpX2Color = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeHeadPUpPointTickColor")
                    {
                        gameSettings.snakeHeadPUpPointTickColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeHeadPUpSlowmoColor")
                    {
                        gameSettings.snakeHeadPUpSlowmoColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeHeadPUpNoclipColor")
                    {
                        gameSettings.snakeHeadPUpNoclipColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeBodyNormalColor")
                    {
                        gameSettings.snakeBodyNormalColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeBodyPUpX2Color")
                    {
                        gameSettings.snakeBodyPUpX2Color = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeBodyPUpPointTickColor")
                    {
                        gameSettings.snakeBodyPUpPointTickColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeBodyPUpSlowmoColor")
                    {
                        gameSettings.snakeBodyPUpSlowmoColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "snakeBodyPUpNoclipColor")
                    {
                        gameSettings.snakeBodyPUpNoclipColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "foodNormalColor")
                    {
                        gameSettings.foodNormalColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "foodPUpX2Color")
                    {
                        gameSettings.foodPUpX2Color = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "foodPUpPointTickColor")
                    {
                        gameSettings.foodPUpPointTickColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "foodPUpSlowmoColor")
                    {
                        gameSettings.foodPUpSlowmoColor = getBrush(_xmlAttrib.Value);
                    }
                    if (_xmlAttrib.Name == "foodPUpNoclipColor")
                    {
                        gameSettings.foodPUpNoclipColor = getBrush(_xmlAttrib.Value);
                    }
                }
            }
            catch (Exception) // If no xml is found use standard values
            {
                MessageBox.Show("Unexpected error ocurred reading the settings XML!\nUsing standard settings instead.", 
                                "Unexpected error while reading settings XML",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error
                                );

                new gameSettings(true, true);
            }
        }

        // Write the settings to the .xml
        public void writeSettingsXML()
        {
            // Create .xml
            try
            {
                (new FileInfo(Properties.Settings.Default.settingsXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            }
            catch (Exception) // If xml cannot be created due to missing permissions save to the desktop
            {
                MessageBox.Show("Unspecified error occured while creating the settings XML!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.settingsXmlPath,
                                "Unexpected error while creating settings XML",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );

                SaveFileDialog(gameConstants.settingsXML);

                (new FileInfo(Properties.Settings.Default.settingsXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            }

            XmlWriter _xmlDoc = XmlWriter.Create(Properties.Settings.Default.settingsXmlPath);
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
                // DrawingMode
                _xmlDoc.WriteStartAttribute("DrawingMode");
                _xmlDoc.WriteString(Convert.ToString(Convert.ToInt32(gameSettings.DrawingMode)));
                _xmlDoc.WriteEndAttribute();
                // RainbowMode
                _xmlDoc.WriteStartAttribute("RainbowMode");
                _xmlDoc.WriteString(Convert.ToString(Convert.ToInt32(gameSettings.RainbowMode)));
                _xmlDoc.WriteEndAttribute();
                // PowerupSpawnGap         
                _xmlDoc.WriteStartAttribute("PowerupSpawnGap");
                _xmlDoc.WriteString(Convert.ToString(Convert.ToInt32(gameSettings.PowerupSpawnGapConfigured)));
                _xmlDoc.WriteEndAttribute();
                // PowerupDurationX2       
                _xmlDoc.WriteStartAttribute("PowerupDurationX2");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndAttribute();
                // PowerupDurationPointTick
                _xmlDoc.WriteStartAttribute("PowerupDurationPointTick");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTick), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndAttribute();
                // PowerupDurationSlowmo   
                _xmlDoc.WriteStartAttribute("PowerupDurationSlowmo");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationSlowmo), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndAttribute();
                // PowerupDurationNoclip         
                _xmlDoc.WriteStartAttribute("PowerupDurationNoclip");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationNoclip), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndAttribute();
                // snakeHeadNormalColor      
                _xmlDoc.WriteStartAttribute("snakeHeadNormalColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadNormalColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeHeadPUpX2Color       
                _xmlDoc.WriteStartAttribute("snakeHeadPUpX2Color");
                _xmlDoc.WriteString(((gameSettings.snakeHeadPUpX2Color as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeHeadPUpPointTickColor
                _xmlDoc.WriteStartAttribute("snakeHeadPUpPointTickColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadPUpPointTickColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeHeadPUpSlowmoColor   
                _xmlDoc.WriteStartAttribute("snakeHeadPUpSlowmoColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadPUpSlowmoColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeHeadPUpNoclipColor   
                _xmlDoc.WriteStartAttribute("snakeHeadPUpNoclipColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadPUpNoclipColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeBodyNormalColor      
                _xmlDoc.WriteStartAttribute("snakeBodyNormalColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyNormalColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeBodyPUpX2Color       
                _xmlDoc.WriteStartAttribute("snakeBodyPUpX2Color");
                _xmlDoc.WriteString(((gameSettings.snakeBodyPUpX2Color as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeBodyPUpPointTickColor
                _xmlDoc.WriteStartAttribute("snakeBodyPUpPointTickColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyPUpPointTickColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeBodyPUpSlowmoColor   
                _xmlDoc.WriteStartAttribute("snakeBodyPUpSlowmoColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyPUpSlowmoColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // snakeBodyPUpNoclipColor   
                _xmlDoc.WriteStartAttribute("snakeBodyPUpNoclipColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyPUpNoclipColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // foodNormalColor           
                _xmlDoc.WriteStartAttribute("foodNormalColor");
                _xmlDoc.WriteString(((gameSettings.foodNormalColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // foodPUpX2Color            
                _xmlDoc.WriteStartAttribute("foodPUpX2Color");
                _xmlDoc.WriteString(((gameSettings.foodPUpX2Color as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // foodPUpPointTickColor     
                _xmlDoc.WriteStartAttribute("foodPUpPointTickColor");
                _xmlDoc.WriteString(((gameSettings.foodPUpPointTickColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // foodPUpSlowmoColor        
                _xmlDoc.WriteStartAttribute("foodPUpSlowmoColor");
                _xmlDoc.WriteString(((gameSettings.foodPUpSlowmoColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndAttribute();
                // foodPUpNoclipColor        
                _xmlDoc.WriteStartAttribute("foodPUpNoclipColor");
                _xmlDoc.WriteString(((gameSettings.foodPUpNoclipColor as SolidBrush).Color).ToString());
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
                _xmlDoc.Load(Properties.Settings.Default.controlsXmlPath);

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
                foreach (gameConstants.gameAction action in Enum.GetValues(typeof(gameConstants.gameAction)))
                {
                    gameControls.initControls(action);
                }
            }
        }

        // Write the key config to the .xml
        public void writeControlsXML()
        {
            // Create .xml
            try
            {
                (new FileInfo(Properties.Settings.Default.controlsXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            }
            catch (UnauthorizedAccessException) // If xml cannot be created due to missing permissions save to the desktop
            {
                MessageBox.Show("Unspecified error occured while creating the controls XML!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.controlsXmlPath,
                                "Unexpected error while creating settings XML",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );

                SaveFileDialog(gameConstants.controlsXML);

                (new FileInfo(Properties.Settings.Default.controlsXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            }

            XmlWriter _xmlDoc = XmlWriter.Create(Properties.Settings.Default.controlsXmlPath);
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
                _xmlDoc.Load(Properties.Settings.Default.scoreXmlPath);

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
        public void writeScoreXML()
        {
            // Create .xml
            try
            {
                (new FileInfo(Properties.Settings.Default.scoreXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            }
            catch (UnauthorizedAccessException) // If xml cannot be created due to missing permissions save to the desktop
            {
                MessageBox.Show("Unspecified error occured while creating the score XML!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.scoreXmlPath,
                                "Unexpected error while creating settings XML",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );

                SaveFileDialog(gameConstants.scoreXML);

                (new FileInfo(Properties.Settings.Default.scoreXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet
            }

            XmlWriter _xmlDoc = XmlWriter.Create(Properties.Settings.Default.scoreXmlPath);
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

        // Loads or saves gameSprites depending on the file being already existent or not
        public void SaveLoadAllSprites()
        {
            if (!File.Exists(Properties.Settings.Default.gameSpritePath))
            {
                SaveGameSprites(gameConstants.gameSprites);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSprites);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpX2Path))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpX2);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpX2);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpPointTickPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpPointTick);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpPointTick);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpSlowmotionPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpSlowmotion);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpSlowmotion);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpNoclipPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpNoclip);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpNoclip);
            }
        }

        // Saves all gameSprite files
        public void SaveAllGameSprites()
        {
            SaveGameSprites(gameConstants.gameSprites);
            SaveGameSprites(gameConstants.gameSpritesPUpX2);
            SaveGameSprites(gameConstants.gameSpritesPUpPointTick);
            SaveGameSprites(gameConstants.gameSpritesPUpSlowmotion);
            SaveGameSprites(gameConstants.gameSpritesPUpNoclip);
        }

        // Saves the current gameSprite according to passed in spriteId 
        public void SaveGameSprites(string spriteId)
        {
            string _spriteId = spriteId;

            switch (_spriteId)
            {
                case gameConstants.gameSprites:
                    try
                    {
                        gameInterface.gameSprite.Save(Properties.Settings.Default.gameSpritePath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSprite.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePath,
                            "Unexpected error while creating gameSprite.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSprites);
                    }
                    break;
                case gameConstants.gameSpritesPUpX2:
                    try
                    {
                        gameInterface.gameSpritePUpX2.Save(Properties.Settings.Default.gameSpritePUpX2Path, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpX2.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePUpX2Path,
                            "Unexpected error while creating gameSpritePUpX2.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpX2);
                    }
                    break;
                case gameConstants.gameSpritesPUpPointTick:
                    try
                    {
                        gameInterface.gameSpritePUpPointTick.Save(Properties.Settings.Default.gameSpritePUpPointTickPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpPointTick.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePUpPointTickPath,
                            "Unexpected error while creating gameSpritePUpPointTick.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpPointTick);
                    }
                    break;
                case gameConstants.gameSpritesPUpSlowmotion:
                    try
                    {
                        gameInterface.gameSpritePUpSlowmotion.Save(Properties.Settings.Default.gameSpritePUpSlowmotionPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpSlowmotion.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePUpSlowmotionPath,
                            "Unexpected error while creating gameSpritePUpSlowmotion.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpSlowmotion);
                    }
                    break;
                case gameConstants.gameSpritesPUpNoclip:
                    try
                    {
                        gameInterface.gameSpritePUpNoclip.Save(Properties.Settings.Default.gameSpritePUpNoclipPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpNoclip.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePUpNoclipPath,
                            "Unexpected error while creating gameSpritePUpNoclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpNoclip);
                    }
                    break;
                default:
                    MessageBox.Show(
                            "Unspecified error occurred while saving Sprites!\nAn error occurred in gameController.SaveGameSprites() procedure!\nspriteId=" + spriteId,
                            "Unexpected error while creating Sprites",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                    break;
            }
        }

        // Loads all gameSprite files
        public void LoadAllGameSprites()
        {
            LoadGameSprites(gameConstants.gameSprites);
            LoadGameSprites(gameConstants.gameSpritesPUpX2);
            LoadGameSprites(gameConstants.gameSpritesPUpPointTick);
            LoadGameSprites(gameConstants.gameSpritesPUpSlowmotion);
            LoadGameSprites(gameConstants.gameSpritesPUpNoclip);
        }

        // Loads the gameSprite from the currently configured path according to passed in spriteId
        public void LoadGameSprites(string spriteId)
        {
            string _spriteId = spriteId;

            switch (_spriteId)
            {
                case gameConstants.gameSprites:
                    try
                    {
                        gameInterface.gameSprite = Image.FromFile(Properties.Settings.Default.gameSpritePath);
                    }
                    catch (Exception)
                    {

                    }
                    break;
                case gameConstants.gameSpritesPUpX2:
                    try
                    {
                        gameInterface.gameSpritePUpX2 = Image.FromFile(Properties.Settings.Default.gameSpritePUpX2Path);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpX2.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePUpX2Path,
                            "Unexpected error while loading gameSpritePUpX2.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpX2);
                    }
                    break;
                case gameConstants.gameSpritesPUpPointTick:
                    try
                    {
                        gameInterface.gameSpritePUpPointTick = Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpPointTick.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePUpPointTickPath,
                            "Unexpected error while loading gameSpritePUpPointTick.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpPointTick);
                    }
                    break;
                case gameConstants.gameSpritesPUpSlowmotion:
                    try
                    {
                        gameInterface.gameSpritePUpSlowmotion = Image.FromFile(Properties.Settings.Default.gameSpritePUpSlowmotionPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpSlowmotion.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePUpSlowmotionPath,
                            "Unexpected error while loading gameSpritePUpSlowmotion.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpSlowmotion);
                    }
                    break;
                case gameConstants.gameSpritesPUpNoclip:
                    try
                    {
                        gameInterface.gameSpritePUpNoclip = Image.FromFile(Properties.Settings.Default.gameSpritePUpNoclipPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpNoclip.png!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.gameSpritePUpNoclipPath,
                            "Unexpected error while loading gameSpritePUpNoclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpNoclip);
                    }
                    break;
                default:
                    MessageBox.Show(
                            "Unspecified error occurred while loading Sprites!\nAn error occurred in gameController.LoadGameSprites() procedure!\nspriteId=" + spriteId,
                            "Unexpected error while loading Sprites",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                    break;
            }
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

        public void OpenFileDialog(string fileType)
        {
            string _fileType = fileType;
            string _filePath = "";
            bool _doSave = false;

            switch (_fileType)
            {
                case gameConstants.settingsXML:
                    _filePath = Properties.Settings.Default.settingsXmlPath.Substring(0, Properties.Settings.Default.settingsXmlPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.controlsXML:
                    _filePath = Properties.Settings.Default.controlsXmlPath.Substring(0, Properties.Settings.Default.controlsXmlPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.scoreXML:
                    _filePath = Properties.Settings.Default.scoreXmlPath.Substring(0, Properties.Settings.Default.scoreXmlPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSprites:
                    _filePath = Properties.Settings.Default.gameSpritePath.Substring(0, Properties.Settings.Default.gameSpritePath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpX2:
                    _filePath = Properties.Settings.Default.gameSpritePUpX2Path.Substring(0, Properties.Settings.Default.gameSpritePUpX2Path.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpPointTick:
                    _filePath = Properties.Settings.Default.gameSpritePUpPointTickPath.Substring(0, Properties.Settings.Default.gameSpritePUpPointTickPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpSlowmotion:
                    _filePath = Properties.Settings.Default.gameSpritePUpSlowmotionPath.Substring(0, Properties.Settings.Default.gameSpritePUpSlowmotionPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpNoclip:
                    _filePath = Properties.Settings.Default.gameSpritePUpNoclipPath.Substring(0, Properties.Settings.Default.gameSpritePUpNoclipPath.LastIndexOf("\\") + 1);
                    break;
            }


            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = _filePath;
            // Determine filter
            switch (_fileType)
            {
                case gameConstants.controlsXML:
                case gameConstants.settingsXML:
                case gameConstants.scoreXML:
                    openFileDialog.Filter = "XML files (*.xml)|*.xml|All files(*.*)|*.*";
                    break;
                case gameConstants.gameSprites:
                case gameConstants.gameSpritesPUpX2:
                case gameConstants.gameSpritesPUpPointTick:
                case gameConstants.gameSpritesPUpSlowmotion:
                case gameConstants.gameSpritesPUpNoclip:
                    openFileDialog.Filter = "PNG files (*.png)|*.png|All files(*.*)|*.*";
                    break;
            }
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                _filePath = openFileDialog.FileName;

                switch (_fileType)
                {
                    case gameConstants.settingsXML:
                        Properties.Settings.Default.settingsXmlPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.controlsXML:
                        Properties.Settings.Default.controlsXmlPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.scoreXML:
                        Properties.Settings.Default.scoreXmlPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSprites:
                        Properties.Settings.Default.gameSpritePath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpX2:
                        Properties.Settings.Default.gameSpritePUpX2Path = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpPointTick:
                        Properties.Settings.Default.gameSpritePUpPointTickPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpSlowmotion:
                        Properties.Settings.Default.gameSpritePUpSlowmotionPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpNoclip:
                        Properties.Settings.Default.gameSpritePUpNoclipPath = _filePath;
                        _doSave = true;
                        break;
                    default:
                        _doSave = false;
                        break;
                }

                if (_doSave)
                {
                    Properties.Settings.Default.Save();

                    switch (_fileType)
                    {
                        case gameConstants.settingsXML:
                            new gameController().readSettingsXML();
                            new gameSettings(false, true);
                            break;
                        case gameConstants.controlsXML:
                            new gameController().readControlsXML();
                            new gameControls(false);
                            break;
                        case gameConstants.scoreXML:
                            new gameController().readScoreXML();
                            break;
                        case gameConstants.gameSprites:
                        case gameConstants.gameSpritesPUpX2:
                        case gameConstants.gameSpritesPUpPointTick:
                        case gameConstants.gameSpritesPUpSlowmotion:
                        case gameConstants.gameSpritesPUpNoclip:
                            LoadGameSprites(_fileType);
                            break;
                        default:
                            break;
                    }
                }

                gameSettings.GameOver = true;
            }
        }

        public void SaveFileDialog(string fileType)
        {
            string _fileType = fileType;
            string _filePath = "";
            bool _doSave = false;

            switch (_fileType)
            {
                case gameConstants.settingsXML:
                    _filePath = Properties.Settings.Default.settingsXmlPath.Substring(0, Properties.Settings.Default.settingsXmlPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.controlsXML:
                    _filePath = Properties.Settings.Default.controlsXmlPath.Substring(0, Properties.Settings.Default.controlsXmlPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.scoreXML:
                    _filePath = Properties.Settings.Default.scoreXmlPath.Substring(0, Properties.Settings.Default.scoreXmlPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSprites:
                    _filePath = Properties.Settings.Default.gameSpritePath.Substring(0, Properties.Settings.Default.gameSpritePath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpX2:
                    _filePath = Properties.Settings.Default.gameSpritePUpX2Path.Substring(0, Properties.Settings.Default.gameSpritePUpX2Path.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpPointTick:
                    _filePath = Properties.Settings.Default.gameSpritePUpPointTickPath.Substring(0, Properties.Settings.Default.gameSpritePUpPointTickPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpSlowmotion:
                    _filePath = Properties.Settings.Default.gameSpritePUpSlowmotionPath.Substring(0, Properties.Settings.Default.gameSpritePUpSlowmotionPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpNoclip:
                    _filePath = Properties.Settings.Default.gameSpritePUpNoclipPath.Substring(0, Properties.Settings.Default.gameSpritePUpNoclipPath.LastIndexOf("\\") + 1);
                    break;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = _filePath;
            // Determine filter
            switch (_fileType)
            {
                case gameConstants.controlsXML:
                case gameConstants.settingsXML:
                case gameConstants.scoreXML:
                    saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files(*.*)|*.*";
                    break;
                case gameConstants.gameSprites:
                case gameConstants.gameSpritesPUpX2:
                case gameConstants.gameSpritesPUpPointTick:
                case gameConstants.gameSpritesPUpSlowmotion:
                case gameConstants.gameSpritesPUpNoclip:
                    saveFileDialog.Filter = "PNG files (*.png)|*.png|All files(*.*)|*.*";
                    break;
            }
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                _filePath = saveFileDialog.FileName;

                switch (_fileType)
                {
                    case gameConstants.settingsXML:
                        Properties.Settings.Default.settingsXmlPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.controlsXML:
                        Properties.Settings.Default.controlsXmlPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.scoreXML:
                        Properties.Settings.Default.scoreXmlPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSprites:
                        Properties.Settings.Default.gameSpritePath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpX2:
                        Properties.Settings.Default.gameSpritePUpX2Path = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpPointTick:
                        Properties.Settings.Default.gameSpritePUpPointTickPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpSlowmotion:
                        Properties.Settings.Default.gameSpritePUpSlowmotionPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpNoclip:
                        Properties.Settings.Default.gameSpritePUpNoclipPath = _filePath;
                        _doSave = true;
                        break;
                    default:
                        _doSave = false;
                        break;
                }

                if (_doSave)
                {
                    Properties.Settings.Default.Save();

                    switch (_fileType)
                    {
                        case gameConstants.settingsXML:
                            new gameController().writeSettingsXML();
                            new gameSettings(false, true);
                            break;
                        case gameConstants.controlsXML:
                            new gameController().writeControlsXML();
                            new gameControls(false);
                            break;
                        case gameConstants.scoreXML:
                            new gameController().writeScoreXML();
                            break;
                        case gameConstants.gameSprites:
                        case gameConstants.gameSpritesPUpX2:
                        case gameConstants.gameSpritesPUpPointTick:
                        case gameConstants.gameSpritesPUpSlowmotion:
                        case gameConstants.gameSpritesPUpNoclip:
                            SaveGameSprites(_fileType);
                            break;
                        default:
                            break;
                    }
                }

                gameSettings.GameOver = true;
            }
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
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2 - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.PointOnTick:
                    _CurrentPowerup = "Point on Tick";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTick - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.Slowmotion:
                    _CurrentPowerup = "Slowmotion";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationSlowmo - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.Noclip:
                    _CurrentPowerup = "NoClip";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationNoclip - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
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

        // Converts time from a specific time format to a specific time format
        public int ConvTime(int time, string fromTime, string toTime)
        {
            int _convertedTime = 0;
            bool _showError = true;

            if (toTime == gameConstants.gameTime)
            {
                if (fromTime == gameConstants.gameSpeed)
                {
                    _convertedTime = 1000 / time; // 1000 / speed; time = amount of ticks in 1 second
                    _showError = false;
                }
            }
            else if (toTime == gameConstants.gameSpeed)
            {
                if (fromTime == gameConstants.gameTime)
                {
                    _convertedTime = 1000 / time; // 1000 / interval; time = interval in ms
                    _showError = false;
                }
            }
            else if (toTime == gameConstants.milliseconds)
            {
                if (fromTime == gameConstants.seconds)
                {
                    _convertedTime = time * 1000; // seconds * 1000
                    _showError = false;
                }
                else if (fromTime == gameConstants.minutes)
                {
                    _convertedTime = ConvTime(ConvTime(time, gameConstants.minutes, gameConstants.seconds), gameConstants.seconds, gameConstants.milliseconds); // recursively convert time
                    _showError = false;
                }
            }
            else if (toTime == gameConstants.seconds)
            {
                if (fromTime == gameConstants.milliseconds)
                {
                    _convertedTime = time / 1000; // milliseconds / 1000
                    _showError = false;
                }
                else if (fromTime == gameConstants.minutes)
                {
                    _convertedTime = time * 60; // minutes * 60
                    _showError = false;
                }
            }
            else if (toTime == gameConstants.minutes)
            {
                if (fromTime == gameConstants.milliseconds)
                {
                    _convertedTime = ConvTime(ConvTime(time, gameConstants.milliseconds, gameConstants.seconds), gameConstants.seconds, gameConstants.minutes); // recursively convert time
                    _showError = false;
                }
                else if (fromTime == gameConstants.seconds)
                {
                    _convertedTime = time / 60; // seconds / 60
                    _showError = false;
                }
            }
            else
            {
                _showError = true; // If time wasn't converted set _showError => true
            }

            // if time wasn't converted show an error message
            if (_showError)
            {
                MessageBox.Show(
                            "Invalid time conversion in \ngameController.ConvTime procedure!\ntime=" + time + ";fromTime=" + fromTime + ";toTime=" + toTime,
                            "Error!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
            }

            return _convertedTime;
        }

        public void SetTimerInterval(Timer timer, int speed, bool isGameTime)
        {
            // Determine whether speed has to be converted to gametime or not
            timer.Interval = isGameTime ? ConvTime(speed, gameConstants.gameSpeed, gameConstants.gameTime) : speed;
        }

        #endregion
    }
}
