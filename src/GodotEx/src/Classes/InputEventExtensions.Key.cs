using Godot;

namespace GodotEx;

public static partial class InputEventExtensions {
    /// <summary>
    /// Checks if keyboard W key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard W key is pressed.</returns>
    public static bool IsWKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.W);

    /// <summary>
    /// Checks if keyboard W key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard W key is released.</returns>
    public static bool IsWKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.W);

    /// <summary>
    /// Checks if keyboard A key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard A key is pressed.</returns>
    public static bool IsAKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.A);

    /// <summary>
    /// Checks if keyboard A key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard A key is released.</returns>
    public static bool IsAKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.A);

    /// <summary>
    /// Checks if keyboard S key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard S key is pressed.</returns>
    public static bool IsSKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.S);

    /// <summary>
    /// Checks if keyboard S key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard S key is released.</returns>
    public static bool IsSKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.S);

    /// <summary>
    /// Checks if keyboard D key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard D key is pressed.</returns>
    public static bool IsDKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.D);

    /// <summary>
    /// Checks if keyboard D key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard D key is released.</returns>
    public static bool IsDKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.D);

    /// <summary>
    /// Checks if keyboard up arrow key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard up arrow key is pressed.</returns>
    public static bool IsUpKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Up);

    /// <summary>
    /// Checks if keyboard up key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard up key is released.</returns>
    public static bool IsUpKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Up);

    /// <summary>
    /// Checks if keyboard down key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard down key is pressed.</returns>
    public static bool IsDownKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Down);

    /// <summary>
    /// Checks if keyboard down arrow key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard down arrow key is released.</returns>
    public static bool IsDownKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Down);

    /// <summary>
    /// Checks if keyboard left arrow key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard left arrow key is pressed.</returns>
    public static bool IsLeftKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Left);

    /// <summary>
    /// Checks if keyboard left arrow key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard left arrow key is released.</returns>
    public static bool IsLeftKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Left);

    /// <summary>
    /// Checks if keyboard right arrow key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard right arrow key is pressed.</returns>
    public static bool IsRightKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Right);

    /// <summary>
    /// Checks if keyboard right arrow key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard right arrow key is released.</returns>
    public static bool IsRightKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Right);

    /// <summary>
    /// Checks if keyboard space key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard space key is pressed.</returns>
    public static bool IsSpaceKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Space);

    /// <summary>
    /// Checks if keyboard space key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard space key is released.</returns>
    public static bool IsSpaceKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Space);

    /// <summary>
    /// Checks if keyboard shift key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard shift key is pressed.</returns>
    public static bool IsShiftKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Shift);

    /// <summary>
    /// Checks if keyboard shift key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard shift key is released.</returns>
    public static bool IsShiftKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Shift);

    /// <summary>
    /// Checks if keyboard ctrl key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard ctrl key is pressed.</returns>
    public static bool IsCtrlKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Ctrl);

    /// <summary>
    /// Checks if keyboard ctrl key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard ctrl key is released.</returns>
    public static bool IsCtrlKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Ctrl);

    /// <summary>
    /// Checks if keyboard alt key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard alt key is pressed.</returns>
    public static bool IsAltKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Alt);

    /// <summary>
    /// Checks if keyboard alt key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard alt key is released.</returns>
    public static bool IsAltKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Alt);

    /// <summary>
    /// Checks if keyboard esc key is pressed.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard esc key is pressed.</returns>
    public static bool IsEscKeyPressed(this InputEvent @event) => @event.IsKeyPressed(Key.Escape);

    /// <summary>
    /// Checks if keyboard esc key is released.
    /// </summary>
    /// <param name="event">Input event to check.</param>
    /// <returns>True if keyboard esc key is released.</returns>
    public static bool IsEscKeyReleased(this InputEvent @event) => @event.IsKeyReleased(Key.Escape);
}
