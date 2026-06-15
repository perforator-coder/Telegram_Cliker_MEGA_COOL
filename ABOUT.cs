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
using WindowsFormsApp3.Properties;

namespace WindowsFormsApp3
{
    public partial class ABOUT : Form
    {
        //private SoundPlayer sound = new SoundPlayer();
        private Dictionary<string, bool> list_meme_find;
        private Dictionary<string, Image> list_res_meme;
        private List<string> memeKey;
        private int index = 0;
        public ABOUT()
        {
            InitializeComponent();
            //sound.SoundLocation = "";
            list_meme_find=Cucumber_Image.ListFindMEME;
            list_res_meme = Cucumber_Image.ListMEME;
            memeKey = list_meme_find.Keys.ToList();
            loadmeme();
        }
        private void loadmeme()
        {
            string curet_meme = memeKey[index];
            if (list_meme_find[curet_meme] == false)
            {
                galari_box.Image = Resources.close;
            }
            else 
            {
                galari_box.Image = list_res_meme[curet_meme];
            }
        }
        private void prev_pic_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = memeKey.Count - 1;
            }
            loadmeme();
        }

        private void next_pic_Click(object sender, EventArgs e)
        {
            index++;
            if (index >= memeKey.Count)
            {
                index = 0;
            }
            loadmeme();
        }
    }
}
