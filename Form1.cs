using LibVLCSharp.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace WindowsFormsApp3
{
   
    public partial class Form1 : Form
    {
        private long hamster_coin = 0; // Главный счесчик
        private int power_tap = 1; // сила клика 
        private bool max_pay = false; // проверка что поставлена галочка
        private bool count_click = false; // проверка что показывается сила клика
        private Random Random = new Random(); // рандом MGE
        private int shans = -100; // шанс на MGE
        public static LibVLC libmedia = new LibVLC(); // Библиотека для vlc
       

        public Form1()
        {
           
            InitializeComponent();
            ReadJson();
            button6.Visible = false;
            label2.Text = hamster_coin.ToString();
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
                numericUpDown1.Visible = true;
            }
            else
            {
                button6.Visible = false;
                numericUpDown1.Visible = false;
            }
            this.FormClosed += new FormClosedEventHandler(save_json);
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
            int random_shans = Random.Next(1, 10000);
            if (random_shans <= shans )
            {
                Play_With_67 MGE = new Play_With_67(true);
                hamster_coin -= (hamster_coin / 100) * 15;
                label2.Text = hamster_coin.ToString();
                MGE.ShowDialog();
                shans = -100;
            }
            else           
            {
                shans += 1;
            }
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
                numericUpDown1.Visible = true;
            }
            else 
            {
                button6.Visible = false;
                numericUpDown1.Visible = false;
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
            Play_With_67 form67 = new Play_With_67(false);
            form67.Show();
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
         
            if (hamster_coin >= 100)
            {
                
                if (max_pay)
                {
                    //действия при поставленой галочой
                    int max_upgrade = (int)hamster_coin / 100;
                    int ost = (int)hamster_coin % 100;//проблема
                    
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
                    hamster_coin = ost;
                    label2.Text = hamster_coin.ToString();
                    if (!(hamster_coin >= 100))
                    {
                        button6.Visible = false;
                        checkBox1.Visible = false;
                    }
                   

                }
                else 
                {
                    if (setcol())
                    {
                        for (int i = 1; i < numericUpDown1.Value + 1; i++)
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
                                numericUpDown1.Visible = false;
                            }
                            else if (hamster_coin >= 100 && hamster_coin < 200)
                            {
                                checkBox1.Visible = false;
                            }
                        }
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
        private bool setcol()
        {
            int index = (int)numericUpDown1.Value;
            int need_pay = 100 * index;
            if (hamster_coin < need_pay)
            {
                MessageBox.Show("Недостаточно средств", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else 
            {
                return true;
            }
        }
        private void save_json(object sender, EventArgs e) // для сохранения кликов после закрытия
        {
            var save_data = new { coin = hamster_coin, power_clik = power_tap, MEMES_find = Cucumber_Image.ListFindMEME, Find_Video = Play_With_67.Get_Video };
            string json_info = JsonConvert.SerializeObject(save_data);
            File.WriteAllText("USER_info.json",json_info);
            
        }
        private void ReadJson()
        {
            if (File.Exists("USER_info.json"))
            {
                string Json_info = File.ReadAllText("USER_info.json");
                json_info Data = JsonConvert.DeserializeObject<json_info>(Json_info);
                hamster_coin = Data.coin;
                power_tap = Data.power_clik;
                
            }
        }
       
    }
}

