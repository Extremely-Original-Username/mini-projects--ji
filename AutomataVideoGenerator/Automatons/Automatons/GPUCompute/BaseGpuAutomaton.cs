using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ComputeSharp;

namespace AutomataVideoGenerator.Automatons.GPUCompute
{
    public abstract partial class BaseGpuAutomaton : iAutomaton
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

        public void run(int cycles, string savePath, int scale)
        {
            Directory.CreateDirectory(savePath);

            for (int i = 0; i < cycles; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Processing: " + i + "                  ");
                getImage(scale).Save(savePath + "/" + i + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                update();
            }
        }
        public void run(int cycles, string savePath)
        {
            run(cycles, savePath, 1);
        }

        public void setRandom()
        {
            int width = texture.Width;
            int height = texture.Height;

            int[,] startingMap = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    startingMap[x, y] = new Random().Next() % 2;
                }
            }

            var initial = GraphicsDevice.GetDefault().AllocateReadWriteTexture2D<int>(startingMap);

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new
                Set(texture, initial));
        }

        [AutoConstructor]
        public readonly partial struct Set : IComputeShader
        {
            public readonly ReadWriteTexture2D<int> buffer;
            public readonly ReadWriteTexture2D<int> source;

            public void Execute()
            {
                buffer[ThreadIds.XY] = source[ThreadIds.XY];
            }
        }
    }
}
