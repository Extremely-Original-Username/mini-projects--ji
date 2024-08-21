﻿using Model.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Model.Geometry;
using System.Text;
using System.Threading.Tasks;
using Model.Config;



namespace Model.Genetics.Parts.Base
{
    public class PartDef
    {
        public string Name { get; }
        public string Description { get; }
        public float MetabolicLoad { get; }
        public Vector2<int> Size { get; }
        public Action<Part, Critter> PresentEffect { get; }
        public Action<Part, Critter> UpdateEffect { get; }

        public PartDef(string name, string description, float metabolicLoad, Action<Part, Critter> presentEffect, Action<Part, Critter> updateEffect)
        {
            Name = name;
            Description = description;
            MetabolicLoad = metabolicLoad;
            PresentEffect = presentEffect;
            UpdateEffect = updateEffect;
        }

        public static readonly Dictionary<char, PartDef> PartList = new Dictionary<char, PartDef>
        {
            { '0', null },

            { 'B', new PartDef(
                "Body",
                "Stores energy",
                1,
                (p, c) => { c.maxEnergy += p.Size.X * p.Size.Y; },
                (p, c) => { return; }
                )},

            { 'P', new PartDef(
                "Photosynthesis",
                "Generates energy in bright areas",
                0.5f,
                (p, c) => { return; },
                (p, c) => {
                    c.energy += c.World.lightMap[
                        Math.Clamp(c.Position.X, 0, c.World.lightMap.GetLength(0) - 1),
                        Math.Clamp(c.Position.Y, 0, c.World.lightMap.GetLength(1) - 1)] * p.Size.X * p.Size.Y;
                }
                )},
        };

        public static Vector2<double> GetPartPosition(int position, int of)
        {
            double angle = 2 * Math.PI * position / of;

            return new Vector2<double>(Math.Cos(angle), Math.Sin(angle));
        }
    }
}
