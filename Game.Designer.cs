﻿namespace Winforms_experiment
{
    partial class Wintris_Gameplay
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wintris_Gameplay));
            imageList1 = new ImageList(components);
            button1 = new Button();
            PauseMenu = new PictureBox();
            scoreDisplay = new Label();
            levelDisplay = new Label();
            GameTime = new Label();
            Settings = new Button();
            Continue = new Button();
            leaveGame = new Button();
            ((System.ComponentModel.ISupportInitialize)PauseMenu).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // button1
            // 
            button1.BackColor = Color.Firebrick;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(459, 12);
            button1.Name = "button1";
            button1.Size = new Size(29, 29);
            button1.TabIndex = 10;
            button1.TabStop = false;
            button1.Text = "I I";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // PauseMenu
            // 
            PauseMenu.BackColor = Color.Transparent;
            PauseMenu.Image = Properties.Resources.Design_ohne_Titel__5__removebg_preview;
            PauseMenu.Location = new Point(42, 78);
            PauseMenu.Name = "PauseMenu";
            PauseMenu.Size = new Size(409, 614);
            PauseMenu.TabIndex = 1;
            PauseMenu.TabStop = false;
            // 
            // scoreDisplay
            // 
            scoreDisplay.AutoSize = true;
            scoreDisplay.BackColor = Color.Transparent;
            scoreDisplay.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scoreDisplay.Location = new Point(12, 20);
            scoreDisplay.Name = "scoreDisplay";
            scoreDisplay.Size = new Size(62, 21);
            scoreDisplay.TabIndex = 2;
            scoreDisplay.Text = "label1";
            // 
            // levelDisplay
            // 
            levelDisplay.AutoSize = true;
            levelDisplay.BackColor = Color.Transparent;
            levelDisplay.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            levelDisplay.Location = new Point(153, 20);
            levelDisplay.Name = "levelDisplay";
            levelDisplay.Size = new Size(62, 21);
            levelDisplay.TabIndex = 3;
            levelDisplay.Text = "label2";
            // 
            // GameTime
            // 
            GameTime.AutoSize = true;
            GameTime.BackColor = Color.Transparent;
            GameTime.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GameTime.Location = new Point(309, 20);
            GameTime.Name = "GameTime";
            GameTime.Size = new Size(62, 21);
            GameTime.TabIndex = 4;
            GameTime.Text = "label3";
            // 
            // Settings
            // 
            Settings.BackColor = Color.Black;
            Settings.Location = new Point(171, 381);
            Settings.Name = "Settings";
            Settings.Size = new Size(159, 55);
            Settings.TabIndex = 11;
            Settings.Text = "Settings";
            Settings.UseVisualStyleBackColor = false;
            Settings.Click += Settings_Click;
            // 
            // Continue
            // 
            Continue.BackColor = Color.Black;
            Continue.Location = new Point(171, 455);
            Continue.Name = "Continue";
            Continue.Size = new Size(159, 55);
            Continue.TabIndex = 12;
            Continue.Text = "Continue";
            Continue.UseVisualStyleBackColor = false;
            Continue.Click += Continue_Click;
            // 
            // leaveGame
            // 
            leaveGame.BackColor = Color.Black;
            leaveGame.Location = new Point(171, 533);
            leaveGame.Name = "leaveGame";
            leaveGame.Size = new Size(159, 55);
            leaveGame.TabIndex = 13;
            leaveGame.Text = "leave Game";
            leaveGame.UseVisualStyleBackColor = false;
            leaveGame.Click += leaveGame_Click;
            // 
            // Wintris_Gameplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Firebrick;
            ClientSize = new Size(500, 950);
            ControlBox = false;
            Controls.Add(leaveGame);
            Controls.Add(Continue);
            Controls.Add(Settings);
            Controls.Add(GameTime);
            Controls.Add(levelDisplay);
            Controls.Add(scoreDisplay);
            Controls.Add(PauseMenu);
            Controls.Add(button1);
            ForeColor = SystemColors.Control;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Wintris_Gameplay";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Wintris_Gameplay";
            Load += Wintris_Gameplay_Load;
            ((System.ComponentModel.ISupportInitialize)PauseMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ImageList imageList1;
        public PictureBox PauseMenu;
        public Label scoreDisplay;
        private Label levelDisplay;
        private Label GameTime;
        public Button button1;
        private Button Settings;
        private Button Continue;
        private Button leaveGame;
    }
}