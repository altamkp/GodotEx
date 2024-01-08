using Godot;

namespace GodotEx.Inputs;

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
    /// <returns>True if successfully handled, other false due to handler being disabled,
    /// input event type not matching <typeparamref name="TInputEvent"/>, or 
    /// predicate not satisfied.</returns>
    bool Handle(InputEvent @event);
}
