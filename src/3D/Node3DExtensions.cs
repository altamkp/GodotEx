using Godot;

namespace GodotEx;

public static class Node3DExtensions {
    public static Vector3 DirectionToVector(this Node3D spatial, Direction direction) => direction switch {
        Direction.Right => -spatial.GlobalTransform.Basis.X,
        Direction.Left => spatial.GlobalTransform.Basis.X,
        Direction.Forward => spatial.GlobalTransform.Basis.Z,
        Direction.Back => -spatial.GlobalTransform.Basis.Z,
        Direction.Up => spatial.GlobalTransform.Basis.Y,
        Direction.Down => -spatial.GlobalTransform.Basis.Y,
        _ => throw new ArgumentException($"Not expected direction value: {direction}."),
    };

    public static Vector3 DistanceProjectTo(this Node3D node3D, Vector3 target, Direction direction) =>
        (target - node3D.GlobalPosition).Project(node3D.DirectionToVector(direction));

    public static Vector3 DistanceProjectTo(this Node3D node3D, Node3D target, Direction direction) =>
    (target.GlobalPosition - node3D.GlobalPosition).Project(node3D.DirectionToVector(direction));

    public static float DistanceTo(this Node3D node3D, Vector3 target) =>
        node3D.GlobalPosition.DistanceTo(target);

    public static float DistanceTo(this Node3D node3D, Node3D target) =>
        node3D.GlobalPosition.DistanceTo(target.GlobalPosition);
}
