using Godot;

namespace GodotEx;

public static class Transform2DExtensions {
    public static Vector2 Right(this Transform2D transform) => transform.X.Normalized();
    public static Vector2 Left(this Transform2D transform) => -transform.X.Normalized();
    public static Vector2 Up(this Transform2D transform) => transform.Y.Normalized();
    public static Vector2 Down(this Transform2D transform) => -transform.Y.Normalized();
}
