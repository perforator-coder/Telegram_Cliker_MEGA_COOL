using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp3
{
    public partial class Cucumber_Image : Form
    {
        private List<Image> images = new List<Image>
        { 
            
            Properties.Resources.mama_cuc,
            Properties.Resources.hagiev,
            Properties.Resources.fat_epstein
            
        };
        private List<Image> EPIC_MEMES = new List<Image>() //особые мемы
        {
            Properties.Resources.v_md,
            Properties.Resources.v_in_can,
            Properties.Resources.edit_epstein_mega_cool,
            Properties.Resources.ice_bac
        };
        private Random random_shanc = new Random(); //рандомное число на эпичный мем
        private Random Random_index = new Random(); // рандом для листа
        private static int all_open_memes = 0; //количество всех мемов открытых мемов
        private static Dictionary<string, bool> MEME_status = new Dictionary<string, bool>() // словарь для сохранения статуса найденого мема
        {
            { "mama_cuc",false},
            { "hagiev",false},
            { "fat_epstein",false},
            { "v_md",false},
            { "v_in_can",false},
            { "edit_epstein_mega_cool",false},
            { "ice_bac",false}
        };
        private static readonly Dictionary<string, Image> MEME_LIST = new Dictionary<string, Image>() //словарь для сохранения списка всех мемов
        {
             { "mama_cuc",Properties.Resources.mama_cuc},
            { "hagiev",Properties.Resources.hagiev},
            { "fat_epstein",Properties.Resources.fat_epstein},
            { "v_md",Properties.Resources.v_md},
            { "v_in_can",Properties.Resources.v_in_can},
            { "edit_epstein_mega_cool",Properties.Resources.edit_epstein_mega_cool},
            { "ice_bac",Properties.Resources.ice_bac}
            
        };
       

        public Cucumber_Image()
        {
            InitializeComponent();
            LoadMEME();
            ListFindMEME = MEME_status;
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_stop);
            timer.Start();
            



        }
        //свойство для получения эпичный ли мем или нет
        public bool isEPIC { get; set; }
        //свойство для передачи списка найденых мемов
        public static Dictionary<string,bool> ListFindMEME { get; set; }
        // свойство для передачи списка всех мемов
        public static Dictionary<string, Image> ListMEME { get { return MEME_LIST; } }
       
        private void LoadMEME()
        {
            
            
            int Epic_chose = random_shanc.Next(0,101);
            if (all_open_memes >= 15) // если обычных мемов найдено более 15
            {
                LegendaryMEME();
            }
            else
            {
                if (Epic_chose >= 5) // уровень шанса
                {
                    SimpleMEME();
                }
                else
                {
                    LegendaryMEME();
                }
                
            }
            /* foreach (var i in MEME_status)
                 { 
                     Console.WriteLine(i);
                 }*/
        }

        private void timer_stop(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }
        private void LegendaryMEME()
        {
            //код если число <= n
            // код для показа особых мемов
            int index_meme = 0;
            index_meme = Random_index.Next(EPIC_MEMES.Count);
            switch (index_meme)
            {
                case 0:
                    this.Text = "Не повезло >:)  -- V";
                    this.Icon = Properties.Resources.v_icon;
                    MEME_status["v_md"] = true;
                    break;
                case 1:
                    this.Text = "О НЕТ ТОЛЬКО НЕ БАНКА -- V";
                    this.Icon = Properties.Resources.bank;
                    MEME_status["v_in_can"] = true;
                    break;
                case 2:
                    this.Text = "ГДЕ ТО НА ОСТРОВЕ";
                    this.Icon = Properties.Resources.island;
                    MEME_status["edit_epstein_mega_cool"] = true;
                    break;
                case 3:
                    this.Text = "🍧";
                    this.Icon = Properties.Resources.tink;
                    MEME_status["ice_bac"] = true;
                    break;

            }
            isEPIC = true;
            all_open_memes = 0;// если мем найден легиндарным то 0
            pictureBox1.Image = EPIC_MEMES[index_meme];
        }
        private void SimpleMEME()
        {
            //Обычные мемы
            int index_meme = 0;
            index_meme = Random_index.Next(images.Count);
            switch (index_meme)
            {
                case 0:
                    this.Text = "О НЕТ ОГУРЦЫ СЬЕЛИ";
                    MEME_status["mama_cuc"] = true;
                    break;
                case 1:
                    this.Text = "ОРЕШКИ БИГ БОБ";
                    MEME_status["hagiev"] = true;
                    this.Icon = Properties.Resources.melon;
                    break;
                case 2:
                    this.Text = "ДЯДЯ ЖИРШТЕЙН";
                    MEME_status["fat_epstein"] = true;
                    this.Icon = Properties.Resources.hamburger;
                    break;
            }
            isEPIC = false;
            all_open_memes += 1; //повышаем шанс на легендарный
            pictureBox1.Image = images[index_meme];
        }
    }
}
