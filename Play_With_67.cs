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
        private static Dictionary<string,bool> FindVideo = new Dictionary<string, bool>()
        {
            { "MGE_GIRL",false},
            { "Linux",false}
        };
        private MediaPlayer Player = new MediaPlayer(Form1.libmedia);// vlc плейер
        private  List<string> media_list = new List<string>()//список медиа
        {
            "Media/mge_girl.mp4",
            "Media/linux.mp4"
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
                        FindVideo["MGE_GIRL"] = true;
                        break;
                    case 1:
                        time.Interval = 10000;
                        FindVideo["Linux"] = true;
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
            Get_Video = FindVideo;
            this.FormClosed += new FormClosedEventHandler(closed_form);

        }
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
        public static Dictionary<string, bool> Get_Video {
            get { return FindVideo; }
            set { FindVideo = value; }
        }

        private void videoView1_Click(object sender, EventArgs e)
        {

        }
    }
}

