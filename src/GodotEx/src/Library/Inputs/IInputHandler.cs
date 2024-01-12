using Godot;

namespace GodotEx;

internal interface IInputHandler {
    string Name { get; }
    bool Pass { get; }
    bool Disabled { get; set; }

    bool Handle(InputEvent @event);
}
