using ComputeSharp.Resources;
using ComputeSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraFX.Interop.Windows;

namespace AutomataVideoGenerator.Automatons.Standard
{
    public partial class BoostedBugs : BaseGpuAutomaton
    {
        private int width;
        private int height;

        private int live = 1;
        private int dead = 0;

        public BoostedBugs(int width, int height) : base(width, height)
        {
            int[,] startingMap = new int[width,height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    startingMap[x, y] = new Random().Next() % 2;
                    //startingMap[x, y] = 1;
                }
            }

            var initial = GraphicsDevice.GetDefault().AllocateReadWriteTexture2D<int>(startingMap);

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new 
                Set(texture, initial));
        }

        public override void update()
        {
            ReadWriteTexture2D<int> neighborGrid = GraphicsDevice.GetDefault().AllocateReadWriteTexture2D<int>(texture.Width, texture.Height);

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new
                NeighborCount(neighborGrid, texture, live, dead));

            //var arr = neighborGrid.ToArray();
            //for (int y = 0; y < neighborGrid.Height; y++)
            //{
            //    for (int x = 0; x < neighborGrid.Width; x++)
            //    {
            //        Console.WriteLine(x + ", " + y + ":  " + arr[x, y]);
            //    }
            //}
            //Thread.Sleep(10000);

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new 
                Step(texture, neighborGrid, live, dead));
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

        [AutoConstructor]
        public readonly partial struct NeighborCount : IComputeShader
        {
            public readonly ReadWriteTexture2D<int> buffer;
            public readonly ReadWriteTexture2D<int> neighborhood;
            public readonly int live;
            public readonly int dead;

            public void Execute()
            {
                int X = ThreadIds.X;
                int Y = ThreadIds.Y;

                int total = 0;
                for ( //For Y that is not out of bounds
                    int y = Hlsl.Max(0, Y - 5); 
                    y <= Hlsl.Min(neighborhood.Height - 1, Y + 5); 
                    y++)
                {
                    for ( //For X that is not out of bounds
                        int x = Hlsl.Max(0, X - 5);
                        x <= Hlsl.Min(neighborhood.Width - 1, X + 5);
                        x++)
                    {
                        if (
                            (x != X || y != Y) && //If not the current cell
                            neighborhood[X, Y] == 1 //And cell is alive
                            )
                        {
                            total++;
                        }
                    }
                }

                buffer[ThreadIds.XY] = total;
            }
        }

        [AutoConstructor]
        public readonly partial struct Step : IComputeShader
        {
            public readonly ReadWriteTexture2D<int> buffer;
            public readonly ReadWriteTexture2D<int> neighborCount;
            public readonly int live;
            public readonly int dead;

            public void Execute()
            {
                int neighbors = neighborCount[ThreadIds.XY];

                //if (neighbors >= 0 && neighbors <= 33)
                //{
                //    buffer[ThreadIds.XY] = dead;
                //}
                //if (neighbors >= 34 && neighbors <= 45)
                //{
                //    buffer[ThreadIds.XY] = live;
                //}
                //if (neighbors >= 58 && neighbors <= 121)
                //{
                //    buffer[ThreadIds.XY] = dead;
                //}

                if (buffer[ThreadIds.XY] == dead)
                {
                    buffer[ThreadIds.XY] = live;
                }
                else if (buffer[ThreadIds.XY] == live)
                {
                    buffer[ThreadIds.XY] = dead;
                }
            }
        }
    }
}
