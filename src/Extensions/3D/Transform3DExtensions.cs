using Godot;

namespace GodotEx.Extensions;

public static class Transform3DExtensions {
    public static Vector3 Right(this Transform3D transform) => transform.Basis.X.Normalized();
    public static Vector3 Left(this Transform3D transform) => -transform.Basis.X.Normalized();
    public static Vector3 Up(this Transform3D transform) => transform.Basis.Y.Normalized();
    public static Vector3 Down(this Transform3D transform) => -transform.Basis.Y.Normalized();
    public static Vector3 Forward(this Transform3D transform) => transform.Basis.Z.Normalized();
    public static Vector3 Back(this Transform3D transform) => -transform.Basis.Z.Normalized();
}
