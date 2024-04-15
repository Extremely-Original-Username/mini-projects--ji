using ComputeSharp;
using System.Drawing;
using ComputeSharp;
using TerraFX.Interop.Windows;


namespace Mandelbrot
{
    public partial class Mandelbrot : Fractal
    {
        readonly int cutoff;

        public Mandelbrot(int resolution, int cutoff) : base(resolution, resolution)
        {
            this.cutoff = cutoff;

            Draw(-2.5f, 1.5f, -2, 2);
        }

        public void Draw(float left, float right, float bottom, float top)
        {
            ReadWriteTexture2D<Bgra32, float4> buffer = GraphicsDevice.GetDefault()
                .AllocateReadWriteTexture2D<Bgra32, float4>(fractalImage.Width, fractalImage.Height);

            GraphicsDevice.GetDefault().For(fractalImage.Width, fractalImage.Height, new
                DrawMandelBrot(buffer, left, right, bottom, top, cutoff, fractalImage.Width, fractalImage.Height));

            Bgra32[,] result = buffer.ToArray();

            for (int y = 0; y < fractalImage.Height; y++)
            {
                for (int x = 0; x < fractalImage.Width; x++)
                {
                    var current = result[y, x];
                    fractalImage.SetPixel(y, x, Color.FromArgb(current.A, current.R, current.G, current.B));
                }
            }
        }

        [AutoConstructor]
        public readonly partial struct DrawMandelBrot : IComputeShader
        {
            public readonly ReadWriteTexture2D<Bgra32, float4> targetBuffer;
            public readonly float left;
            public readonly float right;
            public readonly float bottom;
            public readonly float top;
            public readonly int cutoff;
            public readonly int resolutionX;
            public readonly int resolutionY;


            public void Execute()
            {
                int X = ThreadIds.X;
                int Y = ThreadIds.Y;

                // Calculate the complex number corresponding to the current pixel
                float xPos = left + (right - left) * X / resolutionX;
                float yPos = bottom + (top - bottom) * Y / resolutionY;
                float xCalc = 0;
                float yCalc = 0;
                int iteration = 0; // You can adjust this value as needed

                // Perform the Mandelbrot iteration
                while (xCalc * xCalc + yCalc * yCalc <= 4 && iteration < cutoff)
                {
                    float xTemp = xCalc * xCalc - yCalc * yCalc + xPos;
                    yCalc = 2 * xCalc * yCalc + yPos;
                    xCalc = xTemp;
                    iteration++;
                }

                // Set the color based on whether the point is in the Mandelbrot set or not
                if (iteration < cutoff)
                {
                    // Set the pixel to black if it belongs to the Mandelbrot set
                    targetBuffer[X, Y] = new float4(0, 0, 0, 255); // Black color
                }
                else
                {
                    // Set the pixel to white if it does not belong to the Mandelbrot set
                    targetBuffer[X, Y] = new float4(255, 255, 255, 255); // White color
                }
            }
        }


    }
}
