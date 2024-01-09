using Godot;

namespace GodotEx.Extensions.Tests;

public partial class InstantiationTest : Node {
    public override void _Ready() {
        var image = GDx.New<TestImage>();
        var label = GDx.New<TestLabel>();

        AddChild(image);
        AddChild(label);
    }
}
