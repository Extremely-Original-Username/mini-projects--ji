using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Geometry;

namespace Model
{
    public abstract class WorldObject
    {
        protected World World {  get; }
        public Vector2Int Position { get; }
        public Vector2Int Size { get; }

        protected WorldObject(World world, Vector2Int position, Vector2Int size)
        {
            this.World = world;
            this.Position = position;
            Size = size;
        }
    }
}
