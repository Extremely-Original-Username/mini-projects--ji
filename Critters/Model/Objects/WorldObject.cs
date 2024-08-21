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
        public World World { get; }
        public Vector2<int> Position { get; }
        public Vector2<int> Size { get; }

        protected WorldObject(World world, Vector2<int> position, Vector2<int> size)
        {
            World = world;
            Position = position;
            Size = size;
        }
    }
}
