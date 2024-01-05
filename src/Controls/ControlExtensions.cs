using Godot;

namespace GodotEx;

public static class ControlExtensions {
    public static float DistanceTo(this Control control, Vector2 target) =>
        control.GlobalPosition.DistanceTo(target);

    public static float DistanceTo(this Control control, Control target) =>
        control.GlobalPosition.DistanceTo(target.GlobalPosition);
}
