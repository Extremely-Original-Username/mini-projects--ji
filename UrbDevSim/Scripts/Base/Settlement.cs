using System;

namespace UrbDevSim.Base
{
    public class Settlement
    {
        public Landmass Land;

        public Settlement()
        {
            Land = new Landmass(100, 100, 10);
        }
    }
}
