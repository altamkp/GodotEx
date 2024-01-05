using Godot;

namespace GodotEx;

public static class Transform3DExtensions {
    public static Vector3 Right(this Transform3D transform) {
        return transform.Basis.X.Normalized();
    }

    public static Vector3 Left(this Transform3D transform) {
        return -transform.Basis.X.Normalized();
    }

    public static Vector3 Up(this Transform3D transform) {
        return transform.Basis.Y.Normalized();
    }

    public static Vector3 Down(this Transform3D transform) {
        return -transform.Basis.Y.Normalized();
    }

    public static Vector3 Forward(this Transform3D transform) {
        return transform.Basis.Z.Normalized();
    }

    public static Vector3 Back(this Transform3D transform) {
        return -transform.Basis.Z.Normalized();
    }

    public static Transform3D Flip(this Transform3D transform) {
        return transform.Rotated(Direction.Up);
    }

    public static Transform3D Rotated(this Transform3D transform, Direction direction) {
        (var axis, var angle) = direction.ToRotationVector(transform);
        return transform.Rotated(axis, angle);
    }
}
