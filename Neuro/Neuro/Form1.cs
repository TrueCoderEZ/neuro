using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuro
{
    public partial class Form1 : Form
    {
        bool[,] isThis = new bool[10,205];
        PictureBox[] PBs = new PictureBox[10];
        List<List<int>> keys = new List<List<int>>
        {
            new List<int>(){81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100},//0
            new List<int>(){19, 24, 48,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117},//1
            new List<int>(){16, 17, 18, 46, 49, 50, 51,118, 119, 120, 121, 122,123,124,125,126,127,128,129,130},//2
            new List<int>(){20, 23, 52, 53, 54, 55, 56, 131,132,133,134,135,136,137,138,139,140,141,142,143},//3
            new List<int>(){21, 22, 57,144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,160},//4
            new List<int>(){1, 2, 3, 4, 5, 26, 27, 28, 29, 30, 31, 32, 33, 34, 42, 47, 59,161,162,163},//5
            new List<int>(){6, 7, 8, 9, 35, 36, 37, 38, 60,164,165,166,167,168,169,170,171,172,173,174},//6
            new List<int>(){10, 11, 43, 61, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80},//7
            new List<int>(){12, 13, 44, 45, 60, 62,175,176,177,178,179,180,181,182,183,184,185,186,187,188},//8
            new List<int>(){14, 15, 39, 40, 41, 63,189,190,191,192,193,194,195,196,197,198,199,200,201,202},//9
        };
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j < 203; j++)
                    isThis[i, j] = keys[i].Contains(j);
                PBs[i] = new PictureBox();
                PBs[i].Location = new Point(10 + 40 * (i % 5), 200 + 70 * (i / 5));
                PBs[i].Size = new Size(30, 50);
            }
        }
        Network[] NN = new Network[10];
        int n = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                NN[i] = new Network(ImageSerializer.ImageToArray((n).ToString() + ".bmp"), Convert.ToInt32(textBox1.Text));
            }
            Network.ReadAll("w.txt", NN);
            double maxRes = -100500;
            int maxIndex = -15000;
            for (int i = 0; i < 10; i++)
            {
                double tmp = NN[i].GetResult();
                if(tmp > maxRes)
                {
                    maxRes = tmp;
                    maxIndex = i;
                }
            }
            pictureBox1.Load("Numbers\\" + n.ToString() + ".bmp");
            label1.Text = maxIndex.ToString();
            n++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            NN.Teach(false);
            pictureBox2.Load("228.bmp");
            NN.SaveToFile("w.txt");*/
            pictureBox2.Load("FiveImage.bmp");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //NN.Teach(true);
            //pictureBox2.Load("228.bmp");
            //NN.SaveToFile("w.txt");
            pictureBox2.Load("FiveImage.bmp");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int j = 0; j < 5; j++)
                for (int i = 1; i <= 202; i++)
                {
                    Network.ReadAll("w.txt", NN);
                    for (int x = 0; x < 10; x++)
                    {
                        NN[x].SetDataAndLimit(ImageSerializer.ImageToArray(i.ToString() + ".bmp"), Convert.ToInt32(textBox1.Text));
                        
                        //if (isThis[x, i] != NN[x].Resolve())
                            NN[x].Teach(isThis[x, i]);
                        pictureBox2.Image = null;
                    }
                    Network.SaveAll("w.txt", NN);
                    //pictureBox2.Load("FiveImage.bmp");
                }
            for (int x = 0; x < 10; x++)
            {
                ImageSerializer.DrawFive(NN[x].Neurons, x.ToString());
                PBs[x].Load(x.ToString() + ".bmp");
            }
        }
    }
}
