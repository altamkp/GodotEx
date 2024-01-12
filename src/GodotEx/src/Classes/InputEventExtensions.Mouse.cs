using Godot;

namespace GodotEx;

public static partial class InputEventExtensions {
    /// <summary>
    /// Checks if mouse left button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse left button is pressed.</returns>
    public static bool IsMouseLeftPressed(this InputEvent @event) => @event.IsMousePressed(MouseButton.Left);

    /// <summary>
    /// Checks if mouse left button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse left button is released.</returns>
    public static bool IsMouseLeftReleased(this InputEvent @event) => @event.IsMouseReleased(MouseButton.Left);

    /// <summary>
    /// Checks if mouse right button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse right button is pressed.</returns>
    public static bool IsMouseRightPressed(this InputEvent @event) => @event.IsMousePressed(MouseButton.Right);

    /// <summary>
    /// Checks if mouse right button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse right button is released.</returns>
    public static bool IsMouseRightReleased(this InputEvent @event) => @event.IsMouseReleased(MouseButton.Right);

    /// <summary>
    /// Checks if mouse middle button is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse middle button is pressed.</returns>
    public static bool IsMouseMiddlePressed(this InputEvent @event) => @event.IsMousePressed(MouseButton.Middle);

    /// <summary>
    /// Checks if mouse middle button is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if mouse middle button is released.</returns>
    public static bool IsMouseMiddleReleased(this InputEvent @event) => @event.IsMouseReleased(MouseButton.Middle);
}
