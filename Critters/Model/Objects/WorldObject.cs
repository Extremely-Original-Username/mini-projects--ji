using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Geometry;

namespace Model.Objects
{
    public abstract class WorldObject
    {
        protected World World { get; }
        public Vector2<int> Position { get; }
        public Vector2<int> Size { get; }
        public Vector2<float> FacingAngle { get; }

        protected WorldObject(World world, Vector2<int> position, Vector2<int> size, Vector2<float> facingAngle)
        {
            World = world;
            Position = position;
            Size = size;
            FacingAngle = facingAngle;
        }
    }
}
