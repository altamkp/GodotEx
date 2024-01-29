using Godot;

namespace GodotEx.Tests;

public partial class LayerTest : Node {
    [NodePath]
    [Mask(PhysicsLayers3D.Player)]
    private Camera3D _camera;

    public override void _Ready() {
        this.Resolve();
        this.SetLayers();
    }
}
