using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Config
{
    public static class GlobalConfig
    {
        //Arena settings
        public const int baseAgentCount = 100;  //Starting number of agents
        public const int arenaWidth = 800;      //Size of arena in pixels
        public const int arenaHeight = 800;

        public const int lightNoiseScale = 300;         //Scales of the perlin noise
        public const int shadowNoiseScale = 400;
        public const float shadowEffectScale = 1.6f;    //Multiplier on shadow perlin map subtraction

        //Agent settings
        public const int baseAgentSize = 10;    //Default size of agents in pixels

        //Critter settings
        public const int maxChildParts = 6; //Number of parts per part, including base
        public const int partOffset = 15; //Pixel offset of parts
    }
}
