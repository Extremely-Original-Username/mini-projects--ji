using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ComputeSharp;

namespace AutomataVideoGenerator.Automatons.Standard
{
    public abstract class BaseGpuAutomaton : iAutomaton
    {
        protected ReadWriteTexture2D<int> texture;

        public BaseGpuAutomaton(int width, int height)
        {
            texture = GraphicsDevice.GetDefault().AllocateReadWriteTexture2D<int>(width, height);
        }

        public Bitmap getImage()
        {
            return getImage(1);
        }

        public Bitmap getImage(int scale)
        {
            int[,] textureArray = texture.ToArray();
            Bitmap bitmap = new Bitmap(texture.Width, texture.Height);

            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    var pixel = textureArray[x, y];
                    if (pixel == 1)
                    {
                        bitmap.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return resizeImage(bitmap, bitmap.Width * scale, bitmap.Height * scale);
        }

        private static Bitmap resizeImage(Bitmap image, int newWidth, int newHeight)
        {
            Bitmap result = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor; // Disable anti-aliasing
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return result;
        }

        public abstract void update();

        public void run(int cycles, string savePath)
        {
            Directory.CreateDirectory(savePath);

            for (int i = 0; i < cycles; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Processing: " + i + "                  ");
                getImage(1).Save(savePath + "/" + i + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                update();
            }
        }
    }
}
