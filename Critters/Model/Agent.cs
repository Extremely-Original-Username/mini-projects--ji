using Model.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Agent : WorldObject
    {
        protected Agent(World world, Vector2Int position, Vector2Int size) : base(world, position, size)
        {

        }

        public abstract void OnUpdate();

        protected void Translate(int x, int y)
        {
            Position.X += x;
            Position.Y += y;

            if (Position.X > this.World.Width)
            {
                Position.X = Position.X % this.World.Width;
            }
            if (Position.Y > this.World.Height)
            {
                Position.Y = Position.Y % this.World.Height;
            }
            if (Position.X < 0)
            {
                Position.X = World.Width + Position.X;
            }
            if (Position.Y < 0)
            {
                Position.Y = World.Height + Position.Y;
            }
        }
    }
}
