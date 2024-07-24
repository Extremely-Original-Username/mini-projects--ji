using EvoSim.Library.Geometry;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSim.Library.Objects
{
    internal class Agent : GameObject
    {
        public Agent(Transform transform, Texture2D texture) : base(transform, texture)
        {
            
        }

        public void Jitter()
        {
            int jx = new Random().Next() % 3 - 1;
            int jy = new Random().Next() % 3 - 1;

            this.Transform.Position.X += jx;
            this.Transform.Position.Y += jy;
        }
    }
}
