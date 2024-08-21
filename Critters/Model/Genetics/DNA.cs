using Model.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Genetics
{
    public class DNA
    {
        public string Code { get; }

        public DNA()
        {
            Code = "B(";
            for (int i = 0; i < GlobalConfig.maxChildParts; i++)
            {
                if (i == 0 || i == 3)
                {
                    Code += "P(000000)";
                    continue;
                }
                Code += '0';
            }
            Code += ")";
        }
    }
}
