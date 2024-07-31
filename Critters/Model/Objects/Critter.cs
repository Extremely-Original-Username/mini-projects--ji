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
        public Critter(World world, Vector2Int position, Vector2Int size) : base(world, position, size)
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
