using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace EvoSim.Library.Geometry
{
    public class Transform
    {
        private const int defaultSize = 10;

        public Vector2Int Position { get; set; }
        public Vector2Int Size { get; set; }

        public Transform()
        {
            Position = new Vector2Int(0, 0);
            Size = new Vector2Int(defaultSize, defaultSize);
        }

        public Transform(Vector2Int position, Vector2Int size)
        {
            Position = position;
            Size = size;
        }
    }
}
