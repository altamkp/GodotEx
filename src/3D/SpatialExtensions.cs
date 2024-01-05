using Godot;

namespace GodotEx;

public static class SpatialExtensions {
    public static bool IsInFrontOf(this Node3D other, Node3D spatial) {
        var direction = spatial.GlobalPosition.DirectionTo(other.GlobalPosition);
        return spatial.GlobalTransform.Forward().Dot(direction) > 0;
    }
}
