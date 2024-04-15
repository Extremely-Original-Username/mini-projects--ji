using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractals
{
    public abstract class Fractal
    {
        protected Bitmap fractalImage;

        protected Fractal(int width, int height)
        {
            fractalImage = new Bitmap(width, height);
        }

        public Bitmap getImage()
        {
            return fractalImage;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
