using Godot;

namespace GodotEx;

public static class InputEventExtensions {
    public static bool IsLeftPressed(this InputEvent @event) {
        return @event.IsButtonPressed(MouseButton.Left);
    }

    public static bool IsLeftReleased(this InputEvent @event) {
        return @event.IsButtonReleased(MouseButton.Left);
    }

    public static bool IsRightPressed(this InputEvent @event) {
        return @event.IsButtonPressed(MouseButton.Right);
    }

    public static bool IsRightReleased(this InputEvent @event) {
        return @event.IsButtonReleased(MouseButton.Right);
    }

    public static bool IsMiddlePressed(this InputEvent @event) {
        return @event.IsButtonPressed(MouseButton.Middle);
    }

    public static bool IsMiddleReleased(this InputEvent @event) {
        return @event.IsButtonReleased(MouseButton.Middle);
    }

    public static bool IsButtonPressed(this InputEvent @event, MouseButton button) {
        return @event is InputEventMouseButton mButton && mButton.ButtonIndex == button && mButton.IsPressed();
    }

    public static bool IsButtonReleased(this InputEvent @event, MouseButton button) {
        return @event is InputEventMouseButton mButton && mButton.ButtonIndex == button && !mButton.IsPressed();
    }
}
