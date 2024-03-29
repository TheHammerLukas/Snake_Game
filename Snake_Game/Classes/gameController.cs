﻿using System;
using System.Diagnostics;
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
            }
            else
            {
                _foodPowerup = (gamePowerup)random.Next(0, 5);
            }
            gameSettings.initPowerupSpawnGap(false);

            if (cntFoodSpawned >= gameSettings.PowerupSpawnGap)
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
            if ((gameSettings.GamePowerup == gamePowerup.X2 || gameSettings.GamePowerup == gamePowerup.X2PointOnTick || 
                 gameSettings.GamePowerup == gamePowerup.X2Slowmotion || gameSettings.GamePowerup == gamePowerup.X2Noclip) && 
                 !gameSettings.GamePowerupActive || gameSettings.GamePowerup != gamePowerup.X2)
            {
                gameSettings.Score += gameSettings.Points;
            }
            else if ((gameSettings.GamePowerup == gamePowerup.X2 || gameSettings.GamePowerup == gamePowerup.X2PointOnTick ||
                      gameSettings.GamePowerup == gamePowerup.X2Slowmotion || gameSettings.GamePowerup == gamePowerup.X2Noclip) && 
                      gameSettings.GamePowerupActive)
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

        // Shrink the snake
        public void ShrinkSnake()
        {
            if (gameObject.Snake.Count > 1)
            {
                gameObject.Snake.RemoveAt(gameObject.Snake.Count - 1);
            }
        }

        // Kill the player
        private void Die()
        {
            if ((gameSettings.GamePowerup == gamePowerup.Noclip || gameSettings.GamePowerup == gamePowerup.X2Noclip ||
                 gameSettings.GamePowerup == gamePowerup.PointOnTickNoclip || gameSettings.GamePowerup == gamePowerup.SlowmotionNoclip) && 
                 gameSettings.GamePowerupActive || gameSettings.NoClipEnabled)
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
                growCnt = gameSettings.GrowMultiplicator;
                PlayGameSound(gameConstants.gameSound.SnakeDie);

                if (gameSettings.Score > gameSettings.HighScore && !gameSettings.IsModifierRound)
                {
                    writeScoreXML();
                    PlayGameSound(gameConstants.gameSound.NewHighscore);
                }
            }
        }

        // Gets passed in the gameSound that should be played and plays the corresponding sound resource
        public void PlayGameSound(gameConstants.gameSound sound)
        {
            SoundPlayer audio = new SoundPlayer();
            gameConstants.gameSound _sound = sound;

            // Handle specific sounds differently if needed 
            if (_sound == gameConstants.gameSound.ApplicationStartup && Debugger.IsAttached)
            {
                _sound = gameConstants.gameSound.None;
            }

            // Get a random number to determine a random sound
            Random random = new Random();
            int _randomSound = 0;

            if (_sound == gameConstants.gameSound.PUpX2Deactivate || _sound == gameConstants.gameSound.PUpPointTickDeactivate ||
                _sound == gameConstants.gameSound.PUpSlowmoDeactivate || _sound == gameConstants.gameSound.PUpNoclipDeactivate ||
                _sound == gameConstants.gameSound.PUpX2PointTickDeactivate || _sound == gameConstants.gameSound.PUpX2SlowmoDeactivate ||
                _sound == gameConstants.gameSound.PUpX2NoclipDeactivate || _sound == gameConstants.gameSound.PUpPointTickSlowmoDeactivate ||
                _sound == gameConstants.gameSound.PUpPointTickNoclipDeactivate || _sound == gameConstants.gameSound.PUpSlowmoNoclipDeactivate  ||
                _sound == gameConstants.gameSound.PUpX2PointTickSynergy || _sound == gameConstants.gameSound.PUpX2SlowmoSynergy ||
                _sound == gameConstants.gameSound.PUpX2NoclipSynergy || _sound == gameConstants.gameSound.PUpPointTickSlowmoSynergy ||
                _sound == gameConstants.gameSound.PUpPointTickNoclipSynergy || _sound == gameConstants.gameSound.PUpSlowmoNoclipSynergy)
            {
                _randomSound = random.Next(0, 2);
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
                case gameConstants.gameSound.NewHighscore:
                    audio = new SoundPlayer(Properties.Resources.gameSoundNewHighscore);
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
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01 
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpPointTickActivate:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPUpPointTick);
                    break;
                case gameConstants.gameSound.PUpPointTickDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpSlowmoActivate:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPUpSlowmotion);
                    break;
                case gameConstants.gameSound.PUpSlowmoDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpNoclipActivate:
                    audio = new SoundPlayer(Properties.Resources.gameSoundPUpNoclip);
                    break;
                case gameConstants.gameSound.PUpNoclipDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpX2PointTickSynergy:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpSynergy01
                                                              : Properties.Resources.gameSoundPUpSynergy02);
                    break;
                case gameConstants.gameSound.PUpX2PointTickDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpX2SlowmoSynergy:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpSynergy01
                                                              : Properties.Resources.gameSoundPUpSynergy02);
                    break;
                case gameConstants.gameSound.PUpX2SlowmoDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpX2NoclipSynergy:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpSynergy01
                                                              : Properties.Resources.gameSoundPUpSynergy02);
                    break;
                case gameConstants.gameSound.PUpX2NoclipDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpPointTickSlowmoSynergy:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpSynergy01
                                                              : Properties.Resources.gameSoundPUpSynergy02);
                    break;
                case gameConstants.gameSound.PUpPointTickSlowmoDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpPointTickNoclipSynergy:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpSynergy01
                                                              : Properties.Resources.gameSoundPUpSynergy02);
                    break;
                case gameConstants.gameSound.PUpPointTickNoclipDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
                                                              : Properties.Resources.gameSoundPUpDeactivate02);
                    break;
                case gameConstants.gameSound.PUpSlowmoNoclipSynergy:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpSynergy01
                                                              : Properties.Resources.gameSoundPUpSynergy02);
                    break;
                case gameConstants.gameSound.PUpSlowmoNoclipDeactivate:
                    audio = new SoundPlayer(_randomSound == 0 ? Properties.Resources.gameSoundPUpDeactivate01
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
            if (_sound != gameConstants.gameSound.None && _sound != gameConstants.gameSound.SnakeChangeDir && 
                _sound != gameConstants.gameSound.FoodSpawn)
            {
                if (_sound != gameConstants.gameSound.SnakeNoClip || (soundCheckTime != lastSoundPlayTime && (_sound == gameConstants.gameSound.SnakeNoClip)))
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
        public void readSettingsXML(string xmlPath)
        {
            try // Try to get the .xml data
            {
                // Open .xml
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(xmlPath);

                foreach (XmlNode _xmlParNode in _xmlDoc.ChildNodes)
                {
                    foreach (XmlNode _xmlNode in _xmlParNode.ChildNodes)
                    {
                        if (_xmlNode.Name == "Width" && _xmlParNode.Name == "Settings")
                        {
                            if ((Convert.ToInt32(_xmlNode.InnerText) > 200 && Convert.ToInt32(_xmlNode.InnerText) % 100 == 0 ||
                                 Convert.ToInt32(_xmlNode.InnerText) < 200 && Convert.ToInt32(_xmlNode.InnerText) % 2 == 0 && Convert.ToInt32(_xmlNode.InnerText) % 5 == 0) &&
                                 Convert.ToInt32(_xmlNode.InnerText) > 0 && Convert.ToInt32(_xmlNode.InnerText) <= 300)
                            {
                                gameSettings.Width = Convert.ToInt32(_xmlNode.InnerText);
                            }
                        }
                        if (_xmlNode.Name == "Height" && _xmlParNode.Name == "Settings")
                        {
                            if ((Convert.ToInt32(_xmlNode.InnerText) > 200 && Convert.ToInt32(_xmlNode.InnerText) % 100 == 0 ||
                                 Convert.ToInt32(_xmlNode.InnerText) < 200 && Convert.ToInt32(_xmlNode.InnerText) % 2 == 0 && Convert.ToInt32(_xmlNode.InnerText) % 5 == 0) &&
                                 Convert.ToInt32(_xmlNode.InnerText) > 0 && Convert.ToInt32(_xmlNode.InnerText) <= 300)
                            {
                                gameSettings.Height = Convert.ToInt32(_xmlNode.InnerText);
                            }
                        }
                        if (_xmlNode.Name == "Speed" && _xmlParNode.Name == "Settings")
                        {
                            if (Convert.ToInt32(_xmlNode.InnerText) > 0 && Convert.ToInt32(_xmlNode.InnerText) <= 1000)
                            {
                                gameSettings.Speed = Convert.ToInt32(_xmlNode.InnerText);
                            }
                        }
                        if (_xmlNode.Name == "GrowMultiplicator" && _xmlParNode.Name == "Settings")
                        {
                            if (Convert.ToInt32(_xmlNode.InnerText) >= 0)
                            {
                                gameSettings.GrowMultiplicator = Convert.ToInt32(_xmlNode.InnerText);
                                growCnt = gameSettings.GrowMultiplicator;
                            }
                        }
                        if (_xmlNode.Name == "Points" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.Points = Convert.ToInt32(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "DrawingMode" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.DrawingMode = (gameConstants.gameDrawingMode)Convert.ToInt32(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "RainbowMode" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.RainbowMode = (gameConstants.rainbowMode)Convert.ToInt32(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "PowerupSpawnGap" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupSpawnGap = Convert.ToInt32(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "PowerupDurationX2" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationX2 = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationPointTick" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationPointTick = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationSlowmo" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationSlowmo = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationNoclip" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationNoclip = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationX2PointTick" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationX2PointTick = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationX2Slowmo" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationX2Slowmo = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationX2Noclip" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationX2Noclip = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationPointTickSlowmo" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationPointTickSlowmo = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationPointTickNoclip" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationPointTickNoclip = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "PowerupDurationSlowmoNoclip" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.PowerupDurationSlowmoNoclip = ConvTime(Convert.ToInt32(_xmlNode.InnerText), gameConstants.seconds, gameConstants.milliseconds);
                        }
                        if (_xmlNode.Name == "snakeHeadNormalColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeHeadNormalColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeHeadPUpX2Color" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeHeadPUpX2Color = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeHeadPUpPointTickColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeHeadPUpPointTickColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeHeadPUpSlowmoColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeHeadPUpSlowmoColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeHeadPUpNoclipColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeHeadPUpNoclipColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeBodyNormalColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeBodyNormalColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeBodyPUpX2Color" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeBodyPUpX2Color = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeBodyPUpPointTickColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeBodyPUpPointTickColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeBodyPUpSlowmoColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeBodyPUpSlowmoColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "snakeBodyPUpNoclipColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.snakeBodyPUpNoclipColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "foodNormalColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.foodNormalColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "foodPUpX2Color" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.foodPUpX2Color = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "foodPUpPointTickColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.foodPUpPointTickColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "foodPUpSlowmoColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.foodPUpSlowmoColor = getBrush(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "foodPUpNoclipColor" && _xmlParNode.Name == "Settings")
                        {
                            gameSettings.foodPUpNoclipColor = getBrush(_xmlNode.InnerText);
                        }
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

        // Overload of readSettingsXML that always saves the standard settings .xml file
        public void readSettingsXML()
        {
            readSettingsXML(Properties.Settings.Default.settingsXmlPath);
        }

        // Write the settings to the .xml
        public void writeSettingsXML(string xmlPath, string xmlType)
        {
            bool _xmlFileCreated = false;

            // Create .xml
            do
            {
                try
                {
                    (new FileInfo(xmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet

                    _xmlFileCreated = true;
                }
                catch (Exception) // If xml cannot be created due to missing permissions save to the specified path
                {
                    MessageBox.Show("Unspecified error occured while creating the settings XML!\nSelect path instead.\noriginal Path=" + xmlPath,
                                    "Unexpected error while creating settings XML",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                    );

                    SaveFileDialog(xmlType);

                    _xmlFileCreated = false;
                }
            } while (!_xmlFileCreated);

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;
            XmlWriter _xmlDoc = XmlWriter.Create(xmlPath, xmlWriterSettings);
            _xmlDoc.WriteStartDocument();

            // Settings
            _xmlDoc.WriteStartElement("Settings");
                // Width
                _xmlDoc.WriteStartElement("Width"); 
                _xmlDoc.WriteString(gameSettings.Width.ToString());
                _xmlDoc.WriteEndElement();
                // Height
                _xmlDoc.WriteStartElement("Height"); 
                _xmlDoc.WriteString(gameSettings.Height.ToString());
                _xmlDoc.WriteEndElement();
                // Speed
                _xmlDoc.WriteStartElement("Speed"); 
                _xmlDoc.WriteString(gameSettings.Speed.ToString());
                _xmlDoc.WriteEndElement();
                // GrowMultiplicator
                _xmlDoc.WriteStartElement("GrowMultiplicator"); 
                _xmlDoc.WriteString(gameSettings.GrowMultiplicator.ToString());
                _xmlDoc.WriteEndElement();
                // Points
                _xmlDoc.WriteStartElement("Points"); 
                _xmlDoc.WriteString(gameSettings.Points.ToString());
                _xmlDoc.WriteEndElement();
                // DrawingMode
                _xmlDoc.WriteStartElement("DrawingMode");
                _xmlDoc.WriteString(Convert.ToString(Convert.ToInt32(gameSettings.DrawingMode)));
                _xmlDoc.WriteEndElement();
                // RainbowMode
                _xmlDoc.WriteStartElement("RainbowMode");
                _xmlDoc.WriteString(Convert.ToString(Convert.ToInt32(gameSettings.RainbowMode)));
                _xmlDoc.WriteEndElement();
                // PowerupSpawnGap         
                _xmlDoc.WriteStartElement("PowerupSpawnGap");
                _xmlDoc.WriteString(Convert.ToString(Convert.ToInt32(gameSettings.PowerupSpawnGapConfigured)));
                _xmlDoc.WriteEndElement();
                // PowerupDurationX2       
                _xmlDoc.WriteStartElement("PowerupDurationX2");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDurationPointTick
                _xmlDoc.WriteStartElement("PowerupDurationPointTick");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTick), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDurationSlowmo   
                _xmlDoc.WriteStartElement("PowerupDurationSlowmo");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationSlowmo), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDurationNoclip         
                _xmlDoc.WriteStartElement("PowerupDurationNoclip");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationNoclip), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDuration
                _xmlDoc.WriteStartElement("PowerupDurationX2PointTick");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2PointTick), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDuration
                _xmlDoc.WriteStartElement("PowerupDurationX2Slowmo");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2Slowmo), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDuration
                _xmlDoc.WriteStartElement("PowerupDurationX2Noclip");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2Noclip), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDuration
                _xmlDoc.WriteStartElement("PowerupDurationPointTickSlowmo");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTickSlowmo), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDuration
                _xmlDoc.WriteStartElement("PowerupDurationPointTickNoclip");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTickNoclip), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // PowerupDuration
                _xmlDoc.WriteStartElement("PowerupDurationSlowmoNoclip");
                _xmlDoc.WriteString(Convert.ToString(ConvTime(Convert.ToInt32(gameSettings.PowerupDurationSlowmoNoclip), gameConstants.milliseconds, gameConstants.seconds)));
                _xmlDoc.WriteEndElement();
                // snakeHeadNormalColor      
                _xmlDoc.WriteStartElement("snakeHeadNormalColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadNormalColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeHeadPUpX2Color       
                _xmlDoc.WriteStartElement("snakeHeadPUpX2Color");
                _xmlDoc.WriteString(((gameSettings.snakeHeadPUpX2Color as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeHeadPUpPointTickColor
                _xmlDoc.WriteStartElement("snakeHeadPUpPointTickColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadPUpPointTickColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeHeadPUpSlowmoColor   
                _xmlDoc.WriteStartElement("snakeHeadPUpSlowmoColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadPUpSlowmoColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeHeadPUpNoclipColor   
                _xmlDoc.WriteStartElement("snakeHeadPUpNoclipColor");
                _xmlDoc.WriteString(((gameSettings.snakeHeadPUpNoclipColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeBodyNormalColor      
                _xmlDoc.WriteStartElement("snakeBodyNormalColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyNormalColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeBodyPUpX2Color       
                _xmlDoc.WriteStartElement("snakeBodyPUpX2Color");
                _xmlDoc.WriteString(((gameSettings.snakeBodyPUpX2Color as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeBodyPUpPointTickColor
                _xmlDoc.WriteStartElement("snakeBodyPUpPointTickColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyPUpPointTickColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeBodyPUpSlowmoColor   
                _xmlDoc.WriteStartElement("snakeBodyPUpSlowmoColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyPUpSlowmoColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // snakeBodyPUpNoclipColor   
                _xmlDoc.WriteStartElement("snakeBodyPUpNoclipColor");
                _xmlDoc.WriteString(((gameSettings.snakeBodyPUpNoclipColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // foodNormalColor           
                _xmlDoc.WriteStartElement("foodNormalColor");
                _xmlDoc.WriteString(((gameSettings.foodNormalColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // foodPUpX2Color            
                _xmlDoc.WriteStartElement("foodPUpX2Color");
                _xmlDoc.WriteString(((gameSettings.foodPUpX2Color as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // foodPUpPointTickColor     
                _xmlDoc.WriteStartElement("foodPUpPointTickColor");
                _xmlDoc.WriteString(((gameSettings.foodPUpPointTickColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // foodPUpSlowmoColor        
                _xmlDoc.WriteStartElement("foodPUpSlowmoColor");
                _xmlDoc.WriteString(((gameSettings.foodPUpSlowmoColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
                // foodPUpNoclipColor        
                _xmlDoc.WriteStartElement("foodPUpNoclipColor");
                _xmlDoc.WriteString(((gameSettings.foodPUpNoclipColor as SolidBrush).Color).ToString());
                _xmlDoc.WriteEndElement();
            // End .xml
            _xmlDoc.WriteEndDocument();
            _xmlDoc.Flush();
            _xmlDoc.Close(); // Close .xml
        }

        // Overload of writeSettingsXML that always saves the standard settings .xml file
        public void writeSettingsXML()
        {
            writeSettingsXML(Properties.Settings.Default.settingsXmlPath, gameConstants.settingsXML);
        }

        // Get the key config from the .xml
        public void readControlsXML()
        {
            try // Try to get the .xml data
            {
                // Open .xml
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(Properties.Settings.Default.controlsXmlPath);

                foreach (XmlNode _xmlParNode in _xmlDoc.ChildNodes)
                {
                    foreach (XmlNode _xmlNode in _xmlParNode.ChildNodes)
                    {
                        if (_xmlNode.Name == "UpKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.dirUpKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "DownKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.dirDownKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "LeftKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.dirLeftKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "RightKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.dirRightKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "RestartKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.modRestartKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "BotKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.modBotKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "SpeedKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.modSpeedKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "PauseKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.modPauseKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "NoClipKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.modNoClipKey = getKey(_xmlNode.InnerText);
                        }
                        if (_xmlNode.Name == "PowerupKey" && _xmlParNode.Name == "Controls")
                        {
                            gameControls.modPowerupKey = getKey(_xmlNode.InnerText);
                        }
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
            bool _xmlFileCreated = false;

            // Create .xml
            do
            {
                try
                {
                    (new FileInfo(Properties.Settings.Default.controlsXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet

                    _xmlFileCreated = true;
                }
                catch (UnauthorizedAccessException) // If xml cannot be created due to missing permissions save to the specified path
                {
                    MessageBox.Show("Unspecified error occured while creating the controls XML!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.controlsXmlPath,
                                    "Unexpected error while creating settings XML",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                    );

                    SaveFileDialog(gameConstants.controlsXML);

                    _xmlFileCreated = false;
                }
            } while (!_xmlFileCreated);
            
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;
            XmlWriter _xmlDoc = XmlWriter.Create(Properties.Settings.Default.controlsXmlPath, xmlWriterSettings);
            _xmlDoc.WriteStartDocument();

            // Controls
            _xmlDoc.WriteStartElement("Controls");
                // Up Key
                _xmlDoc.WriteStartElement("UpKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.dirUpKey));
                _xmlDoc.WriteEndElement();
                // Down Key
                _xmlDoc.WriteStartElement("DownKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.dirDownKey));
                _xmlDoc.WriteEndElement();
                // Left Key
                _xmlDoc.WriteStartElement("LeftKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.dirLeftKey));
                _xmlDoc.WriteEndElement();
                // Right Key
                _xmlDoc.WriteStartElement("RightKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.dirRightKey));
                _xmlDoc.WriteEndElement();
                // Restart Key
                _xmlDoc.WriteStartElement("RestartKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modRestartKey));
                _xmlDoc.WriteEndElement();
                // Bot Key
                _xmlDoc.WriteStartElement("BotKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modBotKey));
                _xmlDoc.WriteEndElement();
                // Speed Key
                _xmlDoc.WriteStartElement("SpeedKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modSpeedKey));
                _xmlDoc.WriteEndElement();
                // Pause Key
                _xmlDoc.WriteStartElement("PauseKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modPauseKey));
                _xmlDoc.WriteEndElement();
                // NoClip Key
                _xmlDoc.WriteStartElement("NoClipKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modNoClipKey));
                _xmlDoc.WriteEndElement();
                // Powerup Key
                _xmlDoc.WriteStartElement("PowerupKey");
                _xmlDoc.WriteString(Convert.ToString(gameControls.modPowerupKey));
                _xmlDoc.WriteEndElement();
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

                foreach (XmlNode _xmlParNode in _xmlDoc.ChildNodes)
                {
                    foreach (XmlNode _xmlNode in _xmlParNode)
                    {
                        if (_xmlNode.Name == "HighScore" && _xmlParNode.Name == "Scores")
                        {
                            gameSettings.HighScore = Convert.ToInt32(_xmlNode.InnerText);
                        }
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
            bool _xmlFileCreated = false;

            // Create .xml
            do
            {
                try
                {
                    (new FileInfo(Properties.Settings.Default.scoreXmlPath)).Directory.Create(); // Create the xml path in case it hasn't been created yet

                    _xmlFileCreated = true;
                }
                catch (UnauthorizedAccessException) // If xml cannot be created due to missing permissions save to the specified path
                {
                    MessageBox.Show("Unspecified error occured while creating the score XML!\nSelect path instead.\noriginal Path=" + Properties.Settings.Default.scoreXmlPath,
                                    "Unexpected error while creating settings XML",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                    );

                    SaveFileDialog(gameConstants.scoreXML);

                    _xmlFileCreated = false;
                }
            } while (!_xmlFileCreated);

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;
            XmlWriter _xmlDoc = XmlWriter.Create(Properties.Settings.Default.scoreXmlPath, xmlWriterSettings);

            _xmlDoc.WriteStartDocument();

            // Scores
            _xmlDoc.WriteStartElement("Scores");
                // HighScore
                _xmlDoc.WriteStartElement("HighScore");
                _xmlDoc.WriteString(gameSettings.Score.ToString());
                _xmlDoc.WriteEndElement();
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

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpX2PointTickPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpX2PointTick);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpX2PointTick);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpX2Slowmotion);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpX2Slowmotion);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpX2NoclipPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpX2Noclip);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpX2Noclip);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpPointTickSlowmotion);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpPointTickSlowmotion);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpPointTickNoclip);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpPointTickNoclip);
            }

            if (!File.Exists(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath))
            {
                SaveGameSprites(gameConstants.gameSpritesPUpSlowmotionNoclip);
            }
            else
            {
                LoadGameSprites(gameConstants.gameSpritesPUpSlowmotionNoclip);
            }

        }

        // Resets all gameSprite files
        public void ResetAllGameSprites()
        {
            DialogResult result = MessageBox.Show("Do you want to reset all game sprites now?\nThe program will restart to complete the operation.",
                                                  "Reset game sprites?",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning
                                                 );

            if (result == DialogResult.Yes)
            {
                gameSettings.initGameSprites();

                gameInterface.gameSprite.Save(Properties.Settings.Default.gameSpritePath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpX2.Save(Properties.Settings.Default.gameSpritePUpX2Path + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpPointTick.Save(Properties.Settings.Default.gameSpritePUpPointTickPath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpSlowmotion.Save(Properties.Settings.Default.gameSpritePUpSlowmotionPath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpNoclip.Save(Properties.Settings.Default.gameSpritePUpNoclipPath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpX2PointTick.Save(Properties.Settings.Default.gameSpritePUpX2PointTickPath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpX2Slowmotion.Save(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpX2Noclip.Save(Properties.Settings.Default.gameSpritePUpX2NoclipPath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpPointTickSlowmotion.Save(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpPointTickNoclip.Save(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath + ".tmp", ImageFormat.Png);
                gameInterface.gameSpritePUpSlowmotionNoclip.Save(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath + ".tmp", ImageFormat.Png);

                // Restart the program using specific command args
                Program.RestartApplication(gameConstants.resetSpriteArgs);
            }
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
                            "Unspecified error occurred while saving gameSprite.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePath,
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
                            "Unspecified error occurred while saving gameSpritePUpX2.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpX2Path,
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
                            "Unspecified error occurred while saving gameSpritePUpPointTick.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpPointTickPath,
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
                            "Unspecified error occurred while saving gameSpritePUpSlowmotion.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpSlowmotionPath,
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
                            "Unspecified error occurred while saving gameSpritePUpNoclip.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpNoclipPath,
                            "Unexpected error while creating gameSpritePUpNoclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpNoclip);
                    }
                    break;
                case gameConstants.gameSpritesPUpX2PointTick:
                    try
                    {
                        gameInterface.gameSpritePUpX2PointTick.Save(Properties.Settings.Default.gameSpritePUpX2PointTickPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpX2PointTick.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpX2PointTickPath,
                            "Unexpected error while creating gameSpritePUpX2PointTick.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpX2PointTick);
                    }
                    break;
                case gameConstants.gameSpritesPUpX2Slowmotion:
                    try
                    {
                        gameInterface.gameSpritePUpX2Slowmotion.Save(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpX2Slowmotion.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpX2SlowmotionPath,
                            "Unexpected error while creating gameSpritePUpX2Slowmotion.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpX2Slowmotion);
                    }
                    break;
                case gameConstants.gameSpritesPUpX2Noclip:
                    try
                    {
                        gameInterface.gameSpritePUpX2Noclip.Save(Properties.Settings.Default.gameSpritePUpX2NoclipPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpX2Noclip.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpX2NoclipPath,
                            "Unexpected error while creating gameSpritePUpX2Noclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpX2Noclip);
                    }
                    break;
                case gameConstants.gameSpritesPUpPointTickSlowmotion:
                    try
                    {
                        gameInterface.gameSpritePUpPointTickSlowmotion.Save(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpPointTickSlowmotion.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath,
                            "Unexpected error while creating gameSpritePUpPointTickSlowmotion.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpPointTickSlowmotion);
                    }
                    break;
                case gameConstants.gameSpritesPUpPointTickNoclip:
                    try
                    {
                        gameInterface.gameSpritePUpPointTickNoclip.Save(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePointTickNoclip.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpPointTickNoclipPath,
                            "Unexpected error while creating gameSpritePointTickNoclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpPointTickNoclip);
                    }
                    break;
                case gameConstants.gameSpritesPUpSlowmotionNoclip:
                    try
                    {
                        gameInterface.gameSpritePUpSlowmotionNoclip.Save(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while saving gameSpritePUpSlowmotionNoclip.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath,
                            "Unexpected error while creating gameSpritePUpSlowmotionNoclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        SaveFileDialog(gameConstants.gameSpritesPUpSlowmotionNoclip);
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
            LoadGameSprites(gameConstants.gameSpritesPUpX2PointTick);
            LoadGameSprites(gameConstants.gameSpritesPUpX2Slowmotion);
            LoadGameSprites(gameConstants.gameSpritesPUpX2Noclip);
            LoadGameSprites(gameConstants.gameSpritesPUpPointTickSlowmotion);
            LoadGameSprites(gameConstants.gameSpritesPUpPointTickNoclip);
            LoadGameSprites(gameConstants.gameSpritesPUpSlowmotionNoclip);
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
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSprite.png!\nSelect path instead.\noriginal Path=" +
                            Properties.Settings.Default.gameSpritePath,
                            "Unexpected error while loading gameSprite.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSprites);
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
                            "Unspecified error occurred while loading gameSpritePUpX2.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpX2Path,
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
                            "Unspecified error occurred while loading gameSpritePUpPointTick.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpPointTickPath,
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
                            "Unspecified error occurred while loading gameSpritePUpSlowmotion.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpSlowmotionPath,
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
                            "Unspecified error occurred while loading gameSpritePUpNoclip.png!\nSelect path instead.\noriginal Path=" + 
                            Properties.Settings.Default.gameSpritePUpNoclipPath,
                            "Unexpected error while loading gameSpritePUpNoclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpNoclip);
                    }
                    break;
                case gameConstants.gameSpritesPUpX2PointTick:
                    try
                    {
                        gameInterface.gameSpritePUpX2PointTick = Image.FromFile(Properties.Settings.Default.gameSpritePUpX2PointTickPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpX2PointTick.png!\nSelect path instead.\noriginal Path=" +
                            Properties.Settings.Default.gameSpritePUpX2PointTickPath,
                            "Unexpected error while loading gameSpritePUpX2PointTick.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpX2PointTick);
                    }
                    break;
                case gameConstants.gameSpritesPUpX2Slowmotion:
                    try
                    {
                        gameInterface.gameSpritePUpX2Slowmotion = Image.FromFile(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpX2Slowmotion.png!\nSelect path instead.\noriginal Path=" +
                            Properties.Settings.Default.gameSpritePUpX2SlowmotionPath,
                            "Unexpected error while loading gameSpritePUpX2Slowmotion.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpX2Slowmotion);
                    }
                    break;
                case gameConstants.gameSpritesPUpX2Noclip:
                    try
                    {
                        gameInterface.gameSpritePUpX2Noclip = Image.FromFile(Properties.Settings.Default.gameSpritePUpX2NoclipPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpX2Noclip.png!\nSelect path instead.\noriginal Path=" +
                            Properties.Settings.Default.gameSpritePUpX2NoclipPath,
                            "Unexpected error while loading gameSpritePUpX2Noclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpX2Noclip);
                    }
                    break;
                case gameConstants.gameSpritesPUpPointTickSlowmotion:
                    try
                    {
                        gameInterface.gameSpritePUpPointTickSlowmotion = Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpPointTickSlowmotion.png!\nSelect path instead.\noriginal Path=" +
                            Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath,
                            "Unexpected error while loading gameSpritePUpPointTickSlowmotion.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpPointTickSlowmotion);
                    }
                    break;
                case gameConstants.gameSpritesPUpPointTickNoclip:
                    try
                    {
                        gameInterface.gameSpritePUpPointTickNoclip = Image.FromFile(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePointTickNoclip.png!\nSelect path instead.\noriginal Path=" +
                            Properties.Settings.Default.gameSpritePUpPointTickNoclipPath,
                            "Unexpected error while loading gameSpritePointTickNoclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpPointTickNoclip);
                    }
                    break;
                case gameConstants.gameSpritesPUpSlowmotionNoclip:
                    try
                    {
                        gameInterface.gameSpritePUpSlowmotionNoclip = Image.FromFile(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Unspecified error occurred while loading gameSpritePUpSlowmotionNoclip.png!\nSelect path instead.\noriginal Path=" +
                            Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath,
                            "Unexpected error while loading gameSpritePUpSlowmotionNoclip.png",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );

                        OpenFileDialog(gameConstants.gameSpritesPUpSlowmotionNoclip);
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

        // To save or load 'Devmode' settings
        public void SaveLoadDevmodeSettings()
        {
            gameSettings.Width = gameConstants.devmodeWidth;
            gameSettings.Height = gameConstants.devmodeHeight;
            gameSettings.Speed = gameConstants.devmodeSpeed;
            gameSettings.Score = gameConstants.devmodeScore;
            gameSettings.GrowMultiplicator = gameConstants.devmodeGrowMultiplicator;
            gameSettings.Points = gameConstants.devmodePoints;
            gameSettings.PowerupSpawnGapConfigured = gameConstants.devmodePowerupSpawnGap;
            gameSettings.GameOver = true;

            if (!File.Exists(Properties.Settings.Default.settingsDeveloperXmlPath))
            {
                SaveFileDialog(gameConstants.settingsDeveloperXML);
            }
            else
            {
                readSettingsXML(Properties.Settings.Default.settingsDeveloperXmlPath);
                Properties.Settings.Default.settingsXmlPath = Properties.Settings.Default.settingsDeveloperXmlPath;
            }
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
                case gameConstants.gameSpritesPUpX2PointTick:
                    _filePath = Properties.Settings.Default.gameSpritePUpX2PointTickPath.Substring(0, Properties.Settings.Default.gameSpritePUpX2PointTickPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpX2Slowmotion:
                    _filePath = Properties.Settings.Default.gameSpritePUpX2SlowmotionPath.Substring(0, Properties.Settings.Default.gameSpritePUpX2SlowmotionPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpX2Noclip:
                    _filePath = Properties.Settings.Default.gameSpritePUpX2NoclipPath.Substring(0, Properties.Settings.Default.gameSpritePUpX2NoclipPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpPointTickSlowmotion:
                    _filePath = Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath.Substring(0, Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpPointTickNoclip:
                    _filePath = Properties.Settings.Default.gameSpritePUpPointTickNoclipPath.Substring(0, Properties.Settings.Default.gameSpritePUpPointTickNoclipPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpSlowmotionNoclip:
                    _filePath = Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath.Substring(0, Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath.LastIndexOf("\\") + 1);
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
                case gameConstants.gameSpritesPUpX2PointTick:
                case gameConstants.gameSpritesPUpX2Slowmotion:
                case gameConstants.gameSpritesPUpX2Noclip:
                case gameConstants.gameSpritesPUpPointTickSlowmotion:
                case gameConstants.gameSpritesPUpPointTickNoclip:
                case gameConstants.gameSpritesPUpSlowmotionNoclip:
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
                    case gameConstants.gameSpritesPUpX2PointTick:
                        Properties.Settings.Default.gameSpritePUpX2PointTickPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpX2Slowmotion:
                        Properties.Settings.Default.gameSpritePUpX2SlowmotionPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpX2Noclip:
                        Properties.Settings.Default.gameSpritePUpX2NoclipPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpPointTickSlowmotion:
                        Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpPointTickNoclip:
                        Properties.Settings.Default.gameSpritePUpPointTickNoclipPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpSlowmotionNoclip:
                        Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath = _filePath;
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
                        case gameConstants.gameSpritesPUpX2PointTick:
                        case gameConstants.gameSpritesPUpX2Slowmotion:
                        case gameConstants.gameSpritesPUpX2Noclip:
                        case gameConstants.gameSpritesPUpPointTickSlowmotion:
                        case gameConstants.gameSpritesPUpPointTickNoclip:
                        case gameConstants.gameSpritesPUpSlowmotionNoclip:
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
                case gameConstants.gameSpritesPUpX2PointTick:
                    _filePath = Properties.Settings.Default.gameSpritePUpX2PointTickPath.Substring(0, Properties.Settings.Default.gameSpritePUpX2PointTickPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpX2Slowmotion:
                    _filePath = Properties.Settings.Default.gameSpritePUpX2SlowmotionPath.Substring(0, Properties.Settings.Default.gameSpritePUpX2SlowmotionPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpX2Noclip:
                    _filePath = Properties.Settings.Default.gameSpritePUpX2NoclipPath.Substring(0, Properties.Settings.Default.gameSpritePUpX2NoclipPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpPointTickSlowmotion:
                    _filePath = Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath.Substring(0, Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpPointTickNoclip:
                    _filePath = Properties.Settings.Default.gameSpritePUpPointTickNoclipPath.Substring(0, Properties.Settings.Default.gameSpritePUpPointTickNoclipPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.gameSpritesPUpSlowmotionNoclip:
                    _filePath = Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath.Substring(0, Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath.LastIndexOf("\\") + 1);
                    break;
                case gameConstants.settingsDeveloperXML:
                    _filePath = Properties.Settings.Default.settingsDeveloperXmlPath.Substring(0, Properties.Settings.Default.settingsDeveloperXmlPath.LastIndexOf("\\") + 1);
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
                case gameConstants.settingsDeveloperXML:
                    saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files(*.*)|*.*";
                    break;
                case gameConstants.gameSprites:
                case gameConstants.gameSpritesPUpX2:
                case gameConstants.gameSpritesPUpPointTick:
                case gameConstants.gameSpritesPUpSlowmotion:
                case gameConstants.gameSpritesPUpNoclip:
                case gameConstants.gameSpritesPUpX2PointTick:
                case gameConstants.gameSpritesPUpX2Slowmotion:
                case gameConstants.gameSpritesPUpX2Noclip:
                case gameConstants.gameSpritesPUpPointTickSlowmotion:
                case gameConstants.gameSpritesPUpPointTickNoclip:
                case gameConstants.gameSpritesPUpSlowmotionNoclip:
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
                    case gameConstants.gameSpritesPUpX2PointTick:
                        Properties.Settings.Default.gameSpritePUpX2PointTickPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpX2Slowmotion:
                        Properties.Settings.Default.gameSpritePUpX2SlowmotionPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpX2Noclip:
                        Properties.Settings.Default.gameSpritePUpX2NoclipPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpPointTickSlowmotion:
                        Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpPointTickNoclip:
                        Properties.Settings.Default.gameSpritePUpPointTickNoclipPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.gameSpritesPUpSlowmotionNoclip:
                        Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath = _filePath;
                        _doSave = true;
                        break;
                    case gameConstants.settingsDeveloperXML:
                        Properties.Settings.Default.settingsDeveloperXmlPath = _filePath;
                        Properties.Settings.Default.settingsXmlPath = Properties.Settings.Default.settingsDeveloperXmlPath;
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
                        case gameConstants.gameSpritesPUpX2PointTick:
                        case gameConstants.gameSpritesPUpX2Slowmotion:
                        case gameConstants.gameSpritesPUpX2Noclip:
                        case gameConstants.gameSpritesPUpPointTickSlowmotion:
                        case gameConstants.gameSpritesPUpPointTickNoclip:
                        case gameConstants.gameSpritesPUpSlowmotionNoclip:
                            SaveGameSprites(_fileType);
                            break;

                        case gameConstants.settingsDeveloperXML:
                            writeSettingsXML(_filePath, gameConstants.settingsDeveloperXML);
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

        public void SetScore( Label labelScoreValue)
        {
            labelScoreValue.Text = gameSettings.Score.ToString();
        }

        public void SetHighScore(Label labelHighScoreValue)
        {
            labelHighScoreValue.Text = gameSettings.HighScore.ToString();
        }

        // Sets the values for the powerup controls
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
                    _CurrentPowerup = "Point Tick";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTick - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.Slowmotion:
                    _CurrentPowerup = "Slowmo";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationSlowmo - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.Noclip:
                    _CurrentPowerup = "NoClip";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationNoclip - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.X2PointOnTick:
                    _CurrentPowerup = "x2 Points + Point Tick";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2PointTick - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.X2Slowmotion:
                    _CurrentPowerup = "x2 Points + Slowmo";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2Slowmo - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.X2Noclip:
                    _CurrentPowerup = "x2 Points + Noclip";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationX2Noclip - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.PointOnTickSlowmotion:
                    _CurrentPowerup = "Point Tick + Slowmo";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTickSlowmo - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.PointOnTickNoclip:
                    _CurrentPowerup = "Point Tick + Noclip";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationPointTickNoclip - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
                case gamePowerup.SlowmotionNoclip:
                    _CurrentPowerup = "Slowmo + Noclip";
                    _PowerupDuration = ConvTime(Convert.ToInt32(gameSettings.PowerupDurationSlowmoNoclip - (currentTime - lastChangeTime)), gameConstants.milliseconds, gameConstants.seconds);
                    break;
            }

            switch (gameSettings.SavedPowerup)
            {
                case gamePowerup.X2:
                    _SavedPowerup = "x2 Points";
                    break;
                case gamePowerup.PointOnTick:
                    _SavedPowerup = "Point Tick";
                    break;
                case gamePowerup.Slowmotion:
                    _SavedPowerup = "Slowmo";
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

        public void SetTimerInterval(Timer timer, int interval, bool isGameTime)
        {
            // Determine whether speed has to be converted to gametime or not
            timer.Interval = isGameTime ? ConvTime(interval, gameConstants.gameSpeed, gameConstants.gameTime) : interval;
        }

        #endregion
    }
}
