using Godot;

namespace GodotEx;

public static class Vector3Extensions {
    public static Vector3 SetX(this Vector3 vector, float x) => new(x, vector.Y, vector.Z);
    public static Vector3 SetY(this Vector3 vector, float y) => new(vector.X, y, vector.Z);
    public static Vector3 SetZ(this Vector3 vector, float z) => new(vector.X, vector.Y, z);

    public static Vector3 AddX(this Vector3 vector, float x) => vector + new Vector3(x, 0, 0);
    public static Vector3 AddY(this Vector3 vector, float y) => vector + new Vector3(0, y, 0);
    public static Vector3 AddZ(this Vector3 vector, float z) => vector + new Vector3(0, 0, z);

    public static Vector3 ScaleX(this Vector3 vector, float x) => new(vector.X * x, vector.Y, vector.Z);
    public static Vector3 ScaleY(this Vector3 vector, float y) => new(vector.X, vector.Y * y, vector.Z);
    public static Vector3 ScaleZ(this Vector3 vector, float z) => new(vector.X, vector.Y, vector.Z * z);

    public static (Vector3.Axis Axis, float length) Max(this Vector3 vector) {
        var axis = vector.MaxAxisIndex();
        return (axis, vector[(int)axis]);
    }

    public static (Vector3.Axis Axis, float length) Min(this Vector3 vector) {
        var axis = vector.MinAxisIndex();
        return (axis, vector[(int)axis]);
    }

    public static Vector3 Flip(this Vector3 vector) => -vector;
    public static Vector3 Trim(this Vector3 vector) => new(MathUtils.Trim(vector.X), MathUtils.Trim(vector.Y), MathUtils.Trim(vector.Z));

    public static Vector3 RadToDeg(this Vector3 vector) => vector * Mathf.Pi / 180f;
    public static Vector3 DegToRad(this Vector3 vector) => vector * 180f / Mathf.Pi;

    public static bool IsEqualApprox(this Vector3 a, Vector3 b, float precision) {
        return MathUtils.IsEqualApprox(a.X, b.X, precision) 
            && MathUtils.IsEqualApprox(a.Y, b.Y, precision)
            && MathUtils.IsEqualApprox(a.Z, b.Z, precision);
    }

    public static bool IsZeroApprox(this Vector3 vector, float precision) {
        return MathUtils.IsZeroApprox(vector.X, precision) 
            && MathUtils.IsZeroApprox(vector.Y, precision)
            && MathUtils.IsZeroApprox(vector.Z, precision);
    }

    public static Direction ToDirection(this Vector3 vector) {
        if (vector.IsEqualApprox(Vector3.Forward)) {
            return Direction.Forward;
        } else if (vector.IsEqualApprox(Vector3.Back)) {
            return Direction.Back;
        } else if (vector.IsEqualApprox(Vector3.Left)) {
            return Direction.Left;
        } else if (vector.IsEqualApprox(Vector3.Right)) {
            return Direction.Right;
        } else if (vector.IsEqualApprox(Vector3.Up)) {
            return Direction.Up;
        } else if (vector.IsEqualApprox(Vector3.Down)) {
            return Direction.Down;
        } else {
            throw new ArgumentException($"Vector {vector} is not orthogonal to the any of the axes.");
        }
    }
}
