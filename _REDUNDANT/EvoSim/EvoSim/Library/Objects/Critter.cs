using EvoSim.Library.Geometry;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSim.Library.Objects
{
    public class Critter : Agent
    {
        public Critter(Transform transform, Texture2D texture) : base(transform, texture)
        {

        }

        public override void OnUpdate()
        {
            Move();
        }

        private void Move()
        {

        }
    }
}
