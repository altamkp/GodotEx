using Godot;
using System.Diagnostics;

namespace GodotEx;

public class InputManager {
    private const string MOUSE_MOTION = "MouseMotion";
    private static readonly Func<InputEvent, bool> TRUE = e => true;

    private readonly HashSet<string> _handlerNames = new();
    private readonly List<IInputHandler> _inputHandlers = new();
    private readonly Viewport _viewport;

    public InputManager(Viewport viewport) {
        _viewport = viewport;
    }

    /// <summary>
    /// Add input handler for InputEventMouseMotion, since InputEventMouseMotion does not support
    /// <see cref="InputEvent.IsMatch(InputEvent, bool)"/>, it should be handled .
    /// </summary>
    /// <param name="handler"></param>
    public void AddMouseMotionHandler(Action<InputEventMouseMotion> handler, bool pass = false) {
        _inputHandlers.Add(new InputHandler<InputEventMouseMotion>(MOUSE_MOTION, TRUE, handler, pass));
    }

    /// <summary>
    /// Add input handler for InputEventMouseMotion, since InputEventMouseMotion does not support action,
    /// it should be handled specifically.
    /// </summary>
    /// <param name="predicate"> Predicate if the handler should be used.</param>
    /// <param name="handler"></param>
    public void AddMouseMotionHandler(Func<InputEventMouseMotion, bool> predicate,
                                      Action<InputEventMouseMotion> handler,
                                      bool pass = false) {
        _inputHandlers.Add(new InputHandler<InputEventMouseMotion>(MOUSE_MOTION, predicate, handler, pass));
    }

    /// <summary>
    /// Add input handler for InputEvent, such InputEventKey, InputEventMouseButton, InputEventJoypadButton,
    /// InputEventJoyPadMotion and InputEventAction. This would match both pressed and released event and
    /// ignore all modifiers.
    /// </summary>
    /// <typeparam name="TInputEvent">the type of InputEvent to handler</typeparam>
    /// <param name="name">name of the handler</param>
    /// <param name="inputEvent">the inputEvent to match. </param>
    /// <param name="handler">the handler to call if inputEvent matches</param>
    /// <exception cref="ArgumentException">if inputEvent is InputEventMouseMotion or name has already been registered</exception>
    public void AddHandler<TInputEvent>(string name,
                                        TInputEvent inputEvent,
                                        Action<TInputEvent> handler,
                                        bool pass = false)
            where TInputEvent : InputEvent {
        if (inputEvent is InputEventMouseMotion) {
            throw new ArgumentException($"Use AddMouseMotionInputHandler instead.");
        }
        if (_handlerNames.Contains(name)) {
            throw new ArgumentException($"{name} has already been registered.");
        }

        _inputHandlers.Add(new InputHandler<TInputEvent>(name, e => e.IsMatch(inputEvent, false), handler, pass));
    }

    /// <summary>
    /// Add input handler for InputEvent, such InputEventKey, InputEventMouseButton, InputEventJoypadButton,
    /// InputEventJoyPadMotion and InputEventAction. This would match only pressed or released event depends
    /// on <paramref name="matchPressed"/> and match modifiers depends on <paramref name="matchModifiers"/>.
    /// </summary>
    /// <typeparam name="TInputEvent">the type of InputEvent to handler</typeparam>
    /// <param name="name">name of the handler</param>
    /// <param name="inputEvent">the inputEvent to match. </param>
    /// <param name="matchPressed">match pressed specified in <paramref name="inputEvent"/> if true, otherwise ignore pressed</param>
    /// <param name="matchModifiers">match modifier specified in <paramref name="inputEvent"/> if true, otherwise ignore all modifiers</param>
    /// <param name="handler">the handler to call if inputEvent matches</param>
    /// <exception cref="ArgumentException">if inputEvent is InputEventMouseMotion or name has already been registered</exception>
    public void AddHandler<TInputEvent>(string name,
                                        TInputEvent inputEvent,
                                        bool matchPressed,
                                        bool matchModifiers,
                                        Action<TInputEvent> handler,
                                        bool pass = false)
        where TInputEvent : InputEvent {
        if (inputEvent is InputEventMouseMotion) {
            throw new ArgumentException($"Use AddMouseMotionInputHandler instead.");
        }
        if (_handlerNames.Contains(name)) {
            throw new ArgumentException($"{name} has already been registered.");
        }

        Func<TInputEvent, bool> predicate = matchPressed
            ? e => e.IsPressed() == inputEvent.IsPressed() && e.IsMatch(inputEvent, matchModifiers)
            : e => e.IsMatch(inputEvent, matchModifiers);
        _inputHandlers.Add(new InputHandler<TInputEvent>(name, predicate, handler, pass));
    }

    /// <summary>
    /// Add input handler for InputEvent, such InputEventKey, InputEventMouseButton, InputEventJoypadButton,
    /// InputEventJoyPadMotion and InputEventAction. This would match all input events that match
    /// <paramref name="predicate"/>.
    /// </summary>
    /// <typeparam name="TInputEvent">the type of InputEvent to handler</typeparam>
    /// <param name="name">name of the handler</param>
    /// <param name="predicate">the predicate which matches event to handle</param>
    /// <param name="handler">the handler to call if inputEvent matches</param>
    /// <exception cref="ArgumentException">if inputEvent is InputEventMouseMotion or name has already been registered</exception>
    public void AddHandler<TInputEvent>(string name,
                                        Func<TInputEvent, bool> predicate,
                                        Action<TInputEvent> handler,
                                        bool pass = false)
            where TInputEvent : InputEvent {
        if (typeof(TInputEvent) == typeof(InputEventMouseMotion)) {
            throw new ArgumentException($"Use AddMouseMotionInputHandler instead.");
        }
        if (_handlerNames.Contains(name)) {
            throw new ArgumentException($"{name} has already been registered.");
        }

        _inputHandlers.Add(new InputHandler<TInputEvent>(name, predicate, handler, pass));
    }

    public void Handle(InputEvent inputEvent) {
        foreach (IInputHandler inputHandler in _inputHandlers) {
            if (inputHandler.Handle(inputEvent) && !inputHandler.Pass) {
                _viewport.SetInputAsHandled();
                return;
            }
        }
    }

    private interface IInputHandler {
        bool Pass { get; }

        bool Handle(InputEvent inputEvent);
    }

    [DebuggerDisplay("{Name}")]
    private class InputHandler<TInputEvent> : IInputHandler where TInputEvent : InputEvent {
        private readonly Func<TInputEvent, bool> _predicate;
        private readonly Action<TInputEvent> _handler;

        public InputHandler(string name, Func<TInputEvent, bool> predicate, Action<TInputEvent> handler, bool pass) {
            Name = name;
            _predicate = predicate;
            _handler = handler;
            Pass = pass;
        }

        public string Name { get; }

        public bool Pass { get; }

        public bool Handle(InputEvent inputEvent) {
            if (inputEvent is not TInputEvent tInputEvent) {
                return false;
            }

            if (!_predicate(tInputEvent)) {
                return false;
            }

            _handler(tInputEvent);
            return true;
        }
    }
}
