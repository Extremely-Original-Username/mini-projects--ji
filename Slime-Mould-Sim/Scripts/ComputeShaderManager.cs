using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public class ComputeShaderManager
{
	private RenderingDevice rd;
	private Rid shader;
	private List<inputDataSet> inputDataSets = new List<inputDataSet>();

	public ComputeShaderManager(string shaderPath)
	{
		rd = RenderingServer.CreateLocalRenderingDevice();

		//Load Shader
		RDShaderFile shaderFile = GD.Load<RDShaderFile>(shaderPath);
		RDShaderSpirV shaderBytecode = shaderFile.GetSpirV();
		shader = rd.ShaderCreateFromSpirV(shaderBytecode);
	}

	public ComputeShaderManager with1DInputData<T>(T[] input, Int32 TSize)
	{
        var inputBytes = new byte[input.Length * TSize];
        Buffer.BlockCopy(input, 0, inputBytes, 0, inputBytes.Length);

        // Create a storage buffer that can hold our float values.
        // Each float has 4 bytes (32 bit) so 10 x 4 = 40 bytes
        var buffer = rd.StorageBufferCreate((uint)inputBytes.Length, inputBytes);

        // Create a uniform to assign the buffer to the rendering device
        var uniform = new RDUniform
        {
            UniformType = RenderingDevice.UniformType.StorageBuffer,
            Binding = 0
        };
        uniform.AddId(buffer);
		inputDataSets.Add(new inputDataSet()
		{
			inputString = string.Join(", ", input),
			inputLength = input.Length,
			buffer = buffer,
			uniformSet = rd.UniformSetCreate(new Array<RDUniform> { uniform }, shader, 0)
        });
        return this;
	}

	public ComputeShaderManager generatePipeline()
	{
        // Create a compute pipeline
        var pipeline = rd.ComputePipelineCreate(shader);
        var computeList = rd.ComputeListBegin();
        rd.ComputeListBindComputePipeline(computeList, pipeline);

		for (int i = 0; i < inputDataSets.Count; i++)
		{
            rd.ComputeListBindUniformSet(computeList, inputDataSets[i].uniformSet, (uint)i);
        }

        rd.ComputeListDispatch(computeList, xGroups: 5, yGroups: 1, zGroups: 1);
        rd.ComputeListEnd();
        return this;
	}

    public void run()
    {
        // Submit to GPU and wait for sync
		rd.Submit();
		rd.Sync();

		// Read back the data from the buffers
		for (int i = 0; i < inputDataSets.Count; i++)
		{
            var outputBytes = rd.BufferGetData(inputDataSets[i].buffer);
            var output = new float[inputDataSets[i].inputLength];
            Buffer.BlockCopy(outputBytes, 0, output, 0, outputBytes.Length);
            GD.Print("Input: ", inputDataSets[i].inputString);
            GD.Print("Output: ", string.Join(", ", output));
        }
    }

	public class inputDataSet
	{
		public string inputString;
		public int inputLength;
		public Rid buffer;
		public Rid uniformSet;
	}
}
