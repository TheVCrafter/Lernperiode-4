namespace Winforms_experiment
{
    public partial class Wintris : Form
    {
        MusicPlayer mainmenumusic = new MusicPlayer();
        public Wintris()
        {
            InitializeComponent();
            string path = "C:\\Users\\vince\\source\\repos\\Winforms experiment\\bin\\Debug\\title-101soundboards.mp3";
            mainmenumusic.PlayMusic(path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Wintris_Gameplay game = new Wintris_Gameplay();
            game.Show();
            mainmenumusic.StopMusic();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
