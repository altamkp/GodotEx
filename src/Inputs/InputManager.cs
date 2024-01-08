using Godot;

namespace GodotEx.Inputs;

/// <summary>
/// Manager class for registering input events and handling them.
/// </summary>
public class InputManager {
    private static readonly Func<InputEvent, bool> TRUE = e => true;

    private readonly Dictionary<string, IInputHandler> _handlers = new();
    private readonly Viewport _viewport;

    public InputManager(Viewport viewport) {
        _viewport = viewport;
    }

    /// <summary>
    /// If true, calling <see cref="Handle(InputEvent)"/> has no effect.
    /// </summary>
    public bool Disabled { get; set; } = false;

    /// <summary>
    /// Adds input handler for InputEventMouseMotion. Since <see cref="InputEventMouseMotion"/> 
    /// does not support action, it should be handled specifically.
    /// </summary>
    /// <param name="handler">Handler to add.</param>
    public void AddMouseMotionHandler(string name, Action<InputEventMouseMotion> handler, bool pass = false) {
        if (_handlers.ContainsKey(name)) {
            throw new ArgumentException($"{name} has already been registered.");
        }
        _handlers.Add(name, new InputHandler<InputEventMouseMotion>(name, pass, TRUE, handler));
    }

    /// <summary>
    /// Adds input handler for InputEventMouseMotion, Since <see cref="InputEventMouseMotion"/>
    /// does not support action, it should be handled specifically.
    /// </summary>
    /// <param name="predicate"> Predicate if the handler should be used.</param>
    /// <param name="handler"></param>
    public void AddMouseMotionHandler(string name, Func<InputEventMouseMotion, bool> predicate, Action<InputEventMouseMotion> handler, bool pass = false) {
        if (_handlers.ContainsKey(name)) {
            throw new ArgumentException($"{name} has already been registered.");
        }
        _handlers.Add(name, new InputHandler<InputEventMouseMotion>(name, pass, predicate, handler));
    }

    /// <summary>
    /// Adds input handler for <see cref="InputEvent"/>, including <see cref="InputEventKey"/>, 
    /// <see cref="InputEventMouseButton"/>, <see cref="InputEventJoypadButton"/>,
    /// <see cref="InputEventJoypadMotion"/> and <see cref="InputEventAction"/>. 
    /// This would match both pressed and released event and ignore all modifiers.
    /// </summary>
    /// <typeparam name="TInputEvent">Type of <see cref="InputEvent"/> to handle.</typeparam>
    /// <param name="name">Name of the handler.</param>
    /// <param name="@event"><see cref="InputEvent"/> to match.</param>
    /// <param name="handler">Handler to call if input event matches successfully.</param>
    /// <exception cref="ArgumentException">If <see cref="InputEvent"/> is <see cref="InputEventMouseMotion"/> or the handler name has already been registered.</exception>
    public void AddHandler<TInputEvent>(string name, TInputEvent @event, Action<TInputEvent> handler, bool pass = false) where TInputEvent : InputEvent {
        if (@event is InputEventMouseMotion) {
            throw new ArgumentException($"Use AddMouseMotionInputHandler instead.");
        }
        if (_handlers.ContainsKey(name)) {
            throw new ArgumentException($"{name} has already been registered.");
        }
        _handlers.Add(name, new InputHandler<TInputEvent>(name, pass, e => e.IsMatch(@event, false), handler));
    }

