using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Neuro
{
    class ImageSerializer
    {
        public static int[,] ImageToArray(string filename)
        {
            Bitmap im = new Bitmap(@"Numbers\" + filename);
            int[,] output = new int[im.Width, im.Height];
            for (int i = 0; i < im.Width; i++)
                for (int j = 0; j < im.Height; j++)
                    output[i, j] = (Math.Abs(255 - im.GetPixel(i, j).B) < 30 ? 1 : 0);
            im.Dispose();
            return output;
        }

        public static void DrawFive(Neuron[] nn)
        {
            int min = 100000;
            int max = -100000;
            for(int i = 0; i < nn.Length; i++)
            {
                if (nn[i].Weight > max)
                    max = (int)nn[i].Weight;
                if (nn[i].Weight < min)
                    min = (int)nn[i].Weight;
            }
            Bitmap im = new Bitmap(30, 50);
            for(int i = 0; i < nn.Length; i++)
            {
                Color tmp = Color.FromArgb((byte)(((float)(nn[i].Weight - min) / (max - min)) * 255), (byte)(((float)(nn[i].Weight - min) / (max - min)) * 255), (byte)(((float)(nn[i].Weight - min) / (max - min)) * 255));
                im.SetPixel(i % 30, i / 30, tmp);
            }
            im.Save("FiveImage.bmp");
            im.Dispose();
        }
    }
}
