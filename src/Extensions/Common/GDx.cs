using Godot;

namespace GodotEx;

/// <summary>
/// GodotEx's global functions.
/// </summary>
public static class GDx {
    /// <summary>
    /// Instantiates node from packed scene using its path.
    /// </summary>
    /// <typeparam name="T">Node type.</typeparam>
    /// <param name="path">Packed scene path.</param>
    /// <returns>Instantiated node of type <typeparamref name="T"/>.</returns>
    public static T Instantiate<T>(string path) where T : Node {
        return GD.Load<PackedScene>(path).Instantiate<T>();
    }
}
