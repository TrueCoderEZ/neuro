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
        private void button1_Click(object sender, EventArgs e)
        {
            NN = new Network(ImageSerializer.ImageToArray("30.bmp"), 10);
            pictureBox1.Load(@"C:\Numbers\30.bmp");
            //NN.SaveToFile("w.txt");
            NN.ReadFromFile("w.txt");
            label1.Text = (NN.Resolve() ? "5" : "!5");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NN?.Teach(false);
            NN?.SaveToFile("w.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NN?.Teach(true);
            NN?.SaveToFile("w.txt");
        }
    }
}
