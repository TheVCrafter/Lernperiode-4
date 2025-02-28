using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using NAudio.Wave;

namespace Winforms_experiment
{
    public partial class Game : Form
    {
        
        int size = 50;
        int startX = 50, startY = 50;
        int movementY = 5;
        int speed = 0;
        PictureBox[] nextShape = new PictureBox[4];
        private System.Windows.Forms.Timer fallTimer = new System.Windows.Forms.Timer();
        public Game()
        {

            InitializeComponent();
            MusicPlayer player = new MusicPlayer();
            player.PlayMusic(@"C:\Users\vince\source\repos\Winforms experiment\bin\Debug\Tetris.mp3");
            int[,] oCoordinates = { { -1, 3 }, { -1, 4 }, { 0, 3 }, { 0, 4 } };
            int[,] sCoordinates = { { -1, 5 }, { -1, 4 }, { 0, 4 }, { 0, 3 } };
            int[,] lCoordinates = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 1, 4 } };
            int[,] zCoordinates = { { -1, 3 }, { -1, 4 }, { 0, 4 }, { 0, 5 } };
            int[,] tCoordinates = { { -1, 4 }, { 0, 4 }, { 0, 3 }, { 0, 5 } };
            int[,] jCoordinates = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 1, 2 } };
            int[,] iCoordinates = { { -1, 3}, { 0, 3}, { 1, 3}, { 2, 3 } };
            Random rnd = new Random();
            int randomint = rnd.Next(1,8);
            int[,] nextCoordinates = { };
            switch (randomint)
            {
                case 1: nextCoordinates = oCoordinates;
                    break;
                case 2: nextCoordinates = sCoordinates;
                    break;
                case 3: nextCoordinates = lCoordinates;
                    break;
                case 4: nextCoordinates = zCoordinates;
                    break;
                case 5: nextCoordinates = tCoordinates;
                    break;
                case 6: nextCoordinates = jCoordinates;
                    break;
                case 7: nextCoordinates = iCoordinates;
                    break;
            }
            NeueForm(nextCoordinates);
            fallTimer.Interval = 500;
            fallTimer.Tick += FallTimer_Tick;
            fallTimer.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        void NeueForm(int[,] koordinaten)
        {
            for (int i = 0; i < koordinaten.GetLength(0); i++)
            {
                int x = koordinaten[i, 1];
                int y = koordinaten[i, 0];

                PictureBox box = new PictureBox
                {
                    Width = size,
                    Height = size,
                    Left = startX + (x * size),
                    Top = startY + (y * size),
                    BackColor = Color.DarkRed,
                    BorderStyle = BorderStyle.FixedSingle
                };
                box.Image = Image.FromFile("C:\\Users\\vince\\source\\repos\\Winforms experiment\\bin\\Debug\\Wintrisblock.png");


                nextShape[i] = (box);
                this.Controls.Add(box);
            }
            this.KeyDown += Game_KeyDown;
            this.KeyPreview = true;
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                foreach (PictureBox box in nextShape)
                {
                    box.Left -= movementY;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                foreach (PictureBox box in nextShape)
                {
                    box.Left += movementY;
                } 
            }
        }
        private void FallTimer_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox box in nextShape)
            {
                box.Top += size;
            }
        }

    }
    public class MusicPlayer
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public void PlayMusic(string filePath)
        {
            StopMusic();

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(filePath);
            outputDevice.Init(audioFile);
            outputDevice.Play();
        }

        public void StopMusic()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                audioFile.Dispose();
                outputDevice = null;
                audioFile = null;
            }
        }
    }
}

