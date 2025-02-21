using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Winforms_experiment
{
    public partial class Game : Form
    {
        List<PictureBox> lShape = new List<PictureBox>();
        int size = 50;
        int startX = 50, startY = 50;
        int verschiebungY = 5;

        public Game()
        {
            InitializeComponent();
            
            int[,] lKoordinaten = { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 2, 1 } };
            for (int i = 0; i < lKoordinaten.GetLength(0); i++)
            {
                int x = lKoordinaten[i, 1];
                int y = lKoordinaten[i, 0];

                PictureBox box = new PictureBox
                {
                    Width = size,
                    Height = size,
                    Left = startX + (x * size),
                    Top = startY + (y * size),
                    BackColor = Color.DarkRed,
                    BorderStyle = BorderStyle.FixedSingle
                };

                lShape.Add(box);
                this.Controls.Add(box);
            }
            this.KeyDown += Game_KeyDown;
            this.KeyPreview = true; 
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                foreach (PictureBox element in lShape)
                {
                    element.Top += verschiebungY;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
