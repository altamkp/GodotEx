using Godot;

namespace GodotEx.RayCasts;

public class RayCastHit {
    public RayCastHit() { }

    public RayCastHit(Vector3? position,
                      Vector3? normal,
                      Node3D? collider,
                      string? colliderId,
                      Rid? rid,
                      int? shape) {
        Position = position;
        Normal = normal;
        Collider = collider;
        ColliderId = colliderId;
        Rid = rid;
        Shape = shape;
    }

    public Vector3? Position { get; }
    public Vector3? Normal { get; }

    public Node3D? Collider { get; }
    public string? ColliderId { get; }

    public Rid? Rid { get; }

    public int? Shape { get; }
}
