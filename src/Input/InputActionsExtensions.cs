using Godot;

namespace GodotEx;

public static class InputActionsExtensions {
    public static bool IsPressed(this string action) {
        return Godot.Input.IsActionPressed(action);
    }

    public static bool IsJustPressed(this string action) {
        return Godot.Input.IsActionJustPressed(action);
    }
}
