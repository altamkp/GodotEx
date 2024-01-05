using Godot;

namespace GodotEx;

public static class PackedSceneExtensions {
    public static T Instantiate<T>(string path) where T : Node {
        return GD.Load<PackedScene>(path).Instantiate<T>();
    }

    public static T Create<T>(this PackedScene packedScene, Transform3D transform, Node3D parent) where T : Node3D {
        var created = packedScene.Instantiate<T>();
        parent.AddChild(created);
        created.Owner = parent;
        created.GlobalTransform = transform;
        return created;
    }

    public static T Create<T>(this PackedScene packedScene, Vector3 position, Node3D parent) where T : Node3D {
        var created = packedScene.Instantiate<T>();
        parent.AddChild(created);
        created.Owner = parent;
        created.GlobalPosition = position;
        return created;
    }

    public static T Create<T>(this PackedScene packedScene, Marker3D position, Node3D parent) where T : Node3D {
        return packedScene.Create<T>(position.GlobalTransform, parent);
    }

    public static T Create<T>(this PackedScene packedScene, Node parent) where T : Node {
        var created = packedScene.Instantiate<T>();
        parent.AddChild(created);
        created.Owner = parent;
        return created;
    }
}
