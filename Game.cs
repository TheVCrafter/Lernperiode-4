using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using NAudio.Wave;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Winforms_experiment
{
    public partial class Wintris_Gameplay : Form
    {

        int size = 50;
        int startX = 50, startY = 50;
        int movementY = 50;
        int speed = 0;
        int shapecounter = 0;
        int xoffset = 0;
        int yoffset = 0;
        int score = 0;
        Label scoreDisplay;
        PictureBox[] nextShape = new PictureBox[4];
        PictureBox[] previousShapes = new PictureBox[2048];
        private System.Windows.Forms.Timer fallTimer = new System.Windows.Forms.Timer();
        private Dictionary<string, int[][,]> shapeRotations;
        public Wintris_Gameplay()
        {
            InitializeComponent();
            MusicPlayer player = new MusicPlayer();
            player.PlayMusic(@"C:\Users\vince\source\repos\Winforms experiment\bin\Debug\Tetris.mp3");
            fallTimer.Interval = 500;
            fallTimer.Tick += FallTimer_Tick;
            fallTimer.Start();
            this.KeyDown += Game_KeyDown;
            this.KeyPreview = true;
            scoreDisplay = new Label()
            {
                Left = 10,
                Top = 0,
                Text = $"Score: {score}"
            };
            this.Controls.Add(scoreDisplay);
            scoreDisplay.BringToFront();
            // O-Shape (keine Rotation nötig)
            int[,] oCoordinates = { { -1, 3 }, { -1, 4 }, { 0, 3 }, { 0, 4 } };

            // S-Shape
            int[,] sCoordinates_0 = { { -1, 4 }, { -1, 5 }, { 0, 3 }, { 0, 4 } };
            int[,] sCoordinates_90 = { { -1, 4 }, { 0, 4 }, { 0, 5 }, { 1, 5 } };

            // Z-Shape
            int[,] zCoordinates_0 = { { -1, 3 }, { -1, 4 }, { 0, 4 }, { 0, 5 } };
            int[,] zCoordinates_90 = { { -1, 5 }, { 0, 5 }, { 0, 4 }, { 1, 4 } };

            // L-Shape
            int[,] lCoordinates_0 = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 1, 4 } };
            int[,] lCoordinates_90 = { { 0, 3 }, { 0, 4 }, { 0, 5 }, { 1, 3 } };
            int[,] lCoordinates_180 = { { -1, 3 }, { -1, 4 }, { 0, 4 }, { 1, 4 } };
            int[,] lCoordinates_270 = { { -1, 3 }, { 0, 3 }, { 0, 2 }, { 0, 1 } };

            // J-Shape
            int[,] jCoordinates_0 = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 1, 2 } };
            int[,] jCoordinates_90 = { { -1, 4 }, { 0, 4 }, { 1, 4 }, { 1, 5 } };
            int[,] jCoordinates_180 = { { -1, 3 }, { -1, 4 }, { 0, 4 }, { 1, 4 } };
            int[,] jCoordinates_270 = { { 0, 3 }, { 0, 2 }, { 0, 1 }, { -1, 1 } };

            // T-Shape
            int[,] tCoordinates_0 = { { -1, 4 }, { 0, 4 }, { 0, 3 }, { 0, 5 } };
            int[,] tCoordinates_90 = { { -1, 4 }, { 0, 4 }, { 1, 4 }, { 0, 3 } };
            int[,] tCoordinates_180 = { { -1, 4 }, { 0, 4 }, { 0, 3 }, { 0, 5 } };
            int[,] tCoordinates_270 = { { -1, 4 }, { 0, 4 }, { 1, 4 }, { 0, 5 } };

            // I-Shape
            int[,] iCoordinates_0 = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 2, 3 } };
            int[,] iCoordinates_90 = { { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 } };

            shapeRotations = new Dictionary<string, int[][,]>
    {
        { "S", new int[][,] { sCoordinates_0, sCoordinates_90 } },
        { "Z", new int[][,] { zCoordinates_0, zCoordinates_90 } },
        { "L", new int[][,] { lCoordinates_0, lCoordinates_90, lCoordinates_180, lCoordinates_270 } },
        { "J", new int[][,] { jCoordinates_0, jCoordinates_90, jCoordinates_180, jCoordinates_270 } },
        { "T", new int[][,] { tCoordinates_0, tCoordinates_90, tCoordinates_180, tCoordinates_270 } },
        { "I", new int[][,] { iCoordinates_0, iCoordinates_90 } }
    };

            CreateShape();
        }

        void CreateShape()
        {
            scoreDisplay.Text = $"Score: {score}";
            xoffset = 0;
            yoffset = 0;
            Random rnd = new Random();
            List<string> shapeKeys = new List<string>(shapeRotations.Keys);
            string randomShapeKey = shapeKeys[rnd.Next(shapeKeys.Count)];
            currentShape = randomShapeKey; // Setze die aktuelle Form für die Rotation
            int[,] nextCoordinates = shapeRotations[randomShapeKey][0];
            NeueForm(nextCoordinates);
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
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = Image.FromFile("C:\\Users\\vince\\source\\repos\\Winforms experiment\\bin\\Debug\\Wintrisblock.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };



                nextShape[i] = (box);
                this.Controls.Add(box);
            }
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            bool touchingEdge = false;
            if (e.KeyCode == Keys.Left)
            {
                foreach (PictureBox box in nextShape)
                {
                    if (box.Left == 0)
                    {
                        touchingEdge = true;
                    }
                }
                if (!touchingEdge)
                {
                    for (int i = 0; i < previousShapes.Length; i++)
                    {
                        if (previousShapes[i] == null) continue;

                        foreach (PictureBox box in nextShape)
                        {
                            if (box.Left == previousShapes[i].Right && box.Bottom == previousShapes[i].Bottom)
                            {
                                touchingEdge = true;
                                break;
                            }
                        }
                    }
                }
                if (!touchingEdge)
                {
                    foreach (PictureBox box in nextShape)
                    {
                        box.Left -= movementY;
                        xoffset = box.Left;
                    }
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                foreach (PictureBox box in nextShape)
                {
                    if (box.Right >= this.ClientRectangle.Right)
                    {
                        touchingEdge = true;
                    }
                }
                if (!touchingEdge)
                {
                    for (int i = 0; i < previousShapes.Length; i++)
                    {
                        if (previousShapes[i] == null) continue;

                        foreach (PictureBox box in nextShape)
                        {
                            if (box.Right == previousShapes[i].Left && box.Bottom == previousShapes[i].Bottom && previousShapes[i].Visible)
                            {
                                touchingEdge = true;
                                break;
                            }
                        }
                    }
                }
                if (!touchingEdge)
                {
                    foreach (PictureBox box in nextShape)
                    {
                        box.Left += movementY;
                        xoffset = box.Left;
                    }
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                RotateShape();
            }
        }
        private void FallTimer_Tick(object sender, EventArgs e)
        {
            bool touchingBottom = false;
            foreach (PictureBox box in nextShape)
            {
                if (box.Bottom >= this.ClientRectangle.Bottom)
                {
                    touchingBottom = true;
                }
            }
            if (!touchingBottom)
            {
                for (int i = 0; i < previousShapes.Length; i++)
                {
                    if (previousShapes[i] == null) continue;

                    foreach (PictureBox box in nextShape)
                    {
                        if (box.Bottom == previousShapes[i].Top && box.Left == previousShapes[i].Left && previousShapes[i].Visible)
                        {
                            touchingBottom = true;
                            break;
                        }
                    }
                }
            }
            if (!touchingBottom)
            {
                foreach (PictureBox box in nextShape)
                {
                    box.Top += size;
                    yoffset = box.Top;
                }
            }
            if (touchingBottom)
            {
                for (int i = 0; i < nextShape.Length; i++)
                {
                    if (shapecounter < 2048)
                    {
                        shapecounter++;
                    }
                    previousShapes[shapecounter] = nextShape[i];
                }
                for (int i = 0; i < 19; i++)
                {
                    int y = i * size;
                    int boxesInLine = 0;
                    foreach (PictureBox box in previousShapes)
                    {
                        if (box != null && box.Top == y)
                        {
                            boxesInLine++;
                        }
                    }
                    if (boxesInLine == 10)
                    {
                        foreach (PictureBox box in previousShapes)
                        {
                            if (box != null && box.Top == y)
                            {
                                box.Hide();
                                score += 50;
                            }
                            else if (box != null && box.Bottom != this.ClientRectangle.Bottom)
                            {
                                box.Top += 50;
                            }
                        }
                    }
                }
                CreateShape();

            }
        }
        private string currentShape = "";
        private int currentRotationIndex = 0;
        void RotateShape()
        {
            if (shapeRotations.ContainsKey(currentShape))
            {
                currentRotationIndex = (currentRotationIndex + 1) % shapeRotations[currentShape].Length;
                int[,] newCoordinates = shapeRotations[currentShape][currentRotationIndex];
                ApplyNewCoordinates(newCoordinates);
            }

        }

        void ApplyNewCoordinates(int[,] newCoordinates)
        {
            for (int i = 0; i < nextShape.Length; i++)
            {
                int x = newCoordinates[i, 1];
                int y = newCoordinates[i, 0];
                nextShape[i].Left = startX + (x * size + (yoffset - 250));
                nextShape[i].Top = startY + (y * size + (xoffset));

            }
        }

        private void Wintris_Gameplay_Load(object sender, EventArgs e)
        {

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
