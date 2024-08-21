using Model.Config;
using Model.Genetics.Parts.Base;
using Model.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Genetics.Parts
{
    public class Part
    {
        public PartDef Definition { get; }
        public Part[] Children { get; }
        public Vector2<int> Size = new Vector2<int>(GlobalConfig.baseAgentSize, GlobalConfig.baseAgentSize);

        public Part(PartDef definition)
        {
            this.Definition = definition;
            this.Children = new Part[GlobalConfig.maxChildParts];
        }
    }
}
