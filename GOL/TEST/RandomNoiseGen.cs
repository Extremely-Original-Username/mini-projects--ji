using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Interfaces;

namespace TEST
{
    public class RandomNoiseGen : IGridStateGenerator
    {
        public int[,] Generate(int width, int height)
        {
            int[,] result = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    result[i, j] = new Random().Next() % 2;
                }
            }

            return result;
        }
    }
}
