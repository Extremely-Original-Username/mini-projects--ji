using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.Interfaces
{
    public interface IGridStateGenerator
    {
        public int[,] Generate(int width, int height);
    }
}
