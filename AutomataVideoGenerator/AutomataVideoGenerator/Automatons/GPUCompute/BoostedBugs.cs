﻿using ComputeSharp.Resources;
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
            int seed = DateTime.Now.GetHashCode();

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new 
                Randomise(texture, seed, live, dead));
        }

        public override void update()
        {
            ReadWriteTexture2D<int> neighborGrid = GraphicsDevice.GetDefault().AllocateReadWriteTexture2D<int>(texture.Width, texture.Height);

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new
                NeighborCount(neighborGrid, texture, live, dead));

            var arr = neighborGrid.ToArray();
            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    Console.WriteLine(x + ", " + y + ":  " + arr[x, y]);
                }
            }

            Thread.Sleep(10000);


            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new 
                Step(texture, neighborGrid, live, dead));
        }

        [AutoConstructor]
        public readonly partial struct Randomise : IComputeShader
        {
            public readonly ReadWriteTexture2D<int> buffer;
            public readonly int seed;
            public readonly int live;
            public readonly int dead;

            public void Execute()
            {
                buffer[ThreadIds.XY] = (ThreadIds.X + (seed % ThreadIds.Y) + ThreadIds.Y + (seed % ThreadIds.X)) % 2 == 0 ? live : dead;
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
                for (
                    int y = Math.Max(Y - 5, 0);
                    y <= Math.Min(Y + 5, neighborhood.Height - 1);
                    y++
                    )
                {
                    for (
                        int x = Math.Max(X - 5, 0);
                        x <= Math.Min(X + 5, neighborhood.Width - 1);
                        x++
                        )
                    {
                        if (neighborhood[ThreadIds.XY] == live)
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

                if (neighbors >= 0 && neighbors <= 33)
                {
                    buffer[ThreadIds.XY] = dead;
                }
                if (neighbors >= 34 && neighbors <= 45)
                {
                    buffer[ThreadIds.XY] = live;
                }
                if (neighbors >= 58 && neighbors <= 121)
                {
                    buffer[ThreadIds.XY] = dead;
                }
            }
        }
    }
}