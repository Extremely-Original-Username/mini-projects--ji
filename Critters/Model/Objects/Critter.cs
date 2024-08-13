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
        public bool Dead { get; private set; } = false;

        private readonly float maxEnergy;
        private float energy;
        private float metabolicRate;

        public Critter(World world, Vector2<int> position, Vector2<int> size, Vector2<float> facingAngle) : base(world, position, size, facingAngle)
        {
            float sizeScalar = size.X * size.Y;
            maxEnergy = sizeScalar;
            metabolicRate = (float)Math.Pow(sizeScalar, 0.75f) / 100; //Divisor of 10 = 30 frame starvation for 100 maxEnergy, 100 = 300 - TODO make parameter

            energy = maxEnergy / 2 + (new Random().Next(40) - 20); //Make these parameters too
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Dead) return;

            metabolise();
            if (energy > maxEnergy * 0.7) tryReproduce();
            else if (energy <= 0) die();

            Move();
            Rotate();
        }

        private void metabolise()
        {
            energy -= metabolicRate;
        }

        private void tryReproduce()
        {

        }

        private void die()
        {
            this.Dead = true;
        }

        private void Move()
        {
            Random r = new Random();
            float cX = FacingAngle.X;
            float cY = FacingAngle.Y;

            int dX = r.NextSingle() < Math.Abs(cX) ? (int)Math.Clamp(cX * 1000, -1, 1) : 0;
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
