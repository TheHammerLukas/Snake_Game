using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new gameController().PlayGameSound(gameConstants.gameSound.ApplicationStartup);
            // Handle command line args
            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains(gameConstants.resetSpriteArgs))
            {
                // Delete files to be reset
                try
                {
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpX2Path);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpPointTickPath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpSlowmotionPath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpNoclipPath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpX2PointTickPath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpX2NoclipPath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath);
                    System.IO.File.Delete(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occurred while deleting .png files!\ncommand line arguments=" + listCmdArgs(args),
                                    "Error occurred while resetting sprites!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                   );
                }

                // Rename .tmp files to actually "reset" the previously deleted files
                try
                {
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePath + ".tmp", Properties.Settings.Default.gameSpritePath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpX2Path + ".tmp", Properties.Settings.Default.gameSpritePUpX2Path);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpPointTickPath + ".tmp", Properties.Settings.Default.gameSpritePUpPointTickPath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpSlowmotionPath + ".tmp", Properties.Settings.Default.gameSpritePUpSlowmotionPath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpNoclipPath + ".tmp", Properties.Settings.Default.gameSpritePUpNoclipPath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpX2PointTickPath + ".tmp", Properties.Settings.Default.gameSpritePUpX2PointTickPath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpX2SlowmotionPath + ".tmp", Properties.Settings.Default.gameSpritePUpX2SlowmotionPath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpX2NoclipPath + ".tmp", Properties.Settings.Default.gameSpritePUpX2NoclipPath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath + ".tmp", Properties.Settings.Default.gameSpritePUpPointTickSlowmotionPath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpPointTickNoclipPath + ".tmp", Properties.Settings.Default.gameSpritePUpPointTickNoclipPath);
                    System.IO.File.Move(Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath + ".tmp", Properties.Settings.Default.gameSpritePUpSlowmotionNoclipPath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occurred while renaming .tmp files!\ncommand line arguments=" + listCmdArgs(args),
                                    "Error occurred while resetting sprites!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                   );
                }
            }
            Application.Run(new gameInterface());
        }

        public static void RestartApplication(string restartArgs)
        {
            ProcessStartInfo startInfo = Process.GetCurrentProcess().StartInfo;
            startInfo.FileName = Application.ExecutablePath;
            var exit = typeof(Application).GetMethod("ExitInternal",
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Static);
            var newArgs = restartArgs;
            startInfo.Arguments = newArgs;
            exit.Invoke(null, null);
            Process.Start(startInfo);
        }

        // returns a semicolon seperated list of all command line args
        private static string listCmdArgs(string[] args)
        {
            string cmdArgs = "";
            int argCnt = 0;

            foreach (string argsValue in args)
            {
                // Do not list the first argument
                if (argCnt != 0)
                {
                    cmdArgs = cmdArgs + argsValue + ";";
                }

                argCnt++;
            }

            return cmdArgs;
        }
    }
}
