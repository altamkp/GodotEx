using Godot;

namespace GodotEx;

public static partial class NodeExtensions {
    public static float GetGravity3D(this Node node) {
        return (float)ProjectSettings.GetSetting("physics/3d/default_gravity");
    }
}
