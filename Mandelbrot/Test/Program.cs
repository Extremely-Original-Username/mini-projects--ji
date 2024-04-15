using Mandelbrot;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mandelbrot.Mandelbrot mandelbrot = new Mandelbrot.Mandelbrot(2000, 100);

            mandelbrot.getImage().Save("temp.bmp");
        }
    }
}
