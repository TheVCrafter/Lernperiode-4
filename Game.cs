using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        int movementseed = 50;
        int timerinterval = 500;
        bool boostactive = false;
        int shapecounter = 0;
        int xoffset = 0;
        int yoffset = 0;
        int score = 0;
        int level = 1;
        MusicPlayer player = new MusicPlayer();
        Stopwatch gameTime = new Stopwatch();
        Keys RotateKey = Keys.W;
        Keys BoostKey = Keys.S;
        Keys GoLeftKey = Keys.A;
        Keys GoRightKey = Keys.D;
        Keys PauseKey = Keys.Escape;
        int[,] nextCoordinates;
        PictureBox[] nextShape = new PictureBox[4];
        PictureBox[] previousShapes = new PictureBox[2048];
        private System.Windows.Forms.Timer fallTimer = new System.Windows.Forms.Timer();
        private Dictionary<string, int[][,]> shapeRotations;
        public Wintris_Gameplay()
        {
            InitializeComponent();
            PauseMenu.Hide();
            Continue.Hide();
            leaveGame.Hide();
            Settings.Hide();
            player.PlayMusic(@"C:\Users\vince\source\repos\Winforms experiment\bin\Debug\TETRIS PHONK.mp3");
            fallTimer.Interval = 500;
            fallTimer.Tick += FallTimer_Tick;
            fallTimer.Start();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
            scoreDisplay.Text = $"Score: {score}";
            levelDisplay.Text = $"Level: {level}";
            GameTime.Text = $"Time: {gameTime}";
            this.Controls.Add(scoreDisplay);
            this.Controls.Add(levelDisplay);
            gameTime.Start();
            // O-Shape (keine Rotation nötig)
            int[,] oCoordinates = { { -1, 3 }, { -1, 4 }, { 0, 3 }, { 0, 4 } };

            // S-Shape
            int[,] sCoordinates_0 = { { -1, 3 }, { 0, 3 }, { 0, 2 }, { -1, 4 } };
            int[,] sCoordinates_90 = { { -1, 2 }, { 0, 3 }, { 0, 2 }, { 1, 3 } };

            // Z-Shape
            int[,] zCoordinates_0 = { { -1, 3 }, { -1, 4 }, { 0, 4 }, { 0, 5 } };
            int[,] zCoordinates_90 = { { 0, 3 }, { -1, 4 }, { 1, 3 }, { 0, 4 } };

            // L-Shape
            int[,] lCoordinates_0 = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 1, 4 } };
            int[,] lCoordinates_90 = { { 0, 2 }, { 0, 3 }, { -1, 4 }, { 0, 4 } };
            int[,] lCoordinates_180 = { { -1, 2 }, { 0, 3 }, { -1, 3 }, { 1, 3 } };
            int[,] lCoordinates_270 = { { 0, 2 }, { 0, 3 }, { 1, 2 }, { 0, 4 } };

            // J-Shape
            int[,] jCoordinates_0 = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 1, 2 } };
            int[,] jCoordinates_90 = { { 0, 2 }, { 0, 3 }, { 0, 4 }, { 1, 4 } };
            int[,] jCoordinates_180 = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { -1, 4 } };
            int[,] jCoordinates_270 = { { -1, 2 }, { 0, 3 }, { 0, 2 }, { 0, 4 } };

            // T-Shape
            int[,] tCoordinates_0 = { { -1, 3 }, { 0, 3 }, { 0, 2 }, { 0, 4 } };
            int[,] tCoordinates_90 = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 0, 2 } };
            int[,] tCoordinates_180 = { { 0, 2 }, { 0, 3 }, { 1, 3 }, { 0, 4 } };
            int[,] tCoordinates_270 = { { -1, 3 }, { 0, 3 }, { 1, 3 }, { 0, 4 } };

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
            levelDisplay.Text = $"Level: {level}";
            xoffset = 0;
            yoffset = 0;
            Random rnd = new Random();
            List<string> shapeKeys = new List<string>(shapeRotations.Keys);
            string randomShapeKey = shapeKeys[rnd.Next(shapeKeys.Count)];
            currentShape = randomShapeKey; // Setze die aktuelle Form für die Rotation
            nextCoordinates = shapeRotations[randomShapeKey][0];
            NeueForm(nextCoordinates);
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
            /* for (int i = 0;i<nextShape.Length;i++)
             {
                 foreach (PictureBox box in previousShapes)
                 {
                     if (nextShape[i].Top == box.Top && box!= null)
                     {
                         GameOver();

                     }
                 }
             }*/
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            bool touchingEdge = false;
            if (e.KeyCode == GoLeftKey)
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
                    }
                }
            }
            if (e.KeyCode == GoRightKey)
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
            if (e.KeyCode == RotateKey)
            {
                if (currentShape != previousShape)
                {
                    currentRotationIndex = 0;
                }
                RotateShape();
            }
            if (e.KeyCode == BoostKey)
            {
                boostactive = true;
            }
            else
            {
                boostactive = false;
            }
        }
        private void FallTimer_Tick(object sender, EventArgs e)
        {
            if (boostactive)
            {
                fallTimer.Interval = 50;
            }
            else
            {
                fallTimer.Interval = timerinterval;
            }
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
                }
            }
            if (touchingBottom)
            {
                for (int i = 0; i < nextShape.Length; i++)
                {
                    for (int j = 0; j < previousShapes.Length; j++)
                    {
                        if (previousShapes[j] == null)
                        {
                            previousShapes[j] = nextShape[i];
                            break;
                        }
                    }
                    boostactive = false;
                }
                for (int i = 19; i > 0; i--)
                {
                    int y = i * size;
                    int boxesInLine = 0;
                    foreach (PictureBox box in previousShapes)
                    {
                        if (box != null && box.Top == y && box.Visible)
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
                            }
                            if (box != null && box.Top < y && box.Visible)
                            {
                                box.Top += size;
                            }
                        }
                        score += boxesInLine;
                        if (score % 100 == 0)
                        {
                            timerinterval -= 5;
                            level++;
                        }
                        i = 19;
                    }
                }
                for (int i = 0; i < previousShapes.Length; i++)
                {
                    if (previousShapes[i] != null && !previousShapes[i].Visible)
                    {
                        previousShapes[i] = null;
                    }
                }
                CreateShape();

            }
        }
        private string currentShape = "";
        private int currentRotationIndex = 0;
        private string previousShape;
        int previousRotation;
        void RotateShape()
        {
            previousRotation = currentRotationIndex;
            previousShape = currentShape;
            if (shapeRotations.ContainsKey(currentShape))
            {
                currentRotationIndex = (currentRotationIndex + 1) % shapeRotations[currentShape].Length;
                int[,] newCoordinates = shapeRotations[currentShape][currentRotationIndex];
                ApplyNewCoordinates(newCoordinates);
            }

        }

        void ApplyNewCoordinates(int[,] newCoordinates)
        {
            bool illegalrotation = false;
            int[] newXCoordinateswithoffset = new int[nextShape.Length];
            int[] newYCoordinateswithoffset = new int[nextShape.Length];
            xoffset = nextShape[1].Left - (newCoordinates[1, 1] * size);
            yoffset = nextShape[1].Top - (newCoordinates[1, 0] * size);
            for (int i = 0; i < nextShape.Length; i++)
            {
                int x = newCoordinates[i, 1] * size + xoffset;
                int y = newCoordinates[i, 0] * size + yoffset;
                foreach (PictureBox box in previousShapes)
                {
                    if (box != null && box.Visible && (box.Left == x && box.Top == y))
                    {
                        illegalrotation = true;
                        break;
                    }
                }
                if (x < 0 || x > this.ClientRectangle.Right - 50 || y > this.ClientRectangle.Bottom - 50)
                {
                    illegalrotation = true;
                }
                newXCoordinateswithoffset[i] = x;
                newYCoordinateswithoffset[i] = y;
            }
            if (illegalrotation)
            {
                currentRotationIndex = previousRotation;
                return;
            }

            for (int i = 0; i < nextShape.Length; i++)
            {
                nextShape[i].Left = newXCoordinateswithoffset[i];
                nextShape[i].Top = newYCoordinateswithoffset[i];
            }
        }
        public void GameOver()
        {
            Thread.Sleep(500);
            scoreDisplay.Hide();
            levelDisplay.Hide();
            foreach (PictureBox box in previousShapes)
            {
                box.Visible = false;
            }
            this.BackColor = Color.Black;
            Label Gameover = new Label
            {
                ForeColor = Color.DarkRed,
                Text = "Game Over",
                BackColor = Color.Transparent,

            };
        }
        private void Wintris_Gameplay_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            PauseMenu.Show();
            Continue.Show();
            Settings.Show();
            leaveGame.Show();
            fallTimer.Stop();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void Continue_Click(object sender, EventArgs e)
        {
            PauseMenu.Hide();
            Continue.Hide();
            button1.Show();
            leaveGame.Hide();
            Settings.Hide();
            fallTimer.Start();
        }

        private void leaveGame_Click(object sender, EventArgs e)
        {
            Wintris mainMenu = new Wintris();
            player.StopMusic();
            this.Close();
            mainMenu.Show();
        }
    }
}
