using Godot;

namespace GodotEx;

public static partial class InputEventExtensions {
    /// <summary>
    /// Checks if mouse left button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse left button is pressed.</returns>
    public static bool IsLeftClicked(this InputEvent @event) => @event.IsMouseClicked(MouseButton.Left);

    /// <summary>
    /// Checks if mouse left button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse left button is released.</returns>
    public static bool IsLeftLifted(this InputEvent @event) => @event.IsMouseLifted(MouseButton.Left);

    /// <summary>
    /// Checks if mouse right button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse right button is pressed.</returns>
    public static bool IsRightClicked(this InputEvent @event) => @event.IsMouseClicked(MouseButton.Right);

    /// <summary>
    /// Checks if mouse right button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse right button is released.</returns>
    public static bool IsRightLifted(this InputEvent @event) => @event.IsMouseLifted(MouseButton.Right);

    /// <summary>
    /// Checks if mouse middle button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse middle button is pressed.</returns>
    public static bool IsMiddleClicked(this InputEvent @event) => @event.IsMouseClicked(MouseButton.Middle);

    /// <summary>
    /// Checks if mouse middle button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse middle button is released.</returns>
    public static bool IsMiddleLifted(this InputEvent @event) => @event.IsMouseLifted(MouseButton.Middle);
}
