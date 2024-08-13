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
            base.OnUpdate();
            Move();
            Rotate();
        }

        private void Move()
        {
            Random r = new Random();
            float cX = FacingAngle.X;
            float cY = FacingAngle.Y;

            int dX = r.NextSingle() < Math.Abs(cX)? (int)Math.Clamp(cX * 1000, -1, 1) : 0;
            int dY = r.NextSingle() < Math.Abs(cY) ? (int)Math.Clamp(cY * 1000, -1, 1) : 0;

            Translate(dX, dY);
        }

        private void Rotate()
        {
            Random r = new Random();
            FacingAngle.X += ((r.Next() % 3) - 1) / 1.5f;
            FacingAngle.Y += ((r.Next() % 3) - 1) / 1.5f;
            FacingAngle.normalise();
        }
    }
}
