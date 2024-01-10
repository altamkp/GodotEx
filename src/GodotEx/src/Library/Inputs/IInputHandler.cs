using Godot;

namespace GodotEx;

/// <summary>
/// Input handler interface
/// </summary>
public interface IInputHandler {
    /// <summary>
    /// Name of the handler.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Whether the input would be passed to its parent after it has been handled.
    /// </summary>
    bool Pass { get; }

    /// <summary>
    /// When disabled, the input event is not handled.
    /// </summary>
    bool Disabled { get; }

    /// <summary>
    /// Handles the given input event.
    /// </summary>
    /// <param name="event">Input event to handle.</param>
    /// <returns>True if successfully handled.</returns>
    bool Handle(InputEvent @event);
}
