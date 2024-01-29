namespace GodotEx.Tests;

public enum PhysicsLayers3D : uint {
    Ground = 1 << 0,
    Player = 1 << 1,
    Enemy = 1 << 2,
    Obstacle = 1 << 3,
}
