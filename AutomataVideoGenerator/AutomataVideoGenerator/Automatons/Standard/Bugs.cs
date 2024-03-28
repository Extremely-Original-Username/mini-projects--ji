using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataVideoGenerator.Automatons.Standard
{
    public class Bugs : BaseAutomaton
    {
        private Color liveColor;
        private Color deadColor;
        public Bugs(int width, int height, Color? liveColor = null, Color? deadColor = null) : base(width, height)
        {
            if (liveColor != null)
            {
                this.liveColor = (Color)liveColor;
            }
            else
            {
                this.liveColor = Color.White;
            }
            if (deadColor != null)
            {
                this.deadColor = (Color)deadColor;
            }
            else
            {
                this.deadColor = Color.Black;
            }

            Color[] colors = new Color[2] { this.liveColor, this.deadColor };
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bitmap.SetPixel(x, y, colors[new Random().Next() % 2]);
                }
            }
        }

        public override void update()
        {
            Bitmap prevState = (Bitmap)bitmap.Clone();
            int width = prevState.Width;
            int height = prevState.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int neighbors = getNeighbors(x, y, prevState);

                    if (neighbors >= 0 && neighbors <= 33)
                    {
                        bitmap.SetPixel(x, y, deadColor);
                    }
                    if (neighbors >= 34 && neighbors <= 45)
                    {
                        bitmap.SetPixel(x, y, liveColor);
                    }
                    if (neighbors >= 58 && neighbors <= 121)
                    {
                        bitmap.SetPixel(x, y, deadColor);
                    }
                }
            }
        }

        private int getNeighbors(int X, int Y, Bitmap state)
        {
            int total = 0;
            for (
                int y = Math.Max(Y - 5, 0);
                y <= Math.Min(Y + 5, state.Height - 1);
                y++
                )
            {
                for (
                    int x = Math.Max(X - 5, 0);
                    x <= Math.Min(X + 5, state.Width - 1);
                    x++
                    )
                {
                    if ((x != X || y != Y) && state.GetPixel(x, y).ToArgb() == liveColor.ToArgb())
                    {
                        total++;
                    }
                }
            }
            return total;
        }
    }
}
