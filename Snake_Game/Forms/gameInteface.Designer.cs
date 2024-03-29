﻿namespace Snake_Game
{
    partial class gameInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemModifiersLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameInterface));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelHighscore = new System.Windows.Forms.Label();
            this.labelScoreValue = new System.Windows.Forms.Label();
            this.labelHighscoreValue = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.heightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heightToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.growMultiplicatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.growMultiplicatorToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNoClip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSpeed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBot = new System.Windows.Forms.ToolStripMenuItem();
            this.milliSecondTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxPowerup = new System.Windows.Forms.GroupBox();
            this.labelPowerupTimerValue = new System.Windows.Forms.Label();
            this.labelPowerupTimer = new System.Windows.Forms.Label();
            this.labelSavedPowerupValue = new System.Windows.Forms.Label();
            this.labelCurrentPowerupValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentPowerup = new System.Windows.Forms.Label();
            ToolStripMenuItemModifiersLabel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxPowerup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripMenuItemModifiersLabel
            // 
            ToolStripMenuItemModifiersLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            ToolStripMenuItemModifiersLabel.Name = "ToolStripMenuItemModifiersLabel";
            ToolStripMenuItemModifiersLabel.Size = new System.Drawing.Size(72, 20);
            ToolStripMenuItemModifiersLabel.Text = "Modifiers:";
            ToolStripMenuItemModifiersLabel.ToolTipText = "If any modifier is enabled, no new Highscore can be set!";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pictureBox.Location = new System.Drawing.Point(12, 80);
            this.pictureBox.MaximumSize = new System.Drawing.Size(600, 600);
            this.pictureBox.MinimumSize = new System.Drawing.Size(600, 600);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 600);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(48, 49);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(70, 25);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Score:";
            // 
            // labelHighscore
            // 
            this.labelHighscore.AutoSize = true;
            this.labelHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHighscore.Location = new System.Drawing.Point(12, 24);
            this.labelHighscore.Name = "labelHighscore";
            this.labelHighscore.Size = new System.Drawing.Size(106, 25);
            this.labelHighscore.TabIndex = 2;
            this.labelHighscore.Text = "Highscore:";
            // 
            // labelScoreValue
            // 
            this.labelScoreValue.AutoSize = true;
            this.labelScoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreValue.Location = new System.Drawing.Point(124, 49);
            this.labelScoreValue.Name = "labelScoreValue";
            this.labelScoreValue.Size = new System.Drawing.Size(156, 25);
            this.labelScoreValue.TabIndex = 4;
            this.labelScoreValue.Text = "labelScoreValue";
            // 
            // labelHighscoreValue
            // 
            this.labelHighscoreValue.AutoSize = true;
            this.labelHighscoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHighscoreValue.Location = new System.Drawing.Point(124, 24);
            this.labelHighscoreValue.Name = "labelHighscoreValue";
            this.labelHighscoreValue.Size = new System.Drawing.Size(192, 25);
            this.labelHighscoreValue.TabIndex = 3;
            this.labelHighscoreValue.Text = "labelHighscoreValue";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // widthToolStripTextBox
            // 
            this.widthToolStripTextBox.Name = "widthToolStripTextBox";
            this.widthToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // heightToolStripMenuItem
            // 
            this.heightToolStripMenuItem.Name = "heightToolStripMenuItem";
            this.heightToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // heightToolStripTextBox
            // 
            this.heightToolStripTextBox.Name = "heightToolStripTextBox";
            this.heightToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // speedToolStripTextBox
            // 
            this.speedToolStripTextBox.Name = "speedToolStripTextBox";
            this.speedToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // growMultiplicatorToolStripMenuItem
            // 
            this.growMultiplicatorToolStripMenuItem.Name = "growMultiplicatorToolStripMenuItem";
            this.growMultiplicatorToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // growMultiplicatorToolStripTextBox
            // 
            this.growMultiplicatorToolStripTextBox.Name = "growMultiplicatorToolStripTextBox";
            this.growMultiplicatorToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // pointsToolStripMenuItem
            // 
            this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
            this.pointsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pointsToolStripTextBox
            // 
            this.pointsToolStripTextBox.Name = "pointsToolStripTextBox";
            this.pointsToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMenu,
            this.toolStripMenuItemNoClip,
            this.toolStripMenuItemSpeed,
            this.toolStripMenuItemBot,
            ToolStripMenuItemModifiersLabel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemMenu
            // 
            this.toolStripMenuItemMenu.Name = "toolStripMenuItemMenu";
            this.toolStripMenuItemMenu.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItemMenu.Text = "Menu";
            this.toolStripMenuItemMenu.Click += new System.EventHandler(this.toolStripMenuItemMenu_Click);
            // 
            // toolStripMenuItemNoClip
            // 
            this.toolStripMenuItemNoClip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemNoClip.BackColor = System.Drawing.Color.Red;
            this.toolStripMenuItemNoClip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripMenuItemNoClip.Name = "toolStripMenuItemNoClip";
            this.toolStripMenuItemNoClip.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItemNoClip.Text = "NoClip";
            this.toolStripMenuItemNoClip.ToolTipText = "If any modifier is enabled, no new Highscore can be set!";
            this.toolStripMenuItemNoClip.Click += new System.EventHandler(this.toolStripMenuItemNoClip_Click);
            // 
            // toolStripMenuItemSpeed
            // 
            this.toolStripMenuItemSpeed.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemSpeed.BackColor = System.Drawing.Color.Red;
            this.toolStripMenuItemSpeed.Name = "toolStripMenuItemSpeed";
            this.toolStripMenuItemSpeed.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItemSpeed.Text = "Speed";
            this.toolStripMenuItemSpeed.ToolTipText = "If any modifier is enabled, no new Highscore can be set!";
            this.toolStripMenuItemSpeed.Click += new System.EventHandler(this.toolStripMenuItemSpeed_Click);
            // 
            // toolStripMenuItemBot
            // 
            this.toolStripMenuItemBot.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemBot.BackColor = System.Drawing.Color.Red;
            this.toolStripMenuItemBot.Name = "toolStripMenuItemBot";
            this.toolStripMenuItemBot.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemBot.Text = "Bot";
            this.toolStripMenuItemBot.ToolTipText = "If any modifier is enabled, no new Highscore can be set!";
            this.toolStripMenuItemBot.Click += new System.EventHandler(this.toolStripMenuItemBot_Click);
            // 
            // milliSecondTimer
            // 
            this.milliSecondTimer.Interval = 500;
            this.milliSecondTimer.Tick += new System.EventHandler(this.MilliSecondTimer_Tick);
            // 
            // groupBoxPowerup
            // 
            this.groupBoxPowerup.Controls.Add(this.labelPowerupTimerValue);
            this.groupBoxPowerup.Controls.Add(this.labelPowerupTimer);
            this.groupBoxPowerup.Controls.Add(this.labelSavedPowerupValue);
            this.groupBoxPowerup.Controls.Add(this.labelCurrentPowerupValue);
            this.groupBoxPowerup.Controls.Add(this.label2);
            this.groupBoxPowerup.Controls.Add(this.labelCurrentPowerup);
            this.groupBoxPowerup.Location = new System.Drawing.Point(312, 24);
            this.groupBoxPowerup.Name = "groupBoxPowerup";
            this.groupBoxPowerup.Size = new System.Drawing.Size(300, 50);
            this.groupBoxPowerup.TabIndex = 11;
            this.groupBoxPowerup.TabStop = false;
            this.groupBoxPowerup.Text = "Powerup";
            // 
            // labelPowerupTimerValue
            // 
            this.labelPowerupTimerValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPowerupTimerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPowerupTimerValue.Location = new System.Drawing.Point(258, 22);
            this.labelPowerupTimerValue.Name = "labelPowerupTimerValue";
            this.labelPowerupTimerValue.Size = new System.Drawing.Size(36, 23);
            this.labelPowerupTimerValue.TabIndex = 5;
            this.labelPowerupTimerValue.Text = "00";
            this.labelPowerupTimerValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPowerupTimer
            // 
            this.labelPowerupTimer.AutoSize = true;
            this.labelPowerupTimer.Location = new System.Drawing.Point(258, 9);
            this.labelPowerupTimer.Name = "labelPowerupTimer";
            this.labelPowerupTimer.Size = new System.Drawing.Size(36, 13);
            this.labelPowerupTimer.TabIndex = 4;
            this.labelPowerupTimer.Text = "Timer:";
            // 
            // labelSavedPowerupValue
            // 
            this.labelSavedPowerupValue.AutoSize = true;
            this.labelSavedPowerupValue.Location = new System.Drawing.Point(119, 28);
            this.labelSavedPowerupValue.Name = "labelSavedPowerupValue";
            this.labelSavedPowerupValue.Size = new System.Drawing.Size(96, 13);
            this.labelSavedPowerupValue.TabIndex = 3;
            this.labelSavedPowerupValue.Text = "labelSavPUpValue";
            // 
            // labelCurrentPowerupValue
            // 
            this.labelCurrentPowerupValue.AutoSize = true;
            this.labelCurrentPowerupValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPowerupValue.Location = new System.Drawing.Point(119, 12);
            this.labelCurrentPowerupValue.Name = "labelCurrentPowerupValue";
            this.labelCurrentPowerupValue.Size = new System.Drawing.Size(123, 17);
            this.labelCurrentPowerupValue.TabIndex = 2;
            this.labelCurrentPowerupValue.Text = "labelCurPUpValue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Saved Powerup:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCurrentPowerup
            // 
            this.labelCurrentPowerup.AutoSize = true;
            this.labelCurrentPowerup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPowerup.Location = new System.Drawing.Point(6, 12);
            this.labelCurrentPowerup.Name = "labelCurrentPowerup";
            this.labelCurrentPowerup.Size = new System.Drawing.Size(118, 17);
            this.labelCurrentPowerup.TabIndex = 0;
            this.labelCurrentPowerup.Text = "Current Powerup:";
            this.labelCurrentPowerup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gameInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 691);
            this.Controls.Add(this.groupBoxPowerup);
            this.Controls.Add(this.labelHighscoreValue);
            this.Controls.Add(this.labelScoreValue);
            this.Controls.Add(this.labelHighscore);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 730);
            this.MinimumSize = new System.Drawing.Size(640, 730);
            this.Name = "gameInterface";
            this.Text = "Snake Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameInterface_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxPowerup.ResumeLayout(false);
            this.groupBoxPowerup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelHighscore;
        private System.Windows.Forms.Label labelHighscoreValue;
        private System.Windows.Forms.Label labelScoreValue;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox widthToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem heightToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox heightToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox speedToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem growMultiplicatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox growMultiplicatorToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox pointsToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMenu;
        private System.Windows.Forms.Timer milliSecondTimer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBot;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSpeed;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNoClip;
        private System.Windows.Forms.GroupBox groupBoxPowerup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentPowerup;
        private System.Windows.Forms.Label labelSavedPowerupValue;
        private System.Windows.Forms.Label labelCurrentPowerupValue;
        private System.Windows.Forms.Label labelPowerupTimer;
        private System.Windows.Forms.Label labelPowerupTimerValue;
    }
}

