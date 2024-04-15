shader_type canvas_item;
render_mode unshaded;

void fragment() {
	vec4 resultColor = vec4(UV.x, UV.y, 0, 1);
	COLOR = resultColor;
}
