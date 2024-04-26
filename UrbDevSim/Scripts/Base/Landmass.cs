using System;
using System.Collections.Generic;
using System.Drawing;
using noise;
using noise.module;

namespace UrbDevSim.Base
{
	public class Landmass
	{
		private const int maxImageSize = 16000;

		private const int scale = 4;
		private const int noisePrecision = 5;

		//0.25-1
		private const float sharpness = 0.1f;
		//Factor of 10
		private const int gritReduction = 100000;

		public Bitmap LandImage;

		public string TEMP = "";

		public Landmass(int width, int height, int resolution)
		{
			LandImage = new Bitmap(width * resolution, height * resolution);

			var noise = new Perlin();
			Random rand = new Random();

			//noise.Seed = rand.Next();
			noise.Persistence = sharpness;
			noise.Frequency = scale;

			//noise.Seed = seed;



			for (int y = 0; y < LandImage.Height; y++)
			{
				for (int x = 0; x < LandImage.Width; x++)
				{
					double rawValue = Math.Clamp(Math.Round(noise.GetValue((double)x / LandImage.Width, (double)y / LandImage.Height, rand.NextDouble() / gritReduction), noisePrecision), -1, 1);

					int value = Convert.ToInt32(((double)(rawValue + 1) / 2 * 255));

					//Regular view
					//LandImage.SetPixel(x, y, Color.FromArgb(255, value, value, value));

					//View with height lines
					if (value % 10 > 2.5 && value % 10 < 4.5)
					{
						LandImage.SetPixel(x, y, Color.Black);
					}
					else
					{
						LandImage.SetPixel(x, y, Color.White);
					}
				}
			}
		}
	}
}
