using Godot;

namespace GodotEx;

public static partial class InputEventExtensions {
    /// <summary>
    /// Checks if keyboard W key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard W key is pressed.</returns>
    public static bool IsWPressed(this InputEvent @event) => @event.IsKeyPressed(Key.W);

    /// <summary>
    /// Checks if keyboard W key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard W key is released.</returns>
    public static bool IsWReleased(this InputEvent @event) => @event.IsKeyReleased(Key.W);

    /// <summary>
    /// Checks if keyboard A key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard A key is pressed.</returns>
    public static bool IsAPressed(this InputEvent @event) => @event.IsKeyPressed(Key.A);

    /// <summary>
    /// Checks if keyboard A key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard A key is released.</returns>
    public static bool IsAReleased(this InputEvent @event) => @event.IsKeyReleased(Key.A);

    /// <summary>
    /// Checks if keyboard S key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard S key is pressed.</returns>
    public static bool IsSPressed(this InputEvent @event) => @event.IsKeyPressed(Key.S);

    /// <summary>
    /// Checks if keyboard S key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard S key is released.</returns>
    public static bool IsSReleased(this InputEvent @event) => @event.IsKeyReleased(Key.S);

    /// <summary>
    /// Checks if keyboard D key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard D key is pressed.</returns>
    public static bool IsDPressed(this InputEvent @event) => @event.IsKeyPressed(Key.D);

    /// <summary>
    /// Checks if keyboard D key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard D key is released.</returns>
    public static bool IsDReleased(this InputEvent @event) => @event.IsKeyReleased(Key.D);

    /// <summary>
    /// Checks if keyboard up arrow key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard up arrow key is pressed.</returns>
    public static bool IsUpPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Up);

    /// <summary>
    /// Checks if keyboard up key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard up key is released.</returns>
    public static bool IsUpReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Up);

    /// <summary>
    /// Checks if keyboard down key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard down key is pressed.</returns>
    public static bool IsDownPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Down);

    /// <summary>
    /// Checks if keyboard down arrow key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard down arrow key is released.</returns>
    public static bool IsDownReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Down);

    /// <summary>
    /// Checks if keyboard left arrow key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard left arrow key is pressed.</returns>
    public static bool IsLeftPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Left);

    /// <summary>
    /// Checks if keyboard left arrow key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard left arrow key is released.</returns>
    public static bool IsLeftReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Left);

    /// <summary>
    /// Checks if keyboard right arrow key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard right arrow key is pressed.</returns>
    public static bool IsRightPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Right);

    /// <summary>
    /// Checks if keyboard right arrow key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard right arrow key is released.</returns>
    public static bool IsRightReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Right);

    /// <summary>
    /// Checks if keyboard space key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard space key is pressed.</returns>
    public static bool IsSpacePressed(this InputEvent @event) => @event.IsKeyPressed(Key.Space);

    /// <summary>
    /// Checks if keyboard space key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard space key is released.</returns>
    public static bool IsSpaceReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Space);

    /// <summary>
    /// Checks if keyboard shift key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard shift key is pressed.</returns>
    public static bool IsShiftPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Shift);

    /// <summary>
    /// Checks if keyboard shift key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard shift key is released.</returns>
    public static bool IsShiftReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Shift);

    /// <summary>
    /// Checks if keyboard ctrl key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard ctrl key is pressed.</returns>
    public static bool IsCtrlPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Ctrl);

    /// <summary>
    /// Checks if keyboard ctrl key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard ctrl key is released.</returns>
    public static bool IsCtrlReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Ctrl);

    /// <summary>
    /// Checks if keyboard alt key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard alt key is pressed.</returns>
    public static bool IsAltPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Alt);

    /// <summary>
    /// Checks if keyboard alt key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard alt key is released.</returns>
    public static bool IsAltReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Alt);

    /// <summary>
    /// Checks if keyboard esc key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard esc key is pressed.</returns>
    public static bool IsEscPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Escape);

    /// <summary>
    /// Checks if keyboard esc key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard esc key is released.</returns>
    public static bool IsEscReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Escape);
}
