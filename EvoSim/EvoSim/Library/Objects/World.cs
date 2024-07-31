using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoSim.Library.Geometry;
using LibNoise;
using System.Drawing;
using LibNoise.Primitive;
using LibNoise.Builder;
using LibNoise.Renderer;
using System.IO;
using Microsoft.Xna.Framework;
using Color = LibNoise.Renderer.Color;

namespace EvoSim.Library.Objects
{
    public class World : GameObject
    {
        public World(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.Transform = new Transform(
                new Vector2Int(0, 0),
                new Vector2Int(GlobalConfig.arenaWidth, GlobalConfig.arenaHeight)
                );

            Texture = new Texture2D(graphicsDevice, Convert.ToInt32(this.Transform.Size.X), Convert.ToInt32(this.Transform.Size.Y));

            Microsoft.Xna.Framework.Color[] buffer = new Microsoft.Xna.Framework.Color[Texture.Width * Texture.Height];

            var rand = new Random();
            var baseMap = new LibNoise.Primitive.SimplexPerlin()
            {
                Seed = rand.Next(),
                Quality = NoiseQuality.Best
            };
            var reductionMap = new LibNoise.Primitive.SimplexPerlin()
            {
                Seed = rand.Next(),
                Quality = NoiseQuality.Fast
            };
            float scale = GlobalConfig.lightNoiseScale;
            float altScale = GlobalConfig.shadowNoiseScale;

            for (int y = 0; y < Texture.Height; y++)
            {
                for (int x = 0; x < Texture.Width; x++)
                {
                    var noiseVal = baseMap.GetValue((float)x / scale, (float)y / scale, rand.NextSingle() / scale)
                        - reductionMap.GetValue((float)x / altScale, (float)y / altScale, rand.NextSingle() / altScale) * GlobalConfig.shadowEffectScale;
                    noiseVal = Math.Clamp((noiseVal + 1f) / 2f, 0, 1);

                    buffer[x + (Texture.Width * y)] = new Microsoft.Xna.Framework.Color(
                        Convert.ToInt32(GlobalConfig.baseLightR * noiseVal),
                        Convert.ToInt32(GlobalConfig.baseLightG * noiseVal),
                        Convert.ToInt32(GlobalConfig.baseLightB * noiseVal),
                        1000);
                }
            }

            Texture.SetData(buffer);
        }
    }
}
