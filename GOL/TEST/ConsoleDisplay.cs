using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    public class ConsoleDisplay<T>
    {
        private int width;
        private int height;
        private Dictionary<T, char> map;

        public ConsoleDisplay(int width, int height, Dictionary<T, char> map)
        {
            this.width = width;
            this.height = height;
            this.map = map;

            Console.SetWindowSize(width * 2, height + 1);
        }

        public void printGrid(T[,] input)
        {
            Console.SetCursorPosition(0, 0);

            if (input.GetLength(0) != width || input.GetLength(1) != height)
            {
                throw new Exception("INVALID INPUT");
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    try
                    {
                        Console.Write(map[input[x, y]] + " ");
                    }
                    catch (Exception)
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
