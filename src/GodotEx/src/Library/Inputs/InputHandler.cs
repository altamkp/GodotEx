using Godot;

namespace GodotEx;

/// <summary>
/// Handler class for handling input event of type <typeparamref name="TInputEvent"/>.
/// </summary>
/// <typeparam name="TInputEvent"></typeparam>
public class InputHandler<TInputEvent> : IInputHandler where TInputEvent : InputEvent {
    private readonly Func<TInputEvent, bool> _predicate;
    private readonly Action<TInputEvent> _handler;

    /// <summary>
    /// Constructs an new input handler object.
    /// </summary>
    /// <param name="name">Name of the handler.</param>
    /// <param name="pass">True input would be passed to its parent after it has been handled.</param>
    /// <param name="predicate">Predicate to satisfy upon handling input events.</param>
    /// <param name="handler">Handler to execute when predicate is satisfied.</param>
    public InputHandler(string name, bool pass, Func<TInputEvent, bool> predicate, Action<TInputEvent> handler) {
        Name = name;
        Pass = pass;
        _predicate = predicate;
        _handler = handler;
    }

    /// <summary>
    /// Name of the handler.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Whether the input would be passed to its parent after it has been handled.
    /// </summary>
    public bool Pass { get; }

    /// <summary>
    /// When disabled, the input event is not handled.
    /// </summary>
    public bool Disabled { get; set; } = false;

    /// <summary>
    /// Handles the given input event.
    /// </summary>
    /// <param name="event">Input event to handle.</param>
    /// <returns>True if successfully handled, otherwise false due to handler being disabled, input event 
    /// type not matching <typeparamref name="TInputEvent"/>, or predicate not satisfied.</returns>
    public bool Handle(InputEvent @event) {
        if (Disabled || @event is not TInputEvent tInputEvent || !_predicate(tInputEvent)) {
            return false;
        }
        _handler(tInputEvent);
        return true;
    }
}
