using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private int hamster_coin = 0;
        private SoundPlayer Player_67 = new SoundPlayer();
        private bool Play_on = false;
        
        public Form1()
        {
            InitializeComponent();
            button6.Visible = false;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hamster_coin >= 100)
            {
                button6.Visible = true;
            }
            else 
            {
                button6.Visible = false;
            }
            hamster_coin++;
            label2.Text = hamster_coin.ToString();
            pictureBox1.Visible = true; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MAX form_max = new MAX();
            form_max.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Player_67.SoundLocation = "Gazan_67_Six_Seven.wav";
            if (Play_on == false)
            {
                Play_With_67 Form_67 = new Play_With_67();
                Form_67.Show();
                Player_67.Play();
                Play_on = true;
            }
            else 
            {
                Player_67.Stop();
                Play_on = false;
            }
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (hamster_coin >= 100)
            {
                Cucumber_Image cucumber = new Cucumber_Image();
                cucumber.Show();
                hamster_coin -= 100;
                label2.Text = hamster_coin.ToString();
                button6.Visible = false;
            }
            else 
            {
                //вставте сюда смешной код
            }
        }
    }
}

