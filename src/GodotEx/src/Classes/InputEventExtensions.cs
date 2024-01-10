using Godot;

namespace GodotEx;

public static class InputEventExtensions {
    /// <summary>
    /// Checks if mouse left button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse left button is pressed.</returns>
    public static bool IsLeftPressed(this InputEvent @event) {
        return @event.IsButtonPressed(MouseButton.Left);
    }

    /// <summary>
    /// Checks if mouse left button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse left button is released.</returns>
    public static bool IsLeftReleased(this InputEvent @event) {
        return @event.IsButtonReleased(MouseButton.Left);
    }

    /// <summary>
    /// Checks if mouse right button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse right button is pressed.</returns>
    public static bool IsRightPressed(this InputEvent @event) {
        return @event.IsButtonPressed(MouseButton.Right);
    }

    /// <summary>
    /// Checks if mouse right button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse right button is released.</returns>
    public static bool IsRightReleased(this InputEvent @event) {
        return @event.IsButtonReleased(MouseButton.Right);
    }

    /// <summary>
    /// Checks if mouse middle button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse middle button is pressed.</returns>
    public static bool IsMiddlePressed(this InputEvent @event) {
        return @event.IsButtonPressed(MouseButton.Middle);
    }

    /// <summary>
    /// Checks if mouse middle button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse middle button is released.</returns>
    public static bool IsMiddleReleased(this InputEvent @event) {
        return @event.IsButtonReleased(MouseButton.Middle);
    }

    /// <summary>
    /// Checks if mouse <paramref name="button"/> is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <param name="button">Mouse button to compare to.</param>
    /// <returns>True if mouse <paramref name="button"/> is pressed.</returns>
    public static bool IsButtonPressed(this InputEvent @event, MouseButton button) {
        return @event is InputEventMouseButton mButton && mButton.ButtonIndex == button && mButton.IsPressed();
    }

    /// <summary>
    /// Checks if mouse <paramref name="button"/> is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <param name="button">Mouse button to compare to.</param>
    /// <returns>True if mouse <paramref name="button"/> is released.</returns>
    public static bool IsButtonReleased(this InputEvent @event, MouseButton button) {
        return @event is InputEventMouseButton mButton && mButton.ButtonIndex == button && !mButton.IsPressed();
    }
}
