using Godot;
using Godot.Collections;
using System;

public partial class ShaderRenderer : Node
{
	ComputeShaderManager manager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		manager = new ComputeShaderManager("res://Components/Slime-Mould/Slime-Mould-1.0/Compute-Shader.glsl");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
