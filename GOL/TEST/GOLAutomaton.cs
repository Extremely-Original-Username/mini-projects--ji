using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.Interfaces;

namespace TEST
{
    public class GOLAutomaton
    {
        int width;
        int height;
        public int[,] grid;
        int[,] prevState;

        public GOLAutomaton(int width, int height, IGridStateGenerator startGenerator)
        {
            grid = new int[width, height];
            this.width = width;
            this.height = height;

            grid = startGenerator.Generate(width, height);

            if (grid.GetLongLength(0) != width || grid.GetLongLength(1) != height)
            {
                throw new Exception("Error with grid size");
            }
        }

        public int[,] step()
        {
            prevState = (int[,])grid.Clone();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int neighbors = getNeighbors(x, y);

                    if (prevState[x, y] == 1)
                    {
                        if (neighbors < 2)
                        {
                            grid[x, y] = 0;
                        }
                        if (neighbors > 3)
                        {
                            grid[x, y] = 0;
                        }
                    }
                    if (prevState[x, y] == 0)
                    {
                        if (neighbors == 3)
                        {
                            grid[x, y] = 1;
                        }
                    }
                }
            }

            return grid;
        }

        private int getNeighbors(int X, int Y)
        {
            int total = 0;
            for (
                int y = Math.Max(Y - 1, 0); 
                y <= Math.Min(Y + 1, height - 1); 
                y++
                )
            {
                for (
                    int x = Math.Max(X - 1, 0); 
                    x <= Math.Min(X + 1, width - 1); 
                    x++
                    )
                {
                    if ((x != X || y != Y) && prevState[x, y] == 1)
                    {
                        total++;
                    }
                }
            }
            return total;
        }

        private int getNeighborsAlt(int X, int Y)
        {
            int total = 0;
            int x = X - 1;
            int y = Y - 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (x < 0)
                    {
                        x = width - 1;
                    }
                    if (y < 0)
                    {
                        y = height - 1;
                    }
                    if (x > width - 1)
                    {
                        x = 0;
                    }
                    if (y > height - 1)
                    {
                        y = 0;
                    }
                    if ((x != X || y != Y) && prevState[x, y] == 1)
                    {
                        total++;
                    }

                    x++;
                }
                x -= 3;
                y++;
            }
            return total;
        }
    }
}
