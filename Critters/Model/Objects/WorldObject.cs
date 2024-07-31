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
        public Vector2Int Position { get; }
        public Vector2Int Size { get; }

        protected WorldObject(World world, Vector2Int position, Vector2Int size)
        {
            World = world;
            Position = position;
            Size = size;
        }
    }
}
