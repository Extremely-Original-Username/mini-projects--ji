using ComputeSharp.Resources;
using ComputeSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraFX.Interop.Windows;
using AutomataVideoGenerator.Automatons.GPUCompute;

namespace AutomataVideoGenerator.Automatons.Redundant.GPUCompute
{
    public partial class BoostedGameOfLife : BaseGpuAutomaton
    {
        private int live = 1;
        private int dead = 0;

        public BoostedGameOfLife(int width, int height) : base(width, height)
        {
            setRandom();
        }

        public override void update()
        {
            ReadWriteTexture2D<int> neighborGrid = GraphicsDevice.GetDefault().AllocateReadWriteTexture2D<int>(texture.Width, texture.Height);

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new
                NeighborCount(neighborGrid, texture, live, dead));

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new 
                Step(texture, neighborGrid, live, dead));
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
                    int y = Hlsl.Max(0, Y - 1); 
                    y <= Hlsl.Min(neighborhood.Height - 1, Y + 1); 
                    y++)
                {
                    for ( //For X that is not out of bounds
                        int x = Hlsl.Max(0, X - 1);
                        x <= Hlsl.Min(neighborhood.Width - 1, X + 1);
                        x++)
                    {
                        if (
                            (x != X || y != Y) && //If not the current cell
                            neighborhood[x, y] == live //And cell is alive
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

                if (buffer[ThreadIds.XY] == live)
                {
                    if (neighbors < 2)
                    {
                        buffer[ThreadIds.XY] = dead;
                    }
                    if (neighbors > 3)
                    {
                        buffer[ThreadIds.XY] = dead;
                    }
                }
                else
                {
                    if (neighbors == 3)
                    {
                        buffer[ThreadIds.XY] = live;
                    }
                }
            }
        }
    }
}
