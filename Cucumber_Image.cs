using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Properties.Resources.v_md,
            Properties.Resources.mama_cuc
            };

        private Random Random_index = new Random();
        public Cucumber_Image()
        {
            InitializeComponent();
            LoadMEME();
        }

        private void LoadMEME()
        {
            int index_meme = Random_index.Next(images.Count);
            switch (index_meme)
            {
                case 0:
                    this.Text = "Не повезло >:)  -- V";
                    break;
                case 1:
                    this.Text = "О НЕТ ОГУРЦЫ СЬЕЛИ";
                    break;
            }
            pictureBox1.Image = images[index_meme];

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
