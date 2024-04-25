using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UrbDevSim.Base
{
    public class Landmass
    {
        private Bitmap LandImage;

        public Landmass(int width, int height, int resolution)
        {
            LandImage = new Bitmap(width * resolution, height * resolution);
        }
    }
}
