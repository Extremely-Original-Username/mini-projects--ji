using Godot;
using System;
using System.Drawing;
using UrbDevSim.Base;

namespace UrbDevSim.NodeScripts
{
	public partial class LandNode : Sprite2D
	{
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			Settlement settlement = new Settlement();
			settlement.Land.LandImage.Save("temp.png");
			GD.Print(settlement.Land.TEMP);

			this.Texture = ImageTexture.CreateFromImage(Godot.Image.LoadFromFile("temp.png"));
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			
		}
	}
}
