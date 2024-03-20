using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AutomataVideoGenerator.Automatons
{
    public abstract class BaseAutomaton : iAutomaton
    {
        protected Bitmap bitmap;
        public BaseAutomaton(int width, int height)
        {
            bitmap = new Bitmap(width, height);
        }

        public Bitmap getImage()
        {
            return getImage(1);
        }

        public Bitmap getImage(int scale)
        {
            return resizeImage(bitmap, bitmap.Width * scale, bitmap.Height * scale);
        }

        private static Bitmap resizeImage(Bitmap image, int newWidth, int newHeight)
        {
            Bitmap result = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor; // Disable anti-aliasing
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return result;
        }

        public abstract void update();
    }
}
