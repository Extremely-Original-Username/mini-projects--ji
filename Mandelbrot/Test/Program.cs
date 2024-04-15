using Fractals;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mandelbrot mandelbrot = new Mandelbrot(2000, 100);

            mandelbrot.getImage().Save("temp.bmp");
        }
    }
}
