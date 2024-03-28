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
        private Color liveColor;
        private Color deadColor;
        public BoostedBugs(int width, int height, Color? liveColor = null, Color? deadColor = null) : base(width, height)
        {
            if (liveColor != null)
            {
                this.liveColor = (Color)liveColor;
            }
            else
            {
                this.liveColor = Color.White;
            }
            if (deadColor != null)
            {
                this.deadColor = (Color)deadColor;
            }
            else
            {
                this.deadColor = Color.Black;
            }

            int seed = DateTime.Now.GetHashCode();

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new 
                Randomise(texture, seed, colorToFloat4(this.liveColor), colorToFloat4(this.deadColor)));
        }

        public override void update()
        {
            ReadWriteTexture2D<int> neighborGrid = GraphicsDevice.GetDefault().AllocateReadWriteTexture2D<int>(texture.Width, texture.Height);

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new
                NeighborCount(neighborGrid, texture, colorToFloat4(liveColor), colorToFloat4(deadColor)));

            GraphicsDevice.GetDefault().For(texture.Width, texture.Height, new 
                Step(texture, neighborGrid, colorToFloat4(liveColor), colorToFloat4(deadColor)));
        }

        [AutoConstructor]
        public readonly partial struct Randomise : IComputeShader
        {
            public readonly ReadWriteTexture2D<Bgra32, Float4> buffer;
            public readonly int seed;
            public readonly float4 liveColor;
            public readonly float4 deadColor;

            public void Execute()
            {
                buffer[ThreadIds.XY] = (ThreadIds.X + (seed % ThreadIds.Y) + ThreadIds.Y + (seed % ThreadIds.X)) % 2 == 0 ? liveColor : deadColor;
            }
        }

        [AutoConstructor]
        public readonly partial struct NeighborCount : IComputeShader
        {
            public readonly ReadWriteTexture2D<int> buffer;
            public readonly ReadWriteTexture2D<Bgra32, Float4> neighborhood;
            public readonly float4 liveColor;
            public readonly float4 deadColor;

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
                        Float4 current = neighborhood[ThreadIds.XY].BGRA;
                        Float4 live = liveColor.BGRA;
                        //if (neighborhood[ThreadIds.XY].BGRA.Equals(liveColor))
                        if (
                            current.W == live.W &&
                            current.X == live.X &&
                            current.Y == live.Y && 
                            current.Z == live.Z
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
            public readonly ReadWriteTexture2D<Bgra32, Float4> buffer;
            public readonly ReadWriteTexture2D<int> neighborCount;
            public readonly float4 liveColor;
            public readonly float4 deadColor;

            public void Execute()
            {
                int neighbors = neighborCount[ThreadIds.XY];

                if (neighbors >= 0 && neighbors <= 33)
                {
                    buffer[ThreadIds.XY] = deadColor;
                }
                if (neighbors >= 34 && neighbors <= 45)
                {
                    buffer[ThreadIds.XY] = liveColor;
                }
                if (neighbors >= 58 && neighbors <= 121)
                {
                    buffer[ThreadIds.XY] = deadColor;
                }
            }
        }
    }
}
