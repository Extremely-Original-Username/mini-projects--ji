using Model.Config;
using Model.Genetics;
using Model.Genetics.Parts;
using Model.Genetics.Parts.Base;
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
        public float maxEnergy { get; set; }
        public float energy { get; set; }
        public float metabolicRate { get; set; }
        public float reproductionThreshold = 0.7f;

        public Part BasePart { get; }

        public Critter(World world, Vector2<int> position, Vector2<int> size, Vector2<float> facingAngle, DNA dna = null) : base(world, position, size, facingAngle)
        {
            if (dna == null) dna = new DNA();
            BasePart = ParseDNA(dna);

            DoActionForPartAndChildren(BasePart, x =>
            {
                x.Definition.PresentEffect.Invoke(x, this);
                this.metabolicRate += x.Definition.MetabolicLoad * (float)x.Size.X * (float)x.Size.Y;
            });
            //maxEnergy = 0;
            //metabolicRate = (float)Math.Pow(sizeScalar, 0.75f) / 100; //Divisor of 10 = 30 frame starvation for 100 maxEnergy, 100 = 300 - TODO make parameter

            energy = maxEnergy / 2 + (new Random().Next(40) - 20); //Make these parameters too
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Dead) return;
            //All critter bahviour below

            DoActionForPartAndChildren(BasePart, x => { x.Definition.UpdateEffect.Invoke(x, this); });
            metabolise();
            if (energy > maxEnergy * reproductionThreshold) tryReproduce();
            else if (energy <= 0) die();

            Move();
            Rotate();
        }

        private void metabolise()
        {
            if(energy > maxEnergy) energy = maxEnergy;

            energy -= metabolicRate / 100;
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

        private void DoActionForPartAndChildren(Part part, Action<Part> action)
        {
            action.Invoke(part);
            foreach (Part child in part.Children)
            {
                if (child != null)
                {
                    DoActionForPartAndChildren(child, action);
                }
            }
        }

        private Part ParseDNA(DNA dna)
        {
            Part result = generatePartFromDnaSegment(dna.Code);

            return result;
        }

        private Part generatePartFromDnaSegment(string segment)
        {
            if (!PartDef.PartList.ContainsKey(segment[0]) || segment[segment.Length - 1] != ')') throw new InvalidDataException("Invalid DNA segment");

            Part result = new Part(PartDef.PartList[segment[0]]);

            int currentIndex = segment.IndexOf("(") + 1;
            int currentChild = 0;
            while (currentChild < GlobalConfig.maxChildParts)
            {
                Part? current = new Part(PartDef.PartList[segment[currentIndex]]);
                if (current.Definition != null)
                {
                    int endindex = currentIndex;
                    int depth = -1;
                    while (endindex < segment.Length)
                    {
                        char currentCharacter = segment[endindex];

                        if (currentCharacter == ')' && depth == 0) break;
                        else if (currentCharacter == ')') depth -= 1;
                        if (currentCharacter == '(') depth += 1;
                        endindex += 1;
                    }
                    current = generatePartFromDnaSegment(segment.Substring(currentIndex, endindex - currentIndex + 1));
                    result.Children[currentChild] = current;
                    currentIndex = endindex;
                }
                currentIndex += 1;
                currentChild += 1;
            }

            return result;
        }
    }
}
