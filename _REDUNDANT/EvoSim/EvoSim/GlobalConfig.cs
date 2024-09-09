using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSim
{
    public static class GlobalConfig
    {
        //Arena settings
        public const int baseAgentCount = 100;  //Starting number of agents
        public const int arenaWidth = 800;      //Size of arena in pixels
        public const int arenaHeight = 800;

        public const int lightNoiseScale = 300;         //Scales of the perlin noise
        public const int shadowNoiseScale = 400;
        public const float shadowEffectScale = 1.5f;    //Multiplier on shadow perlin map subtraction
        public const int baseLightR = 250;              //Color of light
        public const int baseLightG = 220;
        public const int baseLightB = 200;

        //Agent settings
        public const int baseAgentSize = 10;    //Default size of agents in pixels
    }
}
