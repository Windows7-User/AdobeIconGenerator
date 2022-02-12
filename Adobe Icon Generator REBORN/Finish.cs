using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Adobe_Icon_Generator_REBORN.Properties;
using Adobe_Icon_Generator.Properties;
using System.Diagnostics;

namespace Adobe_Icon_Generator
{
    public partial class Finish : Form
    {
        public Finish(string FilePath, string FolderPath)
        {
            Path = FilePath;
            FolderPathLocal = FolderPath;
            InitializeComponent();
        }
        string Path;
        string FolderPathLocal;

        private void Finish_Load(object sender, EventArgs e)
        {
            timer1.Start();
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.Ready);
            soundPlayer.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(FolderPathLocal);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox1.Hide();
            pictureBox1.Image = Properties.Resources.checkbox_still;
            pictureBox1.Show();
        }
    }
}
