using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSim.Library.Geometry
{
    public class Vector2Int
    {
        public long X { get; set; }
        public long Y { get; set; }

        public Vector2Int(long x, long y)
        {
            X = x;
            Y = y;
        }
    }
}
