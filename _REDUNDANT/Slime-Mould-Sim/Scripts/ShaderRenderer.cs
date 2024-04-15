using Godot;
using Godot.Collections;
using System;

public partial class ShaderRenderer : Node
{
	ComputeShaderManager manager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        var input1 = new float[] { 1, 3, 5, 7, 9 };
        var input2 = new float[] { 2, 4, 6, 8, 10 };
        var input3 = new float[] { 0, 0, 0, 0, 0 };

        manager = new ComputeShaderManager("res://Components/Slime-Mould/Slime-Mould-1.0/Compute-Shader.glsl")
            .with1DInputData(input1, sizeof(float))
            .with1DInputData(input2, sizeof(float))
            .with1DInputData(input3, sizeof(float))
            .generatePipeline();

		manager.run();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
