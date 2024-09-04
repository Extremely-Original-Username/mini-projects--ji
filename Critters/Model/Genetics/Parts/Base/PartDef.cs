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
        public char Id { get; }
        public string Name { get; }
        public string Description { get; }
        public float MetabolicLoad { get; }
        public Vector2<int> Size { get; }
        public Action<Part, Critter> PresentEffect { get; }
        public Action<Part, Critter> UpdateEffect { get; }

        public PartDef(char id, string name, string description, float metabolicLoad, Action<Part, Critter> presentEffect, Action<Part, Critter> updateEffect)
        {
            Id = id;
            Name = name;
            Description = description;
            MetabolicLoad = metabolicLoad;
            PresentEffect = presentEffect;
            UpdateEffect = updateEffect;
        }

        public static char GetRandomGene()
        {
            var result = PartList.Keys.Where(x => x != EmptyGeneChar).ToList()[new Random().Next(PartList.Count - 1)];
            if (result == '0')
            {
                var test = true;
            }
            return result;
        }

        public const char EmptyGeneChar = '0';
        public static readonly Dictionary<char, PartDef> PartList = new Dictionary<char, PartDef>
        {
            { '0', null },

            { 'B', new PartDef(
                'B',
                "Body",
                "Stores energy",
                0.75f,
                (p, c) => { c.maxEnergy += 1 * p.Size.X * p.Size.Y; c.partEfficiency += 0.1f; },
                (p, c) => { return; }
                )},

            { 'P', new PartDef(
                'P',
                "Photosynthesis",
                "Generates energy in bright areas",
                0.5f,
                (p, c) => { return; },
                (p, c) => {
                    c.energy += c.getEnergy(c.World.LightMap.getLightLevelAt(c.Position.X, c.Position.Y) * p.Size.X * p.Size.Y * c.partEfficiency);
                }
                )},
            { 'M', new PartDef(
                'M',
                "Move",
                "Moves the critter",
                1f,
                (p, c) => { return; },
                (p, c) => { return; }
                )},
            { 'R', new PartDef(
                'R',
                "Rotate",
                "Rotates the critter",
                0.4f,
                (p, c) => { return; },
                (p, c) => { return; }
                )},
            { 'F', new PartDef(
                'F',
                "Flagella",
                "Randomly moves the critter",
                0.6f,
                (p, c) => { return; },
                (p, c) => { c.Move(c.r.Next(3) - 1, c.r.Next(3) - 1); }
                )},
        };

        //Gets normal vector of part position based total potential children and an offset
        public static Vector2<double> GetRelativePartPosition(int position, int of, float offsetAngle = 0)
        {
            double angle = (2 * Math.PI * position / of) + offsetAngle;

            return new Vector2<double>(Math.Cos(angle), Math.Sin(angle));
        }
    }
}
