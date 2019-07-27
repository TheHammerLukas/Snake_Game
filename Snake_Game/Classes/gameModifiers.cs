using System;

namespace Snake_Game
{
    class gameModifiers
    {
        // Logic for the bot
        public void BotLogic()
        {
            // Check if the bot is enabled
            if (gameSettings.BotEnabled)
            {
                // If bot is at the top row
                if (gameObject.Snake[0].Y == 0)
                {
                    if (gameObject.Snake[0].X == 0)
                    {
                        gameSettings.directionHead = gameDirection.Down;
                    }
                    else
                    {
                        gameSettings.directionHead = gameDirection.Left;
                    }
                }
                // If bot is at the bottom row
                else if (gameObject.Snake[0].Y == gameController.maxPosY - 1)
                {
                    if (gameObject.Snake[0].X == gameController.maxPosX - 1)
                    {
                        gameSettings.directionHead = gameDirection.Up;
                    }
                    else
                    {
                        gameSettings.directionHead = gameDirection.Right;
                    }
                }
                // If bot is between top and bottom row -> leave one column space
                else if (gameObject.Snake[0].X == 1 || gameObject.Snake[0].X == gameController.maxPosX - 1)
                {
                    if (gameSettings.directionHead == gameDirection.Left || gameSettings.directionHead == gameDirection.Right)
                    {
                        gameSettings.directionHead = gameDirection.Up;
                    }
                    else if (gameObject.Snake[0].X == 1)
                    {
                        gameSettings.directionHead = gameDirection.Right;
                    }
                    else if (gameObject.Snake[0].X == gameController.maxPosX - 1)
                    {
                        gameSettings.directionHead = gameDirection.Left;
                    }
                }
            }
        }
    }
}
