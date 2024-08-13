using Model.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
    public class Critter : Agent
    {
        public Critter(World world, Vector2<int> position, Vector2<int> size, Vector2<float> facingAngle) : base(world, position, size, facingAngle)
        {

        }

        public override void OnUpdate()
        {
            Move();
        }

        private void Move()
        {
            Random r = new Random();
            int dX = r.Next() % 3 - 1;
            int dY = r.Next() % 3 - 1;

            Translate(dX, dY);
        }
    }
}
