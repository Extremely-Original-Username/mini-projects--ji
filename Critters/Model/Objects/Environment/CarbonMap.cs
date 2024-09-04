using Model.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects.Environment
{
    public class CarbonMap
    {
        public float[,] Map { get; set; }
        
        public CarbonMap(int width, int height)
        {
            Map = new float[pixelToGridSquare(width), pixelToGridSquare(height)];

            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    Map[x, y] = GlobalConfig.baseCarbonLevel;
                }
            }
        }

        public float GetCarbonLevelAt(int x, int y)
        {
            validateXY(ref x, ref y);

            return Map[pixelToGridSquare(x), pixelToGridSquare(y)];
        }

        public float TryTakeCarbonAmountAt(int x, int y, float targetAmount)
        {
            validateXY(ref x, ref y);

            float startVal = Map[pixelToGridSquare(x), pixelToGridSquare(y)];

            Map[pixelToGridSquare(x), pixelToGridSquare(y)] -= targetAmount;
            if (Map[pixelToGridSquare(x), pixelToGridSquare(y)] < 0) Map[pixelToGridSquare(x), pixelToGridSquare(y)] = 0;

            return startVal - Map[pixelToGridSquare(x), pixelToGridSquare(y)];
        }

        public void Diffuse()
        {

        }

        private int pixelToGridSquare(int pixel)
        {
            return pixel / GlobalConfig.carbonGridSquareSize;
        }

        private void validateXY(ref int x, ref int y)
        {
            if (pixelToGridSquare(x) < 0 || pixelToGridSquare(x) > Map.GetLength(0) - 1)
            {
                DebugHelper.PrintWarning("CarbonMap", "X value is outwith acceptable range of 0-" + (Map.GetLength(0) - 1));
                x = Math.Clamp(x, 0, GlobalConfig.carbonGridSquareSize * Map.GetLength(1) - 1);
            }
            if (pixelToGridSquare(y) < 0 || pixelToGridSquare(y) > Map.GetLength(0) - 1)
            {
                DebugHelper.PrintWarning("CarbonMap", "Y value is outwith acceptable range of 0-" + (Map.GetLength(1) - 1));
                y = Math.Clamp(y, 0, GlobalConfig.carbonGridSquareSize * Map.GetLength(1) - 1);
            }
        }
    }
}
