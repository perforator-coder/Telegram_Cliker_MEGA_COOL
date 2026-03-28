using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace WindowsFormsApp3
{
    public partial class Play_With_67 : Form
    {
        private SoundPlayer Player_67 = new SoundPlayer();
        public Play_With_67()
        {
            InitializeComponent();
            this.TopMost = true;
            Player_67.SoundLocation = "Gazan_67_Six_Seven.wav";

            Player_67.Play();
            this.FormClosed += new FormClosedEventHandler(closed_form);

        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {
           // Process.Start("")
        }
        private void closed_form(object sender, EventArgs e)
        {
            Player_67.Stop();
        }
    }
}

