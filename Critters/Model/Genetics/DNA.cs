using Model.Config;
using Model.Genetics.Parts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Model.Genetics
{
    public class DNA
    {
        public string Code { get; protected set; }
        private int MaxChildren { get; }

        public DNA()
        {
            MaxChildren = GlobalConfig.maxChildParts;
            Code = getNewEmptyGene('B');
        }
        public DNA(int maxChildren)
        {
            MaxChildren = maxChildren;
            Code = getNewEmptyGene('B');
        }

        public void GenerativeEvolve()
        {

        }

        public void DegenerativeEvolve()
        {

        }

        //Replace empty gene
        protected void addGene(int location, Char gene)
        {
            if (Code[location] != PartDef.EmptyGeneChar) throw new InvalidDataException("Gene must be empty");

            Code = Code.Remove(location, 1).Insert(location, getNewEmptyGene(gene));
        }

        //Remove a gene with no children
        protected void removeGene(int location)
        {
            if (Code.Substring(location, 3 + MaxChildren) != getNewEmptyGene(Code[location]))
                throw new InvalidDataException("Gene must not be empty and have no children to be removed");

            Code = Code.Remove(location, 3 + MaxChildren);
            Code = Code.Insert(location, PartDef.EmptyGeneChar.ToString());
        }

        //Change an existing gene
        protected void swapGene(int location, Char newGene)
        {
            if (Code[location] == PartDef.EmptyGeneChar || "()".Contains(Code[location]))
                throw new InvalidDataException("Invalid gene to swap");

            Code = Code.Remove(location, 1).Insert(location, newGene.ToString());
        }

        protected string getNewEmptyGene(char defId)
        {
            string result = defId + "(";
            for (int i = 0; i < MaxChildren; i++)
            {
                result += PartDef.EmptyGeneChar;
            }
            result += ")";

            return result;
        }
    }
}
