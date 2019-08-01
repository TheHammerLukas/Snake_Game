using System.Windows.Forms;

namespace Snake_Game
{
    partial class gameMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameMenu));
            this.tabControlMenu = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelSettings = new System.Windows.Forms.TableLayoutPanel();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelGrowMultiplicator = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.textBoxGrowMultiplicator = new System.Windows.Forms.TextBox();
            this.textBoxPoints = new System.Windows.Forms.TextBox();
            this.tabPageControls = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelControls = new System.Windows.Forms.TableLayoutPanel();
            this.buttonResetNoClipKey = new System.Windows.Forms.Button();
            this.buttonSetNoClipKey = new System.Windows.Forms.Button();
            this.textBoxNoClipKey = new System.Windows.Forms.TextBox();
            this.labelNoClipKey = new System.Windows.Forms.Label();
            this.buttonResetPowerupKey = new System.Windows.Forms.Button();
            this.buttonSetPowerupKey = new System.Windows.Forms.Button();
            this.textBoxPowerupKey = new System.Windows.Forms.TextBox();
            this.buttonResetBotKey = new System.Windows.Forms.Button();
            this.buttonResetSpeedKey = new System.Windows.Forms.Button();
            this.buttonSetBotKey = new System.Windows.Forms.Button();
            this.buttonResetPauseKey = new System.Windows.Forms.Button();
            this.buttonSetSpeedKey = new System.Windows.Forms.Button();
            this.buttonResetRestartKey = new System.Windows.Forms.Button();
            this.buttonSetPauseKey = new System.Windows.Forms.Button();
            this.buttonResetRightKey = new System.Windows.Forms.Button();
            this.buttonSetRestartKey = new System.Windows.Forms.Button();
            this.buttonResetLeftKey = new System.Windows.Forms.Button();
            this.buttonSetRightKey = new System.Windows.Forms.Button();
            this.buttonResetDownKey = new System.Windows.Forms.Button();
            this.buttonSetLeftKey = new System.Windows.Forms.Button();
            this.buttonSetDownKey = new System.Windows.Forms.Button();
            this.buttonResetUpKey = new System.Windows.Forms.Button();
            this.buttonSetUpKey = new System.Windows.Forms.Button();
            this.labelUpKey = new System.Windows.Forms.Label();
            this.labelDownKey = new System.Windows.Forms.Label();
            this.labelLeftKey = new System.Windows.Forms.Label();
            this.labelRightKey = new System.Windows.Forms.Label();
            this.labelBotKey = new System.Windows.Forms.Label();
            this.labelSpeedKey = new System.Windows.Forms.Label();
            this.labelPauseKey = new System.Windows.Forms.Label();
            this.textBoxDownKey = new System.Windows.Forms.TextBox();
            this.textBoxLeftKey = new System.Windows.Forms.TextBox();
            this.textBoxRightKey = new System.Windows.Forms.TextBox();
            this.textBoxUpKey = new System.Windows.Forms.TextBox();
            this.textBoxPauseKey = new System.Windows.Forms.TextBox();
            this.textBoxSpeedKey = new System.Windows.Forms.TextBox();
            this.textBoxBotKey = new System.Windows.Forms.TextBox();
            this.labelRestartKey = new System.Windows.Forms.Label();
            this.textBoxRestartKey = new System.Windows.Forms.TextBox();
            this.labelPowerupKey = new System.Windows.Forms.Label();
            this.tabPageColors = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelColors = new System.Windows.Forms.TableLayoutPanel();
            this.buttonResetFoodColor = new System.Windows.Forms.Button();
            this.buttonSetFoodColor = new System.Windows.Forms.Button();
            this.labelFoodPrev = new System.Windows.Forms.Label();
            this.labelFoodColor = new System.Windows.Forms.Label();
            this.buttonResetHeadColor = new System.Windows.Forms.Button();
            this.buttonSetHeadColor = new System.Windows.Forms.Button();
            this.buttonSetBodyColor = new System.Windows.Forms.Button();
            this.labelSnakeHeadColor = new System.Windows.Forms.Label();
            this.labelSnakeBodyColor = new System.Windows.Forms.Label();
            this.labelSnakeHeadPrev = new System.Windows.Forms.Label();
            this.labelSnakeBodyPrev = new System.Windows.Forms.Label();
            this.buttonSwitchRainbowMode = new System.Windows.Forms.Button();
            this.buttonResetBodyColor = new System.Windows.Forms.Button();
            this.groupBoxDrawingMode = new System.Windows.Forms.GroupBox();
            this.radioButtongameDrawingModeSprite = new System.Windows.Forms.RadioButton();
            this.radioButtongameDrawingModeRainbow = new System.Windows.Forms.RadioButton();
            this.radioButtongameDrawingModeNormal = new System.Windows.Forms.RadioButton();
            this.tabPagePowerups = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelPowerups = new System.Windows.Forms.TableLayoutPanel();
            this.buttonResetFoodNoclipColor = new System.Windows.Forms.Button();
            this.buttonSetFoodNoclipColor = new System.Windows.Forms.Button();
            this.labelFoodNoclipPrev = new System.Windows.Forms.Label();
            this.buttonResetBodyNoclipColor = new System.Windows.Forms.Button();
            this.buttonSetBodyNoclipColor = new System.Windows.Forms.Button();
            this.labelSnakeBodyNoclipPrev = new System.Windows.Forms.Label();
            this.buttonResetHeadNoclipColor = new System.Windows.Forms.Button();
            this.buttonSetHeadNoclipColor = new System.Windows.Forms.Button();
            this.labelSnakeHeadNoclipPrev = new System.Windows.Forms.Label();
            this.buttonResetFoodSlowmoColor = new System.Windows.Forms.Button();
            this.buttonSetFoodSlowmoColor = new System.Windows.Forms.Button();
            this.labelFoodSlowmoPrev = new System.Windows.Forms.Label();
            this.buttonResetBodySlowmoColor = new System.Windows.Forms.Button();
            this.buttonSetBodySlowmoColor = new System.Windows.Forms.Button();
            this.labelSnakeBodySlowmoPrev = new System.Windows.Forms.Label();
            this.buttonResetHeadSlowmoColor = new System.Windows.Forms.Button();
            this.buttonSetHeadSlowmoColor = new System.Windows.Forms.Button();
            this.labelSnakeHeadSlowmoPrev = new System.Windows.Forms.Label();
            this.buttonResetFoodPointTickColor = new System.Windows.Forms.Button();
            this.buttonSetFoodPointTickColor = new System.Windows.Forms.Button();
            this.labelFoodPointTickPrev = new System.Windows.Forms.Label();
            this.buttonResetBodyPointTickColor = new System.Windows.Forms.Button();
            this.buttonSetBodyPointTickColor = new System.Windows.Forms.Button();
            this.labelSnakeBodyPointTickPrev = new System.Windows.Forms.Label();
            this.buttonResetHeadPointTickColor = new System.Windows.Forms.Button();
            this.buttonSetHeadPointTickColor = new System.Windows.Forms.Button();
            this.labelSnakeHeadPointTickPrev = new System.Windows.Forms.Label();
            this.buttonResetFoodX2Color = new System.Windows.Forms.Button();
            this.buttonSetFoodX2Color = new System.Windows.Forms.Button();
            this.buttonResetBodyX2Color = new System.Windows.Forms.Button();
            this.buttonSetBodyX2Color = new System.Windows.Forms.Button();
            this.buttonResetHeadX2Color = new System.Windows.Forms.Button();
            this.buttonSetHeadX2Color = new System.Windows.Forms.Button();
            this.labelFoodX2Prev = new System.Windows.Forms.Label();
            this.labelSnakeBodyX2Prev = new System.Windows.Forms.Label();
            this.labelSnakeHeadX2Prev = new System.Windows.Forms.Label();
            this.labelFoodNoclipColor = new System.Windows.Forms.Label();
            this.labelSnakeBodyNoclipColor = new System.Windows.Forms.Label();
            this.labelSnakeHeadNoclipColor = new System.Windows.Forms.Label();
            this.labelNoclipColors = new System.Windows.Forms.Label();
            this.labelFoodSlowmoColor = new System.Windows.Forms.Label();
            this.labelSnakeBodySlowmoColor = new System.Windows.Forms.Label();
            this.labelSnakeHeadSlowmoColor = new System.Windows.Forms.Label();
            this.labelSlowmoColors = new System.Windows.Forms.Label();
            this.labelFoodPointTickColor = new System.Windows.Forms.Label();
            this.labelSnakeBodyPointTickColor = new System.Windows.Forms.Label();
            this.labelSnakeHeadPointTickColor = new System.Windows.Forms.Label();
            this.labelPointTickColors = new System.Windows.Forms.Label();
            this.labelFoodX2Color = new System.Windows.Forms.Label();
            this.labelSnakeBodyX2Color = new System.Windows.Forms.Label();
            this.textBoxPUpNoclipDuration = new System.Windows.Forms.TextBox();
            this.labelPUpNoclipDuration = new System.Windows.Forms.Label();
            this.textBoxPUpSlowmoDuration = new System.Windows.Forms.TextBox();
            this.labelPUpSlowmoDuration = new System.Windows.Forms.Label();
            this.textBoxPUpPointTickDuration = new System.Windows.Forms.TextBox();
            this.labelPUpPointTickDuration = new System.Windows.Forms.Label();
            this.textBoxPUpX2Duration = new System.Windows.Forms.TextBox();
            this.labelPUpX2Duration = new System.Windows.Forms.Label();
            this.labelPUpSpawnGap = new System.Windows.Forms.Label();
            this.textBoxPUpSpawnGap = new System.Windows.Forms.TextBox();
            this.labelX2Colors = new System.Windows.Forms.Label();
            this.labelSnakeHeadX2Color = new System.Windows.Forms.Label();
            this.tabPageSavefiles = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelSavefiles = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSavefilesScore = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSavefilesScore = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSaveFileScore = new System.Windows.Forms.Button();
            this.buttonOpenFileScore = new System.Windows.Forms.Button();
            this.labelScoreXmlPath = new System.Windows.Forms.Label();
            this.groupBoxSavefilesSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelSavefilesSettings = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOpenFileSettings = new System.Windows.Forms.Button();
            this.buttonSaveFileSettings = new System.Windows.Forms.Button();
            this.labelSettingsXmlPath = new System.Windows.Forms.Label();
            this.groupBoxSavefilesControls = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOpenFileControls = new System.Windows.Forms.Button();
            this.buttonSaveFileControls = new System.Windows.Forms.Button();
            this.labelControlsXmlPath = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxSavefilesSprites = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSaveFileSprites = new System.Windows.Forms.Button();
            this.buttonOpenFileSprites = new System.Windows.Forms.Button();
            this.labelSavefilesSpritesPath = new System.Windows.Forms.Label();
            this.tabControlMenu.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tableLayoutPanelSettings.SuspendLayout();
            this.tabPageControls.SuspendLayout();
            this.tableLayoutPanelControls.SuspendLayout();
            this.tabPageColors.SuspendLayout();
            this.tableLayoutPanelColors.SuspendLayout();
            this.groupBoxDrawingMode.SuspendLayout();
            this.tabPagePowerups.SuspendLayout();
            this.tableLayoutPanelPowerups.SuspendLayout();
            this.tabPageSavefiles.SuspendLayout();
            this.tableLayoutPanelSavefiles.SuspendLayout();
            this.groupBoxSavefilesScore.SuspendLayout();
            this.tableLayoutPanelSavefilesScore.SuspendLayout();
            this.groupBoxSavefilesSettings.SuspendLayout();
            this.tableLayoutPanelSavefilesSettings.SuspendLayout();
            this.groupBoxSavefilesControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxSavefilesSprites.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMenu
            // 
            this.tabControlMenu.Controls.Add(this.tabPageSettings);
            this.tabControlMenu.Controls.Add(this.tabPageControls);
            this.tabControlMenu.Controls.Add(this.tabPageColors);
            this.tabControlMenu.Controls.Add(this.tabPagePowerups);
            this.tabControlMenu.Controls.Add(this.tabPageSavefiles);
            this.tabControlMenu.Location = new System.Drawing.Point(13, 12);
            this.tabControlMenu.Multiline = true;
            this.tabControlMenu.Name = "tabControlMenu";
            this.tabControlMenu.SelectedIndex = 0;
            this.tabControlMenu.Size = new System.Drawing.Size(398, 249);
            this.tabControlMenu.TabIndex = 0;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.tableLayoutPanelSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(390, 223);
            this.tabPageSettings.TabIndex = 0;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSettings
            // 
            this.tableLayoutPanelSettings.ColumnCount = 2;
            this.tableLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSettings.Controls.Add(this.labelWidth, 0, 0);
            this.tableLayoutPanelSettings.Controls.Add(this.labelHeight, 0, 1);
            this.tableLayoutPanelSettings.Controls.Add(this.labelSpeed, 0, 2);
            this.tableLayoutPanelSettings.Controls.Add(this.labelPoints, 0, 4);
            this.tableLayoutPanelSettings.Controls.Add(this.labelGrowMultiplicator, 0, 3);
            this.tableLayoutPanelSettings.Controls.Add(this.textBoxWidth, 1, 0);
            this.tableLayoutPanelSettings.Controls.Add(this.textBoxHeight, 1, 1);
            this.tableLayoutPanelSettings.Controls.Add(this.textBoxSpeed, 1, 2);
            this.tableLayoutPanelSettings.Controls.Add(this.textBoxGrowMultiplicator, 1, 3);
            this.tableLayoutPanelSettings.Controls.Add(this.textBoxPoints, 1, 4);
            this.tableLayoutPanelSettings.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanelSettings.Name = "tableLayoutPanelSettings";
            this.tableLayoutPanelSettings.RowCount = 5;
            this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSettings.Size = new System.Drawing.Size(377, 210);
            this.tableLayoutPanelSettings.TabIndex = 0;
            // 
            // labelWidth
            // 
            this.labelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWidth.Location = new System.Drawing.Point(3, 0);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(182, 42);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Width";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelHeight
            // 
            this.labelHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeight.Location = new System.Drawing.Point(3, 42);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(182, 42);
            this.labelHeight.TabIndex = 1;
            this.labelHeight.Text = "Height";
            this.labelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.Location = new System.Drawing.Point(3, 84);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(182, 42);
            this.labelSpeed.TabIndex = 2;
            this.labelSpeed.Text = "Speed";
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPoints
            // 
            this.labelPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoints.Location = new System.Drawing.Point(3, 168);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(182, 42);
            this.labelPoints.TabIndex = 4;
            this.labelPoints.Text = "Points";
            this.labelPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelGrowMultiplicator
            // 
            this.labelGrowMultiplicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGrowMultiplicator.AutoSize = true;
            this.labelGrowMultiplicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrowMultiplicator.Location = new System.Drawing.Point(3, 126);
            this.labelGrowMultiplicator.Name = "labelGrowMultiplicator";
            this.labelGrowMultiplicator.Size = new System.Drawing.Size(182, 42);
            this.labelGrowMultiplicator.TabIndex = 3;
            this.labelGrowMultiplicator.Text = "Grow Multiplicator";
            this.labelGrowMultiplicator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWidth.Location = new System.Drawing.Point(191, 3);
            this.textBoxWidth.MaxLength = 3;
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(183, 38);
            this.textBoxWidth.TabIndex = 5;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHeight.Location = new System.Drawing.Point(191, 45);
            this.textBoxHeight.MaxLength = 3;
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(183, 38);
            this.textBoxHeight.TabIndex = 6;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSpeed.Location = new System.Drawing.Point(191, 87);
            this.textBoxSpeed.MaxLength = 4;
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(183, 38);
            this.textBoxSpeed.TabIndex = 7;
            // 
            // textBoxGrowMultiplicator
            // 
            this.textBoxGrowMultiplicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGrowMultiplicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGrowMultiplicator.Location = new System.Drawing.Point(191, 129);
            this.textBoxGrowMultiplicator.Name = "textBoxGrowMultiplicator";
            this.textBoxGrowMultiplicator.Size = new System.Drawing.Size(183, 38);
            this.textBoxGrowMultiplicator.TabIndex = 8;
            // 
            // textBoxPoints
            // 
            this.textBoxPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPoints.Location = new System.Drawing.Point(191, 171);
            this.textBoxPoints.Name = "textBoxPoints";
            this.textBoxPoints.Size = new System.Drawing.Size(183, 38);
            this.textBoxPoints.TabIndex = 9;
            // 
            // tabPageControls
            // 
            this.tabPageControls.Controls.Add(this.tableLayoutPanelControls);
            this.tabPageControls.Location = new System.Drawing.Point(4, 22);
            this.tabPageControls.Name = "tabPageControls";
            this.tabPageControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageControls.Size = new System.Drawing.Size(390, 223);
            this.tabPageControls.TabIndex = 1;
            this.tabPageControls.Text = "Controls";
            this.tabPageControls.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelControls
            // 
            this.tableLayoutPanelControls.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.tableLayoutPanelControls.AutoScroll = true;
            this.tableLayoutPanelControls.AutoScrollMinSize = new System.Drawing.Size(0, 540);
            this.tableLayoutPanelControls.ColumnCount = 4;
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetNoClipKey, 3, 9);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetNoClipKey, 2, 9);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxNoClipKey, 1, 9);
            this.tableLayoutPanelControls.Controls.Add(this.labelNoClipKey, 0, 9);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetPowerupKey, 3, 4);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetPowerupKey, 2, 4);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxPowerupKey, 1, 4);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetBotKey, 3, 8);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetSpeedKey, 3, 7);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetBotKey, 2, 8);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetPauseKey, 3, 6);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetSpeedKey, 2, 7);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetRestartKey, 3, 5);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetPauseKey, 2, 6);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetRightKey, 3, 3);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetRestartKey, 2, 5);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetLeftKey, 3, 2);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetRightKey, 2, 3);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetDownKey, 3, 1);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetLeftKey, 2, 2);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetDownKey, 2, 1);
            this.tableLayoutPanelControls.Controls.Add(this.buttonResetUpKey, 3, 0);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetUpKey, 2, 0);
            this.tableLayoutPanelControls.Controls.Add(this.labelUpKey, 0, 0);
            this.tableLayoutPanelControls.Controls.Add(this.labelDownKey, 0, 1);
            this.tableLayoutPanelControls.Controls.Add(this.labelLeftKey, 0, 2);
            this.tableLayoutPanelControls.Controls.Add(this.labelRightKey, 0, 3);
            this.tableLayoutPanelControls.Controls.Add(this.labelBotKey, 0, 8);
            this.tableLayoutPanelControls.Controls.Add(this.labelSpeedKey, 0, 7);
            this.tableLayoutPanelControls.Controls.Add(this.labelPauseKey, 0, 6);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxDownKey, 1, 1);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxLeftKey, 1, 2);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxRightKey, 1, 3);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxUpKey, 1, 0);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxPauseKey, 1, 6);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxSpeedKey, 1, 7);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxBotKey, 1, 8);
            this.tableLayoutPanelControls.Controls.Add(this.labelRestartKey, 0, 5);
            this.tableLayoutPanelControls.Controls.Add(this.textBoxRestartKey, 1, 5);
            this.tableLayoutPanelControls.Controls.Add(this.labelPowerupKey, 0, 4);
            this.tableLayoutPanelControls.Location = new System.Drawing.Point(-4, 0);
            this.tableLayoutPanelControls.MaximumSize = new System.Drawing.Size(394, 223);
            this.tableLayoutPanelControls.Name = "tableLayoutPanelControls";
            this.tableLayoutPanelControls.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.tableLayoutPanelControls.RowCount = 10;
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.Size = new System.Drawing.Size(394, 223);
            this.tableLayoutPanelControls.TabIndex = 1;
            // 
            // buttonResetNoClipKey
            // 
            this.buttonResetNoClipKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetNoClipKey.Location = new System.Drawing.Point(291, 489);
            this.buttonResetNoClipKey.Name = "buttonResetNoClipKey";
            this.buttonResetNoClipKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetNoClipKey.TabIndex = 42;
            this.buttonResetNoClipKey.Text = "Reset";
            this.buttonResetNoClipKey.UseVisualStyleBackColor = true;
            this.buttonResetNoClipKey.Click += new System.EventHandler(this.buttonResetNoClipKey_Click);
            // 
            // buttonSetNoClipKey
            // 
            this.buttonSetNoClipKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetNoClipKey.Location = new System.Drawing.Point(219, 489);
            this.buttonSetNoClipKey.Name = "buttonSetNoClipKey";
            this.buttonSetNoClipKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetNoClipKey.TabIndex = 41;
            this.buttonSetNoClipKey.Text = "Set";
            this.buttonSetNoClipKey.UseVisualStyleBackColor = true;
            this.buttonSetNoClipKey.Click += new System.EventHandler(this.buttonSetNoClipKey_Click);
            // 
            // textBoxNoClipKey
            // 
            this.textBoxNoClipKey.Enabled = false;
            this.textBoxNoClipKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNoClipKey.Location = new System.Drawing.Point(147, 489);
            this.textBoxNoClipKey.MaxLength = 1;
            this.textBoxNoClipKey.Name = "textBoxNoClipKey";
            this.textBoxNoClipKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxNoClipKey.TabIndex = 40;
            this.textBoxNoClipKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNoClipKey
            // 
            this.labelNoClipKey.AutoSize = true;
            this.labelNoClipKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNoClipKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoClipKey.Location = new System.Drawing.Point(3, 486);
            this.labelNoClipKey.Name = "labelNoClipKey";
            this.labelNoClipKey.Size = new System.Drawing.Size(138, 54);
            this.labelNoClipKey.TabIndex = 39;
            this.labelNoClipKey.Text = "NoClip";
            this.labelNoClipKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonResetPowerupKey
            // 
            this.buttonResetPowerupKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetPowerupKey.Location = new System.Drawing.Point(291, 219);
            this.buttonResetPowerupKey.Name = "buttonResetPowerupKey";
            this.buttonResetPowerupKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetPowerupKey.TabIndex = 38;
            this.buttonResetPowerupKey.Text = "Reset";
            this.buttonResetPowerupKey.UseVisualStyleBackColor = true;
            this.buttonResetPowerupKey.Click += new System.EventHandler(this.buttonResetPowerupKey_Click);
            // 
            // buttonSetPowerupKey
            // 
            this.buttonSetPowerupKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetPowerupKey.Location = new System.Drawing.Point(219, 219);
            this.buttonSetPowerupKey.Name = "buttonSetPowerupKey";
            this.buttonSetPowerupKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetPowerupKey.TabIndex = 37;
            this.buttonSetPowerupKey.Text = "Set";
            this.buttonSetPowerupKey.UseVisualStyleBackColor = true;
            this.buttonSetPowerupKey.Click += new System.EventHandler(this.buttonSetPowerupKey_Click);
            // 
            // textBoxPowerupKey
            // 
            this.textBoxPowerupKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPowerupKey.Enabled = false;
            this.textBoxPowerupKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPowerupKey.Location = new System.Drawing.Point(147, 219);
            this.textBoxPowerupKey.MaxLength = 1;
            this.textBoxPowerupKey.Name = "textBoxPowerupKey";
            this.textBoxPowerupKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxPowerupKey.TabIndex = 36;
            this.textBoxPowerupKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonResetBotKey
            // 
            this.buttonResetBotKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetBotKey.Location = new System.Drawing.Point(291, 435);
            this.buttonResetBotKey.Name = "buttonResetBotKey";
            this.buttonResetBotKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetBotKey.TabIndex = 34;
            this.buttonResetBotKey.Text = "Reset";
            this.buttonResetBotKey.UseVisualStyleBackColor = true;
            this.buttonResetBotKey.Click += new System.EventHandler(this.buttonResetBotKey_Click);
            // 
            // buttonResetSpeedKey
            // 
            this.buttonResetSpeedKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetSpeedKey.Location = new System.Drawing.Point(291, 381);
            this.buttonResetSpeedKey.Name = "buttonResetSpeedKey";
            this.buttonResetSpeedKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetSpeedKey.TabIndex = 33;
            this.buttonResetSpeedKey.Text = "Reset";
            this.buttonResetSpeedKey.UseVisualStyleBackColor = true;
            this.buttonResetSpeedKey.Click += new System.EventHandler(this.buttonResetSpeedKey_Click);
            // 
            // buttonSetBotKey
            // 
            this.buttonSetBotKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetBotKey.Location = new System.Drawing.Point(219, 435);
            this.buttonSetBotKey.Name = "buttonSetBotKey";
            this.buttonSetBotKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetBotKey.TabIndex = 32;
            this.buttonSetBotKey.Text = "Set";
            this.buttonSetBotKey.UseVisualStyleBackColor = true;
            this.buttonSetBotKey.Click += new System.EventHandler(this.buttonSetBotKey_Click);
            // 
            // buttonResetPauseKey
            // 
            this.buttonResetPauseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetPauseKey.Location = new System.Drawing.Point(291, 327);
            this.buttonResetPauseKey.Name = "buttonResetPauseKey";
            this.buttonResetPauseKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetPauseKey.TabIndex = 31;
            this.buttonResetPauseKey.Text = "Reset";
            this.buttonResetPauseKey.UseVisualStyleBackColor = true;
            this.buttonResetPauseKey.Click += new System.EventHandler(this.buttonResetPauseKey_Click);
            // 
            // buttonSetSpeedKey
            // 
            this.buttonSetSpeedKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetSpeedKey.Location = new System.Drawing.Point(219, 381);
            this.buttonSetSpeedKey.Name = "buttonSetSpeedKey";
            this.buttonSetSpeedKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetSpeedKey.TabIndex = 30;
            this.buttonSetSpeedKey.Text = "Set";
            this.buttonSetSpeedKey.UseVisualStyleBackColor = true;
            this.buttonSetSpeedKey.Click += new System.EventHandler(this.buttonSetSpeedKey_Click);
            // 
            // buttonResetRestartKey
            // 
            this.buttonResetRestartKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetRestartKey.Location = new System.Drawing.Point(291, 273);
            this.buttonResetRestartKey.Name = "buttonResetRestartKey";
            this.buttonResetRestartKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetRestartKey.TabIndex = 29;
            this.buttonResetRestartKey.Text = "Reset";
            this.buttonResetRestartKey.UseVisualStyleBackColor = true;
            this.buttonResetRestartKey.Click += new System.EventHandler(this.buttonResetRestartKey_Click);
            // 
            // buttonSetPauseKey
            // 
            this.buttonSetPauseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetPauseKey.Location = new System.Drawing.Point(219, 327);
            this.buttonSetPauseKey.Name = "buttonSetPauseKey";
            this.buttonSetPauseKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetPauseKey.TabIndex = 28;
            this.buttonSetPauseKey.Text = "Set";
            this.buttonSetPauseKey.UseVisualStyleBackColor = true;
            this.buttonSetPauseKey.Click += new System.EventHandler(this.buttonSetPauseKey_Click);
            // 
            // buttonResetRightKey
            // 
            this.buttonResetRightKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetRightKey.Location = new System.Drawing.Point(291, 165);
            this.buttonResetRightKey.Name = "buttonResetRightKey";
            this.buttonResetRightKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetRightKey.TabIndex = 27;
            this.buttonResetRightKey.Text = "Reset";
            this.buttonResetRightKey.UseVisualStyleBackColor = true;
            this.buttonResetRightKey.Click += new System.EventHandler(this.buttonResetRightKey_Click);
            // 
            // buttonSetRestartKey
            // 
            this.buttonSetRestartKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetRestartKey.Location = new System.Drawing.Point(219, 273);
            this.buttonSetRestartKey.Name = "buttonSetRestartKey";
            this.buttonSetRestartKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetRestartKey.TabIndex = 26;
            this.buttonSetRestartKey.Text = "Set";
            this.buttonSetRestartKey.UseVisualStyleBackColor = true;
            this.buttonSetRestartKey.Click += new System.EventHandler(this.buttonSetRestartKey_Click);
            // 
            // buttonResetLeftKey
            // 
            this.buttonResetLeftKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetLeftKey.Location = new System.Drawing.Point(291, 111);
            this.buttonResetLeftKey.Name = "buttonResetLeftKey";
            this.buttonResetLeftKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetLeftKey.TabIndex = 25;
            this.buttonResetLeftKey.Text = "Reset";
            this.buttonResetLeftKey.UseVisualStyleBackColor = true;
            this.buttonResetLeftKey.Click += new System.EventHandler(this.buttonResetLeftKey_Click);
            // 
            // buttonSetRightKey
            // 
            this.buttonSetRightKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetRightKey.Location = new System.Drawing.Point(219, 165);
            this.buttonSetRightKey.Name = "buttonSetRightKey";
            this.buttonSetRightKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetRightKey.TabIndex = 24;
            this.buttonSetRightKey.Text = "Set";
            this.buttonSetRightKey.UseVisualStyleBackColor = true;
            this.buttonSetRightKey.Click += new System.EventHandler(this.buttonSetRightKey_Click);
            // 
            // buttonResetDownKey
            // 
            this.buttonResetDownKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetDownKey.Location = new System.Drawing.Point(291, 57);
            this.buttonResetDownKey.Name = "buttonResetDownKey";
            this.buttonResetDownKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetDownKey.TabIndex = 23;
            this.buttonResetDownKey.Text = "Reset";
            this.buttonResetDownKey.UseVisualStyleBackColor = true;
            this.buttonResetDownKey.Click += new System.EventHandler(this.buttonResetDownKey_Click);
            // 
            // buttonSetLeftKey
            // 
            this.buttonSetLeftKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetLeftKey.Location = new System.Drawing.Point(219, 111);
            this.buttonSetLeftKey.Name = "buttonSetLeftKey";
            this.buttonSetLeftKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetLeftKey.TabIndex = 22;
            this.buttonSetLeftKey.Text = "Set";
            this.buttonSetLeftKey.UseVisualStyleBackColor = true;
            this.buttonSetLeftKey.Click += new System.EventHandler(this.buttonSetLeftKey_Click);
            // 
            // buttonSetDownKey
            // 
            this.buttonSetDownKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetDownKey.Location = new System.Drawing.Point(219, 57);
            this.buttonSetDownKey.Name = "buttonSetDownKey";
            this.buttonSetDownKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetDownKey.TabIndex = 21;
            this.buttonSetDownKey.Text = "Set";
            this.buttonSetDownKey.UseVisualStyleBackColor = true;
            this.buttonSetDownKey.Click += new System.EventHandler(this.buttonSetDownKey_Click);
            // 
            // buttonResetUpKey
            // 
            this.buttonResetUpKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetUpKey.Location = new System.Drawing.Point(291, 3);
            this.buttonResetUpKey.Name = "buttonResetUpKey";
            this.buttonResetUpKey.Size = new System.Drawing.Size(66, 48);
            this.buttonResetUpKey.TabIndex = 19;
            this.buttonResetUpKey.Text = "Reset";
            this.buttonResetUpKey.UseVisualStyleBackColor = true;
            this.buttonResetUpKey.Click += new System.EventHandler(this.buttonResetUpKey_Click);
            // 
            // buttonSetUpKey
            // 
            this.buttonSetUpKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetUpKey.Location = new System.Drawing.Point(219, 3);
            this.buttonSetUpKey.Name = "buttonSetUpKey";
            this.buttonSetUpKey.Size = new System.Drawing.Size(66, 48);
            this.buttonSetUpKey.TabIndex = 18;
            this.buttonSetUpKey.Text = "Set";
            this.buttonSetUpKey.UseVisualStyleBackColor = true;
            this.buttonSetUpKey.Click += new System.EventHandler(this.buttonSetUpKey_Click);
            // 
            // labelUpKey
            // 
            this.labelUpKey.AutoSize = true;
            this.labelUpKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUpKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpKey.Location = new System.Drawing.Point(3, 0);
            this.labelUpKey.Name = "labelUpKey";
            this.labelUpKey.Size = new System.Drawing.Size(138, 54);
            this.labelUpKey.TabIndex = 0;
            this.labelUpKey.Text = "Up";
            this.labelUpKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDownKey
            // 
            this.labelDownKey.AutoSize = true;
            this.labelDownKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDownKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownKey.Location = new System.Drawing.Point(3, 54);
            this.labelDownKey.Name = "labelDownKey";
            this.labelDownKey.Size = new System.Drawing.Size(138, 54);
            this.labelDownKey.TabIndex = 1;
            this.labelDownKey.Text = "Down";
            this.labelDownKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLeftKey
            // 
            this.labelLeftKey.AutoSize = true;
            this.labelLeftKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLeftKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeftKey.Location = new System.Drawing.Point(3, 108);
            this.labelLeftKey.Name = "labelLeftKey";
            this.labelLeftKey.Size = new System.Drawing.Size(138, 54);
            this.labelLeftKey.TabIndex = 2;
            this.labelLeftKey.Text = "Left";
            this.labelLeftKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRightKey
            // 
            this.labelRightKey.AutoSize = true;
            this.labelRightKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRightKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRightKey.Location = new System.Drawing.Point(3, 162);
            this.labelRightKey.Name = "labelRightKey";
            this.labelRightKey.Size = new System.Drawing.Size(138, 54);
            this.labelRightKey.TabIndex = 3;
            this.labelRightKey.Text = "Right";
            this.labelRightKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBotKey
            // 
            this.labelBotKey.AutoSize = true;
            this.labelBotKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBotKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBotKey.Location = new System.Drawing.Point(3, 432);
            this.labelBotKey.Name = "labelBotKey";
            this.labelBotKey.Size = new System.Drawing.Size(138, 54);
            this.labelBotKey.TabIndex = 4;
            this.labelBotKey.Text = "Bot";
            this.labelBotKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSpeedKey
            // 
            this.labelSpeedKey.AutoSize = true;
            this.labelSpeedKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSpeedKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeedKey.Location = new System.Drawing.Point(3, 378);
            this.labelSpeedKey.Name = "labelSpeedKey";
            this.labelSpeedKey.Size = new System.Drawing.Size(138, 54);
            this.labelSpeedKey.TabIndex = 5;
            this.labelSpeedKey.Text = "Speed";
            this.labelSpeedKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPauseKey
            // 
            this.labelPauseKey.AutoSize = true;
            this.labelPauseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPauseKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPauseKey.Location = new System.Drawing.Point(3, 324);
            this.labelPauseKey.Name = "labelPauseKey";
            this.labelPauseKey.Size = new System.Drawing.Size(138, 54);
            this.labelPauseKey.TabIndex = 6;
            this.labelPauseKey.Text = "Pause";
            this.labelPauseKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDownKey
            // 
            this.textBoxDownKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDownKey.Enabled = false;
            this.textBoxDownKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDownKey.Location = new System.Drawing.Point(147, 57);
            this.textBoxDownKey.MaxLength = 1;
            this.textBoxDownKey.Name = "textBoxDownKey";
            this.textBoxDownKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxDownKey.TabIndex = 8;
            this.textBoxDownKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxLeftKey
            // 
            this.textBoxLeftKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLeftKey.Enabled = false;
            this.textBoxLeftKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLeftKey.Location = new System.Drawing.Point(147, 111);
            this.textBoxLeftKey.MaxLength = 1;
            this.textBoxLeftKey.Name = "textBoxLeftKey";
            this.textBoxLeftKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxLeftKey.TabIndex = 9;
            this.textBoxLeftKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxRightKey
            // 
            this.textBoxRightKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRightKey.Enabled = false;
            this.textBoxRightKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRightKey.Location = new System.Drawing.Point(147, 165);
            this.textBoxRightKey.MaxLength = 1;
            this.textBoxRightKey.Name = "textBoxRightKey";
            this.textBoxRightKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxRightKey.TabIndex = 10;
            this.textBoxRightKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxUpKey
            // 
            this.textBoxUpKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUpKey.Enabled = false;
            this.textBoxUpKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUpKey.Location = new System.Drawing.Point(147, 3);
            this.textBoxUpKey.MaxLength = 1;
            this.textBoxUpKey.Name = "textBoxUpKey";
            this.textBoxUpKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxUpKey.TabIndex = 14;
            this.textBoxUpKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPauseKey
            // 
            this.textBoxPauseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPauseKey.Enabled = false;
            this.textBoxPauseKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPauseKey.Location = new System.Drawing.Point(147, 327);
            this.textBoxPauseKey.MaxLength = 1;
            this.textBoxPauseKey.Name = "textBoxPauseKey";
            this.textBoxPauseKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxPauseKey.TabIndex = 13;
            this.textBoxPauseKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSpeedKey
            // 
            this.textBoxSpeedKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSpeedKey.Enabled = false;
            this.textBoxSpeedKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSpeedKey.Location = new System.Drawing.Point(147, 381);
            this.textBoxSpeedKey.MaxLength = 1;
            this.textBoxSpeedKey.Name = "textBoxSpeedKey";
            this.textBoxSpeedKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxSpeedKey.TabIndex = 12;
            this.textBoxSpeedKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxBotKey
            // 
            this.textBoxBotKey.Enabled = false;
            this.textBoxBotKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBotKey.Location = new System.Drawing.Point(147, 435);
            this.textBoxBotKey.MaxLength = 1;
            this.textBoxBotKey.Name = "textBoxBotKey";
            this.textBoxBotKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxBotKey.TabIndex = 11;
            this.textBoxBotKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelRestartKey
            // 
            this.labelRestartKey.AutoSize = true;
            this.labelRestartKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRestartKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestartKey.Location = new System.Drawing.Point(3, 270);
            this.labelRestartKey.Name = "labelRestartKey";
            this.labelRestartKey.Size = new System.Drawing.Size(138, 54);
            this.labelRestartKey.TabIndex = 15;
            this.labelRestartKey.Text = "Restart";
            this.labelRestartKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxRestartKey
            // 
            this.textBoxRestartKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRestartKey.Enabled = false;
            this.textBoxRestartKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRestartKey.Location = new System.Drawing.Point(147, 273);
            this.textBoxRestartKey.MaxLength = 1;
            this.textBoxRestartKey.Name = "textBoxRestartKey";
            this.textBoxRestartKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxRestartKey.TabIndex = 16;
            this.textBoxRestartKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPowerupKey
            // 
            this.labelPowerupKey.AutoSize = true;
            this.labelPowerupKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPowerupKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPowerupKey.Location = new System.Drawing.Point(3, 216);
            this.labelPowerupKey.Name = "labelPowerupKey";
            this.labelPowerupKey.Size = new System.Drawing.Size(138, 54);
            this.labelPowerupKey.TabIndex = 35;
            this.labelPowerupKey.Text = "Powerup";
            this.labelPowerupKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPageColors
            // 
            this.tabPageColors.Controls.Add(this.tableLayoutPanelColors);
            this.tabPageColors.Location = new System.Drawing.Point(4, 22);
            this.tabPageColors.Name = "tabPageColors";
            this.tabPageColors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColors.Size = new System.Drawing.Size(390, 223);
            this.tabPageColors.TabIndex = 2;
            this.tabPageColors.Text = "Colors";
            this.tabPageColors.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelColors
            // 
            this.tableLayoutPanelColors.AutoScroll = true;
            this.tableLayoutPanelColors.ColumnCount = 4;
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelColors.Controls.Add(this.buttonResetFoodColor, 3, 2);
            this.tableLayoutPanelColors.Controls.Add(this.buttonSetFoodColor, 2, 2);
            this.tableLayoutPanelColors.Controls.Add(this.labelFoodPrev, 1, 2);
            this.tableLayoutPanelColors.Controls.Add(this.labelFoodColor, 0, 2);
            this.tableLayoutPanelColors.Controls.Add(this.buttonResetHeadColor, 3, 0);
            this.tableLayoutPanelColors.Controls.Add(this.buttonSetHeadColor, 2, 0);
            this.tableLayoutPanelColors.Controls.Add(this.buttonSetBodyColor, 2, 1);
            this.tableLayoutPanelColors.Controls.Add(this.labelSnakeHeadColor, 0, 0);
            this.tableLayoutPanelColors.Controls.Add(this.labelSnakeBodyColor, 0, 1);
            this.tableLayoutPanelColors.Controls.Add(this.labelSnakeHeadPrev, 1, 0);
            this.tableLayoutPanelColors.Controls.Add(this.labelSnakeBodyPrev, 1, 1);
            this.tableLayoutPanelColors.Controls.Add(this.buttonSwitchRainbowMode, 0, 3);
            this.tableLayoutPanelColors.Controls.Add(this.buttonResetBodyColor, 3, 1);
            this.tableLayoutPanelColors.Controls.Add(this.groupBoxDrawingMode, 1, 3);
            this.tableLayoutPanelColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelColors.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelColors.Name = "tableLayoutPanelColors";
            this.tableLayoutPanelColors.RowCount = 4;
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelColors.Size = new System.Drawing.Size(384, 217);
            this.tableLayoutPanelColors.TabIndex = 0;
            // 
            // buttonResetFoodColor
            // 
            this.buttonResetFoodColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetFoodColor.Location = new System.Drawing.Point(290, 111);
            this.buttonResetFoodColor.Name = "buttonResetFoodColor";
            this.buttonResetFoodColor.Size = new System.Drawing.Size(91, 48);
            this.buttonResetFoodColor.TabIndex = 12;
            this.buttonResetFoodColor.Text = "Reset";
            this.buttonResetFoodColor.UseVisualStyleBackColor = true;
            this.buttonResetFoodColor.Click += new System.EventHandler(this.buttonResetFoodColor_Click);
            // 
            // buttonSetFoodColor
            // 
            this.buttonSetFoodColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetFoodColor.Location = new System.Drawing.Point(194, 111);
            this.buttonSetFoodColor.Name = "buttonSetFoodColor";
            this.buttonSetFoodColor.Size = new System.Drawing.Size(90, 48);
            this.buttonSetFoodColor.TabIndex = 11;
            this.buttonSetFoodColor.Text = "Set";
            this.buttonSetFoodColor.UseVisualStyleBackColor = true;
            this.buttonSetFoodColor.Click += new System.EventHandler(this.buttonSetFoodColor_Click);
            // 
            // labelFoodPrev
            // 
            this.labelFoodPrev.AutoSize = true;
            this.labelFoodPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFoodPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodPrev.Location = new System.Drawing.Point(137, 108);
            this.labelFoodPrev.Name = "labelFoodPrev";
            this.labelFoodPrev.Size = new System.Drawing.Size(51, 54);
            this.labelFoodPrev.TabIndex = 10;
            // 
            // labelFoodColor
            // 
            this.labelFoodColor.AutoSize = true;
            this.labelFoodColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoodColor.Location = new System.Drawing.Point(3, 108);
            this.labelFoodColor.Name = "labelFoodColor";
            this.labelFoodColor.Size = new System.Drawing.Size(128, 54);
            this.labelFoodColor.TabIndex = 9;
            this.labelFoodColor.Text = "Food";
            this.labelFoodColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonResetHeadColor
            // 
            this.buttonResetHeadColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetHeadColor.Location = new System.Drawing.Point(290, 3);
            this.buttonResetHeadColor.Name = "buttonResetHeadColor";
            this.buttonResetHeadColor.Size = new System.Drawing.Size(91, 48);
            this.buttonResetHeadColor.TabIndex = 1;
            this.buttonResetHeadColor.Text = "Reset";
            this.buttonResetHeadColor.UseVisualStyleBackColor = true;
            this.buttonResetHeadColor.Click += new System.EventHandler(this.buttonResetHeadColor_Click);
            // 
            // buttonSetHeadColor
            // 
            this.buttonSetHeadColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetHeadColor.Location = new System.Drawing.Point(194, 3);
            this.buttonSetHeadColor.Name = "buttonSetHeadColor";
            this.buttonSetHeadColor.Size = new System.Drawing.Size(90, 48);
            this.buttonSetHeadColor.TabIndex = 0;
            this.buttonSetHeadColor.Text = "Set";
            this.buttonSetHeadColor.UseVisualStyleBackColor = true;
            this.buttonSetHeadColor.Click += new System.EventHandler(this.buttonSetHeadColor_Click);
            // 
            // buttonSetBodyColor
            // 
            this.buttonSetBodyColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetBodyColor.Location = new System.Drawing.Point(194, 57);
            this.buttonSetBodyColor.Name = "buttonSetBodyColor";
            this.buttonSetBodyColor.Size = new System.Drawing.Size(90, 48);
            this.buttonSetBodyColor.TabIndex = 1;
            this.buttonSetBodyColor.Text = "Set";
            this.buttonSetBodyColor.UseVisualStyleBackColor = true;
            this.buttonSetBodyColor.Click += new System.EventHandler(this.buttonSetBodyColor_Click);
            // 
            // labelSnakeHeadColor
            // 
            this.labelSnakeHeadColor.AutoSize = true;
            this.labelSnakeHeadColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeHeadColor.Location = new System.Drawing.Point(3, 0);
            this.labelSnakeHeadColor.Name = "labelSnakeHeadColor";
            this.labelSnakeHeadColor.Size = new System.Drawing.Size(128, 54);
            this.labelSnakeHeadColor.TabIndex = 3;
            this.labelSnakeHeadColor.Text = "Snake Head";
            this.labelSnakeHeadColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeBodyColor
            // 
            this.labelSnakeBodyColor.AutoSize = true;
            this.labelSnakeBodyColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeBodyColor.Location = new System.Drawing.Point(3, 54);
            this.labelSnakeBodyColor.Name = "labelSnakeBodyColor";
            this.labelSnakeBodyColor.Size = new System.Drawing.Size(128, 54);
            this.labelSnakeBodyColor.TabIndex = 4;
            this.labelSnakeBodyColor.Text = "Snake Body";
            this.labelSnakeBodyColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeHeadPrev
            // 
            this.labelSnakeHeadPrev.AutoSize = true;
            this.labelSnakeHeadPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeHeadPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadPrev.Location = new System.Drawing.Point(137, 0);
            this.labelSnakeHeadPrev.Name = "labelSnakeHeadPrev";
            this.labelSnakeHeadPrev.Size = new System.Drawing.Size(51, 54);
            this.labelSnakeHeadPrev.TabIndex = 5;
            // 
            // labelSnakeBodyPrev
            // 
            this.labelSnakeBodyPrev.AutoSize = true;
            this.labelSnakeBodyPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeBodyPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyPrev.Location = new System.Drawing.Point(137, 54);
            this.labelSnakeBodyPrev.Name = "labelSnakeBodyPrev";
            this.labelSnakeBodyPrev.Size = new System.Drawing.Size(51, 54);
            this.labelSnakeBodyPrev.TabIndex = 6;
            // 
            // buttonSwitchRainbowMode
            // 
            this.buttonSwitchRainbowMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSwitchRainbowMode.Location = new System.Drawing.Point(3, 165);
            this.buttonSwitchRainbowMode.Name = "buttonSwitchRainbowMode";
            this.buttonSwitchRainbowMode.Size = new System.Drawing.Size(128, 49);
            this.buttonSwitchRainbowMode.TabIndex = 7;
            this.buttonSwitchRainbowMode.Text = "buttonSwitchRainbowMode";
            this.buttonSwitchRainbowMode.UseVisualStyleBackColor = true;
            this.buttonSwitchRainbowMode.Click += new System.EventHandler(this.buttonSwitchRainbowMode_Click);
            // 
            // buttonResetBodyColor
            // 
            this.buttonResetBodyColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetBodyColor.Location = new System.Drawing.Point(290, 57);
            this.buttonResetBodyColor.Name = "buttonResetBodyColor";
            this.buttonResetBodyColor.Size = new System.Drawing.Size(91, 48);
            this.buttonResetBodyColor.TabIndex = 8;
            this.buttonResetBodyColor.Text = "Reset";
            this.buttonResetBodyColor.UseVisualStyleBackColor = true;
            this.buttonResetBodyColor.Click += new System.EventHandler(this.buttonResetBodyColor_Click);
            // 
            // groupBoxDrawingMode
            // 
            this.tableLayoutPanelColors.SetColumnSpan(this.groupBoxDrawingMode, 3);
            this.groupBoxDrawingMode.Controls.Add(this.radioButtongameDrawingModeSprite);
            this.groupBoxDrawingMode.Controls.Add(this.radioButtongameDrawingModeRainbow);
            this.groupBoxDrawingMode.Controls.Add(this.radioButtongameDrawingModeNormal);
            this.groupBoxDrawingMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDrawingMode.Location = new System.Drawing.Point(137, 165);
            this.groupBoxDrawingMode.Name = "groupBoxDrawingMode";
            this.groupBoxDrawingMode.Size = new System.Drawing.Size(244, 49);
            this.groupBoxDrawingMode.TabIndex = 15;
            this.groupBoxDrawingMode.TabStop = false;
            this.groupBoxDrawingMode.Text = "Drawing Mode";
            // 
            // radioButtongameDrawingModeSprite
            // 
            this.radioButtongameDrawingModeSprite.AutoSize = true;
            this.radioButtongameDrawingModeSprite.Location = new System.Drawing.Point(143, 19);
            this.radioButtongameDrawingModeSprite.Name = "radioButtongameDrawingModeSprite";
            this.radioButtongameDrawingModeSprite.Size = new System.Drawing.Size(66, 17);
            this.radioButtongameDrawingModeSprite.TabIndex = 15;
            this.radioButtongameDrawingModeSprite.TabStop = true;
            this.radioButtongameDrawingModeSprite.Tag = "gameConstants.gameDrawingMode";
            this.radioButtongameDrawingModeSprite.Text = "Textures";
            this.radioButtongameDrawingModeSprite.UseVisualStyleBackColor = true;
            this.radioButtongameDrawingModeSprite.CheckedChanged += new System.EventHandler(this.radioButtongameDrawingMode_Click);
            // 
            // radioButtongameDrawingModeRainbow
            // 
            this.radioButtongameDrawingModeRainbow.AutoSize = true;
            this.radioButtongameDrawingModeRainbow.Location = new System.Drawing.Point(70, 19);
            this.radioButtongameDrawingModeRainbow.Name = "radioButtongameDrawingModeRainbow";
            this.radioButtongameDrawingModeRainbow.Size = new System.Drawing.Size(67, 17);
            this.radioButtongameDrawingModeRainbow.TabIndex = 14;
            this.radioButtongameDrawingModeRainbow.TabStop = true;
            this.radioButtongameDrawingModeRainbow.Tag = "gameConstants.gameDrawingMode";
            this.radioButtongameDrawingModeRainbow.Text = "Rainbow";
            this.radioButtongameDrawingModeRainbow.UseVisualStyleBackColor = true;
            this.radioButtongameDrawingModeRainbow.CheckedChanged += new System.EventHandler(this.radioButtongameDrawingMode_Click);
            // 
            // radioButtongameDrawingModeNormal
            // 
            this.radioButtongameDrawingModeNormal.AutoSize = true;
            this.radioButtongameDrawingModeNormal.Location = new System.Drawing.Point(6, 19);
            this.radioButtongameDrawingModeNormal.Name = "radioButtongameDrawingModeNormal";
            this.radioButtongameDrawingModeNormal.Size = new System.Drawing.Size(58, 17);
            this.radioButtongameDrawingModeNormal.TabIndex = 13;
            this.radioButtongameDrawingModeNormal.TabStop = true;
            this.radioButtongameDrawingModeNormal.Tag = "gameConstants.gameDrawingMode";
            this.radioButtongameDrawingModeNormal.Text = "Normal";
            this.radioButtongameDrawingModeNormal.UseVisualStyleBackColor = true;
            this.radioButtongameDrawingModeNormal.CheckedChanged += new System.EventHandler(this.radioButtongameDrawingMode_Click);
            // 
            // tabPagePowerups
            // 
            this.tabPagePowerups.Controls.Add(this.tableLayoutPanelPowerups);
            this.tabPagePowerups.Location = new System.Drawing.Point(4, 22);
            this.tabPagePowerups.Name = "tabPagePowerups";
            this.tabPagePowerups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePowerups.Size = new System.Drawing.Size(390, 223);
            this.tabPagePowerups.TabIndex = 3;
            this.tabPagePowerups.Text = "Powerups";
            this.tabPagePowerups.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelPowerups
            // 
            this.tableLayoutPanelPowerups.AutoScroll = true;
            this.tableLayoutPanelPowerups.AutoScrollMinSize = new System.Drawing.Size(0, 1050);
            this.tableLayoutPanelPowerups.ColumnCount = 4;
            this.tableLayoutPanelPowerups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelPowerups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelPowerups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPowerups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetFoodNoclipColor, 3, 20);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetFoodNoclipColor, 2, 20);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelFoodNoclipPrev, 1, 20);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetBodyNoclipColor, 3, 19);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetBodyNoclipColor, 2, 19);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeBodyNoclipPrev, 1, 19);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetHeadNoclipColor, 3, 18);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetHeadNoclipColor, 2, 18);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeHeadNoclipPrev, 1, 18);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetFoodSlowmoColor, 3, 16);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetFoodSlowmoColor, 2, 16);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelFoodSlowmoPrev, 1, 16);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetBodySlowmoColor, 3, 15);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetBodySlowmoColor, 2, 15);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeBodySlowmoPrev, 1, 15);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetHeadSlowmoColor, 3, 14);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetHeadSlowmoColor, 2, 14);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeHeadSlowmoPrev, 1, 14);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetFoodPointTickColor, 3, 12);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetFoodPointTickColor, 2, 12);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelFoodPointTickPrev, 1, 12);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetBodyPointTickColor, 3, 11);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetBodyPointTickColor, 2, 11);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeBodyPointTickPrev, 1, 11);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetHeadPointTickColor, 3, 10);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetHeadPointTickColor, 2, 10);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeHeadPointTickPrev, 1, 10);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetFoodX2Color, 3, 8);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetFoodX2Color, 2, 8);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetBodyX2Color, 3, 7);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetBodyX2Color, 2, 7);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonResetHeadX2Color, 3, 6);
            this.tableLayoutPanelPowerups.Controls.Add(this.buttonSetHeadX2Color, 2, 6);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelFoodX2Prev, 1, 8);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeBodyX2Prev, 1, 7);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeHeadX2Prev, 1, 6);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelFoodNoclipColor, 0, 20);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeBodyNoclipColor, 0, 19);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeHeadNoclipColor, 0, 18);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelNoclipColors, 0, 17);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelFoodSlowmoColor, 0, 16);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeBodySlowmoColor, 0, 15);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeHeadSlowmoColor, 0, 14);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSlowmoColors, 0, 13);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelFoodPointTickColor, 0, 12);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeBodyPointTickColor, 0, 11);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeHeadPointTickColor, 0, 10);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelPointTickColors, 0, 9);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelFoodX2Color, 0, 8);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeBodyX2Color, 0, 7);
            this.tableLayoutPanelPowerups.Controls.Add(this.textBoxPUpNoclipDuration, 2, 4);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelPUpNoclipDuration, 0, 4);
            this.tableLayoutPanelPowerups.Controls.Add(this.textBoxPUpSlowmoDuration, 2, 3);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelPUpSlowmoDuration, 0, 3);
            this.tableLayoutPanelPowerups.Controls.Add(this.textBoxPUpPointTickDuration, 2, 2);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelPUpPointTickDuration, 0, 2);
            this.tableLayoutPanelPowerups.Controls.Add(this.textBoxPUpX2Duration, 2, 1);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelPUpX2Duration, 0, 1);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelPUpSpawnGap, 0, 0);
            this.tableLayoutPanelPowerups.Controls.Add(this.textBoxPUpSpawnGap, 2, 0);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelX2Colors, 0, 5);
            this.tableLayoutPanelPowerups.Controls.Add(this.labelSnakeHeadX2Color, 0, 6);
            this.tableLayoutPanelPowerups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPowerups.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelPowerups.Name = "tableLayoutPanelPowerups";
            this.tableLayoutPanelPowerups.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.tableLayoutPanelPowerups.RowCount = 21;
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPowerups.Size = new System.Drawing.Size(384, 217);
            this.tableLayoutPanelPowerups.TabIndex = 0;
            // 
            // buttonResetFoodNoclipColor
            // 
            this.buttonResetFoodNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetFoodNoclipColor.Location = new System.Drawing.Point(264, 1003);
            this.buttonResetFoodNoclipColor.Name = "buttonResetFoodNoclipColor";
            this.buttonResetFoodNoclipColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetFoodNoclipColor.TabIndex = 61;
            this.buttonResetFoodNoclipColor.Text = "Reset";
            this.buttonResetFoodNoclipColor.UseVisualStyleBackColor = true;
            this.buttonResetFoodNoclipColor.Click += new System.EventHandler(this.buttonResetFoodNoclipColor_Click);
            // 
            // buttonSetFoodNoclipColor
            // 
            this.buttonSetFoodNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetFoodNoclipColor.Location = new System.Drawing.Point(177, 1003);
            this.buttonSetFoodNoclipColor.Name = "buttonSetFoodNoclipColor";
            this.buttonSetFoodNoclipColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetFoodNoclipColor.TabIndex = 60;
            this.buttonSetFoodNoclipColor.Text = "Set";
            this.buttonSetFoodNoclipColor.UseVisualStyleBackColor = true;
            this.buttonSetFoodNoclipColor.Click += new System.EventHandler(this.buttonSetFoodNoclipColor_Click);
            // 
            // labelFoodNoclipPrev
            // 
            this.labelFoodNoclipPrev.AutoSize = true;
            this.labelFoodNoclipPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFoodNoclipPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodNoclipPrev.Location = new System.Drawing.Point(125, 1000);
            this.labelFoodNoclipPrev.Name = "labelFoodNoclipPrev";
            this.labelFoodNoclipPrev.Size = new System.Drawing.Size(46, 50);
            this.labelFoodNoclipPrev.TabIndex = 59;
            // 
            // buttonResetBodyNoclipColor
            // 
            this.buttonResetBodyNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetBodyNoclipColor.Location = new System.Drawing.Point(264, 953);
            this.buttonResetBodyNoclipColor.Name = "buttonResetBodyNoclipColor";
            this.buttonResetBodyNoclipColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetBodyNoclipColor.TabIndex = 58;
            this.buttonResetBodyNoclipColor.Text = "Reset";
            this.buttonResetBodyNoclipColor.UseVisualStyleBackColor = true;
            this.buttonResetBodyNoclipColor.Click += new System.EventHandler(this.buttonResetBodyNoclipColor_Click);
            // 
            // buttonSetBodyNoclipColor
            // 
            this.buttonSetBodyNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetBodyNoclipColor.Location = new System.Drawing.Point(177, 953);
            this.buttonSetBodyNoclipColor.Name = "buttonSetBodyNoclipColor";
            this.buttonSetBodyNoclipColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetBodyNoclipColor.TabIndex = 57;
            this.buttonSetBodyNoclipColor.Text = "Set";
            this.buttonSetBodyNoclipColor.UseVisualStyleBackColor = true;
            this.buttonSetBodyNoclipColor.Click += new System.EventHandler(this.buttonSetBodyNoclipColor_Click);
            // 
            // labelSnakeBodyNoclipPrev
            // 
            this.labelSnakeBodyNoclipPrev.AutoSize = true;
            this.labelSnakeBodyNoclipPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeBodyNoclipPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyNoclipPrev.Location = new System.Drawing.Point(125, 950);
            this.labelSnakeBodyNoclipPrev.Name = "labelSnakeBodyNoclipPrev";
            this.labelSnakeBodyNoclipPrev.Size = new System.Drawing.Size(46, 50);
            this.labelSnakeBodyNoclipPrev.TabIndex = 56;
            // 
            // buttonResetHeadNoclipColor
            // 
            this.buttonResetHeadNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetHeadNoclipColor.Location = new System.Drawing.Point(264, 903);
            this.buttonResetHeadNoclipColor.Name = "buttonResetHeadNoclipColor";
            this.buttonResetHeadNoclipColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetHeadNoclipColor.TabIndex = 55;
            this.buttonResetHeadNoclipColor.Text = "Reset";
            this.buttonResetHeadNoclipColor.UseVisualStyleBackColor = true;
            this.buttonResetHeadNoclipColor.Click += new System.EventHandler(this.buttonResetHeadNoclipColor_Click);
            // 
            // buttonSetHeadNoclipColor
            // 
            this.buttonSetHeadNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetHeadNoclipColor.Location = new System.Drawing.Point(177, 903);
            this.buttonSetHeadNoclipColor.Name = "buttonSetHeadNoclipColor";
            this.buttonSetHeadNoclipColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetHeadNoclipColor.TabIndex = 54;
            this.buttonSetHeadNoclipColor.Text = "Set";
            this.buttonSetHeadNoclipColor.UseVisualStyleBackColor = true;
            this.buttonSetHeadNoclipColor.Click += new System.EventHandler(this.buttonSetHeadNoclipColor_Click);
            // 
            // labelSnakeHeadNoclipPrev
            // 
            this.labelSnakeHeadNoclipPrev.AutoSize = true;
            this.labelSnakeHeadNoclipPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeHeadNoclipPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadNoclipPrev.Location = new System.Drawing.Point(125, 900);
            this.labelSnakeHeadNoclipPrev.Name = "labelSnakeHeadNoclipPrev";
            this.labelSnakeHeadNoclipPrev.Size = new System.Drawing.Size(46, 50);
            this.labelSnakeHeadNoclipPrev.TabIndex = 53;
            // 
            // buttonResetFoodSlowmoColor
            // 
            this.buttonResetFoodSlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetFoodSlowmoColor.Location = new System.Drawing.Point(264, 803);
            this.buttonResetFoodSlowmoColor.Name = "buttonResetFoodSlowmoColor";
            this.buttonResetFoodSlowmoColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetFoodSlowmoColor.TabIndex = 52;
            this.buttonResetFoodSlowmoColor.Text = "Reset";
            this.buttonResetFoodSlowmoColor.UseVisualStyleBackColor = true;
            this.buttonResetFoodSlowmoColor.Click += new System.EventHandler(this.buttonResetFoodSlowmoColor_Click);
            // 
            // buttonSetFoodSlowmoColor
            // 
            this.buttonSetFoodSlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetFoodSlowmoColor.Location = new System.Drawing.Point(177, 803);
            this.buttonSetFoodSlowmoColor.Name = "buttonSetFoodSlowmoColor";
            this.buttonSetFoodSlowmoColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetFoodSlowmoColor.TabIndex = 51;
            this.buttonSetFoodSlowmoColor.Text = "Set";
            this.buttonSetFoodSlowmoColor.UseVisualStyleBackColor = true;
            this.buttonSetFoodSlowmoColor.Click += new System.EventHandler(this.buttonSetFoodSlowmoColor_Click);
            // 
            // labelFoodSlowmoPrev
            // 
            this.labelFoodSlowmoPrev.AutoSize = true;
            this.labelFoodSlowmoPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFoodSlowmoPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodSlowmoPrev.Location = new System.Drawing.Point(125, 800);
            this.labelFoodSlowmoPrev.Name = "labelFoodSlowmoPrev";
            this.labelFoodSlowmoPrev.Size = new System.Drawing.Size(46, 50);
            this.labelFoodSlowmoPrev.TabIndex = 50;
            // 
            // buttonResetBodySlowmoColor
            // 
            this.buttonResetBodySlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetBodySlowmoColor.Location = new System.Drawing.Point(264, 753);
            this.buttonResetBodySlowmoColor.Name = "buttonResetBodySlowmoColor";
            this.buttonResetBodySlowmoColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetBodySlowmoColor.TabIndex = 49;
            this.buttonResetBodySlowmoColor.Text = "Reset";
            this.buttonResetBodySlowmoColor.UseVisualStyleBackColor = true;
            this.buttonResetBodySlowmoColor.Click += new System.EventHandler(this.buttonResetBodySlowmoColor_Click);
            // 
            // buttonSetBodySlowmoColor
            // 
            this.buttonSetBodySlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetBodySlowmoColor.Location = new System.Drawing.Point(177, 753);
            this.buttonSetBodySlowmoColor.Name = "buttonSetBodySlowmoColor";
            this.buttonSetBodySlowmoColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetBodySlowmoColor.TabIndex = 48;
            this.buttonSetBodySlowmoColor.Text = "Set";
            this.buttonSetBodySlowmoColor.UseVisualStyleBackColor = true;
            this.buttonSetBodySlowmoColor.Click += new System.EventHandler(this.buttonSetBodySlowmoColor_Click);
            // 
            // labelSnakeBodySlowmoPrev
            // 
            this.labelSnakeBodySlowmoPrev.AutoSize = true;
            this.labelSnakeBodySlowmoPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeBodySlowmoPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodySlowmoPrev.Location = new System.Drawing.Point(125, 750);
            this.labelSnakeBodySlowmoPrev.Name = "labelSnakeBodySlowmoPrev";
            this.labelSnakeBodySlowmoPrev.Size = new System.Drawing.Size(46, 50);
            this.labelSnakeBodySlowmoPrev.TabIndex = 47;
            // 
            // buttonResetHeadSlowmoColor
            // 
            this.buttonResetHeadSlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetHeadSlowmoColor.Location = new System.Drawing.Point(264, 703);
            this.buttonResetHeadSlowmoColor.Name = "buttonResetHeadSlowmoColor";
            this.buttonResetHeadSlowmoColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetHeadSlowmoColor.TabIndex = 46;
            this.buttonResetHeadSlowmoColor.Text = "Reset";
            this.buttonResetHeadSlowmoColor.UseVisualStyleBackColor = true;
            this.buttonResetHeadSlowmoColor.Click += new System.EventHandler(this.buttonResetHeadSlowmoColor_Click);
            // 
            // buttonSetHeadSlowmoColor
            // 
            this.buttonSetHeadSlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetHeadSlowmoColor.Location = new System.Drawing.Point(177, 703);
            this.buttonSetHeadSlowmoColor.Name = "buttonSetHeadSlowmoColor";
            this.buttonSetHeadSlowmoColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetHeadSlowmoColor.TabIndex = 45;
            this.buttonSetHeadSlowmoColor.Text = "Set";
            this.buttonSetHeadSlowmoColor.UseVisualStyleBackColor = true;
            this.buttonSetHeadSlowmoColor.Click += new System.EventHandler(this.buttonSetHeadSlowmoColor_Click);
            // 
            // labelSnakeHeadSlowmoPrev
            // 
            this.labelSnakeHeadSlowmoPrev.AutoSize = true;
            this.labelSnakeHeadSlowmoPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeHeadSlowmoPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadSlowmoPrev.Location = new System.Drawing.Point(125, 700);
            this.labelSnakeHeadSlowmoPrev.Name = "labelSnakeHeadSlowmoPrev";
            this.labelSnakeHeadSlowmoPrev.Size = new System.Drawing.Size(46, 50);
            this.labelSnakeHeadSlowmoPrev.TabIndex = 44;
            // 
            // buttonResetFoodPointTickColor
            // 
            this.buttonResetFoodPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetFoodPointTickColor.Location = new System.Drawing.Point(264, 603);
            this.buttonResetFoodPointTickColor.Name = "buttonResetFoodPointTickColor";
            this.buttonResetFoodPointTickColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetFoodPointTickColor.TabIndex = 43;
            this.buttonResetFoodPointTickColor.Text = "Reset";
            this.buttonResetFoodPointTickColor.UseVisualStyleBackColor = true;
            this.buttonResetFoodPointTickColor.Click += new System.EventHandler(this.buttonResetFoodPointTickColor_Click);
            // 
            // buttonSetFoodPointTickColor
            // 
            this.buttonSetFoodPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetFoodPointTickColor.Location = new System.Drawing.Point(177, 603);
            this.buttonSetFoodPointTickColor.Name = "buttonSetFoodPointTickColor";
            this.buttonSetFoodPointTickColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetFoodPointTickColor.TabIndex = 42;
            this.buttonSetFoodPointTickColor.Text = "Set";
            this.buttonSetFoodPointTickColor.UseVisualStyleBackColor = true;
            this.buttonSetFoodPointTickColor.Click += new System.EventHandler(this.buttonSetFoodPointTickColor_Click);
            // 
            // labelFoodPointTickPrev
            // 
            this.labelFoodPointTickPrev.AutoSize = true;
            this.labelFoodPointTickPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFoodPointTickPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodPointTickPrev.Location = new System.Drawing.Point(125, 600);
            this.labelFoodPointTickPrev.Name = "labelFoodPointTickPrev";
            this.labelFoodPointTickPrev.Size = new System.Drawing.Size(46, 50);
            this.labelFoodPointTickPrev.TabIndex = 41;
            // 
            // buttonResetBodyPointTickColor
            // 
            this.buttonResetBodyPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetBodyPointTickColor.Location = new System.Drawing.Point(264, 553);
            this.buttonResetBodyPointTickColor.Name = "buttonResetBodyPointTickColor";
            this.buttonResetBodyPointTickColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetBodyPointTickColor.TabIndex = 40;
            this.buttonResetBodyPointTickColor.Text = "Reset";
            this.buttonResetBodyPointTickColor.UseVisualStyleBackColor = true;
            this.buttonResetBodyPointTickColor.Click += new System.EventHandler(this.buttonResetBodyPointTickColor_Click);
            // 
            // buttonSetBodyPointTickColor
            // 
            this.buttonSetBodyPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetBodyPointTickColor.Location = new System.Drawing.Point(177, 553);
            this.buttonSetBodyPointTickColor.Name = "buttonSetBodyPointTickColor";
            this.buttonSetBodyPointTickColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetBodyPointTickColor.TabIndex = 39;
            this.buttonSetBodyPointTickColor.Text = "Set";
            this.buttonSetBodyPointTickColor.UseVisualStyleBackColor = true;
            this.buttonSetBodyPointTickColor.Click += new System.EventHandler(this.buttonSetBodyPointTickColor_Click);
            // 
            // labelSnakeBodyPointTickPrev
            // 
            this.labelSnakeBodyPointTickPrev.AutoSize = true;
            this.labelSnakeBodyPointTickPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeBodyPointTickPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyPointTickPrev.Location = new System.Drawing.Point(125, 550);
            this.labelSnakeBodyPointTickPrev.Name = "labelSnakeBodyPointTickPrev";
            this.labelSnakeBodyPointTickPrev.Size = new System.Drawing.Size(46, 50);
            this.labelSnakeBodyPointTickPrev.TabIndex = 38;
            // 
            // buttonResetHeadPointTickColor
            // 
            this.buttonResetHeadPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetHeadPointTickColor.Location = new System.Drawing.Point(264, 503);
            this.buttonResetHeadPointTickColor.Name = "buttonResetHeadPointTickColor";
            this.buttonResetHeadPointTickColor.Size = new System.Drawing.Size(83, 44);
            this.buttonResetHeadPointTickColor.TabIndex = 37;
            this.buttonResetHeadPointTickColor.Text = "Reset";
            this.buttonResetHeadPointTickColor.UseVisualStyleBackColor = true;
            this.buttonResetHeadPointTickColor.Click += new System.EventHandler(this.buttonResetHeadPointTickColor_Click);
            // 
            // buttonSetHeadPointTickColor
            // 
            this.buttonSetHeadPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetHeadPointTickColor.Location = new System.Drawing.Point(177, 503);
            this.buttonSetHeadPointTickColor.Name = "buttonSetHeadPointTickColor";
            this.buttonSetHeadPointTickColor.Size = new System.Drawing.Size(81, 44);
            this.buttonSetHeadPointTickColor.TabIndex = 36;
            this.buttonSetHeadPointTickColor.Text = "Set";
            this.buttonSetHeadPointTickColor.UseVisualStyleBackColor = true;
            this.buttonSetHeadPointTickColor.Click += new System.EventHandler(this.buttonSetHeadPointTickColor_Click);
            // 
            // labelSnakeHeadPointTickPrev
            // 
            this.labelSnakeHeadPointTickPrev.AutoSize = true;
            this.labelSnakeHeadPointTickPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeHeadPointTickPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadPointTickPrev.Location = new System.Drawing.Point(125, 500);
            this.labelSnakeHeadPointTickPrev.Name = "labelSnakeHeadPointTickPrev";
            this.labelSnakeHeadPointTickPrev.Size = new System.Drawing.Size(46, 50);
            this.labelSnakeHeadPointTickPrev.TabIndex = 35;
            // 
            // buttonResetFoodX2Color
            // 
            this.buttonResetFoodX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetFoodX2Color.Location = new System.Drawing.Point(264, 403);
            this.buttonResetFoodX2Color.Name = "buttonResetFoodX2Color";
            this.buttonResetFoodX2Color.Size = new System.Drawing.Size(83, 44);
            this.buttonResetFoodX2Color.TabIndex = 34;
            this.buttonResetFoodX2Color.Text = "Reset";
            this.buttonResetFoodX2Color.UseVisualStyleBackColor = true;
            this.buttonResetFoodX2Color.Click += new System.EventHandler(this.buttonResetFoodX2Color_Click);
            // 
            // buttonSetFoodX2Color
            // 
            this.buttonSetFoodX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetFoodX2Color.Location = new System.Drawing.Point(177, 403);
            this.buttonSetFoodX2Color.Name = "buttonSetFoodX2Color";
            this.buttonSetFoodX2Color.Size = new System.Drawing.Size(81, 44);
            this.buttonSetFoodX2Color.TabIndex = 33;
            this.buttonSetFoodX2Color.Text = "Set";
            this.buttonSetFoodX2Color.UseVisualStyleBackColor = true;
            this.buttonSetFoodX2Color.Click += new System.EventHandler(this.buttonSetFoodX2Color_Click);
            // 
            // buttonResetBodyX2Color
            // 
            this.buttonResetBodyX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetBodyX2Color.Location = new System.Drawing.Point(264, 353);
            this.buttonResetBodyX2Color.Name = "buttonResetBodyX2Color";
            this.buttonResetBodyX2Color.Size = new System.Drawing.Size(83, 44);
            this.buttonResetBodyX2Color.TabIndex = 32;
            this.buttonResetBodyX2Color.Text = "Reset";
            this.buttonResetBodyX2Color.UseVisualStyleBackColor = true;
            this.buttonResetBodyX2Color.Click += new System.EventHandler(this.buttonResetBodyX2Color_Click);
            // 
            // buttonSetBodyX2Color
            // 
            this.buttonSetBodyX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetBodyX2Color.Location = new System.Drawing.Point(177, 353);
            this.buttonSetBodyX2Color.Name = "buttonSetBodyX2Color";
            this.buttonSetBodyX2Color.Size = new System.Drawing.Size(81, 44);
            this.buttonSetBodyX2Color.TabIndex = 31;
            this.buttonSetBodyX2Color.Text = "Set";
            this.buttonSetBodyX2Color.UseVisualStyleBackColor = true;
            this.buttonSetBodyX2Color.Click += new System.EventHandler(this.buttonSetBodyX2Color_Click);
            // 
            // buttonResetHeadX2Color
            // 
            this.buttonResetHeadX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetHeadX2Color.Location = new System.Drawing.Point(264, 303);
            this.buttonResetHeadX2Color.Name = "buttonResetHeadX2Color";
            this.buttonResetHeadX2Color.Size = new System.Drawing.Size(83, 44);
            this.buttonResetHeadX2Color.TabIndex = 30;
            this.buttonResetHeadX2Color.Text = "Reset";
            this.buttonResetHeadX2Color.UseVisualStyleBackColor = true;
            this.buttonResetHeadX2Color.Click += new System.EventHandler(this.buttonResetHeadX2Color_Click);
            // 
            // buttonSetHeadX2Color
            // 
            this.buttonSetHeadX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetHeadX2Color.Location = new System.Drawing.Point(177, 303);
            this.buttonSetHeadX2Color.Name = "buttonSetHeadX2Color";
            this.buttonSetHeadX2Color.Size = new System.Drawing.Size(81, 44);
            this.buttonSetHeadX2Color.TabIndex = 29;
            this.buttonSetHeadX2Color.Text = "Set";
            this.buttonSetHeadX2Color.UseVisualStyleBackColor = true;
            this.buttonSetHeadX2Color.Click += new System.EventHandler(this.buttonSetHeadX2Color_Click);
            // 
            // labelFoodX2Prev
            // 
            this.labelFoodX2Prev.AutoSize = true;
            this.labelFoodX2Prev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFoodX2Prev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodX2Prev.Location = new System.Drawing.Point(125, 400);
            this.labelFoodX2Prev.Name = "labelFoodX2Prev";
            this.labelFoodX2Prev.Size = new System.Drawing.Size(46, 50);
            this.labelFoodX2Prev.TabIndex = 28;
            // 
            // labelSnakeBodyX2Prev
            // 
            this.labelSnakeBodyX2Prev.AutoSize = true;
            this.labelSnakeBodyX2Prev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeBodyX2Prev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyX2Prev.Location = new System.Drawing.Point(125, 350);
            this.labelSnakeBodyX2Prev.Name = "labelSnakeBodyX2Prev";
            this.labelSnakeBodyX2Prev.Size = new System.Drawing.Size(46, 50);
            this.labelSnakeBodyX2Prev.TabIndex = 27;
            // 
            // labelSnakeHeadX2Prev
            // 
            this.labelSnakeHeadX2Prev.AutoSize = true;
            this.labelSnakeHeadX2Prev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSnakeHeadX2Prev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadX2Prev.Location = new System.Drawing.Point(125, 300);
            this.labelSnakeHeadX2Prev.Name = "labelSnakeHeadX2Prev";
            this.labelSnakeHeadX2Prev.Size = new System.Drawing.Size(46, 50);
            this.labelSnakeHeadX2Prev.TabIndex = 26;
            // 
            // labelFoodNoclipColor
            // 
            this.labelFoodNoclipColor.AutoSize = true;
            this.labelFoodNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodNoclipColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoodNoclipColor.Location = new System.Drawing.Point(3, 1000);
            this.labelFoodNoclipColor.Name = "labelFoodNoclipColor";
            this.labelFoodNoclipColor.Size = new System.Drawing.Size(116, 50);
            this.labelFoodNoclipColor.TabIndex = 25;
            this.labelFoodNoclipColor.Text = "Food";
            this.labelFoodNoclipColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeBodyNoclipColor
            // 
            this.labelSnakeBodyNoclipColor.AutoSize = true;
            this.labelSnakeBodyNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyNoclipColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeBodyNoclipColor.Location = new System.Drawing.Point(3, 950);
            this.labelSnakeBodyNoclipColor.Name = "labelSnakeBodyNoclipColor";
            this.labelSnakeBodyNoclipColor.Size = new System.Drawing.Size(116, 50);
            this.labelSnakeBodyNoclipColor.TabIndex = 24;
            this.labelSnakeBodyNoclipColor.Text = "Snake Body";
            this.labelSnakeBodyNoclipColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeHeadNoclipColor
            // 
            this.labelSnakeHeadNoclipColor.AutoSize = true;
            this.labelSnakeHeadNoclipColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadNoclipColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeHeadNoclipColor.Location = new System.Drawing.Point(3, 900);
            this.labelSnakeHeadNoclipColor.Name = "labelSnakeHeadNoclipColor";
            this.labelSnakeHeadNoclipColor.Size = new System.Drawing.Size(116, 50);
            this.labelSnakeHeadNoclipColor.TabIndex = 23;
            this.labelSnakeHeadNoclipColor.Text = "Snake Head";
            this.labelSnakeHeadNoclipColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNoclipColors
            // 
            this.labelNoclipColors.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelNoclipColors, 4);
            this.labelNoclipColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNoclipColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoclipColors.Location = new System.Drawing.Point(3, 850);
            this.labelNoclipColors.Name = "labelNoclipColors";
            this.labelNoclipColors.Size = new System.Drawing.Size(344, 50);
            this.labelNoclipColors.TabIndex = 22;
            this.labelNoclipColors.Text = "Noclip Colors";
            this.labelNoclipColors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFoodSlowmoColor
            // 
            this.labelFoodSlowmoColor.AutoSize = true;
            this.labelFoodSlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodSlowmoColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoodSlowmoColor.Location = new System.Drawing.Point(3, 800);
            this.labelFoodSlowmoColor.Name = "labelFoodSlowmoColor";
            this.labelFoodSlowmoColor.Size = new System.Drawing.Size(116, 50);
            this.labelFoodSlowmoColor.TabIndex = 21;
            this.labelFoodSlowmoColor.Text = "Food";
            this.labelFoodSlowmoColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeBodySlowmoColor
            // 
            this.labelSnakeBodySlowmoColor.AutoSize = true;
            this.labelSnakeBodySlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodySlowmoColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeBodySlowmoColor.Location = new System.Drawing.Point(3, 750);
            this.labelSnakeBodySlowmoColor.Name = "labelSnakeBodySlowmoColor";
            this.labelSnakeBodySlowmoColor.Size = new System.Drawing.Size(116, 50);
            this.labelSnakeBodySlowmoColor.TabIndex = 20;
            this.labelSnakeBodySlowmoColor.Text = "Snake Body";
            this.labelSnakeBodySlowmoColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeHeadSlowmoColor
            // 
            this.labelSnakeHeadSlowmoColor.AutoSize = true;
            this.labelSnakeHeadSlowmoColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadSlowmoColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeHeadSlowmoColor.Location = new System.Drawing.Point(3, 700);
            this.labelSnakeHeadSlowmoColor.Name = "labelSnakeHeadSlowmoColor";
            this.labelSnakeHeadSlowmoColor.Size = new System.Drawing.Size(116, 50);
            this.labelSnakeHeadSlowmoColor.TabIndex = 19;
            this.labelSnakeHeadSlowmoColor.Text = "Snake Head";
            this.labelSnakeHeadSlowmoColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSlowmoColors
            // 
            this.labelSlowmoColors.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelSlowmoColors, 4);
            this.labelSlowmoColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSlowmoColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSlowmoColors.Location = new System.Drawing.Point(3, 650);
            this.labelSlowmoColors.Name = "labelSlowmoColors";
            this.labelSlowmoColors.Size = new System.Drawing.Size(344, 50);
            this.labelSlowmoColors.TabIndex = 18;
            this.labelSlowmoColors.Text = "Slowmotion Colors";
            this.labelSlowmoColors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFoodPointTickColor
            // 
            this.labelFoodPointTickColor.AutoSize = true;
            this.labelFoodPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodPointTickColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoodPointTickColor.Location = new System.Drawing.Point(3, 600);
            this.labelFoodPointTickColor.Name = "labelFoodPointTickColor";
            this.labelFoodPointTickColor.Size = new System.Drawing.Size(116, 50);
            this.labelFoodPointTickColor.TabIndex = 17;
            this.labelFoodPointTickColor.Text = "Food";
            this.labelFoodPointTickColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeBodyPointTickColor
            // 
            this.labelSnakeBodyPointTickColor.AutoSize = true;
            this.labelSnakeBodyPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyPointTickColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeBodyPointTickColor.Location = new System.Drawing.Point(3, 550);
            this.labelSnakeBodyPointTickColor.Name = "labelSnakeBodyPointTickColor";
            this.labelSnakeBodyPointTickColor.Size = new System.Drawing.Size(116, 50);
            this.labelSnakeBodyPointTickColor.TabIndex = 16;
            this.labelSnakeBodyPointTickColor.Text = "Snake Body";
            this.labelSnakeBodyPointTickColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeHeadPointTickColor
            // 
            this.labelSnakeHeadPointTickColor.AutoSize = true;
            this.labelSnakeHeadPointTickColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadPointTickColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeHeadPointTickColor.Location = new System.Drawing.Point(3, 500);
            this.labelSnakeHeadPointTickColor.Name = "labelSnakeHeadPointTickColor";
            this.labelSnakeHeadPointTickColor.Size = new System.Drawing.Size(116, 50);
            this.labelSnakeHeadPointTickColor.TabIndex = 15;
            this.labelSnakeHeadPointTickColor.Text = "Snake Head";
            this.labelSnakeHeadPointTickColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPointTickColors
            // 
            this.labelPointTickColors.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelPointTickColors, 4);
            this.labelPointTickColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPointTickColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPointTickColors.Location = new System.Drawing.Point(3, 450);
            this.labelPointTickColors.Name = "labelPointTickColors";
            this.labelPointTickColors.Size = new System.Drawing.Size(344, 50);
            this.labelPointTickColors.TabIndex = 14;
            this.labelPointTickColors.Text = "Point Tick Colors";
            this.labelPointTickColors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFoodX2Color
            // 
            this.labelFoodX2Color.AutoSize = true;
            this.labelFoodX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoodX2Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoodX2Color.Location = new System.Drawing.Point(3, 400);
            this.labelFoodX2Color.Name = "labelFoodX2Color";
            this.labelFoodX2Color.Size = new System.Drawing.Size(116, 50);
            this.labelFoodX2Color.TabIndex = 13;
            this.labelFoodX2Color.Text = "Food";
            this.labelFoodX2Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeBodyX2Color
            // 
            this.labelSnakeBodyX2Color.AutoSize = true;
            this.labelSnakeBodyX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyX2Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeBodyX2Color.Location = new System.Drawing.Point(3, 350);
            this.labelSnakeBodyX2Color.Name = "labelSnakeBodyX2Color";
            this.labelSnakeBodyX2Color.Size = new System.Drawing.Size(116, 50);
            this.labelSnakeBodyX2Color.TabIndex = 12;
            this.labelSnakeBodyX2Color.Text = "Snake Body";
            this.labelSnakeBodyX2Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPUpNoclipDuration
            // 
            this.tableLayoutPanelPowerups.SetColumnSpan(this.textBoxPUpNoclipDuration, 2);
            this.textBoxPUpNoclipDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPUpNoclipDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPUpNoclipDuration.Location = new System.Drawing.Point(177, 203);
            this.textBoxPUpNoclipDuration.Name = "textBoxPUpNoclipDuration";
            this.textBoxPUpNoclipDuration.Size = new System.Drawing.Size(170, 45);
            this.textBoxPUpNoclipDuration.TabIndex = 9;
            // 
            // labelPUpNoclipDuration
            // 
            this.labelPUpNoclipDuration.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelPUpNoclipDuration, 2);
            this.labelPUpNoclipDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPUpNoclipDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPUpNoclipDuration.Location = new System.Drawing.Point(3, 200);
            this.labelPUpNoclipDuration.Name = "labelPUpNoclipDuration";
            this.labelPUpNoclipDuration.Size = new System.Drawing.Size(168, 50);
            this.labelPUpNoclipDuration.TabIndex = 8;
            this.labelPUpNoclipDuration.Text = "Noclip Duration";
            this.labelPUpNoclipDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPUpSlowmoDuration
            // 
            this.tableLayoutPanelPowerups.SetColumnSpan(this.textBoxPUpSlowmoDuration, 2);
            this.textBoxPUpSlowmoDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPUpSlowmoDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPUpSlowmoDuration.Location = new System.Drawing.Point(177, 153);
            this.textBoxPUpSlowmoDuration.Name = "textBoxPUpSlowmoDuration";
            this.textBoxPUpSlowmoDuration.Size = new System.Drawing.Size(170, 45);
            this.textBoxPUpSlowmoDuration.TabIndex = 7;
            // 
            // labelPUpSlowmoDuration
            // 
            this.labelPUpSlowmoDuration.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelPUpSlowmoDuration, 2);
            this.labelPUpSlowmoDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPUpSlowmoDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPUpSlowmoDuration.Location = new System.Drawing.Point(3, 150);
            this.labelPUpSlowmoDuration.Name = "labelPUpSlowmoDuration";
            this.labelPUpSlowmoDuration.Size = new System.Drawing.Size(168, 50);
            this.labelPUpSlowmoDuration.TabIndex = 6;
            this.labelPUpSlowmoDuration.Text = "Slowmotion Duration";
            this.labelPUpSlowmoDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPUpPointTickDuration
            // 
            this.tableLayoutPanelPowerups.SetColumnSpan(this.textBoxPUpPointTickDuration, 2);
            this.textBoxPUpPointTickDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPUpPointTickDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPUpPointTickDuration.Location = new System.Drawing.Point(177, 103);
            this.textBoxPUpPointTickDuration.Name = "textBoxPUpPointTickDuration";
            this.textBoxPUpPointTickDuration.Size = new System.Drawing.Size(170, 45);
            this.textBoxPUpPointTickDuration.TabIndex = 5;
            // 
            // labelPUpPointTickDuration
            // 
            this.labelPUpPointTickDuration.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelPUpPointTickDuration, 2);
            this.labelPUpPointTickDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPUpPointTickDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPUpPointTickDuration.Location = new System.Drawing.Point(3, 100);
            this.labelPUpPointTickDuration.Name = "labelPUpPointTickDuration";
            this.labelPUpPointTickDuration.Size = new System.Drawing.Size(168, 50);
            this.labelPUpPointTickDuration.TabIndex = 4;
            this.labelPUpPointTickDuration.Text = "Point on Tick Duration";
            this.labelPUpPointTickDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPUpX2Duration
            // 
            this.tableLayoutPanelPowerups.SetColumnSpan(this.textBoxPUpX2Duration, 2);
            this.textBoxPUpX2Duration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPUpX2Duration.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPUpX2Duration.Location = new System.Drawing.Point(177, 53);
            this.textBoxPUpX2Duration.Name = "textBoxPUpX2Duration";
            this.textBoxPUpX2Duration.Size = new System.Drawing.Size(170, 45);
            this.textBoxPUpX2Duration.TabIndex = 3;
            // 
            // labelPUpX2Duration
            // 
            this.labelPUpX2Duration.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelPUpX2Duration, 2);
            this.labelPUpX2Duration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPUpX2Duration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPUpX2Duration.Location = new System.Drawing.Point(3, 50);
            this.labelPUpX2Duration.Name = "labelPUpX2Duration";
            this.labelPUpX2Duration.Size = new System.Drawing.Size(168, 50);
            this.labelPUpX2Duration.TabIndex = 2;
            this.labelPUpX2Duration.Text = "X2 Duration";
            this.labelPUpX2Duration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPUpSpawnGap
            // 
            this.labelPUpSpawnGap.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelPUpSpawnGap, 2);
            this.labelPUpSpawnGap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPUpSpawnGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPUpSpawnGap.Location = new System.Drawing.Point(3, 0);
            this.labelPUpSpawnGap.Name = "labelPUpSpawnGap";
            this.labelPUpSpawnGap.Size = new System.Drawing.Size(168, 50);
            this.labelPUpSpawnGap.TabIndex = 0;
            this.labelPUpSpawnGap.Text = "Spawn Gap";
            this.labelPUpSpawnGap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPUpSpawnGap
            // 
            this.tableLayoutPanelPowerups.SetColumnSpan(this.textBoxPUpSpawnGap, 2);
            this.textBoxPUpSpawnGap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPUpSpawnGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPUpSpawnGap.Location = new System.Drawing.Point(177, 3);
            this.textBoxPUpSpawnGap.Name = "textBoxPUpSpawnGap";
            this.textBoxPUpSpawnGap.Size = new System.Drawing.Size(170, 45);
            this.textBoxPUpSpawnGap.TabIndex = 1;
            // 
            // labelX2Colors
            // 
            this.labelX2Colors.AutoSize = true;
            this.tableLayoutPanelPowerups.SetColumnSpan(this.labelX2Colors, 4);
            this.labelX2Colors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX2Colors.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2Colors.Location = new System.Drawing.Point(3, 250);
            this.labelX2Colors.Name = "labelX2Colors";
            this.labelX2Colors.Size = new System.Drawing.Size(344, 50);
            this.labelX2Colors.TabIndex = 10;
            this.labelX2Colors.Text = "X2 Colors";
            this.labelX2Colors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeHeadX2Color
            // 
            this.labelSnakeHeadX2Color.AutoSize = true;
            this.labelSnakeHeadX2Color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadX2Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeHeadX2Color.Location = new System.Drawing.Point(3, 300);
            this.labelSnakeHeadX2Color.Name = "labelSnakeHeadX2Color";
            this.labelSnakeHeadX2Color.Size = new System.Drawing.Size(116, 50);
            this.labelSnakeHeadX2Color.TabIndex = 11;
            this.labelSnakeHeadX2Color.Text = "Snake Head";
            this.labelSnakeHeadX2Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageSavefiles
            // 
            this.tabPageSavefiles.AutoScroll = true;
            this.tabPageSavefiles.Controls.Add(this.tableLayoutPanelSavefiles);
            this.tabPageSavefiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageSavefiles.Name = "tabPageSavefiles";
            this.tabPageSavefiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSavefiles.Size = new System.Drawing.Size(390, 223);
            this.tabPageSavefiles.TabIndex = 4;
            this.tabPageSavefiles.Text = "Savefiles";
            this.tabPageSavefiles.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSavefiles
            // 
            this.tableLayoutPanelSavefiles.AutoScroll = true;
            this.tableLayoutPanelSavefiles.AutoScrollMinSize = new System.Drawing.Size(0, 330);
            this.tableLayoutPanelSavefiles.ColumnCount = 1;
            this.tableLayoutPanelSavefiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSavefiles.Controls.Add(this.groupBoxSavefilesScore, 0, 2);
            this.tableLayoutPanelSavefiles.Controls.Add(this.groupBoxSavefilesSettings, 0, 1);
            this.tableLayoutPanelSavefiles.Controls.Add(this.groupBoxSavefilesControls, 0, 0);
            this.tableLayoutPanelSavefiles.Controls.Add(this.groupBoxSavefilesSprites, 0, 3);
            this.tableLayoutPanelSavefiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSavefiles.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelSavefiles.Name = "tableLayoutPanelSavefiles";
            this.tableLayoutPanelSavefiles.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.tableLayoutPanelSavefiles.RowCount = 4;
            this.tableLayoutPanelSavefiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSavefiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSavefiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSavefiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSavefiles.Size = new System.Drawing.Size(384, 217);
            this.tableLayoutPanelSavefiles.TabIndex = 0;
            // 
            // groupBoxSavefilesScore
            // 
            this.groupBoxSavefilesScore.Controls.Add(this.tableLayoutPanelSavefilesScore);
            this.groupBoxSavefilesScore.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBoxSavefilesScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSavefilesScore.Location = new System.Drawing.Point(3, 167);
            this.groupBoxSavefilesScore.Name = "groupBoxSavefilesScore";
            this.groupBoxSavefilesScore.Size = new System.Drawing.Size(344, 76);
            this.groupBoxSavefilesScore.TabIndex = 8;
            this.groupBoxSavefilesScore.TabStop = false;
            this.groupBoxSavefilesScore.Text = "Score";
            // 
            // tableLayoutPanelSavefilesScore
            // 
            this.tableLayoutPanelSavefilesScore.ColumnCount = 2;
            this.tableLayoutPanelSavefilesScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSavefilesScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSavefilesScore.Controls.Add(this.buttonSaveFileScore, 1, 1);
            this.tableLayoutPanelSavefilesScore.Controls.Add(this.buttonOpenFileScore, 0, 1);
            this.tableLayoutPanelSavefilesScore.Controls.Add(this.labelScoreXmlPath, 0, 0);
            this.tableLayoutPanelSavefilesScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSavefilesScore.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelSavefilesScore.Name = "tableLayoutPanelSavefilesScore";
            this.tableLayoutPanelSavefilesScore.RowCount = 2;
            this.tableLayoutPanelSavefilesScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSavefilesScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSavefilesScore.Size = new System.Drawing.Size(338, 57);
            this.tableLayoutPanelSavefilesScore.TabIndex = 0;
            // 
            // buttonSaveFileScore
            // 
            this.buttonSaveFileScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveFileScore.Location = new System.Drawing.Point(172, 31);
            this.buttonSaveFileScore.Name = "buttonSaveFileScore";
            this.buttonSaveFileScore.Size = new System.Drawing.Size(163, 23);
            this.buttonSaveFileScore.TabIndex = 5;
            this.buttonSaveFileScore.Text = "Save";
            this.buttonSaveFileScore.UseVisualStyleBackColor = true;
            this.buttonSaveFileScore.Click += new System.EventHandler(this.ButtonSaveFileScore_Click);
            // 
            // buttonOpenFileScore
            // 
            this.buttonOpenFileScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenFileScore.Location = new System.Drawing.Point(3, 31);
            this.buttonOpenFileScore.Name = "buttonOpenFileScore";
            this.buttonOpenFileScore.Size = new System.Drawing.Size(163, 23);
            this.buttonOpenFileScore.TabIndex = 4;
            this.buttonOpenFileScore.Text = "Load";
            this.buttonOpenFileScore.UseVisualStyleBackColor = true;
            this.buttonOpenFileScore.Click += new System.EventHandler(this.ButtonOpenFileScore_Click);
            // 
            // labelScoreXmlPath
            // 
            this.labelScoreXmlPath.AutoSize = true;
            this.labelScoreXmlPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelSavefilesScore.SetColumnSpan(this.labelScoreXmlPath, 2);
            this.labelScoreXmlPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelScoreXmlPath.Location = new System.Drawing.Point(3, 0);
            this.labelScoreXmlPath.Name = "labelScoreXmlPath";
            this.labelScoreXmlPath.Size = new System.Drawing.Size(332, 28);
            this.labelScoreXmlPath.TabIndex = 6;
            // 
            // groupBoxSavefilesSettings
            // 
            this.groupBoxSavefilesSettings.Controls.Add(this.tableLayoutPanelSavefilesSettings);
            this.groupBoxSavefilesSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBoxSavefilesSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSavefilesSettings.Location = new System.Drawing.Point(3, 85);
            this.groupBoxSavefilesSettings.Name = "groupBoxSavefilesSettings";
            this.groupBoxSavefilesSettings.Size = new System.Drawing.Size(344, 76);
            this.groupBoxSavefilesSettings.TabIndex = 7;
            this.groupBoxSavefilesSettings.TabStop = false;
            this.groupBoxSavefilesSettings.Text = "Settings";
            // 
            // tableLayoutPanelSavefilesSettings
            // 
            this.tableLayoutPanelSavefilesSettings.ColumnCount = 2;
            this.tableLayoutPanelSavefilesSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSavefilesSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSavefilesSettings.Controls.Add(this.buttonOpenFileSettings, 0, 1);
            this.tableLayoutPanelSavefilesSettings.Controls.Add(this.buttonSaveFileSettings, 1, 1);
            this.tableLayoutPanelSavefilesSettings.Controls.Add(this.labelSettingsXmlPath, 0, 0);
            this.tableLayoutPanelSavefilesSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSavefilesSettings.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelSavefilesSettings.Name = "tableLayoutPanelSavefilesSettings";
            this.tableLayoutPanelSavefilesSettings.RowCount = 2;
            this.tableLayoutPanelSavefilesSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSavefilesSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSavefilesSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSavefilesSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSavefilesSettings.Size = new System.Drawing.Size(338, 57);
            this.tableLayoutPanelSavefilesSettings.TabIndex = 0;
            // 
            // buttonOpenFileSettings
            // 
            this.buttonOpenFileSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenFileSettings.Location = new System.Drawing.Point(3, 31);
            this.buttonOpenFileSettings.Name = "buttonOpenFileSettings";
            this.buttonOpenFileSettings.Size = new System.Drawing.Size(163, 23);
            this.buttonOpenFileSettings.TabIndex = 2;
            this.buttonOpenFileSettings.Text = "Load";
            this.buttonOpenFileSettings.UseVisualStyleBackColor = true;
            this.buttonOpenFileSettings.Click += new System.EventHandler(this.ButtonOpenFileSettings_Click);
            // 
            // buttonSaveFileSettings
            // 
            this.buttonSaveFileSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveFileSettings.Location = new System.Drawing.Point(172, 31);
            this.buttonSaveFileSettings.Name = "buttonSaveFileSettings";
            this.buttonSaveFileSettings.Size = new System.Drawing.Size(163, 23);
            this.buttonSaveFileSettings.TabIndex = 3;
            this.buttonSaveFileSettings.Text = "Save";
            this.buttonSaveFileSettings.UseVisualStyleBackColor = true;
            this.buttonSaveFileSettings.Click += new System.EventHandler(this.ButtonSaveFileSettings_Click);
            // 
            // labelSettingsXmlPath
            // 
            this.labelSettingsXmlPath.AutoSize = true;
            this.labelSettingsXmlPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelSavefilesSettings.SetColumnSpan(this.labelSettingsXmlPath, 2);
            this.labelSettingsXmlPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSettingsXmlPath.Location = new System.Drawing.Point(3, 0);
            this.labelSettingsXmlPath.Name = "labelSettingsXmlPath";
            this.labelSettingsXmlPath.Size = new System.Drawing.Size(332, 28);
            this.labelSettingsXmlPath.TabIndex = 4;
            // 
            // groupBoxSavefilesControls
            // 
            this.groupBoxSavefilesControls.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxSavefilesControls.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBoxSavefilesControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSavefilesControls.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSavefilesControls.Name = "groupBoxSavefilesControls";
            this.groupBoxSavefilesControls.Size = new System.Drawing.Size(344, 76);
            this.groupBoxSavefilesControls.TabIndex = 6;
            this.groupBoxSavefilesControls.TabStop = false;
            this.groupBoxSavefilesControls.Text = "Controls";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenFileControls, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveFileControls, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControlsXmlPath, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(338, 57);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonOpenFileControls
            // 
            this.buttonOpenFileControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenFileControls.Location = new System.Drawing.Point(3, 31);
            this.buttonOpenFileControls.Name = "buttonOpenFileControls";
            this.buttonOpenFileControls.Size = new System.Drawing.Size(163, 23);
            this.buttonOpenFileControls.TabIndex = 2;
            this.buttonOpenFileControls.Text = "Load";
            this.buttonOpenFileControls.UseVisualStyleBackColor = true;
            this.buttonOpenFileControls.Click += new System.EventHandler(this.ButtonOpenFileControls_Click);
            // 
            // buttonSaveFileControls
            // 
            this.buttonSaveFileControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveFileControls.Location = new System.Drawing.Point(172, 31);
            this.buttonSaveFileControls.Name = "buttonSaveFileControls";
            this.buttonSaveFileControls.Size = new System.Drawing.Size(163, 23);
            this.buttonSaveFileControls.TabIndex = 3;
            this.buttonSaveFileControls.Text = "Save";
            this.buttonSaveFileControls.UseVisualStyleBackColor = true;
            this.buttonSaveFileControls.Click += new System.EventHandler(this.ButtonSaveFileControls_Click);
            // 
            // labelControlsXmlPath
            // 
            this.labelControlsXmlPath.AutoSize = true;
            this.labelControlsXmlPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.labelControlsXmlPath, 2);
            this.labelControlsXmlPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControlsXmlPath.Location = new System.Drawing.Point(3, 0);
            this.labelControlsXmlPath.Name = "labelControlsXmlPath";
            this.labelControlsXmlPath.Size = new System.Drawing.Size(332, 28);
            this.labelControlsXmlPath.TabIndex = 4;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(13, 267);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(336, 267);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(94, 267);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBoxSavefilesSprites
            // 
            this.groupBoxSavefilesSprites.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxSavefilesSprites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSavefilesSprites.Location = new System.Drawing.Point(3, 249);
            this.groupBoxSavefilesSprites.Name = "groupBoxSavefilesSprites";
            this.groupBoxSavefilesSprites.Size = new System.Drawing.Size(344, 78);
            this.groupBoxSavefilesSprites.TabIndex = 9;
            this.groupBoxSavefilesSprites.TabStop = false;
            this.groupBoxSavefilesSprites.Text = "Textures";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonSaveFileSprites, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonOpenFileSprites, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelSavefilesSpritesPath, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(338, 59);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonSaveFileSprites
            // 
            this.buttonSaveFileSprites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveFileSprites.Location = new System.Drawing.Point(172, 32);
            this.buttonSaveFileSprites.Name = "buttonSaveFileSprites";
            this.buttonSaveFileSprites.Size = new System.Drawing.Size(163, 24);
            this.buttonSaveFileSprites.TabIndex = 5;
            this.buttonSaveFileSprites.Text = "Save";
            this.buttonSaveFileSprites.UseVisualStyleBackColor = true;
            this.buttonSaveFileSprites.Click += new System.EventHandler(this.ButtonSaveFileSprites_Click);
            // 
            // buttonOpenFileSprites
            // 
            this.buttonOpenFileSprites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenFileSprites.Location = new System.Drawing.Point(3, 32);
            this.buttonOpenFileSprites.Name = "buttonOpenFileSprites";
            this.buttonOpenFileSprites.Size = new System.Drawing.Size(163, 24);
            this.buttonOpenFileSprites.TabIndex = 4;
            this.buttonOpenFileSprites.Text = "Load";
            this.buttonOpenFileSprites.UseVisualStyleBackColor = true;
            this.buttonOpenFileSprites.Click += new System.EventHandler(this.ButtonOpenFileSprites_Click);
            // 
            // labelSavefilesSpritesPath
            // 
            this.labelSavefilesSpritesPath.AutoSize = true;
            this.labelSavefilesSpritesPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.labelSavefilesSpritesPath, 2);
            this.labelSavefilesSpritesPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSavefilesSpritesPath.Location = new System.Drawing.Point(3, 0);
            this.labelSavefilesSpritesPath.Name = "labelSavefilesSpritesPath";
            this.labelSavefilesSpritesPath.Size = new System.Drawing.Size(332, 29);
            this.labelSavefilesSpritesPath.TabIndex = 6;
            // 
            // gameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 295);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.tabControlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(439, 334);
            this.MinimumSize = new System.Drawing.Size(439, 334);
            this.Name = "gameMenu";
            this.Text = "Menu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameMenu_KeyDown);
            this.tabControlMenu.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tableLayoutPanelSettings.ResumeLayout(false);
            this.tableLayoutPanelSettings.PerformLayout();
            this.tabPageControls.ResumeLayout(false);
            this.tableLayoutPanelControls.ResumeLayout(false);
            this.tableLayoutPanelControls.PerformLayout();
            this.tabPageColors.ResumeLayout(false);
            this.tableLayoutPanelColors.ResumeLayout(false);
            this.tableLayoutPanelColors.PerformLayout();
            this.groupBoxDrawingMode.ResumeLayout(false);
            this.groupBoxDrawingMode.PerformLayout();
            this.tabPagePowerups.ResumeLayout(false);
            this.tableLayoutPanelPowerups.ResumeLayout(false);
            this.tableLayoutPanelPowerups.PerformLayout();
            this.tabPageSavefiles.ResumeLayout(false);
            this.tableLayoutPanelSavefiles.ResumeLayout(false);
            this.groupBoxSavefilesScore.ResumeLayout(false);
            this.tableLayoutPanelSavefilesScore.ResumeLayout(false);
            this.tableLayoutPanelSavefilesScore.PerformLayout();
            this.groupBoxSavefilesSettings.ResumeLayout(false);
            this.tableLayoutPanelSavefilesSettings.ResumeLayout(false);
            this.tableLayoutPanelSavefilesSettings.PerformLayout();
            this.groupBoxSavefilesControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxSavefilesSprites.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMenu;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSettings;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelGrowMultiplicator;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.TextBox textBoxGrowMultiplicator;
        private System.Windows.Forms.TextBox textBoxPoints;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TabPage tabPageControls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControls;
        private System.Windows.Forms.Label labelUpKey;
        private System.Windows.Forms.Label labelDownKey;
        private System.Windows.Forms.Label labelLeftKey;
        private System.Windows.Forms.Label labelRightKey;
        private System.Windows.Forms.Label labelSpeedKey;
        private System.Windows.Forms.Label labelPauseKey;
        private System.Windows.Forms.TextBox textBoxDownKey;
        private System.Windows.Forms.TextBox textBoxLeftKey;
        private System.Windows.Forms.TextBox textBoxRightKey;
        private System.Windows.Forms.TextBox textBoxUpKey;
        private System.Windows.Forms.TextBox textBoxPauseKey;
        private System.Windows.Forms.TextBox textBoxSpeedKey;
        private System.Windows.Forms.Label labelRestartKey;
        private System.Windows.Forms.TextBox textBoxRestartKey;
        private System.Windows.Forms.Label labelBotKey;
        private System.Windows.Forms.TextBox textBoxBotKey;
        private Button buttonResetBotKey;
        private Button buttonResetSpeedKey;
        private Button buttonSetBotKey;
        private Button buttonResetPauseKey;
        private Button buttonSetSpeedKey;
        private Button buttonResetRestartKey;
        private Button buttonSetPauseKey;
        private Button buttonResetRightKey;
        private Button buttonSetRestartKey;
        private Button buttonResetLeftKey;
        private Button buttonSetRightKey;
        private Button buttonResetDownKey;
        private Button buttonSetLeftKey;
        private Button buttonSetDownKey;
        private Button buttonResetUpKey;
        private Button buttonSetUpKey;
        private TabPage tabPageColors;
        private TableLayoutPanel tableLayoutPanelColors;
        private Button buttonSetHeadColor;
        private Button buttonSetBodyColor;
        private Label labelSnakeHeadColor;
        private Label labelSnakeBodyColor;
        private Label labelSnakeHeadPrev;
        private Label labelSnakeBodyPrev;
        private Button buttonSwitchRainbowMode;
        private Button buttonResetHeadColor;
        private Button buttonResetBodyColor;
        private Button buttonResetNoClipKey;
        private Button buttonSetNoClipKey;
        private TextBox textBoxNoClipKey;
        private Label labelNoClipKey;
        private Button buttonResetPowerupKey;
        private Button buttonSetPowerupKey;
        private TextBox textBoxPowerupKey;
        private Label labelPowerupKey;
        private Button buttonResetFoodColor;
        private Button buttonSetFoodColor;
        private Label labelFoodPrev;
        private Label labelFoodColor;
        private TabPage tabPagePowerups;
        private TableLayoutPanel tableLayoutPanelPowerups;
        private Label labelPUpSpawnGap;
        private TextBox textBoxPUpSpawnGap;
        private TextBox textBoxPUpPointTickDuration;
        private Label labelPUpPointTickDuration;
        private TextBox textBoxPUpX2Duration;
        private Label labelPUpX2Duration;
        private TextBox textBoxPUpNoclipDuration;
        private Label labelPUpNoclipDuration;
        private TextBox textBoxPUpSlowmoDuration;
        private Label labelPUpSlowmoDuration;
        private Label labelFoodNoclipColor;
        private Label labelSnakeBodyNoclipColor;
        private Label labelSnakeHeadNoclipColor;
        private Label labelNoclipColors;
        private Label labelFoodSlowmoColor;
        private Label labelSnakeBodySlowmoColor;
        private Label labelSnakeHeadSlowmoColor;
        private Label labelSlowmoColors;
        private Label labelFoodPointTickColor;
        private Label labelSnakeBodyPointTickColor;
        private Label labelSnakeHeadPointTickColor;
        private Label labelPointTickColors;
        private Label labelFoodX2Color;
        private Label labelSnakeBodyX2Color;
        private Label labelX2Colors;
        private Label labelSnakeHeadX2Color;
        private Button buttonResetFoodNoclipColor;
        private Button buttonSetFoodNoclipColor;
        private Label labelFoodNoclipPrev;
        private Button buttonResetBodyNoclipColor;
        private Button buttonSetBodyNoclipColor;
        private Label labelSnakeBodyNoclipPrev;
        private Button buttonResetHeadNoclipColor;
        private Button buttonSetHeadNoclipColor;
        private Label labelSnakeHeadNoclipPrev;
        private Button buttonResetFoodSlowmoColor;
        private Button buttonSetFoodSlowmoColor;
        private Label labelFoodSlowmoPrev;
        private Button buttonResetBodySlowmoColor;
        private Button buttonSetBodySlowmoColor;
        private Label labelSnakeBodySlowmoPrev;
        private Button buttonResetHeadSlowmoColor;
        private Button buttonSetHeadSlowmoColor;
        private Label labelSnakeHeadSlowmoPrev;
        private Button buttonResetFoodPointTickColor;
        private Button buttonSetFoodPointTickColor;
        private Label labelFoodPointTickPrev;
        private Button buttonResetBodyPointTickColor;
        private Button buttonSetBodyPointTickColor;
        private Label labelSnakeBodyPointTickPrev;
        private Button buttonResetHeadPointTickColor;
        private Button buttonSetHeadPointTickColor;
        private Label labelSnakeHeadPointTickPrev;
        private Button buttonResetFoodX2Color;
        private Button buttonSetFoodX2Color;
        private Button buttonResetBodyX2Color;
        private Button buttonSetBodyX2Color;
        private Button buttonResetHeadX2Color;
        private Button buttonSetHeadX2Color;
        private Label labelFoodX2Prev;
        private Label labelSnakeBodyX2Prev;
        private Label labelSnakeHeadX2Prev;
        private RadioButton radioButtongameDrawingModeNormal;
        private GroupBox groupBoxDrawingMode;
        private RadioButton radioButtongameDrawingModeSprite;
        private RadioButton radioButtongameDrawingModeRainbow;
        private TabPage tabPageSavefiles;
        private TableLayoutPanel tableLayoutPanelSavefiles;
        private GroupBox groupBoxSavefilesScore;
        private TableLayoutPanel tableLayoutPanelSavefilesScore;
        private Button buttonSaveFileScore;
        private Button buttonOpenFileScore;
        private GroupBox groupBoxSavefilesSettings;
        private TableLayoutPanel tableLayoutPanelSavefilesSettings;
        private Button buttonOpenFileSettings;
        private Button buttonSaveFileSettings;
        private GroupBox groupBoxSavefilesControls;
        private Label labelScoreXmlPath;
        private Label labelSettingsXmlPath;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonOpenFileControls;
        private Button buttonSaveFileControls;
        private Label labelControlsXmlPath;
        private GroupBox groupBoxSavefilesSprites;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonSaveFileSprites;
        private Button buttonOpenFileSprites;
        private Label labelSavefilesSpritesPath;
    }
}