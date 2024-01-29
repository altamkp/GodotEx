using Godot;

namespace GodotEx.Tests;

[Layer(PhysicsLayers3D.Player)]
[Mask(PhysicsLayers3D.Ground | PhysicsLayers3D.Obstacle)]
public partial class TestRigidBody : RigidBody3D {
    public override void _Ready() {
        this.SetLayers();
    }
}
