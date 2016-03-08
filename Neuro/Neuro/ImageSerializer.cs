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
            Bitmap im = new Bitmap(@"C:\Numbers\" + filename);
            int[,] output = new int[im.Width, im.Height];
            for (int i = 0; i < im.Width; i++)
                for (int j = 0; j < im.Height; j++)
                    output[i, j] = (Math.Abs(255 - im.GetPixel(i, j).B) < 30 ? 1 : 0);
            return output;
        }
    }
}
