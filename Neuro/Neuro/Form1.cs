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
        public Form1()
        {
            InitializeComponent();
        }
        Network NN;
        int n = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            int[] fives = { 1, 2, 3, 4, 5, 26, 27, 28, 29, 30, 31, 32, 33, 34, 42, 47, 59 };
            NN = new Network(ImageSerializer.ImageToArray((n).ToString() + ".bmp"), Convert.ToInt32(textBox1.Text));
            pictureBox1.Load("Numbers\\" + n.ToString() + ".bmp");
            NN.ReadFromFile("w.txt");
            label1.Text = ((NN.Resolve() ? "5" : "!5"));
            n++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NN.Teach(false);
            pictureBox2.Load("228.bmp");
            NN.SaveToFile("w.txt");
            pictureBox2.Load("FiveImage.bmp");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NN.Teach(true);
            pictureBox2.Load("228.bmp");
            NN.SaveToFile("w.txt");
            pictureBox2.Load("FiveImage.bmp");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] fives = { 1, 2, 3, 4, 5, 26, 27, 28, 29, 30, 31, 32, 33, 34, 42, 47, 59 };
            for (int j = 0; j < 1; j++)
                for (int i = 1; i <= 63; i++)
                {
                    bool isFive;
                    isFive = fives.Contains<int>(i);
                    NN = new Network(ImageSerializer.ImageToArray(i.ToString() + ".bmp"), Convert.ToInt32(textBox1.Text));
                    //pictureBox1.Load("Numbers\\" + n.ToString() + ".bmp");
                    NN.ReadFromFile("w.txt");
                    if(isFive != NN.Resolve())
                        NN.Teach(isFive);
                    pictureBox2.Image = null;
                    NN.SaveToFile("w.txt");
                    pictureBox2.Load("FiveImage.bmp");
                }
        }
    }
}
