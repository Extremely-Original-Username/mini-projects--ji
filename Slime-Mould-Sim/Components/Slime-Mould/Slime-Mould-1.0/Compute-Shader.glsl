#[compute]
#version 450

// Invocations in the (x, y, z) dimension
layout(local_size_x = 2, local_size_y = 1, local_size_z = 1) in;

// A binding to the buffer we create in our script
layout(set = 0, binding = 0, std430) restrict buffer MyDataBuffer1 {
    float data[];
}
my_data_buffer1;

// A binding to the buffer we create in our script
layout(set = 1, binding = 0, std430) restrict buffer MyDataBuffer2 {
    float data[];
}
my_data_buffer2;

// A binding to the buffer we create in our script
layout(set = 2, binding = 0, std430) restrict buffer MyDataBuffer3 {
    float data[];
}
my_data_buffer3;


// The code we want to execute in each invocation
void main() {
    // gl_GlobalInvocationID.x uniquely identifies this invocation across all work groups
    my_data_buffer1.data[gl_GlobalInvocationID.x] += 1.0;
    my_data_buffer2.data[gl_GlobalInvocationID.x] += 1.0;
    my_data_buffer3.data[gl_GlobalInvocationID.x] = my_data_buffer1.data[gl_GlobalInvocationID.x] + my_data_buffer2.data[gl_GlobalInvocationID.x];
}