    /// <summary>
    /// Adds input handler for <see cref="InputEvent"/>, including <see cref="InputEventKey"/>, 
    /// <see cref="InputEventMouseButton"/>, <see cref="InputEventJoypadButton"/>,
    /// <see cref="InputEventJoypadMotion"/> and <see cref="InputEventAction"/>. 
    /// This would match pressed or released event only depending on <paramref name="matchPressed"/>,
    /// and match modifiers depends on <paramref name="matchModifiers"/>.
    /// </summary>
    /// <typeparam name="TInputEvent">Type of <see cref="InputEvent"/> to handle.</typeparam>
    /// <param name="name">Name of the handler.</param>
    /// <param name="@event"><see cref="InputEvent"/> to match.</param>
    /// <param name="matchPressed">Match pressed specified in <paramref name="@event"/> if true, otherwise ignore pressed.</param>
    /// <param name="matchModifiers">Match modifier specified in <paramref name="@event"/> if true, otherwise ignore all modifiers.</param>
    /// <param name="handler">Handler to call if input event matches successfully.</param>
    /// <exception cref="ArgumentException">If <see cref="InputEvent"/> is <see cref="InputEventMouseMotion"/> or the handler name has already been registered.</exception>
    public void AddHandler<TInputEvent>(string name,
                                        TInputEvent @event,
                                        bool matchPressed,
                                        bool matchModifiers,
                                        Action<TInputEvent> handler,
                                        bool pass = false)
            where TInputEvent : InputEvent {
        if (@event is InputEventMouseMotion) {
            throw new ArgumentException($"Use AddMouseMotionInputHandler instead.");
        }
        if (_handlers.ContainsKey(name)) {
            throw new ArgumentException($"{name} has already been registered.");
        }

        Func<TInputEvent, bool> predicate = matchPressed
            ? e => e.IsPressed() == @event.IsPressed() && e.IsMatch(@event, matchModifiers)
            : e => e.IsMatch(@event, matchModifiers);
        _handlers.Add(name, new InputHandler<TInputEvent>(name, pass, predicate, handler));
    }

    /// <summary>
    /// Adds input handler for <see cref="InputEvent"/>, including <see cref="InputEventKey"/>, 
    /// <see cref="InputEventMouseButton"/>, <see cref="InputEventJoypadButton"/>,
    /// <see cref="InputEventJoypadMotion"/> and <see cref="InputEventAction"/>. 
    /// This would match all input events that match <paramref name="predicate"/>.
    /// </summary>
    /// <typeparam name="TInputEvent">Type of <see cref="InputEvent"/> to handle.</typeparam>
    /// <param name="name">Name of the handler.</param>
    /// <param name="predicate">Predicate which matches event to handle.</param>
    /// <param name="handler">Handler to call if input event matches successfully.</param>
    /// <exception cref="ArgumentException">If <see cref="InputEvent"/> is <see cref="InputEventMouseMotion"/> or the handler name has already been registered.</exception>
    public void AddHandler<TInputEvent>(string name, Func<TInputEvent, bool> predicate, Action<TInputEvent> handler, bool pass = false) where TInputEvent : InputEvent {
        if (typeof(TInputEvent) == typeof(InputEventMouseMotion)) {
            throw new ArgumentException($"Use AddMouseMotionInputHandler instead.");
        }
        if (_handlers.ContainsKey(name)) {
            throw new ArgumentException($"{name} has already been registered.");
        }

        _handlers.Add(name, new InputHandler<TInputEvent>(name, pass, predicate, handler));
    }

    /// <summary>
    /// Adds input handler.
    /// </summary>
    /// <param name="handler">Handler to add.</param>
    /// <exception cref="ArgumentException"></exception>
    public void AddHandler(IInputHandler handler) {
        if (!_handlers.TryAdd(handler.Name, handler)) {
            throw new ArgumentException($"{handler.Name} has already been registered.");
        }
    }

    /// <summary>
    /// Removes input handler with the given <paramref name="name"/>.
    /// </summary>
    /// <param name="name">Name of the handler to remove.</param>
    /// <exception cref="ArgumentException">Handler was not registered.</exception>
    public void RemoveHandler(string name) {
        if (!_handlers.Remove(name)) {
            throw new ArgumentException($"{name} was not registered.");
        }
    }

    /// <summary>
    /// Handles the provided <paramref name="@event"/>. This is normally used within override Godot input methods such as
    /// <see cref="Node._Input(InputEvent)"/>, <see cref="Node._UnhandledInput(InputEvent)"/>, <see cref="Control._GuiInput(InputEvent)"/> etc.
    /// </summary>
    /// <param name="@event">Input event to handle.</param>
    public void Handle(InputEvent @event) {
        if (Disabled) {
            return;
        }

        foreach (var (_, handler) in _handlers) {
            if (handler.Handle(@event) && !handler.Pass) {
                _viewport.SetInputAsHandled();
                return;
            }
        }
    }
}
