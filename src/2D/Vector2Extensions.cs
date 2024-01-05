using Godot;

namespace GodotEx;

public static class Vector2Extensions {
    public static Vector2 SetX(this Vector2 vector, float x) => new(x, vector.Y);
    public static Vector2 SetY(this Vector2 vector, float y) => new(vector.X, y);

    public static Vector2 AddX(this Vector2 vector, float x) => vector + new Vector2(x, 0);
    public static Vector2 AddY(this Vector2 vector, float y) => vector + new Vector2(0, y);

    public static Vector2 ScaleX(this Vector2 vector, float x) => new(vector.X * x, vector.Y);
    public static Vector2 ScaleY(this Vector2 vector, float y) => new(vector.X, vector.Y * y);

    public static (Vector2.Axis Axis, float length) Max(this Vector2 vector) {
        var axis = vector.MaxAxisIndex();
        return (axis, vector[(int)axis]);
    }

    public static (Vector2.Axis Axis, float length) Min(this Vector2 vector) {
        var axis = vector.MinAxisIndex();
        return (axis, vector[(int)axis]);
    }

    public static Vector2 Flip(this Vector2 vector) => -vector;
    public static Vector2 Trim(this Vector2 vector) => new(MathUtils.Trim(vector.X), MathUtils.Trim(vector.Y));

    public static Vector2 DegToRad(this Vector2 vector) => vector * Mathf.Pi / 180f;
    public static Vector2 RadToDeg(this Vector2 vector) => vector * 180f / Mathf.Pi;

    public static bool IsEqualApprox(this Vector2 a, Vector2 b, float precision) {
        return MathUtils.IsEqualApprox(a.X, b.X, precision) 
            && MathUtils.IsEqualApprox(a.Y, b.Y, precision);
    }

    public static bool IsZeroApprox(this Vector2 vector, float precision) {
        return MathUtils.IsZeroApprox(vector.X, precision) 
            && MathUtils.IsZeroApprox(vector.Y, precision);
    }
}
