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
        protected ReadWriteTexture2D<Bgra32, Float4> texture;

        public BaseGpuAutomaton(int width, int height)
        {
            texture = GraphicsDevice.GetDefault().AllocateReadWriteTexture2D<Bgra32, Float4>(width, height);
        }

        public Bitmap getImage()
        {
            return getImage(1);
        }

        public Bitmap getImage(int scale)
        {
            Bgra32[,] textureArray = texture.ToArray();
            Bitmap bitmap = new Bitmap(texture.Width, texture.Height);

            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    var pixel = textureArray[x, y];
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
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

        protected Bgra32 colorToBGRA(Color color)
        {
            Bgra32 result = new Bgra32();
            result.B = color.B;
            result.G = color.G;
            result.R = color.R;
            result.A = color.A;

            return result;
        }

        protected Float4 colorToFloat4(Color color)
        {
            Float4 result = new Float4();
            result.X = color.B;
            result.Y = color.G;
            result.Z = color.R;
            result.W = color.A;

            return result;
        }
    }
}
