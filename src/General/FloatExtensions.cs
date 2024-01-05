using Godot;

namespace GodotEx;

public static class FloatExtensions {
	public static float Trim(this float value, int precision = 3) {
		var rounded = Mathf.Round(value);
		return Mathf.Abs(value - rounded) < Mathf.Pow(10, -precision) ? rounded : value;
	}
}
