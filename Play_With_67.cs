using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
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
        private SoundPlayer Player_67 = new SoundPlayer();//газанFM

        private MediaPlayer Player = new MediaPlayer(Form1.libmedia);// vlc плейер
        private List<string> media_list = new List<string>()//список медиа
        {
            "Media/mge_girl.mp4",
            "Media/linux.mp4"
        };
        private Dictionary<string, bool> List_video_find = new Dictionary<string, bool>()
        {
            { "MGE_GIRL",false},
            { "Linux",false}
        };

        public Play_With_67(bool MGE_status)
        {
            InitializeComponent();
            this.TopMost = true;
            if (MGE_status)
            {
                Random random = new Random();
                int index = random.Next(0,media_list.Count);
                Timer time = new Timer();
                switch (index)// TRUE
                {
                    case 0:
                        time.Interval = 16000;
                        List_video_find["MGE_GIRL"] = true;
                        break;
                    case 1:
                        time.Interval = 10000;
                        List_video_find["Linux"] = true;
                        break;
                }
                
                time.Tick += new EventHandler(timer_stop);
                time.Start();
                
                
                videoView1.MediaPlayer = Player;
                var media = new Media(Form1.libmedia, media_list[index], FromType.FromPath);
                this.Icon = Properties.Resources.eye;
                if (index == 1) // в будущем переписать в case
                {
                    this.Text = "ONLYLINUX";
                }
                else 
                {
                    this.Text = "Вас что-то заметило";
                }
                
                Player.Play(media);
                this.ShowInTaskbar = false;

                
               
                 
            }
            else
            {
                Player_67.SoundLocation = "sound/Gazan_67_Six_Seven.wav";
                videoView1.Visible = false;
                videoView1.Enabled = false;
                Player_67.Play();
            }
            ListVideo = List_video_find;
            this.FormClosed += new FormClosedEventHandler(closed_form);

        }
        public static Dictionary<string, bool> ListVideo { get; set; }
        private void timer_stop(object sender, EventArgs e)
        {
            this.Close();
            Player.Stop();
        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {
           // Process.Start("")
        }
        private void closed_form(object sender, EventArgs e)
        {
            Player_67.Stop();
            Player.Stop();

        }
       

        private void videoView1_Click(object sender, EventArgs e)
        {

        }
    }
}

