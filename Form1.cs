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
        private long hamster_coin = 1000; // Главный счесчик
        private SoundPlayer Player_67 = new SoundPlayer(); // 67
        private bool Play_on = false; // проверка что есть музыка 67
        private int power_tap = 1; // сила клика 
        private bool max_pay = false; // проверка что поставлена галочка
        private bool count_click = false; // проверка что показывается сила клика
        
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
            //обработка клика
            hamster_coin += power_tap;
            label2.Text = hamster_coin.ToString();
            pictureBox1.Visible = true;
            //показывание или скрытие при наборе очков
            if (hamster_coin >= 200)
            {
                checkBox1.Visible = true; 
            }
            else
            {
                checkBox1.Visible = false;
            }
            if (hamster_coin >= 100)
            {
                button6.Visible = true;
            }
            else 
            {
                button6.Visible = false;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //секрет
            if (!count_click)
            {
                count_click = true;
                this.Text = $"Сила Клика = {power_tap}";
            }
            else 
            {
                count_click = false;
                this.Text = "Hamster Combat";
            }
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
         
            //6767676767676767
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
                
                if (max_pay)
                {
                    //действия при поставленой галочой
                    int max_upgrade = (int)hamster_coin / 100;
                    
                    for (int i = 0; i < max_upgrade; i++)
                    {
                        Cucumber_Image add_max_count = new Cucumber_Image();
                        add_max_count.Show();
                        if (add_max_count.isEPIC)
                        {
                            power_tap += 4;
                        }
                        else 
                        {
                            power_tap++;
                        }
                        
                    }
                    hamster_coin = hamster_coin / (100 * max_upgrade);
                    label2.Text = hamster_coin.ToString();
                    if (!(hamster_coin >= 100))
                    {
                        button6.Visible = false;
                        checkBox1.Visible = false;
                    }
                   

                }
                else 
                {
                    Cucumber_Image cucumber = new Cucumber_Image();
                    cucumber.Show();
                    hamster_coin -= 100;
                    label2.Text = hamster_coin.ToString();
                    //обработка свойства isEPIC
                    if (cucumber.isEPIC)
                    {
                        power_tap += 4;
                    }
                    else
                    {
                        power_tap++;
                    }
                   
                    //скрытие gui
                    if (!(hamster_coin >= 100))
                    {
                        button6.Visible = false;
                        checkBox1.Visible = false;
                    }
                    else if (hamster_coin >= 100 && hamster_coin < 200)
                    {
                        checkBox1.Visible = false;
                    }

                } 
                
            }
            //обновление показа силы клика
            if (count_click == true)
            {
                this.Text = $"Сила Клика = {power_tap}";
            }
            /*Console.WriteLine("#СПИСОК НАЙДЕНЫХ МЕМОВ#");
            foreach (var i in Cucumber_Image.ListFindMEME)
            {
               
                Console.WriteLine(i);
            }*/ //проверка списка найденых
            /*Console.WriteLine("СПИСОК МЕМОВ");
            foreach (var i in Cucumber_Image.ListMEME)
            {
                Console.WriteLine(i);
            }*/ //проверка списка всех мемов

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                max_pay = true;
            }
            else 
            {
                max_pay = false;
            }
        }
    }
}

