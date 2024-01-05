using Godot;

namespace GodotEx;

public static class Vector2IExtensions {
    public static Vector2I SetX(this Vector2I vector, int x) => new(x, vector.Y);
    public static Vector2I SetY(this Vector2I vector, int y) => new(vector.X, y);

    public static Vector2I AddX(this Vector2I vector, int x) => vector + new Vector2I(x, 0);
    public static Vector2I AddY(this Vector2I vector, int y) => vector + new Vector2I(0, y);

    public static Vector2I ScaleX(this Vector2I vector, float x) => new(Mathf.RoundToInt(vector.X * x), vector.Y);
    public static Vector2I ScaleY(this Vector2I vector, float y) => new(vector.X, Mathf.RoundToInt(vector.Y * y));

    public static (Vector2I.Axis Axis, float length) Max(this Vector2I vector) {
        var axis = vector.MaxAxisIndex();
        return (axis, vector[(int)axis]);
    }

    public static (Vector2I.Axis Axis, float length) Min(this Vector2I vector) {
        var axis = vector.MinAxisIndex();
        return (axis, vector[(int)axis]);
    }

    public static Vector2I Flip(this Vector2I vector) => -vector;
}
