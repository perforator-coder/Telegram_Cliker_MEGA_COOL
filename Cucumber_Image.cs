using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        // У меня не получислось сделать словарик с картинкой и его состоянием :(((((((((((((
        // если я создам и укажу Propertis.Resources.[Название фото] то потом будет в ключе BitMap
        public Cucumber_Image()
        {
            InitializeComponent();
            LoadMEME();
           
        }
        //свойство для получения эпичный ли мем или нет
        public bool isEPIC { get; set; }
       
        private void LoadMEME()
        {
          
            int Epic_chose = random_shanc.Next(0,101);
            int index_meme = 0;
            if (Epic_chose >= 5) // уровень шанса
            {
                index_meme = Random_index.Next(images.Count);
                switch (index_meme)
                {
                    case 0:
                        this.Text = "О НЕТ ОГУРЦЫ СЬЕЛИ";
                        
                        break;
                    case 1:
                        this.Text = "ОРЕШКИ БИГ БОБ";
                      
                        this.Icon = Properties.Resources.melon;
                        break;
                    case 2:
                        this.Text = "ДЯДЯ ЖИРШТЕЙН";
                       
                        this.Icon = Properties.Resources.hamburger;
                        break;
                    
                        
                }
                isEPIC = false;
                pictureBox1.Image = images[index_meme];
            }
            else 
            {
                //код если число <= n
                // код для показа особых мемов
                index_meme = Random_index.Next(EPIC_MEMES.Count);
                switch (index_meme)
                {
                    case 0:
                        this.Text = "Не повезло >:)  -- V";
                        this.Icon = Properties.Resources.v_icon;
                        
                        break;
                    case 1:
                        this.Text = "О НЕТ ТОЛЬКО НЕ БАНКА -- V";
                        this.Icon = Properties.Resources.bank;
                        
                        break;
                    case 2:
                        this.Text = "ГДЕ ТО НА ОСТРОВЕ";
                        this.Icon = Properties.Resources.island;
                        
                        break;
                    case 3:
                        this.Text = "🍧";
                        this.Icon = Properties.Resources.tink;
                       
                        break;

                }
                isEPIC = true;
                pictureBox1.Image = EPIC_MEMES[index_meme];
               
                
            }
            
        }
       
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
