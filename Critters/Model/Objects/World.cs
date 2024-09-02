using Model.Config;
using Model.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibNoise;
using Model.Genetics;

namespace Model.Objects
{
    public class World
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public float[,] lightMap { get; set; }

        private List<Agent> Agents { get; set; } = new List<Agent>();

        public delegate void OnUpdateDelegate();
        public event OnUpdateDelegate OnUpdate;

        public delegate void OnAgentCreatedDelegate(Agent agent);
        public event OnAgentCreatedDelegate OnAgentCreated;
        public delegate void OnAgentRemovedDelegate(Agent agent);
        public event OnAgentRemovedDelegate OnAgentRemoved;

        public World(int width, int height)
        {
            Width = width;
            Height = height;

            GenerateLightMap();
        }

        public void Update()
        {
            if (OnUpdate != null)
            {
                OnUpdate();
            }

            for (int i = 0; i < Agents.Count; i++)
            {
                Agents[i].OnUpdate();
            }
        }

        public Agent[] getAgents() { return Agents.ToArray(); }

        public void addAgent(Agent agent)
        {
            Agents.Add(agent);

            if (OnAgentCreated != null)
            {
                OnAgentCreated(agent);
            }
        }

        public void RemoveAgent(Agent agent)
        {
            Agents.Remove(agent);

            if (OnAgentRemoved != null)
            {
                OnAgentRemoved(agent);
            }
        }

        private void GenerateLightMap()
        {
            lightMap = new float[Width, Height];

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

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var noiseVal = baseMap.GetValue(x / scale, y / scale, rand.NextSingle() / scale)
                        - reductionMap.GetValue(x / altScale, y / altScale, rand.NextSingle() / altScale) * GlobalConfig.shadowEffectScale;
                    noiseVal = Math.Clamp((noiseVal + 1f) / 2f, 0, 1);

                    lightMap[y, x] = noiseVal;
                }
            }
        }
    }
}
