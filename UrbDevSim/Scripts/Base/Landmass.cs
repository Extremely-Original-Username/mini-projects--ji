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

		public Bitmap LandImage;
		public string TEMP = "";

		public Landmass(int width, int height, int resolution)
		{
			LandImage = new Bitmap(width * resolution, height * resolution);

			var noise = new Billow();
			Random rand = new Random();

			noise.Seed = rand.Next();
			noise.Persistence = 0.75;
			noise.Frequency = 1.5;
			noise.OctaveCount = 4;


			//noise.Seed = seed;



			for (int y = 0; y < LandImage.Height; y++)
			{
				for (int x = 0; x < LandImage.Width; x++)
				{
					double rawValue = noise.GetValue(x, y, rand.NextDouble());

					int value = Math.Abs(Convert.ToInt32(((rawValue + 1) / 2 * 255))) % 255;

					if (x == 0)
					{
						TEMP += rawValue.ToString() + ",   ";
					}

					LandImage.SetPixel(x, y, Color.FromArgb(255, value, value, value));
				}
			}
		}
	}
}
