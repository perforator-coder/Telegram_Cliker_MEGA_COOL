using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;


namespace WindowsFormsApp3
{
    public partial class Play_With_67 : Form
    {
        private SoundPlayer Player_67 = new SoundPlayer();
     
        public Play_With_67(bool MGE_status)
        {
            InitializeComponent();
            this.TopMost = true;
            if (MGE_status)
            {
                Timer time = new Timer();
                time.Interval = 16000;
                time.Tick += new EventHandler(timer_stop);
                time.Start();
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Normal;
              
                this.Icon = Properties.Resources.eye;
                this.Text = "Вас что-то заметило";
                Image image = Properties.Resources.MGE_GIRL;
               
                this.ControlBox = false;
                this.ShowInTaskbar = false;
                pictureBox67.Image = image;
                Player_67.SoundLocation = "sound/mge.wav";
                Player_67.Play();
                
                 
            }
            else
            {
                Player_67.SoundLocation = "sound/Gazan_67_Six_Seven.wav";

                Player_67.PlayLooping();
            }
            this.FormClosed += new FormClosedEventHandler(closed_form);

        }
        private void timer_stop(object sender, EventArgs e)
        {
            this.Close();
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

