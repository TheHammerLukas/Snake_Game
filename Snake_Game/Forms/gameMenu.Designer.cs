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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.tabPageColors = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonResetHeadColor = new System.Windows.Forms.Button();
            this.buttonSetHeadColor = new System.Windows.Forms.Button();
            this.buttonSetBodyColor = new System.Windows.Forms.Button();
            this.checkBoxRainbowColor = new System.Windows.Forms.CheckBox();
            this.labelSnakeHeadColor = new System.Windows.Forms.Label();
            this.labelSnakeBodyColor = new System.Windows.Forms.Label();
            this.labelSnakeHeadPrev = new System.Windows.Forms.Label();
            this.labelSnakeBodyPrev = new System.Windows.Forms.Label();
            this.buttonSwitchRainbowMode = new System.Windows.Forms.Button();
            this.buttonResetBodyColor = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelPowerupKey = new System.Windows.Forms.Label();
            this.textBoxPowerupKey = new System.Windows.Forms.TextBox();
            this.buttonSetPowerupKey = new System.Windows.Forms.Button();
            this.buttonResetPowerupKey = new System.Windows.Forms.Button();
            this.labelNoClipKey = new System.Windows.Forms.Label();
            this.textBoxNoClipKey = new System.Windows.Forms.TextBox();
            this.buttonSetNoClipKey = new System.Windows.Forms.Button();
            this.buttonResetNoClipKey = new System.Windows.Forms.Button();
            this.tabControlMenu.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tableLayoutPanelSettings.SuspendLayout();
            this.tabPageControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageColors.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMenu
            // 
            this.tabControlMenu.Controls.Add(this.tabPageSettings);
            this.tabControlMenu.Controls.Add(this.tabPageControls);
            this.tabControlMenu.Controls.Add(this.tabPageColors);
            this.tabControlMenu.Location = new System.Drawing.Point(13, 12);
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
            this.tabPageControls.Controls.Add(this.tableLayoutPanel1);
            this.tabPageControls.Location = new System.Drawing.Point(4, 22);
            this.tabPageControls.Name = "tabPageControls";
            this.tabPageControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageControls.Size = new System.Drawing.Size(390, 223);
            this.tabPageControls.TabIndex = 1;
            this.tabPageControls.Text = "Controls";
            this.tabPageControls.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(0, 540);
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonResetNoClipKey, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetNoClipKey, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNoClipKey, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelNoClipKey, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetPowerupKey, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetPowerupKey, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPowerupKey, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetBotKey, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetSpeedKey, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetBotKey, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetPauseKey, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetSpeedKey, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetRestartKey, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetPauseKey, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetRightKey, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetRestartKey, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetLeftKey, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetRightKey, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetDownKey, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetLeftKey, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetDownKey, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetUpKey, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSetUpKey, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelUpKey, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDownKey, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelLeftKey, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelRightKey, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelBotKey, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelSpeedKey, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelPauseKey, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDownKey, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLeftKey, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxRightKey, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUpKey, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPauseKey, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSpeedKey, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxBotKey, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelRestartKey, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxRestartKey, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelPowerupKey, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-4, 0);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(394, 223);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 223);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonResetBotKey
            // 
            this.buttonResetBotKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetBotKey.Location = new System.Drawing.Point(291, 459);
            this.buttonResetBotKey.Name = "buttonResetBotKey";
            this.buttonResetBotKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetBotKey.TabIndex = 34;
            this.buttonResetBotKey.Text = "Reset";
            this.buttonResetBotKey.UseVisualStyleBackColor = true;
            this.buttonResetBotKey.Click += new System.EventHandler(this.buttonResetBotKey_Click);
            // 
            // buttonResetSpeedKey
            // 
            this.buttonResetSpeedKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetSpeedKey.Location = new System.Drawing.Point(291, 402);
            this.buttonResetSpeedKey.Name = "buttonResetSpeedKey";
            this.buttonResetSpeedKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetSpeedKey.TabIndex = 33;
            this.buttonResetSpeedKey.Text = "Reset";
            this.buttonResetSpeedKey.UseVisualStyleBackColor = true;
            this.buttonResetSpeedKey.Click += new System.EventHandler(this.buttonResetSpeedKey_Click);
            // 
            // buttonSetBotKey
            // 
            this.buttonSetBotKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetBotKey.Location = new System.Drawing.Point(219, 459);
            this.buttonSetBotKey.Name = "buttonSetBotKey";
            this.buttonSetBotKey.Size = new System.Drawing.Size(66, 51);
            this.buttonSetBotKey.TabIndex = 32;
            this.buttonSetBotKey.Text = "Set";
            this.buttonSetBotKey.UseVisualStyleBackColor = true;
            this.buttonSetBotKey.Click += new System.EventHandler(this.buttonSetBotKey_Click);
            // 
            // buttonResetPauseKey
            // 
            this.buttonResetPauseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetPauseKey.Location = new System.Drawing.Point(291, 345);
            this.buttonResetPauseKey.Name = "buttonResetPauseKey";
            this.buttonResetPauseKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetPauseKey.TabIndex = 31;
            this.buttonResetPauseKey.Text = "Reset";
            this.buttonResetPauseKey.UseVisualStyleBackColor = true;
            this.buttonResetPauseKey.Click += new System.EventHandler(this.buttonResetPauseKey_Click);
            // 
            // buttonSetSpeedKey
            // 
            this.buttonSetSpeedKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetSpeedKey.Location = new System.Drawing.Point(219, 402);
            this.buttonSetSpeedKey.Name = "buttonSetSpeedKey";
            this.buttonSetSpeedKey.Size = new System.Drawing.Size(66, 51);
            this.buttonSetSpeedKey.TabIndex = 30;
            this.buttonSetSpeedKey.Text = "Set";
            this.buttonSetSpeedKey.UseVisualStyleBackColor = true;
            this.buttonSetSpeedKey.Click += new System.EventHandler(this.buttonSetSpeedKey_Click);
            // 
            // buttonResetRestartKey
            // 
            this.buttonResetRestartKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetRestartKey.Location = new System.Drawing.Point(291, 288);
            this.buttonResetRestartKey.Name = "buttonResetRestartKey";
            this.buttonResetRestartKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetRestartKey.TabIndex = 29;
            this.buttonResetRestartKey.Text = "Reset";
            this.buttonResetRestartKey.UseVisualStyleBackColor = true;
            this.buttonResetRestartKey.Click += new System.EventHandler(this.buttonResetRestartKey_Click);
            // 
            // buttonSetPauseKey
            // 
            this.buttonSetPauseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetPauseKey.Location = new System.Drawing.Point(219, 345);
            this.buttonSetPauseKey.Name = "buttonSetPauseKey";
            this.buttonSetPauseKey.Size = new System.Drawing.Size(66, 51);
            this.buttonSetPauseKey.TabIndex = 28;
            this.buttonSetPauseKey.Text = "Set";
            this.buttonSetPauseKey.UseVisualStyleBackColor = true;
            this.buttonSetPauseKey.Click += new System.EventHandler(this.buttonSetPauseKey_Click);
            // 
            // buttonResetRightKey
            // 
            this.buttonResetRightKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetRightKey.Location = new System.Drawing.Point(291, 174);
            this.buttonResetRightKey.Name = "buttonResetRightKey";
            this.buttonResetRightKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetRightKey.TabIndex = 27;
            this.buttonResetRightKey.Text = "Reset";
            this.buttonResetRightKey.UseVisualStyleBackColor = true;
            this.buttonResetRightKey.Click += new System.EventHandler(this.buttonResetRightKey_Click);
            // 
            // buttonSetRestartKey
            // 
            this.buttonSetRestartKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetRestartKey.Location = new System.Drawing.Point(219, 288);
            this.buttonSetRestartKey.Name = "buttonSetRestartKey";
            this.buttonSetRestartKey.Size = new System.Drawing.Size(66, 51);
            this.buttonSetRestartKey.TabIndex = 26;
            this.buttonSetRestartKey.Text = "Set";
            this.buttonSetRestartKey.UseVisualStyleBackColor = true;
            this.buttonSetRestartKey.Click += new System.EventHandler(this.buttonSetRestartKey_Click);
            // 
            // buttonResetLeftKey
            // 
            this.buttonResetLeftKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetLeftKey.Location = new System.Drawing.Point(291, 117);
            this.buttonResetLeftKey.Name = "buttonResetLeftKey";
            this.buttonResetLeftKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetLeftKey.TabIndex = 25;
            this.buttonResetLeftKey.Text = "Reset";
            this.buttonResetLeftKey.UseVisualStyleBackColor = true;
            this.buttonResetLeftKey.Click += new System.EventHandler(this.buttonResetLeftKey_Click);
            // 
            // buttonSetRightKey
            // 
            this.buttonSetRightKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetRightKey.Location = new System.Drawing.Point(219, 174);
            this.buttonSetRightKey.Name = "buttonSetRightKey";
            this.buttonSetRightKey.Size = new System.Drawing.Size(66, 51);
            this.buttonSetRightKey.TabIndex = 24;
            this.buttonSetRightKey.Text = "Set";
            this.buttonSetRightKey.UseVisualStyleBackColor = true;
            this.buttonSetRightKey.Click += new System.EventHandler(this.buttonSetRightKey_Click);
            // 
            // buttonResetDownKey
            // 
            this.buttonResetDownKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetDownKey.Location = new System.Drawing.Point(291, 60);
            this.buttonResetDownKey.Name = "buttonResetDownKey";
            this.buttonResetDownKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetDownKey.TabIndex = 23;
            this.buttonResetDownKey.Text = "Reset";
            this.buttonResetDownKey.UseVisualStyleBackColor = true;
            this.buttonResetDownKey.Click += new System.EventHandler(this.buttonResetDownKey_Click);
            // 
            // buttonSetLeftKey
            // 
            this.buttonSetLeftKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetLeftKey.Location = new System.Drawing.Point(219, 117);
            this.buttonSetLeftKey.Name = "buttonSetLeftKey";
            this.buttonSetLeftKey.Size = new System.Drawing.Size(66, 51);
            this.buttonSetLeftKey.TabIndex = 22;
            this.buttonSetLeftKey.Text = "Set";
            this.buttonSetLeftKey.UseVisualStyleBackColor = true;
            this.buttonSetLeftKey.Click += new System.EventHandler(this.buttonSetLeftKey_Click);
            // 
            // buttonSetDownKey
            // 
            this.buttonSetDownKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetDownKey.Location = new System.Drawing.Point(219, 60);
            this.buttonSetDownKey.Name = "buttonSetDownKey";
            this.buttonSetDownKey.Size = new System.Drawing.Size(66, 51);
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
            this.buttonResetUpKey.Size = new System.Drawing.Size(66, 51);
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
            this.buttonSetUpKey.Size = new System.Drawing.Size(66, 51);
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
            this.labelUpKey.Size = new System.Drawing.Size(138, 57);
            this.labelUpKey.TabIndex = 0;
            this.labelUpKey.Text = "Up";
            this.labelUpKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDownKey
            // 
            this.labelDownKey.AutoSize = true;
            this.labelDownKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDownKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownKey.Location = new System.Drawing.Point(3, 57);
            this.labelDownKey.Name = "labelDownKey";
            this.labelDownKey.Size = new System.Drawing.Size(138, 57);
            this.labelDownKey.TabIndex = 1;
            this.labelDownKey.Text = "Down";
            this.labelDownKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLeftKey
            // 
            this.labelLeftKey.AutoSize = true;
            this.labelLeftKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLeftKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeftKey.Location = new System.Drawing.Point(3, 114);
            this.labelLeftKey.Name = "labelLeftKey";
            this.labelLeftKey.Size = new System.Drawing.Size(138, 57);
            this.labelLeftKey.TabIndex = 2;
            this.labelLeftKey.Text = "Left";
            this.labelLeftKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRightKey
            // 
            this.labelRightKey.AutoSize = true;
            this.labelRightKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRightKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRightKey.Location = new System.Drawing.Point(3, 171);
            this.labelRightKey.Name = "labelRightKey";
            this.labelRightKey.Size = new System.Drawing.Size(138, 57);
            this.labelRightKey.TabIndex = 3;
            this.labelRightKey.Text = "Right";
            this.labelRightKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBotKey
            // 
            this.labelBotKey.AutoSize = true;
            this.labelBotKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBotKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBotKey.Location = new System.Drawing.Point(3, 456);
            this.labelBotKey.Name = "labelBotKey";
            this.labelBotKey.Size = new System.Drawing.Size(138, 57);
            this.labelBotKey.TabIndex = 4;
            this.labelBotKey.Text = "Bot";
            this.labelBotKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSpeedKey
            // 
            this.labelSpeedKey.AutoSize = true;
            this.labelSpeedKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSpeedKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeedKey.Location = new System.Drawing.Point(3, 399);
            this.labelSpeedKey.Name = "labelSpeedKey";
            this.labelSpeedKey.Size = new System.Drawing.Size(138, 57);
            this.labelSpeedKey.TabIndex = 5;
            this.labelSpeedKey.Text = "Speed";
            this.labelSpeedKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPauseKey
            // 
            this.labelPauseKey.AutoSize = true;
            this.labelPauseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPauseKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPauseKey.Location = new System.Drawing.Point(3, 342);
            this.labelPauseKey.Name = "labelPauseKey";
            this.labelPauseKey.Size = new System.Drawing.Size(138, 57);
            this.labelPauseKey.TabIndex = 6;
            this.labelPauseKey.Text = "Pause";
            this.labelPauseKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDownKey
            // 
            this.textBoxDownKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDownKey.Enabled = false;
            this.textBoxDownKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDownKey.Location = new System.Drawing.Point(147, 60);
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
            this.textBoxLeftKey.Location = new System.Drawing.Point(147, 117);
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
            this.textBoxRightKey.Location = new System.Drawing.Point(147, 174);
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
            this.textBoxPauseKey.Location = new System.Drawing.Point(147, 345);
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
            this.textBoxSpeedKey.Location = new System.Drawing.Point(147, 402);
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
            this.textBoxBotKey.Location = new System.Drawing.Point(147, 459);
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
            this.labelRestartKey.Location = new System.Drawing.Point(3, 285);
            this.labelRestartKey.Name = "labelRestartKey";
            this.labelRestartKey.Size = new System.Drawing.Size(138, 57);
            this.labelRestartKey.TabIndex = 15;
            this.labelRestartKey.Text = "Restart";
            this.labelRestartKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxRestartKey
            // 
            this.textBoxRestartKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRestartKey.Enabled = false;
            this.textBoxRestartKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRestartKey.Location = new System.Drawing.Point(147, 288);
            this.textBoxRestartKey.MaxLength = 1;
            this.textBoxRestartKey.Name = "textBoxRestartKey";
            this.textBoxRestartKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxRestartKey.TabIndex = 16;
            this.textBoxRestartKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPageColors
            // 
            this.tabPageColors.Controls.Add(this.tableLayoutPanel2);
            this.tabPageColors.Location = new System.Drawing.Point(4, 22);
            this.tabPageColors.Name = "tabPageColors";
            this.tabPageColors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColors.Size = new System.Drawing.Size(390, 223);
            this.tabPageColors.TabIndex = 2;
            this.tabPageColors.Text = "Colors";
            this.tabPageColors.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.buttonResetHeadColor, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetHeadColor, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetBodyColor, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxRainbowColor, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelSnakeHeadColor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelSnakeBodyColor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelSnakeHeadPrev, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelSnakeBodyPrev, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonSwitchRainbowMode, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonResetBodyColor, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 217);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonResetHeadColor
            // 
            this.buttonResetHeadColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetHeadColor.Location = new System.Drawing.Point(290, 3);
            this.buttonResetHeadColor.Name = "buttonResetHeadColor";
            this.buttonResetHeadColor.Size = new System.Drawing.Size(91, 66);
            this.buttonResetHeadColor.TabIndex = 1;
            this.buttonResetHeadColor.Text = "Reset";
            this.buttonResetHeadColor.UseVisualStyleBackColor = true;
            this.buttonResetHeadColor.Click += new System.EventHandler(this.ButtonResetHeadColor_Click);
            // 
            // buttonSetHeadColor
            // 
            this.buttonSetHeadColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetHeadColor.Location = new System.Drawing.Point(194, 3);
            this.buttonSetHeadColor.Name = "buttonSetHeadColor";
            this.buttonSetHeadColor.Size = new System.Drawing.Size(90, 66);
            this.buttonSetHeadColor.TabIndex = 0;
            this.buttonSetHeadColor.Text = "Set";
            this.buttonSetHeadColor.UseVisualStyleBackColor = true;
            this.buttonSetHeadColor.Click += new System.EventHandler(this.buttonSetHeadColor_Click);
            // 
            // buttonSetBodyColor
            // 
            this.buttonSetBodyColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetBodyColor.Location = new System.Drawing.Point(194, 75);
            this.buttonSetBodyColor.Name = "buttonSetBodyColor";
            this.buttonSetBodyColor.Size = new System.Drawing.Size(90, 66);
            this.buttonSetBodyColor.TabIndex = 1;
            this.buttonSetBodyColor.Text = "Set";
            this.buttonSetBodyColor.UseVisualStyleBackColor = true;
            this.buttonSetBodyColor.Click += new System.EventHandler(this.buttonSetBodyColor_Click);
            // 
            // checkBoxRainbowColor
            // 
            this.checkBoxRainbowColor.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.checkBoxRainbowColor, 2);
            this.checkBoxRainbowColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxRainbowColor.Location = new System.Drawing.Point(194, 147);
            this.checkBoxRainbowColor.Name = "checkBoxRainbowColor";
            this.checkBoxRainbowColor.Size = new System.Drawing.Size(187, 67);
            this.checkBoxRainbowColor.TabIndex = 2;
            this.checkBoxRainbowColor.Text = "Rainbow Snake";
            this.checkBoxRainbowColor.UseVisualStyleBackColor = true;
            this.checkBoxRainbowColor.Click += new System.EventHandler(this.checkBoxRainbowColor_Click);
            // 
            // labelSnakeHeadColor
            // 
            this.labelSnakeHeadColor.AutoSize = true;
            this.labelSnakeHeadColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeHeadColor.Location = new System.Drawing.Point(3, 0);
            this.labelSnakeHeadColor.Name = "labelSnakeHeadColor";
            this.labelSnakeHeadColor.Size = new System.Drawing.Size(128, 72);
            this.labelSnakeHeadColor.TabIndex = 3;
            this.labelSnakeHeadColor.Text = "Snake Head";
            this.labelSnakeHeadColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeBodyColor
            // 
            this.labelSnakeBodyColor.AutoSize = true;
            this.labelSnakeBodyColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSnakeBodyColor.Location = new System.Drawing.Point(3, 72);
            this.labelSnakeBodyColor.Name = "labelSnakeBodyColor";
            this.labelSnakeBodyColor.Size = new System.Drawing.Size(128, 72);
            this.labelSnakeBodyColor.TabIndex = 4;
            this.labelSnakeBodyColor.Text = "Snake Body";
            this.labelSnakeBodyColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSnakeHeadPrev
            // 
            this.labelSnakeHeadPrev.AutoSize = true;
            this.labelSnakeHeadPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeHeadPrev.Location = new System.Drawing.Point(137, 0);
            this.labelSnakeHeadPrev.Name = "labelSnakeHeadPrev";
            this.labelSnakeHeadPrev.Size = new System.Drawing.Size(51, 72);
            this.labelSnakeHeadPrev.TabIndex = 5;
            // 
            // labelSnakeBodyPrev
            // 
            this.labelSnakeBodyPrev.AutoSize = true;
            this.labelSnakeBodyPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSnakeBodyPrev.Location = new System.Drawing.Point(137, 72);
            this.labelSnakeBodyPrev.Name = "labelSnakeBodyPrev";
            this.labelSnakeBodyPrev.Size = new System.Drawing.Size(51, 72);
            this.labelSnakeBodyPrev.TabIndex = 6;
            // 
            // buttonSwitchRainbowMode
            // 
            this.buttonSwitchRainbowMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSwitchRainbowMode.Location = new System.Drawing.Point(3, 147);
            this.buttonSwitchRainbowMode.Name = "buttonSwitchRainbowMode";
            this.buttonSwitchRainbowMode.Size = new System.Drawing.Size(128, 67);
            this.buttonSwitchRainbowMode.TabIndex = 7;
            this.buttonSwitchRainbowMode.Text = "buttonSwitchRainbowMode";
            this.buttonSwitchRainbowMode.UseVisualStyleBackColor = true;
            this.buttonSwitchRainbowMode.Click += new System.EventHandler(this.buttonSwitchRainbowMode_Click);
            // 
            // buttonResetBodyColor
            // 
            this.buttonResetBodyColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetBodyColor.Location = new System.Drawing.Point(290, 75);
            this.buttonResetBodyColor.Name = "buttonResetBodyColor";
            this.buttonResetBodyColor.Size = new System.Drawing.Size(91, 66);
            this.buttonResetBodyColor.TabIndex = 8;
            this.buttonResetBodyColor.Text = "Reset";
            this.buttonResetBodyColor.UseVisualStyleBackColor = true;
            this.buttonResetBodyColor.Click += new System.EventHandler(this.ButtonResetBodyColor_Click);
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
            // labelPowerupKey
            // 
            this.labelPowerupKey.AutoSize = true;
            this.labelPowerupKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPowerupKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPowerupKey.Location = new System.Drawing.Point(3, 228);
            this.labelPowerupKey.Name = "labelPowerupKey";
            this.labelPowerupKey.Size = new System.Drawing.Size(138, 57);
            this.labelPowerupKey.TabIndex = 35;
            this.labelPowerupKey.Text = "Powerup";
            this.labelPowerupKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPowerupKey
            // 
            this.textBoxPowerupKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPowerupKey.Enabled = false;
            this.textBoxPowerupKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPowerupKey.Location = new System.Drawing.Point(147, 231);
            this.textBoxPowerupKey.MaxLength = 1;
            this.textBoxPowerupKey.Name = "textBoxPowerupKey";
            this.textBoxPowerupKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxPowerupKey.TabIndex = 36;
            this.textBoxPowerupKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSetPowerupKey
            // 
            this.buttonSetPowerupKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetPowerupKey.Location = new System.Drawing.Point(219, 231);
            this.buttonSetPowerupKey.Name = "buttonSetPowerupKey";
            this.buttonSetPowerupKey.Size = new System.Drawing.Size(66, 51);
            this.buttonSetPowerupKey.TabIndex = 37;
            this.buttonSetPowerupKey.Text = "Set";
            this.buttonSetPowerupKey.UseVisualStyleBackColor = true;
            this.buttonSetPowerupKey.Click += new System.EventHandler(this.buttonSetPowerupKey_Click);
            // 
            // buttonResetPowerupKey
            // 
            this.buttonResetPowerupKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetPowerupKey.Location = new System.Drawing.Point(291, 231);
            this.buttonResetPowerupKey.Name = "buttonResetPowerupKey";
            this.buttonResetPowerupKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetPowerupKey.TabIndex = 38;
            this.buttonResetPowerupKey.Text = "Reset";
            this.buttonResetPowerupKey.UseVisualStyleBackColor = true;
            this.buttonResetPowerupKey.Click += new System.EventHandler(this.buttonResetPowerupKey_Click);
            // 
            // labelNoClipKey
            // 
            this.labelNoClipKey.AutoSize = true;
            this.labelNoClipKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNoClipKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoClipKey.Location = new System.Drawing.Point(3, 513);
            this.labelNoClipKey.Name = "labelNoClipKey";
            this.labelNoClipKey.Size = new System.Drawing.Size(138, 57);
            this.labelNoClipKey.TabIndex = 39;
            this.labelNoClipKey.Text = "NoClip";
            this.labelNoClipKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNoClipKey
            // 
            this.textBoxNoClipKey.Enabled = false;
            this.textBoxNoClipKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNoClipKey.Location = new System.Drawing.Point(147, 516);
            this.textBoxNoClipKey.MaxLength = 1;
            this.textBoxNoClipKey.Name = "textBoxNoClipKey";
            this.textBoxNoClipKey.Size = new System.Drawing.Size(66, 45);
            this.textBoxNoClipKey.TabIndex = 40;
            this.textBoxNoClipKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSetNoClipKey
            // 
            this.buttonSetNoClipKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetNoClipKey.Location = new System.Drawing.Point(219, 516);
            this.buttonSetNoClipKey.Name = "buttonSetNoClipKey";
            this.buttonSetNoClipKey.Size = new System.Drawing.Size(66, 51);
            this.buttonSetNoClipKey.TabIndex = 41;
            this.buttonSetNoClipKey.Text = "Set";
            this.buttonSetNoClipKey.UseVisualStyleBackColor = true;
            this.buttonSetNoClipKey.Click += new System.EventHandler(this.buttonSetNoClipKey_Click);
            // 
            // buttonResetNoClipKey
            // 
            this.buttonResetNoClipKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetNoClipKey.Location = new System.Drawing.Point(291, 516);
            this.buttonResetNoClipKey.Name = "buttonResetNoClipKey";
            this.buttonResetNoClipKey.Size = new System.Drawing.Size(66, 51);
            this.buttonResetNoClipKey.TabIndex = 42;
            this.buttonResetNoClipKey.Text = "Reset";
            this.buttonResetNoClipKey.UseVisualStyleBackColor = true;
            this.buttonResetNoClipKey.Click += new System.EventHandler(this.buttonResetNoClipKey_Click);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageColors.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonSetHeadColor;
        private Button buttonSetBodyColor;
        private CheckBox checkBoxRainbowColor;
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
    }
}