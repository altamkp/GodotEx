using Godot;

namespace GodotEx.Extensions;

public static class InputActionsExtensions {
    public static bool IsPressed(this string action) {
        return Input.IsActionPressed(action);
    }

    public static bool IsJustPressed(this string action) {
        return Input.IsActionJustPressed(action);
    }
}
